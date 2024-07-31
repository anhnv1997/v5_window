using IdentityModel.OidcClient;
using iParkingv5.ApiManager.KzParkingv5Apis;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Core;
using iParkingv5_window.Forms;
using iParkingv5.ApiManager;
using iParkingv5.Objects.Databases;
using iParkingv5.Lpr.Objects;
using iParkingv5.Objects.Configs;
using iParkingv5.Objects;
using iParkingv6.ApiManager.KzParkingv3Apis;
using Kztek.Tool;
using iParkingv5.Objects.Datas.parking;

namespace iParkingv5.FeeTest
{
    public partial class Form1 : Form
    {
        OidcClient _oidcClient;
        OidcClientOptions options = null;
        string token = null;
        public static iParkingApi ApiServer = new KzParkingv5ApiHelper();
        private List<IdentityGroup> IdentityGroups = new List<IdentityGroup>();
        public static string pathBase = Application.StartupPath;
         
        public Form1()
        {
            InitializeComponent();

            LoadSystemConfig();
            //KzParkingv5ApiHelper.server = "http://103.127.207.247:5000";

            //KzParkingv5BaseApi.server = "http://10.10.0.103:5000";
            string clientId = "910ae83b-5205-4c35-bf45-8926ff620386";
            KzParkingv5BaseApi.client_id = clientId;

            options = new OidcClientOptions
            {
                Authority = KzParkingv5BaseApi.server.Replace(":5000", ":3000").Replace("api.", "oauth."),
                ClientId = clientId,
                Scope = "openid role-data user-data parking-data offline_access device-data invoice-data project-data payment-data tenant-data warehouse-data reporting-data",
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
                token = loginResult.TokenResponse.AccessToken;
                KzParkingv5BaseApi.token = loginResult.TokenResponse.AccessToken;

                frmFeeCalculate frm = new()
                {
                    Owner = this
                };
                frm.Show();
            }
        }
        private static void LoadSystemConfig()
        {
            try
            {
                string path = Path.Combine(Application.StartupPath, "configs/app/server.txt");
                //string path2 = Path.Combine(Application.StartupPath, PathManagement.serverConfigPath);
                StaticPool.serverConfig = NewtonSoftHelper<ServerConfig>.DeserializeObjectFromPath(path);
                if (StaticPool.serverConfig == null)
                {
                    MessageBox.Show("Không tìm thấy cấu hình server hoặc cấu hình không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                    return;
                }
                KzParkingv5BaseApi.server = StaticPool.serverConfig.ParkingServerUrl;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadServer: " + ex.Message + "\r\n" + ex.InnerException?.Message);
            }


            //try
            //{
            //    StaticPool.appOption = NewtonSoftHelper<AppOption>.DeserializeObjectFromPath(PathManagement.appOptionConfigPath) ?? new AppOption();
            //    StaticPool.eInvoiceConfig = NewtonSoftHelper<EInvoiceConfig>.DeserializeObjectFromPath(PathManagement.einvoiceConfigPath) ?? new EInvoiceConfig();
            //    StaticPool.lprConfig = NewtonSoftHelper<LprConfig>.DeserializeObjectFromPath(PathManagement.lprConfigPath) ?? new LprConfig();
            //    LogHelper.isSaveLog = StaticPool.appOption.IsSaveLog;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("LoadServer2: " + ex.Message + "\r\n" + ex.InnerException?.Message);
            //}

        }
    }
}