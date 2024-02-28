using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects
{
    public static class ApiInternalErrorMessages
    {
        public enum EmApiErrorMessage
        {
            PINT_1001,
            PINT_1002,
            PINT_1003,
            PINT_1004,
            PINT_1005,
            PINT_1006,
            PINT_1007,
            PINT_1008,
            PINT_1009,
            PINT_1010,
            PINT_1011,
            PINT_1012,
            PINT_1013,
            PINT_1014,
            PINT_1015,
            PINT_1016,
            PINT_1017,
            /// <summary>
            /// Plate number in and out are not same
            /// </summary>
            PINT_1018,
            PINT_1019,
            PINT_4001,
            PINT_4002,
            PINT_4003,
            PINT_4004,
            PINT_4005,
            PINT_4006,
            PINT_4007,
            PINT_4008,
            PINT_4009,
            PINT_4010,
            PINT_4011,
            PINT_4012,
            PINT_4013,
            PINT_4014,
            PINT_4015,
            PINT_4016,
            PINT_4017,
            PINT_5001,
            PINT_5002
        }
        /// <summary>
        /// <param name="errorMessage"></param>
        /// <param name="language">0 - Tiếng Việt, 1 - Tiếng Anh</param>
        /// </summary>
        /// <returns></returns>
        public static string ToString(EmApiErrorMessage? errorMessage, int language = 0)
        {
            if (errorMessage == null)
            {
                return string.Empty;
            }
            switch (errorMessage)
            {
                case EmApiErrorMessage.PINT_1001:
                    return language == 0 ? "Đăng nhập thất bại" : "Login failed";
                case EmApiErrorMessage.PINT_1002:
                    return language == 0 ? "Tên đã tồn tại trong hệ thống" : "Duplicated name";
                case EmApiErrorMessage.PINT_1003:
                    return language == 0 ? "Mã đã tồn tại trong hệ thống" : "Duplicated code";
                case EmApiErrorMessage.PINT_1004:
                    return language == 0 ? "Địa chỉ IP đã tồn tại trong hệ thống" : "Duplicated ip address";
                case EmApiErrorMessage.PINT_1005:
                    return language == 0 ? "Tên đăng nhập đã tồn tại trong hệ thống" : "Duplicated user name";
                case EmApiErrorMessage.PINT_1006:
                    return language == 0 ? "Biển số xe đã tồn tại trong hệ thống" : "Duplicated Plate Number";
                case EmApiErrorMessage.PINT_1007:
                    return language == 0 ? "Phương tiện đã hết hạn sử dụng" : "Registered vehicle expired";
                case EmApiErrorMessage.PINT_1008:
                    return language == 0 ? "Phượng tiện đang bị khóa" : "Registered vehicle not enabled";
                case EmApiErrorMessage.PINT_1009:
                    return language == 0 ? "Phương tiện chưa được kích hoạt" : "Registered vehicle not activated";
                case EmApiErrorMessage.PINT_1010:
                    return language == 0 ? "Identity not in use" : "Identity not in use";
                case EmApiErrorMessage.PINT_1011:
                    return language == 0 ? "Xe đang trong bãi" : "Vehicle already in parking lot";
                case EmApiErrorMessage.PINT_1012:
                    return language == 0 ? "Xe chưa vào bãi" : "Vehicle not in parking lot";
                case EmApiErrorMessage.PINT_1013:
                    return language == 0 ? "Biển số không khớp với biển số đăng ký" : "Plate number does not correspond to any registered vehicle";
                case EmApiErrorMessage.PINT_1014:
                    return language == 0 ? "Nhóm định danh không được sử dụng với làn" : "Identity group not granted access to this lane";
                case EmApiErrorMessage.PINT_1015:
                    return language == 0 ? "Nhóm định danh chưa được kích hoạt" : "Identity group not enabled";
                case EmApiErrorMessage.PINT_1016:
                    return language == 0 ? "Nhóm định danh - sai giờ sử dụng" : "Identity group not enabled in this time";
                case EmApiErrorMessage.PINT_1017:
                    return language == 0 ? "This Identity is not the one used for check in" : "This Identity is not the one used for check in";
                case EmApiErrorMessage.PINT_1018:
                    return language == 0 ? "Biển số vào ra không khớp" : "Plate number in and out are not same";
                case EmApiErrorMessage.PINT_1019:
                    return language == 0 ? "Phương tiện không được phép ghi vào bằng biển số" : "Registered vehicle not allowed to check in by plate only";
                case EmApiErrorMessage.PINT_4001:
                    return language == 0 ? "Không tìm thấy thông tin camera" : "Camera not found";
                case EmApiErrorMessage.PINT_4002:
                    return language == 0 ? "Không tìm thấy thông tin máy tính" : "Computer not found";
                case EmApiErrorMessage.PINT_4003:
                    return language == 0 ? "Không tìm thấy thông tin bộ điều khiển" : "Control unit not found";
                case EmApiErrorMessage.PINT_4004:
                    return language == 0 ? "Không tìm thấy thông tin nhóm khách hàng" : "Customer group not found";
                case EmApiErrorMessage.PINT_4005:
                    return language == 0 ? "Không tìm thấy thông tin khách hàng" : "Customer not found";
                case EmApiErrorMessage.PINT_4006:
                    return language == 0 ? "Không tìm thấy thông tin cổng" : "Gate not found";
                case EmApiErrorMessage.PINT_4007:
                    return language == 0 ? "Không tìm thấy thông tin định danh" : "Identity not found";
                case EmApiErrorMessage.PINT_4008:
                    return language == 0 ? "Không tìm thấy thông tin nhóm định danh" : "Identity group not found";
                case EmApiErrorMessage.PINT_4009:
                    return language == 0 ? "Không tìm thấy thông tin làn" : "Lane not found";
                case EmApiErrorMessage.PINT_4010:
                    return language == 0 ? "Không tìm thấy thông tin bảng LED" : "Led not found";
                case EmApiErrorMessage.PINT_4011:
                    return language == 0 ? "Không tìm thấy thông tin phương tiện" : "Registered vehicle not found";
                case EmApiErrorMessage.PINT_4012:
                    return language == 0 ? "Không tìm thấy thông tin phân quyền" : "Role not found";
                case EmApiErrorMessage.PINT_4013:
                    return language == 0 ? "Không tìm thấy thông tin người dùng" : "User not found";
                case EmApiErrorMessage.PINT_4014:
                    return language == 0 ? "Không tìm thấy thông tin loại phương tiện" : "Vehicle type not found";
                case EmApiErrorMessage.PINT_4015:
                    return language == 0 ? "KHông tìm thấy thông tin sự kiện vào" : "Event in not found";
                case EmApiErrorMessage.PINT_4016:
                    return language == 0 ? "Không tìm thấy thông tin sự kiện ra" : "Event out not found";
                case EmApiErrorMessage.PINT_4017:
                    return language == 0 ? "Không tìm thấy thông tin quyền truy cập" : "Permission out not found";
                case EmApiErrorMessage.PINT_5001:
                    return language == 0 ? "Thông tin sự kiện không hợp lệ" : "Invalid input";
                case EmApiErrorMessage.PINT_5002:
                    return language == 0 ? "Làn không tồn tại" : "Invalid lane";
                default:
                    return string.Empty;
            }
        }

        public static EmApiErrorMessage? GetFromName(string name)
        {
            foreach (EmApiErrorMessage item in Enum.GetValues(typeof(EmApiErrorMessage)))
            {
                if (item.ToString() == name)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
