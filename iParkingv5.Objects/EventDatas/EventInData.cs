using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Datas.Device_service;
using iParkingv5.Objects.Datas.parking_service;
using System;
using System.Collections.Generic;
using System.Text;
using static iParkingv5.Objects.Enums.ParkingImageType;

namespace iParkingv5.Objects.EventDatas
{
    public class EventInData : BaseEventData
    {
        public DateTime? DateTimeIn
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
        public long Charge { get; set; }
        public EventInData()
        {

        }

        public EventInData(EventInReport reportData)
        {
            this.Id = reportData.Id;
            this.PlateNumber = reportData.PlateNumber;
            this.Note = reportData.Note;
            this.CreatedBy = reportData.CreatedBy;
            this.CreatedUtc = reportData.CreatedUtc;
            this.Identity = reportData.Identity;
            this.IdentityGroup = reportData.IdentityGroup;
            this.images = reportData.images;
            this.OpenBarrier = reportData.OpenBarrier;
            this.vehicle = reportData.vehicle;
            this.customer = reportData.customer;
            this.OpenBarrier = reportData.OpenBarrier;
        }
    }
}
