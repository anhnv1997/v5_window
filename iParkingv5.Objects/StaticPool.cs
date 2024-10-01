using iParkingv5.Objects.Configs;
using iParkingv5.Objects.Databases;
using iParkingv5.Objects.Datas.Device_service;
using iParkingv5.Objects.Datas.parking_service;
using iParkingv5.Objects.Datas.system_service;
using iParkingv5.Objects.Datas.weighing_service;
using iParkingv6.Objects.Datas;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace iParkingv5.Objects
{
    public static class StaticPool
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
        public static OEMConfig oemConfig = new OEMConfig();
        public static TienPhongConfig tienPhongConfig = new TienPhongConfig();
        public static EInvoiceConfig eInvoiceConfig = new EInvoiceConfig();
        public static AppViewModeConfig appViewModeConfig = new AppViewModeConfig();

        public static CustomerGroupCollection customerGroupCollection = new CustomerGroupCollection();
        public static Mdb mdb;
        public static Mdb mdbEx;
        public static ServerConfig serverConfig = new ServerConfig();
        #endregion End App Datas

        #region EInvoice Data
        public static string CompanyName = "CÔNG TY CP HỮU NGHỊ XUÂN CƯƠNG";
        public static string CompanyAddress = "Cửa Khẩu QT Hữu Nghị - Huyện Cao Lộc - Tỉnh Lạng Sơn";
        public static string TaxCode = "0100109106-503";
        public static string templateCode = "5/00023";
        public static string invoiceTypeCode = "5";
        public static string symbolCode = "C24HAY";
        public static float TaxRate = 10;
        #endregion End EInvoice

        //--Function
        public static string GetCurrentVersion()
        {
            string filePath = Process.GetCurrentProcess().MainModule.FileName;
            FileVersionInfo updateFileVersionInfo = FileVersionInfo.GetVersionInfo(filePath);
            string updateFilePathVersion = updateFileVersionInfo.FileVersion;
            return updateFilePathVersion;
        }
        public static string ImageToBase64(string imagePath)
        {
            string base64String = string.Empty;
            if (File.Exists(imagePath))
            {
                using (var imageStream = new FileStream(imagePath, FileMode.Open))
                {
                    var buffer = new byte[imageStream.Length];
                    imageStream.Read(buffer, 0, (int)imageStream.Length);
                    base64String = Convert.ToBase64String(buffer);
                }
            }
            return base64String;
        }
        public static Image Base64ToImage(string base64String)
        {
            try
            {
                // Convert base 64 string to byte[]
                byte[] imageBytes = Convert.FromBase64String(base64String);
                // Convert byte[] to Image
                using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
                {
                    Image image = Image.FromStream(ms, true);
                    return image;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
