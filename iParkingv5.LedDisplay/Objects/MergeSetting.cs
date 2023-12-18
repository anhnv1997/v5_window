using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.LedDisplay.Objects
{
    public class MergeSetting
    {
        int startIndex;
        int mergeRowsCount;
        char splitLineChar;
        string displayText = string.Empty;

        public int StartIndex { get => startIndex; set => startIndex = value; }
        public int EndIndex { get => mergeRowsCount; set => mergeRowsCount = value; }
        public char SplitLineChar { get => splitLineChar; set => splitLineChar = value; }
        public string DisplayText { get => displayText; set => displayText = value; }
    }
}
