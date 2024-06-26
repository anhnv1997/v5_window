﻿using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.ApiManager.KzScaleApis
{
    public static class KzScaleUrlManagement
    {

        public static string GetCountInDayRoute() => "report_count";
        public static string GetAllWeighingFormRoute() => "list_weighing_form";

        public static string CreateWeighingAction() => "save_weighing_action";
        public static string GetAllWeighingHistory() => "list_weighing_action";

        public static string GetWeighingActionDetailsByTrafficIdRoute(string trafficId) => "";
    }
}
