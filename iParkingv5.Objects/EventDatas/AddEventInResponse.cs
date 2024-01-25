using iParkingv5.Objects.Datas;
using iParkingv6.Objects.Datas;
using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.EventDatas
{
    public class AddEventInResponse
    {
        public string Id { get; set; }
        public string IdentityId { get; set; }
        public string LaneId { get; set; }
        public string PlateNumber { get; set; }
        public bool OpenBarrier { get; set; }
        public RegisteredVehicle registeredVehicle { get; set; }
        public Customer customer { get; set; }
    }
}
