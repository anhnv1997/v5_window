using iParkingv5.ApiManager.interfaces;
using iParkingv6.ApiManager;
using Kztek.Tool;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using static iParkingv5.ApiManager.KzParkingv5Apis.Filter;
using static iParkingv5.ApiManager.KzParkingv5Apis.KzParkingv5ApiHelper;
using System.Threading.Tasks;
using System.Threading;
using System.Data;
using iParkingv5.Objects.Datas.reporting_service;
using RestSharp;
using static iParkingv5.ApiManager.KzParkingv5Apis.KzParkingv5BaseApi;
using iParkingv5.Objects.EventDatas;

namespace iParkingv5.ApiManager.KzParkingv5Apis.services
{
    public class KzParkingv5ReportingService : iReportingService
    {

        public async Task<Report<EventInData>> GetEventIns(string keyword, DateTime startTime, DateTime endTime,
                                    string identityGroupId, string vehicleTypeId, string laneId, string user,
                                    int pageIndex = 1, int pageSize = 100)
        {
            server = server.StandardlizeServerName();
            string apiUrl = server + "event-in/search";
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };


            List<FilterModel> filterModels = new List<FilterModel>()
                        {
                            new FilterModel("createdUtc", EmPageSearchType.DATETIME, startTime.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss:0000"), EmOperation._gte),
                            new FilterModel("createdUtc", EmPageSearchType.DATETIME, endTime.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss:0000"),  EmOperation._lte),
                            new FilterModel("createdBy", EmPageSearchType.TEXT, user,  EmOperation._contains),
                            new FilterModel("status", EmPageSearchType.TEXT, "parking",  EmOperation._eq),
                        };
            if (!string.IsNullOrEmpty(laneId))
            {
                filterModels.Add(new FilterModel("lane.id", EmPageSearchType.GUID, laneId, EmOperation._in));
            }
            if (!string.IsNullOrEmpty(identityGroupId))
            {
                filterModels.Add(new FilterModel("identityGroup.id", EmPageSearchType.GUID, identityGroupId, EmOperation._in));
            }
            if (!string.IsNullOrEmpty(vehicleTypeId))
            {
                filterModels.Add(new FilterModel("identityGroup.vehicleType", EmPageSearchType.TEXT, vehicleTypeId.ToUpper(), EmOperation._eq));
            }
            var filter1 = Filter.CreateFilterItem(filterModels, EmMainOperation.and);
            var filter2 = Filter.CreateFilterItem(new List<FilterModel>()
                            {
                                new FilterModel("plateNumber", "TEXT", keyword, "contains"),
                                new FilterModel("identity.code", "TEXT", keyword, "contains"),
                                new FilterModel("identity.name", "TEXT", keyword, "contains"),
                            }, EmMainOperation.or);
            var filter = Filter.CreateFilter(new List<Dictionary<string, List<FilterModel>>>() { filter1, filter2 },
                                            pageIndex: pageIndex,
                                            pageSize: pageSize);

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, filter, headers, null, timeOut, RestSharp.Method.Post);

            if (!string.IsNullOrEmpty(response.Item1))
            {
                var baseResponse = NewtonSoftHelper<KzParkingv5BaseResponse<List<EventInData>>>.GetBaseResponse(response.Item1);
                if (baseResponse != null)
                {
                    Report<EventInData> report = new Report<EventInData>()
                    {
                        TotalPage = baseResponse.totalPage,
                        TotalCount = baseResponse.totalCount,
                        data = baseResponse.data ?? new List<EventInData>(),
                    };
                    return report;
                }
                return new Report<EventInData>()
                {
                    TotalPage = 0,
                    TotalCount = 0,
                    data = new List<EventInData>(),
                };
            }
            return new Report<EventInData>()
            {
                TotalPage = 0,
                TotalCount = 0,
                data = new List<EventInData>(),
            };
        }
        public async Task<Report<EventOutData>> GetEventOuts(string keyword, DateTime startTime, DateTime endTime, string identityGroupId, string vehicleTypeId, string laneId, string user, int pageIndex = 1, int pageSize = 10000)
        {
            server = server.StandardlizeServerName();
            string apiUrl = server + "event-out/search";
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };


            List<FilterModel> filterModels = new List<FilterModel>()
                        {
                            new FilterModel("createdUtc", EmPageSearchType.DATETIME, startTime.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss:0000"), EmOperation._gte),
                            new FilterModel("createdUtc", EmPageSearchType.DATETIME, endTime.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss:0000"),  EmOperation._lte),
                            new FilterModel("createdBy", EmPageSearchType.TEXT, user,  EmOperation._contains),
                        };
            if (!string.IsNullOrEmpty(laneId))
            {
                filterModels.Add(new FilterModel("lane.id", EmPageSearchType.GUID, laneId, EmOperation._in));
            }
            if (!string.IsNullOrEmpty(identityGroupId))
            {
                filterModels.Add(new FilterModel("identityGroup.id", EmPageSearchType.GUID, identityGroupId, EmOperation._in));
            }
            if (!string.IsNullOrEmpty(vehicleTypeId))
            {
                filterModels.Add(new FilterModel("identityGroup.vehicleType", EmPageSearchType.TEXT, vehicleTypeId.ToUpper(), EmOperation._eq));
            }
            var filter1 = Filter.CreateFilterItem(filterModels, EmMainOperation.and);
            var filter2 = Filter.CreateFilterItem(new List<FilterModel>()
                        {
                            new FilterModel("plateNumber", "TEXT", keyword, "contains"),
                            new FilterModel("identity.code", "TEXT", keyword, "contains"),
                            new FilterModel("identity.name", "TEXT", keyword, "contains"),
                        }, EmMainOperation.or);
            var filter = Filter.CreateFilter(new List<Dictionary<string, List<FilterModel>>>() { filter1, filter2 },
                                            pageIndex: pageIndex,
                                            pageSize: pageSize);
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, filter, headers, null, timeOut, Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                var baseResponse = NewtonSoftHelper<KzParkingv5BaseResponse<List<EventOutData>>>.GetBaseResponse(response.Item1);
                if (baseResponse != null)
                {
                    Report<EventOutData> report = new Report<EventOutData>()
                    {
                        TotalPage = baseResponse.totalPage,
                        TotalCount = baseResponse.totalCount,
                        data = baseResponse.data ?? new List<EventOutData>(),
                    };
                    return report;
                }
                return new Report<EventOutData>()
                {
                    TotalPage = 0,
                    TotalCount = 0,
                    data = new List<EventOutData>(),
                };
            }
            return new Report<EventOutData>()
            {
                TotalPage = 0,
                TotalCount = 0,
                data = new List<EventOutData>(),
            };
        }

        public async Task<DataTable> GetAlarmReport(string keyword, DateTime startTime, DateTime endTime, string identityGroupId, string vehicleTypeId, string laneId, int pageIndex = 1, int pageSize = 10000)
        {
            server = server.StandardlizeServerName();
            string apiUrl = server + KzParkingv5ApiUrlManagement.GetBySqlCmd;
            string cmd = string.Empty;
            cmd += "SELECT * FROM index_abnormal_event ";
            cmd += $"WHERE (createdutc Between '{startTime.ToUniversalTime():yyyy-MM-ddTHH:mm:ss.000Z}' AND '{endTime.ToUniversalTime():yyyy-MM-ddTHH:mm:ss.000Z}') ";
            if (!string.IsNullOrEmpty(laneId))
            {
                cmd += $@"AND (laneid = '{laneId.ToUpper()}' or eventinlaneid = '{laneId.ToUpper()}')  ";
            }
            if (!string.IsNullOrEmpty(identityGroupId))
            {
                cmd += $@"AND identitygroupid = '{identityGroupId.ToUpper()}' ";
            }
            if (!string.IsNullOrEmpty(vehicleTypeId))
            {
                cmd += $@"AND vehicletypeid = '{vehicleTypeId.ToUpper()}' ";
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                cmd += $@"AND ((identityname like '%{keyword}%' OR platenumber like '%{keyword}%' OR identitycode like '%{keyword}%') OR
                               (eventinidentityname like '%{keyword}%' OR platenumber like '%{keyword}%' OR eventinidentitycode like '%{keyword}%'))";
            }
            cmd += "ORDER BY createdutc desc";
            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var data = new
            {
                query = cmd,
                fetch_size = pageSize,
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, data, headers, null, timeOut, RestSharp.Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                // Deserialize JSON to JObject
                JObject jsonObject = JObject.Parse(response.Item1);

                // Extract columns and rows from JSON
                JArray columns = (JArray)jsonObject["columns"];
                JArray rows = (JArray)jsonObject["rows"];

                // Create a new DataTable
                DataTable dataTable = new DataTable();
                if (columns != null)
                {
                    foreach (JObject column in columns)
                    {
                        string columnName = (string)column["name"];
                        string columnType = (string)column["type"];

                        Type type;

                        switch (columnType)
                        {
                            case "text":
                                type = typeof(string);
                                break;
                            case "long":
                                type = typeof(long);
                                break;
                            case "datetime":
                                type = typeof(DateTime);
                                break;
                            default:
                                type = typeof(string);
                                break;
                        }

                        dataTable.Columns.Add(columnName, type);
                    }
                    if (rows != null)
                    {
                        foreach (JArray row in rows)
                        {
                            object[] rowData = row.ToObject<object[]>();
                            dataTable.Rows.Add(rowData);
                        }

                    }
                }
                return dataTable;
            }
            return null;
        }

        /// <summary>
        /// Gửi api lấy thông tin số lượng xe đang trong bãi, số lượng xe vào bãi trong ngày, số lượng xe ra khỏi bãi trong ngày
        /// </summary>
        /// <returns></returns>
        public async Task<SumaryCountEvent> SummaryEventAsync()
        {
            return new SumaryCountEvent();
            server = server.StandardlizeServerName();
            string apiUrl = server + KzParkingv5ApiUrlManagement.GetBySqlCmd;
            DateTime startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            DateTime endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            string vehicleInParkCmd = string.Empty;
            vehicleInParkCmd += "SELECT Count(id) FROM index_event_in ";
            vehicleInParkCmd += $"WHERE (status != 'Exited' and status is not null) ";
            var data = new
            {
                query = vehicleInParkCmd
            };
            int vehicleInPark = await GetRecordCountByCmd(apiUrl, headers, data);

            string vehicleGotInInDayCmd = string.Empty;
            vehicleGotInInDayCmd += "SELECT Count(id) FROM index_event_in ";
            vehicleGotInInDayCmd += $"WHERE (createdutc Between '{startTime.ToUniversalTime():yyyy-MM-ddTHH:mm:ss.000Z}' AND '{endTime.ToUniversalTime():yyyy-MM-ddTHH:mm:ss.000Z}') ";
            data = new
            {
                query = vehicleGotInInDayCmd
            };
            int vehicleGotInIn = await GetRecordCountByCmd(apiUrl, headers, data);

            string vehicleGotOutInDayCmdc = string.Empty;
            vehicleGotOutInDayCmdc += "SELECT Count(id) FROM index_event_out ";
            vehicleGotOutInDayCmdc += $"WHERE (createdutc Between '{startTime.ToUniversalTime():yyyy-MM-ddTHH:mm:ss.000Z}' AND '{endTime.ToUniversalTime():yyyy-MM-ddTHH:mm:ss.000Z}') ";
            data = new
            {
                query = vehicleGotOutInDayCmdc
            };
            int vehicleGotOutInDay = await GetRecordCountByCmd(apiUrl, headers, data);

            return new SumaryCountEvent()
            {
                countAllEventIn = vehicleInPark,
                totalEventOut = vehicleGotOutInDay,
                totalVehicleIn = vehicleGotInIn,
            };
        }

        private async Task<int> GetRecordCountByCmd(string apiUrl, Dictionary<string, string> headers, object data)
        {
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, data, headers, null, timeOut, RestSharp.Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                // Deserialize JSON to JObject
                JObject jsonObject = JObject.Parse(response.Item1);

                // Extract columns and rows from JSON
                JArray columns = (JArray)jsonObject["columns"];
                JArray rows = (JArray)jsonObject["rows"];

                if (rows != null)
                {
                    if (rows.Count > 0)
                    {
                        try
                        {
                            string temp = rows[0].ToString();
                            object[] rowData = rows[0].ToObject<object[]>();
                            return int.Parse(rowData[0].ToString());
                        }
                        catch (Exception)
                        {
                            return 0;
                        }
                    }
                    return 0;
                }
            }
            return 0;
        }
    }
}
