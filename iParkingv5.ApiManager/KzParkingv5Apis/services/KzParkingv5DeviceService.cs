using iParkingv5.ApiManager.interfaces;
using iParkingv5.Objects.Datas.Device_service;
using iParkingv6.Objects.Datas;
using System;
using System.Collections.Generic;
using System.Text;
using static iParkingv5.ApiManager.KzParkingv5Apis.Filter;
using System.Threading.Tasks;

namespace iParkingv5.ApiManager.KzParkingv5Apis.services
{
    public class KzParkingv5DeviceService : iDeviceService
    {
        #region DEVICE - SERVICE

        #region Computer --OK
        public async Task<Tuple<List<Computer>, string>> GetComputersAsync()
        {
            return await KzParkingv5BaseApi.GetAllObjectAsync<Computer>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Computer);
        }
        public async Task<Tuple<Computer, string>> GetComputerByIPAsync(string ip)
        {
            return await KzParkingv5BaseApi.GetTop1ObjectAsync<Computer>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Computer,
                                                      EmPageSearchType.TEXT, EmPageSearchKey.IpAddress, ip);
        }
        #endregion End Computer

        #region Gate --OK
        public async Task<Tuple<List<Gate>, string>> GetGatesAsync()
        {
            return await KzParkingv5BaseApi.GetAllObjectAsync<Gate>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Gate);
        }
        public async Task<Tuple<Gate, string>> GetGateByIdAsync(string gateId)
        {
            return await KzParkingv5BaseApi.GetObjectDetailByIdAsync<Gate>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Gate, gateId);
        }
        #endregion End Gate

        #region Camera
        public async Task<Tuple<List<Camera>, string>> GetCamerasAsync()
        {
            return await KzParkingv5BaseApi.GetAllObjectAsync<Camera>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Camera);
        }
        public async Task<Tuple<List<Camera>, string>> GetCameraByComputerIdAsync(string computerId)
        {
            return await KzParkingv5BaseApi.GetObjectByConditionAsync<Camera>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Camera,
                                                           EmPageSearchType.GUID, EmPageSearchKey.ComputerId, computerId, EmOperation._eq);
        }
        #endregion End Camera

        #region Lane
        public async Task<Tuple<List<Lane>, string>> GetLanesAsync()
        {
            return await KzParkingv5BaseApi.GetAllObjectAsync<Lane>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Lane);
        }
        public async Task<Tuple<List<Lane>, string>> GetLaneByComputerIdAsync(string computerId)
        {
            return await KzParkingv5BaseApi.GetObjectByConditionAsync<Lane>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Lane,
                                                        EmPageSearchType.GUID, EmPageSearchKey.ComputerId, computerId, EmOperation._eq);

        }
        public async Task<Tuple<Lane, string>> GetLaneByIdAsync(string laneId)
        {
            return await KzParkingv5BaseApi.GetObjectDetailByIdAsync<Lane>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Lane, laneId);
        }
        #endregion End Lane

        #region Parking Led
        public async Task<Tuple<List<Led>, string>> GetLedsAsync()
        {
            return await KzParkingv5BaseApi.GetAllObjectAsync<Led>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Led);
        }
        public async Task<Tuple<List<Led>, string>> GetLedByComputerIdAsync(string computerId)
        {
            return await KzParkingv5BaseApi.GetObjectByConditionAsync<Led>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.Led,
                                                        EmPageSearchType.GUID, EmPageSearchKey.ComputerId, computerId, EmOperation._eq);
        }
        #endregion End Parking Led

        #region Control Unit
        public async Task<Tuple<List<Bdk>, string>> GetControlUnitsAsync()
        {
            return await KzParkingv5BaseApi.GetAllObjectAsync<Bdk>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.ControlUnit);
        }
        public async Task<Tuple<List<Bdk>, string>> GetControlUnitByComputerIdAsync(string computerId)
        {
            return await KzParkingv5BaseApi.GetObjectByConditionAsync<Bdk>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.ControlUnit,
                                                        EmPageSearchType.GUID, EmPageSearchKey.ComputerId, computerId, EmOperation._eq);
        }
        #endregion End Control Unit

        #endregion END DEVICE - SERVICE

    }
}
