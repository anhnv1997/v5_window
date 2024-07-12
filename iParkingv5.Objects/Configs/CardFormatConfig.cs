using iParkingv5.Objects.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Configs
{
    public class CardFormatConfig
    {
        public int ReaderIndex { get; set; }
        public CardFormat.EmCardFormat InputFormat { get; set; } = CardFormat.EmCardFormat.HEXA;
        public CardFormat.EmCardFormat OutputFormat { get; set; } = CardFormat.EmCardFormat.HEXA;
        public CardFormat.EmCardFormatOption OutputOption { get; set; } = CardFormat.EmCardFormatOption.Toi_Gian;
    }
}
