using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.ApiManager
{
    public static class ApiExtension
    {
        #region Private Function
        public static string StandardlizeServerName(this string serverUrl)
        {
            if (serverUrl[^1] != '/' && serverUrl[^1] != '\\')
            {
                serverUrl += "/";
            }
            return serverUrl;
        }
        #endregion End Private Function
    }
}
