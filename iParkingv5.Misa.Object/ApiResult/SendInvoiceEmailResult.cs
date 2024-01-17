using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Object
{
    /// <summary>
    /// Kết quả trả về: Danh sách kết quả gửi email
    /// </summary>
    public class SendInvoiceEmailResult : OperationResult
    {
        /// <summary>
        /// Danh sách kết quả gửi email
        /// </summary>
        public SendInvoiceEmail SendInvoiceEmail { get; set; }
    }

    /// <summary>
    /// Thông tin kết quả gửi email
    /// </summary>
    public class SendInvoiceEmail
    {
        /// <summary>
        /// Mã tra cứu hóa đơn
        /// </summary>
        public string TransactionID { get; set; }

        /// <summary>
        /// Trạng thái gửi email
        /// </summary>
        public Em_SendInvoiceStatus SendEmailStatus { get; set; }

        /// <summary>
        /// Mã lỗi
        /// </summary>
        public string ErrorCode { get; set; }
    }
}