using iParkingv5.Objects.Datas;
using System;
using System.Collections.Generic;
using System.Text;
using static iParkingv5.Objects.Enums.CardType;

namespace iParkingv5.Objects.Enums
{
    public class VehicleType
    {
        public enum VehicleBaseType
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
            /// Ô tô điện
            /// </summary>
            ElectricalCar = 1,

            /// <summary>
            /// xe máy
            /// </summary>
            MotorBike = 2,

            /// <summary>
            /// Xe máy điện
            /// </summary>
            ElectricalMotorBike = 3,

            /// <summary>
            /// Xe đạp
            /// </summary>
            Bicyle = 4,

            /// <summary>
            /// Xe máy điện
            /// </summary>
            ElectricalBike = 5,
        }
        public static string GetDisplayStr(VehicleBaseType type)
        {
            switch (type)
            {
                case VehicleBaseType.Unknown:
                    return "Không đinh nghĩa";
                case VehicleBaseType.Car:
                    return "Xe ô tô";
                case VehicleBaseType.ElectricalCar:
                    return "Xe ô tô điện";
                case VehicleBaseType.MotorBike:
                    return "Xe máy";
                case VehicleBaseType.ElectricalMotorBike:
                    return "Xe máy điện";
                case VehicleBaseType.Bicyle:
                    return "Xe đạp";
                case VehicleBaseType.ElectricalBike:
                    return "Xe máy điện";
                default:
                    return string.Empty;
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Xe máy, ô tô, etc..
        /// </summary>
        public VehicleBaseType Type { get; set; }

        public int? LimitParkingSlot { get; set; }
        public bool Enabled { get; set; }
        public bool Deleted { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }

        public ICollection<IdentityGroup> IdentityGroups { get; set; }
        public ICollection<RegisteredVehicle> RegisteredVehicles { get; set; }

        public VehicleType()
        {
            IdentityGroups = new List<IdentityGroup>();
            RegisteredVehicles = new List<RegisteredVehicle>();
        }
        public static string GetVehicleTypeName(List<VehicleType>? vehicleTypes, int id)
        {
            if (vehicleTypes == null)
            {
                return string.Empty;
            }
            foreach (var item in vehicleTypes)
            {
                if (item.Id == id)
                {
                    return item.Name;
                }
            }
            return string.Empty;
        }

    }
}
