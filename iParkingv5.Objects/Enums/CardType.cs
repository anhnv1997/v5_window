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
            Monthly = 0,

            /// <summary>
            /// Vé ngày
            /// </summary>
            Daily = 1,

            /// <summary>
            /// vé vip
            /// </summary>
            Free = 2,

            /// <summary>
            /// Vé master
            /// </summary>
            VIP = 3
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
                case EmCardType.Free:
                    return "Vé miễn phí";
                default:
                    return string.Empty;
            }
        }

    }
}
