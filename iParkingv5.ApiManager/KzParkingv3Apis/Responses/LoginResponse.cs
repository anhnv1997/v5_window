using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv6.ApiManager.KzParkingv3Apis.Responses
{
    public class LoginResponse
    {
        public string Identifier { get; set; } = string.Empty;
        public int Expires_In  { get; set; } = 0;
        public string Token { get; set; } = string.Empty;
    }
}
