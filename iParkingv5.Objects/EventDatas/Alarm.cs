using iParkingv6.Objects.Datas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iParkingv5.Objects.EventDatas
{
    public class Alarm
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public DateTime? Date { get; set; }

        public string CardNumber { get; set; }

        public string CardNo { get; set; }
        public string Plate { get; set; }

        public string UserId { get; set; }
        public string LaneId { get; set; }
        public ICollection<Images> Images { get; set; }
        public string AlarmCode { get; set; }
        public string AlarmDescription { get; set; }
        public string Description { get; set; }
        public long RowNumber { get; set; }
        public string UserName { get; set; }
        public string LaneName { get; set; }
        public string VehicleType { get; set; }

        public string GetJsonImages()
        {
            return JsonConvert.SerializeObject(Images.Select(n => n.FilePath).ToArray());
        }
    }
}