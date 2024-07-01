using System;
using System.Collections.Generic;
using System.Linq;
using iParkingv5.Objects.Enums;
using static iParkingv5.Objects.Enums.VehicleType;

namespace iParkingv5.Objects.Datas
{
    public enum EmPlateCompareRule
    {
        Exactly,
        Same,
        UnCheck,
    }
    public class IdentityGroup
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public IdentityGroupType Type { get; set; }
        public VehicleBaseType VehicleType { get; set; }
        public int PlateNumberValidation { get; set; }
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
}

