using iParkingv5.Objects.Datas.parking_service;
using iParkingv5.Objects.Datas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using iParkingv5.Objects.Datas.Device_service;

namespace iParkingv5.Objects.EventDatas
{
    public class EventInReport : BaseReportData
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

    }
}
