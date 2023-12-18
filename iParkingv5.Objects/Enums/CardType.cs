using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Enums
{
    public class CardType
    {
        public enum EmCardType
        {
            /// <summary>
            /// Không định nghĩa
            /// </summary>
            Unknown = -1,

            /// <summary>
            /// Vé tháng
            /// </summary>
            Monthly = 1,

            /// <summary>
            /// Vé ngày
            /// </summary>
            Daily = 2,

            /// <summary>
            /// vé vip
            /// </summary>
            VIP = 3,

            /// <summary>
            /// Vé master
            /// </summary>
            Master = 4
        }
        public static string GetDisplayStr(EmCardType type)
        {
            switch (type)
            {
                case EmCardType.Unknown:
                    return "Không định nghĩa";
                case EmCardType.Monthly:
                    return "Vé tháng";
                case EmCardType.Daily:
                    return "Vé ngày";
                case EmCardType.VIP:
                    return "Vé vip";
                case EmCardType.Master:
                    return " Vé master";
                default:
                    return string.Empty;
            }
        }

    }
}
