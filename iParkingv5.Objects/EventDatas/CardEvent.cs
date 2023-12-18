using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using iParkingv5.Objects.Datas;
using iParkingv6.Objects.Datas;
using Newtonsoft.Json;

namespace iParkingv5.Objects.EventDatas
{
    public class CardEvent
    {
        #region Table Fields

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string EventCode { get; set; }
        public string CardNumber { get; set; }

        public DateTime? DateTimeIn { get; set; }

        public DateTime? DateTimeOut { get; set; }

        public List<Images> ImagesIn { get; set; }
        public List<Images> ImagesOut { get; set; }
        public string LaneIdIn { get; set; }
        public string LaneIdOut { get; set; }
        public string UserIdIn { get; set; }
        public string UserIdOut { get; set; }
        public string PlateIn { get; set; }

        public string PlateOut { get; set; }
        public string RegisteredPlate { get; set; }
        public decimal Moneys { get; set; }
        public string CardGroupId { get; set; }
        public string VehicleGroupId { get; set; }
        public string CustomerGroupId { get; set; }
        public string CustomerName { get; set; }
        public bool IsBlackList { get; set; }
        public bool IsFree { get; set; }
        public bool IsDelete { get; set; }
        public string FreeType { get; set; }
        public string CardNo { get; set; }
        public string Description { get; set; }
        public string PaperTicketNumber { get; set; } = "";
        public bool IsIncludePaperTicket { get; set; } = false;
        public string UnsignPlateIn =>
            string.IsNullOrEmpty(PlateIn) ? string.Empty : Regex.Replace(PlateIn, "[^a-zA-Z0-9]", "");
        public string UnsignPlateOut =>
            string.IsNullOrEmpty(PlateOut)
                ? string.Empty
                : Regex.Replace(PlateOut, "[^a-zA-Z0-9]", "");
        public long FeePaid { get; set; } = 0;
        public long Discount { get; set; } = 0;
        public List<string> PaymentTransactions { get; set; }

        /// <summary>
        /// list<VoucherId> áp dụng cho sự kiện này
        /// </summary>
        public List<string> AppliedVoucher { get; set; }

        public List<VoucherTypeBaseInfo> AppliedVoucherType { get; set; }

        public DateTime LastPaymentTime { get; set; } = DateTime.Now;

        public string Token { get; set; }

        #endregion

        #region Non Table Fields for Report + excel

        public string InUserName { get; set; } = null;

        public string InLaneName { get; set; } = null;

        public string OutUserName { get; set; } = null;

        public string OutLaneName { get; set; } = null;

        public string CustomerGroupName { get; set; } = null;
        public string CardGroupName { get; set; } = null;
        public string VehicleGroupName { get; set; } = null;
        public int RowIndex { get; set; } = 0;
        public long ParkingDurationMinutes =>
            DateTimeOut == null || DateTimeIn == null
                ? 0
                : (long)(DateTimeOut.Value - DateTimeIn.Value).TotalMinutes;

        #endregion

        public long ParkingFeeLeft()
        {
            return Math.Max((long)Moneys - FeePaid - Discount, 0);
        }
        public string GetJsonImages()
        {
            var res = new List<string>();
            res.AddRange(ImagesIn.Select(n => n.FilePath));

            if (ImagesOut?.Count > 0)
                res.AddRange(ImagesOut.Select(n => n.FilePath));

            return JsonConvert.SerializeObject(res);
        }
        public void RemoveDuplicatedTransaction()
        {
            if (PaymentTransactions != null && PaymentTransactions.Any())
            {
                PaymentTransactions = PaymentTransactions.Distinct().ToList();
            }
        }
    }
}