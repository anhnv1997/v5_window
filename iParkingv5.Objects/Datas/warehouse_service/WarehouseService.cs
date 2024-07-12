using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Datas.warehouse_service
{
    public class WarehouseService
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string EventInId { get; set; }
        public string EventOutId { get; set; }
        public string PlateNumber { get; set; }
        public string Description { get; set; }
        public string codeCharacterSequence { get; set; }
        public string codeNumberSequence { get; set; }
        public string paperworkSequence { get; set; }
        public int Type { get; set; }
        public bool PrintPaper { get; set; }
    }
}
