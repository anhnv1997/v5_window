using iParkingv5.ApiManager.KzParkingv5Apis;
using iParkingv5.Objects.Datas.ThirtParty.Hanet;
using iParkingv5.Objects.EventDatas;
using iParkingv6.ApiManager;
using Kztek.Tool;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace iParkingv5.ApiManager
{
    public static class HANETApi
    {
        public class BaseResponse<T> where T : class
        {
            public int returnCode { get; set; }
            public string returnMessage { get; set; }
            public T data { get; set; }
        }

        public static string baseUrl = "https://partner.hanet.ai/";
        public static string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjI2NzkxNTUxODE3MDI5NjA0ODgiLCJlbWFpbCI6Im5ndXllbnZpZXRhbmgwOTAzMTk5N0BnbWFpbC5jb20iLCJjbGllbnRfaWQiOiJjODI0MWIwZWRiODIxNWNmZTA2YWViNjczNjlmNjdjMCIsInR5cGUiOiJhdXRob3JpemF0aW9uX2NvZGUiLCJpYXQiOjE3MjQ3Mzk5MjYsImV4cCI6MTc1NjI3NTkyNn0.sumq_rHyc2MQ3HXeigymv2qYfC7RYq1RhAcQZLY9Hmo";

        public static string GetIdentityCodeByPersonId(string personId)
        {
            string url = "https://partner.hanet.ai/person/getUserInfoByPersonID";

            var _client = new RestClient(url);
            var _request = new RestRequest
            {
                Method = Method.Post,
                Timeout = 10000,
            };
            _request.AddHeader("content-type", "application/x-www-form-urlencoded");
            _request.AddParameter("application/x-www-form-urlencoded", $"token={token}&personID={personId}", ParameterType.RequestBody);
            var _response = _client.Execute(_request);
            if (_response.IsSuccessful)
            {
                var baseData = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseResponse<HANETFaceData>>(_response.Content);
                if (baseData!=null)
                {
                    return baseData.data?.aliasID;
                }
            }
            return "";
        }
        public static bool RegisterUser(string name, string aliasId, string placeId, List<byte> imageBytes)
        {
            string url = "https://partner.hanet.ai/person/register";

            var _client = new RestClient(url);
            var request = new RestRequest
            {
                Method = Method.Post,
                Timeout = 20000,
            };
            request.AlwaysMultipartFormData = true;
            request.AddParameter("token", token);
            request.AddParameter("name", name);
            request.AddParameter("aliasID", aliasId);
            request.AddParameter("placeID", placeId);
            request.AddParameter("title", name);
            request.AddFile($"file", imageBytes.ToArray(), "x.jpg");
            var _response = _client.Execute(request);
            return _response.IsSuccessful;
        }
        public static bool CheckPlate(string deviceId)
        {
            string url = "https://partner3.hanet.ai/device/checkLicensePlate";

            var _client = new RestClient(url);
            var request = new RestRequest
            {
                Method = Method.Post,
                Timeout = 10000,
            };
            request.AlwaysMultipartFormData = true;
            request.AddParameter("token", token);
            request.AddParameter("deviceID", "O2238UV1088");
            var _response = _client.Execute(request);
            return _response.IsSuccessful;
        }
    }
}
