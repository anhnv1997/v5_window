using System;
using System.Collections.Generic;
using System.Text;

namespace Viettel.Object
{
    public class LoginResponse
    {
        public string access_token { get; set; } = string.Empty;
        public string token_type { get; set; } = string.Empty;
        public string refresh_token { get; set; } = string.Empty;
        public int expires_in { get; set; } = 0;
        public string scope { get; set; } = string.Empty;
        public long iat { get; set; } = 0;
        public string invoice_cluster { get; set; } = string.Empty;
        public int type { get; set; } = 0;
        public string jti { get; set; } = string.Empty;
    }
}
