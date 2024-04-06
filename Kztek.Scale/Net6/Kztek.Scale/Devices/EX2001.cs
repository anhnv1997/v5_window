using System;
using System.IO.Ports;
using System.Threading;
using Kztek.Scale_net6.Events;
using Kztek.Scale_net6.Interfaces;
using ErrorEventHandler = Kztek.Scale_net6.Events.ErrorEventHandler;

namespace Kztek.Scale_net6.Devices
{
    public class EX2001Scale : IScale
    {
        public SerialPort serialPort;
        private bool isConnected;
        private bool isStable = true;
        private DateTime lastTimeReceivedEvent = DateTime.Now;
        private System.Timers.Timer reconnectTimer = new System.Timers.Timer();
        private string comPort = "COM1";
        private int baudRate = 9600;
        private int dataBits = 8;
        private int parity = 2;
        private int stopBits = 1;
        public int receivedTimeOut = 500;
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

        public EX2001Scale()
        {
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

        private void reconnectTimer_Elapsed(object sender, EventArgs e)
        {
            TimeSpan timeSpan = new TimeSpan(DateTime.Now.Ticks - lastTimeReceivedEvent.Ticks);
            if (timeSpan.TotalSeconds >= 15.0)
            {
                PollingStop();
                Disconnect();
                Thread.Sleep(100);
                Connect();
                PollingStart();
                lastTimeReceivedEvent = DateTime.Now;
            }
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
            string dataString = "";
            serialPort.DiscardInBuffer();
            string dataReceived = ReadData(ref dataString);
            if (DataReceivedEvent != null)
            {
                DataReceivedEvent(this, dataString);
            }
            lastTimeReceivedEvent = DateTime.Now;
            ParseData(dataReceived);
        }
        private void ParseData(string dataReceived)
        {
            if (ScaleEvent != null)
            {
                try
                {
                    if (dataReceived.Length >= 6)
                    {
                        bool isMinusValue = false;
                        int decimalValue = 0;
                        if (dataReceived.Length == 8)
                        {
                            if (dataReceived.Contains("-"))
                            {
                                isMinusValue = true;
                            }
                            dataReceived = dataReceived.Substring(2, 6);
                        }
                        int gross = 0;
                        ScaleEventArgs scaleEventArgs = new ScaleEventArgs();
                        if (int.TryParse(dataReceived, out gross))
                        {
                            scaleEventArgs.Gross = gross;
                            scaleEventArgs.IsMinusValue = isMinusValue;
                            scaleEventArgs.DecimalValue = decimalValue;
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
        private string ReadData(ref string dataReceived)
        {
            string result;
            try
            {
                Thread.Sleep(receivedTimeOut);
                string text = "";
                while (serialPort.BytesToRead > 0)
                {
                    int num = serialPort.ReadByte();
                    char c = Convert.ToChar(num);
                    dataReceived += c;
                    text += c;
                }
                int num2 = text.LastIndexOf("kg");
                if (num2 <= 0) num2 = text.LastIndexOf("KG"); Console.WriteLine(num2);
                if (num2 >= 6)
                {
                    if (num2 < 8)
                    {
                        text = text.Substring(num2 - 6, 6);
                    }
                    else
                    {
                        text = text.Substring(num2 - 8, 8);
                    }
                    result = text;
                }
                else
                {
                    result = "";
                }
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
