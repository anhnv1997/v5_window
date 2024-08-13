using iParkingv6.ApiManager;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static iParkingv5.ApiManager.KzParkingv5Apis.KzParkingv5BaseApi;
using iParkingv5.Objects.Datas.ThirtParty.OfficeHaus;
using Newtonsoft.Json;
using Kztek.Tools;

namespace iParkingv5.ApiManager.KzParkingv5Apis.services
{
    public class ThirdPartyService
    {
        public static async Task<HausVisitor> AddVisitor(string identityGroupCode, string plateNumber)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ThirdPartyService", "Add Visitor", (identityGroupCode, plateNumber));

            server = server.StandardlizeServerName();
            string apiUrl = server + "integration/visitor";

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var data = new
            {
                identityGroupCode = identityGroupCode,
                plateNumber = plateNumber,
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, data, headers, null,
                                                                  timeOut, Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    return JsonConvert.DeserializeObject<HausVisitor>(response.Item1);
                }
                catch (Exception)
                {
                    return null;

                }
            }
            return null;
        }

        public static async Task<HausQR> GetQRData(HausVisitor visitor)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ThirdPartyService", "Get QR Data", visitor);
            server = server.StandardlizeServerName();
            string apiUrl = server + "integration/visitor/get-qr";

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, visitor, headers, null,
                                                                  timeOut, Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    return JsonConvert.DeserializeObject<HausQR>(response.Item1);
                }
                catch (Exception)
                {
                    return null;

                }
            }
            return null;
        }
    }
}
