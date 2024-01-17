using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.EventDatas
{
    public class PaymentTransaction
    {
        public Guid Id { get; set; }

        public Guid? EventInId { get; set; }

        public Guid? EventOutId { get; set; }

        public PaymentTransactionMethod Method { get; set; }

        public PaymentTransactionType Type { get; set; }

        /// <summary>
        /// Số tiền cần trả
        /// </summary>
        public long Fee { get; set; }

        /// <summary>
        /// Số tiền giảm nhờ áp dụng voucher
        /// </summary>
        public long Discount { get; set; }

        /// <summary>
        /// Số tiền trả trên giao dịch này
        /// </summary>
        public long Paid { get; set; }

        public string Note { get; set; }
        public string Token { get; set; }
        //public Guid? VoucherConsumptionId { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedUtc { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedUtc { get; set; }
        public Guid? UpdatedBy { get; set; }

        //public VoucherConsumption VoucherConsumption { get; set; }

        public EventIn EventIn { get; set; }

        public EventOut EventOut { get; set; }

        public ParkingEventPaymentMap ParkingEventPaymentTransactionMaps { get; set; }

        public PaymentTransaction()
        {
        }
    }
}