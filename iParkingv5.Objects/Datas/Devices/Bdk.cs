using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Datas.Devices
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
    }
}
