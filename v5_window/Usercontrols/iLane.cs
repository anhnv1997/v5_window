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
        Task OnNewEvent(EventArgs e);
        bool SaveUIConfig();
        //Task ExcecuteCardEvent(CardEventArgs ce);
        //Task ExcecuteInputEvent(InputEventArgs ie);
    }
}
