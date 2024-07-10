using iParkingv5.Objects.Datas.Device_service;
using iParkingv6.Objects.Datas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iParkingv5.ApiManager.interfaces
{
    public interface iDeviceService
    {
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
    }
}
