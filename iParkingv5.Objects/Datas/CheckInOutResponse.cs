using iParkingv5.Objects.EventDatas;
using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Datas
{
    public class CheckInOutResponse
    {
        public bool IsValidEvent { get; set; }
        public bool IsContinueExcecute { get; set; }
        public EventInData? eventIn { get; set; }
        public string ErrorMessage { get; set; } = "";
        public BaseErrorData? ErrorData { get; set; } = null;
    }
}
