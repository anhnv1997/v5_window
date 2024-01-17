using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv6.Objects.Datas
{
    public class CustomerGroup
    {
        public string Id { get; set; } = string.Empty;
        public string ParentId { get; set; }
        public string CustomerGroupCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Inactive { get; set; }
        public int SortOrder { get; set; }
        public int Ordering { get; set; }
        public string Tax { get; set; }
        public bool IsCompany { get; set; }
    }
}
