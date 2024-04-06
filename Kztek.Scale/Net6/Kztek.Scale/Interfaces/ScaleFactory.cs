using Kztek.Scale_net6.Devices;
using Kztek.Scale_net6.Objects;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kztek.Scale_net6.Objects.ScaleType;

namespace Kztek.Scale_net6.Interfaces
{
    public static class ScaleFactory
    {
        public static IScale? CreateScaleController(ScaleConfig scaleModel)
        {
            IScale? scale = null;
            switch (scaleModel.ScaleType)
            {
                case EmScaleType.KingBird:
                    scale = new KingbirdScale();
                    break;
                case EmScaleType.KingBirdStandard:
                    scale = new KingbirdStandardScale();
                    break;
                case EmScaleType.Ex2001:
                    scale = new EX2001Scale();
                    break;
                case EmScaleType.Rinstrum:
                    scale = new RinstrumR320Scale();
                    break;
                case EmScaleType.D2008:
                    scale = new D2008Scale();
                    break;
                default:
                    break;
            }
            if (scale != null)
            {
                scale.ComPort = scaleModel.Comport;
                scale.BaudRate = scaleModel.Baudrate;
                scale.ReceivedTimeOut = scaleModel.ReceiveTimeout;
                scale.DataBits = scaleModel.DataBits;
                scale.Parity = 2;
                scale.StopBits = scaleModel.StopBit;
            }

            return scale;
        }
        private static int ParityGet(string parity)
        {
            if (parity == "Even")
                return 0;
            if (parity == "Odd")
                return 1;
            else
                return 2;
        }
    }
}
