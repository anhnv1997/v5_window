using Kztek.Tools;

namespace iLogHelper
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
            LogHelper.CreateConnection();
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "Start", "Khởi chạy ứng dụng");
            Application.Run(new Form1());
        }
    }
}