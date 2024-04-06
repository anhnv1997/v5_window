using iParkingv5.Objects;
using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Enums;
using iParkingv6.ApiManager.KzParkingv3Apis;
using iParkingv6.Objects.Datas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iParkingv5_window.Usercontrols
{
    public partial class ucEventInInfo : UserControl
    {
        public delegate void OnBackClick(object sender);
        public event OnBackClick onBackClickEvent;
        public ucEventInInfo()
        {
            InitializeComponent();
            this.Load += UcEventInInfo_Load;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Visible = false;
                onBackClickEvent?.Invoke(this);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void UcEventInInfo_Load(object? sender, EventArgs e)
        {
            this.Visible = false;
            lblTitle.Location = new Point(StaticPool.baseSize * 2, StaticPool.baseSize * 2);
            lblLaneNameTitle.Location = new Point(lblTitle.Location.X,
                                                   lblTitle.Location.Y + lblTitle.Height + StaticPool.baseSize);
            lblTimeInTitle.Location = new Point(lblTitle.Location.X, lblLaneNameTitle.Location.Y + lblTimeInTitle.Height + StaticPool.baseSize);
            lblPlateNumberTitle.Location = new Point(lblTitle.Location.X, lblTimeInTitle.Location.Y + lblTimeInTitle.Height + StaticPool.baseSize);
            lblVehilceTypeTitle.Location = new Point(lblTitle.Location.X, lblPlateNumberTitle.Location.Y + lblPlateNumberTitle.Height + StaticPool.baseSize);
            lblIdentityNameTitle.Location = new Point(lblTitle.Location.X, lblVehilceTypeTitle.Location.Y + lblVehilceTypeTitle.Height + StaticPool.baseSize);
            lblIdentityCodeTitle.Location = new Point(lblTitle.Location.X, lblIdentityNameTitle.Location.Y + lblIdentityNameTitle.Height + StaticPool.baseSize);
            lblIdentityGroupTitle.Location = new Point(lblTitle.Location.X, lblIdentityCodeTitle.Location.Y + lblIdentityCodeTitle.Height + StaticPool.baseSize);
            lblCustomerTitle.Location = new Point(lblTitle.Location.X, lblIdentityGroupTitle.Location.Y + lblIdentityGroupTitle.Height + StaticPool.baseSize);
            lblPhoneTitle.Location = new Point(lblTitle.Location.X, lblCustomerTitle.Location.Y + lblCustomerTitle.Height + StaticPool.baseSize);
            lblExpireTimeTitle.Location = new Point(lblTitle.Location.X, lblPhoneTitle.Location.Y + lblPhoneTitle.Height + StaticPool.baseSize);

            lblLaneName.Location = new Point(this.DisplayRectangle.Width - lblLaneName.Width - StaticPool.baseSize * 2, lblLaneNameTitle.Location.Y);
            lblTimeIn.Location = new Point(this.DisplayRectangle.Width - lblTimeIn.Width - StaticPool.baseSize * 2, lblTimeInTitle.Location.Y);
            lblPlateNumber.Location = new Point(this.DisplayRectangle.Width - lblPlateNumber.Width - StaticPool.baseSize * 2, lblPlateNumberTitle.Location.Y);
            lblVehilceType.Location = new Point(this.DisplayRectangle.Width - lblVehilceType.Width - StaticPool.baseSize * 2, lblVehilceTypeTitle.Location.Y);
            lblIdentityName.Location = new Point(this.DisplayRectangle.Width - lblIdentityName.Width - StaticPool.baseSize * 2, lblIdentityNameTitle.Location.Y);
            lblIdentityCode.Location = new Point(this.DisplayRectangle.Width - lblIdentityCode.Width - StaticPool.baseSize * 2, lblIdentityCodeTitle.Location.Y);
            lblIdentityGroup.Location = new Point(this.DisplayRectangle.Width - lblIdentityGroup.Width - StaticPool.baseSize * 2, lblIdentityGroupTitle.Location.Y);
            lblCustomer.Location = new Point(this.DisplayRectangle.Width - lblCustomer.Width - StaticPool.baseSize * 2, lblCustomerTitle.Location.Y);
            lblPhoneNumber.Location = new Point(this.DisplayRectangle.Width - lblPhoneNumber.Width - StaticPool.baseSize * 2, lblPhoneTitle.Location.Y);
            lblExpireTime.Location = new Point(this.DisplayRectangle.Width - lblExpireTime.Width - StaticPool.baseSize * 2, lblExpireTimeTitle.Location.Y);

            lblLaneName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTimeIn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPlateNumber.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblVehilceType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblIdentityName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblIdentityCode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblIdentityGroup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPhoneNumber.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblExpireTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            lblCancel1.InitControl(LblCancel1_Click);
            this.Height = lblExpireTime.Location.Y + lblExpireTime.Height + StaticPool.baseSize * 3 + lblCancel1.Height;
            lblCancel1.Location = new Point(this.DisplayRectangle.Width - lblCancel1.Width - StaticPool.baseSize * 2,
                                            lblExpireTime.Location.Y + lblExpireTime.Height + StaticPool.baseSize);
        }
        private void LblCancel1_Click(object? sender, EventArgs e)
        {
            this.Visible = false;
            onBackClickEvent?.Invoke(this);
        }
        public async void ShowInfo(Point position, string laneId, string datetimeIn, string plateNumber,
                                   string identityId, string userId, string customerID, string registerVehicleId)
        {
            this.SuspendLayout();
            this.Location = position;
            this.BackColor = Color.FromArgb(255, 224, 192);
            Lane? lane = await KzParkingApiHelper.GetLaneByIdAsync(laneId);
            Identity? identity = await KzParkingApiHelper.GetIdentityById(identityId);
            IdentityGroup? identityGroup = null;
            VehicleType? vehicleType = null;
            if (identity != null)
            {
                identityGroup = await KzParkingApiHelper.GetIdentityGroupByIdAsync(identity.IdentityGroupId.ToString());
                if (identityGroup != null)
                {
                    vehicleType = await KzParkingApiHelper.GetVehicleTypeById(identityGroup.VehicleTypeId.ToString());
                }
            }

            Customer? customer = string.IsNullOrEmpty(customerID) ? null : await KzParkingApiHelper.GetCustomerById(customerID);
            RegisteredVehicle? registerVehicle = string.IsNullOrEmpty(registerVehicleId) ? null : await KzParkingApiHelper.GetRegisteredVehicleById(registerVehicleId);

            lblLaneName.Text = lane == null ? "_" : lane.name;
            lblTimeIn.Text = datetimeIn;
            lblPlateNumber.Text = plateNumber;
            lblVehilceType.Text = vehicleType == null ? "_" : vehicleType.Name;
            lblIdentityName.Text = identity == null ? "_" : identity.Name;
            lblIdentityCode.Text = identity == null ? "_" : identity.Code;
            lblIdentityGroup.Text = identityGroup == null ? "_" : identityGroup.Name;
            lblPhoneNumber.Text = customer == null ? "_" : customer.PhoneNumber;
            lblCustomer.Text = customer == null ? "_" : customer.Name;
            lblExpireTime.Text = registerVehicle == null ? "_" : registerVehicle.ExpireTime?.ToString("dd/MM/yyyy HH:mm:ss") ?? "_";

            lblLaneName.Location = new Point(this.DisplayRectangle.Width - lblLaneName.Width - StaticPool.baseSize * 2, lblLaneNameTitle.Location.Y);
            lblTimeIn.Location = new Point(this.DisplayRectangle.Width - lblTimeIn.Width - StaticPool.baseSize * 2, lblTimeInTitle.Location.Y);
            lblPlateNumber.Location = new Point(this.DisplayRectangle.Width - lblPlateNumber.Width - StaticPool.baseSize * 2, lblPlateNumberTitle.Location.Y);
            lblVehilceType.Location = new Point(this.DisplayRectangle.Width - lblVehilceType.Width - StaticPool.baseSize * 2, lblVehilceTypeTitle.Location.Y);
            lblIdentityName.Location = new Point(this.DisplayRectangle.Width - lblIdentityName.Width - StaticPool.baseSize * 2, lblIdentityNameTitle.Location.Y);
            lblIdentityCode.Location = new Point(this.DisplayRectangle.Width - lblIdentityCode.Width - StaticPool.baseSize * 2, lblIdentityCodeTitle.Location.Y);
            lblIdentityGroup.Location = new Point(this.DisplayRectangle.Width - lblIdentityGroup.Width - StaticPool.baseSize * 2, lblIdentityGroupTitle.Location.Y);
            lblCustomer.Location = new Point(this.DisplayRectangle.Width - lblCustomer.Width - StaticPool.baseSize * 2, lblCustomerTitle.Location.Y);
            lblPhoneNumber.Location = new Point(this.DisplayRectangle.Width - lblPhoneNumber.Width - StaticPool.baseSize * 2, lblPhoneTitle.Location.Y);
            lblExpireTime.Location = new Point(this.DisplayRectangle.Width - lblExpireTime.Width - StaticPool.baseSize * 2, lblExpireTimeTitle.Location.Y);

            this.BringToFront();
            this.ResumeLayout();
            this.Visible = true;
            this.ActiveControl = lblCancel1;
        }
    }
}
