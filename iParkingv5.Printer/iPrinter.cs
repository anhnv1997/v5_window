using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iParkingv5.Printer
{
    public interface iPrinter
    {
        void PrintPhieuThu(string baseContent, string cardName, string cardGroupName, Image img,
                                      DateTime dateTimeIn, DateTime dateTimeOut,
                                      string plate = "", string moneyStr = "",
                                      long moneyInt = 0, string receiveBillCode = "");
        void PrintOffliceInvoice(string baseContent, string cardName, string cardGroupName, Image img,
                                      DateTime dateTimeIn, DateTime dateTimeOut,
                                      string plate = "", string moneyStr = "",
                                      long moneyInt = 0, string receiveBillCode = "");
        void PrintOnlineInvoice(string baseContent, string cardName, string cardGroupName, Image img,
                                      DateTime dateTimeIn, DateTime dateTimeOut,
                                      string plate = "", string moneyStr = "",
                                      long moneyInt = 0, string receiveBillCode = "");
    }
}
