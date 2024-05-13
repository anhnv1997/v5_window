using iParkingv5.Objects;
using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Enums;
using iParkingv5.Objects.EventDatas;
using iParkingv5.Objects.Invoices;
using iParkingv6.ApiManager;
using iParkingv6.ApiManager.KzParkingv3Apis;
using iParkingv6.Objects.Datas;
using Kztek.Tool;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using static iParkingv5.ApiManager.KzParkingv5Apis.Filter;
using static iParkingv5.ApiManager.KzParkingv5Apis.KzParkingv5ApiHelper;
using static iParkingv6.ApiManager.KzParkingv3Apis.KzParkingApiHelper;
using static iParkingv6.ApiManager.KzParkingv3Apis.KzParkingApiHelper.TransactionType;

namespace iParkingv5.ApiManager.KzParkingv5Apis
{
    public static class KzParkingv5ApiHelper
    {
        #region SubClass
        public class BaseEventReport<T> where T : class
        {
            public List<T> rows { get; set; }
        }
        public class CommitData
        {
            public string op { get; set; }
            public string path { get; set; }
            public object value { get; set; }
        }
        #endregion End SubClass

        #region Properties
        public static string server = "http://14.160.26.45:5000";
        public static string username = "admin";
        public static string password = "123456";
        public static int timeOut = 10000;
        public static string refresh_token = "";
        public static string client_id = "";
        public static int expireTime = 1000;
        public static string token = string.Empty;
        public static CancellationTokenSource cts;
        #endregion End Properties

        #region Base
        #region GET
        /// <summary>
        /// Lấy tất cả dữ liệu lưu trong database 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public static async Task<Tuple<List<T>, string>> GetAllObjectAsync<T>(
            KzParkingv5ApiUrlManagement.EmParkingv5ObjectType objectType) where T : class
        {
            StandardlizeServerName();
            string apiUrl = server + KzParkingv5ApiUrlManagement.SearchObjectDataRoute(objectType);

            var filter = Filter.CreateFilter(new FilterModel());
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, filter, headers, null,
                                                                   timeOut, RestSharp.Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzParkingv5BaseResponse<List<T>> kzBaseResponse =
                    NewtonSoftHelper<KzParkingv5BaseResponse<List<T>>>.GetBaseResponse(response.Item1);
                if (kzBaseResponse == null)
                {
                    return Tuple.Create<List<T>, string>(null, "Error Convert Json Data" + response.Item1);
                }
                if (kzBaseResponse.data == null)
                {
                    return Tuple.Create<List<T>, string>(null, kzBaseResponse.detailCode);
                }
                return Tuple.Create<List<T>, string>(kzBaseResponse.data, kzBaseResponse.detailCode);
            }
            return Tuple.Create<List<T>, string>(null, "Empty Data");
        }

        /// <summary>
        /// Lấy bản ghi có điều kiện = điều kiện tìm kiếm
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectType"></param>
        /// <param name="emPageSearchType"></param>
        /// <param name="emPageSearchKey"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static async Task<Tuple<T, string>> GetTop1ObjectAsync<T>(
            KzParkingv5ApiUrlManagement.EmParkingv5ObjectType objectType,
            EmPageSearchType emPageSearchType, EmPageSearchKey emPageSearchKey, string searchValue) where T : class
        {
            StandardlizeServerName();
            string apiUrl = server + KzParkingv5ApiUrlManagement.SearchObjectDataRoute(objectType);

            var filter = Filter.CreateFilter(new FilterModel(emPageSearchKey, emPageSearchType, searchValue, EmOperation._eq));
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, filter, headers, null,
                                                                   timeOut, RestSharp.Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzParkingv5BaseResponse<List<T>> kzBaseResponse =
                    NewtonSoftHelper<KzParkingv5BaseResponse<List<T>>>.GetBaseResponse(response.Item1);
                if (kzBaseResponse == null)
                {
                    return Tuple.Create<T, string>(null, "Error Convert Json Data" + response.Item1);
                }
                if (kzBaseResponse.data == null)
                {
                    return Tuple.Create<T, string>(null, kzBaseResponse.detailCode);
                }
                return Tuple.Create<T, string>(kzBaseResponse.data.Count > 0 ? kzBaseResponse.data[0] : null, kzBaseResponse.detailCode);
            }
            return Tuple.Create<T, string>(null, "Empty Data");
        }

        /// <summary>
        /// Lấy bản ghi có điều kiện = điều kiện tìm kiếm
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectType"></param>
        /// <param name="emPageSearchType"></param>
        /// <param name="emPageSearchKey"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static async Task<Tuple<List<T>, string>> GetObjectByConditionAsync<T>(
            KzParkingv5ApiUrlManagement.EmParkingv5ObjectType objectType,
            EmPageSearchType emPageSearchType, EmPageSearchKey emPageSearchKey, string searchValue, EmOperation operation) where T : class
        {
            StandardlizeServerName();
            string apiUrl = server + KzParkingv5ApiUrlManagement.SearchObjectDataRoute(objectType);

            var filter = Filter.CreateFilter(new FilterModel(emPageSearchKey, emPageSearchType, searchValue, operation));
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, filter, headers, null,
                                                                   timeOut, RestSharp.Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzParkingv5BaseResponse<List<T>> kzBaseResponse =
                    NewtonSoftHelper<KzParkingv5BaseResponse<List<T>>>.GetBaseResponse(response.Item1);
                if (kzBaseResponse == null)
                {
                    return Tuple.Create<List<T>, string>(null, "Error Convert Json Data" + response.Item1);
                }
                if (kzBaseResponse.data == null)
                {
                    return Tuple.Create<List<T>, string>(null, kzBaseResponse.detailCode);
                }
                return Tuple.Create<List<T>, string>(kzBaseResponse.data, kzBaseResponse.detailCode);
            }
            return Tuple.Create<List<T>, string>(null, "Empty Data");
        }

        /// <summary>
        /// Lấy bản ghi có điều kiện = điều kiện tìm kiếm
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<Tuple<T, string>> GetObjectDetailByIdAsync<T>(
            KzParkingv5ApiUrlManagement.EmParkingv5ObjectType objectType, string id) where T : class
        {
            StandardlizeServerName();
            string apiUrl = server + KzParkingv5ApiUrlManagement.GetObjectDataDetailRoute(objectType, id);

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null,
                                                                   timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response.Item1);
                return Tuple.Create<T, string>(data, response.Item2);
            }
            return Tuple.Create<T, string>(null, "Empty Data");
        }
        #endregion END GET

        #region ADD
        public static async Task<Tuple<T, string>> CreateObjectAsync<T>(
                                    KzParkingv5ApiUrlManagement.EmParkingv5ObjectType objectType,
                                    T obj) where T : class
        {
            StandardlizeServerName();
            string apiUrl = server + KzParkingv5ApiUrlManagement.PostObjectRoute(objectType);

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, obj, headers, null,
                                                                  timeOut, Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response.Item1);
                return Tuple.Create<T, string>(data, response.Item2);
            }
            return Tuple.Create<T, string>(null, "Empty Data");
        }
        #endregion End ADD

        #endregion End Base

        #region USER
        public class User
        {
            public string id { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string upn { get; set; }
            public object[] groups { get; set; }
            public string[] rightHashes { get; set; }
            public object[] objectRightHashes { get; set; }
            public string[] rights { get; set; }
            public object[] objectRights { get; set; }
        }

        public static async Task GetUserInfor()
        {
            StandardlizeServerName();
            string apiUrl = server + "user/info";

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null,
                                                                  timeOut, Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    User user = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(response.Item1);
                    StaticPool.userId = user.id;
                    StaticPool.user_name = user.upn;
                }
                catch (Exception)
                {

                }
            }
        }
        public static async Task<Tuple<List<User>, string>> GetAllUsers()
        {
            return await GetAllObjectAsync<User>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.User);
        }
        #endregion

        #region Computer --OK
        public static async Task<Tuple<List<Computer>, string>> GetComputersAsync()
        {
            return await GetAllObjectAsync<Computer>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Computer);
        }
        public static async Task<Tuple<Computer, string>> GetComputerByIPAsync(string ip)
        {
            return await GetTop1ObjectAsync<Computer>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Computer,
                                                      EmPageSearchType.TEXT, EmPageSearchKey.IpAddress, ip);
        }
        #endregion End Computer

        #region Gate --OK
        public static async Task<Tuple<List<Gate>, string>> GetGatesAsync()
        {
            return await GetAllObjectAsync<Gate>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Gate);
        }
        public static async Task<Tuple<Gate, string>> GetGateByIdAsync(string gateId)
        {
            return await GetObjectDetailByIdAsync<Gate>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Gate, gateId);
        }
        #endregion End Gate

        #region Camera
        public static async Task<Tuple<List<Camera>, string>> GetCamerasAsync()
        {
            return await GetAllObjectAsync<Camera>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Camera);
        }
        public static async Task<Tuple<List<Camera>, string>> GetCameraByComputerIdAsync(string computerId)
        {
            return await GetObjectByConditionAsync<Camera>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Camera,
                                                           EmPageSearchType.GUID, EmPageSearchKey.ComputerId, computerId, EmOperation._eq);
        }
        #endregion End Camera

        #region Lane
        public static async Task<Tuple<List<Lane>, string>> GetLanesAsync()
        {
            return await GetAllObjectAsync<Lane>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Lane);
        }
        public static async Task<Tuple<List<Lane>, string>> GetLaneByComputerIdAsync(string computerId)
        {
            return await GetObjectByConditionAsync<Lane>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Lane,
                                                        EmPageSearchType.GUID, EmPageSearchKey.ComputerId, computerId, EmOperation._eq);

        }
        public static async Task<Tuple<Lane, string>> GetLaneByIdAsync(string laneId)
        {
            return await GetObjectDetailByIdAsync<Lane>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Lane, laneId);
        }
        #endregion End Lane

        #region Parking Led
        public static async Task<Tuple<List<Led>, string>> GetLedsAsync()
        {
            return await GetAllObjectAsync<Led>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Led);
        }
        public static async Task<Tuple<List<Led>, string>> GetLedByComputerIdAsync(string computerId)
        {
            return await GetObjectByConditionAsync<Led>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Led,
                                                        EmPageSearchType.GUID, EmPageSearchKey.ComputerId, computerId, EmOperation._eq);
        }
        #endregion End Parking Led

        #region Control Unit
        public static async Task<Tuple<List<Bdk>, string>> GetControlUnitsAsync()
        {
            return await GetAllObjectAsync<Bdk>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.ControlUnit);
        }
        public static async Task<Tuple<List<Bdk>, string>> GetControlUnitByComputerIdAsync(string computerId)
        {
            return await GetObjectByConditionAsync<Bdk>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.ControlUnit,
                                                        EmPageSearchType.GUID, EmPageSearchKey.ComputerId, computerId, EmOperation._eq);
        }
        #endregion End Control Unit

        #region Vehicle Type
        public static async Task<Tuple<VehicleType, string>> GetVehicleTypeByIdAsync(string vehicleTypeId)
        {
            return await GetObjectDetailByIdAsync<VehicleType>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.VehicleType, vehicleTypeId);
        }
        public static async Task<Tuple<List<VehicleType>, string>> GetVehicleTypesAsync()
        {
            return await GetAllObjectAsync<VehicleType>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.VehicleType);
        }
        public static async Task<Tuple<List<VehicleType>, string>> GetVehicleTypesAsync(string keyword)
        {
            return await GetObjectByConditionAsync<VehicleType>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.VehicleType,
                                                        EmPageSearchType.TEXT, EmPageSearchKey.name, keyword, EmOperation._contains);

        }
        #endregion End Vehicle Type

        #region Identity
        public static async Task<Tuple<Identity, string>> GetIdentityByIdAsync(string id)
        {
            return await GetObjectDetailByIdAsync<Identity>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Identity, id);
        }
        public static async Task<Tuple<List<Identity>, string>> GetIdentitiesAsync(string keyword)
        {
            return await GetObjectByConditionAsync<Identity>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Identity,
                                                        EmPageSearchType.TEXT, EmPageSearchKey.name, keyword, EmOperation._contains);

        }
        public static async Task<Tuple<Identity, string>> GetIdentityByCodeAsync(string code)
        {
            return await GetTop1ObjectAsync<Identity>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Identity, EmPageSearchType.TEXT,
                                                      EmPageSearchKey.code, code);
        }
        #endregion End Identity

        #region Identity Group
        public static async Task<Tuple<IdentityGroup, string>> GetIdentityGroupByIdAsync(string id)
        {
            return await GetObjectDetailByIdAsync<IdentityGroup>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.IdentityGroup, id);
        }
        public static async Task<Tuple<List<IdentityGroup>, string>> GetIdentityGroupsAsync()
        {
            return await GetAllObjectAsync<IdentityGroup>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.IdentityGroup);
        }

        #endregion End Identity Group

        #region Register Vehicle
        public static async Task<Tuple<RegisteredVehicle, string>> GetRegistedVehilceByPlateAsync(string plateNumber)
        {
            return await GetTop1ObjectAsync<RegisteredVehicle>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.RegisteredVehicle, EmPageSearchType.TEXT,
                                                      EmPageSearchKey.plateNumber, plateNumber);
        }
        public static async Task<Tuple<RegisteredVehicle, string>> GetRegistedVehilceByIdAsync(string id)
        {
            return await GetObjectDetailByIdAsync<RegisteredVehicle>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.RegisteredVehicle, id);
        }
        public static async Task<Tuple<List<RegisteredVehicle>, string>> GetRegisterVehiclesAsync(string keyword)
        {
            return await GetObjectByConditionAsync<RegisteredVehicle>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.RegisteredVehicle,
                                                            EmPageSearchType.TEXT, EmPageSearchKey.name, keyword, EmOperation._contains);

        }
        public static async Task<Tuple<RegisteredVehicle, string>> CreateRegisteredVehicle(RegisteredVehicle registeredVehicle)
        {
            return await CreateObjectAsync<RegisteredVehicle>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.RegisteredVehicle,
                                                              registeredVehicle);
        }
        public static async Task<bool> UpdateRegisteredVehicleAsyncById(RegisteredVehicle registeredVehicle)
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.RegisteredVehicle.UpdateRouteById(registeredVehicle.Id);

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, registeredVehicle, headers, null, timeOut, RestSharp.Method.Put);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponseData<RegisteredVehicle> kzBaseResponse = NewtonSoftHelper<KzBaseResponseData<RegisteredVehicle>>.GetBaseResponse(response.Item1);
                if (kzBaseResponse == null)
                {
                    return false;
                }
                return kzBaseResponse.metadata?.success ?? false;
            }
            return false;
        }
        #endregion End Register Vehicle

        #region Customer
        public static async Task<Tuple<Customer, string>> CreateCustomer(Customer customer)
        {
            return await CreateObjectAsync<Customer>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Customer,
                                                             customer);
        }
        public static async Task<Tuple<Customer, string>> GetCustomerByIdAsync(string id)
        {
            return await GetObjectDetailByIdAsync<Customer>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Customer, id);
        }
        public static async Task<Tuple<List<Customer>, string>> GetCustomersAsync()
        {
            return await GetAllObjectAsync<Customer>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Customer);
        }
        public static async Task<Tuple<List<Customer>, string>> GetCustomersAsync(string keyword)
        {
            return await GetObjectByConditionAsync<Customer>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Customer,
                                                            EmPageSearchType.TEXT, EmPageSearchKey.name, keyword, EmOperation._contains);

        }
        public static async Task<bool> UpdateCustomer(Customer customer)
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.Customer.UpdateRouteById(customer.Id);

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, customer, headers, null, timeOut, RestSharp.Method.Put);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponseData<Customer> kzBaseResponse = NewtonSoftHelper<KzBaseResponseData<Customer>>.GetBaseResponse(response.Item1);
                return kzBaseResponse?.metadata?.success ?? false;
            }
            return false;
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
        #endregion End Customer

        #region Customer Group
        public static async Task<Tuple<List<CustomerGroup>, string>> GetCustomerGroupsAsync()
        {
            return await GetAllObjectAsync<CustomerGroup>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.CustomerGroup);
        }
        #endregion End Customer Group

        #region Event In
        public static async Task<bool> UpdateEventInPlateAsync(string eventId, string newPlate)
        {
            StandardlizeServerName();
            string apiUrl = server + KzParkingv5ApiUrlManagement.PostObjectRoute(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.EventIn) + "/" + eventId;
            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
             {
                 { "Authorization","Bearer " + token  }
             };
            var commitData = new List<CommitData>();
            commitData.Add(new CommitData()
            {
                op = "replace",
                path = "plateNumber",
                value = newPlate
            });
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, commitData, headers, null, timeOut, RestSharp.Method.Patch);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                return true;
            }
            return false;
        }
        public static async Task<AddEventInResponse> PostCheckInAsync(
            string _laneId, string _plateNumber, Identity? identity, List<string> imageKeys, bool isForce = false, RegisteredVehicle? registeredVehicle = null)
        {
            if (identity == null)
            {
                return await PostCheckInByPlateAsync(_laneId, _plateNumber, identity, imageKeys, isForce, registeredVehicle);
            }
            else
            {
                return await PostCheckInByIdentityAsync(_laneId, _plateNumber, identity, imageKeys, isForce, registeredVehicle);
            }
        }
        public static async Task<AddEventInResponse> PostCheckInByIdentityAsync(string _laneId, string _plateNumber, Identity? identity, List<string> imageKeys, bool isForce = false, RegisteredVehicle? registeredVehicle = null)
        {
            StandardlizeServerName();
            string apiUrl = server + KzParkingv5ApiUrlManagement.PostObjectRoute(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.EventIn) + "/identity";
            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
                {
                { "Authorization","Bearer " + token  }
                };

            var data = new
            {
                laneId = _laneId,
                identity = new
                {
                    id = identity.Id,
                    code = identity.Code,
                    identityGroupId = identity.IdentityGroupId,
                    type = 0,
                },
                plateNumber = _plateNumber,
                forceEntrance = isForce,
                fileKeys = new List<string>(),
            };

            foreach (var item in imageKeys)
            {
                data.fileKeys.Add(item);
            }
            string a = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, data, headers, null, timeOut, RestSharp.Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    AddEventInResponse addEventInResponse = NewtonSoftHelper<AddEventInResponse>.GetBaseResponse(response.Item1);
                    return addEventInResponse;
                }
                catch (Exception)
                {
                }
            }
            return null;
        }
        public static async Task<AddEventInResponse> PostCheckInByPlateAsync(string _laneId, string _plateNumber, Identity? identity, List<string> imageKeys, bool isForce = false, RegisteredVehicle? registeredVehicle = null)
        {
            StandardlizeServerName();
            string apiUrl = server + KzParkingv5ApiUrlManagement.PostObjectRoute(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.EventIn) + "/vehicle";

            return null;
            //StandardlizeServerName();
            //string apiUrl = string.Empty;

            //if (identity == null)
            //{
            //    apiUrl = server + KzApiUrlManagement.EmObjectType.EventIn.CreateRoute() + "/vehicle";
            //    //Gửi API
            //    Dictionary<string, string> headers = new Dictionary<string, string>()
            //    {
            //    { "Authorization","Bearer " + token  }
            //    };
            //    var _vehicle = new
            //    {
            //        id = registeredVehicle.Id,
            //        plateNumber = _plateNumber,
            //        customerId = registeredVehicle.CustomerId,
            //    };
            //    var data = new
            //    {
            //        laneId = _laneId,
            //        vehicle = _vehicle,
            //        forceEntrance = isForce,
            //        fileKeys = new List<string>()
            //    };

            //    foreach (var item in imageKeys)
            //    {
            //        data.fileKeys.Add(item);
            //    }
            //    string a = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            //    var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, data, headers, null, timeOut, RestSharp.Method.Post);
            //    if (!string.IsNullOrEmpty(response.Item1))
            //    {
            //        try
            //        {
            //            KzBaseResponseData<AddEventInResponse> addEventInResponse = NewtonSoftHelper<KzBaseResponseData<AddEventInResponse>>.GetBaseResponse(response.Item1);
            //            return addEventInResponse;
            //        }
            //        catch (Exception)
            //        {
            //        }
            //    }
            //}
            //else
            //{
            //    apiUrl = server + KzApiUrlManagement.EmObjectType.EventIn.CreateRoute() + "/vehicle";
            //    //Gửi API
            //    Dictionary<string, string> headers = new Dictionary<string, string>()
            //    {
            //    { "Authorization","Bearer " + token  }
            //    };

            //    var _identityCheckIn = new
            //    {
            //        id = identity.Id,
            //        code = identity.Code,
            //        identityGroupId = identity.IdentityGroupId,
            //    };

            //    var data = new
            //    {
            //        laneId = _laneId,
            //        identity = _identityCheckIn,
            //        plateNumber = _plateNumber,
            //        //identityCode = identity == null ? null : identity?.Code,
            //        //identityType = identity == null ? null : identity?.Type,
            //        forceEntrance = isForce,
            //        fileKeys = new List<string>()
            //    };

            //    foreach (var item in imageKeys)
            //    {
            //        data.fileKeys.Add(item);
            //    }
            //    string a = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            //    var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, data, headers, null, timeOut, RestSharp.Method.Post);
            //    if (!string.IsNullOrEmpty(response.Item1))
            //    {
            //        try
            //        {
            //            KzBaseResponseData<AddEventInResponse> addEventInResponse = NewtonSoftHelper<KzBaseResponseData<AddEventInResponse>>.GetBaseResponse(response.Item1);
            //            return addEventInResponse;
            //        }
            //        catch (Exception)
            //        {
            //        }
            //    }
            //}
        }
        public static async Task<DataTable> GetEventIns(string keyword, DateTime startTime, DateTime endTime,
                                    string identityGroupId, string vehicleTypeId, string laneId, string user,
                                    int pageIndex = 1, int pageSize = 100)
        {
            StandardlizeServerName();
            string apiUrl = server + KzParkingv5ApiUrlManagement.GetBySqlCmd;
            string cmd = string.Empty;
            cmd += "SELECT * FROM index_event_in ";
            cmd += $"WHERE status != 'Exited' AND (createdutc Between '{startTime.ToUniversalTime():yyyy-MM-ddTHH:mm:ss.000Z}' AND '{endTime.ToUniversalTime():yyyy-MM-ddTHH:mm:ss.000Z}') ";
            if (!string.IsNullOrEmpty(laneId))
            {
                cmd += $@"AND laneid = '{laneId.ToUpper()}' ";
            }
            if (!string.IsNullOrEmpty(identityGroupId))
            {
                cmd += $@"AND identitygroupid = '{identityGroupId.ToUpper()}' ";
            }
            if (!string.IsNullOrEmpty(vehicleTypeId))
            {
                cmd += $@"AND vehicletypeid = '{vehicleTypeId.ToUpper()}' ";
            }
            if (!string.IsNullOrEmpty(user))
            {
                cmd += $@"AND createdby = '{user}' ";
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                cmd += $@"AND (identityname like '%{keyword}%' OR platenumber like '%{keyword}%' OR identitycode like '%{keyword}%')";
            }
            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var data = new
            {
                query = cmd
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, data, headers, null, timeOut, RestSharp.Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                // Deserialize JSON to JObject
                JObject jsonObject = JObject.Parse(response.Item1);

                // Extract columns and rows from JSON
                JArray columns = (JArray)jsonObject["columns"];
                JArray rows = (JArray)jsonObject["rows"];

                // Create a new DataTable
                DataTable dataTable = new DataTable();
                if (columns != null)
                {
                    foreach (JObject column in columns)
                    {
                        string columnName = (string)column["name"];
                        string columnType = (string)column["type"];

                        Type type;

                        switch (columnType)
                        {
                            case "text":
                                type = typeof(string);
                                break;
                            case "long":
                                type = typeof(long);
                                break;
                            case "datetime":
                                type = typeof(DateTime);
                                break;
                            default:
                                type = typeof(string);
                                break;
                        }

                        dataTable.Columns.Add(columnName, type);
                    }
                    if (rows != null)
                    {
                        foreach (JArray row in rows)
                        {
                            object[] rowData = row.ToObject<object[]>();
                            dataTable.Rows.Add(rowData);
                        }

                    }
                }
                return dataTable;
            }
            return null;
        }
        #endregion End Event In

        #region Event Out
        public static async Task<bool> UpdateEventOutPlate(string eventId, string newPlate)
        {
            StandardlizeServerName();
            string apiUrl = server + KzParkingv5ApiUrlManagement.PostObjectRoute(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.EventIn) + "/" + eventId;
            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
             {
                 { "Authorization","Bearer " + token  }
             };
            var commitData = new List<CommitData>();
            commitData.Add(new CommitData()
            {
                op = "replace",
                path = "plateNumber",
                value = newPlate
            });
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, commitData, headers, null, timeOut, RestSharp.Method.Patch);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                return true;
            }
            return false;
        }
        public static async Task<DataTable> GetEventOuts(string keyword, DateTime startTime, DateTime endTime, string identityGroupId, string vehicleTypeId, string laneId, string user, int pageIndex = 1, int pageSize = 10000)
        {
            StandardlizeServerName();
            string apiUrl = server + KzParkingv5ApiUrlManagement.GetBySqlCmd;
            string cmd = string.Empty;
            cmd += "SELECT * FROM index_event_out ";
            cmd += $"WHERE (createdutc Between '{startTime.ToUniversalTime():yyyy-MM-ddTHH:mm:ss.000Z}' AND '{endTime.ToUniversalTime():yyyy-MM-ddTHH:mm:ss.000Z}') ";
            if (!string.IsNullOrEmpty(laneId))
            {
                cmd += $@"AND (laneid = '{laneId.ToUpper()}' or eventinlaneid = '{laneId.ToUpper()}')  ";
            }
            if (!string.IsNullOrEmpty(identityGroupId))
            {
                cmd += $@"AND identitygroupid = '{identityGroupId.ToUpper()}' ";
            }
            if (!string.IsNullOrEmpty(vehicleTypeId))
            {
                cmd += $@"AND vehicletypeid = '{vehicleTypeId.ToUpper()}' ";
            }
            if (!string.IsNullOrEmpty(user))
            {
                cmd += $@"AND (eventincreatedby = '{user}' or createdby = '{user}' ) ";
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                cmd += $@"AND ((identityname like '%{keyword}%' OR platenumber like '%{keyword}%' OR identitycode like '%{keyword}%') OR
                               (eventinidentityname like '%{keyword}%' OR platenumber like '%{keyword}%' OR eventinidentitycode like '%{keyword}%'))";
            }
            cmd += "ORDER BY createdutc desc";
            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var data = new
            {
                query = cmd,
                fetch_size = pageSize,
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, data, headers, null, timeOut, RestSharp.Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                // Deserialize JSON to JObject
                JObject jsonObject = JObject.Parse(response.Item1);

                // Extract columns and rows from JSON
                JArray columns = (JArray)jsonObject["columns"];
                JArray rows = (JArray)jsonObject["rows"];

                // Create a new DataTable
                DataTable dataTable = new DataTable();
                if (columns != null)
                {
                    foreach (JObject column in columns)
                    {
                        string columnName = (string)column["name"];
                        string columnType = (string)column["type"];

                        Type type;

                        switch (columnType)
                        {
                            case "text":
                                type = typeof(string);
                                break;
                            case "long":
                                type = typeof(long);
                                break;
                            case "datetime":
                                type = typeof(DateTime);
                                break;
                            default:
                                type = typeof(string);
                                break;
                        }

                        dataTable.Columns.Add(columnName, type);
                    }
                    if (rows != null)
                    {
                        foreach (JArray row in rows)
                        {
                            object[] rowData = row.ToObject<object[]>();
                            dataTable.Rows.Add(rowData);
                        }

                    }
                }
                return dataTable;
            }
            return null;
        }
        public static async Task<AddEventOutResponse> PostCheckOutAsync(string _laneId, string _plateNumber, Identity? identitiy, List<string> imageKeys, bool isForce)
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.EventOut.CreateRoute();
            if (identitiy == null)
            {
                return await PostCheckOutByPlateAsync(_laneId, _plateNumber, identitiy, imageKeys, isForce);
            }
            else
            {
                return await PostCheckOutByIdentityAsync(_laneId, _plateNumber, identitiy, imageKeys, isForce);
            }
        }
        public static async Task<AddEventOutResponse> PostCheckOutByIdentityAsync(string _laneId, string _plateNumber, Identity? identity, List<string> imageKeys, bool isForce = false)
        {
            StandardlizeServerName();
            string apiUrl = server + KzParkingv5ApiUrlManagement.PostObjectRoute(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.EventOut) + "/identity";
            //Gửi API
            //apiUrl = "http://192.168.21.13:3004/pk/event-out/identity";
            Dictionary<string, string> headers = new Dictionary<string, string>()
                {
                { "Authorization","Bearer " + token  }
                };

            var data = new
            {
                laneId = _laneId,
                identity = new
                {
                    id = identity.Id,
                    code = identity.Code,
                    identityGroupId = identity.IdentityGroupId,
                    type = 0,
                },
                plateNumber = _plateNumber,
                force = isForce,
                fileKeys = new List<string>()
            };

            foreach (var item in imageKeys)
            {
                data.fileKeys.Add(item);
            }
            string a = JsonConvert.SerializeObject(data);
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, data, headers, null, timeOut, RestSharp.Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    AddEventOutResponse addEventOutResponse = NewtonSoftHelper<AddEventOutResponse>.GetBaseResponse(response.Item1);
                    if (!addEventOutResponse.IsSuccess)
                    {
                        addEventOutResponse.eventIn = addEventOutResponse.payload.ContainsKey("EventIn") ? addEventOutResponse.payload["EventIn"] : null;
                    }
                    return addEventOutResponse;
                }
                catch (Exception)
                {
                }
            }
            return null;
        }
        public static async Task<AddEventOutResponse> PostCheckOutByPlateAsync(string _laneId, string _plateNumber, Identity? identity, List<string> imageKeys, bool isForce = false, RegisteredVehicle? registeredVehicle = null)
        {
            StandardlizeServerName();
            string apiUrl = server + KzParkingv5ApiUrlManagement.PostObjectRoute(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.EventIn) + "/vehicle";

            return null;
        }

        public static async Task<bool> CommitOutAsync(AddEventOutResponse eventOut)
        {
            StandardlizeServerName();
            string apiUrl = server + KzParkingv5ApiUrlManagement.PostObjectRoute(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.EventOut) + "/" + eventOut.Id;
            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var commitData = new List<CommitData>();
            commitData.Add(new CommitData()
            {
                op = "replace",
                path = "approve",
                value = true
            });
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, commitData, headers, null, timeOut, RestSharp.Method.Patch);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                return Convert.ToBoolean(response.Item1);
                //AddEventOutResponse addEventOutResponse = NewtonSoftHelper<AddEventOutResponse>.GetBaseResponse(response.Item1);
                //return addEventOutResponse;
            }
            return false;
        }
        public static async Task<bool> CancelCheckOut(string eventOutId)
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.DeleteCheckOutRoute(eventOutId);
            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzBaseResponseData<string> kzBaseResponse = NewtonSoftHelper<KzBaseResponseData<string>>.GetBaseResponse(response.Item1);
                if (kzBaseResponse == null)
                {
                    return false;
                }
                return kzBaseResponse.metadata.success;
            }
            return false;
        }

        public class PaymentTransaction
        {
            public string id { get; set; }
            public string eventInId { get; set; }
            public string eventOutId { get; set; }
            public int method { get; set; }
            public int purpose { get; set; }
            public long charge { get; set; }
            public long discount { get; set; }
            public long paid { get; set; }
            public string note { get; set; }
            public DateTime createdUtc { get; set; }
            public DateTime updatedUtc { get; set; }
        }
        public enum PaymentTransactionMethod
        {
            CashAtBooth,
            CashAtKiosk,
        }
        public enum PaymentTransactionPurpose
        {
            ParkingCharge,
        }
        public static async Task<PaymentTransaction> CreatePaymentTransaction(AddEventOutResponse eventOut)
        {
            StandardlizeServerName();
            string apiUrl = server + KzParkingv5ApiUrlManagement.PostObjectRoute(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.PaymentTransaction);
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var data = new PaymentTransaction
            {
                eventInId = eventOut.eventIn.Id,
                eventOutId = eventOut.Id,
                method = (int)PaymentTransactionMethod.CashAtBooth,
                purpose = (int)PaymentTransactionPurpose.ParkingCharge,
                charge = eventOut.charge,
                discount = eventOut.discount,
                paid = eventOut.charge,
                note = "",
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, data, headers, null, timeOut, RestSharp.Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                PaymentTransaction paymentTransaction = NewtonSoftHelper<PaymentTransaction>.GetBaseResponse(response.Item1);
                return paymentTransaction;
            }
            return null;
        }
        #endregion End Event Out

        #region Alarm
        public static async Task<bool> CreateAlarmAsync(string identityId, string laneId, string plate, AbnormalCode abnormalCode,
                                                        string imageKey, bool isLaneIn, string _identityGroupId, string customerId,
                                                        string registerVehicleId, string description)
        {
            StandardlizeServerName();
            string apiUrl = server + KzParkingv5ApiUrlManagement.PostObjectRoute(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.AbnormalEvent);
            Dictionary<string, string> headers = new Dictionary<string, string>()
                    {
                        { "Authorization","Bearer " + token  }
                    };
            var abnormalEvent = new
            {
                LaneId = laneId,
                identity = new
                {
                    id = identityId,
                    identityGroupId = _identityGroupId,
                },
                PlateNumber = plate,
                AbnormalCode = abnormalCode,
                FileKeys = new List<string>()
                        {
                            imageKey + (isLaneIn? "_OVERVIEWIN.jpeg" : "_OVERVIEWOUT.jpeg"),
                            imageKey + (isLaneIn ? "_VEHICLEIN.jpeg" : "_VEHICLEOUT.jpeg")
                        },
                Description = description
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, abnormalEvent, headers, null, timeOut, RestSharp.Method.Post);
            string a = Newtonsoft.Json.JsonConvert.SerializeObject(abnormalEvent);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                AbnormalEvent kzBaseResponse = NewtonSoftHelper<AbnormalEvent>.GetBaseResponse(response.Item1);
                return kzBaseResponse != null;
            }
            return false;
        }
        public static async Task<DataTable> GetAlarmReport(string keyword, DateTime startTime, DateTime endTime, string identityGroupId, string vehicleTypeId, string laneId, int pageIndex = 1, int pageSize = 10000)
        {
            StandardlizeServerName();
            string apiUrl = server + KzParkingv5ApiUrlManagement.GetBySqlCmd;
            string cmd = string.Empty;
            cmd += "SELECT * FROM index_abnormal_event ";
            cmd += $"WHERE (createdutc Between '{startTime.ToUniversalTime():yyyy-MM-ddTHH:mm:ss.000Z}' AND '{endTime.ToUniversalTime():yyyy-MM-ddTHH:mm:ss.000Z}') ";
            if (!string.IsNullOrEmpty(laneId))
            {
                cmd += $@"AND (laneid = '{laneId.ToUpper()}' or eventinlaneid = '{laneId.ToUpper()}')  ";
            }
            if (!string.IsNullOrEmpty(identityGroupId))
            {
                cmd += $@"AND identitygroupid = '{identityGroupId.ToUpper()}' ";
            }
            if (!string.IsNullOrEmpty(vehicleTypeId))
            {
                cmd += $@"AND vehicletypeid = '{vehicleTypeId.ToUpper()}' ";
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                cmd += $@"AND ((identityname like '%{keyword}%' OR platenumber like '%{keyword}%' OR identitycode like '%{keyword}%') OR
                               (eventinidentityname like '%{keyword}%' OR platenumber like '%{keyword}%' OR eventinidentitycode like '%{keyword}%'))";
            }
            cmd += "ORDER BY createdutc desc";
            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var data = new
            {
                query = cmd,
                fetch_size = pageSize,
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, data, headers, null, timeOut, RestSharp.Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                // Deserialize JSON to JObject
                JObject jsonObject = JObject.Parse(response.Item1);

                // Extract columns and rows from JSON
                JArray columns = (JArray)jsonObject["columns"];
                JArray rows = (JArray)jsonObject["rows"];

                // Create a new DataTable
                DataTable dataTable = new DataTable();
                if (columns != null)
                {
                    foreach (JObject column in columns)
                    {
                        string columnName = (string)column["name"];
                        string columnType = (string)column["type"];

                        Type type;

                        switch (columnType)
                        {
                            case "text":
                                type = typeof(string);
                                break;
                            case "long":
                                type = typeof(long);
                                break;
                            case "datetime":
                                type = typeof(DateTime);
                                break;
                            default:
                                type = typeof(string);
                                break;
                        }

                        dataTable.Columns.Add(columnName, type);
                    }
                    if (rows != null)
                    {
                        foreach (JArray row in rows)
                        {
                            object[] rowData = row.ToObject<object[]>();
                            dataTable.Rows.Add(rowData);
                        }

                    }
                }
                return dataTable;
            }
            return null;
        }
        #endregion End Alarm

        #region EInvoice
        public class InvoiceDto
        {
            public string id { get; set; }
            public string orderId { get; set; }
            public object requestId { get; set; }
            public int serviceProvider { get; set; }
            public Creator creator { get; set; }
            public string signedFileData { get; set; }
            public Company company { get; set; }
            public Paymentitem[] paymentItems { get; set; }
            public DateTime createdAt { get; set; }
            public object modifiedAt { get; set; }
            public Lookupinformation lookupInformation { get; set; }
            public object note { get; set; }
            public Taxdetails taxDetails { get; set; }
            public Invoiceconfiguration invoiceConfiguration { get; set; }
        }

        public class Creator
        {
            public string id { get; set; }
            public string name { get; set; }
            public object code { get; set; }
            public object phone { get; set; }
            public object email { get; set; }
            public object description { get; set; }
        }

        public class Company
        {
            public string name { get; set; }
            public object code { get; set; }
            public string taxCode { get; set; }
            public object description { get; set; }
            public object phoneNumber { get; set; }
            public object email { get; set; }
        }

        public class Lookupinformation
        {
            public object mappingId { get; set; }
            public string invoiceNumber { get; set; }
            public string reservationCode { get; set; }
        }

        public class Taxdetails
        {
            public int totalWithTax { get; set; }
            public int taxAmount { get; set; }
            public int taxRate { get; set; }
        }

        public class Invoiceconfiguration
        {
            public string templateCode { get; set; }
            public string invoiceTypeCode { get; set; }
            public string symbolCode { get; set; }
        }

        public class Paymentitem
        {
            public string name { get; set; }
            public string code { get; set; }
            public object description { get; set; }
            public string unitName { get; set; }
            public object category { get; set; }
            public int quantity { get; set; }
            public int unitPrice { get; set; }
            public int taxRate { get; set; }
            public int total { get; set; }
        }

        public static async Task<InvoiceDto> CreateEinvoice(long price, string plateNumber, DateTime datetimeIn, DateTime datetimeOut, string eventOutId)
        {
            //string url = $"http://14.160.26.45:26868/einvoice?provider=VIETTEL";
            StandardlizeServerName();
            string apiUrl = server + "einvoice?provider=VIETTEL";
            apiUrl = apiUrl.Replace(":5000", ":26868");
            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            TimeSpan parkingTime = datetimeOut - datetimeIn;
            var data = new
            {
                Id = eventOutId,
                Company = new
                {
                    Name = StaticPool.CompanyName,
                    taxCode = StaticPool.TaxCode,
                },
                Creator = new
                {
                    Id = StaticPool.userId,
                    Name = StaticPool.user_name,
                },
                paymentItems = new List<object>()
                {
                    new
                    {
                        name = "Hàng hóa 1",
                        code = "HH1",
                        unitName = "Cái",
                        quantity = 1,
                        unitPrice = price,
                        taxRate = StaticPool.TaxRate,
                    }
                },
                additionalData = new List<object>()
                {
                    new
                    {
                        tag =  "licensePlate",
                        name = "Biển kiểm soát",
                        value =  plateNumber,
                        type=  "text"
                    },
                    new
                    {
                        tag =  "checkIn",
                        name = "Giờ vào",
                        value =  datetimeIn.ToString("dd/MM/yyyy HH:mm:ss"),
                        type=  "text"
                    },
                    new
                    {
                        tag =  "checkOut",
                        name = "Giờ ra",
                        value =  datetimeOut.ToString("dd/MM/yyyy HH:mm:ss"),
                        type=  "text"
                    },
                    new
                    {
                        tag =  "parkingTime",
                        name = "Thời gian lưu bãi",
                        value = (int)parkingTime.TotalHours + " giờ " + ((int)parkingTime.TotalMinutes - 60 * (int)parkingTime.TotalHours) + " phút",
                        type=  "text"
                    },
                },
                invoiceConfiguration = new
                {
                    templateCode = StaticPool.templateCode,
                    invoiceTypeCode = StaticPool.invoiceTypeCode,
                    symbolCode = StaticPool.symbolCode,
                },
                taxRate = StaticPool.TaxRate,
                createdAt = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:sss.fffZ"),
                MappingId = eventOutId,
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, data, headers, null, timeOut, Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<InvoiceDto>(response.Item1);
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return null;
        }
        public static async Task<InvoiceData> GetInvoiceData(string orderId, EmInvoiceProvider provider = EmInvoiceProvider.VIETTEL)
        {
            // string url = $"http://14.160.26.45:26868/einvoice?provider=65";
            StandardlizeServerName();
            string apiUrl = server + "einvoice?einvoice?provider=65";
            apiUrl = apiUrl.Replace(":5000", ":26868");

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var data = new
            {
                InvoiceNumber = "",
                OrderId = orderId,
                GetFile = true,
                FileType = "Pdf"
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, data, headers, null, timeOut, Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                return NewtonSoftHelper<InvoiceData>.GetBaseResponse(response.Item1);
            }
            return null;
        }
        public static async Task<List<InvoiceDataSearch>> GetMultipleInvoiceData(List<string> orderIds, EmInvoiceProvider provider = EmInvoiceProvider.VIETTEL)
        {
            //string url = $"http://14.160.26.45:26868/sent-invoice/many";
            StandardlizeServerName();
            string apiUrl = server + "sent-invoice/many";
            apiUrl = apiUrl.Replace(":5000", ":26868");

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, orderIds, headers, null, timeOut, Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                return NewtonSoftHelper<List<InvoiceDataSearch>>.GetBaseResponse(response.Item1);
            }
            return null;
        }
        #endregion End Einvoice

        #region Private Function
        private static void StandardlizeServerName()
        {
            if (server[^1] != '/' && server[^1] != '\\')
            {
                server += "/";
            }
        }
        #endregion End Private Function

        #region SUMARY
        /// <summary>
        /// Gửi api lấy thông tin số lượng xe đang trong bãi, số lượng xe vào bãi trong ngày, số lượng xe ra khỏi bãi trong ngày
        /// </summary>
        /// <returns></returns>
        public static async Task<SumaryCountEvent> SummaryEventAsync()
        {
            StandardlizeServerName();
            string apiUrl = server + KzParkingv5ApiUrlManagement.GetBySqlCmd;
            DateTime startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            DateTime endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            string vehicleInParkCmd = string.Empty;
            vehicleInParkCmd += "SELECT Count(id) FROM index_event_in ";
            vehicleInParkCmd += $"WHERE status != 'Exited' ";
            var data = new
            {
                query = vehicleInParkCmd
            };
            int vehicleInPark = await GetRecordCountByCmd(apiUrl, headers, data);

            string vehicleGotInInDayCmd = string.Empty;
            vehicleGotInInDayCmd += "SELECT Count(id) FROM index_event_in ";
            vehicleGotInInDayCmd += $"WHERE (createdutc Between '{startTime.ToUniversalTime():yyyy-MM-ddTHH:mm:ss.000Z}' AND '{endTime.ToUniversalTime():yyyy-MM-ddTHH:mm:ss.000Z}') ";
            data = new
            {
                query = vehicleGotInInDayCmd
            };
            int vehicleGotInIn = await GetRecordCountByCmd(apiUrl, headers, data);

            string vehicleGotOutInDayCmdc = string.Empty;
            vehicleGotOutInDayCmdc += "SELECT Count(id) FROM index_event_out ";
            vehicleGotOutInDayCmdc += $"WHERE (createdutc Between '{startTime.ToUniversalTime():yyyy-MM-ddTHH:mm:ss.000Z}' AND '{endTime.ToUniversalTime():yyyy-MM-ddTHH:mm:ss.000Z}') ";
            data = new
            {
                query = vehicleGotOutInDayCmdc
            };
            int vehicleGotOutInDay = await GetRecordCountByCmd(apiUrl, headers, data);

            return new SumaryCountEvent()
            {
                countAllEventIn = vehicleInPark,
                totalEventOut = vehicleGotOutInDay,
                totalVehicleIn = vehicleGotInIn,
            };
        }

        private static async Task<int> GetRecordCountByCmd(string apiUrl, Dictionary<string, string> headers, object data)
        {
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, data, headers, null, timeOut, RestSharp.Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                // Deserialize JSON to JObject
                JObject jsonObject = JObject.Parse(response.Item1);

                // Extract columns and rows from JSON
                JArray columns = (JArray)jsonObject["columns"];
                JArray rows = (JArray)jsonObject["rows"];

                if (rows != null)
                {
                    if (rows.Count > 0)
                    {
                        try
                        {
                            string temp = rows[0].ToString();
                            object[] rowData = rows[0].ToObject<object[]>();
                            return int.Parse(rowData[0].ToString());
                        }
                        catch (Exception)
                        {
                            return 0;
                        }
                    }
                    return 0;
                }
            }
            return 0;
        }
        #endregion End SUMARY

        #region WAREHOUSE
        public class WarehouseService
        {
            public string Id { get; set; }
            public string Code { get; set; }
            public string EventInId { get; set; }
            public string EventOutId { get; set; }
            public string PlateNumber { get; set; }
            public string Description { get; set; }
            public string codeCharacterSequence { get; set; }
            public string codeNumberSequence { get; set; }
            public string paperworkSequence { get; set; }
            public int Type { get; set; }
            public bool PrintPaper { get; set; }
        }

        public class WarehouseServiceInput
        {
            public int type { get; set; }
            public string plateNumber { get; set; }
            public string eventInId { get; set; }
            public Guid eventOutId { get; set; }
            public string description { get; set; }
            public bool PrintPaper { get; set; }
        }

        public static async Task<WarehouseService> CreateWarehouseService(string eventInId, string eventOutId, string plate, EmTransactionType type, bool isPrint = false)
        {

            StandardlizeServerName();
            string apiUrl = server + "warehouse/transaction";
            Dictionary<string, string> headers = new Dictionary<string, string>()
                    {
                        { "Authorization","Bearer " + token  }
                    };
            WarehouseServiceInput warehouseService = new WarehouseServiceInput()
            {
                type = (int)type,
                plateNumber = plate,
                eventInId = eventInId,
                eventOutId = Guid.Empty,
                PrintPaper = isPrint,
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, warehouseService, headers, null, timeOut, RestSharp.Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    WarehouseService result = NewtonSoftHelper<WarehouseService>.GetBaseResponse(response.Item1);
                    return result;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return null;
        }
        #endregion
    }
}
