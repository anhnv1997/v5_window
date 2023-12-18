using iParkingv5.Controller;
using iParkingv5.Objects;
using iParkingv5.Objects.Events;
using iParkingv5_window.Usercontrols;
using iParkingv6.Objects.Datas;
using System.Collections.Concurrent;

namespace iParkingv5_window.Forms.DataForms
{
    public partial class frmMain : Form
    {
        #region Properties
        public static List<IController> controllers = new List<IController>();
        private static List<iLane> lanes = new List<iLane>();
        public static ConcurrentQueue<CardEventArgs> cardEvents = new ConcurrentQueue<CardEventArgs>();
        public static ConcurrentQueue<InputEventArgs> inputEvents = new ConcurrentQueue<InputEventArgs>();
        #endregion

        #region Forms
        public frmMain()
        {
            InitializeComponent();
            this.Load += FrmMain_Load;
        }
        private async void FrmMain_Load(object? sender, EventArgs e)
        {
            ucViewGrid1.UpdateRowSetting(1, StaticPool.lanes.Count);
            foreach (Lane lane in StaticPool.lanes)
            {
                lblLoadingStatus.Text = "Khởi tạo làn: " + lane.name;
                lblLoadingStatus.Refresh();
                iLane iLane = LaneFactory.CreateLane(lane);
                lanes.Add(iLane);
                ucViewGrid1.UpdateSelectLocation(iLane as Control);
                ((Control)iLane).Dock = DockStyle.Fill;
                ucViewGrid1.Refresh();
            }

            foreach (Bdk bdk in StaticPool.bdks)
            {
                bdk.communicationType = 0;
                IController controller = ControllerFactory.CreateController(bdk);
                controllers.Add(controller);
                lblLoadingStatus.Text = "Đang kết nối đến bộ điều khiển: " + bdk.name;
                lblLoadingStatus.Refresh();
                bool isConnectSuccess = await controller.ConnectAsync();
                controller.CardEvent += Controller_CardEvent;
                controller.ErrorEvent += Controller_ErrorEvent;
                controller.InputEvent += Controller_InputEvent;
                controller.ConnectStatusChangeEvent += Controller_ConnectStatusChangeEvent;
                controller.DeviceInfoChangeEvent += Controller_DeviceInfoChangeEvent;
                lblLoadingStatus.Text = "Kết nối đến bộ điều khiển: " + bdk.name + (isConnectSuccess ? "thành công" : "thất bại");
                lblLoadingStatus.Refresh();
            }

            foreach (IController controller in controllers)
            {
                controller.PollingStart();
            }
            lblLoadingStatus.Text = string.Empty;
            lblLoadingStatus.Refresh();
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (iLane lane in lanes)
            {
                lane.SaveUIConfig();
            }
            SaveUIConfig();
        }
        #endregion

        #region Controls In Form
        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void tsmiDevelopeMode_Click(object sender, EventArgs e)
        {
            panelDevelopeMode.Visible = !panelDevelopeMode.Visible;
            splitterDevelopeMode.Visible = !splitterDevelopeMode.Visible;
            splitterDevelopeMode.BringToFront();
        }
        private void tsmiAlarmReport_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Timer
        private void timerUpdateTime_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            lblTime.Refresh();
        }
        #endregion

        #region Controller Event
        private void Controller_DeviceInfoChangeEvent(object sender, DeviceInfoChangeArgs e)
        {
            lblLoadingStatus.BeginInvoke(new Action(() =>
            {
                lblLoadingStatus.Text = "Nhận sự kiện thay đổi thông tin thiết bị từ bộ điều khiển " + e.DeviceName;
                lblLoadingStatus.Refresh();
            }));
        }
        private void Controller_ConnectStatusChangeEvent(object sender, ConnectStatusCHangeEventArgs e)
        {
            lblLoadingStatus.BeginInvoke(new Action(() =>
            {
                lblLoadingStatus.Text = "Nhận sự kiện thay đổi trạng thái kết nối từ bộ điều khiển " + e.DeviceName;
                lblLoadingStatus.Refresh();
            }));
        }
        private void Controller_InputEvent(object sender, InputEventArgs e)
        {
            lblLoadingStatus.BeginInvoke(new Action(() =>
            {
                lblLoadingStatus.Text = $"Nhận sự kiện input {e.InputType} từ bộ điều khiển " + e.DeviceName;
                lblLoadingStatus.Refresh();
                foreach (iLane iLane in lanes)
                {
                    iLane.OnNewEvent(e);
                }
            }));
        }
        private void Controller_ErrorEvent(object sender, ControllerErrorEventArgs e)
        {
            lblLoadingStatus.BeginInvoke(new Action(() =>
            {
                lblLoadingStatus.Text = $"Nhận sự kiện error từ bộ điều khiển " + e.DeviceName;
                lblLoadingStatus.Refresh();
            }));
        }
        private void Controller_CardEvent(object sender, CardEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                lblLoadingStatus.Text = $"Nhận sự kiện quẹt thẻ READER: {e.ReaderIndex}, CARD: {e.AllCardFormats[0]} từ bộ điều khiển " + e.DeviceName;
                lblLoadingStatus.Refresh();

                foreach (CardEventArgs cardEvent in cardEvents)
                {
                    if (cardEvent.IsInWaitingTime(e, 5000, out int thoiGianCho))
                    {
                        lblLoadingStatus.Text = $"Đang trong thời gian chờ {e.AllCardFormats[0]}, quẹt lại sau {thoiGianCho / 1000}s";
                        lblLoadingStatus.Refresh();
                        return;
                    }
                }

                foreach (iLane iLane in lanes)
                {
                    iLane.OnNewEvent(e);
                }
            }));
        }
        #endregion End Controller Event

        #region Public Function

        #endregion

        #region Private Function
        private bool SaveUIConfig()
        {
            return true;
        }
        #endregion

        private void tsmiReportIn_Click(object sender, EventArgs e)
        {

        }

        private void tsmiReportInOut_Click(object sender, EventArgs e)
        {

        }

        private void tsmiSystem_Click(object sender, EventArgs e)
        {

        }

        private void tsmiLanguage_Click(object sender, EventArgs e)
        {
        }

        private void tsmiLogout_Click(object sender, EventArgs e)
        {
        }
    }
}
