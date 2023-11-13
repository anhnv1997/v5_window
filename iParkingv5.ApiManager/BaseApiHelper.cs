using Kztek.Tool.NetworkTools;
using Kztek.Tools;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iParkingv6.ApiManager
{
    public class BaseApiHelper
    {
        #region JSON API HELPER
        public static string startupPath = "";
        public static int timeOut = 10000;
        public static string tokenHeader = "token";
        public const int max_send_times = 2;

        public static string GeneralJsonAPI(string apiUrl, object data, Dictionary<string, string>? headerValues, Dictionary<string, string> requiredParams, int timeOut, ref string error, Method method)
        {
            var client = new RestClient(apiUrl);
            var request = new RestRequest();
            request.Method = method;
            request.Timeout = timeOut;
            request.RequestFormat = DataFormat.Json;
            if (data != null)
                request.AddJsonBody(data);

            foreach (KeyValuePair<string, string> item in headerValues)
            {
                request.AddHeader(item.Key, item.Value);
            }
            foreach (KeyValuePair<string, string> kvp in requiredParams)
            {
                request.AddQueryParameter(kvp.Key, kvp.Value);
            }
            var response = client.Execute(request);
            if (!response.IsSuccessful)
            {
                client = new RestClient(apiUrl);
                request = new RestRequest();
                request.Method = method;
                request.Timeout = timeOut;
                request.RequestFormat = DataFormat.Json;
                if (data != null)
                    request.AddJsonBody(data);
                request.AddHeaders(headerValues);
                foreach (KeyValuePair<string, string> kvp in requiredParams)
                {
                    request.AddQueryParameter(kvp.Key, kvp.Value);
                }
                response = client.Execute(request);
                if (!response.IsSuccessful)
                {
                    error = apiUrl + ":" + response.ErrorMessage;
                    return string.Empty;
                }
            }
            return response.Content;
        }

        public static string GeneralJsonAPI(string apiUrl, string data, Dictionary<string, string>? headerValues, Dictionary<string, string> requiredParams, int timeOut, ref string error, Method method)
        {
            var client = new RestClient(apiUrl);
            var request = new RestRequest
            {
                Timeout = timeOut,
                Method = method
            };
            if (data != null)
                request.AddParameter("application/json", data, ParameterType.RequestBody);

            request.AddHeaders(headerValues);
            foreach (KeyValuePair<string, string> kvp in requiredParams)
            {
                request.AddQueryParameter(kvp.Key, kvp.Value);
            }
            var response = client.Execute(request);
            if (!response.IsSuccessful)
            {
                client = new RestClient(apiUrl);
                request = new RestRequest();
                request.Timeout = timeOut;
                request.Method = method;
                request.RequestFormat = DataFormat.Json;
                if (data != null)
                    request.AddParameter("application/json", data, ParameterType.RequestBody);
                request.AddHeaders(headerValues);
                foreach (KeyValuePair<string, string> kvp in requiredParams)
                {
                    request.AddQueryParameter(kvp.Key, kvp.Value);
                }
                response = client.Execute(request);
                if (!response.IsSuccessful)
                {
                    error = apiUrl + ":" + response.ErrorMessage;
                    return string.Empty;
                }
            }
            return response.Content;
        }

        /// <summary>
        /// Hàm gửi trả về 1 Tuple trong đó Item1 là kết quả trả về, Item2 là thông tin lỗi nếu có
        /// </summary>
        /// <param name="apiUrl"></param>
        /// <param name="data"></param>
        /// <param name="headerValues"></param>
        /// <param name="requiredParams"></param>
        /// <param name="timeOut"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public static async Task<Tuple<string, string>> GeneralJsonAPIAsync(string apiUrl, object data, Dictionary<string, string>? headerValues, Dictionary<string, string>? requiredParams, int timeOut, Method method)
        {
            Uri uri = new Uri(apiUrl);
            if (!NetWorkTools.IsPingSuccess(uri.Host, 100))
            {
                return Tuple.Create<string, string>(string.Empty, "PING ERROR");
            }

            string errorMessage = string.Empty;
            for (int i = 0; i < max_send_times; i++)
            {
                var client = new RestClient(apiUrl);
                var request = new RestRequest
                {
                    Method = method,
                    Timeout = timeOut,
                    RequestFormat = DataFormat.Json
                };
                if (data != null)
                    request.AddJsonBody(data);

                if (headerValues!=null)
                {
                    foreach (KeyValuePair<string, string> item in headerValues)
                    {
                        request.AddHeader(item.Key, item.Value);
                    }
                }
                if (requiredParams != null)
                {
                    foreach (KeyValuePair<string, string> kvp in requiredParams)
                    {
                        request.AddQueryParameter(kvp.Key, kvp.Value);
                    }
                }
                  
                var response = await client.ExecuteAsync(request);
                if (!response.IsSuccessful)
                {
                    errorMessage = $"Error {apiUrl} + Lần {i + 1} + \r\nError Message: {response.ErrorMessage} \r\nError Exception: {response.ErrorException}";
                    LogHelper.Logger_API_Error(errorMessage, LogHelper.SaveLogFolder, data);
                    continue;
                }
                LogHelper.Logger_API_Infor($"{apiUrl} Success: " + response.Content, LogHelper.SaveLogFolder, data);
                return Tuple.Create<string, string>(response.Content, string.Empty);
            }
            return Tuple.Create<string, string>(string.Empty, errorMessage);
        }
        #endregion END JSON API HELPER
    }
}