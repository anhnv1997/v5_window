using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Configs
{
    public class LaneDisplayConfig
    {
        public string LaneId { get; set; }
        public int DisplayIndex { get; set; }
        public int SplitterCameraPosition { get; set; }
        public int splitContainerMain { get; set; }
        public int splitContainerEventContent { get; set; }
    }
}
