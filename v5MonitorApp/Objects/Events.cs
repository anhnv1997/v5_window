using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace v5MonitorApp.Objects
{
    public delegate void OnMonitorDeviceNewMessageEventHandler(object sender, DeviceMessageEventArgs deviceMessageEventArgs);
    public class DeviceMessageEventArgs
    {
        public bool IsNormal { get; set; }
        public DateTime NotiTime { get; set; }
        public string DeviceId { get; set; }
        public string IpAddress { get; set; }
        public string DeviceName { get; set; }
        public string Message { get; set; }
    }
}
