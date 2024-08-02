﻿using iParkingv5.Objects.Enums;
using iParkingv5.Objects.Events;
using iParkingv6.Objects.Datas;
using Kztek.Tool.SocketHelpers;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static OpenCvSharp.Stitcher;
using static System.Windows.Forms.AxHost;

namespace iParkingv5.Controller.KztekDevices.MT166_CardDispenser
{
    public class MT166_CardDispenserv8 : BaseKzDevice
    {
        private enum MT166EventType
        {
            /// <summary>
            /// ( Nút nhấn BTN1) thẻ được nhả ra sau khi nhấn nút trên BTN1 và có sự kiện thẻ
            /// </summary>
            Button1 = 1,

            /// <summary>
            /// (Nút nhấn BTN2) thẻ được nhả ra sau khi nhấn nút trên BTN2 và có sự kiện thẻ
            /// </summary>
            Button2 = 2,

            /// <summary>
            /// ( Reader 1)
            /// </summary>
            Reader1 = 3,

            /// <summary>
            /// ( Reader 2)
            /// </summary>
            Reader2 = 4,

            /// <summary>
            /// Loop1
            /// </summary>
            Loop1 = 9,

            /// <summary>
            /// Loop2
            /// </summary>
            Loop2 = 10,

            /// <summary>
            /// Loop3
            /// </summary>
            Loop3 = 11,

            /// <summary>
            /// Loop4
            /// </summary>
            Loop4 = 12,

            /// <summary>
            /// Spare
            /// </summary>
            Spare = 13,

            /// <summary>
            /// Sự kiện có thẻ được rút ra khỏi miệng nhả thẻ ( Bezel)
            /// </summary>
            CardbeTaken = 14,

            /// <summary>
            /// sự kiện nhấn nút trên BTN1, nhưng vòng loop 1 không được kích hoạt hoặc có một lý do khác mà nhấn nút nhưng thẻ không nhả ra
            /// </summary>
            BTN1_ABNORMAL = 15,

            /// <summary>
            /// sự kiện nhấn nút trên BTN2, nhưng vòng loop 1 không được kích hoạt hoặc có một lý do khác mà nhấn nút nhưng thẻ không nhả ra
            /// </summary>
            BTN2_ABNORMAL = 16,

            /// <summary>
            /// Sự kiện nhấn nút BTN1 nhưng trạng thái máy nhả thẻ đang ở trạng thái STOP và không nhả thẻ.
            /// </summary>
            BTN1_STOP = 17,

            /// <summary>
            /// Sự kiện nhấn nút BTN2 nhưng trạng thái máy nhả thẻ đang ở trạng thái STOP và không nhả thẻ.
            /// </summary>
            BTN2_STOP = 18,

            /// <summary>
            /// thẻ được nuốt vào khay nhả thẻ sau khi được nhấn trên BTN1, nhưng người dùng đã không rút thẻ sau một thời gian quy định.
            /// </summary>
            CardRevertedInTray1 = 21,

            /// <summary>
            /// thẻ được nuốt vào khay nhả thẻ sau khi được nhấn trên BTN2, nhưng người dùng đã không rút thẻ sau một thời gian quy định.
            /// </summary>
            CardRevertedInTray2 = 22,

            /// <summary>
            /// Thẻ được nhả ra sau khi nhận lệnh điều khiển từ máy tính
            /// </summary>
            CardOut = 23,

            /// <summary>
            /// Thẻ được bị nuốt vào khay thẻ sau khi máy tính ra lệnh nhả thẻ, nhưng người dùng đã không rút thẻ sau một thời gian quy định
            /// </summary>
            CardRevertedInTray = 24,

            /// <summary>
            /// Tín hiệu ra lệnh mở Barrie
            /// </summary>
            Open = 30,

            /// <summary>
            /// Tín hiệu bắt đầu dừng Barrie
            /// </summary>
            Stop_Start = 31,

            /// <summary>
            /// Tín hiệu hết lệnh dừng Barrie
            /// </summary>
            Stop_End = 32,

            /// <summary>
            /// Tín hiệu ra lệnh đóng Barrie
            /// </summary>
            Close = 33,
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

                    Free();
                }
                return false;
            }
        }

        public override void DeleteCardEvent()
        {
            string comport = this.ControllerInfo.Comport;
            int baudrate = GetBaudrate(this.ControllerInfo.Baudrate);
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
                    string comport = this.ControllerInfo.Comport;
                    int baudrate = GetBaudrate(this.ControllerInfo.Baudrate);
                    string getEventCmd = KZTEK_CMD.GetEventCMD();
                    this.IsBusy = true;
                    string response = string.Empty;
                    await Task.Run(() =>
                    {
                        response = UdpTools.ExecuteCommand(comport, baudrate, getEventCmd, 500, UdpTools.STX, Encoding.ASCII);
                    });
                    this.IsBusy = false;
                    // Trang thai thiet bij
                    this.ControllerInfo.IsConnect = response != "";
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
                        MT166EventType _eventType = (MT166EventType)int.Parse(eventType);
                        bool isCardEvent = _eventType == MT166EventType.Reader1 || _eventType == MT166EventType.Reader2 ||
                                           _eventType == MT166EventType.Button1 || _eventType == MT166EventType.Button2;

                        bool isLoopEvent = _eventType == MT166EventType.CardbeTaken ||
                                           _eventType == MT166EventType.Loop1 || _eventType == MT166EventType.Loop2 ||
                                           _eventType == MT166EventType.Loop3 || _eventType == MT166EventType.Loop4;

                        //bool isExitEvent = _eventType == MT166EventType.Exit1 || _eventType == MT166EventType.Exit2;
                        if (isCardEvent)
                        {
                            CallCardEvent(this.ControllerInfo, map);
                        }
                        else if (isCardEvent)
                        {
                            CallInputEvent(this.ControllerInfo, map);
                        }
                        //else if (isExitEvent)
                        //{
                        //    string inputport = _eventType == MT166EventType.Exit1 ? "1" : "2";
                        //    CallExitEvent(this.ControllerInfo, inputport);
                        //}
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
                DeviceId = controller.Id
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
                DeviceId = controller.Id,
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
                DeviceId = controller.Id,
                DeviceName = controller.Name,
            };
            ie.InputIndex = int.Parse(doorNo);
            ie.InputType = InputTupe.EmInputType.Exit;
            OnInputEvent(ie);
        }

        public override async Task<bool> OpenDoor(int timeInMilisecond, int relayIndex)
        {
            string comport = this.ControllerInfo.Comport;
            int baudrate = GetBaudrate(this.ControllerInfo.Baudrate);
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
                ErrorFunc = "OpenDoor",
                CMD = openRelayCmd
            });
            return false;
        }

        /// <summary>
        /// Thực hiện hành động cho phép máy nhả thẻ đang trong trạng thái dừng hoạt động: Sẽ không thực hiện thao tác nhả thẻ nữa
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public async Task<bool> SetStateWorkCardDispenser(string state)
        {
            string comport = this.ControllerInfo.Comport;
            int baudrate = GetBaudrate(this.ControllerInfo.Baudrate);
            string openRelayCmd = "SetStateWorkCardDispenser?/State=" + state;

            this.IsBusy = true;
            string response = string.Empty;
            await Task.Run(() =>
            {
                response = UdpTools.ExecuteCommand(comport, baudrate, openRelayCmd, 500, UdpTools.STX, Encoding.ASCII);
            });
            this.IsBusy = false;
            //SetStateWorkCardDispenser?/OK/
            //SetStateWorkCardDispenser?/ERROR/
            if (UdpTools.IsSuccess(response, "OK"))
            {
                return true;
            }
            else if (UdpTools.IsSuccess(response, "ERROR"))
            {
                return false;
            }
            OnErrorEvent(new ControllerErrorEventArgs()
            {
                ErrorString = response,
                ErrorFunc = "SetStateWorkCardDispenser",
                CMD = openRelayCmd
            });
            return false;
        }

        public async Task<string> GetStateWorkCardDispenser()
        {
            string GetStateWorkCardDispenserCMD = "GetStateWorkCardDispenser?/";

            string comport = this.ControllerInfo.Comport;
            int baudrate = GetBaudrate(this.ControllerInfo.Baudrate);
            this.IsBusy = true;
            string response = string.Empty;
            await Task.Run(() => response = UdpTools.ExecuteCommand(comport, baudrate, GetStateWorkCardDispenserCMD, 500, UdpTools.STX, Encoding.ASCII));
            this.IsBusy = false;
            //GetStateWorkCardDispenser?/State=Working/
            //GetStateWorkCardDispenser?/State=Stop/
            if (UdpTools.IsSuccess(response, "GetStateWorkCardDispenser?/"))
            {
                string[] data = response.Split('/');
                Dictionary<string, string> map = GetEventContent(data);
                string state = map.ContainsKey("state") ? map["state"] : "";
                return state;
            }
            OnErrorEvent(new ControllerErrorEventArgs()
            {
                ErrorString = response,
                ErrorFunc = "GetStateWorkCardDispenser",
                CMD = GetStateWorkCardDispenserCMD
            });
            return "";
        }

        /// <summary>
        /// Lệnh thực hiện chức năng nhả thẻ tới các vị khe nhả thẻ
        /// </summary>
        /// <returns></returns>
        public async Task<bool> DispenseCard()
        {
            string comport = this.ControllerInfo.Comport;
            int baudrate = GetBaudrate(this.ControllerInfo.Baudrate);
            string openRelayCmd = "DispenseCard?/ToBezel/";

            this.IsBusy = true;
            string response = string.Empty;
            await Task.Run(() =>
            {
                response = UdpTools.ExecuteCommand(comport, baudrate, openRelayCmd, 500, UdpTools.STX, Encoding.ASCII);
            });
            this.IsBusy = false;
            //DispenseCard?/DispensingToBezel/
            return UdpTools.IsSuccess(response, "DispenseCard?/DispensingToBezel/");
        }

        /// <summary>
        /// Audio có giá trị từ 1 -> 6
        /// </summary>
        /// <param name="readerIndex"></param>
        /// <returns></returns>
        public async Task<bool> SetAudio(int readerIndex)
        {
            string comport = this.ControllerInfo.Comport;
            int baudrate = GetBaudrate(this.ControllerInfo.Baudrate);
            string setAudioCmd = $"SetAudio?/Audio={readerIndex}/State=ON/";

            this.IsBusy = true;
            string response = string.Empty;
            await Task.Run(() =>
            {
                response = UdpTools.ExecuteCommand(comport, baudrate, setAudioCmd, 500, UdpTools.STX, Encoding.ASCII);
            });
            this.IsBusy = false;
            //SetAudio?/OK/
            //SetAudio?/ERROR/
            if (UdpTools.IsSuccess(response, "OK"))
            {
                return true;
            }
            else if (UdpTools.IsSuccess(response, "ERROR"))
            {
                return false;
            }
            OnErrorEvent(new ControllerErrorEventArgs()
            {
                ErrorString = response,
                ErrorFunc = "SetAudio",
                CMD = setAudioCmd
            });
            return false;
        }

        /// <summary>
        /// Sử dụng lệnh điều khiển Relay cho phép nuốt thẻ trong cơ cấu nuốt thẻ, được sử dụng cho cấu cơ nuốt thẻ của máy nuốt thẻ
        /// </summary>
        /// <returns></returns>
        public async Task<bool> CollectCard()
        {
            string comport = this.ControllerInfo.Comport;
            int baudrate = GetBaudrate(this.ControllerInfo.Baudrate);
            string collectCardCmd = $"ColllectCard?/";

            this.IsBusy = true;
            string response = string.Empty;
            await Task.Run(() =>
            {
                response = UdpTools.ExecuteCommand(comport, baudrate, collectCardCmd, 500, UdpTools.STX, Encoding.ASCII);
            });
            this.IsBusy = false;
            //SetAudio?/OK/
            //SetAudio?/ERROR/
            if (UdpTools.IsSuccess(response, "OK"))
            {
                return true;
            }
            else if (UdpTools.IsSuccess(response, "ERROR"))
            {
                return false;
            }
            OnErrorEvent(new ControllerErrorEventArgs()
            {
                ErrorString = response,
                ErrorFunc = "ColllectCard",
                CMD = collectCardCmd
            });
            return false;
        }

        /// <summary>
        /// Sử dụng lệnh điều khiển Relay cho phép thẻ trả lại do không hợp lệ.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> RejectCard()
        {
            string comport = this.ControllerInfo.Comport;
            int baudrate = GetBaudrate(this.ControllerInfo.Baudrate);
            string rejectCardCmd = $"RejectCard?/";

            this.IsBusy = true;
            string response = string.Empty;
            await Task.Run(() =>
            {
                response = UdpTools.ExecuteCommand(comport, baudrate, rejectCardCmd, 500, UdpTools.STX, Encoding.ASCII);
            });
            this.IsBusy = false;
            //SetAudio?/OK/
            //SetAudio?/ERROR/
            if (UdpTools.IsSuccess(response, "OK"))
            {
                return true;
            }
            else if (UdpTools.IsSuccess(response, "ERROR"))
            {
                return false;
            }
            OnErrorEvent(new ControllerErrorEventArgs()
            {
                ErrorString = response,
                ErrorFunc = "RejectCard",
                CMD = rejectCardCmd
            });
            return false;
        }

        /// <summary>
        /// Giá trị tối đa hỗ trợ: 900000
        /// </summary>
        /// <param name="relay"></param>
        /// <param name="delayInMilisecond"></param>
        /// <returns></returns>
        public async Task<bool> SetDelayRelay(int relay, int delayInMilisecond)
        {
            string comport = this.ControllerInfo.Comport;
            int baudrate = GetBaudrate(this.ControllerInfo.Baudrate);
            string setDelayRelayCmd = $"SetDelayRelay?/Relay={relay}/Delay={delayInMilisecond}/";

            this.IsBusy = true;
            string response = string.Empty;
            await Task.Run(() =>
            {
                response = UdpTools.ExecuteCommand(comport, baudrate, setDelayRelayCmd, 500, UdpTools.STX, Encoding.ASCII);
            });
            this.IsBusy = false;
            //SetDelayRelay?/OK/
            //SetDelayRelay?/ERROR/
            if (UdpTools.IsSuccess(response, "OK"))
            {
                return true;
            }
            else if (UdpTools.IsSuccess(response, "ERROR"))
            {
                return false;
            }
            OnErrorEvent(new ControllerErrorEventArgs()
            {
                ErrorString = response,
                ErrorFunc = "SetDelayRelay",
                CMD = setDelayRelayCmd
            });
            return false;
        }

        /// <summary>
        /// Nếu sử dụng đầu đọc ngoài lắp trên cơ cấu nhả thẻ ( bỏ đầu đọc tích hợp sẵn bên trong ) thì chế độ ExternalReader sẽ được kích hoạt. <br/>
        /// Chế độ này được kích hoạt bằng cách gạt dipswitch 2 lên On.
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetModeExternalReader()
        {
            string getModeExternalReaderCMD = "GetModeExternalReader?/";

            string comport = this.ControllerInfo.Comport;
            int baudrate = GetBaudrate(this.ControllerInfo.Baudrate);
            this.IsBusy = true;
            string response = string.Empty;
            await Task.Run(() => response = UdpTools.ExecuteCommand(comport, baudrate, getModeExternalReaderCMD, 500, UdpTools.STX, Encoding.ASCII));
            this.IsBusy = false;
            //GetModeExternalReader?/ModeExternalReader=1/
            //GetModeExternalReader?/ModeExternalReader=0/
            if (UdpTools.IsSuccess(response, "GetModeExternalReader?/"))
            {
                string[] data = response.Split('/');
                Dictionary<string, string> map = GetEventContent(data);
                string modeExternalReader = map.ContainsKey("modeexternalreader") ? map["modeexternalreader"] : "";
                return modeExternalReader;
            }
            OnErrorEvent(new ControllerErrorEventArgs()
            {
                ErrorString = response,
                ErrorFunc = "GetModeExternalReader",
                CMD = getModeExternalReaderCMD
            });
            return "";
        }

        /// <summary>
        /// Mode Key được quy định bởi dipswitch 3
        /// Dipswitch 3 = OFF : Không sử dụng chế độ xác thực key. (ModeKey=0)
        /// ON: Sử dụng chế độ xác thực Key. (ModeKey=1)
        /// Lưu ý: Khi đặt ở chế độ xác thực key, thì nó chỉ có ý nghĩa với đầu đọc thẻ vé ngày gắn liền với
        /// cơ cấu nhả thẻ.Với đầu đọc vé tháng thì phải thiết lập riêng
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetModeKey()
        {
            string getModeKeyCmd = "GetModeKey?/";

            string comport = this.ControllerInfo.Comport;
            int baudrate = GetBaudrate(this.ControllerInfo.Baudrate);
            this.IsBusy = true;
            string response = string.Empty;
            await Task.Run(() => response = UdpTools.ExecuteCommand(comport, baudrate, getModeKeyCmd, 500, UdpTools.STX, Encoding.ASCII));
            this.IsBusy = false;
            //GetModeKey?/ModeKey=1/
            //GetModeKey?/ ModeKey=0/
            if (UdpTools.IsSuccess(response, "GetModeKey?/"))
            {
                string[] data = response.Split('/');
                Dictionary<string, string> map = GetEventContent(data);
                string modeKey = map.ContainsKey("modekey") ? map["modekey"] : "";
                return modeKey;
            }
            OnErrorEvent(new ControllerErrorEventArgs()
            {
                ErrorString = response,
                ErrorFunc = "GetModeKey",
                CMD = getModeKeyCmd
            });
            return "";
        }

        /// <summary>
        /// Mode Key được quy định bởi dipswitch 4
        /// Dipswitch 4 = OFF : Không sử dụng chế độ tự động nuốt thẻ (ModeAutoCollectCard=0)
        ///               ON : Sử dụng chế độ tự động nuốt thẻ. (ModeAutoCollectCard=1)
        /// ModeAutoCollectCard=0 : Không có chế độ tự động nuốt thẻ khi người dùng ấn nhả thẻ nhưng không rút thẻ.
        /// ModeAutoCollectCard=1 : Có chế độ tự động nuốt thẻ khi người dùng ấn nhả thẻ nhưng không rút thẻ sau một khoảng thời gian nào đó.
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetModeAutoCollectCard()
        {
            string getModeAutoCollectCardCmd = "GetModeAutoCollectCard?/";

            string comport = this.ControllerInfo.Comport;
            int baudrate = GetBaudrate(this.ControllerInfo.Baudrate);
            this.IsBusy = true;
            string response = string.Empty;
            await Task.Run(() => response = UdpTools.ExecuteCommand(comport, baudrate, getModeAutoCollectCardCmd, 500, UdpTools.STX, Encoding.ASCII));
            this.IsBusy = false;
            //GetModeAutoCollectCard?/ModeAutoCollectCard=0/
            if (UdpTools.IsSuccess(response, "GetModeAutoCollectCard?/"))
            {
                string[] data = response.Split('/');
                Dictionary<string, string> map = GetEventContent(data);
                string modeAutoCollectCard = map.ContainsKey("modeautocollectcard") ? map["modeautocollectcard"] : "";
                return modeAutoCollectCard;
            }
            OnErrorEvent(new ControllerErrorEventArgs()
            {
                ErrorString = response,
                ErrorFunc = "GetModeAutoCollectCard",
                CMD = getModeAutoCollectCardCmd
            });
            return "";
        }

        /// <summary>
        /// Thiết lập ngưỡng thời gian tối đa, người dùng buộc phải rút thẻ ra khỏi miệng máy nhả thẻ, tính
        /// bằng giây. Quá thời gian này, máy nhả thẻ sẽ tự nuốt thẻ vào khay thẻ lỗi và hủy thẻ trên máy tính
        /// </summary>
        /// <param name="timeInSecond"></param>
        /// <returns></returns>
        public async Task<bool> SetTimeOutAutoCollectCard(int timeInSecond)
        {
            string comport = this.ControllerInfo.Comport;
            int baudrate = GetBaudrate(this.ControllerInfo.Baudrate);
            string setTimeOutAutoCollectCardCmd = $"SetTimeOutAutoCollectCard?/TimeOutAutoCollectCard={timeInSecond}/";

            this.IsBusy = true;
            string response = string.Empty;
            await Task.Run(() =>
                {
                    response = UdpTools.ExecuteCommand(comport, baudrate, setTimeOutAutoCollectCardCmd, 500, UdpTools.STX, Encoding.ASCII);
                });
            this.IsBusy = false;
            //SetTimeOutAutoCollectCard?/OK/
            //SetTimeOutAutoCollectCard?/ERROR/
            if (UdpTools.IsSuccess(response, "OK"))
            {
                return true;
            }
            else if (UdpTools.IsSuccess(response, "ERROR"))
            {
                return false;
            }
            OnErrorEvent(new ControllerErrorEventArgs()
            {
                ErrorString = response,
                ErrorFunc = "SetTimeOutAutoCollectCard",
                CMD = setTimeOutAutoCollectCardCmd
            });
            return false;
        }

        public async Task<string> GetTimeOutAutoCollectCard()
        {
            string getTimeOutAutoCollectCardCmd = "GetTimeOutAutoCollectCard?/";

            string comport = this.ControllerInfo.Comport;
            int baudrate = GetBaudrate(this.ControllerInfo.Baudrate);
            this.IsBusy = true;
            string response = string.Empty;
            await Task.Run(() => response = UdpTools.ExecuteCommand(comport, baudrate, getTimeOutAutoCollectCardCmd, 500, UdpTools.STX, Encoding.ASCII));
            this.IsBusy = false;
            //GetTimeOutAutoCollectCard?/TimeOutAutoCollectCard=20/
            if (UdpTools.IsSuccess(response, "GetTimeOutAutoCollectCard?/"))
            {
                string[] data = response.Split('/');
                Dictionary<string, string> map = GetEventContent(data);
                string timeOutAutoCollectCard = map.ContainsKey("timeoutautocollectcard") ? map["timeoutautocollectcard"] : "";
                return timeOutAutoCollectCard;
            }
            OnErrorEvent(new ControllerErrorEventArgs()
            {
                ErrorString = response,
                ErrorFunc = "GetTimeOutAutoCollectCard",
                CMD = getTimeOutAutoCollectCardCmd
            });
            return "";
        }

        /// <summary>
        /// Với bộ MT166, chỉ có thể dùng chế độ xác thực KeyA, mặc định là KeyA sẽ được nạp vào sector0.
        /// Đầu đọc thẻ chỉ xác thực đúng KeyA trên sector0
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<bool> SetKeyA(string key)
        {
            string comport = this.ControllerInfo.Comport;
            int baudrate = GetBaudrate(this.ControllerInfo.Baudrate);
            string setKeyA = $"SetKeyA?/KeyA={key}/";

            this.IsBusy = true;
            string response = string.Empty;
            await Task.Run(() =>
            {
                response = UdpTools.ExecuteCommand(comport, baudrate, setKeyA, 500, UdpTools.STX, Encoding.ASCII);
            });
            this.IsBusy = false;
            //SetKeyA?/OK/
            //SetKeyA?/ERROR/
            if (UdpTools.IsSuccess(response, "OK"))
            {
                return true;
            }
            else if (UdpTools.IsSuccess(response, "ERROR"))
            {
                return false;
            }
            OnErrorEvent(new ControllerErrorEventArgs()
            {
                ErrorString = response,
                ErrorFunc = "SetKeyA",
                CMD = setKeyA
            });
            return false;
        }

        /// <summary>
        /// Các chế độ của Wiegand có thể là 26 ,34,58,66 bit.
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public async Task<bool> SetWiegandMode(int mode)
        {
            string comport = this.ControllerInfo.Comport;
            int baudrate = GetBaudrate(this.ControllerInfo.Baudrate);
            string setWiegandModeCmd = $"SetWiegandMode?/WiegandMode={mode}/";

            this.IsBusy = true;
            string response = string.Empty;
            await Task.Run(() =>
            {
                response = UdpTools.ExecuteCommand(comport, baudrate, setWiegandModeCmd, 500, UdpTools.STX, Encoding.ASCII);
            });
            this.IsBusy = false;
            //SetWiegandMode?/OK/
            //SetWiegandMode?/ERROR/
            if (UdpTools.IsSuccess(response, "OK"))
            {
                return true;
            }
            else if (UdpTools.IsSuccess(response, "ERROR"))
            {
                return false;
            }
            OnErrorEvent(new ControllerErrorEventArgs()
            {
                ErrorString = response,
                ErrorFunc = "SetWiegandMode",
                CMD = setWiegandModeCmd
            });
            return false;
        }

        public async Task<string> GetWiegandMode()
        {
            string getWiegandModeCmd = "GetWiegandMode?/";

            string comport = this.ControllerInfo.Comport;
            int baudrate = GetBaudrate(this.ControllerInfo.Baudrate);
            this.IsBusy = true;
            string response = string.Empty;
            await Task.Run(() => response = UdpTools.ExecuteCommand(comport, baudrate, getWiegandModeCmd, 500, UdpTools.STX, Encoding.ASCII));
            this.IsBusy = false;
            //GetWiegandMode?/WiegandMode=26/
            if (UdpTools.IsSuccess(response, "GetWiegandMode?/"))
            {
                string[] data = response.Split('/');
                Dictionary<string, string> map = GetEventContent(data);
                string wiegandMode = map.ContainsKey("wiegandmode") ? map["wiegandmode"] : "";
                return wiegandMode;
            }
            OnErrorEvent(new ControllerErrorEventArgs()
            {
                ErrorString = response,
                ErrorFunc = "GetWiegandMode",
                CMD = getWiegandModeCmd
            });
            return "";
        }

        /// <summary>
        /// ModeButton = 0 : sử dụng 1 Nút Bấm ( Sử dụng BTN1), 1 cơ cấu nhả thẻ ( Sử dụng COM1) , với chế độ này thì LoopMode chỉ có 2 tình huống: ModeLoop = 0, hoặc ModeLoop =1. Giá trị khác của ModeLoop khác sẽ tương đương với ModeLoop = 0 ( Không sử dụng vòng loop)<br/>
        /// ModeButton = 1 : sử dụng 1 Nút Bấm ( Sử dụng BTN1), 2 cơ cấu nhả thẻ ( Sử dụng cả COM1 và COM2), với chế độ này thì LoopMode chỉ có 2 tình huống: ModeLoop = 0, hoặc ModeLoop =1. Giá trị khác của ModeLoop khác sẽ tương đương với ModeLoop = 0 ( Không sử dụng vòng loop) <br/>
        /// ModeButton = 2 : Sử dụng 2 nút Bấm : 1 nút bấm xe máy và 1 nút bấm oto, 1 máy nhả thẻ COM1( Thẻ nhả ra là 1 trong 2 loại : oto hoặc xe máy, phụ thuộc vào nút bấm là loại gì )<br/>
        /// Có thể sử dụng kết hợp với 3 chế độ: ModeLoop =0,1,2<br/>
        /// ModeButton = 3 :sử dụng 2 nút bấm : 1 nút bấm xe máy nhả thẻ trên một máy, 1 nút bấm oto nhả thẻ trên 1 máy. Có thể sử dụng kết hợp với 4 chế độ: ModeLoop =0,1,2 <br/>
        /// Lưu ý: ModeButton được quy định bởi dipswitch 7,8 </summary>br>
        /// ModeButton = (dipswitch7 )*2 + dipswitch8 <br/>
        /// Khi gạt nên ON thì dipswitch7 = 1, Khi gạt OFF thì dipswitch7 = 0. Tương tự với dipswitch8 <br/>
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetModeButton()
        {
            string getModeButtonCmd = "GetModeButton?/";

            string comport = this.ControllerInfo.Comport;
            int baudrate = GetBaudrate(this.ControllerInfo.Baudrate);
            this.IsBusy = true;
            string response = string.Empty;
            await Task.Run(() => response = UdpTools.ExecuteCommand(comport, baudrate, getModeButtonCmd, 500, UdpTools.STX, Encoding.ASCII));
            this.IsBusy = false;
            //GetWiegandMode?/ModeButton=0/
            if (UdpTools.IsSuccess(response, "GetModeButton?/"))
            {
                string[] data = response.Split('/');
                Dictionary<string, string> map = GetEventContent(data);
                string modeButton = map.ContainsKey("modebutton") ? map["modebutton"] : "";
                return modeButton;
            }
            OnErrorEvent(new ControllerErrorEventArgs()
            {
                ErrorString = response,
                ErrorFunc = "GetModeButton",
                CMD = getModeButtonCmd
            });
            return "";
        }

        /// <summary>
        /// ModeLoop = 0 : Không sử dụng vòng Loop nào cả
        /// ModeLoop = 1 : Sử dụng vòng Loop1 để cho phép nhấn thẻ 1 lần trên BTN1 và BTN2
        /// ModeLoop = 2 : sử dụng Loop1 để cho phép một lần nhả thẻ trên BTN1 ( xe máy ), Kết hợp Loop1 và Loop2 nhả thẻ 1 lần trên BTN2 – Oto ( bắt sườn sau của Loop1 để cho phép nhấn thẻ lần 2
        /// LoopMode = 3 : dự phòng.
        /// Lưu ý: ModeLoop được quy định bởi dipswitch 5,6: ModeLoop = (dipswitch5 )*2 + dipswitch6
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetModeLoop()
        {
            string getModeLoopCmd = "GetModeLoop?/";

            string comport = this.ControllerInfo.Comport;
            int baudrate = GetBaudrate(this.ControllerInfo.Baudrate);
            this.IsBusy = true;
            string response = string.Empty;
            await Task.Run(() => response = UdpTools.ExecuteCommand(comport, baudrate, getModeLoopCmd, 500, UdpTools.STX, Encoding.ASCII));
            this.IsBusy = false;
            //GetWiegandMode?/ModeLoop=0/
            if (UdpTools.IsSuccess(response, "GetModeLoop?/"))
            {
                string[] data = response.Split('/');
                Dictionary<string, string> map = GetEventContent(data);
                string modeLoop = map.ContainsKey("modeloop") ? map["modeloop"] : "";
                return modeLoop;
            }
            OnErrorEvent(new ControllerErrorEventArgs()
            {
                ErrorString = response,
                ErrorFunc = "GetModeLoop",
                CMD = getModeLoopCmd
            });
            return "";
        }

        public async Task<bool> SetPauseDispenseCard()
        {
            string comport = this.ControllerInfo.Comport;
            int baudrate = GetBaudrate(this.ControllerInfo.Baudrate);
            string setPauseDispenseCardCmd = $"SetPauseDispenseCard?/";

            this.IsBusy = true;
            string response = string.Empty;
            await Task.Run(() =>
            {
                response = UdpTools.ExecuteCommand(comport, baudrate, setPauseDispenseCardCmd, 500, UdpTools.STX, Encoding.ASCII);
            });
            this.IsBusy = false;
            //SetPauseDispenseCard?/OK/
            //SetPauseDispenseCard?/ERROR/
            if (UdpTools.IsSuccess(response, "OK"))
            {
                return true;
            }
            else if (UdpTools.IsSuccess(response, "ERROR"))
            {
                return false;
            }
            OnErrorEvent(new ControllerErrorEventArgs()
            {
                ErrorString = response,
                ErrorFunc = "SetPauseDispenseCard",
                CMD = setPauseDispenseCardCmd
            });
            return false;
        }
    }
}
