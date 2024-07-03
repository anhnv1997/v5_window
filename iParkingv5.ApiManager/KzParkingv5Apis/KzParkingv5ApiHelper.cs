using iParkingv5.Objects;
using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Enums;
using iParkingv5.Objects.EventDatas;
using iParkingv5.Objects.Invoices;
using iParkingv6.ApiManager;
using iParkingv6.ApiManager.KzParkingv3Apis;
using iParkingv6.Objects.Datas;
using Kztek.Tool;
using Kztek.Tools;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Threading;
using System.Threading.Tasks;
using static iParkingv5.ApiManager.iParkingApi;
using static iParkingv5.ApiManager.KzParkingv5Apis.Filter;
using static iParkingv5.ApiManager.KzParkingv5Apis.KzParkingv5ApiHelper;
using static iParkingv6.ApiManager.KzParkingv3Apis.KzParkingApiHelper;
using static iParkingv6.ApiManager.KzParkingv3Apis.KzParkingApiHelper.TransactionType;
using static OpenCvSharp.ML.DTrees;

namespace iParkingv5.ApiManager.KzParkingv5Apis
{
    public class KzParkingv5ApiHelper : iParkingApi
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
                                                                   timeOut, Method.Post);
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
                                                                   timeOut, Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {

                    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response.Item1);
                    return Tuple.Create<T, string>(data, response.Item2);
                }
                catch (Exception e)
                {
                    return null;
                }
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

        #region System Config

        public class CompanyInfo
        {
            public string id { get; set; }
            public string companyName { get; set; }
            public string companyAddress { get; set; }
            public string companyTelephone { get; set; }
            public string companyTax { get; set; }
            public DateTime createdUtc { get; set; }
            public DateTime updatedUtc { get; set; }
        }

        public async Task<SystemConfig> GetSystemConfigAsync()
        {
            StandardlizeServerName();
            string apiUrl = server + "project/BF195768-4C7F-4F59-A50F-F41AD693BBC0";

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null,
                                                                  timeOut, Method.Get);

            apiUrl = server + "tenant/" + "00f43ef8-f67b-446a-870a-c219b59c0c4e".ToUpper();
            var response2 = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null,
                                                               timeOut, Method.Get);
            if (!string.IsNullOrEmpty(response2.Item1))
            {
                var companyInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<CompanyInfo>(response2.Item1);
                if (companyInfo != null)
                {
                    StaticPool.TaxCode = companyInfo.companyTax;
                    StaticPool.CompanyName = companyInfo.companyName;
                    StaticPool.CompanyAddress = companyInfo.companyAddress;
                }
            }

            if (!string.IsNullOrEmpty(response.Item1))
            {
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<SystemConfig>(response.Item1);
                if (data != null)
                {
                    StaticPool.templateCode = data.InvoiceTemplateCode;
                    StaticPool.invoiceTypeCode = data.InvoiceTypeCode;
                    StaticPool.symbolCode = data.InvoiceSymbolCode;
                    StaticPool.TaxRate = data.taxRate;
                    LogHelper.Log(LogHelper.EmLogType.INFOR,
                        LogHelper.EmObjectLogType.System,
                        noi_dung_hanh_dong: $@"Tải hóa đơn điện tử {StaticPool.CompanyName} - {StaticPool.CompanyAddress} - 
                                                                   {StaticPool.TaxCode} - {StaticPool.templateCode} - 
                                                                   {StaticPool.symbolCode} - {StaticPool.TaxRate}");
                }
                return data;
            }
            else
            {
                return null;
            }

        }

        #endregion

        #region USER
        public async Task GetUserInfor()
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
        public async Task<string> GetFeeCalculate(string dateTimeIn, string dateTimeOut, string identityGroupID)
        {
            StandardlizeServerName();
            string apiUrl = $"{server}charge/calculate";

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var data = new
            {
                dateTimeIn = dateTimeIn,
                dateTimeOut = dateTimeOut,
                identityGroupId = identityGroupID,
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, data, headers, null,
                                                                  timeOut, Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    return response.Item1.ToString();
                }
                catch (Exception)
                {
                    return "";
                }
            }
            return "";
        }

        public async Task<Tuple<List<User>, string>> GetAllUsers()
        {
            return await GetAllObjectAsync<User>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.User);
        }
        #endregion

        #region Computer --OK
        public async Task<Tuple<List<Computer>, string>> GetComputersAsync()
        {
            return await GetAllObjectAsync<Computer>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Computer);
        }
        public async Task<Tuple<Computer, string>> GetComputerByIPAsync(string ip)
        {
            return await GetTop1ObjectAsync<Computer>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Computer,
                                                      EmPageSearchType.TEXT, EmPageSearchKey.IpAddress, ip);
        }
        #endregion End Computer

        #region Gate --OK
        public async Task<Tuple<List<Gate>, string>> GetGatesAsync()
        {
            return await GetAllObjectAsync<Gate>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Gate);
        }
        public async Task<Tuple<Gate, string>> GetGateByIdAsync(string gateId)
        {
            return await GetObjectDetailByIdAsync<Gate>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Gate, gateId);
        }
        #endregion End Gate

        #region Camera
        public async Task<Tuple<List<Camera>, string>> GetCamerasAsync()
        {
            return await GetAllObjectAsync<Camera>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Camera);
        }
        public async Task<Tuple<List<Camera>, string>> GetCameraByComputerIdAsync(string computerId)
        {
            return await GetObjectByConditionAsync<Camera>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Camera,
                                                           EmPageSearchType.GUID, EmPageSearchKey.ComputerId, computerId, EmOperation._eq);
        }
        #endregion End Camera

        #region Lane
        public async Task<Tuple<List<Lane>, string>> GetLanesAsync()
        {
            return await GetAllObjectAsync<Lane>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Lane);
        }
        public async Task<Tuple<List<Lane>, string>> GetLaneByComputerIdAsync(string computerId)
        {
            return await GetObjectByConditionAsync<Lane>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Lane,
                                                        EmPageSearchType.GUID, EmPageSearchKey.ComputerId, computerId, EmOperation._eq);

        }
        public async Task<Tuple<Lane, string>> GetLaneByIdAsync(string laneId)
        {
            return await GetObjectDetailByIdAsync<Lane>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Lane, laneId);
        }
        #endregion End Lane

        #region Parking Led
        public async Task<Tuple<List<Led>, string>> GetLedsAsync()
        {
            return await GetAllObjectAsync<Led>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Led);
        }
        public async Task<Tuple<List<Led>, string>> GetLedByComputerIdAsync(string computerId)
        {
            return await GetObjectByConditionAsync<Led>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Led,
                                                        EmPageSearchType.GUID, EmPageSearchKey.ComputerId, computerId, EmOperation._eq);
        }
        #endregion End Parking Led

        #region Control Unit
        public async Task<Tuple<List<Bdk>, string>> GetControlUnitsAsync()
        {
            return await GetAllObjectAsync<Bdk>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.ControlUnit);
        }
        public async Task<Tuple<List<Bdk>, string>> GetControlUnitByComputerIdAsync(string computerId)
        {
            return await GetObjectByConditionAsync<Bdk>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.ControlUnit,
                                                        EmPageSearchType.GUID, EmPageSearchKey.ComputerId, computerId, EmOperation._eq);
        }
        #endregion End Control Unit

        #region Vehicle Type
        public async Task<Tuple<VehicleType, string>> GetVehicleTypeByIdAsync(string vehicleTypeId)
        {
            return await GetObjectDetailByIdAsync<VehicleType>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.VehicleType, vehicleTypeId);
        }
        public async Task<Tuple<List<VehicleType>, string>> GetVehicleTypesAsync()
        {
            return await GetAllObjectAsync<VehicleType>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.VehicleType);
        }
        public async Task<Tuple<List<VehicleType>, string>> GetVehicleTypesAsync(string keyword)
        {
            return await GetObjectByConditionAsync<VehicleType>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.VehicleType,
                                                        EmPageSearchType.TEXT, EmPageSearchKey.name, keyword, EmOperation._contains);

        }
        #endregion End Vehicle Type

        #region Identity
        public async Task<Tuple<Identity, string>> GetIdentityByIdAsync(string id)
        {
            return await GetObjectDetailByIdAsync<Identity>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Identity, id);
        }
        public async Task<Tuple<List<Identity>, string>> GetIdentitiesAsync(string keyword)
        {
            return await GetObjectByConditionAsync<Identity>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Identity,
                                                        EmPageSearchType.TEXT, EmPageSearchKey.name, keyword, EmOperation._contains);

        }
        public async Task<Tuple<Identity, string>> GetIdentityByCodeAsync(string code)
        {
            return await GetTop1ObjectAsync<Identity>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Identity, EmPageSearchType.TEXT,
                                                      EmPageSearchKey.code, code);
        }
        public async Task<Tuple<Identity, string>> CreateIdentityAsync(Identity identity)
        {
            return await CreateObjectAsync<Identity>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Identity,
                                                              identity);
        }
        #endregion End Identity

        #region Identity Group
        public async Task<Tuple<IdentityGroup, string>> GetIdentityGroupByIdAsync(string id)
        {
            return await GetObjectDetailByIdAsync<IdentityGroup>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.IdentityGroup, id);
        }
        public async Task<Tuple<List<IdentityGroup>, string>> GetIdentityGroupsAsync()
        {
            return await GetAllObjectAsync<IdentityGroup>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.IdentityGroup);
        }
        #endregion End Identity Group

        #region Register Vehicle
        public async Task<Tuple<RegisteredVehicle, string>> GetRegistedVehilceByPlateAsync(string plateNumber)
        {
            return await GetTop1ObjectAsync<RegisteredVehicle>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.RegisteredVehicle, EmPageSearchType.TEXT,
                                                      EmPageSearchKey.plateNumber, plateNumber);
        }
        public async Task<Tuple<RegisteredVehicle, string>> GetRegistedVehilceByIdAsync(string id)
        {
            return await GetObjectDetailByIdAsync<RegisteredVehicle>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.RegisteredVehicle, id);
        }
        public async Task<Tuple<List<RegisteredVehicle>, string>> GetRegisterVehiclesAsync(string keyword)
        {
            return await GetObjectByConditionAsync<RegisteredVehicle>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.RegisteredVehicle,
                                                            EmPageSearchType.TEXT, EmPageSearchKey.name, keyword, EmOperation._contains);

        }
        public async Task<Tuple<RegisteredVehicle, string>> CreateRegisteredVehicle(RegisteredVehicle registeredVehicle)
        {
            return await CreateObjectAsync<RegisteredVehicle>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.RegisteredVehicle,
                                                              registeredVehicle);
        }
        public async Task<bool> UpdateRegisteredVehicleAsyncById(RegisteredVehicle registeredVehicle)
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
        public async Task<Tuple<Customer, string>> CreateCustomer(Customer customer)
        {
            return await CreateObjectAsync<Customer>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Customer,
                                                             customer);
        }
        public async Task<Tuple<Customer, string>> GetCustomerByIdAsync(string id)
        {
            return await GetObjectDetailByIdAsync<Customer>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Customer, id);
        }
        public async Task<Tuple<List<Customer>, string>> GetCustomersAsync()
        {
            return await GetAllObjectAsync<Customer>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Customer);
        }
        public async Task<Tuple<List<Customer>, string>> GetCustomersAsync(string keyword)
        {
            return await GetObjectByConditionAsync<Customer>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Customer,
                                                            EmPageSearchType.TEXT, EmPageSearchKey.name, keyword, EmOperation._contains);

        }
        public async Task<bool> UpdateCustomer(Customer customer)
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
        public async Task<Tuple<bool, string>> DeleteCustomerById(string customerId)
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
        public async Task<Tuple<List<CustomerGroup>, string>> GetCustomerGroupsAsync()
        {
            return await GetAllObjectAsync<CustomerGroup>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.CustomerGroup);
        }
        #endregion End Customer Group

        #region Event In
        public async Task<bool> UpdateEventInPlateAsync(string eventId, string newPlate, string oldPlate)
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
                LogHelper.Log(LogHelper.EmLogType.WARN, LogHelper.EmObjectLogType.System, specailName: "LPR_EDIT_IN", mo_ta_them: "EventId: " + eventId +
                                                                                                                                 "\r\nOld Plate: " + oldPlate +
                                                                                                                                 " => New Plate: " + newPlate);
                return true;
            }
            return false;
        }
        public async Task<EventInData> PostCheckInAsync(
            string _laneId, string _plateNumber, Identity? identity, Dictionary<emParkingImageType, List<byte>> imageKeys, bool isForce = false, RegisteredVehicle? registeredVehicle = null, string _note = "")
        {
            if (identity == null)
            {
                return await PostCheckInByPlateAsync(_laneId, _plateNumber, identity, imageKeys, isForce, registeredVehicle, _note);
            }
            else
            {
                return await PostCheckInByIdentityAsync(_laneId, _plateNumber, identity, imageKeys, isForce, registeredVehicle, _note);
            }
        }

        public async Task<EventInData> PostCheckInByIdentityAsync(string _laneId, string _plateNumber, Identity? identity,
                                                                         Dictionary<emParkingImageType, List<byte>> imageDatas, bool isForce = false,
                                                                         RegisteredVehicle? registeredVehicle = null, string _note = "")
        {
            StandardlizeServerName();

            var options = new RestClientOptions("http://192.168.21.145:5000")
            {
                MaxTimeout = 10000,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/event-in", Method.Post);
            request.AddHeader("Authorization", "Bearer " + token);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("laneId", _laneId);
            request.AddParameter("identityCode", identity.Code);
            request.AddParameter("identityType", "0");
            request.AddParameter("plateNumber", _plateNumber);
            request.AddParameter("force", isForce);

            int i = 0;
            foreach (KeyValuePair<emParkingImageType, List<byte>> kvp in imageDatas)
            {
                if (kvp.Value.Count > 0)
                {
                    request.AddFile($"images[{i}].File", kvp.Value.ToArray(), "x.jpg");
                    request.AddParameter($"images[{i}].Type", (int)kvp.Key);
                }
                i++;
            }
            RestResponse response = await client.ExecuteAsync(request);
            if (!string.IsNullOrEmpty(response.Content))
            {
                try
                {
                    EventInData addEventInResponse = NewtonSoftHelper<EventInData>.GetBaseResponse(response.Content);
                    //if (string.IsNullOrEmpty(addEventInResponse.Id))
                    //{
                    //    return null;
                    //}
                    return addEventInResponse;
                }
                catch (Exception)
                {
                }
            }
            return null;
        }
        public async Task<EventInData> PostCheckInByPlateAsync(string _laneId, string _plateNumber, Identity? identity,
                                                                      Dictionary<emParkingImageType, List<byte>> imageDatas, bool isForce = false,
                                                                      RegisteredVehicle? registeredVehicle = null,
                                                                      string _note = "")
        {
            StandardlizeServerName();

            var options = new RestClientOptions(server)
            {
                MaxTimeout = 10000,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/event-in", Method.Post);
            request.AddHeader("Authorization", "Bearer " + token);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("laneId", _laneId);
            request.AddParameter("identityCode", _plateNumber);
            request.AddParameter("identityType", 1);
            request.AddParameter("plateNumber", _plateNumber);
            request.AddParameter("force", isForce);

            int i = 0;
            foreach (KeyValuePair<emParkingImageType, List<byte>> kvp in imageDatas)
            {
                request.AddFile($"images[{i}].File", kvp.Value.ToArray(), "x.jpg");
                request.AddParameter($"images[{i}].Type", (int)kvp.Key);
                i++;
            }
            RestResponse response = await client.ExecuteAsync(request);
            if (!string.IsNullOrEmpty(response.Content))
            {
                try
                {
                    EventInData addEventInResponse = NewtonSoftHelper<EventInData>.GetBaseResponse(response.Content);
                    return addEventInResponse;
                }
                catch (Exception)
                {
                }
            }
            return null;
        }
        public class ImageData
        {
            public string Url { get; set; }
            public emParkingImageType type { get; set; }
        }
        public class EventInData
        {
            public string Id { get; set; }
            public string PlateNumber { get; set; }
            public string note { get; set; }
            public string createdBy { get; set; }
            public string createdUtc { get; set; }
            public Lane Lane { get; set; }
            public Identity Identity { get; set; }
            public Identity IdentityGroup { get; set; }
            public bool OpenBarrier { get; set; }
            public List<ErrorDescription> fields { get; set; } = null;
            public bool IsSuccess { get; set; } = true;
            public string message { get; set; } = string.Empty;
            public string errorCode { get; set; } = string.Empty;
            public string detailCode { get; set; } = string.Empty;
            public List<ImageData> images { get; set; }
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

        public class Report<T> where T : class
        {
            public int TotalPage { get; set; }
            public int TotalCount { get; set; }
            public List<T> data { get; set; }
        }

        public async Task<Report<EventInData>> GetEventIns(string keyword, DateTime startTime, DateTime endTime,
                                    string identityGroupId, string vehicleTypeId, string laneId, string user,
                                    int pageIndex = 1, int pageSize = 100)
        {
            StandardlizeServerName();
            string apiUrl = server + "event-in/search";
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };


            List<FilterModel> filterModels = new List<FilterModel>()
                        {
                            new FilterModel("createdUtc", EmPageSearchType.DATETIME, startTime.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss:0000"), EmOperation._gte),
                            new FilterModel("createdUtc", EmPageSearchType.DATETIME, endTime.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss:0000"),  EmOperation._lte),
                            new FilterModel("createdBy", EmPageSearchType.TEXT, user,  EmOperation._contains),
                            new FilterModel("status", EmPageSearchType.TEXT, "parking",  EmOperation._eq),
                        };
            if (!string.IsNullOrEmpty(laneId))
            {
                filterModels.Add(new FilterModel("lane.id", EmPageSearchType.GUID, laneId, EmOperation._in));
            }
            if (!string.IsNullOrEmpty(identityGroupId))
            {
                filterModels.Add(new FilterModel("identityGroup.id", EmPageSearchType.GUID, identityGroupId, EmOperation._in));
            }
            if (!string.IsNullOrEmpty(vehicleTypeId))
            {
                filterModels.Add(new FilterModel("identityGroup.vehicleType", EmPageSearchType.TEXT, vehicleTypeId.ToUpper(), EmOperation._eq));
            }
            var filter1 = Filter.CreateFilterItem(filterModels, EmMainOperation.and);
            var filter2 = Filter.CreateFilterItem(new List<FilterModel>()
                            {
                                new FilterModel("plateNumber", "TEXT", keyword, "contains"),
                                new FilterModel("identity.code", "TEXT", keyword, "contains"),
                                new FilterModel("identity.name", "TEXT", keyword, "contains"),
                            }, EmMainOperation.or);
            var filter = Filter.CreateFilter(new List<Dictionary<string, List<FilterModel>>>() { filter1, filter2 },
                                            pageIndex: pageIndex,
                                            pageSize: pageSize);

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, filter, headers, null, timeOut, RestSharp.Method.Post);

            if (!string.IsNullOrEmpty(response.Item1))
            {
                var baseResponse = NewtonSoftHelper<KzParkingv5BaseResponse<List<EventInData>>>.GetBaseResponse(response.Item1);
                if (baseResponse != null)
                {
                    Report<EventInData> report = new Report<EventInData>()
                    {
                        TotalPage = baseResponse.totalPage,
                        TotalCount = baseResponse.totalCount,
                        data = baseResponse.data ?? new List<EventInData>(),
                    };
                    return report;
                }
                return new Report<EventInData>()
                {
                    TotalPage = 0,
                    TotalCount = 0,
                    data = new List<EventInData>(),
                };
            }
            return new Report<EventInData>()
            {
                TotalPage = 0,
                TotalCount = 0,
                data = new List<EventInData>(),
            };
        }
        #endregion End Event In

        #region Event Out
        public async Task<string> GetLastEventOutIdentityGroupIdByPlateNumber(string plateNumber)
        {
            StandardlizeServerName();
            string apiUrl = server + KzParkingv5ApiUrlManagement.GetBySqlCmd;
            string cmd = string.Empty;
            cmd += $"SELECT * FROM index_event_out WHERE platenumber = '{plateNumber}' ORDER BY createdutc desc";

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var data = new
            {
                query = cmd,
                fetch_size = 1,
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
                if (dataTable.Rows.Count > 0)
                {
                    return dataTable.Rows[0]["identitygroupid"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            return null;
        }
        public class EventOutData
        {
            public string Id { get; set; }
            public string PlateNumber { get; set; }
            public string createdBy { get; set; }
            public string createdUtc { get; set; }
            public Lane Lane { get; set; }
            public Identity Identity { get; set; }
            public Identity IdentityGroup { get; set; }
            public bool OpenBarrier { get; set; }
            public List<ErrorDescription> fields { get; set; } = null;
            public bool IsSuccess { get; set; } = true;
            public string message { get; set; } = string.Empty;
            public string errorCode { get; set; } = string.Empty;
            public string detailCode { get; set; } = string.Empty;
            public List<ImageData> images { get; set; }
            public EventInData eventIn { get; set; }
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
            public int charge { get; set; }
        }
        public class AddEventOutResponse
        {
            public string invoiceId { get; set; }
            public bool OpenBarrier { get; set; }
            public string Id { get; set; }
            public Identity Identity { get; set; }
            public IdentityGroup IdentityGroup { get; set; }
            public string PlateNumber { get; set; }
            public List<string> fileKeys { get; set; }
            public bool Force { get; set; }
            public bool approve { get; set; }

            public EventInData eventIn { get; set; }

            public string lastPaymentUtc { get; set; }
            public ChargeDetail chargeDetail { get; set; }
            public long discount { get; set; }
            public long paid { get; set; }
            public bool free { get; set; }

            public string createdUtc { get; set; }

            public RegisteredVehicle? RegisteredVehicle { get; set; }
            public Customer? Customer { get; set; }
            public CustomerGroup? CustomerGroup { get; set; }

            public DateTime? DatetimeOut
            {
                get
                {
                    try
                    {
                        if (string.IsNullOrEmpty(createdUtc))
                        {
                            return null;
                        }
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

            public bool IsSuccess { get; set; } = true;
            public string message { get; set; } = string.Empty;
            public string errorCode { get; set; } = string.Empty;
            public string detailCode { get; set; } = string.Empty;
            public List<ErrorDescription> fields { get; set; } = new List<ErrorDescription>();
            public Dictionary<string, EventInData> payload { get; set; }
        }

        public async Task<Report<EventOutData>> GetEventOuts(string keyword, DateTime startTime, DateTime endTime, string identityGroupId, string vehicleTypeId, string laneId, string user, int pageIndex = 1, int pageSize = 10000)
        {
            StandardlizeServerName();
            string apiUrl = server + "event-out/search";
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };


            List<FilterModel> filterModels = new List<FilterModel>()
                        {
                            new FilterModel("createdUtc", EmPageSearchType.DATETIME, startTime.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss:0000"), EmOperation._gte),
                            new FilterModel("createdUtc", EmPageSearchType.DATETIME, endTime.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss:0000"),  EmOperation._lte),
                            new FilterModel("createdBy", EmPageSearchType.TEXT, user,  EmOperation._contains),
                        };
            if (!string.IsNullOrEmpty(laneId))
            {
                filterModels.Add(new FilterModel("lane.id", EmPageSearchType.GUID, laneId, EmOperation._in));
            }
            if (!string.IsNullOrEmpty(identityGroupId))
            {
                filterModels.Add(new FilterModel("identityGroup.id", EmPageSearchType.GUID, identityGroupId, EmOperation._in));
            }
            if (!string.IsNullOrEmpty(vehicleTypeId))
            {
                filterModels.Add(new FilterModel("identityGroup.vehicleType", EmPageSearchType.TEXT, vehicleTypeId.ToUpper(), EmOperation._eq));
            }
            var filter1 = Filter.CreateFilterItem(filterModels, EmMainOperation.and);
            var filter2 = Filter.CreateFilterItem(new List<FilterModel>()
                        {
                            new FilterModel("plateNumber", "TEXT", keyword, "contains"),
                            new FilterModel("identity.code", "TEXT", keyword, "contains"),
                            new FilterModel("identity.name", "TEXT", keyword, "contains"),
                        }, EmMainOperation.or);
            var filter = Filter.CreateFilter(new List<Dictionary<string, List<FilterModel>>>() { filter1, filter2 },
                                            pageIndex: pageIndex,
                                            pageSize: pageSize);
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, filter, headers, null, timeOut, Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                var baseResponse = NewtonSoftHelper<KzParkingv5BaseResponse<List<EventOutData>>>.GetBaseResponse(response.Item1);
                if (baseResponse != null)
                {
                    Report<EventOutData> report = new Report<EventOutData>()
                    {
                        TotalPage = baseResponse.totalPage,
                        TotalCount = baseResponse.totalCount,
                        data = baseResponse.data ?? new List<EventOutData>(),
                    };
                    return report;
                }
                return new Report<EventOutData>()
                {
                    TotalPage = 0,
                    TotalCount = 0,
                    data = new List<EventOutData>(),
                };
            }
            return new Report<EventOutData>()
            {
                TotalPage = 0,
                TotalCount = 0,
                data = new List<EventOutData>(),
            };
        }

        public async Task<AddEventOutResponse> PostCheckOutAsync(string _laneId, string _plateNumber, Identity? identitiy,
                                                                 Dictionary<emParkingImageType, List<byte>> imageDatas, bool isForce)
        {
            StandardlizeServerName();
            string apiUrl = server + KzApiUrlManagement.EmObjectType.EventOut.CreateRoute();
            if (identitiy == null)
            {
                return await PostCheckOutByPlateAsync(_laneId, _plateNumber, identitiy, imageDatas, isForce);
            }
            else
            {
                return await PostCheckOutByIdentityAsync(_laneId, _plateNumber, identitiy, imageDatas, isForce);
            }
        }
        public async Task<AddEventOutResponse> PostCheckOutByIdentityAsync(string _laneId, string _plateNumber, Identity? identity,
                                                                           Dictionary<emParkingImageType, List<byte>> imageDatas, bool isForce = false)
        {
            StandardlizeServerName();

            var options = new RestClientOptions(server)
            {
                MaxTimeout = 10000,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/event-out", Method.Post);
            request.AddHeader("Authorization", "Bearer " + token);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("laneId", _laneId);
            request.AddParameter("identityCode", identity.Code);
            request.AddParameter("identityType", 0);
            request.AddParameter("plateNumber", _plateNumber);
            request.AddParameter("force", isForce);

            int i = 0;
            foreach (KeyValuePair<emParkingImageType, List<byte>> kvp in imageDatas)
            {
                if (kvp.Value.Count > 0)
                {
                    request.AddFile($"images[{i}].File", kvp.Value.ToArray(), "x.jpg");
                    request.AddParameter($"images[{i}].Type", (int)kvp.Key);
                }
                i++;
            }
            RestResponse response = await client.ExecuteAsync(request);
            if (!string.IsNullOrEmpty(response.Content))
            {
                try
                {
                    AddEventOutResponse addEventOutResponse = NewtonSoftHelper<AddEventOutResponse>.GetBaseResponse(response.Content);
                    return addEventOutResponse;
                }
                catch (Exception)
                {
                }
            }
            return null;
        }
        public async Task<AddEventOutResponse> PostCheckOutByPlateAsync(string _laneId, string _plateNumber, Identity? identity,
                                                                        Dictionary<emParkingImageType, List<byte>> imageDatas, bool isForce = false, RegisteredVehicle? registeredVehicle = null)
        {
            StandardlizeServerName();

            var options = new RestClientOptions(server)
            {
                MaxTimeout = 10000,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/event-iout", Method.Post);
            request.AddHeader("Authorization", "Bearer " + token);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("laneId", _laneId);
            request.AddParameter("identityCode", _plateNumber);
            request.AddParameter("identityType", 1);
            request.AddParameter("plateNumber", _plateNumber);
            request.AddParameter("force", isForce);

            int i = 0;
            foreach (KeyValuePair<emParkingImageType, List<byte>> kvp in imageDatas)
            {
                request.AddFile($"images[{i}].File", kvp.Value.ToArray(), "x.jpg");
                request.AddParameter($"images[{i}].Type", (int)kvp.Key);
                i++;
            }
            RestResponse response = await client.ExecuteAsync(request);
            if (!string.IsNullOrEmpty(response.Content))
            {
                try
                {
                    AddEventOutResponse addEventOutResponse = NewtonSoftHelper<AddEventOutResponse>.GetBaseResponse(response.Content);
                    return addEventOutResponse;
                }
                catch (Exception)
                {
                }
            }
            return null;
        }

        public async Task<bool> UpdateEventOutPlate(string eventId, string newPlate, string oldPlate)
        {
            StandardlizeServerName();
            string apiUrl = server + KzParkingv5ApiUrlManagement.PostObjectRoute(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.EventOut) + "/" + eventId;
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
                LogHelper.Log(LogHelper.EmLogType.WARN, LogHelper.EmObjectLogType.System, specailName: "LPR_EDIT_OUT", mo_ta_them: "EventId: " + eventId +
                                                                                                                                    "\r\nOld Plate: " + oldPlate +
                                                                                                                                    " => New Plate: " + newPlate); return true;
            }
            return false;
        }
        public async Task<bool> CommitOutAsync(AddEventOutResponse eventOut)
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
        public async Task<bool> CancelCheckOut(string eventOutId)
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
            public string targetId { get; set; }
            public TargetType targetType { get; set; } = TargetType.EventOut;
            public long amount { get; set; }
            public List<PaymentDetail> details { get; set; }
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
        public async Task<PaymentTransaction> CreatePaymentTransaction(AddEventOutResponse eventOut)
        {
            StandardlizeServerName();
            string apiUrl = server + KzParkingv5ApiUrlManagement.PostObjectRoute(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.PaymentTransaction);
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var data = new PaymentTransaction
            {
                targetId = eventOut.Id,
                targetType = TargetType.EventOut,
                amount = eventOut.chargeDetail.Amount,

                details = new List<PaymentDetail>()
                {
                    new PaymentDetail(){purpose = Purpose.ParkingDay, quantity = eventOut.chargeDetail.Day, amount = eventOut.chargeDetail.DayAmount, price = eventOut.chargeDetail.DayPrice },
                    new PaymentDetail(){purpose = Purpose.ParkingNight, quantity = eventOut.chargeDetail.Night, amount = eventOut.chargeDetail.NightAmount, price = eventOut.chargeDetail.NightPrice },
                    new PaymentDetail(){purpose = Purpose.ParkingNormalCharge, quantity = 1, amount =eventOut.chargeDetail.FullDayAmount, price =eventOut.chargeDetail.FullDayPrice },
                },
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
        public async Task<bool> CreateAlarmAsync(string identityId, string laneId, string plate, AbnormalCode abnormalCode,
                                                Dictionary<emParkingImageType, List<byte>> imageDatas, bool isLaneIn,
                                                string _identityGroupId, string customerId,
                                                string registerVehicleId, string description)
        {
            StandardlizeServerName();
            //string apiUrl = server + KzParkingv5ApiUrlManagement.PostObjectRoute(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.AbnormalEvent);
            //Dictionary<string, string> headers = new Dictionary<string, string>()
            //        {
            //            { "Authorization","Bearer " + token  }
            //        };
            //var abnormalEvent = new
            //{
            //    LaneId = laneId,
            //    identity = new
            //    {
            //        id = identityId,
            //        identityGroupId = _identityGroupId,
            //    },
            //    PlateNumber = plate,
            //    Code = abnormalCode,
            //    FileKeys = new List<string>()
            //            {
            //                imageDatas + (isLaneIn? "_OVERVIEWIN.jpeg" : "_OVERVIEWOUT.jpeg"),
            //                imageDatas + (isLaneIn ? "_VEHICLEIN.jpeg" : "_VEHICLEOUT.jpeg")
            //            },
            //    Description = description
            //};
            //var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, abnormalEvent, headers, null, timeOut, RestSharp.Method.Post);
            //string a = Newtonsoft.Json.JsonConvert.SerializeObject(abnormalEvent);
            //if (!string.IsNullOrEmpty(response.Item1))
            //{
            //    AbnormalEvent kzBaseResponse = NewtonSoftHelper<AbnormalEvent>.GetBaseResponse(response.Item1);
            //    return kzBaseResponse != null;
            //}
            return false;
        }
        public async Task<DataTable> GetAlarmReport(string keyword, DateTime startTime, DateTime endTime, string identityGroupId, string vehicleTypeId, string laneId, int pageIndex = 1, int pageSize = 10000)
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

        //public class InvoiceDto
        //{
        //    public string id { get; set; }
        //    public string orderId { get; set; }
        //    public object requestId { get; set; }
        //    public int serviceProvider { get; set; }
        //    public Creator creator { get; set; }
        //    public string signedFileData { get; set; }
        //    public Company company { get; set; }
        //    public Paymentitem[] paymentItems { get; set; }
        //    public DateTime createdAt { get; set; }
        //    public object modifiedAt { get; set; }
        //    public Lookupinformation lookupInformation { get; set; }
        //    public object note { get; set; }
        //    public Taxdetails taxDetails { get; set; }
        //    public Invoiceconfiguration invoiceConfiguration { get; set; }
        //}

        //public class Creator
        //{
        //    public string id { get; set; }
        //    public string name { get; set; }
        //    public object code { get; set; }
        //    public object phone { get; set; }
        //    public object email { get; set; }
        //    public object description { get; set; }
        //}

        //public class Company
        //{
        //    public string name { get; set; }
        //    public object code { get; set; }
        //    public string taxCode { get; set; }
        //    public object description { get; set; }
        //    public object phoneNumber { get; set; }
        //    public object email { get; set; }
        //}

        //public class Lookupinformation
        //{
        //    public object mappingId { get; set; }
        //    public string invoiceNumber { get; set; }
        //    public string reservationCode { get; set; }
        //}

        //public class Taxdetails
        //{
        //    public int totalWithTax { get; set; }
        //    public int taxAmount { get; set; }
        //    public int taxRate { get; set; }
        //}

        //public class Invoiceconfiguration
        //{
        //    public string templateCode { get; set; }
        //    public string invoiceTypeCode { get; set; }
        //    public string symbolCode { get; set; }
        //}

        //public class Paymentitem
        //{
        //    public string name { get; set; }
        //    public string code { get; set; }
        //    public object description { get; set; }
        //    public string unitName { get; set; }
        //    public object category { get; set; }
        //    public int quantity { get; set; }
        //    public int unitPrice { get; set; }
        //    public int taxRate { get; set; }
        //    public int total { get; set; }
        //}



        public enum Provider
        {
            ThaiSon,
            Misa,
            Viettel
        }
        public enum TargetType
        {
            EventIn,
            EventOut,
            Vehicle
        }

        //public async Task<InvoiceDto> CreateEinvoice(long price, string plateNumber, DateTime datetimeIn, DateTime datetimeOut, string eventOutId, bool isSendNow = true, string cardGroupName = "")
        //{
        //    //string url = $"http://14.160.26.45:26868/einvoice?provider=VIETTEL";
        //    string apiUrl = "";
        //    StandardlizeServerName();
        //    if (isSendNow)
        //    {
        //        apiUrl = server + "e-invoice?provider=VIETTEL";
        //    }
        //    else
        //    {
        //        apiUrl = server + "e-invoice-pending?provider=VIETTEL";
        //    }
        //    //apiUrl = apiUrl.Replace(":5000", ":26868");
        //    //Gửi API
        //    Dictionary<string, string> headers = new Dictionary<string, string>()
        //    {
        //        { "Authorization","Bearer " + token  }
        //    };
        //    TimeSpan parkingTime = datetimeOut - datetimeIn;
        //    var data = new
        //    {
        //        Id = eventOutId,
        //        Company = new
        //        {
        //            Name = StaticPool.CompanyName,
        //            taxCode = StaticPool.TaxCode,
        //        },
        //        Creator = new
        //        {
        //            Id = StaticPool.userId,
        //            Name = StaticPool.user_name,
        //        },
        //        paymentItems = new List<object>()
        //        {
        //            new
        //            {
        //                name = string.IsNullOrEmpty( cardGroupName) ? "Hàng hóa" : cardGroupName,
        //                code = "HH1",
        //                unitName = "Cái",
        //                quantity = 1,
        //                unitPrice = price,
        //                taxRate = StaticPool.TaxRate,
        //            }
        //        },
        //        additionalData = new List<object>()
        //        {
        //            new
        //            {
        //                tag =  "licensePlate",
        //                name = "Biển kiểm soát",
        //                value =  plateNumber,
        //                type=  "text"
        //            },
        //            new
        //            {
        //                tag =  "checkIn",
        //                name = "Giờ vào",
        //                value =  datetimeIn.ToString("dd/MM/yyyy HH:mm:ss"),
        //                type=  "text"
        //            },
        //            new
        //            {
        //                tag =  "checkOut",
        //                name = "Giờ ra",
        //                value =  datetimeOut.ToString("dd/MM/yyyy HH:mm:ss"),
        //                type=  "text"
        //            },
        //            new
        //            {
        //                tag =  "parkingTime",
        //                name = "Thời gian lưu bãi",
        //                value = (int)parkingTime.TotalHours + " giờ " + ((int)parkingTime.TotalMinutes - 60 * (int)parkingTime.TotalHours) + " phút",
        //                type=  "text"
        //            },
        //        },
        //        invoiceConfiguration = new
        //        {
        //            templateCode = StaticPool.templateCode,
        //            invoiceTypeCode = StaticPool.invoiceTypeCode,
        //            symbolCode = StaticPool.symbolCode,
        //        },
        //        taxRate = StaticPool.TaxRate,
        //        createdAt = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:sss.fffZ"),
        //        MappingId = eventOutId,
        //    };
        //    var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, data, headers, null, timeOut, Method.Post);
        //    if (!string.IsNullOrEmpty(response.Item1))
        //    {
        //        try
        //        {
        //            return Newtonsoft.Json.JsonConvert.DeserializeObject<InvoiceDto>(response.Item1);
        //        }
        //        catch (Exception)
        //        {
        //            return null;

        //        }
        //    }
        //    return null;
        //}


        public class InvoiceResponse
        {
            public string id { get; set; }
            public string targetId { get; set; }
            public int targetType { get; set; }
            public string code { get; set; }
            public string reservationCode { get; set; }
            public int provider { get; set; }
            public float amount { get; set; }
            public float taxRate { get; set; }
            public float amountAfterTax { get; set; }
            public bool success { get; set; }
            public bool send { get; set; }
            public int retryAttempt { get; set; }
            public string createdBy { get; set; }
            public string createdUtc { get; set; }
        }

        public class FileInfor
        {
            public string fileName { get; set; }
            public string fileToBytes { get; set; }
        }
        public async Task<InvoiceResponse> CreateEinvoice(long _price, string plateNumber, DateTime datetimeIn, DateTime datetimeOut, string eventOutId, bool isSendNow = true, string cardGroupName = "")
        {
            //string url = $"http://14.160.26.45:26868/einvoice?provider=VIETTEL";
            string apiUrl = "";
            StandardlizeServerName();
            apiUrl = server + "invoice";

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            TimeSpan parkingTime = datetimeOut - datetimeIn;
            var data = new
            {
                targetType = (int)TargetType.EventOut,
                targetId = eventOutId,
                send = isSendNow ? 1 : 0,
                provider = (int)Provider.Viettel,
                items = new List<object>()
                {
                    new
                    {
                        name = string.IsNullOrEmpty( cardGroupName) ? "Hàng hóa" : cardGroupName,
                        code = "HH1",
                        quantity = 1,
                        price = _price,
                    }
                },
                extraInformation = new List<object>()
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
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, data, headers, null, timeOut, Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    return JsonConvert.DeserializeObject<InvoiceResponse>(response.Item1);
                }
                catch (Exception)
                {
                    return null;

                }
            }
            return null;
        }


        public async Task<FileInfor> GetInvoiceData(string orderId, EmInvoiceProvider provider = EmInvoiceProvider.VIETTEL)
        {
            // string url = $"http://14.160.26.45:26868/einvoice?provider=65";
            StandardlizeServerName();
            string apiUrl = server + $"invoice/{orderId}/representation";

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "provider","2"  },
                { "filetType","1"  }
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                return NewtonSoftHelper<FileInfor>.GetBaseResponse(response.Item1);
            }
            return null;
        }

        public async Task<List<InvoiceResponse>> GetMultipleInvoiceData(DateTime startTime, DateTime endTime, EmInvoiceProvider provider = EmInvoiceProvider.VIETTEL)
        {
            //string url = $"http://14.160.26.45:26868/invoice/many";
            StandardlizeServerName();
            string apiUrl = server + "invoice/search";

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var filter = Filter.CreateFilter(new List<FilterModel>()
            {
                new FilterModel("success", "BOOLEAN", "true", "eq"),
                new FilterModel("createdUtc", "DATETIME", startTime.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss:0000"), "gte"),
                new FilterModel("createdUtc", "DATETIME", endTime.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss:0000"), "lte"),
            }, EmMainOperation.and, 0, 10000);
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, filter, headers, null, timeOut, Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {

                return NewtonSoftHelper<KzParkingv5BaseResponse<List<InvoiceResponse>>>.GetBaseResponse(response.Item1)?.data ?? new List<InvoiceResponse>();
            }
            return null;
        }

        public async Task<List<InvoiceResponse>> getPendingEInvoice(DateTime startTime, DateTime endTime)
        {
            //string url = $"http://14.160.26.45:26868/sent-invoice/many";
            StandardlizeServerName();
            string apiUrl = server + "invoice/search";

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var filter = Filter.CreateFilter(new List<FilterModel>()
            {
                new FilterModel("success", "BOOLEAN", "true", "neq"),
                new FilterModel("success", "BOOLEAN", "false", "neq"),
                new FilterModel("createdUtc", "DATETIME", startTime.ToUniversalTime().ToString("2023-MM-ddTHH:mm:ss:0000"), "gte"),
                new FilterModel("createdUtc", "DATETIME", endTime.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss:0000"), "lte"),
            }, EmMainOperation.and, 0, 10000);
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, filter, headers, null, timeOut, Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                var pendingData = NewtonSoftHelper<KzParkingv5BaseResponse<List<InvoiceResponse>>>.GetBaseResponse(response.Item1)?.data ?? new List<InvoiceResponse>();
                return pendingData;
            }
            return new List<InvoiceResponse>();
        }
        public async Task<bool> sendPendingEInvoice(string orderId)
        {
            StandardlizeServerName();
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            string apiUrl = server + $"invoice/{orderId}/resend";
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                var pendingData = NewtonSoftHelper<InvoiceResponse>.GetBaseResponse(response.Item1);
                return pendingData != null;
            }
            return false;
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
        public async Task<SumaryCountEvent> SummaryEventAsync()
        {
            return new SumaryCountEvent();
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
            vehicleInParkCmd += $"WHERE (status != 'Exited' and status is not null) ";
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

        private async Task<int> GetRecordCountByCmd(string apiUrl, Dictionary<string, string> headers, object data)
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

        public async Task<WarehouseService> CreateWarehouseService(string eventInId, string eventOutId, string plate, EmTransactionType type, bool isPrint = false)
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

        public static async Task<bool> UpdateNoteIn(string eventId, string note1, string note2, string note3)
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
                path = "note",
                value = new List<string>() { note1, note2, note3 }
            });
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, commitData, headers, null, timeOut, Method.Patch);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                return true;
            }
            return false;
        }
        public static async Task<bool> UpdateNoteOut(string eventId, string note1, string note2, string note3)
        {
            StandardlizeServerName();
            string apiUrl = server + KzParkingv5ApiUrlManagement.PostObjectRoute(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.EventOut) + "/" + eventId;
            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
             {
                 { "Authorization","Bearer " + token  }
             };
            var commitData = new List<CommitData>();
            commitData.Add(new CommitData()
            {
                op = "replace",
                path = "note",
                value = new List<string>() { note1, note2, note3 }
            });
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, commitData, headers, null, timeOut, Method.Patch);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                return true;
            }
            return false;
        }

        public static async Task<bool> UpdateBSXNote(string newNote, string eventId, bool isEventIn)
        {
            StandardlizeServerName();
            string apiUrl = isEventIn ?
                server + KzParkingv5ApiUrlManagement.PostObjectRoute(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.EventIn) + "/" + eventId :
                server + KzParkingv5ApiUrlManagement.PostObjectRoute(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.EventOut) + "/" + eventId
                ;
            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
             {
                 { "Authorization","Bearer " + token  }
             };
            var commitData = new List<CommitData>();
            commitData.Add(new CommitData()
            {
                op = "replace",
                path = "baseNote",
                value = newNote
            });
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, commitData, headers, null, timeOut, Method.Patch);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
