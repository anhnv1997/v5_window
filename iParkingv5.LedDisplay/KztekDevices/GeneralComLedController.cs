using iParkingv5.LedDisplay.Behavior.ConnectBehavior;
using iParkingv5.LedDisplay.Enums;
using iParkingv5.LedDisplay.Interface;
using iParkingv5.LedDisplay.Interface.iCommand;
using iParkingv5.LedDisplay.Interface.iDevice;
using iParkingv5.Objects.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace iParkingv5.LedDisplay.KztekDevices
{
    public class GeneralComLedController : iComLed
    {
        #region: Properties
        public string ComPort { get; set; } = string.Empty;
        public int Baudrate { get; set; }
        public EmComArrowType Arrow { get; set; }
        public EmComColor Color { get; set; }
        public string CurrentDisplayData { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public EmModuleType ModuleType { get; set; }

        public event ConnectStatusChangeEventHandler ConnectStatusChangeEvent;
        public event ErrorEventHandler ErrorEvent;
        public event DisplayTextChangeEventHandler DisplayTextChangeEvent;

        public iConnectBehavior ConnectBehavior { get; set; } = new ComConnectBehavior();
        public iCMD CmdController { get; set; } = new ip_v1_cmd_controller();
        public dynamic LedController { get; set; }
        #endregion: End Properties

        #region: Constructor
        public GeneralComLedController()
        {
            ConnectStatusChangeEvent += GeneralComLedController_ConnectStatusChangeEvent;
            ErrorEvent += GeneralComLedController_ErrorEvent;
            DisplayTextChangeEvent += GeneralComLedController_DisplayTextChangeEvent;
        }

        private void GeneralComLedController_DisplayTextChangeEvent(object? sender, TextChangeEventArgs e)
        {
            DisplayTextChangeEvent?.Invoke(sender, e);
        }

        private void GeneralComLedController_ErrorEvent(object? sender, ErrorEventArgs e)
        {
            ErrorEvent?.Invoke(sender, e);
        }

        private void GeneralComLedController_ConnectStatusChangeEvent(object? sender, ConnectStatusCHangeEventArgs e)
        {
            ConnectStatusChangeEvent?.Invoke(sender, e);
        }
        #endregion: End Constructor

        #region: LOOP
        public void PollingStart()
        {

        }
        public void PollingStop()
        {

        }
        #endregion: END LOOP

        #region: Public Func
        public bool ChangeDisplay(string displayData, ref string errorMessage)
        {
            return false;
        }

        public bool Connect(string comport, int baudrate, string username = "", string password = "")
        {
            this.ComPort = comport;
            this.Baudrate = baudrate;
            this.Username = username;
            this.Password = password;
            return ConnectBehavior.Connect(this.ComPort, this.Baudrate, this.Username, this.Password);
        }

        public bool Disconnect(string comport, int baudrate, string username = "", string password = "")
        {
            return ConnectBehavior.Disconnect(this.ComPort, this.Baudrate, this.Username, this.Password);
        }

        public void Stop(bool a)
        {
            throw new NotImplementedException();
        }
        #endregion: End Public Func
    }
}
