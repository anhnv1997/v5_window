using iParkingv5.Objects;
using iParkingv6.ApiManager.KzParkingv3Apis.Responses;
using iParkingv6.ApiManager.KzParkingv3Apis;
using iParkingv6.ApiManager;
using Kztek.Tool;
using Kztek.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using iParkingv5.Objects.Datas.VETC;
using System.Text.Json.Nodes;
using Newtonsoft.Json;

namespace iParkingv5.ApiManager.VETCParking
{
    public static class VETCParkingApihelper
    {
        public static string server = "http://localhost:50050";
        public static int timeOut = 10000;

        public static int expireTime = 1000;
        public static string token = string.Empty;
        public static CancellationTokenSource cts;
        private static void StandardlizeServerName()
        {
            if (server[^1] != '/' && server[^1] != '\\')
            {
                server += "/";
            }
        }
        public static async Task<VETCBaseResponseData<EtagTriggerData>> Healthcheck()
        {
            StandardlizeServerName();
            string apiUrl = VETCUrlManager.UrlCheckConnectAgent;

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, null, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    VETCBaseResponseData<EtagTriggerData> vetcBaseResponse = NewtonSoftHelper<VETCBaseResponseData<EtagTriggerData>>.GetBaseResponse(response.Item1);
                    if (vetcBaseResponse.data != null)
                    {
                        return vetcBaseResponse;

                    }
                    return null;
                }
                catch (Exception ex)
                {
                    LogHelper.Log(logType: LogHelper.EmLogType.ERROR,
                              doi_tuong_tac_dong: LogHelper.EmObjectLogType.Api,
                              obj: ex);
                }
            }
            return null;

        }
        public static async Task<VETCBaseResponseData<CheckOutData>> CheckOut(CheckOutModel data)
        {
            StandardlizeServerName();
            string apiUrl = VETCUrlManager.UrlCheckOut;
            
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, data, null, null, timeOut, RestSharp.Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    //var res = JsonConvert.DeserializeObject<VETCBaseResponseData<CheckOutResponse>>(response.Item1);
                    VETCBaseResponseData<CheckOutData> vetcBaseResponse = NewtonSoftHelper<VETCBaseResponseData<CheckOutData>>.GetBaseResponse(response.Item1);
                    if (vetcBaseResponse.data != null)
                    {
                        return vetcBaseResponse;

                    }
                    return null;
                }
                catch (Exception ex)
                {
                    LogHelper.Log(logType: LogHelper.EmLogType.ERROR,
                              doi_tuong_tac_dong: LogHelper.EmObjectLogType.Api,
                              obj: ex);
                }
            }
            return null;

        }
        public static async Task<bool> FakeEtag(string etag)
        {
            StandardlizeServerName();
            string apiUrl = VETCUrlManager.UrlTriggerEtag;

            object etags = new 
            {
                etag = etag,
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, etags, null, null, timeOut, RestSharp.Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    //var res = JsonConvert.DeserializeObject<VETCBaseResponseData<CheckOutResponse>>(response.Item1);
                    VETCBaseResponseData<object> vetcBaseResponse = NewtonSoftHelper<VETCBaseResponseData<object>>.GetBaseResponse(response.Item1);
                    if (vetcBaseResponse.message == "Success")
                    {
                        return true;

                    }
                    return false;
                }
                catch (Exception ex)
                {
                    LogHelper.Log(logType: LogHelper.EmLogType.ERROR,
                              doi_tuong_tac_dong: LogHelper.EmObjectLogType.Api,
                              obj: ex);
                }
            }
            return false;

        }
        public static async Task<VETCBaseResponseData<EtagAreaData>> GetAllEtagArea()
        {
            StandardlizeServerName();
            string apiUrl = VETCUrlManager.UrlGetAllEtag;

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, null, null, timeOut, RestSharp.Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    VETCBaseResponseData<EtagAreaData> vetcBaseResponse = NewtonSoftHelper<VETCBaseResponseData<EtagAreaData>>.GetBaseResponse(response.Item1);
                    if (vetcBaseResponse.data != null)
                    {
                        return vetcBaseResponse;

                    }
                    return null;
                }
                catch (Exception ex)
                {
                    LogHelper.Log(logType: LogHelper.EmLogType.ERROR,
                              doi_tuong_tac_dong: LogHelper.EmObjectLogType.Api,
                              obj: ex);
                }
            }
            return null;

        }
        public static async Task<VETCBaseResponseData<CheckPaymentData>> CheckPaymentStatus(string tranID)
        {
            StandardlizeServerName();
            string apiUrl = VETCUrlManager.UrlCheckTransaction(tranID);

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, null, null, timeOut, RestSharp.Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    VETCBaseResponseData<CheckPaymentData> vetcBaseResponse = NewtonSoftHelper<VETCBaseResponseData<CheckPaymentData>>.GetBaseResponse(response.Item1);
                    if (vetcBaseResponse.data != null)
                    {
                        return vetcBaseResponse;

                    }
                    return null;
                }
                catch (Exception ex)
                {
                    LogHelper.Log(logType: LogHelper.EmLogType.ERROR,
                              doi_tuong_tac_dong: LogHelper.EmObjectLogType.Api,
                              obj: ex);
                }
            }
            return null;

        }
    }
}
