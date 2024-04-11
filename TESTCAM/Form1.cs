using static HIKSDK.CHCNetSDK.NET_DVR_WIFI_CFG_EX;

namespace TESTCAM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kztek.Cameras.Camera cameras = new Kztek.Cameras.Camera();
            cameras.CameraType = Kztek.Cameras.CameraType.Test;
            Kztek.Cameras.Camera cam_du_phong = new Kztek.Cameras.Camera();
            cam_du_phong.VideoSource = textBox1.Text;
            cam_du_phong.HttpPort =int.Parse(textBox7.Text);
            cam_du_phong.Login = textBox5.Text;
            cam_du_phong.Password =textBox6.Text;
            cam_du_phong.Chanel = 0;
            cam_du_phong.CameraType = Kztek.Cameras.CameraTypes.GetType(textBox4.Text);
            cam_du_phong.StreamType = Kztek.Cameras.StreamTypes.GetType(textBox2.Text);
            cam_du_phong.Resolution = textBox3.Text;
            cam_du_phong.Start();
            var control = (Control)cam_du_phong.videoSourcePlayer;
            panel1.Controls.Add(control);
            control.Dock =  DockStyle.Fill;
        }
    }
}
