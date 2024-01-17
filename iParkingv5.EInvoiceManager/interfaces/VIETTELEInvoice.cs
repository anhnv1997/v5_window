using iParkingv5.Objects;
using iParkingv5.Objects.Configs;
using Kztek.Tools;
using Misa.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Viettel.Object;
using static EInvoiceManager.Events.Events;

namespace EInvoiceManager.interfaces
{
    public class VIETTELEInvoice : BaseEinvoice, iEInvoice
    {
        #region Properties
        private CancellationTokenSource? ctsGetToken;
        #endregion End Properties

        #region Public Function
        public void InitService(EInvoiceConfig config)
        {
            Viettel.Object.ViettelInvoiceHelper.server = config.ServerUrl;
            Viettel.Object.ViettelInvoiceHelper.companyTaxCode = config.TaxCode;
            Viettel.Object.ViettelInvoiceHelper.username = config.Username;
            Viettel.Object.ViettelInvoiceHelper.password = config.Password;
            Viettel.Object.ViettelInvoiceHelper.Mau = config.TicketTemplate;
            Viettel.Object.ViettelInvoiceHelper.KyHieuHoaDon = config.TicketSerie;
            Viettel.Object.ViettelInvoiceHelper.taxPercent = config.VatRate;
            Viettel.Object.ViettelInvoiceHelper.createInvoieAction = $"/services/einvoiceapplication/api/InvoiceAPI/InvoiceWS/createInvoice/{Viettel.Object.ViettelInvoiceHelper.companyTaxCode}";
        }

        public bool Connect()
        {
            return !string.IsNullOrEmpty(ViettelInvoiceHelper.GetToken().Result);
        }

        public void PollingStart()
        {
            ctsGetToken = new CancellationTokenSource();
            Task.Run(() =>
             AutoGetToken(ctsGetToken.Token), ctsGetToken.Token
            );
        }
        public void PollingStop()
        {
            ctsGetToken?.Cancel();
        }

        public void SendEInvoice(string customerName, string cardNumber, string cardNo, string plateIn,
                                 string plateOut, long money, string receiveBillCode, DateTime datetimeIn, DateTime datetimeOut, string receiveUrl = "")
        {
            string transactionUID = Guid.NewGuid().ToString();
            ViettelInvoiceResult response = ViettelInvoiceHelper.CreateInvoice(ViettelInvoiceHelper.token, money, ViettelInvoiceHelper.taxPercent,
                                                        string.IsNullOrEmpty(plateOut) ? plateIn : plateOut, datetimeIn, datetimeOut, transactionUID).Result;
            EInvoiceEventArgs eInvoiceEventArgs = new EInvoiceEventArgs()
            {
                IsSuccess = response.IsSuccess,
                CardNumber = cardNumber,
                DataReceive = Newtonsoft.Json.JsonConvert.SerializeObject(response.MessageReceived),
                DataSend = response.MessageSend,
                Money = money,
                Plate = string.IsNullOrEmpty(plateIn) ? plateOut : plateIn,
                Description = "",
                DatetimeIn = datetimeIn,
                DatetimeOut = datetimeOut,
            };
            if (response.IsSuccess)
            {
                eInvoiceEventArgs.ReceiveBillCode = response.MessageReceived.result.reservationCode;
                eInvoiceEventArgs.InvoiceNo = response.MessageReceived.result.invoiceNo;
            }
            PublishEInvoiceResult(this, eInvoiceEventArgs);
        }
        #endregion End Public Function

        #region Private Function
        private async Task AutoGetToken(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                Connect();
                await Task.Delay(TimeSpan.FromHours(1));
            }
        }
        #endregion End Private Function
    }
}
