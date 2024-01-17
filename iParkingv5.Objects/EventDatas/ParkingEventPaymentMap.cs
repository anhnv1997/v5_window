using System;

namespace iParkingv5.Objects.EventDatas
{
    public class ParkingEventPaymentMap
    {
        public int Id { get; set; }
        public Guid? EventInId { get; set; }
        public Guid? EventOutId { get; set; }
        public Guid PaymentTransactionId { get; set; }

        public EventIn EventIn { get; set; }
        public EventOut EventOut { get; set; }
        public PaymentTransaction PaymentTransaction { get; set; }
    }
}
