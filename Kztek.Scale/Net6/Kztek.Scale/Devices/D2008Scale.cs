using System;
using System.IO.Ports;
using System.Threading;
using Kztek.Scale_net6.Events;
using Kztek.Scale_net6.Interfaces;
using Kztek.Scale_net6.Objects;
using ErrorEventHandler = Kztek.Scale_net6.Events.ErrorEventHandler;

namespace Kztek.Scale_net6.Devices
{

    public class D2008Scale : IScale
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
            string dataString = "";
            serialPort.DiscardInBuffer();
            string dataReceived = ReadData(ref dataString);
            if (DataReceivedEvent != null) DataReceivedEvent(this, dataReceived);
            ParseData(dataReceived);
        }
        private void ParseData(string dataReceived)
        {
            if (ScaleEvent != null)
            {
                try
                {
                    if (dataReceived.Length >= 7 && dataReceived.Substring(0, 1) == "+")
                    {
                        bool isMinusValue = false;
                        int decimalValue = 0;
                        isMinusValue = dataReceived.Substring(0, 1) == "-" ? true : false;
                        dataReceived = dataReceived.Substring(1, 6);
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
            string result = "";
            try
            {
                Thread.Sleep(receivedTimeOut);
                string text = "";
                bool flag = false;
                bool flag2 = false;
                while (serialPort.BytesToRead > 0)
                {
                    int num = serialPort.ReadByte();
                    char c = Convert.ToChar(num);
                    string a = ByteUtils.DecimalToBase(num, 16);
                    dataReceived += c;
                    if (a == "02")
                    {
                        flag = true;
                        text = "";
                    }
                    else
                    {
                        if (a == "03")
                        {
                            flag = false;
                            if (text.Length >= 10)
                            {
                                result = text.Substring(0, 7);
                                flag2 = true;
                            }
                        }
                        else
                        {
                            if (flag)
                            {
                                text += c;
                            }
                        }
                    }
                }
                if (flag2 && result.Length == 7)
                    return result;
                else
                {
                    if (text.Length >= 10)
                    {
                        result = text.Substring(0, 7);
                        return result;
                    }
                    else
                    {
                        result = "";
                    }
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
