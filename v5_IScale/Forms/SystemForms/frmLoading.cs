using IPaking.Ultility;
using iParkingv5.ApiManager.KzParkingv5Apis;
using iParkingv5.ApiManager.KzScaleApis;
using iParkingv5.LprDetecter.LprDetecters;
using iParkingv5.Objects;
using iParkingv5.Objects.ScaleObjects;
using iParkingv5_window;
using iParkingv6.ApiManager.KzParkingv3Apis;
using iParkingv6.Objects.Datas;
using IPGS.Ultility.TextFormats;
using Kztek.Scale_net6.Interfaces;
using Kztek.Scale_net6.Objects;
using Kztek.Tool;
using Kztek.Tool.NetworkTools;
using Kztek.Tools;
using Minio;

namespace v5_IScale.Forms.SystemForms
{
    public partial class frmLoading : Form
    {
        #region Properties
        public static string connectionStr = "";
        Dictionary<string, Func<Task<bool>>> loadingWorks = new Dictionary<string, Func<Task<bool>>>();
        private bool isWaiting = false;

        private List<string> displayMessages = new List<string>();
        private int currentDisplayIndex = 0;
        private bool isLoadingFalse;
        private Label? lblMessage;
        #endregion

        #region Forms
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public frmLoading()
        {
            InitializeComponent();

            CreatePanelTittle();
            CreatePanelBackground();
            CreatePanelMessage();

            loadingWorks.Add("Kết nối tới máy chủ lưu hình ảnh", CheckMinioConnection);
            loadingWorks.Add("Tải thông tin máy tính", LoadPCConfig);
            loadingWorks.Add("Tải thông tin cổng", LoadGates);
            loadingWorks.Add("Tải thông tin làn", LoadLanes);
            loadingWorks.Add("Tải thông tin bộ điều khiển", LoadControllers);
            loadingWorks.Add("Tải thông tin bảng led", LoadLeds);
            loadingWorks.Add("Tải thông tin camera", LoadCameras);
            loadingWorks.Add("Tải thông tin cân", LoadingWeighingHistory);
            //loadingWorks.Add("Khởi tạo KztekLPR", CreateKztLPR);

            loadingWorks.Add("Tải thông tin nhóm khách hàng", LoadCustomerGroup);
            this.Load += FrmLoading_Load;
        }
        private async void FrmLoading_Load(object? sender, EventArgs e)
        {
            if (File.Exists(PathManagement.scaleConfigPath))
            {
                AppData.ScaleConfig = NewtonSoftHelper<ScaleConfig>.DeserializeObjectFromPath(PathManagement.scaleConfigPath);
                KzScaleApiHelper.server = AppData.ScaleConfig.ScaleServer;
            }
            else
            {
                MessageBox.Show("NO OK");
            }

            foreach (KeyValuePair<string, Func<Task<bool>>> actions in loadingWorks)
            {
                try
                {
                    bool isSuccess = await actions.Value();
                    if (!isSuccess)
                    {
                        isLoadingFalse = false;
                        lblMessage!.Text = "Gặp Lỗi Khi " + actions.Key + " Vui Lòng Khởi Động Lại Ứng Dụng Và Thử Lại";
                        lblMessage.ForeColor = Color.DarkRed;
                        lblMessage.Refresh();
                        return;
                    }
                }
                catch
                {
                    throw;
                }

            }
            timer1.Enabled = false;
            this.FormClosing -= frmLoading_FormClosing;

            bool isNeedToChooseLane = false;

            Form1 frm = new(StaticPool.lanes)
            {
                Owner = this.Owner
            };
            frm.Show();
            frm.Show();

            this.Close();
            GC.Collect();
        }
        private void frmLoading_FormClosing(object? sender, FormClosingEventArgs e)
        {
            this.FormClosing -= frmLoading_FormClosing;
            Application.Exit();
            Environment.Exit(0);
        }
        #endregion

        #region Controls In Form
        private void LblCompanyName_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        #region Private Function
        //--CREATE FORMS
        private void CreatePanelTittle()
        {
            panelTittle.BackColor = SystemColors.ButtonHighlight;

            //LOGO
            Label lblCompanyName = new Label();
            lblCompanyName.AutoSize = false;
            lblCompanyName.Text = "iParking";
            lblCompanyName.TextAlign = ContentAlignment.MiddleCenter;
            lblCompanyName.MouseDown += LblCompanyName_MouseDown;

            panelTittle.MinimumSize = new Size(0, lblCompanyName.Height);
            panelTittle.Size = new Size(0, lblCompanyName.Height);
            panelTittle.Font = lblCompanyName.Font;

            panelTittle.Controls.Add(lblCompanyName);
            lblCompanyName.Dock = DockStyle.Fill;
            lblCompanyName.BringToFront();
        }
        private void CreatePanelBackground()
        {
            PictureBox picBackground = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            panelBackground.Controls.Add(picBackground);
            picBackground.Dock = DockStyle.Fill;
        }
        private void CreatePanelMessage()
        {
            lblMessage = new Label();
            lblMessage.AutoSize = false;
            lblMessage.SetKioskSecondary("Đang tải thông tin hệ thống, vui lòng chờ trong giây lát...",
                                        panelMessage.Width, panelMessage.Height, false);
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;

            panelMessage.MinimumSize = new Size(0, lblMessage.Height);
            panelMessage.Size = new Size(0, lblMessage.Height);
            panelMessage.Font = lblMessage.Font;

            panelMessage.Controls.Add(lblMessage);
            lblMessage.Dock = DockStyle.Top;
        }
        ////--WORK
        private async Task<bool> CheckMinioConnection()
        {
            try
            {
                MinioHelper.secure = false;
                MinioHelper.bucketName = "parking-images";

                currentDisplayIndex = 0;
                lblMessage!.Text = "Đang kết nối tới máy chủ lưu hình ảnh, vui lòng chờ trong giấy lát";
                lblMessage.Refresh();
                displayMessages = CreateDisplayListMessage(lblMessage.Text);
                this.isWaiting = true;
                timer1.Enabled = true;

                MinioClient minio = new MinioClient()
                                        .WithEndpoint(MinioHelper.EndPoint)
                                        .WithCredentials(MinioHelper.AccessKey, MinioHelper.SecretKey)
                                        .WithSSL(false)
                                        .Build();

                var getListBucketsTask = await minio.ListBucketsAsync().ConfigureAwait(false);
                timer1.Enabled = false;
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.System, obj: ex);
                timer1.Enabled = false;
                return false;
            }

        }
        private async Task<bool> LoadPCConfig()
        {
            currentDisplayIndex = 0;
            lblMessage!.Text = "Đang tải thông tin cấu hình máy tính, vui lòng chờ trong giấy lát";
            lblMessage.Refresh();
            displayMessages = CreateDisplayListMessage(lblMessage.Text);
            this.isWaiting = true;
            timer1.Enabled = true;
            Computer? computer = null;
        GetPCConfig:
            {
                List<string> validIps = NetWorkTools.GetLocalIPAddress();
                validIps.Add(Environment.MachineName);
                var computers = await AppData.ApiServer.GetComputersAsync();
                //computer = await KzParkingApiHelper.GetComputerByIPAddressAsync(Environment.MachineName);
                if (computers.Item1 == null)
                {
                    goto GetPCConfig;
                }
                foreach (var item in computers.Item1)
                {
                    foreach (var ip in validIps)
                    {
                        if (ip.Equals(item.IpAddress, StringComparison.CurrentCultureIgnoreCase))
                        {
                            computer = item;
                            break;
                        }
                    }
                    if (computer != null)
                    {
                        break;
                    }
                }
                if (computer == null)
                {
                    goto GetPCConfig;
                }
            }

            this.isWaiting = false;
            timer1.Enabled = false;

            if (computer == null)
            {
                MessageBox.Show("Không tìm thấy thông tin cấu hình máy tính trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            StaticPool.selectedComputer = computer;

            GC.Collect();
            return true;
        }

        private async Task<bool> LoadGates()
        {
            //StaticPool.gate = await KzParkingApiHelper.GetGateByIdAsync(StaticPool.selectedComputer.GateId);
            StaticPool.gate = (await  AppData.ApiServer.GetGateByIdAsync(StaticPool.selectedComputer.GateId)).Item1;
            return StaticPool.gate != null;
        }

        private async Task<bool> LoadCameras()
        {
            currentDisplayIndex = 0;
            lblMessage!.Text = "Đang tải thông tin cấu hình camera, vui lòng chờ trong giấy lát";
            lblMessage.Refresh();
            displayMessages = CreateDisplayListMessage(lblMessage.Text);
            this.isWaiting = true;
            timer1.Enabled = true;
            List<Camera>? cameras = null;
        GetCameraConfig:
            {
                //cameras = await KzParkingApiHelper.GetCameraByComputerIdAsync(StaticPool.selectedComputer.Id);
                cameras = (await  AppData.ApiServer.GetCameraByComputerIdAsync(StaticPool.selectedComputer.Id)).Item1;
                if (cameras == null)
                {
                    goto GetCameraConfig;
                }
            }

            this.isWaiting = false;
            timer1.Enabled = false;
            StaticPool.cameras = cameras;
            GC.Collect();
            return true;
        }

        private async Task<bool> LoadCustomerGroup()
        {
            StaticPool.customerGroupCollection = new iParkingv5.Objects.Datas.CustomerGroupCollection();

            //var customerGroups = await KzParkingApiHelper.GetAllCustomerGroups();
            var customerGroups = (await  AppData.ApiServer.GetCustomerGroupsAsync()).Item1;
            if (customerGroups != null)
            {
                foreach (var item in customerGroups)
                {
                    StaticPool.customerGroupCollection.Add(item);
                }
            }
            return true;
        }

        private async Task<bool> LoadLanes()
        {
            currentDisplayIndex = 0;
            lblMessage!.Text = "Đang tải thông tin cấu hình làn, vui lòng chờ trong giấy lát";
            lblMessage.Refresh();
            displayMessages = CreateDisplayListMessage(lblMessage.Text);
            this.isWaiting = true;
            timer1.Enabled = true;
            List<Lane>? laneByComputerIds = null;
        GetLaneConfig:
            {
                //laneByComputerIds = await KzParkingApiHelper.GetLanesAsync(StaticPool.selectedComputer.Id);
                laneByComputerIds = (await  AppData.ApiServer.GetLaneByComputerIdAsync(StaticPool.selectedComputer.Id)).Item1;
                if (laneByComputerIds == null)
                {
                    goto GetLaneConfig;
                }
            }

            this.isWaiting = false;
            timer1.Enabled = false;
            if (laneByComputerIds.Count == 0)
            {
                MessageBox.Show("Không tìm thấy thiết lập làn trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                foreach (var lane in laneByComputerIds)
                {
                    //Lane? _lane = await KzParkingApiHelper.GetLaneByIdAsync(lane.id);
                    Lane? _lane = (await  AppData.ApiServer.GetLaneByIdAsync(lane.id)).Item1;

                    if (_lane != null)
                    {
                        StaticPool.lanes.Add(_lane);
                    }
                }
                laneByComputerIds.Clear();
            }
            GC.Collect();
            return true;
        }

        private async Task<bool> LoadLeds()
        {
            currentDisplayIndex = 0;
            lblMessage!.Text = "Đang tải thông tin cấu hình led, vui lòng chờ trong giấy lát";
            lblMessage.Refresh();
            displayMessages = CreateDisplayListMessage(lblMessage.Text);
            this.isWaiting = true;
            timer1.Enabled = true;
            List<Led> leds = null;
        GetLedConfig:
            {
                //leds = await KzParkingApiHelper.GetLedsAsync(StaticPool.selectedComputer.Id);
                leds = (await  AppData.ApiServer.GetLedByComputerIdAsync(StaticPool.selectedComputer.Id)).Item1;
                if (leds == null)
                {
                    goto GetLedConfig;
                }
            }

            this.isWaiting = false;
            timer1.Enabled = false;
            StaticPool.leds = leds;
            GC.Collect();
            return true;
        }

        private async Task<bool> LoadControllers()
        {
            currentDisplayIndex = 0;
            lblMessage!.Text = "Đang tải thông tin cấu hình led, vui lòng chờ trong giấy lát";
            lblMessage.Refresh();
            displayMessages = CreateDisplayListMessage(lblMessage.Text);
            this.isWaiting = true;
            timer1.Enabled = true;
            List<Bdk> bdks = null;
        GetBDKConfig:
            {
                //bdks = await KzParkingApiHelper.GetControllerByPCId(StaticPool.selectedComputer.Id);
                bdks = (await  AppData.ApiServer.GetControlUnitByComputerIdAsync(StaticPool.selectedComputer.Id)).Item1;
                if (bdks == null)
                {
                    goto GetBDKConfig;
                }
            }

            this.isWaiting = false;
            timer1.Enabled = false;
            StaticPool.bdks = bdks;
            GC.Collect();
            return true;
        }

        private async Task<bool> LoadingWeighingHistory()
        {
            currentDisplayIndex = 0;
            lblMessage!.Text = "Đang tải thông tin cấu hình cân, vui lòng chờ trong giấy lát";
            lblMessage.Refresh();
            displayMessages = CreateDisplayListMessage(lblMessage.Text);
            this.isWaiting = true;
            timer1.Enabled = true;
            AppData.WeighingDetailCollection = new WeighingDetailCollection();
            List<WeighingAction> weighingHistory = null;
        GetWeighingInDayHistory:
            {
                DateTime startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                DateTime endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
                weighingHistory = await KzScaleApiHelper.GetWeighingActionDetails(startTime, endTime);
                if (weighingHistory == null)
                {
                    goto GetWeighingInDayHistory;
                }
            }

            this.isWaiting = false;
            timer1.Enabled = false;
            for (int i = 0; i < weighingHistory.Count; i++)
            {
                AppData.WeighingDetailCollection.Add(weighingHistory[i]);
            }
            weighingHistory.Clear();
            GC.Collect();
            return true;
        }

        private async Task<bool> CreateKztLPR()
        {
            currentDisplayIndex = 0;
            lblMessage!.Text = "Khởi tạo LPR Engine";
            lblMessage.Refresh();
            displayMessages = CreateDisplayListMessage(lblMessage.Text);
            this.isWaiting = true;
            timer1.Enabled = true;

            StaticPool.LprDetect = LprFactory.CreateLprDetecter(StaticPool.lprConfig, null);
            StaticPool.LprDetect?.CreateLpr(StaticPool.lprConfig);

            this.isWaiting = false;
            timer1.Enabled = false;
            return StaticPool.LprDetect != null;
        }

        private List<string> CreateDisplayListMessage(string message)
        {
            List<string> result = new List<string>
            {
                message,
                message + " .",
                message + " ..",
                message + " ..."
            };
            return result;
        }
        #endregion

        #region Timer
        private void timerUpdateWaitingMessage_Tick(object sender, EventArgs e)
        {
            if (this.isWaiting)
            {
                lblMessage!.Text = displayMessages[currentDisplayIndex];
                lblMessage.Refresh();
                currentDisplayIndex++;
                if (currentDisplayIndex > displayMessages.Count - 1)
                {
                    currentDisplayIndex = 0;
                }
            }
        }
        #endregion
    }
}
