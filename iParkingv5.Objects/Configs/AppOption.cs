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
        public bool IsSaveLog { get; set; }
        public int LoopDelay { get; set; } = 0;
        public int RetakePhotoDelay { get; set; } = 300;
        public int RetakePhotoTimes { get; set; } = 5;
        public string ScaleDevice { get; set; } = "";
    }
}
