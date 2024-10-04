using IPaking.Ultility;
using iPakrkingv5.Controls;
using iPakrkingv5.Controls.Controls.Labels;
using iParkingv5.ApiManager.KzParkingv5Apis.services;
using iParkingv5.ApiManager.XuanCuong;
using iParkingv5.Controller;
using iParkingv5.Objects;
using iParkingv5.Objects.Configs;
using iParkingv5.Objects.Datas.Device_service;
using iParkingv5.Objects.Datas.ThirtParty.OfficeHaus;
using iParkingv5.Objects.Enums;
using iParkingv5.Objects.Events;
using iParkingv5.Printer;
using iParkingv5.Printer.OfficeHaus;
using iParkingv5.Reporting;
using iParkingv5_window.Forms.SystemForms;
using iParkingv5_window.Forms.ThirdPartyForms.OfficeHausForms;
using iParkingv5_window.Usercontrols;
using iParkingv6.Objects.Datas;
using Kztek.Tool;
using Kztek.Tool.LogDatabases;
using Kztek.Tools;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Collections.Concurrent;
using System.Reflection;
using System.Text;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt;
using static IPaking.Ultility.TextManagement;
using static iParkingv5.Controller.ControllerFactory;
using static iParkingv5.Objects.Enums.LaneDirectionType;
using static iParkingv5.Objects.Enums.PrintHelpers;
using static Kztek.Tool.LogDatabases.tblSystemLog;
using static Kztek.Tools.LogHelper;
using static QRCoder.PayloadGenerator;
using iParkingv5.Objects.Datas.ThirtParty.Hanet;
using DocumentFormat.OpenXml.VariantTypes;
using iParkingv5.ApiManager;
using iParkingv5_window.Forms.ThirdPartyForms.HANETForms;
using static iParkingv5.Objects.Configs.AppViewModeConfig;
using iParkingv5_window.Forms.DevelopeModes;
using iParking.ConfigurationManager.Forms.SystemForms;

namespace iParkingv5_window.Forms.DataForms
{
    //public int SplitterCameraPosition { get; set; }
    //public int spliterCamera_top3Event { get; set; }
    //public int spliterPicEv_PicPlate { get; set; }
    //public int spliterEventPlate { get; set; }
    //public int spliterTopEvent_Actions { get; set; }
    //public int spliterEvInPlate { get; set; }
    //public int spliterEvOutPlate { get; set; }

    public partial class frmMain : Form
    {
        #region Display config
        public static LaneDisplayConfig preferLaneDisplayConfigIn;


        public static int preferMainDistance = 0;
        public static int preferCameraDistance = 0;

        public static int preferCamera_PicEv_PicPlateDistance = 0;
        public static int preferPicEv_PicPlateDistance = 0;

        public static int preferCamera_TopEvent_Distance = 0;
        public static int preferTopEvent_Action_Distance = 0;

        public static int preferEvInPlateDistance = 0;
        public static int preferEvOutPlateDistance = 0;


        public static bool IsNeedToConfirmPassword = true;
        #endregion

        public static ControlSizeChangedEventArgs? splitContainerMainLocation;
        public static EmLanguage language = EmLanguage.Vietnamese;
        #region Properties
        public static List<IController> controllers = new List<IController>();
        private static List<iLane> lanes = new List<iLane>();
        //private static IScale scaleController;
        public static ConcurrentQueue<CardEventArgs> cardEvents = new ConcurrentQueue<CardEventArgs>();
        public static ConcurrentQueue<InputEventArgs> inputEvents = new ConcurrentQueue<InputEventArgs>();
        List<LaneDisplayConfig>? laneDisplayConfigs = null;
        public static string controllerEventInitQueueName = "queue.ControllerEvent";
        private List<Lane> activeLanes = new List<Lane>();
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

            AppData.printer = PrinterFactory.CreatePrinter((EmPrintTemplate)StaticPool.appOption.PrintTemplate);

            this.Text = StaticPool.oemConfig.AppName;

            controllerEventInitQueueName = "queue.ControllerEvent";
            controllerEventInitQueueName = controllerEventInitQueueName + " - " + StaticPool.selectedComputer.IpAddress +
                                                                                  StaticPool.selectedComputer.Id;
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
            if (StaticPool.appOption.PrintTemplate != (int)EmPrintTemplate.OfficeHaus &&
                StaticPool.appOption.PrintTemplate != (int)EmPrintTemplate.HANET)
            {
                tsmiRegister.Visible = false;
                inQRToolStripMenuItem.Visible = false;
            }
            lblSoftwareName.Text = StaticPool.oemConfig.AppName + " - " + Assembly.GetExecutingAssembly().GetName().Version!.ToString();
            lblSoftwareName.Width = lblSoftwareName.PreferredSize.Width;

            lblLoadingStatus.MessageForeColor = Color.Black;
            lblLoadingStatus.MessageBackColor = SystemColors.ButtonHighlight;

            this.FormClosing += frmMain_FormClosing;

          
        }
        public static bool isNeedToRestart = true;

        private async void FrmMain_Load(object? sender, EventArgs e)
        {
            try
            {
                this.Invoke(new Action(() =>
                {
                    lblUserName.Text = StaticPool.user_name;
                    lblUserName.Width = lblUserName.PreferredSize.Width;
                }));
                var screenBound = Screen.FromControl(this).WorkingArea;
                this.Size = new Size(screenBound.Width, screenBound.Height);
                //this.Size = new Size(1366, 768);
                this.Location = new Point(0, 0);

                LoadAppDisplayConfig();
                LoadThirdPartyConfig();

                InitLaneView();

                await ConnectToRabbitMQ();
                await StartControllers();

                ConnectMQTT();
                lblSoftwareName.Width = lblSoftwareName.PreferredWidth;
                lblTime.Width = lblTime.PreferredWidth;
                panelAppStatus.Visible = StaticPool.appOption.IsDisplayStatusBar;
            }
            catch (Exception ex)
            {
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
            tblUserLog.SaveLog("Application", $"User Click To Exit");

            Application.Exit();
            Environment.Exit(0);
        }
        private void tsmiAlarmReport_Click(object sender, EventArgs e)
        {
            tblUserLog.SaveLog("Application", $"User Click To Alarm Report");

            //new frmReportAlarms().Show(this);
        }
        private void tsmiReportIn_Click(object sender, EventArgs e)
        {
            tblUserLog.SaveLog("Application", $"User Click To Report In");
            new frmReportIn(Image.FromFile(StaticPool.oemConfig.LogoPath), AppData.ApiServer).Show(this);
        }
        private void tsmiReportInOut_Click(object sender, EventArgs e)
        {
            tblUserLog.SaveLog("Application", $"User Click To Report Out");
            new frmReportInOut(AppData.ApiServer, Image.FromFile(StaticPool.oemConfig.LogoPath), AppData.printer).Show(this);
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
            lblLoadingStatus.Message = "Nhận sự kiện thay đổi thông tin thiết bị Controller: " + e.DeviceName;
            //lblLoadingStatus.UpdateResultMessage(
            //    "Nhận sự kiện thay đổi thông tin thiết bị Controller " + e.DeviceName,
            //    Color.DarkBlue);
            //lblLoadingStatus.BeginInvoke(new Action(() =>
            //{
            //    lblLoadingStatus.Text = "Nhận sự kiện thay đổi thông tin thiết bị Controller " + e.DeviceName;
            //    lblLoadingStatus.Refresh();
            //}));
        }
        private void Controller_ConnectStatusChangeEvent(object sender, ConnectStatusCHangeEventArgs e)
        {
            lblLoadingStatus.Message = "Nhận sự kiện thay đổi trạng thái kết nối Controller: " + e.DeviceName;

            //lblLoadingStatus.UpdateResultMessage(
            //           "Nhận sự kiện thay đổi trạng thái kết nối Controller " + e.DeviceName,
            //           Color.DarkBlue);

            //lblLoadingStatus.BeginInvoke(new Action(() =>
            //{
            //    lblLoadingStatus.Text = "Nhận sự kiện thay đổi trạng thái kết nối Controller " + e.DeviceName;
            //    lblLoadingStatus.Refresh();
            //}));
        }
        private void Controller_InputEvent(object sender, InputEventArgs e)
        {
            // lblLoadingStatus.UpdateResultMessage(
            //$"Nhận sự kiện input {e.InputIndex} Controller " + e.DeviceName, Color.DarkBlue);


            lblLoadingStatus.BeginInvoke(new Action(() =>
            {
                lblLoadingStatus.Message = $"Nhận sự kiện input {e.InputIndex} Controller " + e.DeviceName;
                //lblLoadingStatus.Text = $"Nhận sự kiện input {e.InputIndex} Controller " + e.DeviceName;
                //lblLoadingStatus.Refresh();
                foreach (iLane iLane in lanes)
                {
                    iLane.OnNewEvent(e);
                }
            }));
        }
        private void Controller_ErrorEvent(object sender, ControllerErrorEventArgs e)
        {
            //lblLoadingStatus.Message = $"Nhận sự kiện error Controller " + e.DeviceName;

            lblLoadingStatus.UpdateResultMessage(
               $"Nhận sự kiện error Controller " + e.DeviceName, Color.DarkBlue);

            lblLoadingStatus.BeginInvoke(new Action(() =>
            {
                lblLoadingStatus.Text = $"Nhận sự kiện error Controller " + e.DeviceName;
                lblLoadingStatus.Refresh();

                foreach (iLane iLane in lanes)
                {
                    iLane.OnNewEvent(e);
                }
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
                        e.PreferCard = CardFactory.StandardlizedCardNumber(e.PreferCard, config);
                        while (e.PreferCard.Length < 8)
                        {
                            e.PreferCard = "0" + e.PreferCard;
                        }
                        e.AllCardFormats.Add(e.PreferCard);
                        lblLoadingStatus.Message = $"{DateTime.Now:HH:mm:ss} READER: {e.ReaderIndex}, CARD: {e.PreferCard} Controller: " + e.DeviceName;
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
            switch (StaticPool.appViewModeConfig.ViewMode)
            {
                default:
                    break;
            }
            switch ((EmAppViewMode)StaticPool.appViewModeConfig.ViewMode)
            {
                case EmAppViewMode.Optional:
                    ucViewGrid1.UpdateRowSetting(StaticPool.appViewModeConfig.RowCount, StaticPool.appViewModeConfig.ColumnCount);
                    break;
                case EmAppViewMode.Horizontal:
                    ucViewGrid1.UpdateRowSetting(1, this.activeLanes.Count);
                    break;
                case EmAppViewMode.Vertical:
                    ucViewGrid1.UpdateRowSetting(this.activeLanes.Count, 1);
                    break;
                default:
                    break;
            }
            lanes.Clear();
            foreach (Lane lane in this.activeLanes)
            {
                lblLoadingStatus.Message = "Khởi tạo làn: " + lane.name;

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
            switch ((EmAppViewMode)StaticPool.appViewModeConfig.ViewMode)
            {
                case EmAppViewMode.Optional:
                    for (int i = 0; i < table.ColumnStyles.Count; i++)
                    {
                        var item = table.GetControlFromPosition(i, 0);
                        if (item is ucLaneIn)
                        {
                            table.ColumnStyles[i] = new ColumnStyle(SizeType.Percent, 40);
                        }
                        else
                        {
                            table.ColumnStyles[i] = new ColumnStyle(SizeType.Percent, 60);
                        }
                    }
                    break;
                case EmAppViewMode.Horizontal:
                    for (int i = 0; i < table.ColumnStyles.Count; i++)
                    {
                        var item = table.GetControlFromPosition(i, 0);
                        if (item is ucLaneIn)
                        {
                            table.ColumnStyles[i] = new ColumnStyle(SizeType.Percent, 40);
                        }
                        else
                        {
                            table.ColumnStyles[i] = new ColumnStyle(SizeType.Percent, 60);
                        }
                    }
                    break;
                case EmAppViewMode.Vertical:
                    for (int i = 0; i < table.RowStyles.Count; i++)
                    {
                        var item = table.GetControlFromPosition(0, i);
                        if (item is ucLaneIn)
                        {
                            table.RowStyles[i] = new RowStyle(SizeType.Percent, 40);
                        }
                        else
                        {
                            table.RowStyles[i] = new RowStyle(SizeType.Percent, 60);
                        }
                    }
                    break;
                default:
                    break;
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
                lbl.Width = lbl.PreferredWidth;
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
            ucEventCount1.SendToBack();
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

        //--MQTT
        public void ConnectMQTT()
        {
            if (!string.IsNullOrEmpty(StaticPool.serverConfig.MQTTUrl))
            {
                var _MqttClient = new MqttClient(StaticPool.serverConfig.MQTTUrl, 1883, false, MqttSslProtocols.None, null, null);
                _MqttClient.ProtocolVersion = MqttProtocolVersion.Version_3_1;

                // Set username and password
                string username = StaticPool.serverConfig.MQTTUsername;
                string password = StaticPool.serverConfig.MQTTPassword;

                // Connect to the MQTT broker with the specified credentials
                _MqttClient.Connect(StaticPool.selectedComputer.Name, username, password);

                // Subscribe to topics
                _MqttClient.MqttMsgPublishReceived += _MqttClient_MqttMsgPublishReceived;
                _MqttClient.Subscribe(new string[] { "#" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
            }
        }

        //--RABBITMQ
        private IConnection conn;
        private IModel channel;
        private EventingBasicConsumer controllerEventConsumer;
        List<string> monitoringTask = new List<string>();

        private async Task ConnectToRabbitMQ()
        {
            if (string.IsNullOrEmpty(StaticPool.serverConfig.RabbitMqUrl))
            {
                return;
            }
            await Task.Run(() =>
            {
                try
                {
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
                }
                catch (Exception ex)
                {
                    tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS,
                                         $"RabbitMQ Connect {StaticPool.serverConfig.RabbitMqUrl} - {StaticPool.serverConfig.RabbitMqUsername} - {StaticPool.serverConfig.RabbitMqPassword}", ex);
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }

        private void CreateRequireExchange()
        {
            channel.ExchangeDeclare(StaticPool.serverConfig.RabbitMQExchangeName, "topic");
        }

        public void CreateRequiredQueue()
        {
            channel.QueueDeclare(controllerEventInitQueueName, true, false, false, null);
            channel.QueueBind(controllerEventInitQueueName, StaticPool.serverConfig.RabbitMQExchangeName,
                                                            StaticPool.serverConfig.RabbitMQRoutingKey);
        }
        public void MonitorControllerEvent()
        {
            controllerEventConsumer = new EventingBasicConsumer(channel);
            monitoringTask.Add(channel.BasicConsume(controllerEventInitQueueName, true, controllerEventConsumer));
            controllerEventConsumer.Received += ControllerEventConsumer_Received;
        }

        private void ControllerEventConsumer_Received(object? sender, BasicDeliverEventArgs e)
        {
            string payLoad = Encoding.ASCII.GetString(e.Body.ToArray());
            try
            {
                tblSystemLog.SaveLog(EmSystemAction.MessageQueue, EmSystemActionDetail.GET, payLoad);
                CardEventArgs ce = Newtonsoft.Json.JsonConvert.DeserializeObject<CardEventArgs>(payLoad)!;

                foreach (var item in lanes)
                {
                    if (item.lane.code == ce.DeviceId)
                    {
                        foreach (var controlUnit in item.lane.controlUnits)
                        {
                            if (controlUnit.readers.Length > 0)
                            {
                                ce.DeviceId = controlUnit.controlUnitId;
                                ce.ReaderIndex = controlUnit.readers[0];
                                lblLoadingStatus.Message = $"{DateTime.Now:HH:mm:ss} READER: {ce.ReaderIndex}, CARD: {ce.PreferCard} Controller: " + ce.DeviceName;
                                item.OnNewEvent(ce);
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                tblSystemLog.SaveLog(EmSystemAction.MessageQueue, EmSystemActionDetail.GET, payLoad, ex);
            }
        }

        #endregion End Private Function

        private void timerUpdateControllerConnection_Tick(object sender, EventArgs e)
        {
            timerUpdateControllerConnection.Enabled = false;
            foreach (Bdk bdk in StaticPool.bdks)
            {
                foreach (Label lbl in panelAppStatus.Controls.OfType<Label>())
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
            tblUserLog.SaveLog("Application", $"User Click To Open Chosse Lane");

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
                                laneDisplayConfig.SplitterCameraPosition = temp.SplitterCameraPosition;
                                laneDisplayConfig.splitContainerMain = temp.splitContainerMain;
                                laneDisplayConfig.spliterCamera_PicEv_PicPlate = temp.spliterCamera_PicEv_PicPlate;
                                laneDisplayConfig.spliterCamera_top3Event = temp.spliterCamera_top3Event;
                                laneDisplayConfig.spliterPicEv_PicPlate = temp.spliterPicEv_PicPlate;
                                laneDisplayConfig.spliterEventPlate = temp.spliterEventPlate;
                                laneDisplayConfig.spliterTopEvent_Actions = temp.spliterTopEvent_Actions;
                                laneDisplayConfig.spliterEvOutPlate = temp.spliterEvOutPlate;
                                laneDisplayConfig.spliterEvInPlate = temp.spliterEvInPlate;
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
                    lblLoadingStatus.Message = "Khởi tạo làn: " + updateLane.name;

                    //lblLoadingStatus.UpdateResultMessage("Khởi tạo làn: " + updateLane.name, Color.DarkBlue);
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
                LogHelper.ClearLogAfterDays(StaticPool.appOption.NumLogKeepDays * -1);
                this.timerClearLog.Enabled = true;
            }
            catch (Exception ex)
            {
                tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.DELETE, "LOG", ex);
            }
        }

        private void menuStrip1_DoubleClick(object sender, EventArgs e)
        {
            panelAppStatus.Visible = !panelAppStatus.Visible;
        }

        HausVisitor? lastHausVistor = null;
        private void btnRegister_Click(object? sender, EventArgs e)
        {
            tblUserLog.SaveLog("Application", $"User Click To Open Register Screen");
            if (StaticPool.appOption.PrintTemplate == (int)EmPrintTemplate.HANET)
            {
                new frmRegisterHANETUser().ShowDialog();
            }
            else
            {
                var frmAddVisitor = new frmAddVisitor();
                if (frmAddVisitor.ShowDialog() == DialogResult.OK)
                {
                    string identityGroupCode = frmAddVisitor.IdentityGroupCode;
                    string plateNumber = frmAddVisitor.PlateNumber;
                    lastHausVistor = frmAddVisitor.lastHausVistor;
                }
            }

        }
        private async void btnPrintQR_Click(object? sender, EventArgs e)
        {
            tblUserLog.SaveLog("Application", $"User Click To Print QR");

            if (lastHausVistor == null)
            {
                MessageBox.Show("Không có thông tin khách đăng ký, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var qrData = await ThirdPartyService.GetQRData(lastHausVistor);
            if (qrData == null || string.IsNullOrEmpty(qrData.QrCode))
            {
                MessageBox.Show("Lấy thông tin không thành công, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                foreach (var lane in lanes)
                {
                    if (lane.lane.type + 1 == (int)EmLaneDirection.IN)
                    {
                        foreach (var item in lane.lane.controlUnits)
                        {
                            if (item.readers.Length > 0)
                            {
                                CardEventArgs ce = new CardEventArgs();
                                ce.DeviceId = item.controlUnitId;
                                ce.ReaderIndex = item.readers[0];
                                ce.PreferCard = lastHausVistor.IdentityCode;
                                lane.printQR(ce, qrData);
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void _MqttClient_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            var data = Encoding.UTF8.GetString(e.Message);
            var topic = e.Topic;
            if (e.Topic.Contains("topic/detected/O2238UV0956"))
            {
                HANETFaceData faceData = Newtonsoft.Json.JsonConvert.DeserializeObject<HANETFaceData>(data);
                if (faceData != null)
                {
                    var identityCode = HANETApi.GetIdentityCodeByPersonId(faceData.person_id);
                    this.Invoke(new Action(() =>
                    {
                        foreach (var item in lanes)
                        {
                            foreach (ControllerInLane controllerInLane in item.lane.controlUnits)
                            {
                                Bdk bdk = (from Bdk _bdk in StaticPool.bdks
                                           where _bdk.Id.ToLower() == controllerInLane.controlUnitId
                                           select _bdk).FirstOrDefault();
                                if (bdk == null)
                                {
                                    continue;
                                }
                                if (bdk.Code == faceData.camera_id)
                                {
                                    lblLoadingStatus.Message = $"{DateTime.Now:HH:mm:ss} Face:{faceData.person_name} - {faceData.person_id} - {faceData.camera_id}";

                                    //lblLoadingStatus.UpdateResultMessage($"{DateTime.Now:HH:mm:ss} Face:{faceData.person_name} - {faceData.person_id} - {faceData.camera_id}", Color.DarkBlue);

                                    CardEventArgs ce = new CardEventArgs();
                                    ce.DeviceId = item.lane.controlUnits[0].controlUnitId;
                                    ce.ReaderIndex = item.lane.controlUnits[0].readers[0];
                                    ce.AllCardFormats.Add(identityCode);
                                    ce.PreferCard = identityCode;
                                    item.OnNewEvent(ce);

                                    break;
                                }
                            }
                        }
                    }));
                }
            }
            else if (e.Topic.Contains("topic/detected/O2238UV1088"))
            {
                HANETPlateData plateData = Newtonsoft.Json.JsonConvert.DeserializeObject<HANETPlateData>(data);
                if (plateData != null)
                {
                    if (string.IsNullOrEmpty(plateData.image))
                    {
                        return;
                    }
                    foreach (var item in lanes)
                    {
                        item.hanetPlateNumber = plateData.code_result;
                        try
                        {
                            item.hanetImg = StaticPool.Base64ToImage(plateData.image.Split(",")[1]);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
        }

        #region Develope mode
        private void btnCheckVersion_Click(object sender, EventArgs e)
        {
            new frmVersions().Show(this);
        }

        private void btnShowSystemLog_Click(object sender, EventArgs e)
        {
            new frmSystemLogs().Show(this);
        }
        private void btnShowConnectionConfig_Click(object sender, EventArgs e)
        {
            new frmConnectionConfig().Show(this);
        }
        #endregion End Develope mode

        private void tToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputEventArgs ex = new InputEventArgs()
            {
                InputType = InputTupe.EmInputType.Exit,
                InputIndex = 1
            };
            Controller_InputEvent(null, ex);
        }
    }
}
