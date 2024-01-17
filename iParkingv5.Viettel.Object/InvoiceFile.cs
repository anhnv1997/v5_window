namespace Viettel.Object
{
    /// <summary>
    /// Các file đính kèm khi lập hóa đơn dạng 
    /// </summary>
    public class invoiceFile
    {
        /// <summary>
        /// Nội dung file dạng chuỗi base64 
        /// </summary>
        public string fileContent { get; set; }
        /// <summary>
        /// Loại file
        ///-1: bảng kê(Cho phép định dạng xlsx)
        /// 2: biên bản thỏa thuận(Cho phép định dạng .doc, .docx, .pdf, .png, .jpg)
        /// </summary>
        public int fileType { get; set; }
        /// <summary>
        /// Định dạng file theo từng loại tương ứng fileType
        /// </summary>
        public string fileExtension { get; set; }
    }
}
