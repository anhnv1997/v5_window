using iParkingv5.Lpr.Objects;
using iParkingv5.LprDetecter.LprDetecters;
using iParkingv5.Objects.Configs;
using iParkingv5.Objects.Databases;
using iParkingv5.Objects.Datas;
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
        public static int baseSize = 12;
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
        public static AppOption appOption = new AppOption();
        public static EInvoiceConfig eInvoiceConfig = new EInvoiceConfig();
        public static LprConfig lprConfig = new LprConfig();
        public static ILpr LprDetect;

        public static CustomerGroupCollection customerGroupCollection = new CustomerGroupCollection();
        public static Mdb mdb;
        public static ServerConfig serverConfig = new ServerConfig();
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
