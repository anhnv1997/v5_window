using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Invoices
{
    public class InvoiceResponse
    {
        public string id { get; set; }
        public string targetId { get; set; }
        public int targetType { get; set; }
        public string code { get; set; }
        public string reservationCode { get; set; }
        public int provider { get; set; }
        public float amount { get; set; }
        public float taxRate { get; set; }
        public float amountAfterTax { get; set; }
        public bool success { get; set; }
        public bool send { get; set; }
        public int retryAttempt { get; set; }
        public string createdBy { get; set; }
        public string createdUtc { get; set; }
    }
}
