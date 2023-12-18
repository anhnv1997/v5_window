using iParkingv5.LedDisplay.Interface.iCommand;
using iParkingv5.LedDisplay.Interface.iDevice;
using iParkingv5.Objects.Events;
using Kztek.Tool.NetworkTools;
using Kztek.Tool.SocketHelpers;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using iParkingv5.LedDisplay.KztekDevices.PGSIndoorLed;

namespace KzLedLibraryv2.PGSIndoorLed
{
    public class PGSIndoorLed : IPGSLed
    {
        private const int PingTimeOut = 500;
        private CancellationTokenSource? cts;
        private bool IsStopPolling = false;

        #region: EVENT
        public event ConnectStatusChangeEventHandler? ConnectStatusChangeEvent;
        public event ErrorEventHandler? ErrorEvent;
        public event DisplayTextChangeEventHandler? DisplayTextChangeEvent;
        #endregion: END EVENT

        #region: INFOR
        private bool isConnect = false;
        public string IpAddress { get; set; } = string.Empty;
        public int Port { get; set; } = 100;
        public bool IsConnect
        {
            get => isConnect;
            set
            {
                if (isConnect != value)
                {
                    ConnectStatusChangeEvent?.Invoke(this, new ConnectStatusCHangeEventArgs()
                    {
                        EventTime = DateTime.Now,
                        CurrentStatus = value,
                        DeviceId = this.IpAddress,
                    });
                    isConnect = value;
                }
            }
        }
        public bool Connect(string ipAddress, int port)
        {
            IpAddress = ipAddress;
            Port = port;
            return NetWorkTools.IsPingSuccess(ipAddress, PingTimeOut);
        }
        public bool Disconnect()
        {
            cts?.Cancel();
            return true;
        }
        #endregion: END INFOR

        #region: DISPLAY
        private int currentSlotsDisplay = 0;

        public int CurrentSlotsDisplay
        {
            get => currentSlotsDisplay;
            set
            {
                if (currentSlotsDisplay != value)
                {
                    DisplayTextChangeEvent?.Invoke(this, new TextChangeEventArgs()
                    {
                        CurrentText = currentSlotsDisplay.ToString(),
                        DeviceId = this.IpAddress,
                        EventTime = DateTime.Now,
                        UpdateText = value.ToString(),
                    });
                    currentSlotsDisplay = value;
                }
            }
        }
        public bool ChangeCurrentSlotsAvailable(int slotsCount, ref string errorMessage, IndoorLedColor.EmPGSIndoorLedColor color = IndoorLedColor.EmPGSIndoorLedColor.Red,
                                                IndoorLedArrow.EmPGSIndoorLedArrow arrow = IndoorLedArrow.EmPGSIndoorLedArrow.Left_Down, int address = 1)
        {
            string cmd = pgs_cmd.ChangeDisplayCmd(slotsCount, color, arrow, address);
            if (GeneralSetCmd(cmd))
            {
                this.CurrentSlotsDisplay = slotsCount;
                return true;
            }
            return false;
        }
        #endregion: END DISPLAY

        #region: NETWORK
        public bool GetIpAddress(ref string ipAddress, ref string errorMessage)
        {
            string cmd = pgs_cmd.AutoDetectCmd();
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
        public bool GetGateway(ref string gateway, ref string errorMessage)
        {
            string cmd = pgs_cmd.AutoDetectCmd();
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
        public bool GetSubnetMask(ref string subnetMask, ref string errorMessage)
        {
            string cmd = pgs_cmd.AutoDetectCmd();
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
        public bool ChangeIpAddress(string ipAddress, string subnetMask, string gateWay, ref string errorMessage)
        {
            string macAddress = string.Empty;
            if (!GetMacAddress(ref macAddress, ref errorMessage))
                return false;
            string cmd = pgs_cmd.ChangeIpAddress(ipAddress, gateWay, macAddress, subnetMask);
            if (GeneralSetCmd(cmd))
            {
                this.IpAddress = ipAddress;
                return true;
            }
            return false;
        }
        #endregion: END NETWORK

        #region: SYSTEM
        public bool GetFirmwareVersion(ref string firmwareVersion, ref string errorMessage)
        {
            string cmd = pgs_cmd.AutoDetectCmd();
            string response = UdpTools.ExecuteCommand_Ascii(this.IpAddress, 100, cmd);
            if (response != null && response.Length > 0)
            {
                string[] _responses = response.Split('/');
                if (_responses.Length > 0)
                {
                    firmwareVersion = _responses[0].Substring(1);
                    return true;
                }
            }
            return false;
        }
        public bool GetMacAddress(ref string macAddress, ref string errorMessage)
        {
            string cmd = pgs_cmd.AutoDetectCmd();
            string response = UdpTools.ExecuteCommand_Ascii(this.IpAddress, 100, cmd);
            if (response != null && response.Length > 0)
            {
                string[] _responses = response.Split('/');
                if (_responses.Length > 5)
                {
                    macAddress = _responses[5];
                    macAddress = macAddress[..^1];
                    return true;
                }
            }
            return false;
        }
        public bool ChangeMacAddress(string macAddress, ref string errorMessage)
        {
            string cmd = pgs_cmd.ChangeMacAddress(macAddress);
            if (GeneralSetCmd(cmd))
            {
                return true;
            }
            return false;
        }
        #endregion: END SYSTEM

        #region: POLLING START
        public void PollingStartCheckConnection()
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
        public void PollingStopCheckConnection()
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
        #endregion: END POLLING START

        #region: Private
        public bool GeneralSetCmd(string cmd)
        {
            string response = UdpTools.ExecuteCommand_Ascii(this.IpAddress, 100, cmd);
            if (UdpTools.IsSuccess(response, "OK"))
            {
                return true;
            }
            return false;
        }
        #endregion: End Private
    }
}
