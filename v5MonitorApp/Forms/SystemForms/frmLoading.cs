using iParkingv5.ApiManager.KzParkingv5Apis;
using iParkingv5.LprDetecter.LprDetecters;
using iParkingv5.Objects;
using iParkingv5.Objects.Datas.Devices;
using iParkingv6.ApiManager.KzParkingv3Apis;
using Kztek.Tool.NetworkTools;
using Kztek.Tools;
using v5MonitorApp;

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
        private List<Computer> computers = new List<Computer>();
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

            loadingWorks.Add("Tải thông tin máy tính", LoadPCConfig);
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
            this.FormClosing -= frmLoading_FormClosing;

            Form1 frm = new(this.computers)
            {
                Owner = this.Owner
            };
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
        #endregion End Forms

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
            lblMessage.Text = "Đang tải thông tin hệ thống, vui lòng chờ trong giây lát...";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;

            panelMessage.MinimumSize = new Size(0, lblMessage.Height);
            panelMessage.Size = new Size(0, lblMessage.Height);
            panelMessage.Font = lblMessage.Font;

            panelMessage.Controls.Add(lblMessage);
            lblMessage.Dock = DockStyle.Top;
        }
        ////--WORK
        private async Task<bool> LoadPCConfig()
        {
            currentDisplayIndex = 0;
            lblMessage!.Text = "Đang tải thông tin cấu hình máy tính, vui lòng chờ trong giấy lát";
            lblMessage.Refresh();
            displayMessages = CreateDisplayListMessage(lblMessage.Text);
            this.isWaiting = true;
            timer1.Enabled = true;
        GetPCConfig:
            {
                //computer = await KzParkingApiHelper.GetComputerByIPAddressAsync(Environment.MachineName);
                computers = (await AppData.ApiServer.GetComputersAsync()).Item1;
                if (computers == null)
                {
                    goto GetPCConfig;
                }
            }

            this.isWaiting = false;
            timer1.Enabled = false;

            GC.Collect();
            return true;
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
        #endregion End Private Function

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
        #endregion End Timer
    }
}
