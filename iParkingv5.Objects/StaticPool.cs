using iParkingv5.Lpr.Objects;
using iParkingv5.LprDetecter.LprDetecters;
using iParkingv5.Objects.Configs;
using iParkingv5.Objects.Databases;
using iParkingv5.Objects.Datas;
using iParkingv5.Objects.ScaleObjects;
using iParkingv6.Objects.Datas;
using System.Collections.Generic;
using System.Diagnostics;

namespace iParkingv5.Objects
{
    public class StaticPool
    {
        public static int baseSize = 12;
        public static WeighingDetailCollection WeighingDetailCollection = new WeighingDetailCollection();
        public static WeighingFormCollection WeighingFormCollection = new WeighingFormCollection();
        public static SharedPreferences sharedPreferences = new SharedPreferences();
        #region APP - Datas
        public static Computer selectedComputer = null;
        public static Gate gate = null;
        public static SystemConfig systemConfig = null;
        public static List<Camera> cameras = new List<Camera>();
        public static List<Lane> lanes = new List<Lane>();
        public static List<Led> leds = new List<Led>();
        public static List<Bdk> bdks = new List<Bdk>();
        public static string userId = string.Empty;
        public static string user_name = string.Empty;
        public static AppOption appOption = new AppOption();
        public static EInvoiceConfig eInvoiceConfig = new EInvoiceConfig();
        public static LprConfig lprConfig = new LprConfig();
        public static ILpr LprDetect;
        public static ILpr LprDetect2;
        public static ILpr LprDetect3;
        public static ILpr LprDetect4;

        public static CustomerGroupCollection customerGroupCollection = new CustomerGroupCollection();
        public static Mdb mdb;
        public static ServerConfig serverConfig = new ServerConfig();
        #endregion End App Datas

        #region EInvoice Data
        public static string CompanyName = "CÔNG TY CP HỮU NGHỊ XUÂN CƯƠNG";
        public static string CompanyAddress = "Cửa Khẩu QT Hữu Nghị - Huyện Cao Lộc - Tỉnh Lạng Sơn";
        public static string TaxCode = "0100109106-503";
        public static string templateCode = "5/00023";
        public static string invoiceTypeCode = "5";
        public static string symbolCode = "C24HAY";
        public static int TaxRate = 10;
        #endregion End EInvoice

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
