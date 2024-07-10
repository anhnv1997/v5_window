using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iParkingv5.Objects.Datas.warehouse_service
{
    public class WeighingActionDetail
    {
        public string Id { get; set; } = string.Empty;
        public int Order_by { get; set; }
        public string traffic_id { get; set; } = string.Empty;
        public string Weighing_action_id { get; set; } = string.Empty;
        public string Weighting_form_id { get; set; } = string.Empty;
        public double Weight { get; set; }
        public long Price { get; set; }
        public string User_action { get; set; } = string.Empty;
        public string User_code { get; set; } = string.Empty;
        public string Created_at { get; set; } = "";
        public string list_image { get; set; } = "";
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
