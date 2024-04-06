using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iParkingv5.Objects.ScaleObjects
{
    public class WeighingAction
    {
        public string Id { get; set; } = string.Empty;
        public int Code { get; set; } = 0;
        public string Traffic_id { get; set; } = string.Empty;
        public string plate_number { get; set; } = string.Empty;
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
