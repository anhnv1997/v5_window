using iParkingv5.Objects.Configs;
using iParkingv5.Objects.Datas.Device_service;
using iParkingv5.Objects.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iParkingv5_window.Usercontrols
{
    public interface iLane
    {
        event OnChangeLaneEvent OnChangeLaneEvent;
        Lane lane { get; set; }
        List<CardEventArgs> lastCardEventDatas { get; set; }
        List<InputEventArgs> lastInputEventDatas { get; set; }
        Task OnNewEvent(EventArgs e);
        void OnKeyPress(Keys keys);
        LaneDisplayConfig GetCurrentUIConfig();
        void GetShortcutConfig();
        void LoadSavedUIConfig();
        void DispayUI();
    }
}
