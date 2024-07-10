using iParkingv5.ApiManager.interfaces;
using iParkingv5.ApiManager.KzParkingv5Apis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IParkingv5.RegisterCard
{
    public class AppData
    {
        public static iParkingApi ApiServer = new KzParkingv5ApiHelper();
    }
}
