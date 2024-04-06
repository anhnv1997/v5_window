using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kztek.Scale_net6.Objects.ScaleType;

namespace Kztek.Scale_net6.Objects
{
    public class ScaleConfig
    {
        public EmScaleType ScaleType { get; set; }
        public string ScaleServer { get; set; }
        public string Comport { get; set; } = string.Empty;
        public int Baudrate { get; set; } = 9600;
        public int DataBits { get; set; } = 7;
        public int StopBit { get; set; } = 1;
        public int ReceiveTimeout { get; set; } = 1000;
        public bool IsUseScaleDevice { get; set; } = false;

        public ScaleConfig(EmScaleType scaleType = EmScaleType.D2008,
                           string comport = "", int baudrate = 9600,
                           int databits = 8, int stopbit = 1,
                           int receiveTimeout = 1000, bool isUseScaleDevice = false, string scaleServer = "")
        {
            this.ScaleType = scaleType;
            this.Comport = comport;
            this.Baudrate = baudrate;
            this.DataBits = databits;
            this.StopBit = stopbit;
            this.ReceiveTimeout = receiveTimeout;
            this.IsUseScaleDevice = isUseScaleDevice;
            this.ScaleServer = scaleServer;
        }

        public ScaleConfig() : this(EmScaleType.D2008, "", 9600, 8, 1, 1000, false, "")
        {

        }
        public static ScaleConfig CreateDefaultConfig()
        {
            return new ScaleConfig();
        }
    }
}
