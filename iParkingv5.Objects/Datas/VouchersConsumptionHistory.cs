using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Datas
{
    public class VouchersConsumptionHistory : VouchersAvailable
    {
        public DateTime DateReleased { get; set; }
        public string Note { get; set; }
        public string Consumer { get; set; }

        public int Type { get; set; } = 0;

       public string ConsumerName { get; set; }
       public string TypeName { get; set; }

        //public static VouchersConsumptionHistory FromVouchersAvailable(VouchersAvailable vouchers)
        //{
        //    var obj = vouchers.TypeCastByJson<VouchersConsumptionHistory>();
        //    obj.DateReleased = obj.DateCreated;
        //    obj.DateCreated = DateTime.Now;
        //    obj.User = vouchers.User;
        //    obj.GroupId = vouchers.GroupId;
        //    obj.Description = vouchers.Description;
        //    return obj;
        //}
    }
}
