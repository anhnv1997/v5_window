using System;
using System.Collections.Generic;
using System.Text;
using static iParkingv5.Objects.Enums.CardType;

namespace iParkingv5.Objects.Enums
{
    public class VehicleType
    {
        public enum EmVehicleType
        {
            /// <summary>
            /// Không định nghĩa
            /// </summary>
            Unknown = -1,

            /// <summary>
            /// Xe ô tô
            /// </summary>
            Car = 0,

            /// <summary>
            /// xe máy
            /// </summary>
            MotorBike = 1,

            /// <summary>
            /// Xe đạp
            /// </summary>
            Bicyle = 2,

            /// <summary>
            /// Xe máy điện
            /// </summary>
            ElectricalBike = 3,
        }
        public static string GetDisplayStr(EmVehicleType type)
        {
            switch (type)
            {
                case EmVehicleType.Unknown:
                    return "Không đinh nghĩa";
                case EmVehicleType.Car:
                    return "Xe ô tô";
                case EmVehicleType.MotorBike:
                    return "Xe máy";
                case EmVehicleType.Bicyle:
                    return "Xe đạp";
                case EmVehicleType.ElectricalBike:
                    return "Xe máy điện";
                default:
                    return string.Empty;
            }
        }
    }
}
