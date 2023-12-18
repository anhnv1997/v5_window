using iParkingv5.LedDisplay.Behavior.ConnectBehavior;
using iParkingv5.LedDisplay.Enums;
using iParkingv5.LedDisplay.Interface.iCommand;
using iParkingv5.LedDisplay.Interface.iDevice;
using iParkingv5.Objects.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Text;
using static iParkingv5.LedDisplay.Enums.LedColors;
using System.Threading.Tasks;
using System.Threading;
using Kztek.Tool.SocketHelpers;
using Kztek.Tool.NetworkTools;
using iParkingv5.LedDisplay.Objects;

namespace iParkingv5.LedDisplay.KztekDevices
{
    public abstract class GeneralIpLedController : iIpLed
    {
        public CancellationTokenSource ctsScroll;
        #region: Public Properties
        public string IpAddress { get; set; } = string.Empty;
        public int Port { get; set; } = 100;
        public virtual iConnectBehavior ConnectBehavior { get; set; } = new IpConnectBehavior();
        public virtual iCMD CmdBehavior { get; set; } = new ip_v1_cmd_controller();
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public EmModuleType ModuleType { get; set; }
        public dynamic LedController { get; set; }

        public event ConnectStatusChangeEventHandler ConnectStatusChangeEvent;
        public event ErrorEventHandler ErrorEvent;
        public event DisplayTextChangeEventHandler DisplayTextChangeEvent;
        #endregion: End Public Properties

        #region: Private Properties
        private CancellationTokenSource cts;
        private bool IsStopPolling = false;
        private bool isConnect = false;
        public bool IsConnect
        {
            get => isConnect;
            set
            {
                if (isConnect != value)
                {
                    isConnect = value;
                    ConnectStatusChangeEvent?.Invoke(this, new ConnectStatusCHangeEventArgs()
                    {
                        CurrentStatus = value,
                        DeviceId = this.IpAddress,
                        EventTime = DateTime.Now
                    });
                }
            }
        }
        private bool isScroll = false;
        public bool IsScroll
        {
            get => isScroll;
            set
            {
                if (isScroll != value)
                {
                    isScroll = value;
                    if (value)
                    {
                        ctsScroll = new CancellationTokenSource();
                    }
                    else
                        ctsScroll?.Cancel();
                }
            }
        }
        #endregion: End Private Properties

        #region: Connect
        public bool Connect(string ip, int port, string username = "", string password = "")
        {
            this.IpAddress = ip;
            this.Port = port;
            this.Username = username;
            this.Password = password;
            return ConnectBehavior.Connect(ip, port, username, password);
        }

        public bool Disconnect(string ip, int port, string username = "", string password = "")
        {
            cts?.Cancel();
            return ConnectBehavior.Disconnect(ip, port, username, password);
        }
        #endregion: End Connect

        #region: Constructor
        public GeneralIpLedController(string ipAddress, int port, EmModuleType moduleType, string username = "", string password = "")
        {
            this.IpAddress = ipAddress;
            this.Port = port;
            this.Username = username;
            this.Password = password;
            this.ModuleType = moduleType;

            EmModuleType _moduleType = EmModuleType.P10FullColor_Outdoor;
            string errorMessage = "";
            GetModuleType(ref _moduleType, ref errorMessage);
            if (_moduleType.ToString() != moduleType.ToString())
                SetModuleType(moduleType, ref errorMessage);

            ConnectStatusChangeEvent += GeneralIpLedController_ConnectStatusChangeEvent;
            ErrorEvent += GeneralIpLedController_ErrorEvent;
            DisplayTextChangeEvent += GeneralIpLedController_DisplayTextChangeEvent;
        }

        private void GeneralIpLedController_DisplayTextChangeEvent(object? sender, TextChangeEventArgs e)
        {
            DisplayTextChangeEvent?.Invoke(sender, e);
        }

        private void GeneralIpLedController_ErrorEvent(object? sender, ErrorEventArgs e)
        {
            ErrorEvent?.Invoke(sender, e);
        }

        private void GeneralIpLedController_ConnectStatusChangeEvent(object? sender, ConnectStatusCHangeEventArgs e)
        {
            ConnectStatusChangeEvent?.Invoke(sender, e);
        }
        #endregion

        #region: Network Infor
        public bool GetIpAddr(ref string ipAddress, ref string errorMessage)
        {
            string cmd = CmdBehavior.AutoDetectCmd();
            string response = UdpTools.ExecuteCommand_Ascii(this.IpAddress, 100, cmd);
            if (response != null && response.Length > 0)
            {
                string[] _responses = response.Split('/');
                if (_responses.Length > 1)
                {
                    ipAddress = _responses[1];
                    return true;
                }
            }
            return false;
        }
        public bool GetPort(ref int port, ref string errorMessage)
        {
            port = this.Port;
            return true;
        }
        public bool GetMac(ref string macAddress, ref string errorMessage)
        {
            string cmd = CmdBehavior.AutoDetectCmd();
            string response = UdpTools.ExecuteCommand_Ascii(this.IpAddress, 100, cmd);
            if (response != null && response.Length > 0)
            {
                string[] _responses = response.Split('/');
                if (_responses.Length > 5)
                {
                    macAddress = _responses[5].Substring(0, _responses[5].Length - 1);
                    return true;
                }
            }
            return false;
        }
        public bool GetSubnetMask(ref string subnetMask, ref string errorMessage)
        {
            string cmd = CmdBehavior.AutoDetectCmd();
            string response = UdpTools.ExecuteCommand_Ascii(this.IpAddress, 100, cmd);
            if (response != null && response.Length > 0)
            {
                string[] _responses = response.Split('/');
                if (_responses.Length > 3)
                {
                    subnetMask = _responses[3];
                    return true;
                }
            }
            return false;
        }
        public bool GetGateWay(ref string gateway, ref string errorMessage)
        {
            string cmd = CmdBehavior.AutoDetectCmd();
            string response = UdpTools.ExecuteCommand_Ascii(this.IpAddress, 100, cmd);
            if (response != null && response.Length > 0)
            {
                string[] _responses = response.Split('/');
                if (_responses.Length > 4)
                {
                    gateway = _responses[4];
                    return true;
                }
            }
            return false;
        }
        public bool GetNetworkInfor(ref string ipAddress, ref int port, ref string macAddress, ref string subnetMask, ref string gateway, ref string errorMessage)
        {
            string cmd = CmdBehavior.AutoDetectCmd();
            string response = UdpTools.ExecuteCommand_Ascii(this.IpAddress, 100, cmd);
            if (response != null && response.Length > 0)
            {
                string[] _responses = response.Split('/');
                if (_responses.Length > 5)
                {
                    ipAddress = _responses[1];
                    port = int.Parse(_responses[2]);
                    subnetMask = _responses[3];
                    gateway = _responses[1];
                    macAddress = _responses[1];
                    return true;
                }
            }
            return false;
        }

        public bool ChangeIp(string ipAddress, ref string errorMessage)
        {
            return false;
        }
        public bool ChangePort(int port, ref string errorMessage)
        {
            return false;
        }
        public bool ChangeMac(string macAddress, ref string errorMessage)
        {
            string cmd = CmdBehavior.ChangeMacAddressCmd(macAddress);
            string response = UdpTools.ExecuteCommand_Ascii(this.IpAddress, 100, cmd);
            if (UdpTools.IsSuccess(response, "OK"))
            {
                return true;
            }
            return false;
        }
        public bool ChangeSubnetMask(string subnetMask, ref string errorMessage)
        {
            return false;
        }
        public bool ChangeGateWay(string gateway, ref string errorMessage)
        {
            return false;
        }
        public bool ChangeNetworkInfor(string ipAddress, int port, string macAddress, string subnetMask, string gateway, ref string errorMessage)
        {
            string cmd = CmdBehavior.ChangeNetworkInfor(ipAddress, subnetMask, gateway, macAddress);
            string response = UdpTools.ExecuteCommand_Ascii(this.IpAddress, 100, cmd);
            if (UdpTools.IsSuccess(response, "OK"))
            {
                return true;
            }
            return false;
        }
        #endregion: End Network Infor

        #region: System Infor
        public bool GetFirmwareVersion(ref string firmwareVersion, ref string errorMessage)
        {
            string cmd = CmdBehavior.GetFirmwareVersionCmd();
            string response = UdpTools.ExecuteCommand_Ascii(this.IpAddress, 100, cmd);
            if (string.IsNullOrEmpty(response))
            {
                errorMessage = "EMPTY_RESPONSE";
                return false;
            }
            string[] data = response.Split('/');
            Dictionary<string, string> map = GetEventContent(data);
            firmwareVersion = map.ContainsKey("version") ? map["version"] : "";
            return true;
        }
        public bool ResetDefault()
        {
            string cmd = CmdBehavior.ResetDefaultCmd();
            string errorMessage;
            try
            {
                var serverIP = IPAddress.Parse(this.IpAddress);
                if (NetWorkTools.IsPingSuccess(this.IpAddress, 300))
                {
                    var serverEndpoint = new IPEndPoint(serverIP, this.Port);
                    var size = 500;
                    var receiveBuffer = new byte[size];
                    var socket = new Socket(SocketType.Dgram, ProtocolType.Udp);

                    var sendBuffer = Encoding.UTF8.GetBytes(cmd);

                    socket.SendTo(sendBuffer, serverEndpoint);

                    EndPoint dummyEndpoint = new IPEndPoint(IPAddress.Any, 0);
                    string response = "";
                    while (!response.Contains("ResetComplete"))
                    {
                        var length = socket.ReceiveFrom(receiveBuffer, ref dummyEndpoint);
                        response = Encoding.UTF8.GetString(receiveBuffer);
                        Array.Clear(receiveBuffer, 0, size);
                        Thread.Sleep(1000);
                    }
                    errorMessage = "";
                    socket.Close();
                    return true;
                }
                else
                {
                    errorMessage = "Ping Error";
                }
            }
            catch (Exception ex)
            {

                errorMessage = ex.Message;
            }
            return false;
        }
        #endregion: End System Infor

        #region: Module Type
        public bool GetModuleType(ref EmModuleType moduleType, ref string errorMessage)
        {
            string _moduleType = "";
            string cmd = CmdBehavior.GetModuleTypeCmd();
            string response = UdpTools.ExecuteCommand_Ascii(this.IpAddress, 100, cmd);
            if (string.IsNullOrEmpty(response))
            {
                errorMessage = "EMPTY_RESPONSE";
                return false;
            }
            string[] data = response.Split('/');
            Dictionary<string, string> map = GetEventContent(data);
            _moduleType = map.ContainsKey("moduletype") ? map["moduletype"] : "0";
            moduleType = (EmModuleType)(Convert.ToInt16(_moduleType));
            return true;
        }
        public bool SetModuleType(EmModuleType moduleType, ref string errorMessage)
        {
            string cmd = CmdBehavior.SetModuleTypeCmd(moduleType);
            string response = UdpTools.ExecuteCommand_Ascii(this.IpAddress, 100, cmd);
            if (UdpTools.IsSuccess(response, "OK"))
            {
                return true;
            }
            return false;
        }
        #endregion: End Module Type

        #region: Resolution
        public bool GetResolution(ref int rowCount, ref int columnCount, ref string errorMessage)
        {
            string cmd = CmdBehavior.GetResolutionCmd();
            string response = UdpTools.ExecuteCommand_Ascii(this.IpAddress, 100, cmd);
            if (string.IsNullOrEmpty(response))
            {
                errorMessage = "EMPTY_RESPONSE";
                return false;
            }
            string[] data = response.Split('/');
            Dictionary<string, string> map = GetEventContent(data);
            //_moduleType = map.ContainsKey("numofline") ? map["numofline"] : "0";
            rowCount = map.ContainsKey("row") ? int.Parse(map["row"]) : 0;
            columnCount = map.ContainsKey("col") ? int.Parse(map["col"]) : 0;
            return true;
        }
        public bool SetResolution(int numberOfLine, int rowCount, int columnCount, ref string errorMessage)
        {
            string cmd = CmdBehavior.SetResolutionCmd(numberOfLine, rowCount, columnCount);
            string response = UdpTools.ExecuteCommand_Ascii(this.IpAddress, 100, cmd);
            if (UdpTools.IsSuccess(response, "OK"))
            {
                return true;
            }
            return false;
        }
        #endregion: End Resolution

        #region: Change Display
        #endregion: End Change Display

        #region: LOOP
        public void PollingStart()
        {
            cts = new CancellationTokenSource();
            if (this.IsStopPolling == true)
            {
                this.IsStopPolling = false;
            }
            else
            {
                Task.Run(new Action(() =>
                {
                    PollingCheckConnection();
                }));
            }
        }
        public void PollingStop()
        {
            this.IsStopPolling = true;
        }
        private void PollingCheckConnection()
        {
            while (!cts.IsCancellationRequested)
            {
                if (!this.IsStopPolling)
                {
                    this.IsConnect = NetWorkTools.IsPingSuccess(IpAddress, 500);
                }
                Thread.Sleep(500);
            }
        }

        #endregion: END LOOP

        public bool GeneralSetCmd(string cmd)
        {
            try
            {
                string response = UdpTools.ExecuteCommand_UTF8(this.IpAddress, 100, cmd);
                return UdpTools.IsSuccess(response, "OK");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public EmLedColor CheckColor(EmLedColor color)
        {
            EmLedColor validColor = LedColors.GetValidColorByModuleType(this.ModuleType);
            if ((color & validColor) != 0)
            {
                return EmLedColor.RED;
            }
            return color;
        }

        public abstract void ChangeDisplayWithScroll(Dictionary<int, LineConfig> lineConfigs, List<string> scrollDatas, bool isUpdate = true);

        public abstract void Stop(bool a);
        public static Dictionary<string, string> GetEventContent(string[] datas)
        {
            Dictionary<string, string> output = new Dictionary<string, string>();
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

        public abstract bool ChangeDisplay(EmScreenType screen, Dictionary<int, LineConfig> datas, EmDisplayMode displayMode, List<MergeSetting> mergeSettings, List<ScrollSetting> scrollSettings, bool isScroll);


    }
}
