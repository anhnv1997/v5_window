using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.system
{
    public class CompanyInfo
    {
        public string id { get; set; }
        public string companyName { get; set; }
        public string companyAddress { get; set; }
        public string companyTelephone { get; set; }
        public string companyTax { get; set; }
        public DateTime createdUtc { get; set; }
        public DateTime updatedUtc { get; set; }
    }
}
