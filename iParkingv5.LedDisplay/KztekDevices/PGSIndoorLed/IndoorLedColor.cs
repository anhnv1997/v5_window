using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.LedDisplay.KztekDevices.PGSIndoorLed
{
    public class IndoorLedColor
    {
        public EmPGSIndoorLedColor LedColor { get; set; }
        public enum EmPGSIndoorLedColor
        {
            Red = 0x30,
            Yellow = 0x31,
            Green = 0x32,
        }
        public override string ToString()
        {
            return GetIndoorLedColorStr(this.LedColor);
        }
        public static string GetIndoorLedColorStr(EmPGSIndoorLedColor color)
        {
            return color switch
            {
                EmPGSIndoorLedColor.Red => "0",
                EmPGSIndoorLedColor.Yellow => "1",
                EmPGSIndoorLedColor.Green => "2",
                _ => throw new Exception("NOT SUPPORT"),
            };
        }
    }
}
