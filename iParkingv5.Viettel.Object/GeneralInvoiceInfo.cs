namespace Viettel.Object
{
    public class GeneralInvoiceInfo
    {
        /// <summary>
        /// Mã loại hóa đơn chỉ nhận các giá trị sau: <br/>
        /// Thông tư 32: 01GTKT, 02GTTT, 07KPTQ, 03XKNB, 04HGDL, 01BLP.Tuân thủ theo quy định ký hiệu loại hóa đơn của Thông tư hướng dẫn thi hành nghị định số 51/2010/NĐ-CP.Chi tiết xem PL1 Thông tư 39/2014/TT-BTC. <br/>
        /// Thông tư 78: 1, 2, 3, 4. Tuân thủ theo đúng Thông tư 78/2021/TT-BTC <br/>
        /// Lưu ý: tại một thời điểm, doanh nghiệp có thể sử dụng nhiều loại hóa đơn. <br/>
        /// </summary>
        public string invoiceType { get; set; } = "5";

        /// <summary>
        /// Maxlength: 20 <br/>
        /// Ký hiệu mẫu hóa đơn, tuân thủ theo quy định ký hiệu mẫu hóa đơn của Thông tư hướng dẫn thi hành <br/>
        /// Thông tư 32: Nghị định số 51/2010/NĐ-CP <br/>
        /// Ví dụ 01GTKT0/001, trong đó <br/>
        /// 01GTKT: ký hiệu loại hóa đơn <br/>
        /// 0: số liên, đối với hóa đơn điện tử luôn là 0 <br/>
        /// 001: số thứ tự tăng dần theo số lượng mẫu DN đăng ký <br/>
        /// với cơ quan thuế <br/>
        /// Chi tiết xem PL1 Thông tư 39/2014/TT-BTC <br/>
        /// Thông tư 78: Ví dụ: 1/001 trong đó <br/>
        /// 1: Ký hiệu loại hóa đơn <br/>
        /// 001: Thứ tự tăng dần theo số lượng mẫu DN đăng ký với cơ quan thuế <br/>
        /// Chi tiết tại khoản 1, Điều 3 Thông tư 78/2019/TT-BTC <br/>
        /// Lưu ý: tại một thời điểm, doanh nghiệp có thể có nhiều mẫu hóa đơn. <br/>
        /// </summary>
        public string templateCode { get; set; }

        /// <summary>
        /// Maxlength : 7 <br/>
        /// Format : ^[a-zA-Z0-9/]*$ <br/>
        /// Là “Ký hiệu hóa đơn” tuân thủ theo quy tắc tạo ký hiệu hóa đơn của Thông tư hướng dẫn thi hành <br/>
        /// Thông tư 32: Nghị định số 51/2010/NĐ-CP. <br/>
        /// Ví dụ AA/20E. <br/>
        /// Chi tiết xem PL1 Thông tư 39/2014/TT-BTC <br/>
        /// Thông tư 78: Ví dụ: K20TYY <br/>
        /// Chi tiết tại khoản 1, Điều 3 Thông tư 78/2019/TT-BTC <br/>
        /// Lưu ý: Tại một thời điểm, doanh nghiệp có thể có nhiều ký hiệu hóa đơn. <br/>
        /// Đối với hóa đơn theo TT78, người dùng không bắt buộc phải truyền đúng hai chữ số trong ký hiệu theo đúng năm phát hành hóa đơn. Trường hợp người dùng truyền sai (năm quá khứ hoặc tương lai), hệ thống vẫn lưu ký hiệu theo năm  <br/>
        /// Ví dụ: Người dùng lập hóa đơn với ký hiệu K18TAA, có ngày phát hành trong năm 2023, nếu truyền giá trị K50TAA, hệ thống vẫn sẽ lưu ký hiệu hóa đơn sau khi lập là K23TAA. <br/>
        /// </summary>
        public string invoiceSeries { get; set; }

        /// <summary>
        /// Ngày lập hóa đơn, tuân theo nguyên tắc đảm bảo về trình tự thời gian trong 1 ký hiệu hóa đơn 
        /// của một mẫu hóa đơn với một mã số thuế cụ thể: số hóa đơn sau phải được lập với thời gian 
        /// lớn hơn hoặc bằng số hóa đơn trước. <br/>
        /// Lưu ý: <br/>
        /// - Thời gian chính xác đến giờ phút giây <br/>
        /// - Trong trường hợp không gửi ngày lập sang, hệ thống tự động lấy theo thời gian hiện tại trên hệ thống với múi giờ GMT+7. <br/>
        /// - Dữ liệu truyền vào là thời gian dạng milliseconds kiểu long trong mục 5.1 <br/>
        /// Hệ thống ghi nhận đến chỉ số giây. Có thể tham khảo công thức tính tại: https://currentmillis.com/ <br/>
        /// </summary>
        public long? invoiceIssuedDate { get; set; } = null;

        /// <summary>
        /// Mã tiền tệ dùng cho hóa đơn có chiều dài 3 ký tự theo quy định của ngân hàng nhà nước Việt Nam. 
        /// Ví dụ: USD, VND, EUR… <br/>
        /// Minlength: 3 <br/>
        /// Maxlength: 3 <br/>
        /// Format: [A-Z]+ <br/>
        /// </summary>
        public string currencyCode { get; set; }

        /// <summary>
        /// Trạng thái điều chỉnh hóa đơn: <br/>
        /// 1: Hóa đơn gốc <br/>
        /// 3: Hóa đơn thay thế <br/>
        /// 5: Hóa đơn điều chỉnh <br/>
        /// 7: Hóa đơn xóa bỏ <br/>
        /// Không truyền sẽ mặc định là 1 <br/>
        /// Maxlength: 1 <br/>
        /// </summary>
        public string adjustmentType { get; set; } = "1";

        /// <summary>
        /// Lý do sai sót <br/>
        /// Cho phép nhập chuỗi ký tự tối đa 255 ký tự. <br/>
        /// Không bắt buộc truyền. <br/>
        /// Maxlength: 255 <br/>
        /// </summary>
        public string adjustedNote { get; set; } = string.Empty;

        /// <summary>
        /// Loại điều chỉnh đối với hóa đơn điều chỉnh <br/>
        /// 1: Hóa đơn điều chỉnh tiền <br/>
        /// 2: Hóa đơn điều chỉnh thông tin <br/>
        /// Bắt buộc nhập nếu adjustmentType = 5 <br/>
        /// Maxlength: 1 <br/>
        /// </summary>
        public string adjustmentInvoiceType { get; set; } = string.Empty;

        /// <summary>
        /// Số hóa đơn của hóa đơn gốc trong trường hợp lập hóa đơn là: <br/> 
        /// Hóa đơn thay thế <br/> 
        /// Hóa đơn điều chỉnh <br/> 
        /// Số hóa đơn có dạng AA20E00000001, trong đó <br/> 
        /// AA20E: ký hiệu hóa đơn <br/> 
        /// 00000001: số thứ tự tăng dần <br/> 
        /// Chi tiết xem PL1 Thông tư 39/2014/TT-BTC <br/> 
        /// Minlength: 7 <br/> 
        /// Maxlength: 15 <br/> 
        /// Format: ^[a-zA-Z0-9]*$ <br/> 
        /// </summary>
        public string originalInvoiceId { get; set; }

        /// <summary>
        /// Thời gian lập hóa đơn gốc, bắt buộc trong trường hợp lập hóa đơn thay thế và hóa đơn điều chỉnh. <br/>
        /// Dùng để tìm kiếm hóa đơn gốc của hóa đơn thay thế, điều chỉnh <br/>
        /// Maxlength: 50 <br/>
        /// Format: yyyy-MM-dd <br/>
        /// </summary>
        public long originalInvoiceIssueDate { get; set; } = 0;

        /// <summary>
        /// Thông tin tham khảo nếu có kèm theo của hóa đơn: <br/>
        /// văn bản thỏa thuận giữa bên mua và bên bán về việc thay thế, điều chỉnh hóa đơn. <br/>
        /// Bắt buộc khi lập hóa đơn thay thế, hóa đơn điều chỉnh.<br/>
        /// Maxlength : 225 <br/>
        /// </summary>
        public string additionalReferenceDesc { get; set; } = string.Empty;

        /// <summary>
        /// Thời gian phát sinh văn bản thỏa thuận giữa bên mua và bên bán, <br/>
        /// bắt buộc khi lập hóa đơn thay thế, hóa đơn điều chỉnh. <br/>
        /// - Dữ liệu truyền vào là thời gian dạng milisecond kiểu long trong mục 5.1 <br/>
        /// Maxlength: 50 <br/>
        /// Format: UNIX <br/>
        /// </summary>
        public long additionalReferenceDate { get; set; }

        /// <summary>
        /// Trạng thái thanh toán của hóa đơn <br/>
        /// True: Đã thanh toán <br/>
        /// False: Chưa thanh toán <br/>
        /// </summary>
        public bool paymentStatus { get; set; } = true;

        /// <summary>
        /// Cho phép người dùng tra cứu hóa đơn hay không. <br/>
        /// Mặc định true. <br/>
        /// Nếu để giá trị false thì sẽ không view được hóa đơn lên <br/>
        /// </summary>
        public bool cusGetInvoiceRight { get; set; }

        /// <summary>
        /// Tỷ giá ngoại tệ tại thời điểm lập hóa đơn quy đổi ra VND <br/>
        /// Lưu ý: Phần nguyên được nhập tối đa 11 chữ số, phần thập phân tối đa là 2 chữ số <br/>
        /// Maxlength: 13 <br/>
        /// </summary>
        public double exchangeRate { get; set; } = 1;

        /// <summary>
        /// Chú ý: Dữ liệu này không bắt buộc trong chuỗi json nhưng các phần mềm nên có để kiểm soát dữ liệu trùng cho các hóa đơn. <br/>
        /// ID để kiểm trùng giao dịch lập hóa đơn, được sinh ra từ hệ thống của bên đối tác,  <br/>
        /// là duy nhất với mỗi hóa đơn.  <br/>
        /// Trong trường hợp gửi transactionUuid thì bên hệ thống đối tác sẽ tự quản lý để đảm bảo tính duy nhất của transactionUuid. <br/>
        /// Với mỗi transactionUuid, khi đã gửi một transactionUuid với một hóa đơn A thì mọi request lập hóa đơn với cùng transactionUuid sẽ trả về hóa đơn A chứ không lập hóa đơn khác. <br/>
        /// Thời gian hiệu lực của transactionUuid là 3 ngày. <br/>
        /// Khuyến cáo: sử dụng UUID V4 để tránh bị trùng số. <br/>
        /// Tham khảo: https://en.wikipedia.org/wiki/Universally_unique_identifier <br/>
        /// Minlength: 10 <br/>
        /// Maxlength: 36 <br/>
        /// </summary>
        public string transactionUuid { get; set; } = string.Empty;

        /// <summary>
        /// Được sử dụng khi lập hóa đơn sử dụng USB Token. <br/>
        /// Serial Number của chứng thư số của doanh nghiệp,
        /// chứng thư số này đã được doanh nghiệp đẩy lên trên hệ thống khi đăng ký sử dụng USB Token. <br/>
        /// Định dạng Hex. <br/>
        /// Ví dụ: 5404FFFEB7033FB316D672201B7BA4FE <br/>
        /// Maxlength: 100 <br/>
        /// </summary>
        public string certificateSerial { get; set; } = string.Empty;

        /// <summary>
        /// Loại hóa đơn gốc <br/>
        /// Truyền giá trị số với ý nghĩa như sau  <br/>
        /// 0- Không phải hóa đơn giấy/hóa đơn không tồn tại trên hệ thống  <br/>
        /// 1-Hóa đơn TT78  <br/>
        /// 2-Hóa đơn theo QĐ 1209  <br/>
        /// 3-Hóa đơn điện tử/giấy TT32 <br/>
        /// 4-Hóa đơn giấy TT 78 <br/>
        /// Không truyền thì mặc định sẽ là 0 <br/>
        /// </summary>
        public string originalInvoiceType { get; set; } = "0";

        /// <summary>
        /// Bắt buộc truyền nếu originalInvoiceType là 1, 2, 3 hoặc 4 <br/>
        /// Ví dụ mẫu TT32: 01GTKT0/001 <br/>
        /// Ví dụ mẫu TT78: 1/0224 sẽ truyền là 1 <br/>
        /// 2/001 sẽ truyền là 2.... tương tự các loại hóa đơn khác(đối với tt78 sẽ truyền theo invoiceType ) <br/>
        /// Maxlength: 20
        /// </summary>
        public string originalTemplateCode { get; set; }

        /// <summary>
        /// - Mã bí mật đã được cấp cho MST <br/>
        /// - Yêu cầu này thực hiện thêm mới API phát hành hóa đơn có mã bí mật sử dụng chữ ký server <br/>
        /// - Thông tin đầu ra tương tự như API createInvoice/{supplierTaxCode <br/>
        /// }, trong đó reservationCode trong response chính là reservationCode <br/>
        /// trong Input.  <br/>
        /// - Trong trường hợp hệ thống gặp lỗi/chậm không thế trả kết quả ngay thì trả kết quả sau 10s. <br/>
        /// Maxlength: 100 <br/>
        /// </summary>
        public string reservationCode { get; set; }

        /// <summary>
        /// trường giảm giá 20% đối với hóa đơn bán hàng: Trường nhận giá trị “Tỷ lệ % theo doanh thu”. <br/>
        /// Giá trị truyền vào thuộc một trong các giá trị “1, 2, 3, 5”. <br/>
        /// Ví dụ: “adjustAmount20”: “2” <br/>
        /// Không bắt buộc <br/>
        /// </summary>
        public int adjustAmount20 { get; set; }

        /// <summary>
        /// Được sử dụng như là 1 dòng ghi chú ở dưới danh sách hàng hóa, <br/>
        /// khi thay thế điều chỉnh hệ thống sẽ tự sinh ra dòng “ Điều chỉnh / thay thế cho hóa đơn ... ngày .... “ . <br/>
        /// Khi điều chỉnh trên web sẽ tự sinh còn api thì phải truyền vào <br/>
        /// Lưu ý: Không tự sinh nếu bỏ kiểm tra dữ liệu đầu vào<br/>
        /// </summary>
        public string invoiceNote { get; set; }
    }
}
