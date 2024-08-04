using IPaking.Ultility;
using iParkingv5.Controller;
using iParkingv5.Objects;
using iParkingv5.Objects.Configs;
using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Datas.Device_service;
using iParkingv5.Objects.Datas.parking_service;
using iParkingv5.Objects.Datas.weighing_service;
using iParkingv5.Objects.Enums;
using iParkingv5.Objects.EventDatas;
using iParkingv5.Objects.Events;
using iParkingv5_CustomerRegister.Forms;
using iParkingv5_window.Forms.DataForms;
using iParkingv5_window.Helpers;
using iParkingv6.Objects.Datas;
using Kztek.Tool;
using Kztek.Tools;
using System.Data;
using System.Drawing.Imaging;
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
        #endregion

        #endregion END PROPERTIES

        #region FORMS
        public ucLaneIn(Lane lane, LaneDisplayConfig? laneDisplayConfig)
        {
            InitializeComponent();

            lblLaneName.Text = lane.name;
            lblLaneName.BackColor = Color.DarkGreen;

            this.lane = lane;
            this.laneDisplayConfig = laneDisplayConfig;

            this.DoubleBuffered = true;

            laneDirection = NewtonSoftHelper<LaneDirectionConfig>.DeserializeObjectFromPath(PathManagement.appLaneDirectionConfigPath(this.lane.Id)) ??
                            LaneDirectionConfig.CreateDefault();

            panelDisplayLastEvent.Visible = laneDirection.IsDisplayLastEvent;
            splitContainerMain.Panel2Collapsed = laneDirection.IsDisplayLastEvent ? false : true;
            panelLastEvent.Visible = laneDirection.IsDisplayLastEvent;

            this.Load += UcLaneIn_Load;
        }

        private async void UcLaneIn_Load(object? sender, EventArgs e)
        {
            GetShortcutConfig();
            LoadCamera(panelCameras);

            await CreateUI();
            RegisterUIEvent();

            this.ActiveControl = lblLaneName;

            SetDisplayDirection();
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
        #endregion END FORMS

        #region EVENT
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
                        this.AllowDesignRealtime(this.IsAllowDesignRealtime);
                    }));
                }
                //if (keys == Keys.Enter && this.lastEvent != null && txtNote.Focused)
                //{
                //    bool isUpdateNote = MessageBox.Show("Bạn có muốn cập nhật ghi chú?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
                //    if (isUpdateNote)
                //    {
                //        bool isUpdateSuccess = await AppData.ApiServer.parkingProcessService.UpdateBSXNote(txtNote.Text, lastEvent.Id, true);
                //        if (isUpdateSuccess)
                //        {
                //            lblResult.UpdateResultMessage("Ra Lệnh Cập Nhật Ghi Chú Biển Số Thành Công", Color.DarkBlue);
                //        }
                //        else
                //        {
                //            lblResult.UpdateResultMessage("Cập Nhật Lỗi, Vui Lòng Thử Lại", Color.DarkRed);
                //        }
                //    }
                //    FocusOnTitle();
                //}

                if (laneInShortcutConfig != null)
                {
                    if ((int)keys == laneInShortcutConfig.ConfirmPlateKey)
                    {
                        if (txtPlate.Focused)
                        {
                            //Cập nhật biển số xe
                            if (this.lastEvent != null)
                            {
                                string newPlate = string.Empty;
                                this.Invoke(new Action(() =>
                                {
                                    txtPlate.Text = txtPlate.Text.ToUpper().Replace("-", "").Replace(".", "");
                                    newPlate = txtPlate.Text;
                                }));
                                bool isUpdateSuccess = await AppData.ApiServer.parkingProcessService.UpdateEventInPlateAsync(lastEvent.Id, newPlate.ToUpper(), lastEvent.PlateNumber);
                                if (isUpdateSuccess)
                                {
                                    lblResult.UpdateResultMessage("Ra Lệnh Cập Nhật Biển Số Thành Công", Color.DarkBlue);
                                    if (ucTop1Event != null)
                                    {
                                        ucTop1Event.plateNumber = newPlate.ToUpper();
                                    }
                                    lastEvent.PlateNumber = newPlate.ToUpper();
                                    FocusOnTitle();
                                }
                                else
                                {
                                    lblResult.UpdateResultMessage("Cập nhật lỗi, vui lòng thử lại", Color.DarkBlue);
                                    FocusOnTitle();
                                }
                            }
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
                            lblResult.UpdateResultMessage("Ra Lệnh Đảo Làn", Color.DarkBlue);
                            OnChangeLaneEventInvoke(this);
                            return;
                        }
                        else
                        {
                            lblResult.UpdateResultMessage("Không có cấu hình làn đảo", Color.DarkBlue);
                        }
                    }
                    else if ((int)keys == laneInShortcutConfig.WriteIn)
                    {
                        lblResult.UpdateResultMessage("Ra Lệnh Ghi Vé Vào", Color.DarkBlue);
                        btnWriteIn?.Invoke(new Action(() =>
                        {
                            btnWriteIn.PerformClick();
                        }));
                    }
                    else if ((int)keys == laneInShortcutConfig.ReSnapshotKey)
                    {
                        lblResult.UpdateResultMessage("Ra lệnh chụp lại", Color.DarkBlue);
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
                            if (item.Value == (int)keys)
                            {
                                string controllerId = controllerShortcutConfig.ControllerId;
                                int barrieIndex = item.Key;
                                foreach (IController controller in frmMain.controllers)
                                {
                                    if (controller.ControllerInfo.Id.ToLower() == controllerId.ToLower())
                                    {
                                        lblResult.UpdateResultMessage("Ra Lệnh Rơ le " + barrieIndex, Color.DarkBlue);

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
            catch (Exception)
            {

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
            EventInData? eventIn = null;
            string errorMessage = string.Empty;

            //Danh sách biến sử dụng
            Image? vehicleImg = null;
            Image? overviewImg = null;
            List<Image?> optionalImages = new();
            VehicleBaseType vehicleType = VehicleBaseType.Car;
            Customer? customer = null;
            lblResult.UpdateResultMessage("Đang kiểm trang thông tin sự kiện loop..." + ie.InputIndex, Color.DarkBlue);
            overviewImg = ucOverView?.GetFullCurrentImage();
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
            BaseLane.ShowImage(picVehicleImage, vehicleImg);
            BaseLane.ShowImage(picOverviewImage, overviewImg);

            //Không đọc được biển số hoặc biển số đọc được không hợp lệ, hiểm thị hình ảnh toàn cảnh và kết thúc sự kiện
            if (string.IsNullOrEmpty(plate) || plate.Length < 5)
            {
                lblResult.UpdateResultMessage("Không đọc được thông tin biển số xe", Color.DarkRed);
                return;
            }
            //Đọc thông tin định danh từ thông tin biển số nhận được

            ClearView();
            lblResult.UpdateResultMessage("Đang check in..." + plate, Color.DarkBlue);
            DisplayDetectedPlate(plate, lprImage);

            //Đọc thông tin loại phương tiện
            if (registeredVehicle == null)
            {
                lblResult.UpdateResultMessage("Phương tiện chưa được đăng ký trong hệ thống", Color.DarkRed);
                return;
            }

            string customerId = registeredVehicle.CustomerId;

            vehicleType = registeredVehicle.vehicleType;
            if (!string.IsNullOrEmpty(customerId))
            {
                customer = (await AppData.ApiServer.parkingDataService.GetCustomerByIdAsync(customerId))?.Item1;
            }

            List<EmParkingImageType> validImageTypes = BaseLane.GetValidImageType(overviewImg, vehicleImg, lprImage);
            var eventInReport = await AppData.ApiServer.parkingProcessService.PostCheckInAsync(lane.Id, plate, null, validImageTypes, false, null, "");

            if (eventInReport == null)
            {
                goto LOI_HE_THONG;
            }
            eventIn = eventInReport.Item1;
            var errorData = eventInReport.Item2;

            if (errorData != null)
            {
                if (!errorData.IsSuccess)
                {
                    if (errorData.fields == null)
                    {
                        goto LOI_HE_THONG;
                    }
                    errorMessage = errorData.fields.Count > 0 ? (errorData.fields[0].ToString() ?? "") : errorData.detailCode;
                    if (errorMessage != "Biển số không hợp lệ".ToUpper())
                    {
                        goto SU_KIEN_LOI;
                    }
                }
            }

            if (eventIn.OpenBarrier)
            {
                ControllerInLane? controllerInLane = (from _controllerInLane in this.lane.controlUnits
                                                      where _controllerInLane.controlUnitId == ie.DeviceId
                                                      select _controllerInLane).FirstOrDefault();
                await BaseLane.OpenBarrieByControllerId(ie.DeviceId, controllerInLane, this);
            }
            goto SU_KIEN_HOP_LE;

        CheckInWithForce:
            {
                eventInReport = await AppData.ApiServer.parkingProcessService.PostCheckInAsync(lane.Id, plate, null, validImageTypes, true, null, "");
                if (eventInReport == null)
                {
                    goto LOI_HE_THONG;
                }
                else
                {
                    eventIn = eventInReport.Item1;
                    if (eventIn == null)
                    {
                        goto LOI_HE_THONG;
                    }
                    if (eventIn.OpenBarrier)
                    {
                        ControllerInLane? controllerInLane = (from _controllerInLane in this.lane.controlUnits
                                                              where _controllerInLane.controlUnitId == ie.DeviceId
                                                              select _controllerInLane).FirstOrDefault();
                        await BaseLane.OpenBarrieByControllerId(ie.DeviceId, controllerInLane, this);
                    }
                    goto SU_KIEN_HOP_LE;
                }
            }
        LOI_HE_THONG:
            {
                ExcecuteSystemErrorCheckIn();
                return;
            }
        SU_KIEN_LOI:
            {
                ExcecuteUnvalidEvent(null, null, vehicleType, plate, ie.EventTime, errorMessage, customer, registeredVehicle.PlateNumber);
                return;
            }
        SU_KIEN_HOP_LE:
            {
                await ExcecuteValidEvent(null, null, vehicleType, plate, ie.EventTime, overviewImg,
                                        vehicleImg, lprImage, eventIn, isAlarm);
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
                var imageData = SaveAllCameraImage();
                var response = await AppData.ApiServer.parkingProcessService.CreateAlarmAsync("", this.lane.Id, "", AbnormalCode.OpenBarrierByButton, imageData, true, "", "", "", "");
                if (response != null)
                {
                    BaseLane.SaveImage(response.images, imageData);
                }
                return;
            }

            //Đã có sự kiện trước đó kiểm tra xem có trong thời gian cho phép mở ko
            if ((DateTime.Now - lastEvent.DateTimeIn)?.TotalSeconds >= StaticPool.appOption.AllowBarrieDelayOpenTime)
            {
                var imageData = SaveAllCameraImage();

                var response = await AppData.ApiServer.parkingProcessService.CreateAlarmAsync(lastEvent.Identity?.Code, this.lane.Id, lastEvent.PlateNumber, AbnormalCode.OpenBarrierByButton,
                                                             imageData, true,
                                                             lastEvent?.IdentityGroup.Id, "", "", "");
                if (response != null)
                {
                    BaseLane.SaveImage(response.images, imageData);
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

            ClearView();
            lblResult.UpdateResultMessage("Đang kiểm tra thông tin sự kiện quẹt thẻ..." + ce.PreferCard, Color.DarkBlue);

            #region Kiểm tra thông tin định danh
            var identityResponse = await IsValidIdentity(ce.PreferCard);

            if (!identityResponse.Item1)
            {
                return;
            }
            Identity? identity = identityResponse.Item2!;

            //Cần gọi GET by ID để lấy thông tin phương tiện đăng ký
            identity = (await AppData.ApiServer.parkingDataService.GetIdentityByIdAsync(identity.Id)).Item1;
            if (identity == null || string.IsNullOrEmpty(identity.IdentityGroupId))
            {
                lblResult.UpdateResultMessage("Không đọc được thông tin định danh, vui lòng thử lại", Color.DarkRed);
                return;
            }
            #endregion End kiểm tra thông tin định danh

            #region Kiểm tra thông tin nhóm định danh
            IdentityGroup? identityGroup = (await AppData.ApiServer.parkingDataService.GetIdentityGroupByIdAsync(identity.IdentityGroupId.ToString()))?.Item1;
            if (identityGroup == null || identityGroup.Id == Guid.Empty || string.IsNullOrEmpty(identity.Id))
            {
                lblResult.UpdateResultMessage("Không đọc được thông tin nhóm định danh, vui lòng thử lại", Color.DarkRed);
                return;
            }
            #endregion End kiểm tra thông tin nhóm định danh

            #region Kiểm tra thông tin loại phương tiện
            lblResult.UpdateResultMessage("Đọc thông tin loại phương tiện...", Color.DarkBlue);
            VehicleBaseType vehicleBaseType = identityGroup.VehicleType;
            if (vehicleBaseType == VehicleBaseType.Unknown)
            {
                lblResult.UpdateResultMessage("Thông tin loại phương tiện không hợp lệ, vui lòng sử dụng thẻ khác", Color.DarkRed);
                return;
            }
            #endregion End kiểm tra thông tin loại phương tiện

            Image? overviewImg = null;
            Image? vehicleImg = null;
            Image? lprImage = GetPlate(ce, ref overviewImg, ref vehicleImg, vehicleBaseType, lblResult, txtPlate, picOverviewImage, picVehicleImage, picLprImage);

            //Đọc thông tin loại phương tiện
            lblResult.UpdateResultMessage("Đang kiểm tra thông tin..." + ce.PreferCard, Color.DarkBlue);
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
                lblResult.UpdateResultMessage("Gặp lỗi trong quá trình xử lý, vui lòng thử lại", Color.DarkRed);
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
                var imageData = SaveAllCameraImage();
                var response = await AppData.ApiServer.parkingProcessService.CreateAlarmAsync("", this.lane.Id, "", AbnormalCode.OpenBarrierByKeyboard, imageData, true, "", "", "", "");
                if (response != null)
                {
                    if (response.images != null)
                    {
                        BaseLane.SaveImage(response.images, imageData);
                    }
                }
            }
            else if ((DateTime.Now - lastEvent.DateTimeIn)?.TotalSeconds >= StaticPool.appOption.AllowBarrieDelayOpenTime)
            {
                var imageData = SaveAllCameraImage();
                var response = await AppData.ApiServer.parkingProcessService.CreateAlarmAsync(lastEvent.Identity?.Code, this.lane.Id, lastEvent.PlateNumber, AbnormalCode.OpenBarrierByKeyboard,
                                                        imageData, true,
                                                        lastEvent?.IdentityGroup?.Id ?? "", "", "", "");
                if (response != null)
                {
                    BaseLane.SaveImage(response.images, imageData);
                }
            }
        }
        #endregion End EVENT

        #region Private Function
        private async Task CreateUI()
        {
            this.Dock = DockStyle.Fill;
            panelCameras.BorderStyle = BorderStyle.None;
            lblResult.Padding = new Padding(StaticPool.baseSize);
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
            toolTip2.SetToolTip(picRetakePhoto, "Chụp Lại " + ((Keys)laneInShortcutConfig?.ReSnapshotKey).ToString());
            toolTip3.SetToolTip(picWriteIn, "Ghi Vé Vào " + ((Keys)laneInShortcutConfig?.WriteIn).ToString()); 

            picLprImage.Image = picLprImage.InitialImage = picLprImage.ErrorImage = defaultImg;
            picOverviewImage.Image = picOverviewImage.InitialImage = picOverviewImage.ErrorImage = defaultImg;
            picVehicleImage.Image = picVehicleImage.InitialImage = picVehicleImage.ErrorImage = defaultImg;

            //Get Top3 Event
            DateTime startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                              0, 0, 0);
            DateTime endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                            23, 59, 59);

            panelNearestEvent.Dock = DockStyle.Fill;
            panelNearestEvent.Location = new Point(0, 36);
            panelNearestEvent.Name = "panel9";
            panelNearestEvent.Size = new Size(539, 123);
            panelNearestEvent.TabIndex = 8;

            // 
            // label2
            // 
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(539, 36);
            label2.TabIndex = 7;
            label2.Text = "Các lượt xe vào gần đây";
            label2.TextAlign = ContentAlignment.MiddleLeft;
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
            var top3Event = (await AppData.ApiServer.reportingService.GetEventIns("", startTime, endTime, "", "", this.lane.Id, "", 0, 3)).data;
            if (top3Event != null)
            {
                for (int i = 0; i < top3Event.Count; i++)
                {
                    if (ucLastEventInfos.Count <= i)
                    {
                        continue;
                    }
                    string id = top3Event[i].Id;
                    string plateNumber = top3Event[i].PlateNumber;
                    string vehicleGroupId = "";
                    string cardGroupId = top3Event[i].IdentityGroup.Id;
                    DateTime dateTimeIn = top3Event[i].DateTimeIn.Value;

                    List<string> picDirs = new List<string>();
                    string customerId = "";// top3Event.Rows[i]["customerid"].ToString() ?? "";
                    string registerVehicleId = "";// top3Event.Rows[i]["vehicleid"].ToString() ?? "";
                    string laneId = top3Event[i].Lane.Id;
                    string identityId = top3Event[i].Identity.Id;
                    ucLastEventInfos[i].UpdateEventInfo(id, plateNumber, vehicleGroupId, cardGroupId, dateTimeIn, picDirs,
                                                        customerId, registerVehicleId, laneId, identityId, true);
                }
            }

            splitContainerMain.BringToFront();
        }
        private void RegisterUIEvent()
        {
            panelCameras.SizeChanged += PanelCameras_SizeChanged;
            splitContainerEventContent.SizeChanged += SplitContainerEventContent_SizeChanged;
            splitContainerMain.MouseDoubleClick += SplitContainerEventContent_MouseDoubleClick;
            toolTip1.OwnerDraw = true;
            toolTip1.Draw += ToolTip1_Draw;
            toolTip1.Popup += ToolTip1_Popup;

            toolTip2.OwnerDraw = true;
            toolTip2.Draw += ToolTip2_Draw;
            toolTip2.Popup += ToolTip2_Popup;

            toolTip3.OwnerDraw = true;
            toolTip3.Draw += ToolTip3_Draw;
            toolTip3.Popup += ToolTip3_Popup;

            picRetakePhoto.MouseHover += PicRetakePhoto_MouseHover;
            picRetakePhoto.MouseLeave += PicSetting_MouseLeave;

            picOpenBarrie.MouseHover += PicRetakePhoto_MouseHover;
            picOpenBarrie.MouseLeave += PicSetting_MouseLeave;

            picWriteIn.MouseHover += PicRetakePhoto_MouseHover;
            picWriteIn.MouseLeave += PicSetting_MouseLeave;
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

                lblResult.UpdateResultMessage(StaticPool.oemConfig.AppName, Color.DarkGreen);
                lblResult.Refresh();
            }));
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
        #endregion End Private Function

        #region Xử lý sự kiện thẻ
        private async Task ExcecuteMonthCardEventIn(Identity identity, IdentityGroup identityGroup,
                                                    VehicleBaseType vehicleType, string plateNumber,
                                                    CardEventArgs ce, ControllerInLane? controllerInLane,
                                                    Image? overviewImg, Image? vehicleImg, Image? lprImage)
        {
            bool isAlarm = false;
            List<EmParkingImageType> validImageTypes = BaseLane.GetValidImageType(overviewImg, vehicleImg, lprImage);

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

            string errorMessage = string.Empty;
            EventInData? eventIn = null;
            if (string.IsNullOrEmpty(plateNumber) && identity.Vehicles.Count == 1)
            {
                bool isConfirm = MessageBox.Show("Không nhận diện được biển số, bạn có muốn cho xe vào bãi?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
                if (isConfirm)
                {
                    isAlarm = true;
                    goto CheckInWithForce;
                }
                else
                {
                    ClearView();
                    return;
                }
            }
            else
            {
                goto CheckInNormal;
            }

        CheckInNormal:
            {
                var eventInResponse = await AppData.ApiServer.parkingProcessService.PostCheckInAsync(lane.Id, plateNumber, identity, validImageTypes, false, null, "");
                if (eventInResponse == null)
                {
                    goto LOI_HE_THONG;
                }
                eventIn = eventInResponse.Item1;
                var errorData = eventInResponse.Item2;
                if (errorData != null)
                {
                    errorMessage = errorData.fields.Count > 0 ? (errorData.fields[0].ToString() ?? "") : errorData.detailCode;
                    if (errorMessage != "Biển số không hợp lệ".ToUpper())
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
                                                                         "", "",
                                                                         "", vehicleImg, overviewImg, plateNumber);
                            isConfirm = frmConfirmIn.ShowDialog()
                                                    == DialogResult.OK;
                            plateNumber = frmConfirmIn.updatePlate;
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
                            goto CheckInWithForce;
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
                    if (eventIn.OpenBarrier)
                    {
                        await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane, this);
                    }
                    goto SU_KIEN_HOP_LE;
                }
            }

        CheckInWithForce:
            {
                var eventInResponse = await AppData.ApiServer.parkingProcessService.PostCheckInAsync(lane.Id, plateNumber, identity, validImageTypes, true, null, "");
                if (eventInResponse == null)
                {
                    goto LOI_HE_THONG;
                }
                eventIn = eventInResponse.Item1;
                var errorData = eventInResponse.Item2;
                if (errorData != null)
                {
                    if (errorData.fields.Count > 0)
                    {
                        errorMessage = errorData.fields[0].ToString() ?? "";
                    }
                    goto SU_KIEN_LOI;
                }
                else
                {
                    if (eventIn.OpenBarrier)
                    {
                        await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane, this);
                    }
                    goto SU_KIEN_HOP_LE;
                }
            }

        LOI_HE_THONG:
            {
                ExcecuteSystemErrorCheckIn();
                return;
            }
        SU_KIEN_LOI:
            {
                ExcecuteUnvalidEvent(identity, identityGroup, vehicleType, plateNumber, ce.EventTime, errorMessage, null, "");
                return;
            }
        SU_KIEN_HOP_LE:
            {
                await ExcecuteValidEvent(identity, identityGroup, vehicleType, plateNumber, ce.EventTime, overviewImg, vehicleImg, lprImage, eventIn, isAlarm);
                return;
            }
        }


        private async Task ExcecuteNonMonthCardEventIn(Identity identity, IdentityGroup identityGroup,
                                                       VehicleBaseType vehicleType, string plateNumber,
                                                       CardEventArgs ce, ControllerInLane? controllerInLane,
                                                       Image? overviewImg, Image? vehicleImg, Image? lprImage)
        {
            List<EmParkingImageType> validImageTypes = BaseLane.GetValidImageType(overviewImg, vehicleImg, lprImage);
            string errorMessage = string.Empty;
            EventInData? eventIn = null;
            bool isAlarm = false;
            if (identityGroup.PlateNumberValidation != (int)EmPlateCompareRule.UnCheck)
            {
                if (string.IsNullOrEmpty(plateNumber))
                {
                    isAlarm = true;
                    bool isConfirm = MessageBox.Show("Không nhận diện được biển số, bạn có muốn cho xe vào bãi?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes;
                    if (!isConfirm)
                    {
                        ClearView();
                        return;
                    }
                }
            }
            var eventInResponse = await AppData.ApiServer.parkingProcessService.PostCheckInAsync(lane.Id, plateNumber, identity, validImageTypes, false, null, "");

            if (eventInResponse == null)
            {
                goto LOI_HE_THONG;
            }
            eventIn = eventInResponse.Item1;
            var errorData = eventInResponse.Item2;

            if (errorData != null)
            {
                if (errorData.fields == null || errorData.fields.Count == 0)
                {
                    goto LOI_HE_THONG;
                }
                errorMessage = errorData.fields[0].ToString() ?? "";
                goto SU_KIEN_LOI;
            }
            else
            {
                if (eventIn.OpenBarrier)
                {
                    await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane, this);
                }
                else
                {
                    bool isOpenBarrie = MessageBox.Show("Bạn có muốn mở Barrie?", "Thông báo",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                        == DialogResult.Yes;
                    if (isOpenBarrie)
                    {
                        await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane, this);
                    }
                }
                goto SU_KIEN_HOP_LE;
            }

        LOI_HE_THONG:
            {
                ExcecuteSystemErrorCheckIn();
                return;
            }
        SU_KIEN_LOI:
            {
                ExcecuteUnvalidEvent(identity, identityGroup, vehicleType, ce.PlateNumber, ce.EventTime, errorMessage, null, "");
                return;
            }
        SU_KIEN_HOP_LE:
            {
                await ExcecuteValidEvent(identity, identityGroup, vehicleType,
                                        ce.PlateNumber, ce.EventTime,
                                        overviewImg, vehicleImg, lprImage,
                                        eventIn, isAlarm);
                return;
            }
        }

        private void ExcecuteSystemErrorCheckIn()
        {
            lblResult.UpdateResultMessage("Gặp lỗi trong quá trình xử lý, vui lòng thử lại sau giây lát", Color.DarkRed);
        }
        private void ExcecuteUnvalidEvent(Identity identity, IdentityGroup identityGroup, VehicleBaseType vehicleType, string detectPlate,
                                          DateTime eventTime, string errorMessage, Customer? customer, string registerPlate)
        {
            lblResult.UpdateResultMessage(errorMessage, Color.DarkRed);
            DisplayEventInfo(eventTime, detectPlate, identity, identityGroup, vehicleType, customer, null);
        }

        private async Task ExcecuteValidEvent(Identity? identity, IdentityGroup? identityGroup,
                                              VehicleBaseType vehicleType, string detectPlate,
                                              DateTime eventTime, Image? overviewImg,
                                              Image? vehicleImg, Image? lprImage,
                                              EventInData eventIn, bool isAlarm)
        {
            lblResult.UpdateResultMessage("Xin Mời Qua", Color.DarkGreen);

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
        }
        #endregion End xử lý sự kiện thẻ

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
            frmSearchPlateNumber frmSearchPlateNumber = new frmSearchPlateNumber();

            if (frmSearchPlateNumber.ShowDialog() != DialogResult.OK) return;
            string selectedPlate = frmSearchPlateNumber.selectedVehiclePlate;
            RegisteredVehicle? registeredVehicle = (await AppData.ApiServer.parkingDataService.GetRegistedVehilceByPlateAsync(selectedPlate)).Item1;
            if (registeredVehicle == null)
            {
                return;
            }
            Image? vehicleImg = null;
            Image? overviewImg = ucOverView?.GetFullCurrentImage();
            Customer? customer = null;
            EventInData? eventIn = null;
            string errorMessage = string.Empty;

            string customerId = registeredVehicle.CustomerId;

            VehicleBaseType vehicleType = registeredVehicle.vehicleType;

            switch (vehicleType)
            {
                case VehicleBaseType.Car:
                    vehicleImg = ucCarLpr?.GetFullCurrentImage();
                    break;
                case VehicleBaseType.Bike:
                case VehicleBaseType.MotorBike:
                    vehicleImg = ucMotoLpr?.GetFullCurrentImage();
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(customerId))
            {
                customer = (await AppData.ApiServer.parkingDataService.GetCustomerByIdAsync(customerId)).Item1;
            }

            ClearView();
            //Hiển thị thông tin hình ảnh phương tiện
            BaseLane.ShowImage(picVehicleImage, vehicleImg);
            BaseLane.ShowImage(picOverviewImage, overviewImg);
            List<EmParkingImageType> validImageTypes = BaseLane.GetValidImageType(overviewImg, vehicleImg, null);
            var eventInResponse = await AppData.ApiServer.parkingProcessService.PostCheckInAsync(lane.Id, selectedPlate, null, validImageTypes, true, null, "");
            if (eventInResponse == null)
            {
                goto LOI_HE_THONG;
            }
            eventIn = eventInResponse.Item1;
            var errorData = eventInResponse.Item2;

            if (errorData != null)
            {
                if (errorData.fields == null)
                {
                    goto LOI_HE_THONG;
                }
                errorMessage = errorData.fields.Count > 0 ? (errorData.fields[0].ToString() ?? "") : errorData.detailCode;
                if (errorMessage != "Biển số không hợp lệ".ToUpper())
                {
                    goto SU_KIEN_LOI;
                }
            }
            else
            {
                if (eventIn.OpenBarrier)
                {
                    foreach (var controllerInLane in this.lane.controlUnits)
                    {
                        if (controllerInLane.barriers.Length > 0)
                        {
                            foreach (IController item in frmMain.controllers)
                            {
                                if (item.ControllerInfo.Id.ToLower() == controllerInLane.controlUnitId.ToLower())
                                {
                                    for (int i = 0; i < controllerInLane?.barriers.Length; i++)
                                    {
                                        bool isOpenSuccess = false;
                                        if (!await item.OpenDoor(100, controllerInLane.barriers[i]))
                                        {
                                            isOpenSuccess = await item.OpenDoor(100, controllerInLane.barriers[i]);
                                            if (!isOpenSuccess)
                                            {
                                            }
                                        }
                                        else
                                        {
                                        }
                                        if (isOpenSuccess)
                                        {
                                        }
                                    }
                                    break;
                                }
                            }

                        }
                    }

                }
                goto SU_KIEN_HOP_LE;
            }

        LOI_HE_THONG:
            {
                ExcecuteSystemErrorCheckIn();
                return;
            }
        SU_KIEN_LOI:
            {
                ExcecuteUnvalidEvent(null, null, vehicleType, selectedPlate, DateTime.Now, errorMessage, null, "");
                return;
            }
        SU_KIEN_HOP_LE:
            {

                await ExcecuteValidEvent(null, null, vehicleType, selectedPlate, DateTime.Now, overviewImg, vehicleImg, null, eventIn, false);
                var task1 = overviewImg.ImageToByteArrayAsync();
                var task2 = vehicleImg.ImageToByteArrayAsync();
                await Task.WhenAll(task1, task2);

                var imageDatas = new Dictionary<EmParkingImageType, List<List<byte>>>
                {
                    { EmParkingImageType.Overview, new List<List<byte>>(){ task1.Result } },
                    { EmParkingImageType.Vehicle,new List<List<byte>>(){ task2.Result } },
                };

                if (lastEvent != null)
                {
                    var identity = (await AppData.ApiServer.parkingDataService.GetIdentityByIdAsync(eventIn.Identity.Id)).Item1;
                    var response = await AppData.ApiServer.parkingProcessService.CreateAlarmAsync(identity.Code, this.lane.Id, lastEvent.PlateNumber, AbnormalCode.ManualEvent,
                                                          imageDatas, true,
                                                          identity?.IdentityGroupId, "", "", "");
                    if (response != null)
                    {
                        BaseLane.SaveImage(response.images, imageDatas);
                    }
                }
                return;
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
                var imageDatas = SaveAllCameraImage();

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
        private void PicRetakePhoto_MouseHover(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            var pictureBox = sender as PictureBox;
            pictureBox!.BackColor = Color.Green;
            pictureBox!.Refresh();
        }
        private void PicSetting_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            var pictureBox = (sender as PictureBox)!;
            pictureBox.BackColor = Color.DarkGreen;
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

        #region EVENT

        #endregion END EVENT

        #region PRIVATE FUNCTION
        private async Task<Tuple<bool, Identity?>> IsValidIdentity(string cardNumber)
        {
            var identityResponse = await AppData.ApiServer.parkingDataService.GetIdentityByCodeAsync(cardNumber);
            Identity? identity = identityResponse.Item1;
            if (identityResponse == null)
            {
                lblResult.UpdateResultMessage("Không đọc được thông tin định danh, vui lòng thử lại", Color.DarkRed);
                return Tuple.Create<bool, Identity?>(false, null);
            }

            if (identity == null)
            {
                lblResult.UpdateResultMessage("Mã định danh không có trong hệ thống", Color.DarkRed);
                return Tuple.Create<bool, Identity?>(false, null);
            }

            if (identity.Status == IdentityStatus.Locked)
            {
                lblResult.UpdateResultMessage("Định danh - ngừng sử dụng", Color.DarkRed);
                return Tuple.Create<bool, Identity?>(false, identity);
            }
            return Tuple.Create<bool, Identity?>(true, identity);
        }
        private void AllowDesignRealtime(bool isAllow)
        {
            splitContainerMain.IsSplitterFixed = !isAllow;
            splitContainerEventContent.IsSplitterFixed = !isAllow;
            splitterCamera.Enabled = isAllow;
            splitterEventInfoWithCamera.Enabled = isAllow;
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
                this.splitterEventInfoWithCamera.SplitPosition = this.laneDisplayConfig.splitEventInfoWithCameraPosition;
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

        private void FocusOnTitle()
        {
            this.Invoke(new Action(() =>
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
            }));
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