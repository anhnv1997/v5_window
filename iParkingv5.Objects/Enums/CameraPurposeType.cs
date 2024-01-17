using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Enums
{
    public class CameraPurposeType
    {
        public enum EmCameraPurposeType
        {
            /// <summary>
            /// camera toan canh chinh
            /// </summary>
            MainOverView = 3,

            /// <summary>
            /// Camera biển số oto
            /// </summary>
            CarLPR = 2,

            /// <summary>
            /// Camera biển số xe máy
            /// </summary>
            MotorLPR = 1,

            /// <summary>
            /// Camera toàn cảnh phụ
            /// </summary>
            SubOverView = 4,
        }
        public static string GetDisplayStr(EmCameraPurposeType type)
        {
            switch (type)
            {
                case EmCameraPurposeType.MainOverView:
                    return "Camera toàn cảnh chính";
                case EmCameraPurposeType.CarLPR:
                    return "Camera biển số ô tô";
                case EmCameraPurposeType.MotorLPR:
                    return "Camera biển số xe máy";
                case EmCameraPurposeType.SubOverView:
                    return "Camera toàn cảnh phụ";
                default:
                    return string.Empty;
            }
        }
    }
}
