using iParkingv5.Objects.Datas.Devices;
using iParkingv5.Objects.Datas.parking;
using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.EventDatas
{
    public class EventOut
    {
        public string Id { get; set; }
        public Guid? IdentityId { get; set; }
        public string LaneId { get; set; }
        public string PlateNumber { get; set; }
        public DateTime LastPaymentUtc { get; set; }
        public long Fee { get; set; }
        public long Discount { get; set; }
        public long Paid { get; set; }
        public bool Free { get; set; }
        public bool Deleted { get; set; }
        public string CreatedUtc { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? DatetimeOut
        {
            get
            {
                try
                {
                    if (CreatedUtc.Contains("T"))
                    {
                        return DateTime.ParseExact(CreatedUtc.Substring(0, "yyyy-MM-ddTHH:mm:ss".Length), "yyyy-MM-ddTHH:mm:ss", null).AddHours(7);
                    }
                    else
                    {
                        return DateTime.Parse(CreatedUtc).AddHours(7);
                    }
                }
                catch
                {
                    return null;
                }
            }
        }
        public DateTime? UpdatedUtc { get; set; }
        public Guid? UpdatedBy { get; set; }
        public Guid? EventInIdentityId { get; set; }
        public Guid EventInLaneId { get; set; }
        public string EventInPlateNumber { get; set; }
        public DateTime EventInCreatedUtc { get; set; }
        public Guid EventInCreatedBy { get; set; }

        public IEnumerable<EventPhysicalFileMap> EventPhysicalFileMaps { get; set; }
        public ICollection<ParkingEventPaymentMap> ParkingEventPaymentMaps { get; set; }

        public Identity Identity { get; set; }
        public Lane Lane { get; set; }

        public ICollection<PaymentTransaction> PaymentTransactions { get; set; }

        public long ParkingFeeLeft()
        {
            return Math.Max(Fee - Paid - Discount, 0);
        }

        public EventOut()
        {
            PaymentTransactions = new List<PaymentTransaction>();
        }
        public Customer customer { get; set; }
        public RegisteredVehicle RegisteredVehicle { get; set; }
        public string IdentityGroupId { get; set; }
    }
}