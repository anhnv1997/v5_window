using System;
using System.Collections.Generic;
using System.Text;
using static iParkingv5.Objects.Enums.VehicleType;

namespace iParkingv5.Objects.Enums
{
    public enum CheckPlateMode
    {
        InExactly = 1,
        Exactly,
        NonCompare,
    }

    public enum KieuMoTuDongBarrierVao
    {
        MoiTruongHop = 1,
        TheThangDungBienSoVaTheLuot,
        ChiTheThangDungBienSo,
        ChiTheLuot,
        KhongMo,
    }

    public enum KieuMoTuDongBarrierRa
    {
        MoiTruongHop = 1,
        ChiTheThangDungBienSo,
        TheThangDungBienSoVaTheLuot,
        ChiTheLuotDungBienSo,
        KhongMo,
        TheThang,
        TheLuot,
    }


    public class LaneDirectionType
    {
        public enum EmLaneDirection
        {
            /// <summary>
            /// vào
            /// </summary>
            IN = 1,

            /// <summary>
            /// ra
            /// </summary>
            OUT = 2,
            KIOSK_IN = 3,
            DYNAMIC = 4,

        }
        public static string GetDisplayStr(EmLaneDirection type)
        {
            switch (type)
            {
                case EmLaneDirection.IN:
                    return "Làn vào";
                case EmLaneDirection.OUT:
                    return "Làn ra";
                case EmLaneDirection.KIOSK_IN:
                    return "KIOSK_IN";
                case EmLaneDirection.DYNAMIC:
                    return "DYNAMIC";
                default:
                    return string.Empty;
            }
        }
    }
}
