using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Enums
{
    public class CommunicationTypes
    {
        public enum EM_CommunicationType
        {
            TCP_IP,
            SERIAL,
            USB
        }

        public static bool IS_TCP(EM_CommunicationType communicationType)
        {
            return communicationType == EM_CommunicationType.TCP_IP;
        }
    }

}
