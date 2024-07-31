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
            }
            var options = new OidcClientOptions
            {
                Authority = KzParkingv5BaseApi.server.Replace(":5000", ":3000"),// "http://14.160.26.45:3000",
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
            if (loginResult.IsError)
            {
                MessageBox.Show(this, loginResult.Error, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                NewtonSoftHelper<string>.SaveConfig(loginResult.RefreshToken, PathManagement.tokenPath);
                this.refreshToken = loginResult.RefreshToken;
                this.Hide();
                //KzParkingApiHelper.token = loginResult.TokenResponse.AccessToken;
                KzParkingv5BaseApi.token = loginResult.TokenResponse.AccessToken;
                await AppData.ApiServer.GetUserInforAsync();
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
        }

        private void Control_Click(object sender, EventArgs e)
        {
            lblStatus.Visible = false;
        }

        private void chbIsRemember_CheckedChanged(object sender, EventArgs e)
        {
            lblStatus.Visible = false;
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
            Application.Exit();
            Environment.Exit(0);
        }
        #endregion End Controls In Form

        #region TIMER
        #endregion END TIMER
    }
}
