using AForge.Imaging;
using AForge.Vision.Motion;
using IPaking.Ultility;
using iParkingv5.Objects;
using iParkingv5.Objects.Configs;
using iParkingv5.Objects.Enums;
using Kztek.Cameras;
using Kztek.Tool;
using Kztek.Tool.LogDatabases;
using Kztek.Tools;

namespace iParkingv5_window.Usercontrols
{
    public partial class ucCameraView : UserControl
    {
        public delegate void MotionDetectEventHandler(object sender, MotionDetectEventArgs e);
        public event MotionDetectEventHandler MotionDetectEvent;
        public class MotionDetectEventArgs : EventArgs
        {
            public DateTime EventTime { get; set; }

            public Kztek.Cameras.Camera DetectCamera { get; init; }
        }
        #region Properties
        public Kztek.Cameras.Camera? _Camera { get; set; }
        private MotionDetector MotionDetector { get; set; }
        private CancellationTokenSource _ctsDetectMotion;
        private string laneId;

        #endregion End Properties

        #region Forms
        public ucCameraView(string laneId)
        {
            InitializeComponent();
            this.laneId = laneId;
        }

        public void ChangeByHeight(Size newSize, EmCameraResolutionDisplay cameraResolutionDisplay)
        {
            switch (cameraResolutionDisplay)
            {
                case EmCameraResolutionDisplay.Mode_16_9:
                    this.Height = newSize.Height;
                    this.Refresh();
                    this.Width = newSize.Height * 16 / 9;
                    break;
                case EmCameraResolutionDisplay.Mode_4_3:
                    this.Height = newSize.Height;
                    this.Refresh();
                    this.Width = newSize.Height * 4 / 3;
                    break;
                case EmCameraResolutionDisplay.Mode_Fill:
                    this.Size = newSize;
                    break;
                default:
                    break;
            }
        }
        public void ChangeByWidth(Size newSize, EmCameraResolutionDisplay cameraResolutionDisplay)
        {
            switch (cameraResolutionDisplay)
            {
                case EmCameraResolutionDisplay.Mode_16_9:
                    this.Width = newSize.Width;
                    this.Refresh();
                    newSize.Height = this.Width * 9 / 16;
                    break;
                case EmCameraResolutionDisplay.Mode_4_3:
                    this.Height = newSize.Height;
                    this.Refresh();
                    newSize.Height = this.Width * 3 / 4;
                    break;
                case EmCameraResolutionDisplay.Mode_Fill:
                    this.Size = newSize;
                    break;
                default:
                    break;
            }
        }
        #endregion End Forms

        #region Controls In Form
        private void Control_DoubleClick(object? sender, EventArgs e)
        {
            frmViewCamera frm = new()
            {
                CurrentCamera = _Camera
            };
            frm.ShowDialog();
        }
        #endregion

        #region Public Function
        public void StartViewer(Kztek.Cameras.Camera camera, CameraErrorEventHandler cameraErrorFunc)
        {
            this._Camera = camera;

            lblCameraName.Text = camera.Name;
            camera.CameraError += cameraErrorFunc;
            camera.Start();

            if (camera != null && camera.videoSourcePlayer != null)
            {
                var control = (Control)camera.videoSourcePlayer;
                panelCameraView.Controls.Add(control);

                control.Name = camera.ID;
                control.Dock = DockStyle.Fill;
                control.DoubleClick += Control_DoubleClick;
                control.BringToFront();
            }
        }
        public void StartViewer2(Kztek.Cameras.Camera camera, int i)
        {
            this._Camera = camera;

            lblCameraName.Text = camera.Name;


            if (camera != null && camera.videoSourcePlayer != null)
            {
                iCameraSourcePlayer iCameraSourcePlayer = camera.videoSourcePlayer;
                var control = (Control)iCameraSourcePlayer;
                panelCameraView.Controls.Add(control);

                control.Name = camera.ID;
                control.Dock = DockStyle.Fill;
                control.DoubleClick += Control_DoubleClick;
                control.BringToFront();
            }
        }

        private void VideoSourcePlayer_NewFrame(object sender, ref Bitmap image)
        {
        }

        public System.Drawing.Image? GetFullCurrentImage()
        {
            var bmp = _Camera!.GetCurrentVideoFrame();
            if (bmp == null)
            {
                bmp = _Camera.GetCurrentVideoFrame();
                if (bmp == null)
                {
                    return null;
                }
            }
            return bmp;
        }
        #endregion End Public Function
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (this._Camera != null)
            {
                this._Camera.videoSourcePlayer?.Stop();
                this._Camera.Stop();
            }
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private async Task DetectMotionCam(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(1000, token);

                    var currentFrame = GetFullCurrentImage();

                    if (currentFrame != null)
                    {
                        Rectangle? config = null;
                        try
                        {
                            if (File.Exists(PathManagement.laneCameraLoopConfigPath(this.laneId, this._Camera.ID)))
                            {
                                CameraDetectRegion? cameraDetectRegion = NewtonSoftHelper<CameraDetectRegion>.DeserializeObjectFromPath(PathManagement.laneCameraLoopConfigPath(laneId, this._Camera.ID));
                                if (cameraDetectRegion != null)
                                {
                                    config = new Rectangle()
                                    {
                                        X = cameraDetectRegion.X,
                                        Y = cameraDetectRegion.Y,
                                        Width = cameraDetectRegion.Width,
                                        Height = cameraDetectRegion.Height
                                    };
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                        }

                        if (config != null)
                        {
                            using Bitmap bmp = CropBitmap(new(currentFrame), config.Value);// new(currentFrame);
                            UnmanagedImage currentVideoFrame = UnmanagedImage.FromManagedImage(bmp);
                            if (this.MotionDetector != null && currentVideoFrame != null)
                            {
                                float motionLevel = MotionDetector.ProcessFrame(currentVideoFrame);
                                float alarmLevel = (float)AppData.alarmLLevel / 1000f;
                                label1.Invoke(new Action(() =>
                                {
                                    label1.Text = motionLevel + "-" + alarmLevel;
                                }));
                                if (motionLevel > alarmLevel)
                                {

                                    MotionDetectEvent?.Invoke(this, new MotionDetectEventArgs { DetectCamera = this._Camera, EventTime = DateTime.Now });
                                }
                            }

                            if (currentVideoFrame != null)
                            {
                                currentVideoFrame.Dispose();
                            }
                        }
                        else
                        {
                            using Bitmap bmp = new(currentFrame);
                            UnmanagedImage currentVideoFrame = UnmanagedImage.FromManagedImage(bmp);
                            if (this.MotionDetector != null && currentVideoFrame != null)
                            {
                                float motionLevel = MotionDetector.ProcessFrame(currentVideoFrame);
                                float alarmLevel = (float)AppData.alarmLLevel / 1000f;
                                label1.Invoke(new Action(() =>
                                {
                                    label1.Text = motionLevel + "-" + alarmLevel;
                                }));
                                if (motionLevel > alarmLevel)
                                {

                                    MotionDetectEvent?.Invoke(this, new MotionDetectEventArgs { DetectCamera = this._Camera, EventTime = DateTime.Now });
                                }
                            }

                            if (currentVideoFrame != null)
                            {
                                currentVideoFrame.Dispose();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
        public void StartMotionDetection()
        {
            label1.Visible = true;
            this.MotionDetector = new MotionDetector(new TwoFramesDifferenceDetector(true), null);
            PollingStart();
        }

        private void PollingStart()
        {
            _ctsDetectMotion = new CancellationTokenSource();

            Task.Run(() =>
                DetectMotionCam(_ctsDetectMotion.Token), _ctsDetectMotion.Token
            );
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

    }
}
