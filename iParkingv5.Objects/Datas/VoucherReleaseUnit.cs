using iParkingv6.Objects.Datas;
using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Datas
{
    public class VoucherReleaseUnit : ObjectBase
    {
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string User { get; set; }
        public bool InActive { get; set; }
        public bool IsDelete { get; set; }
        public string Description { get; set; }
    }
}
