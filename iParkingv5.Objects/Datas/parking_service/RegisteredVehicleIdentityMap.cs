using System;
using iParkingv5.Objects.Datas.parking_service;

namespace iParkingv5.Objects.Datas
{
    public class RegisteredVehicleIdentityMap 
    {
        public int Id { get; set; }
        public string RegisteredVehicleId { get; set; }
        public string IdentityId { get; set; }

        public Identity Identity { get; set; }
        public RegisteredVehicle RegisteredVehicle { get; set; }

        public RegisteredVehicleIdentityMap(string registeredVehicleId, string identityId)
        {
            RegisteredVehicleId = registeredVehicleId;
            IdentityId = identityId;
        }

        public RegisteredVehicleIdentityMap()
        {
        }
    }
}

