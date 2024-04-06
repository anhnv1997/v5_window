using Kztek.Scale_net6.Devices;
using Kztek.Scale_net6.Events;
using Kztek.Scale_net6.Interfaces;

namespace Kztek.Scale_net6.Objects
{
    public class ScaleController
    {
        public Action<object, string> ErrorEvent { get; set; }

        public Action<object, ScaleEventArgs> NewScaleValueReceived { get; set; }

        private IScale scale;

        private ScaleModel configs;

        internal ScaleModel Configs { get => configs; set => configs = value; }

        public int CurrentWeight { get => currentWeight; set => currentWeight = value; }

        private int currentWeight = 0;

        public ScaleController(ScaleModel scaleConfigs)
        {
            configs = scaleConfigs;
        }

        public bool ConnectToScale()
        {
            try
            {
                if (configs.Name == "KingBird")
                {
                    scale = new KingbirdScale();
                }
                else if (configs.Name == "KingBirdStandard")
                {
                    scale = new KingbirdStandardScale();
                }
                else if (configs.Name.ToLower() == "ex2001")
                {
                    scale = new EX2001Scale();
                }
                else if (configs.Name.ToLower() == "Rinstrum")
                {
                    scale = new RinstrumR320Scale();
                }
                else
                {
                    //scale = new RinstrumR320Scale();
                    scale = new D2008Scale();
                }


                scale.ReceivedTimeOut = configs.ReceiveTimeout;
                scale.DataBits = configs.DataBits;
                scale.Parity = ParityGet(configs.Parity);
                scale.StopBits = configs.StopBit;

                if (scale.Connect(configs.Comport, configs.Baudrate))
                {
                    scale.DataReceivedEvent += new DataReceivedEventHandler(scale_DataReceivedEvent);
                    scale.ScaleEvent += new ScaleEventHandler(scale_ScaleEvent);
                    scale.ErrorEvent += new Events.ErrorEventHandler(scale_ScaleErrorEvent);
                    scale.PollingStart();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DisconnectToScale()
        {
            scale.DataReceivedEvent -= new DataReceivedEventHandler(scale_DataReceivedEvent);
            scale.ScaleEvent -= new ScaleEventHandler(scale_ScaleEvent);
            scale.PollingStop();
            scale.Disconnect();
        }

        private void scale_DataReceivedEvent(object sender, string dataString)
        {
            //donothing
        }

        private void scale_ScaleEvent(object sender, ScaleEventArgs e)
        {
            currentWeight = e.Gross;
            Console.WriteLine(e.Gross.ToString());
            if (NewScaleValueReceived != null)
                NewScaleValueReceived(this, e);
        }

        private void scale_ScaleErrorEvent(object sender, string errorString)
        {
            if (errorString.Contains("port is closed"))
            {
                scale.PollingStop();
                if (scale.Connect(configs.Comport, configs.Baudrate))
                {
                    scale.PollingStart();
                }
            }
        }

        private int ParityGet(string parity)
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
