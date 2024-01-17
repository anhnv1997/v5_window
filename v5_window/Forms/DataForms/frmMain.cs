using IPaking.Ultility;
using iParkingv5.Controller;
using iParkingv5.Objects;
using iParkingv5.Objects.Configs;
using iParkingv5.Objects.Events;
using iParkingv5_window.Forms.ReportForms;
using iParkingv5_window.Usercontrols;
using iParkingv6.Objects.Datas;
using Kztek.Tool;
using Kztek.Tools;
using System.Collections.Concurrent;
using static IPaking.Ultility.TextManagement;

namespace iParkingv5_window.Forms.DataForms
{
    public partial class frmMain : Form
    {
        public static EmLanguage language = EmLanguage.Vietnamese;
        #region Properties
        public static List<IController> controllers = new List<IController>();
        private static List<iLane> lanes = new List<iLane>();
        public static ConcurrentQueue<CardEventArgs> cardEvents = new ConcurrentQueue<CardEventArgs>();
        public static ConcurrentQueue<InputEventArgs> inputEvents = new ConcurrentQueue<InputEventArgs>();
        List<LaneDisplayConfig>? laneDisplayConfigs = null;
        #endregion

        #region Forms
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool isEnableDevelopeMode = (keyData & Keys.Control) == Keys.Control &&
                                 (keyData & Keys.Shift) == Keys.Shift &&
                                 (keyData & Keys.KeyCode) == Keys.E;
            bool isDisEnableDevelopeMode = (keyData & Keys.Control) == Keys.Control &&
                                (keyData & Keys.Shift) == Keys.Shift &&
                                (keyData & Keys.KeyCode) == Keys.D;
            if (isEnableDevelopeMode)
            {
                panelDevelopeMode.Visible = true;
                splitterDevelopeMode.Visible = true;
                splitterDevelopeMode.BringToFront();
            }
            else if (isDisEnableDevelopeMode)
            {
                panelDevelopeMode.Visible = false;
                splitterDevelopeMode.Visible = false;
                splitterDevelopeMode.BringToFront();
            }
            else
            {
                foreach (iLane item in lanes)
                {
                    item.OnKeyPress(keyData);
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        public frmMain()
        {
            InitializeComponent();
            this.Load += FrmMain_Load;
            this.Shown += FrmMain_Shown;
            lblServerName.Text = Environment.MachineName;
        }
        private void FrmMain_Shown(object? sender, EventArgs e)
        {
            foreach (var item in lanes)
            {
                item.DisplayUIConfig();
            }
        }
        private async void FrmMain_Load(object? sender, EventArgs e)
        {
            try
            {
                var screenBound = Screen.FromControl(this).WorkingArea;
                this.Size = new Size(screenBound.Width, screenBound.Height);
                this.Location = new Point(0, 0);

                LoadAppDisplayConfig();

                InitLaneView();

                await StartControllers();
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.System, obj: ex);
            }
        }
        private void frmMain_FormClosing(object? sender, FormClosingEventArgs e)
        {
            List<string> orderConfig = this.ucViewGrid1.GetOrderConfig();

            this.laneDisplayConfigs = new List<LaneDisplayConfig>();

            for (int i = 0; i < lanes.Count; i++)
            {
                LaneDisplayConfig displayConfig = lanes[i].SaveUIConfig();
                displayConfig.DisplayIndex = i;
                laneDisplayConfigs.Add(displayConfig);
            }

            List<LaneDisplayConfig> sortedLaneDisplayConfigs = laneDisplayConfigs
                   .OrderBy(item => orderConfig.IndexOf(item.LaneId))
                   .ToList();
            for (int i = 0; i < sortedLaneDisplayConfigs.Count; i++)
            {
                sortedLaneDisplayConfigs[i].DisplayIndex = i;
            }
            this.laneDisplayConfigs = sortedLaneDisplayConfigs;
            SaveUIConfig();

            FormClosing -= frmMain_FormClosing;
            Application.Exit();
            Environment.Exit(0);
        }
        #endregion

        #region Controls In Form
        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void tsmiAlarmReport_Click(object sender, EventArgs e)
        {
            new frmReportAlarms().Show(this);
        }
        private void tsmiReportIn_Click(object sender, EventArgs e)
        {
            new frmReportIn().Show(this);
        }
        private void tsmiReportInOut_Click(object sender, EventArgs e)
        {
            new frmReportInOut().Show(this);
        }
        private void tsmiReport_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            (sender as ToolStripMenuItem)!.Image = Properties.Resources.report_255_255_255_32px;
            (sender as ToolStripMenuItem)!.ForeColor = Color.Red;
        }
        private void tsmiReport_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            (sender as ToolStripMenuItem)!.Image = Properties.Resources.report_0_0_0_32px;
            (sender as ToolStripMenuItem)!.ForeColor = Color.Black;
        }
        private void tsmiExit_MouseEnter(object sender, EventArgs e)
        {
            (sender as ToolStripMenuItem)!.Image = Properties.Resources.NO_255_255_255_32px;
            (sender as ToolStripMenuItem)!.ForeColor = Color.Red;
        }
        private void tsmiExit_MouseLeave(object sender, EventArgs e)
        {
            (sender as ToolStripMenuItem)!.Image = Properties.Resources.NO_0_0_0_32px;
            (sender as ToolStripMenuItem)!.ForeColor = Color.Black;
        }
        #endregion

        #region Timer
        private void timerUpdateTime_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString(UltilityManagement.timeFormat);
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
                lblLoadingStatus.Text = $"Nhận sự kiện quẹt thẻ READER: {e.ReaderIndex}, CARD: {e.PreferCard} từ bộ điều khiển " + e.DeviceName;
                lblLoadingStatus.Refresh();

                foreach (iLane iLane in lanes)
                {
                    iLane.OnNewEvent(e);
                }
            }));
        }
        #endregion End Controller Event

        #region Private Function
        //--LOADING
        private void LoadAppDisplayConfig()
        {
            //Đọc thông tin config thứ tự hiển thị trên giao diện
            laneDisplayConfigs = NewtonSoftHelper<List<LaneDisplayConfig>>.DeserializeObjectFromPath(PathManagement.appDisplayConfigPath);
            if (laneDisplayConfigs != null)
            {
                //Lấy danh sách laneId theo thứ tự ưu tiên
                List<string> orderLaneIds = (from item in laneDisplayConfigs
                                             orderby item.DisplayIndex
                                             select item.LaneId).ToList();

                //Sắp xếp lại danh sách làn theo thứ tự ưu tiên
                List<Lane> sortedLanes = StaticPool.lanes
                    .OrderBy(lane => orderLaneIds.IndexOf(lane.id))
                    .ToList();
                StaticPool.lanes = sortedLanes;
            }
        }
        private void InitLaneView()
        {
            ucViewGrid1.UpdateRowSetting(1, StaticPool.lanes.Count);
            foreach (Lane lane in StaticPool.lanes)
            {
                lblLoadingStatus.Text = "Khởi tạo làn: " + lane.name;
                lblLoadingStatus.Refresh();
                LaneDisplayConfig? laneDisplayConfig = GetLaneDisplayConfigByLaneId(lane);
                iLane iLane = LaneFactory.CreateLane(lane, laneDisplayConfig);
                lanes.Add(iLane);
                ucViewGrid1.UpdateSelectLocation(iLane as Control);
                ((Control)iLane).Dock = DockStyle.Fill;
                ucViewGrid1.Refresh();
            }
        }
        private LaneDisplayConfig? GetLaneDisplayConfigByLaneId(Lane lane)
        {
            if (this.laneDisplayConfigs != null)
            {
                if (this.laneDisplayConfigs.Count > 0)
                {
                    foreach (LaneDisplayConfig item in this.laneDisplayConfigs)
                    {
                        if (item.LaneId == lane.id)
                        {
                            return item;
                        }
                    }
                }
            }

            return null;
        }
        private async Task StartControllers()
        {
            foreach (Bdk bdk in StaticPool.bdks)
            {
                IController? controller = ControllerFactory.CreateController(bdk);
                if (controller != null)
                {
                    controllers.Add(controller);
                    lblLoadingStatus.UpdateResultMessage("Đang kết nối đến bộ điều khiển: " + bdk.name, lblLoadingStatus.BackColor);
                    bool isConnectSuccess = await controller.ConnectAsync();
                    controller.CardEvent += Controller_CardEvent;
                    controller.ErrorEvent += Controller_ErrorEvent;
                    controller.InputEvent += Controller_InputEvent;
                    controller.ConnectStatusChangeEvent += Controller_ConnectStatusChangeEvent;
                    controller.DeviceInfoChangeEvent += Controller_DeviceInfoChangeEvent;
                    lblLoadingStatus.UpdateResultMessage("Kết nối đến bộ điều khiển: " + bdk.name + (isConnectSuccess ? "thành công" : "thất bại"), lblLoadingStatus.BackColor);
                }
            }

            foreach (IController controller in controllers)
            {
                controller.PollingStart();
            }

            lblLoadingStatus.UpdateResultMessage(string.Empty, lblLoadingStatus.BackColor);
        }

        //--CLOSING
        private bool SaveUIConfig()
        {
            return NewtonSoftHelper<List<LaneDisplayConfig>>.SaveConfig(laneDisplayConfigs, PathManagement.appDisplayConfigPath);
        }
        #endregion End Private Function
    }
}
