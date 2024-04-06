using iParkingv5.Objects.Configs;
using iParkingv5.Objects.Events;
using iParkingv6.Objects.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iParkingv5_window.Usercontrols
{
    public interface iLane
    {
        bool isScale { get; set; }
        int ScaleValue { get; set; }

        event OnControlSizeChanged onControlSizeChangeEvent;
        event OnChangeLaneEvent OnChangeLaneEvent;
        Lane lane { get; set; }
        List<CardEventArgs> lastCardEventDatas { get; set; }
        List<InputEventArgs> lastInputEventDatas { get; set; }
        Task OnNewEvent(EventArgs e);
        void OnKeyPress(Keys keys);
        LaneDisplayConfig SaveUIConfig();
        void GetShortcutConfig();
        void DisplayUIConfig();
    }
}
