using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Datas.warehouse_service
{
    public class WarehouseServiceInput
    {
        public int type { get; set; }
        public string plateNumber { get; set; }
        public string eventInId { get; set; }
        public Guid eventOutId { get; set; }
        public string description { get; set; }
        public bool PrintPaper { get; set; }
    }
}
