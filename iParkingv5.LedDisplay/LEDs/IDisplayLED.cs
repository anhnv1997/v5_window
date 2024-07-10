using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Datas.Devices;
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
