using iParkingv5.ApiManager.interfaces;
using iParkingv5.Objects.Datas.invoice_service;
using iParkingv6.ApiManager;
using Kztek.Tool;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using static iParkingv5.ApiManager.KzParkingv5Apis.Filter;
using static iParkingv5.ApiManager.KzParkingv5Apis.KzParkingv5ApiHelper;
using System.Threading.Tasks;
using System.Threading;
using static iParkingv5.ApiManager.KzParkingv5Apis.KzParkingv5BaseApi;
using Kztek.Tools;

namespace iParkingv5.ApiManager.KzParkingv5Apis.services
{
    public class KzParkingv5InvoiceService : iInvoiceService
    {

        public async Task<InvoiceResponse> CreateEinvoice(long _price, string plateNumber, DateTime datetimeIn, DateTime datetimeOut, string eventOutId, bool isSendNow = true, string cardGroupName = "")
        {
            string apiUrl = "";
            server = server.StandardlizeServerName();
            apiUrl = server + "invoice";

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            TimeSpan parkingTime = datetimeOut - datetimeIn;
            var data = new
            {
                targetType = (int)InvoiceTargetType.EventOut,
                targetId = eventOutId,
                send = isSendNow ? 1 : 0,
                provider = (int)EmInvoiceProvider.VIETTEL,
                items = new List<object>()
                {
                    new
                    {
                        name = string.IsNullOrEmpty( cardGroupName) ? "Hàng hóa" : cardGroupName,
                        code = "HH1",
                        quantity = 1,
                        price = _price,
                    }
                },
                extraInformation = new List<object>()
                {
                    new
                    {
                        tag =  "licensePlate",
                        name = "Biển kiểm soát",
                        value =  plateNumber,
                        type=  "text"
                    },
                    new
                    {
                        tag =  "checkIn",
                        name = "Giờ vào",
                        value =  datetimeIn.ToString("dd/MM/yyyy HH:mm:ss"),
                        type=  "text"
                    },
                    new
                    {
                        tag =  "checkOut",
                        name = "Giờ ra",
                        value =  datetimeOut.ToString("dd/MM/yyyy HH:mm:ss"),
                        type=  "text"
                    },
                    new
                    {
                        tag =  "parkingTime",
                        name = "Thời gian lưu bãi",
                        value = (int)parkingTime.TotalHours + " giờ " + ((int)parkingTime.TotalMinutes - 60 * (int)parkingTime.TotalHours) + " phút",
                        type=  "text"
                    },
                },
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, data, headers, null, timeOut, Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    return JsonConvert.DeserializeObject<InvoiceResponse>(response.Item1);
                }
                catch (Exception)
                {
                    return null;

                }
            }
            return null;
        }


        public async Task<InvoiceFileInfor> GetInvoiceData(string orderId, EmInvoiceProvider provider = EmInvoiceProvider.VIETTEL)
        {
            server = server.StandardlizeServerName();
            string apiUrl = server + $"invoice/{orderId}/representation";

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "provider","2"  },
                { "filetType","1"  }
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters, timeOut, Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                return NewtonSoftHelper<InvoiceFileInfor>.GetBaseResponse(response.Item1);
            }
            return null;
        }

        public async Task<List<InvoiceResponse>> GetMultipleInvoiceData(DateTime startTime, DateTime endTime, EmInvoiceProvider provider = EmInvoiceProvider.VIETTEL)
        {
            server = server.StandardlizeServerName();
            string apiUrl = server + "invoice/search";

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var filter = Filter.CreateFilter(new List<FilterModel>()
            {
                new FilterModel("success", "BOOLEAN", "true", "eq"),
                new FilterModel("createdUtc", "DATETIME", startTime.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss:0000"), "gte"),
                new FilterModel("createdUtc", "DATETIME", endTime.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss:0000"), "lte"),
            }, false, EmMainOperation.and, 0, 10000);
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, filter, headers, null, timeOut, Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {

                return NewtonSoftHelper<KzParkingv5BaseResponse<List<InvoiceResponse>>>.GetBaseResponse(response.Item1)?.data ?? new List<InvoiceResponse>();
            }
            return null;
        }

        public async Task<List<InvoiceResponse>> getPendingEInvoice(DateTime startTime, DateTime endTime)
        {
            server = server.StandardlizeServerName();
            string apiUrl = server + "invoice/search";

            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var filter = Filter.CreateFilter(new List<FilterModel>()
            {
                new FilterModel("success", "BOOLEAN", "true", "neq"),
                new FilterModel("success", "BOOLEAN", "false", "neq"),
                new FilterModel("createdUtc", "DATETIME", startTime.ToUniversalTime().ToString("2023-MM-ddTHH:mm:ss:0000"), "gte"),
                new FilterModel("createdUtc", "DATETIME", endTime.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss:0000"), "lte"),
            }, false, EmMainOperation.and, 0, 10000);
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, filter, headers, null, timeOut, Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                var pendingData = NewtonSoftHelper<KzParkingv5BaseResponse<List<InvoiceResponse>>>.GetBaseResponse(response.Item1)?.data ?? new List<InvoiceResponse>();
                return pendingData;
            }
            return new List<InvoiceResponse>();
        }
        public async Task<bool> sendPendingEInvoice(string orderId)
        {
            server = server.StandardlizeServerName();
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            string apiUrl = server + $"invoice/{orderId}/resend";
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null, timeOut, Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                var pendingData = NewtonSoftHelper<InvoiceResponse>.GetBaseResponse(response.Item1);
                return pendingData != null;
            }
            return false;
        }
    }
}
