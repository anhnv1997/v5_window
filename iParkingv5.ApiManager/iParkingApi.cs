using iParkingv5.ApiManager.KzParkingv5Apis;
using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Enums;
using iParkingv5.Objects.EventDatas;
using iParkingv5.Objects.Invoices;
using iParkingv6.Objects.Datas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using static iParkingv5.ApiManager.KzParkingv5Apis.KzParkingv5ApiHelper;
using static iParkingv6.ApiManager.KzParkingv3Apis.KzParkingApiHelper;
using static iParkingv6.ApiManager.KzParkingv3Apis.KzParkingApiHelper.TransactionType;

namespace iParkingv5.ApiManager
{
    public interface iParkingApi
    {
        Task<string> GetFeeCalculate(string dateTimeIn, string dateTimeOut, string identityGroupID);
        Task GetUserInfor();
        Task<Tuple<List<User>, string>> GetAllUsers();

        #region Computer
        Task<Tuple<List<Computer>, string>> GetComputersAsync();
        Task<Tuple<Computer, string>> GetComputerByIPAsync(string ip);
        #endregion End Computer

        #region Gate
        Task<Tuple<List<Gate>, string>> GetGatesAsync();
        Task<Tuple<Gate, string>> GetGateByIdAsync(string gateId);
        #endregion End Gate

        #region Camera
        Task<Tuple<List<Camera>, string>> GetCamerasAsync();
        Task<Tuple<List<Camera>, string>> GetCameraByComputerIdAsync(string computerId);
        #endregion End Camera

        #region Lane
        Task<Tuple<List<Lane>, string>> GetLanesAsync();
        Task<Tuple<List<Lane>, string>> GetLaneByComputerIdAsync(string computerId);
        Task<Tuple<Lane, string>> GetLaneByIdAsync(string laneId);
        #endregion End Lane

        #region Parking Led
        Task<Tuple<List<Led>, string>> GetLedsAsync();
        Task<Tuple<List<Led>, string>> GetLedByComputerIdAsync(string computerId);
        #endregion End Parking Led

        #region Control Unit
        Task<Tuple<List<Bdk>, string>> GetControlUnitsAsync();
        Task<Tuple<List<Bdk>, string>> GetControlUnitByComputerIdAsync(string computerId);
        #endregion End Control Unit

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

        #region Event In
        Task<bool> UpdateEventInPlateAsync(string eventId, string newPlate);
        Task<AddEventInResponse> PostCheckInAsync(
            string _laneId, string _plateNumber, Identity? identity, List<string> imageKeys, 
            bool isForce = false, RegisteredVehicle? registeredVehicle = null, string note = "");
        Task<DataTable> GetEventIns(string keyword, DateTime startTime, DateTime endTime,
                                    string identityGroupId, string vehicleTypeId, string laneId, string user,
                                    int pageIndex = 1, int pageSize = 100);
        #endregion End Event In

        #region Event Out
        Task<bool> UpdateEventOutPlate(string eventId, string newPlate);
        Task<DataTable> GetEventOuts(string keyword, DateTime startTime, DateTime endTime, string identityGroupId, string vehicleTypeId, string laneId, string user, int pageIndex = 1, int pageSize = 10000);
        Task<AddEventOutResponse> PostCheckOutAsync(string _laneId, string _plateNumber, Identity? identitiy, List<string> imageKeys, bool isForce);
        Task<bool> CommitOutAsync(AddEventOutResponse eventOut);
        Task<bool> CancelCheckOut(string eventOutId);
        Task<KzParkingv5ApiHelper.PaymentTransaction> CreatePaymentTransaction(AddEventOutResponse eventOut);
        #endregion End Event Out

        #region Alarm
        Task<bool> CreateAlarmAsync(string identityId, string laneId, string plate, AbnormalCode abnormalCode,
                                                        string imageKey, bool isLaneIn, string _identityGroupId, string customerId,
                                                        string registerVehicleId, string description);
        Task<DataTable> GetAlarmReport(string keyword, DateTime startTime, DateTime endTime, string identityGroupId, string vehicleTypeId, string laneId, int pageIndex = 1, int pageSize = 10000);
        #endregion End Alarm

        #region EInvoice
        Task<InvoiceDto> CreateEinvoice(long price, string plateNumber, DateTime datetimeIn, DateTime datetimeOut, string eventOutId);
        Task<InvoiceData> GetInvoiceData(string orderId, EmInvoiceProvider provider = EmInvoiceProvider.VIETTEL);
        Task<List<InvoiceDataSearch>> GetMultipleInvoiceData(List<string> orderIds, EmInvoiceProvider provider = EmInvoiceProvider.VIETTEL);
        #endregion End Einvoice

        #region Sumary
        Task<SumaryCountEvent> SummaryEventAsync();
        #endregion End Sumary

        #region Warehouse
        Task<WarehouseService> CreateWarehouseService(string eventInId, string eventOutId, string plate, EmTransactionType type, bool isPrint = false);
        #endregion End warehouse
    }
}
