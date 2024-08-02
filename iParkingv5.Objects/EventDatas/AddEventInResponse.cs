using iParkingv5.Objects.Datas.Device_service;
using iParkingv5.Objects.Datas.parking_service;
using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.EventDatas
{
    public class ErrorDescription
    {
        public string name { get; set; }
        public string errorCode { get; set; }
        public override string ToString()
        {
            if (name.ToUpper() == "PlateNumber".ToUpper())
            {
                if (errorCode == "ERROR.ENTITY.VALIDATION.FIELD_NOT_MATCH_WITH_EVENT_IN")
                {
                    return "Biển số vào ra không khớp".ToUpper();
                }
            }
            if (name.ToUpper() == "IdentityGroup".ToUpper())
            {
                if (errorCode == "ERROR.ENTITY.VALIDATION.FIELD_NOT_ACTIVE")
                {
                    return "Nhóm định danh chưa được kích hoạt".ToUpper();
                }
            }

            if (name.ToUpper() == "vehicle".ToUpper())
            {
                if (errorCode == "ERROR.ENTITY.VALIDATION.FIELD_NOT_FOUND")
                {
                    return "Biển Số Không Hợp Lệ".ToUpper();
                }
            }
            else if (name.ToUpper() == "IdentityGroup".ToUpper())
            {
                if (errorCode == "ERROR.ENTITY.VALIDATION.FIELD_NOT_HAVE_PERMISSION_TO_USE_THIS_LANE")
                {
                    return "Nhóm thẻ không được phép sử dụng với làn".ToUpper();
                }
            }
            else if (name.ToUpper() == "EventIn".ToUpper())
            {
                if (errorCode == "ERROR.ENTITY.VALIDATION.FIELD_DUPLICATED")
                {
                    return "Xe đã vào bãi".ToUpper();
                }
                else if (errorCode == "ERROR.ENTITY.VALIDATION.FIELD_NOT_FOUND")
                {
                    return "Xe chưa vào bãi".ToUpper();
                }
                else if (errorCode == "ERROR.ENTITY.VALIDATION.FIELD_NOT_APPROVED_FOR_EXIT")
                {
                    return "Xe chưa được phép ra".ToUpper();
                }
            }
            return  name + " - " + errorCode;
        }
    }
}
