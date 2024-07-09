using IPaking.Ultility;
using iPakrkingv5.Controls;
using iParkingv5.ApiManager.KzParkingv5Apis;
using iParkingv5.ApiManager.KzScaleApis;
using iParkingv5.Controller;
using iParkingv5.Objects;
using iParkingv5.Objects.Databases;
using iParkingv5.Objects.Enums;
using iParkingv5.Objects.Events;
using iParkingv5.Objects.ScaleObjects;
using iParkingv5_window.Usercontrols;
using iParkingv6.ApiManager.KzParkingv3Apis;
using iParkingv6.Objects.Datas;
using Kztek.Scale_net6.Interfaces;
using Kztek.Scale_net6.Objects;
using Kztek.Tool;
using Kztek.Tool.TextFormatingTools;
using Kztek.Tools;
using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using v5_IScale.Forms;
using v5_IScale.Forms.ReportForms;
using static iParkingv5.Controller.ControllerFactory;
using static iParkingv5.Objects.Enums.PrintHelpers;
using Camera = iParkingv6.Objects.Datas.Camera;

namespace v5_IScale
{
    public partial class Form1 : Form
    {
        #region Properties
        public static List<IController> controllers = new List<IController>();
        private static IScale scaleController;
        private List<Lane> activeLanes = new List<Lane>();

        ucCameraView? ucOverView = null;
        ucCameraView? ucMotoLpr = null;
        ucCameraView? ucCarLpr = null;
        private Dictionary<CameraPurposeType.EmCameraPurposeType, List<Camera>> cameras = new Dictionary<CameraPurposeType.EmCameraPurposeType, List<Camera>>();
        private List<Kztek.Cameras.Camera> camBienSoXeMayDuPhongs = new List<Kztek.Cameras.Camera>();
        private List<Kztek.Cameras.Camera> camBienSoOTODuPhongs = new List<Kztek.Cameras.Camera>();

        private readonly SemaphoreSlim semaphoreSlimOnNewEvent = new SemaphoreSlim(1, 1);
        public static string defaultImagePath = Application.StartupPath + @"Resources\defaultImage.png";
        public static Image defaultImg = Image.FromFile(Form1.defaultImagePath);

        private string selectedParkingEventId = string.Empty;
        private string selectedPlateNumber = string.Empty;
        private string weighing_action_id = string.Empty;

        private int printCount = 1;
        #endregion End Properties

        #region Form
        public Form1(List<Lane> activeLanes)
        {
            InitializeComponent();
            this.activeLanes = activeLanes;
            this.Load += Form1_Load;
            this.Shown += Form1_Shown;
            this.FormClosed += Form1_FormClosed;
        }
        private async void Form1_Load(object? sender, EventArgs e)
        {
            var screenBound = Screen.FromControl(this).WorkingArea;
            this.Size = new Size(screenBound.Width, screenBound.Height);
            //this.Size = new Size(1366, 768);
            this.Location = new Point(0, 0);

            InitLaneView();

            await StartControllers();
            await LoadGoodsType();
            DisplayInGridview();

            cbWeighingTypes.SelectedIndex = 0;

            if (AppData.ScaleConfig != null)
            {
                try
                {
                    scaleController = ScaleFactory.CreateScaleController(AppData.ScaleConfig);
                    scaleController.Connect(AppData.ScaleConfig.Comport, AppData.ScaleConfig.Baudrate);
                    scaleController.PollingStart();
                    if (scaleController != null)
                    {
                        scaleController.ScaleEvent += ScaleController_ScaleEvent;
                        scaleController.PollingStart();
                    }
                }
                catch (Exception exx)
                {
                    MessageBox.Show(exx.Message);
                }

            }
            lblAppVersion.Text = this.Text + " - " + Assembly.GetExecutingAssembly().GetName().Version!.ToString();

            lblTime.Width = lblTime.PreferredWidth;
            lblAppVersion.Width = lblAppVersion.PreferredSize.Width;

            this.splitterMain.SplitterDistance = StaticPool.sharedPreferences.SplitterMainPosition > 0 ?
                                                    StaticPool.sharedPreferences.SplitterMainPosition : this.splitterMain.SplitterDistance;
            this.splliterEventList.SplitterDistance = StaticPool.sharedPreferences.SplitterEventDisplayPosition > 0 ?
                                                    StaticPool.sharedPreferences.SplitterEventDisplayPosition : this.splliterEventList.SplitterDistance;
            this.splitterCurrentVehicle.SplitterDistance = StaticPool.sharedPreferences.SplitterCurrentVehiclePosition > 0 ?
                                                    StaticPool.sharedPreferences.SplitterCurrentVehiclePosition : this.splitterCurrentVehicle.SplitterDistance;
            dgvData.ToggleDoubleBuffered(true);
            this.ActiveControl = btnSave;
        }
        private void Form1_Shown(object? sender, EventArgs e)
        {

        }
        private void Form1_FormClosed(object? sender, FormClosedEventArgs e)
        {
            StaticPool.sharedPreferences.SplitterMainPosition = this.splitterMain.SplitterDistance;
            StaticPool.sharedPreferences.SplitterEventDisplayPosition = this.splliterEventList.SplitterDistance;
            StaticPool.sharedPreferences.SplitterCurrentVehiclePosition = this.splitterCurrentVehicle.SplitterDistance;
            NewtonSoftHelper<SharedPreferences>.SaveConfig(StaticPool.sharedPreferences, PathManagement.sharedPreferencesPath());
            Application.Exit();
            Environment.Exit(0);
        }
        #endregion End Form

        #region Controls In Form
        private async void btnGetEventIn_Click(object sender, EventArgs e)
        {
            frmReportIn frm = new frmReportIn(true);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ClearView();
                string selectedPlateNumber = frm.selectedPlateNumber;
                this.Invoke(new Action(() =>
                {
                    txtPlateNumber.Text = selectedPlateNumber;
                }));
                txtPlateNumber.Text = selectedPlateNumber;
                this.selectedParkingEventId = frm.selectedEventId;
                string[] physicalFileIds = frm.fileKeys;

                await ShowParkingEventImage(physicalFileIds);
                await DisplayWeightInfo();
                foreach (DataGridViewRow item in dgvData.Rows)
                {
                    if (item.Cells[0].Value.ToString() == selectedParkingEventId)
                    {
                        dgvData.SelectionChanged -= dgvData_SelectionChanged;
                        dgvData.CurrentCell = item.Cells[1];
                        dgvData.FirstDisplayedScrollingRowIndex = dgvData.SelectedRows[0].Index;
                        dgvData.SelectionChanged += dgvData_SelectionChanged;
                        return;
                    }
                }
            }
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.selectedParkingEventId))
            {
                MessageBox.Show("Hãy chọn xe cần cân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DateTime eventTime = DateTime.Now;
            var imageKey = BaseLane.GetBaseImageKey(Environment.MachineName, "", selectedPlateNumber, eventTime);

            long weight = int.Parse(lblScale.Text);
            if (weight <= 0)
            {
                bool isAcceptScale = MessageBox.Show("Cân nặng <= 0, bạn có chắc chắn muốn lưu thông tin?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
                if (!isAcceptScale)
                {
                    return;
                }
            }
            string weightFormId = ((ListItem)cbGoodsType.SelectedItem).Name;

            var imageKeys = new List<string>(){
                                    imageKey + "_EventInImage.jpeg",
                                    imageKey + "_OVERVIEWSCALE.jpeg",
                                    imageKey + "_VEHICLESCALE.jpeg",};

            var result = await KzScaleApiHelper.CreateScaleEvent(txtPlateNumber.Text, this.selectedParkingEventId,
                                                                 weight, weightFormId,
                                                                 StaticPool.user_name, StaticPool.userId,
                                                                 imageKeys);
            if (result == null)
            {
                MessageBox.Show("Lưu thông tin cân không thành công, vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            RefreshData();
            lblMoney.Text = TextFormatingTool.GetMoneyFormat(result.weighingType.Price.ToString());
            await SaveEventImage(this.ucOverView.GetFullCurrentImage(), this.ucCarLpr.GetFullCurrentImage(), imageKey);
        }

        private async void btnPrint_Click(object sender, EventArgs e)
        {
            var frm = new frmSelectPrintCount();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.printCount = frm.PrintCount;

                var wbPrint = new WebBrowser();
                wbPrint.DocumentCompleted += WbPrint_DocumentCompleted;
                wbPrint.DocumentText = GetPrintContent(await KzScaleApiHelper.GetWeighingActionDetailsByTrafficId(this.selectedParkingEventId));
            }
        }
        private void btnInvoice_Click(object sender, EventArgs e)
        {

        }
        private async void btnPrintInternetInvoice_Click(object sender, EventArgs e)
        {
            var weighingActionDetails = await KzScaleApiHelper.GetWeighingActionDetailsByTrafficId(this.selectedParkingEventId);
           var response = await KzScaleApiHelper.CreateInvoice(weighingActionDetails[^1].Id, true);
            if (string.IsNullOrEmpty(response.id))
            {
                MessageBox.Show("Chưa gửi được thông tin hóa đơn điện tử", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var invoiceData = await AppData.ApiServer.GetInvoiceData(response.id);
            if (invoiceData == null)
            {
                MessageBox.Show("Chưa có thông tin hóa đơn điện tử", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                string pdfContent = invoiceData.fileToBytes;
                byte[] bytes = Convert.FromBase64String(pdfContent);
                if (!Directory.Exists(@"C:\print"))
                {
                    Directory.CreateDirectory(@"C:\print");
                }
                string fileName = (@"C:\print\file" + DateTime.Now.ToString("yyyy_mm_dd_HH_mm_ss") + ".pdf");

                System.IO.FileStream stream =
                    new FileStream(fileName, FileMode.CreateNew);
                System.IO.BinaryWriter writer =
                    new BinaryWriter(stream);
                writer.Write(bytes, 0, bytes.Length);
                writer.Close();
                Process p = new Process
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        CreateNoWindow = true,
                        Verb = "print",
                        UseShellExecute = true,
                        FileName = fileName //put the correct path here
                    }
                };
                p.Start();
                p.WaitForExit();
                //p.Dispose();
                File.Delete(fileName);
            }
            catch (Exception ex)
            {
            }
        }

        private void xeCóGửiHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmReportScaleWithInvoice().ShowDialog();
        }

        private void xeKhôngGửiHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmReportScaleWithoutInvoice().ShowDialog();
        }
        #endregion End Controls In Form

        #region Private Function
        private void InitLaneView()
        {
            this.DoubleBuffered = true;
            var lane = this.activeLanes[0];
            if (lane.cameras == null)
            {
                return;
            }
            foreach (CameraInLane cameraInLane in lane.cameras)
            {
                foreach (Camera cam in StaticPool.cameras)
                {
                    if (cam.Id?.ToLower() == cameraInLane.cameraId)
                    {
                        if (cameras.ContainsKey((CameraPurposeType.EmCameraPurposeType)(cameraInLane.cameraPurpose + 1)))
                        {
                            cameras[(CameraPurposeType.EmCameraPurposeType)(cameraInLane.cameraPurpose + 1)].Add(cam);
                        }
                        else
                        {
                            cameras.Add((CameraPurposeType.EmCameraPurposeType)(cameraInLane.cameraPurpose + 1), new List<Camera>() { cam });
                        }
                    }
                }
            }


            Kztek.Cameras.Camera? mainOverviewCamera = GetCameraConfig(CameraPurposeType.EmCameraPurposeType.MainOverView, cameras);
            if (mainOverviewCamera != null)
            {
                mainOverviewCamera.Name += "-OVERVIEW";
                ucOverView = new ucCameraView();
                ucOverView.StartViewer(mainOverviewCamera, CameraErrorFunc);
                panelCameras.Controls.Add(ucOverView);
                ucOverView.Location = new Point(0);
            }

            Kztek.Cameras.Camera? motorLprCamera = GetCameraConfig(CameraPurposeType.EmCameraPurposeType.MotorLPR, cameras);
            if (motorLprCamera != null)
            {
                motorLprCamera.Name += "-MOTOLPR";
                ucMotoLpr = new ucCameraView();
                ucMotoLpr.StartViewer(motorLprCamera, CameraErrorFunc);
                if (panelCameras.Controls.Count > 0)
                {
                    Control lastControl = panelCameras.Controls[panelCameras.Controls.Count - 1];
                    Point location = new Point(lastControl.Location.X, lastControl.Location.Y + lastControl.Height + 10);
                    panelCameras.Controls.Add(ucMotoLpr);
                    ucMotoLpr.Location = location;
                }
                else
                {
                    panelCameras.Controls.Add(ucMotoLpr);
                    ucMotoLpr.Location = new Point(0);
                }
            }


            Kztek.Cameras.Camera? carLprCamera = GetCameraConfig(CameraPurposeType.EmCameraPurposeType.CarLPR, cameras);
            if (carLprCamera != null)
            {
                carLprCamera.Name += "-CARLPR";
                ucCarLpr = new ucCameraView();
                ucCarLpr.StartViewer(carLprCamera, CameraErrorFunc);
                if (panelCameras.Controls.Count > 0)
                {
                    Control lastControl = panelCameras.Controls[panelCameras.Controls.Count - 1];
                    Point location = new Point(lastControl.Location.X, lastControl.Location.Y + lastControl.Height + 10);
                    panelCameras.Controls.Add(ucCarLpr);
                    ucCarLpr.Location = location;
                }
                else
                {
                    panelCameras.Controls.Add(ucCarLpr);
                    ucCarLpr.Location = new Point(0);
                }
            }
            panelCameras.SizeChanged += PanelCameras_SizeChanged;
        }
        private Kztek.Cameras.Camera? GetCameraConfig(CameraPurposeType.EmCameraPurposeType key, Dictionary<CameraPurposeType.EmCameraPurposeType, List<Camera>> cameras)
        {
            if (cameras.ContainsKey(key))
            {
                if (cameras[key].Count > 1)
                {
                    for (int i = 1; i < cameras[key].Count; i++)
                    {
                        Kztek.Cameras.Camera cam_du_phong = new Kztek.Cameras.Camera();
                        cam_du_phong.ID = cameras[key][i].Id;
                        cam_du_phong.Name = cameras[key][i].Name;
                        cam_du_phong.VideoSource = cameras[key][i].IpAddress;
                        cam_du_phong.HttpPort = int.Parse(cameras[key][i].HttpPort);
                        cam_du_phong.Login = cameras[key][i].Username;
                        cam_du_phong.Password = cameras[key][i].Password;
                        cam_du_phong.Chanel = cameras[key][i].Channel;
                        string _camType = cameras[key][i].GetCameraType() == "HIK" ? "HIKVISION" : cameras[key][i].GetCameraType();
                        cam_du_phong.CameraType = Kztek.Cameras.CameraTypes.GetType(_camType);
                        cam_du_phong.StreamType = Kztek.Cameras.StreamTypes.GetType("H264");
                        cam_du_phong.Resolution = string.IsNullOrEmpty(cameras[key][0].Resolution) ? "1280x720" : cameras[key][i].Resolution;
                        switch (key)
                        {
                            case CameraPurposeType.EmCameraPurposeType.CarLPR:
                                camBienSoOTODuPhongs.Add(cam_du_phong);
                                break;
                            case CameraPurposeType.EmCameraPurposeType.MotorLPR:
                                camBienSoXeMayDuPhongs.Add(cam_du_phong);
                                break;
                            default:
                                break;
                        }
                        cam_du_phong.Start();
                    }
                }
                Kztek.Cameras.Camera cam = new Kztek.Cameras.Camera();
                cam.ID = cameras[key][0].Id;
                cam.Name = cameras[key][0].Name;
                cam.VideoSource = cameras[key][0].IpAddress;
                cam.HttpPort = int.Parse(cameras[key][0].HttpPort);
                cam.Login = cameras[key][0].Username;
                cam.Password = cameras[key][0].Password;
                cam.Chanel = cameras[key][0].Channel;
                string camType = cameras[key][0].GetCameraType() == "HIK" ? "HIKVISION2" : cameras[key][0].GetCameraType();
                cam.CameraType = Kztek.Cameras.CameraTypes.GetType(camType);
                cam.StreamType = Kztek.Cameras.StreamTypes.GetType("H264");
                cam.Resolution = string.IsNullOrEmpty(cameras[key][0].Resolution) ? "1280x720" : cameras[key][0].Resolution;
                return cam;
            }
            return null;
        }
        private void CameraErrorFunc(object sender, string errorString)
        {
            LogHelper.Log(logType: LogHelper.EmLogType.ERROR,
                           doi_tuong_tac_dong: LogHelper.EmObjectLogType.Camera,
                           mo_ta_them: errorString);
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
                lbl.Size = lbl.PreferredSize;

                IController? controller = ControllerFactory.CreateController(bdk);
                if (controller != null)
                {
                    controllers.Add(controller);
                    //lblLoadingStatus.UpdateResultMessage("Đang kết nối đến bộ điều khiển: " + bdk.Name, lblLoadingStatus.BackColor);
                    bool isConnectSuccess = await controller.ConnectAsync();
                    controller.CardEvent += Controller_CardEvent;
                    controller.ErrorEvent += Controller_ErrorEvent;
                    controller.InputEvent += Controller_InputEvent;
                    controller.ConnectStatusChangeEvent += Controller_ConnectStatusChangeEvent;
                    controller.DeviceInfoChangeEvent += Controller_DeviceInfoChangeEvent;
                    //lblLoadingStatus.UpdateResultMessage("Kết nối đến bộ điều khiển: " + bdk.Name + (isConnectSuccess ? "thành công" : "thất bại"), lblLoadingStatus.BackColor);
                }
            }
            lblTime.SendToBack();

            foreach (IController controller in controllers)
            {
                controller.PollingStart();
            }

            //lblLoadingStatus.UpdateResultMessage(string.Empty, lblLoadingStatus.BackColor);
        }
        #endregion End Private Function

        #region Controls In Form
        private void PanelCameras_SizeChanged(object? sender, EventArgs e)
        {
            foreach (Control item in panelCameras.Controls)
            {
                item.Width = panelCameras.Width;
                //- panelCameras.Margin.Left - panelCameras.Margin.Right - panelCameras.Padding.Left - panelCameras.Padding.Right
                //                                - item.Margin.Left - item.Margin.Right - item.Padding.Left - item.Padding.Right;
            }
            for (int i = 0; i < panelCameras.Controls.Count; i++)
            {
                if (i == 0)
                {
                    panelCameras.Controls[i].Location = new Point(0);
                }
                else
                {
                    Control lastControl = panelCameras.Controls[i - 1];
                    Point location = new Point(lastControl.Location.X, lastControl.Location.Y + lastControl.Height + 10);
                    panelCameras.Controls[i].Location = location;
                }
            }
        }
        private async void dgvData_SelectionChanged(object? sender, EventArgs e)
        {
            string trafficId = "";
            string vehicleImage = "";
            string firstScaleImage = dgvData.CurrentRow.Cells[dgvData.ColumnCount - 2].Value.ToString() ?? "";
            string secondScaleImage = dgvData.CurrentRow.Cells[dgvData.ColumnCount - 1].Value.ToString() ?? "";
            if (!string.IsNullOrEmpty(firstScaleImage))
            {
                string[] firstScaleImages = firstScaleImage.Split(";");
                if (firstScaleImages.Length > 1)
                {
                    string firstWeightPath = await MinioHelper.GetImage(firstScaleImages[1]);
                    this.Invoke(new Action(() =>
                    {
                        picFirstScale.LoadAsync(firstWeightPath);
                    }));
                    string vehicleImagePath = await MinioHelper.GetImage(firstScaleImages[0]);
                    this.Invoke(new Action(() =>
                    {
                        picVehicleImageIn.LoadAsync(vehicleImagePath);
                    }));
                }
            }
            if (!string.IsNullOrEmpty(secondScaleImage))
            {
                string[] secondScaleImages = secondScaleImage.Split(";");
                if (secondScaleImages.Length > 1)
                {
                    string tempPath = await MinioHelper.GetImage(secondScaleImages[1]);
                    this.Invoke(new Action(() =>
                    {
                        picSecondScale.LoadAsync(tempPath);
                    }));
                }
            }

            int firstScale = int.Parse(dgvData.CurrentRow.Cells[5].Value.ToString()?.Replace(",", "") ?? "0");
            string secondScaleStr = dgvData.CurrentRow.Cells[7].Value.ToString()?.Replace(",", "") ?? "";
            if (string.IsNullOrEmpty(secondScaleStr))
            {
                lblFirstScale.Text = firstScale.ToString();
                lblSecondScale.Text = "_";
                lblGoodsScale.Text = "_";
                lblMoney.Text = "_";
            }
            else
            {
                int secondScale = int.Parse(secondScaleStr);
                int goodScale = Math.Abs(firstScale - secondScale);

                lblFirstScale.Text = firstScale.ToString();
                lblSecondScale.Text = secondScale.ToString();
                lblGoodsScale.Text = goodScale.ToString();
                lblMoney.Text = "_";
            }
            this.selectedParkingEventId = dgvData.CurrentRow.Cells[0].Value.ToString();
        }
        private void Pic_LoadCompleted(object? sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            PictureBox pictureBox = (sender as PictureBox)!;
            if (e.Error != null)
            {
                pictureBox.Image = defaultImg;
            }
        }
        #endregion End Controls In Form

        #region Event
        private void ScaleController_ScaleEvent(object sender, Kztek.Scale_net6.Events.ScaleEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                if (lblScale.Text != e.Gross.ToString())
                {
                    lblScale.Text = e.Gross.ToString();
                }
            }));
        }

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
        private async void Controller_CardEvent(object sender, CardEventArgs e)
        {
            await semaphoreSlimOnNewEvent.WaitAsync();
            try
            {
                ClearView();
                this.Invoke(new Action(() =>
                {
                    lblLoadingStatus.Text = $"Nhận sự kiện quẹt thẻ READER: {e.ReaderIndex}, CARD: {e.PreferCard} từ bộ điều khiển " + e.DeviceName;
                    lblLoadingStatus.Refresh();
                }));

                var eventInData = await AppData.ApiServer.GetEventIns(e.PreferCard, DateTime.MinValue, DateTime.Now, "", "", "", "");
                if (eventInData != null)
                {
                    if (eventInData.Count > 0)
                    {
                        string selectedPlateNumber = eventInData[0].plateNumber.ToString() ?? "";
                        this.selectedParkingEventId = eventInData[0].id.ToString() ?? "";
                        string[] physicalFileIds = eventInData[0].fileKeys.Split(",") ?? new string[] { };
                        this.Invoke(new Action(() =>
                        {
                            txtPlateNumber.Text = selectedPlateNumber;
                        }));
                        await ShowParkingEventImage(physicalFileIds);
                        await DisplayWeightInfo();
                    }
                }
            }
            finally
            {
                semaphoreSlimOnNewEvent.Release();
            }
        }
        #endregion End Event

        #region Timer
        private void timerUpdateTime_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString(UltilityManagement.timeFormat);
            lblTime.Size = lblTime.PreferredSize;
            lblTime.Refresh();
        }
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
        #endregion End Timer

        #region Private Function
        private async Task ShowImage(string fileKey, PictureBox pic)
        {
            if (!string.IsNullOrEmpty(fileKey))
            {
                string displayPath = await MinioHelper.GetImage(fileKey);
                if (!string.IsNullOrEmpty(displayPath))
                {
                    pic.LoadAsync(displayPath);
                    return;
                }
            }
            pic.Image = defaultImg;
        }
        private async Task LoadGoodsType()
        {
            AppData.WeighingFormCollection.Clear();
            var weighingForms = await KzScaleApiHelper.GetWeighingForms();
            foreach (var item in weighingForms)
            {
                AppData.WeighingFormCollection.Add(item);
                ListItem li = new ListItem()
                {
                    Name = item.Id,
                    Value = item.Name,
                };
                cbGoodsType.Items.Add(li);
            }
            cbGoodsType.DisplayMember = "Value";
            cbGoodsType.SelectedIndex = cbGoodsType.Items.Count > 0 ? 0 : -1;
        }
        private async Task ShowParkingEventImage(string[] physicalFileIds)
        {
            if (physicalFileIds.Length >= 2)
            {
                string displayOverviewInPath = await MinioHelper.GetImage(physicalFileIds[0]);
                string vehicleInPath = await MinioHelper.GetImage(physicalFileIds[1]);
                await ShowImage(physicalFileIds[1], picVehicleImageIn);
            }
            else if (physicalFileIds.Length > 0)
            {
                await ShowImage(physicalFileIds[0], picVehicleImageIn);
                this.Invoke((Delegate)(() =>
                {
                    picVehicleImageIn.Image = defaultImg;
                }));
            }
            else
            {
                this.Invoke((Delegate)(() =>
                {
                    picVehicleImageIn.Image = defaultImg;
                }));
            }
        }
        private async Task DisplayWeightInfo()
        {
            this.Invoke(new Action(() =>
            {
                lblMoney.Text = "";
            }));
            var weighingActionDetails = await KzScaleApiHelper.GetWeighingActionDetailsByTrafficId(this.selectedParkingEventId);
            if (weighingActionDetails == null)
            {
                this.weighing_action_id = string.Empty;
                this.Invoke(new Action(() =>
                {
                    lblFirstScale.Text = "0";
                    lblSecondScale.Text = "0";
                    lblGoodsScale.Text = "0";
                    picFirstScale.Image = defaultImg;
                    picSecondScale.Image = defaultImg;
                }));
            }
            var weighingActionDetailsOrder = weighingActionDetails.OrderBy(x => x.createdUtc).ToList();
            if (weighingActionDetailsOrder.Count > 0)
            {
                this.weighing_action_id = weighingActionDetailsOrder[0].Id;
                string weighing_form_id = weighingActionDetailsOrder[0].WeighingTypeId;

                foreach (var item in cbGoodsType.Items)
                {
                    ListItem li = (ListItem)item;
                    if (li.Name == weighing_form_id)
                    {
                        this.Invoke(new Action(() =>
                        {
                            cbGoodsType.SelectedItem = item;
                        }));
                        break;
                    }
                }
                this.Invoke(new Action(() =>
                {
                    lblFirstScale.Text = weighingActionDetails[0].Weight.ToString();
                    lblSecondScale.Text = weighingActionDetails.Count > 1 ? weighingActionDetails[1].Weight.ToString() : "0";
                    lblGoodsScale.Text = Math.Abs(int.Parse(lblFirstScale.Text) - int.Parse(lblSecondScale.Text)).ToString();
                }));
                //await ShowImage(weighingActionDetails[0].list_image.Split(";")[1], picFirstScale);
                //if (weighingActionDetails.Count > 1)
                //{
                //    await ShowImage(weighingActionDetails[0].list_image.Split(";")[1], picSecondScale);
                //}
            }
            else
            {
                this.weighing_action_id = string.Empty;
                this.Invoke(new Action(() =>
                {
                    lblFirstScale.Text = "0";
                    lblSecondScale.Text = "0";
                    lblGoodsScale.Text = "0";
                    picFirstScale.Image = defaultImg;
                    picSecondScale.Image = defaultImg;
                }));
            }
        }
        public async Task SaveEventImage(Image? overviewImg, Image? vehicleImg, string imageKey)
        {
            var task0 = MinioHelper.UploadPicture(picVehicleImageIn.Image, imageKey + "_EventInImage.jpeg");
            var task1 = MinioHelper.UploadPicture(overviewImg, imageKey + "_OVERVIEWSCALE.jpeg");
            var task2 = MinioHelper.UploadPicture(vehicleImg, imageKey + "_VEHICLESCALE.jpeg");
            await Task.WhenAll(task1, task2);
        }

        private string GetPrintContent(List<WeighingAction> weighingActionDetails)
        {
            string printContent = string.Empty;
            int i = 1;
            if (weighingActionDetails.Count <= 2)
            {
                foreach (var item in weighingActionDetails)
                {
                    string scaleItem = GetPrintContentItem(item, i);
                    printContent += scaleItem;
                    i++;
                }
                if (weighingActionDetails.Count <= 1)
                {
                    printContent += GetPrintContentItem(null, 2);
                    printContent += GetGoodsScaleItem("_");
                }
                else
                {
                    printContent += GetGoodsScaleItem(Math.Abs(weighingActionDetails[0].Weight - weighingActionDetails[1].Weight).ToString("#,0"));
                }
            }
            else
            {
                foreach (var item in weighingActionDetails)
                {
                    string scaleItem = GetPrintContentItem(item, i);
                    printContent += scaleItem;
                    i++;
                }
            }

            string printTemplatePath = PathManagement.appPrintScaleTemplateConfigPath(((EmPrintTemplate)StaticPool.appOption.PrintTemplate).ToString());
            if (File.Exists(printTemplatePath))
            {
                string baseContent = File.ReadAllText(printTemplatePath);
                baseContent = baseContent.Replace("{$content}", printContent);
                baseContent = baseContent.Replace("{$plateNumber}", txtPlateNumber.Text);
                baseContent = baseContent.Replace("{$weightType}", cbWeighingTypes.Text);
                return baseContent;
            }
            else
            {
                MessageBox.Show("Không tìm thấy mẫu in", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return string.Empty;
            }
        }
        private string GetPrintContentItem(WeighingAction? weighingActionDetail, int index)
        {
            if (weighingActionDetail == null)
            {
                return $@"<tr>
                    <td>
                        <span>
                            <center>Lần cân {index}</center>
                        </span>
                    </td>
                    <td>
                        <center><span>__/__/____ __:__</span></center>
                    </td>
                    <td>
                        <center><span><b>_</b></span></center>
                    </td>
                    </tr>";
            }
            else
                return $@"<tr>
                    <td>
                        <span>
                            <center>Lần cân {index}</center>
                        </span>
                    </td>
                    <td>
                        <center><span>{weighingActionDetail.createdUtcTime:dd/MM/yyyy HH:mm:ss}</span></center>
                    </td>
                    <td>
                        <center><span><b>{weighingActionDetail.Weight.ToString("#,0")}</b></span></center>
                    </td>
                    </tr>";
        }
        private string GetGoodsScaleItem(string goodScale)
        {
            return $@" <tr>
                    <td colspan=""2"">
                        <span>
                            <center>Khối lượng hàng</center>
                        </span>
                    </td>
                    <td>
                        <center><b><span>{goodScale}</span></b></center>
                    </td>
                    </tr>";
        }
        private void WbPrint_DocumentCompleted(object? sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                var browser = (WebBrowser)sender!;
                for (int i = 0; i < this.printCount; i++)
                {
                    browser.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void RefreshData()
        {
            AppData.WeighingDetailCollection = new WeighingDetailCollection();
            List<WeighingAction> weighingHistory = null;
            DateTime startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            DateTime endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            weighingHistory = await KzScaleApiHelper.GetWeighingActionDetails(startTime, endTime);
            for (int i = 0; i < weighingHistory.Count; i++)
            {
                AppData.WeighingDetailCollection.Add(weighingHistory[i]);
            }
            this.Invoke(new Action(() =>
            {
                DisplayInGridview();
            }));
        }
        private void DisplayInGridview()
        {
            dgvData.SelectionChanged -= dgvData_SelectionChanged;
            dgvData.Rows.Clear();

            Dictionary<string, List<WeighingAction>> reports = new Dictionary<string, List<WeighingAction>>();

            foreach (WeighingAction item in AppData.WeighingDetailCollection)
            {
                string eventId = item.eventInId;
                if (reports.ContainsKey(eventId))
                {
                    reports[eventId].Add(item);
                }
                else
                {
                    reports.Add(eventId, new List<WeighingAction> { item });
                }
            }

            foreach (KeyValuePair<string, List<WeighingAction>> item in reports)
            {
                var orderData = item.Value.OrderBy(e => e.createdUtcTime).ToList();
                string firstScaleTime = "";
                string secondScaleTime = "";
                string largerThan2TimesScale = "";
                string plateNumber = item.Value[0].plateNumber;
                string firstWeightScale = "";
                string secondWeightScale = "";
                string goodType = "";
                string firstWeightPrice = "";
                string secondWeightPrice = "";

                if (orderData.Count > 0)
                {
                    firstScaleTime = orderData[0].createdUtcTime?.ToString("dd/MM/yyyy HH:mm:ss") ?? "";
                    firstWeightScale = orderData[0].Weight.ToString("#,0");
                    goodType = orderData[0].weighingType.Name;
                    firstWeightPrice = TextFormatingTool.GetMoneyFormat(orderData[0].Charge.ToString());
                }
                if (orderData.Count > 1)
                {
                    secondScaleTime = orderData[1].createdUtcTime?.ToString("dd/MM/yyyy HH:mm:ss") ?? "";
                    secondWeightScale = orderData[1].Weight.ToString("#,0");
                    secondWeightPrice = TextFormatingTool.GetMoneyFormat(orderData[1].Charge.ToString());
                }
                if (orderData.Count > 2)
                {
                    for (int i = 2; i < orderData.Count; i++)
                    {
                        string tempTime = orderData[i].createdUtcTime?.ToString("dd/MM/yyyy HH:mm:ss") ?? "";
                        string tempWeight = orderData[i].Weight.ToString("#,0");
                        largerThan2TimesScale += "Lần " + (i + 1) + " : " + tempTime + " - " + tempWeight + "\r\n";
                    }
                }
                largerThan2TimesScale = largerThan2TimesScale.TrimEnd();
                string userAction = orderData.Count > 0 ? orderData[0].createdBy : "";
                string vehicleImage = "";
                string firstScaleImage = orderData.Count > 0 ? string.Join(";", orderData[0].FileKeys) : "";
                string secondScaleImage = orderData.Count > 1 ? string.Join(";", orderData[1].FileKeys) : "";
                dgvData.Rows.Add(item.Key, dgvData.Rows.Count + 1, firstScaleTime, secondScaleTime,
                                 plateNumber, firstWeightScale, firstWeightPrice, secondWeightScale, secondWeightPrice, largerThan2TimesScale, goodType,
                                 userAction, vehicleImage, firstScaleImage, secondScaleImage);

            }
            dgvData.SelectionChanged += dgvData_SelectionChanged;
            if (dgvData.RowCount > 0)
            {
                dgvData.CurrentCell = dgvData.CurrentRow.Cells[1];
                dgvData_SelectionChanged(null, EventArgs.Empty);
            }
        }
        private void ClearView()
        {
            this.Invoke(new Action(() =>
            {
                lblFirstScale.Text = "0";
                lblSecondScale.Text = "0";
                lblGoodsScale.Text = "0";
                lblMoney.Text = "0";
                picFirstScale.Image = defaultImg;
                picVehicleImageIn.Image = defaultImg;
                picSecondScale.Image = defaultImg;
            }));
        }
        #endregion End Private Function
    }
}
