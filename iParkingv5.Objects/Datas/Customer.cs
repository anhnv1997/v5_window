using iParkingv5.Objects;
using Newtonsoft.Json;
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
        [JsonIgnore]
        public DateTime dateOfBirth { get; set; } = DateTime.MinValue;
        public string customerGroupId { get; set; }
        public string customerGroup
        {
            get => StaticPool.customerGroupCollection.GetById(this.customerGroupId)?.Name ?? "";
        }
        public object description { get; set; }
        public bool enabled { get; set; } = true;
        public bool deleted { get; set; } = false;
        public static void GetCustomerName(List<Customer> customers, string id, out string customerName, out string customerCode, out string customerGroupId, out string customerGroupName)
        {
            if (customers == null)
            {
                customerName = string.Empty;
                customerCode = string.Empty;
                customerGroupId = string.Empty;
                customerGroupName = string.Empty;
                return;
            }
            foreach (var item in customers)
            {
                if (item.id == id)
                {
                    customerName = item.name;
                    customerCode = item.code;
                    customerGroupId = item.customerGroupId;
                    customerGroupName = item.customerGroup;
                    return;
                }
            }
            customerName = string.Empty;
            customerCode = string.Empty;
            customerGroupId = string.Empty;
            customerGroupName = string.Empty;
            return;
        }
    }

}
