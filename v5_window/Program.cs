using iParkingv5.Controller.Ingress;
using iParkingv5.Controller.KztekDevices.KZE02NETController;
using iParkingv5.Objects;
using iParkingv5_window.Forms.SystemForms;
using iParkingv6.ApiManager.KzParkingv3Apis;
using iParkingv6_window;
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
            LogHelper.SaveLogFolder = Application.StartupPath;

        StartApp:
            {
                using (Mutex mutex = new Mutex(true, "v5_window", out bool ownmutex))
                {
                    if (ownmutex)
                    {
                        LogHelper.SaveLogFolder = Application.StartupPath;
                        LogHelper.Logger_SystemInfor("Application Start -- check version: " + StaticPool.GetCurrentVersion(), LogHelper.SaveLogFolder);
                        Application.Run(new frmLogin());
                    }
                    else
                    {
                        // ứng dụng đã chạy, đóng ứng dụng trước đó và chạy ứng dụng mới
                        Process currentProcess = Process.GetCurrentProcess();
                        foreach (Process process in Process.GetProcessesByName(currentProcess.ProcessName))
                        {
                            try
                            {
                                if (process.Id != currentProcess.Id && process.MainModule.FileName == currentProcess.MainModule.FileName)
                                {
                                    LogHelper.Logger_SystemWarn("Ứng dụng đang được mở, tắt ứng dụng mở trước đó, mở ứng dụng mới", LogHelper.SaveLogFolder);
                                    process.Kill();
                                    goto StartApp;
                                }
                            }
                            catch (Exception ex)
                            {
                                goto StartApp;
                            }
                        }
                    }
                }
            }
        }
    }
}