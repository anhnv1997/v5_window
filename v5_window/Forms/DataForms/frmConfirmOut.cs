using iParkingv5.Objects;
using iParkingv5.Objects.Datas.Device_service;
using iParkingv5.Objects.Datas.parking_service;
using iParkingv5.Objects.Enums;
using iParkingv5.Objects.EventDatas;
using Kztek.Tool.TextFormatingTools;
using static iParkingv5.Objects.Enums.ParkingImageType;
using static iParkingv5.Objects.Enums.VehicleType;
using IPaking.Ultility;
namespace iParkingv5_window.Forms.DataForms
{
    public partial class frmConfirmOut : Form
    {
        #region PROPERTIES
        private string plateIn;
        private string detectedPlate;
        private string identityNameIn;
        private string identityGroupName;
        private Dictionary<EmParkingImageType, List<ImageData>> imageDatas;
        private DateTime datetimeIn;
        private long charge = 0;
        public string updatePlate;

        public static Image defaultImg = Image.FromFile(StaticPool.oemConfig.LogoPath);

        private List<string>? eventInFileKeys;
        private DateTime dateTime;
        private int autoReturnTime = 0;
        VehicleBaseType vehicleType;
        #endregion End PROPERTIES

        #region Forms
        public frmConfirmOut(string detectedPlate, string errorMessage, string plateIn, string identityNameIn, string identityGroupName, VehicleBaseType vehicleType,
                            Dictionary<EmParkingImageType, List<ImageData>> fileKeys, DateTime datetimeIn, bool isDisplayQuestion = true, long charge = 0)
        {
            InitializeComponent();
            this.Text = "Xác nhận xe ra khỏi bãi";
            if (errorMessage == "Bạn có xác nhận mở barrie?")
            {
                txtPlateOut.TabIndex = 3;
                txtPlateOut.Enabled = false;
            }
            if (isDisplayQuestion)
            {
                lblMessage.Text = errorMessage + "\r\nBạn có xác nhận cho xe ra khỏi bãi?";
            }
            else
            {
                lblMessage.Text = errorMessage;
            }
            lblMessage.Size = lblMessage.PreferredSize;

            lblMessage.Padding = new Padding(StaticPool.baseSize);
            lblMessage.Height = lblMessage.PreferredSize.Height;

            this.detectedPlate = detectedPlate;
            this.plateIn = plateIn;
            this.identityNameIn = identityNameIn;
            this.identityGroupName = identityGroupName;
            this.imageDatas = fileKeys;
            this.datetimeIn = datetimeIn;
            this.charge = charge;
            this.updatePlate = detectedPlate;
            this.vehicleType = vehicleType;
            this.FormClosing += FrmConfirmOut_FormClosing;
            this.Load += FrmConfirm_Load;
        }
        private void FrmConfirm_Load(object? sender, EventArgs e)
        {
            btnCancel1.InitControl(BtnCancel1_Click);
            btnOk.InitControl(BtnOk_Click);

            panelAction.Height = btnCancel1.Height + StaticPool.baseSize * 3;
            btnCancel1.Location = new Point(panelAction.Width - btnCancel1.Width - StaticPool.baseSize * 2,
                                            StaticPool.baseSize);
            btnOk.Location = new Point(btnCancel1.Location.X - btnOk.Width - StaticPool.baseSize,
                                       StaticPool.baseSize);
            if (StaticPool.appOption.AutoRejectDialogTime > 0)
            {
                lblTimer.Visible = true;
                lblTimer.BringToFront();
                lblTimer.Text = "";
                timerAutoConfirm.Enabled = true;
            }
            ShowInfo(this.detectedPlate, this.datetimeIn, this.plateIn, this.identityNameIn, vehicleType);
        }
        private void frmConfirmOut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                BtnOk_Click(null, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                BtnCancel1_Click(null, EventArgs.Empty);
            }
        }
        private void FrmConfirmOut_FormClosing(object? sender, FormClosingEventArgs e)
        {
            StopTimer();
        }
        #endregion End Forms

        #region CONTROLS IN FORM
        private void btnCopy_Click(object sender, EventArgs e)
        {
            txtPlateOut.Text = lblPlateIn.Text;
            this.ActiveControl = txtPlateOut;
            txtPlateOut.SelectionStart = txtPlateOut.Text.Length;
            txtPlateOut.SelectionLength = 0;
        }
        private void BtnOk_Click(object? sender, EventArgs e)
        {
            updatePlate = txtPlateOut.Text;
            this.DialogResult = DialogResult.OK;
        }
        private void BtnCancel1_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion End CONTROLS IN FORM

        #region TIMER
        private void timerAutoConfirm_Tick(object? sender, EventArgs e)
        {
            if (autoReturnTime < StaticPool.appOption.AutoRejectDialogTime)
            {
                string message = StaticPool.appOption.AutoRejectDialogResult ? "Xác nhận" : "Đóng";
                int remainingTime = StaticPool.appOption.AutoRejectDialogTime - autoReturnTime;
                lblTimer.Text = $"Tự động {message} sau {remainingTime}s!";
                autoReturnTime++;
            }
            else
            {
                StopTimer();
                if (StaticPool.appOption.AutoRejectDialogResult)
                {
                    BtnOk_Click(null, EventArgs.Empty);
                }
                else
                {
                    BtnCancel1_Click(null, EventArgs.Empty);
                }
            }
        }
        private void StopTimer()
        {
            autoReturnTime = 0;
            timerAutoConfirm.Tick -= timerAutoConfirm_Tick;
            timerAutoConfirm.Enabled = false;
        }
        #endregion End TIMER

        #region PRIVATE FUNCTION
        private async Task ShowImage(ImageData? imageData, PictureBox pic)
        {
            try
            {
                if (imageData == null)
                {
                    pic.Image = defaultImg;
                }
                else
                {
                    string imageUrl = await AppData.ApiServer.parkingProcessService.GetImageUrl(imageData.bucket, imageData.objectKey);
                    pic.LoadAsync(imageUrl);
                }
            }
            catch (Exception)
            {
                pic.Image = defaultImg;
            }
        }
        #endregion End PRIVATE FUNCTION

        #region PUBLIC FUNCTION
        public async void ShowInfo(string detectedPlate, DateTime datetimeIn, string plateIn, string identityInName, VehicleBaseType vehicleType)
        {
            try
            {
                this.SuspendLayout();
                this.updatePlate = detectedPlate;

                this.Invoke(new Action(() =>
                {
                    lblTimeIn.Text = datetimeIn.ToVNTime();
                    lblTimeOut.Text = DateTime.Now.ToVNTime();
                    lblIdentityCode.Text = identityNameIn;
                    txtPlateOut.Text = detectedPlate;
                    lblPlateIn.Text = plateIn;
                    lblIdentityGroup.Text = identityGroupName;
                    lblVehicleType.Text = VehicleType.GetDisplayStr(vehicleType);
                }));


                List<Task> tasks = new List<Task>();
                foreach (KeyValuePair<EmParkingImageType, List<ImageData>> item in this.imageDatas)
                {
                    if (item.Key == EmParkingImageType.Overview)
                    {
                        tasks.Add(ShowImage(this.imageDatas[item.Key][0], picOverview));
                    }
                    else if (item.Key == EmParkingImageType.Vehicle)
                    {
                        tasks.Add(ShowImage(this.imageDatas[item.Key][0], picVehicle));
                    }
                }
                await Task.WhenAll(tasks);
                this.BringToFront();
                this.ResumeLayout();
            }
            catch (Exception)
            {
            }
        }
        #endregion End PUBLIC FUNCTION

    }
}
