using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Reporting
{
    public class EventOutReport
    {
        //Thông tin sự kiện ra
        public string id { get; set; }
        public string eventinid { get; set; }
        public string identityId { get; set; }
        public string[] fileKeys { get; set; }
        public string lastPaymentUtc { get; set; }
        public int discount { get; set; }
        public int paid { get; set; }
        public bool free { get; set; }
        public string CustomerId { get; set; }
        public string RegisteredVehicleId { get; set; }

        //Thông tin sự kiện vào
        public string eventInIdentityName { get; set; }
        public string[] eventInFileKeys { get; set; }
        public int? eventInWeight { get; set; }


        public string eventInCreatedUtc { get; set; }
        public string createdUtc { get; set; }
        public string ParkingTime()
        {
            TimeSpan ParkingTime = (TimeSpan)(DateTime.Parse(createdUtc) - DateTime.Parse(eventInCreatedUtc))!;
            string formattedTime = "";
            if (ParkingTime.TotalDays > 1)
            {
                formattedTime = string.Format("{0} ngày {1} giờ {2} phút", ParkingTime.Days, ParkingTime.Hours, ParkingTime.Minutes);
            }
            else
            {
                formattedTime = string.Format("{0} giờ {1} phút", ParkingTime.Hours, ParkingTime.Minutes);
            }
            return formattedTime;
        }
        [JsonIgnore]
        public DateTime? DatetimeOut
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

        [JsonIgnore]
        public DateTime? DatetimeIn
        {
            get
            {
                try
                {
                    if (eventInCreatedUtc.Contains("T"))
                    {
                        return DateTime.ParseExact(eventInCreatedUtc.Substring(0, "yyyy-MM-ddTHH:mm:ss".Length), "yyyy-MM-ddTHH:mm:ss", null).AddHours(7);
                    }
                    else
                    {
                        return DateTime.Parse(eventInCreatedUtc).AddHours(7);
                    }
                }
                catch
                {
                    return null;
                }
            }
        }
        public string IdentityName { get; set; }
        public string IdentityGroupId { get; set; }
        public string identityGroupName { get; set; }
        public string eventInPlateNumber { get; set; }
        public string plateNumber { get; set; }
        public int TransactionType { get; set; }
        public string TransactionCode { get; set; }
        public int charge { get; set; }
        public string eventInCreatedBy { get; set; }
        public string createdBy { get; set; }
        public string eventInLaneName { get; set; }
        public string laneId { get; set; }

        public string InvoiceTemplate { get; set; }
        public string InvoiceNo { get; set; }

        public string note { get; set; }
        public string thirdpartynote { get; set; }
        public int FirstWeight { get; set; }
        public int LastWeight { get; set; }
        public int Weight { get; set; }
    }

}
