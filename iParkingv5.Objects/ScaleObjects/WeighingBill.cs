using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iParkingv5.Objects.ScaleObjects
{
    public class WeighingBill
    {
        public string Id { get; set; } = string.Empty;
        public int Guid_id { get; set; }
        public string Weighing_action_id { get; set; } = string.Empty;
        public string Weighing_action_detail_id { get; set; } = string.Empty;
        public string Number_of_bill { get; set; } = string.Empty;
        public string code_of_bill { get; set; }
        public string Lookup_code { get; set; }
        public string First_time { get; set; } = string.Empty;
        public string Last_time { get; set; } = string.Empty;
        public string Response_data { get; set; } = string.Empty;
        public string Created_at { get; set; } = "";
        public DateTime? CreatedAtTime
        {
            get
            {
                try
                {
                    if (string.IsNullOrEmpty(Created_at))
                    {
                        return null;
                    }
                    if (Created_at.Contains("T"))
                    {
                        return DateTime.ParseExact(Created_at.Substring(0, "yyyy-MM-ddTHH:mm:ss".Length), "yyyy-MM-ddTHH:mm:ss", null).AddHours(7);
                    }
                    else
                    {
                        return DateTime.Parse(Created_at).AddHours(7);
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
