using iParkingv5.Objects.Enums;
using iParkingv6.ApiManager.KzParkingv3Apis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private List<string> picDirs = new List<string>();
        private string customerId, registerVehicleId, laneId, identityId;
        public string updatePlate = "";
        public static Image defaultImg = Image.FromFile(frmMain.defaultImagePath);
        private bool isEventIn = false;
        #endregion End Properties

        #region Forms
        public frmEventInDetail(string eventInId, string plateNumber, string vehicleGroupId,
                                string cardGroupId, DateTime dateTimeIn, List<string> picDirs,
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
            var lane = await KzParkingApiHelper.GetLaneByIdAsync(laneId);
            var identity = await KzParkingApiHelper.GetIdentityById(this.identityId);
            var identityGroup = await KzParkingApiHelper.GetIdentityGroupByIdAsync(this.cardGroupId);
            var customer = await KzParkingApiHelper.GetCustomerById(this.customerId);
            var registerVehicle = await KzParkingApiHelper.GetRegisteredVehicleById(this.registerVehicleId);
            VehicleType vehicleType = await KzParkingApiHelper.GetVehicleTypeById(identityGroup?.VehicleTypeId.ToString());

            txtPlate.Text = this.PlateNumber;
            lblLaneName.Text = lane?.name;
            lblTimeIn.Text = this.datetimeIn.ToString("dd/MM/yyyy HH:mm:ss");
            lblVehilceType.Text = vehicleType == null ? "" : VehicleType.GetDisplayStr(vehicleType.Type);
            lblIdentityName.Text = identity == null ? "" : identity.Name;
            lblIdentityCode.Text = identity == null ? "" : identity.Code;
            lblIdentityGroup.Text = identityGroup == null ? "" : identityGroup.Name;
            lblCustomer.Text = customer == null ? "" : customer.Name;
            lblPhoneNumber.Text = customer == null ? "" : customer.PhoneNumber;
            lblExpireTime.Text = registerVehicle == null ? "" : registerVehicle.ExpireTime?.ToString("dd/MM/yyyy HH:mm:ss");

            try
            {
                if (this.picDirs.Count >= 2)
                {
                    string displayOverviewInPath = await MinioHelper.GetImage(this.picDirs[0]);
                    string vehicleInPath = await MinioHelper.GetImage(this.picDirs[1]);
                    Task task1 = ShowImage(this.picDirs[0], picOverviewImageIn);
                    Task task2 = ShowImage(this.picDirs[1], picVehicleImageIn);
                    await Task.WhenAll(task1, task2);
                }
                else if (this.picDirs.Count > 0)
                {
                    await ShowImage(this.picDirs[0], picOverviewImageIn);
                    this.Invoke((Delegate)(() =>
                    {
                        picVehicleImageIn.Image = defaultImg;
                    }));
                }
                else
                {
                    this.Invoke((Delegate)(() =>
                    {
                        picOverviewImageIn.Image = defaultImg;
                        picVehicleImageIn.Image = defaultImg;
                    }));
                }
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
                bool isUpdateSuccess = await KzParkingApiHelper.UpdateEventInPlate(this.EventId, txtPlate.Text);
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
                bool isUpdateSuccess = await KzParkingApiHelper.UpdateEventOutPlate(this.EventId, txtPlate.Text);
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
        #endregion End Public Function
    }
}
