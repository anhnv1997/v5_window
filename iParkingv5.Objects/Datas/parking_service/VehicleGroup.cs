using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Datas.parking_service
{
    public class VehicleGroup
    {
        public string Id { get; set; }
        public string VehicleGroupId { get; set; }
        public string VehicleGroupCode { get; set; }
        public string VehicleGroupName { get; set; }
        public int? VehicleType { get; set; }
        public int? LimitNumber { get; set; }
        public bool Inactive { get; set; }
        public int SortOrder { get; set; }
    }
}
