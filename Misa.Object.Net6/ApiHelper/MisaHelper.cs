using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using static Misa.Object.CQT_TYPE;
using static Misa.Object.InvoiceFileDownloadType;
using ApiHelper;
using Futech.Tools;

namespace Misa.Object
{
    public class MisaHelper
    {
        public static string startupPath = "";
        public static int timeOut = 10000;
        public static string tokenHeader = "token";
        public const int max_send_times = 2;

        #region: Get System Config
        public static bool GetToken(string appId, string taxCode, string username, string password, ref string token)
        {
            try
            {
                string apiUrl = ApiUrlManagement.GetToken;
                Dictionary<string, string> headerValues = new Dictionary<string, string>();
                Dictionary<string, string> requiredParams = new Dictionary<string, string>();
                string error = string.Empty;
                Login login = new Login()
                {
                    appid = appId,
                    taxcode = taxCode,
                    username = username,
                    password = password,
                };
                string loginResponseData = RestsharpApiHelpers.GeneralJsonAPI(apiUrl, login, headerValues, requiredParams, timeOut, ref error, Method.Post);
                if (string.IsNullOrEmpty(loginResponseData))
                {
                    return false;
                }
                LoginResponse loginResponse = SerializeUtil.DeserializeObject<LoginResponse>(loginResponseData) ?? new LoginResponse();
                if (!loginResponse.Success) return false;
                token = loginResponse.Data.ToString();
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR,
                              LogHelper.EmObjectLogType.Api,
                              obj: ex,
                              specailName: "MISA");
                return false;
            }
            finally
            {
                GC.Collect();
            }
        }
        #endregion: End Get System Config

        #region: Company
        public static Company GetCompanyInfoResult(string token)
        {
            try
            {
                string apiUrl = ApiUrlManagement.GetCompanyInfor;
                Dictionary<string, string> headerValues = new Dictionary<string, string>();
                Dictionary<string, string> requiredParams = new Dictionary<string, string>();
                string error = string.Empty;
                headerValues.Add("authorization", "Bearer " + token);

                string companyData = RestsharpApiHelpers. GeneralJsonAPI(apiUrl, null, headerValues, requiredParams, timeOut, ref error, Method.Get);
                if (string.IsNullOrEmpty(companyData))
                {
                    return new Company();
                }
                CompanyInfoResult companyInfoResult = SerializeUtil.DeserializeObject<CompanyInfoResult>(companyData) ?? new CompanyInfoResult();
                if (companyInfoResult.Success)
                {
                    return SerializeUtil.DeserializeObject<Company>(companyInfoResult.Data.ToString()) ?? new Company();
                }
                return new Company(); ;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR,
                              LogHelper.EmObjectLogType.Api,
                              obj: ex,
                              specailName: "MISA");
                return new Company();
            }
            finally
            {
                GC.Collect();
            }
        }

        public static ListInvoiceTemplateResult GetInvoiceTemplate(string token, bool IsInvoiceWithCode, string companyCode, int year)
        {
            try
            {
                string apiUrl = IsInvoiceWithCode ? ApiUrlManagement.GetInvoiceHaveCodeTemplate : ApiUrlManagement.GetInvoiceNotHaveCodeTemplate;// ApiUrlManagement.GetCompanyInfor;
                Dictionary<string, string> headerValues = new Dictionary<string, string>();
                Dictionary<string, string> requiredParams = new Dictionary<string, string>();
                string error = string.Empty;
                headerValues.Add("authorization", "Bearer " + token);
                headerValues.Add("CompanyTaxCode", companyCode);
                requiredParams.Add("invyear", year.ToString());

                string invoiceTemplateData = RestsharpApiHelpers.GeneralJsonAPI(apiUrl, null, headerValues, requiredParams, timeOut, ref error, Method.Get);
                if (string.IsNullOrEmpty(invoiceTemplateData))
                {
                    return new ListInvoiceTemplateResult();
                }
                ListInvoiceTemplateResult invoiceTemplateResult = SerializeUtil.DeserializeObject<ListInvoiceTemplateResult>(invoiceTemplateData) ?? new ListInvoiceTemplateResult();
                if (invoiceTemplateResult.Success)
                {
                    invoiceTemplateResult.TemplateDatas = SerializeUtil.DeserializeObject<List<TemplateData>>(invoiceTemplateResult.Data.ToString()) ?? new List<TemplateData>();
                    return invoiceTemplateResult;
                }
                return new ListInvoiceTemplateResult(); ;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR,
                              LogHelper.EmObjectLogType.Api,
                              obj: ex,
                              specailName: "MISA");
                return new ListInvoiceTemplateResult();
            }
            finally
            {
                GC.Collect();
            }
        }

        public static ListInvoiceTemplateResult GetAllTicket(string token, string companyCode)
        {
            try
            {
                string apiUrl = ApiUrlManagement.GetTicketUrl;
                Dictionary<string, string> headerValues = new Dictionary<string, string>();
                Dictionary<string, string> requiredParams = new Dictionary<string, string>();
                string error = string.Empty;
                headerValues.Add("authorization", "Bearer " + token);
                headerValues.Add("CompanyTaxCode", companyCode);

                string invoiceTemplateData = RestsharpApiHelpers.GeneralJsonAPI(apiUrl, null, headerValues, requiredParams, timeOut, ref error, Method.Get);
                if (string.IsNullOrEmpty(invoiceTemplateData))
                {
                    return new ListInvoiceTemplateResult();
                }
                ListInvoiceTemplateResult invoiceTemplateResult = SerializeUtil.DeserializeObject<ListInvoiceTemplateResult>(invoiceTemplateData) ?? new ListInvoiceTemplateResult();
                if (invoiceTemplateResult.Success)
                {
                    invoiceTemplateResult.TicketDatas = SerializeUtil.DeserializeObject<List<TicketTemplateData>>(invoiceTemplateResult.Data.ToString()) ?? new List<TicketTemplateData>();
                    return invoiceTemplateResult;
                }
                return new ListInvoiceTemplateResult(); ;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR,
                              LogHelper.EmObjectLogType.Api,
                              obj: ex,
                              specailName: "MISA");
                return new ListInvoiceTemplateResult();
            }
            finally
            {
                GC.Collect();
            }
        }
        #endregion: End Company

        #region: Invoice
        //public static bool PublishInvoice(string token, string companyCode, InvoiceBuilder invoiceBuilder,
        //                                 int lineNumber, int sortOrder, string itemCode, string itemName, Em_ItemType itemType, string unitName, decimal unitPrice, decimal quantity,
        //                                 CustomerInfor customer, TemplateData selectedTemplate, InvoiceCurrencyInfor invoiceCurrencyInfor,
        //                                 Em_InvoiceReferenceType invoiceReferenceType, OrgInvoiceInfor orgInvoiceInfor, ref string errorMessage, Em_SignType signType = Em_SignType.Direct,
        //                                 string signName = "", string signPin = "", string signByFileDataPath = "", string signByFilePinPath = "",
        //                                 bool isSendMail = false, string receiverEmail = "", string receiverName = "",
        //                                 decimal vatValue = 10 / 100, string vatRateName = "10%", decimal? discountRate = 0, decimal exchangeRate = 1, string unitCode = "DVT")
        //{
        //    // Khai báo đôi tượng list hóa đơn cần phát hành
        //    List<OriginalInvoiceData> lstData = new List<OriginalInvoiceData>();

        //    // Khai báo đối tượng hóa đơn khi tạo xml thô trả về
        //    ListCreateInvoiceDataResult InvoiceDataResult = new ListCreateInvoiceDataResult();

        //    // Khai báo list đối tượng cần đem đi phát hành
        //    List<PublishInvoiceData> lstPublishInvoiceData = new List<PublishInvoiceData>();

        //    // khai báo đối tượng HD cần phát hành
        //    PublishInvoiceData PublishInvoiceData = new PublishInvoiceData();

        //    // Khai báo đối tượng khi phát hành hóa đơn trả về
        //    ListPublishInvoiceResult PublishInvoiceResult = new ListPublishInvoiceResult();

        //    // Lấy giá trị gán vào đối tượng hóa đơn
        //    OriginalInvoiceData invoiceData = BuildOriginalInvoiceData(lineNumber, sortOrder, itemCode, itemName, itemType, unitName, unitPrice, quantity,
        //                                                               customer, selectedTemplate, invoiceCurrencyInfor,
        //                                                               invoiceReferenceType, orgInvoiceInfor,
        //                                                               vatValue, vatRateName, discountRate, exchangeRate, unitCode);
        //    // Thêm đối tượng hóa đơn vào list hóa đơn cần phát hành
        //    lstData.Add(invoiceData);

        //    if (signType == Em_SignType.Direct || signType == Em_SignType.Server || signType == Em_SignType.File)
        //    {
        //        //Ký trực tiếp và ký qua server
        //        //tạo hóa đơn xml dạng thô
        //        InvoiceDataResult = CreateInvoiceData(lstData, companyCode, token);
        //        //kiểm trá kết quả trả về thành công không, có xml không. nếu không báo mã lỗi trả về
        //        if (InvoiceDataResult.ErrorCode == "" && InvoiceDataResult.CreateInvoiceDatas.Count > 0)
        //        {
        //            // kiểm tra lỗi trong nội dung json không có thì đem đi ký
        //            if (string.IsNullOrEmpty(InvoiceDataResult.CreateInvoiceDatas[0].ErrorCode))
        //            {
        //                // Khai báo đối tượng xml chưa xml thô được trả về
        //                XmlDocument XmlData = new XmlDocument();
        //                // gán xml dạng string được trả về khi tạo xml thô
        //                XmlData.LoadXml(InvoiceDataResult.CreateInvoiceDatas[0].InvoiceData);
        //                // kiểm tra xem đang là ký trực tiếp hay ký qua tool ký

        //                if (signType == Em_SignType.Server)
        //                {
        //                    // PHƯƠNG THỨC KÝ QUA TOOL KÝ.
        //                    // tên máy chủ ký số
        //                    // mã pin của Chứng thư số
        //                    // file xml cần ký
        //                    // cổng port của tool ký
        //                    var oResultSignXML = SignXmlUtil.SignXMLByTool(signName, signPin, XmlData, "12019");
        //                    if (string.IsNullOrEmpty(oResultSignXML.Data))
        //                    {
        //                        XmlData.LoadXml(oResultSignXML.Data);
        //                    }
        //                    else
        //                    {
        //                        errorMessage = "Ký SignService XML lỗi, Mã lỗi: " + oResultSignXML.Error;
        //                        return false;
        //                    }
        //                }
        //                else if (signType == Em_SignType.Direct)
        //                {
        //                    //PHƯƠNG THỨC KÝ TRỰC TIẾP
        //                    // Gọi SDK để show chọn CTS được cài trên máy
        //                    X509Certificate2 cert = GetCertificateFromStore();
        //                    // truyền các giá trị vào hàm ký số để ký
        //                    SignXmlUtil.SignXml(XmlData, cert);
        //                }
        //                else if (signType == Em_SignType.File)
        //                {
        //                    var oResultSignXML = SignXmlUtil.SignXMLByFile(XmlData, signByFileDataPath, signByFilePinPath);
        //                    if (!string.IsNullOrEmpty(oResultSignXML.Data))
        //                    {
        //                        XmlData.LoadXml(oResultSignXML.Data);
        //                    }
        //                    else
        //                    {
        //                        errorMessage = "Ký file XML lỗi, Mã lỗi: " + oResultSignXML.Error;
        //                        return false;
        //                    }
        //                }

        //                // Gán giá trị cho đối tượng gọi đi phát hành
        //                PublishInvoiceData.InvoiceData = XmlData.InnerXml;
        //                PublishInvoiceData.RefID = InvoiceDataResult.CreateInvoiceDatas[0].RefID;
        //                PublishInvoiceData.TransactionID = InvoiceDataResult.CreateInvoiceDatas[0].TransactionID;
        //                PublishInvoiceData.IsSendEmail = isSendMail;
        //                PublishInvoiceData.ReceiverEmail = receiverEmail;
        //                PublishInvoiceData.ReceiverName = receiverName;

        //                lstPublishInvoiceData.Add(PublishInvoiceData);
        //                // Phát hành hóa đơn lên hệ thống MISA
        //                PublishInvoiceResult = PublishInvoiceToMisa(token, companyCode, lstPublishInvoiceData);
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    else if (signType == Em_SignType.HSM)
        //    {
        //        // Nếu ký qua HSM thì tạo đối tượng ký HSM
        //        var invoiceListHSM = new List<OriginalInvoiceDataHSM>();
        //        var invoiceHSM = new OriginalInvoiceDataHSM()
        //        {
        //            RefID = invoiceData.RefID,
        //            OriginalInvoiceData = invoiceData,
        //            IsInvoiceSummary = false, //nếu đơn vị dùng hóa đơn không mã, và hình thức đơn vị dùng là gửi dữ liệu dưới dạng bảng tổng hợp lên thuế thì gán là true
        //            IsSendEmail = isSendMail, //nếu đơn vị muốn sau khi phát hành xong mà gửi email hóa đơn cho khách hàng thì gán là true
        //            ReceiverEmail = receiverEmail, //địa chỉ email ng nhận hóa đơn
        //            ReceiverName = receiverName
        //        };
        //        invoiceListHSM.Add(invoiceHSM);
        //        PublishInvoiceResult = PublishInvoiceHSMToMisa(token, companyCode, invoiceListHSM);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Chưa chọn phương thức ký nào.");
        //        return false;
        //    }

        //    // kiểm tra xem hàm phát hành thành công hay chưa. nếu lỗi báo theo mã lỗi phía dưới
        //    if (PublishInvoiceResult.Success && PublishInvoiceResult.ErrorCode == "")
        //    {
        //        // đối tượng nhận kết quả khi phát hành trả về
        //        List<PublishInvoice> pubResult = PublishInvoiceResult.PublishInvoices;
        //        // kiểm tra có đối tượng phát hành trả về không
        //        if (pubResult != null && pubResult.Count > 0)
        //        {
        //            // kiểm tra có mã lỗi trả về không
        //            if (string.IsNullOrEmpty(pubResult[0].ErrorCode))
        //            {
        //                ////show các thông tin hóa đơn đã phát hành thành công được trả về
        //                //StringBuilder messageBuilder = new StringBuilder();
        //                //messageBuilder.AppendFormat("Phát hành hóa đơn thành công.{0}", Environment.NewLine);
        //                //messageBuilder.AppendFormat("Mã tra cứu: {0}{1}", pubResult[0].TransactionID, Environment.NewLine);
        //                //messageBuilder.AppendFormat("Số hóa đơn: {0}{1}", pubResult[0].InvNo, Environment.NewLine);
        //                //messageBuilder.AppendFormat("Ngày hóa đơn: {0}{1}", pubResult[0].InvDate, Environment.NewLine);

        //                //txtNumberOrg.Text = pubResult[0].InvNo;
        //                //dteOrgDate.Value = pubResult[0].InvDate.Date;

        //                //using (Form frm = new Form())
        //                //{
        //                //    RichTextBox rtb = new RichTextBox();
        //                //    rtb.Text = messageBuilder.ToString();
        //                //    rtb.Dock = DockStyle.Fill;
        //                //    frm.Controls.Add(rtb);
        //                //    frm.StartPosition = FormStartPosition.CenterScreen;
        //                //    frm.ShowDialog();
        //                //}
        //                errorMessage = "";
        //                return true;
        //            }
        //            else
        //            {
        //                //Phát hành không thành công, show mã lỗi trả về
        //                switch (pubResult[0].ErrorCode)
        //                {
        //                    case ErrorCode.SignatureEmpty:
        //                        errorMessage = "File chưa được ký";
        //                        break;
        //                    case ErrorCode.InvalidSignature:
        //                        errorMessage = "Chữ ký số không hợp lệ";
        //                        break;
        //                    case ErrorCode.InvalidXMLData:
        //                        errorMessage = "Dữ liệu XML hóa đơn không hợp lệ";
        //                        break;
        //                    case ErrorCode.InvoiceTemplateNotValidInDeclaration:
        //                        errorMessage = "Tờ khai đăng ký/thay đổi đã được Cơ quan thuế chấp nhận không tồn tại";
        //                        break;
        //                    case ErrorCode.InvoiceNumberNotCotinuous:
        //                        errorMessage = "Số hóa đơn không liên tục";
        //                        break;
        //                    case ErrorCode.InvalidInvNo:
        //                        errorMessage = "Số hóa đơn không hợp lệ";
        //                        break;
        //                    case ErrorCode.InvalidInvoiceDate:
        //                        errorMessage = "Ngày hóa đơn không hợp lệ";
        //                        break;
        //                    case ErrorCode.TaxRateInfo_:
        //                        errorMessage = "Tên loại thuế suất trong Bảng tổng hợp thuế suất của hóa đơn có dữ liệu không hợp lệ";
        //                        break;
        //                    case ErrorCode.InvalidTaxCode:
        //                        errorMessage = "Mã số thuế người bán không giống MST kết nối";
        //                        break;

        //                    default:
        //                        errorMessage = pubResult[0].ErrorCode;
        //                        break;
        //                }
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            errorMessage = "Phát hành thất bại: " + pubResult[0].ErrorCode;
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        errorMessage = "Phát hành thất bại: " + PublishInvoiceResult.ErrorCode;
        //        return false;
        //    }
        //}

        /// <summary>
        /// <c> <em> Quy trình phát hành hóa đơn </em> <br/></c>
        /// <list type="bullet|number|table">
        /// 
        /// <item>
        /// <term><c> Bước 1 </c>: Tạo thông tin cho hóa đơn</term>
        /// <description><see cref="CreateInvoiceData(List{OriginalInvoiceData}, string, string)"/></description>
        /// </item>
        /// 
        /// <item>
        /// <term><c>Bước 2</c>: Phát hàng hóa đơn</term>
        /// <description> Tùy thuộc vào loại hóa đơn mà sử dụng <see cref="PublishInvoiceToMisa(string, string, List{PublishInvoiceData})"/> hay <see cref="PublishInvoiceHSMToMisa(string, string, List{OriginalInvoiceDataHSM})"/></description>
        /// </item>
        /// 
        /// <item>
        /// <term><c>Bước 3</c>: Kiểm tra phát hành thành công hay thất bại</term>
        /// <description><see cref="GetPublishInvoiceErrorCode(List{PublishInvoice})"/></description>
        /// </item>
        /// 
        /// </list>
        /// <param name="token"> <paramref name="token"/> Token trả về sau khi đăng nhập thành công hệ thống <see cref="GetToken(string, string, string, string, ref string)"/></param> <br/>
        /// <param name="companyCode"><paramref name="companyCode"/> Thông tin MST của công ty <see cref="GetCompanyInfoResult(string)"/></param> <br/>
        /// <param name="invoiceBuilder"><paramref name="invoiceBuilder"/> Builder dùng để xây dựng nội dung hóa đơn để phát hành <seealso cref="InvoiceBuilder"/></param> <br/>
        /// <param name="signType"><paramref name="signType"/> Hình thức chữ ký sử dụng <see cref="Em_SignType"/></param> <br/>
        /// <param name="signName"><paramref name="signName"/> Tên hình thức chữ ký sử dụng</param> <br/>
        /// <param name="signPin"><paramref name="signPin"/> Mã Pin chữ ký sử dụng</param> <br/>
        /// <param name="signByFileDataPath"><paramref name="signByFileDataPath"/> Đường dẫn chứa chữ ký số sử dụng</param> <br/>
        /// <param name="signByFilePinPath"><paramref name="signByFilePinPath"/> Đường dẫn mã chữ ký số sử dụng</param> <br/>
        /// <param name="isSendMail"><paramref name="isSendMail"/> Xác định có gửi mail hay không, mặc định sẽ không gửi</param> <br/>
        /// <param name="receiverEmail"><paramref name="receiverEmail"/> Thông tin Mail nhận hóa đơn</param> <br/>
        /// <param name="receiverName"><paramref name="receiverName"/> Tên chủ sở hữu mail nhận hóa đơn</param> <br/>
        /// <param name="errorMessage"><paramref name="errorMessage"/> Mã lỗi trả về nếu có</param> <br/>
        /// </summary>
        /// <returns></returns>
        public static bool PublishInvoice(string token, string companyCode, InvoiceBuilder invoiceBuilder, ref string errorMessage, ref string apiContent, ref string result,
                                         Em_SignType signType = Em_SignType.Direct, string signName = "", string signPin = "", string signByFileDataPath = "", string signByFilePinPath = "",
                                         bool isSendMail = false, string receiverEmail = "", string receiverName = "")
        {
            // Khai báo đôi tượng list hóa đơn cần phát hành
            List<OriginalInvoiceData> lstData = new List<OriginalInvoiceData>();
            // Khai báo đối tượng hóa đơn khi tạo xml thô trả về
            ListCreateInvoiceDataResult InvoiceDataResult = new ListCreateInvoiceDataResult();
            // Khai báo list đối tượng cần đem đi phát hành
            List<PublishInvoiceData> lstPublishInvoiceData = new List<PublishInvoiceData>();
            // khai báo đối tượng HD cần phát hành
            PublishInvoiceData PublishInvoiceData = new PublishInvoiceData();
            // Khai báo đối tượng khi phát hành hóa đơn trả về
            ListPublishInvoiceResult PublishInvoiceResult = new ListPublishInvoiceResult();
            // Lấy giá trị gán vào đối tượng hóa đơn
            // Thêm đối tượng hóa đơn vào list hóa đơn cần phát hành
            lstData.Add(invoiceBuilder.invoiceData);
            invoiceBuilder.invoiceData.IsTaxReduction43 = invoiceBuilder.invoiceData.TaxRateInfo[0].VATRateName == "8%" ? true : false;
            invoiceBuilder.invoiceData.isTicket = true;
            if (signType == Em_SignType.Direct || signType == Em_SignType.Server || signType == Em_SignType.File)
            {
                //Ký trực tiếp và ký qua server
                //tạo hóa đơn xml dạng thô
                InvoiceDataResult = CreateInvoiceData(lstData, companyCode, token);
                //kiểm trá kết quả trả về thành công không, có xml không. nếu không báo mã lỗi trả về
                if (InvoiceDataResult.ErrorCode == "" && InvoiceDataResult.CreateInvoiceDatas.Count > 0)
                {
                    // kiểm tra lỗi trong nội dung json không có thì đem đi ký
                    if (string.IsNullOrEmpty(InvoiceDataResult.CreateInvoiceDatas[0].ErrorCode))
                    {
                        // Khai báo đối tượng xml chưa xml thô được trả về
                        XmlDocument XmlData = new XmlDocument();
                        // gán xml dạng string được trả về khi tạo xml thô
                        XmlData.LoadXml(InvoiceDataResult.CreateInvoiceDatas[0].InvoiceData);
                        // kiểm tra xem đang là ký trực tiếp hay ký qua tool ký

                        if (signType == Em_SignType.Server)
                        {
                            // PHƯƠNG THỨC KÝ QUA TOOL KÝ.
                            // tên máy chủ ký số
                            // mã pin của Chứng thư số
                            // file xml cần ký
                            // cổng port của tool ký
                            var oResultSignXML = SignXmlUtil.SignXMLByTool(signName, signPin, XmlData, "12019");
                            if (string.IsNullOrEmpty(oResultSignXML.Data))
                            {
                                XmlData.LoadXml(oResultSignXML.Data);
                            }
                            else
                            {
                                errorMessage = "Ký SignService XML lỗi, Mã lỗi: " + oResultSignXML.Error;
                                return false;
                            }
                        }
                        else if (signType == Em_SignType.Direct)
                        {
                            //PHƯƠNG THỨC KÝ TRỰC TIẾP
                            // Gọi SDK để show chọn CTS được cài trên máy
                            X509Certificate2 cert = SignXmlUtil.GetCertificateFromStore();
                            if (cert == null) return false;
                            // truyền các giá trị vào hàm ký số để ký
                            SignXmlUtil.SignXml(XmlData, cert);
                        }
                        else if (signType == Em_SignType.File)
                        {
                            var oResultSignXML = SignXmlUtil.SignXMLByFile(XmlData, signByFileDataPath, signByFilePinPath);
                            if (!string.IsNullOrEmpty(oResultSignXML.Data))
                            {
                                XmlData.LoadXml(oResultSignXML.Data);
                            }
                            else
                            {
                                errorMessage = "Ký file XML lỗi, Mã lỗi: " + oResultSignXML.Error;
                                return false;
                            }
                        }

                        // Gán giá trị cho đối tượng gọi đi phát hành
                        PublishInvoiceData.InvoiceData = XmlData.InnerXml;
                        PublishInvoiceData.RefID = InvoiceDataResult.CreateInvoiceDatas[0].RefID;
                        PublishInvoiceData.TransactionID = InvoiceDataResult.CreateInvoiceDatas[0].TransactionID;
                        PublishInvoiceData.IsSendEmail = isSendMail;
                        PublishInvoiceData.ReceiverEmail = receiverEmail;
                        PublishInvoiceData.ReceiverName = receiverName;

                        lstPublishInvoiceData.Add(PublishInvoiceData);
                        // Phát hành hóa đơn lên hệ thống MISA
                        PublishInvoiceResult = PublishInvoiceToMisa(token, companyCode, lstPublishInvoiceData);
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else if (signType == Em_SignType.HSM)
            {
                //    InvoiceDataResult = CreateInvoiceData(lstData, companyCode, token);
                // Nếu ký qua HSM thì tạo đối tượng ký HSM
                var invoiceListHSM = new List<OriginalInvoiceDataHSM>();
                var invoiceHSM = new OriginalInvoiceDataHSM()
                {
                    RefID = lstData[0].RefID,
                    OriginalInvoiceData = lstData[0],
                    IsInvoiceSummary = false, //nếu đơn vị dùng hóa đơn không mã, và hình thức đơn vị dùng là gửi dữ liệu dưới dạng bảng tổng hợp lên thuế thì gán là true
                    IsSendEmail = isSendMail, //nếu đơn vị muốn sau khi phát hành xong mà gửi email hóa đơn cho khách hàng thì gán là true
                    ReceiverEmail = receiverEmail, //địa chỉ email ng nhận hóa đơn
                    ReceiverName = receiverName
                };
                invoiceListHSM.Add(invoiceHSM);

                apiContent = SerializeUtil.SerializeObject(invoiceListHSM);
                PublishInvoiceResult = PublishInvoiceHSMToMisa(token, companyCode, invoiceListHSM, ref result);
            }
            else
            {
                return false;
            }

            // kiểm tra xem hàm phát hành thành công hay chưa. nếu lỗi báo theo mã lỗi phía dưới
            if (PublishInvoiceResult.Success && PublishInvoiceResult.ErrorCode == "")
            {
                // đối tượng nhận kết quả khi phát hành trả về
                List<PublishInvoice> pubResult = PublishInvoiceResult.PublishInvoices;
                // kiểm tra có đối tượng phát hành trả về không
                if (pubResult != null && pubResult.Count > 0)
                {
                    // kiểm tra có mã lỗi trả về không
                    if (string.IsNullOrEmpty(pubResult[0].ErrorCode))
                    {
                        ////show các thông tin hóa đơn đã phát hành thành công được trả về
                        //StringBuilder messageBuilder = new StringBuilder();
                        //messageBuilder.AppendFormat("Phát hành hóa đơn thành công.{0}", Environment.NewLine);
                        //messageBuilder.AppendFormat("Mã tra cứu: {0}{1}", pubResult[0].TransactionID, Environment.NewLine);
                        //messageBuilder.AppendFormat("Số hóa đơn: {0}{1}", pubResult[0].InvNo, Environment.NewLine);
                        //messageBuilder.AppendFormat("Ngày hóa đơn: {0}{1}", pubResult[0].InvDate, Environment.NewLine);

                        //txtNumberOrg.Text = pubResult[0].InvNo;
                        //dteOrgDate.Value = pubResult[0].InvDate.Date;

                        //using (Form frm = new Form())
                        //{
                        //    RichTextBox rtb = new RichTextBox();
                        //    rtb.Text = messageBuilder.ToString();
                        //    rtb.Dock = DockStyle.Fill;
                        //    frm.Controls.Add(rtb);
                        //    frm.StartPosition = FormStartPosition.CenterScreen;
                        //    frm.ShowDialog();
                        //}
                        errorMessage = "";
                        return true;
                    }
                    else
                    {
                        //Phát hành không thành công, show mã lỗi trả về
                        errorMessage = GetPublishInvoiceErrorCode(pubResult);
                        return false;
                    }
                }
                else
                {
                    errorMessage = "Phát hành thất bại: " + pubResult[0].ErrorCode;
                    return false;
                }
            }
            else
            {
                errorMessage = "Phát hành thất bại: " + PublishInvoiceResult.ErrorCode;
                return false;
            }
        }

        /// <summary>
        /// <c>Lấy trạng thái hóa đơn</c>
        /// </summary>
        /// <param name="originalInvoiceDatas"></param>
        /// <param name="_taxCode"></param>
        /// <param name="_token"></param>
        /// <returns></returns>
        public static ListInvoiceStatusResult GetInvoiceStatus(List<string> lsttransactionID, string _taxCode, string _token)
        {
            try
            {
                string apiUrl = ApiUrlManagement.GetInvoiceStatusUrl(_taxCode != "");
                Dictionary<string, string> headerValues = new Dictionary<string, string>();
                Dictionary<string, string> requiredParams = new Dictionary<string, string>();
                string error = string.Empty;
                headerValues.Add("authorization", "Bearer " + _token);
                headerValues.Add("CompanyTaxCode", _taxCode);

                string serviceResultData = RestsharpApiHelpers.GeneralJsonAPI(apiUrl, lsttransactionID, headerValues, requiredParams, timeOut, ref error, Method.Post);
                ListInvoiceStatusResult oResult = new ListInvoiceStatusResult { Success = false, ErrorCode = string.Empty };
                if (string.IsNullOrEmpty(serviceResultData))
                {
                    return oResult;
                }
                ServiceResult serviceResult = SerializeUtil.DeserializeObject<ServiceResult>(serviceResultData) ?? new ServiceResult();
                if (serviceResult.Success)
                {
                    oResult.lstInvoiceStatus = SerializeUtil.DeserializeObject<List<InvoiceStatus>>(serviceResult.Data.ToString());
                }
                return oResult;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR,
                              LogHelper.EmObjectLogType.Api,
                              obj: ex,
                              specailName: "MISA");
                //return new ListInvoiceTemplateResult();
                return null;
            }
            finally
            {
                GC.Collect();
            }
        }

        /// <summary>
        /// Phương thức này cho phép tải hóa đơn đã phát hành ở dạng XML, PDF hoặc ZIP(PDF và XML)
        /// </summary>
        /// <param name="token"></param>
        /// <param name="companyTaxCode"></param>
        /// <param name="fileDownloadType"></param>
        /// <param name="lsttransactionID"></param>
        /// <returns></returns>
        public static DownloadInvoiceResult DownloadInvoiceResult(string token, string companyTaxCode, Em_FileDownloadType fileDownloadType, List<string> lsttransactionID)
        {
            try
            {
                string apiUrl = ApiUrlManagement.PostDownloadInvoiceUrl(companyTaxCode != "", fileDownloadType);
                Dictionary<string, string> headerValues = new Dictionary<string, string>();
                Dictionary<string, string> requiredParams = new Dictionary<string, string>();
                string error = string.Empty;
                headerValues.Add("authorization", "Bearer " + companyTaxCode);
                headerValues.Add("CompanyTaxCode", companyTaxCode);

                string serviceResultData = RestsharpApiHelpers.GeneralJsonAPI(apiUrl, lsttransactionID, headerValues, requiredParams, timeOut, ref error, Method.Post);
                DownloadInvoiceResult oResult = new DownloadInvoiceResult { Success = false, ErrorCode = string.Empty };
                if (string.IsNullOrEmpty(serviceResultData))
                {
                    return oResult;
                }
                ServiceResult serviceResult = SerializeUtil.DeserializeObject<ServiceResult>(serviceResultData) ?? new ServiceResult();
                if (serviceResult.Success)
                {
                    oResult.DownloadInvoices = SerializeUtil.DeserializeObject<List<DownloadInvoice>>(serviceResult.Data.ToString());
                }
                return oResult;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR,
                              LogHelper.EmObjectLogType.Api,
                              obj: ex,
                              specailName: "MISA");
                return null;
            }
            finally
            {
                GC.Collect();
            }
        }

        //--Chuyển đổi hóa đơn phát hành thành hóa đơn giấy
        public static bool ConvertVoucherPaper(string token, string companyTaxCode, List<string> lsttransactionID)
        {
            return false;
            //try
            //{
            //    string apiUrl = ApiUrlManagement.ConvertVoucherPaper(companyTaxCode != "");
            //    Dictionary<string, string> headerValues = new Dictionary<string, string>();
            //    Dictionary<string, string> requiredParams = new Dictionary<string, string>();
            //    string error = string.Empty;
            //    headerValues.Add("authorization", "Bearer " + companyTaxCode);
            //    headerValues.Add("CompanyTaxCode", companyTaxCode);

            //    string serviceResultData = GeneralJsonAPI(apiUrl, lsttransactionID, headerValues, requiredParams, timeOut, ref error, Method.POST);
            //    DownloadInvoiceResult oResult = new DownloadInvoiceResult { Success = false, ErrorCode = string.Empty };
            //    if (string.IsNullOrEmpty(serviceResultData))
            //    {
            //        LogHelper.Logger_API_Error("Send API CreateInvoiceData Error: " + error, startupPath);
            //        return oResult;
            //    }
            //    ServiceResult serviceResult = Newtonsoft.Json.JsonConvert.DeserializeObject<ServiceResult>(serviceResultData) ?? new ServiceResult();
            //    if (serviceResult.Success)
            //    {
            //        oResult.DownloadInvoices = SerializeUtil.DeserializeObject<List<DownloadInvoice>>(serviceResult.Data.ToString());
            //        LogHelper.Logger_API_Infor("Send API CreateInvoiceData Success", startupPath);
            //    }
            //    return oResult;
            //}
            //catch (Exception ex)
            //{
            //    LogHelper.Logger_API_Error("Send API CreateInvoiceData Exception: " + ex.Message, startupPath);
            //    //return new ListInvoiceTemplateResult();
            //    return null;
            //}
            //finally
            //{
            //    GC.Collect();
            //}
        }

        //--Lấy lin Xem hóa đơn
        public static string GetLinkInvoiceView(string _token)
        {
            try
            {
                string apiUrl = ApiUrlManagement.GetLinkViewUrl();
                Dictionary<string, string> headerValues = new Dictionary<string, string>();
                Dictionary<string, string> requiredParams = new Dictionary<string, string>();
                string error = string.Empty;
                headerValues.Add("authorization", "Bearer " + _token);

                string serviceResultData = RestsharpApiHelpers.GeneralJsonAPI(apiUrl, null, headerValues, requiredParams, timeOut, ref error, Method.Get);
                if (string.IsNullOrEmpty(serviceResultData))
                {
                    return "";
                }
                ServiceResult serviceResult = SerializeUtil.DeserializeObject<ServiceResult>(serviceResultData) ?? new ServiceResult();
                if (serviceResult.Success)
                {
                    return serviceResult.Data.ToString();
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR,
                              LogHelper.EmObjectLogType.Api,
                              obj: ex,
                              specailName: "MISA");
                return string.Empty;
            }
            finally
            {
                GC.Collect();
            }
        }

        //--Gửi hóa đơn
        public static SendInvoiceEmailResult SendInvoice(string _token, string _taxCode, SendEmailParameter sendData)
        {
            try
            {
                SendInvoiceEmailResult oResult = new SendInvoiceEmailResult { Success = false, ErrorCode = string.Empty };

                string apiUrl = ApiUrlManagement.PostSendInvoiceToCustomer();
                Dictionary<string, string> headerValues = new Dictionary<string, string>();
                Dictionary<string, string> requiredParams = new Dictionary<string, string>();
                string error = string.Empty;
                headerValues.Add("authorization", "Bearer " + _token);
                headerValues.Add("CompanyTaxCode", _taxCode);

                string serviceResultData = RestsharpApiHelpers.GeneralJsonAPI(apiUrl, sendData, headerValues, requiredParams, timeOut, ref error, Method.Post);
                if (string.IsNullOrEmpty(serviceResultData))
                {
                    return null;
                }
                ServiceResult serviceResult = SerializeUtil.DeserializeObject<ServiceResult>(serviceResultData) ?? new ServiceResult();
                if (serviceResult.Success)
                {
                    oResult.Success = true;
                    oResult.ErrorCode = serviceResult.ErrorCode;
                    if (!string.IsNullOrEmpty(serviceResult.Data.ToString()))
                    {
                        oResult.SendInvoiceEmail = SerializeUtil.DeserializeObject<List<SendInvoiceEmail>>(serviceResult.Data.ToString())[0];
                    }
                }
                else
                {
                    oResult.ErrorCode = serviceResult.ErrorCode;
                }
                return oResult;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR,
                              LogHelper.EmObjectLogType.Api,
                              obj: ex,
                              specailName: "MISA");
                return null;
            }
            finally
            {
                GC.Collect();
            }
        }

        //--Hủy hóa đơn
        public static bool CancelInvoice(string _token, string _taxCode, CancelInvoiceParamter paramter)
        {
            try
            {
                string apiUrl = ApiUrlManagement.CancelInvoice(_taxCode != "");
                Dictionary<string, string> headerValues = new Dictionary<string, string>();
                Dictionary<string, string> requiredParams = new Dictionary<string, string>();
                string error = string.Empty;
                headerValues.Add("authorization", "Bearer " + _token);
                headerValues.Add("CompanyTaxCode", _taxCode);

                string serviceResultData = RestsharpApiHelpers.GeneralJsonAPI(apiUrl, paramter, headerValues, requiredParams, timeOut, ref error, Method.Post);
                if (string.IsNullOrEmpty(serviceResultData))
                {
                    return false;
                }
                ServiceResult serviceResult = SerializeUtil.DeserializeObject<ServiceResult>(serviceResultData) ?? new ServiceResult();

                return serviceResult.Success;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR,
                              LogHelper.EmObjectLogType.Api,
                              obj: ex,
                              specailName: "MISA");
                return false;
            }
            finally
            {
                GC.Collect();
            }
        }

        #endregion: End Invoice

        #region: Internal

        //--Invoice
        private static OriginalInvoiceData BuildOriginalInvoiceData(int lineNumber, int sortOrder, string itemCode, string itemName, Em_ItemType itemType, string unitName, decimal unitPrice, decimal quantity,
                                                                    CustomerInfor customer, TemplateData selectedTemplate, InvoiceCurrencyInfor invoiceCurrencyInfor,
                                                                    Em_InvoiceReferenceType invoiceReferenceType, OrgInvoiceInfor orgInvoiceInfor,
                                                                    decimal vatValue = 10 / 100, string vatRateName = "10%", decimal? discountRate = 0, decimal exchangeRate = 1, string unitCode = "DVT")
        {
            List<OriginalInvoiceDetail> lstInvoiceDetail = new List<OriginalInvoiceDetail>();
            GetInvoiceDetail(lineNumber, itemType, sortOrder, itemCode, itemName, unitName, unitPrice, quantity, vatValue, vatRateName, discountRate, exchangeRate, unitCode, lstInvoiceDetail);

            var newDetails = lstInvoiceDetail;
            var invoice = new OriginalInvoiceData()
            {
                RefID = Guid.NewGuid().ToString(),

                InvoiceName = selectedTemplate.TemplateName,
                InvSeries = selectedTemplate.InvSeries,

                BuyerAddress = customer.BuyerAddress,
                BuyerBankAccount = customer.BuyerBankAccount,
                BuyerBankName = customer.BuyerBankName,
                BuyerCode = customer.BuyerCode,
                BuyerEmail = customer.BuyerEmail,
                BuyerFullName = customer.BuyerFullName,
                BuyerLegalName = customer.BuyerLegalName,
                BuyerPhoneNumber = customer.BuyerPhoneNumber,
                BuyerTaxCode = customer.BuyerTaxCode,
                ContactName = customer.ContactName,
                InvDate = customer.InvDate,


                CurrencyCode = invoiceCurrencyInfor.CurrencyCode,
                ExchangeRate = invoiceCurrencyInfor.ExchangeRate,
                PaymentMethodName = invoiceCurrencyInfor.PaymentMethodName,

                CustomField1 = "trường mở rộng 1",
                CustomField2 = "trường mở rộng 2",

                OptionUserDefined = new OptionUserDefined()
                {
                    MainCurrency = invoiceCurrencyInfor.CurrencyCode,
                    AmountDecimalDigits = invoiceCurrencyInfor.AmountDecimalDigits.ToString(),
                    AmountOCDecimalDigits = invoiceCurrencyInfor.AmountOCDecimalDigits.ToString(),
                    ClockDecimalDigits = invoiceCurrencyInfor.ClockDecimalDigits.ToString(),
                    CoefficientDecimalDigits = invoiceCurrencyInfor.CoefficientDecimalDigits.ToString(),
                    ExchangRateDecimalDigits = invoiceCurrencyInfor.ExchangRateDecimalDigits.ToString(),
                    QuantityDecimalDigits = invoiceCurrencyInfor.QuantityDecimalDigits.ToString(),
                    UnitPriceDecimalDigits = invoiceCurrencyInfor.UnitPriceDecimalDigits.ToString(),
                    UnitPriceOCDecimalDigits = invoiceCurrencyInfor.UnitPriceOCDecimalDigits.ToString(),
                },
                OriginalInvoiceDetail = newDetails,

                TotalSaleAmountOC = newDetails.Sum(t => t.AmountOC),
                TotalSaleAmount = newDetails.Sum(t => t.Amount),
                TotalDiscountAmountOC = newDetails.Sum(t => t.DiscountAmountOC ?? 0),
                TotalDiscountAmount = newDetails.Sum(t => t.DiscountAmount ?? 0),
                TotalVATAmountOC = newDetails.Sum(t => t.VATAmountOC ?? 0),
                TotalVATAmount = newDetails.Sum(t => t.VATAmount ?? 0),
                TotalAmountWithoutVATOC = newDetails.Sum(t => t.AmountWithoutVATOC ?? 0),
                TotalAmountWithoutVAT = newDetails.Sum(t => t.Amount ?? 0 - t.DiscountAmount ?? 0),
                TotalAmountOC = newDetails.Sum(t => t.AmountOC ?? 0 - t.DiscountAmountOC ?? 0 + t.VATAmountOC ?? 0),
                TotalAmount = newDetails.Sum(t => t.Amount ?? 0 - t.DiscountAmount ?? 0 + t.VATAmount ?? 0),
            };

            if (invoiceReferenceType == Em_InvoiceReferenceType.Replacement || invoiceReferenceType == Em_InvoiceReferenceType.Adjustment)
            {
                invoice.ReferenceType = (int?)invoiceReferenceType;
                invoice.OrgInvoiceType = 1;
                invoice.OrgInvTemplateNo = selectedTemplate.InvSeries.Substring(0, 1);
                invoice.OrgInvSeries = selectedTemplate.InvSeries.Substring(1);
                invoice.OrgInvNo = orgInvoiceInfor.OrgInvNo;
                invoice.OrgInvDate = orgInvoiceInfor.OrgInvDate;
            }

            var taxRateInfos = new List<TaxRateInfo>();
            foreach (var item in newDetails)
            {
                if (!string.IsNullOrEmpty(item.VATRateName) && taxRateInfos.FirstOrDefault(t => t.VATRateName.Equals(item.VATRateName)) == null)
                {
                    var taxRate = new TaxRateInfo()
                    {
                        VATRateName = item.VATRateName,
                        VATAmountOC = newDetails.Sum(t => t.VATRateName == item.VATRateName ? t.VATAmountOC ?? 0 : 0),
                        AmountWithoutVATOC = newDetails.Sum(t => t.VATRateName == item.VATRateName ? t.AmountWithoutVATOC ?? 0 : 0)
                    };
                    taxRateInfos.Add(taxRate);
                }
            }
            invoice.TaxRateInfo = taxRateInfos;
            string beforeWordAmount = "";
            string beforeWordAmountEND = "";
            string sayMoneyENG = "dong";

            if (invoice.ReferenceType == 2)
            {
                // Điều chỉnh
                beforeWordAmount = "Điều chỉnh tăng";
                beforeWordAmountEND = "Adjusted up";
            }

            invoice.TotalAmountInWords = SayMoney.MISASaysMoney.MISASayMoney(invoice.TotalAmountOC ?? 0, sCurrencyID: invoice.CurrencyCode, beforeWordAmount: beforeWordAmount);
            invoice.TotalAmountInWordsVN = SayMoney.MISASaysMoney.MISASayMoney(invoice.TotalAmountOC ?? 0, sCurrencyID: invoice.CurrencyCode, beforeWordAmount: beforeWordAmount);
            invoice.TotalAmountInWordsByENG = SayMoney.MISASaysMoney.MISASayMoney(invoice.TotalAmountOC ?? 0, sLanguageID: "ENG", sCurrencyID: invoice.CurrencyCode, beforeWordAmount: beforeWordAmountEND, afterWordAmount: sayMoneyENG);

            return invoice;
        }

        private static void GetInvoiceDetail(int lineNumber, Em_ItemType itemType, int sortOrder, string itemCode, string itemName, string unitName, decimal unitPrice, decimal quantity, decimal vatValue, string vatRateName, decimal? discountRate, decimal exchangeRate, string unitCode, List<OriginalInvoiceDetail> lstInvoiceDetail)
        {
            OriginalInvoiceDetail originalInvoiceDetail = new OriginalInvoiceDetail()
            {
                LineNumber = lineNumber,
                SortOrder = sortOrder,

                ItemType = (int)itemType,
                ItemCode = itemCode,
                ItemName = itemName,

                UnitCode = unitCode,
                UnitName = unitName,
                UnitPrice = unitPrice,

                Quantity = quantity,

                AmountOC = unitPrice * quantity,
                Amount = unitPrice * quantity * exchangeRate,

                DiscountRate = discountRate,
                DiscountAmountOC = unitPrice * quantity * (discountRate ?? 0),
                DiscountAmount = unitPrice * quantity * exchangeRate * (discountRate ?? 0),

                VATRateName = vatRateName,// tên thuế suất (10%,5%,0%,KCT,KKKNT,KHAC:X.XX% (X: số tự nhiên ví dụ : KHAC:7.00%))
                VATAmountOC = unitPrice * quantity * vatValue,
                VATAmount = unitPrice * quantity * exchangeRate * vatValue,
                AmountWithoutVATOC = unitPrice * quantity * (1 - discountRate ?? 0) // AmountOC - DiscountAmountOC
            };
            lstInvoiceDetail.Add(originalInvoiceDetail);
        }
        #endregion: End Internal
        //public class CustomerInfor
        //{
        //    public string BuyerAddress { get; set; } = string.Empty;
        //    public string BuyerBankAccount { get; set; } = string.Empty;
        //    public string BuyerBankName { get; set; } = string.Empty;
        //    public string BuyerCode { get; set; } = string.Empty;
        //    public string BuyerEmail { get; set; } = string.Empty;
        //    public string BuyerFullName { get; set; } = string.Empty;
        //    public string BuyerLegalName { get; set; } = string.Empty;
        //    public string BuyerPhoneNumber { get; set; } = string.Empty;
        //    public string BuyerTaxCode { get; set; } = string.Empty;
        //    public string ContactName { get; set; } = string.Empty;
        //    public DateTime InvDate { get; set; } = DateTime.Now.Date;
        //    public string InvSeries { get; set; } = string.Empty;
        //}

        //public class InvoiceCurrencyInfor
        //{
        //    public string CurrencyCode { get; set; } = "VND";
        //    public decimal ExchangeRate { get; set; } = 1;
        //    public string PaymentMethodName { get; set; } = "TM/CK";
        //    public int AmountDecimalDigits { get; set; } = 2;
        //    public int AmountOCDecimalDigits { get; set; } = 2;
        //    public int ClockDecimalDigits { get; set; } = 4;
        //    public int CoefficientDecimalDigits { get; set; } = 2;
        //    public int ExchangRateDecimalDigits { get; set; } = 2;
        //    public int QuantityDecimalDigits { get; set; } = 0;
        //    public int UnitPriceDecimalDigits { get; set; } = 2;
        //    public int UnitPriceOCDecimalDigits { get; set; } = 2;
        //}

        //public class OrgInvoiceInfor
        //{
        //    public string OrgInvNo { get; set; } = string.Empty;
        //    public DateTime OrgInvDate { get; set; }
        //}

        private static string GetInvyear(int year, InvoiceType invoiceType, EM_CQT_Type CQT_Type, bool IsInvoiceWithCode)
        {
            return (int)invoiceType + (IsInvoiceWithCode ? "C" : "K") + year.ToString().Substring(2, 2) + "T" + "KZ";
        }


        #region: Private Function
        //--Phát hành hóa đơn
        public static ListCreateInvoiceDataResult CreateInvoiceData(List<OriginalInvoiceData> originalInvoiceDatas, string _taxCode, string _token)
        {
            try
            {
                string apiUrl = ApiUrlManagement.PostCreateInvoicePublishingUrl(_taxCode != "");
                Dictionary<string, string> headerValues = new Dictionary<string, string>();
                Dictionary<string, string> requiredParams = new Dictionary<string, string>();
                string error = string.Empty;
                headerValues.Add("authorization", "Bearer " + _token);
                headerValues.Add("CompanyTaxCode", _taxCode);

                string serviceResultData = RestsharpApiHelpers.GeneralJsonAPI(apiUrl, originalInvoiceDatas, headerValues, requiredParams, timeOut, ref error, Method.Post);
                ListCreateInvoiceDataResult oResult = new ListCreateInvoiceDataResult { Success = false, ErrorCode = string.Empty };
                if (string.IsNullOrEmpty(serviceResultData))
                {
                    return oResult;
                }
                ServiceResult serviceResult = SerializeUtil.DeserializeObject<ServiceResult>(serviceResultData) ?? new ServiceResult();
                if (serviceResult.Success)
                {
                    oResult.CreateInvoiceDatas = SerializeUtil.DeserializeObject<List<CreateInvoiceData>>(serviceResult.Data.ToString());
                }
                return oResult;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR,
                              LogHelper.EmObjectLogType.Api,
                              obj: ex,
                              specailName: "MISA");
                return null;
            }
            finally
            {
                GC.Collect();
            }
        }
        /// <summary>
        /// Phát hành hóa đơn
        /// </summary>
        /// <param name="_token"></param>
        /// <param name="_taxCode"></param>
        /// <param name="publishInvoiceDatas"></param>
        /// <returns></returns>
        public static ListPublishInvoiceResult PublishInvoiceToMisa(string _token, string _taxCode, List<PublishInvoiceData> publishInvoiceDatas)
        {
            try
            {
                string apiUrl = ApiUrlManagement.PostInvoicePublishingUrl(_taxCode != "");
                Dictionary<string, string> headerValues = new Dictionary<string, string>();
                Dictionary<string, string> requiredParams = new Dictionary<string, string>();
                string error = string.Empty;
                headerValues.Add("authorization", "Bearer " + _token);
                headerValues.Add("CompanyTaxCode", _taxCode);

                string response = RestsharpApiHelpers.GeneralJsonAPI(apiUrl, publishInvoiceDatas, headerValues, requiredParams, timeOut, ref error, Method.Post);

                ListPublishInvoiceResult oResult = new ListPublishInvoiceResult { Success = false, ErrorCode = string.Empty };

                if (string.IsNullOrEmpty(response))
                {
                    return oResult;
                }
                ServiceResult serviceResult = SerializeUtil.DeserializeObject<ServiceResult>(response) ?? new ServiceResult();
                if (serviceResult.Success)
                {
                    oResult.Success = true;
                    oResult.PublishInvoices = SerializeUtil.DeserializeObject<List<PublishInvoice>>(serviceResult.Data.ToString());
                }
                else
                {
                    oResult.ErrorCode = serviceResult.ErrorCode;
                }
                return oResult;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR,
                              LogHelper.EmObjectLogType.Api,
                              obj: ex,
                              specailName: "MISA");
                return null;
            }
            finally
            {
                GC.Collect();
            }
        }
        /// <summary>
        /// Phát hành hóa đơn HSM
        /// </summary>
        /// <param name="_token"></param>
        /// <param name="_taxCode"></param>
        /// <param name="publishInvoiceDatas"></param>
        /// <returns></returns>
        public static ListPublishInvoiceResult PublishInvoiceHSMToMisa(string _token, string _taxCode, List<OriginalInvoiceDataHSM> publishInvoiceDatas, ref string response)
        {
            try
            {
                string apiUrl = ApiUrlManagement.PostInvoicePublishingHSMUrl(_taxCode != "");
                Dictionary<string, string> headerValues = new Dictionary<string, string>();
                Dictionary<string, string> requiredParams = new Dictionary<string, string>();
                string error = string.Empty;
                headerValues.Add("authorization", "Bearer " + _token);
                headerValues.Add("CompanyTaxCode", _taxCode);

                string publishData = SerializeUtil.SerializeObject(publishInvoiceDatas);
                response = RestsharpApiHelpers.GeneralJsonAPI(apiUrl, publishData, headerValues, requiredParams, timeOut, ref error, Method.Post);

                ListPublishInvoiceResult oResult = new ListPublishInvoiceResult { Success = false, ErrorCode = string.Empty };

                if (string.IsNullOrEmpty(response))
                {
                    return oResult;
                }
                ServiceResult serviceResult = Newtonsoft.Json.JsonConvert.DeserializeObject<ServiceResult>(response) ?? new ServiceResult();
                if (serviceResult.Success)
                {
                    oResult.Success = true;
                    oResult.PublishInvoices = SerializeUtil.DeserializeObject<List<PublishInvoice>>(serviceResult.Data.ToString());
                }
                else
                {
                    oResult.ErrorCode = serviceResult.ErrorCode;
                }
                return oResult;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR,
                              LogHelper.EmObjectLogType.Api,
                              obj: ex,
                              specailName: "MISA");
                return null;
            }
            finally
            {
                GC.Collect();
            }
        }

        /// <summary>
        /// Phát hành hóa đơn với máy tính tiền
        /// </summary>
        /// <param name="_token"></param>
        /// <param name="_taxCode"></param>
        public static void PublistInvoieForMTT(string _token, string _taxCode)
        {

        }
        private static string GetPublishInvoiceErrorCode(List<PublishInvoice> pubResult)
        {
            string errorMessage;
            switch (pubResult[0].ErrorCode)
            {
                case ErrorCode.SignatureEmpty:
                    errorMessage = "File chưa được ký";
                    break;
                case ErrorCode.InvalidSignature:
                    errorMessage = "Chữ ký số không hợp lệ";
                    break;
                case ErrorCode.InvalidXMLData:
                    errorMessage = "Dữ liệu XML hóa đơn không hợp lệ";
                    break;
                case ErrorCode.InvoiceTemplateNotValidInDeclaration:
                    errorMessage = "Tờ khai đăng ký/thay đổi đã được Cơ quan thuế chấp nhận không tồn tại";
                    break;
                case ErrorCode.InvoiceNumberNotCotinuous:
                    errorMessage = "Số hóa đơn không liên tục";
                    break;
                case ErrorCode.InvalidInvNo:
                    errorMessage = "Số hóa đơn không hợp lệ";
                    break;
                case ErrorCode.InvalidInvoiceDate:
                    errorMessage = "Ngày hóa đơn không hợp lệ";
                    break;
                case ErrorCode.TaxRateInfo_:
                    errorMessage = "Tên loại thuế suất trong Bảng tổng hợp thuế suất của hóa đơn có dữ liệu không hợp lệ";
                    break;
                case ErrorCode.InvalidTaxCode:
                    errorMessage = "Mã số thuế người bán không giống MST kết nối";
                    break;

                default:
                    errorMessage = pubResult[0].ErrorCode;
                    break;
            }
            return errorMessage;
        }
        #endregion: End Private Function
    }
}