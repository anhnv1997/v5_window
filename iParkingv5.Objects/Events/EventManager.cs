using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static iParkingv5.Objects.Enums.InputTupe;

namespace iParkingv5.Objects.Events
{
    public delegate void ControllerErrorEventHandler(object sender, ControllerErrorEventArgs e);
    public delegate void InputEventHandler(object sender, InputEventArgs e);
    public delegate void CardEventHandler(object sender, CardEventArgs e);
    public delegate void ConnectStatusChangeEventHandler(object sender, ConnectStatusCHangeEventArgs e);
    public delegate void DeviceInfoChangeEventHandler(object sender, DeviceInfoChangeArgs e);
    public delegate void DisplayTextChangeEventHandler(object? sender, TextChangeEventArgs e);
    public delegate void FingerEventHandler(object sender, FingerEventArgs e);
    public delegate void OnChangeLaneEvent(object sender);
    public delegate void OnControlSizeChanged(object sender, ControlSizeChangedEventArgs type);

    public class ControlSizeChangedEventArgs : EventArgs
    {
        public int Type { get; set; }
        public  int NewX { get; set; }
        public  int NewY { get; set; }
        public int NewDistance { get; set; }
    }
    public class GeneralEventArgs : EventArgs
    {
        public string DeviceId { get; set; } = string.Empty;
        public string DeviceName { get; set; } = string.Empty;
        public DateTime EventTime { get; set; } = DateTime.Now;
    }


    public class ControllerErrorEventArgs : GeneralEventArgs
    {
        public string ErrorString { get; set; } = string.Empty;
        public string ErrorFunc { get; set; } = string.Empty;
        public string ErrorLine { get; set; } = string.Empty;
        public string CMD { get; set; } = string.Empty;
    }
    public class InputEventArgs : GeneralEventArgs
    {
        public int InputIndex { get; set; }
        public EmInputType InputType { get; set; }
        public string Status { get; set; }
    }
    public class CardEventArgs : GeneralEventArgs
    {
        public List<string> AllCardFormats { get; set; } = new List<string>();
        public string PreferCard { get; set; } = string.Empty;
        public int ReaderIndex { get; set; }
        public string Doors { get; set; }
        public string PlateNumber { get; set; } = string.Empty;
        public bool IsInWaitingTime(CardEventArgs e, int waitingTime, out int thoiGianCho)
        {
            thoiGianCho = 0;
            if (DeviceId != e.DeviceId)
            {
                return false;
            }
            if (ReaderIndex != e.ReaderIndex)
            {
                return false;
            }
            if (AllCardFormats.Count != e.AllCardFormats.Count)
            {
                return false;
            }
            foreach (string format in AllCardFormats)
            {
                if (!e.AllCardFormats.Contains(format))
                {
                    return false;
                }
            }

            double v = Math.Abs((EventTime - e.EventTime).TotalSeconds);
            if (v < waitingTime)
            {
                thoiGianCho = (int)(waitingTime - v);
                return true;
            }
            return false;
        }
    }
    public class FingerEventArgs : GeneralEventArgs
    {
        public string UserId { get; set; }
        public int ReaderIndex { get; set; }
    }

    public class ConnectStatusCHangeEventArgs : GeneralEventArgs
    {
        public bool CurrentStatus { get; set; }
        public string Reason { get; set; }
    }
    public class DeviceInfoChangeArgs : GeneralEventArgs
    {
        public string InfoKey { get; set; } = string.Empty;
        public string OldValue { get; set; } = string.Empty;
        public string NewValue { get; set; } = string.Empty;
    }
    public class TextChangeEventArgs : GeneralEventArgs
    {
        public string CurrentText { get; set; } = string.Empty;
        public string UpdateText { get; set; } = string.Empty;
        public string Cmd { get;set; } = string.Empty;
    }
}
