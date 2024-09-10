using iPakrkingv5.Controls;
using iParkingv5.Objects;
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
        public static Image defaultImg = Image.FromFile(StaticPool.oemConfig.LogoPath);
        private bool isEventIn = false;
        public delegate void OnChoosen(object sender, string eventId);
        public event OnChoosen? onChoosen;
        #endregion End Properties

        #region Forms0
        public ucLastEventInfo(bool isDisplayArrow = true)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            picVehicle.Image = picVehicle.ErrorImage = defaultImg.GetThumbnailImage(picVehicle.Image.Width, picVehicle.Image.Height, null, IntPtr.Zero);
            picVehicle.Tag = defaultImg;
            this.Load += UcLastEventInfo_Load;
            this.SizeChanged += UcLastEventInfo_SizeChanged;
        }

        private void Parent_SizeChanged(object? sender, EventArgs e)
        {
            this.Width = (this.Parent.Width + this.Padding.Right) / 3;
        }
        public void UpdateSize()
        {
            this.Width = (this.Parent.Width + this.Padding.Right) / 3;
        }
        private void UcLastEventInfo_SizeChanged(object? sender, EventArgs e)
        {
            if (this.Parent != null)
            {

                this.Width = (this.Parent.Width + this.Padding.Right) / 3;
            }
            else
            {
                this.Width = this.Height;
            }
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
            this.Width = this.Height * 16 / 9;
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
                this.Invoke(new Action(() =>
                {
                    this.SuspendLayout();
                    this.eventId = eventId;
                    this.picDirs = picDirs;

                }));
                if (displayImage != null)
                {
                    BaseLane.ShowImage(picVehicle, displayImage);
                }
                else
                {
                    ImageData? overviewData = picDirs.ContainsKey(EmParkingImageType.Overview) ? picDirs[EmParkingImageType.Overview][0] : null;
                    ImageData? vehicleData = picDirs.ContainsKey(EmParkingImageType.Vehicle) ? picDirs[EmParkingImageType.Vehicle][0] : null;
                    ImageData? lprData = picDirs.ContainsKey(EmParkingImageType.Plate) ? picDirs[EmParkingImageType.Plate][0] : null;

                    var overviewTask = AppData.ApiServer.parkingProcessService.GetImageUrl(overviewData?.bucket ?? "", overviewData?.objectKey ?? "");
                    var vehicleTask = AppData.ApiServer.parkingProcessService.GetImageUrl(vehicleData?.bucket ?? "", vehicleData?.objectKey ?? "");
                    var lprTask = AppData.ApiServer.parkingProcessService.GetImageUrl(lprData?.bucket ?? "", lprData?.objectKey ?? "");

                    await Task.WhenAll(overviewTask, vehicleTask, lprTask);

                    List<string> validUrls = new List<string>();
                    if (!string.IsNullOrEmpty(lprTask.Result))
                    {
                        validUrls.Add(lprTask.Result);
                    }
                    if (!string.IsNullOrEmpty(vehicleTask.Result))
                    {
                        validUrls.Add(vehicleTask.Result);
                    }
                    if (!string.IsNullOrEmpty(overviewTask.Result))
                    {
                        validUrls.Add(overviewTask.Result);
                    }

                    for (int i = 0; i < validUrls.Count; i++)
                    {
                        try
                        {
                            picVehicle.LoadAsync(validUrls[i]);
                            break;
                        }
                        catch (Exception)
                        {
                        }
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
        }
        private void picVehicle_LoadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            PictureBox pictureBox = (sender as PictureBox)!;
            if (e.Error != null)
            {
                picVehicle.Image = defaultImg.GetThumbnailImage(picVehicle.Image.Width, picVehicle.Image.Height, null, IntPtr.Zero);
                pictureBox.Tag = defaultImg;
            }
        }
        #endregion End Controls In Form

    }
}
