using iParkingv5.Objects.Events;
using iParkingv6.Objects.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iParkingv5.Controller
{
    public interface IController
    {
        Bdk ControllerInfo { get; set; }

        #region Event
        event CardEventHandler CardEvent;
        event ControllerErrorEventHandler ErrorEvent;
        event InputEventHandler InputEvent;
        event ConnectStatusChangeEventHandler ConnectStatusChangeEvent;
        event DeviceInfoChangeEventHandler DeviceInfoChangeEvent;
        void PollingStart();
        void PollingStop();
        #endregion End Event

        #region: CONNECT
        Task<bool> TestConnectionAsync();
        Task<bool> ConnectAsync();
        Task<bool> DisconnectAsync();
        #endregion: END CONNECT

        #region DATE - TIME
        Task<DateTime> GetDateTime();
        Task<bool> SetDateTime(DateTime time);
        Task<bool> SyncDateTime();
        #endregion END DATE - TIME

        #region:TCP_IP
        //GET
        Task<string> GetIPAsync();
        Task<string> GetMacAsync();
        Task<string> GetDefaultGatewayAsync();
        Task<int> GetPortAsync();
        Task<string> GetComkeyAsync();

        //SET
        Task<bool> SetMacAsync(string macAddr);
        Task<bool> SetNetWorkInforAsync(string ip, string subnetMask, string defaultGateway, string macAddr);
        Task<bool> SetComKeyAsync(string comKey);
        #endregion: END TCP_IP

        #region System
        Task<bool> ClearMemory();
        Task<bool> RestartDevice();
        Task<bool> ResetDefault();
        #endregion End System

        #region Door Control
        Task<bool> OpenDoor(int timeInMilisecond, int relayIndex);

        Task<bool> AddFinger(List<string> fingerDatas);
        Task<bool> ModifyFInger(string userId, int fingerIndex, string fingerData);
        Task<bool> DeleteFinger(string userId, int fingerIndex);
        #endregion End Region
    }
}
