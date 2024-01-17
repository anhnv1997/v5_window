using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Object
{
    /// <summary>
    /// Kết quả trả về: Thông tin công ty
    /// </summary>
    public class CompanyInfoResult : OperationResult
    {
        /// <summary>
        /// Thông tin công ty
        /// </summary>
        public Company CompanyInfo { get; set; } = new Company();
    }

    /// <summary>
    /// Thông tin công ty
    /// </summary>
    public class Company
    {
        /// <summary>
        /// ID công ty
        /// </summary>
        public int CompanyID { get; set; } = 0;

        /// <summary>
        /// Mã công ty
        /// </summary>
        public string CompanyCode { get; set; } = string.Empty;

        /// <summary>
        /// Tên công ty
        /// </summary>
        public string CompanyName { get; set; } = string.Empty;

        /// <summary>
        /// Mã bảo mật
        /// </summary>
        public string SecureToken { get; set; } = string.Empty;

        /// <summary>
        /// Mã số thuế công ty
        /// </summary>
        public string CompanyTaxCode { get; set; } = string.Empty;

        /// <summary>
        /// Ngưng hoạt dộng
        /// </summary>
        public bool Inactive { get; set; }

        /// <summary>
        /// Địa chỉ công ty
        /// </summary>
        public string CompanyAddress { get; set; } = string.Empty;

        /// <summary>
        /// Tỉnh/ Thành phố
        /// </summary>
        public string CompanyCity { get; set; } = string.Empty;

        /// <summary>
        /// Mã nhân viên MISA
        /// </summary>
        public string MISAEmployeeCode { get; set; } = string.Empty;

        /// <summary>
        /// Đơn vị tích hợp
        /// </summary>
        public int SourceType { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Ngày tích hợp
        /// </summary>
        public DateTime? IntegratedDate { get; set; }

        /// <summary>
        /// Mã số thuế không dấu
        /// </summary>
        public string CompanyTaxCodeWithoutSign { get; set; } = string.Empty;

        /// <summary>
        /// Thông tin người đại diện pháp luật
        /// </summary>
        public string CompanyAgentFollowLaw { get; set; } = string.Empty;

        /// <summary>
        /// ĐT cty
        /// </summary>
        public string CompanyTel { get; set; } = string.Empty;

        /// <summary>
        /// Email cty
        /// </summary>
        public string CompanyEmail { get; set; } = string.Empty;

        /// <summary>
        /// Website
        /// </summary>
        public string CompanyWebsite { get; set; } = string.Empty;

        /// <summary>
        /// Lĩnh vực hoạt động
        /// </summary>
        public string BusinessType { get; set; } = string.Empty;

        /// <summary>
        /// TK Ngân Hàng
        /// </summary>
        public string BankAccount { get; set; } = string.Empty;

        /// <summary>
        /// Ngân hàng
        /// </summary>
        public string BankName { get; set; } = string.Empty;

        /// <summary>
        /// Chi nhánh NH
        /// </summary>
        public string BankBranchName { get; set; } = string.Empty;

        /// <summary>
        /// Cơ quan thuế cấp cục
        /// </summary>
        public string TaxationBureau { get; set; } = string.Empty;

        /// <summary>
        /// CQ thuế quản lý
        /// </summary>
        public string TaxOrganManagement { get; set; } = string.Empty;

        /// <summary>
        /// Mã CQ thuế quản lý
        /// </summary>
        public string TaxOrganManagementCode { get; set; } = string.Empty;

        /// <summary>
        /// Người đại diện pháp luật
        /// </summary>
        public string Director { get; set; } = string.Empty;

        /// <summary>
        /// Fax công ty
        /// </summary>
        public string CompanyFax { get; set; } = string.Empty;

        /// <summary>
        /// nghệ nghiệp lĩnh vực hoạt động của công ty
        /// </summary>
        public string Career { get; set; } = string.Empty;

        /// <summary>
        /// email người đại diện pháp luật
        /// </summary>
        public string LegalepresentationEmail { get; set; } = string.Empty;

        /// <summary>
        /// SĐT người đại diện pháp luật
        /// </summary>
        public string LegalepresentationPhone { get; set; } = string.Empty;

        /// <summary>
        /// Thông tư áp dụng
        /// </summary>
        public string CircularFollow { get; set; } = string.Empty;

        /// <summary>
        /// True: sử dụng HĐ có mã
        /// </summary>
        public bool IsInvoiceWithCode { get; set; }

        /// <summary>
        /// Sử dụng vé
        /// </summary>
        public bool IsUsingTicket { get; set; }

        /// <summary>
        /// Người liên hệ
        /// </summary>
        public string ContactName { get; set; } = string.Empty;

        /// <summary>
        /// Địa chỉ liên hệ
        /// </summary>
        public string ContactAddress { get; set; } = string.Empty;

        /// <summary>
        /// Email liên hệ
        /// </summary>
        public string ContactEmail { get; set; } = string.Empty;

        /// <summary>
        /// Điện thoại liên hệ
        /// </summary>
        public string ContactMobile { get; set; } = string.Empty;

        /// <summary>
        /// Có tờ khai được chấp nhận hay chưa
        /// </summary>
        public bool HasAccepted123 { get; set; }
    }
}
