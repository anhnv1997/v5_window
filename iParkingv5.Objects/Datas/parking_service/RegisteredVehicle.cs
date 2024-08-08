using iParkingv5.Objects.Datas.parking_service;
using iParkingv5.Objects.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iParkingv5.Objects.Datas
{
    public class RegisteredVehicle
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PlateNumber { get; set; }
        public VehicleType.VehicleBaseType vehicleType { get; set; }
        public string CustomerId { get; set; }
        public string ExpireUtc { get; set; }

        /// <summary>
        /// Chỉ có thông tin khi thực hiện các API GetById
        /// </summary>
        public Customer customer { get; set; }
        public bool Enabled { get; set; }
        public bool Deleted { get; set; }
        public List<string> IdentityIds { get; set; }
        [JsonIgnore]
        public DateTime? ExpireTime
        {
            get
            {
                try
                {
                    if (string.IsNullOrEmpty(ExpireUtc))
                    {
                        return null;
                    }
                    if (ExpireUtc.Contains("T"))
                    {
                        return DateTime.ParseExact(ExpireUtc.Substring(0, "yyyy-MM-ddTHH:mm:ss".Length), "yyyy-MM-ddTHH:mm:ss", null).AddHours(7);
                    }
                    else
                    {
                        return DateTime.Parse(ExpireUtc).AddHours(7);
                    }
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}