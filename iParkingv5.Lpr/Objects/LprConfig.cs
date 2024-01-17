using System;
using System.Collections.Generic;
using System.Text;
using static iParkingv5.LprDetecter.Objects.LprDetecter;

namespace iParkingv5.Lpr.Objects
{
    public class LprConfig
    {
        public EmLprDetecter LPRDetecterType { get; set; } = EmLprDetecter.KztekLpr;
        public string Url { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
