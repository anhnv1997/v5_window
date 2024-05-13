//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.NetworkInformation;
//using System.Text;
//using System.Threading.Tasks;

//namespace iParkingv5.Controller.Ingress
//{
//    public class IngressTask
//    {
//        //--private
//        private Thread thread = null;
//        private Ingressus.Ingressus sdk = null;
//        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
//        private bool isbusy = false;
//        private string lineID = "";
//        private string comport = "COM14";
//        private int baudrate = 9600;
//        private int communicationtype = 0;
//        private int delaytime = 300;
//        private byte address = 0x00;
//        private bool isconnect = false;
//        private int count = 0;

//        private int timeout = 0;
//        public bool IsReadingEvent { get; set; } = false;
//        public string LineID
//        {
//            set { lineID = value; }
//        }
//        public string ComPort
//        {
//            get { return comport; }
//            set { comport = value; }
//        }
//        public int BaudRate
//        {
//            get { return baudrate; }
//            set { baudrate = value; }
//        }
//        public int CommunicationType
//        {
//            get { return communicationtype; }
//            set { communicationtype = value; }
//        }
//        public int DelayTime
//        {
//            get { return delaytime; }
//            set { delaytime = value; }
//        }
//        public bool IsStopGetEvent { get; set; } = false;
//        //--event
//        private CancellationTokenSource cts;
//        private ManualResetEvent ForceLoopIteration;



//        private long ConvertCard(string cardumber, int cardType)
//        {
//            return int.Parse(cardumber);

//            ////Convert from 3.5D -> 2.4H
//            //try
//            //{
//            //    if (cardType == (int)EM_CardType.PROXIMITY_LEN10)
//            //    {
//            //        return int.Parse(cardumber);
//            //    }
//            //    else if (cardType == (int)EM_CardType.PROXIMITY_LEN8)
//            //    {
//            //        try
//            //        {
//            //            string temp = Convert.ToInt32(cardumber).ToString("00000000");
//            //            string s1 = Convert.ToInt32(temp.Substring(0, 3)).ToString("X");
//            //            string s2 = Convert.ToInt32(temp.Substring(3)).ToString("X");
//            //            while (s2.Length < 4)
//            //                s2 = "0" + s2;
//            //            int card = int.Parse(s1 + s2, System.Globalization.NumberStyles.HexNumber);
//            //            return card;
//            //        }
//            //        catch
//            //        {
//            //            return 0;
//            //        }
//            //    }
//            //    else
//            //    {
//            //        return Convert.ToInt64(cardumber, 16);
//            //    }
//            //}
//            //catch
//            //{
//            //    return 0;
//            //}
//        }

//        public bool Unlock(int doorNo)
//        {
//            if (isconnect)
//            {
//                //sdk.RemoteNormalOpenDoor(doorNo);
//                sdk.RemoteOpenDoor(1, 3);
//                sdk.RemoteCloseDoor(1);
//                return true;
//            }
//            return false;
//        }

//        public bool OpenfileAlarm(int doorIndex)
//        {
//            if (isconnect)
//            {
//                return sdk.RemoteNormalOpenDoor(doorIndex);
//            }
//            return false;
//        }
//        public bool CloseFireAlarm(int doorIndex)
//        {
//            if (isconnect)
//            {
//                return sdk.RemoteNormalCloseDoor(doorIndex);
//            }
//            return false;
//        }

//        public bool Connect(string _ComPort, int _BaudRate, int _CommunicationType)
//        {
//            try
//            {
//                if (this.sdk != null)
//                {
//                    try
//                    {
//                        this.sdk.Disconnect();
//                        this.sdk = null;
//                        this.sdk = new Ingressus.Ingressus();
//                        this.sdk.SetConnectionTimeout(5);
//                    }
//                    catch (Exception)
//                    {
//                    }
//                }
//                else
//                {
//                    this.sdk = new Ingressus.Ingressus();
//                    this.sdk.SetConnectionTimeout(5);
//                }
//                ComPort = _ComPort;
//                BaudRate = _BaudRate;
//                CommunicationType = _CommunicationType;

//                if (communicationtype == 1)
//                {
//                    sdk.Connect_TCPIP(ComPort, BaudRate);
//                }
//            }
//            catch (Exception)
//            {
//                return false;
//            }
//            return false;
//        }
//    }
//}