using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Reporting
{
    public class EventInReport
    {
        public string id { get; set; }
        public string identityId { get; set; }
        public string identityCode { get; set; }
        public string identityName { get; set; }

        public string laneId { get; set; }
        public string plateNumber { get; set; }
        public int status { get; set; }
        public object lastPaymentUtc { get; set; }
        public int charge { get; set; }
        public int paid { get; set; }
        public int discount { get; set; }
        public string createdUtc { get; set; }
        public string createdBy { get; set; }
        public List<string> fileKeys { get; set; }
        [JsonIgnore]
        public DateTime? DatetimeIn
        {
            get
            {
                try
                {
                    if (createdUtc.Contains("T"))
                    {
                        return DateTime.ParseExact(createdUtc.Substring(0, "yyyy-MM-ddTHH:mm:ss".Length), "yyyy-MM-ddTHH:mm:ss", null).AddHours(7);
                    }
                    else
                    {
                        return DateTime.Parse(createdUtc).AddHours(7);
                    }
                }
                catch
                {
                    return null;
                }
            }
        }
        public string IdentityGroupId { get; set; }
        public string CustomerId { get; set; }
        public string RegisteredVehicleId { get; set; }
        public string CheckOutValidationStatus { get; set; }

        public string note { get; set; }
        public string thirdpartynote { get; set; }

        public int TransactionType { get; set; }
        public string TransactionCode { get; set; }
        public int FirstWeight { get; set; }
        public int LastWeight { get; set; }
        public int? Weight { get; set; }
    }

}
