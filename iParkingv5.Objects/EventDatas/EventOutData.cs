using iParkingv5.Objects.Datas.Device_service;
using iParkingv5.Objects.Datas.parking_service;
using System;
using System.Collections.Generic;
using System.Text;
using static iParkingv5.Objects.Enums.ParkingImageType;

namespace iParkingv5.Objects.EventDatas
{
    public class EventOutData
    {
        public string Id { get; set; }
        public string PlateNumber { get; set; }
        public string createdBy { get; set; }
        public string createdUtc { get; set; }
        public Lane Lane { get; set; }
        public Identity Identity { get; set; }
        public Identity IdentityGroup { get; set; }
        public bool OpenBarrier { get; set; }
        public List<ErrorDescription> fields { get; set; } = null;
        public bool IsSuccess { get; set; } = true;
        public string message { get; set; } = string.Empty;
        public string errorCode { get; set; } = string.Empty;
        public string detailCode { get; set; } = string.Empty;
        public Dictionary<EmParkingImageType, ImageData> images { get; set; }
        public EventInData eventIn { get; set; }
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
        public int charge { get; set; }
    }

}
