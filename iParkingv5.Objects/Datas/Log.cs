using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv6.Objects.Datas
{
    public class Log
    {
        public string Id { get; set; }
        public string LogID { get; set; }
        public DateTime? Date { get; set; }
        public string UserName { get; set; }
        public string AppCode { get; set; }
        public string SubSystemCode { get; set; }
        public string ObjectName { get; set; }
        public string Actions { get; set; }
        public string Description { get; set; }
        public string IPAddress { get; set; }
        public string ComputerName { get; set; }
    }
}
