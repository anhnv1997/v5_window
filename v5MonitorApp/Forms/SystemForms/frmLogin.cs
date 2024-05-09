using IdentityModel.OidcClient;
using IPaking.Ultility;
using iParkingv5.ApiManager.KzParkingv5Apis;
using iParkingv5.Objects;
using iParkingv6.ApiManager.KzParkingv3Apis;
using Kztek.Tool;
using Kztek.Tools;
using static Kztek.Tools.LogHelper;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using v5MonitorApp.UserControls;

namespace iParkingv5_window.Forms.SystemForms
{
    public partial class frmLogin : Form
    {
        #region Properties
        private int waitTimeForLogin = 0;
        List<Control> activeControls = new List<Control>();
        #endregion End Properties

        #region Forms
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Return)
            {
                if (btnLogin.Enabled)
                    //btnLogin_Click(null, null);
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        OidcClient _oidcClient;
        private string refreshToken = "";
        public frmLogin()
        {
            InitializeComponent();
            this.Hide();
            lblStatus.Text = "";
            lblStatus.BackColor = Color.Transparent;
            if (File.Exists(PathManagement.tokenPath))
            {
                refreshToken = NewtonSoftHelper<string>.DeserializeObjectFromPath(PathManagement.tokenPath) ?? "";
                if (!string.IsNullOrEmpty(refreshToken))
                {
                    timerAutoConnect.Enabled = true;
                }
            }
            var options = new OidcClientOptions
            {
                Authority = KzParkingv5ApiHelper.server.Replace(":5000", ":3000"),// "http://14.160.26.45:3000",
                ClientId = "910ae83b-5205-4c35-bf45-8926ff620386",
                Scope = "openid role-data user-data parking-data offline_access device-data",
                RedirectUri = "http://localhost/winforms.client",
                Browser = new WinFormsWebView(webView21, this),
                Policy = new Policy
                {
                    Discovery = new IdentityModel.Client.DiscoveryPolicy
                    {
                        RequireHttps = false,
                        ValidateIssuerName = false
                    },
                },

            };

            _oidcClient = new OidcClient(options);

            Login();

            //this.Load += FrmLogin_Load;
        }
        LoginResult loginResult;
        private async void Login()
        {
            try
            {
                loginResult = await _oidcClient.LoginAsync();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
            timerAutoConnect.Enabled = false;
            if (loginResult.IsError)
            {
                MessageBox.Show(this, loginResult.Error, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                timerRefreshToken.Enabled = true;
                NewtonSoftHelper<string>.SaveConfig(loginResult.RefreshToken, PathManagement.tokenPath);
                this.refreshToken = loginResult.RefreshToken;
                this.Hide();
                //KzParkingApiHelper.token = loginResult.TokenResponse.AccessToken;
                KzParkingv5ApiHelper.token = loginResult.TokenResponse.AccessToken;
                await KzParkingv5ApiHelper.GetUserInfor();
                frmLoading frm = new()
                {
                    Owner = this
                };
                frm.Show();
            }
        }


        #endregion End Forms

        #region Controls In Form
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            lblStatus.Visible = false;
            timerAutoConnect.Enabled = false;
        }

        private void Control_Click(object sender, EventArgs e)
        {
            lblStatus.Visible = false;
            timerAutoConnect.Enabled = false;
        }

        private void chbIsRemember_CheckedChanged(object sender, EventArgs e)
        {
            lblStatus.Visible = false;
            timerAutoConnect.Enabled = false;
        }
        private void UcNotify1_OnSelectResultEvent(DialogResult result)
        {
            panelMain.BackColor = Color.White;
            foreach (var item in activeControls)
            {
                item.Visible = true;
            }
        }

        private void btnExit_Click(object? sender, EventArgs e)
        {
            lblStatus.Visible = false;
            timerAutoConnect.Enabled = false;
            Application.Exit();
            Environment.Exit(0);
        }
        #endregion End Controls In Form

        #region TIMER
        private async void timerAutoConnect_Tick(object sender, EventArgs e)
        {
            timerAutoConnect.Enabled = false;

            waitTimeForLogin++;
            if (waitTimeForLogin > 30)
            {
                var refreshToken = await _oidcClient.RefreshTokenAsync(this.refreshToken);
                if (refreshToken == null)
                {
                    lblStatus.Text = "Gặp lỗi khi kết nối tới server";
                    NewtonSoftHelper<string>.SaveConfig("", PathManagement.tokenPath);
                }
                if (!refreshToken.IsError)
                {
                    lblStatus.Text = "Đăng nhập thành công";
                    KzParkingv5ApiHelper.token = refreshToken.AccessToken;
                    timerRefreshToken.Enabled = true;
                    NewtonSoftHelper<string>.SaveConfig(refreshToken.RefreshToken, PathManagement.tokenPath);
                    this.refreshToken = refreshToken.RefreshToken;
                    this.Hide();
                    await KzParkingv5ApiHelper.GetUserInfor();
                    timerRestartSocket.Enabled = true;
                    frmLoading frm = new()
                    {
                        Owner = this
                    };
                    frm.Show();
                }
                else
                {
                    lblStatus.Text = "Đăng nhập không thành công";
                    NewtonSoftHelper<string>.SaveConfig("", PathManagement.tokenPath);
                }
            }
            else
            {
                lblStatus.Visible = true;
                lblStatus.Text = "Tự động đăng nhập sau: " + (30 - waitTimeForLogin) + "s";
                lblStatus.Refresh();
                timerAutoConnect.Enabled = true;
            }
        }
        private async void timerRefreshToken_Tick(object sender, EventArgs e)
        {
            timerRefreshToken.Enabled = false;
            var refreshToken = await _oidcClient.RefreshTokenAsync(this.refreshToken);
            if (refreshToken != null)
            {
                if (!refreshToken.IsError)
                {
                    KzParkingv5ApiHelper.token = refreshToken.AccessToken;
                    NewtonSoftHelper<string>.SaveConfig(refreshToken.RefreshToken, PathManagement.tokenPath);
                }
            }

            timerRefreshToken.Enabled = true;
        }
        #endregion END TIMER
    }
}
