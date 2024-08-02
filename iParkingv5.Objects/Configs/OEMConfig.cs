using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Configs
{
    public class OEMConfig
    {
        public string AppName { get; set; } = "KZTEK";
        public string CompanyName { get; set; } = "KZTEK";
        public int Language { get; set; } = 0;
        public int TimeToDefautUI { get; set; } = 15;
        public bool IsAutoReturnToDefault { get; set; } = false;
    }
}
