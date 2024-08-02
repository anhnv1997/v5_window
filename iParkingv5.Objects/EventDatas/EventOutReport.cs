using iParkingv5.Objects.Datas.Device_service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.EventDatas
{
    public class EventOutReport : BaseReportData
    {
        public EventInReport EventIn { get; set; }
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
        public long Charge { get; set; }
    }
}
