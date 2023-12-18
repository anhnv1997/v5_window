using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.LedDisplay.Enums
{
    public enum EmFontSize
    {
        FontSize_7,
        FontSize_8,
        FontSize_10,
        FontSize_12,
        FontSize_13,
        FontSize_14,
        FontSize_16,
        FontSize_23,
        FontSize_24,
        FontSize_25,
        FontSize_26,
    }

    public class LedFontsizes
    {
        public Dictionary<string, int> dislayPointsCount = new Dictionary<string, int>()
        {
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
            {"a",1},{"A",1},
        };

        private static Dictionary<EmFontSize, int> Fontsize_str = new Dictionary<EmFontSize, int>() {
            {EmFontSize.FontSize_7,7 },
            {EmFontSize.FontSize_8,8 },
            {EmFontSize.FontSize_10,10 },
            {EmFontSize.FontSize_12,12 },
            {EmFontSize.FontSize_13,13 },
            {EmFontSize.FontSize_14,14 },
            {EmFontSize.FontSize_16,16 },
            {EmFontSize.FontSize_23,23 },
            {EmFontSize.FontSize_24,24 },
            {EmFontSize.FontSize_25,25 },
            {EmFontSize.FontSize_26,26 },
        };
        public static Dictionary<int, int> MaxLetterDefines = new Dictionary<int, int>()
        {
            {Fontsize_str[EmFontSize.FontSize_7], 11},
            {Fontsize_str[EmFontSize.FontSize_8], 10},
            {Fontsize_str![EmFontSize.FontSize_10], 9},
            {Fontsize_str![EmFontSize.FontSize_12], 8},
            {Fontsize_str![EmFontSize.FontSize_13], 7},
            {Fontsize_str![EmFontSize.FontSize_14], 6},
            {Fontsize_str![EmFontSize.FontSize_16], 5},
            {Fontsize_str![EmFontSize.FontSize_23], 4},
            {Fontsize_str![EmFontSize.FontSize_24], 3},
            {Fontsize_str![EmFontSize.FontSize_25], 2},
            {Fontsize_str![EmFontSize.FontSize_26], 1},
        };
        public static int GetFontsizeInt(EmFontSize fontSize)
        {
            return Fontsize_str[fontSize];
        }
    }

}
