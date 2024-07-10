using iParkingv5.Objects.Enums;
using iParkingv5.Objects.warehouse;
using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Reporting
{
    public enum EmParkingStatus
    {
        Parking = 0,
        Exited = 1,
    }
    public class SearchEventIn
    {
        public string keyword { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public DateTime FromUTC { get; set; }
        public DateTime ToUTC { get; set; }
        public List<string> laneIds { get; set; }
        public List<string> identityGroupIds { get; set; }
        public List<string> upns { get; set; }
        public bool paging { get; set; } = false;
        public PlateNumberType PlateNumberType { get; set; }
        public List<TransactionType> transactionTypes { get; set; } = new List<TransactionType>();
        public EmParkingStatus Status { get; set; } = EmParkingStatus.Parking;
    }
}
