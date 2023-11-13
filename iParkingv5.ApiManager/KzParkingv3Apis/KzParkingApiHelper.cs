using iParkingv6.ApiManager.KzParkingv3Apis.Responses;
using iParkingv6.Objects.Datas;
using Kztek.Tools;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iParkingv6.ApiManager.KzParkingv3Apis
{
    public static class KzParkingApiHelper
    {
        public static string server = "http://192.168.20.52:2100";
        public static string defaultRoute = "api/";
        public static string username = "admin";
        public static string password = "123456";
        public static int timeOut = 10000;

        public static int expireTime = 1000;
        public static string token = string.Empty;
        public static CancellationTokenSource cts;

        #region PUBLIC FUNCTION
        #region -- Authorize Related Done
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
        #endregion END -- Authorize Related

        #region -- Card Related

        #endregion END -- Card Related

        #region -- System Config Related
        //--PC
        public static async Task<List<Computer>> GetComputersAsync()
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetPCByListRoute;

            //Check PING
            Ping ping = new Ping();
            Uri uri = new Uri(apiUrl);
            IPStatus pingStatus = (await ping.SendPingAsync(uri.Host, 100)).Status;
            if (pingStatus != IPStatus.Success)
            {
                LogHelper.Logger_API_Error($"{apiUrl} Ping Error With Status {pingStatus}", LogHelper.SaveLogFolder);
                return null;
            }

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    KzBaseResponse kzBaseResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<KzBaseResponse>(response.Item1);
                    if (kzBaseResponse == null)
                    {
                        LogHelper.Logger_API_Error(apiUrl + "Error: Can't convert BaseRespose With: " + response.Item1, LogHelper.SaveLogFolder);
                        return null;
                    }

                    List<Computer> computers = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Computer>>(kzBaseResponse.Result);
                    if (computers == null)
                    {
                        LogHelper.Logger_API_Error(apiUrl + "Error: Can't Convert To computers With: " + response.Item1, LogHelper.SaveLogFolder);
                        return null;
                    }
                    else
                    {
                        return computers;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Logger_API_Error(apiUrl + $"Get Exception: \r\n--Error: {ex.Message} \r\n--Ex: {ex.InnerException?.Message} \r\n--Response" + response.Item1, LogHelper.SaveLogFolder);
                }
            }
            return null;
        }
        public static async Task<Computer> GetComputerByIdAsync(string pcId)
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetPCByIdRoute;

            //Check PING
            Ping ping = new Ping();
            Uri uri = new Uri(apiUrl);
            IPStatus pingStatus = (await ping.SendPingAsync(uri.Host, 100)).Status;
            if (pingStatus != IPStatus.Success)
            {
                LogHelper.Logger_API_Error($"{apiUrl} Ping Error With Status {pingStatus}", LogHelper.SaveLogFolder);
                return null;
            }

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {"id", pcId}
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    KzBaseResponse kzBaseResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<KzBaseResponse>(response.Item1);
                    if (kzBaseResponse == null)
                    {
                        LogHelper.Logger_API_Error(apiUrl + "Error: Can't convert BaseRespose With: " + response.Item1, LogHelper.SaveLogFolder);
                        return null;
                    }

                    Computer computer = Newtonsoft.Json.JsonConvert.DeserializeObject<Computer>(kzBaseResponse.Result);
                    if (computer == null)
                    {
                        LogHelper.Logger_API_Error(apiUrl + "Error: Can't Convert To computer With: " + response.Item1, LogHelper.SaveLogFolder);
                        return null;
                    }
                    else
                    {
                        return computer;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Logger_API_Error(apiUrl + $"Get Exception: \r\n--Error: {ex.Message} \r\n--Ex: {ex.InnerException?.Message} \r\n--Response" + response.Item1, LogHelper.SaveLogFolder);
                }
            }
            return null;
        }

        //--Controller
        public static async Task<List<Bdk>> GetBdksAsync()
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetControllerByListRoute;

            //Check PING
            Ping ping = new Ping();
            Uri uri = new Uri(apiUrl);
            IPStatus pingStatus = (await ping.SendPingAsync(uri.Host, 100)).Status;
            if (pingStatus != IPStatus.Success)
            {
                LogHelper.Logger_API_Error($"{apiUrl} Ping Error With Status {pingStatus}", LogHelper.SaveLogFolder);
                return null;
            }

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    KzBaseResponse kzBaseResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<KzBaseResponse>(response.Item1);
                    if (kzBaseResponse == null)
                    {
                        LogHelper.Logger_API_Error(apiUrl + "Error: Can't convert BaseRespose With: " + response.Item1, LogHelper.SaveLogFolder);
                        return null;
                    }

                    List<Bdk> bdks = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Bdk>>(kzBaseResponse.Result);
                    if (bdks == null)
                    {
                        LogHelper.Logger_API_Error(apiUrl + "Error: Can't Convert To Bdks With: " + response.Item1, LogHelper.SaveLogFolder);
                        return null;
                    }
                    else
                    {
                        return bdks;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Logger_API_Error(apiUrl + $"Get Exception: \r\n--Error: {ex.Message} \r\n--Ex: {ex.InnerException?.Message} \r\n--Response" + response.Item1, LogHelper.SaveLogFolder);
                }
            }
            return null;
        }
        public static async Task<Bdk> GetBdkByIdAsync(string controllerId)
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetControllerByIdRoute;

            //Check PING
            Ping ping = new Ping();
            Uri uri = new Uri(apiUrl);
            IPStatus pingStatus = (await ping.SendPingAsync(uri.Host, 100)).Status;
            if (pingStatus != IPStatus.Success)
            {
                LogHelper.Logger_API_Error($"{apiUrl} Ping Error With Status {pingStatus}", LogHelper.SaveLogFolder);
                return null;
            }

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {"id", controllerId}
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    KzBaseResponse kzBaseResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<KzBaseResponse>(response.Item1);
                    if (kzBaseResponse == null)
                    {
                        LogHelper.Logger_API_Error(apiUrl + "Error: Can't convert BaseRespose With: " + response.Item1, LogHelper.SaveLogFolder);
                        return null;
                    }

                    Bdk bdk = Newtonsoft.Json.JsonConvert.DeserializeObject<Bdk>(kzBaseResponse.Result);
                    if (bdk == null)
                    {
                        LogHelper.Logger_API_Error(apiUrl + "Error: Can't Convert To BDK With: " + response.Item1, LogHelper.SaveLogFolder);
                        return null;
                    }
                    else
                    {
                        return bdk;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Logger_API_Error(apiUrl + $"Get Exception: \r\n--Error: {ex.Message} \r\n--Ex: {ex.InnerException?.Message} \r\n--Response" + response.Item1, LogHelper.SaveLogFolder);
                }
            }
            return null;
        }

        //--Camera
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pcId"></param>
        /// <param name="cameraFunction">Để trống thì sẽ tìm tất cả</param>
        /// <returns></returns>
        public static async Task<List<Camera>> GetCamerasAsync(string pcId, string cameraFunction)
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetCameraByListRoute;

            //Check PING
            Ping ping = new Ping();
            Uri uri = new Uri(apiUrl);
            IPStatus pingStatus = (await ping.SendPingAsync(uri.Host, 100)).Status;
            if (pingStatus != IPStatus.Success)
            {
                LogHelper.Logger_API_Error($"{apiUrl} Ping Error With Status {pingStatus}", LogHelper.SaveLogFolder);
                return null;
            }

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {"pcid", pcId},
            };
            if (!string.IsNullOrEmpty(cameraFunction))
            {
                parameters.Add("key", cameraFunction);
            }

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    KzBaseResponse kzBaseResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<KzBaseResponse>(response.Item1);
                    if (kzBaseResponse == null)
                    {
                        LogHelper.Logger_API_Error(apiUrl + "Error: Can't convert BaseRespose With: " + response.Item1, LogHelper.SaveLogFolder);
                        return null;
                    }

                    List<Camera> cameras = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Camera>>(kzBaseResponse.Result);
                    if (cameras == null)
                    {
                        LogHelper.Logger_API_Error(apiUrl + "Error: Can't Convert To Cameras With: " + response.Item1, LogHelper.SaveLogFolder);
                        return null;
                    }
                    else
                    {
                        return cameras;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Logger_API_Error(apiUrl + $"Get Exception: \r\n--Error: {ex.Message} \r\n--Ex: {ex.InnerException?.Message} \r\n--Response" + response.Item1, LogHelper.SaveLogFolder);
                }
            }
            return null;
        }
        public static async Task<Camera> GetCameraAsync(string cameraId)
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetCameraByIdRoute;

            //Check PING
            Ping ping = new Ping();
            Uri uri = new Uri(apiUrl);
            IPStatus pingStatus = (await ping.SendPingAsync(uri.Host, 100)).Status;
            if (pingStatus != IPStatus.Success)
            {
                LogHelper.Logger_API_Error($"{apiUrl} Ping Error With Status {pingStatus}", LogHelper.SaveLogFolder);
                return null;
            }

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {"id", cameraId}
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    KzBaseResponse kzBaseResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<KzBaseResponse>(response.Item1);
                    if (kzBaseResponse == null)
                    {

                        LogHelper.Logger_API_Error(apiUrl + "Error: Can't convert BaseRespose With: " + response.Item1, LogHelper.SaveLogFolder);
                        return null;
                    }

                    Camera camera = Newtonsoft.Json.JsonConvert.DeserializeObject<Camera>(kzBaseResponse.Result);
                    if (camera == null)
                    {
                        LogHelper.Logger_API_Error(apiUrl + "Error: Can't Convert To Camera With: " + response.Item1, LogHelper.SaveLogFolder);
                        return null;
                    }
                    else
                    {
                        return camera;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Logger_API_Error(apiUrl + $"Get Exception: \r\n--Error: {ex.Message} \r\n--Ex: {ex.InnerException?.Message} \r\n--Response" + response.Item1, LogHelper.SaveLogFolder);
                }
            }
            return null;
        }

        //--Lane
        public static async Task<List<Lane>> GetLanesAsync(string pcId, string key)
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetLaneByListRoute;

            //Check PING
            Ping ping = new Ping();
            Uri uri = new Uri(apiUrl);
            IPStatus pingStatus = (await ping.SendPingAsync(uri.Host, 100)).Status;
            if (pingStatus != IPStatus.Success)
            {
                LogHelper.Logger_API_Error($"{apiUrl} Ping Error With Status {pingStatus}", LogHelper.SaveLogFolder);
                return null;
            }

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(pcId))
            {
                parameters.Add("pcId", pcId);
            }
            if (!string.IsNullOrWhiteSpace(key))
            {
                parameters.Add("key", key);
            }

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    KzBaseResponse kzBaseResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<KzBaseResponse>(response.Item1);
                    if (kzBaseResponse == null)
                    {
                        LogHelper.Logger_API_Error(apiUrl + "Error: Can't convert BaseRespose With: " + response.Item1, LogHelper.SaveLogFolder);
                        return null;
                    }

                    List<Lane> lanes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Lane>>(kzBaseResponse.Result);
                    if (lanes == null)
                    {
                        LogHelper.Logger_API_Error(apiUrl + "Error: Can't Convert To Lanes With: " + response.Item1, LogHelper.SaveLogFolder);
                        return null;
                    }
                    else
                    {
                        return lanes;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Logger_API_Error(apiUrl + $"Get Exception: \r\n--Error: {ex.Message} \r\n--Ex: {ex.InnerException?.Message} \r\n--Response" + response.Item1, LogHelper.SaveLogFolder);
                }
            }
            return null;
        }
        public static async Task<Lane> GetLaneByIdAsync(string laneId)
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetLaneByIdRoute;

            //Check PING
            Ping ping = new Ping();
            Uri uri = new Uri(apiUrl);
            IPStatus pingStatus = (await ping.SendPingAsync(uri.Host, 100)).Status;
            if (pingStatus != IPStatus.Success)
            {
                LogHelper.Logger_API_Error($"{apiUrl} Ping Error With Status {pingStatus}", LogHelper.SaveLogFolder);
                return null;
            }

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {"id", laneId}
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    KzBaseResponse kzBaseResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<KzBaseResponse>(response.Item1);
                    if (kzBaseResponse == null)
                    {
                        LogHelper.Logger_API_Error(apiUrl + "Error: Can't convert BaseRespose With: " + response.Item1, LogHelper.SaveLogFolder);
                        return null;
                    }

                    Lane lane = Newtonsoft.Json.JsonConvert.DeserializeObject<Lane>(kzBaseResponse.Result);
                    if (lane == null)
                    {
                        LogHelper.Logger_API_Error(apiUrl + "Error: Can't Convert To Lane With: " + response.Item1, LogHelper.SaveLogFolder);
                        return null;
                    }
                    else
                    {
                        return lane;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Logger_API_Error(apiUrl + $"Get Exception: \r\n--Error: {ex.Message} \r\n--Ex: {ex.InnerException?.Message} \r\n--Response" + response.Item1, LogHelper.SaveLogFolder);
                }
            }
            return null;
        }

        //--Gate
        public static async Task<List<Gate>> GetGatesAsync()
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetGateByListRoute;

            //Check PING
            Ping ping = new Ping();
            Uri uri = new Uri(apiUrl);
            IPStatus pingStatus = (await ping.SendPingAsync(uri.Host, 100)).Status;
            if (pingStatus != IPStatus.Success)
            {
                LogHelper.Logger_API_Error($"{apiUrl} Ping Error With Status {pingStatus}", LogHelper.SaveLogFolder);
                return null;
            }

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    KzBaseResponse kzBaseResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<KzBaseResponse>(response.Item1);
                    if (kzBaseResponse == null)
                    {
                        LogHelper.Logger_API_Error(apiUrl + "Error: Can't convert BaseRespose With: " + response.Item1, LogHelper.SaveLogFolder);
                        return null;
                    }

                    List<Gate> gates = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Gate>>(kzBaseResponse.Result);
                    if (gates == null)
                    {
                        LogHelper.Logger_API_Error(apiUrl + "Error: Can't Convert To Gates With: " + response.Item1, LogHelper.SaveLogFolder);
                        return null;
                    }
                    else
                    {
                        return gates;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Logger_API_Error(apiUrl + $"Get Exception: \r\n--Error: {ex.Message} \r\n--Ex: {ex.InnerException?.Message} \r\n--Response" + response.Item1, LogHelper.SaveLogFolder);
                }
            }
            return null;
        }
        public static async Task<Gate> GetGateByIdAsync(string gateId)
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetGateByIdRoute;

            //Check PING
            Ping ping = new Ping();
            Uri uri = new Uri(apiUrl);
            IPStatus pingStatus = (await ping.SendPingAsync(uri.Host, 100)).Status;
            if (pingStatus != IPStatus.Success)
            {
                LogHelper.Logger_API_Error($"{apiUrl} Ping Error With Status {pingStatus}", LogHelper.SaveLogFolder);
                return null;
            }

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(gateId))
            {
                parameters.Add("id", gateId);
            }

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    KzBaseResponse kzBaseResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<KzBaseResponse>(response.Item1);
                    if (kzBaseResponse == null)
                    {
                        LogHelper.Logger_API_Error(apiUrl + "Error: Can't convert BaseRespose With: " + response.Item1, LogHelper.SaveLogFolder);
                        return null;
                    }

                    Gate lanes = Newtonsoft.Json.JsonConvert.DeserializeObject<Gate>(kzBaseResponse.Result);
                    if (lanes == null)
                    {
                        LogHelper.Logger_API_Error(apiUrl + "Error: Can't Convert To Gate With: " + response.Item1, LogHelper.SaveLogFolder);
                        return null;
                    }
                    else
                    {
                        return lanes;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Logger_API_Error(apiUrl + $"Get Exception: \r\n--Error: {ex.Message} \r\n--Ex: {ex.InnerException?.Message} \r\n--Response" + response.Item1, LogHelper.SaveLogFolder);
                }
            }
            return null;
        }

        //--LED
        public static async Task<List<Led>> GetLedsAsync(string pcId, string key)
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetLedByListRoute;

            //Check PING
            Ping ping = new Ping();
            Uri uri = new Uri(apiUrl);
            IPStatus pingStatus = (await ping.SendPingAsync(uri.Host, 100)).Status;
            if (pingStatus != IPStatus.Success)
            {
                LogHelper.Logger_API_Error($"{apiUrl} Ping Error With Status {pingStatus}", LogHelper.SaveLogFolder);
                return null;
            }

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(pcId))
            {
                parameters.Add("pcId", pcId);
            }
            if (!string.IsNullOrWhiteSpace(key))
            {
                parameters.Add("key", key);
            }
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    KzBaseResponse kzBaseResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<KzBaseResponse>(response.Item1);
                    if (kzBaseResponse == null)
                    {
                        LogHelper.Logger_API_Error(apiUrl + "Error: Can't convert BaseRespose With: " + response.Item1, LogHelper.SaveLogFolder);
                        return null;
                    }

                    List<Led> leds = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Led>>(kzBaseResponse.Result);
                    if (leds == null)
                    {
                        LogHelper.Logger_API_Error(apiUrl + "Error: Can't Convert To Leds With: " + response.Item1, LogHelper.SaveLogFolder);
                        return null;
                    }
                    else
                    {
                        return leds;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Logger_API_Error(apiUrl + $"Get Exception: \r\n--Error: {ex.Message} \r\n--Ex: {ex.InnerException?.Message} \r\n--Response" + response.Item1, LogHelper.SaveLogFolder);
                }
            }
            return null;
        }
        public static async Task<Led> GetLedByIdAsync(string ledId)
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetLedByIdRoute;

            //Check PING
            Ping ping = new Ping();
            Uri uri = new Uri(apiUrl);
            IPStatus pingStatus = (await ping.SendPingAsync(uri.Host, 100)).Status;
            if (pingStatus != IPStatus.Success)
            {
                LogHelper.Logger_API_Error($"{apiUrl} Ping Error With Status {pingStatus}", LogHelper.SaveLogFolder);
                return null;
            }

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(ledId))
            {
                parameters.Add("id", ledId);
            }

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    KzBaseResponse kzBaseResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<KzBaseResponse>(response.Item1);
                    if (kzBaseResponse == null)
                    {
                        LogHelper.Logger_API_Error(apiUrl + "Error: Can't convert BaseRespose With: " + response.Item1, LogHelper.SaveLogFolder);
                        return null;
                    }

                    Led leds = Newtonsoft.Json.JsonConvert.DeserializeObject<Led>(kzBaseResponse.Result);
                    if (leds == null)
                    {
                        LogHelper.Logger_API_Error(apiUrl + "Error: Can't Convert To Led With: " + response.Item1, LogHelper.SaveLogFolder);
                        return null;
                    }
                    else
                    {
                        return leds;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Logger_API_Error(apiUrl + $"Get Exception: \r\n--Error: {ex.Message} \r\n--Ex: {ex.InnerException?.Message} \r\n--Response" + response.Item1, LogHelper.SaveLogFolder);
                }
            }
            return null;
        }

        //--System Config
        public static async Task<SystemConfig> GetSystemConfigAsync()
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetSystemConfigRoute;

            //Check PING
            Ping ping = new Ping();
            Uri uri = new Uri(apiUrl);
            IPStatus pingStatus = (await ping.SendPingAsync(uri.Host, 100)).Status;
            if (pingStatus != IPStatus.Success)
            {
                LogHelper.Logger_API_Error($"{apiUrl} Ping Error With Status {pingStatus}", LogHelper.SaveLogFolder);
                return null;
            }

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    KzBaseResponse kzBaseResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<KzBaseResponse>(response.Item1);
                    if (kzBaseResponse == null)
                    {
                        LogHelper.Logger_API_Error(apiUrl + "Error: Can't convert BaseRespose With: " + response.Item1, LogHelper.SaveLogFolder);
                        return null;
                    }

                    SystemConfig systemConfig = Newtonsoft.Json.JsonConvert.DeserializeObject<SystemConfig>(kzBaseResponse.Result);
                    if (systemConfig == null)
                    {
                        LogHelper.Logger_API_Error(apiUrl + "Error: Can't Convert To SystemConfig With: " + response.Item1, LogHelper.SaveLogFolder);
                        return null;
                    }
                    else
                    {
                        return systemConfig;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Logger_API_Error(apiUrl + $"Get Exception: \r\n--Error: {ex.Message} \r\n--Ex: {ex.InnerException?.Message} \r\n--Response" + response.Item1, LogHelper.SaveLogFolder);
                }
            }
            return null;
        }
        #endregion END -- System Config Related

        #region -- Event Related
        public static async Task PostCheckInAsync()
        {
        }
        public static async Task PostCheckOutAsync()
        {
        }
        #endregion End -- Event Related

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
