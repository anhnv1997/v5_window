using iParkingv5.ApiManager.interfaces;
using iParkingv5.Objects.Datas.parking_service;
using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Enums;
using System;
using System.Collections.Generic;
using static iParkingv5.ApiManager.KzParkingv5Apis.Filter;
using System.Threading.Tasks;
using static iParkingv5.ApiManager.KzParkingv5Apis.KzParkingv5BaseApi;
using Kztek.Tools;

namespace iParkingv5.ApiManager.KzParkingv5Apis.services
{
    public class KzParkingv5DataService : iParkingDataService
    {
        #region PARKING - SERVICE
        public async Task<Tuple<List<ChargeRate>, string>> GetChargeRateAsync()
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingDataService", "Get All Charge Rate");
            return await GetAllObjectAsync<ChargeRate>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.ChargeRate);
        }
        #region Charge - rate

        #endregion

        #region Vehicle Type
        public async Task<Tuple<VehicleType, string>> GetVehicleTypeByIdAsync(string vehicleTypeId)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingDataService", "Get Vehicle Type By Id", vehicleTypeId);
            return await GetObjectDetailByIdAsync<VehicleType>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.VehicleType, vehicleTypeId);
        }
        public async Task<Tuple<List<VehicleType>, string>> GetVehicleTypesAsync()
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingDataService", "Get All VehicleType");
            return await GetAllObjectAsync<VehicleType>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.VehicleType);
        }
        public async Task<Tuple<List<VehicleType>, string>> GetVehicleTypesAsync(string keyword)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingDataService", "Get VehicleType By KeyWord");
            return await GetObjectByConditionAsync<VehicleType>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.VehicleType,
                                                        EmPageSearchType.TEXT, EmPageSearchKey.name, keyword, EmOperation._contains);

        }
        #endregion End Vehicle Type

        #region Identity
        public async Task<Tuple<Identity, string>> GetIdentityByIdAsync(string id)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingDataService", "Get Identity By Id", id);
            return await GetObjectDetailByIdAsync<Identity>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Identity, id);
        }
        public async Task<Tuple<List<Identity>, string>> GetIdentitiesAsync(string keyword)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingDataService", "Get Identity By KeyWord");
            return await GetObjectByConditionAsync<Identity>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Identity,
                                                        EmPageSearchType.TEXT, EmPageSearchKey.name, keyword, EmOperation._contains);

        }
        public async Task<Tuple<Identity, string>> GetIdentityByCodeAsync(string code)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingDataService", "Get Top 1 Identity By Code");
            return await GetTop1ObjectAsync<Identity>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Identity, EmPageSearchType.TEXT,
                                                      EmPageSearchKey.code, code);
        }
        public async Task<Tuple<Identity, string>> CreateIdentityAsync(Identity identity)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingDataService", "Create Identity");
            return await CreateObjectAsync<Identity>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Identity,
                                                              identity);
        }
        #endregion End Identity

        #region Identity Group
        public async Task<Tuple<IdentityGroup, string>> GetIdentityGroupByIdAsync(string id)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingDataService", "Get IdentityGroup By Id", id);
            return await GetObjectDetailByIdAsync<IdentityGroup>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.IdentityGroup, id);
        }
        public async Task<Tuple<List<IdentityGroup>, string>> GetIdentityGroupsAsync()
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingDataService", "Get All IdentityGroup");
            return await GetAllObjectAsync<IdentityGroup>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.IdentityGroup);
        }
        #endregion End Identity Group

        #region Register Vehicle
        public async Task<Tuple<RegisteredVehicle, string>> GetRegistedVehilceByPlateAsync(string plateNumber)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingDataService", "Get Top 1 RegisteredVehicle By PlateNumber");
            return await GetTop1ObjectAsync<RegisteredVehicle>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.RegisteredVehicle, EmPageSearchType.TEXT,
                                                      EmPageSearchKey.plateNumber, plateNumber);
        }
        public async Task<Tuple<RegisteredVehicle, string>> GetRegistedVehilceByIdAsync(string id)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingDataService", "Get RegisteredVehicle By Id", id);
            return await GetObjectDetailByIdAsync<RegisteredVehicle>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.RegisteredVehicle, id);
        }
        public async Task<Tuple<List<RegisteredVehicle>, string>> GetRegisterVehiclesAsync(string keyword)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingDataService", "Get RegisteredVehicle By KeyWord");
            return await GetObjectByConditionAsync<RegisteredVehicle>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.RegisteredVehicle,
                                                            EmPageSearchType.TEXT, EmPageSearchKey.name, keyword, EmOperation._contains);

        }
        public async Task<Tuple<RegisteredVehicle, string>> CreateRegisteredVehicle(RegisteredVehicle registeredVehicle)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingDataService", "Create RegisteredVehicle");
            return await CreateObjectAsync<RegisteredVehicle>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.RegisteredVehicle,
                                                              registeredVehicle);
        }
        public async Task<bool> UpdateRegisteredVehicleAsyncById(RegisteredVehicle registeredVehicle)
        {
            //server = server.StandardlizeServerName();
            //string apiUrl = server + KzApiUrlManagement.EmObjectType.RegisteredVehicle.UpdateRouteById(registeredVehicle.Id);

            ////Gửi API
            //Dictionary<string, string> headers = new Dictionary<string, string>()
            //{
            //    { "Authorization","Bearer " + token  }
            //};
            //var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, registeredVehicle, headers, null, timeOut, RestSharp.Method.Put);
            //if (!string.IsNullOrEmpty(response.Item1))
            //{
            //    KzBaseResponseData<RegisteredVehicle> kzBaseResponse = NewtonSoftHelper<KzBaseResponseData<RegisteredVehicle>>.GetBaseResponse(response.Item1);
            //    if (kzBaseResponse == null)
            //    {
            //        return false;
            //    }
            //    return kzBaseResponse.metadata?.success ?? false;
            //}
            return false;
        }
        #endregion End Register Vehicle

        #region Customer
        public async Task<Tuple<Customer, string>> CreateCustomer(Customer customer)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingDataService", "Create Customer");
            return await CreateObjectAsync<Customer>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Customer,
                                                             customer);
        }
        public async Task<Tuple<Customer, string>> GetCustomerByIdAsync(string id)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingDataService", "Get Customer By Id", id);
            return await GetObjectDetailByIdAsync<Customer>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Customer, id);
        }
        public async Task<Tuple<List<Customer>, string>> GetCustomersAsync()
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingDataService", "Get All Customer");
            return await GetAllObjectAsync<Customer>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Customer);
        }
        public async Task<Tuple<List<Customer>, string>> GetCustomersAsync(string keyword)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingDataService", "Get Customer By KeyWord");
            return await GetObjectByConditionAsync<Customer>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Customer,
                                                            EmPageSearchType.TEXT, EmPageSearchKey.name, keyword, EmOperation._contains);

        }
        public async Task<bool> UpdateCustomer(Customer customer)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingDataService", "Update Customer");
            //server = server.StandardlizeServerName();
            //string apiUrl = server + KzApiUrlManagement.EmObjectType.Customer.UpdateRouteById(customer.Id);

            ////Gửi API
            //Dictionary<string, string> headers = new Dictionary<string, string>()
            //{
            //    { "Authorization","Bearer " + token  }
            //};
            //var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, customer, headers, null, timeOut, RestSharp.Method.Put);
            //if (!string.IsNullOrEmpty(response.Item1))
            //{
            //    KzBaseResponseData<Customer> kzBaseResponse = NewtonSoftHelper<KzBaseResponseData<Customer>>.GetBaseResponse(response.Item1);
            //    return kzBaseResponse?.metadata?.success ?? false;
            //}
            return false;
        }
        public async Task<Tuple<bool, string>> DeleteCustomerById(string customerId)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingDataService", "Delete Customer By Id", customerId);
            //server = server.StandardlizeServerName();
            //string apiUrl = server + KzApiUrlManagement.EmObjectType.Customer.DeleteByIdRoute(customerId);

            ////Gửi API
            //Dictionary<string, string> headers = new Dictionary<string, string>()
            //{
            //    { "Authorization","Bearer " + token  }
            //};
            //var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Delete);
            //if (!string.IsNullOrEmpty(response.Item1))
            //{
            //    KzBaseResponse kzBaseResponse = NewtonSoftHelper<KzBaseResponse>.GetBaseResponse(response.Item1);

            //    if (kzBaseResponse == null)
            //    {
            //        return Tuple.Create<bool, string>(false, "Lỗi dữ liệu, vui lòng thử lại");
            //    }
            //    if (!kzBaseResponse.isSuccess)
            //    {
            //        return Tuple.Create<bool, string>(false, kzBaseResponse.message);
            //    }
            //    return Tuple.Create<bool, string>(true, string.Empty);
            //}
            return Tuple.Create<bool, string>(false, "Lỗi hệ thống, vui lòng thử lại");
        }
        #endregion End Customer

        #region Customer Group
        public async Task<Tuple<List<CustomerGroup>, string>> GetCustomerGroupsAsync()
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingDataService", "Get All Customer Group");
            return await GetAllObjectAsync<CustomerGroup>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.CustomerGroup);
        }
        #endregion End Customer Group
        #endregion END PARKING - SERVICE

    }
}
