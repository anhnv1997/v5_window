using iParkingv5_window.Forms.DataForms;
using iParkingv6.Objects.Datas;

namespace iParkingv5_window.Usercontrols
{
    public partial class ucLastEventInfo : UserControl
    {
        #region Properties
        public string eventId = string.Empty;
        public string plateNumber = string.Empty;

        public string CustomerId { get; set; }
        public string vehicleGroupId = string.Empty;
        public string IdentityGroupId = string.Empty;
        public string RegisterVehicleId { get; set; }
        public string LaneId { get; set; }
        public string IdentityId { get; set; }

        public DateTime datetimeIn = DateTime.Now;
        public List<string> picDirs = new List<string>();
        public static Image defaultImg = Image.FromFile(frmMain.defaultImagePath);
        private bool isEventIn = false;

        #endregion End Properties

        #region Forms
        public ucLastEventInfo(bool isDisplayArrow = true)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            picVehicle.Image = defaultImg;
            pictureBox1.Visible = isDisplayArrow;
            this.Load += UcLastEventInfo_Load;
        }
        private void UcLastEventInfo_Load(object? sender, EventArgs e)
        {
            this.Click += UcLastEventInfo_Click;
            foreach (Control item in this.Controls)
            {
                item.Click += UcLastEventInfo_Click;
            }
            this.Width = pictureBox1.Visible ? this.Width : this.Width - pictureBox1.Width;
        }
        public async void UpdateEventInfo(string eventId, string plateNumber, string vehicleGroupId,
                                          string identityGroupId, DateTime datetimeIn, List<string> picDirs,
                                          string customerId, string registerVehicleId, string laneId, string identityId, bool isEventIn)
        {
            try
            {
                this.isEventIn = isEventIn;
                this.Invoke(new Action(() =>
                {
                    this.SuspendLayout();
                    this.eventId = eventId;
                    this.plateNumber = plateNumber;
                    this.vehicleGroupId = vehicleGroupId;
                    this.IdentityGroupId = identityGroupId;
                    this.datetimeIn = datetimeIn;
                    this.CustomerId = customerId;
                    this.RegisterVehicleId = registerVehicleId;
                    this.LaneId = laneId;
                    this.IdentityId = identityId;
                    this.picDirs = picDirs;

                }));

                if (this.picDirs.Count > 0)
                {
                    string displayPath = await MinioHelper.GetImage(this.picDirs[0]);
                    if (!string.IsNullOrEmpty(displayPath))
                    {
                        this.Invoke(new Action(() =>
                        {
                            picVehicle.LoadAsync(displayPath);
                        }));
                    }
                }
                this.ResumeLayout();
            }
            catch (Exception)
            {
            }
        }
        #endregion End Forms

        #region Controls In Form
        private void UcLastEventInfo_Click(object? sender, EventArgs e)
        {
            //if (this.isEventIn)
            {
                var frm = new frmEventInDetail(this.eventId, plateNumber, vehicleGroupId, IdentityGroupId, datetimeIn, picDirs,
                                          CustomerId, RegisterVehicleId, this.LaneId, this.IdentityId, this.isEventIn);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.plateNumber = frm.updatePlate;
                }
            }
        }
        #endregion End Controls In Form

        #region Private Function

        #endregion End Private Function

        #region Public Function

        #endregion End Public Function
    }
}
