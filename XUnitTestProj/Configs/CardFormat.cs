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
            Type1,
            Type2,
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
                default:
                    return option.ToString();
            }
        }
    }
}
