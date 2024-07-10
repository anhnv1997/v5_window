using iParkingv5.Objects.Datas.Devices;
using iParkingv5.Objects.Datas.parking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.EventDatas
{
    public class EventIn
    {
        public string Id { get; set; }
        public string? IdentityId { get; set; }
        public string LaneId { get; set; }
        public string PlateNumber { get; set; }
        public EventInStatus Status { get; set; } = EventInStatus.Parking;
        public DateTime? LastPaymentUtc { get; set; }
        public long Fee { get; set; }
        public long Paid { get; set; }
        public long Discount { get; set; }
        public string Note { get; set; }
        public string CreatedUtc { get; set; }
        [JsonIgnore]
        public DateTime? DatetimeIn
        {
            get
            {
                try
                {
                    if (string.IsNullOrEmpty(CreatedUtc))
                    {
                        return null;
                    }
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
        public Guid CreatedBy { get; set; }
        public string? UpdatedUtc { get; set; }
        public Guid? UpdatedBy { get; set; }

        public List<string> FileKeys { get; set; }
        public ICollection<ParkingEventPaymentMap> ParkingEventPaymentMaps { get; set; }

        public Identity Identity { get; set; }
        public Lane Lane { get; set; }

        public ICollection<PaymentTransaction> PaymentTransactions { get; set; }

        public EventIn()
        {
            PaymentTransactions = new List<PaymentTransaction>();
        }
        public Customer customer { get; set; }
        public string IdentityGroupId { get; set; }
        public RegisteredVehicle RegisteredVehicle { get; set; }
    }
}