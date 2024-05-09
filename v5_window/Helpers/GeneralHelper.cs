using iParkingv5.Objects.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iParkingv5_window.Helpers
{
    public static class GeneralHelper
    {
        public static void DrawTooltip(this DrawToolTipEventArgs e, string text)
        {
            Font customFont = new Font("Arial", 16, FontStyle.Bold);
            e.DrawBackground();
            e.DrawBorder();
            e.Graphics.DrawString(text, customFont, Brushes.Black, new PointF(2, 2));
        }
    }
}
