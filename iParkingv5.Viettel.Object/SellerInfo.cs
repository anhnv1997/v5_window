using System;
using System.Collections.Generic;
using System.Text;

namespace Viettel.Object
{
    /// <summary>
    /// Thông tin người bán trên hóa đơn, có thể được truyền sang hoặc lấy tự động trên hệ thống hóa đơn điện tử. <br/>
    /// Trong trường hợp sellerTaxCode KHÔNG ĐƯỢC truyền sang thì dữ liệu sẽ được lấy từ hệ thống hóa đơn điện tử. <br/>
    /// </summary>
    public class SellerInfo
    {
        /// <summary>
        /// Tên (đăng ký kinh doanh trong trường hợp là doanh nghiệp) của người bán
        /// </summary>
        public string sellerLegalName { get; set; }

        /// <summary>
        /// Mã số thuế người bán được cấp bởi TCT Việt Nam. <br/>
        /// Mẫu 1: 0312770607  <br/>
        /// Mẫu 2: 0312770607-001 <br/>
        /// Mã số này được dùng để kiểm tra xem dữ liệu sẽ lấy từ hệ thống SInvoice  <br/>
        /// hay do phần mềm tích hợp truyền sang. <br/>
        /// Nếu có dữ liệu thì sẽ lấy toàn bộ thông tin người bán từ phần mềm tích hợp. <br/>
        /// Nếu không có sẽ lấy thông tin được cấu hình trên SInvoice.  <br/>
        /// Mã số này không được dùng để phát hành lên hóa đơn.  <br/>
        /// </summary>
        public string sellerTaxCode { get; set; }

        /// <summary>
        /// Địa chỉ của bên bán được thể hiện trên hóa đơn.
        /// Maxlength: 20 <br/>
        /// </summary>
        public string sellerAddressLine { get; set; }
        /// <summary>
        /// Số điện thoại người bán
        /// </summary>
        public string sellerPhoneNumber { get; set; }
        /// <summary>
        /// Số fax người bán
        /// </summary>
        public string sellerFaxNumber { get; set; }
        /// <summary>
        /// Địa chỉ thư điện tử người bán
        /// </summary>
        public string sellerEmail { get; set; }
        /// <summary>
        /// Tên ngân hàng nơi người bán mở tài khoản giao dịch
        /// </summary>
        public string sellerBankName { get; set; }
        /// <summary>
        /// Tài khoản ngân hàng của người bán
        /// </summary>
        public string sellerBankAccount { get; set; }
        /// <summary>
        /// Tên Quận Huyện
        /// </summary>
        public string sellerDistrictName { get; set; }
        /// <summary>
        /// Tên Tỉnh/Thành phố
        /// </summary>
        public string sellerCityName { get; set; }
        /// <summary>
        /// Mã quốc gia 
        /// </summary>
        public string sellerCountryCode { get; set; }
        /// <summary>
        /// Website của người bán
        /// </summary>
        public string sellerWebsite { get; set; }
        /// <summary>
        /// Mã danh mục đơn vị chấp nhận thanh toán
        /// Chỉ cho phép truyền ký tự số
        /// Lưu ý: các trường này phục vụ cho việc sinh qrcode78, các mẫu khác không bắt buộc
        /// </summary>
        public string merchantCode { get; set; }
        /// <summary>
        /// Tên đơn vị chấp nhận thanh toán
        /// Chỉ cho phép truyền 96 ký tự theo EMV Book
        /// Lưu ý: các trường này phục vụ cho việc sinh qrcode78, các mẫu khác không bắt buộc
        /// </summary>
        public string merchantName { get; set; }
        /// <summary>
        /// Thành phố đơn vị chấp nhận thanh toán 
        /// Chỉ cho phép truyền 96 ký tự theo EMV Book
        /// Lưu ý: các trường này phục vụ cho việc sinh qrcode78, các mẫu khác không bắt buộc
        /// </summary>
        public string merchantCity { get; set; }
    }
}
