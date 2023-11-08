using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv6.Objects.Datas
{
    public class Card
    {
        public string Id { get; set; } = string.Empty;
        public string CardNo { get; set; }
        public string CardNumber { get; set; }
        public string CustomerId { get; set; }
        public string CardGroupId { get; set; }
        public DateTime? ImportDate { get; set; }
        public DateTime? ExpireDate { get; set; }

        public string Plate1 { get; set; }
        public string PlateUnsigned1 { get; set; }
        public string VehicleName1 { get; set; }
        public string Plate2 { get; set; }
        public string PlateUnsigned2 { get; set; }
        public string VehicleName2 { get; set; }
        public string Plate3 { get; set; }
        public string PlateUnsigned3 { get; set; }
        public string VehicleName3 { get; set; }
        public bool IsLock { get; set; }
        public bool IsDelete { get; set; }
        public int SortOrder { get; set; }
        public string Description { get; set; }
        public DateTime? DateRegister { get; set; }
        public DateTime? DateRelease { get; set; }
        public DateTime? DateCancel { get; set; }
        public DateTime? DateActive { get; set; }
        public DateTime AccessExpireDate { get; set; }
        //Chạy tự động
        public bool IsAutoCapture { get; set; }
        public bool IsLost { get; set; }
    }

}
