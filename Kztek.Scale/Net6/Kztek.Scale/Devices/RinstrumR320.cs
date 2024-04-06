using System;
using System.IO.Ports;
using System.Threading;
using Kztek.Scale_net6.Events;
using Kztek.Scale_net6.Interfaces;
using ErrorEventHandler = Kztek.Scale_net6.Events.ErrorEventHandler;
namespace Kztek.Scale_net6.Devices
{
    public class RinstrumR320Scale : IScale
    {
        public SerialPort serialPort;
        private bool isConnected;
        private string comPort = "COM1";
        private int baudRate = 9600;
        private int dataBits = 8;
        private int parity = 2;
        private int stopBits = 1;
        public int receivedTimeOut = 100;
        private bool isStable = true;
        public event ScaleEventHandler ScaleEvent;
        public event ErrorEventHandler ErrorEvent;
        public event DataReceivedEventHandler DataReceivedEvent;
        public string ComPort
        {
            get
            {
                return comPort;
            }
            set
            {
                comPort = value;
            }
        }
        public int BaudRate
        {
            get
            {
                return baudRate;
            }
            set
            {
                baudRate = value;
            }
        }
        public int DataBits
        {
            get
            {
                return dataBits;
            }
            set
            {
                dataBits = value;
            }
        }
        public int Parity
        {
            get
            {
                return parity;
            }
            set
            {
                parity = value;
            }
        }
        public int StopBits
        {
            get
            {
                return stopBits;
            }
            set
            {
                stopBits = value;
            }
        }
        public int ReceivedTimeOut
        {
            get
            {
                return receivedTimeOut;
            }
            set
            {
                receivedTimeOut = value;
                if (receivedTimeOut < 400) receivedTimeOut = 400;
            }
        }
        public bool IsConnected
        {
            get
            {
                return isConnected;
            }
        }

        public bool IsStable
        {
            get { return isStable; }
            set { isStable = value; }
        }

        public bool Connect()
        {
            return Connect(comPort, baudRate);
        }
        public bool Connect(string portName, int baudRate)
        {
            comPort = portName;
            this.baudRate = baudRate;
            bool result;
            try
            {
                serialPort = new SerialPort();
                serialPort.PortName = portName;
                serialPort.BaudRate = baudRate;
                serialPort.ReadBufferSize = 4096;
                serialPort.WriteBufferSize = 4096;
                serialPort.DataBits = dataBits;
                if (parity == 0)
                {
                    serialPort.Parity = System.IO.Ports.Parity.Even;
                }
                else
                {
                    if (parity == 1)
                    {
                        serialPort.Parity = System.IO.Ports.Parity.Odd;
                    }
                    else
                    {
                        if (parity == 2)
                        {
                            serialPort.Parity = System.IO.Ports.Parity.None;
                        }
                    }
                }
                if (stopBits == 1)
                {
                    serialPort.StopBits = System.IO.Ports.StopBits.One;
                }
                else
                {
                    if (stopBits == 2)
                    {
                        serialPort.StopBits = System.IO.Ports.StopBits.Two;
                    }
                }
                serialPort.ReadTimeout = -1;
                serialPort.WriteTimeout = -1;
                serialPort.DtrEnable = true;
                serialPort.RtsEnable = true;
                serialPort.Open();
                isConnected = true;
                result = true;
            }
            catch (Exception ex)
            {
                if (ErrorEvent != null)
                {
                    ErrorEvent(this, ex.ToString());
                }
                result = false;
            }
            return result;
        }
        public bool Disconnect()
        {
            bool result;
            try
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                isConnected = false;
                result = true;
            }
            catch (Exception ex)
            {
                if (ErrorEvent != null)
                {
                    ErrorEvent(this, ex.ToString());
                }
                result = false;
            }
            return result;
        }
        public void PollingStart()
        {
            try
            {
                isConnected = false;
                if (serialPort.IsOpen)
                {
                    isConnected = true;
                }
                serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
            }
            catch (Exception ex)
            {
                if (ErrorEvent != null)
                {
                    ErrorEvent(this, ex.ToString());
                }
            }
        }
        public void SignalToStop()
        {
        }
        public void PollingStop()
        {
            try
            {
                serialPort.DataReceived -= new SerialDataReceivedEventHandler(serialPort_DataReceived);
            }
            catch (Exception ex)
            {
                if (ErrorEvent != null)
                {
                    ErrorEvent(this, ex.ToString());
                }
            }
        }
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            isConnected = true;
            string text = ReadData();
            if (DataReceivedEvent != null)
            {
                DataReceivedEvent(this, text);
            }
            ParseData(text);
        }
        private void ParseData(string dataReceived)
        {
            if (ScaleEvent != null)
            {
                try
                {
                    int num = dataReceived.LastIndexOf('G');
                    if (num < 0)
                    {
                        num = dataReceived.LastIndexOf('M');
                    }
                    if (num >= 8)
                    {
                        string s = dataReceived.Substring(num - 7, 7);
                        int gross = 0;
                        ScaleEventArgs scaleEventArgs = new ScaleEventArgs();
                        if (int.TryParse(s, out gross))
                        {
                            scaleEventArgs.Gross = gross;
                        }
                        else
                        {
                            scaleEventArgs.Gross = 0;
                        }
                        ScaleEvent(this, scaleEventArgs);
                    }
                }
                catch (Exception ex)
                {
                    if (ErrorEvent != null)
                    {
                        ErrorEvent(this, ex.ToString());
                    }
                }
            }
        }
        private string ReadData()
        {
            string result;
            try
            {
                Thread.Sleep(receivedTimeOut);
                string text = "";
                while (serialPort.BytesToRead > 0)
                {
                    char c = Convert.ToChar(serialPort.ReadByte());
                    text += c;
                }
                result = text;
            }
            catch (Exception ex)
            {
                if (ErrorEvent != null)
                {
                    ErrorEvent(this, ex.ToString());
                }
                result = "";
            }
            return result;
        }
        public bool TestConnection()
        {
            return serialPort != null && serialPort.IsOpen;
        }
    }
}
