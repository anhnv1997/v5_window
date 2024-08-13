using iParkingv5.ApiManager.interfaces;
using iParkingv5.Objects.Datas.Device_service;
using iParkingv6.Objects.Datas;
using System;
using System.Collections.Generic;
using System.Text;
using static iParkingv5.ApiManager.KzParkingv5Apis.Filter;
using System.Threading.Tasks;
using Kztek.Tools;

namespace iParkingv5.ApiManager.KzParkingv5Apis.services
{
    public class KzParkingv5DeviceService : iDeviceService
    {
        #region DEVICE - SERVICE

        #region Computer --OK
        public async Task<Tuple<List<Computer>, string>> GetComputersAsync()
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "DeviceService", "Get All Computer");
            return await KzParkingv5BaseApi.GetAllObjectAsync<Computer>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Computer);
        }
        public async Task<Tuple<Computer, string>> GetComputerByIPAsync(string ip)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "DeviceService", "Get Top 1 Computer By IP", ip);
            return await KzParkingv5BaseApi.GetTop1ObjectAsync<Computer>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Computer,
                                                      EmPageSearchType.TEXT, EmPageSearchKey.IpAddress, ip);
        }
        #endregion End Computer

        #region Gate --OK
        public async Task<Tuple<List<Gate>, string>> GetGatesAsync()
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "DeviceService", "Get All Gate");
            return await KzParkingv5BaseApi.GetAllObjectAsync<Gate>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Gate);
        }
        public async Task<Tuple<Gate, string>> GetGateByIdAsync(string id)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "DeviceService", "Get Gate By Id", id);
            return await KzParkingv5BaseApi.GetObjectDetailByIdAsync<Gate>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Gate, id);
        }
        #endregion End Gate

        #region Camera
        public async Task<Tuple<List<Camera>, string>> GetCamerasAsync()
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "DeviceService", "Get All Camera");
            return await KzParkingv5BaseApi.GetAllObjectAsync<Camera>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Camera);
        }
        public async Task<Tuple<List<Camera>, string>> GetCameraByComputerIdAsync(string computerId)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "DeviceService", "Get Camera By ComputerId", computerId);
            return await KzParkingv5BaseApi.GetObjectByConditionAsync<Camera>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Camera,
                                                           EmPageSearchType.GUID, EmPageSearchKey.ComputerId, computerId, EmOperation._eq);
        }
        #endregion End Camera

        #region Lane
        public async Task<Tuple<List<Lane>, string>> GetLanesAsync()
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "DeviceService", "Get All Lane");
            return await KzParkingv5BaseApi.GetAllObjectAsync<Lane>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Lane);
        }
        public async Task<Tuple<List<Lane>, string>> GetLaneByComputerIdAsync(string computerId)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "DeviceService", "Get Lane By ComputerId", computerId);
            return await KzParkingv5BaseApi.GetObjectByConditionAsync<Lane>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Lane,
                                                        EmPageSearchType.GUID, EmPageSearchKey.ComputerId, computerId, EmOperation._eq);

        }
        public async Task<Tuple<Lane, string>> GetLaneByIdAsync(string id)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "DeviceService", "Get Lane By Id", id);
            return await KzParkingv5BaseApi.GetObjectDetailByIdAsync<Lane>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Lane, id);
        }
        #endregion End Lane

        #region Parking Led
        public async Task<Tuple<List<Led>, string>> GetLedsAsync()
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "DeviceService", "Get All Led");
            return await KzParkingv5BaseApi.GetAllObjectAsync<Led>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Led);
        }
        public async Task<Tuple<List<Led>, string>> GetLedByComputerIdAsync(string computerId)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "DeviceService", "Get Led By ComputerId", computerId);
            return await KzParkingv5BaseApi.GetObjectByConditionAsync<Led>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Led,
                                                        EmPageSearchType.GUID, EmPageSearchKey.ComputerId, computerId, EmOperation._eq);
        }
        #endregion End Parking Led

        #region Control Unit
        public async Task<Tuple<List<Bdk>, string>> GetControlUnitsAsync()
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "DeviceService", "Get All Bdk");
            return await KzParkingv5BaseApi.GetAllObjectAsync<Bdk>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.ControlUnit);
        }
        public async Task<Tuple<List<Bdk>, string>> GetControlUnitByComputerIdAsync(string computerId)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "DeviceService", "Get Bdk By ComputerId", computerId);
            return await KzParkingv5BaseApi.GetObjectByConditionAsync<Bdk>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.ControlUnit,
                                                        EmPageSearchType.GUID, EmPageSearchKey.ComputerId, computerId, EmOperation._eq);
        }
        #endregion End Control Unit

        #endregion END DEVICE - SERVICE
    }
}
