using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Configs
{
    public class LaneOutShortcutConfig
    {
        public int ConfirmPlateKey { get; set; } = 0x0D;
        public int WriteOut { get; set; } = 0x72;
        public int ReserveLane { get; set; } = 0x73;
    }
}
