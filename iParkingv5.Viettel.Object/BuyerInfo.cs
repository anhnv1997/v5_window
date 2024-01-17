using System;
using System.Collections.Generic;
using System.Text;

namespace Viettel.Object
{
    public class BuyerInfo
    {
        /// <summary>
        /// Tên người mua trong trường hợp là người mua lẻ, cá nhân. Tên người mua hoặc tên đơn vị là bắt buộc khi buyerNotGetInvoice = 0
        /// </summary>
        public string buyerName { get; set; }
        /// <summary>
        /// Mã khách hàng, chỉ cho phép các ký tự 
        /// </summary>
        public string buyerCode { get; set; }
        /// <summary>
        /// Tên đơn vị (đăng ký kinh doanh trong trường hợp là doanh nghiệp) của người mua. Tên người mua hoặc tên đơn vị là bắt buộc.
        /// </summary>
        public string buyerLegalName { get; set; }
        /// <summary>
        /// Mã số thuế người mua, có thể là mã số thuế Việt Nam hoặc mã số thuế nước ngoài
        /// Mẫu 1: 0312770607 
        /// Mẫu 2: 0312770607-001
        /// Bắt buộc khi buyerNotGetInvoice = 0
        /// </summary>
        public string buyerTaxCode { get; set; }
        /// <summary>
        /// Địa chỉ xuất hóa đơn của người mua 
        /// Bắt buộc khi buyerNotGetInvoice = 0
        /// </summary>
        public string buyerAddressLine { get; set; }
        /// <summary>
        /// Số điện thoại người mua, số điện thoại sẽ được dùng để gửi tin nhắn trong trường hợp bên bán đăng ký dịch vụ SMS Brandname. 
        /// </summary>
        public string buyerPhoneNumber { get; set; }
        /// <summary>
        /// Số fax người mua
        /// </summary>
        public string buyerFaxNumber { get; set; }
        /// <summary>
        /// Email người mua, sử dụng để gửi hóa đơn cho người mua
        /// Nếu có nhiều email thì cách nhau bởi dấu chấm phẩy(;). 
        /// Khi tài khoản email của bên bán được cấu hình trên hệ thống thì hệ thống tự động gửi nếu có email của người mua.
        /// Chi tiết cấu hình email xem ở đây:https://sinvoice.viettel.vn/ho-tro/huong-dan-su-dung/5-huong-dan-cau-hinh-doanh-nghiep--cau-hinh-chung 
        /// </summary>
        public string buyerEmail { get; set; }
        /// <summary>
        /// Tên trụ sở chính ngân hàng nơi người mua mở tài khoản giao dịch.
        /// </summary>
        public string buyerBankName { get; set; }
        /// <summary>
        /// Tài khoản ngân hàng của người mua. 
        /// </summary>
        public string buyerBankAccount { get; set; }
        /// <summary>
        /// Tên Quận Huyện
        /// </summary>
        public string buyerDistrictName { get; set; }
        /// <summary>
        /// Tên Tỉnh/Thành phố
        /// </summary>
        public string buyerCityName { get; set; }
        /// <summary>
        /// Mã quốc gia người mua
        /// </summary>
        public string buyerCountryCode { get; set; }
        /// <summary>
        /// Loại giấy tờ của người mua: <br/>
        /// 1: Số CMND <br/>
        /// 2: Hộ chiếu <br/>
        /// 3: Giấy phép kinh doanh <br/>
        /// Format: [123]* <br/>
        /// </summary>
        public string buyerIdType { get; set; }

        /// <summary>
        /// Chú ý: Khi buyerIdType có giá trị thì buyerIdNo bắt buộc phải có giá trị.
        /// Số giấy tờ của người mua, có thể là chứng minh thư, giấy phép kinh doanh, hộ chiếu
        /// </summary>
        public string buyerIdNo { get; set; }

        /// <summary>
        /// Ngày sinh của người mua
        /// </summary>
        public long buyerBirthDay { get; set; }

        /// <summary>
        /// 0- người mua lấy hóa đơn
        /// 1- người mua không lấy hóa đơn
        /// </summary>
        public int buyerNotGetInvoice { get; set; } = 1;
    }
}
