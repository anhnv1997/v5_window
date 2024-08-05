using iParkingv5.Printer.OfficeHaus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iParkingv5.Objects.Enums.PrintHelpers;

namespace iParkingv5.Printer
{
    public static class PrinterFactory
    {
        public static iPrinter CreatePrinter(EmPrintTemplate emPrintTemplate)
        {
            switch (emPrintTemplate)
            {
                case EmPrintTemplate.BaseTemplate:
                    return new DefaultPrinter();
                case EmPrintTemplate.XuanCuong:
                    break;
                case EmPrintTemplate.OfficeHaus:
                    return new OfficeHausPrinter();
                case EmPrintTemplate.Seastars_Hotel:
                    return new SeaStarsHotelPrinter();
                default:
                    break;
            }
            return null;
        }
    }
}
