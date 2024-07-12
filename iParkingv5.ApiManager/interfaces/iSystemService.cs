using iParkingv5.Objects.Datas.system_service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iParkingv5.ApiManager.interfaces
{
    public interface iSystemService
    {
        Task<SystemConfig> GetSystemConfigAsync();
    }
}
