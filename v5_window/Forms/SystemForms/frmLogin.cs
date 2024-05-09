using IdentityModel.OidcClient;
using IPaking.Ultility;
using iParkingv5.ApiManager.KzParkingv5Apis;
using iParkingv5.Objects;
using iParkingv5_window.Forms.DataForms;
using iParkingv6.ApiManager.KzParkingv3Apis;
using Kztek.Tool;
using Kztek.Tools;
using static Kztek.Tools.LogHelper;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Diagnostics;
using System.Reflection;

namespace iParkingv5_window.Forms.SystemForms
{
    public partial class frmLogin : Form
    {
        #region Properties
        private int waitTimeForLogin = 0;
        List<Control> activeControls = new List<Control>();
        public static Socket? socket_listener;
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
                StartSocketServer();
                timerRestartSocket.Enabled = true;
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

        private void FrmLogin_Load(object? sender, EventArgs e)
        {
            chbIsRemember.Checked = Properties.Settings.Default.isRemember;
            if (chbIsRemember.Checked)
            {
                txtUsername.Text = Properties.Settings.Default.username;
                txtPassword.Text = Properties.Settings.Default.password;
            }

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
            ucLoading1.Show("Đang đăng nhập hệ thống", frmMain.language);
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

                Properties.Settings.Default.isRemember = chbIsRemember.Checked;
                Properties.Settings.Default.username = txtUsername.Text;
                Properties.Settings.Default.password = txtPassword.Text;
                Properties.Settings.Default.Save();
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
                    StartSocketServer();
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
        private async void timerRestartSocket_Tick(object sender, EventArgs e)
        {
            try
            {
                timerRestartSocket.Enabled = false;
                ctsSocket?.Cancel();
                socket_listener?.Close();
                socket_listener?.Dispose();
                StartSocketServer();
            }
            catch (Exception ex)
            {
                Log(EmLogType.ERROR, EmObjectLogType.System,
                    hanh_dong: "frmMain ", noi_dung_hanh_dong: "Restart socker server",
                    obj: ex);
            }
            finally
            {
                timerRestartSocket.Enabled = true;
            }
        }
        #endregion END TIMER

        private void StartSocketServer()
        {
            int port = 100;
            // Get the IP addresses associated with the PC name
            //IPAddress[] ipAddressList = Dns.GetHostAddresses(Environment.MachineName);
            var LocalPort = port;
            var localEndPoint = new IPEndPoint(IPAddress.Any, LocalPort);
            socket_listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket_listener.Bind(localEndPoint);
                socket_listener.Listen(10);
                //isListening = true;
                ctsSocket = new CancellationTokenSource();
                Task.Run(() => PollingReceiveSocketMessage(ctsSocket.Token));
            }
            catch (Exception ex)
            {
                Log(EmLogType.ERROR, EmObjectLogType.System,
                    hanh_dong: "frmMain", noi_dung_hanh_dong: "Start Socket Server",
                    //mo_ta_them: ipAddressList,
                    obj: ex);
            }
        }
        private async Task PollingReceiveSocketMessage(CancellationToken ctsToken)
        {
            while (!ctsToken.IsCancellationRequested)
            {
                try
                {
                    int recv;
                    byte[] data = new byte[1024];
                    while (true)
                    {
                        var socket = socket_listener!.Accept();

                        #region: __________________________Receive command__________________________
                        data = new byte[1024];
                        recv = socket.Receive(data);
                        socket.Shutdown(SocketShutdown.Receive);
                        string receiceMessage = Encoding.ASCII.GetString(data, 0, recv);
                        #endregion

                        if (!string.IsNullOrEmpty(receiceMessage))
                        {
                            if (receiceMessage == "GetVersion?/")
                            {
                                string ParkingAppVersion = Assembly.GetExecutingAssembly().GetName().Version!.ToString();
                                string apiManagerVersion = FileVersionInfo.GetVersionInfo(Path.Combine(PathManagement.baseBath, "iParkingv5.ApiManager.dll")).FileVersion!.ToString();
                                string lprAIVersion = FileVersionInfo.GetVersionInfo(Path.Combine(PathManagement.baseBath, "NXT.Net6.LPR_AI.dll")).FileVersion!.ToString();
                                string response = "Parking App Version: " + ParkingAppVersion;
                                response += "\r\nApi Manager Version" + apiManagerVersion;
                                response += "\r\nLPR AI Version" + lprAIVersion;
                                socket.Send(Encoding.UTF8.GetBytes(response));
                            }
                            else if (receiceMessage == "RestartSoftware?/")
                            {
                                socket.Send(Encoding.UTF8.GetBytes("RestartSoftware?/OK"));
                                socket.Shutdown(SocketShutdown.Send);
                                Application.Restart();
                                Application.Exit();
                                Environment.Exit(0);
                                return;
                            }
                            else if (receiceMessage == "CheckUpdate?/")
                            {
                                bool isHaveUpdate = CheckForUpdate(out List<string> updateDetails);
                                socket.Send(Encoding.UTF8.GetBytes(isHaveUpdate ? "Có bản update:\r\n" + string.Join("\r\n", updateDetails.ToArray()) : "Phiên bản hiện tại đã là mới nhất"));
                            }
                            else if (receiceMessage.Contains("Support?/"))
                            {
                                string timeLog = receiceMessage.Substring(receiceMessage.IndexOf("/") + 1);
                                await GetLogFile(DateTime.Parse(timeLog));
                                socket.Send(Encoding.UTF8.GetBytes("Saved Log File To Minio"));
                            }
                            else if (receiceMessage == "ClearLog?/")
                            {
                                ClearLog();
                                socket.Send(Encoding.UTF8.GetBytes("Clear Completed"));
                            }
                        }
                        else
                        {
                            socket.Send(Encoding.UTF8.GetBytes("Received Empty Message"));
                        }
                        socket.Shutdown(SocketShutdown.Send);
                    }
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    GC.Collect();
                    await Task.Delay(500, ctsToken);
                }
            }
        }
        private static bool CheckForUpdate(out List<string> updateDetail)
        {
            updateDetail = new List<string>();
            if (string.IsNullOrEmpty(StaticPool.appOption.CheckForUpdatePath)) return false;

            if (!Directory.Exists(StaticPool.appOption.CheckForUpdatePath)) return false;

            try
            {
                bool isHavingUpdate = false;
                // Get all files in the specified path and its subdirectories
                string[] updatefiles = Directory.GetFiles(StaticPool.appOption.CheckForUpdatePath, "*", SearchOption.AllDirectories);
                List<string> realUpdateFiles = new List<string>();
                foreach (string file in updatefiles)
                {
                    realUpdateFiles.Add(Path.GetFileName(file));
                }

                string[] currentVersionFiles = Directory.GetFiles(Application.StartupPath, "*", SearchOption.AllDirectories);
                List<string> realCurrentFiles = new List<string>();
                foreach (string file in currentVersionFiles)
                {
                    string relativePath = file.Remove(0, Application.StartupPath.Length);
                    realCurrentFiles.Add(Path.GetFileName(file));
                }

                for (int i = 0; i < realUpdateFiles.Count; i++)
                {
                    string fileName = realUpdateFiles[i];
                    if (realCurrentFiles.Contains(fileName))
                    {
                        string currentFilePath = Path.Combine(Application.StartupPath, fileName);
                        string updateFilePath = updatefiles[i];

                        FileVersionInfo currentFileVersionInfo = FileVersionInfo.GetVersionInfo(currentFilePath);
                        string currentFilePathVersion = currentFileVersionInfo.FileVersion!;

                        FileVersionInfo updateFileVersionInfo = FileVersionInfo.GetVersionInfo(updateFilePath);
                        string updateFilePathVersion = updateFileVersionInfo.FileVersion!;

                        if (currentFilePathVersion != updateFilePathVersion)
                        {
                            updateDetail.Add(fileName + " " + currentFilePathVersion + " - UPDATE: " + updateFilePathVersion);
                            isHavingUpdate = true;
                        }
                        //update file text
                        else if (updateFilePathVersion == null && currentFilePathVersion == null)
                        {
                            System.IO.File.Delete(currentFilePath);
                            System.IO.File.Copy(updateFilePath, currentFilePath);
                        }
                    }
                    //THÊM FILE CHƯA CÓ
                    else
                    {
                        updateDetail.Add(fileName + " - ADD");
                        isHavingUpdate = true;
                    }
                }

                if (isHavingUpdate)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private void ClearLog()
        {
            string logDir = Path.Combine(PathManagement.baseBath, $@"logs");
            var files = Directory.GetFiles(PathManagement.baseBath, "*", SearchOption.AllDirectories);
            if (Directory.Exists(logDir))
            {
                var directories = Directory.GetDirectories(logDir);
                foreach (var directory in directories)
                {
                    try
                    {
                        Directory.Delete(directory, true);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            foreach (var file in files)
            {
                try
                {
                    if (file.Contains("_bak_"))
                    {
                        File.Delete(file);
                    }
                }
                catch (Exception)
                {
                }
            }
        }
        private async Task GetLogFile(DateTime time)
        {
            string dir = Path.Combine(PathManagement.baseBath, $@"logs\{time.Year}\{time.Month}\{time.Day}\");
            if (Directory.Exists(dir))
            {
                var files = Directory.GetFiles(dir);
                foreach (var file in files)
                {
                    await MinioHelper.UploadFile(Path.GetFileName(file), file, Environment.MachineName, time);
                }
            }
        }
    }
}
