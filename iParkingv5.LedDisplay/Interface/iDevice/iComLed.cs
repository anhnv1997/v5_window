using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.LedDisplay.Interface.iDevice
{
    public enum EmComArrowType
    {
        Right_LeftToRight = 0x30,
        Right_RightToLeft = 0x31,
        Right_Up = 0x32,
        Right_down = 0x33,
        Left_LeftToRight = 0x34,
        Left_RightToLeft = 0x35,
        Left_Up = 0x36,
        Left_Down = 0x37
    }
    public enum EmComColor
    {
        Red = 0x30,
        Yellow = 0x31,
        Green = 0x32
    }
    public interface iComLed : IEventMonitoring, iBaseLed
    {
        string ComPort { get; set; }
        int Baudrate { get; set; }
        EmComArrowType Arrow { get; set; }
        EmComColor Color { get; set; }
        string CurrentDisplayData { get; set; }
        bool ChangeDisplay(string displayData, ref string errorMessage);
    }
}
