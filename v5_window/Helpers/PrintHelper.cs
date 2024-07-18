using IPaking.Ultility;
using iParkingv5.Objects;
using iParkingv5.Objects.ScaleObjects;
using Kztek.Tool.TextFormatingTools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iParkingv5.Objects.Enums.PrintHelpers;

namespace iParkingv5_window.Helpers
{
    public static class PrintHelper
    {
        #region PUBLIC FUNCTION
        public static string GetPrintScaleInvoiceOfflineContent(WeighingAction weighingActionDetail, string plateNumber)
        {
            string printTemplatePath = PathManagement.appPrintScaleInvoiceOfflineTemplateConfigPath(((EmPrintTemplate)StaticPool.appOption.PrintTemplate).ToString());
            if (File.Exists(printTemplatePath))
            {
                string baseContent = File.ReadAllText(printTemplatePath);
                baseContent = baseContent.Replace("$companyTaxCode", StaticPool.TaxCode);
                baseContent = baseContent.Replace("$companyAddress", StaticPool.CompanyAddress);
                baseContent = baseContent.Replace("$companyName", StaticPool.CompanyName);
                baseContent = baseContent.Replace("$templateCode", StaticPool.scaleSymbolCode);

                baseContent = baseContent.Replace("$day", DateTime.Now.Day.ToString("00"));
                baseContent = baseContent.Replace("$month", DateTime.Now.Month.ToString("00"));
                baseContent = baseContent.Replace("$year", DateTime.Now.Year.ToString("0000"));

                baseContent = baseContent.Replace("$excecute_time", DateTime.Now.ToString(UltilityManagement.fullDayFormat));
                baseContent = baseContent.Replace("$plateNumber", plateNumber);

                baseContent = baseContent.Replace("$money_int", TextFormatingTool.GetMoneyFormat(weighingActionDetail.weighingType.Price.ToString()));

                baseContent = baseContent.Replace("$money_str", SayMoney.MISASaysMoney.MISASayMoney(weighingActionDetail.weighingType.Price));

                return baseContent;
            }
            else
            {
                MessageBox.Show("Không tìm thấy mẫu in", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return string.Empty;
            }
        }
        public static string GetScalePrintContent(List<WeighingAction> weighingActionDetails, string plateNumber, string weighingType)
        {
            string printContent = string.Empty;
            if (weighingActionDetails.Count <= 2)
            {
                int i = 1;
                foreach (var item in weighingActionDetails)
                {
                    string scaleItem = GetPrintContentItem(item, i);
                    printContent += scaleItem;
                    i++;
                }
                if (weighingActionDetails.Count <= 1)
                {
                    printContent += GetPrintContentItem(null, 2);
                    printContent += GetGoodsScaleItem("_");
                }
                else
                {
                    printContent += GetGoodsScaleItem(Math.Abs(weighingActionDetails[0].Weight - weighingActionDetails[1].Weight).ToString("#,0"));
                }
            }
            else
            {
                int i = 1;
                foreach (var item in weighingActionDetails)
                {
                    string scaleItem = GetPrintContentItem(item, i);
                    printContent += scaleItem;
                    i++;
                }
            }

            string printTemplatePath = PathManagement.appPrintScaleTemplateConfigPath(((EmPrintTemplate)StaticPool.appOption.PrintTemplate).ToString());
            if (File.Exists(printTemplatePath))
            {
                string baseContent = File.ReadAllText(printTemplatePath);
                baseContent = baseContent.Replace("{$content}", printContent);
                baseContent = baseContent.Replace("{$plateNumber}", plateNumber);
                baseContent = baseContent.Replace("{$weightType}", weighingType);
                baseContent = baseContent.Replace("{$number}", weighingActionDetails[0].weighingSlip?.printNumber ?? "");
                return baseContent;
            }
            else
            {
                MessageBox.Show("Không tìm thấy mẫu in", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return string.Empty;
            }
        }
        public static string GetParkingPrintContent(string baseContent,
                                       DateTime dateTimeIn, DateTime dateTimeOut,
                                       string plate = "", string moneyStr = "", long moneyInt = 0, string receiveBillCode = "")
        {
            baseContent = baseContent.Replace("$companyTaxCode", StaticPool.TaxCode);
            baseContent = baseContent.Replace("$companyAddress", StaticPool.CompanyAddress);
            baseContent = baseContent.Replace("$companyName", StaticPool.CompanyName);
            baseContent = baseContent.Replace("$templateCode", StaticPool.templateCode);

            baseContent = baseContent.Replace("$day", DateTime.Now.Day.ToString("00"));
            baseContent = baseContent.Replace("$month", DateTime.Now.Month.ToString("00"));
            baseContent = baseContent.Replace("$year", DateTime.Now.Year.ToString("0000"));

            baseContent = baseContent.Replace("$datetimeIn", dateTimeIn.ToString(UltilityManagement.fullDayFormat));
            baseContent = baseContent.Replace("$datetimeOut", dateTimeOut.ToString(UltilityManagement.fullDayFormat));
            var ParkingTime = dateTimeOut - dateTimeIn;
            string formattedTime = "";
            if (ParkingTime.TotalDays > 1)
            {
                formattedTime = string.Format("{0} ngày {1} giờ {2} phút {3} giây", ParkingTime.Days, ParkingTime.Hours, ParkingTime.Minutes, ParkingTime.Seconds);
            }
            else
            {
                formattedTime = string.Format("{0} giờ {1} phút {2} giây", ParkingTime.Hours, ParkingTime.Minutes, ParkingTime.Seconds);
                //formattedTime = string.Format("{0:hh\\:mm\\:ss}", ParkingTime);
            }

            baseContent = baseContent.Replace("$parking_time", formattedTime);
            baseContent = baseContent.Replace("$plateNumber", plate);

            baseContent = baseContent.Replace("$money_int", moneyStr);

            baseContent = baseContent.Replace("$money_str", SayMoney.MISASaysMoney.MISASayMoney(moneyInt));

            baseContent = baseContent.Replace("$ReceiveBillCode", receiveBillCode);
            return baseContent;
        }

        public static string GetPhieuThuContent(string baseContent, string cardName, string cardGroupName, Image img,
                                      DateTime dateTimeIn, DateTime dateTimeOut,
                                      string plate = "", string moneyStr = "",
                                      long moneyInt = 0, string receiveBillCode = "")
        {
            baseContent = baseContent.Replace("$companyTaxCode", StaticPool.TaxCode);

            baseContent = baseContent.Replace("$day", DateTime.Now.Day.ToString("00"));
            baseContent = baseContent.Replace("$month", DateTime.Now.Month.ToString("00"));
            baseContent = baseContent.Replace("$year", DateTime.Now.Year.ToString("0000"));

            baseContent = baseContent.Replace("$timeIn", dateTimeIn.ToString(UltilityManagement.fullDayFormat));
            baseContent = baseContent.Replace("$timeOut", dateTimeOut.ToString(UltilityManagement.fullDayFormat));
            baseContent = baseContent.Replace("$plate", plate);
            baseContent = baseContent.Replace("$cardName", cardName);
            baseContent = baseContent.Replace("$cardGroupName", cardGroupName);
            if (img != null)
            {
                try
                {
                    using (MemoryStream m = new MemoryStream())
                    {
                        img.Save(m, img.RawFormat);
                        byte[] imageBytes = m.ToArray();

                        // Convert byte[] to Base64 String
                        string base64String = Convert.ToBase64String(imageBytes);
                        baseContent = baseContent.Replace("$image_data", base64String);
                    }
                }
                catch (Exception)
                {
                }
            }

            baseContent = baseContent.Replace("$money", moneyStr);
            return baseContent;
        }

        public static void PrintPdf(string pdfContent)
        {
            byte[] bytes = Convert.FromBase64String(pdfContent);
            if (!Directory.Exists(@"C:\print"))
            {
                Directory.CreateDirectory(@"C:\print");
            }
            string fileName = (@"C:\print\file" + DateTime.Now.ToString("yyyy_mm_dd_HH_mm_ss_ffff") + ".pdf");

            System.IO.FileStream stream =
                new FileStream(fileName, FileMode.CreateNew);
            System.IO.BinaryWriter writer =
                new BinaryWriter(stream);
            writer.Write(bytes, 0, bytes.Length);
            writer.Close();
            Process p = new Process
            {
                StartInfo = new ProcessStartInfo()
                {
                    CreateNoWindow = true,
                    Verb = "print",
                    UseShellExecute = true,
                    FileName = fileName
                }
            };
            p.Start();
            p.WaitForExit();
            //p.Dispose();
            File.Delete(fileName);
        }
        #endregion END PUBLIC FUNCTION

        #region PRIVATE FUNCTION
        private static string GetPrintContentItem(WeighingAction? weighingActionDetail, int index)
        {
            if (weighingActionDetail == null)
            {
                return $@"<tr>
                    <td>
                        <span>
                            <center>Lần cân {index}</center>
                        </span>
                    </td>
                    <td>
                        <center><span>__/__/____ __:__</span></center>
                    </td>
                    <td>
                        <center><span><b>_</b></span></center>
                    </td>
                    </tr>";
            }
            else
                return $@"<tr>
                    <td>
                        <span>
                            <center>Lần cân {index}</center>
                        </span>
                    </td>
                    <td>
                        <center><span>{weighingActionDetail.createdUtcTime.Value.ToString(UltilityManagement.fullDayFormat)}</span></center>
                    </td>
                    <td>
                        <center><span><b>{weighingActionDetail.Weight.ToString("#,0")}</b></span></center>
                    </td>
                    </tr>";
        }
        private static string GetGoodsScaleItem(string goodScale)
        {
            return $@" <tr>
                    <td colspan=""2"">
                        <span>
                            <center>Khối lượng hàng</center>
                        </span>
                    </td>
                    <td>
                        <center><b><span>{goodScale}</span></b></center>
                    </td>
                    </tr>";
        }
        #endregion END PRIVATE FUNCTION

    }
}
