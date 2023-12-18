using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv6.Objects.Datas
{
    public class Computer
    {
        public string id { get; set; }
        public string name { get; set; }
        public string gateId { get; set; }
        public string ipAddress { get; set; }
        public object description { get; set; }
        public bool enabled { get; set; }
        public bool deleted { get; set; }
        public string createdUtc { get; set; }
        public string createdBy { get; set; }
        public string updatedUtc { get; set; }
        public string updatedBy { get; set; }
        public object gate { get; set; }
    }
}
