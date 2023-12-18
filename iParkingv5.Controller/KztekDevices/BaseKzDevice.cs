﻿using iParkingv5.Objects.Enums;
using iParkingv5.Objects.Events;
using iParkingv6.Objects.Datas;
using Kztek.Tool.NetworkTools;
using Kztek.Tool.SocketHelpers;
using Kztek.Tools;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static iParkingv5.Objects.Enums.CommunicationTypes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace iParkingv5.Controller.KztekDevices
{
    public abstract class BaseKzDevice : IController
    {
        const string TimeFormat = "yyyyMMddHHmmss";
        public Bdk ControllerInfo { get; set; }
        public bool IsBusy = false;

        public CancellationTokenSource? cts { get; set; }
        public ManualResetEvent? ForceLoopIteration { get; set; }
        #region Event
        public event CardEventHandler? CardEvent;
        public event ControllerErrorEventHandler? ErrorEvent;
        public event InputEventHandler? InputEvent;
        public event ConnectStatusChangeEventHandler? ConnectStatusChangeEvent;
        public event DeviceInfoChangeEventHandler? DeviceInfoChangeEvent;

        public abstract void PollingStart();
        public abstract void PollingStop();
        public abstract void DeleteCardEvent();
        public abstract Task<bool> OpenDoor(int timeInMilisecond, int relayIndex);
        #endregion End Event

        #region: CONNECT
        public async Task<bool> TestConnectionAsync()
        {
            if (CommunicationTypes.IS_TCP((EM_CommunicationType)(this.ControllerInfo.communicationType)))
            {
                if (NetWorkTools.IsPingSuccess(this.ControllerInfo.comport, 500))
                {
                    this.ControllerInfo.isConnect = !string.IsNullOrEmpty(await GetIPAsync());
                    return this.ControllerInfo.isConnect;
                }
            }
            return false;
        }
        public async Task<bool> ConnectAsync()
        {
            return await this.TestConnectionAsync();
        }
        public async Task<bool> DisconnectAsync()
        {
            while (this.IsBusy)
            {
                await Task.Delay(10);
            }
            cts?.Cancel();
            return true;
        }
        #endregion: END CONNECT

        #region DATE - TIME
        public async Task<DateTime> GetDateTime()
        {
            string GetDateTimeCMD = KZTEK_CMD.GetDateTimeCMD();

            string comport = this.ControllerInfo.comport;
            int baudrate = GetBaudrate(this.ControllerInfo.baudrate);
            this.IsBusy = true;
            string response = string.Empty;
            await Task.Run(() => response = UdpTools.ExecuteCommand(comport, baudrate, GetDateTimeCMD, 500, UdpTools.STX, Encoding.ASCII));
            this.IsBusy = false;
            //Char(2) + GetDateTime?/YYYYMMDDhhmmss + char(3)
            if (UdpTools.IsSuccess(response, "GetDateTime?/"))
            {
                string _datetime = response.Split('/')[1];
                return DateTime.ParseExact(_datetime, TimeFormat, CultureInfo.CurrentCulture);
            }
            if (ErrorEvent != null)
            {
                ErrorEvent?.Invoke(this, new ControllerErrorEventArgs()
                {
                    ErrorString = response,
                    ErrorFunc = "GetDateTime",
                    CMD = GetDateTimeCMD
                });
            }
            return DateTime.MinValue;
        }
        public async Task<bool> SetDateTime(DateTime time)
        {
            string comport = this.ControllerInfo.comport;
            int baudrate = GetBaudrate(this.ControllerInfo.baudrate);
            string SetDateTimeCMD = KZTEK_CMD.SetDateTimeCMD(time.ToString(TimeFormat));
            this.IsBusy = true;
            string response = string.Empty;
            await Task.Run(() =>
            {
                response = UdpTools.ExecuteCommand(comport, baudrate, SetDateTimeCMD, 500, UdpTools.STX, Encoding.ASCII);
            });
            this.IsBusy = false;
            //Char(2) + SetDateTime?/OK + char(3)
            //Char(2) + SetDateTime?/ERR + char(3)
            if (UdpTools.IsSuccess(response, "OK"))
            {
                return true;
            }
            else if (UdpTools.IsSuccess(response, "ERR"))
            {
                return false;
            }

            ErrorEvent?.Invoke(this, new ControllerErrorEventArgs()
            {
                ErrorString = response,
                ErrorFunc = "SetDateTime",
                CMD = SetDateTimeCMD
            });
            return false;
        }
        public async Task<bool> SyncDateTime()
        {
            return await SetDateTime(DateTime.Now);
        }
        #endregion END DATE - TIME

        #region:TCP_IP
        //GET
        public async Task<string> GetIPAsync()
        {
            string autoDetectCMD = KZTEK_CMD.AutoDetectCMD();
            string comport = this.ControllerInfo.comport;
            int baudrate = GetBaudrate(this.ControllerInfo.baudrate);
            this.IsBusy = true;
            string response = string.Empty;
            await Task.Run(() => response = UdpTools.ExecuteCommand(comport, baudrate, autoDetectCMD, 500, UdpTools.STX, Encoding.ASCII));
            this.IsBusy = false;
            //Char(2)  + version  + “/”  + IPAdress + “/”  Port + “/” + subNetMask + “/”  + DefaultGateway + “/”+ MacAddress + char(3)
            if (response != null && response.Length > 0)
            {
                string[] _responses = response.Split('/');
                if (_responses.Length > 1)
                {
                    return _responses[1];
                }
            }
            ErrorEvent?.Invoke(this, new ControllerErrorEventArgs()
            {
                ErrorString = response,
                ErrorFunc = "GetIPAsync",
                CMD = autoDetectCMD
            });
            return string.Empty;
        }
        public async Task<string> GetMacAsync()
        {
            string autoDetectCMD = KZTEK_CMD.AutoDetectCMD();
            string comport = this.ControllerInfo.comport;
            int baudrate = GetBaudrate(this.ControllerInfo.baudrate);
            this.IsBusy = true;
            string response = string.Empty;
            await Task.Run(() => response = UdpTools.ExecuteCommand(comport, baudrate, autoDetectCMD, 500, UdpTools.STX, Encoding.ASCII));
            this.IsBusy = false;
            //Char(2)  + version  + “/”  + IPAdress + “/”  Port + “/” + subNetMask + “/”  + DefaultGateway + “/”+ MacAddress + char(3)
            if (response != null && response.Length > 0)
            {
                string[] _responses = response.Split('/');
                if (_responses.Length > 5)
                {
                    return _responses[5];
                }
            }
            ErrorEvent?.Invoke(this, new ControllerErrorEventArgs()
            {
                ErrorString = response,
                ErrorFunc = "GetMacAsync",
                CMD = autoDetectCMD
            });
            return string.Empty;
        }
        public async Task<string> GetDefaultGatewayAsync()
        {
            string autoDetectCMD = KZTEK_CMD.AutoDetectCMD();
            string comport = this.ControllerInfo.comport;
            int baudrate = GetBaudrate(this.ControllerInfo.baudrate);
            this.IsBusy = true;
            string response = string.Empty;
            await Task.Run(() => response = UdpTools.ExecuteCommand(comport, baudrate, autoDetectCMD, 500, UdpTools.STX, Encoding.ASCII));
            this.IsBusy = false;
            //Char(2)  + version  + “/”  + IPAdress + “/”  Port + “/” + subNetMask + “/”  + DefaultGateway + “/”+ MacAddress + char(3)
            if (response != null && response.Length > 0)
            {
                string[] _responses = response.Split('/');
                if (_responses.Length > 4)
                {
                    return _responses[4];
                }
            }
            ErrorEvent?.Invoke(this, new ControllerErrorEventArgs()
            {
                ErrorString = response,
                ErrorFunc = "GetDefaultGatewayAsync",
                CMD = autoDetectCMD
            });
            return string.Empty;
        }

        public async Task<int> GetPortAsync()
        {
            return GetBaudrate(this.ControllerInfo.baudrate);
        }
        public async Task<string> GetComkeyAsync()
        {
            return string.Empty;
        }
        //SET
        public async Task<bool> SetMacAsync(string macAddr)
        {
            string comport = this.ControllerInfo.comport;
            int baudrate = GetBaudrate(this.ControllerInfo.baudrate);
            string SetDateTimeCMD = KZTEK_CMD.Get_ChangeMacAddressCmd(macAddr);
            this.IsBusy = true;
            string response = string.Empty;
            await Task.Run(() =>
            {
                response = UdpTools.ExecuteCommand(comport, baudrate, SetDateTimeCMD, 500, UdpTools.STX, Encoding.ASCII);
            });
            this.IsBusy = false;
            //Char(2) + SetDateTime?/OK + char(3)
            //Char(2) + SetDateTime?/ERR + char(3)
            if (UdpTools.IsSuccess(response, "OK"))
            {
                return true;
            }
            else if (UdpTools.IsSuccess(response, "ERR"))
            {
                return false;
            }

            ErrorEvent?.Invoke(this, new ControllerErrorEventArgs()
            {
                ErrorString = response,
                ErrorFunc = "SetMacAsync",
                CMD = SetDateTimeCMD
            });
            return false;
        }
        public async Task<bool> SetNetWorkInforAsync(string ip, string subnetMask, string defaultGateway, string macAddr)
        {
            string comport = this.ControllerInfo.comport;
            int baudrate = GetBaudrate(this.ControllerInfo.baudrate);
            string SetDateTimeCMD = KZTEK_CMD.ChangeIPCMD(ip, subnetMask, defaultGateway, macAddr);
            this.IsBusy = true;
            string response = string.Empty;
            await Task.Run(() =>
            {
                response = UdpTools.ExecuteCommand(comport, baudrate, SetDateTimeCMD, 500, UdpTools.STX, Encoding.ASCII);
            });
            this.IsBusy = false;
            //Char(2) + SetDateTime?/OK + char(3)
            //Char(2) + SetDateTime?/ERR + char(3)
            if (UdpTools.IsSuccess(response, "OK"))
            {
                return true;
            }
            else if (UdpTools.IsSuccess(response, "ERR"))
            {
                return false;
            }

            ErrorEvent?.Invoke(this, new ControllerErrorEventArgs()
            {
                ErrorString = response,
                ErrorFunc = "SetNetWorkInforAsync",
                CMD = SetDateTimeCMD
            });
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
            var serverIP = IPAddress.Parse(this.ControllerInfo.comport);
            var serverPort = GetBaudrate(this.ControllerInfo.baudrate);
            var serverEndpoint = new IPEndPoint(serverIP, serverPort);
            var size = 500;
            var receiveBuffer = new byte[size];
            string text = KZTEK_CMD.Get_InitCardEventCmd();
            var socket = new Socket(SocketType.Dgram, ProtocolType.Udp);

            var sendBuffer = Encoding.UTF8.GetBytes(text);

            socket.SendTo(sendBuffer, serverEndpoint);

            EndPoint dummyEndpoint = new IPEndPoint(IPAddress.Any, 0);
            string response = "";
            while (!response.Contains("InitComplete"))
            {
                var length = socket.ReceiveFrom(receiveBuffer, ref dummyEndpoint);
                response = Encoding.UTF8.GetString(receiveBuffer);
                response = response.Substring(1, length - 2);
                Array.Clear(receiveBuffer, 0, size);
                await Task.Delay(1000);
            }
            socket.Close();
            return true;
        }
        public async Task<bool> RestartDevice()
        {
            string comport = this.ControllerInfo.comport;
            int baudrate = GetBaudrate(this.ControllerInfo.baudrate);
            string ResetCMD = "ResetDevice?/";
            string response = UdpTools.ExecuteCommand(comport, baudrate, ResetCMD, 500, UdpTools.STX, Encoding.ASCII);
            return true;
        }
        public async Task<bool> ResetDefault()
        {
            var serverIP = IPAddress.Parse(this.ControllerInfo.comport);
            var serverPort = GetBaudrate(this.ControllerInfo.baudrate);
            var serverEndpoint = new IPEndPoint(serverIP, serverPort);
            var size = 500;
            var receiveBuffer = new byte[size];
            string text = KZTEK_CMD.ResetDefaultCmd();
            var socket = new Socket(SocketType.Dgram, ProtocolType.Udp);

            var sendBuffer = Encoding.UTF8.GetBytes(text);

            socket.SendTo(sendBuffer, serverEndpoint);

            EndPoint dummyEndpoint = new IPEndPoint(IPAddress.Any, 0);
            string response = "";
            while (!response.Contains("ResetComplete"))
            {
                var length = socket.ReceiveFrom(receiveBuffer, ref dummyEndpoint);
                response = Encoding.UTF8.GetString(receiveBuffer);
                response = response.Substring(1, length - 2);
                Array.Clear(receiveBuffer, 0, size);
                await Task.Delay(1000);
            }
            socket.Close();
            return true;
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
        public int GetBaudrate(string GetDateTimeCMD)
        {
            int baudrate = 0;
            if (!string.IsNullOrEmpty(this.ControllerInfo.baudrate))
            {
                try
                {
                    baudrate = int.Parse(this.ControllerInfo.baudrate);
                }
                catch (Exception ex)
                {
                    string errorMessage = $@"Controller {this.ControllerInfo.comport} Got Baudrate Error: " + ex.Message;
                    ErrorEvent?.Invoke(this, new ControllerErrorEventArgs()
                    {
                        ErrorString = errorMessage,
                        ErrorFunc = "GetDateTime",
                        CMD = GetDateTimeCMD
                    });
                    throw new Exception(errorMessage);
                }
            }
            return baudrate;
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
    }
}
