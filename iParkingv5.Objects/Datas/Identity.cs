using iParkingv5.Objects.EventDatas;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace iParkingv5.Objects.Datas
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

        public Guid IdentityGroupId { get; set; }
        public IdentityType Type { get; set; }
        public IdentityStatus Status { get; set; }
        public string Note { get; set; }
        public string PlateNumber { get; set; }
        public bool Deleted { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }

        public IdentityGroup IdentityGroup { get; set; }

        public ICollection<RegisteredVehicleIdentityMap> RegisteredVehicleIdentityMaps { get; set; }
        public ICollection<EventIn> EventIns { get; set; }
        public ICollection<EventOut> EventOuts { get; set; }
        public ICollection<AbnormalEvent> AbnormalEvents { get; set; }

        public Identity()
        {
            Id = Guid.NewGuid().ToString();
            RegisteredVehicleIdentityMaps = new List<RegisteredVehicleIdentityMap>();
            EventIns = new List<EventIn>();
            EventOuts = new List<EventOut>();
        }
    }
}