using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iParking.ConfigurationManager.Enums
{
    public class ConfigurationMode
    {
        [Flags]
        public enum EmConfigurationMode
        {
            ALL = 0,
            Database = 1,
            LPR = 2,
            KzAPI = 4,
            CustomerApi = 8,
            ParkingStandalone = 16,
            ParkingAsClient = 32,
        }
    }
}
