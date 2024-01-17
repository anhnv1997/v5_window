using System;
namespace EInvoiceManager.Events
{
    public class Events
    {
        public delegate void OnSendEInvoiceComplete(object sender, EInvoiceEventArgs e);
        public class EInvoiceEventArgs : EventArgs
        {
            public bool IsSuccess { get; set; } = false;
            public string CardNumber { get; set; } = string.Empty;
            public string Plate { get; set; } = string.Empty;
            public long Money { get; set; } = 0;
            public string DataSend { get; set; } = string.Empty;
            public string DataReceive { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public DateTime DatetimeIn { get; set; }
            public DateTime DatetimeOut { get; set;}
            public string ReceiveBillCode { get; set; } = string.Empty;
            public string TransactionId { get; set; } = string.Empty;
            public string InvoiceNo { get; set; } = string.Empty;
        }
    }
}
