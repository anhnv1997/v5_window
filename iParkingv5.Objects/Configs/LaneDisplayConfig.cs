using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Configs
{
    /// <summary>
    /// Thông tin kích thước hiển thị trên giao diện
    /// </summary>
    public class LaneDisplayConfig
    {
        public string LaneId { get; set; }
        public int DisplayIndex { get; set; }
        public int SplitterCameraPosition { get; set; }
        public int splitContainerMain { get; set; }
        public int splitContainerEventContent { get; set; }
        public int splitEventInfoWithCameraPosition { get; set; }
        public int splitContainerCameraPosition { get; set; }
        public int splitLastEventPosition { get; set; }
    }
}
