﻿using iParkingv6.Objects.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iParkingv5.Objects.Enums.LaneDirectionType;

namespace iParkingv5_window.Usercontrols
{
    public static class LaneFactory
    {
        public static iLane CreateLane(Lane lane)
        {
            switch ((EmLaneDirection)(lane.type +1))
            {
                case EmLaneDirection.IN:
                    return new ucLaneIn(lane);
                case EmLaneDirection.OUT:
                    return new ucLaneOut(lane);
                default:
                    throw new Exception("Thông tin làn không hợp lệ, hãy kiểm tra lại thông tin thiết lập!");
            }
        }
    }
}
