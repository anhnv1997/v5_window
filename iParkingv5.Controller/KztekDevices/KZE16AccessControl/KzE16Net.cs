using iParkingv5.Controller.KztekDevices.KZE02NETController;
using iParkingv5.Objects.Events;
using Kztek.Tool.SocketHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace iParkingv5.Controller.KztekDevices.KZE16AccessControl
{
    public class KzE16Net : KzE02Net
    {
        public override async Task<bool> OpenDoor(int timeInMilisecond, int relayIndex)
        {
            string comport = this.ControllerInfo.comport;
            int baudrate = GetBaudrate(this.ControllerInfo.baudrate);
            string openRelayCmd = $"SetRelayPulse?/Relay={relayIndex:00}";

            this.IsBusy = true;
            string response = string.Empty;
            await Task.Run(() =>
            {
                response = UdpTools.ExecuteCommand(comport, baudrate, openRelayCmd, 500, UdpTools.STX, Encoding.ASCII);
            });
            this.IsBusy = false;
            if (UdpTools.IsSuccess(response, "OK"))
            {
                return true;
            }
            else if (UdpTools.IsSuccess(response, "ERR"))
            {
                return false;
            }
            OnErrorEvent(new ControllerErrorEventArgs()
            {
                ErrorString = response,
                ErrorFunc = "OpenDoor",
                CMD = openRelayCmd
            });
            return false;
        }

    }
}
