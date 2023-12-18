using static Misa.Object.InvoiceFileDownloadType;

namespace Misa.Object
{
    public static class ApiUrlManagement
    {
        public static string baseUrl = string.Empty;
        public static string companyTaxCode = string.Empty;
        public static string username = string.Empty;
        public static string password = string.Empty;
        public static string appId = string.Empty;
        public static string receiveInvoiceLink = string.Empty;
        #region: Login
        public static string GetToken => $"{baseUrl}/auth/token";
        #endregion: End Login

        #region: Company
        public static string GetCompanyInfor => $"{baseUrl}/company";
        #endregion: End Company

        #region: Invoice
        public static string GetInvoiceNotHaveCodeTemplate => $"{baseUrl}/itg/InvoicePublishing/templates";
        public static string GetInvoiceHaveCodeTemplate => $"{baseUrl}/code/itg/InvoicePublishing/templates";

        //Mẫu phiếu/vé
        public static string GetTicketUrl => $"{baseUrl}/code/invoicepublishing/tickettemplates?invyear=2023";

        //--Phát hành hóa đơn
        public static string PostCreateInvoicePublishingUrl(bool IsInvoiceWithCode)
        {
            if (IsInvoiceWithCode)
                return $"{baseUrl}/code/itg/invoicepublishing/createinvoice";
            return $"{baseUrl}/itg/invoicepublishing/createinvoice";
        }
        public static string PostInvoicePublishingUrl(bool IsInvoiceWithCode)
        {
            if (IsInvoiceWithCode)
                return $"{baseUrl}/code/itg/invoicepublishing";
            return $"{baseUrl}/itg/invoicepublishing";
        }
        public static string PostInvoicePublishingHSMUrl(bool IsInvoiceWithCode)
        {
            if (IsInvoiceWithCode)
                return $"{baseUrl}/code/itg/invoicepublishing/publishhsm";
            return $"{baseUrl}/itg/invoicepublishing/publishhsm";
        }

        //--Kiểm tra trạng thái hóa đơn
        public static string GetInvoiceStatusUrl(bool IsInvoiceWithCode)
        {
            if (IsInvoiceWithCode)
                return $"{baseUrl}/code/itg/invoicepublished/invoicestatus";
            return $"{baseUrl}/itg/invoicepublished/invoicestatus";
        }
        //--Tải hóa đơn
        public static string PostDownloadInvoiceUrl(bool IsInvoiceWithCode, Em_FileDownloadType fileDownloadType)
        {
            if (IsInvoiceWithCode)
                return $"{baseUrl}/code/itg/invoicepublished/invoicestatus?downloadDataType=" + InvoiceFileDownloadType.GetDownloadTypeStr(fileDownloadType);
            return $"{baseUrl}/itg/invoicepublished/invoicestatus?downloadDataType=" + InvoiceFileDownloadType.GetDownloadTypeStr(fileDownloadType);
        }
        //--Chuyển đổi hóa đơn giấy
        public static string ConvertVoucherPaper(bool IsInvoiceWithCode)
        {
            if (IsInvoiceWithCode)
                return $"{baseUrl}/code/itg/invoicepublished/voucher-paper";
            return $"{baseUrl}/itg/invoicepublished/voucher-paper";
        }
        //--Xem hóa đơn
        public static string GetLinkViewUrl()
        {
            return $"{baseUrl}/invoicepublished/linkview";
        }

        //--Gửi hóa đơn
        public static string PostSendInvoiceToCustomer()
        {
            return $"{baseUrl}/itg/emails";
        }

        //--Hủy hóa đơn
        public static string CancelInvoice(bool IsInvoiceWithCode)
        {
            if (IsInvoiceWithCode)
                return $"{baseUrl}/code/itg/invoicepublished/cancel";
            return $"{baseUrl}/itg/invoicepublished/cancel";
        }
        #endregion: End Invoice
    }
}
