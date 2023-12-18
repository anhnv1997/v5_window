using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Object
{
    public class OperationResult
    {
        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        public object Data { get; set; } =  string.Empty;

        /// <summary>
        /// Trạng thái (thành công = true)
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Mã lỗi
        /// </summary>
        public string ErrorCode { get; set; } = string.Empty;

        /// <summary>
        /// Thông báo: thường là thông báo lỗi
        /// </summary>
        public List<string> Errors { get; set; } = new List<string>();

        /// <summary>
        /// Dữ liệu cấu hình riêng nếu có
        /// </summary>
        public string CustomData { get; set; } = string.Empty;
    }
}
