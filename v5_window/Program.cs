using iParkingv6.ApiManager.KzParkingv3Apis;
using iParkingv6_window;
using Kztek.Tools;

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
            LogHelper.SaveLogFolder = Application.StartupPath;
            Application.Run(new frmMain());
        }
    }
}