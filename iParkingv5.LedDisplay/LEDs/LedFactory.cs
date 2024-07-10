using iParkingv5.LedDisplay.Enums;
using iParkingv5.LedDisplay.LEDs.KztekLeds;
using iParkingv5.Objects.Datas.Device_service;
using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.LedDisplay.LEDs
{
    public static class LedFactory
    {
        public static IDisplayLED? CreateLed(Led led)
        {
            switch ((EmLedType)led.type)
            {
                case EmLedType.P10RED:
                    return new ParkingP10Red() { led = led };
                case EmLedType.P10FULL:
                    return new ParkingP10FullColor() { led = led };
                case EmLedType.P762RGY:
                    return new ParkingP767RGY() { led = led };
                default:
                    return null;
            }
        }
    }
}
