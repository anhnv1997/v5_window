using iParkingv5.ApiManager.VETCParking;
using iParkingv5.Objects.Datas.VETC;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.WebSockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iParkingv5_window.Forms.VETCForm
{
    public partial class frmVETCtest : Form
    {
        private event EventHandler<string> ReceiverSocket;
        public string transactionId = "";
        public string QRCode = "";

        enum Em_PaymentStatus
        {
            PENDING,
            SUCCESS,
            FAIL,
            CANCEL,
            EXPIRE,
        }
        public frmVETCtest()
        {
            InitializeComponent();

            this.ReceiverSocket += Form1_ReceiverSocket;

            Task.Run(() => GetWebSocket());
        }
        private async Task GetWebSocket()
        {
            using (ClientWebSocket ws = new ClientWebSocket())
            {
                Uri serverUri = new Uri("ws://localhost:50050/etag-reader");

                try
                {
                    await ws.ConnectAsync(serverUri, CancellationToken.None);

                    while (true)
                    {
                        ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[4096]);
                        WebSocketReceiveResult result = await ws.ReceiveAsync(buffer, CancellationToken.None);

                        if (result.MessageType == WebSocketMessageType.Close)
                        {
                            await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
                            break;
                        }
                        else
                        {
                            string message = System.Text.Encoding.UTF8.GetString(buffer.Array, 0, result.Count);



                            ReceiverSocket?.Invoke(null, message);

                            string etag = message;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //
                }
            }
        }
        private void Form1_ReceiverSocket(object? sender, string message)
        {
            txbEtagSocket.Invoke(() =>
            {
                txbEtagSocket.Text += $"{DateTime.Now.ToString("HH:mm:ss")}: {message}{Environment.NewLine}";
            });
        }
        private async void btnCheckOut_Click(object sender, EventArgs e)
        {
            CheckOutModel model = new CheckOutModel();
            model.transId = "20240305123000139";
            model.checkoutLaneId = "6";
            model.etag = "";
            model.plate = "30A12345";
            model.laneCardId = "";
            model.totalAmount = 10000;
            model.description = "Gửi xe 12h-18h 50k, gửi xe 18h-23h 50k";
            model.checkinTime = 1713857142000;
            model.base64Image = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAMgAAADIAQAAAACFI5MzAAACm0lEQVR4XrWXUYojMQwFDb6WQVcX+FoGb5U6G5iw87MoIcy0VQ1uPT3JnXF/" +
                "+4zPwPszcox5D9+4Z6w1VpzYBpvJvnfnzHkmbJ8RLgx2E/4Ty3nvWcHWPMI0+AWSa/gEiy955oovkWua4DGIRYa5txPEY1m6XjZnte9b6z6iGfbn5+2dT/D/RHOjZYb77ls3Po7vJTkmq1HmwPubu0h4rWgmbF" +
                "tm141BmO2tYjsxTZNld9L0DhuZO7qJdkgy3T4ENVumiiW7Saooue6npzSm985mwuoUQEUbi2SFJ7pJaHFkTbuKUaHhobud5PIBtv7gqvx+VLSX7DIiez6+L8cj6e4mZjfdPpzmxyPqyKObpHXjZIq/rmfSCp" +
                "uJ21IzUlXQcnyxbnId4c+woHpPEcv2zQSLa7+neGE7s1TgdkL/6nHeGoZaLju6NOglOo/C2b54BMcbyXbC6uVDT0KUxffTpm4m6cYl4fXCoh3PpppIjWSXfpfKKWg1FpKSfTOxXYeCGt7leNxoB/cSymbN" +
                "bGI8SI+ZpW+rzYRqoSWa8hT6Q+s72aOZVLVqSFCz+9RPrnc6CUktPGh02GJe15BtJmSFfKeys8kcsaT9OksaiUVbWIKq2bwkrrRq3UoAPgPb1t4YpBJW61biEsvXfN0/HN9MKv70FiHzHo+ivaTcHlpPIf2L" +
                "shwb1cGNhKwGM7WOc8I4fjvYw4nUSkb9UlXH6fDjQCdAys0ka945LEbFEVRtM5oJ74uvdjqmyvbmnTq+leRj8OOw8NXkeAsXddY3kjry4lHUnJV06v5uorsd56WolkwVdSK1E/VMt30cX4v7BcL0W8pKvjUwyL" +
                "mfoKiRqt61jRkb287qJTqEGaTjA2EtHAlff1G2Eh3/z8/v5A+jQasPKWdzUQAAAABJRU5ErkJggg==";
            model.additionalBase64Image = "";
            model.forceQR = false;

            var data = await VETCParkingApihelper.CheckOut(model);

            string abc = data.data.amount.ToString();
            transactionId = data.data.transactionId;
            QRCode = data.data.qrData;
            Bitmap qrCodeImage = GenerateQRCode(QRCode);

            picQR.Image = qrCodeImage;
        }

        private async void btnCheckConnect_Click(object sender, EventArgs e)
        {
            var health = await VETCParkingApihelper.Healthcheck();

            if (health != null)
            {
                label1.Text = health.data.version;

                if (health.data.etagDevices[0].connected == true)
                {
                    btnCheckConnect.BackColor = Color.Green;
                }
                else
                {
                    btnCheckConnect.BackColor = Color.Red;
                }
            }
        }

        private async void btnFakeEtag_Click(object sender, EventArgs e)
        {
            if (txbEtag.Text != "")
            {
                bool isTy = await VETCParkingApihelper.FakeEtag(txbEtag.Text);

                btnFakeEtag.BackColor = isTy ? Color.Green : Color.Red;
            }
        }

        private async void btnGetAllEtag_Click(object sender, EventArgs e)
        {
            var EtagArea = await VETCParkingApihelper.GetAllEtagArea();
        }

        private void btnConfigPayment_Click(object sender, EventArgs e)
        {

        }

        private void btnTriggerPayment_Click(object sender, EventArgs e)
        {
            string plate = "51813070";
            plate = StandardPlate(plate);
        }
        private string StandardPlate(string plate)
        {
            if (plate.Length > 3 && plate[2].ToString() == "-")
            {
                plate = plate.Remove(2, 1);
            }
            if (plate.Length > 2)
            {
                if (plate.Substring(0, 2) == "BB")
                {
                    plate = "88" + plate.Substring(2);
                }
                else if (plate[1] == 'B')
                {
                    plate = plate[0] + "8" + plate.Substring(2);
                }
                else if (plate[1] == 'D')
                {
                    plate = plate[0] + "0" + plate.Substring(2);
                }
            }
            plate = plate.Replace('Q', '0');
            plate = plate.Replace('O', '0');
            plate = plate.Replace('Z', '2');
            if (plate.Length > 3)
            {
                if (plate[2] == '8')
                {
                    plate = plate.Substring(0, 2) + "B" + plate.Substring(3);
                }
                for (int i = 3; i < plate.Length - 1; i++)
                {
                    if (plate[i] == 'D' && i > 3)
                    {
                        plate = plate.Substring(0, i) + "0" + plate.Substring(i + 1);
                    }
                    else if (plate[i] == 'B')
                    {
                        plate = plate.Substring(0, i) + "8" + plate.Substring(i + 1);
                    }
                }
            }
            plate = StandardlizePlateNumber(plate);
            return plate;
        }
        public string StandardlizePlateNumber(string plateNumber)
        {
            string output = string.Empty;
            Regex regex = new Regex("[a-zA-Z0-9;]");
            for (int i = 0; i < plateNumber.Length; i++)
            {
                string plateNumberItem = plateNumber[i].ToString();
                if (regex.IsMatch(plateNumberItem))
                {
                    output += plateNumberItem;
                }
            }
            return output;
        }
        private async void btnCheckTransaction_Click(object sender, EventArgs e)
        {
            var paymentCheck = await VETCParkingApihelper.CheckPaymentStatus(transactionId);

            if (paymentCheck.message.ToUpper() == "SUCCESS")
            {
                if (paymentCheck.data.status == Em_PaymentStatus.SUCCESS.ToString())
                {

                }
                MessageBox.Show($"{paymentCheck.data.status}");
            }
        }

        private void btnGenQR_Click(object sender, EventArgs e)
        {
            string qrData = txbQR.Text;

            Bitmap qrCodeImage = GenerateQRCode(qrData);

            picQR.Image = qrCodeImage;
        }
        static Bitmap GenerateQRCode(string data)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            return qrCodeImage;
        }
        
    }
}
