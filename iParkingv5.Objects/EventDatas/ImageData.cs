using System;
using System.Collections.Generic;
using System.Text;
using static iParkingv5.Objects.Enums.ParkingImageType;

namespace iParkingv5.Objects.EventDatas
{
    public class ImageData
    {
        public string Url { get; set; }
        public EmParkingImageType type { get; set; }
    }
}
