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
        public int spliterCamera_PicEv_PicPlate { get; set; }
        public int spliterCamera_top3Event { get; set; }
        public int spliterPicEv_PicPlate { get; set; }
        public int spliterEventPlate { get; set; }
        public int spliterTopEvent_Actions { get; set; }
        public int spliterEvInPlate { get; set; }
        public int spliterEvOutPlate { get; set; }
    }
}
