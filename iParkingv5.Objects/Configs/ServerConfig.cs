using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Configs
{
    public class ServerConfig
    {
        public string ParkingServerUrl { get; set; } = string.Empty;
        public string MinioServerUrl { get; set; } = string.Empty;
        public string MinioServerUsername { get; set; } = string.Empty;
        public string MinioServerPassword { get; set; } = string.Empty;
    }
}
