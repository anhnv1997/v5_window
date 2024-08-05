using iParkingv5.ApiManager.interfaces;
using iParkingv5.ApiManager.KzParkingv5Apis;
using iParkingv5.Printer;

namespace iParkingv5_window
{
    public static class AppData
    {
        public static iParkingApi ApiServer = new KzParkingv5ApiHelper();
        public static iPrinter printer = new DefaultPrinter();
    }
}
