using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Object
{
    /// <summary>
    /// Quy trình xây dựng thông tin 1 hóa đơn trước khi phát hành <b/>
    /// <list type="bullet|number|table">
    /// 
    /// <item>
    /// <term>Bước 1: Thiết lập thông tin hóa đơn chi tiết</term>
    /// <description><see cref="WithInvoiceDetail(InvoiceDetailBuilder)"/></description>
    /// </item>
    /// 
    /// <item>
    /// <term>Bước 2: Khởi tạo thông tin khách hàng</term>
    /// <description><see cref="WithCustomerInfor(CustomerInfor)"/></description>
    /// </item>
    /// 
    /// <item>
    /// <term>Bước 3: Khởi tạo thông tin mẫu hóa đơn</term>
    /// <description><see cref="WithInvoiceTemplate(TemplateData)"/></description>
    /// </item>
    /// 
    /// 
    /// <item>
    /// <term>Bước 4: Khởi tạo thông tin loại tiền sử dụng</term>
    /// <description><see cref="WithCurrenceInfor(InvoiceCurrencyInfor)"/></description>
    /// </item>
    /// 
    /// <item>
    /// <term>Bước 5: Khởi tạo thông tin TAX</term>
    /// <description><see cref="SyntheticTaxInfor"/></description>
    /// </item>
    /// 
    /// <item>
    /// <term>Bước 6: Khởi tạo thông tin loại hóa đơn</term>
    /// <description><see cref="WithReferenceType(Em_InvoiceReferenceType, OrgInvoiceInfor?)"/></description>
    /// </item>
    /// 
    /// <item>
    /// <term>Bước 7: Tính tiền</term>
    /// <description><see cref="CalculateCost"/></description>
    /// </item>
    /// 
    /// </list>
    /// </summary>
    public class InvoiceBuilder
    {
        public OriginalInvoiceData invoiceData = new OriginalInvoiceData();
        public InvoiceBuilder()
        {
            this.invoiceData = new OriginalInvoiceData();
            this.invoiceData.RefID = Guid.NewGuid().ToString();
            this.invoiceData.CustomField1 = "trường mở rộng 1";
            this.invoiceData.CustomField2 = "trường mở rộng 2";
        }

        public InvoiceBuilder WithInvoiceDetail(InvoiceDetailBuilder detailBuilder)
        {
            this.invoiceData.OriginalInvoiceDetail = new List<OriginalInvoiceDetail>()
            {
                detailBuilder.originalInvoiceDetail,
            };
            return this;
        }

        public InvoiceBuilder WithParkingDetail(string cardNumber, string cardNo, string plateNumber, DateTime dateTimeIn, DateTime dateTimeOut)
        {
            invoiceData.CustomField1 = cardNumber;
            invoiceData.CustomField2 = cardNo;
            invoiceData.CustomField3 = plateNumber;
            invoiceData.CustomField4 = dateTimeIn.ToString("HH:mm:ss dd/MM/yyyy");
            invoiceData.CustomField5 = dateTimeOut.ToString("HH:mm:ss dd/MM/yyyy");
            invoiceData.CustomField6 = (dateTimeOut - dateTimeIn).TotalMinutes + "phút";
            return this;
        }


        /// <summary>
        /// Khởi tạo thông tin mẫu hóa đơn sử dụng
        /// </summary>
        /// <param name="templateData"></param>
        /// <returns></returns>
        public InvoiceBuilder WithInvoiceTemplate(TemplateData templateData)
        {
            this.invoiceData.InvoiceName = templateData.TemplateName;
            this.invoiceData.InvSeries = templateData.InvSeries;
            return this;
        }
        public InvoiceBuilder WithInvoiceTicket(TicketTemplateData templateData)
        {
            this.invoiceData.InvoiceName = templateData.TemplateName;
            this.invoiceData.InvSeries = templateData.InvSeries;
            return this;
        }

        /// <summary>
        /// Khởi tạo thông tin khách hàng
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public InvoiceBuilder WithCustomerInfor(CustomerInfor customer)
        {
            this.invoiceData.BuyerAddress = customer.BuyerAddress;
            this.invoiceData.BuyerBankAccount = customer.BuyerBankAccount;
            this.invoiceData.BuyerBankName = customer.BuyerBankName;
            this.invoiceData.BuyerCode = customer.BuyerCode;
            this.invoiceData.BuyerEmail = customer.BuyerEmail;
            this.invoiceData.BuyerFullName = customer.BuyerFullName;
            this.invoiceData.BuyerLegalName = customer.BuyerLegalName;
            this.invoiceData.BuyerPhoneNumber = customer.BuyerPhoneNumber;
            this.invoiceData.BuyerTaxCode = customer.BuyerTaxCode;
            this.invoiceData.ContactName = customer.ContactName;
            this.invoiceData.InvDate = customer.InvDate;
            return this;
        }

        /// <summary>
        /// Khởi tạo thông tin loại tiền được sử dụng
        /// </summary>
        /// <param name="invoiceCurrencyInfor"></param>
        /// <returns></returns>
        public InvoiceBuilder WithCurrenceInfor(InvoiceCurrencyInfor invoiceCurrencyInfor)
        {
            this.invoiceData.CurrencyCode = "VND";
            this.invoiceData.PaymentMethodName = "TM/CK";
            this.invoiceData.ExchangeRate = 1;
            this.invoiceData.OptionUserDefined = new OptionUserDefined()
            {
                MainCurrency = invoiceCurrencyInfor.CurrencyCode,
                AmountDecimalDigits = invoiceCurrencyInfor.AmountDecimalDigits.ToString(),
                AmountOCDecimalDigits = invoiceCurrencyInfor.AmountOCDecimalDigits.ToString(),
                ClockDecimalDigits = invoiceCurrencyInfor.ClockDecimalDigits.ToString(),
                CoefficientDecimalDigits = invoiceCurrencyInfor.CoefficientDecimalDigits.ToString(),
                ExchangRateDecimalDigits = invoiceCurrencyInfor.ExchangRateDecimalDigits.ToString(),
                QuantityDecimalDigits = invoiceCurrencyInfor.QuantityDecimalDigits.ToString(),
                UnitPriceDecimalDigits = invoiceCurrencyInfor.UnitPriceDecimalDigits.ToString(),
                UnitPriceOCDecimalDigits = invoiceCurrencyInfor.UnitPriceOCDecimalDigits.ToString(),
            };
            return this;
        }

        /// <summary>
        /// Gọi hàm này sau khi đã set xong thông tin Invoice Detail <see cref="WithInvoiceTemplate(TemplateData)"/>
        /// </summary>
        /// <returns></returns>
        public InvoiceBuilder SyntheticTaxInfor()
        {
            var taxRateInfos = new List<TaxRateInfo>();
            foreach (var item in this.invoiceData.OriginalInvoiceDetail)
            {
                if (!string.IsNullOrEmpty(item.VATRateName) && taxRateInfos.FirstOrDefault(t => t.VATRateName.Equals(item.VATRateName)) == null)
                {
                    var taxRate = new TaxRateInfo()
                    {
                        VATRateName = item.VATRateName,
                        VATAmountOC = Math.Round(this.invoiceData.OriginalInvoiceDetail.Sum(t => t.VATRateName == item.VATRateName ? t.VATAmountOC ?? 0 : 0), 2),
                        AmountWithoutVATOC = this.invoiceData.OriginalInvoiceDetail.Sum(t => t.VATRateName == item.VATRateName ? t.AmountWithoutVATOC ?? 0 : 0)
                    };
                    taxRateInfos.Add(taxRate);
                }
            }
            this.invoiceData.TaxRateInfo = taxRateInfos;
            return this;
        }

        /// <summary>
        /// Set loại hóa đơn sử dụng, sử dụng hàm này sau khi set mẫu hóa đơn <see cref="WithInvoiceTemplate(TemplateData)"/>
        /// </summary>
        /// <param name="invoiceReferenceType"></param>
        /// <param name="orgInvoiceInfor"></param>
        /// <returns></returns>
        public InvoiceBuilder WithReferenceType(Em_InvoiceReferenceType invoiceReferenceType = Em_InvoiceReferenceType.Original, OrgInvoiceInfor orgInvoiceInfor = null)
        {
            if (invoiceReferenceType == Em_InvoiceReferenceType.Replacement || invoiceReferenceType == Em_InvoiceReferenceType.Adjustment)
            {
                invoiceData.ReferenceType = (int?)invoiceReferenceType;
                invoiceData.OrgInvoiceType = 1;
                invoiceData.OrgInvTemplateNo = invoiceData.InvSeries.Substring(0, 1);
                invoiceData.OrgInvSeries = invoiceData.InvSeries.Substring(1);
                invoiceData.OrgInvNo = orgInvoiceInfor?.OrgInvNo;
                invoiceData.OrgInvDate = orgInvoiceInfor?.OrgInvDate;
            }
            return this;
        }

        /// <summary>
        /// Gọi hàm này sau khi đã set xong thông tin Invoice Detail <see cref="WithInvoiceTemplate(TemplateData)"/> và ReferenceType <see cref="WithReferenceType(Em_InvoiceReferenceType, OrgInvoiceInfor?)"/>
        /// </summary>
        /// <returns></returns>
        public InvoiceBuilder CalculateCost()
        {
            string beforeWordAmount = "";
            string beforeWordAmountEND = "";
            string sayMoneyENG = "dong";
            this.invoiceData.TotalSaleAmountOC = this.invoiceData.OriginalInvoiceDetail.Sum(t => t.AmountOC);
            this.invoiceData.TotalSaleAmount = this.invoiceData.OriginalInvoiceDetail.Sum(t => t.Amount);
            this.invoiceData.TotalDiscountAmountOC = this.invoiceData.OriginalInvoiceDetail.Sum(t => t.DiscountAmountOC ?? 0);
            this.invoiceData.TotalDiscountAmount = this.invoiceData.OriginalInvoiceDetail.Sum(t => t.DiscountAmount ?? 0);
            this.invoiceData.TotalVATAmountOC = this.invoiceData.OriginalInvoiceDetail.Sum(t => t.VATAmountOC ?? 0);
            this.invoiceData.TotalVATAmount = this.invoiceData.OriginalInvoiceDetail.Sum(t => t.VATAmount ?? 0);
            this.invoiceData.TotalAmountWithoutVATOC = this.invoiceData.OriginalInvoiceDetail.Sum(t => t.AmountWithoutVATOC);
            this.invoiceData.TotalAmountWithoutVAT = this.invoiceData.OriginalInvoiceDetail.Sum(t => t.Amount ?? 0 - t.DiscountAmount);
            this.invoiceData.TotalAmountOC = Math.Round((decimal)this.invoiceData.OriginalInvoiceDetail.Sum(t => t.AmountOC - t.DiscountAmountOC + t.VATAmountOC), 0);
            this.invoiceData.TotalAmount = Math.Round((decimal)this.invoiceData.OriginalInvoiceDetail.Sum(t => t.Amount - t.DiscountAmount + t.VATAmount), 0);

            this.invoiceData.TotalAmountInWords = SayMoney.MISASaysMoney.MISASayMoney(this.invoiceData.TotalAmountOC ?? 0, sCurrencyID: this.invoiceData.CurrencyCode, beforeWordAmount: beforeWordAmount);
            this.invoiceData.TotalAmountInWordsVN = SayMoney.MISASaysMoney.MISASayMoney(this.invoiceData.TotalAmountOC ?? 0, sCurrencyID: this.invoiceData.CurrencyCode, beforeWordAmount: beforeWordAmount);
            this.invoiceData.TotalAmountInWordsByENG = SayMoney.MISASaysMoney.MISASayMoney(this.invoiceData.TotalAmountOC ?? 0, sLanguageID: "ENG", sCurrencyID: this.invoiceData.CurrencyCode, beforeWordAmount: beforeWordAmountEND, afterWordAmount: sayMoneyENG);

            return this;
        }
    }
}
