using iParkingv6.Objects.Datas;
using Kztek.LPR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace iParkingv5.Objects
{
    public class StaticPool
    {
        #region APP - Datas
        public static Computer selectedComputer = null;
        public static Gate gate = null;
        public static SystemConfig systemConfig = null;
        public static List<Camera> cameras = new List<Camera>();
        public static List<Lane> lanes = new List<Lane>();
        public static List<Led> leds = new List<Led>();
        public static List<Bdk> bdks = new List<Bdk>();

        public static CarANPR carANPR = null;
        public static MotorANPR motoANPR = null;
        public static string userId = string.Empty;
        #endregion End App Datas


        //--Function
        public static string GetCurrentVersion()
        {
            string filePath = Process.GetCurrentProcess().MainModule.FileName;
            FileVersionInfo updateFileVersionInfo = FileVersionInfo.GetVersionInfo(filePath);
            string updateFilePathVersion = updateFileVersionInfo.FileVersion;
            return updateFilePathVersion;
        }        
    }
}
