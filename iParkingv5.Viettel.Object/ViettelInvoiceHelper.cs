using iParkingv6.ApiManager;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Viettel.Object
{
    public class ViettelInvoiceHelper
    {
        public static string server = "https://api-vinvoice.viettel.vn";
        public static string token = "";
        public static string companyTaxCode = "4900239158";
        public static string username = "4900239158_bxk";
        public static string password = "Bxk1234@";

        public static string createInvoieAction = $"/services/einvoiceapplication/api/InvoiceAPI/InvoiceWS/createInvoice/{companyTaxCode}";
        public static string loginAction = $"/auth/login";

        public static string MaLoiHoaDon = "5";
        public static string Mau = "5/006";
        public static string KyHieuHoaDon = "C23GTK";
        public static int taxPercent = 10;
        public static CancellationTokenSource cts;

        public static async Task<string> GetToken()
        {
            var login = new
            {
                username = username,
                password = password,
            };

            string errorMessage = string.Empty;
            string response = BaseApiHelper.GeneralJsonAPI(server + loginAction, login, new Dictionary<string, string>(), new Dictionary<string, string>(), 5000, ref errorMessage, RestSharp.Method.Post);
            if (string.IsNullOrEmpty(response))
            {
                return string.Empty;
            }
            try
            {
                LoginResponse loginResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginResponse>(response);
                token = loginResponse.access_token;
                return token;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
            return response;
        }

        public static async Task<ViettelInvoiceResult> CreateInvoice(string accessToken, decimal unitPrice, int taxPercent, string plateNumber, DateTime datetimeIn, DateTime datetimeOut, string transactionUID)
        {
            ViettelInvoiceResult viettelInvoiceResult = new ViettelInvoiceResult();

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Cookie", $"access_token={accessToken}");
            string errorMessage = string.Empty;

            MetaData metaData_plateNumber = new MetaData();
            metaData_plateNumber.keyTag = "licensePlate";
            //metaData_plateNumber.keyTag = "plateNumber";
            metaData_plateNumber.valueType = "text";
            metaData_plateNumber.stringValue = string.IsNullOrEmpty(plateNumber) ? "_" : plateNumber;
            metaData_plateNumber.keyLabel = "Biển kiểm soát";
            metaData_plateNumber.isRequired = false;
            metaData_plateNumber.isSeller = false;

            MetaData metaData_datetimeIn = new MetaData();
            metaData_datetimeIn.keyTag = "checkIn";
            //metaData_datetimeIn.keyTag = "datetimeIn";
            metaData_datetimeIn.valueType = "text";
            metaData_datetimeIn.stringValue = datetimeIn.ToString("dd/MM/yyyy HH:mm:ss");
            metaData_datetimeIn.keyLabel = "Giờ vào";
            metaData_datetimeIn.isRequired = false;
            metaData_datetimeIn.isSeller = false;

            MetaData metaData_datetimeOut = new MetaData();
            metaData_datetimeOut.keyTag = "checkOut";
            //metaData_datetimeOut.keyTag = "datetimeOut";
            metaData_datetimeOut.valueType = "text";
            metaData_datetimeOut.stringValue = datetimeOut.ToString("dd/MM/yyyy HH:mm:ss");
            metaData_datetimeOut.keyLabel = "Giờ ra";
            metaData_datetimeOut.isRequired = false;
            metaData_datetimeOut.isSeller = false;

            TimeSpan parkingTime = datetimeOut - datetimeIn;

            MetaData metaData_parkingTime = new MetaData
            {
                keyTag = "parkingTime",
                valueType = "text",
                stringValue = (int)parkingTime.TotalHours + " giờ " + ((int)parkingTime.TotalMinutes - 60 * (int)parkingTime.TotalHours) + " phút",
                keyLabel = "Thời gian lưu bãi",
                isRequired = false,
                isSeller = false
            };

            List<MetaData> metaDatas = new List<MetaData>()
            {
                metaData_plateNumber,
                metaData_datetimeIn,
                metaData_datetimeOut,
                metaData_parkingTime
            };

            float ratio = 1.0f + (float)taxPercent / 100;

            unitPrice = Math.Round((decimal)((float)unitPrice / ratio));
            var orderSend = new
            {
                generalInvoiceInfo = new
                {
                    invoiceType = MaLoiHoaDon,
                    templateCode = Mau,
                    invoiceSeries = KyHieuHoaDon,
                    currencyCode = "VND",
                    adjustmentType = "1",
                    paymentStatus = true,
                    cusGetInvoiceRight = true,
                    transactionUuid = transactionUID,
                },

                sellerInfo = new SellerInfo(),
                buyerInfo = new BuyerInfo(),

                payments = new List<Payments>() {
                    new Payments()
                    {
                        paymentMethodName = "Tiền Mặt"
                    }
                },

                itemInfo = new List<ItemInfo>()
                {
                    new ItemInfo()
                    {
                        lineNumber = 1,
                        selection = 1,
                        itemCode = "VeGuiXe",
                        itemName = "VÉ XE KHÁCH LƯỢT",
                        uniCode = null,
                        unitName = "Vé",
                        unitPrice = unitPrice,
                        quantity = 1,
                        itemTotalAmountWithoutTax = unitPrice * 1,
                        taxPercentage = taxPercent,
                        taxAmount = taxPercent <= 0 ? 0 :Math.Round( unitPrice* 1 * taxPercent / 100),
                        isIncreaseItem = null,
                        itemNote = string.Empty,
                        batchNo = null,
                        expDate = null,
                        discount = 0,
                        discount2 = 0,
                    },
                },

                taxBreakdowns = new List<TaxBreakdowns>()
                {
                    new TaxBreakdowns()
                    {
                        taxPercentage = taxPercent,
                        taxableAmount = unitPrice,
                        taxAmount = taxPercent <= 0 ? 0 : Math.Round( unitPrice* 1 * taxPercent / 100),
                    }
                },

                metadata = metaDatas
            };

            string response = BaseApiHelper.GeneralJsonAPI(server + createInvoieAction, orderSend, headers, new Dictionary<string, string>(), 5000, ref errorMessage, RestSharp.Method.Post);
            viettelInvoiceResult.IsSuccess = !string.IsNullOrEmpty(response);
            viettelInvoiceResult.MessageSend = Newtonsoft.Json.JsonConvert.SerializeObject(orderSend);

            if (viettelInvoiceResult.IsSuccess)
            {
                viettelInvoiceResult.MessageReceived = Newtonsoft.Json.JsonConvert.DeserializeObject<ViettelInvoiceResponse>(response);
                if (string.IsNullOrEmpty(viettelInvoiceResult.MessageReceived.result.invoiceNo))
                {
                    if (!string.IsNullOrEmpty(viettelInvoiceResult.MessageReceived.description))
                    {
                        viettelInvoiceResult.MessageReceived.description = viettelInvoiceResult.MessageReceived.description.Replace('\'', ' ');
                    }
                    viettelInvoiceResult.MessageReceived.result.invoiceNo = GetInvoiceByTransactionUId(accessToken, transactionUID);
                }
            }
            else
            {
               viettelInvoiceResult.MessageReceived = null;
            }
            return viettelInvoiceResult;
        }

        public static ViettelInvoiceFileResponse GetInvoiceFile(string accessToken, string invoiceNo, out string error)
        {
            var dataSend = new
            {
                supplierTaxCode = companyTaxCode,
                invoiceNo = invoiceNo,
                templateCode = Mau,
                fileType = "pdf"
            };
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Cookie", $"access_token={accessToken}");
            string errorMessage = string.Empty;
            string url = $"https://api-vinvoice.viettel.vn/services/einvoiceapplication/api/InvoiceAPI/InvoiceUtilsWS/getInvoiceRepresentationFile";
            string response =BaseApiHelper.GeneralJsonAPI(url, dataSend, headers, new Dictionary<string, string>(), 5000, ref errorMessage, RestSharp.Method.Post);
            if (string.IsNullOrEmpty(response))
            {
                error = errorMessage;
                return null;
            }
            try
            {
                error = string.Empty;
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ViettelInvoiceFileResponse>(response);
            }
            catch (Exception ex)
            {
                error = Newtonsoft.Json.JsonConvert.SerializeObject(ex.Message);
                return null;
            }
        }
        public static string GetInvoiceByTransactionUId(string accessToken, string transactionUid)
        {
            var client = new RestClient("https://api-vinvoice.viettel.vn/services/einvoiceapplication/api/InvoiceAPI/InvoiceWS/searchInvoiceByTransactionUuid");
            var request = new RestRequest();
            request.Method = Method.Post;
            request.Timeout = 5000;
            request.AddHeader("Cookie", $"access_token={accessToken}");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", $"supplierTaxCode={companyTaxCode}&transactionUuid={transactionUid}", ParameterType.RequestBody);
            var response = client.Execute(request);
            if (!response.IsSuccessful)
            {
                response = client.Execute(request);
                if (!response.IsSuccessful)
                {
                    return string.Empty;
                }
                else
                {
                    try
                    {
                        ViettelInvoiceByTransactionUuid result = Newtonsoft.Json.JsonConvert.DeserializeObject<ViettelInvoiceByTransactionUuid>(response.Content);

                        if (result != null)
                        {
                            if (result.result.Count > 0)
                            {
                                return result.result[0].invoiceNo;
                            }
                        }
                        return string.Empty;
                    }
                    catch (Exception ex)
                    {
                        return string.Empty;
                    }
                }
            }
            else
            {
                try
                {
                    ViettelInvoiceByTransactionUuid result = Newtonsoft.Json.JsonConvert.DeserializeObject<ViettelInvoiceByTransactionUuid>(response.Content);
                    if (result != null)
                    {
                        if (result.result.Count > 0)
                        {
                            return result.result[0].invoiceNo;
                        }
                    }
                    return string.Empty;
                }
                catch (Exception ex)
                {
                    return string.Empty;
                }
            }
        }

        public static async void StartPollingAuthorize()
        {
            cts = new CancellationTokenSource();
            PollingAuthorize(cts.Token);
        }
        public static async void StopPollingAuthorize()
        {
            cts?.Cancel();
        }
        private static async Task PollingAuthorize(CancellationToken ctsToken)
        {
            while (!ctsToken.IsCancellationRequested)
            {
                try
                {
                    var response = await GetToken();
                    if (!string.IsNullOrEmpty(response))
                    {
                        token = response;
                    }
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    GC.Collect();
                    if (string.IsNullOrEmpty(token))
                    {
                        await Task.Delay(TimeSpan.FromSeconds(1));
                    }
                    else
                    {
                        await Task.Delay(TimeSpan.FromSeconds(30), ctsToken);
                    }
                }
            }
        }

        public class GetInvoiceInput
        {
            public string startDate { get; set; }
            public string endDate { get; set; }
            public int rowPerPage { get; set; } = 20;
            public int pageNum { get; set; } = 1;

        }
    }
}