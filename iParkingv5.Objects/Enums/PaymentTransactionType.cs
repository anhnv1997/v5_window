using System.ComponentModel;

/// <summary>
/// Loại hình:
/// Thanh toán thẻ tháng, phạt thanh toán thẻ tháng
/// </summary>
public enum PaymentTransactionType
{
    [Description("Phí vé lượt thông thường")]
    Normal,

    [Description("Phí vé tháng")] Monthly,

    [Description("Vé tháng gửi quá giờ")] PenaltyForMonthly,

    [Description("Phí vé lượt phát sinh sau khi đã thanh toán trước")]
    AdditionalChargeOnPrepayment,

    [Description("Tiền phạt")] Penalty,

    [Description("Khác")] Other
}