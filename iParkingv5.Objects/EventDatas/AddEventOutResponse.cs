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
        public bool OpenBarrier { get; set; }
        public string Id { get; set; }
        public Identity Identity { get; set; }
        public IdentityGroup IdentityGroup { get; set; }
        public string PlateNumber { get; set; }
        public List<string> fileKeys { get; set; }
        public bool Force { get; set; }
        public bool approve { get; set; }

        public AddEventInResponse eventIn { get; set; }

        public string lastPaymentUtc { get; set; }
        public long charge { get; set; }
        public long discount { get; set; }
        public long paid { get; set; }
        public bool free { get; set; }
        public string createdUtc { get; set; }

        public RegisteredVehicle? RegisteredVehicle { get; set; }
        public Customer? Customer { get; set; }
        public CustomerGroup? CustomerGroup { get; set; }

        public DateTime? DatetimeOut
        {
            get
            {
                try
                {
                    if (string.IsNullOrEmpty(createdUtc))
                    {
                        return null;
                    }
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

        public bool IsSuccess { get; set; } = true;
        public string message { get; set; } = string.Empty;
        public string errorCode { get; set; } = string.Empty;
        public string detailCode { get; set; } = string.Empty;
        public List<ErrorDescription> fields { get; set; } = new List<ErrorDescription>();
        public Dictionary<string, AddEventInResponse> payload { get; set; }
    }
}
