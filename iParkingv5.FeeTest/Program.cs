using IPaking.Ultility;
using iParkingv5.ApiManager.KzParkingv5Apis;
using iParkingv5.Auth;
using iParkingv5.Objects;
using iParkingv5.Objects.Configs;
using Kztek.Helper;
using Kztek.Tool;
using Kztek.Tool.LogDatabases;
using Kztek.Tools;

namespace iParkingv5.FeeTest
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            const string appName = "IP_DA_V5_LU_FEE_TEST";
            PathManagement.baseBath = LogHelper.SaveLogFolder = Application.StartupPath;
            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.PROCESS, "CHECK KEY");

            if (LoadSystemConfig())
            {
                Application.Run(new frmLogin(AppData.ApiServer, KzParkingv5BaseApi.server, OpenHomePage));
            }
        }
        static void OpenHomePage()
        {
            frmFeeCalculate frm = new();
            frm.Show();
        }
        private static bool LoadSystemConfig()
        {
            try
            {
                StaticPool.serverConfig = NewtonSoftHelper<ServerConfig>.DeserializeObjectFromPath(PathManagement.serverConfigPath);
                if (StaticPool.serverConfig == null)
                {
                    MessageBox.Show("Cấu hình không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                    return false;
                }
                MinioHelper.EndPoint = StaticPool.serverConfig.MinioServerUrl;
                MinioHelper.AccessKey = StaticPool.serverConfig.MinioServerUsername;
                MinioHelper.SecretKey = StaticPool.serverConfig.MinioServerPassword;
                KzParkingv5BaseApi.server = StaticPool.serverConfig.ParkingServerUrl;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadServer: " + ex.Message + "\r\n" + ex.InnerException?.Message);
            }


            try
            {
                StaticPool.appOption = NewtonSoftHelper<AppOption>.DeserializeObjectFromPath(PathManagement.appOptionConfigPath) ?? new AppOption();
                StaticPool.eInvoiceConfig = NewtonSoftHelper<EInvoiceConfig>.DeserializeObjectFromPath(PathManagement.einvoiceConfigPath) ?? new EInvoiceConfig();
                LogHelper.isSaveLog = StaticPool.appOption.IsSaveLog;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadServer2: " + ex.Message + "\r\n" + ex.InnerException?.Message);
            }
            return true;
        }
    }
}