using IPaking.Ultility;
using iParkingv5.Controller;
using iParkingv5.Objects;
using iParkingv5.Objects.Configs;
using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Enums;
using iParkingv5.Objects.EventDatas;
using iParkingv5.Objects.Events;
using iParkingv5_CustomerRegister.Forms;
using iParkingv5_window.Forms.DataForms;
using iParkingv6.ApiManager.KzParkingv3Apis;
using iParkingv6.Objects.Datas;
using Kztek.Tool;
using Kztek.Tools;
using static iParkingv5.Objects.ApiInternalErrorMessages;
using static iParkingv5.Objects.Enums.LaneDisplayMode;
using static iParkingv5.Objects.Enums.VehicleType;

namespace iParkingv5_window.Usercontrols
{
    public partial class ucLaneIn : UserControl, iLane, IDisposable
    {
        #region PROPERTIES
        public event OnControlSizeChanged onControlSizeChangeEvent;

        #region -- Data
        public Lane lane { get; set; }
        private Dictionary<CameraPurposeType.EmCameraPurposeType, List<Camera>> cameras = new Dictionary<CameraPurposeType.EmCameraPurposeType, List<Camera>>();
        private List<Kztek.Cameras.Camera> camBienSoXeMayDuPhongs = new List<Kztek.Cameras.Camera>();
        private List<Kztek.Cameras.Camera> camBienSoOTODuPhongs = new List<Kztek.Cameras.Camera>();
        public EmLaneDisplayMode displayMode { get; set; } = EmLaneDisplayMode.Horizontal;
        #endregion

        #region -- Controls In Lane
        ucCameraView? ucOverView = null;
        ucCameraView? ucMotoLpr = null;
        ucCameraView? ucCarLpr = null;
        #endregion

        #region Config
        private LaneInShortcutConfig? laneInShortcutConfig = null;
        private List<ControllerShortcutConfig>? controllerShortcutConfigs = null;
        private LaneDisplayConfig? laneDisplayConfig = null;
        #endregion

        #region -- Event Properties
        EventIn? lastEvent = null;

        private readonly SemaphoreSlim semaphoreSlimOnNewEvent = new SemaphoreSlim(1, 1);
        private readonly SemaphoreSlim semaphoreSlimOnKeyPress = new SemaphoreSlim(1, 1);
        public List<CardEventArgs> lastCardEventDatas { get; set; } = new List<CardEventArgs>();
        public List<InputEventArgs> lastInputEventDatas { get; set; } = new List<InputEventArgs>();
        public event OnChangeLaneEvent? OnChangeLaneEvent;

        private bool isInRegister = false;

        private bool isLeftToRight = false;
        private bool isTopToBottom = true;
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

            panelAction.AutoScroll = true;
            this.DoubleBuffered = true;

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


            this.Load += UcLaneIn_Load;
        }
        private void UcLaneIn_Load(object? sender, EventArgs e)
        {
            GetShortcutConfig();
            LoadCamera();
            this.Dock = DockStyle.Top;
            lblResult.MaximumSize = new Size(this.DisplayRectangle.Width, this.Height);
            lblResult.MinimumSize = new Size(this.DisplayRectangle.Width, 0);
            lblResult.Padding = new Padding(StaticPool.baseSize);
            panelCameras.AutoScroll = true;
            this.SizeChanged += UcLaneIn_SizeChanged;
            panelCameras.SizeChanged += PanelCameras_SizeChanged;
            splitContainerEventContent.SizeChanged += SplitContainerEventContent_SizeChanged;
            splitContainerMain.MouseDoubleClick += SplitContainerEventContent_MouseDoubleClick;
            lblResult.UpdateResultMessage("XIN MỜI VÀO", Color.DarkGreen);
        }

        private void SplitContainerEventContent_MouseDoubleClick(object? sender, MouseEventArgs e)
        {
            if (frmMain.splitContainerMainLocation != null)
            {
                splitContainerMain.SplitterDistance = frmMain.splitContainerMainLocation.NewDistance;
            }
        }
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
        private void UcLaneIn_SizeChanged(object? sender, EventArgs e)
        {
            lblResult.MaximumSize = new Size(this.DisplayRectangle.Width, this.Height);
            lblResult.MinimumSize = new Size(this.DisplayRectangle.Width, 0);
            lblResult.Height = lblResult.PreferredHeight;
        }
        #endregion END FORMS

        #region CONTROLS IN FORM -- OK
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
                if (this.isTopToBottom)
                {
                    item.Width = (panelCameras.Height - 50) * 16 / 9;
                }
                else
                {
                    item.Width = panelCameras.Width - 5;
                }
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
                    if (this.isTopToBottom)
                    {
                        Point location = new Point(lastControl.Location.X + lastControl.Width + 10, lastControl.Location.Y);
                        panelCameras.Controls[i].Location = location;
                    }
                    else
                    {
                        Point location = new Point(lastControl.Location.X, lastControl.Location.Y + lastControl.Height + 10);
                        panelCameras.Controls[i].Location = location;
                    }
                }
            }
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
            RegisteredVehicle? registeredVehicle = await KzParkingApiHelper.GetRegisteredVehicle(selectedPlate);
            if (registeredVehicle == null)
            {
                return;
            }
            Image? vehicleImage = null;
            Image? overviewImage = ucOverView?.GetFullCurrentImage();
            VehicleType? vehicleType = null;
            Customer? customer = null;
            AddEventInResponse? eventIn = null;
            string errorMessage = string.Empty;

            int vehicleTypeId = registeredVehicle.VehicleTypeId;
            string customerId = registeredVehicle.CustomerId;

            vehicleType = await KzParkingApiHelper.GetVehicleTypeById(vehicleTypeId.ToString());
            switch (vehicleType.Type)
            {
                case VehicleBaseType.Car:
                    vehicleImage = ucCarLpr?.GetFullCurrentImage();
                    break;
                case VehicleBaseType.ElectricalCar:
                case VehicleBaseType.MotorBike:
                case VehicleBaseType.ElectricalMotorBike:
                case VehicleBaseType.Bicyle:
                case VehicleBaseType.ElectricalBike:
                    vehicleImage = ucMotoLpr?.GetFullCurrentImage();
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(customerId))
            {
                customer = await KzParkingApiHelper.GetCustomerById(customerId);
            }

            ClearView();
            var imageKey = BaseLane.GetBaseImageKey(this.lane.name, "", selectedPlate, DateTime.Now);
            var imageKeys = new List<string>() {
                                        imageKey + "_OVERVIEWIN.jpeg",
                                        imageKey + "_VEHICLEIN.jpeg",
                                        imageKey + "_LPRIN.jpeg", };
            var responseWithForce = await KzParkingApiHelper.PostCheckInAsync(lane.id, selectedPlate, null, imageKeys, true);
            if (responseWithForce == null)
            {
                goto LOI_HE_THONG;
            }
            if (responseWithForce.metadata.success == false)
            {
                errorMessage = ApiInternalErrorMessages.ToString(ApiInternalErrorMessages.GetFromName(responseWithForce.metadata.message.code));
                goto SU_KIEN_LOI;
            }
            else
            {
                eventIn = responseWithForce.data;
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
                ExcecuteUnvalidEvent(null, null, vehicleType, selectedPlate, DateTime.Now, errorMessage, eventIn?.customer, eventIn?.registeredVehicle?.PlateNumber ?? "");
                return;
            }
        SU_KIEN_HOP_LE:
            {
                if (eventIn.registeredVehicle != null)
                {
                    selectedPlate = eventIn.registeredVehicle.PlateNumber;
                }
                await ExcecuteValidEvent(null, null, vehicleType, selectedPlate, DateTime.Now, overviewImage, vehicleImage, null, imageKey, eventIn);
                return;
            }
            //frmSelectCard frmSelectCard = new("Chọn thẻ ghi vé vào");
            //if (frmSelectCard.ShowDialog() != DialogResult.OK) return;
            //frmSelectCard.Dispose();
            //foreach (ControllerInLane controllerInLane in lane.controlUnits)
            //{
            //    if (controllerInLane.readers.Length == 0)
            //    {
            //        continue;
            //    }

            //    CardEventArgs ce = new()
            //    {
            //        EventTime = DateTime.Now,
            //        DeviceId = controllerInLane.controlUnitId,
            //        ReaderIndex = controllerInLane.readers[0],
            //        AllCardFormats = new List<string>() { frmSelectCard.SelectIdentity },
            //        PreferCard = frmSelectCard.SelectIdentity,
            //    };

            //    await OnNewEvent(ce);
            //    if (lastEvent != null)
            //    {
            //        string imageKey = BaseLane.GetBaseImageKey(this.lane.name, ce.PreferCard, ce.PlateNumber, ce.EventTime);
            //        await KzParkingApiHelper.CreateAlarmAsync(frmSelectCard.SelectIdentityId, this.lane.id, ce.PlateNumber, AbnormalCode.ManualEvent, imageKey, true); ;
            //    }
            //    return;
            //}
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
            new frmLaneSetting(this.lane.id, StaticPool.leds, cameraList, this.lane.controlUnits.ToList(), true).ShowDialog();
            GetShortcutConfig();

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
        private void picSetting_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            picSetting.BackColor = Color.Green;
            picSetting.BorderStyle = BorderStyle.FixedSingle;
        }
        private void picSetting_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            picSetting.BackColor = Color.DarkGreen;
            picSetting.BorderStyle = BorderStyle.None;
        }
        #endregion END CONTROLS IN FORM

        #region PUBLIC FUNCTION -- OK
        /// <summary>
        /// Tải thông tin cấu hình phím tắt lưu trong hệ thống
        /// </summary>
        public void GetShortcutConfig()
        {
            laneInShortcutConfig = NewtonSoftHelper<LaneInShortcutConfig>.DeserializeObjectFromPath(PathManagement.laneShortcutConfigPath(this.lane.id)) ?? new LaneInShortcutConfig();
            controllerShortcutConfigs = NewtonSoftHelper<List<ControllerShortcutConfig>>.DeserializeObjectFromPath(PathManagement.laneControllerShortcutConfigPath(this.lane.id)) ?? new List<ControllerShortcutConfig>();
        }

        /// <summary>
        /// Hiển thị giao diện như lần cuối cùng sử dụng
        /// </summary>
        public void DisplayUIConfig()
        {
            this.SuspendLayout();
            if (this.laneDisplayConfig == null) return;

            this.splitContainerMain.SplitterDistance = this.laneDisplayConfig.splitContainerMain;
            this.splitContainerMain.Refresh();

            this.splitContainerEventContent.SplitterDistance = this.laneDisplayConfig.splitContainerEventContent;
            this.splitContainerEventContent.Refresh();

            this.splitterCamera.SplitPosition = this.laneDisplayConfig.SplitterCameraPosition;
            this.splitterCamera.Refresh();
            this.ResumeLayout();
        }

        /// <summary>
        /// Lấy thông tin hiển thị hiện tại để lưu lại
        /// </summary>
        /// <returns></returns>
        public LaneDisplayConfig SaveUIConfig()
        {
            return new LaneDisplayConfig()
            {
                LaneId = this.lane.id,
                DisplayIndex = 1,
                splitContainerEventContent = this.splitContainerEventContent.SplitterDistance,
                splitContainerMain = this.splitContainerMain.SplitterDistance,
                SplitterCameraPosition = this.splitterCamera.SplitPosition,
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
            if (isInRegister)
            {
                semaphoreSlimOnNewEvent.Release();
                return;
            }
            lastEvent = null;
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
        #endregion END PUBLIC FUNCTION -- OK

        #region EVENT
        public async Task ExcecuteInputEvent(InputEventArgs ie)
        {
            foreach (ControllerInLane controllerInLane in lane.controlUnits)
            {
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
            AddEventInResponse? eventIn = null;
            string errorMessage = string.Empty;

            //Danh sách biến sử dụng
            Image? vehicleImg = null;
            Image? overviewImage = null;
            List<Image?> optionalImages = new();
            string imageKey = string.Empty;
            VehicleType? vehicleType = null;
            Customer? customer = null;
            lblResult.UpdateResultMessage("Đang kiểm trang thông tin sự kiện loop..." + ie.InputIndex, Color.DarkBlue);
            overviewImage = ucOverView?.GetFullCurrentImage();
            string plate = "";
            Image? lprImage = null;
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
            //Hiển thị thông tin hình ảnh phương tiện
            BaseLane.ShowImage(picVehicleImage, vehicleImg);
            BaseLane.ShowImage(picOverviewImage, overviewImage);

            //Không đọc được biển số hoặc biển số đọc được không hợp lệ, hiểm thị hình ảnh toàn cảnh và kết thúc sự kiện
            if (string.IsNullOrEmpty(plate) || plate.Length < 5)
            {
                lblResult.UpdateResultMessage("Không đọc được thông tin biển số xe", Color.DarkRed);
                return;
            }
            //Đọc thông tin định danh từ thông tin biển số nhận được
            else
            {
                ClearView();
                imageKey = BaseLane.GetBaseImageKey(this.lane.name, "", plate, ie.EventTime);
                lblResult.UpdateResultMessage("Đang check in..." + plate, Color.DarkBlue);
                BaseLane.ShowImage(picLprImage, lprImage);
                txtPlate.Invoke(new Action(() =>
                {
                    txtPlate.Text = plate;
                }));

                //Đọc thông tin loại phương tiện
                RegisteredVehicle? registeredVehicle = await KzParkingApiHelper.GetRegisteredVehicle(plate);
                if (registeredVehicle == null)
                {
                    lblResult.UpdateResultMessage("Phương tiện chưa được đăng ký trong hệ thống", Color.DarkRed);
                    return;
                }

                int vehicleTypeId = registeredVehicle.VehicleTypeId;
                string customerId = registeredVehicle.CustomerId;

                vehicleType = await KzParkingApiHelper.GetVehicleTypeById(vehicleTypeId.ToString());
                if (!string.IsNullOrEmpty(customerId))
                {
                    customer = await KzParkingApiHelper.GetCustomerById(customerId);
                }
                var imageKeys = new List<string>()
                                                {
                                                    imageKey + "_OVERVIEWIN.jpeg",
                                                    imageKey + "_VEHICLEIN.jpeg",
                                                    imageKey + "_LPRIN.jpeg",
                };

            CheckInNormal:
                {
                    var responseNormal = await KzParkingApiHelper.PostCheckInAsync(lane.id, plate, null, imageKeys);
                    if (responseNormal == null)
                    {
                        goto LOI_HE_THONG;
                    }
                    if (responseNormal.metadata.success == false)
                    {
                        var errorCode = ApiInternalErrorMessages.GetFromName(responseNormal.metadata.message.code);
                        if (errorCode == EmApiErrorMessage.PINT_1013 || errorCode == EmApiErrorMessage.PINT_1018)
                        {
                            bool isConfirm = MessageBox.Show(ApiInternalErrorMessages.ToString(errorCode), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes;
                            if (isConfirm)
                            {
                                goto CheckInWithForce;
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            errorMessage = ApiInternalErrorMessages.ToString(errorCode);
                            goto SU_KIEN_LOI;
                        }
                    }
                    else
                    {
                        eventIn = responseNormal.data;
                        if (eventIn.OpenBarrier)
                        {
                            ControllerInLane? controllerInLane = (from _controllerInLane in this.lane.controlUnits
                                                                  where _controllerInLane.controlUnitId == ie.DeviceId
                                                                  select _controllerInLane).FirstOrDefault();
                            await BaseLane.OpenBarrieByControllerId(ie.DeviceId, controllerInLane);
                        }
                        goto SU_KIEN_HOP_LE;
                    }
                }

            CheckInWithForce:
                {
                    var responseWithForce = await KzParkingApiHelper.PostCheckInAsync(lane.id, plate, null, imageKeys, true);
                    if (responseWithForce == null)
                    {
                        goto LOI_HE_THONG;
                    }
                    if (responseWithForce.metadata.success == false)
                    {
                        errorMessage = ApiInternalErrorMessages.ToString(ApiInternalErrorMessages.GetFromName(responseWithForce.metadata.message.code));
                        goto SU_KIEN_LOI;
                    }
                    else
                    {
                        eventIn = responseWithForce.data;
                        if (eventIn.OpenBarrier)
                        {
                            ControllerInLane? controllerInLane = (from _controllerInLane in this.lane.controlUnits
                                                                  where _controllerInLane.controlUnitId == ie.DeviceId
                                                                  select _controllerInLane).FirstOrDefault();
                            await BaseLane.OpenBarrieByControllerId(ie.DeviceId, controllerInLane);
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
                    ExcecuteUnvalidEvent(null, null, vehicleType, plate, ie.EventTime, errorMessage, eventIn?.customer, eventIn?.registeredVehicle?.PlateNumber ?? "");
                    return;
                }
            SU_KIEN_HOP_LE:
                {
                    if (eventIn.registeredVehicle != null)
                    {
                        plate = eventIn.registeredVehicle.PlateNumber;
                    }
                    await ExcecuteValidEvent(null, null, vehicleType, plate, ie.EventTime, overviewImage, vehicleImg, lprImage, imageKey, eventIn);
                    return;
                }
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
            if (lastEvent == null || (DateTime.Now - lastEvent.DatetimeIn)?.TotalSeconds >= StaticPool.appOption.AllowBarrieDelayOpenTime)
            {
                string imageKey = BaseLane.GetBaseImageKey(this.lane.name, "", "", ie.EventTime);
                await KzParkingApiHelper.CreateAlarmAsync("", this.lane.id, "", AbnormalCode.OpenBarrierByButton, imageKey, true);
                await SaveAllCameraImage(imageKey);
            }
        }

        /// <summary>
        /// Sự kiện xảy ra khi người dùng quẹt thẻ trên đầu đọc, hoặc đầu đọc xa phát hiện thẻ
        /// </summary>
        /// <param name="ce"></param>
        /// <returns></returns>
        public async Task ExcecuteCardEvent(CardEventArgs ce)
        {
            AddEventInResponse? eventIn = null;
            if (!this.CheckNewCardEvent(this.lane, ce, out ControllerInLane? controllerInLane, out int thoiGianCho))
            {
                if (thoiGianCho > 0)
                {
                    lblResult.UpdateResultMessage($"Đang trong thời gian chờ, vui lòng quẹt lại sau {thoiGianCho}s", Color.DarkBlue);
                }
                return;
            }
            ClearView();
            //Danh sách biến sử dụng
            Image? overviewImg = null;
            Image? vehicleImg = null;
            List<Image?> optionalImages = new();

            lblResult.UpdateResultMessage("Đang kiểm trang thông tin sự kiện quẹt thẻ..." + ce.PreferCard, Color.DarkBlue);

            //Đọc thông tin định danh theo mã thẻ
            var identityResponse = await KzParkingApiHelper.GetIdentityByCode(ce.PreferCard);
            Identity? identity = identityResponse.Item1;
            if (!identityResponse.Item2)
            {
                lblResult.UpdateResultMessage("Không đọc được thông tin định danh, vui lòng thử lại", Color.DarkRed);
                return;
            }
            if (identity == null)
            {
                lblResult.UpdateResultMessage("Mã định danh không có trong hệ thống", Color.DarkRed);
                return;
            }

            lblResult.UpdateResultMessage("Đọc thông tin nhóm định danh...", Color.DarkBlue);
            IdentityGroup identityGroup = await KzParkingApiHelper.GetIdentityGroupByIdAsync(identity.IdentityGroupId.ToString());
            if (identityGroup == null)
            {
                lblResult.UpdateResultMessage("Không đọc được thông tin nhóm định danh, vui lòng thử lại", Color.DarkRed);
                return;
            }

            lblResult.UpdateResultMessage("Đọc thông tin loại phương tiện...", Color.DarkBlue);
            int vehicleTypeId = identityGroup!.VehicleTypeId;
            VehicleType vehicleType = await KzParkingApiHelper.GetVehicleTypeById(vehicleTypeId.ToString());
            VehicleBaseType vehicleBaseType = vehicleType.Type;
            switch (vehicleBaseType)
            {
                case VehicleBaseType.Unknown:
                    lblResult.UpdateResultMessage("Thông tin loại phương tiện không hợp lệ vui lòng sử dụng thẻ khác", Color.DarkRed);
                    return;
                default:
                    break;
            }

            //Nếu là sự kiện thẻ thì đọc biển số,
            //còn nếu là sự kiện loop chuyển qua quẹt thẻ thì hiển thị thông tin biển số đã đọc trước đó chứ không đọc lại tránh tốn lượt nhận dạng
            Image? lprImage = GetPlate(ce, ref overviewImg, ref vehicleImg, vehicleBaseType);
            //Đọc thông tin loại phương tiện
            lblResult.UpdateResultMessage("Đang check in..." + ce.PreferCard, Color.DarkBlue);
            string imageKey = BaseLane.GetBaseImageKey(this.lane.name, ce.PreferCard, ce.PlateNumber, ce.EventTime);
            List<string> imageKeys = new List<string>()
                 {
                     imageKey + "_OVERVIEWIN.jpeg",
                     imageKey + "_VEHICLEIN.jpeg",
                     imageKey + "_LPRIN.jpeg",
                 };
            bool isMonthCard = identityGroup.Type == IdentityGroupType.Monthly;
            if (isMonthCard)
            {
                await ExcecuteMonthCardEventIn(identity, identityGroup, vehicleType, ce.PlateNumber, imageKeys,
                                               ce, controllerInLane,
                                               overviewImg, vehicleImg, lprImage, imageKey);
            }
            else
            {
                await ExcecuteNonMonthCardEventIn(identity, identityGroup, vehicleType, ce.PlateNumber, imageKeys,
                                                  ce, controllerInLane,
                                                  overviewImg, vehicleImg, lprImage, imageKey);
            }

        }

        public async void OnKeyPress(Keys keys)
        {
            await semaphoreSlimOnKeyPress.WaitAsync();
            try
            {
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
                                    newPlate = txtPlate.Text;
                                }));
                                bool isUpdateSuccess = await KzParkingApiHelper.UpdateEventInPlate(lastEvent.Id, newPlate);
                                if (isUpdateSuccess)
                                {
                                    lblResult.UpdateResultMessage("Ra Lệnh Cập Nhật Biển Số Thành Công", Color.DarkBlue);
                                }
                                else
                                {
                                    lblResult.UpdateResultMessage("Cập nhật lỗi, vui lòng thử lại", Color.DarkBlue);
                                }
                            }
                        }
                    }
                    else if ((int)keys == laneInShortcutConfig.ReserveLane)
                    {
                        if (!string.IsNullOrEmpty(this.lane.reverseLaneId?.ToString()))
                        {
                            //Đảo làn
                            lblResult.UpdateResultMessage("Ra Lệnh Đảo Làn", Color.DarkBlue);
                            OnChangeLaneEvent?.Invoke(this);
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
        /// Sự kiện xảy ra khi người dùng sử dụng phím tắt để ra lệnh mở barrie
        /// </summary>
        private async Task ProcessButtonEvent()
        {
            //--Chưa có sự kiện vào hoặc thời gian từ lúc có sự kiện đến khi bấm mở barrie quá 5s thì lưu sự kiện cảnh báo
            if (lastEvent == null || (DateTime.Now - lastEvent.DatetimeIn)?.TotalSeconds >= StaticPool.appOption.AllowBarrieDelayOpenTime)
            {
                string imageKey = BaseLane.GetBaseImageKey(this.lane.name, "", "", DateTime.Now);
                await KzParkingApiHelper.CreateAlarmAsync("", this.lane.id, "", AbnormalCode.OpenBarrierByKeyboard, imageKey, true); ;
                await SaveAllCameraImage(imageKey);
            }
        }
        #endregion End EVENT

        #region Private Function
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
                string camType = cameras[key][0].GetCameraType() == "HIK" ? "HIKVISION" : cameras[key][0].GetCameraType();
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
            BaseLane.ShowImage(picOverviewImage, overviewImg);
            BaseLane.ShowImage(picVehicleImage, vehicleImg);
            BaseLane.ShowImage(picLprImage, lprImage);

            txtPlate.Invoke(new Action(() =>
            {
                txtPlate.Text = ce.PlateNumber;
                txtPlate.Refresh();
            }));
            return lprImage;
        }
        private void DisplayEventInfo(DateTime eventTime, string plateNumber, Identity? identity, IdentityGroup? identityGroup, VehicleType? vehicle, Customer? customer, RegisteredVehicle? registeredVehicle)
        {
            LaneDirectionConfig laneDirection = NewtonSoftHelper<LaneDirectionConfig>.DeserializeObjectFromPath(
                                                      PathManagement.appLaneDirectionConfigPath(this.lane.id)) ?? LaneDirectionConfig.CreateDefault();
            dgvEventContent?.Invoke(new Action(() =>
            {
                dgvEventContent.Columns[0].Visible = laneDirection.IsDisplayTitle;
            }));
            dgvEventContent?.Invoke(new Action(() =>
            {
                dgvEventContent.Rows.Clear();
                dgvEventContent.Rows.Add("Thời gian", eventTime.ToString("dd/MM/yyyy HH:mm:ss"));
                dgvEventContent.Rows.Add("Mã định danh", identity?.Code);
                dgvEventContent.Rows.Add("Biển số nhận diện", plateNumber);
                if (customer != null)
                {
                    dgvEventContent.Rows.Add("Khách hàng", customer.Name + " / " + customer.Address);
                }
                if (registeredVehicle != null)
                {
                    dgvEventContent.Rows.Add("Biển số đăng ký", registeredVehicle.Name + "/" + registeredVehicle.PlateNumber);
                }
                if (identity != null)
                {
                    switch (identity.Type)
                    {
                        case IdentityType.Card:
                            dgvEventContent.Rows.Add("Hình thức", "Quẹt thẻ");
                            break;
                        case IdentityType.QrCode:
                            dgvEventContent.Rows.Add("Hình thức", "QR Code");
                            break;
                        case IdentityType.FingerPrint:
                            dgvEventContent.Rows.Add("Hình thức", "Vân tay");
                            break;
                        case IdentityType.FaceId:
                            dgvEventContent.Rows.Add("Hình thức", "Gương mặt");
                            break;
                        default:
                            break;
                    }
                }
                if (identityGroup != null)
                {
                    dgvEventContent.Rows.Add("Nhóm", identityGroup.Name);
                }
                if (vehicle != null)
                {
                    dgvEventContent.Rows.Add("Loại phương tiện", VehicleType.GetDisplayStr(vehicle.Type));
                }
            }));
        }

        private async Task SaveAllCameraImage(string imageKey)
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

            var task1 = MinioHelper.UploadPicture(overviewImg, imageKey + "_OVERVIEWIN.jpeg");
            if (carVehicleImage != null)
            {
                var task2 = MinioHelper.UploadPicture(carVehicleImage, imageKey + "_VEHICLEIN.jpeg");
                await Task.WhenAll(task1, task2);
            }
            else
            {
                var task3 = MinioHelper.UploadPicture(motorVehicleImage, imageKey + "_VEHICLEIN.jpeg");
                await Task.WhenAll(task1, task3);
            }
        }

        private void ClearView()
        {
            this.Invoke(new Action(() =>
            {
                dgvEventContent.Rows.Clear();
                dgvEventContent.Refresh();

                picOverviewImage.Image = null;
                picOverviewImage.Refresh();

                picLprImage.Image = null;
                picLprImage.Refresh();

                picVehicleImage.Image = null;
                picVehicleImage.Refresh();

                txtPlate.Text = string.Empty;
                txtPlate.Refresh();

                lblResult.Message = "";
                lblResult.Refresh();
            }));
        }
        #endregion End Private Function


        #region Xử lý sự kiện thẻ
        private async Task ExcecuteMonthCardEventIn(Identity identity, IdentityGroup identityGroup, VehicleType vehicleType, string plateNumber, List<string> imageKeys,
                                                    CardEventArgs ce, ControllerInLane? controllerInLane,
                                                    Image? overviewImg, Image? vehicleImg, Image? lprImage, string imageKey)
        {
            string errorMessage = string.Empty;
            AddEventInResponse? eventIn = null;
            if (string.IsNullOrEmpty(plateNumber))
            {
                bool isConfirm = MessageBox.Show("Không nhận diện được biển số, bạn có muốn cho xe vào bãi?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes;
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
            else
            {
                goto CheckInNormal;
            }

        CheckInNormal:
            {
                var responseNormal = await KzParkingApiHelper.PostCheckInAsync(lane.id, plateNumber, identity, imageKeys);
                if (responseNormal == null)
                {
                    goto LOI_HE_THONG;
                }
                if (responseNormal.metadata.success == false)
                {
                    var errorCode = ApiInternalErrorMessages.GetFromName(responseNormal.metadata.message.code);
                    if (errorCode == EmApiErrorMessage.PINT_1013 || errorCode == EmApiErrorMessage.PINT_1018)
                    {
                        string registerPlate = "";
                        string customerName = "";
                        string customerAddress = "";
                        if (identity != null)
                        {
                            if (identity.RegisteredVehicles != null)
                            {
                                if (identity.RegisteredVehicles.Count > 0)
                                {
                                    registerPlate = identity.RegisteredVehicles[0].PlateNumber;
                                    customerName = identity.RegisteredVehicles[0].Customer?.Name ?? "";
                                    customerAddress = identity.RegisteredVehicles[0].Customer?.Address ?? "";
                                }
                            }
                        }
                        string message = ApiInternalErrorMessages.ToString(errorCode) + "\r\nBạn có muốn cho xe vào bãi?";
                        bool isConfirm = new frmConfirmIn(message, identity?.Code ?? "", identity?.Name ?? "", identityGroup?.Name ?? "",
                                                          customerName, registerPlate, customerAddress, vehicleImg, overviewImg).ShowDialog()
                                                == DialogResult.OK;

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
                    else
                    {
                        errorMessage = ApiInternalErrorMessages.ToString(errorCode);
                        goto SU_KIEN_LOI;
                    }
                }
                else
                {
                    eventIn = responseNormal.data;
                    if (eventIn.OpenBarrier)
                    {
                        await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane);
                    }
                    goto SU_KIEN_HOP_LE;
                }
            }

        CheckInWithForce:
            {
                var responseWithForce = await KzParkingApiHelper.PostCheckInAsync(lane.id, plateNumber, identity, imageKeys, true);
                if (responseWithForce == null)
                {
                    goto LOI_HE_THONG;
                }
                if (responseWithForce.metadata.success == false)
                {
                    errorMessage = ApiInternalErrorMessages.ToString(ApiInternalErrorMessages.GetFromName(responseWithForce.metadata.message.code));
                    goto SU_KIEN_LOI;
                }
                else
                {
                    eventIn = responseWithForce.data;
                    if (eventIn.OpenBarrier)
                    {
                        await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane);
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
                ExcecuteUnvalidEvent(identity, identityGroup, vehicleType, ce.PlateNumber, ce.EventTime, errorMessage, eventIn?.customer, eventIn?.registeredVehicle?.PlateNumber ?? "");
                return;
            }
        SU_KIEN_HOP_LE:
            {
                if (eventIn.registeredVehicle != null)
                {
                    await ExcecuteValidEvent(identity, identityGroup, vehicleType, eventIn.registeredVehicle.PlateNumber, ce.EventTime, overviewImg, vehicleImg, lprImage, imageKey, eventIn);
                }
                else
                {
                    await ExcecuteValidEvent(identity, identityGroup, vehicleType, ce.PlateNumber, ce.EventTime, overviewImg, vehicleImg, lprImage, imageKey, eventIn);
                }
                return;
            }
        }
        private async Task ExcecuteNonMonthCardEventIn(Identity identity, IdentityGroup identityGroup, VehicleType vehicleType, string plateNumber, List<string> imageKeys,
                                                       CardEventArgs ce, ControllerInLane? controllerInLane,
                                                       Image? overviewImg, Image? vehicleImg, Image? lprImage, string imageKey)
        {

            string errorMessage = string.Empty;
            AddEventInResponse? eventIn = null;

            var responseNormal = await KzParkingApiHelper.PostCheckInAsync(lane.id, plateNumber, identity, imageKeys);
            if (responseNormal == null)
            {
                goto LOI_HE_THONG;
            }
            if (responseNormal.metadata.success == false)
            {
                var errorCode = ApiInternalErrorMessages.GetFromName(responseNormal.metadata.message.code);

                errorMessage = ApiInternalErrorMessages.ToString(errorCode);
                goto SU_KIEN_LOI;
            }
            else
            {
                eventIn = responseNormal.data;
                if (eventIn.OpenBarrier)
                {
                    await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane);
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
                ExcecuteUnvalidEvent(identity, identityGroup, vehicleType, ce.PlateNumber, ce.EventTime, errorMessage, eventIn?.customer, eventIn?.registeredVehicle?.PlateNumber ?? "");
                return;
            }
        SU_KIEN_HOP_LE:
            {
                if (eventIn.registeredVehicle != null)
                {
                    await ExcecuteValidEvent(identity, identityGroup, vehicleType, eventIn.registeredVehicle.PlateNumber, ce.EventTime, overviewImg, vehicleImg, lprImage, imageKey, eventIn);
                }
                else
                {
                    await ExcecuteValidEvent(identity, identityGroup, vehicleType, ce.PlateNumber, ce.EventTime, overviewImg, vehicleImg, lprImage, imageKey, eventIn);
                }
                return;
            }
        }

        private void ExcecuteSystemErrorCheckIn()
        {
            lblResult.UpdateResultMessage("Không gửi được thông tin xe vào lên hệ thống, vui lòng thử lại sau giây lát", Color.DarkRed);
        }
        private void ExcecuteUnvalidEvent(Identity identity, IdentityGroup identityGroup, VehicleType vehicleType, string detectPlate, DateTime eventTime, string errorMessage, Customer? customer, string registerPlate)
        {
            lblResult.UpdateResultMessage(errorMessage, Color.DarkRed);
            DisplayEventInfo(eventTime, detectPlate, identity, identityGroup, vehicleType, customer, null);
        }
        private async Task ExcecuteValidEvent(Identity? identity, IdentityGroup? identityGroup,
                                              VehicleType vehicleType, string detectPlate,
                                              DateTime eventTime, Image? overviewImg,
                                              Image? vehicleImg, Image? lprImage, string imageKey,
                                              AddEventInResponse? eventIn)
        {
            txtPlate.Invoke(new Action(() =>
            {
                txtPlate.Text = detectPlate;
            }));
            lblResult.UpdateResultMessage("Xin Mời Qua", Color.DarkGreen);

            DisplayEventInfo(eventTime, detectPlate, identity, identityGroup, vehicleType, eventIn?.customer, eventIn?.registeredVehicle);
            BaseLane.DisplayLed(detectPlate, eventTime, identity, identityGroup, "Hẹn Gặp lại", this.lane.id);
            await BaseLane.SaveEventImage(overviewImg, vehicleImg, lprImage, imageKey, true);

            lastEvent = new EventIn()
            {
                Id = eventIn?.Id,
                CreatedUtc = eventTime.AddHours(-7).ToString("yyyy-MM-ddTHH:mm:ss:ffff"),
                PlateNumber = detectPlate,
                Identity = identity,
                IdentityId = identity?.Id,
                LaneId = this.lane.id,
            };

        }
        #endregion End xử lý sự kiện thẻ

        #region Xử lý sự kiện loop

        #endregion End xử lý sự kiện loop

        private async void btnOpenBarrie_Click(object sender, EventArgs e)
        {
            //ControllerInLane? controllerInLane = (from _controllerInLane in this.lane.controlUnits
            //                                      where _controllerInLane.controlUnitId == ie.DeviceId
            //                                      select _controllerInLane).FirstOrDefault();
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

            if (lastEvent == null || (DateTime.Now - lastEvent.DatetimeIn)?.TotalSeconds >= StaticPool.appOption.AllowBarrieDelayOpenTime)
            {
                string imageKey = BaseLane.GetBaseImageKey(this.lane.name, "", "", DateTime.Now);
                await KzParkingApiHelper.CreateAlarmAsync("", this.lane.id, "", AbnormalCode.OpenBarrierByKeyboard, imageKey, true);
                await SaveAllCameraImage(imageKey);
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void panelAction_SizeChanged(object sender, EventArgs e)
        {
          //  panelAction.Height = panelAction.PreferredSize.Height;
            //panelAction.Height = (panelAction.Width > panelAction.PreferredSize.Width) ? 48 : 20 + 48;
        }
    }
}