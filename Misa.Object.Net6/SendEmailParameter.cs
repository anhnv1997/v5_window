using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Object
{
    /// <summary>
    /// Tham số gửi Email
    /// </summary>
    public class SendEmailParameter
    {
        /// <summary>
        /// Danh sách thông tin gửi email
        /// </summary>
        public List<SendEmailData> SendEmailDatas { get; set; } = new List<SendEmailData>();

        /// <summary>
        /// Hóa đơn có mã hay không
        /// </summary>
        public bool IsInvoiceCode { get; set; }
    }

    /// <summary>
    /// Tham số gửi Email
    /// </summary>
    public class SendEmailData
    {
        /// <summary>
        /// Mã tra cứu
        /// </summary>
        public string TransactionID { get; set; } = string.Empty;

        /// <summary>
        /// Tên người nhận
        /// </summary>
        public string ReceiverName { get; set; } = string.Empty;

        /// <summary>
        /// List Email
        /// </summary>
        public string ReceiverEmail { get; set; } = string.Empty;

        /// <summary>
        /// Email cc
        /// </summary>
        public string CCEmail { get; set; } = string.Empty;

        /// <summary>
        /// Email bcc
        /// </summary>
        public string BCCEmail { get; set; } = string.Empty;

        /// <summary>
        /// Link callback
        /// </summary>
        public string CallbackUrl { get; set; } = string.Empty;

        /// <summary>
        /// địa chỉ email khi reply
        /// </summary>
        public string ReplyEmail { get; set; } = string.Empty;
    }
}