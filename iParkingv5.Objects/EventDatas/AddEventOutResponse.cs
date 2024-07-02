using iParkingv5.Objects.Datas;
using iParkingv6.Objects.Datas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using static iParkingv5.Objects.ApiInternalErrorMessages;

namespace iParkingv5.Objects.EventDatas
{
    public class PaymentDetail
    {
        public Purpose purpose { get; set; }
        public int quantity { get; set; }
        public long price { get; set; }
        public long amount { get; set; }
    }
    public enum Purpose
    {
        ParkingNight,
        ParkingDay,
        ParkingNormalCharge
    }
    public enum TargetType
    {
        EventIn,
        EventOut,
        Vehicle
    }
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
