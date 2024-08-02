using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.EventDatas
{
    public class BaseErrorData
    {
        public List<ErrorDescription> fields { get; set; } = null;
        public bool IsSuccess { get; set; } = true;
        public string message { get; set; } = string.Empty;
        public string errorCode { get; set; } = string.Empty;
        public string detailCode { get; set; } = string.Empty;
        public Dictionary<string, object> Payload { get; set; }
    }
}
