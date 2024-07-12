namespace iParkingv5.ApiManager.interfaces
{
    public interface iParkingApi
    {
        iSystemService systemService { get; set; }
        iDeviceService deviceService { get; set; }
        iParkingDataService parkingDataService { get; set; }
        iParkingProcessService parkingProcessService { get; set; }
        iPaymentService paymentService { get; set; }
        iUserService userService { get; set; }
        iReportingService reportingService { get; set; }

        iWarehouseService? warehouseService { get; set; }
        iInvoiceService? invoiceService { get; set; }

    }
}
