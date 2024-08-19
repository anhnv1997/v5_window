using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Datas
{
    public class ConnectionInfo
    {
        public bool IsUsingSecondScreen { get; set; } = false;


        public string UserName { get; set; } = "";


        public string Password { get; set; } = "";


        public string HostName { get; set; } = "";


        public int Port { get; set; } = 0;


        public int TimeQRExpired { get; set; } = 0;


        public int TimeDone { get; set; } = 0;


        public int TimeClearList { get; set; } = 0;
    }
}
