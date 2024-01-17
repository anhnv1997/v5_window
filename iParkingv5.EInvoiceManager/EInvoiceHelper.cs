using EInvoiceManager.interfaces;
using iParkingv5.Objects.Configs;
using Misa.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iParkingv5.Objects.Configs.EInvoiceType;

namespace EInvoiceManager
{
    public class EInvoiceHelper
    {
        #region Properties
        public iEInvoice? iEInvoice;
        private EmEinvoiceType invoiceType = EmEinvoiceType.None;
        private EInvoiceConfig invoiceConfig;
        private string receiveUrl = string.Empty;
        #endregion End Properties

        #region Constructor
        public EInvoiceHelper(EmEinvoiceType type, EInvoiceConfig invoiceConfig, string receiveUrl = "")
        {
            this.invoiceType = type;
            this.invoiceConfig = invoiceConfig;
            iEInvoice = EInvoiceFactory.CreateEInvoiceService(type);
            this.receiveUrl = receiveUrl;
        }
        public void InitEinvoiceService()
        {
            iEInvoice?.InitService(this.invoiceConfig);
        }
        #endregion End Constructor

        #region Public Function
        public bool Connect()
        {
            return iEInvoice?.Connect() ?? false;
        }
        public void SendEInvoice(string customerName, string cardNumber, string cardNo, string plateIn,
                                 string plateOut, long money, string receiveBillCode, DateTime datetimeIn, DateTime datetimeOut)
        {
            iEInvoice?.SendEInvoice(customerName, cardNumber, cardNo, plateIn,
                                    plateOut, money, receiveBillCode, datetimeIn, datetimeOut, this.receiveUrl);
        }
        public void PollingStart()
        {
            iEInvoice?.PollingStart();
        }
        public void PollingStop()
        {
            iEInvoice?.PollingStop();
        }
        #endregion End Public Function
    }
}
