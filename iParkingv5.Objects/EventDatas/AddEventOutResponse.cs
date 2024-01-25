using iParkingv5.Objects.Datas;
using iParkingv6.Objects.Datas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using static iParkingv5.Objects.ApiInternalErrorMessages;

namespace iParkingv5.Objects.EventDatas
{
    public class AddEventOutResponse
    {
        public string Id { get; set; }
        public string identityId { get; set; }
        public string laneId { get; set; }
        public string plateNumber { get; set; }
        public List<string> fileKeys { get; set; }
        
        public string eventInIdentityId { get; set; }
        public string eventInLaneId { get; set; }
        public string eventInPlateNumber { get; set; }
        public string eventInCreatedUtc { get; set; }
        public string eventInCreatedBy { get; set; }
        public List<string> eventInFileKeys { get; set; }
       
        public string lastPaymentUtc { get; set; }
        public long charge { get; set; }
        public long discount { get; set; }
        public long paid { get; set; }
        public bool free { get; set; }
        public string createdUtc { get; set; }
        [JsonIgnore]
        public string ErrorMessage { get; set; }

        public bool OpenBarrier { get; set; }
        public int AbnormalCode { get; set; }
        public RegisteredVehicle? RegisteredVehicle { get; set; }
        public Customer? Customer { get; set; }
        public CustomerGroup? CustomerGroup { get; set; }

        public Identity? Identity { get; set; }
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

    }
}
