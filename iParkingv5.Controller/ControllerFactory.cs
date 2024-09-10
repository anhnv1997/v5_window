using iParkingv5.Controller.Aopu;
using iParkingv5.Controller.Dahua;
using iParkingv5.Controller.Ingress;
using iParkingv5.Controller.KztekDevices.KZE02NETControllerv2;
using iParkingv5.Controller.KztekDevices.KZE16AccessControl;
using iParkingv5.Controller.ZktecoDevices.PULL;
using iParkingv6.Objects.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iParkingv5.Controller
{
    public class ControllerFactory
    {
        public static IController? CreateController(Bdk bdk)
        {
            return (EmControllerType)bdk.Type switch
            {
                EmControllerType.IDTECK => new KzE02Netv2() { ControllerInfo = bdk },
                EmControllerType.KZE02_NET => new KzE02Netv2() { ControllerInfo = bdk },
                EmControllerType.KZE16_NET => new KzE16Net() { ControllerInfo = bdk },
                EmControllerType.MT166 => null,
                EmControllerType.INGRESSUS => new ZktecoPull() { ControllerInfo = bdk },
                EmControllerType.E02_NET => new AopuController() { ControllerInfo = bdk },
                EmControllerType.SC200 => new SC200Devices.SC200() { ControllerInfo = bdk },
                //EmControllerType.Dahua => new DahuaAccessControl(bdk.Id) { ControllerInfo = bdk },
                _ => null,
            };
        }

        public enum EmControllerType
        {
            IDTECK = 0,
            KZE02_NET = 1,
            KZE16_NET = 2,
            MT166 = 3,
            INGRESSUS = 4,
            E02_NET = 5,
            SC200 = 6,
            Dahua = 7,
        }
    }
}
