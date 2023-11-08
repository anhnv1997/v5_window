using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv6.Objects.Datas
{
    public class Camera
    {
        public string Id { get; set; }
        //public string CameraID { get; set; }
        public string CameraCode { get; set; }
        public string CameraName { get; set; }
        public string HttpURL { get; set; }
        public string HttpPort { get; set; }
        public string RtspPort { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? FrameRate { get; set; }
        public string Resolution { get; set; }
        public int? Channel { get; set; }
        public string CameraType { get; set; }
        //public string StreamType { get; set; }
        //public string SDK { get; set; }
        //public bool EnableRecording { get; set; }
        public string PCID { get; set; }
        public bool Inactive { get; set; }
        public string ResizeConfigs { get; set; }
        public int SortOrder { get; set; }
    }

}
