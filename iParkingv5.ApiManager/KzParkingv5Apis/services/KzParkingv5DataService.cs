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
using static iParkingv5.ApiManager.KzParkingv5Apis.KzParkingv5ApiUrlManagement;
using Kztek.Tool.LogDatabases;

namespace iParkingv5.ApiManager.KzParkingv5Apis.services
{
    public class KzParkingv5DataService : iParkingDataService
    {
        #region PARKING - SERVICE
        public async Task<Tuple<List<ChargeRate>, string>> GetChargeRateAsync()
        {
            return await GetAllObjectAsync<ChargeRate>(EmParkingv5ObjectType.ChargeRate);
        }
        #region Charge - rate

        #endregion

        #region Vehicle Type
        public async Task<Tuple<VehicleType, string>> GetVehicleTypeByIdAsync(string vehicleTypeId)
        {
            return await GetObjectDetailByIdAsync<VehicleType>(EmParkingv5ObjectType.VehicleType, vehicleTypeId);
        }
        public async Task<Tuple<List<VehicleType>, string>> GetVehicleTypesAsync()
        {
            return await GetAllObjectAsync<VehicleType>(EmParkingv5ObjectType.VehicleType);
        }
        public async Task<Tuple<List<VehicleType>, string>> GetVehicleTypesAsync(string keyword)
        {
            return await GetObjectByConditionAsync<VehicleType>(EmParkingv5ObjectType.VehicleType,
                                                        EmPageSearchType.TEXT, EmPageSearchKey.name, keyword, EmOperation._contains);

        }
        #endregion End Vehicle Type

        #region Identity
        public async Task<Tuple<Identity, string>> GetIdentityByIdAsync(string id)
        {
            return await GetObjectDetailByIdAsync<Identity>(EmParkingv5ObjectType.Identity, id);
        }
        public async Task<Tuple<List<Identity>, string>> GetIdentitiesAsync(string keyword)
        {
            return await GetObjectByConditionAsync<Identity>(EmParkingv5ObjectType.Identity,
                                                        EmPageSearchType.TEXT, EmPageSearchKey.name, keyword, EmOperation._contains);

        }
        public async Task<Tuple<Identity, string>> GetIdentityByCodeAsync(string code)
        {
            return await GetTop1ObjectAsync<Identity>(EmParkingv5ObjectType.Identity, EmPageSearchType.TEXT,
                                                      EmPageSearchKey.code, code);
        }
        public async Task<Tuple<Identity, string>> CreateIdentityAsync(Identity identity)
        {
            return await CreateObjectAsync<Identity>(EmParkingv5ObjectType.Identity,
                                                              identity);
        }
        #endregion End Identity

        #region Identity Group
        public async Task<Tuple<IdentityGroup, string>> GetIdentityGroupByIdAsync(string id)
        {
            return await GetObjectDetailByIdAsync<IdentityGroup>(EmParkingv5ObjectType.IdentityGroup, id);
        }
        public async Task<Tuple<List<IdentityGroup>, string>> GetIdentityGroupsAsync()
        {
            return await GetAllObjectAsync<IdentityGroup>(EmParkingv5ObjectType.IdentityGroup);
        }
        #endregion End Identity Group

        #region Register Vehicle
        public async Task<Tuple<RegisteredVehicle, string>> GetRegistedVehilceByPlateAsync(string plateNumber)
        {
            return await GetTop1ObjectAsync<RegisteredVehicle>(EmParkingv5ObjectType.RegisteredVehicle, EmPageSearchType.TEXT,
                                                      EmPageSearchKey.plateNumber, plateNumber);
        }
        public async Task<Tuple<RegisteredVehicle, string>> GetRegistedVehilceByIdAsync(string id)
        {
            return await GetObjectDetailByIdAsync<RegisteredVehicle>(EmParkingv5ObjectType.RegisteredVehicle, id);
        }
        public async Task<Tuple<List<RegisteredVehicle>, string>> GetRegisterVehiclesAsync(string keyword)
        {
            return await GetObjectByConditionAsync<RegisteredVehicle>(EmParkingv5ObjectType.RegisteredVehicle,
                                                            EmPageSearchType.TEXT, EmPageSearchKey.name, keyword, EmOperation._contains);
        }
        public async Task<Tuple<RegisteredVehicle, string>> CreateRegisteredVehicle(RegisteredVehicle registeredVehicle)
        {
            return await CreateObjectAsync<RegisteredVehicle>(EmParkingv5ObjectType.RegisteredVehicle,
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
            return await CreateObjectAsync<Customer>(EmParkingv5ObjectType.Customer,
                                                             customer);
        }
        public async Task<Tuple<Customer, string>> GetCustomerByIdAsync(string id)
        {
            return await GetObjectDetailByIdAsync<Customer>(EmParkingv5ObjectType.Customer, id);
        }
        public async Task<Tuple<List<Customer>, string>> GetCustomersAsync()
        {
            return await GetAllObjectAsync<Customer>(EmParkingv5ObjectType.Customer);
        }
        public async Task<Tuple<List<Customer>, string>> GetCustomersAsync(string keyword)
        {
            return await GetObjectByConditionAsync<Customer>(EmParkingv5ObjectType.Customer,
                                                            EmPageSearchType.TEXT, EmPageSearchKey.name, keyword, EmOperation._contains);

        }
        public async Task<bool> UpdateCustomer(Customer customer)
        {
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
            return await GetAllObjectAsync<CustomerGroup>(EmParkingv5ObjectType.CustomerGroup);
        }
        #endregion End Customer Group
        #endregion END PARKING - SERVICE

    }
}
