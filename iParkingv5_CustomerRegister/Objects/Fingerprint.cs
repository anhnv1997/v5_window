using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iParkingv5_CustomerRegister.Objects
{
    public class Fingerprint
    {
        public string Id { get; set; } = string.Empty;
        public string FingerId { get; set; } = string.Empty;
        public string FingerData { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public static Fingerprint? GetFingerByFingerId(List<Fingerprint> fingerprints, string fingerId)
        {
            Fingerprint? fingerprint = (from Fingerprint finger in fingerprints
                                        where finger.FingerId.Equals(fingerId,StringComparison.CurrentCultureIgnoreCase)
                                        select finger).FirstOrDefault();
            return fingerprint;
        }
    }
}
