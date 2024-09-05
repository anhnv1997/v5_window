using iParkingv5.Controller.KztekDevices;
using iParkingv5.Objects.Enums;
using iParkingv5.Objects.Events;
using iParkingv6.Objects.Datas;
using Kztek.Tool.NetworkTools;
using Kztek.Tool.SocketHelpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static iParkingv5.Objects.Enums.CommunicationTypes;
using System.Threading;
using Kztek.Tools;
using System.Text.RegularExpressions;
using Kztek.Tool.LogDatabases;

namespace iParkingv5.Controller.ZktecoDevices.PULL
{
    public class ZktecoPull : IController
    {
        const string TimeFormat = "yyyyMMddHHmmss";
        public Bdk ControllerInfo { get; set; }
        public bool IsBusy = false;
        private Thread thread = null;
        private ManualResetEvent stopEvent = null;

        public CancellationTokenSource? cts { get; set; }
        public ManualResetEvent? ForceLoopIteration { get; set; }
        #region Event
        public event CardEventHandler? CardEvent;
        public event FingerEventHandler? FingerEvent;
        public event ControllerErrorEventHandler? ErrorEvent;
        public event InputEventHandler? InputEvent;
        public event ConnectStatusChangeEventHandler? ConnectStatusChangeEvent;
        public event DeviceInfoChangeEventHandler? DeviceInfoChangeEvent;
        PULLHELPER pullHelper = new PULLHELPER();
        IntPtr userID;

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
        #endregion End Event

        #region: CONNECT
        public async Task<bool> TestConnectionAsync()
        {
            if (CommunicationTypes.IS_TCP((EM_CommunicationType)(this.ControllerInfo.CommunicationType)))
            {
                return NetWorkTools.IsPingSuccess(this.ControllerInfo.Comport, 500);
            }
            return false;
        }
        public async Task<bool> ConnectAsync()
        {
            if (await this.TestConnectionAsync())
            {
                int timeOut = 2000;
                string password = string.Empty;
                await Task.Run(() =>
                {
                    userID = pullHelper.ConnectByTCP(this.ControllerInfo.Comport, this.ControllerInfo.Baudrate, timeOut, password, ref userID);
                });
                this.ControllerInfo.IsConnect = userID != IntPtr.Zero;
                return this.ControllerInfo.IsConnect;
            }
            return false;
        }
        public async Task<bool> DisconnectAsync()
        {
            while (this.IsBusy)
            {
                await Task.Delay(10);
            }
            pullHelper.Disconnect(ref userID);
            this.ControllerInfo.IsConnect = false;
            cts?.Cancel();
            return true;
        }
        #endregion: END CONNECT

        #region DATE - TIME
        public async Task<DateTime> GetDateTime()
        {
            return DateTime.Now;
        }
        public async Task<bool> SetDateTime(DateTime time)
        {
            return false;
        }
        public async Task<bool> SyncDateTime()
        {
            return false;
        }
        #endregion END DATE - TIME

        #region:TCP_IP
        //GET
        public async Task<string> GetIPAsync()
        {
            int ret = 0, i = 0;
            int BUFFERSIZE = 10 * 1024 * 1024;
            byte[] buffer = new byte[BUFFERSIZE];
            int lv_sel_count = 1;
            string str = null;
            string tmp = null;
            string[] value = null;
            do
            {
                str = str + "IPAddress";
                if (i < lv_sel_count - 1)
                {
                    str = str + ',';
                }
                i++;
            } while (i < lv_sel_count);
            await Task.Run(() =>
            {
                ret = pullHelper.GetDeviceParam(userID, ref buffer[0], BUFFERSIZE, str);       //obtain device's param value
            });
            if (ret >= 0)
            {
                tmp = Encoding.Default.GetString(buffer);
                value = tmp.Split(',');
                for (int k = 0; k < lv_sel_count; k++)
                {
                    string[] sub_str = value[k].Split('=');
                    if (sub_str.Length >= 2)
                    {
                        return sub_str[1].ToString();
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                return string.Empty;
            }
            else
            {
                return string.Empty;
            }
        }
        public async Task<string> GetMacAsync()
        {
            return string.Empty;
        }
        public async Task<string> GetDefaultGatewayAsync()
        {
            return string.Empty;
        }

        public async Task<int> GetPortAsync()
        {
            return 4370;
        }
        public async Task<string> GetComkeyAsync()
        {
            return string.Empty;
        }
        //SET
        public async Task<bool> SetMacAsync(string macAddr)
        {
            return false;
        }
        public async Task<bool> SetNetWorkInforAsync(string ip, string subnetMask, string defaultGateway, string macAddr)
        {
            return false;
        }
        public async Task<bool> SetComKeyAsync(string comKey)
        {
            return false;
        }
        #endregion: END TCP_IP

        #region System
        public async Task<bool> ClearMemory()
        {
            return false;
        }
        public async Task<bool> RestartDevice()
        {
            return false;
        }
        public async Task<bool> ResetDefault()
        {
            return false;
        }
        #endregion End System

        protected void OnCardEvent(CardEventArgs e)
        {
            CardEvent?.Invoke(this, e);
        }
        protected void OnConnectStatusChangeEvent(ConnectStatusCHangeEventArgs e)
        {
            ConnectStatusChangeEvent?.Invoke(this, e);
        }
        protected void OnErrorEvent(ControllerErrorEventArgs e)
        {
            ErrorEvent?.Invoke(this, e);
        }
        protected void OnInputEvent(InputEventArgs e)
        {
            InputEvent?.Invoke(this, e);
        }
        public int GetBaudrate(string GetBaudrateCMD)
        {
            return 4370;
        }
        public static Dictionary<string, string> GetEventContent(string[] datas)
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

        public async void WorkerThread()
        {
            while (!stopEvent?.WaitOne(0, true) ?? false)
            {
                try
                {
                    if (userID == IntPtr.Zero)
                    {
                        this.ControllerInfo.IsConnect = false;
                        await ConnectAsync();
                    }
                    else
                    {
                        this.ControllerInfo.IsConnect = true;
                        int ret = 0, buffersize = 256;
                        string str = "";
                        string[] eventDatas = null;
                        byte[] buffer = new byte[256];
                        ret = PULLSDK.GetRTLog(userID, ref buffer[0], buffersize);
                        if (ret >= 0)
                        {
                            str = Encoding.Default.GetString(buffer);
                            if (!string.IsNullOrEmpty(str))
                            {
                                eventDatas = str.Split(',');
                                try
                                {
                                    string eventTime = eventDatas[0];
                                    string employeeId = eventDatas[1];
                                    string cardNumberInt = eventDatas[2];
                                    string doorNo = eventDatas[3];
                                    string eventType = eventDatas[4];
                                    string entryStatus = eventDatas[5];
                                    string verifyMode = eventDatas[6];
                                    //--Button 1: 2023-11-15 13:33:14,0,0,1,202,2,200
                                    //--Button 2: 2023-11-15 13:32:36,0,0,2,202,2,200

                                    //102 - Opened Accidentally
                                    //201 - Door Closed Correctly
                                    //202 - Exit button Open
                                    //--LOCK1 (LOOP1): 2023-11-15 15:16:54,0,0,1,102,2,200
                                    //                 2023-11-15 15:16:55,0,0,1,201,2,200
                                    //--LOCK1 (LOOP2): 2023-11-15 15:14:52,0,0,2,102,2,200
                                    //                 2023-11-15 15:14:55,0,0,2,201,2,200
                                    //eventType = "203";
                                    //cardNumberInt = "13033089";
                                    //--Door Status Event
                                    if (eventType == "255")
                                    {
                                    }
                                    //--Input Event
                                    else if (eventType == "102")
                                    {
                                        CallInputEvent(ControllerInfo, doorNo);
                                    }
                                    else if (eventType == "202")
                                    {
                                        CallExitEvent(ControllerInfo, doorNo);
                                    }
                                    //--Card Event
                                    else
                                    {
                                        if (!string.IsNullOrEmpty(cardNumberInt) && Int64.Parse(cardNumberInt) != 0)
                                        {
                                            CallCardEvent(ControllerInfo, cardNumberInt, doorNo);
                                        }
                                    }
                                }
                                catch (Exception)
                                {
                                }
                            }
                        }
                        else
                        {
                            this.userID = IntPtr.Zero;
                            this.ControllerInfo.IsConnect = false;
                        }
                    }
                    await Task.Delay(300);
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void CallInputEvent(Bdk controller, string doorNo)
        {
            InputEventArgs ie = new()
            {
                DeviceId = controller.Id,
                DeviceName = controller.Name,
            };
            ie.InputIndex = int.Parse(doorNo);
            ie.InputType = InputTupe.EmInputType.Loop;
            OnInputEvent(ie);
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
        private void CallCardEvent(Bdk controller, string cardNumberInt, string readerIndex)
        {
            CardEventArgs e = new()
            {
                DeviceId = controller.Id,
                DeviceName = controller.Name,
                AllCardFormats = new List<string>(),

            };
            string cardNumberHex = Convert.ToInt64(cardNumberInt).ToString("X");
            e.PreferCard = cardNumberHex;
            e.ReaderIndex = Regex.IsMatch(readerIndex, @"^\d+$") ? Convert.ToInt32(readerIndex) : -1;
            OnCardEvent(e);
        }
        public async Task<bool> OpenDoor(int timeInMilisecond, int relayIndex)
        {
            int operationID = 1;
            int doorId = 1;
            int result = pullHelper.ControlDevice(userID, operationID, doorId, relayIndex, 1, 1, "");
            await Task.Delay(1);
            return result == 0;
        }

        public Task<bool> AddFinger(List<string> fingerDatas)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ModifyFinger(string userId, int fingerIndex, string fingerData)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFinger(string userId, int fingerIndex)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddFinger(List<string> fingerDatas, string customerName, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ModifyFinger(List<string> fingerDatas, string customerName, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
