using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iParking.ConfigurationManager.Enums
{
    public class AppMode
    {
        public enum EmAppMode
        {
            Parking,
            PGS,
            Other
        }

        public ConfigurationMode.EmConfigurationMode GetConfigurationMode(EmAppMode mode)
        {
            switch (mode)
            {
                case EmAppMode.Parking:
                    return ConfigurationMode.EmConfigurationMode.ALL;
                case EmAppMode.PGS:
                    return ConfigurationMode.EmConfigurationMode.ALL;
                case EmAppMode.Other:
                    return ConfigurationMode.EmConfigurationMode.Database | ConfigurationMode.EmConfigurationMode.CustomerApi | ConfigurationMode.EmConfigurationMode.KzAPI;
                default:
                    return ConfigurationMode.EmConfigurationMode.Database;
            }
        }
    }
}
