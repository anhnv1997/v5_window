using iParkingv6.ApiManager.KzParkingv3Apis.Responses;
using iParkingv6.Objects.Datas;
using Kztek.Tools;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iParkingv6.ApiManager.KzParkingv3Apis
{
    public static class KzParkingApiHelper
    {
        public static string server = "http://192.168.20.135:2100";
        public static string defaultRoute = "api/";
        public static string username = "admin";
        public static string password = "123456";
        public static int timeOut = 10000;

        public static int expireTime = 1000;
        public static string token = string.Empty;
        public static CancellationTokenSource cts;

        #region PUBLIC FUNCTION
        //-- Authorize Related
        public static async Task<string> GetToken(string _username, string _password)
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.PostLoginRoute;

            //Check PING
            Ping ping = new Ping();
            Uri uri = new Uri(apiUrl);
            IPStatus pingStatus = (await ping.SendPingAsync(uri.Host, 100)).Status;
            if (pingStatus != IPStatus.Success)
            {
                LogHelper.Logger_API_Error($"{apiUrl} Ping Error With Status {pingStatus}", LogHelper.SaveLogFolder);
                return string.Empty;
            }

            //Gửi API
            var login = new
            {
                username = _username,
                password = _password
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, login, null, null, timeOut, RestSharp.Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    KzBaseResponse kzBaseResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<KzBaseResponse>(response.Item1);
                    if (kzBaseResponse == null)
                    {
                        LogHelper.Logger_API_Error(apiUrl + "Error: Can't convert BaseRespose With: " + response.Item1, LogHelper.SaveLogFolder);
                        return string.Empty;
                    }

                    LoginResponse loginResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginResponse>(kzBaseResponse.Result);
                    if (loginResponse == null)
                    {
                        LogHelper.Logger_API_Error(apiUrl + "Error: Can't Convert To LoginResponse With: " + response.Item1, LogHelper.SaveLogFolder);
                        return string.Empty;
                    }
                    expireTime = loginResponse.Expires_In;
                    token = loginResponse.Token;
                    return token;
                }
                catch (Exception ex)
                {
                    LogHelper.Logger_API_Error(apiUrl + $"Get Exception: \r\n--Error: {ex.Message} \r\n--Ex: {ex.InnerException?.Message} \r\n--Response" + response.Item1, LogHelper.SaveLogFolder);
                }
            }
            return response.Item1;
        }
        public static async void StartPollingAuthorize()
        {
            cts = new CancellationTokenSource();
            _ = Task.Run(() => PollingAuthorize(cts.Token), cts.Token);
        }
        public static void StopPollingAuthorize()
        {
            cts?.Cancel();
        }
        private static async Task PollingAuthorize(CancellationToken ctsToken)
        {
            while (!ctsToken.IsCancellationRequested)
            {
                int delayTime = expireTime;
                try
                {
                    string _token = await GetToken(username, password);
                    if (string.IsNullOrEmpty(_token))
                    {
                        delayTime = 1000;
                    }
                    else
                    {
                        token = _token;
                        delayTime = expireTime;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Logger_API_Error("AUTHORIZE PARKING ERROR: " + ex.Message, LogHelper.SaveLogFolder);
                }
                finally
                {
                    await Task.Delay(TimeSpan.FromSeconds(delayTime), ctsToken);
                    GC.Collect();
                }
            }
        }
        //-- Card Related

        //-- System Config Related

        //-- Event Related

        //-- Other

        //-- Unsorted

        //-- Vehicle Group

        //-- Customer Related

        //-- Alarm

        //-- Black List

        //-- Payment

        //-- Voucher

        //-- Client Status
        #endregion END PUBLIC FUNCTION

        #region PRIVATE FUNCTION
        private static void StandardlizeServerName()
        {
            if (server[server.Length - 1] != '/' && server[server.Length - 1] != '\\')
            {
                server = server + "/";
            }
        }
        #endregion END PRIVATE FUNCTION
    }
}
