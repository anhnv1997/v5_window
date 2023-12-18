using iParkingv5.LedDisplay.Behavior.ConnectBehavior;
using iParkingv5.LedDisplay.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.LedDisplay.Interface.iDevice
{
    public interface iBaseLed
    {
        iConnectBehavior ConnectBehavior { get; set; }
        string Username { get; set; }
        string Password { get; set; }

        void PollingStart();
        void PollingStop();

        bool Connect(string ip, int port, string username = "", string password = "");
        bool Disconnect(string ip, int port, string username = "", string password = "");

        EmModuleType ModuleType { get; set; }
        dynamic LedController { get; set; }

        void Stop(bool a);
    }
}
