using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kztek.Scale_net6.Objects
{
    public class ScaleModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ScaleType { get; set; }
        public string Comport { get; set; }
        public int Baudrate { get; set; }
        public int ReceiveTimeout { get; set; }
        public int DataBits { get; set; }
        public string Parity { get; set; }
        public int StopBit { get; set; }
        public bool isActive { get; set; }
        public string PcId { get; set; }
    }
}
