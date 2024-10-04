using DocumentFormat.OpenXml.Wordprocessing;
using iParkingv5.Objects;
using Kztek.Tool.LogDatabases;
using Kztek.Tools;
using KztekKeyRegister;

namespace iParkingv5.LprServer
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
            LogHelper.SaveLogFolder = Application.StartupPath;
            const string appName = "CORE-AI-LPR";
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


            Application.Run(new Form1());
        }
    }
}