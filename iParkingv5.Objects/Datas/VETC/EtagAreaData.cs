using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Datas.VETC
{
    public  class EtagAreaData
    {
        public string etag { get; set; } = "";
        public long presentAt { get; set; } = 0;
        public long lastPresent { get; set; } = 0;
        public string laneCode { get; set; } = "";

    }
}
