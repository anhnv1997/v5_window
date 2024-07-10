using iParkingv5.Objects.Datas.parking;
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
            /// xe máy
            /// </summary>
            MotorBike = 2,

            /// <summary>
            /// Xe đạp
            /// </summary>
            Bike = 4,
        }
        public static string GetDisplayStr(VehicleBaseType type)
        {
            switch (type)
            {
                case VehicleBaseType.Unknown:
                    return "Không đinh nghĩa";
                case VehicleBaseType.Car:
                    return "Xe ô tô";
                case VehicleBaseType.MotorBike:
                    return "Xe máy";
                case VehicleBaseType.Bike:
                    return "Xe đạp";
                default:
                    return string.Empty;
            }
        }

        public string Id { get; set; }

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
        public static string GetVehicleTypeName(List<VehicleType>? vehicleTypes, string id)
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
