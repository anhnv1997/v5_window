using IPaking.Ultility;
using iParking.ConfigurationManager.Forms;
using iParking.ConfigurationManager.Forms.SystemForms;
using Kztek.Tools;

namespace iParking.ConfigurationManager
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
            PathManagement.baseBath = LogHelper.SaveLogFolder = Application.StartupPath;
            if (new frmConfirmPassword().ShowDialog() == DialogResult.OK)
            {
                Application.Run(new frmConnectionConfig());
            }
        }
    }
}