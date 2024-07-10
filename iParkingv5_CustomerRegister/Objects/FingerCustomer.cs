using iParkingv5.Objects.Datas.parking_service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iParkingv5_CustomerRegister.Objects
{
    public class FingerCustomer
    {
        public string Id { get; set; } = string.Empty;
        public string FingerId { get; set; } = string.Empty;
        public string CustomerId { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public FingerCustomer(string id, string fingerId, string customerId, string description)
        {
            Id = id;
            FingerId = fingerId;
            CustomerId = customerId;
            Description = description;
        }

        public static List<Fingerprint> GetFingerPrintsByCustomerId(List<FingerCustomer> fingerCustomers, List<Fingerprint> fingerprints, string customerId)
        {
            List<string> fingerIds = (from FingerCustomer fingerCustomer in fingerCustomers
                                      where fingerCustomer.CustomerId.Equals(customerId, StringComparison.CurrentCultureIgnoreCase)
                                      select fingerCustomer.FingerId.ToLower()).ToList();
            List<Fingerprint> _fingerprints = (from fingerprint in fingerprints  
                                               where fingerIds.Contains(fingerprint.Id.ToLower())
                                               select fingerprint).ToList();
            fingerIds.Clear();
            GC.Collect();
            return _fingerprints;
        }
        public static Customer? GetCustomerByFingerId(List<FingerCustomer> fingerCustomers, List<Customer> customers, string fingerId)
        {
            List<string> customerIds = (from FingerCustomer fingerCustomer in fingerCustomers
                                        where fingerCustomer.FingerId.Equals(fingerId, StringComparison.CurrentCultureIgnoreCase)
                                        select fingerCustomer.CustomerId.ToLower()).ToList();
            Customer? _customer = (from Customer customer in customers
                                   where customerIds.Contains(customer.Id)
                                   select customer).FirstOrDefault();
            customerIds.Clear();
            return _customer;
        }
        public static FingerCustomer? GetFingerCustomer(List<FingerCustomer> fingerCustomers, string fingerId, string customerId)
        {
            return (from FingerCustomer fingerCustomer in fingerCustomers
                    where fingerCustomer.CustomerId.Equals(customerId, StringComparison.CurrentCultureIgnoreCase) 
                       && fingerCustomer.FingerId.Equals(fingerId, StringComparison.CurrentCultureIgnoreCase)
                    select fingerCustomer).FirstOrDefault();

        }
    }
}
