namespace IPaking.Ultility
{
    public static class UltilityManagement
    {
        public static string timeFormat = "HH:mm:ss";
        public static string dayFormat = "dd/MM/yyyy";
        public static string UTCFormat = "yyyy-MM-ddTHH:mm:ss:ffff";
        public static string fullDayFormat = "dd/MM/yyyy HH:mm:ss";

        public static string ToVNTime(this DateTime? time)
        {
            return time?.ToString(fullDayFormat) ??"";
        }
    }
}
