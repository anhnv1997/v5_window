using System.Collections.Generic;

namespace iParkingv5.Objects.Configs
{
    public class ControllerShortcutConfig
    {
        public string ControllerId { get; set; } = string.Empty;
        public Dictionary<int, int> KeySetByRelays { get; set; } = new Dictionary<int, int>();
    }
}
