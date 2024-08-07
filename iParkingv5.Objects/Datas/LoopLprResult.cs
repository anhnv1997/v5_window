using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace iParkingv5.Objects.Datas
{

    public class LoopLprResult
    {
        public Image? VehicleImage { get; set; } = null;
        public Image? LprImage { get; set; } = null;
        public RegisteredVehicle? Vehicle { get; set; } = null;
        public string PlateNumber { get; set; } = string.Empty;
    }
}
