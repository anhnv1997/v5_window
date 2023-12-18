using iParkingv5.Objects.Enums;
using iParkingv5.Objects.Events;
using iParkingv6.Objects.Datas;
using Kztek.Tool.SocketHelpers;
using Kztek.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace iParkingv5.Controller.KztekDevices.MT166_CardDispenser
{
    public class MT166_CardDispenser : BaseKzDevice
    {
        private enum EventType
        {
            Button1 = 1,    //( Nút nhấn BTN1) thẻ được nhả ra sau khi nhấn nút trên BTN1 và có sự kiện thẻ
            Button2 = 2,    //( Nút nhấn BTN2) thẻ được nhả ra sau khi nhấn nút trên BTN2 và có sự kiện thẻ
            Reader1 = 3,    //( Reader 1)
            Reader2 = 4,    //( Reader 2)
            Exit1 = 5,      //mo barrie 1
            Exit2 = 6,      //mo barrie 2
            In7 = 7,        //In5
            In8 = 8,        //In6
            Loop1 = 9,      //Loop1
            Loop2 = 10,     //Loop2
            Loop3 = 11,     //Loop3
            Loop4 = 12,     //Loop4
            NONE = 13,      //Spare
            CardbeTaken = 14, //Sự kiện có thẻ được rút ra khỏi miệng nhả thẻ ( Bezel)
            CardRevertedInTray1 = 21, //thẻ được nuốt vào khay nhả thẻ sau khi được nhấn trên BTN1, nhưng người dùng đã không rút thẻ sau một thời gian quy định.
            CardRevertedInTray2 = 22, //thẻ được nuốt vào khay nhả thẻ sau khi được nhấn trên BTN2, nhưng người dùng đã không rút thẻ sau một thời gian quy định.
        }

        private Thread thread = null;
        private ManualResetEvent stopEvent = null;
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
        public override void DeleteCardEvent()
        {
            string comport = this.ControllerInfo.comport;
            int baudrate = GetBaudrate(this.ControllerInfo.baudrate);
            string cmd = KZTEK_CMD.DeleteEventCMD();
            UdpTools.ExecuteCommand(comport, baudrate, cmd, 500, UdpTools.STX, Encoding.ASCII);
        }

        public override void PollingStart()
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
        public override void PollingStop()
        {
            if (this.Running)
            {
                SignalToStop();
                while (thread.IsAlive)
                {
                    if (WaitHandle.WaitAll(
                        (new ManualResetEvent[] { stopEvent }),
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
            while (!stopEvent.WaitOne(0, true))
            {
                try
                {
                    string comport = this.ControllerInfo.comport;
                    int baudrate = GetBaudrate(this.ControllerInfo.baudrate);
                    string getEventCmd = KZTEK_CMD.GetEventCMD();
                    this.IsBusy = true;
                    string response = string.Empty;
                    await Task.Run(() =>
                    {
                        response = UdpTools.ExecuteCommand(comport, baudrate, getEventCmd, 500, UdpTools.STX, Encoding.ASCII);
                    });
                    this.IsBusy = false;
                    // Trang thai thiet bij
                    this.ControllerInfo.isConnect = response != "";
                    //GetEvent?/LenCard=4/Card=7C19F640/Input=1/ArrayInput=X/Com=Com1/StateCardDispenserCom1=Y/StateCardDispenserCom2=Z/

                    if (response != "" && (response.Contains("GetEvent?/")) && !response.Contains("NotEvent"))
                    {
                        string[] data = response.Split('/');
                        Dictionary<string, string> map = GetEventContent(data);

                        string eventType = map.ContainsKey("input") ? map["input"] : "";
                        if (string.IsNullOrEmpty(eventType))
                        {
                            DeleteCardEvent();
                        }
                        EventType _eventType = (EventType)int.Parse(eventType);
                        bool isCardEvent = _eventType == EventType.Reader1 || _eventType == EventType.Reader2 ||
                                           _eventType == EventType.Button1 || _eventType == EventType.Button2;

                        bool isLoopEvent = _eventType == EventType.CardbeTaken ||
                                           _eventType == EventType.Loop1 || _eventType == EventType.Loop2 ||
                                           _eventType == EventType.Loop3 || _eventType == EventType.Loop4;

                        bool isExitEvent = _eventType == EventType.Exit1 || _eventType == EventType.Exit2;
                        if (isCardEvent)
                        {
                            CallCardEvent(this.ControllerInfo, map);
                        }
                        else if (isCardEvent)
                        {
                            CallInputEvent(this.ControllerInfo, map);
                        }
                        else if (isExitEvent)
                        {
                            string inputport = _eventType == EventType.Exit1 ? "1" : "2";
                            CallExitEvent(this.ControllerInfo, inputport);
                        }
                    }
                    await Task.Delay(300);
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void CallInputEvent(Bdk controller, Dictionary<string, string> map)
        {
            InputEventArgs ie = new InputEventArgs
            {
                DeviceId = controller.id
            };
            string str_inputName = map.ContainsKey("input") ? map["input"] : "";
            if (!string.IsNullOrEmpty(str_inputName))
            {
                string str_inputIndex = str_inputName.Replace("INPUT", "");
                ie.InputIndex = Regex.IsMatch(str_inputIndex, @"^\d+$") ? int.Parse(str_inputIndex) : -1;
            }
            ie.InputType = InputTupe.EmInputType.Loop;
            DeleteCardEvent();
            OnInputEvent(ie);
        }
        private void CallCardEvent(Bdk controller, Dictionary<string, string> map)
        {
            CardEventArgs e = new CardEventArgs
            {
                DeviceId = controller.id,
                AllCardFormats = new List<string>(),
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
                    string maInt = Convert.ToInt64(cardNumberHEX, 16).ToString();
                    e.AllCardFormats.Add(maInt);
                }
            }
            string str_readerIndex = map.ContainsKey("reader") ? map["reader"] : "";
            e.ReaderIndex = Regex.IsMatch(str_readerIndex, @"^\d+$") ? Convert.ToInt32(str_readerIndex) : -1;
            OnCardEvent(e);
            DeleteCardEvent();
        }
        private void CallExitEvent(Bdk controller, string doorNo)
        {
            InputEventArgs ie = new()
            {
                DeviceId = controller.id,
                DeviceName = controller.name,
            };
            ie.InputIndex = int.Parse(doorNo);
            ie.InputType = InputTupe.EmInputType.Exit;
            OnInputEvent(ie);
        }

        public override async Task<bool> OpenDoor(int timeInMilisecond, int relayIndex)
        {
            string comport = this.ControllerInfo.comport;
            int baudrate = GetBaudrate(this.ControllerInfo.baudrate);
            string openRelayCmd = KZTEK_CMD.OpenRelayCMD(relayIndex);

            this.IsBusy = true;
            string response = string.Empty;
            await Task.Run(() =>
            {
                response = UdpTools.ExecuteCommand(comport, baudrate, openRelayCmd, 500, UdpTools.STX, Encoding.ASCII);
            });
            this.IsBusy = false;
            if (UdpTools.IsSuccess(response, "OK"))
            {
                return true;
            }
            else if (UdpTools.IsSuccess(response, "ERR"))
            {
                return false;
            }
            OnErrorEvent(new ControllerErrorEventArgs()
            {
                ErrorString = response,
                ErrorFunc = "SetMacAsync",
                CMD = openRelayCmd
            });
            return false;
        }
    }
}
