using iParkingv6.Objects.Datas;
using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Datas
{
    public class IdentityGroupLaneMap
    {
        public int Id { get; set; }
        public Guid LaneId { get; set; }
        public Guid IdentityGroupId { get; set; }

        public Lane Lane { get; set; }
        public IdentityGroup IdentityGroup { get; set; }

        public IdentityGroupLaneMap(Guid identityGroupId, Guid laneId)
        {
            IdentityGroupId = identityGroupId;
            LaneId = laneId;
        }
    }
}
