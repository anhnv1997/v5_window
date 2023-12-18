using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Object
{
    /// <summary>
    /// Kết quả trả về: Thông tin tải hóa đơn
    /// </summary>
    public class DownloadInvoiceResult : OperationResult
    {
        /// <summary>
        /// Danh sách thông tin hóa đơn tải về
        /// </summary>
        public List<DownloadInvoice> DownloadInvoices { get; set; } = new List<DownloadInvoice>();
    }

    /// <summary>
    /// Thông tin tải hóa đơn
    /// </summary>
    public class DownloadInvoice
    {
        /// <summary>
        /// TransactionID
        /// </summary>
        public string TransactionID { get; set; } = string.Empty;

        /// <summary>
        /// Dữ liệu hóa đơn.
        /// <para>Khi chọn tải hóa đơn dạng Xml thì dữ liệu trả về sẽ là nội dung Xml</para>
        /// <para>Khi chọn tải hóa đơn dạng Pdf thì dữ liệu trả về sẽ là nội dung Pdf đã được chuyển đổi sang chuỗi base64</para>
        /// </summary>
        public string Data { get; set; } = string.Empty;

        /// <summary>
        /// Mã lỗi
        /// </summary>
        public string ErrorCode { get; set; } = string.Empty;
    }
}
