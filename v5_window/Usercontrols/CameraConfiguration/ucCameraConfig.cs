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
        private Rectangle? LprConfig = null;
        private Rectangle? LoopConfig = null;
        #endregion End Properties

        #region Forms
        public ucCameraConfig(List<Camera> cameras, string laneId)
        {
            InitializeComponent();

            this.cameras = cameras;
            this.laneId = laneId;

            cbCamera.SelectedIndexChanged += CbCamera_SelectedIndexChanged;
            btnLiveview.Click += btnLiveview_Click;
            btnCarLprDetect.Click += btnCarLprDetect_Click;
            btnDraw.Click += btnDraw_Click;
            this.Load += UcCameraConfig_Load;
        }

        private void UcCameraConfig_Load(object? sender, EventArgs e)
        {
            foreach (Camera camera in this.cameras)
            {
                cbCamera.Items.Add(camera.Name);
            }
        }
        #endregion End Forms

        #region Controls In Form
        private void CbCamera_SelectedIndexChanged(object? sender, EventArgs e)
        {
            currentCamera = null;
            LprConfig = null;
            foreach (Camera camera in this.cameras)
            {
                if (camera.Name == cbCamera.Text)
                {
                    currentCamera = camera;

                    ClearView();

                    camView = new Kztek.Cameras.Camera();
                    camView.ID = currentCamera!.Id;
                    camView.Name = currentCamera!.Name;
                    camView.VideoSource = currentCamera.IpAddress;
                    camView.HttpPort = int.Parse(currentCamera.HttpPort);
                    camView.Login = currentCamera.Username;
                    camView.Password = currentCamera.Password;
                    camView.Chanel = currentCamera.Channel;
                    string _camType = currentCamera.GetCameraType() == "HIK" ? "HIKVISION2" : currentCamera.GetCameraType();
                    camView.CameraType = Kztek.Cameras.CameraTypes.GetType(_camType);
                    camView.StreamType = Kztek.Cameras.StreamTypes.GetType("H264");
                    camView.Resolution = string.IsNullOrEmpty(currentCamera.Resolution) ? "1280x720" : currentCamera.Resolution;

                    var oldConfig = NewtonSoftHelper<CameraDetectRegion>.DeserializeObjectFromPath(PathManagement.laneCameraConfigPath(laneId, this.currentCamera!.Id));
                    if (oldConfig != null)
                    {
                        LprConfig = new Rectangle(oldConfig.X, oldConfig.Y, oldConfig.Width, oldConfig.Height);
                    }

                    var oldLoopConfig = NewtonSoftHelper<CameraDetectRegion>.DeserializeObjectFromPath(PathManagement.laneCameraLoopConfigPath(laneId, this.currentCamera!.Id));
                    if (oldLoopConfig != null)
                    {
                        LoopConfig = new Rectangle(oldLoopConfig.X, oldLoopConfig.Y, oldLoopConfig.Width, oldLoopConfig.Height);
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
            btnCarLprDetect.Visible = false;
            btnMotorLprDetect.Visible = false;
            btnSave.Visible = false;
            btnClearConfig.Visible = false;
            btnVirtualLoop.Visible = false;
        }
        private void btnLiveview_Click(object? sender, EventArgs e)
        {
            if (!IsExistCamera())
            {
                MessageBox.Show("Hãy chọn camera!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            btnDraw.Visible = true;
            btnCarLprDetect.Visible = true;
            btnMotorLprDetect.Visible = true;
            btnSave.Visible = true;
            btnClearConfig.Visible = true;
            btnVirtualLoop.Visible = AppData.isUseVirtualLoop != EmVirtualLoopMode.UnUsed;

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
        private void btnCarLprDetect_Click(object? sender, EventArgs e)
        {
            if (!IsExistCamera())
            {
                MessageBox.Show("Hãy chọn camera!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Image image = camView!.GetCurrentVideoFrame();
            if (image != null)
            {
                if (LprConfig != null)
                {
                    Bitmap bitmapCut = CropBitmap((Bitmap)image, (Rectangle)LprConfig!);

                    string carPlate = AppData.LprDetect.GetPlateNumber(bitmapCut, true, null, out Image? lprImage);
                    lblDetectPlate.Text = carPlate;
                    picCutVehicleImage.Image = bitmapCut;
                    picLprImage.Image = lprImage;
                }
                else
                {
                    string plate = AppData.LprDetect.GetPlateNumber(image, true, null, out Image? lprImage);
                    lblDetectPlate.Text = plate;
                    picCutVehicleImage.Image = image;
                    picLprImage.Image = lprImage;
                }
            }
        }
        private void btnMotorLprDetect_Click(object sender, EventArgs e)
        {
            if (!IsExistCamera())
            {
                MessageBox.Show("Hãy chọn camera!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Image image = camView!.GetCurrentVideoFrame();
            if (image != null)
            {
                if (LprConfig != null)
                {
                    Bitmap bitmapCut = CropBitmap((Bitmap)image, (Rectangle)LprConfig!);

                    string carPlate = AppData.LprDetect.GetPlateNumber(bitmapCut, false, null, out Image? lprImage);
                    lblDetectPlate.Text = carPlate;
                    picCutVehicleImage.Image = bitmapCut;
                    picLprImage.Image = lprImage;
                }
                else
                {
                    string plate = AppData.LprDetect.GetPlateNumber(image, false, null, out Image? lprImage);
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
            frmCameraConfigSet frmCameraConfigSet = new frmCameraConfigSet(image, LprConfig);
            frmCameraConfigSet.ShowDialog();
            if (frmCameraConfigSet.DialogResult == DialogResult.OK)
            {
                this.LprConfig = frmCameraConfigSet.GetSaveConfig();
                panelCamera.Controls[0].Invalidate();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.LprConfig != null)
            {
                CameraDetectRegion cameraDetectRegion = new CameraDetectRegion()
                {
                    X = this.LprConfig.Value.X,
                    Y = this.LprConfig.Value.Y,
                    Width = this.LprConfig.Value.Width,
                    Height = this.LprConfig.Value.Height,
                };
                NewtonSoftHelper<CameraDetectRegion>.SaveConfig(cameraDetectRegion, PathManagement.laneCameraConfigPath(laneId, this.currentCamera!.Id));
            }

            if (this.LoopConfig != null)
            {
                CameraDetectRegion cameraDetectRegion = new CameraDetectRegion()
                {
                    X = this.LoopConfig.Value.X,
                    Y = this.LoopConfig.Value.Y,
                    Width = this.LoopConfig.Value.Width,
                    Height = this.LoopConfig.Value.Height,
                };
                NewtonSoftHelper<CameraDetectRegion>.SaveConfig(cameraDetectRegion, PathManagement.laneCameraLoopConfigPath(laneId, this.currentCamera!.Id));
            }

        }
        private void btnClearConfig_Click(object sender, EventArgs e)
        {
            string lprConfigPath = PathManagement.laneCameraConfigPath(laneId, this.currentCamera!.Id);
            string loopConfigPath = PathManagement.laneCameraLoopConfigPath(laneId, this.currentCamera!.Id);
            try
            {
                if (File.Exists(lprConfigPath))
                {
                    File.Delete(lprConfigPath);
                }
                if (File.Exists(loopConfigPath))
                {
                    File.Delete(loopConfigPath);
                }
                this.LprConfig = null;
                this.LoopConfig = null;
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa cấu hình không thành công, vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnCarLprDetect_Click_1(object sender, EventArgs e)
        {

        }

        private void btnDraw_Click_1(object sender, EventArgs e)
        {

        }

        private void btnVirtualLoop_Click(object sender, EventArgs e)
        {
            if (!IsExistCamera())
            {
                MessageBox.Show("Hãy chọn camera!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Image image = camView!.GetCurrentVideoFrame();
            frmCameraVirtualLoopConfigSet frmCameraConfigSet = new frmCameraVirtualLoopConfigSet(image, LoopConfig);
            frmCameraConfigSet.ShowDialog();
            if (frmCameraConfigSet.DialogResult == DialogResult.OK)
            {
                this.LoopConfig = frmCameraConfigSet.GetSaveConfig();
                panelCamera.Controls[0].Invalidate();
            }
        }
    }
}
