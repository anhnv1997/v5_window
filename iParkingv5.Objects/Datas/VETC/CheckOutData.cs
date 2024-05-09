using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Datas.VETC
{
    public class CheckOutData
    {
        public string transactionId { get; set; }
        public string transId { get; set; }
        public string plate { get; set; }
        public string registerPlate { get; set; }
        public string laneCardId { get; set; }
        public string status { get; set; }
        public int totalAmount { get; set; }
        public int paidAmount { get; set; }
        public int amount { get; set; }
        public string qrData { get; set; }
        public long createDate { get; set; }
        public int isPaid { get; set; }
        public string paymentMethod { get; set; }
        public List<PaymentHistory> paymentHistory { get; set; }
    }

    public class PaymentHistory
    {
        public string orderId { get; set; }
        public string transactionId { get; set; }
        public int amount { get; set; }
        public string paymentMethod { get; set; }
        public long time { get; set; }
    }
}
