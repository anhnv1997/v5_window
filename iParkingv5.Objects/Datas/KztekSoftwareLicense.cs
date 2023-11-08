using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv6.Objects.Datas
{
    public class KztekSoftwareLicense
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string UserCreated { get; set; }
        public string DeviceCode { get; set; }
        public string ActiveCode { get; set; }
        public bool IsDelete { get; set; }
        public string Token { get; set; }
    }
}
