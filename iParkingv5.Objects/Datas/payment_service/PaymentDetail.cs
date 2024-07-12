using iParkingv5.Objects.Enums;
using iParkingv5.Objects.EventDatas;
using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Datas.payment_service
{
    public class PaymentDetail
    {
        public EmPaymentPurpose purpose { get; set; }
        public int quantity { get; set; }
        public long price { get; set; }
        public long amount { get; set; }
    }
}
