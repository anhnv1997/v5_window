using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.ApiManager.TienPhong
{
    public static class TienPhongUrlManagement
    {
        public static string GetAskOpen() => "/Barrier/AskOpen";                         // request when vehicle started in/out
        public static string ParkingLotBarrier() => "/Truck/TruckParkingLotBarrier";     // request when confirm vehicle end in/out
        public static string ParkingLotSensor() => "/Truck/TruckParkingLotSensor";       // request when sensor change 
        public static string GetLedView() => "/Led/View";                                // request get list information vehicle
    }
}
