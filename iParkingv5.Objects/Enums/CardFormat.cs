using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Enums
{
    public class CardFormat
    {
        public enum EmCardFormat
        {
            DECIMA,
            HEXA,
            REHEXA,
            REDECIMA,
            XXX_XXXXX,
        }
        public enum EmCardFormatOption
        {
            Toi_Gian,
            Min_8,
            Min_10,
        }
        public static string ToString(EmCardFormat cardFormat)
        {
            switch (cardFormat)
            {
                case EmCardFormat.XXX_XXXXX:
                    return "XXX:XXXXX";
                default:
                    return cardFormat.ToString();
            }
        }
        public static string ToString(EmCardFormatOption option)
        {
            switch (option)
            {
                case EmCardFormatOption.Toi_Gian:
                    return "Tối Giản";
                case EmCardFormatOption.Min_8:
                    return "Tối Thiểu 8 Ký Tự";
                case EmCardFormatOption.Min_10:
                    return "Tối Thiểu 10 Ký Tự";
                default:
                    return "";
            }
        }
    }
}
