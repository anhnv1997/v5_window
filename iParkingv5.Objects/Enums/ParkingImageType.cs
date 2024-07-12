using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Enums
{
    public class ParkingImageType
    {
        public enum EmParkingImageType
        {
            Overview,
            Vehicle,
            Plate,
        }
        public static string ToString(EmParkingImageType parkingImageType)
        {
            switch (parkingImageType)
            {
                case EmParkingImageType.Overview:
                    return "Ảnh toàn cảnh";
                case EmParkingImageType.Vehicle:
                    return "Ảnh phương tiện";
                case EmParkingImageType.Plate:
                    return "Ảnh biển số xe";
                default:
                    return "";
            }
        }
    }
}
