namespace Misa.Object
{
    public enum InvoiceType
    {
        HD_GTVT = 1,
        HD_BAN_HANG = 2,
        PXK_VanChuyenNoiBo = 6,
    }


    public class CQT_TYPE
    {
        public enum EM_CQT_Type
        {
            KHONG_MA_CQT,
            CO_MA_CQT
        }

        public static string GetCQTType(EM_CQT_Type CQT_Type)
        {
            switch (CQT_Type)
            {
                case EM_CQT_Type.KHONG_MA_CQT: return "K";
                case EM_CQT_Type.CO_MA_CQT: return "C";
                default: return string.Empty;
            }
        }
    }

    #region: Invoice
    public enum Em_ItemType
    {
        HHDV = 1,
        KhuyenMai = 2,
        ChietKhau = 3,
        GhiChu = 4,
    }

    public enum Em_SignType
    {
        Direct,
        File,
        HSM,
        Server
    }
    #endregion: End Invoice

    public enum Em_SaveInvoiceSatus : int
    {
        /// <summary>
        /// Thất bại
        /// </summary>
        Failed = 0,

        /// <summary>
        /// Thành công
        /// </summary>
        Successed = 1
    }

    /// <summary>
    /// Loại hóa đơn
    /// </summary>
    public enum Em_InvoiceReferenceType : int
    {
        /// <summary>
        /// Hóa đơn gốc
        /// </summary>
        Original = 0,

        /// <summary>
        /// Hóa đơn thay thế
        /// </summary>
        Replacement = 1,

        /// <summary>
        /// Hóa đơn điều chỉnh
        /// </summary>
        Adjustment = 2
    }

    /// <summary>
    /// Trạng thái thông báo sai sót
    /// </summary>
    public enum Em_SendToTaxStatus : int
    {
        /// <summary>
        /// chưa gửi CQT
        /// </summary>
        NotSend = 0,

        /// <summary>
        /// Đã gửi CQT
        /// </summary>
        SentToTax = 1,

        /// <summary>
        /// CQT Tiếp nhận
        /// </summary>
        Received = 2,

        /// <summary>
        /// CQT không tiếp nhận
        /// </summary>
        UnReceived = 3,

        /// <summary>
        /// Gửi lỗi
        /// </summary>
        SendError = 4
    }

    public class InvoiceFileDownloadType
    {
        public enum Em_FileDownloadType
        {
            XML,
            PDF,
            ZIP
        }

        public static string GetDownloadTypeStr(Em_FileDownloadType em_FileDownloadType)
        {
            return em_FileDownloadType.ToString().ToLower();
        }
    }

    /// Trạng thái gửi hóa đơn
    /// </summary>
    public enum Em_SendInvoiceStatus : int
    {
        /// <summary>
        /// Chưa gửi
        /// </summary>
        NotSend = 0,

        /// <summary>
        /// Đang gửi
        /// </summary>
        Sending = 1,

        /// <summary>
        /// Gửi lỗi
        /// </summary>
        SendError = 2,

        /// <summary>
        /// Đã gửi
        /// </summary>
        Sent = 3
    }
}
