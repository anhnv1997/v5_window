using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Reporting
{
    public class Paging
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int totalItem { get; set; }
        public int totalPage { get; set; }
    }
}
