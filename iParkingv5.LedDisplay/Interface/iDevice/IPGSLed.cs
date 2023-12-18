using System;
using System.Collections.Generic;
using System.Text;
using static iParkingv5.LedDisplay.KztekDevices.PGSIndoorLed.IndoorLedArrow;
using static iParkingv5.LedDisplay.KztekDevices.PGSIndoorLed.IndoorLedColor;

namespace iParkingv5.LedDisplay.Interface.iDevice
{
    public interface IPGSLed : IEventMonitoring
    {
        #region: INFOR
        string IpAddress { get; set; }
        int Port { get; set; }
        bool Connect(string ipAddress, int port);
        bool Disconnect();
        bool IsConnect { get; set; }
        #endregion: END INFOR

        #region: DISPLAY
        int CurrentSlotsDisplay { get; set; }
        bool ChangeCurrentSlotsAvailable(int slotsCount, ref string errorMessage, EmPGSIndoorLedColor color = EmPGSIndoorLedColor.Red, 
                                         EmPGSIndoorLedArrow arrow = EmPGSIndoorLedArrow.Left_Down, int address = 1);
        #endregion: END DISPLAY

        #region: NETWORK
        bool GetIpAddress(ref string ipAddress, ref string errorMessage);
        bool GetGateway(ref string gateway, ref string errorMessage);
        bool GetSubnetMask(ref string subnetMask, ref string errorMessage);
        bool ChangeIpAddress(string ipAddress, string subnetMask, string gateWay, ref string errorMessage);
        #endregion: END NETWORK

        #region: SYSTEM
        bool GetFirmwareVersion(ref string firmwareVersion, ref string errorMessage);
        bool GetMacAddress(ref string macAddress, ref string errorMessage);
        bool ChangeMacAddress(string macAddress, ref string errorMessage);
        #endregion: END SYSTEM

        #region: POLLING START
        void PollingStartCheckConnection();
        void PollingStopCheckConnection();
        #endregion: END POLLING START
    }
}
