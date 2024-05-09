using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Datas.VETC
{
    public class CheckPaymentData
    {
        public string transactionId { get; set; } = "";
        public string transId { get; set; } = "";
        public string status { get; set; } = "";
        public string paymentMethod { get; set; } = "";

    }
}
