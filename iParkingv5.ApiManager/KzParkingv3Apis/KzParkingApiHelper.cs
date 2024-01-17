using iParkingv5.Objects.Datas;
using iParkingv5.Objects.EventDatas;
using iParkingv6.ApiManager.KzParkingv3Apis.Responses;
using iParkingv6.Objects.Datas;
using Kztek.Tools;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kztek.Tool;
using iParkingv5.Objects.Enums;
using Newtonsoft.Json;
using System.Net;
using Microsoft.Extensions.Logging;
using System.Security.Principal;
using iParkingv5.Objects;

namespace iParkingv6.ApiManager.KzParkingv3Apis
{
    public static class KzParkingApiHelper
    {
        public static string server = "http://14.160.26.45:13000";
        public static string username = "admin";
        public static string password = "123456";
        public static int timeOut = 10000;

        public static int expireTime = 1000;
        public static string token = string.Empty;
        public static CancellationTokenSource cts;

        class EventIdentity
        {
            public string code { get; set; }
            public IdentityType type { get; set; }
        }
        #region PUBLIC FUNCTION

        #region -- USER
        public static async Task<Tuple<string, string>> GetToken(string _username, string _password)
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.PostLoginRoute;
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
                    KzBaseResponseData<LoginResponse> kzBaseResponse = NewtonSoftHelper<KzBaseResponseData<LoginResponse>>.GetBaseResponse(response.Item1);
                    if (kzBaseResponse == null)
                        return Tuple.Create<string, string>(string.Empty, "Data không hợp lệ");
                    if (kzBaseResponse.data != null)
                    {
                        token = kzBaseResponse.data.accessToken;
                        expireTime = kzBaseResponse.data.expireInSeconds;
                    }
                    return Tuple.Create<string, string>(token, kzBaseResponse.metadata?.message?.value ?? "");
                }
                catch (Exception ex)
                {
                    LogHelper.Log(logType: LogHelper.EmLogType.ERROR,
                              doi_tuong_tac_dong: LogHelper.EmObjectLogType.Api,
                              obj: ex);
                }
            }
            return Tuple.Create<string, string>(response.Item1, string.Empty);

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
                    string _token = (await GetToken(username, password)).Item1;
                    if (string.IsNullOrEmpty(_token))
                    {
                        delayTime = 1000;
                    }
                    else
                    {
                        token = _token;
                        delayTime = 15 * 60 * 1000;
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
        #endregion END -- USER

        #region -- CAMERA
        public static async Task<Camera> GetCameraAsync(string cameraId)
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.Camera.GetDataByIdRoute(cameraId);

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponseData<Camera> kzBaseResponse = NewtonSoftHelper<KzBaseResponseData<Camera>>.GetBaseResponse(response.Item1);
                return kzBaseResponse?.data;
            }
            return null;
        }
        public static async Task<List<Camera>> GetCameraByComputerIdAsync(string computerId)
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.Camera.GetDataByParamsRoute();

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "computerId", computerId }
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponseData<List<Camera>> kzBaseResponse = NewtonSoftHelper<KzBaseResponseData<List<Camera>>>.GetBaseResponse(response.Item1);
                return kzBaseResponse?.data;
            }
            return null;
        }
        #endregion

        #region -- LANE
        public static async Task<List<Lane>> GetLanesAsync(string pcId)
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.Lane.GetDataByParamsRoute();

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "computerId",pcId}
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponseData<List<Lane>> kzBaseResponse = NewtonSoftHelper<KzBaseResponseData<List<Lane>>>.GetBaseResponse(response.Item1);
                return kzBaseResponse?.data;
            }
            return null;
        }
        public static async Task<Lane> GetLaneByIdAsync(string laneId)
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.Lane.GetDataByIdRoute(laneId);

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponseData<Lane> kzBaseResponse = NewtonSoftHelper<KzBaseResponseData<Lane>>.GetBaseResponse(response.Item1);
                return kzBaseResponse?.data;
            }
            return null;
        }
        #endregion

        #region -- PARKING LED
        public static async Task<List<Led>> GetLedsAsync(string pcId)
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.Led.GetDataByParamsRoute();

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "computerId",pcId  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponseData<List<Led>> kzBaseResponse = NewtonSoftHelper<KzBaseResponseData<List<Led>>>.GetBaseResponse(response.Item1);
                return kzBaseResponse?.data;
            }
            return null;
        }
        public static async Task<Led> GetLedByIdAsync(string ledId)
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.Led.GetDataByIdRoute(ledId);

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponseData<Led> kzBaseResponse = NewtonSoftHelper<KzBaseResponseData<Led>>.GetBaseResponse(response.Item1);
                return kzBaseResponse?.data;
            }
            return null;
        }
        #endregion

        #region -- CONTROL UNIT
        public static async Task<List<Bdk>> GetControllerByPCId(string pcId)
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.ControlUnit.GetDataByParamsRoute();

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "computerId",pcId  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponseData<List<Bdk>> kzBaseResponse = NewtonSoftHelper<KzBaseResponseData<List<Bdk>>>.GetBaseResponse(response.Item1);
                if (kzBaseResponse == null)
                {
                    return null;
                }
                return kzBaseResponse?.data;
            }
            return null;
        }
        public static async Task<Bdk> GetBdkByIdAsync(string controllerId)
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.ControlUnit.GetDataByIdRoute(controllerId);

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponseData<Bdk> kzBaseResponse = NewtonSoftHelper<KzBaseResponseData<Bdk>>.GetBaseResponse(response.Item1);
                return kzBaseResponse?.data;
            }
            return null;
        }
        #endregion

        #region -- COMPUTER
        public static async Task<Computer> GetComputerByIPAddressAsync(string ipAddress)
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.Computer.GetDataByParamsRoute();

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "keyword", ipAddress  }
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponseData<List<Computer>> kzBaseResponse = NewtonSoftHelper<KzBaseResponseData<List<Computer>>>.GetBaseResponse(response.Item1);
                if (kzBaseResponse?.data != null)
                {
                    if (kzBaseResponse?.data.Count > 0)
                    {
                        return kzBaseResponse?.data[0];
                    }
                }
                return null;
            }
            return null;
        }
        public static async Task<Computer> GetComputerByIdAsync(string id)
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.Computer.GetDataByParamsRoute();

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "keyword", id  }
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponseData<Computer> kzBaseResponse = NewtonSoftHelper<KzBaseResponseData<Computer>>.GetBaseResponse(response.Item1);
                if (kzBaseResponse == null)
                {
                    return null;
                }
                return kzBaseResponse?.data;
            }
            return null;
        }
        #endregion

        #region -- GATE
        public static async Task<List<Gate>> GetGatesAsync()
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.Gate.GetDataByParamsRoute();

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponseData<List<Gate>> kzBaseResponse = NewtonSoftHelper<KzBaseResponseData<List<Gate>>>.GetBaseResponse(response.Item1);
                return kzBaseResponse?.data;
            }
            return null;
        }
        public static async Task<Gate> GetGateByIdAsync(string gateId)
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.Gate.GetDataByIdRoute(gateId);

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponseData<Gate> kzBaseResponse = NewtonSoftHelper<KzBaseResponseData<Gate>>.GetBaseResponse(response.Item1);
                return kzBaseResponse?.data;
            }
            return null;
        }
        #endregion

        #region -- VEHICLE TYPE
        public static async Task<VehicleType> GetVehicleTypeById(string id)
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.VehicleType.GetDataByIdRoute(id);

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponseData<VehicleType> kzBaseResponse = NewtonSoftHelper<KzBaseResponseData<VehicleType>>.GetBaseResponse(response.Item1);
                return kzBaseResponse?.data;
            }
            return null;
        }
        public static async Task<List<VehicleType>> GetAllVehicleTypes()
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.VehicleType.GetDataByParamsRoute();

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponseData<List<VehicleType>> kzBaseResponse = NewtonSoftHelper<KzBaseResponseData<List<VehicleType>>>.GetBaseResponse(response.Item1);
                return kzBaseResponse?.data;
            }
            return null;
        }
        #endregion

        #region -- IDENTITY
        public static async Task<Identity> GetIdentityById(string id)
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.Identity.GetDataByIdRoute(id);

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponseData<Identity> kzBaseResponse = NewtonSoftHelper<KzBaseResponseData<Identity>>.GetBaseResponse(response.Item1);
                if (kzBaseResponse?.data != null)
                {
                    return kzBaseResponse?.data;
                }
            }
            return null;
        }

        public static async Task<Tuple<Identity, bool>> GetIdentityByCode(string code)
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.Identity.GetDataByParamsRoute();

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "keyword", code  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponseData<List<Identity>> kzBaseResponse = NewtonSoftHelper<KzBaseResponseData<List<Identity>>>.GetBaseResponse(response.Item1);
                if (kzBaseResponse?.data != null)
                {
                    if (kzBaseResponse?.data.Count > 0)
                    {
                        return Tuple.Create<Identity, bool>(kzBaseResponse?.data[0], true);
                    }
                    else
                    {
                        return Tuple.Create<Identity, bool>(null, kzBaseResponse.metadata.success);
                    }
                }
                return Tuple.Create<Identity, bool>(null, false);
            }
            return Tuple.Create<Identity, bool>(null, false);
        }
        public static async Task<List<Identity>> GetAllIdentity()
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.Identity.GetDataByParamsRoute();

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponseData<List<Identity>> kzBaseResponse = NewtonSoftHelper<KzBaseResponseData<List<Identity>>>.GetBaseResponse(response.Item1);
                return kzBaseResponse?.data;
            }
            return null;
        }
        #endregion

        #region -- IDENTITY GROUP
        public static async Task<IdentityGroup> GetIdentityGroupByIdAsync(string id)
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.IdentityGroup.GetDataByIdRoute(id);

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponseData<IdentityGroup> kzBaseResponse = NewtonSoftHelper<KzBaseResponseData<IdentityGroup>>.GetBaseResponse(response.Item1);
                return kzBaseResponse?.data;
            }
            return null;
        }

        #endregion

        #region -- EVENT IN
        public static async Task<Tuple<bool, AddEventInResponse>> PostCheckInAsync(string _laneId, string _plateNumber, Identity? identity, List<string> imageKeys, bool isForce = false)
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.EventIn.CreateRoute();
            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var data = new
            {
                laneId = _laneId,
                plateNumber = _plateNumber,
                identityCode = identity == null ? null : identity?.Code,
                identityType = identity == null ? null : identity?.Type,
                forceEntrance = isForce,
                fileKeys = new List<string>()
            };

            foreach (var item in imageKeys)
            {
                data.fileKeys.Add(item);
            }
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, data, headers, null, timeOut, RestSharp.Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    KzBaseResponseData<AddEventInResponse> addEventInResponse = NewtonSoftHelper<KzBaseResponseData<AddEventInResponse>>.GetBaseResponse(response.Item1);
                    if (addEventInResponse != null)
                    {
                        if (addEventInResponse.metadata.success)
                        {
                            return Tuple.Create<bool, AddEventInResponse>(true, addEventInResponse.data);
                        }
                        else
                        {
                            return Tuple.Create<bool, AddEventInResponse>(false, new AddEventInResponse() { ErrorMessage = addEventInResponse.metadata.message.value });
                        }
                    }
                    else
                    {
                        return Tuple.Create<bool, AddEventInResponse>(false, null);
                    }
                }
                catch (Exception)
                {
                    return Tuple.Create<bool, AddEventInResponse>(false, new AddEventInResponse() { ErrorMessage = response.Item1 });
                }

            }
            return Tuple.Create<bool, AddEventInResponse>(false, null);
        }
        public static async Task<List<string>> GetFileIns(List<int> fileIds)
        {
            //StandardlizeServerName();
            //string apiUrl = server + KzApiUrlManagement.GetFileNamesRoute(fileIds);
            ////Gửi API
            //Dictionary<string, string> headers = new Dictionary<string, string>()
            //{
            //    { "Authorization","Bearer " + token  }
            //};

            //var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            //if (!string.IsNullOrEmpty(response.Item1))
            //{
            //    KzBaseResponseData<List<string>> files = NewtonSoftHelper<KzBaseResponseData<List<string>>>.GetBaseResponse(response.Item1);
            //    return files?.data;
            //}
            return null;
        }
        public static async Task<Tuple<bool, string>> UpdateEventInPlate(string eventId, string plate)
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.EventIn.UpdateRouteById(eventId);

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var data = new
            {
                plateNumber = plate
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, data, headers, null, timeOut, RestSharp.Method.Put);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponse kzBaseResponse = NewtonSoftHelper<KzBaseResponse>.GetBaseResponse(response.Item1);
                if (kzBaseResponse == null)
                {
                    return Tuple.Create<bool, string>(false, "Lỗi dữ liệu, vui lòng thử lại");
                }
                if (!kzBaseResponse.isSuccess)
                {
                    return Tuple.Create<bool, string>(false, kzBaseResponse.message);
                }
                return Tuple.Create<bool, string>(true, string.Empty);
            }
            return Tuple.Create<bool, string>(false, "Lỗi hệ thống, vui lòng thử lại");
        }
        public static async Task<Tuple<List<EventInReport>, int, int>> GetEventIns(string keyword, DateTime startTime, DateTime endTime, int pageIndex = 1, int pageSize = 25)
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.EventIn.GetDataByParamsRoute();
            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(keyword))
            {
                parameters.Add("keyword", keyword);
            }
            parameters.Add("fromUtc", startTime.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.000Z"));
            parameters.Add("toUtc", endTime.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.000Z"));
            parameters.Add("pageIndex", pageIndex.ToString());
            parameters.Add("pageSize", pageSize.ToString());

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                BaseReport<EventInReport> reports = NewtonSoftHelper<BaseReport<EventInReport>>.GetBaseResponse(response.Item1);
                if (reports != null)
                {
                    if (reports.data == null)
                    {
                        return Tuple.Create<List<EventInReport>, int, int>(null, 0, 0);
                    }
                    int totalCount = reports.paging.totalItem;
                    int totalPage = reports.paging.totalPage;
                    return Tuple.Create(reports?.data, totalPage, totalCount);
                }
                return Tuple.Create<List<EventInReport>, int, int>(null, 0, 0);
            }
            return Tuple.Create<List<EventInReport>, int, int>(null, 0, 0);
        }

        #endregion

        #region -- EVENT OUT
        public static async Task<AddEventOutResponse> PostCheckOutAsync(string _laneId, string _plateNumber, Identity? identitiy, List<string> imageKeys, bool isForce)
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.EventOut.CreateRoute();
            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var data = new
            {
                laneId = _laneId,
                plateNumber = _plateNumber,
                identityCode = identitiy == null ? null : identitiy?.Code,
                identityType = identitiy == null ? null : identitiy?.Type,
                identities = new List<EventIdentity>(),
                fileKeys = new List<string>(),
                forceEntrance = isForce,
            };
            foreach (var item in imageKeys)
            {
                data.fileKeys.Add(item);
            }
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, data, headers, null, timeOut, RestSharp.Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponseData<AddEventOutResponse> addEventOutResponse = NewtonSoftHelper<KzBaseResponseData<AddEventOutResponse>>.GetBaseResponse(response.Item1);
                if (addEventOutResponse != null)
                {
                    if (addEventOutResponse.data != null)
                    {
                        addEventOutResponse.data.ErrorMessage = addEventOutResponse?.metadata?.message?.value;
                        return addEventOutResponse.data;
                    }
                }
            }
            return null;
        }
        public static async Task<Tuple<bool, string>> UpdateEventOutPlate(string eventId, string plate)
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.EventOut.UpdateRouteById(eventId);

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var data = new
            {
                plateNumber = plate
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, data, headers, null, timeOut, RestSharp.Method.Put);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponse kzBaseResponse = NewtonSoftHelper<KzBaseResponse>.GetBaseResponse(response.Item1);
                if (kzBaseResponse == null)
                {
                    return Tuple.Create<bool, string>(false, "Lỗi dữ liệu, vui lòng thử lại");
                }
                if (!kzBaseResponse.isSuccess)
                {
                    return Tuple.Create<bool, string>(false, kzBaseResponse.message);
                }
                return Tuple.Create<bool, string>(true, string.Empty);
            }
            return Tuple.Create<bool, string>(false, "Lỗi hệ thống, vui lòng thử lại");
        }
        public static async Task<Tuple<List<EventOutReport>, int, int>> GetEventOuts(string keyword, DateTime startTime, DateTime endTime, int pageIndex = 1, int pageSize = 25)
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.EventOut.GetDataByParamsRoute();

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(keyword))
            {
                parameters.Add("keyword", keyword);
            }
            parameters.Add("fromUtc", startTime.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.000Z"));
            parameters.Add("toUtc", endTime.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.000Z"));
            parameters.Add("pageIndex", pageIndex.ToString());
            parameters.Add("pageSize", pageSize.ToString());


            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                BaseReport<EventOutReport> reports = NewtonSoftHelper<BaseReport<EventOutReport>>.GetBaseResponse(response.Item1);
                if (reports != null)
                {
                    if (reports.data == null)
                    {
                        return Tuple.Create<List<EventOutReport>, int, int>(null, 0, 0);
                    }
                    int totalCount = reports.paging.totalItem;
                    int totalPage = reports.paging.totalPage;
                    return Tuple.Create<List<EventOutReport>, int, int>(reports?.data, totalPage, totalCount);
                }
                return Tuple.Create<List<EventOutReport>, int, int>(null, 0, 0);
            }
            return Tuple.Create<List<EventOutReport>, int, int>(null, 0, 0);
        }

        public class BaseReport<T> where T : class
        {
            public Paging paging { get; set; }
            public MetaData metaData { get; set; }
            public List<T> data { get; set; }
        }
        public class Paging
        {
            public int pageIndex { get; set; }
            public int pageSize { get; set; }
            public int totalItem { get; set; }
            public int totalPage { get; set; }
        }
        public class EventInReport
        {
            public string id { get; set; }
            public string identityId { get; set; }
            public string laneId { get; set; }
            public string plateNumber { get; set; }
            public int status { get; set; }
            public object lastPaymentUtc { get; set; }
            public int fee { get; set; }
            public int paid { get; set; }
            public int discount { get; set; }
            public string createdUtc { get; set; }
            public string createdBy { get; set; }
            public string[]? fileKeys { get; set; }
            [JsonIgnore]
            public DateTime? DatetimeIn
            {
                get
                {
                    try
                    {
                        if (createdUtc.Contains("T"))
                        {
                            return DateTime.ParseExact(createdUtc.Substring(0, "yyyy-MM-ddTHH:mm:ss".Length), "yyyy-MM-ddTHH:mm:ss", null).AddHours(7);
                        }
                        else
                        {
                            return DateTime.Parse(createdUtc).AddHours(7);
                        }
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
        }
        public class EventOutReport
        {
            //Thông tin sự kiện ra
            public string id { get; set; }
            public string identityId { get; set; }
            public string laneId { get; set; }
            public string plateNumber { get; set; }
            public string[] fileKeys { get; set; }
            public string lastPaymentUtc { get; set; }
            public int fee { get; set; }
            public int discount { get; set; }
            public int paid { get; set; }
            public bool free { get; set; }
            public string createdUtc { get; set; }
            public string createdBy { get; set; }

            //Thông tin sự kiện vào
            public string eventInIdentityId { get; set; }
            public string eventInLaneId { get; set; }
            public string eventInPlateNumber { get; set; }
            public string eventInCreatedUtc { get; set; }
            public string eventInCreatedBy { get; set; }
            public string[] eventInFileKeys { get; set; }

            [JsonIgnore]
            public DateTime? DatetimeOut
            {
                get
                {
                    try
                    {
                        if (createdUtc.Contains("T"))
                        {
                            return DateTime.ParseExact(createdUtc.Substring(0, "yyyy-MM-ddTHH:mm:ss".Length), "yyyy-MM-ddTHH:mm:ss", null).AddHours(7);
                        }
                        else
                        {
                            return DateTime.Parse(createdUtc).AddHours(7);
                        }
                    }
                    catch
                    {
                        return null;
                    }
                }
            }

            [JsonIgnore]
            public DateTime? DatetimeIn
            {
                get
                {
                    try
                    {
                        if (eventInCreatedUtc.Contains("T"))
                        {
                            return DateTime.ParseExact(eventInCreatedUtc.Substring(0, "yyyy-MM-ddTHH:mm:ss".Length), "yyyy-MM-ddTHH:mm:ss", null).AddHours(7);
                        }
                        else
                        {
                            return DateTime.Parse(eventInCreatedUtc).AddHours(7);
                        }
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
        }
        #endregion

        #region ABNORMAL
        public static async Task<List<AbnormalEvent>> GetAlarms()
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.AbnormalEvent.GetDataByParamsRoute();

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponseData<List<AbnormalEvent>> kzBaseResponse = NewtonSoftHelper<KzBaseResponseData<List<AbnormalEvent>>>.GetBaseResponse(response.Item1);
                return kzBaseResponse?.data;
            }
            return null;
        }

        public static async Task<bool> CreateAlarmAsync(string identityId, string laneId, string plate, AbnormalCode abnormalCode,
                                                        string imageKey, bool isLaneIn)
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.AbnormalEvent.CreateRoute();
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            AbnormalEvent abnormalEvent = new AbnormalEvent()
            {
                IdentityId = identityId,
                LaneId = laneId,
                PlateNumber = plate,
                AbnormalCode = abnormalCode,
                FileKeys = new List<string>()
                    {
                         imageKey + (isLaneIn? "_OVERVIEWIN.jpeg" : "_OVERVIEWOUT.jpeg"),
                         imageKey + (isLaneIn? "_VEHICLEIN.jpeg" : "_VEHICLEOUT.jpeg"),
                         imageKey + (isLaneIn? "_LPRIN.jpeg" : "_LPROUT.jpeg"),
                    },
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, abnormalEvent, headers, null, timeOut, RestSharp.Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponse kzBaseResponse = NewtonSoftHelper<KzBaseResponse>.GetBaseResponse(response.Item1);
                return kzBaseResponse?.isSuccess ?? false;
            }
            return false;
        }
        #endregion

        #region -- REGISTERED VEHICLE
        public static async Task<RegisteredVehicle> GetRegisteredVehicle(string plateNumber)
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.RegisteredVehicle.GetDataByParamsRoute();

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "keyword", plateNumber }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponseData<List<RegisteredVehicle>> kzBaseResponse = NewtonSoftHelper<KzBaseResponseData<List<RegisteredVehicle>>>.GetBaseResponse(response.Item1);
                if (kzBaseResponse?.data != null)
                {
                    if (kzBaseResponse?.data.Count > 0)
                    {
                        return kzBaseResponse?.data[0];
                    }
                }
                return null;
            }
            return null;
        }
        public static async Task<Tuple<bool, string>> CreateRegisteredVehicle(RegisteredVehicle registeredVehicle)
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.RegisteredVehicle.CreateRoute();

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, registeredVehicle, headers, null, timeOut, RestSharp.Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponseData<RegisteredVehicle> kzBaseResponse = NewtonSoftHelper<KzBaseResponseData<RegisteredVehicle>>.GetBaseResponse(response.Item1);
                if (kzBaseResponse == null)
                {
                    return Tuple.Create<bool, string>(false, "Lỗi dữ liệu, vui lòng thử lại");
                }
                if (!kzBaseResponse.metadata.success)
                {
                    return Tuple.Create<bool, string>(false, kzBaseResponse.metadata.message.value);
                }
                return Tuple.Create<bool, string>(true, string.Empty);
            }
            return Tuple.Create<bool, string>(false, "Lỗi hệ thống, vui lòng thử lại");
        }
        #endregion

        #region -- CUSTOMER
        public static async Task<Tuple<bool, string>> CreateCustomer(Customer customer)
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.Customer.CreateRoute();

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, customer, headers, null, timeOut, RestSharp.Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponseData<Customer> kzBaseResponse = NewtonSoftHelper<KzBaseResponseData<Customer>>.GetBaseResponse(response.Item1);

                if (kzBaseResponse == null)
                {
                    return Tuple.Create<bool, string>(false, "Lỗi dữ liệu, vui lòng thử lại");
                }
                if (!kzBaseResponse.metadata.success)
                {
                    return Tuple.Create<bool, string>(false, kzBaseResponse.metadata.message.value);
                }
                return Tuple.Create<bool, string>(true, string.Empty);
            }
            return Tuple.Create<bool, string>(false, "Lỗi hệ thống, vui lòng thử lại");
        }
        public static async Task<Tuple<bool, string>> DeleteCustomerById(string customerId)
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.Customer.DeleteByIdRoute(customerId);

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Delete);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponse kzBaseResponse = NewtonSoftHelper<KzBaseResponse>.GetBaseResponse(response.Item1);

                if (kzBaseResponse == null)
                {
                    return Tuple.Create<bool, string>(false, "Lỗi dữ liệu, vui lòng thử lại");
                }
                if (!kzBaseResponse.isSuccess)
                {
                    return Tuple.Create<bool, string>(false, kzBaseResponse.message);
                }
                return Tuple.Create<bool, string>(true, string.Empty);
            }
            return Tuple.Create<bool, string>(false, "Lỗi hệ thống, vui lòng thử lại");
        }
        public static async Task<Tuple<List<Customer>, string>> GetCustomerByCode(string code)
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.Customer.GetDataByParamsRoute();

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "keyword",code  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponseData<List<Customer>> kzBaseResponse = NewtonSoftHelper<KzBaseResponseData<List<Customer>>>.GetBaseResponse(response.Item1);
                if (kzBaseResponse != null)
                {
                    return Tuple.Create<List<Customer>, string>(null, response.Item2);
                }
                else
                {
                    if (kzBaseResponse.metadata.success)
                    {
                        return Tuple.Create<List<Customer>, string>(kzBaseResponse?.data, kzBaseResponse.metadata?.message?.value);
                    }
                    else
                    {
                        return Tuple.Create<List<Customer>, string>(null, kzBaseResponse.metadata?.message?.value);
                    }
                }
            }
            return Tuple.Create<List<Customer>, string>(null, response.Item2);
        }
        public static async Task<Tuple<List<Customer>, string>> GetAllCustomers(string name = "", string customerGroupId = "")
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.Customer.GetDataByParamsRoute();

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {"keyword", name },
                {"customerGroupId", customerGroupId },
                {"enable", "true" },
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponseData<List<Customer>> kzBaseResponse = NewtonSoftHelper<KzBaseResponseData<List<Customer>>>.GetBaseResponse(response.Item1);
                if (kzBaseResponse == null)
                {
                    return Tuple.Create<List<Customer>, string>(null, response.Item2);
                }
                else
                {
                    if (kzBaseResponse.metadata.success)
                    {
                        return Tuple.Create<List<Customer>, string>(kzBaseResponse?.data, kzBaseResponse.metadata?.message?.value ?? "");
                    }
                    else
                    {
                        return Tuple.Create<List<Customer>, string>(null, kzBaseResponse.metadata?.message?.value);
                    }
                }
            }
            return Tuple.Create<List<Customer>, string>(null, response.Item2);
        }
        #endregion

        #region -- CUSTOMER GROUP
        public static async Task<List<CustomerGroup>> GetAllCustomerGroups()
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.CustomerGroup.GetDataByParamsRoute();

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponseData<List<CustomerGroup>> kzBaseResponse = NewtonSoftHelper<KzBaseResponseData<List<CustomerGroup>>>.GetBaseResponse(response.Item1);
                return kzBaseResponse?.data;
            }
            return null;
        }
        #endregion

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
