using iParkingv5.Objects.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace iParkingv5.LedDisplay.Interface.iDevice
{
    public interface IEventMonitoring
    {
        event ConnectStatusChangeEventHandler ConnectStatusChangeEvent;
        event ErrorEventHandler ErrorEvent;
        event DisplayTextChangeEventHandler DisplayTextChangeEvent;
    }
}
