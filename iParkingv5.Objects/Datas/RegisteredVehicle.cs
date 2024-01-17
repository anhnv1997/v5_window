using iParkingv5.Objects.Enums;
using iParkingv6.Objects.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iParkingv5.Objects.Datas
{
    public class RegisteredVehicle
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PlateNumber { get; set; }
        public int VehicleTypeId { get; set; }
        public string CustomerId { get; set; }
        public string ExpireUtc { get; set; }

        /// <summary>
        /// Ngày kích hoạt/cấp thẻ cho khách hàng
        /// </summary>
        public string LastActivatedUtc { get; set; }

        /// <summary>
        /// Điều xiện xác thực
        /// Ex: PlateNumber && Card || QrCode
        /// </summary>
        public string ValidationCondition { get; set; }

        public bool Enabled { get; set; }
        public bool Deleted { get; set; }
        public string CreatedUtc { get; set; }
        public Guid CreatedBy { get; set; }
        public string UpdatedUtc { get; set; }
        public Guid? UpdatedBy { get; set; }

        public VehicleType VehicleType { get; set; }
        public Customer Customer { get; set; }

        public ICollection<RegisteredVehicleIdentityMap> RegisteredVehicleIdentityMaps { get; set; }

        public RegisteredVehicle()
        {
            RegisteredVehicleIdentityMaps = new List<RegisteredVehicleIdentityMap>();
        }
    }
}