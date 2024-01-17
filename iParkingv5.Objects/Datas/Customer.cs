using iParkingv5.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv6.Objects.Datas
{
    public class Customer
    {
        public string id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string idNumber { get; set; }
        public string phoneNumber { get; set; }
        public object email { get; set; }
        public string dateOfBirth { get; set; }
        public string customerGroupId { get; set; }
        public string customerGroup
        {
            get => StaticPool.customerGroupCollection.GetById(this.customerGroupId)?.Name;
        }
        public object description { get; set; }
        public bool enabled { get; set; } = true;
        public bool deleted { get; set; } = false;
    }

}
