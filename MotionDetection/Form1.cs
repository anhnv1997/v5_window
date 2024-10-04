using iParkingv5.LprDetecter.LprDetecters;
using iParkingv5.Objects.Configs;
using iParkingv5_window;
using iParkingv5_window.Forms.DevelopeModes;
using iParkingv5_window.Usercontrols.CameraConfiguration;
using Kztek.Cameras;
using Kztek.Tool.LogDatabases;

namespace MotionDetection
{
    public partial class Form1 : Form
    {
        Kztek.Cameras.Camera camera;
        ucCameraView uc;
        private Rectangle? LoopConfig = null;

        public Form1()
        {
            InitializeComponent();
            Directory.CreateDirectory(Application.StartupPath + "/img");
            this.Load += Form1_Load;
        }

        private async void Form1_Load(object? sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.rect))
            {
                string[] rectArr = Properties.Settings.Default.rect.Split(",");
                this.LoopConfig = new Rectangle(int.Parse(rectArr[0]), int.Parse(rectArr[1]),
                                                int.Parse(rectArr[2]), int.Parse(rectArr[3]));
            }
            foreach (var item in Enum.GetValues(typeof(CameraType)))
            {
                cbType.Items.Add(item.ToString());
            }
            cbType.SelectedIndex = Properties.Settings.Default.type;

            txtIP.Text = Properties.Settings.Default.ip;
            txtUsername.Text = Properties.Settings.Default.username;
            txtPassword.Text = Properties.Settings.Default.password;
            cbType.SelectedIndex = Properties.Settings.Default.type;
            numAlarmLevel.Value = Properties.Settings.Default.alarmLevel;
            txtResolution.Text = Properties.Settings.Default.resolution;

            numAlarmLevel.ValueChanged += NumAlarmLevel_ValueChanged;

            AppData.LprDetect = LprFactory.CreateLprDetecter(new iParkingv5.Objects.Configs.LprConfig()
            {
                LPRDetecterType = iParkingv5.Objects.Configs.LprDetecter.EmLprDetecter.KztekLpr,
            }, null)!;
            await AppData.LprDetect.CreateLprAsync();
        }

        private void NumAlarmLevel_ValueChanged(object? sender, EventArgs e)
        {
            ucCameraView._alarmLevel = (int)numAlarmLevel.Value;
            Properties.Settings.Default.alarmLevel = ucCameraView._alarmLevel;
            Properties.Settings.Default.Save();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ip = txtIP.Text;
            Properties.Settings.Default.username = txtUsername.Text;
            Properties.Settings.Default.password = txtPassword.Text;
            Properties.Settings.Default.type = cbType.SelectedIndex;
            Properties.Settings.Default.resolution = txtResolution.Text;
            Properties.Settings.Default.alarmLevel = (int)numAlarmLevel.Value;
            Properties.Settings.Default.Save();
            camera = new Camera();
            camera.VideoSource = txtIP.Text;
            camera.Login = txtUsername.Text;
            camera.Password = txtPassword.Text;
            camera.CameraType = (CameraType)cbType.SelectedIndex;
            camera.Resolution = txtResolution.Text;
            ucCameraView._alarmLevel = Properties.Settings.Default.alarmLevel;
            if (uc != null)
            {
                uc.Dispose();
                panelCamera.Controls.Clear();

                uc = new ucCameraView("1");
                uc.StartViewer(camera, CameraErrorFunc);
                uc.MotionDetectEvent += Uc_MotionDetectEvent; ;
                uc.StartMotionDetection();
                panelCamera.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            }
            else
            {
                uc = new ucCameraView("1");
                uc.StartViewer(camera, CameraErrorFunc);
                uc.MotionDetectEvent += Uc_MotionDetectEvent; ;
                uc.StartMotionDetection();
                panelCamera.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            }
        }

        private void Uc_MotionDetectEvent(object sender, ucCameraView.MotionDetectEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                Image vehicleImg = uc.GetFullCurrentImage();
                if (vehicleImg != null)
                {
                    DateTime time = DateTime.Now;
                    string vehiclePath = Application.StartupPath + "/img" + "/vehicleImg" + time.ToString("dd_MM_yyyy_HH_mm_ss_ffffff") + ".jpeg";
                    string lprPath = Application.StartupPath + "/img" + "/lprImg" + time.ToString("dd_MM_yyyy_HH_mm_ss_ffffff") + ".jpeg";
                    try
                    {
                       vehicleImg.Save(vehiclePath);
                    }
                    catch (Exception ex)
                    {
                    }
                    var plateNumber = AppData.LprDetect.GetPlateNumber(vehicleImg, true, null, out Image? lprImage);
                    txtTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    txtPlateNumber.Text = plateNumber;
                    picLpr.Image = lprImage;
                    if (lprImage != null)
                    {
                        try
                        {
                            lprImage.Save(lprPath);
                        }
                        catch (Exception exx)
                        {
                        }
                    }
                    tblMotionLog.SaveLog(Guid.NewGuid().ToString(), DateTime.Now, vehiclePath, lprPath, plateNumber);
                }
            }));
        }

        public void CameraErrorFunc(object sender, string errorString)
        {
        }

        private void btnDetectConfig_Click(object sender, EventArgs e)
        {
            if (camera == null)
            {
                MessageBox.Show("Hãy kết nối camera trước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Image image = camera!.GetCurrentVideoFrame();
            frmCameraVirtualLoopConfigSet frmCameraConfigSet = new frmCameraVirtualLoopConfigSet(image, LoopConfig);
            frmCameraConfigSet.ShowDialog();
            if (frmCameraConfigSet.DialogResult == DialogResult.OK)
            {
                this.LoopConfig = frmCameraConfigSet.GetSaveConfig();
                Properties.Settings.Default.rect = this.LoopConfig.Value.X + "," + this.LoopConfig.Value.Y + "," + this.LoopConfig.Value.Width + "," + this.LoopConfig.Value.Height;
                Properties.Settings.Default.Save();
                uc.rect = this.LoopConfig;
                panelCamera.Controls[0].Invalidate();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            new frmSystemLogs().Show();
        }
    }
}
