using iParkingv6.Objects.Datas;
using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Datas
{
    public class RoleIdentityGroupMap
    {
        public int Id { get; set; }
        public Guid RoleId { get; set; }
        public Guid IdentityGroupId { get; set; }

        public Role Role { get; set; }
        public IdentityGroup IdentityGroup { get; set; }

        public RoleIdentityGroupMap(Guid roleId, Guid identityGroupId)
        {
            RoleId = roleId;
            IdentityGroupId = identityGroupId;
        }
    }
}
