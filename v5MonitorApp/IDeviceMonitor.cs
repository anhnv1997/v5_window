using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using v5MonitorApp.Objects;

namespace v5MonitorApp
{
    public interface IDeviceMonitor
    {
        event OnMonitorDeviceNewMessageEventHandler onMonitorDeviceNewMessageEvent;
        void PollingStart();
        void PollingStop();
    }
}
