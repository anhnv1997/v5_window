using static iParkingv5.Objects.Enums.InputTupe;

namespace ALSE
{
    public delegate void OnBarrieChangeStatusEventHandler(object sender, BarrieChangeStatusEventArgs e);
    public class BarrieChangeStatusEventArgs : EventArgs
    {
        public string ControllerID { get; set; } = string.Empty;
        public string ControllerName { get; set; } = string.Empty;
        public int NewPosition { get; set; } = 0;
        public string NewErrorStatus { get; set; } = string.Empty;
    }


    public delegate void ControllerErrorEventHandler(object sender, ControllerErrorEventArgs e);
    public class ControllerErrorEventArgs : EventArgs
    {
        public string ControllerId { get; set; } = string.Empty;
        public string ControllerName { get; set; } = string.Empty;
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
        public string ControllerName { get; set; } = string.Empty;
        public DateTime EventTime { get; set; } = DateTime.Now;
        public int InputIndex { get; set; }
        public EmInputType InputType { get; set; }
        public string Status { get; set; }
    }

    public delegate void CardEventHandler(object sender, CardEventArgs e);
    public class CardEventArgs : EventArgs
    {
        public string ControllerID { get; set; } = string.Empty;
        public string ControllerName { get; set; } = string.Empty;
        public List<string> AllCardFormats { get; set; } = new List<string>();
        public int ReaderIndex { get; set; }
        public DateTime EventTime { get; set; } = DateTime.Now;
        public string Doors { get; set; }
        public string PreferCard { get; set; }

        public bool IsInWaitingTime(CardEventArgs e, int waitingTime, out int thoiGianCho)
        {
            thoiGianCho = 0;
            if (ControllerID != e.ControllerID)
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

            double v = Math.Abs((EventTime - e.EventTime).TotalMilliseconds);
            if (v < waitingTime)
            {
                thoiGianCho = (int)(waitingTime - v);
                return true;
            }
            return false;
        }
    }

    public delegate void ConnectStatusChangeEventHandler(object sender, ConnectStatusCHangeEventArgs e);
    public class ConnectStatusCHangeEventArgs : EventArgs
    {
        public string ControllerID { get; set; }
        public string ControllerName { get; set; } = string.Empty;
        public DateTime EventTime { get; set; } = DateTime.Now;
        public bool CurrentStatus { get; set; }
        public string Reason { get; set; }
    }

    public delegate void InfoChangeEventHandler(object sender, DeviceInfoChangeArgs e);
    public class DeviceInfoChangeArgs
    {
        public string ControllerId { get; set; } = string.Empty;
        public string ControllerName { get; set; } = string.Empty;
        public string InfoKey { get; set; } = string.Empty;
        public string OldValue { get; set; } = string.Empty;
        public string NewValue { get; set; } = string.Empty;
    }
}