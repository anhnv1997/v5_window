using iParkingv5.Objects.Datas.invoice_service;
using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Datas.payment_service
{
    public class PaymentTransaction
    {
        public string targetId { get; set; }
        public InvoiceTargetType targetType { get; set; } = InvoiceTargetType.EventOut;
        public int method { get; set; } = 0;
        public int provider { get; set; } = 0;
        public long amount { get; set; }
        public List<PaymentDetail> details { get; set; }
    }
}
