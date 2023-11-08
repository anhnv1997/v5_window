using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv6.Objects.Datas
{
    public class ActiveCard
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public DateTime? Date { get; set; }
        public string CardNo { get; set; }
        public string CardNumber { get; set; }
        public string Plate { get; set; }
        public DateTime? OldExpireDate { get; set; }
        public int Days { get; set; }
        public DateTime? NewExpireDate { get; set; }
        public string CardGroupId { get; set; }
        public string CustomerId { get; set; }
        public string UserId { get; set; }
        public int FeeLevel { get; set; }
        public bool IsDelete { get; set; }
        public string ContractCode { get; set; }
        public bool IsTransferPayment { get; set; }
        public string OrderId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerGroupName { get; set; }
        public string UserName { get; set; }
        public string CardGroupName { get; set; }
    }
}
