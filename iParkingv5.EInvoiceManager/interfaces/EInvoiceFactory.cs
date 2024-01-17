using iParkingv5.Objects.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EInvoiceManager.interfaces
{
    public class EInvoiceFactory
    {
        public static iEInvoice? CreateEInvoiceService(EInvoiceType.EmEinvoiceType type)
        {
            switch (type)
            {
                case EInvoiceType.EmEinvoiceType.Viettel:
                    return new VIETTELEInvoice();
                case EInvoiceType.EmEinvoiceType.Misa:
                    return new MISAEinvoice();
                case EInvoiceType.EmEinvoiceType.ThaiSon:
                    return new THAISONEInvoice();
                default:
                    return null;
            }
        }
    }
}
