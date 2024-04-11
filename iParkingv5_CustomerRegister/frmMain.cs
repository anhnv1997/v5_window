using iParkingv5.Controller;
using iParkingv5.Objects;
using iParkingv5.Objects.Events;
using iParkingv5_CustomerRegister.Databases;
using iParkingv5_CustomerRegister.Forms;
using iParkingv5_CustomerRegister.Forms.DataForms;
using iParkingv5_CustomerRegister.Forms.SystemForms;
using iParkingv6.ApiManager.KzParkingv3Apis;
using iParkingv6.Objects.Datas;
using RabbitMQ.Client;
using System.Text;
using static iParkingv5.Controller.ControllerFactory;

namespace iParkingv5_CustomerRegister
{
    public partial class frmMain : Form
    {
        #region Properties
        public static List<IController> controllers = new List<IController>();

        List<Computer>? computers = null;
        private const string controllerEventExchangeName = "ex.ClientIdentityService.ControllerEvent";
        public static string controllerEventInitQueueName = "queue.ControllerEvent";
        #endregion End Properties

        #region Forms
        public frmMain()
        {
            InitializeComponent();
            this.Load += FrmMain_Load;
            this.FormClosing += FrmMain_FormClosing;
        }
        private void FrmMain_FormClosing(object? sender, FormClosingEventArgs e)
        {
            Application.Exit();
            Environment.Exit(0);
        }
        private async void FrmMain_Load(object? sender, EventArgs e)
        {
            ConnectToRabbitMQ();

            computers = await KzParkingApiHelper.GetAllComputer();
            if (computers != null)
            {
                foreach (var computer in computers)
                {
                    string ControllerEventByPcIdRoutingKey = computer.Id;
                    string ControllerEventByPcIdQueueName = controllerEventInitQueueName + " - " + computer.IpAddress + computer.Id;
                    CreateControllerEventRequiredQueue(ControllerEventByPcIdRoutingKey, ControllerEventByPcIdQueueName);
                }
            }

            await StartControllers();
        }
        #endregion End Forms

        #region Controls In Form
        private void btnCusomerRegiser_Click(object sender, EventArgs e)
        {
            new frmRegisterCustomer()
            {
                StartPosition = FormStartPosition.CenterScreen,
            }
            .ShowDialog();
        }
        private void btnVehicle_Click(object sender, EventArgs e)
        {
            new frmRegisterVehicle().ShowDialog();
        }
        private void frmDevice_Click(object sender, EventArgs e)
        {
            new frmRegisterDevicesFinger()
            {
                StartPosition = FormStartPosition.CenterScreen,
            }
            .ShowDialog();
        }
        private void btnRegisterFingerPrint_Click(object sender, EventArgs e)
        {
            new frmRegisterCustomerFinger()
            {
                StartPosition = FormStartPosition.CenterScreen,
            }
            .ShowDialog();
        }
        #endregion End Controls In Form

        #region Public Function

        #endregion End Public Function

        #region Private Function
        private async Task StartControllers()
        {
            foreach (Bdk bdk in StaticPool.bdks)
            {
                if (bdk.Type != (int)EmControllerType.Dahua)
                {
                    continue;
                }
                IController? controller = ControllerFactory.CreateController(bdk);
                if (controller != null)
                {
                    controllers.Add(controller);
                    bool isConnectSuccess = await controller.ConnectAsync();
                    controller.CardEvent += Controller_CardEvent;
                    controller.FingerEvent += Controller_FingerEvent;
                    controller.ErrorEvent += Controller_ErrorEvent;
                    controller.InputEvent += Controller_InputEvent;
                    controller.ConnectStatusChangeEvent += Controller_ConnectStatusChangeEvent;
                    controller.DeviceInfoChangeEvent += Controller_DeviceInfoChangeEvent;
                }
            }
            foreach (IController controller in controllers)
            {
                controller.PollingStart();
            }
        }


        private void Controller_DeviceInfoChangeEvent(object sender, iParkingv5.Objects.Events.DeviceInfoChangeArgs e)
        {
        }
        private void Controller_ConnectStatusChangeEvent(object sender, iParkingv5.Objects.Events.ConnectStatusCHangeEventArgs e)
        {
        }
        private void Controller_InputEvent(object sender, iParkingv5.Objects.Events.InputEventArgs e)
        {
        }
        private void Controller_ErrorEvent(object sender, iParkingv5.Objects.Events.ControllerErrorEventArgs e)
        {
        }
        private void Controller_CardEvent(object sender, iParkingv5.Objects.Events.CardEventArgs e)
        {
            UpdateEventMessage(e.EventTime.ToString("HH:mm:ss") + " Nhận sự kiện quẹt thẻ " + e.PreferCard);
            if (computers != null)
            {
                foreach (var computer in computers)
                {
                    byte[] payLoad = Encoding.ASCII.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(e));
                    controllerEventChannel.BasicPublish(controllerEventExchangeName, computer.Id, null, payLoad);
                }
            }
        }
        private void Controller_FingerEvent(object sender, iParkingv5.Objects.Events.FingerEventArgs e)
        {
            if (e.UserId == "0")
            {
                UpdateEventMessage(e.EventTime.ToString("HH:mm:ss") + " Vân tay chưa được đăng ký ");
            }
            string customerId = tblFingerControlUnit.GetCustomerId(e.DeviceId, e.UserId.ToString());
            if (string.IsNullOrEmpty(customerId))
            {
                return;
            }
            string fingerCustomerCode = tblFingerCustomer.GetFingerCustomeCode(customerId, out bool valid);
            if (!string.IsNullOrWhiteSpace(fingerCustomerCode))
            {
                UpdateEventMessage(e.EventTime.ToString("HH:mm:ss") + " Nhận sự kiện vân tay " + fingerCustomerCode);
                CardEventArgs ce = new CardEventArgs()
                {
                    DeviceId = e.DeviceId,
                    ReaderIndex = e.ReaderIndex,
                    EventTime = e.EventTime,
                    PreferCard = fingerCustomerCode,
                    AllCardFormats = new List<string>() { fingerCustomerCode}
                };

                if (computers != null)
                {
                    foreach (var computer in computers)
                    {
                        byte[] payLoad = Encoding.ASCII.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(ce));
                        controllerEventChannel.BasicPublish(controllerEventExchangeName, computer.Id, null, payLoad);
                    }
                }
            }
        }


        //---RABBITMQ
        public IConnection conn;
        public static IModel controllerEventChannel;
        private void ConnectToRabbitMQ()
        {
            ConnectionFactory factory = new ConnectionFactory
            {
                HostName = StaticPool.serverConfig.RabbitMqUrl,// "192.168.21.140",
                Port = 5672,
                UserName = StaticPool.serverConfig.RabbitMqUsername ,
                Password = StaticPool.serverConfig.RabbitMqPassword,
                VirtualHost = "/"
            };
            conn = factory.CreateConnection();
            controllerEventChannel = conn.CreateModel();
            CreateRequiredQueue();
        }
        public void CreateRequiredQueue()
        {
            controllerEventChannel.ExchangeDeclare(controllerEventExchangeName, "fanout", true, false, null);
        }
        public void CreateControllerEventRequiredQueue(string routingKey, string queueName)
        {
            controllerEventChannel.QueueDeclare(queueName, true, false, false, null);
            controllerEventChannel.QueueBind(queueName, controllerEventExchangeName, routingKey);
        }
        private void UpdateEventMessage(string message)
        {
            lblEventMonitor?.Invoke(new Action(() =>
            {
                lblEventMonitor.Text = message;
            }));
        }
        #endregion End Private Function
    }
}
