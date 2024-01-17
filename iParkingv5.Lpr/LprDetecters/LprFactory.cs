using iParkingv5.Lpr.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iParkingv5.LprDetecter.Events.Events;
using static iParkingv5.LprDetecter.Objects.LprDetecter;

namespace iParkingv5.LprDetecter.LprDetecters
{
    public class LprFactory
    {
        public static ILpr? CreateLprDetecter(LprConfig lprConfig, OnLprDetectComplete? onLprDetectCompleteFunction)
        {
            ILpr? lpr = null;
            switch (lprConfig.LPRDetecterType)
            {
                case Objects.LprDetecter.EmLprDetecter.KztekLpr:
                    lpr = new KztekLpr();
                    break;
                case Objects.LprDetecter.EmLprDetecter.AmericalLpr:
                    lpr = new AmericalLpr();
                    break;
                default:
                    return null;
            }
            lpr.onLprDetectCompleteEvent += onLprDetectCompleteFunction;
            return lpr;
        }

        public static string GetPlateNumber(EmLprDetecter lprDetecter, Image? img, out Image? lprImage)
        {
            string plateNumber = string.Empty;
            lprImage = null;
            if (img == null) return string.Empty;

            switch (lprDetecter)
            {
                case EmLprDetecter.KztekLpr:
                //var lPRObject_Result = new LPRObject
                //{
                //    enableMultiplePlateNumber = true,
                //    vehicleImage = (Bitmap)img
                //};
                //StaticPool.carANPR.Analyze(ref lPRObject_Result);
                //plateNumber = lPRObject_Result.plateNumber;
                //lprImage = lPRObject_Result.plateImage;
                //break;
                case EmLprDetecter.AmericalLpr:
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
