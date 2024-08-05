using iParkingv5.ApiManager.KzScaleApis;
using iParkingv5.Objects.Enums;
using iParkingv5.Objects.EventDatas;
using iParkingv5_window.Usercontrols;
using Kztek.Helper;
using static iParkingv5.Objects.Enums.ParkingImageType;

namespace iParkingv5_window.Forms.DataForms
{
    public partial class frmEventInDetail : Form
    {
        #region Properties
        private string EventId = string.Empty;
        private string PlateNumber = string.Empty;
        private string VehicleGroupId = string.Empty;
        private string cardGroupId = string.Empty;
        private DateTime datetimeIn = DateTime.MinValue;
        private Dictionary<EmParkingImageType, List<ImageData>> picDirs = new Dictionary<EmParkingImageType, List<ImageData>>();
        private string customerId, registerVehicleId, laneId, identityId;
        public string updatePlate = "";
        public static Image defaultImg = Image.FromFile(frmMain.defaultImagePath);
        private bool isEventIn = false;
        #endregion End Properties

        #region Forms
        public frmEventInDetail(string eventInId, string plateNumber, string vehicleGroupId,
                                string cardGroupId, DateTime dateTimeIn, Dictionary<EmParkingImageType, List<ImageData>> picDirs,
                                string customerId, string registerVehicleId, string laneId, string identityId, bool isEventIn = false)
        {
            InitializeComponent();
            EventId = eventInId;
            this.PlateNumber = plateNumber;
            this.VehicleGroupId = vehicleGroupId;
            this.cardGroupId = cardGroupId;
            this.datetimeIn = dateTimeIn;
            this.picDirs = picDirs;
            this.customerId = customerId;
            this.registerVehicleId = registerVehicleId;
            this.laneId = laneId;
            this.identityId = identityId;
            this.isEventIn = isEventIn;
            this.Load += FrmEventInDetail_Load;
        }

        private async void FrmEventInDetail_Load(object? sender, EventArgs e)
        {
            var lane = (await AppData.ApiServer.deviceService.GetLaneByIdAsync(laneId)).Item1;
            var identity = (await AppData.ApiServer.parkingDataService.GetIdentityByIdAsync(this.identityId)).Item1;

            var identityGroup = (await AppData.ApiServer.parkingDataService.GetIdentityGroupByIdAsync(this.cardGroupId)).Item1;
            var customer = (await AppData.ApiServer.parkingDataService.GetCustomerByIdAsync(this.customerId)).Item1;
            var registerVehicle = (await AppData.ApiServer.parkingDataService.GetRegistedVehilceByIdAsync(this.registerVehicleId)).Item1;
            VehicleType.VehicleBaseType vehicleType = identityGroup.VehicleType;

            txtPlate.Text = this.PlateNumber;
            lblLaneName.Text = lane?.name;
            lblTimeIn.Text = this.datetimeIn.ToString("dd/MM/yyyy HH:mm:ss");
            lblVehilceType.Text = VehicleType.GetDisplayStr(vehicleType);
            lblIdentityName.Text = identity == null ? "" : identity.Name;
            lblIdentityCode.Text = identity == null ? "" : identity.Code;
            lblIdentityGroup.Text = identityGroup == null ? "" : identityGroup.Name;
            lblCustomer.Text = customer == null ? "" : customer.Name;
            lblPhoneNumber.Text = customer == null ? "" : customer.PhoneNumber;
            lblExpireTime.Text = registerVehicle == null ? "" : registerVehicle.ExpireTime?.ToString("dd/MM/yyyy HH:mm:ss");

            try
            {
                ImageData? overviewImgData = this.picDirs.ContainsKey(EmParkingImageType.Overview) ?
                                                this.picDirs[EmParkingImageType.Overview][0] : null;
                ImageData? vehicleImgData = this.picDirs.ContainsKey(EmParkingImageType.Vehicle) ?
                                                this.picDirs[EmParkingImageType.Vehicle][0] : null;
                ImageData? lprImgData = this.picDirs.ContainsKey(EmParkingImageType.Plate) ?
                                                this.picDirs[EmParkingImageType.Plate][0] : null;
                picOverviewImageIn.ShowImageAsync(overviewImgData);
                picVehicleImageIn.ShowImageAsync(vehicleImgData);
            }
            catch (Exception)
            {
            }
        }
        #endregion End Forms

        #region Controls In Form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async void btnUpdatePlate_Click(object sender, EventArgs e)
        {
            if (this.isEventIn)
            {
                bool isUpdateSuccess = await AppData.ApiServer.parkingProcessService.UpdateEventInPlateAsync(this.EventId, txtPlate.Text, this.PlateNumber);
                if (isUpdateSuccess)
                {
                    MessageBox.Show("Cập nhật thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.updatePlate = txtPlate.Text;
                    this.DialogResult = DialogResult.OK;
                    return;
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                bool isUpdateSuccess = await AppData.ApiServer.parkingProcessService.UpdateEventOutPlate(this.EventId, txtPlate.Text, this.PlateNumber);
                if (isUpdateSuccess)
                {
                    MessageBox.Show("Cập nhật thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.updatePlate = txtPlate.Text;
                    this.DialogResult = DialogResult.OK;
                    return;
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion End Controls In Form

        #region Private Function
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
        #endregion End Private Function

        #region Public Function
        private void Pic_LoadCompleted(object? sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            PictureBox pictureBox = (sender as PictureBox)!;
            if (e.Error != null)
            {
                pictureBox.Image = defaultImg;
            }
        }
        #endregion End Public Function
    }
}
