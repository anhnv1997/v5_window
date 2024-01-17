using iParkingv5.Objects.Configs;
using Misa.Object;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static EInvoiceManager.Events.Events;

namespace EInvoiceManager.interfaces
{
    public class MISAEinvoice : BaseEinvoice, iEInvoice
    {
        #region Properties
        private CancellationTokenSource? ctsGetToken;
        #endregion End Properties

        #region Public Function
        public void InitService(EInvoiceConfig config)
        {
            ApiUrlManagement.baseUrl = config.ServerUrl;
            ApiUrlManagement.companyTaxCode = config.TaxCode;
            ApiUrlManagement.username = config.Username;
            ApiUrlManagement.password = config.Password;
            ApiUrlManagement.appId = config.AppId;
            ApiUrlManagement.receiveInvoiceLink = config.BillReceiveLink;
            ApiUrlManagement.ticketTemplateName = config.TicketTemplate;
            ApiUrlManagement.vat_rate = config.VatRate;
            ApiUrlManagement.token = string.Empty;
        }

        public bool Connect()
        {
            string token = string.Empty;
            MisaHelper.GetToken(ApiUrlManagement.appId, ApiUrlManagement.companyTaxCode, ApiUrlManagement.username, ApiUrlManagement.password, ref token);
            if (string.IsNullOrEmpty(token))
            {
                return false;
            }
            ApiUrlManagement.token = token;
            return true;
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
            if (!IsValidTicketTemplateData())
            {
                return;
            }
            CreateMisaInvoiceModel(customerName, cardNumber, cardNo, plateIn, plateOut, money, receiveBillCode,
                                   out string error, out InvoiceBuilder invoiceBuilder, datetimeIn, datetimeOut);

            string apiContent = string.Empty, errorMessage = string.Empty, response = string.Empty;
            bool isPublishSuccess = MisaHelper.PublishInvoice(token: ApiUrlManagement.token,
                                                              companyCode: ApiUrlManagement.companyTaxCode,
                                                              invoiceBuilder: invoiceBuilder,
                                                              errorMessage: ref errorMessage,
                                                              apiContent: ref apiContent,
                                                              result: ref response,
                                                              signType: Em_SignType.HSM);
            EInvoiceEventArgs eInvoiceEventArgs = new EInvoiceEventArgs()
            {
                IsSuccess = isPublishSuccess,
                CardNumber = cardNumber,
                DataReceive = response,
                DataSend = apiContent,
                Money = money,
                Plate = string.IsNullOrEmpty(plateIn) ? plateOut : plateIn,
                Description = errorMessage,
                DatetimeIn = datetimeIn,
                DatetimeOut = datetimeOut,
                ReceiveBillCode = receiveBillCode,
            };
            PublishEInvoiceResult(this, eInvoiceEventArgs);
        }
        #endregion End Public Function

        #region Private Function
        private static void GetTicketTemplateData(string token)
        {
            ListInvoiceTemplateResult templateResult = MisaHelper.GetAllTicket(token, ApiUrlManagement.companyTaxCode);
            if (templateResult.TicketDatas != null)
            {
                ApiUrlManagement.ticketTemplateData = (from TicketTemplateData ticket in templateResult.TicketDatas
                                                       where ticket.InvSeries == ApiUrlManagement.ticketTemplateName
                                                       select ticket).FirstOrDefault();
            }
            else
            {
                ApiUrlManagement.ticketTemplateData = null;
            }
        }
        private static bool IsValidTicketTemplateData()
        {
            if (ApiUrlManagement.ticketTemplateData == null)
            {
                GetTicketTemplateData(ApiUrlManagement.token);
            }
            return ApiUrlManagement.ticketTemplateData != null;
        }
        private static void CreateMisaInvoiceModel(string customerName, string cardNumber, string cardNo, string plateIn, string plateOut,
                                                   long money, string receiveBillCode, out string errorMessage, out InvoiceBuilder invoiceBuilder,
                                                   DateTime datetimeIn, DateTime datetimeOut)
        {
            try
            {
                CustomerInfor customer = new CustomerInfor()
                {
                    BuyerAddress = "",
                    BuyerBankAccount = "",
                    BuyerBankName = "",
                    BuyerCode = receiveBillCode,
                    BuyerEmail = "",
                    BuyerFullName = customerName,
                    BuyerLegalName = "",
                    BuyerPhoneNumber = "",
                    BuyerTaxCode = "",
                    ContactName = "",
                    InvDate = DateTime.Now.Date,
                    InvSeries = ApiUrlManagement.ticketTemplateName,
                };

                InvoiceCurrencyInfor invoiceCurrencyInfor = new InvoiceCurrencyInfor()
                {
                    CurrencyCode = "VND",
                    ExchangeRate = 1,
                    PaymentMethodName = "TM/CK",
                    AmountDecimalDigits = 2,
                    AmountOCDecimalDigits = 2,
                    ClockDecimalDigits = 4,
                    CoefficientDecimalDigits = 2,
                    ExchangRateDecimalDigits = 2,
                    QuantityDecimalDigits = 0,
                    UnitPriceDecimalDigits = 2,
                    UnitPriceOCDecimalDigits = 2
                };

                errorMessage = string.Empty;
                int exchangeRate = 1;

                float vatRate = (float)ApiUrlManagement.vat_rate / 100;

                InvoiceDetailBuilder invoiceDetailBuilder = new InvoiceDetailBuilder();

                invoiceDetailBuilder.ForItem(itemType: Em_ItemType.HHDV, itemCode: "VÉ TRÔNG GIỮ XE", itemName: "VÉ TRÔNG GIỮ XE");

                invoiceDetailBuilder.WithOrderUnit(unitName: "Vé", unitPrice: money, unitCode: "", vatRate: ApiUrlManagement.vat_rate);
                invoiceDetailBuilder.WithQuantity(quantity: 1);
                invoiceDetailBuilder.WithCostAmount(amountOC: invoiceDetailBuilder.originalInvoiceDetail.UnitPrice * invoiceDetailBuilder.originalInvoiceDetail.Quantity,
                                                    amount: invoiceDetailBuilder.originalInvoiceDetail.UnitPrice * invoiceDetailBuilder.originalInvoiceDetail.Quantity * exchangeRate);

                invoiceDetailBuilder.WithDiscount(discountRate: 0, discountAmountOC: 0, discountAmount: 0);

                invoiceDetailBuilder.WithVATInfor(vatRateName: ApiUrlManagement.vat_rate + "%",
                                                  vatAmountOC: invoiceDetailBuilder.originalInvoiceDetail.AmountOC * ApiUrlManagement.vat_rate / 100,
                                                  vatAmount: invoiceDetailBuilder.originalInvoiceDetail.AmountOC * exchangeRate * ApiUrlManagement.vat_rate / 100);

                invoiceBuilder = new InvoiceBuilder();
                invoiceBuilder.WithInvoiceDetail(invoiceDetailBuilder);
                invoiceBuilder.WithParkingDetail(cardNumber, cardNo, plateOut, datetimeIn, datetimeOut);
                invoiceBuilder.WithCustomerInfor(customer);
                invoiceBuilder.WithInvoiceTicket(ApiUrlManagement.ticketTemplateData!);
                invoiceBuilder.WithCurrenceInfor(invoiceCurrencyInfor);
                invoiceBuilder.SyntheticTaxInfor();
                invoiceBuilder.WithReferenceType();
                invoiceBuilder.CalculateCost();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                invoiceBuilder = null;
            }
        }
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
