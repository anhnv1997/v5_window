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
        public string WeighingTypeId { get; set; }
        public string eventInId { get; set; } = string.Empty;
        public string plateNumber { get; set; } = string.Empty;
        public string createdUtc { get; set; } = "";
        public int Weight { get; set; }
        public DateTime? createdUtcTime
        {
            get
            {
                try
                {
                    if (string.IsNullOrEmpty(createdUtc))
                    {
                        return null;
                    }
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
        public WeighingType weighingType { get; set; }
        public List<string> FileKeys { get; set; }
        public float Charge { get; set; }
        public string createdBy { get; set; }
        public string InvoiceId { get; set; }
        public string invoiceCode { get; set; }
        public string weighingTypeName { get; set; }
    }
}
