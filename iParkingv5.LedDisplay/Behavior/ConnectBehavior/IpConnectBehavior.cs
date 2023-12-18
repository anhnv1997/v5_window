using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.LedDisplay.Behavior.ConnectBehavior
{
    public class IpConnectBehavior : iConnectBehavior
    {
        public bool Connect(string ip, int port, string username = "", string password = "")
        {
            return true;
        }

        public bool Disconnect(string ip, int port, string username = "", string password = "")
        {
            return false;
        }
    }
}
