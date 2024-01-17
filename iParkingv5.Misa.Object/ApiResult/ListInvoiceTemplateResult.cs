using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Object
{
    /// <summary>
    /// Kết quả trả về: Danh sách mẫu hóa đơn
    /// </summary>
    public class ListInvoiceTemplateResult : OperationResult
    {
        /// <summary>
        /// Danh sách mẫu hóa đơn
        /// </summary>
        public List<TemplateData> TemplateDatas { get; set; }

        /// <summary>
        /// Danh sách mẫu hóa đơn
        /// </summary>
        public List<TicketTemplateData> TicketDatas { get; set; }
    }

    /// <summary>
    /// Mẫu hóa đơn
    /// </summary>
    public class TemplateData
    {
        /// <summary>
        /// ID mẫu
        /// </summary>
        public System.Guid IPTemplateID { get; set; }

        /// <summary>
        /// ID công ty
        /// </summary>
        public int CompanyID { get; set; }

        /// <summary>
        /// Tên mẫu
        /// </summary>
        public string TemplateName { get; set; }

        /// <summary>
        /// Mẫu số
        /// </summary>
        public string InvTemplateNo { get; set; }

        /// <summary>
        /// Ký hiệu
        /// </summary>
        public string InvSeries { get; set; }

        /// <summary>
        /// Ký hiệu
        /// </summary>
        public string OrgInvSeries { get; set; }

        /// <summary>
        /// Loại mẫu (stimul, xslt,...)
        /// </summary>
        public int TemplateType { get; set; }

        /// <summary>
        /// Loại hóa đơn (GTGT, bán hàng, xuất kho,...)
        /// </summary>
        public int InvoiceType { get; set; }

        /// <summary>
        /// Nghiệp vụ
        /// </summary>
        public int BusinessAreas { get; set; }

        /// <summary>
        /// Thứ tự
        /// </summary>
        public int SortOrder { get; set; }

        /// <summary>
        /// Ngày ký
        /// </summary>
        public System.DateTime? SignedDate { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public System.DateTime CreatedDate { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày sửa
        /// </summary>
        public System.DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Người sửa
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Ngừng hoạt động
        /// </summary>
        /// <returns></returns>
        public bool Inactive { get; set; }

        /// <summary>
        /// Nội dung file mẫu
        /// </summary>
        public byte[] TemplateContent { get; set; }

        /// <summary>
        /// ID mẫu mặc định
        /// </summary>
        public System.Guid DefaultTemplateID { get; set; }

        /// <summary>
        /// Có phải mẫu custom không
        /// </summary>
        public bool IsCustomTemplate { get; set; }

        /// <summary>
        /// kế thừa từ mẫu cũ hay không
        /// </summary>
        public bool IsInheritFromOldTemplate { get; set; }

        /// <summary>
        /// Phiên bản mẫu xslt
        /// </summary>
        public int? XsltVersion { get; set; }

        /// <summary>
        /// Đã phát hành hđ hay chưa
        /// </summary>
        public bool IsPublished { get; set; }

        /// <summary>
        /// Mẫu gửi bảng tổng hợp
        /// </summary>
        public bool IsSendSummary { get; set; }
    }

    /// <summary>
    /// Mẫu hóa đơn
    /// </summary>
    public class TicketTemplateData
    {
        /// <summary>
        /// ID mẫu
        /// </summary>
        public System.Guid TicketTemplateID { get; set; }

        /// <summary>
        /// ID công ty
        /// </summary>
        public int CompanyID { get; set; }

        /// <summary>
        /// Tên mẫu
        /// </summary>
        public string TemplateName { get; set; } = string.Empty;

        /// <summary>
        /// Mẫu số
        /// </summary>
        public string InvTemplateNo { get; set; } = string.Empty;

        /// <summary>
        /// Ký hiệu
        /// </summary>
        public string InvSeries { get; set; } = string.Empty;

        /// <summary>
        /// Ký hiệu
        /// </summary>
        public string OrgInvSeries { get; set; }

        /// <summary>
        /// Loại vé (0: giải trí; 1: công ích; 2: vận tải)
        /// </summary>
        public int TicketType { get; set; }

        /// <summary>
        /// Phương pháp kê khai (0: khấu trừ; 1: trực tiếp)
        /// </summary>
        public int DeclarationtType { get; set; }

        /// <summary>
        /// Loại vé (0: in sẵn mệnh giá; 1: không in sẵn mệnh giá)
        /// </summary>
        public int TemplateType { get; set; }

        /// <summary>
        /// Các thông tin khác trên vé (lưu dạng json)
        /// </summary>
        public string OtherInfo { get; set; }

        /// <summary>
        /// Các thông tin khác trên vé (lưu dạng json)
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Thứ tự
        /// </summary>
        public int SortOrder { get; set; }

        /// <summary>
        /// Ngừng sử dụng
        /// </summary>
        public bool Inactive { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public System.DateTime CreatedDate { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày sửa
        /// </summary>
        public System.DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Người sửa
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Trạng thái phát hành (0: chưa lập thông báo phát hành; 1: đã lập thông báo; 2: đã có hiệu lực)
        /// </summary>
        public int? PublishedStatus { get; set; }

        /// <summary>
        /// Phiên bản mẫu
        /// </summary>
        public int? TemplateVersion { get; set; }

        /// <summary>
        /// ID mẫu mặc định
        /// </summary>
        public System.Guid DefaultTemplateID { get; set; }

        /// <summary>
        /// Có phải mẫu custom không
        /// </summary>
        public bool IsCustomTemplate { get; set; }

        /// <summary>
        /// Nội dung file mẫu
        /// </summary>
        public byte[] TemplateContent { get; set; }

        /// <summary>
        /// Đã phát hành vé
        /// </summary>
        public bool IsPublishedTicket { get; set; }

        /// <summary>
        /// ID tuyến đường (dùng cho mẫu vận tải)
        /// </summary>
        public System.Guid? RouteID { get; set; }

        /// <summary>
        /// kế thừa từ mẫu cũ hay không
        /// </summary>
        public bool IsInheritFromOldTemplate { get; set; }

        /// <summary>
        /// Mẫu gửi bảng tổng hợp
        /// </summary>
        public bool IsSendSummary { get; set; }
    }
}