using System.Collections.Generic;
using static iParkingv5.ApiManager.KzParkingv5Apis.Filter;

namespace iParkingv5.ApiManager.KzParkingv5Apis
{
    public class FilterModel
    {
        public string QueryKey { get; set; } = "";
        public string QueryType { get; set; } = "";
        public string QueryValue { get; set; } = "";
        public string Operation { get; set; } = "";

        public FilterModel() { }
        public FilterModel(string queryKey, string queryType, string queryValue, string operation)
        {
            this.QueryKey = queryKey;
            this.QueryType = queryType;
            this.QueryValue = queryValue;
            this.Operation = operation;
        }
        public FilterModel(EmPageSearchKey queryKey, EmPageSearchType queryType, string queryValue, EmOperation operation)
        {
            this.QueryKey = queryKey.ToString();
            this.QueryType = queryType.ToString();
            this.QueryValue = queryValue;
            this.Operation = operation.ToString().Replace("_", "");
        }
    }

    public class Filter
    {
        public enum EmMainOperation
        {
            and,
            or,
        }
        public enum EmOperation
        {
            _eq = 0,
            _neq = 1,
            _in = 2,
            _contains = 3,
            _lt = 4,
            _lte = 5,
            _gt = 6,
            _gte = 7,
        }

        public enum EmPageSearchType
        {
            TEXT = 1,
            NUMBER = 2,
            BOOLEAN = 3,
            GUID = 4,
            DATE = 5,
            DATETIME = 6,
            DATETIME2 = 7,
            NULLABLE_GUID = 8,
            NULLABLE_DATE = 9,
            NULLABLE_DATETIME = 10,
            NULLABLE_DATETIME2 = 11
        }
        public enum EmPageSearchKey
        {
            id,
            name,
            code,
            plateNumber,
            IpAddress,
            ComputerId,
            CreatedUtc,
            LaneId,
            CustomerId,
            identityGroupId
        }

        public class DetailCode
        {
            public const string ERROR_VALIDATION = "ERROR.VALIDATION.FAILED";

            public const string ERROR_VALIDATION_REQUIRED = "ERROR.ENTITY.VALIDATION.FIELD_REQUIRED";

            public const string ERROR_VALIDATION_SOME_ITEMS_DELETED = "ERROR.ENTITY.VALIDATION.SOME_ITEMS_DELETED";

            public const string ERROR_VALIDATION_DUPLICATED = "ERROR.ENTITY.VALIDATION.FIELD_DUPLICATED";

            public const string ERROR_VALIDATION_NOT_FOUND = "ERROR.ENTITY.VALIDATION.FIELD_NOT_FOUND";

            public const string ERROR_ENTITY_NOT_FOUND_SOME_ITEMS_DELETED = "ERROR.ENTITY.NOT_FOUND.SOME_ITEMS_DELETED";

            public const string ERROR_VALIDATION_NOT_ACTIVE = "ERROR.ENTITY.VALIDATION.FIELD_NOT_ACTIVE";

            public const string ERROR_VALIDATION_INVALID = "ERROR.ENTITY.VALIDATION.FIELD_INVALID";
        }

        public static string CreateFilter(List<FilterModel> filterModels, EmMainOperation mainOperation = EmMainOperation.and,
                                          int pageIndex = 0, int pageSize = 100)
        {
            var filterData = new Dictionary<string, List<FilterModel>>
            {
                { mainOperation.ToString(), filterModels }
            };
            var temp = new
            {
                pageIndex = pageIndex,
                pageSize = pageSize,
                filter = Newtonsoft.Json.JsonConvert.SerializeObject(filterData),
                sorts = "",
                fields = new List<object>()
            };
            return Newtonsoft.Json.JsonConvert.SerializeObject(temp);
        }
        public static string CreateFilter(FilterModel filterModel, EmMainOperation mainOperation = EmMainOperation.and,
                                          int _pageIndex = 0, int _pageSize = 100)
        {
            var filterData = new Dictionary<string, List<FilterModel>>
            {
                { mainOperation.ToString(), new List<FilterModel>(){ filterModel } }
            };
            var temp = new
            {
                pageIndex = _pageIndex,
                pageSize = _pageSize,
                filter = string.IsNullOrEmpty(filterModel.QueryKey) ? "" : Newtonsoft.Json.JsonConvert.SerializeObject(filterData),
                sorts = "",
                fields = new List<object>()
            };
            return Newtonsoft.Json.JsonConvert.SerializeObject(temp);
        }
        public static string CreateFilter(EmPageSearchKey queryKey, EmPageSearchType pageSearchType,
                                          EmOperation operation, string searchValue,
                                          EmMainOperation mainOperation = EmMainOperation.and,
                                          int _pageIndex = 0, int _pageSize = 100)
        {
            var filterData = new Dictionary<string, List<FilterModel>>
            {
                { mainOperation.ToString(), new List<FilterModel>(){ new FilterModel(queryKey,pageSearchType, searchValue,operation) } }
            };

            string _filter = Newtonsoft.Json.JsonConvert.SerializeObject(filterData);
            var temp = new
            {
                pageIndex = _pageIndex,
                pageSize = _pageSize,
                filter = _filter,
                sorts = "",
                fields = new List<object>()
            };
            return Newtonsoft.Json.JsonConvert.SerializeObject(temp);
        }

    }
}
