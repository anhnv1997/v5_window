﻿using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv6.Objects.Datas
{
    public class CardGroup
    {
        public CardGroup()
        {
            Id = string.Empty;
            CardGroupId = Id;
        }
        public string Id { get; set; }
        public string CardGroupId { get; set; }
        public string CardGroupCode { get; set; }
        public string CardGroupName { get; set; }
        public string Description { get; set; }
        public int CardType { get; set; }
        public string VehicleGroupId { get; set; }
        public string LaneIDs { get; set; }
        public string DayTimeFrom { get; set; }
        public string DayTimeTo { get; set; }
        public int Formulation { get; set; }
        public int EachFee { get; set; }
        public int Block0 { get; set; }
        public int Time0 { get; set; }
        public int Block1 { get; set; }
        public int Time1 { get; set; }
        public int Block2 { get; set; }
        public int Time2 { get; set; }
        public int Block3 { get; set; }
        public int Time3 { get; set; }
        public int Block4 { get; set; }
        public int Time4 { get; set; }
        public int Block5 { get; set; }
        public int Time5 { get; set; }
        public string TimePeriods { get; set; }
        public string Costs { get; set; }
        public bool Inactive { get; set; }
        public int SortOrder { get; set; }
        public bool IsHaveMoneyExcessTime { get; set; }
        public bool EnableFree { get; set; }
        public int FreeTime { get; set; }
        public bool IsCheckPlate { get; set; }
        public bool IsHaveMoneyExpiredDate { get; set; }
        public bool IsFreeTimeAccumulate { get; set; } = true;
    }
}
