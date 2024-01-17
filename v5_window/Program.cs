using IPaking.Ultility;
using iParkingv5.Lpr.Objects;
using iParkingv5.Objects;
using iParkingv5.Objects.Configs;
using iParkingv5_window;
using iParkingv5_window.Forms;
using iParkingv5_window.Forms.SystemForms;
using iParkingv6.ApiManager.KzParkingv3Apis;
using Kztek.Tool;
using Kztek.Tools;
using System.Diagnostics;

namespace v6_window
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

        StartApp:
            {
                const string appName = "v5_window";
                PathManagement.baseBath = LogHelper.SaveLogFolder = Application.StartupPath;
                LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "Start", "Khởi chạy ứng dụng");
                //Application.Run(new frmTest());
                //return;

                using (Mutex mutex = new Mutex(true, appName, out bool ownmutex))
                {
                    if (ownmutex)
                    {
                        LoadSystemConfig();
                        LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "Start", "Mở giao diện đăng nhập hệ thống");
                        Application.Run(new frmLogin());
                    }
                    else
                    {
                        LogHelper.Log(LogHelper.EmLogType.WARN, LogHelper.EmObjectLogType.System, "Start", "Ứng dụng đã được mở trước đó", "Tắt ứng dụng cũ và kiểm tra lại");
                        // ứng dụng đã chạy, đóng ứng dụng trước đó và chạy ứng dụng mới
                        Process currentProcess = Process.GetCurrentProcess();
                        foreach (Process process in Process.GetProcessesByName(currentProcess.ProcessName))
                        {
                            try
                            {
                                if (process.Id != currentProcess.Id &&
                                    process.MainModule?.FileName == currentProcess.MainModule?.FileName)
                                {
                                    process.Kill();
                                    process.WaitForExit();
                                    goto StartApp;
                                }
                            }
                            catch (Exception ex)
                            {
                                LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.System, "Start", "Ứng dụng đã được mở trước đó", "Tắt ứng dụng cũ và kiểm tra lại", obj: ex);
                                goto StartApp;
                            }
                        }
                    }
                }
           
            }
        }
        private static void LoadSystemConfig()
        {
            ServerConfig? serverConfig = NewtonSoftHelper<ServerConfig>.DeserializeObjectFromPath(PathManagement.serverConfigPath);
            if (serverConfig == null)
            {
                MessageBox.Show("Không tìm thấy cấu hình server hoặc cấu hình không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
                return;
            }
            MinioHelper.EndPoint = serverConfig.MinioServerUrl;
            MinioHelper.AccessKey = serverConfig.MinioServerUsername;
            MinioHelper.SecretKey = serverConfig.MinioServerPassword;
            KzParkingApiHelper.server = serverConfig.ParkingServerUrl;

            StaticPool.appOption = NewtonSoftHelper<AppOption>.DeserializeObjectFromPath(PathManagement.appOptionConfigPath) ?? new AppOption();
            StaticPool.eInvoiceConfig = NewtonSoftHelper<EInvoiceConfig>.DeserializeObjectFromPath(PathManagement.einvoiceConfigPath) ?? new EInvoiceConfig();
            StaticPool.lprConfig = NewtonSoftHelper<LprConfig>.DeserializeObjectFromPath(PathManagement.lprConfigPath) ?? new LprConfig();
        }
    }
}