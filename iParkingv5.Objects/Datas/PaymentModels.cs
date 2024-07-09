using iParkingv5.Objects.EventDatas;
using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Datas
{
    public class PaymentTransaction
    {
        public string targetId { get; set; }
        public TargetType targetType { get; set; } = TargetType.EventOut;
        public long amount { get; set; }
        public List<PaymentDetail> details { get; set; }
    }
    public enum PaymentTransactionMethod
    {
        CashAtBooth,
        CashAtKiosk,
    }
    public enum PaymentTransactionPurpose
    {
        ParkingCharge,
    }
    public enum TargetType
    {
        EventIn = 0,
        EventOut = 1,
        Vehicle = 2,
        Weghing = 3,
    }
}
