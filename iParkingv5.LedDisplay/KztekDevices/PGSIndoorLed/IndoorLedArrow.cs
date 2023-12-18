using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.LedDisplay.KztekDevices.PGSIndoorLed
{
    public class IndoorLedArrow
    {
        public EmPGSIndoorLedArrow LedArrow { get; set; }
        public enum EmPGSIndoorLedArrow
        {
            Right_left_Right = 0x30,
            Right_Right_Left = 0x31,
            Right_Up = 0x32,
            Right_down = 0x33,
            Left_Left_Right = 0x34,
            Left_Right_Left = 0x35,
            Left_Up = 0x36,
            Left_Down = 0x37,
        }
        public static string GetIndoorLedArrowStr(EmPGSIndoorLedArrow arrow)
        {
            return arrow switch
            {
                EmPGSIndoorLedArrow.Right_left_Right => "0",
                EmPGSIndoorLedArrow.Right_Right_Left => "1",
                EmPGSIndoorLedArrow.Right_Up => "2",
                EmPGSIndoorLedArrow.Right_down => "3",
                EmPGSIndoorLedArrow.Left_Left_Right => "4",
                EmPGSIndoorLedArrow.Left_Right_Left => "5",
                EmPGSIndoorLedArrow.Left_Up => "6",
                EmPGSIndoorLedArrow.Left_Down => "7",
                _ => throw new Exception("NOT SUPPORT"),
            };
        }
        public override string ToString()
        {
            return GetIndoorLedArrowStr(this.LedArrow);
        }
    }
}
