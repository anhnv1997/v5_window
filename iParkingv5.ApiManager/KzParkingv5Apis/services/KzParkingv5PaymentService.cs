using iParkingv5.ApiManager.interfaces;
using iParkingv5.Objects.Datas.invoice_service;
using iParkingv5.Objects.Datas.payment_service;
using iParkingv5.Objects.Enums;
using iParkingv5.Objects.EventDatas;
using iParkingv6.ApiManager;
using Kztek.Tool;
using Kztek.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static iParkingv5.ApiManager.KzParkingv5Apis.Filter;
using static iParkingv5.ApiManager.KzParkingv5Apis.KzParkingv5ApiHelper;
using static iParkingv5.ApiManager.KzParkingv5Apis.KzParkingv5ApiUrlManagement;
using static iParkingv5.ApiManager.KzParkingv5Apis.KzParkingv5BaseApi;

namespace iParkingv5.ApiManager.KzParkingv5Apis.services
{
    public class KzParkingv5PaymentService : iPaymentService
    {
        public enum Method
        {
            QrCode,
            Cash,
            Card
        }
        public enum Provider
        {
            None,
            Momo,
            Tingee,
            Vimo,
        }

        public async Task<PaymentTransaction> CreatePaymentTransaction(EventOutData eventOut)
        {
            var data = new PaymentTransaction
            {
                targetId = eventOut.Id,
                targetType = InvoiceTargetType.EventOut,
                amount = eventOut.Charge,
                method = (int)Method.Cash,
                provider = (int)Provider.None,
                //details = new List<PaymentDetail>()
                //{
                //    new PaymentDetail(){purpose = EmPaymentPurpose.ParkingDay, quantity = eventOut.charge.Day, amount = eventOut.charge.DayAmount, price = eventOut.charge.DayPrice },
                //    new PaymentDetail(){purpose = EmPaymentPurpose.ParkingNight, quantity = eventOut.charge.Night, amount = eventOut.charge.NightAmount, price = eventOut.charge.NightPrice },
                //    new PaymentDetail(){purpose = EmPaymentPurpose.ParkingNormalCharge, quantity = 1, amount =eventOut.charge.FullDayAmount, price =eventOut.charge.FullDayPrice },
                //},
            };

            server = server.StandardlizeServerName();
            string apiUrl = server + KzParkingv5ApiUrlManagement.PostObjectRoute(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.PaymentTransaction);
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, data, headers, null, timeOut, RestSharp.Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                PaymentTransaction paymentTransaction = NewtonSoftHelper<PaymentTransaction>.GetBaseResponse(response.Item1);
                return paymentTransaction;
            }
            return null;
        }
    }
}
