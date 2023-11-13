using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Events
{
    public delegate void ControllerErrorEventHandler(object sender, ControllerErrorEventArgs e);
    public class ControllerErrorEventArgs : EventArgs
    {
        public string ControllerId { get; set; } = string.Empty;
        public DateTime EventTime { get; set; } = DateTime.Now;
        public string ErrorString { get; set; } = string.Empty;
        public string ErrorFunc { get; set; } = string.Empty;
        public string ErrorLine { get; set; } = string.Empty;
        public string CMD { get; set; } = string.Empty;
    }

    public delegate void InputEventHandler(object sender, InputEventArgs e);
    public class InputEventArgs : EventArgs
    {
        public string ControllerId { get; set; } = string.Empty;
        public DateTime EventTime { get; set; } = DateTime.Now;
        public string InputIndex { get; set; }
        public string InputName { get; set; }
        public string Status { get; set; }
    }

    public delegate void CardEventHandler(object sender, CardEventArgs e);
    public class CardEventArgs : EventArgs
    {
        public string ControllerID { get; set; } = string.Empty;
        public List<string> AllCardFormats { get; set; } = new List<string>();
        public int ReaderIndex { get; set; }
        public string Date { get; set; } = string.Empty;
        public string EventTime { get; set; } = string.Empty;
        public string Doors { get; set; }
    }

    public delegate void ConnectStatusChangeEventHandler(object sender, ConnectStatusCHangeEventArgs e);
    public class ConnectStatusCHangeEventArgs : EventArgs
    {
        public string ControllerID { get; set; }
        public string EventTime { get; set; } = string.Empty;
        public bool CurrentStatus { get; set; }
        public string Reason { get; set; }
    }

    public delegate void DeviceInfoChangeEventHandler(object sender, DeviceInfoChangeArgs e);
    public class DeviceInfoChangeArgs
    {
        public string ControllerId { get; set; } = string.Empty;
        public string InfoKey { get; set; } = string.Empty;
        public string OldValue { get; set; } = string.Empty;
        public string NewValue { get; set; } = string.Empty;
    }
}
