using System;
using System.Collections.Generic;
using System.Text;

namespace Viettel.Object
{
    /// <summary>
    /// Dùng để tổng hợp thuế suất theo mức cho hóa đơn.
    /// </summary>
    public class TaxBreakdowns
    {
        /// <summary>
        /// Mức thuế: khai báo giá trị như sau <br/>
        /// -2: không thuế <br/>
        /// -1: không kê khai tính/nộp thuế  <br/>
        /// 0: 0% <br/>
        /// 5: 5% <br/>
        /// 10: 10% <br/>
        /// Note: Mỗi một giá trị thuế chỉ xuất hiện 1 lần(lưu giá trị tổng hợp các hàng hóa cùng loại thuế đó) <br/>
        /// Bắt buộc nhập với mãu thuế Tổng <br/>
        /// Trường hợp người dùng không truyền thông tin thì lưu giá trị null vào list_product trong bảng invoice. 
        ///Lưu ý trường hợp đối với hóa đơn thuế tổng, 
        ///hàng hóa có tính chất ghi chú không truyền giá trị vatPercentage 
        ///thì lưu giá trị thuế suất của hàng hóa là NULL, 
        ///không lấy theo vatPercentage trong taxBreakDowns như hiện tại)
        /// </summary>
        public decimal? taxPercentage { get; set; } = null;
        /// <summary>
        /// Tổng tiền chịu thuế của mức thuế tương ứng, tổng tiền chịu thuế không có số âm. Bằng tổng của itemTotalAmountWithoutTax của tất cả các itemInfo có mức thuế suất giống với mức thuế suất tổng hợp. Trong trường hợp dòng hàng hóa là chiết khấu thì trừ đi.
        /// Không cần nhập liệu, hệ thống tự tính dựa vào các itemTotalAmountWithoutTax
        /// </summary>
        public decimal? taxableAmount { get; set; } = null;
        /// <summary>
        /// Tổng tiền thuế của mức thuế tương ứng, tổng tiền thuế không có số âm. Bằng tổng của taxAmount của tất cả các itemInfo có mức thuế suất giống với mức thuế suất tổng hợp. Trong trường hợp dòng hàng hóa là chiết khấu thì trừ đi.
        /// Không cần nhập dữ liệu, nếu không truyền dữ liệu, hệ thống sẽ tự tính dựa vào taxPercentag và các itemTotalAmountWithoutTax.
        /// Nếu nhập dữ liệu cho phép chênh lệch 20000 so với giá trị hệ thống tự tính
        /// </summary>
        public decimal? taxAmount { get; set; } = null;
        /// <summary>
        /// Dùng để biểu thị tổng tiền chịu thuế của mức thuế là âm hay dương. 
        /// - null/true: Tổng tiền đánh thuế dương.Được sử dụng đối với các hàng hóa thông thường.
        /// - false: Tổng tiền đánh thuế âm, được sử dụng với hóa đơn điều chỉnh giảm hoặc hóa đơn có hàng hóa là chiết khấu mà tổng tiền của hàng hóa và chiết khấu của mức thuế là âm.
        /// </summary>
        public bool taxableAmountPos { get; set; } = true;
        /// <summary>
        /// Dùng để biểu thị tổng tiền thuế của mức thuế là âm hay dương.
        /// Giá trị của taxAmountPos luôn giống với giá trị của taxableAmountPos. <br/>
        /// - null/true: Tổng tiền thuế dương <br/>
        /// - false: Tổng tiền thuế âm <br/>
        /// </summary>
        public bool taxAmountPos { get; set; } = true;
        /// <summary>
        /// Lý do miễn giảm thuế
        /// </summary>
        public bool taxExemptionReason { get; set; }
    }
}
