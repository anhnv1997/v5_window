using iParkingv5.ApiManager.VETCParking;
using iParkingv5.Objects;
using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Datas.VETC;
using iParkingv5.Objects.Enums;
using iParkingv6.ApiManager.KzParkingv3Apis;
using iParkingv6.Objects.Datas;
using Kztek.Tool.TextFormatingTools;
using QRCoder;
using System.Transactions;
using static iParkingv5.Objects.Enums.VETCType;

namespace iParkingv5_window.Forms.DataForms
{
    public partial class frmConfirmOut : Form
    {
        //Thông tin sự kiện vào
        private string plateIn;
        private string detectedPlate;
        private string identityIdIn;
        private string laneId;
        private List<string> fileKeys;
        private string datetimeIn;
        private long charge = 0;
        public string updatePlate;
        public CheckOutData DataCheck;


        #region Forms
        public frmConfirmOut(string detectedPlate, string errorMessage, string plateIn, string identityIdIn,
                            string laneId, List<string> fileKeys, DateTime? datetimeIn, bool isDisplayQuestion = true, long charge = 0)
        {
            InitializeComponent();
            this.Text = "Xác nhận xe ra khỏi bãi";
            if (isDisplayQuestion)
            {
                lblMessage.Text = errorMessage + "\r\nBạn có xác nhận cho xe ra khỏi bãi?";
            }
            else
            {
                lblMessage.Text = errorMessage;
            }
            lblMessage.Size = lblMessage.PreferredSize;

            this.detectedPlate = detectedPlate;
            this.plateIn = plateIn;
            this.identityIdIn = identityIdIn;
            this.laneId = laneId;
            this.fileKeys = fileKeys;
            this.datetimeIn = datetimeIn?.ToString() ?? "";
            this.charge = charge;
            btnOk.Focus();
            //this.Size = new Size(lblMessage.Width, lblMessage.Height + panelAction.Height + 100);
            this.Load += FrmConfirm_Load;
        }

        private void FrmConfirm_Load(object? sender, EventArgs e)
        {
            btnCancel1.InitControl(BtnCancel1_Click);
            btnOk.InitControl(BtnOk_Click);

            lblMessage.Padding = new Padding(StaticPool.baseSize);
            lblMessage.Height = lblMessage.PreferredSize.Height;

            panelAction.Height = btnCancel1.Height + StaticPool.baseSize * 3;
            btnCancel1.Location = new Point(panelAction.Width - btnCancel1.Width - StaticPool.baseSize * 2,
                                            StaticPool.baseSize);
            btnOk.Location = new Point(btnCancel1.Location.X - btnOk.Width - StaticPool.baseSize,
                                       StaticPool.baseSize);

            this.Visible = false;

            ShowInfo(this.detectedPlate, this.laneId, this.datetimeIn, this.plateIn, this.identityIdIn);
            this.ActiveControl = btnOk;

            pnlQR.Size = new Size(10, pnlQR.Height);
        }

        private void BtnOk_Click(object? sender, EventArgs e)
        {
            updatePlate = dgvEventInData.Rows[3].Cells[1].Value.ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void BtnCancel1_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion End Forms
        public static Image defaultImg = Image.FromFile(frmMain.defaultImagePath);
        private string v1;
        private string v2;
        private string v3;
        private string v4;
        private List<string>? eventInFileKeys;
        private DateTime dateTime;
        private bool v5;
        private long v6;

        public async void ShowInfo(string detectedPlate, string laneIdIn, string datetimeIn, string plateIn, string identityIdIn)
        {
            try
            {
                this.SuspendLayout();

                Lane? laneIn = await KzParkingApiHelper.GetLaneByIdAsync(laneIdIn);
                Identity? identityIn = await KzParkingApiHelper.GetIdentityById(identityIdIn);
                IdentityGroup? identityGroupIn = null;
                VehicleType? vehicleTypeIn = null;
                if (identityIn != null)
                {
                    identityGroupIn = await KzParkingApiHelper.GetIdentityGroupByIdAsync(identityIn.IdentityGroupId.ToString());
                    if (identityGroupIn != null)
                    {
                        vehicleTypeIn = await KzParkingApiHelper.GetVehicleTypeById(identityGroupIn.VehicleTypeId.ToString());
                    }
                }

                dgvEventInData?.Invoke(new Action(() =>
                {
                    dgvEventInData.Rows.Clear();
                    dgvEventInData.Rows.Add("Thời gian vào", datetimeIn);
                    dgvEventInData.Rows.Add("Thời gian ra", DateTime.Now.ToString());
                    dgvEventInData.Rows.Add("Mã định danh", identityIn?.Code);
                    dgvEventInData.Rows.Add("Biển số vào", plateIn);
                    dgvEventInData.Rows.Add("Biển số Ra", detectedPlate);
                    if (identityGroupIn != null)
                    {
                        dgvEventInData.Rows.Add("Nhóm", identityGroupIn.Name);
                        dgvEventInData.Rows[dgvEventInData.RowCount - 1].DefaultCellStyle.Font = new Font(dgvEventInData.DefaultCellStyle.Font.Name, dgvEventInData.DefaultCellStyle.Font.Size * 2);
                        dgvEventInData.Rows[dgvEventInData.RowCount - 1].DefaultCellStyle.ForeColor = Color.Red;
                    }
                    if (vehicleTypeIn != null)
                    {
                        dgvEventInData.Rows.Add("Loại phương tiện", VehicleType.GetDisplayStr(vehicleTypeIn.Type));
                    }

                    //if (this.charge > 0)
                    {
                        dgvEventInData.Rows.Add("Phí gửi xe", TextFormatingTool.GetMoneyFormat(this.charge.ToString()));
                    }
                    dgvEventInData.Rows[dgvEventInData.RowCount - 1].DefaultCellStyle.Font = new Font(dgvEventInData.DefaultCellStyle.Font.Name, dgvEventInData.DefaultCellStyle.Font.Size * 2);
                    dgvEventInData.Rows[dgvEventInData.RowCount - 1].DefaultCellStyle.ForeColor = Color.Red;

                }));
                if (this.fileKeys?.Count >= 2)
                {
                    string displayOverviewInPath = await MinioHelper.GetImage(this.fileKeys[0]);
                    string vehicleInPath = await MinioHelper.GetImage(this.fileKeys[1]);
                    Task task1 = ShowImage(this.fileKeys[0], picOverview);
                    Task task2 = ShowImage(this.fileKeys[1], picVehicle);
                    await Task.WhenAll(task1, task2);
                }
                else if (this.fileKeys?.Count > 0)
                {
                    await ShowImage(this.fileKeys[0], picOverview);
                    this.Invoke(() =>
                    {
                        picOverview.Image = defaultImg;
                    });
                }
                else
                {
                    this.Invoke(() =>
                    {
                        picOverview.Image = defaultImg;
                        picVehicle.Image = defaultImg;
                    });
                }

                this.BringToFront();
                this.ResumeLayout();
            }
            catch (Exception)
            {
            }
        }
        private async Task ShowImage(string fileKey, PictureBox pic)
        {
            if (!string.IsNullOrEmpty(fileKey))
            {
                string displayPath = await MinioHelper.GetImage(fileKey);
                if (!string.IsNullOrEmpty(displayPath))
                {
                    pic.LoadAsync(displayPath);
                    return;
                }
            }
            pic.Image = defaultImg;
        }

        private async void btnVETC_Click(object sender, EventArgs e)
        {
            pnlQR.Size = new Size(pnlQR.Height, pnlQR.Height);

            picQR.Image = Properties.Resources.Loading;

            //Fix SendAPI_CheckOut_VETC
            CheckOutModel model = new CheckOutModel();
            model.transId = Guid.NewGuid().ToString();
            model.checkoutLaneId = "1";
            model.etag = "3416214B881B000006801436";
            model.plate = plateIn;
            model.laneCardId = "";
            model.totalAmount = (int)charge;
            model.description = "Gửi xe 12h-18h 50k, gửi xe 18h-23h 50k";
            model.checkinTime = ConvertToUnixTimestamp(DateTime.Parse(this.datetimeIn));
            byte[] imageBytes = File.ReadAllBytes(frmMain.defaultImagePath);
            model.base64Image = Convert.ToBase64String(imageBytes);

            //model.base64Image = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAMgAAADIAQAAAACFI5MzAAACm0lEQVR4XrWXUYojMQwFDb6WQVcX+FoGb5U6G5iw87MoIcy0VQ1uPT3JnXF/" +
            //    "+4zPwPszcox5D9+4Z6w1VpzYBpvJvnfnzHkmbJ8RLgx2E/4Ty3nvWcHWPMI0+AWSa/gEiy955oovkWua4DGIRYa5txPEY1m6XjZnte9b6z6iGfbn5+2dT/D/RHOjZYb77ls3Po7vJTkmq1HmwPubu0h4rWgmbF" +
            //    "tm141BmO2tYjsxTZNld9L0DhuZO7qJdkgy3T4ENVumiiW7Saooue6npzSm985mwuoUQEUbi2SFJ7pJaHFkTbuKUaHhobud5PIBtv7gqvx+VLSX7DIiez6+L8cj6e4mZjfdPpzmxyPqyKObpHXjZIq/rmfSCp" +
            //    "uJ21IzUlXQcnyxbnId4c+woHpPEcv2zQSLa7+neGE7s1TgdkL/6nHeGoZaLju6NOglOo/C2b54BMcbyXbC6uVDT0KUxffTpm4m6cYl4fXCoh3PpppIjWSXfpfKKWg1FpKSfTOxXYeCGt7leNxoB/cSymbN" +
            //    "bGI8SI+ZpW+rzYRqoSWa8hT6Q+s72aOZVLVqSFCz+9RPrnc6CUktPGh02GJe15BtJmSFfKeys8kcsaT9OksaiUVbWIKq2bwkrrRq3UoAPgPb1t4YpBJW61biEsvXfN0/HN9MKv70FiHzHo+ivaTcHlpPIf2L" +
            //    "shwb1cGNhKwGM7WOc8I4fjvYw4nUSkb9UlXH6fDjQCdAys0ka945LEbFEVRtM5oJ74uvdjqmyvbmnTq+leRj8OOw8NXkeAsXddY3kjry4lHUnJV06v5uorsd56WolkwVdSK1E/VMt30cX4v7BcL0W8pKvjUwyL" +
            //    "mfoKiRqt61jRkb287qJTqEGaTjA2EtHAlff1G2Eh3/z8/v5A+jQasPKWdzUQAAAABJRU5ErkJggg==";
            model.additionalBase64Image = "";
            model.forceQR = false;

            var vetcData = await VETCParkingApihelper.CheckOut(model);
            if (vetcData.data != null)
            {
                if (model.transId != vetcData.data.transId)
                {
                    // warning
                    return;
                }
                if (vetcData.message.ToUpper() != "SUCCESS")
                {

                }

                if (vetcData.data.status == Em_PaymentStatus.SUCCESS.ToString())
                {
                    if (vetcData.data.amount <= 0)
                    {
                        // Mở Barrier
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (vetcData.data.status == Em_PaymentStatus.PENDING.ToString())
                {
                    DataCheck = vetcData.data;

                    dgvEventInData.Rows.Add("Phí đã thanh toán VETC", DataCheck.paidAmount);
                    dgvEventInData.Rows.Add("Phí còn thiếu", DataCheck.amount);


                    if (DataCheck.qrData != null && DataCheck.qrData != "")
                    {
                        Bitmap qrCodeImage = GenerateQRCode(DataCheck.qrData);

                        picQR.Image = qrCodeImage;
                    }
                    CheckTransaction();
                }

            }
        }

        private async void CheckTransaction()
        {
            int i = 0;
            while (true)
            {
                i++;
                var paymentCheck = await VETCParkingApihelper.CheckPaymentStatus(DataCheck.transactionId);

                if (paymentCheck.message.ToUpper() == "SUCCESS")
                {
                    if (paymentCheck.data.status == Em_PaymentStatus.SUCCESS.ToString())
                    {
                        label1.Text = paymentCheck.data.status;
                        this.DialogResult = DialogResult.OK;
                        return;
                    }
                    else
                    {
                        label1.Text = paymentCheck.data.status + " lần: " + i;
                        await Task.Delay(1000);

                    }
                }
                else
                {
                    await Task.Delay(300);
                }
            }
        }
        static Bitmap GenerateQRCode(string data)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            return qrCodeImage;
        }

        private void frmConfirmOut_Load(object sender, EventArgs e)
        {

        }
        public static long ConvertToUnixTimestamp(DateTime dateTime)
        {
            dateTime = dateTime.ToUniversalTime();

            var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var ticks = dateTime.Ticks - unixEpoch.Ticks;

            return ticks / TimeSpan.TicksPerSecond;
        }
    }
}
