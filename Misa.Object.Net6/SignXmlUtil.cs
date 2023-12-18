using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;

namespace Misa.Object
{
    /// <summary>
    /// Lớp ký hóa đơn
    /// </summary>
    public class SignXmlUtil
    {
        private const string mscDateTimeFormatString = "yyyy-MM-ddTHH:mm:ss";
        private const string SignServerPortTool = "12019;12020;12021;12022;12023";
        private const string SignServerPortDS = "52024;52025;52026;52027;52028";

        public static X509Certificate2 GetCertificateFromStore()
        {
            X509Store oStore = new X509Store(StoreLocation.CurrentUser);
            oStore.Open(OpenFlags.OpenExistingOnly);
            X509Certificate2Collection oFilterCertificateCollection = new X509Certificate2Collection();

            //Add thêm các chứng thư khác k chứa MST
            foreach (X509Certificate2 oFilterCert in oStore.Certificates)
            {

                if (!string.IsNullOrWhiteSpace(oFilterCert.Subject) && oFilterCert.Subject.Contains("MST:") && !oFilterCertificateCollection.Contains(oFilterCert))
                {
                    oFilterCertificateCollection.Add(oFilterCert);
                }
            }

            X509Store oStoreLocalMachine = new X509Store(StoreLocation.LocalMachine);
            oStoreLocalMachine.Open(OpenFlags.OpenExistingOnly);

            foreach (X509Certificate2 oFilterCert in oStoreLocalMachine.Certificates)
            {
                //Nếu đã add chứng thư số này ở CurrentUser thì không add nữa
                if (!string.IsNullOrWhiteSpace(oFilterCert.Subject) && oFilterCert.Subject.Contains("MST:") && !oFilterCertificateCollection.Contains(oFilterCert))
                {
                    oFilterCertificateCollection.Add(oFilterCert);
                }
            }
            X509Certificate2Collection oSelectedCert = null;

            //oSelectedCert = X509Certificate2UI.SelectFromCollection(oFilterCertificateCollection, "MeInvoice.vn", "Chọn chứng thư số", X509SelectionFlag.SingleSelection);

            if (oSelectedCert.Count > 0)
            {
                return oSelectedCert[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Ký XML trực tiếp
        /// </summary>
        /// <param name="xmlDoc">File xml cần ký: Sau khi ký sẽ thêm chữ ký số vào nội dung file luôn</param>
        /// <param name="cert">Chữ ký số được chọn</param>
        /// <param name="uri">Mã tra cứu</param>
        public static void SignXml(XmlDocument xmlDoc, X509Certificate2 cert)
        {
            string uri = xmlDoc.GetElementsByTagName("DLHDon")[0].Attributes["Id"].Value;
            if (string.IsNullOrEmpty(uri))
            {
                throw new ArgumentException("InvlidTransactionID");
            }
            if (xmlDoc == null)
            {
                throw new ArgumentException("xmlDoc");
            }
            if (cert == null)
            {
                throw new ArgumentException("cert");
            }
            MisaSignedXml signedXml = new MisaSignedXml(xmlDoc);
            signedXml.Signature.Id = "seller";  //Thiết lập id cho chữ ký của người bán
            //Add the key to the SignedXml document.
            if (cert.HasPrivateKey)
            {
                signedXml.SigningKey = cert.PrivateKey;
            }
            signedXml.KeyInfo = GetCertificateKeyInfo(cert);
            //Create a reference to be signed.
            Reference reference = new Reference
            {
                Uri = string.Format("#{0}", uri)
            };
            //Add an enveloped transformation to the reference.
            XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
            reference.AddTransform(env);

            //Add the reference to the SignedXml object.
            signedXml.AddReference(reference);

            //Add thêm signingTime
            DataObject signingTimeObject = CreateSigningTimeObject();
            signedXml.AddObject(signingTimeObject);
            //add reference cho SigingTime
            Reference signingReference = new Reference
            {
                Uri = "#SigningTime"
            };
            //end of thêm signingTime

            signedXml.AddReference(signingReference);
            signedXml.ComputeSignature();

            XmlElement xmlDigitalSignature = signedXml.GetXml();
            //Append the element to the XML document.
            XmlNode signedNode = xmlDoc.SelectSingleNode("CKSNNT");

            if (signedNode == null)
            {
                signedNode = xmlDoc.SelectSingleNode("//DSCKS/NNT");
            }
            if (signedNode == null)
            {
                signedNode = xmlDoc.SelectSingleNode("//DSCKS/NBan");
            }
            if (signedNode == null)
            {
                throw new Exception("Không tìm thấy node chứa chữ ký số người bán.");
            }
            signedNode.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, true));
        }

        /// <summary>
        /// Thực hiện ký điện tử tệp XML qua MISA Signed Service
        /// </summary>
        /// <param name="serverName">Máy chủ thực hiện ký</param>
        /// <param name="pinCode">Mã pin chữ ký</param>
        /// <param name="xmlDoc">file xml cần ký</param>
        /// <param name="port">Cổng service ký</param>
        /// <returns>Đối tượng <see cref="SignXMLResult"/> chứa kết quả thực hiện ký trên server</returns>
        public static SignXMLResult SignXMLByTool(string serverName, string pinCode, XmlDocument xmlDoc, string port = "")
        {
            SignXMLResult oResult = new SignXMLResult() { Data = string.Empty, Error = string.Empty };
            //Kiểm tra tham số trước
            if (string.IsNullOrEmpty(serverName))
            {
                throw new ArgumentNullException("serverName");
            }
            if (string.IsNullOrEmpty(pinCode))
            {
                throw new ArgumentNullException("pinCode");
            }
            if (xmlDoc == null || string.IsNullOrEmpty(xmlDoc.InnerXml))
            {
                throw new ArgumentNullException("xmlDoc");
            }
            if (!string.IsNullOrEmpty(port))
            {
                SignServiceResult oSignResult = SignByService(string.Format("http://{0}:{1}", serverName, port), pinCode, xmlDoc.InnerXml);
                if (oSignResult != null)
                {
                    if (oSignResult.Message != null && !string.IsNullOrEmpty(oSignResult.Message))
                    {
                        oResult.Error = oSignResult.Message;
                    }
                    else if (oSignResult.Status == 200 && !string.IsNullOrEmpty(oSignResult.Payload))
                    {
                        oResult.Data = oSignResult.Payload;
                    }
                }
            }
            else
            {
                foreach (string sPort in SignServerPortTool.Split(';'))
                {
                    try
                    {
                        SignServiceResult oSignResult = SignByService(string.Format("http://{0}:{1}", serverName, sPort), pinCode, xmlDoc.InnerXml);
                        if (oSignResult != null)
                        {
                            if (oSignResult.Message != null && !string.IsNullOrEmpty(oSignResult.Message))
                            {
                                oResult.Error = oSignResult.Message;
                            }
                            else if (oSignResult.Status == 200 && !string.IsNullOrEmpty(oSignResult.Payload))
                            {
                                oResult.Data = oSignResult.Payload;
                                break;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // nếu catch vào đoạn này thì không xử lý . đều quy về lỗi không tìm thấy máy chủ ký
                    }
                }
            }
            //Nếu không có kết quả trả về văng chung 1 lỗi không kết nối được máy chủ
            if (string.IsNullOrEmpty(oResult.Data))
            {
                oResult.Error = ErrorCode.CannotConnectSignServer;
            }
            return oResult;
        }

        /// <summary>
        /// Thực hiện ký điện tử tệp XML qua MISA meInvoice Server Manager
        /// </summary>
        /// <param name="serverName">Máy chủ thực hiện ký</param>
        /// <param name="pinCode">Mã pin chữ ký</param>
        /// <param name="xmlDoc">file xml cần ký</param>
        /// <param name="port">Cổng service ký</param>
        /// <returns></returns>
        public static SignXMLResult SignXMLByDS(string serverName, string pinCode, XmlDocument xmlDoc, string port = "")
        {
            SignXMLResult oResult = new SignXMLResult() { Data = string.Empty, Error = string.Empty };
            //Kiểm tra tham số trước
            if (string.IsNullOrEmpty(serverName))
            {
                throw new ArgumentNullException("serverName");
            }
            if (string.IsNullOrEmpty(pinCode))
            {
                throw new ArgumentNullException("pinCode");
            }
            if (xmlDoc == null || string.IsNullOrEmpty(xmlDoc.InnerXml))
            {
                throw new ArgumentNullException("xmlDoc");
            }
            if (!string.IsNullOrEmpty(port))
            {
                DSServiceResult oSignResult = SignByServiceDS(string.Format("http://{0}:{1}", serverName, port), pinCode, xmlDoc.InnerXml);
                if (oSignResult != null)
                {
                    if (oSignResult.Message != null && !string.IsNullOrEmpty(oSignResult.Message))
                    {
                        oResult.Error = oSignResult.Message;
                    }
                    else if (oSignResult.Success && !string.IsNullOrEmpty(oSignResult.Data.ToString()))
                    {
                        oResult.Data = oSignResult.Data.ToString();
                    }
                }
            }
            else
            {
                foreach (string sPort in SignServerPortDS.Split(';'))
                {
                    try
                    {
                        DSServiceResult oSignResult = SignByServiceDS(string.Format("http://{0}:{1}", serverName, sPort), pinCode, xmlDoc.InnerXml);
                        if (oSignResult != null)
                        {
                            if (oSignResult.Message != null && !string.IsNullOrEmpty(oSignResult.Message))
                            {
                                oResult.Error = oSignResult.Message;
                            }
                            else if (oSignResult.Success == true && !string.IsNullOrEmpty(oSignResult.Data.ToString()))
                            {
                                oResult.Data = oSignResult.Data.ToString();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // nếu catch vào đoạn này thì không xử lý . đều quy về lỗi không tìm thấy máy chủ ký
                    }
                }
            }
            //Nếu không có kết quả trả về văng chung 1 lỗi không kết nối được máy chủ
            if (string.IsNullOrEmpty(oResult.Data))
            {
                oResult.Error = ErrorCode.CannotConnectSignServer;
            }
            return oResult;
        }

        /// <summary>
        /// Hàm thực hiện ký số hóa đơn điện tử
        /// </summary>
        /// <param name="xmlDoc">Nội dung Xml cần ký</param>
        /// <param name="certFilePath">Đường dẫn file chữ ký số </param>
        /// <param name="pinCode">PIN Code chữ ký số</param>
        public static SignXMLResult SignXMLByFile(XmlDocument xmlDoc, string certFilePath, string pinCode)
        {
            SignXMLResult result = new SignXMLResult();
            X509Certificate2 oCert = null;
            try
            {
                oCert = new X509Certificate2(certFilePath, pinCode);
            }
            catch (Exception)
            {
                result.Error = ErrorCode.InvalidSignature;
            }
            if (string.IsNullOrEmpty(result.Error))
            {
                try
                {
                    SignXml(xmlDoc, oCert);
                    result.Data = xmlDoc.InnerXml;
                }
                catch (Exception ex)
                {
                    result.Error = ex.Message;
                }
            }
            return result;
        }

        /// <summary>
        /// Thực hiện ký điện tử tệp XML trên Server DS
        /// </summary>
        /// <param name="apiUrl">API service ký</param>
        /// <param name="pincode">mã pin chữ ký</param>
        /// <param name="xmlContent">Nội dung file xml cần ký</param>
        /// <returns>Đối tượng <see cref="SignServiceResult"/> chứa kết quả thực hiện ký trên server</returns>
        private static DSServiceResult SignByServiceDS(string apiUrl, string pincode, string xmlContent)
        {
            try
            {
                if (!apiUrl.EndsWith("/")) apiUrl += "/";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl + "api/Signed/XmlSigning");
                {
                    request.Method = "POST";
                    request.Timeout = 30000;
                    string sParam = SerializeUtil.SerializeObject(new SignedXMLParameter()
                    {
                        PinCode = pincode,
                        XmlContent = xmlContent
                    });
                    System.Text.UTF8Encoding encode = new System.Text.UTF8Encoding();
                    byte[] byteArray = encode.GetBytes(sParam);
                    request.ContentLength = byteArray.Length;
                    request.ContentType = "application/json; charset=utf-8";
                    using (Stream dataStream = request.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                    }
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Accepted)
                        {
                            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                            {
                                //Đọc kết quả
                                string resultString = sr.ReadToEnd();
                                if (!string.IsNullOrWhiteSpace(resultString))
                                {
                                    DSServiceResult result = SerializeUtil.DeserializeObject<DSServiceResult>(resultString);
                                    if (result != null)
                                    {
                                        return result;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }

        /// <summary>
        /// Thực hiện ký điện tử tệp XML trên Server
        /// </summary>
        /// <param name="apiUrl">API service ký</param>
        /// <param name="pincode">mã pin chữ ký</param>
        /// <param name="xmlContent">Nội dung file xml cần ký</param>
        /// <returns>Đối tượng <see cref="SignServiceResult"/> chứa kết quả thực hiện ký trên server</returns>
        private static SignServiceResult SignByService(string apiUrl, string pincode, string xmlContent)
        {
            try
            {
                if (!apiUrl.EndsWith("/")) apiUrl += "/";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl + "api/SignXML");
                {
                    request.Method = "POST";
                    request.Timeout = 30000;
                    string sParam = SerializeUtil.SerializeObject(new SignedXMLParameter()
                    {
                        PinCode = pincode,
                        XmlContent = xmlContent
                    });
                    System.Text.UTF8Encoding encode = new System.Text.UTF8Encoding();
                    byte[] byteArray = encode.GetBytes(sParam);
                    request.ContentLength = byteArray.Length;
                    request.ContentType = "application/json; charset=utf-8";
                    //
                    using (Stream dataStream = request.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                    }
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                            {
                                //Đọc kết quả
                                string resultString = sr.ReadToEnd();
                                if (!string.IsNullOrWhiteSpace(resultString))
                                {
                                    SignServiceResult result = SerializeUtil.DeserializeObject<SignServiceResult>(resultString);
                                    if (result != null)
                                    {
                                        return result;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }

        /// <summary>
        /// Hàm lấy các thông tin của chữ ký.
        /// Các thông tin này sẽ hiển thị trong thẻ KeyInfo
        /// </summary>
        /// <param name="cert">X509Certificate2</param>
        /// <returns></returns>
        private static KeyInfo GetCertificateKeyInfo(X509Certificate2 cert)
        {
            KeyInfo certificateKeyInfo = new KeyInfo();
            KeyInfoX509Data x509Data = new KeyInfoX509Data();
            x509Data.AddCertificate(cert);
            x509Data.AddSubjectName(cert.Subject);
            certificateKeyInfo.AddClause(x509Data);
            return certificateKeyInfo;
        }

        /// <summary>
        /// Tạo ra đối tượng chứa thông tin ngày ký của hóa đơn
        /// </summary>
        /// <returns></returns>
        private static DataObject CreateSigningTimeObject()
        {
            //Add thêm signingTime
            XmlDocument document = new XmlDocument();
            var signaturePropertiesNode = document.CreateElement("SignatureProperties", SignedXml.XmlDsigNamespaceUrl);
            var signaturePropertyNode = document.CreateElement("SignatureProperty", SignedXml.XmlDsigNamespaceUrl);
            //signaturePropertyNode.SetAttribute("Id", "SigningTime");
            signaturePropertyNode.SetAttribute("Target", "#seller");

            var signingTimeNode = document.CreateElement("SigningTime", SignedXml.XmlDsigNamespaceUrl);
            signingTimeNode.InnerText = DateTime.Now.ToString(mscDateTimeFormatString);

            document.AppendChild(signaturePropertiesNode).AppendChild(signaturePropertyNode).AppendChild(signingTimeNode);

            DataObject signingTimeObject = new DataObject
            {
                Id = "SigningTime",
                Data = document.ChildNodes
            };
            return signingTimeObject;
        }
    }

    internal class DSServiceResult
    {
        #region "Property"

        /// <summary>
        /// Trạng thái: true/false thành công/thất bại
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Giá trị trả về: Nội dung lỗi, dữ liệu
        /// </summary>
        public object Data
        {
            get
            {
                string str = string.Empty;

                if (m_Data != null)
                {
                    if (m_Data.GetType() == typeof(string))
                    {
                        str = (string)m_Data;
                    }
                    else
                    {
                        str = SerializeUtil.SerializeObject(m_Data);
                    }
                }
                return str;
            }
            set { m_Data = value; }
        }

        /// <summary>
        /// Dữ liệu gốc
        /// Dùng cho tình huống cất thêm thì sẽ trả về thông tin bản ghi mới trong này để xử lý binding cho form (Giảm 1 request lên server để lấy dữ liệu mới)
        /// </summary>
        public object CustomData
        {
            get
            {
                string str = string.Empty;

                if (m_NewData != null)
                {
                    if (m_NewData.GetType() == typeof(string))
                    {
                        str = (string)m_NewData;
                    }
                    else
                    {
                        str = SerializeUtil.SerializeObject(m_NewData);
                    }
                }

                return str;
            }
            set { m_NewData = value; }
        }

        private object m_Data;
        private object m_NewData;

        /// <summary>
        /// Nội dung lỗi
        /// </summary>
        public List<string> Errors { get; set; }

        /// <summary>
        /// Mã lỗi
        /// </summary>
        public string ErrorCode { get; set; }

        #endregion "Property"

        #region "Sub/Func"

        public DSServiceResult()
        {
            this.Success = true;
            this.Errors = new List<string>();
            this.ErrorCode = "";
        }

        public string Message { get; set; }

        /// <summary>
        /// Trả về data chưa serialize
        /// </summary>
        /// <remarks>8.1.2016</remarks>
        public object GetData()
        {
            return m_Data;
        }

        #endregion "Sub/Func"
    }
}
