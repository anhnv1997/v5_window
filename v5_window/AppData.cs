using iParkingv5.ApiManager.interfaces;
using iParkingv5.ApiManager.KzParkingv5Apis;
using iParkingv5.LprDetecter.LprDetecters;
using iParkingv5.Objects.Configs;
using iParkingv5.Printer;

namespace iParkingv5_window
{
    public static class AppData
    {
        public static iParkingApi ApiServer = new KzParkingv5ApiHelper();
        public static iPrinter printer = new DefaultPrinter();
        public static LprConfig lprConfig = new LprConfig();
        public static ILpr LprDetect;
        public static ILpr LprDetect2;
        public static ILpr LprDetect3;
        public static ILpr LprDetect4;
        public static EmVirtualLoopMode isUseVirtualLoop = EmVirtualLoopMode.UnUsed;
        public static int alarmLLevel = 5;
    }
}
