using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv6.Objects.Datas
{
    public class Computer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string GateId { get; set; }
        public string IpAddress { get; set; }
        public object Description { get; set; }
        public bool Enabled { get; set; }
        public string CreatedUtc { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedUtc { get; set; }
        public string UpdatedBy { get; set; }
        public object Gate { get; set; }
    }
}
