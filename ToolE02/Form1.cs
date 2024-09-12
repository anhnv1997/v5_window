using iParkingv5.Controller;

namespace ToolE02
{
    public partial class Form1 : Form
    {
        IController c;
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            c = ControllerFactory.CreateController(new iParkingv6.Objects.Datas.Bdk()
            {
                Comport = textBox1.Text,
                Baudrate = "8000",
                Type = 5
            });
            await c.ConnectAsync();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            bool success = await c.OpenDoor(1, (int)numericUpDown1.Value);
            MessageBox.Show(success ? "Thành công" : "Thất bại");
        }
    }
}
