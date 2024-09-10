using IdentityModel.OidcClient;
using IPaking.Ultility;
using iParkingv5.ApiManager.interfaces;
using iParkingv5.ApiManager.KzParkingv5Apis;
using iParkingv5.Objects;
using Kztek.Helper;
using Kztek.Tool;
using Kztek.Tool.LogDatabases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Kztek.Tool.LogDatabases.tblSystemLog;
using static Kztek.Tools.LogHelper;

namespace iParkingv5.Auth
{
    public partial class frmLogin : Form
    {
        #region Properties
        private int waitTimeForLogin = 0;
        List<Control> activeControls = new List<Control>();
        public static Socket? socket_listener;
        private CancellationTokenSource? ctsSocket;
        private iParkingApi parkingApi;
        #endregion End Properties

        #region Forms
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //if (keyData == Keys.Return)
            //{
            //    if (btnLogin.Enabled)
            //        btnLogin_Click(null, null);
            //    return true;
            //}
            return base.ProcessCmdKey(ref msg, keyData);
        }
        OidcClient _oidcClient;
        private string refreshToken = "";
        Action completeAuthAction;
        public frmLogin(iParkingApi iParkingApi, string url, Action completeAuthAction, string scope)
        {
            InitializeComponent();
            this.parkingApi = iParkingApi;
            this.FormClosed += FrmLogin_FormClosed;
            this.completeAuthAction = completeAuthAction;
            this.Hide();
            lblStatus.Text = "";
            lblStatus.BackColor = Color.Transparent;
            if (File.Exists(PathManagement.tokenPath))
            {
                refreshToken = NewtonSoftHelper<string>.DeserializeObjectFromPath(PathManagement.tokenPath) ?? "";
            }
            string clientId = "910ae83b-5205-4c35-bf45-8926ff620386";
            KzParkingv5BaseApi.client_id = clientId;
            options = new OidcClientOptions
            {
                Authority = url.Replace(":5000", ":3000"),
                ClientId = clientId,
                //Scope = "openid role-data user-data parking-data offline_access device-data invoice-data project-data payment-data tenant-data",
                Scope = scope,
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
            Application.Exit();
            Environment.Exit(0);
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
                timerRefreshToken.Enabled = true;
                StartSocketServer();
                timerRestartSocket.Enabled = true;
                NewtonSoftHelper<string>.SaveConfig(loginResult.RefreshToken, PathManagement.tokenPath);
                this.refreshToken = loginResult.RefreshToken;
                KzParkingv5BaseApi.refresh_token = this.refreshToken;

                this.Hide();
                //KzParkingApiHelper.token = loginResult.TokenResponse.AccessToken;
                KzParkingv5BaseApi.token = loginResult.TokenResponse.AccessToken;
                await this.parkingApi.userService.GetUserInfor();
                completeAuthAction();
            }
        }

        #endregion End Forms

        #region Controls In Form
        private async void btnLogin_Click(object? sender, EventArgs e)
        {
        }
        #endregion End Controls In Form

        #region TIMER
        private async void timerAutoConnect_Tick(object sender, EventArgs e)
        {
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
                    KzParkingv5BaseApi.token = refreshToken.AccessToken;
                    NewtonSoftHelper<string>.SaveConfig(refreshToken.RefreshToken, PathManagement.tokenPath);
                    this.refreshToken = refreshToken.RefreshToken;
                    KzParkingv5BaseApi.refresh_token = refreshToken.RefreshToken;
                    timerRefreshToken.Enabled = true;
                    this.Hide();
                    await this.parkingApi.userService.GetUserInfor();
                    StartSocketServer();
                    timerRestartSocket.Enabled = true;
                    completeAuthAction.Invoke();
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
            }
        }
        private async void timerRefreshToken_Tick(object sender, EventArgs e)
        {
            timerRefreshToken.Enabled = false;
            try
            {
                if (this.refreshToken != KzParkingv5BaseApi.refresh_token)
                {
                    this.refreshToken = KzParkingv5BaseApi.refresh_token;
                    NewtonSoftHelper<string>.SaveConfig(this.refreshToken, PathManagement.tokenPath);
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                timerRefreshToken.Enabled = true;
            }
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
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.SOCKET, tblSystemLog.EmSystemActionDetail.UPDATE,
                                     "", ex);
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
            var LocalPort = port;
            var localEndPoint = new IPEndPoint(IPAddress.Any, LocalPort);
            socket_listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket_listener.Bind(localEndPoint);
                socket_listener.Listen(10);
                ctsSocket = new CancellationTokenSource();
                Task.Run(() => PollingReceiveSocketMessage(ctsSocket.Token));
            }
            catch (Exception ex)
            {
                tblSystemLog.SaveLog(EmSystemAction.SOCKET, EmSystemActionDetail.CREATE, "", ex);
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
                                string ParkingAppVersion = FileVersionInfo.GetVersionInfo(Path.Combine(PathManagement.baseBath, "iParkingv5_window.dll")).FileVersion!.ToString();
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
                    await MinioHelper.UploadFile(Path.GetFileName(file), file, StaticPool.selectedComputer == null ? Environment.MachineName :
                                                                                                                     StaticPool.selectedComputer.Name, time);
                }
            }
        }
    }
}
