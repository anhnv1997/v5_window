using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.LedDisplay.Behavior.ConnectBehavior
{
    public interface iConnectBehavior
    {
        bool Connect(string ip, int port, string username = "", string password = "");
        bool Disconnect(string ip, int port, string username = "", string password = "");
    }
}
