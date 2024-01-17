using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iParkingv5_window.Controls.Buttons
{
    public interface IDesignControl
    {
        void Init(EventHandler? OnClickEvent);
        void EnableWaitMode();
        void Reset();
    }
}
