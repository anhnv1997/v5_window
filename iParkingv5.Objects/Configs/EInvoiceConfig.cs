using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iParkingv5.Objects.Configs.EInvoiceType;

namespace iParkingv5.Objects.Configs
{
    public class EInvoiceConfig
    {
        public EmEinvoiceType EInvoiceType { get; set; } = EmEinvoiceType.None;
        public bool IsUseEInvoice { get; set; } = false;
        #region Thông tin server
        public string ServerUrl { get; set; } = string.Empty;
        public string ServerAction { get; set; } = string.Empty;
        public string ServerTemplateFile { get; set; } = string.Empty;
        #endregion Eng thông tin server

        #region Thông tin đơn vị
        public string AppId { get; set; } = string.Empty;
        public string TaxCode { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string TicketTemplate { get; set; } = string.Empty;
        public string TicketSerie { get; set; } = string.Empty;
        public int VatRate { get; set; } = 0;
        public string BillReceiveLink { get; set; } = string.Empty;
        #endregion End Thông tin đơn vị

    }

}
