using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Datas.payment_service
{

    public class BaseVoucherObject
    {
        private string _name;
        private string _code;
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name
        {
            get => _name;
            set
            {
                if (value.IndexOfAny("!@#$^&*()".ToCharArray()) != -1)
                {
                    throw new ArgumentException("Không được sử dụng ký tự đặc biệt");
                }
                _name = value;
            }
        }
        public string Code
        {
            get => _code;
            set
            {
                if (value.IndexOfAny("!@#$%^&*()".ToCharArray()) != -1)
                {
                    throw new ArgumentException("Không được sử dụng ký tự đặc biệt");
                }
                _code = value;
            }
        }
    }
}
