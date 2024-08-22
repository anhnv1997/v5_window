namespace iParkingv5.ApiManager.KzParkingv5Apis
{
    internal class KzParkingv5BaseResponse
    {
    }

    public class KzParkingv5BaseResponse<T> where T : class
    {
        public bool isSuccess { get; set; } = true;
        public string message { get; set; } = string.Empty;
        public string errorCode { get; set; } = string.Empty;
        public string detailCode { get; set; } = string.Empty;
        public string traceId { get; set; } = string.Empty;
        public ErrorDetail[]? fields { get; set; } = null;
        public long Revenue { get; set; }
        public int durationInMillisecond { get; set; }
        public int totalCount { get; set; }
        public int totalPage { get; set; }
        public int pageSize { get; set; }
        public int pageIndex { get; set; }
        public T data { get; set; }
    }

    public class ErrorDetail
    {
        public string name { get; set; }
        public string errorCode { get; set; }
    }

}
