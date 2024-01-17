using iParkingv5.Objects.Datas;
using iParkingv6.Objects.Datas;
using System;
using System.Collections.Generic;

namespace iParkingv5.Objects.EventDatas
{
    public class AbnormalEvent
    {
        public string Id { get; set; }
        public string IdentityId { get; set; }
        public string LaneId { get; set; }
        public string CreatedBy { get; set; }
        public string PlateNumber { get; set; }
        public AbnormalCode AbnormalCode { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }
        public string CreatedUtc { get; set; }

        public Identity Identity { get; set; }
        public Lane Lane { get; set; }

        public List<string> FileKeys { get; set; }
    }
}