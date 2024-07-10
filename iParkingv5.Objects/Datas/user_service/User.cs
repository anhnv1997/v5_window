using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;

namespace iParkingv5.Objects.Datas.user_service
{

    public class User
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string upn { get; set; }
        public object[] groups { get; set; }
        public string[] rightHashes { get; set; }
        public object[] objectRightHashes { get; set; }
        public string[] rights { get; set; }
        public object[] objectRights { get; set; }
    }
}
