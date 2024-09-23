using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Enums
{
    public class SoundType
    {
        public enum EmSoundType
        {
            LOOP_PULSE_ON_SOUND = 1,     // Xin moi nhan nut lay the
            OPEN_BARRIER_SOUND = 2,      // Xin moi vao
            INVALID_PLATE = 3,           // Sai biển số vui lòng nhấn nút gọi hỗ trợ
            CARD_NOT_EXIST = 4,          // Thẻ không tồn tại vui lòng gọi hỗ trợ
            CARD_EXPIRED = 5,            // Thẻ hết hạn vui lòng gọi hỗ trợ
            THE_CHUA_RA_KHOI_BAI = 6,    // Thẻ chưa ra khỏi bãi vui lòng gọi hỗ trợ
            CARD_EMPTY = 7,              // Hết thẻ vui lòng gọi hỗ trợ
            CARD_DISPENSING_ERROR = 8,   // Lỗi phát thẻ vui lòng nhấn nút gọi hỗ trợ
        }

    }
}
