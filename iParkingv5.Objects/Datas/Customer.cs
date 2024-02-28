using iParkingv5.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv6.Objects.Datas
{
    public class Customer
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string IdNumber { get; set; }
        public string PhoneNumber { get; set; }
        public object Email { get; set; }
        [JsonIgnore]
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
        public string CustomerGroupId { get; set; }
        public string CustomerGroupName
        {
            get => StaticPool.customerGroupCollection.GetById(this.CustomerGroupId)?.Name ?? "";
        }
        public object Description { get; set; }
        public bool Enabled { get; set; } = true;
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
                if (item.Id == id)
                {
                    customerName = item.Name;
                    customerCode = item.Code;
                    customerGroupId = item.CustomerGroupId;
                    customerGroupName = item.CustomerGroupName;
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
