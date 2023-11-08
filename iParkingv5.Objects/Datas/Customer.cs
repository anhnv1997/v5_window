using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv6.Objects.Datas
{
    public class Customer
    {
        public string Id { get; set; }
        //public string CustomerID { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string IDNumber { get; set; }
        public string Mobile { get; set; }
        public string CustomerGroupID { get; set; }
        public string Description { get; set; }
        public bool EnableAccount { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public bool Inactive { get; set; }
        public int SortOrder { get; set; }
        public string AddressUnsign { get; set; }
        //Update aeon hp 19/11/2020
        public string Plate1 { get; set; }
        public string PlateUnsign1 { get; set; }
        public string VehicleName1 { get; set; }
        public string Plate2 { get; set; }
        public string PlateUnsign2 { get; set; }
        public string VehicleName2 { get; set; }
        public string Plate3 { get; set; }
        public string PlateUnsign3 { get; set; }
        public string VehicleName3 { get; set; }
        public string Keyword
        {
            get { return string.Join('&', CustomerName?.ToLower(), CustomerCode, Address, Description) ?? ""; }
        }
    }

}
