using iPakrkingv5.Controls;
using iParkingv5.Objects.EventDatas;
using iParkingv5_window.Forms.DataForms;
using Kztek.Helper;
using Kztek.Tools;
using static iParkingv5.Objects.Enums.ParkingImageType;

namespace iParkingv5_window.Usercontrols
{
    public partial class ucLastEventInfo : UserControl
    {
        #region Properties
        public string eventId = string.Empty;
        public string plateNumber = string.Empty;

        public string CustomerId { get; set; } = string.Empty;
        public string vehicleGroupId = string.Empty;
        public string IdentityGroupId = string.Empty;
        public string RegisterVehicleId { get; set; } = string.Empty;
        public string LaneId { get; set; } = string.Empty;
        public string IdentityId { get; set; } = string.Empty;

        public DateTime datetimeIn = DateTime.Now;
        public Dictionary<EmParkingImageType, List<ImageData>> picDirs = new Dictionary<EmParkingImageType, List<ImageData>>();
        public static Image defaultImg = Image.FromFile(frmMain.defaultImagePath);
        private bool isEventIn = false;
        public delegate void OnChoosen(object sender, string eventId);
        public event OnChoosen? onChoosen;
        #endregion End Properties

        #region Forms0
        public ucLastEventInfo(bool isDisplayArrow = true)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            picVehicle.Image = picVehicle.ErrorImage = defaultImg;
            pictureBox1.Visible = isDisplayArrow;
            this.Load += UcLastEventInfo_Load;
            this.SizeChanged += UcLastEventInfo_SizeChanged;
        }

        private void UcLastEventInfo_SizeChanged(object? sender, EventArgs e)
        {
            this.Width = pictureBox1.Visible ? this.Height + pictureBox1.Width : this.Height;
        }

        private void UcLastEventInfo_Load(object? sender, EventArgs e)
        {
            this.Click += UcLastEventInfo_Click;
            foreach (Control item in this.Controls)
            {
                item.Click += UcLastEventInfo_Click;
            }
            this.MouseEnter += UcLastEventInfo_MouseEnter;
            this.MouseLeave += UcLastEventInfo_MouseLeave;
            
            picVehicle.MouseEnter += UcLastEventInfo_MouseEnter;
            picVehicle.MouseLeave += UcLastEventInfo_MouseLeave;
            this.Width = pictureBox1.Visible ? this.Width : this.Width - pictureBox1.Width;
        }

        private void UcLastEventInfo_MouseLeave(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void UcLastEventInfo_MouseEnter(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        public async void UpdateEventInfo(string eventId, Dictionary<EmParkingImageType, List<ImageData>> picDirs, Image? displayImage = null)
        {
            try
            {
                this.isEventIn = isEventIn;
                this.Invoke(new Action(() =>
                {
                    this.SuspendLayout();
                    this.eventId = eventId;
                    this.picDirs = picDirs;

                }));
                if (displayImage != null)
                {
                    picVehicle.Image = displayImage;
                }
                else
                {
                    string displayPath = "";
                    ImageData? overviewData = picDirs.ContainsKey(EmParkingImageType.Overview) ? picDirs[EmParkingImageType.Overview][0] : null;
                    ImageData? vehicleData = picDirs.ContainsKey(EmParkingImageType.Vehicle) ? picDirs[EmParkingImageType.Vehicle][0] : null;
                    if (vehicleData != null)
                    {
                        picVehicle.ShowImageAsync(vehicleData);
                    }
                    else
                    {
                        picVehicle.ShowImageAsync(overviewData);
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
            this.onChoosen?.Invoke(this, this.eventId);
            //if (string.IsNullOrEmpty(this.eventId))
            //{
            //    return;
            //}
            //LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "Xem sk " + this.eventId);
            //var frm = new frmEventInDetail(this.eventId, plateNumber, vehicleGroupId, IdentityGroupId, datetimeIn, this.picDirs,
            //                               CustomerId, RegisterVehicleId, this.LaneId, this.IdentityId, this.isEventIn);
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    this.plateNumber = frm.updatePlate;
            //}
        }
        #endregion End Controls In Form

        private void picVehicle_LoadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            PictureBox pictureBox = (sender as PictureBox)!;
            if (e.Error != null)
            {
                pictureBox.Image = defaultImg;
            }
        }
    }
}
