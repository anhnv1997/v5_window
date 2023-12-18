using iParkingv5.Objects;
using iParkingv5_window.Forms.DataForms;
using iParkingv5_window.Properties;
using iParkingv6.ApiManager.KzParkingv3Apis;
using iParkingv6.Objects.Datas;
using IPGS.Object.Ultilities.Enums;
using IPGS.Ultility.TextFormats;
using Kztek.LPR;
using Kztek.Tool.NetworkTools;
using Kztek.Tools;
using Minio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace iParkingv5_window.Forms.SystemForms
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

            //loadingWorks.Add("Tải thông tin cấu hình hệ thống", LoadSystemConfig);
            //loadingWorks.Add("Kết nối tới máy chủ lưu hình ảnh", CheckMinioConnection);
            loadingWorks.Add("Tải thông tin máy tính", LoadPCConfig);
            loadingWorks.Add("Tải thông tin cổng", LoadGates);
            loadingWorks.Add("Tải thông tin làn", LoadLanes);
            loadingWorks.Add("Tải thông tin bộ điều khiển", LoadControllers);
            loadingWorks.Add("Tải thông tin bảng led", LoadLeds);
            loadingWorks.Add("Tải thông tin camera", LoadCameras);
            loadingWorks.Add("Khởi tạo KztekLPR", CreateKztLPR);
            this.Load += FrmLoading_Load;
        }

        private async void FrmLoading_Load(object? sender, EventArgs e)
        {
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
            frmMain frm = new()
            {
                Owner = this.Owner
            };
            frm.Show();
            this.Close();
            GC.Collect();
        }

        private void frmLoading_FormClosing(object sender, FormClosingEventArgs e)
        {
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
        //private async Task<bool> LoadSystemConfig()
        //{
        //    currentDisplayIndex = 0;
        //    lblMessage!.Text = "Đang tải thông tin cấu hình hệ thống, vui lòng chờ trong giấy lát";
        //    lblMessage.Refresh();
        //    displayMessages = CreateDisplayListMessage(lblMessage.Text);
        //    this.isWaiting = true;
        //    timer1.Enabled = true;
        //    SystemConfig systemConfig = null;
        //GetSystemConfig:
        //    {
        //        systemConfig = await KzParkingApiHelper.GetSystemConfigAsync();
        //        if (systemConfig == null)
        //        {
        //            goto GetSystemConfig;
        //        }
        //    }

        //    StaticPool.systemConfig = systemConfig;
        //    MinioHelper.EndPoint = "103.127.207.247:9000";//systemConfig.PhysicalFileSetting.Endpoint;
        //    MinioHelper.AccessKey = "kztek";// systemConfig.PhysicalFileSetting.AccessKey;
        //    MinioHelper.SecretKey = "Kztek123456";//systemConfig.PhysicalFileSetting.SecretKey;
        //    MinioHelper.secure = false;
        //    MinioHelper.bucketName = systemConfig.PhysicalFileSetting.ImageBucketName + "-va";

        //    this.isWaiting = false;
        //    timer1.Enabled = false;
        //    return true;
        //}
        private async Task<bool> CheckMinioConnection()
        {
            try
            {
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
            List<string> validIps = NetWorkTools.GetLocalIPAddress();
        GetPCConfig:
            {
                computer = await KzParkingApiHelper.GetComputerByIPAddressAsync(Environment.MachineName);
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
            StaticPool.gate = await KzParkingApiHelper.GetGateByIdAsync(StaticPool.selectedComputer.gateId);
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
                cameras = await KzParkingApiHelper.GetCameraByComputerIdAsync(StaticPool.selectedComputer.id);
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
        private async Task<bool> LoadLanes()
        {
            currentDisplayIndex = 0;
            lblMessage!.Text = "Đang tải thông tin cấu hình làn, vui lòng chờ trong giấy lát";
            lblMessage.Refresh();
            displayMessages = CreateDisplayListMessage(lblMessage.Text);
            this.isWaiting = true;
            timer1.Enabled = true;
            List<Lane> lanes = null;
        GetLaneConfig:
            {
                lanes = await KzParkingApiHelper.GetLanesAsync(StaticPool.selectedComputer.id);
                if (lanes == null)
                {
                    goto GetLaneConfig;
                }
            }

            this.isWaiting = false;
            timer1.Enabled = false;
            if (lanes.Count == 0)
            {
                MessageBox.Show("Không tìm thấy thiết lập làn trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            StaticPool.lanes = lanes.OrderBy(e => e.type).ToList();
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
                leds = await KzParkingApiHelper.GetLedsAsync(StaticPool.selectedComputer.id);
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
                bdks = await KzParkingApiHelper.GetControllerByPCId(StaticPool.selectedComputer.id);
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
        private async Task<bool> CreateKztLPR()
        {
            StaticPool.carANPR = new CarANPR();
            StaticPool.carANPR.NewError += KztekLPR_NewError;
            StaticPool.carANPR.LPREngineProductKey = "demo";
            StaticPool.carANPR.EnableLPREngine2 = true;
            StaticPool.carANPR.CreateLPREngine();

            StaticPool.motoANPR = new MotorANPR();
            StaticPool.carANPR.NewError += KztekLPR_NewError;
            StaticPool.carANPR.LPREngineProductKey = "demo";
            StaticPool.carANPR.EnableLPREngine2 = true;
            StaticPool.carANPR.CreateLPREngine();

            return true;
        }
        private void KztekLPR_NewError(object sender, Kztek.LPR.ErrorEventArgs e)
        {
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
        private void timer1_Tick(object sender, EventArgs e)
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
