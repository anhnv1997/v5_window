using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv6.Objects.Datas
{
    public class Led
    {
        public string Id { get; set; }
        public string LedName { get; set; }
        public string PcId { get; set; }
        public string Comport { get; set; }
        public int Baudrate { get; set; }

        //public int SideIndex { get; set; }
        //public int Address { get; set; }
        public string LedType { get; set; }
        public bool InActive { get; set; } = false;
        public int RowNumber { get; set; }
    }
}
