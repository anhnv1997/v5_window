using iParkingv5.Objects;
using iParkingv5.Objects.Enums;
using Kztek.LPR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iParkingv5_window
{
    public class LprDetect
    {
        public static string GetPlateNumber(LPRDetecter.EmLprDetecter lprDetecter, Image? img, out Image? lprImage)
        {
            string plateNumber = string.Empty;
            lprImage = null;
            if (img == null) return string.Empty;

            switch (lprDetecter)
            {
                case LPRDetecter.EmLprDetecter.KztekLpr:
                    var lPRObject_Result = new LPRObject();
                    lPRObject_Result.enableMultiplePlateNumber = true;
                    lPRObject_Result.vehicleImage = (Bitmap)img;
                    StaticPool.carANPR.Analyze(ref lPRObject_Result);
                    plateNumber = lPRObject_Result.plateNumber;
                    lprImage = lPRObject_Result.plateImage;
                    break;
                case LPRDetecter.EmLprDetecter.AmericalDocker:
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(plateNumber))
            {
                plateNumber = StandardlizePlateNumber(plateNumber);
            }
            return plateNumber;
        }
        public static string StandardlizePlateNumber(string plateNumber)
        {
            if (plateNumber.Length > 3 && plateNumber[2].ToString() == "-")
            {
                plateNumber = plateNumber.Remove(2, 1);
            }
            if (plateNumber.Length > 2 && plateNumber.Substring(0, 2) == "BB")
            {
                plateNumber = "88" + plateNumber.Substring(2);
            }
            return plateNumber;
        }
    }
}
