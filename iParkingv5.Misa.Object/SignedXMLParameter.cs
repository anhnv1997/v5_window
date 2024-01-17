using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Object
{
    /// <summary>
    /// Tham số thực hiện ký điện tử
    /// </summary>
    public class SignedXMLParameter
    {
        /// <summary>
        /// Mã PIN chữ ký số
        /// </summary>
        public string PinCode { get; set; }

        /// <summary>
        /// Nội dung hóa đơn
        /// </summary>
        public string XmlContent { get; set; }
    }
}
