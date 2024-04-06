using ALSE;
using iParkingv5.Objects.Enums;
using Kztek.Tool.SocketHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ALSE.Objects
{
    public enum EmBarriePosition : int
    {
        UNKNOWN = 0,
        ĐÃ_ĐÓNG = 1,
        ĐÃ_MỞ = 2,
        Ở_GIỮA_VÀ_DỪNG = 3,
        Ở_GIỮA_VÀ_ĐANG_ĐÓNG = 4,
        Ở_GIỮA_VÀ_ĐANG_MỞ = 5,
    }
    public class GeneralObject
    {
        public GeneralObject(string id, string name, string code, string description)
        {
            this.id = id;
            this.name = name;
            this.code = code;
            this.description = description;
        }

        [Browsable(true)]
        public string id { get; set; } = string.Empty;

        [Browsable(true)]
        [DisplayName("Tên Thiết Bị")]
        public string name { get; set; } = string.Empty;

        [Browsable(true)]
        [DisplayName("Mã Thiết Bị")]
        public string code { get; set; } = string.Empty;

        [Browsable(true)]
        [DisplayName("Mô tả")]
        public string description { get; set; } = string.Empty;
    }

    public class Controller : GeneralObject
    {
        public int communication { get; set; }
        public string comport { get; set; } = string.Empty;
        public int baudrate { get; set; } = 100;
        public int type { get; set; }
        public Controller() : this("", "", "", "")
        {

        }
        public Controller(string id, string name, string code, string description) : base(id, name, code, description)
        {
        }
        public Controller(string id, string name, string code, string description, string comport, int baudrate, int type, int communication) : base(id, name, code, description)
        {
            this.communication = communication;
            this.comport = comport;
            this.baudrate = baudrate;
            this.type = type;
        }

        public bool Running
        {
            get
            {
                if (thread != null)
                {
                    if (thread.Join(0) == false)
                        return true;

                    // the thread is not running, so free resources
                    Free();
                }
                return false;
            }
        }
        private bool? isConnect = null;
        public bool? IsConnect
        {
            get => isConnect;
            set
            {
                if (isConnect != value)
                {
                    isConnect = value;
                    ConnectStatusChangeEvent?.Invoke(this, new ConnectStatusCHangeEventArgs()
                    {
                        ControllerID = id,
                        ControllerName = name,
                        CurrentStatus = value ?? false,
                        EventTime = DateTime.Now
                    });
                }
            }
        }
        private EmBarriePosition barriePosition = EmBarriePosition.UNKNOWN;
        private string barrieErrorStr = "";

        private Thread? thread = null;
        private ManualResetEvent? stopEvent = null;

        public event CardEventHandler? CardEvent;
        public event ControllerErrorEventHandler? ErrorEvent;
        public event InputEventHandler? InputEvent;
        public event ConnectStatusChangeEventHandler? ConnectStatusChangeEvent;
        public event InfoChangeEventHandler? InfoChangeEvent;
        public event OnBarrieChangeStatusEventHandler? OnBarrieChangeStatusChangeEvent;


        public void PollingStart()
        {
            if (thread == null)
            {
                // create events
                stopEvent = new ManualResetEvent(false);
                // start thread
                thread = new Thread(new ThreadStart(WorkerThread));
                thread.Start();
            }
        }
        public void PollingStop()
        {
            if (Running)
            {
                SignalToStop();
                while (thread.IsAlive)
                {
                    if (WaitHandle.WaitAll(
                        new ManualResetEvent[] { stopEvent },
                        100,
                        true))
                    {
                        WaitForStop();
                        break;
                    }
                    Application.DoEvents();
                }
            }
        }

        // Signal thread to stop work
        public void SignalToStop()
        {
            // stop thread
            if (thread != null)
            {
                // signal to stop
                stopEvent.Set();
            }
        }
        // Wait for thread stop
        public void WaitForStop()
        {
            if (thread != null)
            {
                // wait for thread stop
                thread.Join();

                Free();
            }
        }
        private void Free()
        {
            thread = null;
            // release events
            stopEvent.Close();
            stopEvent = null;
        }
        public async void WorkerThread()
        {
            while (stopEvent != null)
            {
                if (!stopEvent.WaitOne(0, true))
                {
                    try
                    {
                        await PollingGetCardEvent();
                    }
                    catch
                    {
                        GC.Collect();
                    }
                }
            }
        }
        private async Task PollingGetCardEvent()
        {
            string comport = this.comport;
            int baudrate = this.baudrate;
            string getEventCmd = "GetEvent?/";
            string response = string.Empty;
            await Task.Run(() =>
            {
                response = UdpTools.ExecuteCommand(comport, baudrate, getEventCmd, 500, UdpTools.STX, Encoding.ASCII);
            });
            // Trang thai thiet bij
            IsConnect = response != "" && !response.ToLower().Contains("exception") && !response.ToLower().Contains("error"); ;
            //response = "GetEvent?/Style=Card/UserID=100/LenCard=4/Card=7C19F640/Reader=02/DateTime=YYYYMMDDhhmmss/CardState=U/AccessState=1/Door=00/StateMSG=00";
            //AccessCardGrant: Char(2) + GetEvent?/Style=Card/UserID=100/LenCard=4/Card=7C19F640/Reader=01/DateTime=YYYYMMDDhhmmss/CardState=U/AccessState=1/Door=00/StateMSG=00 + char(3)
            //AccessCardDenie: Char(2) + GetEvent?/Style=Card/UserID=Null/LenCard=4/Card=7C19F640/Reader=01/DateTime=YYYYMMDDhhmmss/CardState=U/AccessState=1/Door=00/StateMSG=00 + char(3)
            //InputEvent     : Char(2) + GetEvent?/Style=input/Input=INPUT1/DateTime=YYYYMMDDhhmmss + char(3)
            //NoEvent        : Char(2) + GetEvent?/NotEvent + char(3)
            if (response != "" && response.Contains("GetEvent?/") && !response.Contains("NotEvent"))
            {
                string[] data = response.Split('/');
                Dictionary<string, string> map = GetEventContent(data);
                bool isCardEvent = response.Contains("Card");
                if (isCardEvent)
                {
                    CallCardEvent(this, map);
                }
                else
                {
                    CallInputEvent(this, map);
                }
            }
            await Task.Delay(300);
        }
        private async Task PollingGetBarrieStatus()
        {
            string comport = this.comport;
            int baudrate = this.baudrate;
            string getEventCmd = "GetBarrierStatus?/";
            string response = string.Empty;
            await Task.Run(() =>
            {
                response = UdpTools.ExecuteCommand(comport, baudrate, getEventCmd, 500, UdpTools.STX, Encoding.ASCII);
            });
            // Trang thai thiet bij
            IsConnect = response != "";
            //response = GetBarrierStatus?/Position=1/Error=00000000
            if (response != "" && response.Contains("GetBarrierStatus?/"))
            {
                string[] data = response.Split('/');
                Dictionary<string, string> map = GetEventContent(data);

                string strBarriePosition = map.ContainsKey("position") ? map["position"] : "";
                int _barriePosition = Regex.IsMatch(strBarriePosition, @"^\d+$") ? Convert.ToInt32(strBarriePosition) : -1;

                string strBarrieError = map.ContainsKey("error") ? map["error"] : "";

                bool isHaveChange = (int)barriePosition != _barriePosition ||
                                    strBarrieError != barrieErrorStr;
                if (isHaveChange)
                {
                    barriePosition = (EmBarriePosition)_barriePosition;
                    barrieErrorStr = strBarrieError;
                    BarrieChangeStatusEventArgs e = new BarrieChangeStatusEventArgs()
                    {
                        ControllerID = id,
                        ControllerName = name,
                        NewPosition = (int)barriePosition,
                        NewErrorStatus = strBarrieError,
                    };
                    OnBarrieChangeStatusChangeEvent?.Invoke(this, e);
                }
            }
            await Task.Delay(300);
        }

        private void CallInputEvent(Controller controller, Dictionary<string, string> map)
        {
            InputEventArgs ie = new InputEventArgs
            {
                ControllerId = id
            };
            string str_inputName = map.ContainsKey("input") ? map["input"] : "";
            if (!string.IsNullOrEmpty(str_inputName))
            {
                string str_inputIndex = str_inputName.Replace("INPUT", "");
                ie.InputIndex = Regex.IsMatch(str_inputIndex, @"^\d+$") ? int.Parse(str_inputIndex) : -1;
            }
            if (ie.InputIndex == 1 || ie.InputIndex == 2)
            {
                ie.InputType = InputTupe.EmInputType.Exit;
            }
            else if (ie.InputIndex == 3 || ie.InputIndex == 4)
            {
                ie.InputType = InputTupe.EmInputType.Loop;
            }
            InputEvent?.Invoke(this, ie);
            DeleteCardEvent();
        }
        private void CallCardEvent(Controller controller, Dictionary<string, string> map)
        {
            CardEventArgs e = new CardEventArgs
            {
                ControllerID = id,
                AllCardFormats = new List<string>(),
                ControllerName = controller.name,
                EventTime = DateTime.Now,
            };
            string cardNumberHEX = map.ContainsKey("card") ? map["card"] : "";
            if (!string.IsNullOrEmpty(cardNumberHEX))
            {
                e.AllCardFormats.Add(cardNumberHEX);

                if (cardNumberHEX.Length == 6)
                {
                    string maTruocToiGian = long.Parse(cardNumberHEX, System.Globalization.NumberStyles.HexNumber).ToString();
                    string maTruocFull = Convert.ToInt64(cardNumberHEX, 16).ToString("0000000000");

                    string maSauFormat1 = int.Parse(cardNumberHEX.Substring(0, 2), System.Globalization.NumberStyles.HexNumber).ToString("000") +
                                          int.Parse(cardNumberHEX.Substring(2, 4), System.Globalization.NumberStyles.HexNumber).ToString("00000");

                    string maSauFormat2 = int.Parse(cardNumberHEX.Substring(0, 2), System.Globalization.NumberStyles.HexNumber).ToString("000") + ":" +
                                          int.Parse(cardNumberHEX.Substring(2, 4), System.Globalization.NumberStyles.HexNumber).ToString("00000");
                    string maSauFormat3 = int.Parse(cardNumberHEX.Substring(0, 2), System.Globalization.NumberStyles.HexNumber).ToString("000") + ":" +
                      int.Parse(cardNumberHEX.Substring(2, 4), System.Globalization.NumberStyles.HexNumber).ToString("00000");

                    e.PreferCard = maSauFormat3;

                    e.AllCardFormats.Add(maTruocToiGian);
                    if (maTruocToiGian != maTruocFull)
                    {
                        e.AllCardFormats.Add(maTruocFull);
                    }
                    e.AllCardFormats.Add(maSauFormat1);
                    e.AllCardFormats.Add(maSauFormat2);
                }
                else
                {
                    cardNumberHEX = cardNumberHEX.Substring(6, 2) + cardNumberHEX.Substring(4, 2) +
                                 cardNumberHEX.Substring(2, 2) + cardNumberHEX.Substring(0, 2);
                    string maInt = Convert.ToInt64(cardNumberHEX, 16).ToString();
                    e.AllCardFormats.Add(maInt);
                    e.PreferCard = maInt;
                }
            }
            string str_readerIndex = map.ContainsKey("reader") ? map["reader"] : "";
            e.ReaderIndex = Regex.IsMatch(str_readerIndex, @"^\d+$") ? Convert.ToInt32(str_readerIndex) : -1;
            CardEvent?.Invoke(this, e);
            DeleteCardEvent();
        }
        private void DeleteCardEvent()
        {
            string comport = this.comport;
            int baudrate = this.baudrate;
            string cmd = "DeleteEvent?/";
            UdpTools.ExecuteCommand(comport, baudrate, cmd, 500, UdpTools.STX, Encoding.ASCII);
        }
        private static Dictionary<string, string> GetEventContent(string[] datas)
        {
            Dictionary<string, string> output = new();
            foreach (string data in datas)
            {
                if (data.Contains("="))
                {
                    string[] subData = data.Split('=');
                    output.Add(subData[0].ToLower().Trim(), subData[1].Trim());
                }
            }
            return output;
        }

        public async Task<bool> OpenBarrie(int relayIndex)
        {
            string cmd = $"SetRelay?/Relay={relayIndex:00}/State=ON";
            string response = string.Empty;
            await Task.Run(() =>
            {
                response = UdpTools.ExecuteCommand(comport, baudrate, cmd, 500, UdpTools.STX, Encoding.ASCII);
            });
            // Trang thai thiet bij
            IsConnect = response != "" && !response.ToLower().Contains("exception");
            return response.Contains("OK");
        }
        public bool CloseBarrie()
        {
            return true;
        }
    }
}
