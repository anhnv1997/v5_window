using iParkingv5.Objects.Datas;
using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.EventDatas
{
    public class AddEventInResponse
    {
        public string Id { get; set; }
        public AbnormalCode? AbnormalCode { get; set; }
        public bool ValidPlateNumber { get; set; }
        public bool OpenBarrier { get; set; }
        public Identity Identity { get; set; }
        public RegisteredVehicle RegisteredVehicle { get; set; }
        public string ErrorMessage { get; set; }

        public AddEventInResponse()
        {
        }
        public AddEventInResponse(AbnormalCode abnormalCode)
        {
            AbnormalCode = abnormalCode;
        }

        public AddEventInResponse(Identity identity, RegisteredVehicle registeredVehicle)
        {
            Identity = identity;
            RegisteredVehicle = registeredVehicle;
        }
    }
}
