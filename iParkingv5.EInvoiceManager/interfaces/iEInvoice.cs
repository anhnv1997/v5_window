using iParkingv5.Objects.Configs;
using System;
using static EInvoiceManager.Events.Events;

namespace EInvoiceManager.interfaces
{
    public interface iEInvoice
    {
        event OnSendEInvoiceComplete onSendEInvoiceComplete;
        void InitService(EInvoiceConfig config);
        bool Connect();
        void PollingStart();
        void PollingStop();
        void SendEInvoice(string customerName, string cardNumber, string cardNo, string plateIn, string plateOut,
                                  long money, string receiveBillCode, DateTime datetimeIn, DateTime datetimeOut, string receiveUrl = "");
    }
}
