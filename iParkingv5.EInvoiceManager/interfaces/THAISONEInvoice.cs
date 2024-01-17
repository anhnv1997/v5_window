using iParkingv5.Objects.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EInvoiceManager.Events.Events;

namespace EInvoiceManager.interfaces
{
    public class THAISONEInvoice : BaseEinvoice, iEInvoice
    {
        #region Public Function
        public bool Connect()
        {
            throw new NotImplementedException();
        }

        public void InitService(EInvoiceConfig config)
        {
            throw new NotImplementedException();
        }

        public void PollingStart()
        {
            throw new NotImplementedException();
        }

        public void PollingStop()
        {
            throw new NotImplementedException();
        }

        public void SendEInvoice(string customerName, string cardNumber, string cardNo, string plateIn,
                                 string plateOut, long money, string receiveBillCode, DateTime datetimeIn, DateTime datetimeOut, string receiveUrl = "")
        {
            throw new NotImplementedException();
        }
        #endregion End Public Function
    }
}
