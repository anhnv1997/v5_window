namespace Viettel.Object
{
    public class Payments
    {
        /// <summary>
        /// Hình thức thanh toán. Có thể không cần truyền giá trị, chỉ cần truyền paymentMethodName <br/>
        /// - Gồm các giá trị sau: <br/>
        /// 1: khi hình thức thanh toán là TM <br/>
        /// 2: khi hình thức thanh toán là CK <br/>
        /// 3: khi hình thức thanh toán là TM/CK <br/>
        /// 4: khi hình thức thanh toán là DTCN <br/>
        /// 5: khi hình thức thanh toán là KHAC <br/>
        /// 6: Khi hình thức thanh toán là Tiền mặt <br/>
        /// 7: Khi hình thức thanh toán là Chuyển khoản <br/>
        /// 8: Khi hình thức thanh toán là Tiền mặt/Chuyển khoản <br/>
        /// - Không truyền dữ liệu thì sẽ được hiểu là 5 <br/>
        /// </summary>
        public string paymentMethod { get; set; }

        /// <summary>
        /// Hình thức thanh toán chi tiết phải mapping theo paymentMethod. <br/>
        /// - Gồm các giá trị sau: <br/>
        /// TM <br/>
        /// CK <br/>
        /// TM/CK <br/>
        /// DTCN <br/>
        /// KHAC <br/>
        /// Tiền mặt <br/>
        /// Chuyển khoản <br/>
        /// Tiền mặt/Chuyển khoản <br/>
        /// - Không truyền dữ liệu thì trả về thông báo lỗi  <br/>
        /// - Được nhập free text khi paymentMethod = 5, được hiểu là hình thức thanh toán khác <br/>
        /// </summary>
        public string paymentMethodName { get; set; }
    }
}
