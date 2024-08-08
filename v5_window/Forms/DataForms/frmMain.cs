using IPaking.Ultility;
using iPakrkingv5.Controls;
using iParkingv5.ApiManager.XuanCuong;
using iParkingv5.Controller;
using iParkingv5.Objects;
using iParkingv5.Objects.Configs;
using iParkingv5.Objects.Datas.Device_service;
using iParkingv5.Objects.Enums;
using iParkingv5.Objects.Events;
using iParkingv5.Printer;
using iParkingv5.Reporting;
using iParkingv5_window.Forms.SystemForms;
using iParkingv5_window.Usercontrols;
using iParkingv6.Objects.Datas;
using Kztek.Scale_net6.Interfaces;
using Kztek.Tool;
using Kztek.Tools;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Collections.Concurrent;
using System.Reflection;
using System.Text;
using static IPaking.Ultility.TextManagement;
using static iParkingv5.Controller.ControllerFactory;
using static iParkingv5.Objects.Enums.PrintHelpers;
using static Kztek.Tools.LogHelper;

namespace iParkingv5_window.Forms.DataForms
{
    public partial class frmMain : Form
    {
        public static ControlSizeChangedEventArgs? splitContainerMainLocation;
        public static EmLanguage language = EmLanguage.Vietnamese;
        #region Properties
        public static List<IController> controllers = new List<IController>();
        private static List<iLane> lanes = new List<iLane>();
        private static IScale scaleController;
        public static ConcurrentQueue<CardEventArgs> cardEvents = new ConcurrentQueue<CardEventArgs>();
        public static ConcurrentQueue<InputEventArgs> inputEvents = new ConcurrentQueue<InputEventArgs>();
        List<LaneDisplayConfig>? laneDisplayConfigs = null;
        public static string controllerEventInitQueueName = "queue.ControllerEvent";
        private List<Lane> activeLanes = new List<Lane>();
        public static string defaultImagePath = Application.StartupPath + @"Resources\defaultImage.png";
        //public static Image _defaultImage ;
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
            bool isRevertRestartMode = (keyData & Keys.Control) == Keys.Control &&
                    (keyData & Keys.Shift) == Keys.Shift &&
                    (keyData & Keys.KeyCode) == Keys.F12;
            if (isEnableDevelopeMode)
            {
                panelDevelopeMode.Visible = true;
                splitterDevelopeMode.Visible = true;
                splitterDevelopeMode.BringToFront();
                return true;
            }
            else if (isDisEnableDevelopeMode)
            {
                panelDevelopeMode.Visible = false;
                splitterDevelopeMode.Visible = false;
                splitterDevelopeMode.BringToFront();
                return true;
            }
            else if (isRevertRestartMode)
            {
                isNeedToRestart = !isNeedToRestart;
            }
            else
            {
                for (int i = 0; i < lanes.Count; i++)
                {
                    iLane item = lanes[i];
                    item.OnKeyPress(keyData);
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        public frmMain(List<Lane> activeLanes)
        {
            InitializeComponent();
            this.Load += FrmMain_Load;
            this.Shown += FrmMain_Shown;

            AppData.printer = PrinterFactory.CreatePrinter((EmPrintTemplate)StaticPool.appOption.PrintTemplate);

            lblServerName.Text = Environment.MachineName;
            lblCompanyName.Text = StaticPool.oemConfig.CompanyName;
            this.Text = StaticPool.oemConfig.AppName;

            controllerEventInitQueueName = "queue.ControllerEvent";
            controllerEventInitQueueName = controllerEventInitQueueName + " - " + StaticPool.selectedComputer.IpAddress + StaticPool.selectedComputer.Id;
            this.activeLanes = activeLanes;

            bool isNeedToChooseLane = false;
            foreach (var item in StaticPool.lanes)
            {
                if (!string.IsNullOrEmpty(item.reverseLaneId))
                {
                    isNeedToChooseLane = true;
                    break;
                }
            }
            if (isNeedToChooseLane)
            {
                tsmiActiveLanesConfig.Visible = true;
            }
            else
            {
                tsmiActiveLanesConfig.Visible = false;
            }
            lblSoftwareName.Text = StaticPool.oemConfig.AppName + " - " + Assembly.GetExecutingAssembly().GetName().Version!.ToString();
            lblSoftwareName.Width = lblSoftwareName.PreferredSize.Width;
            this.FormClosing += frmMain_FormClosing;
        }
        public static bool isNeedToRestart = true;

        private void FrmMain_Shown(object? sender, EventArgs e)
        {
            //foreach (var item in lanes)
            //{
            //    item.DisplayUIConfig();
            //}
        }
        private async void FrmMain_Load(object? sender, EventArgs e)
        {
            try
            {
                this.Invoke(new Action(() =>
                {
                    lblUserNaem.Text = StaticPool.user_name;
                    lblUserNaem.Width = lblUserNaem.PreferredSize.Width;
                }));
                var screenBound = Screen.FromControl(this).WorkingArea;
                this.Size = new Size(screenBound.Width, screenBound.Height);
                this.Location = new Point(0, 0);

                LoadAppDisplayConfig();
                LoadThirdPartyConfig();

                InitLaneView();

                await ConnectToRabbitMQ();
                await StartControllers();
                lblSoftwareName.Width = lblSoftwareName.PreferredWidth;
                lblServerName.Width = lblServerName.PreferredWidth;
                lblCompanyName.Width = lblCompanyName.PreferredWidth;
                lblTime.Width = lblTime.PreferredWidth;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.System, obj: ex);
            }
        }

        private void LoadThirdPartyConfig()
        {
            if (File.Exists(PathManagement.thirtPartyConfigPath))
            {
                var thirdPartyConfig = NewtonSoftHelper<ThirdPartyConfig>.DeserializeObjectFromPath(PathManagement.thirtPartyConfigPath);
                if (thirdPartyConfig != null)
                {
                    if (thirdPartyConfig.IsUse)
                    {
                        if (((EmPrintTemplate)StaticPool.appOption.PrintTemplate) == EmPrintTemplate.XuanCuong)
                        {
                            XuanCuongApiHelper.url = thirdPartyConfig.ServerUrl;
                            XuanCuongApiHelper.apiKey = thirdPartyConfig.Password;
                        }
                    }
                }
            }
        }

        private void frmMain_FormClosing(object? sender, FormClosingEventArgs e)
        {
            FormClosing -= frmMain_FormClosing;

            this.Invoke(new Action(() =>
            {
                List<string> orderConfig = this.ucViewGrid1.GetOrderConfig();

                this.laneDisplayConfigs = new List<LaneDisplayConfig>();

                for (int i = 0; i < lanes.Count; i++)
                {
                    LaneDisplayConfig displayConfig = lanes[i].GetCurrentUIConfig();
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
                this.laneDisplayConfigs = sortedLaneDisplayConfigs; SaveUIConfig();
            }));
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
                Environment.Exit(0);
            }
        }
        #endregion

        #region Controls In Form
        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Environment.Exit(0);
        }
        private void tsmiAlarmReport_Click(object sender, EventArgs e)
        {
            //new frmReportAlarms().Show(this);
        }
        private void tsmiReportIn_Click(object sender, EventArgs e)
        {
            new frmReportIn(Image.FromFile(defaultImagePath), AppData.ApiServer).Show(this);
        }
        private void tsmiReportInOut_Click(object sender, EventArgs e)
        {
            new frmReportInOut(AppData.ApiServer, Image.FromFile(defaultImagePath), AppData.printer).Show(this);
        }
        private void tsmiReport_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            (sender as ToolStripMenuItem)!.ForeColor = Color.Red;
        }
        private void tsmiReport_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            (sender as ToolStripMenuItem)!.ForeColor = Color.Black;
        }
        private void tsmiExit_MouseEnter(object sender, EventArgs e)
        {
            (sender as ToolStripMenuItem)!.ForeColor = Color.Red;
        }
        private void tsmiExit_MouseLeave(object sender, EventArgs e)
        {
            (sender as ToolStripMenuItem)!.ForeColor = Color.Black;
        }
        #endregion

        #region Timer
        private void timerUpdateTime_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString(UltilityManagement.timeFormat);
            lblTime.Refresh();
        }
        #endregion End Timer

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
                lblLoadingStatus.Text = $"Nhận sự kiện input {e.InputIndex} từ bộ điều khiển " + e.DeviceName;
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
                try
                {
                    foreach (iLane iLane in lanes)
                    {
                        var configPath = PathManagement.laneControllerReaderConfigPath(iLane.lane.Id, e.DeviceId, e.ReaderIndex);
                        var config = NewtonSoftHelper<CardFormatConfig>.DeserializeObjectFromPath(configPath) ??
                                        new CardFormatConfig()
                                        {
                                            ReaderIndex = e.ReaderIndex,
                                            InputFormat = CardFormat.EmCardFormat.HEXA,
                                            OutputFormat = CardFormat.EmCardFormat.HEXA,
                                            OutputOption = CardFormat.EmCardFormatOption.Min_8,
                                        };
                        LogHelper.Log(EmLogType.WARN, EmObjectLogType.System, configPath);
                        e.PreferCard = CardFactory.StandardlizedCardNumber(e.PreferCard, config);
                        while (e.PreferCard.Length < 8)
                        {
                            e.PreferCard = "0" + e.PreferCard;
                        }
                        lblLoadingStatus.Text = $"Nhận sự kiện quẹt thẻ READER: {e.ReaderIndex}, CARD: {e.PreferCard} từ bộ điều khiển " + e.DeviceName;
                        lblLoadingStatus.Refresh();

                        iLane.OnNewEvent(e);
                    }
                }
                catch (Exception)
                {
                }
            }));
        }
        #endregion End Controller Event

        #region Private Function
        //--LOADING
        private void LoadAppDisplayConfig()
        {
            laneDisplayConfigs = new List<LaneDisplayConfig>();
            foreach (var item in this.activeLanes)
            {
                var config = NewtonSoftHelper<LaneDisplayConfig>.DeserializeObjectFromPath(PathManagement.appDisplayConfigPath(item.Id));
                if (config != null)
                {
                    laneDisplayConfigs.Add(config);
                }
            }

            //Đọc thông tin config thứ tự hiển thị trên giao diện
            //laneDisplayConfigs = NewtonSoftHelper<List<LaneDisplayConfig>>.DeserializeObjectFromPath(PathManagement.appDisplayConfigPath);
            if (laneDisplayConfigs != null)
            {
                //Lấy danh sách laneId theo thứ tự ưu tiên
                List<string> orderLaneIds = (from item in laneDisplayConfigs
                                             orderby item.DisplayIndex
                                             select item.LaneId).ToList();

                //Sắp xếp lại danh sách làn theo thứ tự ưu tiên
                List<Lane> sortedLanes = this.activeLanes
                    .OrderBy(lane => orderLaneIds.IndexOf(lane.Id))
                    .ToList();
                this.activeLanes = sortedLanes;
            }
        }
        private void InitLaneView()
        {
            this.DoubleBuffered = true;
            ucViewGrid1.ToggleDoubleBuffered(true);

            ucViewGrid1.SuspendLayout();
            ucViewGrid1.UpdateRowSetting(1, this.activeLanes.Count);
            lanes.Clear();
            foreach (Lane lane in this.activeLanes)
            {
                lblLoadingStatus.Text = "Khởi tạo làn: " + lane.name;
                lblLoadingStatus.Refresh();
                LaneDisplayConfig? laneDisplayConfig = GetLaneDisplayConfigByLaneId(lane);
                string configPath = PathManagement.appLaneDirectionConfigPath(lane.Id);
                var laneDirectionConfig = NewtonSoftHelper<LaneDirectionConfig>.DeserializeObjectFromPath(configPath) ?? LaneDirectionConfig.CreateDefault();

                iLane iLane = LaneFactory.CreateLane(lane, laneDisplayConfig, laneDirectionConfig);
                iLane.OnChangeLaneEvent += ILane_OnChangeLaneEvent;
                lanes.Add(iLane);
                ucViewGrid1.UpdateSelectLocation(iLane as Control);
                ((Control)iLane).Dock = DockStyle.Fill;
                ucViewGrid1.Refresh();
            }
            TableLayoutPanel table = (ucViewGrid1.Controls[0] as TableLayoutPanel)!;
            for (int i = 0; i < table.Controls.Count; i++)
            {
                var item = table.Controls[i];
                if (item is ucLaneIn)
                {
                    table.ColumnStyles[i] = new ColumnStyle(SizeType.Percent, 40);
                }
                else
                {
                    table.ColumnStyles[i] = new ColumnStyle(SizeType.Percent, 60);
                }
            }
            ucViewGrid1.ResumeLayout();
            foreach (var item in lanes)
            {
                item.DispayUI();
            }
        }

        private void ILane_onControlSizeChangeEvent(object sender, ControlSizeChangedEventArgs type)
        {
            if (type.Type == 1)
            {
                splitContainerMainLocation = type;
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
                        if (item.LaneId == lane.Id)
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
                if (bdk.Type == (int)EmControllerType.Dahua)
                {
                    continue;
                }
                Label lbl = new Label();
                panelAppStatus.Controls.Add(lbl);
                lbl.Dock = DockStyle.Right;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Text = bdk.Name;
                lbl.Name = bdk.Id;
                lbl.AutoSize = false;

                IController? controller = ControllerFactory.CreateController(bdk);
                if (controller != null)
                {
                    controllers.Add(controller);
                    bool isConnectSuccess = await controller.ConnectAsync();
                    controller.CardEvent += Controller_CardEvent;
                    controller.ErrorEvent += Controller_ErrorEvent;
                    controller.InputEvent += Controller_InputEvent;
                    controller.ConnectStatusChangeEvent += Controller_ConnectStatusChangeEvent;
                    controller.DeviceInfoChangeEvent += Controller_DeviceInfoChangeEvent;
                }
            }
            lblTime.SendToBack();

            foreach (IController controller in controllers)
            {
                controller.PollingStart();
            }

        }

        //--CLOSING
        private bool SaveUIConfig()
        {
            if (laneDisplayConfigs != null)
            {
                foreach (var item in laneDisplayConfigs)
                {
                    NewtonSoftHelper<LaneDisplayConfig>.SaveConfig(item, PathManagement.appDisplayConfigPath(item.LaneId));
                }
            }
            return true;
            //return NewtonSoftHelper<List<LaneDisplayConfig>>.SaveConfig(laneDisplayConfigs, PathManagement.appDisplayConfigPath);
        }

        //--RABBITMQ
        private IConnection conn;
        private IModel channel;
        private EventingBasicConsumer controllerEventConsumer;
        List<string> monitoringTask = new List<string>();

        private async Task ConnectToRabbitMQ()
        {
            await Task.Run(() =>
            {
                if (string.IsNullOrEmpty(StaticPool.serverConfig.RabbitMqUrl))
                {
                    return;
                }
                ConnectionFactory factory = new ConnectionFactory();
                factory.HostName = StaticPool.serverConfig.RabbitMqUrl;
                factory.Port = 5672;
                factory.UserName = StaticPool.serverConfig.RabbitMqUsername;
                factory.Password = StaticPool.serverConfig.RabbitMqPassword;
                conn = factory.CreateConnection();
                channel = conn.CreateModel();
                CreateRequireExchange();
                CreateRequiredQueue();
                MonitorControllerEvent();
            });
        }

        private void CreateRequireExchange()
        {
            channel.ExchangeDeclare("integrations", "topic");
        }

        public void CreateRequiredQueue()
        {
            channel.QueueDeclare(controllerEventInitQueueName, true, false, false, null);
            channel.QueueBind(controllerEventInitQueueName, "integrations", "integration.application.event.transaction");
        }
        public void MonitorControllerEvent()
        {
            controllerEventConsumer = new EventingBasicConsumer(channel);
            monitoringTask.Add(channel.BasicConsume(controllerEventInitQueueName, true, controllerEventConsumer));
            controllerEventConsumer.Received += ControllerEventConsumer_Received;
        }

        private void ControllerEventConsumer_Received(object? sender, BasicDeliverEventArgs e)
        {
            try
            {
                LogHelper.Log(EmLogType.INFOR, EmObjectLogType.System, specailName: "RabbitMQ", obj: e.Body.ToString());
                string payLoad = Encoding.ASCII.GetString(e.Body.ToArray());
                CardEventArgs ce = Newtonsoft.Json.JsonConvert.DeserializeObject<CardEventArgs>(payLoad)!;
                foreach (var item in controllers)
                {
                    if (item.ControllerInfo.Code == ce.DeviceId)
                    {
                        ce.DeviceId = item.ControllerInfo.Id;
                        break;
                    }
                }

                this.Invoke(new Action(() =>
                {
                    lblLoadingStatus.Text = $"Nhận sự kiện quẹt thẻ READER: {ce.ReaderIndex}, CARD: {ce.PreferCard} từ bộ điều khiển " + ce.DeviceName;
                    lblLoadingStatus.Refresh();

                    foreach (iLane iLane in lanes)
                    {
                        iLane.OnNewEvent(ce);
                    }
                }));
            }
            catch (Exception ex)
            {
            }
        }

        #endregion End Private Function

        private void timerUpdateControllerConnection_Tick(object sender, EventArgs e)
        {
            timerUpdateControllerConnection.Enabled = false;
            foreach (Bdk bdk in StaticPool.bdks)
            {
                foreach (Label lbl in panelAppStatus.Controls)
                {
                    if (lbl.Name == bdk.Id)
                    {
                        lbl.ForeColor = !bdk.IsConnect ? Color.Red : Color.Green;
                    }
                }
            }
            timerUpdateControllerConnection.Enabled = true;
        }

        private async void tsmiActiveLanesConfig_Click(object sender, EventArgs e)
        {
            FormClosing -= frmMain_FormClosing;
            try
            {
                foreach (var item in lanes)
                {
                    var temp = item.GetCurrentUIConfig();
                    if (laneDisplayConfigs != null)
                    {
                        foreach (var laneDisplayConfig in laneDisplayConfigs)
                        {
                            if (laneDisplayConfig.LaneId == item.lane.Id)
                            {
                                laneDisplayConfig.DisplayIndex = temp.DisplayIndex;
                                laneDisplayConfig.splitContainerEventContent = temp.splitContainerEventContent;
                                laneDisplayConfig.splitContainerMain = temp.splitContainerMain;
                                laneDisplayConfig.SplitterCameraPosition = temp.SplitterCameraPosition;
                                laneDisplayConfig.splitEventInfoWithCameraPosition = temp.splitEventInfoWithCameraPosition;
                                laneDisplayConfig.splitContainerCameraPosition = temp.splitContainerCameraPosition;
                                laneDisplayConfig.splitLastEventPosition = temp.splitLastEventPosition;
                            }
                        }
                    }


                }
                SaveUIConfig();

                foreach (var item in controllers)
                {
                    item.PollingStop();
                    await item.DisconnectAsync();
                }
                controllers.Clear();
            }
            catch (Exception ex)
            {
            }

            frmSelectLaneMode frm = new frmSelectLaneMode()
            {
                Owner = this.Owner,
            };
            frm.Show();
            this.Close();
        }

        private object lockLane = new object();
        private void ILane_OnChangeLaneEvent(object sender)
        {
            lock (lockLane)
            {
                iLane _ilane = (sender as iLane)!;
                _ilane.OnChangeLaneEvent += ILane_OnChangeLaneEvent;

                string removeLaneId = _ilane.lane.Id;
                string updateLaneId = _ilane.lane.reverseLaneId;

                List<string> activeLanes = NewtonSoftHelper<List<string>>.DeserializeObjectFromPath(PathManagement.appActiveLaneConfigPath()) ?? new List<string>();
                for (int i = 0; i < activeLanes.Count; i++)
                {
                    string laneId = activeLanes[i];
                    if (laneId == _ilane.lane.Id)
                    {
                        activeLanes[i] = _ilane.lane.reverseLaneId;
                        break;
                    }
                }

                ucViewGrid1.SuspendLayout();
                Control parent = null;

                NewtonSoftHelper<List<string>>.SaveConfig(activeLanes, PathManagement.appActiveLaneConfigPath());
                if (_ilane is ucLaneIn)
                {
                    parent = ((ucLaneIn)_ilane).Parent;
                    parent.Controls.Remove((ucLaneIn)_ilane);
                    ((ucLaneIn)_ilane).Dispose();
                }
                else if (_ilane is ucLaneOut)
                {
                    parent = ((ucLaneOut)_ilane).Parent;
                    parent.Controls.Remove((ucLaneOut)_ilane);
                    ((ucLaneOut)_ilane).Dispose();
                }

                Lane? removeLane = null;
                for (int i = 0; i < this.activeLanes.Count; i++)
                {
                    if (this.activeLanes[i].Id == removeLaneId)
                    {
                        removeLane = this.activeLanes[i];
                        break;
                    }
                }
                if (removeLane != null)
                {
                    this.activeLanes.Remove(removeLane);
                }

                Lane updateLane = null;
                for (int i = 0; i < StaticPool.lanes.Count; i++)
                {
                    if (StaticPool.lanes[i].Id == updateLaneId)
                    {
                        updateLane = StaticPool.lanes[i];
                        this.activeLanes.Add(StaticPool.lanes[i]);
                        break;
                    }
                }
                if (updateLane != null)
                {
                    lblLoadingStatus.Text = "Khởi tạo làn: " + updateLane.name;
                    lblLoadingStatus.Refresh();
                    LoadAppDisplayConfig();
                    LaneDisplayConfig? laneDisplayConfig = GetLaneDisplayConfigByLaneId(updateLane);
                    string configPath = PathManagement.appLaneDirectionConfigPath(updateLane.Id);
                    var laneDirectionConfig = NewtonSoftHelper<LaneDirectionConfig>.DeserializeObjectFromPath(configPath) ?? LaneDirectionConfig.CreateDefault();

                    iLane iLane = LaneFactory.CreateLane(updateLane, laneDisplayConfig, laneDirectionConfig);
                    iLane.OnChangeLaneEvent += ILane_OnChangeLaneEvent;
                    for (int i = 0; i < lanes.Count; i++)
                    {
                        if (lanes[i].lane.Id == removeLaneId)
                        {
                            lanes[i] = iLane;
                        }
                    }
                    parent.Controls.Add(iLane as Control);
                    //ucViewGrid1.UpdateSelectLocation(iLane as Control);
                    ((Control)iLane).Dock = DockStyle.Fill;
                    ucViewGrid1.Refresh();
                }

                TableLayoutPanel table = (ucViewGrid1.Controls[0] as TableLayoutPanel)!;
                for (int i = 0; i < table.Controls.Count; i++)
                {
                    var item = table.Controls[i];
                    if (item is ucLaneIn)
                    {
                        table.ColumnStyles[i] = new ColumnStyle(SizeType.Percent, 40);
                    }
                    else
                    {
                        table.ColumnStyles[i] = new ColumnStyle(SizeType.Percent, 60);
                    }
                    //((iLane)item).DisplayUIConfig();
                }
                ucViewGrid1.ResumeLayout();
                foreach (var item in lanes)
                {
                    item.DispayUI();
                }
                GC.Collect();
            }
        }
        private void timerClearLog_Tick(object sender, EventArgs e)
        {
            try
            {
                this.timerClearLog.Enabled = false;
                DateTime before10Day = DateTime.Now.AddDays(-10);
                string path = Path.Combine(LogHelper.SaveLogFolder, $"logs/{before10Day.Year}/{before10Day.Month}/{before10Day.Day}");
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                }
                this.timerClearLog.Enabled = true;
            }
            catch (Exception ex)
            {
                Log(EmLogType.ERROR, EmObjectLogType.System, hanh_dong: "frmMain", noi_dung_hanh_dong: "Clear log", obj: ex);
            }
        }

        private void menuStrip1_DoubleClick(object sender, EventArgs e)
        {
            panelAppStatus.Visible = !panelAppStatus.Visible;
        }
    }
}
