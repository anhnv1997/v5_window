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
        List<CardEventArgs> lastCardEventDatas { get; set; }
        List<InputEventArgs> lastInputEventDatas { get; set; }  
        Task OnNewEvent(EventArgs e);
        bool SaveUIConfig();
    }
}
