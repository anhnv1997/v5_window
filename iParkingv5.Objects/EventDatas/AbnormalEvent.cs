using iParkingv5.Objects.Datas.Device_service;
using iParkingv5.Objects.Datas.parking_service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace iParkingv5.Objects.EventDatas
{
    public class AbnormalEvent
    {
        public string Id { get; set; }
        public string IdentityId { get; set; }
        public string LaneId { get; set; }
        public string CreatedBy { get; set; }
        public string PlateNumber { get; set; }
        public AbnormalCode AbnormalCode { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }
        public string CreatedUtc { get; set; }
        public string RegisteredVehicleId { get; set; }
        public string IdentityGroupId { get; set; }
        public string CustomerId { get; set; }
        public Identity Identity { get; set; }
        public Lane Lane { get; set; }

        public List<string> FileKeys { get; set; }
        [JsonIgnore]
        public DateTime? AlarmTime
        {
            get
            {
                try
                {
                    if (string.IsNullOrEmpty(CreatedUtc))
                    {
                        return null;
                    }
                    if (CreatedUtc.Contains("T"))
                    {
                        return DateTime.ParseExact(CreatedUtc.Substring(0, "yyyy-MM-ddTHH:mm:ss".Length), "yyyy-MM-ddTHH:mm:ss", null).AddHours(7);
                    }
                    else
                    {
                        return DateTime.Parse(CreatedUtc).AddHours(7);
                    }
                }
                catch
                {
                    return null;
                }
            }
        }

        public  string GetAbnormalStr()
        {
            switch (this.AbnormalCode)
            {
                case AbnormalCode.IdentityNotExist:
                    return "Mã đinh danh không tồn tại";
                case AbnormalCode.InvalidPlateNumber:
                    return "Biển số không hợp lệ";
                case AbnormalCode.InvalidLane:
                    return "Làn không hợp lệ";
                case AbnormalCode.OpenBarrierByKeyboard:
                    return "Mở barrie bằng phím tắt";
                case AbnormalCode.OpenBarrierByButton:
                    return "Mở barrie bằng nút cứng";
                case AbnormalCode.ManualEvent:
                    return "Ghi vé thủ công";
                case AbnormalCode.InvalidUser:
                    return "Người dùng không tồn tại";
                default:
                    return AbnormalCode.InvalidUser.ToString();
            }
        }

    }
}