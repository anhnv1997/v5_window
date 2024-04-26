using iParkingv5.ApiManager.KzParkingv5Apis;
using iParkingv5.Objects;
using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Enums;
using iParkingv6.ApiManager.KzParkingv3Apis;
using iParkingv6.Objects.Datas;

namespace iParkingv5_window.Usercontrols
{
    public partial class ucAlarmInfo : UserControl
    {

        public delegate void OnBackClick(object sender);
        public event OnBackClick onBackClickEvent;
        public ucAlarmInfo()
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

            lblLaneName.Location = new Point(this.DisplayRectangle.Width - lblLaneName.Width - StaticPool.baseSize * 2, lblLaneNameTitle.Location.Y);
            lblTimeIn.Location = new Point(this.DisplayRectangle.Width - lblTimeIn.Width - StaticPool.baseSize * 2, lblTimeInTitle.Location.Y);
            lblPlateNumber.Location = new Point(this.DisplayRectangle.Width - lblPlateNumber.Width - StaticPool.baseSize * 2, lblPlateNumberTitle.Location.Y);
            lblVehilceType.Location = new Point(this.DisplayRectangle.Width - lblVehilceType.Width - StaticPool.baseSize * 2, lblVehilceTypeTitle.Location.Y);
            lblIdentityName.Location = new Point(this.DisplayRectangle.Width - lblIdentityName.Width - StaticPool.baseSize * 2, lblIdentityNameTitle.Location.Y);
            lblIdentityCode.Location = new Point(this.DisplayRectangle.Width - lblIdentityCode.Width - StaticPool.baseSize * 2, lblIdentityCodeTitle.Location.Y);
            lblIdentityGroup.Location = new Point(this.DisplayRectangle.Width - lblIdentityGroup.Width - StaticPool.baseSize * 2, lblIdentityGroupTitle.Location.Y);

            lblLaneName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTimeIn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPlateNumber.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblVehilceType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblIdentityName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblIdentityCode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblIdentityGroup.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            lblCancel1.InitControl(LblCancel1_Click);
            this.Height = lblIdentityGroup.Location.Y + lblIdentityGroup.Height + StaticPool.baseSize * 3 + lblCancel1.Height;
            lblCancel1.Location = new Point(this.DisplayRectangle.Width - lblCancel1.Width - StaticPool.baseSize * 2,
                                            lblIdentityGroup.Location.Y + lblIdentityGroup.Height + StaticPool.baseSize);
        }
        private void LblCancel1_Click(object? sender, EventArgs e)
        {
            this.Visible = false;
            onBackClickEvent?.Invoke(this);
        }
        public async void ShowInfo(Point position, string laneId, string datetimeIn, string plateNumber,
                                             string identityId, string userId)
        {
            this.SuspendLayout();
            this.Location = position;
            this.BackColor = Color.FromArgb(255, 224, 192);
            //Lane? lane = await KzParkingApiHelper.GetLaneByIdAsync(laneId);
            Lane? lane = (await KzParkingv5ApiHelper.GetLaneByIdAsync(laneId)).Item1;
            //Identity? identity = await KzParkingApiHelper.GetIdentityById(identityId);
            Identity? identity = (await KzParkingv5ApiHelper.GetIdentityByIdAsync(identityId)).Item1;
            IdentityGroup? identityGroup = null;
            VehicleType? vehicleType = null;
            if (identity != null)
            {
                //identityGroup = await KzParkingApiHelper.GetIdentityGroupByIdAsync(identity.IdentityGroupId.ToString());
                identityGroup = (await KzParkingv5ApiHelper.GetIdentityGroupByIdAsync(identity.IdentityGroupId.ToString())).Item1;
                if (identityGroup != null)
                {
                    //vehicleType = await KzParkingApiHelper.GetVehicleTypeById(identityGroup.VehicleTypeId.ToString());
                    vehicleType = (await KzParkingv5ApiHelper.GetVehicleTypeByIdAsync(identityGroup.VehicleType.Id.ToString())).Item1;
                }
            }
            lblLaneName.Text = lane == null ? "_" : lane.name;
            lblTimeIn.Text = datetimeIn;
            lblPlateNumber.Text = plateNumber;
            lblVehilceType.Text = vehicleType == null ? "_" : vehicleType.Name;
            lblIdentityName.Text = identity == null ? "_" : identity.Name;
            lblIdentityCode.Text = identity == null ? "_" : identity.Code;
            lblIdentityGroup.Text = identityGroup == null ? "_" : identityGroup.Name;

            lblLaneName.Location = new Point(this.DisplayRectangle.Width - lblLaneName.Width - StaticPool.baseSize * 2, lblLaneNameTitle.Location.Y);
            lblTimeIn.Location = new Point(this.DisplayRectangle.Width - lblTimeIn.Width - StaticPool.baseSize * 2, lblTimeInTitle.Location.Y);
            lblPlateNumber.Location = new Point(this.DisplayRectangle.Width - lblPlateNumber.Width - StaticPool.baseSize * 2, lblPlateNumberTitle.Location.Y);
            lblVehilceType.Location = new Point(this.DisplayRectangle.Width - lblVehilceType.Width - StaticPool.baseSize * 2, lblVehilceTypeTitle.Location.Y);
            lblIdentityName.Location = new Point(this.DisplayRectangle.Width - lblIdentityName.Width - StaticPool.baseSize * 2, lblIdentityNameTitle.Location.Y);
            lblIdentityCode.Location = new Point(this.DisplayRectangle.Width - lblIdentityCode.Width - StaticPool.baseSize * 2, lblIdentityCodeTitle.Location.Y);
            lblIdentityGroup.Location = new Point(this.DisplayRectangle.Width - lblIdentityGroup.Width - StaticPool.baseSize * 2, lblIdentityGroupTitle.Location.Y);
            this.BringToFront();
            this.ResumeLayout();
            this.Visible = true;
            this.ActiveControl = lblCancel1;
        }
    }
}