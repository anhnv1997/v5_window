using iParkingv5.ApiManager.interfaces;
using iParkingv6.ApiManager;
using Kztek.Tool;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static iParkingv5.ApiManager.KzParkingv5Apis.KzParkingv5BaseApi;
using iParkingv5.Objects.Datas.warehouse_service;
using static iParkingv5.Objects.Datas.warehouse_service.WarehouseType;

namespace iParkingv5.ApiManager.KzParkingv5Apis.services
{
    public class KzParkingv5WarehouseService : iWarehouseService
    {
        public async Task<WarehouseService> CreateWarehouseService(string eventInId, string eventOutId, string plate, EmTransactionType type, bool isPrint = false)
        {
            return null;
            server = server.StandardlizeServerName();
            string apiUrl = server + "warehouse/transaction";
            Dictionary<string, string> headers = new Dictionary<string, string>()
                    {
                        { "Authorization","Bearer " + token  }
                    };
            WarehouseServiceInput warehouseService = new WarehouseServiceInput()
            {
                type = (int)type,
                plateNumber = plate,
                eventInId = eventInId,
                eventOutId = Guid.Empty,
                PrintPaper = isPrint,
            };

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, warehouseService, headers, null, timeOut, RestSharp.Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    WarehouseService result = NewtonSoftHelper<WarehouseService>.GetBaseResponse(response.Item1);
                    return result;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return null;
        }
    }
}
