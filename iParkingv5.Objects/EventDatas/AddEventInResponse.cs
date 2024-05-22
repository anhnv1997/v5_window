using iParkingv5.Objects.Datas;
using iParkingv6.Objects.Datas;
using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.EventDatas
{
    public class AddEventInResponse
    {
        public string Id { get; set; }
        public string PlateNumber { get; set; }
        public bool OpenBarrier { get; set; }
        public Identity identity { get; set; }
        public IdentityGroup identityGroup { get; set; }
        public List<string> fileKeys { get; set; }
        public string createdUtc { get; set; }
        public Lane lane { get; set; }
        public DateTime? DatetimeIn
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
        public List<ErrorDescription> fields { get; set; } = null;
        public string Note { get; set; }
        public string thirdPartyNote { get; set; }
        //public RegisteredVehicle registeredVehicle { get; set; }
        //public Customer customer { get; set; }
    }
    public class ErrorDescription
    {
        public string name { get; set; }
        public string errorCode { get; set; }
        public override string ToString()
        {
            if (name.ToUpper() == "PlateNumber".ToUpper())
            {
                if (errorCode == "ERROR.ENTITY.VALIDATION.FIELD_NOT_MATCH_WITH_EVENT_IN")
                {
                    return "Biển số vào ra không khớp".ToUpper();
                }
            }
            if (name.ToUpper() == "vehicle".ToUpper())
            {
                if (errorCode == "ERROR.ENTITY.VALIDATION.FIELD_NOT_FOUND")
                {
                    return "Biển Số Không Hợp Lệ".ToUpper();
                }
            }
            else if (name.ToUpper() == "IdentityGroup".ToUpper())
            {
                if (errorCode == "ERROR.ENTITY.VALIDATION.FIELD_NOT_HAVE_PERMISSION_TO_USE_THIS_LANE")
                {
                    return "Nhóm thẻ không được phép sử dụng với làn".ToUpper();
                }
            }
            else if (name.ToUpper() == "EventIn".ToUpper())
            {
                if (errorCode == "ERROR.ENTITY.VALIDATION.FIELD_DUPLICATED")
                {
                    return "Xe đã vào bãi".ToUpper();
                }
                else if (errorCode == "ERROR.ENTITY.VALIDATION.FIELD_NOT_FOUND")
                {
                    return "Xe chưa vào bãi".ToUpper();
                }
                else if (errorCode == "ERROR.ENTITY.VALIDATION.FIELD_NOT_APPROVED_FOR_EXIT")
                {
                    return "Xe chưa được phép ra".ToUpper();
                }
            }
            return base.ToString();
        }
    }
}
