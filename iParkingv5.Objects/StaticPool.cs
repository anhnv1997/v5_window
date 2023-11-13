using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace iParkingv5.Objects
{
    public class StaticPool
    {
        public static string GetCurrentVersion()
        {
            string filePath = Process.GetCurrentProcess().MainModule.FileName;
            FileVersionInfo updateFileVersionInfo = FileVersionInfo.GetVersionInfo(filePath);
            string updateFilePathVersion = updateFileVersionInfo.FileVersion;
            return updateFilePathVersion;
        }
    }
}
