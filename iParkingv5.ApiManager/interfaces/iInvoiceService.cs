using iParkingv5.Objects.Datas.invoice_service;
using System;
using System.Collections.Generic;
using System.Text;
using static iParkingv5.ApiManager.KzParkingv5Apis.KzParkingv5ApiHelper;
using System.Threading.Tasks;

namespace iParkingv5.ApiManager.interfaces
{
    public interface iInvoiceService
    {
        #region EInvoice
        Task<InvoiceResponse> CreateEinvoice(long price, string plateNumber, DateTime datetimeIn, DateTime datetimeOut, string eventOutId, bool isSendNow = true, string cardGroupName = "");
        Task<InvoiceFileInfor> GetInvoiceData(string orderId, EmInvoiceProvider provider = EmInvoiceProvider.VIETTEL);
        Task<List<InvoiceResponse>> GetMultipleInvoiceData(DateTime startTime, DateTime endTime, EmInvoiceProvider provider = EmInvoiceProvider.VIETTEL);
        Task<List<InvoiceResponse>> getPendingEInvoice(DateTime startTime, DateTime endTime);
        Task<bool> sendPendingEInvoice(string orderId);
        #endregion End Einvoice
    }
}
