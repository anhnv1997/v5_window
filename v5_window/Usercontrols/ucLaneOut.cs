using IPaking.Ultility;
using iPakrkingv5.Controls;
using iParkingv5.ApiManager.KzParkingv5Apis;
using iParkingv5.ApiManager.KzScaleApis;
using iParkingv5.ApiManager.XuanCuong;
using iParkingv5.Controller;
using iParkingv5.Objects;
using iParkingv5.Objects.Configs;
using iParkingv5.Objects.Databases;
using iParkingv5.Objects.Datas.Devices;
using iParkingv5.Objects.Datas.parking;
using iParkingv5.Objects.Enums;
using iParkingv5.Objects.EventDatas;
using iParkingv5.Objects.Events;
using iParkingv5.Objects.ScaleObjects;
using iParkingv5_window.Forms.DataForms;
using iParkingv5_window.Forms.ReportForms;
using iParkingv5_window.Helpers;
using Kztek.Tool;
using Kztek.Tool.TextFormatingTools;
using Kztek.Tools;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using v5_IScale.Forms;
using static iParkingv5.Objects.Configs.LaneDirectionConfig;
using static iParkingv5.Objects.Enums.LaneDirectionType;
using static iParkingv5.Objects.Enums.PrintHelpers;
using static iParkingv5.Objects.Enums.VehicleType;

namespace iParkingv5_window.Usercontrols
{
    public partial class ucLaneOut : UserControl, iLane, IDisposable
    {
        #region frm
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
        private WeighingAction? WeighingActionDetail = null;
        LaneDirectionConfig laneDirection = new LaneDirectionConfig();
        List<WeighingType> weighingForms = new List<WeighingType>();
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

            laneDirection = NewtonSoftHelper<LaneDirectionConfig>.DeserializeObjectFromPath(
                                                       PathManagement.appLaneDirectionConfigPath(this.lane.id)) ?? LaneDirectionConfig.CreateDefault();
            splitContainerMain.Panel2Collapsed = laneDirection.IsDisplayLastEvent ? false : true;
            panelLastEvent.Visible = isDisplayLastEvent;

            //switch (laneDirection.displayDirection)
            //{
            //    case LaneDirectionConfig.EmDisplayDirection.Vertical:
            //        this.isTopToBottom = true;
            //        splitterEventInfoWithCamera.Dock = DockStyle.Bottom;
            //        panelEventData.Dock = DockStyle.Bottom;

            //        panelCameras.Dock = DockStyle.Top;
            //        splitterCamera.Dock = DockStyle.Top;
            //        panelCameras.Height = 200;

            //        splitContainerEventContent.Orientation = Orientation.Vertical;
            //        break;
            //    case LaneDirectionConfig.EmDisplayDirection.HorizontalLeftToRight:
            //        this.isTopToBottom = false;
            //        this.isLeftToRight = true;
            //        break;
            //    case LaneDirectionConfig.EmDisplayDirection.HorizontalRightToLeft:
            //        this.isTopToBottom = false;
            //        this.isLeftToRight = false;
            //        break;
            //    default:
            //        break;
            //}

            //if (this.isTopToBottom)
            //{
            //    panelCameras.Dock = DockStyle.Top;
            //    splitterCamera.Dock = DockStyle.Top;
            //}
            //else
            //{
            //    if (this.isLeftToRight)
            //    {
            //        panelCameras.Dock = DockStyle.Left;
            //        splitterCamera.Dock = DockStyle.Left;
            //    }
            //    else
            //    {
            //        panelCameras.Dock = DockStyle.Right;
            //        splitterCamera.Dock = DockStyle.Right;
            //    }
            //}
            panelScaleAction.Visible = isScale;
            this.laneDisplayConfig = laneDisplayConfig;
            txtPlate.Enabled = StaticPool.appOption.IsAllowEditPlateOut;
            this.Load += UcLaneOut_Load;
        }
        private async void UcLaneOut_Load(object? sender, EventArgs e)
        {
            GetShortcutConfig();
            LoadCamera();
            this.Dock = DockStyle.Top;
            lblResult.Padding = new Padding(StaticPool.baseSize);
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
            SetDisplayDirection();
            DisplayUIConfig();
            panelLastEvent.SizeChanged += PanelLastEvent_SizeChanged;
            PanelLastEvent_SizeChanged(null, EventArgs.Empty);
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
                if (StaticPool.appOption.PrintTemplate == (int)EmPrintTemplate.XuanCuong)
                {
                    if (keys == Keys.F8)
                    {
                        this.Invoke(new Action(() =>
                        {
                            btnPrintTicket_Click(null, null);
                            FocusOnTitle();

                        }));
                        return;
                    }
                    else if (keys == Keys.F7)
                    {
                        this.Invoke(new Action(() =>
                        {
                            btnPrintEInvoiceTicket_Click(null, EventArgs.Empty);
                            FocusOnTitle();

                        }));
                        return;
                    }
                    else if (keys == Keys.F6)
                    {
                        this.Invoke(new Action(() =>
                        {
                            btnPrintPhieuThu_Click(null, EventArgs.Empty);
                            FocusOnTitle();
                        }));
                        return;
                    }
                }
                if (keys == Keys.F9)
                {
                    this.IsAllowDesignRealtime = !this.IsAllowDesignRealtime;
                    this.Invoke(new Action(() =>
                    {
                        AllowDesignRealtime(this.IsAllowDesignRealtime);
                        FocusOnTitle();
                    }));
                    return;
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
                                    txtPlate.Text = txtPlate.Text.ToUpper();
                                    newPlate = txtPlate.Text;
                                }));
                                var isUpdateSuccess = await AppData.ApiServer.UpdateEventOutPlate(lastEvent.Id, newPlate, lastEvent.PlateNumber);
                                if (isUpdateSuccess)
                                {
                                    lblResult.UpdateResultMessage("Ra Lệnh Cập Nhật Biển Số Thành Công", Color.DarkBlue);
                                    if (ucTop1Event != null)
                                    {
                                        ucTop1Event.plateNumber = newPlate;
                                    }
                                    if (isScale)
                                    {
                                        KzScaleApiHelper.UpdatePlate(lastEvent.eventIn.Id, newPlate);
                                    }
                                    if (((EmPrintTemplate)StaticPool.appOption.PrintTemplate) == EmPrintTemplate.XuanCuong)
                                    {
                                        await XuanCuongApiHelper.SendParkingInfo(lastEvent.Id, "out", newPlate, lastTime, lastImageKeys, lastEvent.eventIn.Id);
                                    }
                                    lastEvent.PlateNumber = newPlate;
                                }
                                else
                                {
                                    lblResult.UpdateResultMessage("Cập nhật lỗi, vui lòng thử lại", Color.DarkBlue);
                                }
                            }
                            FocusOnTitle();
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
                registeredVehicle = (await AppData.ApiServer.GetRegistedVehilceByPlateAsync(plate)).Item1;

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
            vehicleType = (await AppData.ApiServer.GetVehicleTypeByIdAsync(vehicleTypeId.ToString())).Item1;
            if (!string.IsNullOrEmpty(customerId))
            {
                //customer = await KzParkingApiHelper.GetCustomerById(customerId);
                customer = (await AppData.ApiServer.GetCustomerByIdAsync(customerId)).Item1;
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
                int weight = isScale ? ScaleValue : 0;
                eventOut = await AppData.ApiServer.PostCheckOutAsync(lane.id, plate, null, imageKeys, false, weight);
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
                        await AppData.ApiServer.CommitOutAsync(eventOut);
                    }
                    else
                    {
                        frmConfirmOut frmConfirmOut = new frmConfirmOut(plate, "Bạn có xác nhận mở barrie?",
                                                                        eventOut.eventIn.PlateNumber ?? "", eventOut.eventIn?.identity?.Id ?? "",
                                                                        eventOut.eventIn?.lane?.id ?? "", eventOut.eventIn?.fileKeys ?? new List<string>(),
                                                                        eventOut.eventIn?.DatetimeIn ?? DateTime.Now, false, eventOut.charge.Amount);
                        bool isConfirm = frmConfirmOut.ShowDialog() == DialogResult.OK;
                        if (!isConfirm)
                        {
                            lblResult.UpdateResultMessage("Không xác nhận mở barrie", Color.DarkOrange);
                            return;
                        }
                        else
                        {
                            plate = frmConfirmOut.updatePlate.ToUpper();
                            ControllerInLane? controllerInLane = (from _controllerInLane in this.lane.controlUnits
                                                                  where _controllerInLane.controlUnitId == ie.DeviceId
                                                                  select _controllerInLane).FirstOrDefault();
                            await BaseLane.OpenBarrieByControllerId(ie.DeviceId, controllerInLane, this);
                            eventOut.PlateNumber = plate;
                            await AppData.ApiServer.CommitOutAsync(eventOut);
                        }
                    }
                    goto SU_KIEN_HOP_LE;
                }
            }
        CheckOutWithForce:
            {
                int weight = isScale ? ScaleValue : 0;
                var responseWithForce = await AppData.ApiServer.PostCheckOutAsync(lane.id, plate, null, imageKeys, true, weight);
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
                        await AppData.ApiServer.CommitOutAsync(eventOut);
                    }
                    else
                    {
                        frmConfirmOut frmConfirmOut = new frmConfirmOut(plate, "Bạn có xác nhận mở barrie?",
                                                                                eventOut.eventIn?.PlateNumber ?? "", eventOut.eventIn?.identity?.Id ?? "",
                                                                                eventOut.eventIn?.lane?.id ?? "", eventOut?.eventIn?.fileKeys ?? new List<string>(),
                                                                                eventOut.eventIn?.DatetimeIn ?? DateTime.Now, false, eventOut.charge.Amount);
                        bool isConfirm = frmConfirmOut.ShowDialog() == DialogResult.OK;
                        if (!isConfirm)
                        {
                            lblResult.UpdateResultMessage("Không xác nhận mở barrie", Color.DarkOrange);
                            return;
                        }
                        else
                        {
                            plate = frmConfirmOut.updatePlate.ToUpper();
                            ControllerInLane? controllerInLane = (from _controllerInLane in this.lane.controlUnits
                                                                  where _controllerInLane.controlUnitId == ie.DeviceId
                                                                  select _controllerInLane).FirstOrDefault();
                            await BaseLane.OpenBarrieByControllerId(ie.DeviceId, controllerInLane, this);
                            eventOut.PlateNumber = plate;
                            AppData.ApiServer.CommitOutAsync(eventOut);
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
                ExcecuteUnvalidEvent(null, vehicleType.Type, plate, ie.EventTime, eventOut, errorMessage);
                return;
            }
        SU_KIEN_HOP_LE:
            {
                await ExcecuteValidEvent(null, null, vehicleType.Type, plate, ie.EventTime, overviewImage, vehicleImg,
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
                await AppData.ApiServer.CreateAlarmAsync("", this.lane.id, "", EmAbnormalCode.OpenBarrierByButton, imageKey, false, "", "", "", "");
                SaveAllCameraImage(imageKey);
            }
            else if ((DateTime.Now - lastEvent.DatetimeOut)?.TotalSeconds >= StaticPool.appOption.AllowBarrieDelayOpenTime)
            {
                string imageKey = BaseLane.GetBaseImageKey(this.lane.name, "", "", DateTime.Now);
                await AppData.ApiServer.CreateAlarmAsync(lastEvent.Identity?.Id, this.lane.id, lastEvent.PlateNumber, EmAbnormalCode.OpenBarrierByButton,
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
            var identityResponse = await AppData.ApiServer.GetIdentityByCodeAsync(ce.PreferCard);
            Identity? identity = identityResponse.Item1;
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
            identity = (await AppData.ApiServer.GetIdentityByIdAsync(identity.Id)).Item1;
            if (identity == null)
            {
                lblResult.UpdateResultMessage("Không đọc được thông tin định danh, vui lòng thử lại", Color.DarkRed);
                return;
            }
            lblResult.UpdateResultMessage("Đọc thông tin nhóm định danh...", Color.DarkBlue);
            IdentityGroup identityGroup = (await AppData.ApiServer.GetIdentityGroupByIdAsync(identity.IdentityGroupId.ToString())).Item1;
            if (identityGroup == null)
            {
                lblResult.UpdateResultMessage("Không đọc được thông tin nhóm định danh, vui lòng thử lại", Color.DarkRed);
                return;
            }

            lblResult.UpdateResultMessage("Đọc thông tin loại phương tiện...", Color.DarkBlue);
            VehicleBaseType vehicleBaseType = identityGroup.VehicleType;
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
                        if (vehicleBaseType == VehicleBaseType.Car)
                        {
                            vehicleImg = ucCarLpr?.GetFullCurrentImage();
                        }
                        break;
                    case CameraPurposeType.EmCameraPurposeType.MotorLPR:
                        if (vehicleBaseType != VehicleBaseType.Car)
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
                await ExcecuteMonthCardEventOut(identity, identityGroup, vehicleBaseType, ce.PlateNumber, imageKeys,
                                               ce, controllerInLane,
                                               overviewImg, vehicleImg, lprImage, imageKey);
            }
            else
            {
                await ExcecuteNonMonthCardEventOut(identity, identityGroup, vehicleBaseType, ce.PlateNumber, imageKeys,
                                                  ce, controllerInLane,
                                                  overviewImg, vehicleImg, lprImage, imageKey);
            }
        }

        private async Task ExcecuteNonMonthCardEventOut(Identity identity, IdentityGroup identityGroup, VehicleBaseType vehicleType, string plateNumber, List<string> imageKeys,
                                                        CardEventArgs ce, ControllerInLane? controllerInLane, Image? overviewImg, Image? vehicleImg, Image? lprImage, string imageKey)
        {
            bool isAlarm = false;
            int weight = isScale ? int.Parse(lblScaleInfo.Text) : 0;
            if (isScale)
            {
                if (weight == 0)
                {
                    bool isContinue = MessageBox.Show("Khối lượng cân = 0, bạn có muốn cho xe ra khỏi bãi", "Thông báo",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes;
                    if (!isContinue)
                    {
                        return;
                    }
                }
            }
            AddEventOutResponse? eventOut = await AppData.ApiServer.PostCheckOutAsync(lane.id, plateNumber, identity, imageKeys, false, weight);
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

                //bool isCOnfirm = true;

                //UPDATE TEST
                LogHelper.Log(LogHelper.EmLogType.WARN, LogHelper.EmObjectLogType.System, mo_ta_them: "Yêu cầu xác nhận phương tiện: " + (eventIn.PlateNumber ?? "") + " ; IdentityCode: " + (eventIn.identity?.Code ?? ""));
                frmConfirmOut frmConfirmOut = new frmConfirmOut(plateNumber, errorMessage, eventIn.PlateNumber ?? "",
                                                                eventIn.identity?.Id ?? "", this.lane.id,
                                                                eventIn.fileKeys ?? new List<string>(), eventIn.DatetimeIn ?? DateTime.Now,
                                                                true, eventOut.eventIn.charge);
                if (frmConfirmOut.ShowDialog() == DialogResult.OK)
                {
                    LogHelper.Log(LogHelper.EmLogType.WARN, LogHelper.EmObjectLogType.System, mo_ta_them: "Xác nhận");
                    string eventInPlate = eventIn.PlateNumber ?? "";
                    if (eventInPlate.ToUpper() != frmConfirmOut.updatePlate.ToUpper())
                    {
                        LogHelper.Log(LogHelper.EmLogType.WARN, LogHelper.EmObjectLogType.System, specailName: "LPR_EDIT_OUT", mo_ta_them: "Sửa biển số vào khi quẹt thẻ EventInId: " + eventIn.Id +
                                                                                                                                 "\r\nOld Plate: " + plateNumber +
                                                                                                                                 " => New Plate: " + frmConfirmOut.updatePlate);
                        await AppData.ApiServer.UpdateEventInPlateAsync(eventIn.Id, frmConfirmOut.updatePlate, eventIn.PlateNumber ?? "");
                    }
                    if (plateNumber.ToUpper() != frmConfirmOut.updatePlate.ToUpper())
                    {
                        LogHelper.Log(LogHelper.EmLogType.WARN, LogHelper.EmObjectLogType.System, specailName: "LPR_EDIT_OUT", mo_ta_them: "Sửa biển số ra khi quẹt thẻ EventInId: " + eventIn.Id +
                                                                                                                                   "\r\nOld Plate: " + plateNumber +
                                                                                                                                   " => New Plate: " + frmConfirmOut.updatePlate);
                    }
                    plateNumber = frmConfirmOut.updatePlate.ToUpper();
                    goto CheckOutWithForce;
                }
                else
                {
                    LogHelper.Log(LogHelper.EmLogType.WARN, LogHelper.EmObjectLogType.System, mo_ta_them: "Không Xác nhận");
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
                    await AppData.ApiServer.CommitOutAsync(eventOut);
                }
                else
                {
                    frmConfirmOut frmConfirmOut = new frmConfirmOut(plateNumber, "Bạn có xác nhận mở barrie?", eventIn.PlateNumber ?? "",
                                                                    eventIn.identity?.Id ?? "", eventIn.lane?.id ?? "",
                                                                    eventIn.fileKeys ?? new List<string>(), eventIn.DatetimeIn ?? DateTime.Now,
                                                                    false, eventOut.charge.Amount);
                    bool isConfirm = frmConfirmOut.ShowDialog() == DialogResult.OK;
                    if (!isConfirm)
                    {
                        lblResult.UpdateResultMessage("Không xác nhận mở barrie", Color.DarkOrange);
                        return;
                    }
                    else
                    {
                        plateNumber = frmConfirmOut.updatePlate.ToUpper();
                        eventOut.PlateNumber = plateNumber;
                        await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane, this);
                        await AppData.ApiServer.CommitOutAsync(eventOut);
                    }
                }
                goto SU_KIEN_HOP_LE;
            }

        CheckOutWithForce:
            {
                eventOut = await AppData.ApiServer.PostCheckOutAsync(lane.id, plateNumber, identity, imageKeys, true, weight);
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
                        await AppData.ApiServer.CommitOutAsync(eventOut);
                    }
                    else
                    {
                        if (eventIn == null)
                        {
                            goto LOI_HE_THONG;
                        }
                        frmConfirmOut frmConfirmOut = new frmConfirmOut(plateNumber, "Bạn có xác nhận mở barrie?",
                                                                        eventIn.PlateNumber ?? "", eventIn?.identity?.Id ?? "",
                                                                        eventIn?.lane?.id ?? "", eventIn?.fileKeys ?? new List<string>(),
                                                                        eventIn.DatetimeIn ?? DateTime.Now, false, eventOut.charge.Amount);
                        bool isConfirm = frmConfirmOut.ShowDialog() == DialogResult.OK;
                        if (!isConfirm)
                        {
                            lblResult.UpdateResultMessage("Không xác nhận mở barrie", Color.DarkOrange);
                            return;
                        }
                        else
                        {
                            plateNumber = frmConfirmOut.updatePlate.ToUpper();
                            await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane, this);
                            eventOut.PlateNumber = plateNumber;
                            await AppData.ApiServer.CommitOutAsync(eventOut);
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

        private async Task ExcecuteMonthCardEventOut(Identity identity, IdentityGroup identityGroup, VehicleBaseType vehicleType,
                                                     string plateNumber, List<string> imageKeys, CardEventArgs ce, ControllerInLane? controllerInLane,
                                                     Image? overviewImg, Image? vehicleImg, Image? lprImage, string imageKey)
        {
            bool isAlarm = false;
            if (identity.Vehicles == null)
            {
                lblResult.UpdateResultMessage("Thẻ tháng chưa đăng ký phương tiện", Color.DarkRed);
                return;
            }
            if (identity.Vehicles.Count == 0)
            {
                lblResult.UpdateResultMessage("Thẻ tháng chưa đăng ký phương tiện", Color.DarkRed);
                return;
            }

            AddEventOutResponse? eventOut = null;
            string errorMessage = string.Empty;
            if (string.IsNullOrEmpty(plateNumber) && identity.Vehicles.Count == 1)
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
                int weight = int.Parse(lblScaleInfo.Text);
                if (weight == 0)
                {
                    MessageBox.Show("Khối lượng cân = 0, vui lòng quẹt lại thẻ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                eventOut = await AppData.ApiServer.PostCheckOutAsync(lane.id, plateNumber, identity, imageKeys, true, weight);
                if (eventOut == null)
                {
                    goto LOI_HE_THONG;
                }
                if (eventOut.IsSuccess == false)
                {
                    errorMessage = eventOut.detailCode;
                    goto SU_KIEN_LOI;
                }
                else
                {
                    if (eventOut.OpenBarrier)
                    {
                        await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane, this);
                        await AppData.ApiServer.CommitOutAsync(eventOut);
                    }
                    else
                    {
                        frmConfirmOut frmConfirmOut = new frmConfirmOut(plateNumber, "Bạn có xác nhận mở barrie?",
                                                                        eventOut.eventIn?.PlateNumber ?? "", eventOut.eventIn?.identity?.Id ?? "",
                                                                        eventOut.eventIn?.lane?.id ?? "", eventOut.eventIn?.fileKeys,
                                                                        eventOut.eventIn?.DatetimeIn ?? DateTime.Now, false, eventOut.charge.Amount);
                        bool isConfirm = frmConfirmOut.ShowDialog() == DialogResult.OK;
                        if (!isConfirm)
                        {
                            lblResult.UpdateResultMessage("Không xác nhận mở barrie", Color.DarkOrange);
                            return;
                        }
                        else
                        {
                            plateNumber = frmConfirmOut.updatePlate.ToUpper();
                            eventOut.PlateNumber = plateNumber;
                            await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane, this);
                            await AppData.ApiServer.CommitOutAsync(eventOut);
                        }
                    }
                    goto SU_KIEN_HOP_LE;
                }
            }

        CheckOutNormal:
            {
                int weight = isScale ? ScaleValue : 0;
                eventOut = await AppData.ApiServer.PostCheckOutAsync(lane.id, ce.PlateNumber, identity, imageKeys, false, weight);
                if (eventOut == null)
                {
                    goto LOI_HE_THONG;
                }
                if (eventOut.IsSuccess == false)
                {
                    errorMessage = eventOut.fields.Count > 0 ? (eventOut.fields[0].ToString() ?? "") : eventOut.detailCode;
                    if (errorMessage != "Biển số không hợp lệ".ToUpper() && errorMessage != "BIỂN SỐ VÀO RA KHÔNG KHỚP".ToUpper())
                    {
                        goto SU_KIEN_LOI;
                    }
                    else
                    {
                        bool isConfirm = false;
                        if (identity.Vehicles.Count == 1)
                        {
                            string message = "Biển số không khớp với biển số đăng ký" + "\r\nBạn có muốn cho xe vào bãi?";
                            frmConfirmIn frmConfirmIn = new frmConfirmIn(message, identity?.Code ?? "", identity?.Name ?? "", identityGroup?.Name ?? "",
                                                                         identity.Vehicles[0].Customer.Name, identity.Vehicles[0].PlateNumber,
                                                                         identity.Vehicles[0].Customer.Address, vehicleImg, overviewImg, plateNumber);
                            isConfirm = frmConfirmIn.ShowDialog()
                                                    == DialogResult.OK;
                            plateNumber = frmConfirmIn.updatePlate.ToUpper();
                        }
                        else
                        {
                            var frmSelectVehicle = new frmSelectVehicle(identity.Vehicles);
                            if (frmSelectVehicle.ShowDialog() == DialogResult.OK)
                            {
                                isConfirm = true;
                                plateNumber = frmSelectVehicle.selectedPlate;
                            }
                        }
                        if (isConfirm)
                        {
                            goto CheckOutWithForce;
                        }
                        else
                        {
                            ClearView();
                            return;
                        }
                    }
                }
                else
                {
                    if (eventOut.OpenBarrier)
                    {
                        await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane, this);
                        await AppData.ApiServer.CommitOutAsync(eventOut);
                    }
                    else
                    {
                        frmConfirmOut frmConfirmOut = new frmConfirmOut(plateNumber, "Bạn có xác nhận mở barrie?",
                                                                        eventOut.eventIn?.PlateNumber ?? "", eventOut.eventIn?.identity?.Id ?? "",
                                                                        eventOut.eventIn?.lane?.id ?? "", eventOut.eventIn?.fileKeys ?? new List<string>(),
                                                                        eventOut.eventIn?.DatetimeIn ?? DateTime.Now, false, eventOut.charge.Amount);
                        bool isConfirm = frmConfirmOut.ShowDialog() == DialogResult.OK;
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
                            await AppData.ApiServer.CommitOutAsync(eventOut);
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

        private void ExcecuteUnvalidEvent(Identity identity, VehicleBaseType vehicleType, string plate, DateTime eventTime, AddEventOutResponse? eventOut, string errorMessage)
        {
            lblResult.UpdateResultMessage(errorMessage, Color.DarkRed);
            DisplayEventOutInfo(eventOut?.eventIn?.DatetimeIn, eventTime, plate, identity, null, vehicleType, eventOut?.RegisteredVehicle, (long)(eventOut?.charge?.Amount ?? 0), eventOut?.Customer, null, eventOut?.eventIn?.thirdPartyNote ?? "", eventOut?.eventIn?.Note ?? "");
        }
        List<string> lastImageKeys = new List<string>();
        DateTime lastTime = DateTime.Now;

        private async Task ExcecuteValidEvent(Identity identity, IdentityGroup identityGroup, VehicleBaseType vehicleType,
                                              string detectedPlate, DateTime eventTime, Image? overviewImg, Image? vehicleImg,
                                              Image? lprImage, string imageKey, AddEventOutResponse eventOut,
                                              RegisteredVehicle? registeredVehicle, bool isAlarm, List<string> imageKeys)
        {
            txtPlate.Invoke(new Action(() =>
            {
                txtPlate.Text = detectedPlate;
                txtPlate.Refresh();
            }));

            if (eventOut.charge.Amount > 0)
            {
                lblResult.UpdateResultMessage("Thu tiền", Color.DarkGreen);
            }
            else
            {
                lblResult.UpdateResultMessage("Hẹn gặp lại", Color.DarkGreen);
            }

            DisplayEventOutInfo(eventOut?.eventIn?.DatetimeIn, eventTime, detectedPlate, identity, identityGroup, vehicleType, eventOut?.RegisteredVehicle, (long)(eventOut?.charge?.Amount ?? 0), eventOut?.Customer, null, eventOut?.eventIn?.thirdPartyNote ?? "", eventOut?.eventIn?.Note ?? "");
            ShowEventInData(eventOut);
            Task.Run(async () =>
            {
                BaseLane.DisplayLed(detectedPlate, eventTime, identity, identityGroup, "Hẹn gặp lại", this.lane.id, eventOut.charge.Amount.ToString());
                await BaseLane.SaveEventImage(overviewImg, vehicleImg, lprImage, imageKey, false, new List<Image>());
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
            });
            lastEvent = eventOut;
            if (isAlarm)
            {
                LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "Tạo sự kiện cảnh báo");
                AppData.ApiServer.CreateAlarmAsync(identity.Id, this.lane.id, detectedPlate, EmAbnormalCode.InvalidPlateNumber,
                                                   imageKey, false, identityGroup?.Id.ToString(), eventOut?.Customer?.Id, eventOut?.RegisteredVehicle?.Id, "Cảnh báo biển số");
            }

            //SendAPIXuanCuong
            if (((EmPrintTemplate)StaticPool.appOption.PrintTemplate) == EmPrintTemplate.XuanCuong)
            {
                lastImageKeys = imageKeys;
                lastTime = eventTime;
                LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "Send Api XC");
                XuanCuongApiHelper.SendParkingInfo(lastEvent.Id, "out", detectedPlate, eventTime, imageKeys, lastEvent.eventIn.Id);
            }
            if ((eventOut?.charge?.Amount ?? 0) > 0)
            {
                LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "Create Payment Transaction");
                AppData.ApiServer.CreatePaymentTransaction(eventOut);
                //UPDATE TEST
                LogHelper.Log(LogHelper.EmLogType.WARN, LogHelper.EmObjectLogType.System, mo_ta_them: "Yêu cầu xác nhận gửi hóa đơn: " + lastEvent.Id);
                //bool isConfirmSendEinvoie = MessageBox.Show($"Bạn có muốn gửi hóa đơn ({TextFormatingTool.GetMoneyFormat(eventOut.charge.Amount.ToString())}) không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes;

                var frm = new frmConfirmSendInvoice();
                bool isConfirmSendEinvoie = frm.ShowDialog() == DialogResult.OK;
                //bool isConfirmSendEinvoie = true;
                if (isConfirmSendEinvoie)
                {
                    LogHelper.Log(LogHelper.EmLogType.WARN, LogHelper.EmObjectLogType.System, mo_ta_them: "xác nhận");
                    var invoiceDto = await AppData.ApiServer.CreateEinvoice(eventOut.charge.Amount, eventOut.eventIn.PlateNumber,
                                                                                eventOut.eventIn.DatetimeIn ?? DateTime.Now, eventOut.DatetimeOut ?? DateTime.Now,
                                                                                eventOut.Id, true, identityGroup?.Name ?? "");
                    lastEvent.invoiceId = invoiceDto?.id ?? "";
                }
                else
                {
                    LogHelper.Log(LogHelper.EmLogType.WARN, LogHelper.EmObjectLogType.System, mo_ta_them: "không xác nhận: " + lastEvent.Id);
                    var invoiceDto = await AppData.ApiServer.CreateEinvoice(eventOut.charge.Amount, eventOut.eventIn.PlateNumber,
                                                                               eventOut.eventIn.DatetimeIn ?? DateTime.Now, eventOut.DatetimeOut ?? DateTime.Now,
                                                                               eventOut.Id, false, identityGroup?.Name ?? "");
                    lastEvent.invoiceId = invoiceDto?.id ?? "";
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
                await AppData.ApiServer.CreateAlarmAsync("", this.lane.id, "", EmAbnormalCode.OpenBarrierByKeyboard, imageKey, false, "", "", "", "");
                SaveAllCameraImage(imageKey);
            }
            else if ((DateTime.Now - lastEvent.DatetimeOut)?.TotalSeconds >= StaticPool.appOption.AllowBarrieDelayOpenTime)
            {
                string imageKey = BaseLane.GetBaseImageKey(this.lane.name, "", "", DateTime.Now);
                await AppData.ApiServer.CreateAlarmAsync(lastEvent.Identity?.Id, this.lane.id, lastEvent.PlateNumber, EmAbnormalCode.OpenBarrierByKeyboard,
                                                          imageKey, false,
                                                          lastEvent?.IdentityGroup?.Id.ToString() ?? "", "", "", "");
                SaveAllCameraImage(imageKey);
            }
        }
        #endregion END EVENT

        #region PROPERTIES
        public bool isScale { get; set; }
        private int scaleValue;
        public int ScaleValue
        {
            get => scaleValue;
            set
            {
                scaleValue = value;
                try
                {
                    lblScaleInfo.Invoke(new Action(() =>
                    {
                        if (lblScaleInfo.Text != scaleValue.ToString())
                        {
                            lblScaleInfo.Text = scaleValue.ToString();
                        }
                    }));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

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
            if (this.weighingForms != null)
            {
                foreach (var item in this.weighingForms)
                {
                    if (item.Name == cbGoodsType.Text)
                    {
                        lblScaleFee.Text = TextFormatingTool.GetMoneyFormat(item.Price.ToString());
                    }
                }
            }
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
                if (this.WeighingActionDetail == null)
                {
                    if (isScale)
                    {
                        LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "Tạo sự kiện cân");
                        string weightFormId = ((ListItem)cbGoodsType.SelectedItem).Name;
                        if (string.IsNullOrEmpty(weightFormId))
                        {
                            MessageBox.Show("Hãy chọn loại hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        int weight = int.Parse(lblScaleInfo.Text);

                        if (weight == 0)
                        {
                            bool isConfitm = MessageBox.Show("Khối lượng cân = 0, bạn có muốn in phiếu cân", "Thông báo",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                                    == DialogResult.Yes;
                            if (!isConfitm)
                            {
                                return;
                            }
                        }
                        this.WeighingActionDetail = await KzScaleApiHelper.CreateScaleEvent(lastEvent.PlateNumber ?? "", lastEvent.eventIn.Id ?? "",
                                                                                            weight, weightFormId,
                                                                                            StaticPool.userId, StaticPool.user_name, lastImageKeys, "", this.lane.id);
                    }
                }
                LogHelper.Log(LogHelper.EmLogType.WARN, LogHelper.EmObjectLogType.Camera, "8");
                if (this.WeighingActionDetail == null || string.IsNullOrEmpty(this.WeighingActionDetail.Id))
                {
                    LogHelper.Log(LogHelper.EmLogType.WARN, LogHelper.EmObjectLogType.Camera, "9");
                    MessageBox.Show("Chưa có thông tin sự kiện cân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                bool isContinue = await CheckWeighingType();
                if (!isContinue)
                {
                    return;
                }
                LogHelper.Log(LogHelper.EmLogType.WARN, LogHelper.EmObjectLogType.System, "10");
                this.Invoke(new Action(() =>
                {
                    lblScaleFee.Text = TextFormatingTool.GetMoneyFormat(this.WeighingActionDetail.Charge.ToString());
                }));
                var frm = new frmSelectPrintCount();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.printCount = frm.PrintCount;

                    var wbPrint = new WebBrowser();
                    wbPrint.DocumentCompleted += WbPrint_DocumentCompleted;
                    LogHelper.Log(LogHelper.EmLogType.WARN, LogHelper.EmObjectLogType.System, "Bắt đầu tin phiếu cân " + (lastEvent.PlateNumber ?? ""));
                    wbPrint.DocumentText = PrintHelper.GetScalePrintContent(
                        await KzScaleApiHelper.GetWeighingActionDetailsByTrafficId(this.lastEvent.eventIn.Id), lastEvent.PlateNumber ?? "", cbGoodsType.Text);
                }
            }
            else
            {
                LogHelper.Log(LogHelper.EmLogType.WARN, LogHelper.EmObjectLogType.System, "Chưa có thông tin sự kiện cân");
                MessageBox.Show("Chưa có thông tin sự kiện cân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        private async void btnPrintScaleOffline_Click(object sender, EventArgs e)
        {
            FocusOnTitle();
            //Ra lệnh gửi hóa đơn điện tử
            if (lastEvent == null)
            {
                MessageBox.Show("Chưa có thông tin sự kiện cân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(lastEvent.Id))
            {
                MessageBox.Show("Chưa có thông tin sự kiện cân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Ra lệnh gửi hóa đơn điện tử
            if (this.WeighingActionDetail == null)
            {
                if (isScale)
                {
                    LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "Tạo sự kiện cân");
                    string weightFormId = ((ListItem)cbGoodsType.SelectedItem).Name;
                    if (string.IsNullOrEmpty(weightFormId))
                    {
                        MessageBox.Show("Hãy chọn loại hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    int weight = int.Parse(lblScaleInfo.Text);
                    if (weight == 0)
                    {
                        bool isConfitm = MessageBox.Show("Khối lượng cân = 0, bạn có muốn in phiếu thu", "Thông báo",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                                == DialogResult.Yes;
                        if (!isConfitm)
                        {
                            return;
                        }
                    }
                    this.WeighingActionDetail = await KzScaleApiHelper.CreateScaleEvent(lastEvent.PlateNumber ?? "", lastEvent.eventIn.Id ?? "",
                                                                                        weight, weightFormId,
                                                                                        StaticPool.userId, StaticPool.user_name, lastImageKeys, "", this.lane.id);
                }
            }
            if (this.WeighingActionDetail == null)
            {
                if (string.IsNullOrEmpty(this.WeighingActionDetail.Id) || this.WeighingActionDetail.Id == Guid.Empty.ToString())
                {

                    MessageBox.Show("Chưa có thông tin cân xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            bool isContinue = await CheckWeighingType();
            if (!isContinue)
            {
                return;
            }
            lblScaleFee.Text = TextFormatingTool.GetMoneyFormat(this.WeighingActionDetail.Charge.ToString());

            this.printCount = 1;
            var wbPrint = new WebBrowser();
            wbPrint.DocumentCompleted += WbPrint_DocumentCompleted;
            wbPrint.DocumentText = PrintHelper.GetPrintScaleInvoiceOfflineContent(this.WeighingActionDetail, lastEvent.PlateNumber);
        }
        private async void btnPrintScaleOnline_Click(object sender, EventArgs e)
        {
            FocusOnTitle();
            //Ra lệnh gửi hóa đơn điện tử
            if (lastEvent == null)
            {
                MessageBox.Show("Chưa có thông tin sự kiện cân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(lastEvent.Id))
            {
                MessageBox.Show("Chưa có thông tin sự kiện cân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.WeighingActionDetail == null)
            {
                if (isScale)
                {
                    LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "Tạo sự kiện cân");
                    string weightFormId = ((ListItem)cbGoodsType.SelectedItem).Name;
                    if (string.IsNullOrEmpty(weightFormId))
                    {
                        MessageBox.Show("Hãy chọn loại hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    int weight = int.Parse(lblScaleInfo.Text);
                    if (weight == 0)
                    {
                        bool isConfitm = MessageBox.Show("Khối lượng cân = 0, bạn có muốn in hóa đơn", "Thông báo",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                                == DialogResult.Yes;
                        if (!isConfitm)
                        {
                            return;
                        }
                    }
                    this.WeighingActionDetail = await KzScaleApiHelper.CreateScaleEvent(lastEvent.PlateNumber ?? "", lastEvent.eventIn.Id ?? "",
                                                                                        weight, weightFormId,
                                                                                        StaticPool.userId, StaticPool.user_name, lastImageKeys, "", this.lane.id);
                }
            }
            //Ra lệnh gửi hóa đơn điện tử
            if (this.WeighingActionDetail == null)
            {
                MessageBox.Show("Chưa có thông tin cân xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bool isContinue = await CheckWeighingType();
            if (!isContinue)
            {
                return;
            }
            lblScaleFee.Text = TextFormatingTool.GetMoneyFormat(this.WeighingActionDetail.Charge.ToString());

            if (this.WeighingActionDetail.Charge == 0)
            {
                MessageBox.Show("Phương tiện không phát sinh phí cân xe.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //In hóa đơn internet
            //UPDATE TEST
            if (string.IsNullOrEmpty(this.WeighingActionDetail.InvoiceId))
            {
                var invoiceData = await KzScaleApiHelper.CreateInvoice(this.WeighingActionDetail.Id, true);
                if (string.IsNullOrEmpty(invoiceData.id))
                {
                    MessageBox.Show("Chưa gửi được thông tin hóa đơn điện tử", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                this.WeighingActionDetail.InvoiceId = invoiceData.id;
            }

            var invoiceFile = await AppData.ApiServer.GetInvoiceData(this.WeighingActionDetail.InvoiceId);
            if (invoiceFile == null)
            {
                MessageBox.Show("Chưa có thông tin hóa đơn điện tử", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                string pdfContent = invoiceFile.fileToBytes;
                PrintHelper.PrintPdf(pdfContent);
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.System, obj: ex);
            }
        }

        private async Task<bool> CheckWeighingType()
        {
            if (cbGoodsType.Items.Count > 0)
            {
                string weighingTypeId = ((ListItem)cbGoodsType.SelectedItem).Name;
                if (this.WeighingActionDetail != null && !string.IsNullOrEmpty(this.WeighingActionDetail.Id))
                {
                    if (this.WeighingActionDetail.WeighingTypeId != weighingTypeId)
                    {
                        bool isConfirm = MessageBox.Show($"Bạn có xác nhận đổi từ loại cân {this.WeighingActionDetail.weighingType.Name} sang {cbGoodsType.Text} không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes;
                        if (!isConfirm)
                        {
                            return false;
                        }
                        var response = await KzScaleApiHelper.UpdateWeighingActionDetailById(this.WeighingActionDetail.Id, weighingTypeId);
                        if (response == null)
                        {
                            MessageBox.Show("Gặp lỗi khi cập nhật thông tin lên hệ thống, vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                        else
                        {
                            this.WeighingActionDetail = response;
                            this.Invoke(new Action(() =>
                            {
                                lblScaleFee.Text = TextFormatingTool.GetMoneyFormat(this.WeighingActionDetail.Charge.ToString());
                            }));
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private async void btnPrintEInvoiceTicket_Click(object sender, EventArgs e)
        {
            FocusOnTitle();
            if (this.lastEvent == null)
            {
                MessageBox.Show("Chưa có thông tin phương tiện vào ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.lastEvent.charge?.Amount == 0)
            {
                MessageBox.Show("Phương tiện không phát sinh phí gửi xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //In hóa đơn internet
            var invoiceData = await AppData.ApiServer.GetInvoiceData(this.lastEvent.invoiceId);
            if (invoiceData == null)
            {
                MessageBox.Show("Chưa có thông tin hóa đơn điện tử", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                string pdfContent = invoiceData.fileToBytes;
                if (pdfContent != null)
                {
                    bool isConfirm = MessageBox.Show("Bạn có muốn in hóa đơn (Internet)?", "In hóa đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
                    if (!isConfirm)
                    {
                        return;
                    }
                    PrintHelper.PrintPdf(pdfContent);
                }
                else
                {
                    MessageBox.Show("Chưa có thông tin hóa đơn điện tử", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.System, obj: ex);
            }
        }
        private void btnPrintPhieuThu_Click(object sender, EventArgs e)
        {
            FocusOnTitle();
            if (lastEvent == null)
            {
                MessageBox.Show("Không có thông tin sự kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string printTemplatePath = PathManagement.appPrintPhieuThu(((EmPrintTemplate)StaticPool.appOption.PrintTemplate).ToString());
            if (File.Exists(printTemplatePath))
            {
                bool isConfirm = MessageBox.Show("Bạn có muốn in phiếu thu?", "In hóa đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
                if (!isConfirm)
                {
                    return;
                }
                string printContent = PrintHelper.GetPhieuThuContent(File.ReadAllText(printTemplatePath), lastEvent.Identity.Name, lastEvent.IdentityGroup.Name, picLprImage.Image,
                                                      lastEvent.eventIn.DatetimeIn ?? DateTime.Now, lastEvent.DatetimeOut ?? DateTime.Now,
                                                      lastEvent.PlateNumber, TextFormatingTool.GetMoneyFormat(lastEvent.charge.Amount.ToString()), lastEvent.charge.Amount);
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
                bool isConfirm = MessageBox.Show("Bạn có muốn in hóa đơn?", "In hóa đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
                if (!isConfirm)
                {
                    return;
                }
                string printContent = PrintHelper.GetParkingPrintContent(File.ReadAllText(printTemplatePath),
                                                      lastEvent.eventIn.DatetimeIn ?? DateTime.Now, lastEvent.DatetimeOut ?? DateTime.Now,
                                                      lastEvent.PlateNumber, TextFormatingTool.GetMoneyFormat(lastEvent.charge.Amount.ToString()), lastEvent.charge.Amount);
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
                await AppData.ApiServer.CreateAlarmAsync("", this.lane.id, "", EmAbnormalCode.OpenBarrierByKeyboard, imageKey, false, "", "", "", "");
                SaveAllCameraImage(imageKey);
            }
            else if ((DateTime.Now - lastEvent.DatetimeOut)?.TotalSeconds >= StaticPool.appOption.AllowBarrieDelayOpenTime)
            {
                string imageKey = BaseLane.GetBaseImageKey(this.lane.name, "", "", DateTime.Now);
                await AppData.ApiServer.CreateAlarmAsync(lastEvent.Identity?.Id, this.lane.id, lastEvent.PlateNumber, EmAbnormalCode.OpenBarrierByKeyboard,
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
                Identity identity = (await AppData.ApiServer.GetIdentityByIdAsync(frm.selectedIdentityId)).Item1;
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
                            await AppData.ApiServer.CreateAlarmAsync(lastEvent.Identity?.Id, this.lane.id, lastEvent.PlateNumber, EmAbnormalCode.ManualEvent,
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
            //foreach (Control item in panelCameras.Controls)
            //{
            //    item.Width = panelCameras.Width - 5;
            //}
            //for (int i = 0; i < panelCameras.Controls.Count; i++)
            //{
            //    if (i == 0)
            //    {
            //        panelCameras.Controls[i].Location = new Point(0);
            //    }
            //    else
            //    {
            //        Control lastControl = panelCameras.Controls[i - 1];
            //        Point location = new Point(lastControl.Location.X, lastControl.Location.Y + lastControl.Height + 10);
            //        panelCameras.Controls[i].Location = location;
            //    }
            //}
            int panelHeight = panelCameras.Height - 50;
            foreach (ucCameraView item in panelCameras.Controls.OfType<ucCameraView>())
            {
                if (laneDirection.cameraDirection == LaneDirectionConfig.EmCameraDirection.Vertical)
                {
                    item.Width = panelCameras.Width - panelCameras.Margin.Left - panelCameras.Margin.Right - panelCameras.Padding.Left - panelCameras.Padding.Right
                                                    - item.Margin.Left - item.Margin.Right - item.Padding.Left - item.Padding.Right;
                }
                else
                {
                    item.changeHeight(panelCameras.Height - 50);
                }
            }
            for (int i = 0; i < panelCameras.Controls.OfType<ucCameraView>().ToList().Count; i++)
            {
                if (i == 0)
                {
                    panelCameras.Controls.OfType<ucCameraView>().ToList()[i].Location = new Point(0, 37);
                }
                else
                {
                    Control lastControl = panelCameras.Controls.OfType<ucCameraView>().ToList()[i - 1];
                    if (laneDirection.cameraDirection == LaneDirectionConfig.EmCameraDirection.Vertical)
                    {
                        Point location = new Point(lastControl.Location.X, lastControl.Location.Y + lastControl.Height + 10);
                        panelCameras.Controls.OfType<ucCameraView>().ToList()[i].Location = location;
                    }
                    else
                    {
                        Point location = new Point(lastControl.Location.X + lastControl.Width + 10, lastControl.Location.Y);
                        panelCameras.Controls.OfType<ucCameraView>().ToList()[i].Location = location;
                    }
                }
            }
        }
        private void PanelLastEvent_SizeChanged(object? sender, EventArgs e)
        {
            panel19.Width = panelTop3Event.PreferredSize.Width + 20;
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
            weighingForms = await KzScaleApiHelper.GetWeighingForms() ?? new List<WeighingType>();
            if (weighingForms != null)
            {
                foreach (var item in weighingForms)
                {
                    ListItem li = new ListItem()
                    {
                        Name = item.Id,
                        Value = item.Name,
                    };
                    if (item.Price == 0)
                    {
                        cbGoodsType.Items.Insert(0, li);
                    }
                    else
                        cbGoodsType.Items.Add(li);
                }
                cbGoodsType.DisplayMember = "Value";
                if (cbGoodsType.Items.Count > 0)
                {
                    cbGoodsType.SelectedIndex = cbGoodsType.FindString("Xuất");
                    //cbGoodsType.SelectedIndex = 0;
                }
                //cbGoodsType.SelectedIndex = cbGoodsType.Items.Count > 0 ? 0 : -1;
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
            panelTop3Event.Dock = DockStyle.Fill;
            panelTop3Event.Location = new Point(0, 36);
            panelTop3Event.Name = "panel9";
            panelTop3Event.Size = new Size(539, 123);
            panelTop3Event.TabIndex = 8;

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
            ucEventCount1.Size = new Size(250, 161);
            ucEventCount1.TabIndex = 7;

            ucTop3Event = new ucLastEventInfo(false);
            ucTop2Event = new ucLastEventInfo(true);
            ucTop1Event = new ucLastEventInfo(true);
            ucTop1Event.Size = ucTop2Event.Size = ucTop3Event.Size = panelTop3Event.Width > 750 ? new Size(250, 0) : new Size(125, 0);

            panelTop3Event.Controls.Add(ucTop3Event);
            panelTop3Event.Controls.Add(ucTop2Event);
            panelTop3Event.Controls.Add(ucTop1Event);
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
            var top3EventReport = await AppData.ApiServer.GetEventOuts("", startTime, endTime, "", "", this.lane.id, "", 0, 3);
            var top3Event = top3EventReport?.data ?? null;
            if (top3Event != null)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (top3Event.Count <= i)
                    {
                        break;
                    }
                    string id = top3Event[i].id.ToString() ?? "";
                    string plateNumber = top3Event[i].plateNumber.ToString() ?? "";
                    string vehicleGroupId = "";
                    string cardGroupId = top3Event[i].IdentityGroupId.ToString() ?? "";
                    DateTime dateTimeIn = DateTime.Parse(top3Event[i].eventInCreatedUtc.ToString()).AddHours(7);
                    List<string> picDirs = top3Event[i].fileKeys.ToList() ?? new List<string>();
                    string customerId = "";
                    string registerVehicleId = "";
                    string laneId = this.lane.id;
                    string identityId = top3Event[i].identityId.ToString() ?? "";
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
            this.Invoke(new Action(() =>
            {
                try
                {
                    this.ActiveControl = lblLaneName;
                    lblLaneName.Focus();
                }
                catch (Exception)
                {
                }
            }));
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
            laneDirection = NewtonSoftHelper<LaneDirectionConfig>.DeserializeObjectFromPath(
                                                                   PathManagement.appLaneDirectionConfigPath(this.lane.id)) ?? LaneDirectionConfig.CreateDefault();
            splitContainerMain.Panel2Collapsed = laneDirection.IsDisplayLastEvent ? false : true;
            SetDisplayDirection();
            //switch (laneDirection.displayDirection)
            //{
            //    case LaneDirectionConfig.EmDisplayDirection.Vertical:
            //        this.isTopToBottom = true;
            //        splitterEventInfoWithCamera.Dock = DockStyle.Bottom;
            //        panelEventData.Dock = DockStyle.Bottom;

            //        panelCameras.Dock = DockStyle.Top;
            //        splitterCamera.Dock = DockStyle.Top;
            //        panelCameras.Height = 200;

            //        splitContainerEventContent.Orientation = Orientation.Vertical;
            //        break;
            //    case LaneDirectionConfig.EmDisplayDirection.HorizontalLeftToRight:
            //        if (!this.isLeftToRight || this.isTopToBottom)
            //        {
            //            this.isTopToBottom = false;
            //            this.isLeftToRight = true;
            //            panelCameras.Width = 200;
            //            panelCameras.Dock = DockStyle.Left;
            //            splitterCamera.Dock = DockStyle.Left;
            //        }
            //        break;
            //    case LaneDirectionConfig.EmDisplayDirection.HorizontalRightToLeft:
            //        if (this.isLeftToRight || this.isTopToBottom)
            //        {
            //            this.isTopToBottom = false;
            //            this.isLeftToRight = false;
            //            panelCameras.Width = 200;
            //            panelCameras.Dock = DockStyle.Right;
            //            splitterCamera.Dock = DockStyle.Right;
            //        }
            //        break;
            //    default:
            //        break;
            //}
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

                lblNote1.Text = "Lý do chặn kích xe";
                lblNote2.Text = "Ghi chú DVHT";

                this.WeighingActionDetail = null;
                FocusOnTitle();
                if (cbGoodsType.Items.Count > 0)
                {
                    cbGoodsType.SelectedIndex = cbGoodsType.FindString("Xuất");
                    //cbGoodsType.SelectedIndex = 0;
                }
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

            this.Invoke(new Action(async () =>
            {
                lblPlateIn.Text = eventOut.eventIn.PlateNumber + " " + eventOut.eventIn?.Note ?? "";
                try
                {

                    string displayOverviewInPath = eventOut.eventIn.fileKeys.Where(e => e.Contains("_OVERVIEWIN")).FirstOrDefault() ?? "";
                    string vehicleInPath = eventOut.eventIn.fileKeys.Where(e => e.Contains("_VEHICLEIN")).FirstOrDefault() ?? "";
                    string lprCutPath = eventOut.eventIn.fileKeys.Where(e => e.Contains("_LPRIN")).FirstOrDefault() ?? "";

                    if (string.IsNullOrEmpty(displayOverviewInPath))
                    {
                        if (eventOut.eventIn.fileKeys.Count > 0)
                        {
                            displayOverviewInPath = eventOut.eventIn.fileKeys[0];
                        }
                    }
                    if (string.IsNullOrEmpty(vehicleInPath))
                    {
                        if (eventOut.eventIn.fileKeys.Count > 1)
                        {
                            vehicleInPath = eventOut.eventIn.fileKeys[1];
                        }
                    }
                    if (!string.IsNullOrEmpty(lprCutPath))
                    {
                        if (eventOut.eventIn.fileKeys.Count > 2)
                        {
                            lprCutPath = eventOut.eventIn.fileKeys[2];
                        }
                    }

                    if (!string.IsNullOrEmpty(displayOverviewInPath))
                    {
                        picOverviewImageIn.LoadAsync(await MinioHelper.GetImage(displayOverviewInPath));
                    }
                    if (!string.IsNullOrEmpty(vehicleInPath))
                    {
                        picVehicleImageIn.LoadAsync(await MinioHelper.GetImage(vehicleInPath));
                    }
                    if (!string.IsNullOrEmpty(lprCutPath))
                    {
                        picLprImageIn.LoadAsync(await MinioHelper.GetImage(lprCutPath));
                    }
                    //picVehicleImageIn.LoadAsync(await MinioHelper.GetImage(vehicleInPath));
                }
                catch (Exception ex)
                {
                    LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.System, obj: ex, mo_ta_them: ex.Message);
                }
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

        private async void DisplayEventOutInfo(DateTime? timeIn, DateTime timeOut, string plateNumber, Identity identity, IdentityGroup? identityGroup, VehicleBaseType vehicle,
                                         RegisteredVehicle? registerVehicle, long fee, Customer? customer, WeighingAction? weighingDetail = null, string thirdPartyNote = "", string note = "")
        {
            DateTime startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 1, 1, 1);
            DateTime endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            string transactionCode = "";
            var data = await AppData.ApiServer.GetEventOuts(identity.Code, startTime, endTime, "", "", "", "", 0, 1);
            if (data != null)
            {
                if (data.data != null)
                {
                    if (data.data.Count > 0)
                    {
                        transactionCode = (data.data[0].TransactionCode ?? "").Contains("-0-0") ? "" : data.data[0].TransactionCode;
                    }
                }
            }

            laneDirection = NewtonSoftHelper<LaneDirectionConfig>.DeserializeObjectFromPath(
                                                     PathManagement.appLaneDirectionConfigPath(this.lane.id)) ?? LaneDirectionConfig.CreateDefault();
            dgvEventContent!.Invoke(new Action(() =>
            {
                dgvEventContent.Columns[0].Visible = laneDirection.IsDisplayTitle;
                if (!string.IsNullOrEmpty(thirdPartyNote.Trim()))
                {
                    string[] noteArray = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(thirdPartyNote)!.ToArray();// note.Split(";");
                    lblNote1.Text = noteArray.Length > 0 ? noteArray[0] : "Lý do chặn kích xe";
                    lblNote2.Text = noteArray.Length > 1 ? noteArray[1] : "Ghi chú DVHT";
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

                if (weighingDetail != null && !string.IsNullOrEmpty(weighingDetail.Id))
                {
                    lblScaleFee.Text = TextFormatingTool.GetMoneyFormat(weighingDetail.Charge.ToString());
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

                    dgvEventContent.Rows.Add("Giờ Vào", timeIn?.ToString(UltilityManagement.fullDayFormat));
                    dgvEventContent.Rows.Add("Giờ ra", timeOut.ToString(UltilityManagement.fullDayFormat));
                    dgvEventContent.Rows.Add("Số phiếu", transactionCode);
                }
                else
                {
                    dgvEventContent.Rows.Add("Thời gian ra", timeOut.ToString(UltilityManagement.fullDayFormat));
                }
                dgvEventContent.Rows.Add("Loại Xe", VehicleType.GetDisplayStr(vehicle));

                dgvEventContent.Rows.Add("Vé Xe", identity?.Code ?? "" + " - " + identity?.Code ?? "");

                if (customer != null)
                {
                    dgvEventContent.Rows.Add("Khách hàng", customer.Name + " " + customer.Address);
                    dgvEventContent.Rows.Add("SĐT", customer.PhoneNumber);
                }
                if (registerVehicle != null)
                {
                    dgvEventContent.Rows.Add("BSĐK", registerVehicle.Name + " / " + registerVehicle.PlateNumber);
                    dgvEventContent.Rows.Add("Hết hạn", registerVehicle.ExpireTime?.ToString(UltilityManagement.fullDayFormat));
                }

                dgvEventContent.Rows.Add("Nhóm định danh", identityGroup?.Name);
                dgvEventContent.BringToFront();
                dgvEventContent.CurrentCell = null;
                this.ActiveControl = lblLaneName;
            }));
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
                splitContainerMain = this.splitContainerMain.Panel2Collapsed ? this.splitContainerMain.Height : this.splitContainerMain.SplitterDistance,
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
        private void SetDisplayDirection()
        {
            switch (laneDirection.displayDirection)
            {
                case LaneDirectionConfig.EmDisplayDirection.Vertical:
                    splitterEventInfoWithCamera.Dock = DockStyle.Bottom;
                    panelEventData.Dock = DockStyle.Bottom;
                    panelCameras.Height = 200;
                    break;
                case LaneDirectionConfig.EmDisplayDirection.HorizontalLeftToRight:
                    splitterEventInfoWithCamera.Dock = DockStyle.Right;
                    panelEventData.Dock = DockStyle.Right;
                    panelCameras.Width = 200;
                    break;
                case LaneDirectionConfig.EmDisplayDirection.HorizontalRightToLeft:
                    splitterEventInfoWithCamera.Dock = DockStyle.Left;
                    panelEventData.Dock = DockStyle.Left;
                    panelCameras.Width = 200;
                    break;
                default:
                    break;
            }

            switch (laneDirection.cameraPicDirection)
            {
                case LaneDirectionConfig.EmCameraPicFunction.Vertical:
                    splitterCamera.Dock = DockStyle.Top;
                    panelCameras.Dock = DockStyle.Top;
                    panelCameras.Height = 100;
                    break;
                case LaneDirectionConfig.EmCameraPicFunction.HorizontalLeftToRight:
                    panelCameras.Width = 100;
                    splitterCamera.Dock = DockStyle.Left;
                    panelCameras.Dock = DockStyle.Left;

                    break;
                case LaneDirectionConfig.EmCameraPicFunction.HorizontalRightToLeft:
                    panelCameras.Width = 100;
                    splitterCamera.Dock = DockStyle.Right;
                    panelCameras.Dock = DockStyle.Right;
                    break;
                default:
                    break;
            }
            switch (laneDirection.eventDirection)
            {
                case EmEventDirection.Vertical:
                    splitContainerEventContent.Orientation = Orientation.Horizontal;
                    splitContainerEventContent.Panel1.Controls.Add(panelLpr);
                    splitContainerEventContent.Panel2.Controls.Add(panelEventInfo);
                    break;
                case EmEventDirection.HorizontalLeftToRight:
                    panelEventData.Width = 300;
                    splitContainerEventContent.Orientation = Orientation.Vertical;
                    splitContainerEventContent.Panel1.Controls.Add(panelLpr);
                    splitContainerEventContent.Panel2.Controls.Add(panelEventInfo);
                    break;
                case EmEventDirection.HorizontalRightToLeft:
                    panelEventData.Width = 300;
                    splitContainerEventContent.Orientation = Orientation.Vertical;
                    splitContainerEventContent.Panel1.Controls.Add(panelEventInfo);
                    splitContainerEventContent.Panel2.Controls.Add(panelLpr);
                    break;
                default:
                    break;
            }
            splitContainerMain.Panel2Collapsed = laneDirection.IsDisplayLastEvent ? false : true;
            panelLastEvent.Visible = laneDirection.IsDisplayLastEvent;
            PanelCameras_SizeChanged(null, null);
        }

        //private async void btnUpdateNote1_Click(object sender, EventArgs e)
        //{
        //    if (lastEvent == null)
        //    {
        //        return;
        //    }
        //    bool isCOnfirm = MessageBox.Show("Bạn có muốn cập nhật ghi chú?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes;
        //    if (!isCOnfirm)
        //        return;
        //    if (lastEvent.eventIn == null)
        //    {
        //        MessageBox.Show("Thông tin xe vào không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }
        //    List<string> updateNotes = new List<string>();
        //    if (string.IsNullOrEmpty(lastEvent.eventIn.thirdPartyNote))
        //    {
        //        updateNotes.Add(txtNote1.Text);
        //        updateNotes.Add("");
        //        updateNotes.Add("");
        //    }
        //    else
        //    {
        //        string[] noteArray = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(lastEvent.eventIn.thirdPartyNote)!.ToArray();// note.Split(";");
        //        updateNotes.Add( txtNote1.Text);
        //        if (noteArray.Length > 0)
        //        {
        //            updateNotes.Add(noteArray[1]);
        //        }
        //        else
        //        {
        //            updateNotes.Add("");
        //        }
        //        if (noteArray.Length > 1)
        //        {
        //            updateNotes.Add(noteArray[2]);
        //        }
        //        else
        //        {
        //            updateNotes.Add("");
        //        }
        //    }
        //    bool isUpdateSuccess = await KzParkingv5ApiHelper.UpdateNoteOut(lastEvent.Id, updateNotes[0], updateNotes[1], updateNotes[2]);
        //    if (isUpdateSuccess)
        //    {
        //        lastEvent.eventIn.thirdPartyNote = Newtonsoft.Json.JsonConvert.SerializeObject(updateNotes);
        //        lblResult.UpdateResultMessage($"Cập nhật ghi chú thành công", Color.DarkBlue);
        //    }
        //    else
        //    {
        //        lblResult.UpdateResultMessage($"Cập nhật ghi chú thất bại", Color.DarkBlue);
        //    }

        //}

        //private async void btnUpdateNote2_Click(object sender, EventArgs e)
        //{

        //    if (lastEvent == null)
        //    {
        //        return;
        //    }
        //    bool isCOnfirm = MessageBox.Show("Bạn có muốn cập nhật ghi chú?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes;
        //    if (!isCOnfirm)
        //        return;
        //    if (lastEvent.eventIn == null)
        //    {
        //        MessageBox.Show("Thông tin xe vào không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }
        //    List<string> updateNotes = new List<string>();
        //    if (string.IsNullOrEmpty(lastEvent.eventIn.thirdPartyNote))
        //    {
        //        updateNotes.Add("");
        //        updateNotes.Add(txtNote2.Text);
        //        updateNotes.Add("");
        //    }
        //    else
        //    {
        //        string[] noteArray = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(lastEvent.eventIn.thirdPartyNote)!.ToArray();// note.Split(";");
        //        if (noteArray.Length > 0)
        //        {
        //            updateNotes.Add(noteArray[0]);
        //        }
        //        else
        //        {
        //            updateNotes.Add("");
        //        }
        //        updateNotes.Add(txtNote2.Text);
        //        if (noteArray.Length > 1)
        //        {
        //            updateNotes.Add(noteArray[2]);
        //        }
        //        else
        //        {
        //            updateNotes.Add("");
        //        }
        //    }
        //    bool isUpdateSuccess = await KzParkingv5ApiHelper.UpdateNoteOut(lastEvent.Id, updateNotes[0], updateNotes[1], updateNotes[2]);
        //    if (isUpdateSuccess)
        //    {
        //        lastEvent.eventIn.thirdPartyNote = Newtonsoft.Json.JsonConvert.SerializeObject(updateNotes);
        //        lblResult.UpdateResultMessage($"Cập nhật ghi chú DVHT thành công", Color.DarkBlue);
        //    }
        //    else
        //    {
        //        lblResult.UpdateResultMessage($"Cập nhật ghi chú DVHT thất bại", Color.DarkBlue);
        //    }
        //}
    }
}