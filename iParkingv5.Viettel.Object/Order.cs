using System;
using System.Collections.Generic;
using System.Text;

namespace Viettel.Object
{
    public class Order
    {
        public GeneralInvoiceInfo generalInvoiceInfo { get; set; } = new GeneralInvoiceInfo();
        public BuyerInfo buyerInfo { get; set; } = new BuyerInfo();
        public SellerInfo sellerInfo { get; set; } = new SellerInfo();
        public List<Payments> payments { get; set; } = new List<Payments>();
        public List<ItemInfo> itemInfo { get; set; } = new List<ItemInfo>();
        public List<TaxBreakdowns> taxBreakdowns { get; set; } = new List<TaxBreakdowns>();
        //public List<MetaData> metadata { get; set; } = null;
        //public summarizeInfo summarizeInfo { get; set; } = null;
    }
}
