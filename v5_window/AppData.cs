﻿using iParkingv5.ApiManager.interfaces;
using iParkingv5.ApiManager.KzParkingv5Apis;

namespace iParkingv5_window
{
    public static class AppData
    {
        public static iParkingApi ApiServer = new KzParkingv5ApiHelper();
    }
}
