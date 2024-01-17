using iParkingv5.Objects.Datas;
using iParkingv6.Objects.Datas;
using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.LedDisplay.LEDs
{
    public interface IDisplayLED
    {
        bool Connect(Led led);
        void SendToLED(ParkingData parkingData, LedDisplayConfig ledDisplayConfig);
    }
}
