using System.Threading.Tasks;
using iParkingv5.Objects.Datas.warehouse_service;
using static iParkingv5.Objects.Datas.warehouse_service.WarehouseType;

namespace iParkingv5.ApiManager.interfaces
{
    public interface iWarehouseService
    {
        Task<WarehouseService> CreateWarehouseService(string eventInId, string eventOutId, string plate, EmTransactionType type, bool isPrint = false);
    }
}
