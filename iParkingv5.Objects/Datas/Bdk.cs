using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv6.Objects.Datas
{

    public class Bdk
    {
        public string id { get; set; }
        public object code { get; set; }
        public string name { get; set; }
        public int communicationType { get; set; }
        public string comport { get; set; }
        public string baudrate { get; set; }
        public int type { get; set; }
        public string computerId { get; set; }
        public bool enabled { get; set; }
        public bool deleted { get; set; }
        public string createdUtc { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string createdBy { get; set; }
        public object updatedUtc { get; set; }
        public object updatedBy { get; set; }
        public object computer { get; set; }
        public object[] laneControlUnitMaps { get; set; }

        public bool isConnect { get; set; } 
    }
}
