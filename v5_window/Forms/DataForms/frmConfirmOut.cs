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
        //Thông tin sự kiện vào
        private string plateIn;
        private string detectedPlate;
        private string identityIdIn;
        private string laneId;
        private Dictionary<EmParkingImageType, List<ImageData>> imageDatas;
        private DateTime datetimeIn;
        private long charge = 0;
        public string updatePlate;


        public static Image defaultImg = Image.FromFile(frmMain.defaultImagePath);

        private List<string>? eventInFileKeys;
        private DateTime dateTime;

        #region Forms
        public frmConfirmOut(string detectedPlate, string errorMessage, string plateIn, string identityIdIn,
                            string laneId, Dictionary<EmParkingImageType, List<ImageData>> fileKeys, DateTime datetimeIn, bool isDisplayQuestion = true, long charge = 0)
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

            this.detectedPlate = detectedPlate;
            this.plateIn = plateIn;
            this.identityIdIn = identityIdIn;
            this.laneId = laneId;
            this.imageDatas = fileKeys;
            this.datetimeIn = datetimeIn;
            this.charge = charge;
            this.updatePlate = detectedPlate;
            txtPlateOut.Focus();
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
            this.ActiveControl = txtPlateOut;
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
        #endregion End Forms

        #region Controls In Form
        private void BtnOk_Click(object? sender, EventArgs e)
        {
            updatePlate = txtPlateOut.Text;
            this.DialogResult = DialogResult.OK;
        }
        private void BtnCancel1_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion

        public async void ShowInfo(string detectedPlate, string laneIdIn, DateTime datetimeIn, string plateIn, string identityIdIn)
        {
            try
            {
                this.SuspendLayout();
                this.updatePlate = detectedPlate;
                Lane? laneIn = (await AppData.ApiServer.deviceService.GetLaneByIdAsync(laneIdIn)).Item1;
                Identity? identityIn = (await AppData.ApiServer.parkingDataService.GetIdentityByIdAsync(identityIdIn)).Item1;
                IdentityGroup? identityGroupIn = null;
                VehicleBaseType vehicleTypeIn = VehicleBaseType.Car;
                if (identityIn != null)
                {
                    identityGroupIn = (await AppData.ApiServer.parkingDataService.GetIdentityGroupByIdAsync(identityIn.IdentityGroupId.ToString())).Item1;
                    vehicleTypeIn = identityGroupIn.VehicleType;
                }

                this.Invoke(new Action(() =>
                {
                    lblTimeIn.Text = datetimeIn.ToVNTime();
                    lblTimeOut.Text = DateTime.Now.ToVNTime();
                    lblIdentityCode.Text = identityIn?.Name ?? "";
                    txtPlateOut.Text = detectedPlate;
                    lblPlateIn.Text = plateIn;
                    lblIdentityGroup.Text = identityGroupIn?.Name ?? "";
                    lblVehicleType.Text = VehicleType.GetDisplayStr(vehicleTypeIn);
                }));
                if (this.imageDatas?.Count >= 2)
                {
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
                }
                else if (this.imageDatas?.Count > 0)
                {
                    await ShowImage(this.imageDatas[0][0], picOverview);
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

    }
}
