using IPaking.Ultility;
using iParkingv5.Objects;
using iParkingv5.Objects.Configs;
using iParkingv5_window.Usercontrols.CameraConfiguration;
using iParkingv6.Objects.Datas;
using Kztek.Tool;

namespace iParkingv5_window.Usercontrols
{
    public partial class ucCameraConfig : UserControl
    {
        #region Properties
        private Camera? currentCamera;
        private string laneId = string.Empty;
        private List<Camera> cameras = new List<Camera>();
        Kztek.Cameras.Camera? camView = null;
        private Rectangle? config = null;
        #endregion End Properties

        #region Forms
        public ucCameraConfig(List<Camera> cameras, string laneId)
        {
            InitializeComponent();

            this.cameras = cameras;
            this.laneId = laneId;

            cbCamera.SelectedIndexChanged += CbCamera_SelectedIndexChanged;
            btnLiveview.Click += btnLiveview_Click;
            btnLprDetect.Click += btnLprDetect_Click;
            btnDraw.Click += btnDraw_Click;
            this.Load += UcCameraConfig_Load;
        }

        private void UcCameraConfig_Load(object? sender, EventArgs e)
        {
            foreach (Camera camera in this.cameras)
            {
                cbCamera.Items.Add(camera.name);
            }
        }
        #endregion End Forms

        #region Controls In Form
        private void CbCamera_SelectedIndexChanged(object? sender, EventArgs e)
        {
            currentCamera = null;
            config = null;
            foreach (Camera camera in this.cameras)
            {
                if (camera.name == cbCamera.Text)
                {
                    currentCamera = camera;

                    ClearView();

                    camView = new Kztek.Cameras.Camera();
                    camView.ID = currentCamera!.id;
                    camView.Name = currentCamera!.name;
                    camView.VideoSource = currentCamera.ipAddress;
                    camView.HttpPort = int.Parse(currentCamera.httpPort);
                    camView.Login = currentCamera.username;
                    camView.Password = currentCamera.password;
                    camView.Chanel = currentCamera.channel;
                    string _camType = currentCamera.GetCameraType() == "HIK" ? "HIKVISION" : currentCamera.GetCameraType();
                    camView.CameraType = Kztek.Cameras.CameraTypes.GetType(_camType);
                    camView.StreamType = Kztek.Cameras.StreamTypes.GetType("H264");
                    camView.Resolution = string.IsNullOrEmpty(currentCamera.resolution) ? "1280x720" : currentCamera.resolution;

                    var oldConfig = NewtonSoftHelper<CameraDetectRegion>.DeserializeObjectFromPath(PathManagement.laneCameraConfigPath(laneId, this.currentCamera!.id));
                    if (oldConfig != null)
                    {
                        config = new Rectangle(oldConfig.X, oldConfig.Y, oldConfig.Width, oldConfig.Height);
                    }
                    break;
                }
            }
        }

        private void ClearView()
        {
            camView?.Stop();
            panelCamera.Controls.Clear();
            lblDetectPlate.Text = "";
            picLprImage.Image = null;
            picCutVehicleImage.Image = null;
            btnDraw.Visible = false;
            btnLprDetect.Visible = false;
            btnSave.Visible = false;
        }
        private void btnLiveview_Click(object? sender, EventArgs e)
        {
            if (!IsExistCamera())
            {
                MessageBox.Show("Hãy chọn camera!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            btnDraw.Visible = true;
            btnLprDetect.Visible = true;
            btnSave.Visible = true;
            camView!.Start();

            if (camView != null && camView.videoSourcePlayer != null)
            {
                var control = (Control)camView.videoSourcePlayer;
                panelCamera.Controls.Add(control);

                control.Name = camView.ID;
                control.Location = new Point(0, 0);
                control.Size = panelCamera.Size;
                control.Dock = DockStyle.Fill;
                control.BringToFront();
            }
        }
        private void btnLprDetect_Click(object? sender, EventArgs e)
        {
            if (!IsExistCamera())
            {
                MessageBox.Show("Hãy chọn camera!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Image image = camView!.GetCurrentVideoFrame();
            if (image != null)
            {
                if (config != null)
                {
                    Bitmap bitmapCut = CropBitmap((Bitmap)image, (Rectangle)config!);

                    string plate = StaticPool.LprDetect.GetPlateNumber(bitmapCut, true, null, out Image? lprImage);
                    lblDetectPlate.Text = plate;
                    picCutVehicleImage.Image = bitmapCut;
                    picLprImage.Image = lprImage;
                }
                else
                {
                    string plate = StaticPool.LprDetect.GetPlateNumber(image, true, null, out Image? lprImage);
                    lblDetectPlate.Text = plate;
                    picCutVehicleImage.Image = image;
                    picLprImage.Image = lprImage;
                }
            }
        }
        private void btnDraw_Click(object? sender, EventArgs e)
        {
            if (!IsExistCamera())
            {
                MessageBox.Show("Hãy chọn camera!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Image image = camView!.GetCurrentVideoFrame();
            frmCameraConfigSet frmCameraConfigSet = new frmCameraConfigSet(image, config);
            frmCameraConfigSet.ShowDialog();
            if (frmCameraConfigSet.DialogResult == DialogResult.OK)
            {
                this.config = frmCameraConfigSet.GetSaveConfig();
                panelCamera.Controls[0].Invalidate();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.config != null)
            {
                CameraDetectRegion cameraDetectRegion = new CameraDetectRegion()
                {
                    X = this.config.Value.X,
                    Y = this.config.Value.Y,
                    Width = this.config.Value.Width,
                    Height = this.config.Value.Height,
                };
                NewtonSoftHelper<CameraDetectRegion>.SaveConfig(cameraDetectRegion, PathManagement.laneCameraConfigPath(laneId, this.currentCamera!.id));
            }
            else
            {
                MessageBox.Show("Chưa có thông tin cấu hình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }
        #endregion End Controls In Form

        #region Private Function
        private bool IsExistCamera()
        {
            return currentCamera != null;
        }
        static Bitmap CropBitmap(Bitmap source, Rectangle section)
        {
            // Tạo một Bitmap mới với kích thước được xác định bởi Rectangle
            Bitmap bmp = new Bitmap(section.Width, section.Height);

            // Tạo đối tượng Graphics để vẽ Bitmap mới
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Vẽ phần cắt của Bitmap gốc lên Bitmap mới
                g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);
            }

            return bmp;
        }
        #endregion End Private Function

        private void btnLprDetect_Click_1(object sender, EventArgs e)
        {

        }
    }
}
