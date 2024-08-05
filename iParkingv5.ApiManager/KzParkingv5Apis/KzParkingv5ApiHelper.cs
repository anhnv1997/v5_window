using System.Collections.Generic;
using iParkingv5.ApiManager.interfaces;
using iParkingv5.ApiManager.KzParkingv5Apis.services;

namespace iParkingv5.ApiManager.KzParkingv5Apis
{
    public class KzParkingv5ApiHelper : iParkingApi
    {

        public KzParkingv5ApiHelper(iDeviceService deviceService, iInvoiceService invoiceService, iParkingDataService dataService,
                                  iParkingProcessService parkingProcessService, iPaymentService paymentService, iUserService userService,
                                  iWarehouseService warehouseService, iReportingService reportingService, iSystemService systemService)
        {
            this.deviceService = deviceService;
            this.invoiceService = invoiceService;
            this.parkingDataService = dataService;
            this.parkingProcessService = parkingProcessService;
            this.paymentService = paymentService;
            this.userService = userService;
            this.warehouseService = warehouseService;
            this.reportingService = reportingService;
            this.systemService = systemService;
        }

        public KzParkingv5ApiHelper() :
            this(new KzParkingv5DeviceService(), new KzParkingv5InvoiceService(), new KzParkingv5DataService(),
                 new KzParkingv5ProcessService(), new KzParkingv5PaymentService(), new KzParkingv5UserService(),
                 new KzParkingv5WarehouseService(), new KzParkingv5ReportingService(), new KzParkingv5SystemService())
        { }


        public iDeviceService deviceService { get; set; }
        public iInvoiceService invoiceService { get; set; }
        public iParkingDataService parkingDataService { get; set; }
        public iParkingProcessService parkingProcessService { get; set; }
        public iPaymentService paymentService { get; set; }
        public iUserService userService { get; set; }
        public iWarehouseService warehouseService { get; set; }
        public iReportingService reportingService { get; set; }
        public iSystemService systemService { get; set; }


        #region SubClass
        public class BaseEventReport<T> where T : class
        {
            public List<T> rows { get; set; }
        }
        #endregion End SubClass


        #region System Config


        #endregion







        #region PARKING - PROCESS
        #region Event In

        public class Report<T> where T : class
        {
            public int TotalPage { get; set; }
            public int TotalCount { get; set; }
            public long Revenue { get; set; }
            public List<T> data { get; set; }
        }

        #endregion End Event In

        #region Event Out


        #endregion End Event Out

        #endregion END PARKING - PROCESS
    }
}
