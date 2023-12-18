using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Object
{
    /// <summary>
    /// Khởi tạo thông tin chi tiết cho hóa đơn
    /// <list type="bullet|number|table">
    /// 
    /// <item>
    /// <term>Bước 1: Thiết lập thông tin mặt hàng</term>
    /// <description><see cref="ForItem(Em_ItemType, string, string)"/></description>
    /// </item>
    /// 
    /// <item>
    /// <term>Bước 2: Khởi tạo đơn vị mua hàng</term>
    /// <description><see cref="WithOrderUnit(string, string, decimal?)"/></description>
    /// </item>
    /// 
    /// <item>
    /// <term>Bước 3: Khởi tạo số lượng hàng</term>
    /// <description><see cref="WithQuantity(int)"/></description>
    /// </item>
    /// 
    /// 
    /// <item>
    /// <term>Bước 4: Tính thành tiền</term>
    /// <description><see cref="WithCostAmount(decimal?, decimal?)"/></description>
    /// </item>
    /// 
    /// <item>
    /// <term>Bước 5: Khởi tạo thông tin discount</term>
    /// <description><see cref="WithDiscount(decimal?, decimal?, decimal?)"/></description>
    /// </item>
    /// 
    /// <item>
    /// <term>Bước 6: Khởi tạo thông tin VAT</term>
    /// <description><see cref="WithVATInfor(string, decimal, decimal?)"/></description>
    /// </item>
    /// 
    /// </list>
    /// </summary>
    public class InvoiceDetailBuilder
    {
        public OriginalInvoiceDetail originalInvoiceDetail = new OriginalInvoiceDetail();
        public InvoiceDetailBuilder()
        {
            originalInvoiceDetail = new OriginalInvoiceDetail();
            this.originalInvoiceDetail.LineNumber = 1;
            this.originalInvoiceDetail.SortOrder = 1;
        }

        /// <summary>
        /// Mặt hàng
        /// </summary>
        /// <param name="itemType"></param>
        /// <param name="itemCode"></param>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public InvoiceDetailBuilder ForItem(Em_ItemType itemType, string itemCode, string itemName)
        {
            this.originalInvoiceDetail.ItemType = (int)itemType;
            this.originalInvoiceDetail.ItemCode = itemCode;
            this.originalInvoiceDetail.ItemName = itemName;
            return this;
        }

        /// <summary>
        /// Đơn vị mua hàng
        /// </summary>
        /// <param name="unitName"></param>
        /// <param name="unitCode"></param>
        /// <param name="unitPrice"></param>
        /// <returns></returns>
        public InvoiceDetailBuilder WithOrderUnit(string unitName, string unitCode, decimal? unitPrice, int vatRate)
        {
            this.originalInvoiceDetail.UnitName = unitName;
            this.originalInvoiceDetail.UnitCode = unitCode;
            decimal? value = unitPrice * 100 / (100 + vatRate);
            this.originalInvoiceDetail.UnitPrice = Math.Round((decimal)value, 2);
            return this;
        }

        /// <summary>
        /// Số lượng hàng
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public InvoiceDetailBuilder WithQuantity(int quantity)
        {
            this.originalInvoiceDetail.Quantity = quantity;
            return this;
        }

        /// <summary>
        /// Thành tiền
        /// </summary>
        /// <param name="amountOC"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public InvoiceDetailBuilder WithCostAmount(decimal? amountOC , decimal? amount)
        {
            this.originalInvoiceDetail.Amount = amount;
            this.originalInvoiceDetail.AmountOC = amountOC;
            return this;
        }

        /// <summary>
        /// Thông tin Discount
        /// </summary>
        /// <param name="discountRate"></param>
        /// <param name="discountAmountOC"></param>
        /// <param name="discountAmount"></param>
        /// <returns></returns>
        public InvoiceDetailBuilder WithDiscount(decimal? discountRate, decimal? discountAmountOC, decimal? discountAmount)
        {
            this.originalInvoiceDetail.DiscountRate = discountRate;
            this.originalInvoiceDetail.DiscountAmountOC = discountAmountOC;
            this.originalInvoiceDetail.DiscountAmount = discountAmount;
            return this;
        }

        /// <summary>
        /// Thông tin VAT
        /// </summary>
        /// <param name="vatRateName"></param>
        /// <param name="vatAmountOC"></param>
        /// <param name="vatAmount"></param>
        /// <returns></returns>
        public InvoiceDetailBuilder WithVATInfor(string vatRateName, decimal? vatAmountOC, decimal? vatAmount)
        {
            this.originalInvoiceDetail.VATRateName = vatRateName;
            this.originalInvoiceDetail.VATAmountOC = Math.Round((decimal)vatAmountOC,2);
            this.originalInvoiceDetail.VATAmount = Math.Round((decimal)vatAmount, 2); ;
            this.originalInvoiceDetail.AmountWithoutVATOC = this.originalInvoiceDetail.AmountOC - this.originalInvoiceDetail.DiscountAmountOC;
            return this;
        }
    }
}
