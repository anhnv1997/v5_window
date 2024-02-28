using ALSE;
using ALSE.Objects;

namespace ALSE
{
    public partial class ucControllerConnection : UserControl
    {
        public Controller controller;
        public ucControllerConnection(Controller controller)
        {
            InitializeComponent();
            this.controller = controller;
            lblControllerName.Text = controller.name;
            this.Load += UcControllerConnection_Load;

            this.Width = picConnectStatus.Width + lblControllerName.PreferredWidth;
            toolTip1.SetToolTip(lblControllerName, "Thông Tin Kết Nối Của " + controller.name);
        }

        public void UpdateFloor(Controller newControllerInfo)
        {
            this.Invoke(new Action(() =>
            {
                lblControllerName.Text = newControllerInfo.name;
                toolTip1.SetToolTip(lblControllerName, "Thông Tin Kết Nối Của " + controller.name);
            }));
        }

        private void UcControllerConnection_Load(object? sender, EventArgs e)
        {
            controller.ConnectStatusChangeEvent += Controller_ConnectStatusChangeEvent;
        }
        private void Controller_ConnectStatusChangeEvent(object sender, ConnectStatusCHangeEventArgs e)
        {
            picConnectStatus.Invoke(() =>
            {
                picConnectStatus.Image = e.CurrentStatus ? Properties.Resources.ball_green : Properties.Resources.ball_red;
            });
        }
        private void timerUpdateStatus_Tick(object sender, EventArgs e)
        {
            picConnectStatus.Image = controller.IsConnect == true ? Properties.Resources.ball_green : Properties.Resources.ball_red;
        }

        public static double GetPreferRatio()
        {
            return 32f / 150;
        }
        public static int GetPreferWidth => 150;
    }
}
