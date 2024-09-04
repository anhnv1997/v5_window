﻿using iParkingv5.Objects.Datas.parking_service;
using iParkingv5.Objects.Datas;
using System;
using System.Collections.Generic;
using System.Text;
using static iParkingv5.Objects.Enums.ParkingImageType;
using iParkingv5.Objects.Datas.Device_service;

namespace iParkingv5.Objects.EventDatas
{
    public class BaseReportData
    {
        public string Id { get; set; }
        public string PlateNumber { get; set; }
        public string Note { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedUtc { get; set; }

        public Identity Identity { get; set; }
        public IdentityGroup IdentityGroup { get; set; }
        public Dictionary<EmParkingImageType, List<ImageData>> images { get; set; }

        public bool OpenBarrier { get; set; }

        public RegisteredVehicle vehicle { get; set; }
        public Customer customer { get; set; }
        public Lane Lane { get; set; }
    }
}