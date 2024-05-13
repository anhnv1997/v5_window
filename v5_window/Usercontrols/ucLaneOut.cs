using IPaking.Ultility;
using iPakrkingv5.Controls;
using iParkingv5.ApiManager.KzParkingv5Apis;
using iParkingv5.ApiManager.KzScaleApis;
using iParkingv5.ApiManager.XuanCuong;
using iParkingv5.Controller;
using iParkingv5.Objects;
using iParkingv5.Objects.Configs;
using iParkingv5.Objects.Databases;
using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Enums;
using iParkingv5.Objects.EventDatas;
using iParkingv5.Objects.Events;
using iParkingv5.Objects.ScaleObjects;
using iParkingv5_window.Forms.DataForms;
using iParkingv5_window.Forms.ReportForms;
using iParkingv5_window.Helpers;
using iParkingv6.Objects.Datas;
using Kztek.Tool;
using Kztek.Tool.TextFormatingTools;
using Kztek.Tools;
using System.Diagnostics;
using v5_IScale.Forms;
using static iParkingv5.Objects.Enums.PrintHelpers;
using static iParkingv5.Objects.Enums.VehicleType;

namespace iParkingv5_window.Usercontrols
{
    public partial class ucLaneOut : UserControl, iLane, IDisposable
    {
        #region PROPERTIES
        public event OnChangeLaneEvent? OnChangeLaneEvent;
        public event OnControlSizeChanged? onControlSizeChangeEvent;
        #region -- Data
        //Thông tin làn
        public Lane lane { get; set; }
        //Thông tin các camera trong làn
        private Dictionary<CameraPurposeType.EmCameraPurposeType, List<Camera>> cameras = new Dictionary<CameraPurposeType.EmCameraPurposeType, List<Camera>>();

        private List<Kztek.Cameras.Camera> camBienSoXeMayDuPhongs = new List<Kztek.Cameras.Camera>();
        private List<Kztek.Cameras.Camera> camBienSoOTODuPhongs = new List<Kztek.Cameras.Camera>();
        #endregion

        #region -- Controls In Lane
        ucCameraView? ucOverView = null;
        ucCameraView? ucMotoLpr = null;
        ucCameraView? ucCarLpr = null;
        #endregion

        #region Config
        private LaneOutShortcutConfig? laneOutShortcutConfig;
        private List<ControllerShortcutConfig>? controllerShortcutConfigs = null;
        private LaneDisplayConfig? laneDisplayConfig = null;
        private bool isLeftToRight = false;
        private bool isTopToBottom = true;
        #endregion

        #region -- Event Properties
        AddEventOutResponse? lastEvent = null;

        private readonly SemaphoreSlim semaphoreSlimOnNewEvent = new SemaphoreSlim(1, 1);
        private readonly SemaphoreSlim semaphoreSlimOnKeyPress = new SemaphoreSlim(1, 1);
        public List<CardEventArgs> lastCardEventDatas { get; set; } = new List<CardEventArgs>();
        public List<InputEventArgs> lastInputEventDatas { get; set; } = new List<InputEventArgs>();
        public static Image defaultImg = Image.FromFile(frmMain.defaultImagePath);
        #endregion

        private ucLastEventInfo? ucTop1Event;
        private ucLastEventInfo? ucTop3Event;
        private ucLastEventInfo? ucTop2Event;
        List<ucLastEventInfo> ucLastEventInfos = new List<ucLastEventInfo>();

        private bool IsAllowDesignRealtime = false;
        private WeighingActionDetail? WeighingActionDetail = null;
        #endregion END PROPERTIES

        #region FORMS
        public ucLaneOut(Lane lane, LaneDisplayConfig? laneDisplayConfig, bool isDisplayLastEvent, bool isScale)
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.isScale = isScale;

            lblLaneName.Text = lane.name;
            lblLaneName.BackColor = Color.DarkRed;
            this.lane = lane;

            LaneDirectionConfig laneDirection = NewtonSoftHelper<LaneDirectionConfig>.DeserializeObjectFromPath(
                                                        PathManagement.appLaneDirectionConfigPath(this.lane.id)) ?? LaneDirectionConfig.CreateDefault();
            switch (laneDirection.displayDirection)
            {
                case LaneDirectionConfig.EmDisplayDirection.Vertical:
                    this.isTopToBottom = true;
                    break;
                case LaneDirectionConfig.EmDisplayDirection.HorizontalLeftToRight:
                    this.isTopToBottom = false;
                    this.isLeftToRight = true;
                    break;
                case LaneDirectionConfig.EmDisplayDirection.HorizontalRightToLeft:
                    this.isTopToBottom = false;
                    this.isLeftToRight = false;
                    break;
                default:
                    break;
            }

            if (this.isTopToBottom)
            {
                panelCameras.Dock = DockStyle.Top;
                splitterCamera.Dock = DockStyle.Top;
            }
            else
            {
                if (this.isLeftToRight)
                {
                    panelCameras.Dock = DockStyle.Left;
                    splitterCamera.Dock = DockStyle.Left;
                }
                else
                {
                    panelCameras.Dock = DockStyle.Right;
                    splitterCamera.Dock = DockStyle.Right;
                }
            }
            panelScaleAction.Visible = isScale;
            this.laneDisplayConfig = laneDisplayConfig;
            this.Load += UcLaneOut_Load;
        }
        private async void UcLaneOut_Load(object? sender, EventArgs e)
        {
            GetShortcutConfig();
            LoadCamera();
            this.Dock = DockStyle.Top;
            //lblResult.MaximumSize = new Size(this.DisplayRectangle.Width, 0);
            //lblResult.MinimumSize = new Size(this.DisplayRectangle.Width, 0);
            lblResult.Padding = new Padding(StaticPool.baseSize);
            lblResult.Height = lblResult.PreferredHeight;
            panelCameras.AutoScroll = true;
            panelCameras.SizeChanged += PanelCameras_SizeChanged;
            splitContainerEventContent.SizeChanged += SplitContainerEventContent_SizeChanged;
            splitContainerMain.MouseDoubleClick += SplitContainerEventContent_MouseDoubleClick;
            lblResult.UpdateResultMessage("HẸN GẶP LẠI", Color.DarkGreen);

            List<string> controllserShortcut = new List<string>();
            if (controllerShortcutConfigs != null)
            {
                foreach (var controllerShortcutConfig in controllerShortcutConfigs)
                {
                    foreach (var item in controllerShortcutConfig.KeySetByRelays)
                    {
                        controllserShortcut.Add(((Keys)item.Value).ToString());
                    }
                }
            }
            toolTip1.SetToolTip(picOpenBarrie, "Mở Barrie " + string.Join(",", controllserShortcut));
            toolTip2.SetToolTip(picRetakePhoto, "Chụp Lại" + ((Keys)laneOutShortcutConfig?.ReSnapshotKey).ToString());
            toolTip3.SetToolTip(picWriteOut, "Ghi Vé Ra " + ((Keys)laneOutShortcutConfig?.WriteOut).ToString());
            toolTipPrint.SetToolTip(picPrint, "In Vé Xe " + ((Keys)laneOutShortcutConfig?.PrintKey).ToString());

            toolTip1.OwnerDraw = true;
            toolTip1.Draw += ToolTip1_Draw;
            toolTip1.Popup += ToolTip1_Popup;

            toolTip2.OwnerDraw = true;
            toolTip2.Draw += ToolTip2_Draw;
            toolTip2.Popup += ToolTip2_Popup;

            toolTip3.OwnerDraw = true;
            toolTip3.Draw += ToolTip3_Draw;
            toolTip3.Popup += ToolTip3_Popup;

            toolTipPrint.OwnerDraw = true;
            toolTipPrint.Draw += ToolTipPrint_Draw;
            toolTipPrint.Popup += ToolTipPrint_Popup;

            picRetakePhoto.MouseEnter += PicRetakePhoto_MouseHover;
            picRetakePhoto.MouseLeave += picSetting_MouseLeave;

            picOpenBarrie.MouseEnter += PicRetakePhoto_MouseHover;
            picOpenBarrie.MouseLeave += picSetting_MouseLeave;

            picWriteOut.MouseEnter += PicRetakePhoto_MouseHover;
            picWriteOut.MouseLeave += picSetting_MouseLeave;

            picPrint.MouseEnter += PicRetakePhoto_MouseHover;
            picPrint.MouseLeave += picSetting_MouseLeave;
            picPrint.Click += btnPrintTicket_Click;

            picLprImage.Image = picLprImage.InitialImage = defaultImg;
            picOverviewImageIn.Image = picOverviewImageIn.InitialImage = defaultImg;
            picVehicleImageIn.Image = picVehicleImageIn.InitialImage = defaultImg;

            picOverviewImageOut.Image = picOverviewImageOut.InitialImage = defaultImg;
            picVehicleImageOut.Image = picVehicleImageOut.InitialImage = defaultImg;

            picLprImageIn.Image = picLprImageIn.InitialImage = defaultImg;
            CreatePanelTop3Event();
            await ShowTop3Events();

            splitContainerMain.BringToFront();

            if (this.isScale)
            {
                await LoadGoodsType();
                cbGoodsType.Refresh();
            }
            else
            {
                panelGoodsType.Visible = false;
            }
            if (((EmPrintTemplate)StaticPool.appOption.PrintTemplate) == EmPrintTemplate.XuanCuong)
            {
                if (File.Exists(PathManagement.appServicesConfigPath))
                {
                    //string[] serviceSupport = File.ReadAllText(PathManagement.appServicesConfigPath).Split(";");
                    //foreach (var item in serviceSupport)
                    //{
                    //    cbNote.Items.Add(item);
                    //}
                    //if (cbNote.Items.Count > 0)
                    //{
                    //    cbNote.SelectedIndex = 0;
                    //    cbNote.Refresh();
                    //}
                    //else
                    //{
                    //    for (int i = 0; i < tableLayoutPanelNote.ColumnCount; i++)
                    //    {
                    //        Control Control = tableLayoutPanelNote.GetControlFromPosition(i, tableLayoutPanelNote.RowCount - 1);
                    //        tableLayoutPanelNote.Controls.Remove(Control);
                    //    }
                    //    tableLayoutPanelNote.RowStyles.RemoveAt(tableLayoutPanelNote.RowCount - 1);
                    //}
                }
                else
                {
                    for (int i = 0; i < tableLayoutPanelNote.ColumnCount; i++)
                    {
                        Control Control = tableLayoutPanelNote.GetControlFromPosition(i, tableLayoutPanelNote.RowCount - 1);
                        tableLayoutPanelNote.Controls.Remove(Control);
                    }
                    tableLayoutPanelNote.RowStyles.RemoveAt(tableLayoutPanelNote.RowCount - 1);
                }
            }
            else
            {
                panelNote.Visible = false;
            }
            try
            {
                this.ActiveControl = panelCameras;
            }
            catch (Exception)
            {
            }
            lblScaleFee.Text = TextFormatingTool.GetMoneyFormat("0");
            DisplayUIConfig();
        }

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public async void OnKeyPress(Keys keys)
        {
            await semaphoreSlimOnKeyPress.WaitAsync();

            try
            {
                if (keys == Keys.F9)
                {
                    this.IsAllowDesignRealtime = !this.IsAllowDesignRealtime;
                    this.Invoke(new Action(() =>
                    {
                        AllowDesignRealtime(this.IsAllowDesignRealtime);
                    }));
                }

                if (laneOutShortcutConfig != null)
                {
                    if ((int)keys == laneOutShortcutConfig.ConfirmPlateKey)
                    {
                        if (txtPlate.Focused)
                        {
                            //Cập nhật biển số xe
                            if (this.lastEvent != null)
                            {
                                string newPlate = string.Empty;
                                this.Invoke(new Action(() =>
                                {
                                    newPlate = txtPlate.Text;
                                }));
                                var isUpdateSuccess = await KzParkingv5ApiHelper.UpdateEventOutPlate(lastEvent.Id, newPlate);
                                if (isUpdateSuccess)
                                {
                                    lblResult.UpdateResultMessage("Ra Lệnh Cập Nhật Biển Số Thành Công", Color.DarkBlue);
                                    if (ucTop1Event != null)
                                    {
                                        ucTop1Event.plateNumber = newPlate;
                                    }
                                    KzScaleApiHelper.UpdatePlate(lastEvent.Id, newPlate);
                                }
                                else
                                {
                                    lblResult.UpdateResultMessage("Cập nhật lỗi, vui lòng thử lại", Color.DarkBlue);
                                }
                            }
                        }
                    }
                    else if ((int)keys == laneOutShortcutConfig.ReserveLane)
                    {
                        if (!string.IsNullOrEmpty(this.lane.reverseLaneId?.ToString()))
                        {
                            //Đảo làn
                            this.Invoke(new Action(() =>
                            {
                                var config = SaveUIConfig();
                                NewtonSoftHelper<LaneDisplayConfig>.SaveConfig(config, PathManagement.appDisplayConfigPath(this.lane.id));
                            }));
                            lblResult.UpdateResultMessage("Ra Lệnh Đảo Làn", Color.DarkBlue);
                            OnChangeLaneEvent?.Invoke(this);
                            return;
                        }
                        else
                        {
                            //Chưa cấu hình làn đảo
                            lblResult.UpdateResultMessage("Chưa có cấu hình làn đảo", Color.DarkBlue);
                        }
                    }
                    else if ((int)keys == laneOutShortcutConfig.WriteOut)
                    {
                        lblResult.UpdateResultMessage("Ra lệnh ghi vé ra", Color.DarkBlue);
                        BtnWriteOut_Click(null, EventArgs.Empty);
                    }
                    else if ((int)keys == laneOutShortcutConfig.ReSnapshotKey)
                    {
                        lblResult.UpdateResultMessage("Ra lệnh chụp lại", Color.DarkBlue);
                        picRetakePhoto?.Invoke(new Action(() =>
                        {
                            BtnReTakePhoto_Click(null, null);
                        }));
                    }
                    else if ((int)keys == laneOutShortcutConfig.PrintKey)
                    {
                        lblResult.UpdateResultMessage("Ra lệnh in vé xe", Color.DarkBlue);
                        picPrint?.Invoke(new Action(() =>
                        {
                            btnPrintTicket_Click(null, null);
                        }));
                    }
                }

                if (controllerShortcutConfigs != null)
                {
                    foreach (var controllerShortcutConfig in controllerShortcutConfigs)
                    {
                        foreach (var item in controllerShortcutConfig.KeySetByRelays)
                        {
                            if (item.Value == (int)keys)
                            {
                                string controllerId = controllerShortcutConfig.ControllerId;
                                int barrieIndex = item.Key;
                                foreach (IController controller in frmMain.controllers)
                                {
                                    if (controller.ControllerInfo.Id.ToLower() == controllerId.ToLower())
                                    {
                                        lblResult.UpdateResultMessage("Ra lệnh mở cửa: " + barrieIndex, Color.DarkBlue);

                                        //Ra lệnh mở cửa
                                        await controller.OpenDoor(100, barrieIndex);

                                        //Lưu lại cảnh báo mở barrie bằng nút nhấn
                                        await ProcessButtonEvent();
                                        //Hiển thị sự kiện MỞ BARRIE
                                        break;
                                    }
                                }

                            }
                        }
                    }
                }
            }
            finally
            {
                semaphoreSlimOnKeyPress.Release();
            }
        }
        #endregion END FORMS

        #region EVENT
        public async Task ExcecuteInputEvent(InputEventArgs ie)
        {
            foreach (ControllerInLane controllerInLane in lane.controlUnits)
            {
                //MessageBox.Show(string.Join(",", controllerInLane.inputs.ToArray()));
                if (controllerInLane.controlUnitId.ToLower() != ie.DeviceId.ToLower())
                {
                    continue;
                }
                if (!controllerInLane.inputs.Contains(ie.InputIndex))
                {
                    //Danh sách đăng ký có không có input của sự kiện ==> Bỏ qua
                    continue;
                }

                switch (ie.InputType)
                {
                    case InputTupe.EmInputType.Loop:
                        if (StaticPool.appOption.LoopDelay > 0)
                        {
                            await Task.Delay(StaticPool.appOption.LoopDelay);
                            lblResult.UpdateResultMessage($"Nhận sự kiên Loop {ie.InputIndex}, chờ {StaticPool.appOption.LoopDelay} ms ", Color.DarkBlue);
                        }
                        await ExcecuteLoopEvent(ie);
                        break;
                    case InputTupe.EmInputType.Exit:
                        await ExcecuteExitEvent(ie);
                        break;
                    case InputTupe.EmInputType.Alarm:
                        break;
                    case InputTupe.EmInputType.CardbeTaken:
                        break;
                    default:
                        break;
                }
                return;
            }
        }

        /// <summary>
        /// Sự kiện xảy ra khi xe đi qua vòng từ
        /// </summary>
        /// <param name="ie"></param>
        /// <returns></returns>
        public async Task ExcecuteLoopEvent(InputEventArgs ie)
        {
            VehicleType? vehicleType = null;
            Customer? customer = null;
            //Danh sách biến sử dụng
            Image? vehicleImg = null;
            List<Image?> optionalImages = new();

            Image? overviewImage = ucOverView?.GetFullCurrentImage();

            lblResult.UpdateResultMessage("Đang kiểm trang thông tin sự kiện loop..." + ie.InputIndex, Color.DarkBlue);
            //Đọc biển số bằng cam ô tô
            string plate = "";
            Image? lprImage = null;
            int retry = 0;
            RegisteredVehicle? registeredVehicle = null;
            bool isAlarm = false;
        LprDetecter:
            {
                if (ucCarLpr != null)
                {
                    BaseLane.GetPlate(this.lane.id, out Image? carImage, out plate, out lprImage, ucCarLpr, camBienSoOTODuPhongs, true);
                    if (string.IsNullOrEmpty(plate))
                    {
                        BaseLane.GetPlate(this.lane.id, out Image? motorImage, out plate, out lprImage, ucMotoLpr, camBienSoXeMayDuPhongs, false);
                        vehicleImg = string.IsNullOrEmpty(plate) ? carImage : motorImage;
                    }
                    else
                    {
                        vehicleImg = carImage;
                    }
                }
                else
                {
                    BaseLane.GetPlate(this.lane.id, out vehicleImg, out plate, out lprImage, ucMotoLpr, camBienSoXeMayDuPhongs, false);
                }
                //registeredVehicle = await KzParkingApiHelper.GetRegisteredVehicle(plate);
                registeredVehicle = (await KzParkingv5ApiHelper.GetRegistedVehilceByPlateAsync(plate)).Item1;

                if (string.IsNullOrEmpty(plate) || registeredVehicle == null)
                {
                    if (retry < StaticPool.appOption.RetakePhotoTimes)
                    {
                        retry++;
                        await Task.Delay(StaticPool.appOption.RetakePhotoDelay);
                        goto LprDetecter;
                    }
                }
                else
                {
                    plate = registeredVehicle.PlateNumber;
                }
            }

            //Hiển thị thông tin hình ảnh phương tiện
            BaseLane.ShowImage(picVehicleImageOut, vehicleImg);
            BaseLane.ShowImage(picOverviewImageOut, overviewImage);
            //Không đọc được biển số hoặc biển số đọc được không hợp lệ, hiểm thị hình ảnh toàn cảnh và kết thúc sự kiện
            if (string.IsNullOrEmpty(plate) || plate.Length < 5)
            {
                BaseLane.ShowImage(picOverviewImageOut, ucOverView?.GetFullCurrentImage());
                lblResult.UpdateResultMessage("Không đọc được thông tin biển số xe", Color.DarkRed);
                return;
            }
            //Đọc thông tin định danh từ thông tin biển số nhận được
            ClearView();
            string imageKey = BaseLane.GetBaseImageKey(this.lane.name, "", plate, ie.EventTime);
            lblResult.UpdateResultMessage("Đang check out..." + plate, Color.DarkBlue);
            BaseLane.ShowImage(picLprImage, lprImage);
            txtPlate.Invoke(new Action(() =>
            {
                txtPlate.Text = plate;
            }));
            if (registeredVehicle == null)
            {
                lblResult.UpdateResultMessage("Phương tiện chưa được đăng ký trong hệ thống", Color.DarkRed);
                return;
            }
            string vehicleTypeId = registeredVehicle.VehicleTypeId;
            string customerId = registeredVehicle.CustomerId;

            //vehicleType = await KzParkingApiHelper.GetVehicleTypeById(vehicleTypeId.ToString());
            vehicleType = (await KzParkingv5ApiHelper.GetVehicleTypeByIdAsync(vehicleTypeId.ToString())).Item1;
            if (!string.IsNullOrEmpty(customerId))
            {
                //customer = await KzParkingApiHelper.GetCustomerById(customerId);
                customer = (await KzParkingv5ApiHelper.GetCustomerByIdAsync(customerId)).Item1;
            }
            List<string> imageKeys = new List<string>()
             {
                     imageKey + "_OVERVIEWOUT.jpeg",
                     imageKey + "_VEHICLEOUT.jpeg",
                     imageKey + "_LPROUT.jpeg",
             };
            AddEventOutResponse? eventOut = null;
            string errorMessage = string.Empty;

        CheckOutNormal:
            {
                eventOut = await KzParkingv5ApiHelper.PostCheckOutAsync(lane.id, plate, null, imageKeys, false);
                if (eventOut == null)
                {
                    goto LOI_HE_THONG;
                }
                if (eventOut.IsSuccess == false)
                {
                    //var errorCode = ApiInternalErrorMessages.GetFromName(responseNormal.metadata.message.code);
                    //if (errorCode == EmApiErrorMessage.PINT_1013 || errorCode == EmApiErrorMessage.PINT_1018 || errorCode == EmApiErrorMessage.PINT_4011)
                    //{
                    //    isAlarm = true;
                    //    string message = ApiInternalErrorMessages.ToString(errorCode);
                    //    frmConfirmOut frmConfirmOut = new frmConfirmOut(plate, message, eventOut.plateNumber ?? "", eventOut.identityId ?? "", eventOut.laneId ?? "", eventOut.fileKeys, eventOut.DatetimeOut ?? DateTime.Now, true, eventOut.charge ?? 0);
                    //    bool isConfirm = frmConfirmOut.ShowDialog() == DialogResult.OK;
                    //    if (isConfirm)
                    //    {
                    //        plate = frmConfirmOut.updatePlate;
                    //        goto CheckOutWithForce;
                    //    }
                    //    else
                    //    {
                    //        ClearView();
                    //        return;
                    //    }
                    //}
                    //else
                    //{
                    //    errorMessage = ApiInternalErrorMessages.ToString(errorCode);
                    //    goto SU_KIEN_LOI;
                    //}
                }
                else
                {
                    if (eventOut.OpenBarrier)
                    {
                        ControllerInLane? controllerInLane = (from _controllerInLane in this.lane.controlUnits
                                                              where _controllerInLane.controlUnitId == ie.DeviceId
                                                              select _controllerInLane).FirstOrDefault();
                        await BaseLane.OpenBarrieByControllerId(ie.DeviceId, controllerInLane, this);
                        await KzParkingv5ApiHelper.CommitOutAsync(eventOut);
                    }
                    else
                    {
                        frmConfirmOut frmConfirmOut = new frmConfirmOut(plate, "Bạn có xác nhận mở barrie?",
                                                                        eventOut.eventIn.PlateNumber ?? "", eventOut.eventIn?.identity?.Id ?? "",
                                                                        eventOut.eventIn?.lane?.id ?? "", eventOut.eventIn?.fileKeys ?? new List<string>(),
                                                                        eventOut.eventIn?.DatetimeIn ?? DateTime.Now, false, eventOut.charge);
                        bool isConfirm = frmConfirmOut.ShowDialog() == DialogResult.OK;
                        if (!isConfirm)
                        {
                            lblResult.UpdateResultMessage("Không xác nhận mở barrie", Color.DarkOrange);
                            return;
                        }
                        else
                        {
                            plate = frmConfirmOut.updatePlate;
                            ControllerInLane? controllerInLane = (from _controllerInLane in this.lane.controlUnits
                                                                  where _controllerInLane.controlUnitId == ie.DeviceId
                                                                  select _controllerInLane).FirstOrDefault();
                            await BaseLane.OpenBarrieByControllerId(ie.DeviceId, controllerInLane, this);
                            eventOut.PlateNumber = plate;
                            await KzParkingv5ApiHelper.CommitOutAsync(eventOut);
                        }
                    }
                    goto SU_KIEN_HOP_LE;
                }
            }
        CheckOutWithForce:
            {
                var responseWithForce = await KzParkingv5ApiHelper.PostCheckOutAsync(lane.id, plate, null, imageKeys, true);
                if (responseWithForce == null)
                {
                    goto LOI_HE_THONG;
                }
                if (eventOut.IsSuccess == false)
                {
                    errorMessage = eventOut.detailCode;
                    //errorMessage = ApiInternalErrorMessages.ToString(ApiInternalErrorMessages.GetFromName(responseWithForce.metadata.message.code));
                    goto SU_KIEN_LOI;
                }
                else
                {
                    if (eventOut.OpenBarrier)
                    {
                        ControllerInLane? controllerInLane = (from _controllerInLane in this.lane.controlUnits
                                                              where _controllerInLane.controlUnitId == ie.DeviceId
                                                              select _controllerInLane).FirstOrDefault();
                        await BaseLane.OpenBarrieByControllerId(ie.DeviceId, controllerInLane, this);
                        await KzParkingv5ApiHelper.CommitOutAsync(eventOut);
                    }
                    else
                    {
                        frmConfirmOut frmConfirmOut = new frmConfirmOut(plate, "Bạn có xác nhận mở barrie?",
                                                                                eventOut.eventIn?.PlateNumber ?? "", eventOut.eventIn?.identity?.Id ?? "",
                                                                                eventOut.eventIn?.lane?.id ?? "", eventOut?.eventIn?.fileKeys ?? new List<string>(),
                                                                                eventOut.eventIn?.DatetimeIn ?? DateTime.Now, false, eventOut.charge);
                        bool isConfirm = frmConfirmOut.ShowDialog() == DialogResult.OK;
                        if (!isConfirm)
                        {
                            lblResult.UpdateResultMessage("Không xác nhận mở barrie", Color.DarkOrange);
                            return;
                        }
                        else
                        {
                            plate = frmConfirmOut.updatePlate;
                            ControllerInLane? controllerInLane = (from _controllerInLane in this.lane.controlUnits
                                                                  where _controllerInLane.controlUnitId == ie.DeviceId
                                                                  select _controllerInLane).FirstOrDefault();
                            await BaseLane.OpenBarrieByControllerId(ie.DeviceId, controllerInLane, this);
                            eventOut.PlateNumber = plate;
                            KzParkingv5ApiHelper.CommitOutAsync(eventOut);
                        }
                    }
                    goto SU_KIEN_HOP_LE;
                }
            }

        LOI_HE_THONG:
            {
                ExcecuteSystemErrorCheckOut();
                return;
            }
        SU_KIEN_LOI:
            {
                ExcecuteUnvalidEvent(null, vehicleType, plate, ie.EventTime, eventOut, errorMessage);
                return;
            }
        SU_KIEN_HOP_LE:
            {
                await ExcecuteValidEvent(null, null, vehicleType, plate, ie.EventTime, overviewImage, vehicleImg,
                                         lprImage, imageKey, eventOut, eventOut.RegisteredVehicle, isAlarm, imageKeys);
                return;
            }
        }

        /// <summary>
        /// Sự kiện xảy ra khi người dùng bấm nút EXIT (nút cứng) để ra lệnh mở barrie
        /// </summary>
        /// <param name="ie"></param>
        /// <returns></returns>
        public async Task ExcecuteExitEvent(InputEventArgs ie)
        {
            lblResult.UpdateResultMessage("Đang kiểm trang thông tin sự kiện exit..." + ie.InputIndex, Color.DarkBlue);
            //--Chưa có sự kiện vào hoặc thời gian từ lúc có sự kiện đến khi bấm mở barrie quá 5s thì lưu sự kiện cảnh báo
            if (lastEvent == null)
            {
                string imageKey = BaseLane.GetBaseImageKey(this.lane.name, "", "", DateTime.Now);
                await KzParkingv5ApiHelper.CreateAlarmAsync("", this.lane.id, "", AbnormalCode.OpenBarrierByButton, imageKey, false, "", "", "", "");
                SaveAllCameraImage(imageKey);
            }
            else if ((DateTime.Now - lastEvent.DatetimeOut)?.TotalSeconds >= StaticPool.appOption.AllowBarrieDelayOpenTime)
            {
                string imageKey = BaseLane.GetBaseImageKey(this.lane.name, "", "", DateTime.Now);
                await KzParkingv5ApiHelper.CreateAlarmAsync(lastEvent.Identity?.Id, this.lane.id, lastEvent.PlateNumber, AbnormalCode.OpenBarrierByButton,
                                                          imageKey, false,
                                                          lastEvent?.IdentityGroup?.Id.ToString() ?? "", "", "", "");
                SaveAllCameraImage(imageKey);
            }
        }

        /// <summary>
        /// Sự kiện xảy ra khi người dùng quẹt thẻ trên đầu đọc, hoặc đầu đọc xa phát hiện thẻ
        /// </summary>
        /// <param name="ce"></param>
        /// <returns></returns>
        public async Task ExcecuteCardEvent(CardEventArgs ce)
        {
            if (!this.CheckNewCardEvent(this.lane, ce, out ControllerInLane? controllerInLane, out int thoiGianCho))
            {
                if (thoiGianCho > 0)
                {
                    lblResult.UpdateResultMessage($"Đang trong thời gian chờ, vui lòng quẹt lại sau {thoiGianCho}s", Color.DarkBlue);
                }
                return;
            }
            lastEvent = null;
            ClearView();
            //Danh sách biến sử dụng
            Image? overviewImg = null;
            Image? vehicleImg = null;
            List<Image?> optionalImages = new();

            DateTime eventTime = DateTime.Now;
            lblResult.UpdateResultMessage("Đang kiểm trang thông tin sự kiện quẹt thẻ..." + ce.PreferCard, Color.DarkBlue);

            //Đọc thông tin định danh theo mã thẻ
            //var identityResponse = await KzParkingApiHelper.GetIdentityByCodeAsync(ce.PreferCard);
            var identityResponse = await KzParkingv5ApiHelper.GetIdentityByCodeAsync(ce.PreferCard);
            Identity? identity = identityResponse.Item1;
            if (identity == null)
            {
                lblResult.UpdateResultMessage("Không đọc được thông tin định danh, vui lòng thử lại", Color.DarkRed);
                return;
            }
            if (identity == null)
            {
                lblResult.UpdateResultMessage("Mã định danh không có trong hệ thống", Color.DarkRed);
                return;
            }
            if (identity.Status == IdentityStatus.Locked)
            {
                lblResult.UpdateResultMessage("Định danh - ngừng sử dụng", Color.DarkRed);
                return;
            }

            lblResult.UpdateResultMessage("Đọc thông tin nhóm định danh...", Color.DarkBlue);
            //IdentityGroup identityGroup = await KzParkingApiHelper.GetIdentityGroupByIdAsync(identity.IdentityGroupId.ToString());
            IdentityGroup identityGroup = (await KzParkingv5ApiHelper.GetIdentityGroupByIdAsync(identity.IdentityGroupId.ToString())).Item1;
            if (identityGroup == null)
            {
                lblResult.UpdateResultMessage("Không đọc được thông tin nhóm định danh, vui lòng thử lại", Color.DarkRed);
                return;
            }

            lblResult.UpdateResultMessage("Đọc thông tin loại phương tiện...", Color.DarkBlue);
            string vehicleTypeId = identityGroup!.VehicleType.Id;
            //VehicleType vehicleType = await KzParkingApiHelper.GetVehicleTypeById(vehicleTypeId.ToString());
            VehicleType vehicleType = (await KzParkingv5ApiHelper.GetVehicleTypeByIdAsync(vehicleTypeId.ToString())).Item1;
            VehicleBaseType vehicleBaseType = vehicleType.Type;
            switch (vehicleBaseType)
            {
                case VehicleBaseType.Unknown:
                    lblResult.UpdateResultMessage("Thông tin loại phương tiện không hợp lệ vui lòng sử dụng thẻ khác", Color.DarkRed);
                    return;
                default:
                    break;
            }

            //Lấy hình ảnh sự kiện
            lblResult.UpdateResultMessage("Lấy hình ảnh sự kiện ra...", Color.DarkBlue);
            foreach (KeyValuePair<CameraPurposeType.EmCameraPurposeType, List<Camera>> kvp in cameras)
            {
                switch (kvp.Key)
                {
                    case CameraPurposeType.EmCameraPurposeType.MainOverView:
                        overviewImg = ucOverView?.GetFullCurrentImage();
                        break;
                    case CameraPurposeType.EmCameraPurposeType.CarLPR:
                        if (vehicleBaseType == VehicleBaseType.Car ||
                            vehicleBaseType == VehicleBaseType.ElectricalCar)
                        {
                            vehicleImg = ucCarLpr?.GetFullCurrentImage();
                        }
                        break;
                    case CameraPurposeType.EmCameraPurposeType.MotorLPR:
                        if (vehicleBaseType != VehicleBaseType.Car &&
                            vehicleBaseType != VehicleBaseType.ElectricalCar)
                        {
                            vehicleImg = ucMotoLpr?.GetFullCurrentImage();
                        }
                        break;
                    case CameraPurposeType.EmCameraPurposeType.SubOverView:
                        break;
                    default:
                        break;
                }
            }

            //Hiển thị hình ảnh sự kiện
            lblResult.UpdateResultMessage("Hiển thị hình ảnh sự kiện...", Color.DarkBlue);
            BaseLane.ShowImage(picOverviewImageOut, overviewImg);
            BaseLane.ShowImage(picVehicleImageOut, vehicleImg);

            //Nếu là sự kiện thẻ thì đọc biển số,
            //còn nếu là sự kiện loop chuyển qua quẹt thẻ thì hiển thị thông tin biển số đã đọc trước đó chứ không đọc lại tránh tốn lượt nhận dạng
            Image? lprImage = GetPlate(ce, ref overviewImg, ref vehicleImg, vehicleBaseType);

            //Đọc thông tin loại phương tiện
            string imageKey = BaseLane.GetBaseImageKey(this.lane.name, ce.PreferCard, ce.PlateNumber, ce.EventTime);
            lblResult.UpdateResultMessage("Đang check out..." + ce.PreferCard, Color.DarkBlue);
            List<string> imageKeys = new List<string>()
                 {
                     imageKey + "_OVERVIEWOUT.jpeg",
                     imageKey + "_VEHICLEOUT.jpeg",
                     imageKey + "_LPROUT.jpeg",
                 };
            bool isMonthCard = identityGroup.Type == IdentityGroupType.Monthly;
            if (isMonthCard)
            {
                await ExcecuteMonthCardEventOut(identity, identityGroup, vehicleType, ce.PlateNumber, imageKeys,
                                               ce, controllerInLane,
                                               overviewImg, vehicleImg, lprImage, imageKey);
            }
            else
            {
                await ExcecuteNonMonthCardEventOut(identity, identityGroup, vehicleType, ce.PlateNumber, imageKeys,
                                                  ce, controllerInLane,
                                                  overviewImg, vehicleImg, lprImage, imageKey);
            }
        }

        private async Task ExcecuteNonMonthCardEventOut(Identity identity, IdentityGroup identityGroup, VehicleType vehicleType, string plateNumber, List<string> imageKeys,
                                                        CardEventArgs ce, ControllerInLane? controllerInLane, Image? overviewImg, Image? vehicleImg, Image? lprImage, string imageKey)
        {
            bool isAlarm = false;
            AddEventOutResponse? eventOut = await KzParkingv5ApiHelper.PostCheckOutAsync(lane.id, plateNumber, identity, imageKeys, false);
            if (eventOut == null)
            {
                goto LOI_HE_THONG;
            }
            AddEventInResponse eventIn = eventOut.eventIn;

            string errorMessage;
            if (eventOut.IsSuccess == false)
            {
                if (eventOut.fields == null)
                {
                    goto LOI_HE_THONG;
                }

                errorMessage = eventOut.fields.Count > 0 ? (eventOut.fields[0].ToString() ?? "") : eventOut.detailCode;
                if (eventIn == null)
                {
                    goto SU_KIEN_LOI;
                }

                if (errorMessage != "Biển số vào ra không khớp".ToUpper())
                {
                    goto SU_KIEN_LOI;
                }

                isAlarm = true;
                //frmConfirmOut frmConfirmOut = new frmConfirmOut(plateNumber, errorMessage, eventIn.PlateNumber ?? "",
                //                                                eventIn.identity?.Id ?? "", this.lane.id,
                //                                                eventIn.fileKeys ?? new List<string>(), eventIn.DatetimeIn ?? DateTime.Now,
                //                                                true, eventOut.charge);
                //bool isConfirm = frmConfirmOut.ShowDialog() == DialogResult.OK;
                bool isConfirm = true;
                if (isConfirm)
                {
                    //plateNumber = frmConfirmOut.updatePlate;
                    //plateNumber = frmConfirmOut.updatePlate;
                    goto CheckOutWithForce;
                }
                else
                {
                    lblResult.UpdateResultMessage("Không xác nhận sự kiện ra", Color.DarkOrange);
                    ClearView();
                    return;
                }
            }
            else
            {
                if (eventOut.OpenBarrier)
                {
                    await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane, this);
                    await KzParkingv5ApiHelper.CommitOutAsync(eventOut);
                }
                else
                {
                    //frmConfirmOut frmConfirmOut = new frmConfirmOut(plateNumber, "Bạn có xác nhận mở barrie?", eventIn.PlateNumber ?? "",
                    //                                                eventIn.identity?.Id ?? "", eventIn.lane?.id ?? "",
                    //                                                eventIn.fileKeys ?? new List<string>(), eventIn.DatetimeIn ?? DateTime.Now,
                    //                                                false, eventOut.charge);
                    //bool isConfirm = frmConfirmOut.ShowDialog() == DialogResult.OK;
                    bool isConfirm = true;
                    if (!isConfirm)
                    {
                        lblResult.UpdateResultMessage("Không xác nhận mở barrie", Color.DarkOrange);
                        return;
                    }
                    else
                    {
                        //plateNumber = frmConfirmOut.updatePlate;
                        eventOut.PlateNumber = plateNumber;
                        await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane, this);
                        await KzParkingv5ApiHelper.CommitOutAsync(eventOut);
                    }
                }
                goto SU_KIEN_HOP_LE;
            }

        CheckOutWithForce:
            {
                eventOut = await KzParkingv5ApiHelper.PostCheckOutAsync(lane.id, plateNumber, identity, imageKeys, true);
                if (eventOut == null)
                {
                    goto LOI_HE_THONG;
                }
                eventIn = eventOut.eventIn;

                if (eventOut.IsSuccess == false)
                {
                    if (eventOut.fields == null)
                    {
                        goto LOI_HE_THONG;
                    }

                    errorMessage = eventOut.fields.Count > 0 ? (eventOut.fields[0].ToString() ?? "") : eventOut.detailCode;
                    goto SU_KIEN_LOI;
                }
                else
                {
                    if (eventOut.OpenBarrier)
                    {
                        await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane, this);
                        await KzParkingv5ApiHelper.CommitOutAsync(eventOut);
                    }
                    else
                    {
                        if (eventIn == null)
                        {
                            goto LOI_HE_THONG;
                        }
                        //frmConfirmOut frmConfirmOut = new frmConfirmOut(plateNumber, "Bạn có xác nhận mở barrie?",
                        //                                                eventIn.PlateNumber ?? "", eventIn?.identity?.Id ?? "",
                        //                                                eventIn?.lane?.id ?? "", eventIn?.fileKeys ?? new List<string>(),
                        //                                                eventIn.DatetimeIn ?? DateTime.Now, false, eventOut.charge);
                        //bool isConfirm = frmConfirmOut.ShowDialog() == DialogResult.OK;
                        bool isConfirm = true;
                        if (!isConfirm)
                        {
                            lblResult.UpdateResultMessage("Không xác nhận mở barrie", Color.DarkOrange);
                            return;
                        }
                        else
                        {
                            //plateNumber = frmConfirmOut.updatePlate;
                            await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane, this);
                            eventOut.PlateNumber = plateNumber;
                            await KzParkingv5ApiHelper.CommitOutAsync(eventOut);
                        }
                    }
                    goto SU_KIEN_HOP_LE;
                }
            }

        LOI_HE_THONG:
            {
                ExcecuteSystemErrorCheckOut();
                return;
            }
        SU_KIEN_LOI:
            {
                ExcecuteUnvalidEvent(identity, vehicleType, ce.PlateNumber, ce.EventTime, eventOut, errorMessage);
                return;
            }
        SU_KIEN_HOP_LE:
            {
                await ExcecuteValidEvent(identity, identityGroup, vehicleType, plateNumber,
                                         ce.EventTime, overviewImg, vehicleImg, lprImage, imageKey,
                                         eventOut, eventOut.RegisteredVehicle, isAlarm, imageKeys);
                return;
            }
        }

        private async Task ExcecuteMonthCardEventOut(Identity identity, IdentityGroup identityGroup, VehicleType vehicleType, string plateNumber, List<string> imageKeys, CardEventArgs ce, ControllerInLane? controllerInLane, Image? overviewImg, Image? vehicleImg, Image? lprImage, string imageKey)
        {
            bool isAlarm = false;
            if (identity.RegisteredVehicles == null)
            {
                lblResult.UpdateResultMessage("Thẻ tháng chưa đăng ký phương tiện", Color.DarkRed);
                return;
            }
            if (identity.RegisteredVehicles.Count == 0)
            {
                lblResult.UpdateResultMessage("Thẻ tháng chưa đăng ký phương tiện", Color.DarkRed);
                return;
            }

            AddEventOutResponse? eventOut = null;
            string errorMessage = string.Empty;
            if (string.IsNullOrEmpty(plateNumber) && identity.RegisteredVehicles.Count == 1)
            {
                bool isConfirm = MessageBox.Show("Không nhận diện được biển số, bạn có muốn cho xe ra khỏi bãi?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes;
                if (isConfirm)
                {
                    isAlarm = true;
                    goto CheckOutWithForce;
                }
                else
                {
                    ClearView();
                    return;
                }
            }
            else
            {
                goto CheckOutNormal;
            }

        CheckOutWithForce:
            {
                eventOut = await KzParkingv5ApiHelper.PostCheckOutAsync(lane.id, plateNumber, identity, imageKeys, true);
                if (eventOut == null)
                {
                    goto LOI_HE_THONG;
                }
                if (eventOut.IsSuccess == false)
                {
                    errorMessage = eventOut.detailCode;
                    //ApiInternalErrorMessages.ToString(ApiInternalErrorMessages.GetFromName(responseWithForce.metadata.message.code));
                    goto SU_KIEN_LOI;
                }
                else
                {
                    if (eventOut.OpenBarrier)
                    {
                        await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane, this);
                        await KzParkingv5ApiHelper.CommitOutAsync(eventOut);
                    }
                    else
                    {
                        frmConfirmOut frmConfirmOut = new frmConfirmOut(plateNumber, "Bạn có xác nhận mở barrie?",
                                                                        eventOut.eventIn?.PlateNumber ?? "", eventOut.eventIn?.identity?.Id ?? "",
                                                                        eventOut.eventIn?.lane?.id ?? "", eventOut.eventIn?.fileKeys,
                                                                        eventOut.eventIn?.DatetimeIn ?? DateTime.Now, false, eventOut.charge);
                        bool isConfirm = frmConfirmOut.ShowDialog() == DialogResult.OK;
                        if (!isConfirm)
                        {
                            lblResult.UpdateResultMessage("Không xác nhận mở barrie", Color.DarkOrange);
                            return;
                        }
                        else
                        {
                            plateNumber = frmConfirmOut.updatePlate;
                            eventOut.PlateNumber = plateNumber;
                            await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane, this);
                            await KzParkingv5ApiHelper.CommitOutAsync(eventOut);
                        }
                    }
                    goto SU_KIEN_HOP_LE;
                }
            }

        CheckOutNormal:
            {
                eventOut = await KzParkingv5ApiHelper.PostCheckOutAsync(lane.id, ce.PlateNumber, identity, imageKeys, false);
                if (eventOut == null)
                {
                    goto LOI_HE_THONG;
                }
                if (eventOut.IsSuccess == false)
                {
                    //var errorCode = ApiInternalErrorMessages.GetFromName(responseNormal.metadata.message.code);
                    //if (errorCode == EmApiErrorMessage.PINT_1013 || errorCode == EmApiErrorMessage.PINT_1018 ||
                    //    errorCode == EmApiErrorMessage.PINT_4011)
                    //{
                    //    isAlarm = true;
                    //    string registerPlate = "";
                    //    string customerName = "";
                    //    string customerAddress = "";
                    //    if (identity.RegisteredVehicles != null)
                    //    {
                    //        if (identity.RegisteredVehicles.Count > 0)
                    //        {
                    //            registerPlate = identity.RegisteredVehicles[0].PlateNumber;
                    //            customerName = identity.RegisteredVehicles[0].Customer?.Name ?? "";
                    //            customerAddress = identity.RegisteredVehicles[0].Customer?.Address ?? "";
                    //        }
                    //    }
                    //    string message = "";
                    //    bool isConfirm = false;
                    //    if (errorCode == EmApiErrorMessage.PINT_4011 && identity.RegisteredVehicles?.Count == 1)
                    //    {
                    //        message = "Biển số không khớp với biển số đăng ký" + "\r\nBạn có muốn cho xe ra khỏi bãi?";
                    //        frmConfirmIn frmConfirmIn = new frmConfirmIn(message, identity?.Code ?? "", identity?.Name ?? "", identityGroup?.Name ?? "",
                    //                                                                      customerName, registerPlate, customerAddress, vehicleImg, overviewImg, plateNumber);
                    //        isConfirm = frmConfirmIn.ShowDialog() == DialogResult.OK;
                    //        if (isConfirm)
                    //        {
                    //            plateNumber = frmConfirmIn.updatePlate;
                    //        }
                    //    }
                    //    else if (errorCode == EmApiErrorMessage.PINT_4011 && identity.RegisteredVehicles?.Count > 1)
                    //    {
                    //        var frmSelectVehicle = new frmSelectVehicle(identity.RegisteredVehicles);
                    //        if (frmSelectVehicle.ShowDialog() == DialogResult.OK)
                    //        {
                    //            isConfirm = true;
                    //            plateNumber = frmSelectVehicle.selectedPlate;
                    //        }
                    //        //message = "Biển số không khớp với biển số đăng ký" + "\r\nBạn có muốn cho xe vào bãi?";
                    //        //isConfirm = new frmConfirmIn(message, identity?.Code ?? "", identity?.Name ?? "", identityGroup?.Name ?? "",
                    //        //                                  customerName, registerPlate, customerAddress, vehicleImg, overviewImg, plateNumber).ShowDialog()
                    //        //                        == DialogResult.OK;
                    //    }
                    //    else
                    //    {
                    //        frmConfirmOut frmConfirmOut = new frmConfirmOut(plateNumber, ApiInternalErrorMessages.ToString(errorCode), eventOut.plateNumber, eventOut.identityId, eventOut.laneId, eventOut.fileKeys, eventOut.DatetimeOut ?? null, true, eventOut.charge ?? 0);
                    //        isConfirm = frmConfirmOut.ShowDialog() == DialogResult.OK;
                    //        if (isConfirm)
                    //        {
                    //            plateNumber = frmConfirmOut.updatePlate;
                    //        }
                    //    }
                    //    if (isConfirm)
                    //    {
                    //        goto CheckOutWithForce;
                    //    }
                    //    else
                    //    {
                    //        ClearView();
                    //        return;
                    //    }
                    //}
                    //else
                    //{
                    //    errorMessage = ApiInternalErrorMessages.ToString(errorCode);
                    //    goto SU_KIEN_LOI;
                    //}
                }
                else
                {
                    if (eventOut.OpenBarrier)
                    {
                        await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane, this);
                        await KzParkingv5ApiHelper.CommitOutAsync(eventOut);
                    }
                    else
                    {
                        frmConfirmOut frmConfirmOut = new frmConfirmOut(plateNumber, "Bạn có xác nhận mở barrie?",
                                                                        eventOut.eventIn?.PlateNumber ?? "", eventOut.eventIn?.identity?.Id ?? "",
                                                                        eventOut.eventIn?.lane?.id ?? "", eventOut.eventIn?.fileKeys ?? new List<string>(),
                                                                        eventOut.eventIn?.DatetimeIn ?? DateTime.Now, false, eventOut.charge);
                        bool isConfirm = frmConfirmOut.ShowDialog() == DialogResult.OK;
                        if (!isConfirm)
                        {
                            lblResult.UpdateResultMessage("Không xác nhận mở barrie", Color.DarkOrange);
                            return;
                        }
                        else
                        {
                            plateNumber = frmConfirmOut.updatePlate;
                            await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane, this);
                            eventOut.PlateNumber = plateNumber;
                            await KzParkingv5ApiHelper.CommitOutAsync(eventOut);
                        }
                    }
                    goto SU_KIEN_HOP_LE;
                }
            }

        LOI_HE_THONG:
            {
                ExcecuteSystemErrorCheckOut();
                return;
            }
        SU_KIEN_LOI:
            {
                ExcecuteUnvalidEvent(identity, vehicleType, ce.PlateNumber, ce.EventTime, eventOut, errorMessage);
                return;
            }
        SU_KIEN_HOP_LE:
            {
                await ExcecuteValidEvent(identity, identityGroup, vehicleType, plateNumber,
                                         ce.EventTime, overviewImg, vehicleImg, lprImage, imageKey,
                                         eventOut, eventOut.RegisteredVehicle, isAlarm, imageKeys);
                return;
            }
        }

        private void ExcecuteSystemErrorCheckOut()
        {
            lblResult.UpdateResultMessage("Không gửi được thông tin xe ra lên hệ thống, vui lòng thử lại sau giây lát", Color.DarkRed);
        }

        private void ExcecuteUnvalidEvent(Identity identity, VehicleType vehicleType, string plate, DateTime eventTime, AddEventOutResponse? eventOut, string errorMessage)
        {
            lblResult.UpdateResultMessage(errorMessage, Color.DarkRed);
            DisplayEventOutInfo(eventOut?.eventIn?.DatetimeIn, eventTime, plate, identity, null, vehicleType, eventOut?.RegisteredVehicle, (long)(eventOut?.charge ?? 0), eventOut?.Customer, null, eventOut?.eventIn?.Note ?? "");
        }

        private async Task ExcecuteValidEvent(Identity identity, IdentityGroup identityGroup, VehicleType vehicleType,
                                              string detectedPlate, DateTime eventTime, Image? overviewImg, Image? vehicleImg,
                                              Image? lprImage, string imageKey, AddEventOutResponse eventOut,
                                              RegisteredVehicle? registeredVehicle, bool isAlarm, List<string> imageKeys)
        {
            txtPlate.Invoke(new Action(() =>
            {
                txtPlate.Text = detectedPlate;
                txtPlate.Refresh();
            }));

            if (eventOut.charge > 0)
            {
                lblResult.UpdateResultMessage("Thu tiền", Color.DarkGreen);
            }
            else
            {
                lblResult.UpdateResultMessage("Hẹn gặp lại", Color.DarkGreen);
            }
            WeighingDetail? weighingDetail = null;
            if (isScale)
            {
                string weightFormId = ((ListItem)cbGoodsType.SelectedItem)?.Name ?? "";
                weighingDetail = await KzScaleApiHelper.CreateScaleEvent(detectedPlate, eventOut?.eventIn?.Id, this.ScaleValue, weightFormId,
                                                                         StaticPool.userId, StaticPool.user_name, imageKeys, eventOut.Id);
                if (weighingDetail != null)
                {
                    this.WeighingActionDetail = weighingDetail.weighing_action_detail[weighingDetail.weighing_action_detail.Count - 1];
                }
            }

            DisplayEventOutInfo(eventOut?.eventIn?.DatetimeIn, eventTime, detectedPlate, identity, identityGroup, vehicleType, eventOut?.RegisteredVehicle, (long)(eventOut?.charge ?? 0), eventOut?.Customer, weighingDetail, eventOut?.eventIn?.Note ?? "");
            ShowEventInData(eventOut);
            BaseLane.DisplayLed(detectedPlate, eventTime, identity, identityGroup, "Hẹn gặp lại", this.lane.id);
            await BaseLane.SaveEventImage(overviewImg, vehicleImg, lprImage, imageKey, false, new List<Image>());
            lastEvent = eventOut;
            UnregisterTurnVehicle(identity, registeredVehicle, identityGroup);
            if (isAlarm)
            {
                await KzParkingv5ApiHelper.CreateAlarmAsync(identity.Id, this.lane.id, detectedPlate, AbnormalCode.InvalidPlateNumber,
                                                          imageKey, false, identityGroup?.Id.ToString(), eventOut?.Customer?.Id, eventOut?.RegisteredVehicle?.Id, "Cảnh báo biển số");
            }
            this.Invoke(new Action(() =>
            {
                for (int i = ucLastEventInfos.Count - 1; i > 0; i--)
                {
                    string customerId = ucLastEventInfos[i - 1].CustomerId;
                    string registerVehicleId = ucLastEventInfos[i - 1].RegisterVehicleId;
                    string laneId = ucLastEventInfos[i - 1].LaneId;
                    string identityId = ucLastEventInfos[i - 1].IdentityId;
                    ucLastEventInfos[i].UpdateEventInfo(ucLastEventInfos[i - 1].eventId, ucLastEventInfos[i - 1].plateNumber,
                                                        ucLastEventInfos[i - 1].vehicleGroupId, ucLastEventInfos[i - 1].IdentityGroupId,
                                                        ucLastEventInfos[i - 1].datetimeIn, ucLastEventInfos[i - 1].picDirs,
                                                        customerId, registerVehicleId, laneId, identityId, false);
                }
                var overviewKey = imageKey + "_OVERVIEWOUT.jpeg";
                var vehicleKey = imageKey + "_VEHICLEOUT.jpeg";
                var vehicleCutKey = imageKey + "_LPROUT.jpeg";
                var imageKeys = new List<string>() { overviewKey, vehicleKey, vehicleCutKey };
                ucLastEventInfos[0].UpdateEventInfo(lastEvent.Id, detectedPlate, identityGroup?.Id.ToString() ?? "",
                                                    identityGroup?.Id.ToString() ?? "", eventTime, imageKeys,
                                                    "", "", this.lane.id, identity?.Id, false);
            }));
            //SendAPIXuanCuong
            if (((EmPrintTemplate)StaticPool.appOption.PrintTemplate) == EmPrintTemplate.XuanCuong)
            {
                //List<string> imageUrl = new List<string>();
                //foreach (var item in imageKeys)
                //{
                //    imageUrl.Add(await MinioHelper.GetImage(item));
                //}
                XuanCuongApiHelper.SendParkingInfo(lastEvent.Id, "out", detectedPlate, eventTime, imageKeys);
            }
            if ((eventOut?.charge ?? 0) > 0)
            {
                await KzParkingv5ApiHelper.CreatePaymentTransaction(eventOut);
                //bool isConfirmSendEinvoie = MessageBox.Show($"Bạn có muốn gửi hóa đơn ({TextFormatingTool.GetMoneyFormat(eventOut.charge.ToString())}) không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
                bool isConfirmSendEinvoie = true;
                if (isConfirmSendEinvoie)
                {
                    var invoiceDto = await KzParkingv5ApiHelper.CreateEinvoice(eventOut.charge, txtPlate.Text,
                                                                                eventOut.eventIn.DatetimeIn ?? DateTime.Now, eventOut.DatetimeOut ?? DateTime.Now,
                                                                                eventOut.Id);
                }
            }
        }

        /// <summary>
        /// Sự kiện xảy ra khi người dùng sử dụng phím tắt để ra lệnh mở barrie
        /// </summary>
        private async Task ProcessButtonEvent()
        {
            //--Chưa có sự kiện vào hoặc thời gian từ lúc có sự kiện đến khi bấm mở barrie quá 5s thì lưu sự kiện cảnh báo
            if (lastEvent == null)
            {
                string imageKey = BaseLane.GetBaseImageKey(this.lane.name, "", "", DateTime.Now);
                await KzParkingv5ApiHelper.CreateAlarmAsync("", this.lane.id, "", AbnormalCode.OpenBarrierByKeyboard, imageKey, false, "", "", "", "");
                SaveAllCameraImage(imageKey);
            }
            else if ((DateTime.Now - lastEvent.DatetimeOut)?.TotalSeconds >= StaticPool.appOption.AllowBarrieDelayOpenTime)
            {
                string imageKey = BaseLane.GetBaseImageKey(this.lane.name, "", "", DateTime.Now);
                await KzParkingv5ApiHelper.CreateAlarmAsync(lastEvent.Identity?.Id, this.lane.id, lastEvent.PlateNumber, AbnormalCode.OpenBarrierByKeyboard,
                                                          imageKey, false,
                                                          lastEvent?.IdentityGroup?.Id.ToString() ?? "", "", "", "");
                SaveAllCameraImage(imageKey);
            }
        }
        #endregion END EVENT

        #region PROPERTIES
        public bool isScale { get; set; }
        public int ScaleValue { get; set; }

        private int printCount = 0;
        #endregion END PROPERTIES

        #region CONTROLS IN FORM

        #region ACTION
        private void cbNote_SelectedIndexChanged(object sender, EventArgs e)
        {
            FocusOnTitle();
        }
        private void CbGoodsType_SelectedIndexChanged(object? sender, EventArgs e)
        {
            FocusOnTitle();
        }

        /// <summary>
        /// Mở giao diện cấu hỉnh làn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picSetting_Click(object sender, EventArgs e)
        {
            List<Camera> cameraList = new List<Camera>();
            foreach (KeyValuePair<CameraPurposeType.EmCameraPurposeType, List<Camera>> item in this.cameras)
            {
                foreach (var cameraItem in item.Value)
                {
                    cameraList.Add(cameraItem);
                }
            }
            new frmLaneSetting(this.lane.id, StaticPool.leds, cameraList, this.lane.controlUnits.ToList(), false).ShowDialog();
            GetShortcutConfig();
            UpdateLaneGUI();
        }

        private async void btnPrintScale_Click(object sender, EventArgs e)
        {
            FocusOnTitle();
            if (lastEvent != null)
            {
                if (string.IsNullOrEmpty(lastEvent.Id))
                {
                    MessageBox.Show("Chưa có thông tin sự kiện cân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var frm = new frmSelectPrintCount();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.printCount = frm.PrintCount;

                    var wbPrint = new WebBrowser();
                    wbPrint.DocumentCompleted += WbPrint_DocumentCompleted;
                    wbPrint.DocumentText = PrintHelper.GetScalePrintContent(await KzScaleApiHelper.GetWeighingActionDetailsByTrafficId(this.lastEvent.Id), lastEvent.PlateNumber, cbGoodsType.Text);
                }
            }
            else
            {
                MessageBox.Show("Chưa có thông tin sự kiện cân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        private void btnPrintScaleOffline_Click(object sender, EventArgs e)
        {
            FocusOnTitle();
            //Ra lệnh gửi hóa đơn điện tử
            if (this.WeighingActionDetail == null)
            {
                MessageBox.Show("Chưa có thông tin cân xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.printCount = 1;
            var wbPrint = new WebBrowser();
            wbPrint.DocumentCompleted += WbPrint_DocumentCompleted;
            wbPrint.DocumentText = PrintHelper.GetPrintScaleInvoiceOfflineContent(this.WeighingActionDetail, lastEvent.PlateNumber);
        }
        private async void btnPrintScaleOnline_Click(object sender, EventArgs e)
        {
            FocusOnTitle();

            //Ra lệnh gửi hóa đơn điện tử
            if (this.WeighingActionDetail == null)
            {
                MessageBox.Show("Chưa có thông tin cân xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.WeighingActionDetail.Price == 0)
            {
                MessageBox.Show("Phương tiện không phát sinh phí cân xe.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //In hóa đơn internet
            string orderId = await KzScaleApiHelper.CreateInvoice(this.WeighingActionDetail.Id, StaticPool.userId, StaticPool.user_name);
            if (string.IsNullOrEmpty(orderId))
            {
                MessageBox.Show("Chưa gửi được thông tin hóa đơn điện tử", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var invoiceData = await KzParkingv5ApiHelper.GetInvoiceData(orderId);
            if (invoiceData == null)
            {
                MessageBox.Show("Chưa có thông tin hóa đơn điện tử", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                string pdfContent = invoiceData.signedFileData;
                PrintHelper.PrintPdf(pdfContent);
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.System, obj: ex);
            }
        }

        private async void btnPrintEInvoiceTicket_Click(object sender, EventArgs e)
        {
            FocusOnTitle();
            if (this.lastEvent == null)
            {
                MessageBox.Show("Chưa có thông tin phương tiện vào ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //In hóa đơn internet
            var invoiceData = await KzParkingv5ApiHelper.GetInvoiceData(this.lastEvent.Id);
            if (invoiceData == null)
            {
                MessageBox.Show("Chưa có thông tin hóa đơn điện tử", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                string pdfContent = invoiceData.signedFileData;
                PrintHelper.PrintPdf(pdfContent);
            }
            catch (Exception ex)
            {
            }
        }
        private void btnPrintTicket_Click(object sender, EventArgs e)
        {
            FocusOnTitle();
            if (lastEvent == null)
            {
                MessageBox.Show("Không có thông tin sự kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string printTemplatePath = PathManagement.appPrintTemplateConfigPath(((EmPrintTemplate)StaticPool.appOption.PrintTemplate).ToString());
            if (File.Exists(printTemplatePath))
            {
                string printContent = PrintHelper.GetParkingPrintContent(File.ReadAllText(printTemplatePath),
                                                      lastEvent.eventIn.DatetimeIn ?? DateTime.Now, lastEvent.DatetimeOut ?? DateTime.Now,
                                                      lastEvent.PlateNumber, TextFormatingTool.GetMoneyFormat(lastEvent.charge.ToString()), lastEvent.charge);
                var wbPrint = new WebBrowser();
                wbPrint.DocumentCompleted += WbPrint_DocumentCompleted;
                wbPrint.DocumentText = printContent;
            }
            else
            {
                MessageBox.Show("Không tìm thấy mẫu in", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        /// <summary>
        /// Ra lệnh mở barrie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnOpenBarrie_Click(object sender, EventArgs e)
        {
            FocusOnTitle();
            foreach (var item in this.lane.controlUnits)
            {
                foreach (IController _item in frmMain.controllers)
                {
                    if (_item.ControllerInfo.Id.ToLower() == item.controlUnitId.ToLower())
                    {
                        for (int i = 0; i < item?.barriers.Length; i++)
                        {
                            bool isOpenSuccess = false;
                            if (!await _item.OpenDoor(100, item.barriers[i]))
                            {
                                isOpenSuccess = await _item.OpenDoor(100, item.barriers[i]);
                            }
                        }
                        break;
                    }
                }
            }

            if (lastEvent == null)
            {
                string imageKey = BaseLane.GetBaseImageKey(this.lane.name, "", "", DateTime.Now);
                await KzParkingv5ApiHelper.CreateAlarmAsync("", this.lane.id, "", AbnormalCode.OpenBarrierByKeyboard, imageKey, false, "", "", "", "");
                SaveAllCameraImage(imageKey);
            }
            else if ((DateTime.Now - lastEvent.DatetimeOut)?.TotalSeconds >= StaticPool.appOption.AllowBarrieDelayOpenTime)
            {
                string imageKey = BaseLane.GetBaseImageKey(this.lane.name, "", "", DateTime.Now);
                await KzParkingv5ApiHelper.CreateAlarmAsync(lastEvent.Identity?.Id, this.lane.id, lastEvent.PlateNumber, AbnormalCode.OpenBarrierByKeyboard,
                                                          imageKey, false,
                                                          lastEvent?.IdentityGroup?.Id.ToString() ?? "", "", "", "");
                SaveAllCameraImage(imageKey);
            }
        }

        /// <summary>
        /// Ghi vé ra=> Chọn vé cần ghi ==> Kích hoạt sự kiện như sự kiện quẹt thẻ
        /// Lưu sự kiện cảnh báo MANUAL EVENT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnWriteOut_Click(object sender, EventArgs e)
        {
            frmReportIn frm = new frmReportIn(true);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //Identity identity = await KzParkingApiHelper.GetIdentityById(frm.selectedIdentityId);
                Identity identity = (await KzParkingv5ApiHelper.GetIdentityByIdAsync(frm.selectedIdentityId)).Item1;
                if (identity != null)
                {
                    foreach (ControllerInLane controllerInLane in lane.controlUnits)
                    {
                        if (controllerInLane.readers.Length == 0)
                        {
                            continue;
                        }

                        CardEventArgs ce = new()
                        {
                            EventTime = DateTime.Now,
                            DeviceId = controllerInLane.controlUnitId,
                            ReaderIndex = controllerInLane.readers[0],
                            AllCardFormats = new List<string>() { identity.Code },
                            PreferCard = identity.Code
                        };

                        await OnNewEvent(ce);
                        //Lưu sự kiện cảnh báo
                        if (lastEvent != null)
                        {
                            string imageKey = BaseLane.GetBaseImageKey(this.lane.name, "", "", DateTime.Now);
                            await KzParkingv5ApiHelper.CreateAlarmAsync(lastEvent.Identity?.Id, this.lane.id, lastEvent.PlateNumber, AbnormalCode.ManualEvent,
                                                                      imageKey, false,
                                                                      lastEvent?.IdentityGroup?.Id.ToString() ?? "", "", "", "");
                            SaveAllCameraImage(imageKey);
                        }
                    }

                }
            }
        }

        /// <summary>
        /// Bấm nút chụp lại hình ảnh ==> Kích hoạt sự kiện như sự kiện LOOP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnReTakePhoto_Click(object sender, EventArgs e)
        {
            foreach (ControllerInLane controllerInLane in lane.controlUnits)
            {
                if (controllerInLane.inputs.Length == 0)
                {
                    continue;
                }
                InputEventArgs ie = new()
                {
                    DeviceId = controllerInLane.controlUnitId,
                    InputIndex = controllerInLane.inputs[0],
                    InputType = InputTupe.EmInputType.Loop,
                    EventTime = DateTime.Now
                };
                await OnNewEvent(ie);
                return;
            }
        }
        #endregion END ACTION

        #region RESPONSIVE
        /// <summary>
        /// Có sự thay đổi kích thước Panel hiển thị camera
        /// Cập nhật lại vị trí camera theo kích thước thực tế
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelCameras_SizeChanged(object? sender, EventArgs e)
        {
            foreach (Control item in panelCameras.Controls)
            {
                item.Width = panelCameras.Width - 5;
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
        #endregion END RESPONSIVE

        #region EFFECT
        private void PicRetakePhoto_MouseHover(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            (sender as PictureBox)!.BackColor = Color.Red;
            (sender as PictureBox)!.Refresh();
        }
        private void picSetting_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            //(sender as PictureBox).BorderStyle = BorderStyle.None;
            (sender as PictureBox).BackColor = Color.DarkRed;
            (sender as PictureBox).Refresh();
        }
        private void Pic_LoadCompleted(object? sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            PictureBox pictureBox = (sender as PictureBox)!;
            if (e.Error != null)
            {
                pictureBox.Image = defaultImg;
            }
        }
        #endregion END EFFECT

        #region OTHER
        /// <summary>
        /// Tự động chỉnh kích thước theo kích thước lưu trong frmMain
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SplitContainerEventContent_MouseDoubleClick(object? sender, MouseEventArgs e)
        {
            if (frmMain.splitContainerMainLocation != null)
            {
                splitContainerMain.SplitterDistance = frmMain.splitContainerMainLocation.NewDistance;
            }
        }
        /// <summary>
        /// Sử dụng để cập nhật giá trị khoảng cách vào frmMain để các làn khác có thể kéo cùng kích thước bằng cách nhấn double click <seealso cref="SplitContainerEventContent_MouseDoubleClick"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SplitContainerEventContent_SizeChanged(object? sender, EventArgs e)
        {
            onControlSizeChangeEvent?.Invoke(this, new ControlSizeChangedEventArgs()
            {
                Type = 1,
                NewX = this.splitContainerMain.Location.X,
                NewY = this.splitContainerMain.Location.Y,
                NewDistance = this.splitContainerMain.SplitterDistance
            });
        }

        #endregion END OTHER

        #region TOOLTIP
        private void ToolTipPrint_Popup(object? sender, PopupEventArgs e)
        {
            e.ToolTipSize = TextRenderer.MeasureText("In vé xe " + ((Keys)laneOutShortcutConfig?.PrintKey).ToString(), new Font("Segoe UI", 16, FontStyle.Bold));
        }
        private void ToolTipPrint_Draw(object? sender, DrawToolTipEventArgs e)
        {
            e.DrawTooltip("In vé xe " + ((Keys)laneOutShortcutConfig?.PrintKey).ToString());
        }

        private void ToolTip3_Popup(object? sender, PopupEventArgs e)
        {
            e.ToolTipSize = TextRenderer.MeasureText("Ghi Vé Ra " + ((Keys)laneOutShortcutConfig?.WriteOut).ToString(), new Font("Segoe UI", 16, FontStyle.Bold));
        }
        private void ToolTip3_Draw(object? sender, DrawToolTipEventArgs e)
        {
            e.DrawTooltip("Ghi Vé Ra " + ((Keys)laneOutShortcutConfig?.WriteOut).ToString());
        }

        private void ToolTip2_Popup(object? sender, PopupEventArgs e)
        {
            e.ToolTipSize = TextRenderer.MeasureText("Chụp Lại" + ((Keys)laneOutShortcutConfig?.ReSnapshotKey).ToString(), new Font("Segoe UI", 16, FontStyle.Bold));
        }
        private void ToolTip2_Draw(object? sender, DrawToolTipEventArgs e)
        {
            e.DrawTooltip("Chụp Lại" + ((Keys)laneOutShortcutConfig?.ReSnapshotKey).ToString());
        }

        private void ToolTip1_Popup(object? sender, PopupEventArgs e)
        {
            List<string> controllserShortcut = new List<string>();
            if (controllerShortcutConfigs != null)
            {
                foreach (var controllerShortcutConfig in controllerShortcutConfigs)
                {
                    foreach (var item in controllerShortcutConfig.KeySetByRelays)
                    {
                        controllserShortcut.Add(((Keys)item.Value).ToString());
                    }

                }
            }
            e.ToolTipSize = TextRenderer.MeasureText("Mở Barrie " + string.Join(",", controllserShortcut), new Font("Segoe UI", 16, FontStyle.Bold));
        }
        private void ToolTip1_Draw(object? sender, DrawToolTipEventArgs e)
        {
            Font customFont = new Font("Arial", 16, FontStyle.Bold);
            e.DrawBackground();
            e.DrawBorder();
            List<string> controllserShortcut = new List<string>();
            if (controllerShortcutConfigs != null)
            {
                foreach (var controllerShortcutConfig in controllerShortcutConfigs)
                {
                    foreach (var item in controllerShortcutConfig.KeySetByRelays)
                    {
                        controllserShortcut.Add(((Keys)item.Value).ToString());
                    }
                }
            }
            e.Graphics.DrawString("Mở Barrie " + string.Join(",", controllserShortcut), customFont, Brushes.Black, new PointF(2, 2));
        }
        #endregion END TOOLTIP

        #endregion END CONTROLS IN FORM

        #region PRIVATE FUNCTION
        private async Task LoadGoodsType()
        {
            var weighingForms = await KzScaleApiHelper.GetWeighingForms() ?? new List<WeighingForm>();
            if (weighingForms != null)
            {
                foreach (var item in weighingForms)
                {
                    ListItem li = new ListItem()
                    {
                        Name = item.Id,
                        Value = item.Name,
                    };
                    cbGoodsType.Items.Add(li);
                }
                cbGoodsType.DisplayMember = "Value";
                cbGoodsType.SelectedIndex = cbGoodsType.Items.Count > 0 ? 0 : -1;
                cbGoodsType.SelectedIndexChanged += CbGoodsType_SelectedIndexChanged;
            }
        }

        private void LoadCamera()
        {
            if (lane.cameras == null)
            {
                return;
            }
            foreach (CameraInLane cameraInLane in lane.cameras)
            {
                foreach (Camera cam in StaticPool.cameras)
                {
                    if (cam.Id.ToLower() == cameraInLane.cameraId)
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
                        string _camType = cameras[key][i].GetCameraType() == "HIK" ? "HIKVISION2" : cameras[key][i].GetCameraType();
                        cam_du_phong.CameraType = Kztek.Cameras.CameraTypes.GetType(_camType);
                        cam_du_phong.StreamType = Kztek.Cameras.StreamTypes.GetType("H264");
                        cam_du_phong.Resolution = string.IsNullOrEmpty(cameras[key][0].Resolution) ? "1280x720" : cameras[key][i].Resolution;
                        cam_du_phong.Start();
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
        }

        private void CreatePanelTop3Event()
        {
            panel11.Dock = DockStyle.Fill;
            panel11.Location = new Point(0, 36);
            panel11.Name = "panel9";
            panel11.Size = new Size(539, 123);
            panel11.TabIndex = 8;

            // 
            // label2
            // 
            //label2.Dock = DockStyle.Top;
            //label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            //label2.Location = new Point(0, 0);
            //label2.Name = "label2";
            //label2.Size = new Size(539, 36);
            //label2.TabIndex = 7;
            //label2.Text = "Các lượt xe vào gần đây";
            //label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ucEventCount1
            // 
            ucEventCount1.Dock = DockStyle.Left;
            ucEventCount1.Location = new Point(0, 0);
            ucEventCount1.Name = "ucEventCount1";
            ucEventCount1.Size = new Size(225, 161);
            ucEventCount1.TabIndex = 7;

            ucTop3Event = new ucLastEventInfo(false);
            ucTop2Event = new ucLastEventInfo(true);
            ucTop1Event = new ucLastEventInfo(true);
            ucTop1Event.Size = ucTop2Event.Size = ucTop3Event.Size = panel11.Width > 750 ? new Size(250, 0) : new Size(125, 0);

            panel11.Controls.Add(ucTop3Event);
            panel11.Controls.Add(ucTop2Event);
            panel11.Controls.Add(ucTop1Event);
            // 
            // ucTop3Event
            // 
            ucTop3Event.BackColor = SystemColors.ButtonHighlight;
            ucTop3Event.Dock = DockStyle.Left;
            ucTop3Event.Location = new Point(400, 0);
            ucTop3Event.Name = "ucTop3Event";
            ucTop3Event.Padding = new Padding(0);
            ucTop3Event.TabIndex = 6;
            // 
            // ucTop2Event
            // 
            ucTop2Event.BackColor = SystemColors.ButtonHighlight;
            ucTop2Event.Dock = DockStyle.Left;
            ucTop2Event.Location = new Point(200, 0);
            ucTop2Event.Name = "ucTop2Event";
            ucTop2Event.Padding = new Padding(0);
            ucTop2Event.TabIndex = 6;
            // 
            // ucTop1Event
            // 
            ucTop1Event.BackColor = SystemColors.ButtonHighlight;
            ucTop1Event.Dock = DockStyle.Left;
            ucTop1Event.Location = new Point(0, 0);
            ucTop1Event.Name = "ucTop1Event";
            ucTop1Event.Padding = new Padding(0);
            ucTop1Event.TabIndex = 6;

            ucLastEventInfos.Add(ucTop1Event);
            ucLastEventInfos.Add(ucTop2Event);
            ucLastEventInfos.Add(ucTop3Event);
        }
        private async Task ShowTop3Events()
        {
            DateTime startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                        0, 0, 0);
            DateTime endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                            23, 59, 59);
            //Tuple<List<EventOutReport>, int, int> top3Event = await KzParkingApiHelper.GetEventOuts("", startTime, endTime, "", "", this.lane.id, 1, 3);
            var top3Event = await KzParkingv5ApiHelper.GetEventOuts("", startTime, endTime, "", "", this.lane.id, "", 1, 3);
            if (top3Event != null)
            {
                for (int i = 0; i < top3Event.Rows.Count; i++)
                {
                    string id = top3Event.Rows[i]["id"].ToString() ?? "";
                    string plateNumber = top3Event.Rows[i]["platenumber"].ToString() ?? "";
                    string vehicleGroupId = "";
                    string cardGroupId = top3Event.Rows[i]["identitygroupid"].ToString() ?? "";
                    DateTime dateTimeIn = DateTime.Parse(top3Event.Rows[i]["eventincreatedutc"].ToString()).AddHours(7);
                    List<string> picDirs = top3Event.Rows[i]["filekeys"].ToString()?.Split(",").ToList() ?? new List<string>();
                    string customerId = "";
                    string registerVehicleId = "";
                    string laneId = this.lane.id;
                    string identityId = top3Event.Rows[i]["identityid"].ToString() ?? "";
                    ucLastEventInfos[i].UpdateEventInfo(id, plateNumber, vehicleGroupId, cardGroupId, dateTimeIn, picDirs,
                                                        customerId, registerVehicleId, laneId, identityId, false);

                }
            }
        }

        private void AllowDesignRealtime(bool isAllow)
        {
            splitContainerMain.IsSplitterFixed = !isAllow;
            splitContainerEventContent.IsSplitterFixed = !isAllow;
            splitterCamera.Enabled = isAllow;
            splitterEventInfoWithCamera.Enabled = isAllow;
        }
        private void FocusOnTitle()
        {
            this.ActiveControl = lblLaneName;
        }
        private void WbPrint_DocumentCompleted(object? sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                var browser = (WebBrowser)sender!;
                if (this.printCount == 0)
                {
                    this.printCount = 1;
                }
                for (int i = 0; i < this.printCount; i++)
                {
                    browser.Print();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void UpdateLaneGUI()
        {
            LaneDirectionConfig laneDirection = NewtonSoftHelper<LaneDirectionConfig>.DeserializeObjectFromPath(
                                                                    PathManagement.appLaneDirectionConfigPath(this.lane.id)) ?? LaneDirectionConfig.CreateDefault();
            switch (laneDirection.displayDirection)
            {
                case LaneDirectionConfig.EmDisplayDirection.Vertical:
                    if (!this.isTopToBottom)
                    {
                        this.isTopToBottom = true;
                        panelCameras.Dock = DockStyle.Top;
                        splitterCamera.Dock = DockStyle.Top;
                        panelCameras.Height = 200;
                    }
                    break;
                case LaneDirectionConfig.EmDisplayDirection.HorizontalLeftToRight:
                    if (!this.isLeftToRight || this.isTopToBottom)
                    {
                        this.isTopToBottom = false;
                        this.isLeftToRight = true;
                        panelCameras.Width = 200;
                        panelCameras.Dock = DockStyle.Left;
                        splitterCamera.Dock = DockStyle.Left;
                    }
                    break;
                case LaneDirectionConfig.EmDisplayDirection.HorizontalRightToLeft:
                    if (this.isLeftToRight || this.isTopToBottom)
                    {
                        this.isTopToBottom = false;
                        this.isLeftToRight = false;
                        panelCameras.Width = 200;
                        panelCameras.Dock = DockStyle.Right;
                        splitterCamera.Dock = DockStyle.Right;
                    }
                    break;
                default:
                    break;
            }
        }

        private void ClearView()
        {
            this.Invoke(new Action(() =>
            {
                dgvEventContent.Rows.Clear();

                picOverviewImageIn.Image = picVehicleImageIn.Image =
                picLprImage.Image = picOverviewImageOut.Image =
                picVehicleImageOut.Image = picLprImageIn.Image = defaultImg;

                lblPlateIn.Text = txtPlate.Text = string.Empty;

                lblResult.UpdateResultMessage("", Color.DarkBlue);

                lblScaleFee.Text = TextFormatingTool.GetMoneyFormat("0");

                lblNote1.Text = "";
                lblNote2.Text = "";

                this.WeighingActionDetail = null;
                FocusOnTitle();
            }));
        }
        private Image? GetPlate(CardEventArgs ce, ref Image? overviewImg, ref Image? vehicleImg, VehicleBaseType vehicleBaseType)
        {
            Image? lprImage = null;
            lblResult.UpdateResultMessage("Lấy hình ảnh sự kiện...", Color.DarkBlue);
            overviewImg = ucOverView?.GetFullCurrentImage();

            lblResult.UpdateResultMessage("Đọc biển số...", Color.DarkBlue);
            string plate = string.Empty;
            switch (vehicleBaseType)
            {
                case VehicleBaseType.Car:
                case VehicleBaseType.ElectricalCar:
                    BaseLane.GetPlate(this.lane.id, out vehicleImg, out plate, out lprImage, ucCarLpr, camBienSoOTODuPhongs, true);
                    break;
                default:
                    BaseLane.GetPlate(this.lane.id, out vehicleImg, out plate, out lprImage, ucMotoLpr, camBienSoXeMayDuPhongs, false);
                    break;
            }
            ce.PlateNumber = plate;
            lblResult.UpdateResultMessage("Hiển thị hình ảnh sự kiện...", Color.DarkBlue);
            BaseLane.ShowImage(picOverviewImageOut, overviewImg);
            BaseLane.ShowImage(picVehicleImageOut, vehicleImg);
            BaseLane.ShowImage(picLprImage, lprImage);

            txtPlate.Invoke(new Action(() =>
            {
                txtPlate.Text = ce.PlateNumber;
                txtPlate.Refresh();
            }));
            return lprImage;
        }

        private void ShowEventInData(AddEventOutResponse eventOut)
        {
            if (eventOut == null) return;
            if (eventOut.eventIn == null) return;
            if (eventOut.eventIn.fileKeys == null) return;
            lblPlateIn.Text = eventOut.eventIn.PlateNumber;

            this.Invoke(new Action(async () =>
            {
                string displayOverviewInPath = eventOut.eventIn.fileKeys.Where(e => e.Contains("_OVERVIEWIN")).FirstOrDefault() ?? "";
                string vehicleInPath = eventOut.eventIn.fileKeys.Where(e => e.Contains("_VEHICLEIN")).FirstOrDefault() ?? "";
                string lprCutPath = eventOut.eventIn.fileKeys.Where(e => e.Contains("_LPRIN")).FirstOrDefault() ?? "";
                picOverviewImageIn.LoadAsync(await MinioHelper.GetImage(displayOverviewInPath));
                picVehicleImageIn.LoadAsync(await MinioHelper.GetImage(vehicleInPath));
                picLprImageIn.LoadAsync(await MinioHelper.GetImage(lprCutPath));
            }));

        }

        private void SaveAllCameraImage(string imageKey)
        {
            //--Lưu hình ảnh sự kiện
            //Danh sách biến sử dụng
            Image? overviewImg = null;
            Image? carVehicleImage = null;
            Image? motorVehicleImage = null;
            foreach (KeyValuePair<CameraPurposeType.EmCameraPurposeType, List<Camera>> kvp in cameras)
            {
                switch (kvp.Key)
                {
                    case CameraPurposeType.EmCameraPurposeType.MainOverView:
                        overviewImg = ucOverView?.GetFullCurrentImage();
                        break;
                    case CameraPurposeType.EmCameraPurposeType.CarLPR:
                        carVehicleImage = ucCarLpr?.GetFullCurrentImage();
                        break;
                    case CameraPurposeType.EmCameraPurposeType.MotorLPR:
                        motorVehicleImage = ucMotoLpr?.GetFullCurrentImage();
                        break;
                    default:
                        break;
                }
            }

            _ = MinioHelper.UploadPicture(overviewImg, imageKey + "_OVERVIEWOUT.jpeg");
            if (carVehicleImage != null)
            {
                _ = MinioHelper.UploadPicture(carVehicleImage, imageKey + "_VEHICLEOUT.jpeg");
            }
            else
            {
                _ = MinioHelper.UploadPicture(motorVehicleImage, imageKey + "_VEHICLEOUT.jpeg");
            }
        }

        private void DisplayEventOutInfo(DateTime? timeIn, DateTime timeOut, string plateNumber, Identity identity, IdentityGroup? identityGroup, VehicleType vehicle,
                                         RegisteredVehicle? registerVehicle, long fee, Customer? customer, WeighingDetail? weighingDetail = null, string note = "")
        {
            LaneDirectionConfig laneDirection = NewtonSoftHelper<LaneDirectionConfig>.DeserializeObjectFromPath(
                                                      PathManagement.appLaneDirectionConfigPath(this.lane.id)) ?? LaneDirectionConfig.CreateDefault();
            dgvEventContent!.Invoke(new Action(() =>
            {
                dgvEventContent.Columns[0].Visible = laneDirection.IsDisplayTitle;
                if (!string.IsNullOrEmpty(note))
                {
                    string[] noteArray = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(note)!.ToArray();// note.Split(";");
                    lblNote1.Text = noteArray.Length > 0 ? noteArray[0] : "";
                    lblNote2.Text = noteArray.Length > 1 ? noteArray[1] : "";
                }

                dgvEventContent.Rows.Clear();

                dgvEventContent.Rows.Add("Phí gửi xe", TextFormatingTool.GetMoneyFormat(fee.ToString()));
                if (this.Width < 1500)
                {
                    dgvEventContent.Rows[dgvEventContent.RowCount - 1].DefaultCellStyle.Font = new Font(dgvEventContent.DefaultCellStyle.Font.Name,
                                                                                                        20, FontStyle.Bold);
                }
                else
                {
                    dgvEventContent.Rows[dgvEventContent.RowCount - 1].DefaultCellStyle.Font = new Font(dgvEventContent.DefaultCellStyle.Font.Name,
                                                                                                        dgvEventContent.DefaultCellStyle.Font.Size * 3, FontStyle.Bold);
                }
                dgvEventContent.Rows[dgvEventContent.RowCount - 1].DefaultCellStyle.ForeColor = Color.Red;

                if (weighingDetail != null)
                {
                    if (weighingDetail.weighing_action_detail != null)
                    {
                        lblScaleFee.Text = TextFormatingTool.GetMoneyFormat(weighingDetail.weighing_action_detail[^1].Price.ToString());
                    }
                }

                if (timeIn != null)
                {
                    TimeSpan ParkingTime = (TimeSpan)(timeOut - timeIn)!;
                    string formattedTime = "";
                    if (ParkingTime.TotalDays > 1)
                    {
                        formattedTime = string.Format("{0} ngày {1} giờ {2} phút", ParkingTime.Days, ParkingTime.Hours, ParkingTime.Minutes, ParkingTime.Seconds);
                    }
                    else
                    {
                        formattedTime = string.Format("{0} giờ {1} phút", ParkingTime.Hours, ParkingTime.Minutes, ParkingTime.Seconds);
                    }
                    dgvEventContent.Rows.Add("Thời gian lưu bãi", formattedTime);

                    dgvEventContent.Rows.Add("Giờ Vào", timeIn?.ToString("dd/MM/yyyy HH:mm:ss"));
                    dgvEventContent.Rows.Add("Giờ ra", timeOut.ToString("dd/MM/yyyy HH:mm:ss"));
                }
                else
                {
                    dgvEventContent.Rows.Add("Thời gian ra", timeOut.ToString("dd/MM/yyyy HH:mm:ss"));
                }
                dgvEventContent.Rows.Add("Loại Xe", VehicleType.GetDisplayStr(vehicle.Type));

                dgvEventContent.Rows.Add("Vé Xe", identity?.Code ?? "" + " - " + identity?.Code ?? "");

                if (customer != null)
                {
                    dgvEventContent.Rows.Add("Khách hàng", customer.Name + " " + customer.Address);
                    dgvEventContent.Rows.Add("SĐT", customer.PhoneNumber);
                }
                if (registerVehicle != null)
                {
                    dgvEventContent.Rows.Add("BSĐK", registerVehicle.Name + " / " + registerVehicle.PlateNumber);
                    dgvEventContent.Rows.Add("Hết hạn", registerVehicle.ExpireTime?.ToString("dd/MM/yyyy HH:mm:ss"));
                }

                dgvEventContent.Rows.Add("Nhóm định danh", identityGroup?.Name);
                dgvEventContent.BringToFront();
                dgvEventContent.CurrentCell = null;
                this.ActiveControl = lblLaneName;
            }));
        }
        public async void UnregisterTurnVehicle(Identity? identity, RegisteredVehicle? vehicle, IdentityGroup identityGroup)
        {
            return;
            //if (identity == null || vehicle == null || identityGroup == null)
            //{
            //    return;
            //}
            //if (identityGroup != null)
            //{
            //    if (identityGroup.Type == IdentityGroupType.Daily)
            //    {
            //        if (vehicle == null)
            //        {
            //            return;
            //        }
            //        if (vehicle.IdentityIds != null)
            //        {
            //            vehicle.IdentityIds.Remove(identity?.Id ?? "");
            //        }
            //        await KzParkingApiHelper.UpdateRegisteredVehicleAsyncById(vehicle);
            //    }
            //}
        }
        #endregion END PRIVATE FUNCTION

        #region PUBLIC FUNCTION
        /// <summary>
        /// Tải thông tin cấu hình phím tắt lưu trong hệ thống
        /// </summary>
        public void GetShortcutConfig()
        {
            laneOutShortcutConfig = NewtonSoftHelper<LaneOutShortcutConfig>.DeserializeObjectFromPath(PathManagement.laneShortcutConfigPath(this.lane.id)) ?? new LaneOutShortcutConfig();
            controllerShortcutConfigs = NewtonSoftHelper<List<ControllerShortcutConfig>>.DeserializeObjectFromPath(PathManagement.laneControllerShortcutConfigPath(this.lane.id)) ?? new List<ControllerShortcutConfig>();
        }

        /// <summary>
        /// Hiển thị giao diện như lần cuối cùng sử dụng
        /// </summary>
        public void DisplayUIConfig()
        {
            if (this.laneDisplayConfig == null)
            {
                return;
            }

            try
            {
                this.splitterEventInfoWithCamera.SplitPosition = this.laneDisplayConfig.splitEventInfoWithCameraPosition > 0 ?
                                    this.laneDisplayConfig.splitEventInfoWithCameraPosition : this.splitterEventInfoWithCamera.SplitPosition;
                this.splitterEventInfoWithCamera.Refresh();
            }
            catch
            {
            }

            try
            {
                this.splitContainerMain.SplitterDistance = this.laneDisplayConfig.splitContainerMain;
                this.splitContainerMain.Refresh();
            }
            catch
            {
            }

            try
            {
                this.splitContainerEventContent.SplitterDistance = this.laneDisplayConfig.splitContainerEventContent;
                this.splitContainerEventContent.Refresh();
            }
            catch
            {
            }


            try
            {
                this.splitterCamera.SplitPosition = this.laneDisplayConfig.SplitterCameraPosition > 0 ?
                                     this.laneDisplayConfig.SplitterCameraPosition : this.splitterCamera.SplitPosition;
                this.splitterCamera.Refresh();
            }
            catch
            {
            }

            AllowDesignRealtime(false);
            this.ResumeLayout();
        }

        /// <summary>
        /// Lấy thông tin hiển thị hiện tại để lưu lại
        /// </summary>
        /// <returns></returns>
        public LaneDisplayConfig SaveUIConfig()
        {
            AllowDesignRealtime(true);
            return new LaneDisplayConfig()
            {
                LaneId = this.lane.id,
                DisplayIndex = 1,
                splitContainerEventContent = this.splitContainerEventContent.SplitterDistance,
                splitContainerMain = this.splitContainerMain.SplitterDistance,
                SplitterCameraPosition = this.splitterCamera.SplitPosition,
                splitEventInfoWithCameraPosition = this.splitterEventInfoWithCamera.SplitPosition,
            };
        }

        /// <summary>
        /// Có sự kiện từ bộ điều khiển hoặc người dùng
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public async Task OnNewEvent(EventArgs e)
        {
            await semaphoreSlimOnNewEvent.WaitAsync();
            try
            {
                if (e is CardEventArgs cardEvent)
                {
                    await ExcecuteCardEvent(cardEvent);
                }
                else if (e is InputEventArgs inputEvent)
                {
                    await ExcecuteInputEvent(inputEvent);
                }
            }
            finally
            {
                semaphoreSlimOnNewEvent.Release();
            }
        }
        #endregion END PUBLIC FUNCTION

    }
}