using IPaking.Ultility;
using iPakrkingv5.Controls;
using iPakrkingv5.Controls.Controls.Labels;
using iParkingv5.ApiManager.KzParkingv5Apis.services;
using iParkingv5.Controller;
using iParkingv5.Objects;
using iParkingv5.Objects.Configs;
using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Datas.Device_service;
using iParkingv5.Objects.Datas.parking_service;
using iParkingv5.Objects.Datas.ThirtParty.OfficeHaus;
using iParkingv5.Objects.Datas.weighing_service;
using iParkingv5.Objects.Enums;
using iParkingv5.Objects.EventDatas;
using iParkingv5.Objects.Events;
using iParkingv5_window.Forms.DataForms;
using iParkingv5_window.Forms.ThirdPartyForms.OfficeHausForms;
using iParkingv5_window.Usercontrols.ShortcutConfiguration;
using iParkingv6.Objects.Datas;
using Kztek.Helper;
using Kztek.Tool;
using Kztek.Tools;
using System.Data;
using System.Windows.Forms;
using static iParkingv5.Objects.Configs.LaneDirectionConfig;
using static iParkingv5.Objects.Enums.ParkingImageType;
using static iParkingv5.Objects.Enums.PrintHelpers;
using static iParkingv5.Objects.Enums.VehicleType;

namespace iParkingv5_window.Usercontrols
{
    public partial class ucLaneIn : ucBaseLane, iLane, IDisposable
    {
        #region PROPERTIES
        #region Config
        private LaneInShortcutConfig? laneInShortcutConfig = null;
        #endregion

        #region -- Event Properties
        EventInData? lastEvent = null;
        private bool isInRegisterMode = false;
        public static Image defaultImg = Image.FromFile(frmMain.defaultImagePath);
        private List<string> allowAlarmMessage = new List<string>()
        {
            "Biển số không hợp lệ".ToUpper(),
        };
        #endregion

        #endregion END PROPERTIES

        #region FORMS
        public ucLaneIn(Lane lane, LaneDisplayConfig? laneDisplayConfig)
        {
            InitializeComponent();

            this.lane = lane;
            this.laneDisplayConfig = laneDisplayConfig;

            this.DoubleBuffered = true;

            laneDirection = NewtonSoftHelper<LaneDirectionConfig>.DeserializeObjectFromPath(PathManagement.appLaneDirectionConfigPath(this.lane.Id)) ??
                            LaneDirectionConfig.CreateDefault();

        }
        public void DispayUI()
        {
            if (StaticPool.appOption.PrintTemplate != (int)EmPrintTemplate.OfficeHaus)
            {
                panelThirdParty.Visible = false;
            }
            //panelCameras.SuspendLayout();
            //panelNearestEvent.SuspendLayout();
            //splitContainerEventContent.SuspendLayout();
            //this.SuspendLayout();

            lblLaneName.Text = lane.name;
            lblLaneName.BackColor = SuccessColor;

            panelDisplayLastEvent.Visible = laneDirection.IsDisplayLastEvent;
            splitContainerMain.Panel2Collapsed = !laneDirection.IsDisplayLastEvent;
            panelLastEvent.Visible = laneDirection.IsDisplayLastEvent;

            GetShortcutConfig();
            LoadCamera(panelCameras);

            CreateUI();
            RegisterUIEvent();

            SetDisplayDirection();
            DisplayUIConfig();

            //panelCameras.ResumeLayout(false);
            //panelCameras.PerformLayout();

            //panelNearestEvent.ResumeLayout(false);
            //panelNearestEvent.PerformLayout();

            //splitContainerEventContent.ResumeLayout(false);
            //splitContainerEventContent.PerformLayout();

            this.ResumeLayout(false);
            this.PerformLayout();

            try
            {
                this.ActiveControl = lblLaneName;
            }
            catch (Exception)
            {
            }
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
            foreach (var cam in this.camBienSoOTODuPhongs)
            {
                cam?.Stop();
            }
            foreach (var cam in this.camBienSoXeMayDuPhongs)
            {
                cam?.Stop();
            }
            ucEventCount1.Stop();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion END FORMS

        #region EVENT
        public async void OnKeyPress(Keys keys)
        {
            await semaphoreSlimOnKeyPress.WaitAsync();
            try
            {
                if (keys == Keys.F9)
                {
                    this.Invoke(new Action(() =>
                    {
                        this.AllowDesignRealtime(!this.IsAllowDesignRealtime);
                    }));
                }

                if (laneInShortcutConfig != null)
                {
                    if ((int)keys == laneInShortcutConfig.ConfirmPlateKey && txtPlate.Focused && this.lastEvent != null)
                    {
                        string newPlate = string.Empty;
                        this.Invoke(new Action(() =>
                        {
                            txtPlate.Text = txtPlate.Text.ToUpper().Replace("-", "").Replace(".", "").Trim();
                            newPlate = txtPlate.Text;
                        }));
                        bool isUpdateSuccess = await AppData.ApiServer.parkingProcessService.UpdateEventInPlateAsync(lastEvent.Id, newPlate, lastEvent.PlateNumber);
                        if (isUpdateSuccess)
                        {
                            lblResult.UpdateResultMessage("Ra Lệnh Cập Nhật Biển Số Thành Công", ProcessColor);
                            lastEvent.PlateNumber = newPlate;
                            FocusOnTitle();
                        }
                        else
                        {
                            lblResult.UpdateResultMessage("Cập nhật lỗi, vui lòng thử lại", ProcessColor);
                            FocusOnTitle();
                        }
                    }
                    else if ((int)keys == laneInShortcutConfig.ReserveLane)
                    {
                        if (!string.IsNullOrEmpty(this.lane.reverseLaneId?.ToString()))
                        {
                            //Đảo làn
                            this.Invoke(new Action(() =>
                            {
                                var config = SaveUIConfig();
                                NewtonSoftHelper<LaneDisplayConfig>.SaveConfig(config, PathManagement.appDisplayConfigPath(this.lane.Id));
                            }));
                            lblResult.UpdateResultMessage("Ra Lệnh Đảo Làn", ProcessColor);
                            OnChangeLaneEventInvoke(this);
                            this.Dispose();
                            return;
                        }
                        else
                        {
                            lblResult.UpdateResultMessage("Không có cấu hình làn đảo", ProcessColor);
                        }
                    }
                    else if ((int)keys == laneInShortcutConfig.WriteIn)
                    {
                        lblResult.UpdateResultMessage("Ra Lệnh Ghi Vé Vào", ProcessColor);
                        btnWriteIn?.Invoke(new Action(() =>
                        {
                            btnWriteIn.PerformClick();
                        }));
                    }
                    else if ((int)keys == laneInShortcutConfig.ReSnapshotKey)
                    {
                        lblResult.UpdateResultMessage("Ra lệnh chụp lại", ProcessColor);
                        picRetakePhoto?.Invoke(new Action(() =>
                        {
                            BtnReTakePhoto_Click(null, null);
                        }));
                    }
                }

                if (this.controllerShortcutConfigs != null)
                {
                    foreach (var controllerShortcutConfig in controllerShortcutConfigs)
                    {
                        foreach (var item in controllerShortcutConfig.KeySetByRelays)
                        {
                            if (item.Value != (int)keys)
                            {
                                continue;
                            }
                            string controllerId = controllerShortcutConfig.ControllerId;
                            int barrieIndex = item.Key;
                            foreach (IController controller in frmMain.controllers)
                            {
                                if (controller.ControllerInfo.Id.ToLower() != controllerId.ToLower())
                                {
                                    continue;
                                }
                                lblResult.UpdateResultMessage("Ra Lệnh Mở Barrie" + barrieIndex, ProcessColor);

                                //Ra lệnh mở cửa
                                await controller.OpenDoor(100, barrieIndex);

                                //Lưu lại cảnh báo mở barrie bằng nút nhấn
                                await ProcessButtonEvent();

                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.System, obj: ex);
            }
            finally
            {
                semaphoreSlimOnKeyPress.Release();
            }
        }

        /// <summary>
        /// Sự kiện xảy ra khi xe đi qua vòng từ
        /// </summary>
        /// <param name="ie"></param>
        /// <returns></returns>
        public override async Task ExcecuteLoopEvent(InputEventArgs ie)
        {
            ClearView();

            EventInData? eventIn = null;

            //Danh sách biến sử dụng
            Image? overviewImg = null;
            List<Image?> optionalImages = new();
            bool isAlarm = false;
            var lprResult = new LoopLprResult();

            lblResult.UpdateResultMessage("Nhận dạng biển số", ProcessColor);
            overviewImg = ucOverView?.GetFullCurrentImage();
            lprResult = await LoopLprDetection();

            //Hiển thị hình ảnh
            BaseLane.ShowImage(picVehicleImage, lprResult.VehicleImage);
            BaseLane.ShowImage(picOverviewImage, overviewImg);
            DisplayDetectedPlate(lprResult.PlateNumber, lprResult.LprImage);

            if (lprResult.Vehicle == null)
            {
                lblResult.UpdateResultMessage("Phương tiện chưa được đăng ký trong hệ thống", ErrorColor);
                return;
            }

            lblResult.UpdateResultMessage("Đang check in..." + lprResult.PlateNumber, ProcessColor);
            string customerId = lprResult.Vehicle.CustomerId;
            Customer? customer = string.IsNullOrEmpty(customerId) ?
                                           null : customer = (await AppData.ApiServer.parkingDataService.GetCustomerByIdAsync(customerId))?.Item1;

            List<EmParkingImageType> validImageTypes = BaseLane.GetValidImageType(overviewImg, lprResult.VehicleImage, lprResult.LprImage);
            var eventInResaponse = await AppData.ApiServer.parkingProcessService.PostCheckInAsync(lane.Id, lprResult.PlateNumber, null, validImageTypes,
                                                                                                  false, lprResult.Vehicle);

            var checkInOutResponse = CheckEventInReponse(eventInResaponse, customer, lprResult.Vehicle.vehicleType, lprResult.PlateNumber, false);
            if (!checkInOutResponse.IsValidEvent)
            {
                if (checkInOutResponse.IsContinueExcecute)
                {
                    bool isConfirm = new frmConfirm(checkInOutResponse.ErrorMessage).ShowDialog() == DialogResult.OK;
                    if (!isConfirm)
                    {
                        return;
                    }
                    checkInOutResponse = CheckEventInReponse(eventInResaponse, customer, lprResult.Vehicle.vehicleType, lprResult.PlateNumber, true);
                    if (!checkInOutResponse.IsValidEvent)
                        return;
                }
                else
                {
                    return;
                }
            }
            eventIn = checkInOutResponse.eventIn!;
            if (eventIn.OpenBarrier)
            {
                ControllerInLane? controllerInLane = (from _controllerInLane in this.lane.controlUnits
                                                      where _controllerInLane.controlUnitId == ie.DeviceId
                                                      select _controllerInLane).FirstOrDefault();
                await BaseLane.OpenBarrieByControllerId(ie.DeviceId, controllerInLane, this);
            }
            else
            {
                bool isOpenBarrie = new frmConfirm("Bạn có muốn mở Barrie không?").ShowDialog() == DialogResult.OK;
                if (isOpenBarrie)
                {
                    ControllerInLane? controllerInLane = (from _controllerInLane in this.lane.controlUnits
                                                          where _controllerInLane.controlUnitId == ie.DeviceId
                                                          select _controllerInLane).FirstOrDefault();
                    await BaseLane.OpenBarrieByControllerId(ie.DeviceId, controllerInLane, this);
                }
            }

            await ExcecuteValidEvent(null, null, lprResult.Vehicle.vehicleType, lprResult.PlateNumber, eventIn.DateTimeIn ?? ie.EventTime, overviewImg,
                                    lprResult.VehicleImage, lprResult.LprImage, eventIn, isAlarm);
        }

        /// <summary>
        /// Sự kiện xảy ra khi người dùng bấm nút EXIT (nút cứng) để ra lệnh mở barrie
        /// </summary>
        /// <param name="ie"></param>
        /// <returns></returns>
        public override async Task ExcecuteExitEvent(InputEventArgs ie)
        {
            lblResult.UpdateResultMessage("Đang kiểm trang thông tin sự kiện exit..." + ie.InputIndex, ProcessColor);
            //--Chưa có sự kiện vào hoặc thời gian từ lúc có sự kiện đến khi bấm mở barrie quá 5s thì lưu sự kiện cảnh báo
            if (lastEvent == null)
            {
                var imageData = GetAllCameraImage();
                var response = await AppData.ApiServer.parkingProcessService.CreateAlarmAsync("", this.lane.Id, "", AbnormalCode.OpenBarrierByButton, imageData, true, "", "", "", "");
                BaseLane.SaveImage(response?.images ?? null, imageData);
                return;
            }

            //Đã có sự kiện trước đó kiểm tra xem có trong thời gian cho phép mở ko
            if ((DateTime.Now - lastEvent.DateTimeIn)?.TotalSeconds >= StaticPool.appOption.AllowBarrieDelayOpenTime)
            {
                var imageData = GetAllCameraImage();

                var response = await AppData.ApiServer.parkingProcessService.CreateAlarmAsync(lastEvent.Identity?.Code, this.lane.Id, lastEvent.PlateNumber, AbnormalCode.OpenBarrierByButton,
                                                             imageData, true,
                                                             lastEvent?.IdentityGroup?.Id.ToString() ?? "", "", "", "");
                BaseLane.SaveImage(response?.images ?? null, imageData);
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
                    lblResult.UpdateResultMessage($"Đang trong thời gian chờ, vui lòng quẹt lại sau {thoiGianCho}s", ProcessColor);
                }
                return;
            }

            ClearView();
            lblResult.UpdateResultMessage("Đang kiểm tra thông tin sự kiện quẹt thẻ..." + ce.PreferCard, ProcessColor);

            #region Kiểm tra thông tin định danh
            var identityResponse = await IsValidIdentity(ce.PreferCard);

            if (!identityResponse.Item1)
            {
                return;
            }
            Identity? identity = identityResponse.Item2!;

            var identityTask = AppData.ApiServer.parkingDataService.GetIdentityByIdAsync(identity.Id);
            var identityGroupTask = AppData.ApiServer.parkingDataService.GetIdentityGroupByIdAsync(identity.IdentityGroupId.ToString());
            await Task.WhenAll(identityTask, identityGroupTask);

            //Cần gọi GET BY ID để lấy thông tin phương tiện đăng ký
            identity = identityTask.Result.Item1;
            if (identity == null || string.IsNullOrEmpty(identity.Id) || identity.Id == Guid.Empty.ToString())
            {
                lblResult.UpdateResultMessage("Không đọc được thông tin định danh, vui lòng thử lại", ErrorColor);
                return;
            }
            #endregion End kiểm tra thông tin định danh

            #region Kiểm tra thông tin nhóm định danh
            IdentityGroup? identityGroup = identityGroupTask.Result.Item1;
            if (identityGroup == null || identityGroup.Id == Guid.Empty)
            {
                lblResult.UpdateResultMessage("Không đọc được thông tin nhóm định danh, vui lòng thử lại", ErrorColor);
                return;
            }
            #endregion End kiểm tra thông tin nhóm định danh

            #region Kiểm tra thông tin loại phương tiện
            VehicleBaseType vehicleBaseType = identityGroup.VehicleType;
            if (vehicleBaseType == VehicleBaseType.Unknown)
            {
                lblResult.UpdateResultMessage("Thông tin loại phương tiện không hợp lệ, vui lòng kiểm tra thông tin định danh", ErrorColor);
                return;
            }
            #endregion End kiểm tra thông tin loại phương tiện

            Image? overviewImg = ucOverView?.GetFullCurrentImage();
            Image? vehicleImg = null;
            Image? lprImage = GetPlate(ce, ref overviewImg, ref vehicleImg, vehicleBaseType, lblResult, txtPlate, picOverviewImage, picVehicleImage, picLprImage);

            //Đọc thông tin loại phương tiện
            lblResult.UpdateResultMessage("Đang kiểm tra thông tin..." + ce.PreferCard, ProcessColor);
            try
            {
                bool isMonthCard = identityGroup.Type == IdentityGroupType.Monthly;
                if (isMonthCard)
                {
                    await ExcecuteMonthCardEventIn(identity, identityGroup, vehicleBaseType, ce.PlateNumber,
                                                   ce, controllerInLane,
                                                   overviewImg, vehicleImg, lprImage);
                }
                else
                {
                    await ExcecuteNonMonthCardEventIn(identity, identityGroup, vehicleBaseType, ce.PlateNumber,
                                                      ce, controllerInLane,
                                                      overviewImg, vehicleImg, lprImage);
                }
            }
            catch (Exception ex)
            {
                lblResult.UpdateResultMessage("Gặp lỗi trong quá trình xử lý, vui lòng thử lại", ErrorColor);
                LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.System, obj: ex);
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
                var imageData = GetAllCameraImage();
                var response = await AppData.ApiServer.parkingProcessService.CreateAlarmAsync("", this.lane.Id, "", AbnormalCode.OpenBarrierByKeyboard, imageData, true, "", "", "", "");
                if (response != null)
                {
                    _ = BaseLane.SaveImage(response.images, imageData);
                }
            }
            else if ((DateTime.Now - lastEvent.DateTimeIn)?.TotalSeconds >= StaticPool.appOption.AllowBarrieDelayOpenTime)
            {
                var imageData = GetAllCameraImage();
                var response = await AppData.ApiServer.parkingProcessService.CreateAlarmAsync(lastEvent.Identity?.Code, this.lane.Id, lastEvent.PlateNumber, AbnormalCode.OpenBarrierByKeyboard,
                                                        imageData, true,
                                                        lastEvent?.IdentityGroup?.Id.ToString() ?? "", "", "", "");
                if (response != null)
                {
                    _ = BaseLane.SaveImage(response.images, imageData);
                }
            }
        }
        #endregion End EVENT

        #region Private Function
        private async Task CreateUI()
        {
            lblResult.Padding = new Padding(StaticPool.baseSize);
            lblResult.UpdateResultMessage(StaticPool.oemConfig.AppName, SuccessColor);

            List<string> controllerShortcut = new List<string>();

            if (controllerShortcutConfigs != null)
            {
                controllerShortcut = controllerShortcutConfigs
                    .SelectMany(config => config.KeySetByRelays.Values)
                    .Select(key => ((Keys)key).ToString())
                    .ToList();
            }

            SetupToolTip(toolTipOpenBarrie, picOpenBarrie, "Mở Barrie", string.Join(",", controllerShortcut));
            SetupToolTip(toolTipReTakePhoto, picRetakePhoto, "Chụp Lại", () => ((Keys)laneInShortcutConfig?.ReSnapshotKey).ToString());
            SetupToolTip(toolTipWriteIn, picWriteIn, "Ghi Vé Vào", () => ((Keys)laneInShortcutConfig?.WriteIn).ToString());
            SetupToolTip(toolTipSetting, picSetting, "Cấu hình ứng dụng", "");

            List<PictureBox> displayEventPics = new List<PictureBox>() { picLprImage, picOverviewImage, picVehicleImage, };
            foreach (var item in displayEventPics)
            {
                item.Image = item.InitialImage = item.ErrorImage = defaultImg;
            }

            //Get Top3 Event
            DateTime startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            DateTime endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            // 
            // ucEventCount1
            // 
            ucEventCount1.Location = new Point(0, 0);
            ucEventCount1.Name = "ucEventCount1";
            ucEventCount1.Size = new Size(250, 161);
            ucEventCount1.TabIndex = 7;

            ucTop3Event = new ucLastEventInfo(false);
            ucTop2Event = new ucLastEventInfo(true);
            ucTop1Event = new ucLastEventInfo(true);
            ucTop3Event.Size = new Size(250, 0);
            ucTop2Event.Size = new Size(250, 0);
            ucTop1Event.Size = new Size(250, 0);
            ucTop1Event.Size = ucTop2Event.Size = ucTop3Event.Size = panelNearestEvent.Width > 750 ? new Size(250, 0) : new Size(125, 0);

            panelNearestEvent.Controls.Add(ucTop3Event);
            panelNearestEvent.Controls.Add(ucTop2Event);
            panelNearestEvent.Controls.Add(ucTop1Event);
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
            ucTop1Event.onChoosen += UcTopEvent_onChoosen;
            ucTop2Event.onChoosen += UcTopEvent_onChoosen;
            ucTop3Event.onChoosen += UcTopEvent_onChoosen;
            var top3Event = (await AppData.ApiServer.reportingService.GetEventIns("", startTime, endTime, "", "", this.lane.Id, "", 0, 3)).data;
            if (top3Event != null)
            {
                for (int i = 0; i < top3Event.Count; i++)
                {
                    if (ucLastEventInfos.Count <= i)
                    {
                        continue;
                    }
                    ucLastEventInfos[i].UpdateEventInfo(top3Event[i].Id, top3Event[i].images);
                }
            }

            splitContainerMain.BringToFront();
        }

        private void RegisterUIEvent()
        {
            panelCameras.SizeChanged += PanelCameras_SizeChanged;
            splitContainerEventContent.SizeChanged += SplitContainerEventContent_SizeChanged;
            splitContainerMain.MouseDoubleClick += SplitContainerEventContent_MouseDoubleClick;

            List<PictureBox> picSettings = new List<PictureBox>()
            {
                picSetting, picRetakePhoto, picOpenBarrie, picWriteIn
            };
            foreach (var pic in picSettings)
            {
                pic.MouseHover += Pic_MouseHover;
                pic.MouseLeave += Pic_MouseLeave;
            }
        }

        private void DisplayEventInfo(DateTime eventTime, string plateNumber, Identity? identity, IdentityGroup? identityGroup, VehicleBaseType? vehicle,
                                      Customer? customer, RegisteredVehicle? registeredVehicle, WeighingDetail? weighingDetail = null)
        {
            laneDirection = NewtonSoftHelper<LaneDirectionConfig>.DeserializeObjectFromPath(
                                                      PathManagement.appLaneDirectionConfigPath(this.lane.Id)) ?? LaneDirectionConfig.CreateDefault();
            dgvEventContent?.Invoke(new Action(() =>
            {
                dgvEventContent.Columns[0].Visible = laneDirection.IsDisplayTitle;
            }));
            dgvEventContent?.Invoke(new Action(() =>
            {
                dgvEventContent.Rows.Clear();
                dgvEventContent.Rows.Add("Giờ Vào", eventTime.ToString("dd/MM/yyyy HH:mm:ss"));
                dgvEventContent.Rows.Add("Vé Xe", identity?.Name + " - " + identity?.Code);
                if (customer != null)
                {
                    dgvEventContent.Rows.Add("Khách hàng", customer.Name + " / " + customer.Address);
                    dgvEventContent.Rows.Add("SĐT", customer.PhoneNumber);
                }
                if (registeredVehicle != null)
                {
                    dgvEventContent.Rows.Add("BSĐK", registeredVehicle.Name + "/" + registeredVehicle.PlateNumber);
                    dgvEventContent.Rows.Add("Hết hạn", registeredVehicle.ExpireTime);
                }
                if (identityGroup != null)
                {
                    dgvEventContent.Rows.Add("Nhóm", identityGroup.Name);
                }
                dgvEventContent.BringToFront();
            }));
        }

        private Dictionary<EmParkingImageType, List<List<byte>>> GetAllCameraImage()
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

        private void ClearView()
        {
            this.Invoke(new Action(() =>
            {
                dgvEventContent.Rows.Clear();
                dgvEventContent.Refresh();

                picOverviewImage.Image = defaultImg;
                picOverviewImage.Refresh();

                picLprImage.Image = defaultImg;
                picLprImage.Refresh();

                picVehicleImage.Image = defaultImg;
                picVehicleImage.Refresh();

                txtPlate.Text = string.Empty;
                txtPlate.Refresh();

                lblResult.UpdateResultMessage(StaticPool.oemConfig.AppName, SuccessColor);
                lblResult.Refresh();
            }));
        }
        private void SetupToolTip(ToolTip toolTip, Control control, string baseText, Func<string> additionalTextProvider)
        {
            toolTip.SetToolTip(control, $"{baseText} {additionalTextProvider()}");
            toolTip.OwnerDraw = true;
            toolTip.Draw += (sender, e) =>
            {
                Font customFont = new Font("Arial", 16, FontStyle.Bold);
                e.DrawBackground();
                e.DrawBorder();
                e.Graphics.DrawString($"{baseText} {additionalTextProvider()}", customFont, Brushes.Black, new PointF(2, 2));
            };
            toolTip.Popup += (sender, e) =>
            {
                e.ToolTipSize = TextRenderer.MeasureText($"{baseText} {additionalTextProvider()}", new Font("Segoe UI", 16, FontStyle.Bold));
            };
        }
        private void SetupToolTip(ToolTip toolTip, Control control, string baseText, string additionalText)
        {
            toolTip.SetToolTip(control, $"{baseText} {additionalText}");
            toolTip.OwnerDraw = true;
            toolTip.Draw += (sender, e) =>
            {
                Font customFont = new Font("Arial", 16, FontStyle.Bold);
                e.DrawBackground();
                e.DrawBorder();
                e.Graphics.DrawString($"{baseText} {additionalText}", customFont, Brushes.Black, new PointF(2, 2));
            };
            toolTip.Popup += (sender, e) =>
            {
                e.ToolTipSize = TextRenderer.MeasureText($"{baseText} {additionalText}", new Font("Segoe UI", 16, FontStyle.Bold));
            };
        }
        #endregion End Private Function

        #region Xử lý sự kiện thẻ
        private async Task ExcecuteMonthCardEventIn(Identity identity, IdentityGroup identityGroup,
                                                    VehicleBaseType vehicleType, string plateNumber,
                                                    CardEventArgs ce, ControllerInLane? controllerInLane,
                                                    Image? overviewImg, Image? vehicleImg, Image? lprImage)
        {
            bool isAlarm = false;
            string errorMessage = string.Empty;
            List<EmParkingImageType> validImageTypes = BaseLane.GetValidImageType(overviewImg, vehicleImg, lprImage);

            if (identity.Vehicles == null)
            {
                lblResult.UpdateResultMessage("Thẻ tháng chưa đăng ký phương tiện", ErrorColor);
                return;
            }

            if (identity.Vehicles.Count == 0)
            {
                lblResult.UpdateResultMessage("Thẻ tháng chưa đăng ký phương tiện", ErrorColor);
                return;
            }

            EventInData? eventIn = null;
            if (string.IsNullOrEmpty(plateNumber) && identityGroup.PlateNumberValidation != (int)EmPlateCompareRule.UnCheck)
            {
                bool isConfirm = false;
                if (identity.Vehicles.Count == 1)
                {
                    string message = "Không nhận diện được biển số, bạn có muốn cho xe vào bãi?";
                    var customer = (await AppData.ApiServer.parkingDataService.GetCustomerByIdAsync(identity.Vehicles[0].CustomerId)).Item1;
                    frmConfirmIn frmConfirmIn = new frmConfirmIn(message, identity, identityGroup, customer, identity.Vehicles[0],
                                                                             plateNumber, vehicleImg, overviewImg);
                    isConfirm = frmConfirmIn.ShowDialog() == DialogResult.OK;
                    if (isConfirm)
                    {
                        plateNumber = identity.Vehicles[0].PlateNumber;
                        isAlarm = true;
                    }
                }
                else
                {
                    var frmSelectVehicle = new frmSelectVehicle(identity.Vehicles);
                    isConfirm = frmSelectVehicle.ShowDialog() == DialogResult.OK;
                    if (isConfirm)
                    {
                        isAlarm = true;
                        plateNumber = frmSelectVehicle.selectedPlate;
                    }
                }
                if (!isConfirm)
                {
                    ClearView();
                    return;
                }
            }


            var eventInResponse = await AppData.ApiServer.parkingProcessService.PostCheckInAsync(lane.Id, plateNumber, identity, validImageTypes, false, null, "");
            var checkInOutResponse = CheckEventInReponse(eventInResponse, null, vehicleType, plateNumber, false);
            if (!checkInOutResponse.IsValidEvent)
            {
                if (!checkInOutResponse.IsContinueExcecute)
                {
                    return;
                }
                bool isConfirm = false;

                if (identity.Vehicles.Count == 1)
                {
                    string message = "Biển số không khớp với biển số đăng ký" + "\r\nBạn có muốn cho xe vào bãi?";
                    var customer = (await AppData.ApiServer.parkingDataService.GetCustomerByIdAsync(identity.Vehicles[0].CustomerId)).Item1;

                    frmConfirmIn frmConfirmIn = new frmConfirmIn(message, identity, identityGroup, customer, identity.Vehicles[0],
                                                                 plateNumber, vehicleImg, overviewImg);
                    isConfirm = frmConfirmIn.ShowDialog() == DialogResult.OK;
                    plateNumber = identity.Vehicles[0].PlateNumber;
                }
                else
                {
                    var frmSelectVehicle = new frmSelectVehicle(identity.Vehicles);
                    isConfirm = frmSelectVehicle.ShowDialog() == DialogResult.OK;
                    if (isConfirm)
                    {
                        isConfirm = true;
                        plateNumber = frmSelectVehicle.selectedPlate;
                    }
                }

                if (!isConfirm)
                {
                    return;
                }

                checkInOutResponse = CheckEventInReponse(eventInResponse, null, vehicleType, plateNumber, true);
                if (!checkInOutResponse.IsValidEvent)
                    return;
            }

            eventIn = checkInOutResponse.eventIn!;
            if (eventIn.OpenBarrier)
            {
                await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane, this);
            }
            else
            {

                string message = "Bạn có muốn mở Barrie?";
                frmConfirm frmConfirm = new frmConfirm(message);
                bool isOpenBarrie = frmConfirm.ShowDialog() == DialogResult.OK;
                if (isOpenBarrie)
                {
                    await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane, this);
                }
            }
            await ExcecuteValidEvent(identity, identityGroup, vehicleType, ce.PlateNumber, ce.EventTime,
                                      overviewImg, vehicleImg, lprImage, eventIn, isAlarm);
        }


        private async Task ExcecuteNonMonthCardEventIn(Identity identity, IdentityGroup identityGroup,
                                                       VehicleBaseType vehicleType, string plateNumber,
                                                       CardEventArgs ce, ControllerInLane? controllerInLane,
                                                       Image? overviewImg, Image? vehicleImg, Image? lprImage)
        {
            List<EmParkingImageType> validImageTypes = BaseLane.GetValidImageType(overviewImg, vehicleImg, lprImage);
            EventInData? eventIn = null;
            bool isAlarm = false;
            if (identityGroup.PlateNumberValidation != (int)EmPlateCompareRule.UnCheck)
            {
                if (string.IsNullOrEmpty(plateNumber))
                {
                    isAlarm = true;
                    string message = "Không nhận diện được biển số, bạn có muốn cho xe vào bãi?";
                    frmConfirm frmConfirm = new frmConfirm(message);
                    bool isConfirm = frmConfirm.ShowDialog() == DialogResult.OK;
                    frmConfirm.Dispose();
                    if (!isConfirm)
                    {
                        ClearView();
                        return;
                    }
                }
            }

            var eventInResponse = await AppData.ApiServer.parkingProcessService.PostCheckInAsync(lane.Id, plateNumber, identity, validImageTypes, false, null, "");
            var checkInOutResponse = CheckEventInReponse(eventInResponse, null, vehicleType, plateNumber, false);
            if (!checkInOutResponse.IsValidEvent)
            {
                if (checkInOutResponse.IsContinueExcecute)
                {
                    frmConfirm frmConfirm = new frmConfirm(checkInOutResponse.ErrorMessage);
                    bool isConfirm = frmConfirm.ShowDialog() == DialogResult.OK;
                    frmConfirm.Dispose();
                    if (!isConfirm)
                    {
                        return;
                    }
                    checkInOutResponse = CheckEventInReponse(eventInResponse, null, vehicleType, plateNumber, true);
                    if (!checkInOutResponse.IsValidEvent)
                        return;
                }
                else
                {
                    return;
                }
            }

            eventIn = checkInOutResponse.eventIn!;
            if (eventIn.OpenBarrier)
            {
                await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane, this);
            }
            else
            {
                frmConfirm frmConfirm = new frmConfirm("Bạn có muốn mở Barrie?");
                bool isOpenBarrie = frmConfirm.ShowDialog() == DialogResult.OK;
                if (isOpenBarrie)
                {
                    await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane, this);
                }
            }
            await ExcecuteValidEvent(identity, identityGroup, vehicleType, ce.PlateNumber, ce.EventTime,
                                      overviewImg, vehicleImg, lprImage, eventIn, isAlarm);
        }

        private void ExcecuteSystemErrorCheckIn()
        {
            lblResult.UpdateResultMessage("Gặp lỗi trong quá trình xử lý, vui lòng thử lại sau giây lát", ErrorColor);
        }
        private void ExcecuteUnvalidEvent(Identity? identity, IdentityGroup? identityGroup, VehicleBaseType vehicleType, string detectPlate,
                                          DateTime eventTime, string errorMessage, Customer? customer, string registerPlate)
        {
            lblResult.UpdateResultMessage(errorMessage, ErrorColor);
            DisplayEventInfo(eventTime, detectPlate, identity, identityGroup, vehicleType, customer, null);
        }

        private async Task ExcecuteValidEvent(Identity? identity, IdentityGroup? identityGroup,
                                              VehicleBaseType vehicleType, string detectPlate,
                                              DateTime eventTime, Image? overviewImg,
                                              Image? vehicleImg, Image? lprImage,
                                              EventInData eventIn, bool isAlarm)
        {
            lblResult.UpdateResultMessage("Xin Mời Qua", SuccessColor);

            RegisteredVehicle? registeredVehicle = eventIn.vehicle;
            Customer? customer = null;

            if (registeredVehicle != null)
            {
                var customerResponse = await AppData.ApiServer.parkingDataService.GetCustomerByIdAsync(registeredVehicle.CustomerId);
                if (customerResponse != null)
                {
                    customer = customerResponse.Item1;
                }
            }

            DisplayEventInfo(eventTime, detectPlate, identity, identityGroup, vehicleType, customer, registeredVehicle, null);
            BaseLane.DisplayLed(detectPlate, eventTime, identity, identityGroup, "Xin mời qua", this.lane.Id, "0");

            lastEvent = eventIn;

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

            BaseLane.SaveImage(eventIn.images, imageDatas);

            if (isAlarm)
            {
                string alarmStr = "Cảnh báo biển số";
                var response = await AppData.ApiServer.parkingProcessService.CreateAlarmAsync(identity?.Code, this.lane.Id, detectPlate, AbnormalCode.InvalidPlateNumber,
                                                            imageDatas, true, identityGroup?.Id.ToString(), "", "", alarmStr);
                if (response != null)
                {
                    BaseLane.SaveImage(response.images, imageDatas);
                }
            }

            this.Invoke(new Action(() =>
            {
                for (int i = ucLastEventInfos.Count - 1; i > 0; i--)
                {
                    string customerId = ucLastEventInfos[i - 1].CustomerId;
                    string registerVehicleId = ucLastEventInfos[i - 1].RegisterVehicleId;
                    string laneId = ucLastEventInfos[i - 1].LaneId;
                    string identityId = ucLastEventInfos[i - 1].IdentityId;
                    ucLastEventInfos[i].UpdateEventInfo(ucLastEventInfos[i - 1].eventId, ucLastEventInfos[i - 1].picDirs);
                }
                ucLastEventInfos[0].UpdateEventInfo(eventIn.Id, eventIn.images, vehicleImg);
            }));
        }
        #endregion End xử lý sự kiện thẻ

        #region CONTROLS IN FORM
        private async void UcTopEvent_onChoosen(object sender, string eventId)
        {
            try
            {
                timerRefreshUI.Enabled = false;
                time_refresh = 0;
                if (string.IsNullOrEmpty(eventId))
                {
                    ClearView();
                    return;
                }
                DateTime now = DateTime.Now;
                DateTime startTime = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
                DateTime endTime = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);
                var report = await AppData.ApiServer.reportingService.GetEventIns("", startTime, endTime, "", "", "", "", 0, 1, eventId);
                if (report == null)
                {
                    ClearView();
                    return;
                }
                if (report.data.Count == 0)
                {
                    ClearView();
                    return;
                }
                var eventInfo = report.data[0];
                lastEvent = new EventInData(eventInfo);
                DisplayEventInfo(eventInfo.DateTimeIn ?? DateTime.Now, eventInfo.PlateNumber, eventInfo.Identity, eventInfo.IdentityGroup,
                                 eventInfo.IdentityGroup.VehicleType, eventInfo.customer, eventInfo.vehicle, null);
                if (eventInfo.images != null)
                {
                    ImageData? overviewImgData = eventInfo.images.ContainsKey(EmParkingImageType.Overview) ?
                                                            eventInfo.images[EmParkingImageType.Overview][0] : null;
                    ImageData? vehicleImgData = eventInfo.images.ContainsKey(EmParkingImageType.Vehicle) ?
                                                            eventInfo.images[EmParkingImageType.Vehicle][0] : null;
                    ImageData? lprImgData = eventInfo.images.ContainsKey(EmParkingImageType.Plate) ?
                                                           eventInfo.images[EmParkingImageType.Plate][0] : null;
                    picOverviewImage.ShowImageAsync(overviewImgData);
                    picVehicleImage.ShowImageAsync(vehicleImgData);
                    picLprImage.ShowImageAsync(lprImgData);
                }
                this.Invoke(new Action(() =>
                {
                    txtPlate.Text = eventInfo.PlateNumber;
                }));
            }
            catch (Exception)
            {
            }
            finally
            {
                if (StaticPool.oemConfig.IsAutoReturnToDefault)
                {
                    timerRefreshUI.Enabled = true;
                }
            }

        }

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
            new frmLaneSetting(this.lane.Id, StaticPool.leds, cameraList, this.lane.controlUnits.ToList(), true).ShowDialog();
            GetShortcutConfig();

            var newConfig = NewtonSoftHelper<LaneDirectionConfig>.DeserializeObjectFromPath(
                                                       PathManagement.appLaneDirectionConfigPath(this.lane.Id)) ?? LaneDirectionConfig.CreateDefault();

            bool isChangeDisplayConfig = false;
            if (!laneDirection.IsSameConfig(newConfig))
            {
                laneDirection = newConfig;
                panelDisplayLastEvent.Visible = laneDirection.IsDisplayLastEvent;
                SetDisplayDirection();
            }
        }

        private void SetDisplayDirection()
        {
            panelCameras.SizeChanged -= PanelCameras_SizeChanged;
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
                    panelAllCameras.Dock = DockStyle.Top;
                    panelAllCameras.Height = 100;
                    break;
                case LaneDirectionConfig.EmCameraPicFunction.HorizontalLeftToRight:
                    panelAllCameras.Width = 100;
                    splitterCamera.Dock = DockStyle.Left;
                    panelAllCameras.Dock = DockStyle.Left;

                    break;
                case LaneDirectionConfig.EmCameraPicFunction.HorizontalRightToLeft:
                    panelAllCameras.Width = 100;
                    splitterCamera.Dock = DockStyle.Right;
                    panelAllCameras.Dock = DockStyle.Right;
                    break;
                default:
                    break;
            }
            if (StaticPool.appOption.PrintTemplate != (int)EmPrintTemplate.XuanCuong)
            {
                switch (laneDirection.picDirection)
                {
                    case LaneDirectionConfig.EmPicDirection.Vertical:
                        if (tablePic.ColumnStyles.Count == 2)
                        {
                            tablePic.RowCount = 2;
                            tablePic.ColumnCount = 1;


                            // Di chuyển các phần tử sang cột mới
                            var control1 = tablePic.GetControlFromPosition(0, 0);
                            var control2 = tablePic.GetControlFromPosition(0, 1);

                            // Thiết lập tỷ lệ phần trăm cho các cột
                            tablePic.RowStyles.Clear();
                            tablePic.ColumnStyles.Clear();
                            tablePic.RowStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                            tablePic.RowStyles.Add(new ColumnStyle(SizeType.Percent, 50F));


                            tablePic.Controls.Clear();

                            tablePic.Controls.Add(control1, 0, 0); // Cột 0, Hàng 0
                            tablePic.Controls.Add(control2, 0, 1); // Cột 1, Hàng 0
                        }
                        break;
                    case LaneDirectionConfig.EmPicDirection.Horizontal:
                        if (tablePic.RowStyles.Count == 2)
                        {
                            tablePic.RowCount = 1;
                            tablePic.ColumnCount = 2;

                            // Di chuyển các phần tử sang cột mới
                            var control1 = tablePic.GetControlFromPosition(0, 0);
                            var control2 = tablePic.GetControlFromPosition(0, 1);
                            // Thiết lập tỷ lệ phần trăm cho các cột
                            tablePic.ColumnStyles.Clear();
                            tablePic.RowStyles.Clear();
                            tablePic.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                            tablePic.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));


                            tablePic.Controls.Clear();

                            tablePic.Controls.Add(control1, 0, 0); // Cột 0, Hàng 0
                            tablePic.Controls.Add(control2, 1, 0); // Cột 1, Hàng 0
                        }

                        break;
                    default:
                        break;
                }

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
            panelDisplayLastEvent.Visible = laneDirection.IsDisplayLastEvent;
            splitContainerMain.Panel2Collapsed = laneDirection.IsDisplayLastEvent ? false : true;
            panelLastEvent.Visible = laneDirection.IsDisplayLastEvent;
            PanelCameras_SizeChanged(null, EventArgs.Empty);
            panelCameras.SizeChanged += PanelCameras_SizeChanged;
        }

        /// <summary>
        /// Ghi vé vào=> Chọn vé cần ghi ==> Kích hoạt sự kiện như sự kiện quẹt thẻ
        /// Lưu sự kiện cảnh báo MANUAL EVENT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnWriteIn_Click(object sender, EventArgs e)
        {
            frmSelectCard frmSelectCard = new frmSelectCard("Danh sách thẻ");

            if (frmSelectCard.ShowDialog() != DialogResult.OK) return;
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
                    AllCardFormats = new List<string>() { frmSelectCard.SelectIdentity },
                    PreferCard = frmSelectCard.SelectIdentity
                };

                await OnNewEvent(ce);
                //Lưu sự kiện cảnh báo
                if (lastEvent != null)
                {
                    var imageDatas = GetAllCameraImage();

                    var response = await AppData.ApiServer.parkingProcessService.CreateAlarmAsync(lastEvent.Identity?.Code, this.lane.Id, lastEvent.PlateNumber, AbnormalCode.ManualEvent,
                                                                 imageDatas, false,
                                                                 lastEvent?.IdentityGroup?.Id.ToString() ?? "", "", "", "");
                    if (response != null)
                    {
                        BaseLane.SaveImage(response.images, imageDatas);
                    }
                }
                break;
            }
        }

        /// <summary>
        /// Bấm nút chụp lại hình ảnh ==> Kích hoạt sự kiện như sự kiện LOOP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReTakePhoto_Click(object sender, EventArgs e)
        {
            if (lane.controlUnits == null)
            {
                return;
            }
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
                _ = OnNewEvent(ie);
                return;
            }
        }

        /// <summary>
        /// Đăng ký thông tin khách hàng trước khi cho vào hệ thống
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            //this.isInRegister = true;
            //frmCustomerRegister frm = new frmCustomerRegister(this.lane);
            //frm.ShowDialog();
            //frm.Dispose();
            //this.isInRegister = false;
        }

        private async void BtnOpenBarrie_Click(object sender, EventArgs e)
        {
            foreach (var item in this.lane.controlUnits)
            {
                foreach (IController controller in frmMain.controllers)
                {
                    if (controller.ControllerInfo.Id.ToLower() == item.controlUnitId.ToLower())
                    {
                        for (int i = 0; i < item?.barriers.Length; i++)
                        {
                            if (!await controller.OpenDoor(100, item.barriers[i]))
                            {
                                bool isOpenSuccess = await controller.OpenDoor(100, item.barriers[i]);
                                if (!isOpenSuccess)
                                {
                                    LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.Controller, controller.ControllerInfo.Comport, "Mở barrie thủ công thất bại");
                                }
                            }
                            else
                            {
                                LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.Controller, controller.ControllerInfo.Comport, "Mở barrie thủ công thất bại");
                            }
                        }
                        break;
                    }
                }
            }

            if (lastEvent == null ||
                (DateTime.Now - lastEvent.DateTimeIn)?.TotalSeconds >= StaticPool.appOption.AllowBarrieDelayOpenTime)
            {
                var imageDatas = GetAllCameraImage();

                var response = await AppData.ApiServer.parkingProcessService.CreateAlarmAsync("", this.lane.Id, "", AbnormalCode.OpenBarrierByKeyboard, imageDatas, true,
                                                          "", "", "", "");
                if (response != null)
                {
                    BaseLane.SaveImage(response.images, imageDatas);
                }
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
            int count = panelCameras.Controls.OfType<ucCameraView>().ToList().Count;
            int marginHeight = 5;
            int displayRegionHeight = panelCameras.Height - label15.Height - marginHeight;
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
                                                    - /*item.Margin.Left - item.Margin.Right -*/ item.Padding.Left - item.Padding.Right) / count, panelCameras.Height - 50), this.laneDirection.cameraResolutionDisplay);
                }
            }
            for (int i = 0; i < panelCameras.Controls.OfType<ucCameraView>().ToList().Count; i++)
            {
                var item = panelCameras.Controls.OfType<ucCameraView>().ToList()[i];
                if (i == 0)
                {
                    item.Location = new Point(0, label15.Height);
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
        #endregion END RESPONSIVE

        #region EFFECT
        private void Pic_MouseHover(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            var pictureBox = sender as PictureBox;
            pictureBox!.BackColor = Color.Green;
            pictureBox!.Refresh();
        }
        private void Pic_MouseLeave(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            var pictureBox = (sender as PictureBox)!;
            pictureBox.BackColor = SuccessColor;
            pictureBox.BorderStyle = BorderStyle.None;
            pictureBox.Refresh();
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
        private void SplitContainerEventContent_MouseDoubleClick(object? sender, MouseEventArgs e)
        {
            if (frmMain.splitContainerMainLocation != null)
            {
                splitContainerMain.SplitterDistance = frmMain.splitContainerMainLocation.NewDistance;
            }
        }
        #endregion END OTHER

        #region TOOLTIP
        private void ToolTip3_Popup(object? sender, PopupEventArgs e)
        {
            e.ToolTipSize = TextRenderer.MeasureText("Ghi Vé Vào " + ((Keys)laneInShortcutConfig?.WriteIn).ToString(), new Font("Segoe UI", 16, FontStyle.Bold));
        }
        private void ToolTip3_Draw(object? sender, DrawToolTipEventArgs e)
        {
            e.DrawTooltip("Ghi Vé Vào " + ((Keys)laneInShortcutConfig?.WriteIn).ToString());
        }

        private void ToolTip2_Popup(object? sender, PopupEventArgs e)
        {
            e.ToolTipSize = TextRenderer.MeasureText("Chụp Lại " + ((Keys)laneInShortcutConfig?.ReSnapshotKey).ToString(), new Font("Segoe UI", 16, FontStyle.Bold));
        }
        private void ToolTip2_Draw(object? sender, DrawToolTipEventArgs e)
        {
            e.DrawTooltip("Chụp Lại " + ((Keys)laneInShortcutConfig?.ReSnapshotKey).ToString());
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

        #region TIME
        private void timerRefreshUI_Tick(object sender, EventArgs e)
        {
            time_refresh++;
            if (time_refresh >= StaticPool.oemConfig.TimeToDefautUI)
            {
                ClearView();
                timerRefreshUI.Enabled = false;
            }
        }
        #endregion

        #region EVENT

        #endregion END EVENT

        #region PRIVATE FUNCTION
        private async Task<Tuple<bool, Identity?>> IsValidIdentity(string cardNumber)
        {
            var identityResponse = await AppData.ApiServer.parkingDataService.GetIdentityByCodeAsync(cardNumber);
            if (identityResponse == null)
            {
                lblResult.UpdateResultMessage("Không đọc được thông tin định danh, vui lòng thử lại", ErrorColor);
                return Tuple.Create<bool, Identity?>(false, null);
            }

            Identity? identity = identityResponse.Item1;
            if (identity == null)
            {
                lblResult.UpdateResultMessage("Mã định danh không có trong hệ thống", ErrorColor);
                return Tuple.Create<bool, Identity?>(false, null);
            }

            if (identity.Status == IdentityStatus.Locked)
            {
                lblResult.UpdateResultMessage("Định danh - ngừng sử dụng", ErrorColor);
                return Tuple.Create<bool, Identity?>(false, identity);
            }
            return Tuple.Create<bool, Identity?>(true, identity);
        }

        private void AllowDesignRealtime(bool isAllow)
        {
            this.IsAllowDesignRealtime = isAllow;

            splitContainerMain.IsSplitterFixed = !isAllow;
            splitContainerEventContent.IsSplitterFixed = !isAllow;
            splitContainerLastEvent.IsSplitterFixed = !isAllow;
            splitterCamera.Enabled = isAllow;
            splitterEventInfoWithCamera.Enabled = isAllow;
            Color displayColor = isAllow ? Color.Blue : SystemColors.ButtonHighlight;

            splitContainerMain.BackColor = displayColor;
            splitContainerEventContent.BackColor = displayColor;
            splitContainerLastEvent.BackColor = displayColor;
            splitterCamera.BackColor = displayColor;
            splitterEventInfoWithCamera.BackColor = displayColor;
        }

        private void FocusOnTitle()
        {
            this.BeginInvoke(new Action(() =>
            {
                this.ActiveControl = lblLaneName;
                lblLaneName.Focus();
            }));
        }
        private void DisplayDetectedPlate(string plate, Image? lprImage)
        {
            BaseLane.ShowImage(picLprImage, lprImage);
            txtPlate.Invoke(new Action(() =>
            {
                txtPlate.Text = plate;
                txtPlate.Refresh();
            }));
        }
        #endregion END PRIVATE FUNCTION

        #region PUBLIC FUNCTION
        /// <summary>
        /// Tải thông tin cấu hình phím tắt lưu trong hệ thống
        /// </summary>
        public void GetShortcutConfig()
        {
            laneInShortcutConfig = NewtonSoftHelper<LaneInShortcutConfig>.DeserializeObjectFromPath(
                                            PathManagement.laneShortcutConfigPath(this.lane.Id)) ?? new LaneInShortcutConfig();
            controllerShortcutConfigs = NewtonSoftHelper<List<ControllerShortcutConfig>>.DeserializeObjectFromPath(
                                            PathManagement.laneControllerShortcutConfigPath(this.lane.Id)) ?? new List<ControllerShortcutConfig>();
        }

        /// <summary>
        /// Hiển thị giao diện như lần cuối cùng sử dụng
        /// </summary>
        public void DisplayUIConfig()
        {
            //this.SuspendLayout();

            if (this.laneDisplayConfig == null) return;
            try
            {
                if (this.splitContainerMain.Panel2Collapsed)
                {
                    this.splitContainerMain.Height = this.laneDisplayConfig.splitContainerMain;
                    this.Refresh();
                }
                else
                {

                    this.splitContainerMain.SplitterDistance = this.laneDisplayConfig.splitContainerMain;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.Form, "DisplayUIConfig", "splitContainerMain-SplitterDistance", ex);
            }

            try
            {
                this.splitterEventInfoWithCamera.SplitPosition = this.laneDisplayConfig.splitEventInfoWithCameraPosition;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.Form, "DisplayUIConfig", "splitterEventInfoWithCamera-SplitPosition", ex);
            }
            try
            {
                this.splitContainerLastEvent.SplitterDistance = this.laneDisplayConfig.splitLastEventPosition;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.Form, "DisplayUIConfig", "splitterEventInfoWithCamera-SplitPosition", ex);
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
                this.splitContainerEventContent.SplitterDistance = this.laneDisplayConfig.splitContainerEventContent;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.Form, "DisplayUIConfig", "splitContainerEventContent-SplitterDistance", ex);
            }

            try
            {
                this.splitterCamera.SplitPosition = this.laneDisplayConfig.SplitterCameraPosition;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.Form, "DisplayUIConfig", "splitterCamera-SplitPosition", ex);
            }

            AllowDesignRealtime(false);
            //this.ResumeLayout();
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
                splitLastEventPosition = this.splitContainerLastEvent.SplitterDistance,
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
            if (isInRegisterMode)
            {
                semaphoreSlimOnNewEvent.Release();
                return;
            }
            lastEvent = null;
            try
            {
                if (e is CardEventArgs cardEvent)
                {
                    string controlUnitId = cardEvent.DeviceId;
                    int readerIndex = cardEvent.ReaderIndex;
                    await ExcecuteCardEvent(cardEvent);
                }
                else if (e is InputEventArgs inputEvent)
                {
                    await ExcecuteInputEvent(inputEvent, lblResult);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.Form, "OnNewEvent", "", e, ex);
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

        public CheckInOutResponse CheckEventInReponse(Tuple<EventInData, BaseErrorData> eventInReponse, Customer? customer,
                                                          VehicleBaseType vehicleBaseType, string plateNumber,
                                                          bool isForce)
        {
            CheckInOutResponse checkInOutResponse = new CheckInOutResponse()
            {
                IsContinueExcecute = false,
                IsValidEvent = false,
                eventIn = eventInReponse.Item1,
                ErrorMessage = string.Empty,
                ErrorData = eventInReponse.Item2,
            };
            if (eventInReponse == null)
            {
                ExcecuteSystemErrorCheckIn();
                return checkInOutResponse;
            }
            if (checkInOutResponse.eventIn is null && checkInOutResponse.ErrorData is null)
            {
                ExcecuteSystemErrorCheckIn();
                return checkInOutResponse;
            }
            if (checkInOutResponse.ErrorData is not null)
            {
                if (checkInOutResponse.ErrorData.fields == null || checkInOutResponse.ErrorData.fields.Count == 0)
                {
                    ExcecuteSystemErrorCheckIn();
                    return checkInOutResponse;
                }
                checkInOutResponse.ErrorMessage = checkInOutResponse.ErrorData.fields[0].ToString();
                if (isForce)
                {
                    ExcecuteUnvalidEvent(null, null, vehicleBaseType, plateNumber, DateTime.Now,
                                        checkInOutResponse.ErrorMessage, customer, plateNumber);
                    return checkInOutResponse;
                }
                else
                {
                    // Sử dụng cho các trường hợp phương tiện hết hạn sử dụng, ngoài giờ được phép sử dụng
                    if (!allowAlarmMessage.Contains(checkInOutResponse.ErrorMessage))
                    {
                        ExcecuteUnvalidEvent(null, null, vehicleBaseType, plateNumber, DateTime.Now,
                                             checkInOutResponse.ErrorMessage, customer, plateNumber);
                        return checkInOutResponse;
                    }
                    checkInOutResponse.IsContinueExcecute = true;
                    return checkInOutResponse;
                }
            }
            else
            {
                checkInOutResponse.IsValidEvent = true;
                checkInOutResponse.IsContinueExcecute = false;
                return checkInOutResponse;
            }
        }
        HausVisitor? lastHausVistor = null;
        private async void btnRegister_Click_1(object sender, EventArgs e)
        {
            var frmAddVisitor = new frmAddVisitor();
            if (frmAddVisitor.ShowDialog() == DialogResult.OK)
            {
                string identityGroupCode = frmAddVisitor.IdentityGroupCode;
                string plateNumber = frmAddVisitor.PlateNumber;
                lastHausVistor = await ThirdPartyService.AddVisitor(identityGroupCode, plateNumber);
                if (lastHausVistor == null)
                {
                    MessageBox.Show("Thêm thông tin không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private async void btnPrintQR_Click(object sender, EventArgs e)
        {
            var qrData = await ThirdPartyService.GetQRData(lastHausVistor);
        }
    }
}