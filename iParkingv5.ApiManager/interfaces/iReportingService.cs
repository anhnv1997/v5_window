﻿using iParkingv5.Objects.Datas.reporting_service;
using System;
using System.Data;
using static iParkingv5.ApiManager.KzParkingv5Apis.KzParkingv5ApiHelper;
using System.Threading.Tasks;
using iParkingv5.Objects.EventDatas;

namespace iParkingv5.ApiManager.interfaces
{
    public interface iReportingService
    {
        #region Event In
        Task<Report<EventInReport>> GetEventIns(string keyword, DateTime startTime, DateTime endTime,
                                    string identityGroupId, string vehicleTypeId, string laneId, string user, bool isPaging,
                                    int pageIndex = 0, int pageSize = 100, string eventId = "");
        #endregion End Event In

        #region Event Out
        Task<Report<EventOutReport>> GetEventOuts(string keyword, DateTime startTime, DateTime endTime, string identityGroupId,
                                                  string vehicleTypeId, string laneId, string user, bool isPaging, int pageIndex = 0, int pageSize = 10000, string eventId = "");
        #endregion End Event Out

        #region Alarm

        Task<DataTable> GetAlarmReport(string keyword, DateTime startTime, DateTime endTime, string identityGroupId, string vehicleTypeId, string laneId, int pageIndex = 1, int pageSize = 10000);
        #endregion End Alarm



        #region Sumary
        Task<SumaryCountEvent> SummaryEventAsync();
        #endregion End Sumary
    }
}
