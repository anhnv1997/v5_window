using System;
using System.Collections.Generic;
using System.Linq;
using iParkingv5.Objects.Enums;

namespace iParkingv5.Objects.Datas
{
    public class IdentityGroup
    {
        public int plateCompareLevel { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public IdentityGroupType Type { get; set; }
        public int VehicleTypeId { get; set; }

        /// <summary>
        /// Json: Array objects { minutes: int, fee: decimal }
        /// </summary>
        public List<FeeConfiguration> FeeConfiguration { get; set; }
        public int FreeWithinMinutes { get; set; }
        public bool Enabled { get; set; }
        public bool Deleted { get; set; }
        public VehicleType VehicleType { get; set; }
        public ICollection<Identity> Identities { get; set; }
        public ICollection<IdentityGroupLaneMap> IdentityGroupLaneMaps { get; set; }
        public ICollection<RoleIdentityGroupMap> RoleIdentityGroupMaps { get; set; }

        public List<FeeConfiguration> FeeConfigurations { get; set; }
        public List<Guid> LaneIds
        {
            get => IdentityGroupLaneMaps?.Select(n => n.LaneId).ToList();
            set => IdentityGroupLaneMaps = value?.Select(laneId => new IdentityGroupLaneMap(Id, laneId)).ToList();
        }

        public IdentityGroup()
        {
            Id = Guid.NewGuid();
            Identities = new List<Identity>();
            IdentityGroupLaneMaps = new List<IdentityGroupLaneMap>();
            RoleIdentityGroupMaps = new List<RoleIdentityGroupMap>();
        }

        public static string GetIdentityGroupName(List<IdentityGroup> identityGroups, string identityGroupId)
        {
            if (identityGroups == null)
            {
                return string.Empty;
            }
            if (identityGroups.Count == 0)
            {
                return string.Empty;
            }
            foreach (var item in identityGroups)
            {
                if (item.Id.ToString().ToLower() == identityGroupId.ToLower())
                {
                    return item.Name;
                }
            }
            
            return string.Empty;
        }
    }

    public class FeeConfiguration
    {
        public int Minutes { get; set; }
        public int Fee { get; set; }
    }
}

