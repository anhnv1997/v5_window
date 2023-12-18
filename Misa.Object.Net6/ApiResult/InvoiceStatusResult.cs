using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Object
{
    /// <summary>
    /// Kết quả trả về: Trạng thái phát hành hóa đơn
    /// </summary>
    public class ListInvoiceStatusResult : OperationResult
    {
        /// <summary>
        /// Trạng thái phát hành hóa đơn
        /// </summary>
        public List<InvoiceStatus> lstInvoiceStatus { get; set; }
    }
}
