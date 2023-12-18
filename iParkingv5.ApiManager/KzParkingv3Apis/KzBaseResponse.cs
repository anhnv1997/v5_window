using iParkingv6.ApiManager.KzParkingv3Apis.Responses;
using Kztek.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using static Kztek.Tools.LogHelper;

namespace iParkingv6.ApiManager.KzParkingv3Apis
{
    public class KzBaseResponse<T> where T : class 
    {
        public bool isSuccess { get; set; }
        public string message { get; set; }
        public string version { get; set; } = "5.0.2.1";
        public T data { get; set; } = null;
        public string serverTime { get; set; }= string.Empty;
        [JsonIgnore]
        public DateTime ServerTimeParsed
        {
            get
            {
                return DateTime.ParseExact(serverTime, "yyyy-MM-ddTHH:mm:ss:ffff", null).AddHours(7);
            }
        }
    }
}
