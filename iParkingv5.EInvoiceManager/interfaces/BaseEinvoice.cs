using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EInvoiceManager.Events.Events;

namespace EInvoiceManager.interfaces
{
    public class BaseEinvoice
    {
        public event OnSendEInvoiceComplete? onSendEInvoiceComplete;
        public void PublishEInvoiceResult(object sender, EInvoiceEventArgs e)
        {
            onSendEInvoiceComplete?.Invoke(sender, e);
        }
    }
}
