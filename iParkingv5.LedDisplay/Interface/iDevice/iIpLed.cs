using iParkingv5.LedDisplay.Enums;
using iParkingv5.LedDisplay.KztekDevices;
using iParkingv5.LedDisplay.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using static iParkingv5.LedDisplay.Enums.LedDisplayModes;

namespace iParkingv5.LedDisplay.Interface.iDevice
{
    public enum EmScreenType
    {
        CurrentScreen,
        DefaultScreen
    }
    public interface iIpLed : IEventMonitoring, iBaseLed
    {
        string IpAddress { get; set; }
        int Port { get; set; }
        bool IsScroll { get; set; }


        #region: Network Infor
        bool GetIpAddr(ref string ipAddress, ref string errorMessage);
        bool GetPort(ref int port, ref string errorMessage);
        bool GetMac(ref string macAddress, ref string errorMessage);
        bool GetSubnetMask(ref string subnetMask, ref string errorMessage);
        bool GetGateWay(ref string gateway, ref string errorMessage);
        bool GetNetworkInfor(ref string ipAddress, ref int port, ref string macAddress, ref string subnetMask, ref string gateway, ref string errorMessage);

        bool ChangeIp(string ipAddress, ref string errorMessage);
        bool ChangePort(int port, ref string errorMessage);
        bool ChangeMac(string macAddress, ref string errorMessage);
        bool ChangeSubnetMask(string subnetMask, ref string errorMessage);
        bool ChangeGateWay(string gateway, ref string errorMessage);
        bool ChangeNetworkInfor(string ipAddress, int port, string macAddress, string subnetMask, string gateway, ref string errorMessage);
        #endregion: End Network Infor

        #region: System Infor
        bool GetFirmwareVersion(ref string firmwareVersion, ref string errorMessage);
        bool ResetDefault();
        #endregion: End System Infor

        #region: Module Type
        bool GetModuleType(ref EmModuleType moduleType, ref string errorMessage);
        bool SetModuleType(EmModuleType moduleType, ref string errorMessage);
        #endregion: End Module Type

        #region: Resolution
        bool GetResolution(ref int rowCount, ref int columnCount, ref string errorMessage);
        bool SetResolution(int numberOfLine, int rowCount, int columnCount, ref string errorMessage);
        #endregion: End Resolution

        #region: Change Display
        bool ChangeDisplay(EmScreenType screen, Dictionary<int, LineConfig> datas, EmDisplayMode displayMode, List<MergeSetting> mergeSettings, List<ScrollSetting> scrollSettings, bool isScroll);

        void ChangeDisplayWithScroll(Dictionary<int, LineConfig> lineConfigs, List<string> scrollDatas, bool isUpdate = true);
        #endregion: End Change Display
    }
}
