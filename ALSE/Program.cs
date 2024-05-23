using ALSE.SystemForms;
using DahuaLib.DahuaFuntion;
using IPaking.Ultility;
using iParking.ConfigurationManager;
using iParkingv5.Objects.Configs;
using iParkingv5.Objects.Databases;
using iParkingv5.Objects;
using iParkingv6.ApiManager.KzParkingv3Apis;
using System.Diagnostics;
using Kztek.Tools;
using Kztek.Tool;
using Kztek.Tool.Cryptors;

namespace ALSE
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
                const string appName = "iParkingv5_CustomerRegister";
                PathManagement.baseBath = LogHelper.SaveLogFolder = Application.StartupPath;
                LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "Start", "Khởi chạy ứng dụng");
                using (Mutex mutex = new Mutex(true, appName, out bool ownmutex))
                {
                    if (ownmutex)
                    {
                        //if (Environment.MachineName.ToUpper() != "VIETANHPC")
                        //{
                        //    var frmLicenseValidatorForm = new LicenseValidatorForm();
                        //    frmLicenseValidatorForm.Init(appCode);
                        //    try
                        //    {
                        //        if (frmLicenseValidatorForm.LoadSavedLicense() == null)
                        //        {
                        //            bool isOpenActiveForm = MessageBox.Show("Ứng dụng chưa được kích hoạt, bạn có muốn kích hoạt phần mềm?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes;

                        //            if (isOpenActiveForm)
                        //            {
                        //                frmLicenseValidatorForm.ShowActivateForm();
                        //            }
                        //            else
                        //            {
                        //                Application.Exit();
                        //                return;
                        //            }
                        //        }
                        //    }
                        //    catch (Exception ex)
                        //    {
                        //        bool isOpenActiveForm = MessageBox.Show("Ứng dụng chưa được kích hoạt, bạn có muốn kích hoạt phần mềm?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes;

                        //        if (isOpenActiveForm)
                        //        {
                        //            frmLicenseValidatorForm.ShowActivateForm();
                        //            if (!frmLicenseValidatorForm.LicenseActivated)
                        //            {
                        //                MessageBox.Show("Kích hoạt không thành công " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //                Application.Exit();
                        //                return;
                        //            }
                        //        }
                        //        else
                        //        {
                        //            Application.Exit();
                        //            return;
                        //        }
                        //    }

                        //}
                        try
                        {
                            ServerConfig? serverConfig = NewtonSoftHelper<ServerConfig>.DeserializeObjectFromPath(PathManagement.serverConfigPath);
                            if (serverConfig == null)
                            {
                                MessageBox.Show("Không tìm thấy cấu hình server hoặc cấu hình không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Application.Exit();
                                return;
                            }
                            KzParkingApiHelper.server = serverConfig.ParkingServerUrl;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("LoadServer: " + ex.Message + "\r\n" + ex.InnerException?.Message);
                            Application.Exit();
                            return;
                        }


                        SQLConn? sql = null;
                        string sqlPath = PathManagement.databaseConfigPath;
                        if (File.Exists(sqlPath))
                        {
                            try
                            {
                                FileXML.ReadXMLSQLConn(sqlPath, ref sql);
                                if (sql != null)
                                {
                                    string SQLServerName = sql.SQLServerName;
                                    string SQLDatabaseName = sql.SQLDatabase;
                                    string SQLUserName = sql.SQLUserName;
                                    string SQLPassword = CryptorEngine.Decrypt(sql.SQLPassword, true);
                                    string SQLAuthentication = sql.SQLAuthentication;
                                    StaticPool.mdb = new Mdb(SQLServerName, SQLDatabaseName, SQLAuthentication, SQLUserName, SQLPassword);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Không tải được cấu hình cơ sở dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Application.Exit();
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không tải được cấu hình cơ sở dữ liệu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Application.Exit();
                            return;
                        }

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

    }
}