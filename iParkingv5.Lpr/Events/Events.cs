using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iParkingv5.LprDetecter.Events
{
    public class Events
    {
        public delegate void OnLprDetectComplete(object sender, LprDetectEventArgs e);
        public class LprDetectEventArgs : EventArgs
        {
            public Image? OriginalImage { get; set; }
            public Image? LprImage { get; set; }
            public string Result { get; set; } = string.Empty;
        }
    }

}
