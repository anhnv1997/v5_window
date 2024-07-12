using System.Threading.Tasks;
using iParkingv5.Objects.Datas.payment_service;
using iParkingv5.Objects.EventDatas;

namespace iParkingv5.ApiManager.interfaces
{
    public interface iPaymentService
    {
        Task<PaymentTransaction> CreatePaymentTransaction(AddEventOutResponse eventOut);
    }
}
