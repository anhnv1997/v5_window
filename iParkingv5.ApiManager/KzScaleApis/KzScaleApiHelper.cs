﻿using iParkingv5.Objects.ScaleObjects;
using iParkingv6.ApiManager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iParkingv5.ApiManager.KzScaleApis
{
    public class CountInDayDetail
    {
        public int count_equal_1 { get; set; } = 0;
        public int count__equal_2 { get; set; } = 0;
        public int count_greater_2 { get; set; } = 0;
    }
    public class KzScaleBaseResponse<T>
    {
        public int status { get; set; }
        public int run { get; set; }
        public string error { get; set; }
        public T result { get; set; }
    }

    public static class KzScaleApiHelper
    {
        public static string server = "";
        public static string username = "admin";
        public static string password = "123456";
        public static int timeOut = 10000;

        public static int expireTime = 1000;
        public static string token = string.Empty;
        public static CancellationTokenSource cts;

        #region WeighingForms
        public static async Task<List<WeighingForm>> GetWeighingForms()
        {
            StandardlizeServerName();
            string apiUrl = server + KzScaleUrlManagement.GetAllWeighingFormRoute();

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzScaleBaseResponse<List<WeighingForm>> data = Newtonsoft.Json.JsonConvert.DeserializeObject<KzScaleBaseResponse<List<WeighingForm>>>(response.Item1);
                return data?.result ?? new List<WeighingForm>();
            }
            return null;
        }
        #endregion End WeighingForms

        #region Weighing Action
        public static async Task<WeighingDetail> CreateScaleEvent(string plateNumber, string parkingEventId,
                                                         long weight, string weightFormId,
                                                         string user_action, string user_code,
                                                         List<string> imageKeys, string updateTrafficId = "")
        {
            string apiUrl = server + KzScaleUrlManagement.CreateWeighingAction();

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };

            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "plate_number",plateNumber },
                { "traffic_id",parkingEventId },
                { "weighting_form_id",weightFormId },
                { "weight", weight.ToString() },
                { "user_action", user_action },
                { "user_code", user_code },
                { "list_image", string.Join(";", imageKeys.ToArray()) },
                { "update_traffic_id", updateTrafficId},
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, RestSharp.Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzScaleBaseResponse<WeighingDetail> data = Newtonsoft.Json.JsonConvert.DeserializeObject<KzScaleBaseResponse<WeighingDetail>>(response.Item1);
                return data?.result ?? new WeighingDetail();
            }
            return null;
        }
        public static async Task<List<WeighingDetail>> GetWeighingActionDetails(DateTime startTime, DateTime endTime, string plateNumber = "",
                                        string user_code = "", string weighingFormId = "")
        {
            if (string.IsNullOrEmpty(server))
            {
                return new List<WeighingDetail>();
            }
            StandardlizeServerName();
            string apiUrl = server + KzScaleUrlManagement.GetAllWeighingHistory();

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "start_date",startTime.ToString("yyyy-MM-dd HH:mm:ss") },
                { "end_date", endTime.ToString("yyyy-MM-dd HH:mm:ss") },
                { "plate_number", plateNumber},
                { "user_code", user_code },
                { "weighting_form_id", weighingFormId },
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzScaleBaseResponse<List<WeighingDetail>> data =
                    Newtonsoft.Json.JsonConvert.DeserializeObject<KzScaleBaseResponse<List<WeighingDetail>>>(response.Item1);
                return data?.result ?? new List<WeighingDetail>();
            }
            return new List<WeighingDetail>();
        }
        #endregion End Weighing Action

        #region Weighing Detail
        public static async Task<CountInDayDetail> GetCountInDayRoute()
        {
            if (string.IsNullOrEmpty(server))
            {
                return new CountInDayDetail();
            }
            StandardlizeServerName();
            string apiUrl = server + KzScaleUrlManagement.GetCountInDayRoute();

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzScaleBaseResponse<CountInDayDetail> data =
                  Newtonsoft.Json.JsonConvert.DeserializeObject<KzScaleBaseResponse<CountInDayDetail>>(response.Item1);
                if (data == null)
                {
                    return new CountInDayDetail();
                }
                if (data.result == null)
                {
                    return new CountInDayDetail();
                }
                return data.result;
            }
            return new CountInDayDetail();
        }
        public static async Task<List<WeighingActionDetail>> GetWeighingActionDetailsByTrafficId(string parkingEventId)
        {
            StandardlizeServerName();
            string apiUrl = server + KzScaleUrlManagement.GetAllWeighingHistory();

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "traffic_id",parkingEventId  }
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzScaleBaseResponse<List<WeighingDetail>> data =
                   Newtonsoft.Json.JsonConvert.DeserializeObject<KzScaleBaseResponse<List<WeighingDetail>>>(response.Item1);
                if (data == null)
                {
                    return new List<WeighingActionDetail>();
                }
                if (data.result == null)
                {
                    return new List<WeighingActionDetail>();
                }
                if (data.result.Count == 0)
                {
                    return new List<WeighingActionDetail>();
                }
                return data?.result[0].weighing_action_detail;
            }
            return new List<WeighingActionDetail>();
        }
        #endregion End Weighing Detai;

        #region EInvoice
        public static async Task<bool> CreateInvoice()
        {
            return true;
        }
        #endregion End EInvoice

        #region Privaet Function
        private static void StandardlizeServerName()
        {
            if (server[^1] != '/' && server[^1] != '\\')
            {
                server += "/";
            }
        }
        #endregion End Private Function
    }
}
