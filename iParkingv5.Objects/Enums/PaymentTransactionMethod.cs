using System.ComponentModel;


/// <summary>
/// Phương thức thanh toán:
/// CashAtParkingBooth, CashAtKiosk, etc...
/// </summary>
public enum PaymentTransactionMethod
{
    [Description("Tiền mặt tại bốt thu phí")]
    CashAtParkingBooth,

    [Description("Tiền mặt tại Kiosk")] CashAtKiosk,

    [Description("Online qua thiết bị Payon trên Kiosk")]
    OnlineAtKioskViaPayonDevice,

    [Description("Online qua Payon API trên Kiosk")]
    OnlineViaPayonApi,

    [Description("Sử dụng voucher trên Kiosk")]
    ConsumeVoucherAtKiosk,

    [Description("Sử dụng voucher tại bốt thu phí")]
    ConsumeVoucherAtParkingBooth,

    [Description("QR tĩnh tại bốt thu phí")]
    OnlineViaQrAtParkingBooth,
    
    [Description("Khác")] Undefined
}