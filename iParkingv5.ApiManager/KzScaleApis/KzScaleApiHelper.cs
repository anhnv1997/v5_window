using iParkingv5.Objects;
using iParkingv5.Objects.Datas.warehouse_service;
using iParkingv6.ApiManager;
using OpenCvSharp;
using System;
using System.Collections.Generic;
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
            //weight = new Random().Next(10000, 50000);
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
                { "user_action", StaticPool.userId },
                { "user_code",StaticPool.user_name },
                { "list_image", string.Join(";", imageKeys.ToArray()) },
                //{ "update_traffic_id", updateTrafficId},
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, RestSharp.Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    KzScaleBaseResponse<WeighingDetail> data = Newtonsoft.Json.JsonConvert.DeserializeObject<KzScaleBaseResponse<WeighingDetail>>(response.Item1);
                    return data?.result ?? new WeighingDetail();
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return null;
        }

        public static async Task<WeighingAction> UpdatePlate(string trafficId, string newPlate)
        {
            string apiUrl = server + KzScaleUrlManagement.UpdatePlate();

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };

            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "plate_number",newPlate },
                { "traffic_id",trafficId },
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, RestSharp.Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    KzScaleBaseResponse<WeighingAction> data = Newtonsoft.Json.JsonConvert.DeserializeObject<KzScaleBaseResponse<WeighingAction>>(response.Item1);
                    return data?.result ?? new WeighingAction();
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return null;
        }

        public static async Task<List<WeighingDetail>> GetWeighingActionDetails(DateTime startTime, DateTime endTime, string plateNumber = "",
                                        string user_code = "", string weighingFormId = "", int is_weighing_bill = 0)
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
                { "is_weighing_bill", is_weighing_bill.ToString() },
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
        public static async Task<WeighingActionDetail> UpdateWeighingActionDetailById(string weighingActionDetailId, string weighingFormId)
        {
            if (string.IsNullOrEmpty(server))
            {
                return null;
            }
            StandardlizeServerName();
            string apiUrl = server + KzScaleUrlManagement.updateWeighingActionDetailById(weighingActionDetailId);

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "weighting_form_id", weighingFormId },
                { "weighing_action_detail_id", weighingActionDetailId },
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, RestSharp.Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzScaleBaseResponse<WeighingActionDetail> data =
                    Newtonsoft.Json.JsonConvert.DeserializeObject<KzScaleBaseResponse<WeighingActionDetail>>(response.Item1);
                return data?.result;
            }
            return null;
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
        public static async Task<string> CreateInvoice(string weighingActionDetailId, string userId, string userFullname)
        {
            StandardlizeServerName();
            string apiUrl = server + KzScaleUrlManagement.CreateInvoice();

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var data = new
            {
                WeighingActionDetailID = weighingActionDetailId,
                Creator = new
                {
                    Id = userId,
                    Name = userFullname,
                }
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, data, headers, null, timeOut, RestSharp.Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                KzScaleBaseResponse<WeighingBill> result =
                 Newtonsoft.Json.JsonConvert.DeserializeObject<KzScaleBaseResponse<WeighingBill>>(response.Item1);
                if (result == null)
                {
                    return "";
                }

                return result?.result?.Id ?? "";
            }
            return string.Empty;
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
