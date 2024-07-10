using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Reporting
{
    public class SumaryCountEvent
    {
        /// <summary>
        /// Số lượng xe đang trong bãi
        /// </summary>
        public int countAllEventIn { get; set; } = 0;
        /// <summary>
        /// Tổng số xe ra khỏi bãi trong ngày
        /// </summary>
        public int totalEventOut { get; set; } = 0;
        /// <summary>
        /// Tổng số xe vào bãi trong ngày
        /// </summary>
        public int totalVehicleIn { get; set; } = 0;
    }
}
