using iParkingv6.Objects.Datas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Datas
{
    public class CustomerGroupCollection : CollectionBase
    {
        public CustomerGroupCollection()
        {

        }
        public bool IsEmpty { get => this.InnerList == null || this.InnerList.Count == 0; }
        public CustomerGroupCollection(List<CustomerGroup> obj)
        {
            if (obj == null)
            {
                return;
            }
            InnerList.AddRange(obj);
        }
        public void Add(CustomerGroup obj)
        {
            if (obj == null)
            {
                return;
            }
            InnerList.Add(obj);
        }
        public CustomerGroup GetById(string id)
        {
            if (id == null)
            {
                return null;
            }
            foreach (CustomerGroup item in InnerList)
            {
                if (item.Id?.ToLower() == id?.ToLower())
                {
                    return item;
                }
            }
            return null;
        }
    }
}
