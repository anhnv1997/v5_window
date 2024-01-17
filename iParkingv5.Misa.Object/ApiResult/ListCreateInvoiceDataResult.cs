using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Object
{
    public class ListCreateInvoiceDataResult : OperationResult
    {
        /// <summary>
        /// Danh sách hóa đơn đã khởi tạo XML
        /// </summary>
        public List<CreateInvoiceData> CreateInvoiceDatas { get; set; } = new List<CreateInvoiceData>();
    }

    /// <summary>
    /// Kết quả hàm tạo hóa đơn - tạo XML
    /// </summary>
    public class CreateInvoiceData
    {
        /// <summary>
        /// ID của hóa đơn gốc
        /// </summary>
        public string RefID { get; set; } = string.Empty;

        /// <summary>
        /// Mã tra cứu hóa đơn
        /// </summary>
        public string TransactionID { get; set; } = string.Empty;

        /// <summary>
        /// Số hóa đơn
        /// </summary>
        public string InvNo { get; set; } = string.Empty;
      
        /// <summary>
        /// Ngày hóa đơn
        /// </summary>
        public System.DateTime InvDate { get; set; }

        /// <summary>
        /// Thông tin hóa đơn dạng XML
        /// </summary>
        public string InvoiceData { get; set; } = string.Empty;

        /// <summary>
        /// Mã lỗi
        /// </summary>
        public string ErrorCode { get; set; } = string.Empty;
    }
}
