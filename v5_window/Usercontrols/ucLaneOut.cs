using IPaking.Ultility;
using iPakrkingv5.Controls;
using iParkingv5.Controller;
using iParkingv5.Objects;
using iParkingv5.Objects.Configs;
using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Datas.Device_service;
using iParkingv5.Objects.Datas.invoice_service;
using iParkingv5.Objects.Datas.parking_service;
using iParkingv5.Objects.Datas.weighing_service;
using iParkingv5.Objects.Enums;
using iParkingv5.Objects.EventDatas;
using iParkingv5.Objects.Events;
using iParkingv5.Printer;
using iParkingv5.Reporting;
using iParkingv5_window.Forms.DataForms;
using iParkingv5_window.Forms.ReportForms;
using iParkingv5_window.Helpers;
using iParkingv6.Objects.Datas;
using Kztek.Tool;
using Kztek.Tool.TextFormatingTools;
using Kztek.Tools;
using static iParkingv5.Objects.Configs.LaneDirectionConfig;
using static iParkingv5.Objects.Enums.ParkingImageType;
using static iParkingv5.Objects.Enums.PrintHelpers;
using static iParkingv5.Objects.Enums.VehicleType;

namespace iParkingv5_window.Usercontrols
{
    public partial class ucLaneOut : ucBaseLane, iLane, IDisposable
    {
        #region Config
        private LaneOutShortcutConfig? laneOutShortcutConfig;
        #endregion

        #region -- Event Properties
        EventOutData? lastEvent = null;
        public static Image defaultImg = Image.FromFile(frmMain.defaultImagePath);
        #endregion

        private ucLastEventInfo? ucTop1Event;
        private ucLastEventInfo? ucTop3Event;
        private ucLastEventInfo? ucTop2Event;
        List<string> lastImageKeys = new List<string>();
        DateTime lastTime = DateTime.Now;

        #region FORMS
        public ucLaneOut(Lane lane, LaneDisplayConfig? laneDisplayConfig)
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            lblLaneName.Text = lane.name;
            lblLaneName.BackColor = Color.DarkRed;
            this.lane = lane;

            laneDirection = NewtonSoftHelper<LaneDirectionConfig>.DeserializeObjectFromPath(
                                                       PathManagement.appLaneDirectionConfigPath(this.lane.Id)) ?? LaneDirectionConfig.CreateDefault();
            splitContainerMain.Panel2Collapsed = laneDirection.IsDisplayLastEvent ? false : true;
            panelLastEvent.Visible = laneDirection.IsDisplayLastEvent;

            this.laneDisplayConfig = laneDisplayConfig;
            txtPlate.Enabled = StaticPool.appOption.IsAllowEditPlateOut;
            this.Load += UcLaneOut_Load;
        }
        private async void UcLaneOut_Load(object? sender, EventArgs e)
        {
            GetShortcutConfig();
            LoadCamera(panelCameras);
            this.Dock = DockStyle.Top;
            lblResult.Padding = new Padding(StaticPool.baseSize);
            panelCameras.SizeChanged += PanelCameras_SizeChanged;
            splitContainerEventContent.SizeChanged += SplitContainerEventContent_SizeChanged;
            splitContainerMain.MouseDoubleClick += SplitContainerEventContent_MouseDoubleClick;
            lblResult.UpdateResultMessage(StaticPool.oemConfig.AppName, Color.DarkGreen);

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

            picLprImage.Image = picLprImage.InitialImage = picLprImage.ErrorImage = defaultImg;
            picOverviewImageIn.Image = picOverviewImageIn.InitialImage = picOverviewImageIn.ErrorImage = defaultImg;
            picVehicleImageIn.Image = picVehicleImageIn.InitialImage = picVehicleImageIn.ErrorImage = defaultImg;

            picOverviewImageOut.Image = picOverviewImageOut.InitialImage = picOverviewImageOut.ErrorImage = defaultImg;
            picVehicleImageOut.Image = picVehicleImageOut.InitialImage = picVehicleImageOut.ErrorImage = defaultImg;

            picLprImageIn.Image = picLprImageIn.InitialImage = picLprImageIn.ErrorImage = defaultImg;
            CreatePanelTop3Event();
            await ShowTop3Events();

            splitContainerMain.BringToFront();

            try
            {
                this.ActiveControl = panelCameras;
            }
            catch (Exception)
            {
            }
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
                                var isUpdateSuccess = await AppData.ApiServer.parkingProcessService.UpdateEventOutPlate(lastEvent.Id, newPlate, lastEvent.PlateNumber);
                                if (isUpdateSuccess)
                                {
                                    lblResult.UpdateResultMessage("Ra Lệnh Cập Nhật Biển Số Thành Công", Color.DarkBlue);
                                    if (ucTop1Event != null)
                                    {
                                        ucTop1Event.plateNumber = newPlate;
                                    }
                                    //KzScaleApiHelper.UpdatePlate(lastEvent.eventIn.Id, newPlate);
                                    //if (((EmPrintTemplate)StaticPool.appOption.PrintTemplate) == EmPrintTemplate.XuanCuong)
                                    //{
                                    //    await XuanCuongApiHelper.SendParkingInfo(lastEvent.Id, "out", newPlate, lastTime, lastImageKeys, lastEvent.eventIn.Id);
                                    //}
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
                                NewtonSoftHelper<LaneDisplayConfig>.SaveConfig(config, PathManagement.appDisplayConfigPath(this.lane.Id));
                            }));
                            lblResult.UpdateResultMessage("Ra Lệnh Đảo Làn", Color.DarkBlue);
                            OnChangeLaneEventInvoke(this);
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

        /// <summary>
        /// Sự kiện xảy ra khi xe đi qua vòng từ
        /// </summary>
        /// <param name="ie"></param>
        /// <returns></returns>
        public override async Task ExcecuteLoopEvent(InputEventArgs ie)
        {
            VehicleBaseType vehicleType = VehicleBaseType.Car;
            Customer? customer = null;
            //Danh sách biến sử dụng
            Image? vehicleImg = null;
            List<Image?> optionalImages = new();

            Image? overviewImg = ucOverView?.GetFullCurrentImage();

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
                    BaseLane.GetPlate(this.lane.Id, out Image? carImage, out plate, out lprImage, ucCarLpr, camBienSoOTODuPhongs, true);
                    if (string.IsNullOrEmpty(plate))
                    {
                        BaseLane.GetPlate(this.lane.Id, out Image? motorImage, out plate, out lprImage, ucMotoLpr, camBienSoXeMayDuPhongs, false);
                        vehicleImg = string.IsNullOrEmpty(plate) ? carImage : motorImage;
                    }
                    else
                    {
                        vehicleImg = carImage;
                    }
                }
                else
                {
                    BaseLane.GetPlate(this.lane.Id, out vehicleImg, out plate, out lprImage, ucMotoLpr, camBienSoXeMayDuPhongs, false);
                }
                registeredVehicle = (await AppData.ApiServer.parkingDataService.GetRegistedVehilceByPlateAsync(plate)).Item1;

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
            BaseLane.ShowImage(picOverviewImageOut, overviewImg);
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
            string customerId = registeredVehicle.CustomerId;

            vehicleType = registeredVehicle.vehicleType;
            if (!string.IsNullOrEmpty(customerId))
            {
                customer = (await AppData.ApiServer.parkingDataService.GetCustomerByIdAsync(customerId)).Item1;
            }
            EventOutData? eventOut = null;
            string errorMessage = string.Empty;
            List<EmParkingImageType> validImageTypes = BaseLane.GetValidImageType(overviewImg, vehicleImg, lprImage);

        CheckOutNormal:
            {
                var eventOutResponse = await AppData.ApiServer.parkingProcessService.PostCheckOutAsync(lane.Id, plate, null, validImageTypes, false);

                if (eventOutResponse == null)
                {
                    goto LOI_HE_THONG;
                }
                eventOut = eventOutResponse.Item1;
                var errorData = eventOutResponse.Item2;

                if (errorData != null)
                {
                    errorMessage = errorData.fields.Count > 0 ? (errorData.fields[0].ToString() ?? "") : errorData.detailCode;
                    if (errorMessage != "Biển số không hợp lệ".ToUpper())
                    {
                        goto SU_KIEN_LOI;
                    }
                }
                if (eventOut.OpenBarrier)
                {
                    ControllerInLane? controllerInLane = (from _controllerInLane in this.lane.controlUnits
                                                          where _controllerInLane.controlUnitId == ie.DeviceId
                                                          select _controllerInLane).FirstOrDefault();
                    await BaseLane.OpenBarrieByControllerId(ie.DeviceId, controllerInLane, this);
                    await AppData.ApiServer.parkingProcessService.CommitOutAsync(eventOut);
                }
                else
                {
                    frmConfirmOut frmConfirmOut = new frmConfirmOut(plate, "Bạn có xác nhận mở barrie?",
                                                                    eventOut.EventIn.PlateNumber ?? "",
                                                                    eventOut.EventIn?.Identity?.Name ?? "",
                                                                    eventOut.EventIn?.IdentityGroup?.Name ?? "",
                                                                    eventOut.EventIn?.images,
                                                                    eventOut.EventIn?.DateTimeIn ?? DateTime.Now, false, eventOut.Charge);
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
                        await AppData.ApiServer.parkingProcessService.CommitOutAsync(eventOut);
                    }
                }
                goto SU_KIEN_HOP_LE;
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
                await ExcecuteValidEvent(null, null, vehicleType, plate, ie.EventTime, overviewImg, vehicleImg,
                                         lprImage, eventOut, eventOut.vehicle, isAlarm);
                return;
            }
        }

        /// <summary>
        /// Sự kiện xảy ra khi người dùng bấm nút EXIT (nút cứng) để ra lệnh mở barrie
        /// </summary>
        /// <param name="ie"></param>
        /// <returns></returns>
        public override async Task ExcecuteExitEvent(InputEventArgs ie)
        {
            lblResult.UpdateResultMessage("Đang kiểm trang thông tin sự kiện exit..." + ie.InputIndex, Color.DarkBlue);
            //--Chưa có sự kiện vào hoặc thời gian từ lúc có sự kiện đến khi bấm mở barrie quá 5s thì lưu sự kiện cảnh báo
            if (lastEvent == null)
            {
                var imageDatas = SaveAllCameraImage();
                var response = await AppData.ApiServer.parkingProcessService.CreateAlarmAsync("", this.lane.Id, "", AbnormalCode.OpenBarrierByButton, imageDatas, false, "", "", "", "");
                if (response != null)
                {
                    BaseLane.SaveImage(response.images, imageDatas);
                }

            }
            else if ((DateTime.Now - lastEvent.DatetimeOut)?.TotalSeconds >= StaticPool.appOption.AllowBarrieDelayOpenTime)
            {
                var imageDatas = SaveAllCameraImage();
                var response = await AppData.ApiServer.parkingProcessService.CreateAlarmAsync(lastEvent.Identity?.Code, this.lane.Id, lastEvent.PlateNumber, AbnormalCode.OpenBarrierByButton,
                                                             imageDatas, false,
                                                             lastEvent?.IdentityGroup?.Id.ToString() ?? "", "", "", "");
                if (response != null)
                {
                    BaseLane.SaveImage(response.images, imageDatas);
                }
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
            var identityResponse = await AppData.ApiServer.parkingDataService.GetIdentityByCodeAsync(ce.PreferCard);
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
            identity = (await AppData.ApiServer.parkingDataService.GetIdentityByIdAsync(identity.Id)).Item1;
            if (identity == null)
            {
                lblResult.UpdateResultMessage("Không đọc được thông tin định danh, vui lòng thử lại", Color.DarkRed);
                return;
            }
            lblResult.UpdateResultMessage("Đọc thông tin nhóm định danh...", Color.DarkBlue);
            IdentityGroup identityGroup = (await AppData.ApiServer.parkingDataService.GetIdentityGroupByIdAsync(identity.IdentityGroupId.ToString())).Item1;
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
            Image? lprImage = GetPlate(ce, ref overviewImg, ref vehicleImg, vehicleBaseType, lblResult, txtPlate, picOverviewImageOut, picVehicleImageOut, picLprImage);

            //Đọc thông tin loại phương tiện
            lblResult.UpdateResultMessage("Đang check out..." + ce.PreferCard, Color.DarkBlue);
            bool isMonthCard = identityGroup.Type == IdentityGroupType.Monthly;
            if (isMonthCard)
            {
                await ExcecuteMonthCardEventOut(identity, identityGroup, vehicleBaseType, ce.PlateNumber,
                                               ce, controllerInLane,
                                               overviewImg, vehicleImg, lprImage);
            }
            else
            {
                await ExcecuteNonMonthCardEventOut(identity, identityGroup, vehicleBaseType, ce.PlateNumber,
                                                  ce, controllerInLane,
                                                  overviewImg, vehicleImg, lprImage);
            }
        }

        private async Task ExcecuteNonMonthCardEventOut(Identity identity, IdentityGroup identityGroup, VehicleBaseType vehicleType,
                                                        string plateNumber, CardEventArgs ce, ControllerInLane? controllerInLane,
                                                        Image? overviewImg, Image? vehicleImg, Image? lprImage)
        {
            EventOutData? eventOut = null;
            List<EmParkingImageType> validImageTypes = BaseLane.GetValidImageType(overviewImg, vehicleImg, lprImage);

            bool isAlarm = false;
            var eventOutResponse = await AppData.ApiServer.parkingProcessService.PostCheckOutAsync(lane.Id, plateNumber, identity, validImageTypes, false);
            if (eventOutResponse == null)
            {
                goto LOI_HE_THONG;
            }
            eventOut = eventOutResponse.Item1;
            var errorData = eventOutResponse.Item2;

            EventInData? eventIn = null;

            string errorMessage;
            if (errorData != null)
            {
                if (errorData.fields == null || errorData.Payload == null)
                {
                    goto LOI_HE_THONG;
                }

                errorMessage = errorData.fields.Count > 0 ? (errorData.fields[0].ToString() ?? "") : errorData.detailCode;
                string data = errorData.Payload.ContainsKey("EventIn") ? errorData.Payload["EventIn"].ToString() : "";
                eventIn = Newtonsoft.Json.JsonConvert.DeserializeObject<EventInData>(data);
                if (eventIn == null)
                {
                    goto SU_KIEN_LOI;
                }

                if (errorMessage != "Biển số vào ra không khớp".ToUpper())
                {
                    goto SU_KIEN_LOI;
                }


                frmConfirmOut frmConfirmOut = new frmConfirmOut(plateNumber, errorMessage, eventIn.PlateNumber ?? "",
                                                                eventIn.Identity?.Name ?? "",
                                                                eventIn.IdentityGroup?.Name ?? "",
                                                                eventIn.images, eventIn.DateTimeIn ?? DateTime.Now,
                                                                true, eventIn?.Charge ?? 0);
                if (frmConfirmOut.ShowDialog() == DialogResult.OK)
                {
                    if (plateNumber.ToUpper() != frmConfirmOut.updatePlate.ToUpper())
                    {
                        LogHelper.Log(LogHelper.EmLogType.WARN, LogHelper.EmObjectLogType.System, specailName: "LPR_EDIT_OUT",
                                      mo_ta_them: "Sửa biển số khi quẹt thẻ EventInId: " + eventIn.Id +
                                                  "\r\nOld Plate: " + plateNumber +
                                                  " => New Plate: " + frmConfirmOut.updatePlate);
                    }
                    plateNumber = frmConfirmOut.updatePlate.ToUpper();
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
                eventIn = eventOut.EventIn;
                if (eventOut.OpenBarrier)
                {
                    await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane, this);
                    await AppData.ApiServer.parkingProcessService.CommitOutAsync(eventOut);
                }
                else
                {
                    frmConfirmOut frmConfirmOut = new frmConfirmOut(plateNumber, "Bạn có xác nhận mở barrie?", eventIn.PlateNumber ?? "",
                                                                    eventIn.Identity?.Name ?? "",
                                                                    eventIn.IdentityGroup?.Name ?? "",
                                                                    eventIn.images, eventIn.DateTimeIn ?? DateTime.Now,
                                                                    false, eventOut.Charge);
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
                        await AppData.ApiServer.parkingProcessService.CommitOutAsync(eventOut);
                    }
                }
                goto SU_KIEN_HOP_LE;
            }

        CheckOutWithForce:
            {
                eventOutResponse = await AppData.ApiServer.parkingProcessService.PostCheckOutAsync(lane.Id, plateNumber, identity, validImageTypes, true);
                if (eventOutResponse == null)
                {
                    goto LOI_HE_THONG;
                }
                eventOut = eventOutResponse.Item1;
                errorData = eventOutResponse.Item2;


                if (errorData != null)
                {
                    if (errorData.fields == null)
                    {
                        goto LOI_HE_THONG;
                    }

                    errorMessage = errorData.fields.Count > 0 ? (errorData.fields[0].ToString() ?? "") : errorData.detailCode;
                    goto SU_KIEN_LOI;
                }
                else
                {
                    eventIn = eventOut.EventIn;
                    if (eventOut.OpenBarrier)
                    {
                        BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane, this);
                        await AppData.ApiServer.parkingProcessService.CommitOutAsync(eventOut);
                    }
                    else
                    {
                        if (eventIn == null)
                        {
                            goto LOI_HE_THONG;
                        }
                        frmConfirmOut frmConfirmOut = new frmConfirmOut(plateNumber, "Bạn có xác nhận mở barrie?",
                                                                        eventIn.PlateNumber ?? "",
                                                                        eventIn.Identity?.Name ?? "",
                                                                        eventIn.IdentityGroup?.Name ?? "",
                                                                        eventIn?.images,
                                                                        eventIn.DateTimeIn ?? DateTime.Now, false, eventOut.Charge);
                        bool isConfirm = frmConfirmOut.ShowDialog() == DialogResult.OK;
                        if (!isConfirm)
                        {
                            lblResult.UpdateResultMessage("Không xác nhận mở barrie", Color.DarkOrange);
                            return;
                        }
                        else
                        {
                            plateNumber = frmConfirmOut.updatePlate.ToUpper();
                            BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane, this);
                            eventOut.PlateNumber = plateNumber;
                            await AppData.ApiServer.parkingProcessService.CommitOutAsync(eventOut);
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
                                         ce.EventTime, overviewImg, vehicleImg, lprImage,
                                         eventOut, eventOut.vehicle, isAlarm);
                return;
            }
        }

        private async Task ExcecuteMonthCardEventOut(Identity identity, IdentityGroup identityGroup, VehicleBaseType vehicleType,
                                                     string plateNumber, CardEventArgs ce, ControllerInLane? controllerInLane,
                                                     Image? overviewImg, Image? vehicleImg, Image? lprImage)
        {
            List<EmParkingImageType> validImageTypes = BaseLane.GetValidImageType(overviewImg, vehicleImg, lprImage);
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

            EventOutData? eventOut = null;
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
                var eventOutResponse = await AppData.ApiServer.parkingProcessService.PostCheckOutAsync(lane.Id, plateNumber, identity, validImageTypes, true);
                if (eventOutResponse == null)
                {
                    goto LOI_HE_THONG;
                }
                eventOut = eventOutResponse.Item1;
                var errorData = eventOutResponse.Item2;
                if (errorData != null)
                {
                    errorMessage = errorData.detailCode;
                    goto SU_KIEN_LOI;
                }
                else
                {
                    if (eventOut.OpenBarrier)
                    {
                        await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane, this);
                        await AppData.ApiServer.parkingProcessService.CommitOutAsync(eventOut);
                    }
                    else
                    {
                        frmConfirmOut frmConfirmOut = new frmConfirmOut(plateNumber, "Bạn có xác nhận mở barrie?",
                                                                        eventOut.EventIn?.PlateNumber ?? "",
                                                                        eventOut.EventIn?.Identity?.Name ?? "",
                                                                        eventOut.EventIn?.IdentityGroup?.Name ?? "",
                                                                        eventOut.EventIn?.images,
                                                                        eventOut.EventIn?.DateTimeIn ?? DateTime.Now, false,
                                                                        eventOut.Charge);
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
                            await AppData.ApiServer.parkingProcessService.CommitOutAsync(eventOut);
                        }
                    }
                    goto SU_KIEN_HOP_LE;
                }
            }

        CheckOutNormal:
            {
                var eventOutResponse = await AppData.ApiServer.parkingProcessService.PostCheckOutAsync(lane.Id, ce.PlateNumber, identity, validImageTypes, false);
                if (eventOutResponse == null)
                {
                    goto LOI_HE_THONG;
                }
                eventOut = eventOutResponse.Item1;
                var errorData = eventOutResponse.Item2;
                if (errorData != null)
                {
                    errorMessage = errorData.fields.Count > 0 ? (errorData.fields[0].ToString() ?? "") : errorData.detailCode;
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
                            var customer = (await AppData.ApiServer.parkingDataService.GetCustomerByIdAsync(identity.Vehicles[0].CustomerId)).Item1;
                            frmConfirmIn frmConfirmIn = new frmConfirmIn(message, identity.Code, identity.Name, identityGroup.Name,
                                                                         customer.Name, identity.Vehicles[0].PlateNumber,
                                                                         customer.Address, vehicleImg, overviewImg, plateNumber);
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
                        await AppData.ApiServer.parkingProcessService.CommitOutAsync(eventOut);
                    }
                    else
                    {
                        frmConfirmOut frmConfirmOut = new frmConfirmOut(plateNumber, "Bạn có xác nhận mở barrie?",
                                                                        eventOut.EventIn?.PlateNumber ?? "",
                                                                        eventOut.EventIn?.Identity?.Name ?? "",
                                                                        eventOut.EventIn?.IdentityGroup?.Name ?? "",
                                                                        eventOut.EventIn?.images,
                                                                        eventOut.EventIn?.DateTimeIn ?? DateTime.Now, false, eventOut.Charge);
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
                            await AppData.ApiServer.parkingProcessService.CommitOutAsync(eventOut);
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
                                         ce.EventTime, overviewImg, vehicleImg, lprImage,
                                         eventOut, eventOut.vehicle, isAlarm);
                return;
            }
        }

        private void ExcecuteSystemErrorCheckOut()
        {
            lblResult.UpdateResultMessage("Không gửi được thông tin xe ra lên hệ thống, vui lòng thử lại sau giây lát", Color.DarkRed);
        }

        private void ExcecuteUnvalidEvent(Identity identity, VehicleBaseType vehicleType, string plate, DateTime eventTime, EventOutData? eventOut, string errorMessage)
        {
            lblResult.UpdateResultMessage(errorMessage, Color.DarkRed);
            DisplayEventOutInfo(eventOut?.EventIn?.DateTimeIn, eventTime, plate, identity, null, vehicleType, eventOut?.vehicle, (long)(eventOut?.Charge ?? 0), eventOut?.customer, null, "", "");
        }

        private async Task ExcecuteValidEvent(Identity identity, IdentityGroup identityGroup, VehicleBaseType vehicleType,
                                              string detectedPlate, DateTime eventTime, Image? overviewImg, Image? vehicleImg,
                                              Image? lprImage, EventOutData eventOut,
                                              RegisteredVehicle? registeredVehicle, bool isAlarm)
        {


            if (eventOut.EventIn.images != null)
            {
                ImageData? overviewImgData = eventOut.EventIn.images.ContainsKey(EmParkingImageType.Overview) ?
                                                        eventOut.EventIn.images[EmParkingImageType.Overview][0] : null;
                ImageData? vehicleImgData = eventOut.EventIn.images.ContainsKey(EmParkingImageType.Vehicle) ?
                                                        eventOut.EventIn.images[EmParkingImageType.Vehicle][0] : null;
                ImageData? lprImgData = eventOut.EventIn.images.ContainsKey(EmParkingImageType.Plate) ?
                                                       eventOut.EventIn.images[EmParkingImageType.Plate][0] : null;
                picOverviewImageIn.ShowImageAsync(overviewImgData);
                picVehicleImageIn.ShowImageAsync(vehicleImgData);
                picLprImageIn.ShowImageAsync(lprImgData);
            }

            string resultText = eventOut.Charge > 0 ? "Thu tiền" : "Hẹn gặp lại";
            lblResult.UpdateResultMessage(resultText, Color.DarkGreen);

            DisplayEventOutInfo(eventOut.EventIn?.DateTimeIn, eventTime, detectedPlate, identity, identityGroup, vehicleType,
                                eventOut.vehicle, (long)eventOut.Charge, eventOut.customer, null, "", "");
            ShowEventInData(eventOut);
            BaseLane.DisplayLed(detectedPlate, eventTime, identity, identityGroup, "Hẹn gặp lại", this.lane.Id, eventOut.Charge.ToString());
            lastEvent = eventOut;

            var task1 = overviewImg.ImageToByteArrayAsync();
            var task2 = vehicleImg.ImageToByteArrayAsync();
            var task3 = lprImage.ImageToByteArrayAsync();
            await Task.WhenAll(task1, task2, task3);

            var imageDatas = new Dictionary<EmParkingImageType, List<List<byte>>>
                             {
                                 { EmParkingImageType.Overview, new List<List<byte>>(){ task1.Result } },
                                 { EmParkingImageType.Vehicle,new List<List<byte>>(){ task2.Result } },
                                 { EmParkingImageType.Plate, new List<List<byte>>(){ task3.Result } }
                             };
            BaseLane.SaveImage(eventOut.images, imageDatas);

            if (isAlarm)
            {
                var response = await AppData.ApiServer.parkingProcessService.CreateAlarmAsync(identity.Code, this.lane.Id, detectedPlate, AbnormalCode.InvalidPlateNumber,
                                                                                              imageDatas, false, identityGroup.Id.ToString(),
                                                                                              eventOut.customer?.Id, eventOut.vehicle?.Id, "Cảnh báo biển số");
                if (response != null)
                {
                    BaseLane.SaveImage(response.images, imageDatas);
                }
            }
            //this.Invoke(new Action(() =>
            //{
            //    for (int i = ucLastEventInfos.Count - 1; i > 0; i--)
            //    {
            //        string customerId = ucLastEventInfos[i - 1].CustomerId;
            //        string registerVehicleId = ucLastEventInfos[i - 1].RegisterVehicleId;
            //        string laneId = ucLastEventInfos[i - 1].LaneId;
            //        string identityId = ucLastEventInfos[i - 1].IdentityId;
            //        ucLastEventInfos[i].UpdateEventInfo(ucLastEventInfos[i - 1].eventId, ucLastEventInfos[i - 1].plateNumber,
            //                                            ucLastEventInfos[i - 1].vehicleGroupId, ucLastEventInfos[i - 1].IdentityGroupId,
            //                                            ucLastEventInfos[i - 1].datetimeIn, ucLastEventInfos[i - 1].picDirs,
            //                                            customerId, registerVehicleId, laneId, identityId, false);
            //    }
            //    ucLastEventInfos[0].UpdateEventInfo(lastEvent.Id, detectedPlate, identityGroup?.Id.ToString() ?? "",
            //                                        identityGroup?.Id.ToString() ?? "", eventTime, eventOut.fileKeys,
            //                                        "", "", this.lane.Id, identity?.Id, false);
            //}));

            if ((eventOut?.Charge ?? 0) > 0)
            {
                await AppData.ApiServer.paymentService.CreatePaymentTransaction(eventOut);
                string invoiceId = await SendInvoice(eventOut!, identityGroup?.Name ?? "");
                if (!string.IsNullOrEmpty(invoiceId))
                {
                    lastEvent.InvoiceId = invoiceId;
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
                var imageDatas = SaveAllCameraImage();
                var response = await AppData.ApiServer.parkingProcessService.CreateAlarmAsync("", this.lane.Id, "", AbnormalCode.OpenBarrierByKeyboard, imageDatas, false, "", "", "", "");
                if (response != null)
                {
                    BaseLane.SaveImage(response.images, imageDatas);
                }
            }
            else if ((DateTime.Now - lastEvent.DatetimeOut)?.TotalSeconds >= StaticPool.appOption.AllowBarrieDelayOpenTime)
            {
                var imageDatas = SaveAllCameraImage();
                var response = await AppData.ApiServer.parkingProcessService.CreateAlarmAsync(lastEvent.Identity?.Code, this.lane.Id, lastEvent.PlateNumber, AbnormalCode.OpenBarrierByKeyboard,
                                                           imageDatas, false,
                                                           lastEvent?.IdentityGroup?.Id.ToString() ?? "", "", "", "");
                if (response != null)
                {
                    BaseLane.SaveImage(response.images, imageDatas);
                }
            }
        }
        #endregion END EVENT

        #region CONTROLS IN FORM

        #region ACTION
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
            new frmLaneSetting(this.lane.Id, StaticPool.leds, cameraList, this.lane.controlUnits.ToList(), false).ShowDialog();
            GetShortcutConfig();

            var newConfig = NewtonSoftHelper<LaneDirectionConfig>.DeserializeObjectFromPath(
                                                      PathManagement.appLaneDirectionConfigPath(this.lane.Id)) ?? LaneDirectionConfig.CreateDefault();

            bool isChangeDisplayConfig = false;
            if (!laneDirection.IsSameConfig(newConfig))
            {
                laneDirection = newConfig;
                UpdateLaneGUI();
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
                bool isConfirm = MessageBox.Show("Bạn có muốn in phiếu thu?", "In hóa đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
                if (!isConfirm)
                {
                    return;
                }
                AppData.printer.PrintPhieuThu(File.ReadAllText(printTemplatePath), lastEvent.Identity.Name, lastEvent.IdentityGroup.Name, null,
                                                      lastEvent.EventIn.DateTimeIn ?? DateTime.Now, lastEvent.DatetimeOut ?? DateTime.Now,
                                                      lastEvent.PlateNumber, TextFormatingTool.GetMoneyFormat(lastEvent.Charge.ToString()), lastEvent.Charge);
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
                var imageDatas = SaveAllCameraImage();
                var response = await AppData.ApiServer.parkingProcessService.CreateAlarmAsync("", this.lane.Id, "", AbnormalCode.OpenBarrierByKeyboard, imageDatas, false, "", "", "", "");
                if (response != null)
                {
                    BaseLane.SaveImage(response.images, imageDatas);
                }
            }
            else if ((DateTime.Now - lastEvent.DatetimeOut)?.TotalSeconds >= StaticPool.appOption.AllowBarrieDelayOpenTime)
            {
                var imageDatas = SaveAllCameraImage();

                var response = await AppData.ApiServer.parkingProcessService.CreateAlarmAsync(lastEvent.Identity?.Code, this.lane.Id, lastEvent.PlateNumber, AbnormalCode.OpenBarrierByKeyboard,
                                                            imageDatas, false,
                                                            lastEvent?.IdentityGroup?.Id.ToString() ?? "", "", "", "");
                if (response != null)
                {
                    BaseLane.SaveImage(response.images, imageDatas);
                }
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
            frmReportIn frm = new frmReportIn(defaultImg, AppData.ApiServer, true);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                Identity identity = (await AppData.ApiServer.parkingDataService.GetIdentityByIdAsync(frm.selectedIdentityId)).Item1;
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
                            var imageDatas = SaveAllCameraImage();

                            var response = await AppData.ApiServer.parkingProcessService.CreateAlarmAsync(lastEvent.Identity?.Code, this.lane.Id, lastEvent.PlateNumber, AbnormalCode.ManualEvent,
                                                                         imageDatas, false,
                                                                         lastEvent?.IdentityGroup?.Id.ToString() ?? "", "", "", "");
                            if (response != null)
                            {
                                BaseLane.SaveImage(response.images, imageDatas);
                            }
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
            int count = panelCameras.Controls.OfType<ucCameraView>().ToList().Count;
            int marginHeight = 5;
            int displayRegionHeight = panelCameras.Height - label4.Height - marginHeight;
            foreach (ucCameraView item in panelCameras.Controls.OfType<ucCameraView>())
            {
                if (laneDirection.cameraDirection == LaneDirectionConfig.EmCameraDirection.Vertical)
                {
                    int newWidth = panelCameras.Width - panelCameras.Margin.Left - panelCameras.Margin.Right -
                                                        panelCameras.Padding.Left - panelCameras.Padding.Right
                                                    - /*item.Margin.Left - item.Margin.Right -*/ item.Padding.Left - item.Padding.Right;
                    item.ChangeByWidth(new Size(newWidth, (displayRegionHeight) / count), this.laneDirection.cameraResolutionDisplay);
                }
                else
                {
                    item.ChangeByHeight(new Size((panelCameras.Width - panelCameras.Margin.Left - panelCameras.Margin.Right - panelCameras.Padding.Left - panelCameras.Padding.Right
                                                /*- item.Margin.Left - item.Margin.Right*/ - item.Padding.Left - item.Padding.Right) / count, panelCameras.Height - 50), this.laneDirection.cameraResolutionDisplay);
                }
            }
            for (int i = 0; i < panelCameras.Controls.OfType<ucCameraView>().ToList().Count; i++)
            {
                var item = panelCameras.Controls.OfType<ucCameraView>().ToList()[i];
                if (i == 0)
                {
                    item.Location = new Point(0, label4.Height);
                    item.BringToFront();
                }
                else
                {
                    Control lastControl = panelCameras.Controls.OfType<ucCameraView>().ToList()[i - 1];
                    if (laneDirection.cameraDirection == LaneDirectionConfig.EmCameraDirection.Vertical)
                    {
                        Point location = new Point(lastControl.Location.X, lastControl.Location.Y + lastControl.Height + marginHeight);
                        panelCameras.Controls.OfType<ucCameraView>().ToList()[i].Location = location;
                    }
                    else
                    {
                        Point location = new Point(lastControl.Location.X + lastControl.Width + 3, lastControl.Location.Y);
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
            onControlSizeChangeEventInvoke(this, new ControlSizeChangedEventArgs()
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
            await Task.Delay(1000);
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
                this.ActiveControl = lblLaneName;
                lblLaneName.Focus();
            }));
        }
        private void UpdateLaneGUI()
        {
            laneDirection = NewtonSoftHelper<LaneDirectionConfig>.DeserializeObjectFromPath(
                                                                   PathManagement.appLaneDirectionConfigPath(this.lane.Id)) ?? LaneDirectionConfig.CreateDefault();
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

                lblResult.UpdateResultMessage(StaticPool.oemConfig.AppName, Color.DarkBlue);
                FocusOnTitle();
            }));
        }

        private void ShowEventInData(EventOutData eventOut)
        {
            if (eventOut == null) return;
            if (eventOut.EventIn == null) return;
            if (eventOut.EventIn.images == null) return;

            this.Invoke(new Action(async () =>
            {
                lblPlateIn.Text = eventOut.EventIn.PlateNumber ?? "";
                ImageData? displayOverviewInImage = eventOut.EventIn.images.ContainsKey(EmParkingImageType.Overview) ? eventOut.EventIn.images[EmParkingImageType.Overview][0] : null;
                ImageData? vehicleInImage = eventOut.EventIn.images.ContainsKey(EmParkingImageType.Vehicle) ? eventOut.EventIn.images[EmParkingImageType.Vehicle][0] : null;
                ImageData? lprCutImahe = eventOut.EventIn.images.ContainsKey(EmParkingImageType.Plate) ? eventOut.EventIn.images[EmParkingImageType.Plate][0] : null;

                var overviewInTask = AppData.ApiServer.parkingProcessService.GetImageUrl(displayOverviewInImage?.bucket ?? "", displayOverviewInImage?.objectKey ?? "");
                var vehicleInTask = AppData.ApiServer.parkingProcessService.GetImageUrl(vehicleInImage?.bucket ?? "", vehicleInImage?.objectKey ?? "");
                var lprInTask = AppData.ApiServer.parkingProcessService.GetImageUrl(lprCutImahe?.bucket ?? "", lprCutImahe?.objectKey ?? "");

                await Task.WhenAll(overviewInTask, vehicleInTask, lprInTask);

                picLprImageIn.ShowImageUrlAsync(lprInTask.Result);
                picVehicleImageIn.ShowImageUrlAsync(vehicleInTask.Result);
                picOverviewImageIn.ShowImageUrlAsync(overviewInTask.Result);
            }));

        }

        private Dictionary<EmParkingImageType, List<List<byte>>> SaveAllCameraImage()
        {
            var imageData = new Dictionary<EmParkingImageType, List<List<byte>>>();
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
                        imageData.Add(EmParkingImageType.Overview, new List<List<byte>>() { overviewImg.ImageToByteArray() });
                        break;
                    case CameraPurposeType.EmCameraPurposeType.CarLPR:
                        carVehicleImage = ucCarLpr?.GetFullCurrentImage();
                        if (!imageData.ContainsKey(EmParkingImageType.Vehicle))
                            imageData.Add(EmParkingImageType.Vehicle, new List<List<byte>>() { carVehicleImage.ImageToByteArray() });
                        break;
                    case CameraPurposeType.EmCameraPurposeType.MotorLPR:
                        motorVehicleImage = ucMotoLpr?.GetFullCurrentImage();
                        if (!imageData.ContainsKey(EmParkingImageType.Vehicle))
                            imageData.Add(EmParkingImageType.Vehicle, new List<List<byte>>() { motorVehicleImage.ImageToByteArray() });
                        break;
                    default:
                        break;
                }
            }
            return imageData;
        }

        private void DisplayEventOutInfo(DateTime? timeIn, DateTime timeOut, string plateNumber, Identity identity, IdentityGroup? identityGroup, VehicleBaseType vehicle,
                                         RegisteredVehicle? registerVehicle, long fee, Customer? customer, WeighingDetail? weighingDetail = null, string thirdPartyNote = "", string note = "")
        {
            laneDirection = NewtonSoftHelper<LaneDirectionConfig>.DeserializeObjectFromPath(
                                                     PathManagement.appLaneDirectionConfigPath(this.lane.Id)) ?? LaneDirectionConfig.CreateDefault();
            dgvEventContent!.Invoke(new Action(() =>
            {
                dgvEventContent.Columns[0].Visible = laneDirection.IsDisplayTitle;

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
                    dgvEventContent.Rows.Add("Hết hạn", registerVehicle.ExpireTime?.ToString("dd/MM/yyyy HH:mm:ss"));
                }

                dgvEventContent.Rows.Add("Nhóm định danh", identityGroup?.Name);
                dgvEventContent.BringToFront();
                dgvEventContent.CurrentCell = null;
                this.ActiveControl = lblLaneName;
            }));
        }
        private async Task<string> SendInvoice(EventOutData eventOut, string identityGroupName)
        {
            if (AppData.ApiServer.invoiceService == null)
            {
                return "";
            }
            bool isConfirmSendEinvoie = MessageBox.Show($"Bạn có muốn gửi hóa đơn ({TextFormatingTool.GetMoneyFormat(eventOut.Charge.ToString())}) không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
            if (isConfirmSendEinvoie)
            {
                InvoiceResponse? invoiceDto = await AppData.ApiServer.invoiceService.CreateEinvoice(eventOut.Charge, eventOut.EventIn.PlateNumber,
                                                                            eventOut.EventIn.DateTimeIn ?? DateTime.Now, eventOut.DatetimeOut ?? DateTime.Now,
                                                                            eventOut.Id, true, identityGroupName);
                if (invoiceDto != null)
                {
                    return invoiceDto?.id ?? "";
                }
            }
            else
            {
                InvoiceResponse? invoiceDto = await AppData.ApiServer.invoiceService.CreateEinvoice(eventOut.Charge, eventOut.EventIn.PlateNumber,
                                                                           eventOut.EventIn.DateTimeIn ?? DateTime.Now, eventOut.DatetimeOut ?? DateTime.Now,
                                                                           eventOut.Id, false, identityGroupName);
                if (invoiceDto != null)
                {
                    return invoiceDto?.id ?? "";
                }
            }
            return "";

        }
        #endregion END PRIVATE FUNCTION

        #region PUBLIC FUNCTION
        /// <summary>
        /// Tải thông tin cấu hình phím tắt lưu trong hệ thống
        /// </summary>
        public void GetShortcutConfig()
        {
            laneOutShortcutConfig = NewtonSoftHelper<LaneOutShortcutConfig>.DeserializeObjectFromPath(PathManagement.laneShortcutConfigPath(this.lane.Id)) ?? new LaneOutShortcutConfig();
            controllerShortcutConfigs = NewtonSoftHelper<List<ControllerShortcutConfig>>.DeserializeObjectFromPath(PathManagement.laneControllerShortcutConfigPath(this.lane.Id)) ?? new List<ControllerShortcutConfig>();
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
                if (this.laneDisplayConfig.splitContainerCameraPosition > 0)
                {
                    this.splitContainerCamera.SplitterDistance = this.laneDisplayConfig.splitContainerCameraPosition;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.Form, "DisplayUIConfig", "splitterEventInfoWithCamera-SplitPosition", ex);
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
                LaneId = this.lane.Id,
                DisplayIndex = 1,
                splitContainerEventContent = this.splitContainerEventContent.SplitterDistance,
                splitContainerMain = this.splitContainerMain.Panel2Collapsed ? this.splitContainerMain.Height : this.splitContainerMain.SplitterDistance,
                SplitterCameraPosition = this.splitterCamera.SplitPosition,
                splitEventInfoWithCameraPosition = this.splitterEventInfoWithCamera.SplitPosition,
                splitContainerCameraPosition = this.splitContainerCamera.SplitterDistance,
            };
        }

        /// <summary>
        /// Có sự kiện từ bộ điều khiển hoặc người dùng
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public async Task OnNewEvent(EventArgs e)
        {
            timerRefreshUI.Enabled = false;
            time_refresh = 0;
            await semaphoreSlimOnNewEvent.WaitAsync();
            try
            {
                if (e is CardEventArgs cardEvent)
                {
                    await ExcecuteCardEvent(cardEvent);
                }
                else if (e is InputEventArgs inputEvent)
                {
                    await ExcecuteInputEvent(inputEvent, lblResult);
                }
            }
            finally
            {
                semaphoreSlimOnNewEvent.Release();
            }
            if (StaticPool.oemConfig.IsAutoReturnToDefault)
            {
                timerRefreshUI.Enabled = true;
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
                    splitContainerCamera.Height = 200;
                    break;
                case LaneDirectionConfig.EmDisplayDirection.HorizontalLeftToRight:
                    splitterEventInfoWithCamera.Dock = DockStyle.Right;
                    panelEventData.Dock = DockStyle.Right;
                    splitContainerCamera.Width = 200;
                    break;
                case LaneDirectionConfig.EmDisplayDirection.HorizontalRightToLeft:
                    splitterEventInfoWithCamera.Dock = DockStyle.Left;
                    panelEventData.Dock = DockStyle.Left;
                    splitContainerCamera.Width = 200;
                    break;
                default:
                    break;
            }

            switch (laneDirection.cameraPicDirection)
            {
                case LaneDirectionConfig.EmCameraPicFunction.Vertical:
                    splitterCamera.Dock = DockStyle.Top;
                    splitContainerCamera.Dock = DockStyle.Top;
                    splitContainerCamera.Height = 100;
                    break;
                case LaneDirectionConfig.EmCameraPicFunction.HorizontalLeftToRight:
                    splitContainerCamera.Width = 100;
                    splitContainerCamera.Dock = DockStyle.Left;
                    splitterCamera.Dock = DockStyle.Left;

                    break;
                case LaneDirectionConfig.EmCameraPicFunction.HorizontalRightToLeft:
                    splitContainerCamera.Width = 100;
                    splitContainerCamera.Dock = DockStyle.Right;
                    splitterCamera.Dock = DockStyle.Right;
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
        int time_refresh = 0;

        private void timerRefreshUI_Tick(object sender, EventArgs e)
        {
            time_refresh++;
            if (time_refresh >= StaticPool.oemConfig.TimeToDefautUI)
            {
                ClearView();
                timerRefreshUI.Enabled = false;
            }
        }
    }
}