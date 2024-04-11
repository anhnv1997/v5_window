using IPaking.Ultility;
using iParkingv5.Lpr.Objects;
using iParkingv5.Objects;
using iParkingv5.Objects.Configs;
using iParkingv5_window;
using iParkingv5_window.Forms.SystemForms;
using iParkingv6.ApiManager.KzParkingv3Apis;
using Kztek.Tool;
using Kztek.Tools;
using KztekKeyRegister;
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
                const string appName = "IP_DA_V3_WD";
                PathManagement.baseBath = LogHelper.SaveLogFolder = Application.StartupPath;
                LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "Start", "Khởi chạy ứng dụng");
                string appCode = "IP_DA_V3_WD";
                using (Mutex mutex = new Mutex(true, appName, out bool ownmutex))
                {
                    if (ownmutex)
                    {
                        //return;
                        if (Environment.MachineName.ToUpper() != "VIETANHPC" && Environment.MachineName.ToUpper() != "PC-KIEN")
                        {
                            var frmLicenseValidatorForm = new LicenseValidatorForm();
                            frmLicenseValidatorForm.Init(appCode);
                            try
                            {
                                if (frmLicenseValidatorForm.LoadSavedLicense() == null)
                                {
                                    bool isOpenActiveForm = MessageBox.Show("Ứng dụng chưa được kích hoạt, bạn có muốn kích hoạt phần mềm?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes;

                                    if (isOpenActiveForm)
                                    {
                                        frmLicenseValidatorForm.ShowActivateForm();
                                    }
                                    else
                                    {
                                        Application.Exit();
                                        return;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                bool isOpenActiveForm = MessageBox.Show("Ứng dụng chưa được kích hoạt, bạn có muốn kích hoạt phần mềm?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes;

                                if (isOpenActiveForm)
                                {
                                    frmLicenseValidatorForm.ShowActivateForm();
                                    if (!frmLicenseValidatorForm.LicenseActivated)
                                    {
                                        MessageBox.Show("Kích hoạt không thành công " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        Application.Exit();
                                        return;
                                    }
                                }
                                else
                                {
                                    Application.Exit();
                                    return;
                                }
                            }

                        }
                        //DahuaAccessControl.Init();
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
            try
            {
                StaticPool.serverConfig = NewtonSoftHelper<ServerConfig>.DeserializeObjectFromPath(PathManagement.serverConfigPath);
                if (StaticPool.serverConfig == null)
                {
                    MessageBox.Show("Không tìm thấy cấu hình server hoặc cấu hình không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                    return;
                }
                MinioHelper.EndPoint = StaticPool.serverConfig.MinioServerUrl;
                MinioHelper.AccessKey = StaticPool.serverConfig.MinioServerUsername;
                MinioHelper.SecretKey = StaticPool.serverConfig.MinioServerPassword;
                KzParkingApiHelper.server = StaticPool.serverConfig.ParkingServerUrl;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadServer: " + ex.Message + "\r\n" + ex.InnerException?.Message);
            }


            try
            {
                StaticPool.appOption = NewtonSoftHelper<AppOption>.DeserializeObjectFromPath(PathManagement.appOptionConfigPath) ?? new AppOption();
                StaticPool.eInvoiceConfig = NewtonSoftHelper<EInvoiceConfig>.DeserializeObjectFromPath(PathManagement.einvoiceConfigPath) ?? new EInvoiceConfig();
                StaticPool.lprConfig = NewtonSoftHelper<LprConfig>.DeserializeObjectFromPath(PathManagement.lprConfigPath) ?? new LprConfig();
                LogHelper.isSaveLog = StaticPool.appOption.IsSaveLog;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadServer2: " + ex.Message + "\r\n" + ex.InnerException?.Message);
            }

        }
    }
}