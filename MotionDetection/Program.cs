using iParkingv5.Objects;
using Kztek.Tool.LogDatabases;
using Kztek.Tools;
using KztekKeyRegister;
using System.Diagnostics;

namespace MotionDetection
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
                const string appName = "DEMO";
                LogHelper.CreateConnection();
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.PROCESS, "START");

                using (Mutex mutex = new Mutex(true, appName, out bool ownmutex))
                {
                    if (ownmutex)
                    {
                        //tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.PROCESS, "CHECK KEY");
                        //var frmLicenseValidatorForm = new LicenseValidatorForm();
                        //frmLicenseValidatorForm.Init(appName);
                        //try
                        //{
                        //    if (frmLicenseValidatorForm.LoadSavedLicense() == null)
                        //    {
                        //        bool isOpenActiveForm = MessageBox.Show("Ứng dụng chưa được kích hoạt, bạn có muốn kích hoạt phần mềm?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes;

                        //        if (isOpenActiveForm)
                        //        {
                        //            frmLicenseValidatorForm.ShowActivateForm();
                        //        }
                        //        else
                        //        {
                        //            Application.Exit();
                        //            return;
                        //        }
                        //    }
                        //}
                        //catch (Exception ex)
                        //{
                        //    bool isOpenActiveForm = MessageBox.Show("Ứng dụng chưa được kích hoạt, bạn có muốn kích hoạt phần mềm?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes;

                        //    if (isOpenActiveForm)
                        //    {
                        //        frmLicenseValidatorForm.ShowActivateForm();
                        //        if (!frmLicenseValidatorForm.LicenseActivated)
                        //        {
                        //            MessageBox.Show("Kích hoạt không thành công " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //            Application.Exit();
                        //            return;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        Application.Exit();
                        //        return;
                        //    }
                        //}

                        tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.PROCESS, "OPEN LOADING SCREEN");
                        Application.Run(new Form1());
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
    }
}