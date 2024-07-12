using iParkingv5.ApiManager.interfaces;
using iParkingv5.Objects.Datas.system_service;
using iParkingv5.Objects;
using iParkingv6.ApiManager;
using Kztek.Tools;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using static iParkingv5.ApiManager.KzParkingv5Apis.KzParkingv5ApiHelper;
using System.Threading.Tasks;
using System.Threading;
using static iParkingv5.ApiManager.KzParkingv5Apis.KzParkingv5BaseApi;

namespace iParkingv5.ApiManager.KzParkingv5Apis.services
{
    public class KzParkingv5SystemService : iSystemService
    {
        public async Task<SystemConfig> GetSystemConfigAsync()
        {
            server = server.StandardlizeServerName();
            string apiUrl = server + "project/BF195768-4C7F-4F59-A50F-F41AD693BBC0";

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null,
                                                                  timeOut, Method.Get);

            apiUrl = server + "tenant/" + "00f43ef8-f67b-446a-870a-c219b59c0c4e".ToUpper();
            var response2 = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null,
                                                               timeOut, Method.Get);
            if (!string.IsNullOrEmpty(response2.Item1))
            {
                var companyInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<CompanyInfo>(response2.Item1);
                if (companyInfo != null)
                {
                    StaticPool.TaxCode = companyInfo.companyTax;
                    StaticPool.CompanyName = companyInfo.companyName;
                    StaticPool.CompanyAddress = companyInfo.companyAddress;
                }
            }

            if (!string.IsNullOrEmpty(response.Item1))
            {
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<SystemConfig>(response.Item1);
                if (data != null)
                {
                    StaticPool.templateCode = data.InvoiceTemplateCode;
                    StaticPool.invoiceTypeCode = data.InvoiceTypeCode;
                    StaticPool.symbolCode = data.InvoiceSymbolCode;
                    StaticPool.TaxRate = data.taxRate;
                    LogHelper.Log(LogHelper.EmLogType.INFOR,
                        LogHelper.EmObjectLogType.System,
                        noi_dung_hanh_dong: $@"Tải hóa đơn điện tử {StaticPool.CompanyName} - {StaticPool.CompanyAddress} - 
                                                                   {StaticPool.TaxCode} - {StaticPool.templateCode} - 
                                                                   {StaticPool.symbolCode} - {StaticPool.TaxRate}");
                }
                return data;
            }
            else
            {
                return null;
            }

        }

    }
}
