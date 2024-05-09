using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iParkingv5.Objects
{
    public class SharedPreferences
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsRememberPassword { get; set; }
        public int SplitterMainPosition { get; set; }
        public int SplitterEventDisplayPosition { get; set; }
        public int SplitterCurrentVehiclePosition { get; set; }
    }
}
