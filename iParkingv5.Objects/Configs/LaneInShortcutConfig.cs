using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Configs
{
    public class LaneInShortcutConfig
    {
        public int ConfirmPlateKey { get; set; } = 0x0D;
        public int WriteIn { get; set; } = 0x70;
        public int ReserveLane { get; set; } = 0x71;
        public int ReSnapshotKey { get; set; } = 0x72;

        public LaneInShortcutConfig() { }
    }
}
