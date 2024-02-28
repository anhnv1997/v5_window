using iParkingv6.Objects.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iParkingv5_CustomerRegister.Objects
{
    public class FingerControlUnit
    {
        public string Id { get; set; } = string.Empty;
        public string FingerId { get; set; } = string.Empty;
        public string ControlUnitId { get; set; } = string.Empty;
        public string ControlUnitUserId { get; set; } = string.Empty;

        public FingerControlUnit(string id, string fingerId, string controlUnitId, string controlUnitUserId)
        {
            Id = id;
            FingerId = fingerId;
            ControlUnitId = controlUnitId;
            ControlUnitUserId = controlUnitUserId;
        }
        public static List<Fingerprint> GetFingerPrintsByControlUnitId(List<FingerControlUnit> fingerControlUnits, List<Fingerprint> fingerprints, string controlUnit)
        {
            List<string> fingerIds = (from FingerControlUnit fingerControlUnit in fingerControlUnits
                                      where fingerControlUnit.ControlUnitUserId.Equals(controlUnit, StringComparison.CurrentCultureIgnoreCase)
                                      select fingerControlUnit.Id.ToLower()).ToList();
            List<Fingerprint> _fingerprints = (from fingerprint in fingerprints
                                               where fingerIds.Contains(fingerprint.Id.ToLower())
                                               select fingerprint).ToList();
            fingerIds.Clear();
            GC.Collect();
            return _fingerprints;
        }
        public static Bdk? GetCustomerByFingerId(List<FingerControlUnit> fingerControlUnits, List<Bdk> bdks, string fingerId)
        {
            List<string> bdkIds = (from FingerControlUnit fingerControlUnit in fingerControlUnits
                                   where fingerControlUnit.FingerId.Equals(fingerId, StringComparison.CurrentCultureIgnoreCase)
                                   select fingerControlUnit.ControlUnitId.ToLower()).ToList();
            Bdk? _bdk = (from Bdk bdk in bdks
                         where bdkIds.Contains(bdk.Id)
                         select bdk).FirstOrDefault();
            bdkIds.Clear();
            return _bdk;
        }
        public static FingerControlUnit? GetFingerControlUnit(List<FingerControlUnit> fingerControlUnits, string fingerId, string controlUnitId)
        {
            return (from FingerControlUnit fingerControlUnit in fingerControlUnits
                    where fingerControlUnit.ControlUnitId.Equals(controlUnitId, StringComparison.CurrentCultureIgnoreCase)
                       && fingerControlUnit.FingerId.Equals(fingerId, StringComparison.CurrentCultureIgnoreCase)
                    select fingerControlUnit).FirstOrDefault();
        }
    }
}
