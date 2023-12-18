using Kztek.Tools;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using static Kztek.Tools.LogHelper;

namespace iParkingv6.ApiManager.KzParkingv3Apis.Responses
{
    public class LoginResponse
    {
        public string identifier { get; set; } = string.Empty;
        public int expiredAfter { get; set; } = 0;
        public string token { get; set; } = string.Empty;
    }
}
