using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv6.Objects.Datas
{

    public class Camera
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public string HttpPort { get; set; }
        public string RtspPort { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int FrameRate { get; set; }
        public string Resolution { get; set; }
        public int Channel { get; set; }
        public int Type { get; set; }
        public string ComputerId { get; set; }
        public object ResizeConfigs { get; set; }
        public bool Enabled { get; set; }
        public string CreatedUtc { get; set; }
        public string CreatedBy { get; set; }
        public object UpdatedUtc { get; set; }
        public object UpdatedBy { get; set; }
        public string GetCameraType()
        {
            switch (this.Type)
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
