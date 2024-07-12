using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Datas.warehouse_service
{
    public class WarehouseType
    {
        public enum EmTransactionType
        {
            InBound,
            OutBound,
            Overweight,
            Other
        }
        public static string GetTransactionTypeStr(int transactionType)
        {
            switch (transactionType)
            {
                case (int)EmTransactionType.InBound:
                    return "Nhập";
                case (int)EmTransactionType.OutBound:
                    return "Xuất";
                case (int)EmTransactionType.Overweight:
                    return "Sang tải";
                default:
                    return "khác";
            }
        }
    }

}
