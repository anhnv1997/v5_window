using iParkingv5.Objects.Datas.parking_service;
using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iParkingv5.ApiManager.interfaces
{
    public interface iParkingDataService
    {

        #region Vehicle Type
        Task<Tuple<VehicleType, string>> GetVehicleTypeByIdAsync(string vehicleTypeId);
        Task<Tuple<List<VehicleType>, string>> GetVehicleTypesAsync();
        Task<Tuple<List<VehicleType>, string>> GetVehicleTypesAsync(string keyword);
        #endregion End Vehicle Type

        #region Identity
        Task<Tuple<Identity, string>> GetIdentityByIdAsync(string id);
        Task<Tuple<List<Identity>, string>> GetIdentitiesAsync(string keyword);
        Task<Tuple<Identity, string>> GetIdentityByCodeAsync(string code);
        Task<Tuple<Identity, string>> CreateIdentityAsync(Identity identity);
        #endregion End Identity

        #region Identity Group
        Task<Tuple<IdentityGroup, string>> GetIdentityGroupByIdAsync(string id);
        Task<Tuple<List<IdentityGroup>, string>> GetIdentityGroupsAsync();
        #endregion End Identity Group

        #region Register Vehicle
        Task<Tuple<RegisteredVehicle, string>> GetRegistedVehilceByPlateAsync(string plateNumber);
        Task<Tuple<RegisteredVehicle, string>> GetRegistedVehilceByIdAsync(string id);
        Task<Tuple<List<RegisteredVehicle>, string>> GetRegisterVehiclesAsync(string keyword);
        Task<Tuple<RegisteredVehicle, string>> CreateRegisteredVehicle(RegisteredVehicle registeredVehicle);
        Task<bool> UpdateRegisteredVehicleAsyncById(RegisteredVehicle registeredVehicle);
        #endregion End Register Vehicle

        #region Customer
        Task<Tuple<Customer, string>> CreateCustomer(Customer customer);
        Task<Tuple<Customer, string>> GetCustomerByIdAsync(string id);
        Task<Tuple<List<Customer>, string>> GetCustomersAsync();
        Task<Tuple<List<Customer>, string>> GetCustomersAsync(string keyword);
        Task<bool> UpdateCustomer(Customer customer);
        Task<Tuple<bool, string>> DeleteCustomerById(string customerId);
        #endregion End Customer

        #region Customer Group
        Task<Tuple<List<CustomerGroup>, string>> GetCustomerGroupsAsync();
        #endregion End Customer Group
    }
}
