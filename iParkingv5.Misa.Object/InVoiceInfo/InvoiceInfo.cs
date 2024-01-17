using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Object
{
    /// <summary>
    /// Thông tin hóa đơn gốc
    /// </summary>
    public class OriginalInvoiceData
    {
        /// <summary>
        /// ID của hóa đơn trên Client App
        /// </summary>
        public string RefID { get; set; } = string.Empty;

        /// <summary>
        /// QRCode cho hóa đơn
        /// </summary>
        public string QRCode { get; set; } = string.Empty;

        /// <summary>
        /// Ký hiệu hóa đơn
        /// </summary>
        public string InvSeries { get; set; } = string.Empty;

        /// <summary>
        /// Tên hóa đơn
        /// </summary>
        public string InvoiceName { get; set; } = string.Empty;

        /// <summary>
        /// Ngày hóa đơn
        /// </summary>
        /// <returns></returns>
        public DateTime InvDate { get; set; }

        /// <summary>
        /// Mã loại tiền tệ
        /// </summary>
        public string CurrencyCode { get; set; } = string.Empty;

        /// <summary>
        /// Tỷ giá
        /// </summary>
        public decimal? ExchangeRate { get; set; }

        /// <summary>
        /// Hình thức thanh toán
        /// </summary>
        public string PaymentMethodName { get; set; } = string.Empty;

        /// <summary>
        /// Tính chất hóa đơn (1: thay thế; 2: điều chỉnh)
        /// </summary>
        public int? ReferenceType { get; set; } 

        /// <summary>
        /// Là hóa đơn gửi dạng bảng tổng hợp
        /// </summary>
        public bool IsInvoiceSummary { get; set; }

        /// <summary>
        /// Loại hóa đơn bị thay thế/điều chỉnh (1: Hóa đơn 123; 3: Hóa đơn 51)
        /// </summary>
        public int? OrgInvoiceType { get; set; }

        /// <summary>
        /// Ký hiệu mẫu hđ bị thay thế/điều chỉnh
        /// </summary>
        public string OrgInvTemplateNo { get; set; } = null;

        /// <summary>
        /// Ký hiệu hđ bị thay thế/điều chỉnh
        /// </summary>
        public string OrgInvSeries { get; set; } = null;

        /// <summary>
        /// Số hđ bị thay thế/điều chỉnh
        /// </summary>
        public string OrgInvNo { get; set; } = null;

        /// <summary>
        /// Ngày hóa đơn bị thay thế/điều chỉnh
        /// </summary>
        public DateTime? OrgInvDate { get; set; }

        /// <summary>
        /// Ghi chú của hóa đơn
        /// </summary>
        public string InvoiceNote { get; set; } = string.Empty;

        /// <summary>
        /// Tên người bán
        /// </summary>
        public string SellerLegalName { get; set; } = string.Empty;

        /// <summary>
        /// MST người bán
        /// </summary>
        public string SellerTaxCode { get; set; } = string.Empty;

        /// <summary>
        /// Địa chỉ người bán
        /// </summary>
        public string SellerAddress { get; set; } = string.Empty;

        /// <summary>
        /// ĐT người bán
        /// </summary>
        public string SellerPhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Email người bán
        /// </summary>
        public string SellerEmail { get; set; } = string.Empty;

        /// <summary>
        /// Số TK ngân hàng người bán
        /// </summary>
        public string SellerBankAccount { get; set; } = string.Empty;

        /// <summary>
        /// Tên ngân hàng người bán
        /// </summary>
        public string SellerBankName { get; set; } = string.Empty;

        /// <summary>
        /// Fax người bán
        /// </summary>
        public string SellerFax { get; set; } = string.Empty;

        /// <summary>
        /// Website người bán
        /// </summary>
        public string SellerWebsite { get; set; } = string.Empty;

        /// <summary>
        /// Tên (Tên người xuất hàng)
        /// </summary>
        public string StockOutLegalName { get; set; } = string.Empty;

        /// <summary>
        /// Mã số thuế (MST người xuất hàng)
        /// </summary>
        public string StockOutTaxCode { get; set; } = string.Empty;

        /// <summary>
        /// Lệnh điều động nội bộ
        /// </summary>
        public string InternalCommand { get; set; } = string.Empty;

        /// <summary>
        /// Địa chỉ (Địa chỉ kho xuất hàng)
        /// </summary>
        public string StockOutAddress { get; set; } = string.Empty;

        /// <summary>
        /// Họ và tên người xuất hàng
        /// </summary>
        public string StockOutFullName { get; set; } = string.Empty;

        /// <summary>
        /// Tên người vận chuyển
        /// </summary>
        public string TransporterName { get; set; } = string.Empty;

        /// <summary>
        /// Hợp đồng số (Hợp đồng vận chuyển)
        /// </summary>
        public string TransportContractCode { get; set; } = string.Empty;

        /// <summary>
        /// Phương tiện vận chuyển
        /// </summary>
        public string Transport { get; set; } = string.Empty;

        /// <summary>
        /// Tên (Tên người nhận hàng)
        /// </summary>
        public string StockInLegalName { get; set; } = string.Empty;

        /// <summary>
        /// Mã số thuế (Mã số thuế người nhận hàng)
        /// </summary>
        public string StockInTaxCode { get; set; } = string.Empty;

        /// <summary>
        /// Họ và tên người nhận hàng
        /// </summary>
        public string StockInFullName { get; set; } = string.Empty;

        /// <summary>
        /// Địa chỉ (Địa chỉ kho nhận hàng)
        /// </summary>
        public string StockInAddress { get; set; } = string.Empty;

        /// <summary>
        /// Hợp đồng kinh tế số
        /// </summary>
        public string ContractCode { get; set; } = string.Empty;

        /// <summary>
        /// Hợp đồng kinh tế ngày
        /// </summary>
        public DateTime? ContractDate { get; set; }

        /// <summary>
        /// Tên người mua
        /// </summary>
        public string BuyerLegalName { get; set; } = string.Empty;

        /// <summary>
        /// MST người mua
        /// </summary>
        public string BuyerTaxCode { get; set; } = string.Empty;

        /// <summary>
        /// Địa chỉ người mua
        /// </summary>
        public string BuyerAddress { get; set; } = string.Empty;

        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public string BuyerCode { get; set; } = string.Empty;

        /// <summary>
        /// ĐT người mua
        /// </summary>
        public string BuyerPhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Email người mua
        /// </summary>
        public string BuyerEmail { get; set; } = string.Empty;

        /// <summary>
        /// Tên người mua hàng
        /// </summary>
        public string BuyerFullName { get; set; } = string.Empty;

        /// <summary>
        /// Số TK ngân hàng người mua
        /// </summary>
        public string BuyerBankAccount { get; set; } = string.Empty;

        /// <summary>
        /// Tên ngân hàng người mua
        /// </summary>
        public string BuyerBankName { get; set; } = string.Empty;

        /// <summary>
        /// tên người liên hệ
        /// </summary>
        public string ContactName { get; set; } = string.Empty;

        /// <summary>
        /// Tỷ lệ chiết khấu cho hóa đơn chiết khấu theo giá trị hóa đơn
        /// </summary>
        public decimal? DiscountRate { get; set; }

        /// <summary>
        /// tổng tiền chưa thuế
        /// </summary>
        public decimal? TotalAmountWithoutVATOC { get; set; }

        /// <summary>
        /// Tổng tiền thuế
        /// </summary>
        public decimal? TotalVATAmountOC { get; set; }

        /// <summary>
        /// Tổng tiền CKTM
        /// </summary>
        public decimal? TotalDiscountAmountOC { get; set; }

        /// <summary>
        /// Tổng tiền bằng số
        /// </summary>
        public decimal? TotalAmountOC { get; set; }

        /// <summary>
        /// Tổng tiền bằng chữ
        /// </summary>
        public string TotalAmountInWords { get; set; } = string.Empty;

        /// <summary>
        /// Tổng tiền bằng chữ tiếng anh
        /// </summary>
        public string TotalAmountInWordsByENG { get; set; } = string.Empty;

        #region "Các thông tin bổ sung"

        /// <summary>
        /// Chi tiết hóa đơn
        /// </summary>
        /// <returns></returns>
        public List<OriginalInvoiceDetail> OriginalInvoiceDetail { get; set; }

        /// <summary>
        /// Danh sách các loại thuế suất
        /// </summary>
        public List<TaxRateInfo> TaxRateInfo { get; set; }

        /// <summary>
        /// Danh sách các loại phí
        /// </summary>
        public List<FeeInfo> FeeInfo { get; set; }

        /// <summary>
        /// Định dạng số để hiển thị hóa đơn
        /// </summary>
        public OptionUserDefined OptionUserDefined { get; set; }

        /// <summary>
        /// ID mẫu hóa đơn
        /// </summary>
        public Guid? InvoiceTemplateID { get; set; }

        /// <summary>
        /// Trường mở rộng 1
        /// </summary>
        public string CustomField1 { get; set; } = string.Empty;

        /// <summary>
        /// Trường mở rộng 2
        /// </summary>
        public string CustomField2 { get; set; } = string.Empty;

        /// <summary>
        /// Trường mở rộng 3
        /// </summary>
        public string CustomField3 { get; set; } = string.Empty;

        /// <summary>
        /// Trường mở rộng 4
        /// </summary>
        public string CustomField4 { get; set; } = string.Empty;

        /// <summary>
        /// Trường mở rộng 5
        /// </summary>
        public string CustomField5 { get; set; } = string.Empty;

        /// <summary>
        /// Trường mở rộng 6
        /// </summary>
        public string CustomField6 { get; set; } = string.Empty;

        /// <summary>
        /// Trường mở rộng 7
        /// </summary>
        public string CustomField7 { get; set; } = string.Empty;

        /// <summary>
        /// Trường mở rộng 8
        /// </summary>
        public string CustomField8 { get; set; } = string.Empty;

        /// <summary>
        /// Trường mở rộng 9
        /// </summary>
        public string CustomField9 { get; set; } = string.Empty;

        /// <summary>
        /// Trường mở rộng 10
        /// </summary>
        public string CustomField10 { get; set; } = string.Empty;

        /// <summary>
        /// Tổng tiền bằng số quy đổi
        /// </summary>
        public decimal? TotalAmount { get; set; }

        /// <summary>
        /// tổng tiền chưa thuế quy đổi
        /// </summary>
        public decimal? TotalAmountWithoutVAT { get; set; }

        /// <summary>
        /// Tổng tiền thuế quy đổi
        /// </summary>
        public decimal? TotalVATAmount { get; set; }

        /// <summary>
        /// Tổng tiền CKTM quy đổi
        /// </summary>
        public decimal? TotalDiscountAmount { get; set; }

        /// <summary>
        /// Tổng tiền hàng
        /// </summary>
        public decimal? TotalSaleAmountOC { get; set; }

        /// <summary>
        /// Tổng tiền hàng quy đổi
        /// </summary>
        public decimal? TotalSaleAmount { get; set; }

        /// <summary>
        /// Tổng tiền xuất kho nguyên tệ
        /// </summary>
        public decimal? StockTotalAmountOC { get; set; }

        /// <summary>
        /// Tổng tiền xuất kho
        /// </summary>
        public decimal? StockTotalAmount { get; set; }

        /// <summary>
        /// Có giảm trừ thuế không
        /// </summary>
        public bool? IsTaxReduction { get; set; }

        /// <summary>
        /// Có giảm trừ thuế không
        /// </summary>
        public bool? IsTaxReduction43 { get; set; }

        /// <summary>
        /// </summary>
        public bool? isTicket { get; set; } = true;

        /// <summary>
        /// Số tiền bằng chữ (VNĐ)
        /// </summary>
        public string TotalAmountInWordsVN { get; set; } = string.Empty;

        /// <summary>
        /// Số tiền bằng chữ không dấu
        /// </summary>
        public string TotalAmountInWordsUnsignNormalVN { get; set; } = string.Empty;

        /// <summary>
        /// Tên chi nhánh ngân hàng người bán
        /// </summary>
        public string CompanyBranchBankName { get; set; } = string.Empty;

        /// <summary>
        /// Tên ngân hàng (kèm chi nhánh) của người bán
        /// </summary>
        public string CompanyBankNameWithBranch { get; set; } = string.Empty;

        /// <summary>
        /// Phí hoàn vé máy bay
        /// </summary>
        public decimal? ReturnTicketAmount { get; set; }

        /// <summary>
        /// Phí hoàn vé máy bay nguyên tệ
        /// </summary>
        public decimal? ReturnTicketAmountOC { get; set; }

        /// <summary>
        /// Phần trăm thuế tiêu thụ đặc biệt
        /// </summary>
        public decimal? ExciseTaxRate { get; set; }

        /// <summary>
        /// Tiền thuế tiêu thụ đặc biệt
        /// </summary>
        public decimal? ExciseTaxAmount { get; set; }

        /// <summary>
        /// Thuế tiêu thụ ĐB nguyên tệ
        /// </summary>
        public decimal? ExciseTaxAmountOC { get; set; }

        /// <summary>
        /// Số hợp đồng
        /// </summary>
        public string TrsContractNo { get; set; } = string.Empty;

        /// <summary>
        /// Vận đơn
        /// </summary>
        public string TrsBLNo { get; set; } = string.Empty;

        /// <summary>
        /// Tên tàu
        /// </summary>
        public string TrsNameVessel { get; set; } = string.Empty;

        /// <summary>
        /// Quốc tịch
        /// </summary>
        public string TrsFlag { get; set; } = string.Empty;

        /// <summary>
        /// Ngày đến
        /// </summary>
        public DateTime? TrsArrival { get; set; }

        /// <summary>
        /// Ngày đi
        /// </summary>
        public DateTime? TrsDeparture { get; set; }

        /// <summary>
        /// Phòng số
        /// </summary>
        public string RoomNo { get; set; } = string.Empty;

        /// <summary>
        /// Ngày đến
        /// </summary>
        public string CheckIn { get; set; } = string.Empty;

        /// <summary>
        /// Ngày đi
        /// </summary>
        public string CheckOut { get; set; } = string.Empty;

        /// <summary>
        /// Toán tử tỷ giá
        /// </summary>
        public string ExchangeRateOperation { get; set; } = string.Empty;

        /// <summary>
        /// Ds kho
        /// </summary>
        public string ListStockName { get; set; } = string.Empty;

        /// <summary>
        /// Ds địa chỉ kho
        /// </summary>
        public string ListStockAddress { get; set; } = string.Empty;

        /// <summary>
        /// Mã kho đi
        /// </summary>
        public string ListFromStockCode { get; set; } = string.Empty;

        /// <summary>
        /// Mã kho đến
        /// </summary>
        public string ListToStockCode { get; set; } = string.Empty;

        /// <summary>
        /// Địa chỉ kho đi
        /// </summary>
        public string FromStockAddress { get; set; } = string.Empty;

        /// <summary>
        /// Địa chỉ kho đến
        /// </summary>
        public string ToStockAddress { get; set; } = string.Empty;

        /// <summary>
        /// Lệnh điều động số
        /// </summary>
        public string InternalCommandNo { get; set; } = string.Empty;

        /// <summary>
        /// Lệnh điều động của
        /// </summary>
        public string InternalCommandOwner { get; set; } = string.Empty;

        /// <summary>
        /// Lệnh điều động ngày
        /// </summary>
        public DateTime? InternalCommandDate { get; set; }

        /// <summary>
        /// Về việc
        /// </summary>
        public string JournalMemo { get; set; } = string.Empty;

        /// <summary>
        /// Kỳ thu
        /// </summary>
        public string PeriodName { get; set; } = string.Empty;

        /// <summary>
        ///Từ ngày
        /// </summary>
        public DateTime? PeriodFromDate { get; set; }

        /// <summary>
        /// Đến ngày
        /// </summary>
        public DateTime? PeriodToDate { get; set; }

        /// <summary>
        /// Số nước truy thu
        /// </summary>
        public decimal? WaterArrearage { get; set; }

        /// <summary>
        /// Số nước khuyến mại
        /// </summary>
        public decimal? WaterPromotion { get; set; }

        /// <summary>
        /// Số nước tiêu thụ
        /// </summary>
        public decimal? WaterUsed { get; set; }

        /// <summary>
        /// Chỉ số mới
        /// </summary>
        public decimal? NewIndex { get; set; }

        /// <summary>
        /// Chỉ số cũ
        /// </summary>
        public decimal? OldIndex { get; set; }

        /// <summary>
        /// Mức % Phí bảo vệ môi trường
        /// </summary>
        public int EnvironmmentFeeRate { get; set; }

        /// <summary>
        /// Tiền phí bảo vệ môi trường
        /// </summary>
        public decimal? EnvironmmentFeeAmount { get; set; }

        /// <summary>
        /// Phí đăng kiểm
        /// </summary>
        public decimal? RegistrationFee { get; set; }

        /// <summary>
        /// Tổng chỉ số của các đồng hồ - Điện năng tiêu thụ
        /// </summary>
        public decimal? SumOfClockIndex { get; set; }

        /// <summary>
        /// Danh sách đồng hồ
        /// </summary>
        public List<ClockInfo> ClockInfos { get; set; }

        #endregion "Các thông tin bổ sung"
    }

    /// <summary>
    /// Thông tin chi tiết hóa đơn gốc
    /// </summary>
    public class OriginalInvoiceDetail
    {
        /// <summary>
        /// Tính chất (1: HHDV; 2: khuyến mại; 3: chiết khẩu; 4: ghi chú/diễn giải)
        /// </summary>
        public int ItemType { get; set; }

        /// <summary>
        /// STT dòng mặt hàng (bắt đầu từ 1)
        /// </summary>
        public int LineNumber { get; set; }

        /// <summary>
        /// Mã mặt hàng
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// Tên mặt hàng
        /// </summary>
        public string ItemName { get; set; } = string.Empty;

        /// <summary>
        /// Đơn vị tính
        /// </summary>
        public string UnitName { get; set; } = string.Empty;

        /// <summary>
        /// Số lượng mặt hàng
        /// </summary>
        public decimal? Quantity { get; set; }

        /// <summary>
        /// Đơn giá
        /// </summary>
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// Tỷ lệ chiết khấu
        /// </summary>
        public decimal? DiscountRate { get; set; }

        /// <summary>
        /// Tiền chiết khấu
        /// </summary>
        public decimal? DiscountAmountOC { get; set; }

        /// <summary>
        /// Tiền chiết khấu quy đổi
        /// </summary>
        public decimal? DiscountAmount { get; set; }

        /// <summary>
        /// Thành tiền
        /// </summary>
        public decimal? AmountOC { get; set; }

        /// <summary>
        /// Thành tiền quy đổi
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Thành tiền chưa thuế
        /// </summary>
        public decimal? AmountWithoutVATOC { get; set; }

        /// <summary>
        /// Đơn giá sau thuế
        /// </summary>
        public decimal? UnitPriceAfterTax { get; set; }

        /// <summary>
        /// Thành tiền sau thuế quy đổi
        /// </summary>
        public decimal? AmountAfterTax { get; set; }

        /// <summary>
        /// Tên loại thuế suất
        /// </summary>
        public string VATRateName { get; set; } = string.Empty;

        /// <summary>
        /// Tiền thuế
        /// </summary>
        public decimal? VATAmountOC { get; set; }

        /// <summary>
        /// Tiền thuế quy đổi
        /// </summary>
        public decimal? VATAmount { get; set; }

        /// <summary>
        /// Trường mở rộng 1
        /// </summary>
        public string CustomField1Detail { get; set; } = string.Empty;

        /// <summary>
        /// Trường mở rộng 2
        /// </summary>
        public string CustomField2Detail { get; set; } = string.Empty;

        /// <summary>
        /// Trường mở rộng 3
        /// </summary>
        public string CustomField3Detail { get; set; } = string.Empty;

        /// <summary>
        /// Trường mở rộng 4
        /// </summary>
        public string CustomField4Detail { get; set; } = string.Empty;

        /// <summary>
        /// Trường mở rộng 5
        /// </summary>
        public string CustomField5Detail { get; set; } = string.Empty;

        /// <summary>
        /// Trường mở rộng 6
        /// </summary>
        public string CustomField6Detail { get; set; } = string.Empty;

        /// <summary>
        /// Trường mở rộng 7
        /// </summary>
        public string CustomField7Detail { get; set; } = string.Empty;

        /// <summary>
        /// Trường mở rộng 8
        /// </summary>
        public string CustomField8Detail { get; set; } = string.Empty;

        /// <summary>
        /// Trường mở rộng 9
        /// </summary>
        public string CustomField9Detail { get; set; } = string.Empty;

        /// <summary>
        /// Trường mở rộng 10
        /// </summary>
        public string CustomField10Detail { get; set; } = string.Empty;

        /// <summary>
        /// Thứ tự hiển thị lên mẫu
        /// </summary>
        public int? SortOrder { get; set; }

        /// <summary>
        /// Diễn giải hàng hóa
        /// </summary>
        public string InventoryItemNote { get; set; } = string.Empty;

        /// <summary>
        /// Số lô
        /// </summary>
        public string LotNo { get; set; } = string.Empty;

        /// <summary>
        /// Hạn sử dụng
        /// </summary>
        public DateTime? ExpiryDate { get; set; }

        /// <summary>
        /// Mã ĐVT
        /// </summary>
        public string UnitCode { get; set; } = string.Empty;

        /// <summary>
        /// Tiền thuế đc giảm nguyên tệ (406)
        /// </summary>
        public decimal? TaxReductionAmountOC { get; set; }

        /// <summary>
        /// Tiền thuế được giảm quy đổi (406)
        /// </summary>
        public decimal? TaxReductionAmount { get; set; }

        ///// <summary>
        ///// Số lượng thực nhập
        ///// </summary>
        public decimal? InWards { get; set; }

        /// <summary>
        /// Số khung
        /// </summary>
        public string ChassisNumber { get; set; } = string.Empty;

        /// <summary>
        /// Số khung
        /// </summary>
        public string EngineNumber { get; set; } = string.Empty;

        /// <summary>
        /// Xuất bản phí
        /// </summary>
        public string PublishFee { get; set; } = string.Empty;
    }


    /// <summary>
    /// Thông tin đồng hồ đối với hóa đơn điện nước
    /// </summary>
    public class ClockInfo
    {
        /// <summary>
        /// STT dòng mặt hàng (bắt đầu từ 1)
        /// </summary>
        public int ClockOrder { get; set; }

        /// <summary>
        /// Mã đồng hồ
        /// </summary>
        public string ClockCode { get; set; } = string.Empty;

        /// <summary>
        /// Seri đồng hồ
        /// </summary>
        public string ClockSeri { get; set; } = string.Empty;

        /// <summary>
        /// Chỉ số mới
        /// </summary>
        public decimal? LastIndex { get; set; }

        /// <summary>
        /// Chỉ số cũ
        /// </summary>
        public decimal? FirstIndex { get; set; }

        /// <summary>
        /// Hệ số của đồng hồ
        /// </summary>
        public decimal? Coefficient { get; set; }

        /// <summary>
        /// Mã đồng hồ cũ
        /// </summary>
        public string ClockCodeOld { get; set; } = string.Empty;

        /// <summary>
        /// Seri đồng hồ cũ
        /// </summary>
        public string ClockSeriOld { get; set; } = string.Empty;

        /// <summary>
        /// Chỉ số mới của đồng hồ cũ
        /// </summary>
        public decimal? LastIndexOld { get; set; }

        /// <summary>
        /// Chỉ số cũ của đồng hồ cũ
        /// </summary>
        public decimal? FirstIndexOld { get; set; }

        /// <summary>
        /// Hệ số của đồng hồ cũ
        /// </summary>
        public decimal? CoefficientOld { get; set; }

        /// <summary>
        /// Trạng thái của đồng hồ
        /// 0 hoặc null là đang sử dụng
        /// 1 là thay mới đồng hồ => truyền thêm thông tin đồng hồ cũ vào các trường có Old
        /// </summary>
        public int? ClockStatus { get; set; }

        /// <summary>
        /// Xe tra nạp
        /// </summary>
        public string RefuelerNo { get; set; } = string.Empty;

        /// <summary>
        /// Số lô
        /// </summary>
        public string LotNo { get; set; } = string.Empty;

        /// <summary>
        /// Số công tơ đầu
        /// </summary>
        public decimal? StartMeter { get; set; }

        /// <summary>
        /// Số công tơ cuối
        /// </summary>
        public decimal? EndMeter { get; set; }

        /// <summary>
        /// Nhiệt độ thực tế
        /// </summary>
        public decimal? Temperature { get; set; }

        /// <summary>
        /// Tỉ trọng thực tế
        /// </summary>
        public decimal? Density { get; set; }

        /// <summary>
        /// Gallon thực tế
        /// </summary>
        public decimal? Gallon { get; set; }

        /// <summary>
        /// Lít thực tế
        /// </summary>
        public decimal? Liters { get; set; }
    }

    /// <summary>
    /// Thông tin các loại thuế suất
    /// </summary>
    public class TaxRateInfo
    {
        /// <summary>
        /// Tên loại thuế suất
        /// </summary>
        public string VATRateName { get; set; } = string.Empty;

        /// <summary>
        /// Tiền chưa thuế
        /// </summary>
        public decimal? AmountWithoutVATOC { get; set; }

        /// <summary>
        /// Tiền thuế
        /// </summary>
        public decimal? VATAmountOC { get; set; }
    }

    /// <summary>
    /// Thông tin các loại phí
    /// </summary>
    public class FeeInfo
    {
        /// <summary>
        /// Tên loại phí
        /// </summary>
        public string FeeName { get; set; } = string.Empty;

        /// <summary>
        /// Tiền phí
        /// </summary>
        public decimal? FeeAmountOC { get; set; }
    }

    /// <summary>
    /// Class chứa các tùy chọn cần dùng để hiển thị hóa đơn:
    /// Định dạng số, đồng tiền hạch toán
    /// </summary>
    public class OptionUserDefined
    {
        /// <summary>
        /// Đồng tiền hạch toán
        /// </summary>
        public string MainCurrency { get; set; } = string.Empty;

        /// <summary>
        /// Định dạng số tiền quy dổi
        /// </summary>
        public string AmountDecimalDigits { get; set; } = string.Empty;

        /// <summary>
        /// Định dạng số tiền nguyên tệ
        /// </summary>
        public string AmountOCDecimalDigits { get; set; } = string.Empty;

        /// <summary>
        /// Định dạng đơn giá nguyên tệ
        /// </summary>
        public string UnitPriceOCDecimalDigits { get; set; } = string.Empty;

        /// <summary>
        /// Định dạng đơn giá quy đổi
        /// </summary>
        public string UnitPriceDecimalDigits { get; set; } = string.Empty;

        /// <summary>
        /// Định dạng số lượng
        /// </summary>
        public string QuantityDecimalDigits { get; set; } = string.Empty;

        /// <summary>
        /// Định dạng tỷ lệ
        /// </summary>
        public string CoefficientDecimalDigits { get; set; } = string.Empty;

        /// <summary>
        /// Định dạng tỷ giá
        /// </summary>
        public string ExchangRateDecimalDigits { get; set; } = string.Empty;

        /// <summary>
        /// Định dạng tham số decimal trong ClockInfo
        /// </summary>
        public string ClockDecimalDigits { get; set; } = string.Empty;
    }

    public class OriginalInvoiceDataHSM
    {
        public OriginalInvoiceData OriginalInvoiceData { get; set; }
        public string RefID { get; set; } = string.Empty;
        public bool IsSendEmail { get; set; } = false;
        public bool IsInvoiceSummary { get; set; } = false;
        public string ReceiverName { get; set; } = string.Empty;
        public string ReceiverEmail { get; set; } = string.Empty;
    }
}
