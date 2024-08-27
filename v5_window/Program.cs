using IPaking.Ultility;
using iParkingv5.ApiManager.KzParkingv5Apis;
using iParkingv5.Objects;
using iParkingv5.Objects.Configs;
using Kztek.Tool;
using Kztek.Tools;
using System.Diagnostics;
using iParkingv5.Auth;
using iParkingv5_window.Forms.SystemForms;
using Kztek.Helper;
using KztekKeyRegister;
using iParkingv5_window;
using Kztek.Tool.LogDatabases;

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
                //string destPath = "D:\\TrainingLPR\\DUYTAN\\LprDetect";
                //string rootPath = "D:\\TrainingLPR\\DUYTAN\\New folder";
                //string[] detectFile = Directory.GetFiles(rootPath,
                //                                         "*", SearchOption.AllDirectories);
                //int i = 1;
                //foreach (string file in detectFile)
                //{
                //    if (file.Contains("PLATEIN") || file.Contains("PLATEOUT"))
                //    {
                //        File.Copy(file, Path.Combine(destPath, $"{i}.png"));
                //        i++;
                //    }
                //}

                const string appName = "IP_DA_V5_WD";
                PathManagement.baseBath = LogHelper.SaveLogFolder = Application.StartupPath;

                LogHelper.CreateConnection();
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.PROCESS, "START");

                using (Mutex mutex = new Mutex(true, appName, out bool ownmutex))
                {
                    if (ownmutex)
                    {
                        LoadSystemConfig();
                        if (StaticPool.appOption.IsCheckKey)
                        {
                            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.PROCESS, "CHECK KEY");
                            var frmLicenseValidatorForm = new LicenseValidatorForm();
                            frmLicenseValidatorForm.Init(appName);
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

                        CheckForUpdate();
                        if (!StaticPool.appOption.IsIntergratedEInvoice)
                        {
                            AppData.ApiServer.invoiceService = null;
                        }
                        tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.PROCESS, "OPEN LOADING SCREEN");
                        Application.Run(new frmLogin(AppData.ApiServer, KzParkingv5BaseApi.server, OpenLoadingPage));
                    }
                    else
                    {
                        tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.PROCESS, "Duplicate App Running");

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
                                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.PROCESS, "Duplicate App Running", ex);
                                goto StartApp;
                            }
                        }
                    }
                }
            }
        }

        static void OpenLoadingPage()
        {
            frmLoading frm = new();
            frm.Show();
        }

        private static void LoadSystemConfig()
        {
            try
            {
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.PROCESS, "Load System Config");
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
                KzParkingv5BaseApi.server = StaticPool.serverConfig.ParkingServerUrl;
            }
            catch (Exception ex)
            {
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.PROCESS, "Load System Config", ex);
                MessageBox.Show("LoadServer: " + ex.Message + "\r\n" + ex.InnerException?.Message);
            }


            try
            {
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.PROCESS, "Load OEM Config");
                StaticPool.oemConfig = NewtonSoftHelper<OEMConfig>.DeserializeObjectFromPath(PathManagement.oemConfigPath) ?? new OEMConfig();

                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.PROCESS, "Load APP Option");
                StaticPool.appOption = NewtonSoftHelper<AppOption>.DeserializeObjectFromPath(PathManagement.appOptionConfigPath) ?? new AppOption();

                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.PROCESS, "Load EInvoice Config");
                StaticPool.eInvoiceConfig = NewtonSoftHelper<EInvoiceConfig>.DeserializeObjectFromPath(PathManagement.einvoiceConfigPath) ?? new EInvoiceConfig();

                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.PROCESS, "Load Lpr Config");
                AppData.lprConfig = NewtonSoftHelper<LprConfig>.DeserializeObjectFromPath(PathManagement.lprConfigPath) ?? new LprConfig();
                LogHelper.isSaveLog = StaticPool.appOption.IsSaveLog;
            }
            catch (Exception ex)
            {
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.PROCESS, "Load Config", ex);
                MessageBox.Show("LoadServer2: " + ex.Message + "\r\n" + ex.InnerException?.Message);
            }

        }
        private static void CheckForUpdate()
        {
            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.PROCESS, "Check Update");
            if (string.IsNullOrEmpty(StaticPool.appOption.CheckForUpdatePath)) return;

            if (!Directory.Exists(StaticPool.appOption.CheckForUpdatePath)) return;

            try
            {
                bool isHavingUpdate = false;
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
                        string currentFilePath = currentVersionFiles.Where(e => e.Contains(fileName)).FirstOrDefault() ?? "";
                        string updateFilePath = updatefiles[i];

                        string? currentFilePathVersion = null;
                        string? updateFilePathVersion = null;
                        try
                        {
                            FileVersionInfo currentFileVersionInfo = FileVersionInfo.GetVersionInfo(currentFilePath);
                            currentFilePathVersion = currentFileVersionInfo?.FileVersion;
                        }
                        catch (Exception)
                        {
                        }
                        try
                        {
                            FileVersionInfo updateFileVersionInfo = FileVersionInfo.GetVersionInfo(updateFilePath);
                            updateFilePathVersion = updateFileVersionInfo?.FileVersion;
                        }
                        catch (Exception)
                        {
                        }

                        if (currentFilePathVersion != updateFilePathVersion)
                        {
                            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.PROCESS,
                                                 $"Update {fileName} From {currentFilePathVersion} To {updateFilePathVersion}");
                            isHavingUpdate = true;
                            string newFilePath = Path.Combine(Application.StartupPath, fileName + "_bak_" + currentFilePathVersion + "_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss"));
                            File.Move(currentFilePath, newFilePath);
                            File.Copy(updateFilePath, currentFilePath);
                            while (!File.Exists(currentFilePath))
                            {
                                Thread.Sleep(10);
                            }
                        }
                        else if (updateFilePathVersion == null && currentFilePathVersion == null)
                        {
                            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.PROCESS, $"Copy New {fileName}");

                            File.Delete(currentFilePath);
                            File.Copy(updateFilePath, currentFilePath);
                        }
                    }
                    //THÊM FILE CHƯA CÓ
                    else
                    {
                        isHavingUpdate = true;
                        string updateFilePath = updatefiles[i];

                        // Get the destination directory path
                        string destinationDirectory = Path.Combine(Application.StartupPath, Path.GetDirectoryName(fileName)!);
                        // Create the directory if it doesn't exist
                        Directory.CreateDirectory(destinationDirectory);

                        File.Copy(updateFilePath, Path.Combine(Application.StartupPath, fileName));
                    }
                }

                if (isHavingUpdate)
                {
                    //Fix cung bo restart()
                    //Application.Restart();
                    Application.Exit();
                    Environment.Exit(0);
                    Application.DoEvents();
                    return;
                }
            }
            catch (Exception ex)
            {
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.PROCESS, "Check Update", ex);
                MessageBox.Show(ex.Message);
            }
        }
    }
}