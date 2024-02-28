using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Configs
{
    public class LaneDirectionConfig
    {
        public enum EmDisplayDirection
        {
            Vertical = 0,
            HorizontalLeftToRight = 1,
            HorizontalRightToLeft = 2,
        }
        public EmDisplayDirection displayDirection = EmDisplayDirection.HorizontalLeftToRight;
        public bool IsDisplayTitle { get; set; } = true;

        public static LaneDirectionConfig CreateDefault()
        {
            return new LaneDirectionConfig()
            {
                displayDirection = EmDisplayDirection.HorizontalLeftToRight,
                IsDisplayTitle = true
            };
        }
    }
}
