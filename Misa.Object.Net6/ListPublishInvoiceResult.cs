using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Object
{
    /// <summary>
    /// Kết quả trả về khi phát hành hóa đơn
    /// </summary>
    public class ListPublishInvoiceResult : OperationResult
    {
        /// <summary>
        /// Danh sách kết quả phát hành hóa đơn
        /// </summary>
        public System.Collections.Generic.List<PublishInvoice> PublishInvoices { get; set; }
    }

    /// <summary>
    /// Kết quả phát hành hóa đơn
    /// </summary>
    public class PublishInvoice
    {
        /// <summary>
        /// ID của hóa đơn gốc
        /// </summary>
        public string RefID { get; set; }

        /// <summary>
        /// TransactionID
        /// </summary>
        public string TransactionID { get; set; }

        /// <summary>
        /// Mẫu số hóa đơn
        /// </summary>
        public string InvTemplateNo { get; set; }

        /// <summary>
        /// Ký hiệu hóa đơn
        /// </summary>
        public string InvSeries { get; set; }

        /// <summary>
        /// Số hóa đơn
        /// </summary>
        public string InvNo { get; set; }

        /// <summary>
        /// Ngày hóa đơn
        /// </summary>
        public System.DateTime InvDate { get; set; }

        /// <summary>
        /// Mã lỗi
        /// </summary>
        public string ErrorCode { get; set; }
    }
}