using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Datas.Device_service;
using iParkingv5.Objects.Datas.parking_service;
using System;
using System.Collections.Generic;
using System.Text;
using static iParkingv5.Objects.Enums.ParkingImageType;

namespace iParkingv5.Objects.EventDatas
{
    public class BaseEventData
    {
        public string Id { get; set; }
        public string PlateNumber { get; set; }
        public string Note { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedUtc { get; set; }

        public Identity Identity { get; set; }
        public Identity IdentityGroup { get; set; }
        public Dictionary<EmParkingImageType, List<ImageData>> images { get; set; }

        public bool OpenBarrier { get; set; }

        public RegisteredVehicle vehicle { get; set; }
        public Customer customer { get; set; }
    }
}
