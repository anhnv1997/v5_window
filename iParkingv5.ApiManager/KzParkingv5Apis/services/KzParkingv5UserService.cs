using iParkingv5.ApiManager.interfaces;
using iParkingv5.Objects.Datas.user_service;
using iParkingv5.Objects;
using iParkingv6.ApiManager;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static iParkingv5.ApiManager.KzParkingv5Apis.KzParkingv5BaseApi;
using Kztek.Tools;

namespace iParkingv5.ApiManager.KzParkingv5Apis.services
{
    public class KzParkingv5UserService : iUserService
    {
        #region USER
        public async Task GetUserInfor()
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "SystemService", "Get User Info");
            server = server.StandardlizeServerName();
            string apiUrl = server + "user/info";

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, null,
                                                                  timeOut, Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    User user = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(response.Item1);
                    StaticPool.userId = user.id;
                    StaticPool.user_name = user.upn;
                }
                catch (Exception)
                {

                }
            }
        }

        public async Task<Tuple<List<User>, string>> GetAllUsers()
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "SystemService", "Get All User");
            return await GetAllObjectAsync<User>(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.User);
        }
        #endregion
    }
}
