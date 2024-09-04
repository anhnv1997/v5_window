using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Datas.ThirtParty.Hanet
{
    public class HANETFaceData
    {
        public string person_id { get; set; }
        public string person_name { get; set; }
        public int person_type { get; set; }
        public int mask { get; set; }
        public int date_time { get; set; }
        public string time { get; set; }
        public string msg_id { get; set; }
        public string image { get; set; }
        public string camera_id { get; set; }
        public string aliasID { get; set; }
    }

    public class HANETPlateData
    {
        public string code_result { get; set; }
        public string event_type { get; set; }
        public int date_time { get; set; }
        public string time { get; set; }
        public string msg_id { get; set; }
        public string image { get; set; }
        public string camera_id { get; set; }
        public string leave { get; set; }
    }
}
