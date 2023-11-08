using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv6.Objects.Datas
{
    public class Gate
    {
        public string Id { get; set; }
        public string GateId { get; set; }
        public string GateCode { get; set; }
        public string GateName { get; set; }
        public string Description { get; set; }
        public bool Inactive { get; set; }
        public int SortOrder { get; set; }

        public Gate()
        {
            Id = string.Empty;
            GateId = Id;
        }
    }
}
