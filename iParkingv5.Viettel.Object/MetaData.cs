using System;
using System.Collections.Generic;
using System.Text;

namespace Viettel.Object
{
    public class MetaData
    {
        /// <summary>
        /// Tên dữ liệu <br/>
        /// </summary>
        public string keyTag { get; set; }
        /// <summary>
        /// Kiểu dữ liệu gồm: text, number, date <br/>
        /// </summary>
        public string valueType { get; set; }
        /// <summary>
        /// Giá trị dữ liệu khi kiểu là date. <br/>
        /// </summary>
        public long dateValue { get; set; }
        /// <summary>
        /// Giá trị dữ liệu khi kiểu là text <br/>
        /// </summary>
        public string stringValue { get; set; }
        /// <summary>
        /// Giá trị dữ liệu khi kiểu là number <br/>
        /// </summary>
        public string numberValue { get; set; }
        /// <summary>
        /// Nhãn hiển thị của dữ liệu <br/>
        /// </summary>
        public string keyLabel { get; set; }
        /// <summary>
        /// Giá trị có bắt buộc hay không <br/>
        /// </summary>
        public bool isRequired { get; set; }
        /// <summary>
        /// Giá trị của người bán hay mua <br/>
        /// </summary>
        public bool isSeller { get; set; }
    }
}
