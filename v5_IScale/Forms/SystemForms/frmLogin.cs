using IdentityModel.OidcClient;
using IPaking.Ultility;
using iParkingv5.ApiManager.KzParkingv5Apis;
using iParkingv5.Objects;
using iParkingv6.ApiManager.KzParkingv3Apis;
using Kztek.Tool;
using Kztek.Tools;
using v5_IScale.Usercontrols;
namespace v5_IScale.Forms.SystemForms
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

        private void FrmLogin_Load(object? sender, EventArgs e)
        {
            activeControls = new()
            {
                txtUsername,
                txtPassword,
                btnCancel1,
                btnLogin
            };
            ucNotify1.OnSelectResultEvent += UcNotify1_OnSelectResultEvent;

            panelMain.Padding = new Padding(StaticPool.baseSize);
            panelMain.Font = new Font(panelMain.Font.Name, StaticPool.baseSize);

            btnCancel1.InitControl(btnExit_Click);
            btnLogin.InitControl(btnLogin_Click);

            lblLoginTitle.Location = new Point(StaticPool.baseSize * 2,
                                               picLogo.Location.Y + picLogo.Height + StaticPool.baseSize * 2);

            lblUsername.Location = new Point(lblLoginTitle.Location.X,
                                             lblLoginTitle.Location.Y + lblLoginTitle.Height + StaticPool.baseSize);
            txtUsername.Location = new Point(lblUsername.Location.X + lblUsername.Width + StaticPool.baseSize,
                                             lblUsername.Location.Y + (lblUsername.Height - txtUsername.Height) / 2);
            txtUsername.Width = panelMain.Width - txtUsername.Location.X - StaticPool.baseSize * 2;

            txtPassword.Location = new Point(txtUsername.Location.X,
                                             txtUsername.Location.Y + txtUsername.Height + StaticPool.baseSize / 2);
            txtPassword.Width = txtUsername.Width;
            lblPassword.Location = new Point(lblUsername.Location.X,
                                             txtPassword.Location.Y + (txtPassword.Height - lblPassword.Height) / 2);

            chbIsRemember.Location = new Point(txtPassword.Location.X,
                                               txtPassword.Location.Y + txtPassword.Height + StaticPool.baseSize / 2);

            this.Height = chbIsRemember.Location.Y + chbIsRemember.Height + btnCancel1.Height + StaticPool.baseSize * 3 + this.Height - this.DisplayRectangle.Height;

            btnCancel1.Location = new Point(panelMain.Width - btnCancel1.Width - StaticPool.baseSize * 2,
                                            chbIsRemember.Location.Y + chbIsRemember.Height + StaticPool.baseSize);

            btnLogin.Location = new Point(btnCancel1.Location.X - btnLogin.Width - StaticPool.baseSize / 2,
                                          btnCancel1.Location.Y);

            lblStatus.Location = new Point(lblLoginTitle.Location.X,
                                           btnLogin.Location.Y + (btnLogin.Height - lblStatus.Height) / 2);

            timerAutoConnect.Enabled = true;
            if (File.Exists(Application.StartupPath + @"Resources\defaultImage.png"))
            {
                picLogo.Image = Image.FromFile(Application.StartupPath + @"Resources\logo.png");
            }

            this.ActiveControl = btnLogin;
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
                var tokenResponse = await KzParkingApiHelper.GetToken(txtUsername.Text, txtPassword.Text);
                string token = tokenResponse.Item1;
                panelMain.SuspendLayout();
                ucLoading1.HideLoading();
                if (string.IsNullOrEmpty(token))
                {
                    ucNotify1.Show(Usercontrols.BuildControls.ucNotify.EmNotiType.Error, tokenResponse.Item2);
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

                KzParkingApiHelper.StartPollingAuthorize();

                this.Hide();
                frmLoading frm = new()
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
                    timerRefreshToken.Enabled = true;
                    NewtonSoftHelper<string>.SaveConfig(refreshToken.RefreshToken, PathManagement.tokenPath);
                    this.refreshToken = refreshToken.RefreshToken;
                    this.Hide();
                    await KzParkingv5ApiHelper.GetUserInfor();

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
        #endregion END TIMER

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
    }
}