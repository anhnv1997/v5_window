using IdentityModel.OidcClient;
using IPaking.Ultility;
using iParkingv5.ApiManager.KzParkingv5Apis;
using iParkingv5.ApiManager.KzScaleApis;
using iParkingv5.Objects;
using IParkingv5.RegisterCard.Forms;
using iParkingv6.ApiManager.KzParkingv3Apis;
using Kztek.Tool;
using Kztek.Tools;
namespace IParkingv5.RegisterCard
{
    public partial class frmLogin : Form
    {
        #region Properties
        private int waitTimeForLogin = 0;
        List<Control> activeControls = new List<Control>();
        private CancellationTokenSource? ctsSocket;
        #endregion End Properties

        #region Forms
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Return)
            {
                if (btnLogin.Enabled)
                    btnLogin_Click(null, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        OidcClient _oidcClient;
        private string refreshToken = "";
        public frmLogin()
        {
            InitializeComponent();
            this.FormClosed += FrmLogin_FormClosed;
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
            string clientId = "910ae83b-5205-4c35-bf45-8926ff620386";
            KzParkingv5ApiHelper.client_id = clientId;
            options = new OidcClientOptions
            {
                Authority = KzParkingv5ApiHelper.server.Replace(":5000", ":3000"),//"http://192.168.21.13:3000",// 
                ClientId = clientId,
                Scope = "openid role-data user-data parking-data offline_access device-data invoice-data project-data payment-data tenant-data warehouse-data",
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
        }
        OidcClientOptions options = null;
        private void FrmLogin_FormClosed(object? sender, FormClosedEventArgs e)
        {
            //Application.Restart();
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
                KzParkingv5ApiHelper.refresh_token = this.refreshToken;

                this.Hide();
                //KzParkingApiHelper.token = loginResult.TokenResponse.AccessToken;
                KzParkingv5ApiHelper.token = loginResult.TokenResponse.AccessToken;
                await AppData.ApiServer.GetUserInfor();
                frmMain frm = new()
                {
                    Owner = this
                };
                frm.Show();
            }
        }
        #endregion End Forms

        #region Controls In Form
        private async void btnLogin_Click(object? sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            lblStatus.Visible = false;
            timerAutoConnect.Enabled = false;

            panelMain.SuspendLayout();
            panelMain.BackColor = Color.FromArgb((int)(0.37 * 255), 42, 47, 48);

            foreach (var item in activeControls)
            {
                //item.Visible = false;
                try
                {
                    item.BackColor = Color.FromArgb((int)(0.37 * 255), 42, 47, 48);
                }
                catch (Exception)
                {
                    item.Visible = false;
                }
            }
            ucLoading1.Show("Đang đăng nhập hệ thống", 0);
            panelMain.ResumeLayout();
            Application.DoEvents();

            try
            {
                await Task.Delay(500);
                var tokenResponse = Tuple.Create<string, string>("", "");// await KzParkingApiHelper.GetToken(txtUsername.Text, txtPassword.Text);
                string token = tokenResponse.Item1;
                panelMain.SuspendLayout();
                ucLoading1.HideLoading();
                if (string.IsNullOrEmpty(token))
                {
                    //ucNotify1.Show(Usercontrols.BuildControls.ucNotify.EmNotiType.Error, tokenResponse.Item2);
                    return;
                }
                else
                {
                    panelMain.BackColor = Color.White;
                    foreach (var item in activeControls)
                    {
                        item.Visible = true;
                    }
                }
                panelMain.ResumeLayout();
                Application.DoEvents();
                await Task.Delay(500);

                //KzParkingApiHelper.StartPollingAuthorize();

                Properties.Settings.Default.isRemember = chbIsRemember.Checked;
                Properties.Settings.Default.username = txtUsername.Text;
                Properties.Settings.Default.password = txtPassword.Text;
                Properties.Settings.Default.Save();
                this.Hide();
                frmMain frm = new()
                {
                    Owner = this
                };
                frm.Show();
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.System, obj: ex);
                MessageBox.Show("Gặp lỗi trong quá trình xử lý, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                btnLogin.Enabled = true;
            }
        }

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
                    KzScaleApiHelper.token = refreshToken.AccessToken;
                    NewtonSoftHelper<string>.SaveConfig(refreshToken.RefreshToken, PathManagement.tokenPath);
                    this.refreshToken = refreshToken.RefreshToken;
                    KzParkingv5ApiHelper.refresh_token = refreshToken.RefreshToken;
                    timerRefreshToken.Enabled = true;
                    this.Hide();
                    await AppData.ApiServer.GetUserInfor();
                    frmMain frm = new()
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
            try
            {
                if (this.refreshToken != KzParkingv5ApiHelper.refresh_token)
                {
                    this.refreshToken = KzParkingv5ApiHelper.refresh_token;
                    NewtonSoftHelper<string>.SaveConfig(this.refreshToken, PathManagement.tokenPath);
                }
                //var refreshToken = await _oidcClient.RefreshTokenAsync(this.refreshToken);
                //if (refreshToken != null)
                //{
                //    if (!refreshToken.IsError)
                //    {
                //        KzParkingv5ApiHelper.token = refreshToken.AccessToken;
                //        if (this.refreshToken != refreshToken.RefreshToken)
                //        {
                //            this.refreshToken = refreshToken.RefreshToken;
                //        }
                //        NewtonSoftHelper<string>.SaveConfig(refreshToken.RefreshToken, PathManagement.tokenPath);
                //    }
                //}
            }
            catch (Exception ex)
            {
            }
            finally
            {
                timerRefreshToken.Enabled = true;
            }
        }
        #endregion END TIMER
    }
}
