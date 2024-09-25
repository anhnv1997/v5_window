using static HIKSDK.CHCNetSDK.NET_DVR_WIFI_CFG_EX;

namespace TESTCAM
{
    public partial class Form1 : Form
    {
        Kztek.Cameras.Camera cameras;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cameras = new Kztek.Cameras.Camera();
            cameras.VideoSource = textBox1.Text;
            cameras.HttpPort = int.Parse(textBox7.Text);
            cameras.Login = textBox5.Text;
            cameras.Password = textBox6.Text;
            cameras.Chanel = 0;
            cameras.CameraType = Kztek.Cameras.CameraTypes.GetType(textBox4.Text);
            cameras.StreamType = Kztek.Cameras.StreamTypes.GetType(textBox2.Text);
            cameras.Resolution = textBox3.Text;
            cameras.Start();
            var control = (Control)cameras.videoSourcePlayer;
            panel1.Controls.Add(control);
            control.Dock = DockStyle.Fill;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var img = cameras.GetCurrentVideoFrame();
            pictureBox1.Image = img;
            lblResolution.Text = img.Width + "x" + img.Height;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.GetThumbnailImage(1280,720,null, IntPtr.Zero).Save("test.jpeg");
        }
    }
}
