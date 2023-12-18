using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv6.Objects.Datas
{

    public class Camera
    {
        public string id { get; set; }
        public string name { get; set; }
        public string ipAddress { get; set; }
        public string httpPort { get; set; }
        public string rtspPort { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int frameRate { get; set; }
        public string resolution { get; set; }
        public int channel { get; set; }
        public int type { get; set; }
        public string computerId { get; set; }
        public object resizeConfigs { get; set; }
        public bool enabled { get; set; }
        public bool deleted { get; set; }
        public string createdUtc { get; set; }
        public string createdBy { get; set; }
        public object updatedUtc { get; set; }
        public object updatedBy { get; set; }
        public object computer { get; set; }
        public object[] laneCameraMaps { get; set; }
        public string GetCameraType()
        {
            switch (this.type)
            {
                case 0:
                    return "Secus";
                case 1:
                    return "Shany";
                case 2:
                    return "Bosch";
                case 3:
                    return "Vantech";
                case 4:
                    return "CNB";
                case 5:
                    return "HIK";
                case 6:
                    return "Enster";
                case 7:
                    return "Dahua";
                case 8:
                    return "Hanse";
                case 9:
                    return "Tiandy";
                default:
                    return "";
            }
        }
    }

}
