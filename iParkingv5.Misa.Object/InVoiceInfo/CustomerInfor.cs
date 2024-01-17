using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Object
{
    public class CustomerInfor
    {
        public string BuyerAddress { get; set; } = string.Empty;
        public string BuyerBankAccount { get; set; } = string.Empty;
        public string BuyerBankName { get; set; } = string.Empty;
        public string BuyerCode { get; set; } = string.Empty;
        public string BuyerEmail { get; set; } = string.Empty;
        public string BuyerFullName { get; set; } = string.Empty;
        public string BuyerLegalName { get; set; } = string.Empty;
        public string BuyerPhoneNumber { get; set; } = string.Empty;
        public string BuyerTaxCode { get; set; } = string.Empty;
        public string ContactName { get; set; } = string.Empty;
        public DateTime InvDate { get; set; } = DateTime.Now.Date;
        public string InvSeries { get; set; } = string.Empty;
    }
}
