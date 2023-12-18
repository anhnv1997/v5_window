using iParkingv5.LedDisplay.KztekDevices.PGSIndoorLed;
using System;
using System.Collections.Generic;
using System.Text;
using static iParkingv5.LedDisplay.KztekDevices.PGSIndoorLed.IndoorLedArrow;
using static iParkingv5.LedDisplay.KztekDevices.PGSIndoorLed.IndoorLedColor;

namespace iParkingv5.LedDisplay.Interface.iCommand
{
    public class pgs_cmd
    {
        /// <summary>
        /// SetLotsAvailable?/Address=01/StateArrow=1/Colour=0/Num=0001
        /// </summary>
        /// <param name="slotsCount"></param>
        /// <param name="color"></param>
        /// <param name="arrow"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string ChangeDisplayCmd(int slotsCount, EmPGSIndoorLedColor color = EmPGSIndoorLedColor.Red,
                                              EmPGSIndoorLedArrow arrow = EmPGSIndoorLedArrow.Left_Down, int address = 1)
        {
            if (slotsCount > 9999999)
            {
                throw new Exception("Slots Count Is Limited By 999999");
            }
            string cmd = "SetLotsAvailable?";
            cmd += "/Address=";
            cmd += address.ToString("00");
            cmd += "/StateArrow=";
            cmd += GetIndoorLedArrowStr(arrow);
            cmd += "/Colour=";
            cmd += GetIndoorLedColorStr(color);
            cmd += "/Num=";
            cmd += slotsCount.ToString("0000");
            return cmd;
        }

        public static string AutoDetectCmd() => "AutoDetect?";

        public static string ChangeIpAddress(string ipAddress, string gateWay, string macAddress, string subnetMask = "255.255.255.0")
        {
            string cmd = "ChangeIP?";
            cmd += "/IP=";
            cmd += ipAddress;
            cmd += "/SubnetMask=";
            cmd += subnetMask;
            cmd += "/DefaultGateWay=";
            cmd += gateWay;
            cmd += "/HostMac=";
            cmd += macAddress;
            cmd += "/";
            return cmd;
        }

        public static string ChangeMacAddress(string macAddress)
        {
            string cmd = "ChangeMacAddress?";
            cmd += "/Mac=";
            cmd += macAddress;
            return cmd;
        }
    }

}
