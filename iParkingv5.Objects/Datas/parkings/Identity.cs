using iParkingv5.Objects.EventDatas;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace iParkingv5.Objects.Datas.parking
{
    public enum IdentityStatus
    {
        InUse,
        Locked
    }
    public class Identity
    {
        public string Id { get; set; }

        /// <summary>
        /// Card: CardNo
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Card: Card number
        /// 
        /// </summary>
        public string Code { get; set; }

        public string IdentityGroupId { get; set; }
        public IdentityType Type { get; set; }
        public IdentityStatus Status { get; set; }
        public string Note { get; set; }
        public string PlateNumber { get; set; }
        public bool Deleted { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public List<RegisteredVehicle> Vehicles { get; set; } = new List<RegisteredVehicle>();
    }
}