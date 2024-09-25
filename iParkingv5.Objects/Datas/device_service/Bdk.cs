using iParkingv5.Objects.Configs;
using iParkingv5.Objects.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv6.Objects.Datas
{

    public class Bdk
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public int CommunicationType { get; set; }
        public string Comport { get; set; }
        public string Baudrate { get; set; }

        public int Type { get; set; }
        public string ComputerId { get; set; }
        public bool Enabled { get; set; }

        public string CreatedUtc { get; set; }
        public string CreatedBy { get; set; }
        public object UpdatedUtc { get; set; }
        public object UpdatedBy { get; set; }

        public bool IsConnect { get; set; }
        public int OutputCount { get; set; }
        public List<CardFormatConfig> configs { get; set; } = new List<CardFormatConfig>();
    }
}
