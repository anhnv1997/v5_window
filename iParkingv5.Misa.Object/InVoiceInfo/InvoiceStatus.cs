using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Object
{
    /// <summary>
    /// Trạng thái phát hành hóa đơn
    /// </summary>
    public class InvoiceStatus
    {
        /// <summary>
        /// Mã tra cứu hóa đơn
        /// </summary>
        public string TransactionID { get; set; }

        /// <summary>
        /// Trạng thái phát hành
        /// Mô tả theo <see cref="Enum.SaveInvoiceSatus"/>
        /// </summary>
        public Em_SaveInvoiceSatus PublishStatus { get; set; }

        /// <summary>
        /// Loại hóa đơn
        /// Mô tả theo <see cref="Enum.InvoiceReferenceType"/>
        /// </summary>
        public Em_InvoiceReferenceType ReferenceType { get; set; }

        /// <summary>
        /// Mã cơ quan thuế cấp - đối với hóa đơn có mã
        /// </summary>
        public string InvoiceCode { get; set; }

        /// <summary>
        /// Trạng thái gửi hóa đơn sang Cơ quan thuế
        ///     - Không có mã: (0: chưa gửi CQT; 1: Đã gửi CQT; 2: CQT tiếp nhận; 3: CQT không tiếp nhận; 4: gửi lỗi)
        ///     - Có mã: (0: chờ cấp mã; 1: gửi lỗi; 2: đã cấp mã; 3: từ chối cấp mã; 4: gửi lỗi)
        /// Mô tả theo <see cref="Enum.SendToTaxStatus"/>
        /// </summary>
        public Em_SendToTaxStatus SendTaxStatus { get; set; }

        /// <summary>
        /// Trạng thái gửi hóa đơn cho khách hàng (0: Chưa gửi; 1: Đã gửi)
        /// </summary>
        public bool IsSentEmail { get; set; }

        /// <summary>
        /// Là hóa đơn bị hủy chưa
        /// </summary>
        public bool IsDelete { get; set; }

        /// <summary>
        /// Ngày hủy hóa đơn
        /// </summary>
        public System.DateTime? DeletedDate { get; set; }

        /// <summary>
        /// Lý do hủy hóa đơn
        /// </summary>
        public string DeletedReason { get; set; }

        /// <summary>
        /// Người mua đã nhận hóa đơn: 0: Chưa nhận được; 1: Đã nhận được
        /// </summary>
        public int ReceivedStatus { get; set; }
    }
}
