using System;
using System.Collections.Generic;
using System.Text;

namespace Viettel.Object
{
    public class ViettelInvoiceResult
    {
        public bool IsSuccess { get; set; }
        public string MessageSend { get; set; }
        public ViettelInvoiceResponse MessageReceived { get; set; }
    }
    public class ViettelInvoiceResponse
    {
        public int? errorCode { get; set; }
        public string description { get; set; }
        public ViettelInvoiceResponseDetail result { get; set; }

    }
    public class ViettelInvoiceFileResponse
    {
        public int? errorCode { get; set; }
        public string description { get; set; }
        public string fileToBytes { get; set; }
        public string paymentStatus { get; set; }
    }
    public class ViettelInvoiceByTransactionUuid
    {
        public int? errorCode { get; set; }
        public string description { get; set; }
        public string transactionUuid { get; set; }
        public List<ViettelInvoiceByTransactionUuidDetail> result { get; set; }
    }
    public class ViettelInvoiceByTransactionUuidDetail
    {
        public string supplierTaxCode { get; set; }
        public string invoiceNo { get; set; }
        public string reservationCode { get; set; }
        public string issueDate { get; set; }
        public string status { get; set; }
        public string exchangeStatus { get; set; }
        public string codeOfTax { get; set; }
        public string exchangeDes { get; set; }
    }

    public class ViettelInvoiceResponseDetail
    {
        public string supplierTaxCode { get; set; }
        public string invoiceNo { get; set; }
        public string transactionID { get; set; }
        public string reservationCode { get; set; }
    }
}
