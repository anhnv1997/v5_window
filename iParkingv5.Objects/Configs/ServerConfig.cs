using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Configs
{
    public class ServerConfig
    {
        public string ParkingServerUrl { get; set; } = string.Empty;
        //Thông tin Minio Server
        public string MinioServerUrl { get; set; } = string.Empty;
        public string MinioServerUsername { get; set; } = string.Empty;
        public string MinioServerPassword { get; set; } = string.Empty;

        //Thông tin Rabbit MQ Server
        public string RabbitMqUrl { get; set; }
        public string RabbitMqUsername { get; set; }
        public string RabbitMqPassword { get; set; }

        //Thông tin MQTT Server
        public string MQTTUrl { get; set; }
        public string MQTTUsername { get; set; }
        public string MQTTPassword { get; set; }
    }
}
