using DocumentFormat.OpenXml.Spreadsheet;
using iParkingv5.LprDetecter.LprDetecters;
using iParkingv5.Objects;
using iParkingv5.Objects.Datas.Device_service;
using iParkingv5.Objects.Enums;
using iParkingv5_window.Usercontrols;
using Kztek.Cameras;
using Kztek.Tool.LogDatabases;
using Kztek.Tool.TextFormatingTools;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace iParkingv5_window.Forms
{
    public partial class frmDemo : Form
    {
        string baseUrl = "http://online-payment.demo.kztek.io.vn/";
        ucCameraView ucLpr;
        private string token = "";
        public frmDemo()
        {
            InitializeComponent();
            this.Load += FrmDemo_Load;
        }

        public class user
        {
            public string token { get; set; }
            public int expireAfter { get; set; }
        }
        private async void FrmDemo_Load(object? sender, EventArgs e)
        {
            AppData.LprDetect = LprFactory.CreateLprDetecter(AppData.lprConfig, null);
            AppData.LprDetect?.CreateLpr(AppData.lprConfig);

            Kztek.Cameras.Camera cam = new Kztek.Cameras.Camera();
            cam.ID = "id";
            cam.Name = "name";
            cam.VideoSource = "14.160.26.45";
            cam.HttpPort = 554;
            cam.Login = "admin";
            cam.Password = "admin";
            cam.Chanel = 1;
            cam.CameraType = CameraType.Hanse;
            cam.StreamType = StreamType.H264;
            cam.Resolution = "1280x720";
            ucLpr = new ucCameraView("");
            ucLpr.StartViewer(cam, CameraErrorFunc);
            ucLpr.Dock = DockStyle.Fill;
            panelCamera.Controls.Add(ucLpr);

            lbl1_title.Click += Lbl1_title_Click;
            lbl2Title.Click += Lbl2Title_Click;
            lbl3Title.Click += Lbl3Title_Click;
            lbl4Title.Click += Lbl4Title_Click;
            lbl5Title.Click += Lbl5Title_Click;
            lbl6Title.Click += Lbl6Title_Click;
            lbl7Title.Click += Lbl7Title_Click;
            lbl8Title.Click += Lbl8Title_Click;
            lbl9Title.Click += Lbl9Title_Click;

            string loginUrl = baseUrl + "login";
            var data = new
            {
                username = "client",
                password = "sURV+Aq}Df2j*4,Bt)yMvL",
            };
            var response = await ApiHelper.ApiHelpers.GeneralJsonAPI(loginUrl, data, new Dictionary<string, string>(), new Dictionary<string, string>(), 10000, RestSharp.Method.Post);

            user? user = Newtonsoft.Json.JsonConvert.DeserializeObject<user>(response.Content);
            if (user != null)
            {
                this.token = user.token;
            }
        }

        private void Lbl9Title_Click(object? sender, EventArgs e)
        {
            var vehicleImg = ucLpr.GetFullCurrentImage();
            System.Drawing.Image lprImage = null;
            string plate = AppData.LprDetect.GetPlateNumber(vehicleImg, true, null, out lprImage);
            lblDetectPlate.Text = plate;
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            lblFee.Text = TextFormatingTool.GetMoneyFormat("80000");
            picLpr.Image = lprImage;
            GetQR(80000);
        }

        private void Lbl8Title_Click(object? sender, EventArgs e)
        {
            var vehicleImg = ucLpr.GetFullCurrentImage();
            System.Drawing.Image lprImage = null;
            string plate = AppData.LprDetect.GetPlateNumber(vehicleImg, true, null, out lprImage);
            lblDetectPlate.Text = plate;
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            lblFee.Text = TextFormatingTool.GetMoneyFormat("50000");
            picLpr.Image = lprImage;
            GetQR(50000);

        }

        private void Lbl7Title_Click(object? sender, EventArgs e)
        {
            var vehicleImg = ucLpr.GetFullCurrentImage();
            System.Drawing.Image lprImage = null;
            string plate = AppData.LprDetect.GetPlateNumber(vehicleImg, true, null, out lprImage);
            lblDetectPlate.Text = plate;
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            lblFee.Text = TextFormatingTool.GetMoneyFormat("40000");
            picLpr.Image = lprImage;
            GetQR(40000);
        }

        private void Lbl6Title_Click(object? sender, EventArgs e)
        {
            var vehicleImg = ucLpr.GetFullCurrentImage();
            System.Drawing.Image lprImage = null;
            string plate = AppData.LprDetect.GetPlateNumber(vehicleImg, true, null, out lprImage);
            lblDetectPlate.Text = plate;
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            lblFee.Text = TextFormatingTool.GetMoneyFormat("30000");
            picLpr.Image = lprImage;
            GetQR(30000);
        }

        private void Lbl5Title_Click(object? sender, EventArgs e)
        {
            var vehicleImg = ucLpr.GetFullCurrentImage();
            System.Drawing.Image lprImage = null;
            string plate = AppData.LprDetect.GetPlateNumber(vehicleImg, true, null, out lprImage);
            lblDetectPlate.Text = plate;
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            lblFee.Text = TextFormatingTool.GetMoneyFormat("25000");
            picLpr.Image = lprImage;
            GetQR(25000);
        }

        private void Lbl4Title_Click(object? sender, EventArgs e)
        {
            var vehicleImg = ucLpr.GetFullCurrentImage();
            System.Drawing.Image lprImage = null;
            string plate = AppData.LprDetect.GetPlateNumber(vehicleImg, true, null, out lprImage);
            lblDetectPlate.Text = plate;
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            lblFee.Text = TextFormatingTool.GetMoneyFormat("10000");
            picLpr.Image = lprImage;
            GetQR(10000);
        }

        private void Lbl3Title_Click(object? sender, EventArgs e)
        {
            var vehicleImg = ucLpr.GetFullCurrentImage();
            System.Drawing.Image lprImage = null;
            string plate = AppData.LprDetect.GetPlateNumber(vehicleImg, true, null, out lprImage);
            lblDetectPlate.Text = plate;
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            lblFee.Text = TextFormatingTool.GetMoneyFormat("5000");
            picLpr.Image = lprImage;
            GetQR(5000);
        }

        private void Lbl2Title_Click(object? sender, EventArgs e)
        {
            var vehicleImg = ucLpr.GetFullCurrentImage();
            System.Drawing.Image lprImage = null;
            string plate = AppData.LprDetect.GetPlateNumber(vehicleImg, true, null, out lprImage);
            lblDetectPlate.Text = plate;
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            lblFee.Text = TextFormatingTool.GetMoneyFormat("2000");
            picLpr.Image = lprImage;
            GetQR(2000);
        }
        private void Lbl1_title_Click(object? sender, EventArgs e)
        {
            var vehicleImg = ucLpr.GetFullCurrentImage();
            System.Drawing.Image lprImage = null;
            string plate = AppData.LprDetect.GetPlateNumber(vehicleImg, true, null, out lprImage);
            lblDetectPlate.Text = plate;
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            lblFee.Text = TextFormatingTool.GetMoneyFormat("1000");
            picLpr.Image = lprImage;
            GetQR(1001);
        }

        public void CameraErrorFunc(object sender, string errorString)
        {
            tblDeviceLog.SaveLog("", "", "", "", errorString);
        }
        private async void GetQR(long price)
        {
            try
            {
                picQR.Image = null;
                PaymentInfo paymentInfo = new PaymentInfo()
                {
                    user = new PaymentUser(),
                    paymentObjectDetails = new List<Paymentobjectdetail>() { new Paymentobjectdetail() { price = price } },
                    amount = price,
                };
                var param = new Dictionary<string, string>();
                param.Add("provider", "66");
                param.Add("redirectUrl", "https://kztek.net");

                var headers = new Dictionary<string, string>();
                headers.Add("Authorization", "Bearer " + this.token);

                string url = baseUrl + "order/qr";
                var data = await ApiHelper.ApiHelpers.GeneralJsonAPI(url, paymentInfo, headers, param, 10000, RestSharp.Method.Post);
                QrResponse? qrResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<QrResponse>(data.Content);
                if (qrResponse != null)
                {
                    using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                    {
                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrResponse.relatedData.qrCode, QRCodeGenerator.ECCLevel.Q);
                        QRCoder.QRCode qrCode = new QRCoder.QRCode(qrCodeData);

                        Bitmap qrCodeImage = qrCode.GetGraphic(50);
                        picQR.Image = qrCodeImage.GetThumbnailImage(picQR.Width, picQR.Height, null, IntPtr.Zero);
                    }
                }
            }
            catch (Exception)
            {
            }
        }


        public class QrResponse
        {
            public bool isSuccess { get; set; }
            public QRDetail relatedData { get; set; }
            public int code { get; set; }
            public string message { get; set; }
        }

        public class QRDetail
        {
            public string orderId { get; set; }
            public string requestCode { get; set; }
            public int amount { get; set; }
            public string currency { get; set; }
            public string qrCode { get; set; }
            public string payUrl { get; set; }
        }

        public class PaymentInfo
        {
            public string id { get; set; } = Guid.NewGuid().ToString();
            public string OrderId { get; set; } = Guid.NewGuid().ToString();
            public string code { get; set; } = "3409555591 0832938450";
            public string paymentObjectName { get; set; } = "THANH TOÁN TRẠM THU PHÍ";
            public List<Paymentobjectdetail> paymentObjectDetails { get; set; }
            public string description { get; set; } = "THANH TOÁN TRẠM THU PHÍ";
            public string companyName { get; set; } = "KZTEK";
            public string companyCode { get; set; } = "KZTEK";
            public PaymentUser user { get; set; }
            public string categoryId { get; set; } = "";
            public decimal amount { get; set; } = 0;
            public object additionalData { get; set; } = null;
            public string bankCode { get; set; } = "";
        }

        public class PaymentUser
        {
            public string id { get; set; } = Guid.NewGuid().ToString();
            public string name { get; set; } = "DEMO";
            public string code { get; set; } = "DEMO";
            public string email { get; set; } = "DEMO";
            public string phonenumber { get; set; } = "DEMO";
        }

        public class Paymentobjectdetail
        {
            public string id { get; set; } = Guid.NewGuid().ToString();
            public string name { get; set; } = "THANH TOÁN TRẠM THU PHÍ";
            public string description { get; set; } = "THANH TOÁN TRẠM THU PHÍ";
            public string category { get; set; } = "THANH TOÁN TRẠM THU PHÍ";
            public decimal price { get; set; } = 0;
            public string currency { get; set; } = "VND";
            public int quantity { get; set; } = 1;
            public string unit { get; set; } = "XE";
            public int taxAmount { get; set; } = 0;
        }

    }
}
