using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Datas.payment_service
{
    public class VoucherTypeBaseInfo : BaseVoucherObject
    {
        public int Type { get; set; }
        public float ReduceAmount { get; set; }
    }

    /// <summary>
    /// Đối tượng loại VoucherType giảm giá của hệ thống
    /// </summary>
    public class VoucherType : VoucherTypeBaseInfo
    {
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string User { get; set; }
        public bool InActive { get; set; }
        public bool IsDelete { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public bool UseOnlyOnePerEvent { get; set; }
        public bool UseWithinDayOnly { get; set; }
    }
}
