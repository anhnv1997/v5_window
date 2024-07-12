using iParkingv5.Objects.Datas.user_service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iParkingv5.ApiManager.interfaces
{
    public interface iUserService
    {
        Task GetUserInfor();
        Task<Tuple<List<User>, string>> GetAllUsers();
    }
}
