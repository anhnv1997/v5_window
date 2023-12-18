using iParkingv5.Objects;
using iParkingv5_window.Forms.SystemForms;
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
                LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "Start", "Khởi chạy ứng dụng");
                using (Mutex mutex = new Mutex(true, "v5_window", out bool ownmutex))
                {
                    if (ownmutex)
                    {
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
                                LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.System, "Start", "Ứng dụng đã được mở trước đó", "Tắt ứng dụng cũ và kiểm tra lại", obj : ex);
                                goto StartApp;
                            }
                        }
                    }
                }
            }
        }
    }
}