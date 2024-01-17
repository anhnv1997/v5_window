using static iParkingv5.Objects.Enums.PrintHelpers;

namespace iParkingv5.Objects.Configs
{
    public class AppOption
    {
        /// <summary>
        /// Thời gian cho phép mở barrie sau khi quẹt thẻ
        /// </summary>
        public int AllowBarrieDelayOpenTime { get; set; } = 5;
        /// <summary>
        /// Khoảng cách giữa 2 lần quẹt thẻ liên tiếp (s)
        /// </summary>
        public int MinDelayCardTime { get; set; } = 5;
        /// <summary>
        /// Mẫu phiếu in
        /// </summary>
        public int PrintTemplate { get; set; } = (int)EmPrintTemplate.BaseTemplate;
    }
}
