using iParkingv5.Objects.Datas;
using iParkingv5.Objects.EventDatas;
using iParkingv6.ApiManager.KzParkingv3Apis.Responses;
using iParkingv6.Objects.Datas;
using Kztek.Tools;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Kztek.Tool;
using iParkingv5.Objects;

namespace iParkingv6.ApiManager.KzParkingv3Apis
{
    public static class KzParkingApiHelper
    {
        public static string server = "http://192.168.20.135:13000";
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
            username = _username;
            password = _password;
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
                    KzBaseResponse<LoginResponse> kzBaseResponse = NewtonSoftHelper<KzBaseResponse<LoginResponse>>.GetBaseResponse(response.Item1);
                    if (kzBaseResponse == null)
                        return string.Empty;
                    StaticPool.userId = kzBaseResponse.data.identifier;
                    token =  kzBaseResponse.data?.token;
                    return token;
                }
                catch (Exception ex)
                {
                    LogHelper.Log(logType: LogHelper.EmLogType.ERROR,
                              doi_tuong_tac_dong: LogHelper.EmObjectLogType.Api,
                              obj: ex);
                }
            }
            return response.Item1;
        }
        public static void StartPollingAuthorize()
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
                    LogHelper.Log(logType: LogHelper.EmLogType.ERROR,
                            doi_tuong_tac_dong: LogHelper.EmObjectLogType.Api,
                            obj: ex);
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
        //--Card Group
        public static async Task<List<CardGroup>> GetCardGroupsAsync()
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetAllCardGroupRoute;

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponse<List<CardGroup>> kzBaseResponse = NewtonSoftHelper<KzBaseResponse<List<CardGroup>>>.GetBaseResponse(response.Item1);
                if (kzBaseResponse == null)
                    return null;

                return kzBaseResponse.data;
            }
            return null;
        }
        public static async Task<Tuple<CardGroup, string>> GetCardGroupByIdAsync(string cardGroupId)
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetCardGroupByIdRoute;
            string errorMessage = string.Empty;

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {"id", cardGroupId}
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponse<Tuple<CardGroup, string>> kzBaseResponse = NewtonSoftHelper<KzBaseResponse<Tuple<CardGroup, string>>>.GetBaseResponse(response.Item1);
                if (kzBaseResponse == null)
                {
                    errorMessage = response.Item1;
                    return Tuple.Create<CardGroup, string>(null, errorMessage);
                }
                return kzBaseResponse.data;
            }
            return Tuple.Create<CardGroup, string>(null, errorMessage);
        }

        //--Vehicle Group
        public static async Task<List<VehicleGroup>> GetVehicleGroupsAsync()
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetVehicleGroupByListRoute;

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponse<List<VehicleGroup>> kzBaseResponse = NewtonSoftHelper<KzBaseResponse<List<VehicleGroup>>>.GetBaseResponse(response.Item1);
                if (kzBaseResponse == null)
                {
                    return null;
                }
                return kzBaseResponse.data;
            }
            return null;
        }
        public static async Task<Tuple<VehicleGroup, string>> GetVehicleGroupByIdAsync(string vehicleGroupId)
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetVehicleGroupByIdRoute;
            string errorMessage = string.Empty;

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {"id", vehicleGroupId}
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponse<Tuple<VehicleGroup, string>> kzBaseResponse = NewtonSoftHelper<KzBaseResponse<Tuple<VehicleGroup, string>>>.GetBaseResponse(response.Item1);
                if (kzBaseResponse == null)
                {
                    errorMessage = response.Item1;
                    return Tuple.Create<VehicleGroup, string>(null, errorMessage);
                }
                return kzBaseResponse.data;
            }
            return Tuple.Create<VehicleGroup, string>(null, errorMessage);
        }

        //--Card
        public static async Task<Tuple<Card, string>> GetCardByIdAsync(string cardId)
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetCardByIdRoute;
            string errorMessage = string.Empty;

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {"id", cardId}
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponse<Tuple<Card, string>> kzBaseResponse = NewtonSoftHelper<KzBaseResponse<Tuple<Card, string>>>.GetBaseResponse(response.Item1);
                if (kzBaseResponse == null)
                {
                    errorMessage = response.Item1;
                    return Tuple.Create<Card, string>(null, errorMessage);
                }
                return kzBaseResponse.data;
            }
            return Tuple.Create<Card, string>(null, errorMessage);
        }
        public static async Task<Tuple<Card, string>> GetCardByPlateAsync(string plate)
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetCardByPlateRoute;
            string errorMessage = string.Empty;

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {"plate", plate}
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponse<Tuple<Card, string>> kzBaseResponse = NewtonSoftHelper<KzBaseResponse<Tuple<Card, string>>>.GetBaseResponse(response.Item1);
                if (kzBaseResponse == null)
                {
                    errorMessage = response.Item1;
                    return Tuple.Create<Card, string>(null, errorMessage);
                }
                return kzBaseResponse.data;
            }
            return Tuple.Create<Card, string>(null, errorMessage);
        }
        public static async Task<Tuple<Card, string>> GetCardByCardNumberAsync(string cardnumber)
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetCardByCardNumberRoute;
            string errorMessage = string.Empty;

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {"cardnumber", cardnumber}
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    KzBaseResponse<Tuple<Card, string>> kzBaseResponse = NewtonSoftHelper<KzBaseResponse<Tuple<Card, string>>>.GetBaseResponse(response.Item1);
                    if (kzBaseResponse == null)
                    {
                        errorMessage = response.Item1;
                        return Tuple.Create<Card, string>(null, errorMessage);
                    }
                    return kzBaseResponse.data;
                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                }
            }
            return Tuple.Create<Card, string>(null, errorMessage);
        }
        public static async Task<Card> GetCardByPagingAsync(string key, int pageIndex, int pageSize, bool desc = true, int active = 1)
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetAlarmByPagingRoute;

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {"key", key},
                {"pageindex" , pageIndex.ToString() },
                {"pagesize" , pageSize.ToString() },
                {"desc" , desc.ToString() },
                {"active" , active.ToString() },
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponse<Card> kzBaseResponse = NewtonSoftHelper<KzBaseResponse<Card>>.GetBaseResponse(response.Item1);
                if (kzBaseResponse == null)
                {
                    return null;
                }
                return kzBaseResponse.data;
            }
            return null;
        }

        #endregion END -- Card Related

        #region -- System Config Related
        //--PC
        public static async Task<Computer> GetComputerByIPAddressAsync(string ipAddress)
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetPCByIpAddressRoute(ipAddress);

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponse<Computer> kzBaseResponse = NewtonSoftHelper<KzBaseResponse<Computer>>.GetBaseResponse(response.Item1);
                if (kzBaseResponse == null)
                {
                    return null;
                }
                return kzBaseResponse.data;
            }
            return null;
        }
        public static async Task<Computer> GetComputerByIdAsync(string id)
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetPCByIdRoute(id);

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponse<Computer> kzBaseResponse = NewtonSoftHelper<KzBaseResponse<Computer>>.GetBaseResponse(response.Item1);
                if (kzBaseResponse == null)
                {
                    return null;
                }
                return kzBaseResponse.data;
            }
            return null;
        }

        //--Controller
        public static async Task<List<Bdk>> GetControllerByPCId(string pcId)
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetControllerByComputerIdRoute(pcId);

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponse<List<Bdk>> kzBaseResponse = NewtonSoftHelper<KzBaseResponse<List<Bdk>>>.GetBaseResponse(response.Item1);
                if (kzBaseResponse == null)
                {
                    return null;
                }
                return kzBaseResponse.data;
            }
            return null;
        }
        public static async Task<Bdk> GetBdkByIdAsync(string controllerId)
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetControllerByIdRoute(controllerId);

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponse<Bdk> kzBaseResponse = NewtonSoftHelper<KzBaseResponse<Bdk>>.GetBaseResponse(response.Item1);
                return kzBaseResponse.data;
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
        public static async Task<Camera> GetCameraAsync(string cameraId)
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetCameraByIdRoute(cameraId);

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponse<Camera> kzBaseResponse = NewtonSoftHelper<KzBaseResponse<Camera>>.GetBaseResponse(response.Item1);
                return kzBaseResponse.data;
            }
            return null;
        }
        public static async Task<List<Camera>> GetCameraByComputerIdAsync(string computerId)
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetCameraByComputerIdRoute(computerId);

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponse<List<Camera>> kzBaseResponse = NewtonSoftHelper<KzBaseResponse<List<Camera>>>.GetBaseResponse(response.Item1);
                return kzBaseResponse.data;
            }
            return null;
        }

        //--Lane
        public static async Task<List<Lane>> GetLanesAsync(string pcId, string key = "")
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetLaneByComputerIdRoute(pcId);

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
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponse<List<Lane>> kzBaseResponse = NewtonSoftHelper<KzBaseResponse<List<Lane>>>.GetBaseResponse(response.Item1);
                return kzBaseResponse.data;
            }
            return null;
        }
        public static async Task<Lane> GetLaneByIdAsync(string laneId)
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetLaneByIdRoute(laneId);

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponse<Lane> kzBaseResponse = NewtonSoftHelper<KzBaseResponse<Lane>>.GetBaseResponse(response.Item1);
                return kzBaseResponse.data;
            }
            return null;
        }

        //--Gate
        public static async Task<List<Gate>> GetGatesAsync()
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetGateByListRoute;

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponse<List<Gate>> kzBaseResponse = NewtonSoftHelper<KzBaseResponse<List<Gate>>>.GetBaseResponse(response.Item1);
                return kzBaseResponse.data;
            }
            return null;
        }
        public static async Task<Gate> GetGateByIdAsync(string gateId)
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetGateByIdRoute(gateId);

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponse<Gate> kzBaseResponse = NewtonSoftHelper<KzBaseResponse<Gate>>.GetBaseResponse(response.Item1);
                return kzBaseResponse.data;
            }
            return null;
        }

        //--LED
        public static async Task<List<Led>> GetLedsAsync(string pcId)
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetLedByComputerIdRoute(pcId);

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponse<List<Led>> kzBaseResponse = NewtonSoftHelper<KzBaseResponse<List<Led>>>.GetBaseResponse(response.Item1);
                return kzBaseResponse.data;
            }
            return null;
        }
        public static async Task<Led> GetLedByIdAsync(string ledId)
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetLedByIdRoute(ledId);

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponse<Led> kzBaseResponse = NewtonSoftHelper<KzBaseResponse<Led>>.GetBaseResponse(response.Item1);
                return kzBaseResponse.data;
            }
            return null;
        }

        #endregion END -- System Config Related

        #region -- Event Related
        public static async Task PostCheckInAsync(CardEvent cardEvent)
        {
        }
        public static async Task PostCheckOutAsync(CardEvent cardEvent)
        {
        }
        #endregion End -- Event Related

        //-- Other

        //-- Unsorted

        //-- Vehicle Group

        //-- Customer Related

        #region -- Alarm
        public static async Task<List<Alarm>> GetAlarmByPagingAsync()
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetAlarmByPagingRoute;

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponse<List<Alarm>> kzBaseResponse = NewtonSoftHelper<KzBaseResponse<List<Alarm>>>.GetBaseResponse(response.Item1);
                return kzBaseResponse.data;
            }
            return null;
        }
        public static async Task<Alarm> GetAlarmByIdAsync(string alarmId)
        {
            StandardlizeServerName();
            string apiUrl = server + defaultRoute + KzApiUrlManagement.GetAlarmByIdRoute;

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponse<Alarm> kzBaseResponse = NewtonSoftHelper<KzBaseResponse<Alarm>>.GetBaseResponse(response.Item1);
                return kzBaseResponse.data;
            }
            return null;
        }
        public static async Task<bool> CreateAlarmAsync(Alarm alarm)
        {
            //StandardlizeServerName();
            //string apiUrl = server + defaultRoute + KzApiUrlManagement.PostLoginRoute;
            //Dictionary<string, string> headers = new Dictionary<string, string>()
            //{
            //    { "Authorization","Bearer " + token  }
            //};
            //var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, alarm, headers, null, timeOut, RestSharp.Method.Post);
            //if (!string.IsNullOrEmpty(response.Item1))
            //{
            //    KzBaseResponse kzBaseResponse = NewtonSoftHelper<KzBaseResponse>.GetBaseResponse(response.Item1);
            //    return kzBaseResponse.data;
            //}
            return false;
        }
        #endregion End Alarm

        //-- Black List

        //-- Payment

        //-- Voucher

        //-- Client Status

        #endregion END PUBLIC FUNCTION

        #region PRIVATE FUNCTION
        private static void StandardlizeServerName()
        {
            if (server[^1] != '/' && server[^1] != '\\')
            {
                server += "/";
            }
        }
        #endregion END PRIVATE FUNCTION
    }
}
