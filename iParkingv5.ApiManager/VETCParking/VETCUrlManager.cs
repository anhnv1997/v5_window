using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.ApiManager.VETCParking
{
    public static class VETCUrlManager
    {
        public static string UrlCheckOut = "http://localhost:50050/lane/check-out";
        public static string UrlCheckConnectAgent = "http://localhost:50050/health";
        public static string UrlTriggerEtag = "http://localhost:50050/simulate/etag";
        public static string UrlGetAllEtag = "http://localhost:50050/etag";
        public static string UrlTriggerPayment = "http://localhost:50050/simulate/trigger";
        public static string UrlConfigPayment = "http://localhost:50050/simulate/config";
        public static string UrlCheckTransaction(string tranID)
        {
            return $"http://localhost:50050/transaction/{tranID}/check";
        }
    }
}
