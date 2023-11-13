using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv6.Objects.Datas
{
    public class Bdk
    {
        public bool IsConnect { get; set; } = false;
        public string Id { get; set; } = string.Empty;
        public string Code { get; set; }
        public string Name { get; set; }
        public int? CommunicationType { get; set; }
        public string Comport { get; set; }
        public string Baudrate { get; set; }
        public int? LineTypeId { get; set; }

        //public int? Reader1Type { get; set; }
        //public int? Reader2Type { get; set; }
        public string ComputerId { get; set; }
        public string ComputerName { get; set; }
        public int Address { get; set; }
        public bool Inactive { get; set; }
        public int SortOrder { get; set; }
    }
}
