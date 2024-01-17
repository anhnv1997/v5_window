using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Object
{
    public class InvoiceCurrencyInfor
    {
        public string CurrencyCode { get; set; } = "VND";
        public decimal ExchangeRate { get; set; } = 1;
        public string PaymentMethodName { get; set; } = "TM/CK";
        public int AmountDecimalDigits { get; set; } = 2;
        public int AmountOCDecimalDigits { get; set; } = 2;
        public int ClockDecimalDigits { get; set; } = 4;
        public int CoefficientDecimalDigits { get; set; } = 2;
        public int ExchangRateDecimalDigits { get; set; } = 2;
        public int QuantityDecimalDigits { get; set; } = 0;
        public int UnitPriceDecimalDigits { get; set; } = 2;
        public int UnitPriceOCDecimalDigits { get; set; } = 2;
    }
}
