using iParkingv5.ApiManager.KzScaleApis;
using iParkingv5.Objects.Datas.ThirtParty.TienPhong;
using iParkingv5.Objects.Datas.weighing_service;
using iParkingv6.ApiManager;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace iParkingv5.ApiManager.TienPhong
{
    public static class TienPhongApiHelper
    {
        public static string UrlEndPoint = "";
        public static Dictionary<string, string> KeyValue = new Dictionary<string, string>();
        public static int TimeOut = 10000;

        static TienPhongApiHelper()
        {
            KeyValue.Add("X-API-Key", "12345");     // KEY
        }

        public static async Task<bool> AskOpen(AskOpenData data)
        {
            string apiUrl = UrlEndPoint + TienPhongUrlManagement.GetAskOpen();

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, data, KeyValue, new Dictionary<string, string>(), TimeOut, Method.Post);

            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    var abc = Newtonsoft.Json.JsonConvert.DeserializeObject<TienPhongBaseResponse>(response.Item1);

                    if (abc.open == CheckOpenStatus(EmYesNo.OK))
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }
        public enum EmYesNo
        {
            OK,
            NO,
        }
        public static string CheckOpenStatus(EmYesNo status)
        {
            switch (status)
            {
                case EmYesNo.OK:
                    return "OK";
                    break;
                case EmYesNo.NO:
                    return "NO";
                    break;
                default:
                    return "";
                    break;
            }
            return "";
        }
        public class TienPhongBaseResponse
        {
            public string open { get; set; }
            public string message { get; set; }
        }
    }
}
