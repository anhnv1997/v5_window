using iParkingv6.ApiManager;
using iParkingv6.ApiManager.KzParkingv3Apis;
using Kztek.Tool;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iParkingv5.ApiManager.XuanCuong
{
    public class XuanCuongApiHelper
    {
        public static string url = "https://xc-main-dev.maychudev.com/api/kztek/notify";
        public static string apiKey = "VPVYJIVRQHEPDTOA";
        private static int timeOut = 10000;
        public class XuanCuongApiResponse
        {
            public bool isSuccess { get; set; }
            public string Message { get; set; }
        }
        public static async Task<bool> SendParkingInfo(string eventid, string direction, string plate, DateTime time, List<string> imagePaths)
        {
            if (string.IsNullOrEmpty(url))
            {
                return false;
            }
            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "x-api-key", apiKey  }
            };
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "idEvent", eventid  },

                {"direction", direction },
                {"plate", plate },
                {"time", time.ToString("yyyy-MM-dd HH:mm:ss") },
                {"image", string.Join(";",imagePaths) },
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(url, null, headers, parameters, timeOut, RestSharp.Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                XuanCuongApiResponse response1 = NewtonSoftHelper<XuanCuongApiResponse>.GetBaseResponse(response.Item1);
                return response1?.isSuccess ?? false;
            }
            return false;
        }
    }
}
