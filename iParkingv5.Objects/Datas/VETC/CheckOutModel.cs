using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Datas.VETC
{
    public class CheckOutModel
    {
        public string transId { get; set; } = "";
        public string checkoutLaneId { get; set; } = "";
        public string etag { get; set; } = "";
        public string plate { get; set; } = "";
        public string laneCardId { get; set; } = "";
        public int totalAmount { get; set; } = 0;
        public string description { get; set; } = "";
        public long checkinTime { get; set; } = 0;
        public string base64Image { get; set; } = "";
        public string additionalBase64Image { get; set; } = "";
        public bool forceQR { get; set; } = false;
    }
}
