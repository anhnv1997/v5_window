using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Enums
{
    public class LaneDisplayMode
    {
        public enum EmLaneDisplayMode
        {
            Vertical,
            Horizontal
        }
        public static string ToString(EmLaneDisplayMode displayMode)
        {
            switch (displayMode)
            {
                case EmLaneDisplayMode.Vertical:
                    return "Giao diện dọc";
                case EmLaneDisplayMode.Horizontal:
                    return "Giao diện ngang";
                default:
                    return string.Empty;
            }
        }
    }
}
