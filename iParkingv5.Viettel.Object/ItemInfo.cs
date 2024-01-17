using System;
using System.Collections.Generic;
using System.Text;

namespace Viettel.Object
{
    public class ItemInfo
    {
        /// <summary>
        /// Thứ tự dòng hóa đơn, bắt đầu từ 1 <br/>
        /// Không cần nhập, hệ thống tự động sinh
        /// </summary>
        public int lineNumber { get; set; } = 1;

        /// <summary>
        /// Đánh dấu loại hàng hóa/dịch vụ <br/>
        /// Đối với Thông tư 32: <br/>
        /// Null hoặc 1- Hàng Hóa(Sinh STT, bắt buộc phải nhập số lượng, đơn giá) <br/>
        /// 2: Ghi chú(Không sinh STT và không cộng tiền vào tổng tiền thanh toán) <br/>
        /// 3: Chiết khấu(Không sinh STT, không cần nhập số lượng, đơn giá và thêm isIncreaseItem = false để xác định giảm tiền) <br/>
        /// 4: Bảng kê(Sinh STT, không cần nhập số lượng, đơn giá, chỉ cần nhập thành tiền) <br/>
        /// 5: Phí khác(Sinh STT, bắt buộc nhập số lượng, đơn giá) <br/>
        /// Đối với Thông tư 78: <br/>
        /// Null hoặc 1- Hàng Hóa(Sinh STT, bắt buộc phải nhập số lượng, đơn giá) <br/>
        /// 2: Ghi chú(Không sinh STT và không cộng tiền vào tổng tiền thanh toán) <br/>
        /// 3: Chiết khấu(Không sinh STT, không cần nhập số lượng, đơn giá và thêm isIncreaseItem = false để xác định giảm tiền) <br/>
        /// : Phí khác(Sinh STT, bắt buộc nhập số lượng, đơn giá) <br/>
        /// 5: Khuyến mại(Sinh STT, bắt buộc phải nhập số lượng, đơn giá) <br/>
        /// </summary>
        public int selection { get; set; } = 0;

        /// <summary>
        /// Mã hàng hóa, dịch vụ
        /// </summary>
        public string itemCode { get; set; } = "";

        /// <summary>
        /// Tên hàng hóa, dịch vụ <br/>
        /// Bắt buộc nhập với tính chất hàng hóa là Hàng hóa, Khuyến mãi và Phí khác <br/>
        /// Đối với hóa đơn điều chỉnh, Hệ thống sẽ dựa vào giá trị của isIncreaseItem xác định điều chỉnh tăng, giảm để tự sinh câu mô tả: <br/>
        /// "Điều chỉnh tăng/giảm tiền hàng, tiền thuế của hàng hóa dịch vụ" + itemName <br/>
        /// </summary>
        public string itemName { get; set; }

        /// <summary>
        /// Mã đơn vị tính, không bắt buộc
        /// </summary>
        public string uniCode { get; set; }
        /// <summary>
        /// Tên đơn vị tính hàng hóa, dịch vụ, không bắt buộc
        /// </summary>
        public string unitName { get; set; }
        /// <summary>
        /// Đơn giá của hàng hóa, không có số âm. 
        /// Bắt buộc nhập với tính chất hàng hóa là Hàng hóa, Khuyến mãi và Phí khác
        /// Bổ sung cho phép truyền giá trị âm
        /// </summary>
        public decimal unitPrice { get; set; }
        /// <summary>
        /// Số lượng của hàng hóa, luôn là số dương
        /// Bắt buộc nhập với tính chất hàng hóa là Hàng hóa, Khuyến mãi và Phí khác
        /// Bổ sung cho phép truyền giá trị âm
        /// </summary>
        public decimal quantity { get; set; }
        /// <summary>
        /// Là tổng tiền chưa bao gồm VAT của hàng hóa/dịch vụ. Tổng tiền không có số âm. itemTotalAmountWithoutTax = quantity * unitPrice <br/>
        /// Hệ thống sẽ kiểm tra dữ liệu nhận được vế bên trái với dữ liệu tính toán vế bên phải để kiểm tra tính chính xác của dữ liệu. <br/>
        /// Hóa đơn thường: Là tổng tiền hàng hóa dịch vụ chưa có VAT. <br/>
        /// Hóa đơn điều chỉnh: Là tổng tiền phần điều chỉnh của hàng hóa dịch vụ chưa có VAT <br/>
        /// Lưu ý: Cho phép sai số 5 đơn vị <br/>
        /// </summary>
        public decimal itemTotalAmountWithoutTax { get; set; }
        /// <summary>
        /// Trong trường hợp thuế tổng/hóa đơn bán hàng (theo chuẩn hóa đơn xác thực là phải có) <br/>
        /// -Thuế tổng: để theo con số chung <br/>
        /// -Hóa đơn bán hàng/hóa đơn không thuế: -2  <br/>
        /// Thuế suất của hàng hóa, dịch vụ.Thuế suất bao gồm các loại: <br/>
        /// -2: không thuế <br/>
        /// -1: không kê khai tính/nộp thuế Chỗ này hơi ngược với hóa đơn có mã xác thực của TCT <br/>
        /// 0: 0% <br/>
        /// 5: 5% <br/>
        /// 10: 10% <br/>
        /// </summary>
        public decimal taxPercentage { get; set; }
        /// <summary>
        /// Trong trường hợp thuế tổng/hóa đơn bán hàng: (theo chuẩn hóa đơn xác thực là phải có)
        /// -Thuế tổng: tổng tiền hàng* thuế chung
        /// -Hóa đơn bán hàng/hóa đơn không thuế: 0
        /// Tổng tiền thuế
        /// Nếu không truyền, được hiểu là = 0
        /// </summary>
        public decimal taxAmount { get; set; } = 0;
        /// <summary>
        /// Hóa đơn bình thường: có giá trị là null.
        /// Hóa đơn điều chỉnh:
        /// - false: dòng hàng hóa/dịch vụ bị điều chỉnh giảm 
        /// - true: dòng hàng hóa/dịch vụ bị điều chỉnh tang
        /// </summary>
        public bool? isIncreaseItem { get; set; } = null;

        /// <summary>
        /// - Ghi chú cho từng dòng hàng hóa
        /// - Để đồng bộ nội dung ghi chú của từng dòng hàng hóa đọc tự động trên web và nội dung ghi chú 
        /// từ API tích hợp khi lập hóa đơn điều chỉnh tiền, người dùng API tích hợp truyền nội dung ghi chú
        /// chi tiết cho từng dòng hàng hóa vào trường itemNote trong itemInfo.Hệ thống sẽ tự đọc phần
        /// thông tin “của hàng hóa dịch vụ” và ghép với tên hàng hóa dịch vụ
        /// Ví dụ: Hệ thống tự động sinh ghi chú: Điều chỉnh tăng số lượng, giảm đơn giá của hàng hóa dịch vụ: Máy tính
        /// </summary>
        public string itemNote { get; set; } = string.Empty;
        /// <summary>
        /// Số lô, thường dùng cho các hàng hóa là thuốc, 
        /// có thể sử dụng để hiển thị thêm thông tin trong trường hợp cần thiết.
        /// </summary>
        public string batchNo { get; set; } = string.Empty;
        /// <summary>
        /// Hạn sử dụng của hàng hóa, thường dùng cho các hàng hóa là thuốc,
        /// có thể sử dụng để hiển thị thêm thông tin trong trường hợp cần thiết.
        /// </summary>
        public string expDate { get; set; } = "0";
        /// <summary>
        /// % chiết khấu trên dòng sản phẩm, tính trên đơn giá của sản phẩm. 
        /// Trong trường hợp không có thì truyền 0
        /// </summary>
        public decimal discount { get; set; } = 0;
        /// <summary>
        /// % chiết khấu thứ 2 trên dòng sản phẩm, tính trên đơn giá của sản phẩm.
        /// Trong trường hợp không có thì truyền 0.
        /// </summary>
        public decimal? discount2 { get; set; } = null;
        /// <summary>
        /// Giá trị chiết khấu trên dòng sản phẩm, sau khi nhân với số lượng và % chiết khấu
        /// Hệ thống tự tính, không cần truyền dữ liệu
        /// </summary>
        public decimal? itemDiscount { get; set; } = null;
        /// <summary>
        /// Là tổng tiền sau khi trừ chiết khấu, giảm giá.
        /// Hệ thống tự tính, không cần truyền dữ liệu
        /// </summary>
        public decimal? itemTotalAmountAfterDiscount { get; set; } = null;
        /// <summary>
        /// Là tổng tiền đã bao gồm VAT của hàng hóa/dịch vụ. 
        /// Hệ thống tự tính, không cần truyền dữ liệu
        /// </summary>
        public decimal? itemTotalAmountWithTax { get; set; } = null;
    }
}
