using ALS_BacNinh;
using ALSE;
using ALSE.Objects;
using ALSE.UserControls;
using iParkingv5.Objects;
using iParkingv5.Objects.Datas.parking;
using iParkingv6.ApiManager.KzParkingv3Apis;
using System.Collections.Concurrent;

namespace ALS_BacNinh.Forms.SystemForms
{
    public partial class frmMain : Form
    {
        #region PROPERTIES
        public static ConcurrentQueue<CardEventArgs> cardEvents = new ConcurrentQueue<CardEventArgs>();
        public ConcurrentQueue<InputEventArgs> inputEvents = new ConcurrentQueue<InputEventArgs>();
        private ConcurrentQueue<CardEventArgs> cardEventArgses = new ConcurrentQueue<CardEventArgs>();

        List<ucControllerConnection> ucControllerConnections = new List<ucControllerConnection>();

        public static ucGridview<ucControllerConnection>? ucGridviewControllerCollection;
        #endregion END PROPERTIES

        #region FORMS
        public frmMain()
        {
            InitializeComponent();
            this.Load += FrmMain_Load;
        }
        private async void FrmMain_Load(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            AppDatas.controllers = await tblController.GetControllerCollection();

            CreateControllerMonitor();

            AppDatas.controllers.OnItemAdd += Controllers_OnItemAdd;
            AppDatas.controllers.OnItemDelete += Controllers_OnItemDelete;
            AppDatas.controllers.OnItemUpdate += Controllers_OnItemUpdate;

            timerDisplayEvent.Enabled = true;
            this.Cursor = Cursors.Default;
        }
        #endregion END FORMS

        #region CONTROLLER EVENT
        private void Controller_InputEvent(object sender, InputEventArgs e)
        {
            this.inputEvents.Enqueue(e);
            string cmd = $@"INSERT INTO tblAbnomalEvent([datetime], [input], [type])
                                             VALUES('{e.EventTime.ToString("yyyy/MM/dd HH:mm:ss")}', {e.InputIndex}, '{e.InputType}')";
            StaticPool.mdb.ExecuteCommand(cmd);
        }
        private void Controller_ErrorEvent(object sender, ControllerErrorEventArgs e)
        {
        }
        private async void Controller_CardEvent(object sender, CardEventArgs e)
        {
            this.cardEventArgses.Enqueue(e);
            //foreach (string cardNumber in e.AllCardFormats)
            //{
            var identityResponse = await KzParkingApiHelper.GetIdentityByCodeAsync(e.PreferCard);
            Identity? identity = identityResponse.Item1;
            if (identity != null)
            {
                foreach (Controller item in AppDatas.controllers)
                {
                    if (item.id == e.ControllerID)
                    {
                        string cmd = $@"INSERT INTO tblEvent(card_number, customer_name, event_time, is_valid, card_id, reader)
                                                 VALUES('{e.PreferCard}', N'{identity.Code}', '{e.EventTime.ToString("yyyy/MM/dd HH:mm:ss")}', 1, '{identity.Id}', {e.ReaderIndex})";
                        StaticPool.mdb.ExecuteCommand(cmd);
                        bool isOpenSuccess = await item.OpenBarrie(e.ReaderIndex);
                        if (!isOpenSuccess)
                        {
                            isOpenSuccess = await item.OpenBarrie(e.ReaderIndex);
                            if (!isOpenSuccess)
                            {
                                //LOG
                            }
                        }
                    }
                }
                return;
            }
            //}
            string cmd2 = $@"INSERT INTO tblEvent(card_number, customer_name, event_time, is_valid, card_id, reader)
                                             VALUES('{e.PreferCard}', N'', '{e.EventTime.ToString("yyyy/MM/dd HH:mm:ss")}', 0, '', {e.ReaderIndex})";
            StaticPool.mdb.ExecuteCommand(cmd2);
        }
        #endregion END CONTROLLER EVENT

        #region CONTROLLERS_DATA_EVENT
        private void Controllers_OnItemUpdate(object sender)
        {
            Controller? controller = sender as Controller;
            if (controller == null)
            {
                return;
            }
            foreach (ucControllerConnection item in this.ucControllerConnections)
            {
                if (item.controller.id == controller.id)
                {
                    item.UpdateFloor(controller);
                    return;
                }
            }
        }
        private void Controllers_OnItemDelete(object sender)
        {
            Controller? controller = sender as Controller;
            if (controller == null)
            {
                return;
            }
            foreach (ucControllerConnection item in this.ucControllerConnections)
            {
                if (item.controller.id == controller.id)
                {
                    ucGridviewControllerCollection?.Invoke(new Action(() =>
                    {
                        ucGridviewControllerCollection.RemoveItem(item);
                        item.Dispose();
                        panelControllerStatus.Visible = AppDatas.controllers.Count > 0;
                    }));
                    return;
                }
            }
        }
        private void Controllers_OnItemAdd(object sender)
        {
            Controller? controller = sender as Controller;
            if (controller == null)
            {
                return;
            }
            ucControllerConnection uc = new ucControllerConnection(controller);
            this.ucControllerConnections.Add(uc);
            ucGridviewControllerCollection?.Invoke(new Action(() =>
            {
                ucGridviewControllerCollection.AddItem(uc);
                panelControllerStatus.Visible = AppDatas.controllers.Count > 0;
            }));
        }
        #endregion END CONTROLLERS_DATA_EVENT

        private void CreateControllerMonitor()
        {
            ucGridviewControllerCollection = new ucGridview<ucControllerConnection>(ucControllerConnection.GetPreferWidth, 5, 5);
            foreach (Controller item in AppDatas.controllers)
            {
                ucControllerConnection child = new ucControllerConnection(item);
                ucControllerConnections.Add(child);
                ucGridviewControllerCollection.AddItem(child);
                item.CardEvent += Controller_CardEvent;
                item.InputEvent += Controller_InputEvent;
                item.ErrorEvent += Controller_ErrorEvent;
                item.PollingStart();
            }

            panelControllerStatus.Controls.Add(ucGridviewControllerCollection);
            ucGridviewControllerCollection.Dock = DockStyle.Fill;
            panelControllerStatus.Visible = AppDatas.controllers.Count > 0;
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Environment.Exit(0);
        }
        private void miSystemConfig_Click(object sender, EventArgs e)
        {
            new frmSetting().Show();
        }
        private void timerDisplayEvent_Tick(object sender, EventArgs e)
        {
            timerDisplayEvent.Enabled = false;
            if (this.cardEventArgses.TryDequeue(out CardEventArgs ce))
            {
                if (dgvEvent.Rows.Count >= 200)
                {
                    dgvEvent.Rows.Clear();
                    dgvEvent.Rows.Insert(0, dgvEvent.Rows.Count + 1, ce.PreferCard, ce.ReaderIndex, ce.EventTime);
                }
                else
                {
                    dgvEvent.Rows.Insert(0, dgvEvent.Rows.Count + 1, ce.PreferCard, ce.ReaderIndex, ce.EventTime);
                }
            }
            if (this.inputEvents.TryDequeue(out InputEventArgs ie))
            {
                if (dgvEvent.Rows.Count >= 200)
                {
                    dgvEvent.Rows.Clear();
                    dgvEvent.Rows.Insert(0, dgvEvent.Rows.Count + 1, ie.InputType, ie.InputIndex, ie.EventTime);
                }
                else
                {
                    dgvEvent.Rows.Insert(0, dgvEvent.Rows.Count + 1, ie.InputType, ie.InputIndex, ie.EventTime);
                }

            }
            timerDisplayEvent.Enabled = true;
        }
        private void miReportInOut_Click(object sender, EventArgs e)
        {

            frmReport _frmReport = new frmReport();
            _frmReport.Show();
        }
        private void lịchSửMởCưỡngBứcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportInputEvent frm = new frmReportInputEvent();
            frm.Show();
        }
    }
}
