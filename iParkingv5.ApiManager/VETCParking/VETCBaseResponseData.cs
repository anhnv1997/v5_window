using iParkingv6.ApiManager.KzParkingv3Apis;
using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.ApiManager.VETCParking
{
    public class VETCBaseResponseData<T> where T : class
    {
        public string code { get; set; }
        public string message { get; set; }

        public T data { get; set; } = null;
    }
}
