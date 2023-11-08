using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv6.ApiManager.KzParkingv3Apis
{
    public class KzBaseResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Version { get; set; } = "5.0.2.1";
        public string Result { get; set; } = string.Empty;
        public DateTime ServerTime { get; set; } = DateTime.Now;
    }
}
