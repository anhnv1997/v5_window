using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Datas.device_service
{
    // Code them

    public class CardDispenserService
    {
        public int ButtonIndex { get; set; }
        public string CardbeTaken { get; set; }
        public string CardRevertedInTrayValue { get; set; }
        public string CardRevertedInTrayIndex { get; set; }
        public string ButtonAbnormalValue { get; set; }
        public string ButtonAbnormalIndex { get; set; }
        
    }
    public class CardDispenserError
    {
        public int DispenserIndex { get; set; } = 1;
        public bool IsCardEmptyDispenser { get; set; } = false;
        public bool IsLessCardDispenser { get; set; } = false;
        public bool IsCardErrorDispenser { get; set; } = false;
        public string ErrorString { get; set; } = string.Empty;
    }
    
}
