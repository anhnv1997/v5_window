using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Datas.warehouse_service
{
    public class WeighingDetail : WeighingAction
    {
        public List<WeighingActionDetail> weighing_action_detail { get; set; }
    }
}
