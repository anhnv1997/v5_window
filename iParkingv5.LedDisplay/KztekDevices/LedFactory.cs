using iParkingv5.LedDisplay.Enums;
using iParkingv5.LedDisplay.Interface.iDevice;
using iParkingv5.LedDisplay.KztekDevices.ParkingLed;
using iParkingv5.LedDisplay.Objects;
using KzLedLibraryv2.IpLed;
using System;
using System.Collections.Generic;
using System.Text;
using static iParkingv5.LedDisplay.Enums.LedDisplayModes;

namespace iParkingv5.LedDisplay.KztekDevices
{
    public static class LedFactory
    {
        public static iBaseLed? GetLedController(string ip, int port, EmModuleType moduleType)
        {
            switch (moduleType)
            {
                case EmModuleType.P10FullColor:
                    return new P10FullColor_OutDoor(ip, port, moduleType);
                case EmModuleType.P10FullColor_Outdoor:
                    return new P10FullColor_OutDoor(ip, port, moduleType);
                case EmModuleType.P10_RG_OutDoor:
                    return new P10RG_OutDoor(ip, port, moduleType);
                case EmModuleType.P10Red:
                    return new P10Red_v1(ip, port, moduleType);
                case EmModuleType.P10Red_Outdoor:
                    return new P10Red_OutDoor(ip, port, moduleType);
                case EmModuleType.P7_62_RGY:
                    return new P762RGY(ip, port, moduleType);
                default:
                    return null;
            }
        }

        public static bool ChangeResolution(this iBaseLed led, int numberOfLine, int numRow, int numCol)
        {
            string errorStr = string.Empty;
            try
            {
                if (led == null) return false;
                if (led is iIpLed)
                    return ((iIpLed)led).SetResolution(numberOfLine, numRow, numCol, ref errorStr);
                else return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool ChangeDisplay(this iBaseLed led, Dictionary<int, LineConfig> lineConfigs)
        {
            string errorStr = string.Empty;
            try
            {
                if (led == null) return false;
                if (led is iIpLed)
                    return ((iIpLed)led).ChangeDisplay(EmScreenType.CurrentScreen, lineConfigs, EmDisplayMode.ONE_COLOR_EACH_LINE, null, null, false);
                else return false;
            }
            catch
            {
                return false;
            }
        }


        #region: Network Infor
        public static bool GetIpAddr(this iBaseLed led, ref string ipAddress, ref string errorMessage)
        {
            try
            {
                if (led == null) return false;
                if (led is iIpLed)
                    return ((iIpLed)led).GetIpAddr(ref ipAddress, ref errorMessage);
                else return false;
            }
            catch
            {
                return false;
            }
        }
        public static bool GetPort(this iBaseLed led, ref int port, ref string errorMessage)
        {
            try
            {
                if (led == null) return false;
                if (led is iIpLed)
                    return ((iIpLed)led).GetPort(ref port, ref errorMessage);
                else return false;
            }
            catch
            {
                return false;
            }
        }
        public static bool GetMac(this iBaseLed led, ref string macAddress, ref string errorMessage)
        {
            try
            {
                if (led == null) return false;
                if (led is iIpLed)
                    return ((iIpLed)led).GetMac(ref macAddress, ref errorMessage);
                else return false;
            }
            catch
            {
                return false;
            }
        }
        public static bool GetSubnetMask(this iBaseLed led, ref string subnetMask, ref string errorMessage)
        {
            try
            {
                if (led == null) return false;
                if (led is iIpLed)
                    return ((iIpLed)led).GetSubnetMask(ref subnetMask, ref errorMessage);
                else return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool GetGateWay(this iBaseLed led, ref string gateway, ref string errorMessage)
        {
            try
            {
                if (led == null) return false;
                if (led is iIpLed)
                    return ((iIpLed)led).GetGateWay(ref gateway, ref errorMessage);
                else return false;
            }
            catch
            {
                return false;
            }
        }
        public static bool GetNetworkInfor(this iBaseLed led, ref string ipAddress, ref int port, ref string macAddress, ref string subnetMask, ref string gateway, ref string errorMessage)
        {
            try
            {
                if (led == null) return false;
                if (led is iIpLed)
                    return ((iIpLed)led).GetNetworkInfor(ref ipAddress, ref port, ref macAddress, ref subnetMask, ref gateway, ref errorMessage);
                else return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool ChangeIp(this iBaseLed led, string ipAddress, ref string errorMessage)
        {
            try
            {
                if (led == null) return false;
                if (led is iIpLed)
                    return ((iIpLed)led).ChangeIp(ipAddress, ref errorMessage);
                else return false;
            }
            catch
            {
                return false;
            }
        }
        public static bool ChangePort(this iBaseLed led, int port, ref string errorMessage)
        {
            try
            {
                if (led == null) return false;
                if (led is iIpLed)
                    return ((iIpLed)led).ChangePort(port, ref errorMessage);
                else return false;
            }
            catch
            {
                return false;
            }
        }
        public static bool ChangeMac(this iBaseLed led, string macAddress, ref string errorMessage)
        {
            try
            {
                if (led == null) return false;
                if (led is iIpLed)
                    return ((iIpLed)led).ChangeMac(macAddress, ref errorMessage);
                else return false;
            }
            catch
            {
                return false;
            }
        }
        public static bool ChangeSubnetMask(this iBaseLed led, string subnetMask, ref string errorMessage)
        {
            try
            {
                if (led == null) return false;
                if (led is iIpLed)
                    return ((iIpLed)led).ChangeSubnetMask(subnetMask, ref errorMessage);
                else return false;
            }
            catch
            {
                return false;
            }
        }
        public static bool ChangeGateWay(this iBaseLed led, string gateway, ref string errorMessage)
        {
            try
            {
                if (led == null) return false;
                if (led is iIpLed)
                    return ((iIpLed)led).ChangeGateWay(gateway, ref errorMessage);
                else return false;
            }
            catch
            {
                return false;
            }
        }
        public static bool ChangeNetworkInfor(this iBaseLed led, string ipAddress, int port, string macAddress, string subnetMask, string gateway, ref string errorMessage)
        {
            try
            {
                if (led == null) return false;
                if (led is iIpLed)
                    return ((iIpLed)led).ChangeNetworkInfor(ipAddress, port, macAddress, subnetMask, gateway, ref errorMessage);
                else return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion: End Network Infor

        #region: System Infor
        public static bool GetFirmwareVersion(this iBaseLed led, ref string firmwareVersion, ref string errorMessage)
        {
            try
            {
                if (led == null) return false;
                if (led is iIpLed)
                    return ((iIpLed)led).GetFirmwareVersion(ref firmwareVersion, ref errorMessage);
                else return false;
            }
            catch
            {
                return false;
            }
        }
        public static bool ResetDefault(this iBaseLed led)
        {
            try
            {
                if (led == null) return false;
                if (led is iIpLed)
                    return ((iIpLed)led).ResetDefault();
                else return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion: End System Infor

        #region: Module Type
        public static bool GetModuleType(this iBaseLed led, ref EmModuleType moduleType, ref string errorMessage)
        {
            try
            {
                if (led == null) return false;
                if (led is iIpLed)
                    return ((iIpLed)led).GetModuleType(ref moduleType, ref errorMessage);
                else return false;
            }
            catch
            {
                return false;
            }
        }
        public static bool SetModuleType(this iBaseLed led, EmModuleType moduleType, ref string errorMessage)
        {
            try
            {
                if (led == null) return false;
                if (led is iIpLed)
                    return ((iIpLed)led).SetModuleType(moduleType, ref errorMessage);
                else return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion: End Module Type

        #region: Resolution
        public static bool GetResolution(this iBaseLed led, ref int rowCount, ref int columnCount, ref string errorMessage)
        {
            try
            {
                if (led == null) return false;
                if (led is iIpLed)
                    return ((iIpLed)led).GetResolution(ref rowCount, ref columnCount, ref errorMessage);
                else return false;
            }
            catch
            {
                return false;
            }

        }
        public static bool SetResolution(this iBaseLed led, int numberOfLine, int rowCount, int columnCount, ref string errorMessage)
        {
            try
            {
                if (led == null) return false;
                if (led is iIpLed)
                    return ((iIpLed)led).SetResolution(numberOfLine, rowCount, columnCount, ref errorMessage);
                else return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion: End Resolution

        #region: Change Display
        public static bool ChangeDisplay(this iBaseLed led, EmScreenType screen, Dictionary<int, LineConfig> datas, EmDisplayMode displayMode, List<MergeSetting> mergeSettings, List<ScrollSetting> scrollSettings, bool isScroll)
        {
            try
            {
                if (led == null) return false;
                if (led is iIpLed)
                    return ((iIpLed)led).ChangeDisplay(screen, datas, displayMode, mergeSettings, scrollSettings, isScroll);
                else return false;
            }
            catch
            {
                return false;
            }
        }

        public static void ChangeDisplayWithScroll(this iBaseLed led, Dictionary<int, LineConfig> lineConfigs, List<string> scrollDatas, bool isStartNew = true)
        {
            try
            {
                if (led == null) return;
                if (led is iIpLed)
                    ((iIpLed)led).ChangeDisplayWithScroll(lineConfigs, scrollDatas, isStartNew);
                else return;
            }
            catch
            {
                return;
            }
        }
        #endregion: End Change Display

        public static string GetIpAddress(this iBaseLed led)
        {
            try
            {
                if (led == null) return "";
                if (led is iIpLed)
                    return ((iIpLed)led).IpAddress;
                else return "";
            }
            catch
            {
                return "";
            }
        }
        public static void SetIpAddress(this iBaseLed led, string ip)
        {
            try
            {
                if (led == null) return;
                if (led is iIpLed)
                    ((iIpLed)led).IpAddress = ip;
                else return;
            }
            catch
            {
                return;
            }
        }
    }
}