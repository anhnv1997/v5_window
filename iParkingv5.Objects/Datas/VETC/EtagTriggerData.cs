using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Datas.VETC
{
    public class EtagTriggerData
    {
        public List<EtagDevice> etagDevices { get; set; }
        public string version { get; set; }
    }
    public class EtagDevice
    {
        public string laneCode { get; set; }
        public bool connected { get; set; }
    }
}
