using iParkingv5.LedDisplay.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.LedDisplay.Objects
{
    public class ScrollSetting
    {
        int startIndex;
        int endIndex;
        EmScrollDirection eM_ScrollDirection;
        int scrollDelayTime;

        public int StartIndex { get => startIndex; set => startIndex = value; }
        public int EndIndex { get => endIndex; set => endIndex = value; }
        public EmScrollDirection EM_ScrollDirection { get => eM_ScrollDirection; set => eM_ScrollDirection = value; }
        public int TimeOut { get => scrollDelayTime; set => scrollDelayTime = value; }
    }
}
