using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Datas.payment_service
{
    public class ChargeDetail
    {
        public int Day { get; set; }
        public long DayAmount { get; set; }
        public int Night { get; set; }
        public long NightAmount { get; set; }
        public long FullDayAmount { get; set; }
        public long Amount { get; set; }
        public long DayPrice { get; set; }
        public long NightPrice { get; set; }
        public long FullDayPrice { get; set; }
    }
}
