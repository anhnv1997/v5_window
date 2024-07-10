using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Datas.payment_service
{
    public class VouchersAvailable
    {
        public string Id { get; set; }
        public string GroupId { get; set; }
        public string Code { get; set; }
        public VoucherTypeBaseInfo VoucherType { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string User { get; set; }
        public BaseVoucherObject ReleaseUnit { get; set; }
        public int CodeFormat { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Token { get; set; }
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Hình thức phát hành voucher:
        /// [0] - Fixed số lượng, phát hành bởi chính hệ thống này
        /// [1] - sử dụng trong ngày, được phát hành bởi đơn vị khác nhưng chịu sự quản lý bởi hệ thống này (format, price,.. voucher)
        /// [2] - Bên thứ 3, không thuộc sự quản lý của hệ thống
        /// </summary>
        public int VoucherReleaseType { get; set; }
        public int ReleaseQuantity { get; set; }
        public int ConsumptionQuantity { get; set; }
    }
}
