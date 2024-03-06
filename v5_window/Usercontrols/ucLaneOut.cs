using IPaking.Ultility;
using iPakrkingv5.Controls;
using iParkingv5.Controller;
using iParkingv5.Objects;
using iParkingv5.Objects.Configs;
using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Enums;
using iParkingv5.Objects.EventDatas;
using iParkingv5.Objects.Events;
using iParkingv5_window.Forms.DataForms;
using iParkingv5_window.Forms.ReportForms;
using iParkingv6.ApiManager.KzParkingv3Apis;
using iParkingv6.Objects.Datas;
using Kztek.Tool;
using Kztek.Tool.TextFormatingTools;
using Kztek.Tools;
using static iParkingv5.Objects.ApiInternalErrorMessages;
using static iParkingv5.Objects.Enums.VehicleType;

namespace iParkingv5_window.Usercontrols
{
    public partial class ucLaneOut : UserControl, iLane, IDisposable
    {
        #region PROPERTIES
        public event OnControlSizeChanged onControlSizeChangeEvent;
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
        EventOut? lastEvent = null;

        private Image? LoopVehicleImage = null;
        private Image? LoopLprImage = null;

        private readonly SemaphoreSlim semaphoreSlimOnNewEvent = new SemaphoreSlim(1, 1);
        private readonly SemaphoreSlim semaphoreSlimOnKeyPress = new SemaphoreSlim(1, 1);
        public List<CardEventArgs> lastCardEventDatas { get; set; } = new List<CardEventArgs>();
        public List<InputEventArgs> lastInputEventDatas { get; set; } = new List<InputEventArgs>();
        public event OnChangeLaneEvent OnChangeLaneEvent;
        #endregion 
        #endregion END PROPERTIES

        #region FORMS
        public ucLaneOut(Lane lane, LaneDisplayConfig? laneDisplayConfig)
        {
            InitializeComponent();
            this.DoubleBuffered = true;

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

            this.laneDisplayConfig = laneDisplayConfig;
            this.Load += UcLaneIn_Load;
        }
        private void UcLaneIn_Load(object? sender, EventArgs e)
        {
            GetShortcutConfig();
            LoadCamera();
            this.Dock = DockStyle.Top;
            lblResult.MaximumSize = new Size(this.DisplayRectangle.Width, 0);
            lblResult.MinimumSize = new Size(this.DisplayRectangle.Width, 0);
            lblResult.Padding = new Padding(StaticPool.baseSize);
            lblResult.Height = lblResult.PreferredHeight;
            panelCameras.AutoScroll = true;
            this.SizeChanged += UcLaneOut_SizeChanged;
            panelCameras.SizeChanged += PanelCameras_SizeChanged;
            splitContainerEventContent.SizeChanged += SplitContainerEventContent_SizeChanged;
            splitContainerMain.MouseDoubleClick += SplitContainerEventContent_MouseDoubleClick;
            lblResult.UpdateResultMessage("HẸN GẶP LẠI", Color.DarkGreen);
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

        private void UcLaneOut_SizeChanged(object? sender, EventArgs e)
        {
            lblResult.MaximumSize = new Size(this.DisplayRectangle.Width, 0);
            lblResult.MinimumSize = new Size(this.DisplayRectangle.Width, 0);
            lblResult.Height = lblResult.PreferredHeight;
        }
        #endregion END FORMS

        #region CONTROLS IN FORM
        private async void btnOpenBarrie_Click(object sender, EventArgs e)
        {
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

            if (lastEvent == null || (DateTime.Now - lastEvent.DatetimeOut)?.TotalSeconds >= StaticPool.appOption.AllowBarrieDelayOpenTime)
            {
                string imageKey = BaseLane.GetBaseImageKey(this.lane.name, "", "", DateTime.Now);
                await KzParkingApiHelper.CreateAlarmAsync("", this.lane.id, "", AbnormalCode.OpenBarrierByKeyboard, imageKey, false);
                await SaveAllCameraImage(imageKey);
            }
        }

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
                Identity identity = await KzParkingApiHelper.GetIdentityById(frm.selectedIdentityId);
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
                            string imageKey = BaseLane.GetBaseImageKey(this.lane.name, ce.PreferCard, ce.PlateNumber, ce.EventTime);
                            await KzParkingApiHelper.CreateAlarmAsync(identity.Id, this.lane.id, ce.PlateNumber, AbnormalCode.ManualEvent, imageKey, false); ;
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

        /// <summary>
        /// IN VÉ XE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintTicket_Click(object sender, EventArgs e)
        {
            string printTemplateName = "";
            string directory = LogHelper.SaveLogFolder + $"/configs/app/";
            string printTemplatePath = directory + $"print/{printTemplateName}.txt";
            if (File.Exists(printTemplatePath))
            {
                string printContent = GetPrintContent(File.ReadAllText(printTemplatePath));
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
            picSetting.BorderStyle = BorderStyle.FixedSingle;
            picSetting.BackColor = Color.Red;
        }
        private void picSetting_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            picSetting.BorderStyle = BorderStyle.None;
            picSetting.BackColor = Color.DarkRed;
        }
        #endregion END CONTROLS IN FORM

        #region Public Function
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
            this.IsSupportsTransparency();
            if (this.laneDisplayConfig == null)
            {
                return;
            }
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
        #endregion

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
            LoopLprImage = null;
            LoopVehicleImage = null;

            Image? overviewImage = ucOverView?.GetFullCurrentImage();

            lblResult.UpdateResultMessage("Đang kiểm trang thông tin sự kiện loop..." + ie.InputIndex, Color.DarkBlue);
            //Đọc biển số bằng cam ô tô
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
                var responseNormal = await KzParkingApiHelper.PostCheckOutAsync(lane.id, plate, null, imageKeys, false);
                if (responseNormal == null)
                {
                    goto LOI_HE_THONG;
                }
                if (responseNormal.metadata.success == false)
                {
                    var errorCode = ApiInternalErrorMessages.GetFromName(responseNormal.metadata.message.code);
                    if (errorCode == EmApiErrorMessage.PINT_1013 || errorCode == EmApiErrorMessage.PINT_1018)
                    {
                        string message = ApiInternalErrorMessages.ToString(errorCode);
                        bool isConfirm = new frmConfirmOut(message, responseNormal.data?.plateNumber ?? "", responseNormal.data?.identityId ?? "", responseNormal.data?.laneId ?? "", responseNormal.data?.fileKeys, responseNormal.data?.DatetimeOut ?? DateTime.Now).ShowDialog()
                                                == DialogResult.OK;
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
                    else
                    {
                        errorMessage = ApiInternalErrorMessages.ToString(errorCode);
                        goto SU_KIEN_LOI;
                    }
                }
                else
                {
                    eventOut = responseNormal.data;
                    if (eventOut.OpenBarrier)
                    {
                        ControllerInLane? controllerInLane = (from _controllerInLane in this.lane.controlUnits
                                                              where _controllerInLane.controlUnitId == ie.DeviceId
                                                              select _controllerInLane).FirstOrDefault();
                        await BaseLane.OpenBarrieByControllerId(ie.DeviceId, controllerInLane);
                        KzParkingApiHelper.CommitOutAsync(responseNormal.data);
                    }
                    else
                    {
                        bool isConfirm = new frmConfirmOut("Bạn có xác nhận mở barrie?", responseNormal.data?.eventInPlateNumber ?? "", responseNormal.data?.eventInIdentityId ?? "", responseNormal.data?.eventInLaneId ?? "", responseNormal.data?.eventInFileKeys, responseNormal.data?.DatetimeIn ?? DateTime.Now, false, responseNormal.data?.charge ?? 0).ShowDialog()
                                                           == DialogResult.OK;
                        if (!isConfirm)
                        {
                            lblResult.UpdateResultMessage("Không xác nhận mở barrie", Color.DarkOrange);
                            return;
                        }
                        else
                        {
                            ControllerInLane? controllerInLane = (from _controllerInLane in this.lane.controlUnits
                                                                  where _controllerInLane.controlUnitId == ie.DeviceId
                                                                  select _controllerInLane).FirstOrDefault();
                            await BaseLane.OpenBarrieByControllerId(ie.DeviceId, controllerInLane);
                            KzParkingApiHelper.CommitOutAsync(responseNormal.data);
                        }
                    }
                    goto SU_KIEN_HOP_LE;
                }
            }
        CheckOutWithForce:
            {
                var responseWithForce = await KzParkingApiHelper.PostCheckOutAsync(lane.id,
                                                            plate, null, imageKeys, true);
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
                    eventOut = responseWithForce.data;
                    if (eventOut.OpenBarrier)
                    {
                        ControllerInLane? controllerInLane = (from _controllerInLane in this.lane.controlUnits
                                                              where _controllerInLane.controlUnitId == ie.DeviceId
                                                              select _controllerInLane).FirstOrDefault();
                        await BaseLane.OpenBarrieByControllerId(ie.DeviceId, controllerInLane);
                        KzParkingApiHelper.CommitOutAsync(eventOut);
                    }
                    else
                    {
                        bool isConfirm = new frmConfirmOut("Bạn có xác nhận mở barrie?",
                                                        responseWithForce.data?.eventInPlateNumber ?? "", responseWithForce.data?.eventInIdentityId ?? "", responseWithForce.data?.eventInLaneId ?? "", responseWithForce.data?.eventInFileKeys,
                                                        responseWithForce.data?.DatetimeIn ?? DateTime.Now, false, responseWithForce.data?.charge ?? 0).ShowDialog()
                                                           == DialogResult.OK;
                        if (!isConfirm)
                        {
                            lblResult.UpdateResultMessage("Không xác nhận mở barrie", Color.DarkOrange);
                            return;
                        }
                        else
                        {
                            ControllerInLane? controllerInLane = (from _controllerInLane in this.lane.controlUnits
                                                                  where _controllerInLane.controlUnitId == ie.DeviceId
                                                                  select _controllerInLane).FirstOrDefault();
                            await BaseLane.OpenBarrieByControllerId(ie.DeviceId, controllerInLane);
                            KzParkingApiHelper.CommitOutAsync(responseWithForce.data);
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
                if (eventOut.RegisteredVehicle != null)
                {
                    plate = eventOut.RegisteredVehicle.PlateNumber;
                }
                await ExcecuteValidEvent(null, null, vehicleType, plate, ie.EventTime, overviewImage, vehicleImg,
                                         lprImage, imageKey, eventOut, eventOut.RegisteredVehicle);
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
            if (lastEvent == null || (DateTime.Now - lastEvent.DatetimeOut)?.TotalSeconds >= StaticPool.appOption.AllowBarrieDelayOpenTime)
            {
                string imageKey = BaseLane.GetBaseImageKey(this.lane.name, "", "", ie.EventTime);
                await KzParkingApiHelper.CreateAlarmAsync("", this.lane.id, "", AbnormalCode.OpenBarrierByButton, imageKey, false);
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

        private async Task ExcecuteNonMonthCardEventOut(Identity identity, IdentityGroup identityGroup, VehicleType vehicleType, string plateNumber, List<string> imageKeys, CardEventArgs ce, ControllerInLane? controllerInLane, Image? overviewImg, Image? vehicleImg, Image? lprImage, string imageKey)
        {
            string errorMessage = string.Empty;
            AddEventOutResponse? eventOut = null;

            var responseNormal = await KzParkingApiHelper.PostCheckOutAsync(lane.id, plateNumber, identity, imageKeys, false);
            if (responseNormal == null)
            {
                goto LOI_HE_THONG;
            }
            if (responseNormal.metadata.success == false)
            {
                var errorCode = ApiInternalErrorMessages.GetFromName(responseNormal.metadata.message.code);
                if (errorCode == EmApiErrorMessage.PINT_1013 || errorCode == EmApiErrorMessage.PINT_1018)
                {
                    string message = ApiInternalErrorMessages.ToString(errorCode);
                    bool isConfirm = new frmConfirmOut(message, responseNormal.data?.plateNumber ?? "", responseNormal.data?.identityId ?? "", responseNormal.data?.laneId ?? "", responseNormal.data?.fileKeys, responseNormal.data?.DatetimeOut ?? DateTime.Now).ShowDialog()
                                            == DialogResult.OK;
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
                else
                {
                    errorMessage = ApiInternalErrorMessages.ToString(errorCode);
                    goto SU_KIEN_LOI;
                }
            }
            else
            {
                eventOut = responseNormal.data;
                if (eventOut.OpenBarrier)
                {
                    await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane);
                    KzParkingApiHelper.CommitOutAsync(eventOut);
                }
                else
                {
                    bool isConfirm = new frmConfirmOut("Bạn có xác nhận mở barrie?", responseNormal.data?.eventInPlateNumber ?? "", responseNormal.data?.eventInIdentityId ?? "", responseNormal.data?.eventInLaneId ?? "", responseNormal.data?.eventInFileKeys, responseNormal.data?.DatetimeIn ?? DateTime.Now, false, responseNormal.data?.charge ?? 0).ShowDialog()
                                                       == DialogResult.OK;
                    if (!isConfirm)
                    {
                        lblResult.UpdateResultMessage("Không xác nhận mở barrie", Color.DarkOrange);
                        return;
                    }
                    else
                    {
                        await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane);
                        KzParkingApiHelper.CommitOutAsync(responseNormal.data);
                    }
                }
                goto SU_KIEN_HOP_LE;
            }
        CheckOutWithForce:
            {
                var responseWithForce = await KzParkingApiHelper.PostCheckOutAsync(lane.id,
                                                         ce.PlateNumber, identity, imageKeys, true);
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
                    eventOut = responseWithForce.data;
                    if (eventOut.OpenBarrier)
                    {
                        await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane);
                        KzParkingApiHelper.CommitOutAsync(responseWithForce.data);
                    }
                    else
                    {
                        bool isConfirm = new frmConfirmOut("Bạn có xác nhận mở barrie?",
                                                        responseWithForce.data?.eventInPlateNumber ?? "", responseWithForce.data?.eventInIdentityId ?? "", responseWithForce.data?.eventInLaneId ?? "", responseWithForce.data?.eventInFileKeys,
                                                        responseWithForce.data?.DatetimeIn ?? DateTime.Now, false, responseWithForce.data?.charge ?? 0).ShowDialog()
                                                           == DialogResult.OK;
                        if (!isConfirm)
                        {
                            lblResult.UpdateResultMessage("Không xác nhận mở barrie", Color.DarkOrange);
                            return;
                        }
                        else
                        {
                            await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane);
                            KzParkingApiHelper.CommitOutAsync(responseWithForce.data);
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
                if (eventOut.RegisteredVehicle != null)
                {
                    await ExcecuteValidEvent(identity, identityGroup, vehicleType,
                        eventOut.RegisteredVehicle.PlateNumber, ce.EventTime,
                        overviewImg, vehicleImg, lprImage, imageKey, eventOut, eventOut.RegisteredVehicle);
                }
                else
                    await ExcecuteValidEvent(identity, identityGroup, vehicleType, ce.PlateNumber,
                                             ce.EventTime, overviewImg, vehicleImg, lprImage, imageKey,
                                             eventOut, eventOut.RegisteredVehicle);
                return;
            }
        }

        private async Task ExcecuteMonthCardEventOut(Identity identity, IdentityGroup identityGroup, VehicleType vehicleType, string plateNumber, List<string> imageKeys, CardEventArgs ce, ControllerInLane? controllerInLane, Image? overviewImg, Image? vehicleImg, Image? lprImage, string imageKey)
        {
            AddEventOutResponse? eventOut = null;
            string errorMessage = string.Empty;
            if (string.IsNullOrEmpty(plateNumber))
            {
                bool isConfirm = MessageBox.Show("Không nhận diện được biển số, bạn có muốn cho xe ra khỏi bãi?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes;
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
            else
            {
                goto CheckOutNormal;
            }

        CheckOutWithForce:
            {
                var responseWithForce = await KzParkingApiHelper.PostCheckOutAsync(lane.id,
                                                         ce.PlateNumber, identity, imageKeys, true);
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
                    eventOut = responseWithForce.data;
                    if (eventOut.OpenBarrier)
                    {
                        await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane);
                        KzParkingApiHelper.CommitOutAsync(eventOut);
                    }
                    else
                    {
                        bool isConfirm = new frmConfirmOut("Bạn có xác nhận mở barrie?",
                                                        responseWithForce.data?.eventInPlateNumber ?? "", responseWithForce.data?.eventInIdentityId ?? "", responseWithForce.data?.eventInLaneId ?? "", responseWithForce.data?.eventInFileKeys,
                                                        responseWithForce.data?.DatetimeIn ?? DateTime.Now, false, responseWithForce.data?.charge ?? 0).ShowDialog()
                                                           == DialogResult.OK;
                        if (!isConfirm)
                        {
                            lblResult.UpdateResultMessage("Không xác nhận mở barrie", Color.DarkOrange);
                            return;
                        }
                        else
                        {
                            await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane);
                        }
                    }
                    goto SU_KIEN_HOP_LE;
                }
            }

        CheckOutNormal:
            {
                var responseNormal = await KzParkingApiHelper.PostCheckOutAsync(lane.id,
                                                        ce.PlateNumber, identity, imageKeys, false);
                if (responseNormal == null)
                {
                    goto LOI_HE_THONG;
                }
                if (responseNormal.metadata.success == false)
                {
                    var errorCode = ApiInternalErrorMessages.GetFromName(responseNormal.metadata.message.code);
                    if (errorCode == EmApiErrorMessage.PINT_1013 || errorCode == EmApiErrorMessage.PINT_1018)
                    {
                        bool isConfirm = new frmConfirmOut(ApiInternalErrorMessages.ToString(errorCode), responseNormal.data?.plateNumber, responseNormal.data?.identityId, responseNormal.data?.laneId, responseNormal.data?.fileKeys, responseNormal.data?.DatetimeOut ?? null).ShowDialog()
                                                 == DialogResult.OK;
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
                    else
                    {
                        errorMessage = ApiInternalErrorMessages.ToString(errorCode);
                        goto SU_KIEN_LOI;
                    }
                }
                else
                {
                    eventOut = responseNormal.data;
                    if (eventOut.OpenBarrier)
                    {
                        await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane);
                        KzParkingApiHelper.CommitOutAsync(responseNormal.data);
                    }
                    else
                    {
                        bool isConfirm = new frmConfirmOut("Bạn có xác nhận mở barrie?",
                                                        responseNormal.data?.eventInPlateNumber ?? "", responseNormal.data?.eventInIdentityId ?? "", responseNormal.data?.eventInLaneId ?? "", responseNormal.data?.eventInFileKeys,
                                                        responseNormal.data?.DatetimeIn ?? DateTime.Now, false, responseNormal.data?.charge ?? 0).ShowDialog()
                                                           == DialogResult.OK;
                        if (!isConfirm)
                        {
                            lblResult.UpdateResultMessage("Không xác nhận mở barrie", Color.DarkOrange);
                            return;
                        }
                        else
                        {
                            await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane);
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
                if (eventOut.RegisteredVehicle != null)
                {
                    await ExcecuteValidEvent(identity, identityGroup, vehicleType, eventOut.RegisteredVehicle.PlateNumber,
                                             ce.EventTime, overviewImg, vehicleImg, lprImage, imageKey, eventOut, eventOut.RegisteredVehicle);
                }
                else
                {
                    await ExcecuteValidEvent(identity, identityGroup, vehicleType, ce.PlateNumber, ce.EventTime,
                                             overviewImg, vehicleImg, lprImage, imageKey, eventOut, eventOut.RegisteredVehicle);
                }
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
            DisplayEventOutInfo(eventOut?.DatetimeIn, eventTime, plate, identity, null, vehicleType, eventOut?.RegisteredVehicle, (long)(eventOut?.charge ?? 0), eventOut?.Customer);
        }

        private async Task ExcecuteValidEvent(Identity identity, IdentityGroup identityGroup, VehicleType vehicleType,
                                              string detectedPlate, DateTime eventTime, Image? overviewImg, Image? vehicleImg,
                                              Image? lprImage, string imageKey, AddEventOutResponse? eventOut,
                                              RegisteredVehicle? registeredVehicle)
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
            DisplayEventOutInfo(eventOut?.DatetimeIn, eventTime, detectedPlate, identity, identityGroup, vehicleType, eventOut?.RegisteredVehicle, (long)(eventOut?.charge ?? 0), eventOut?.Customer);
            ShowEventInData(eventOut);
            BaseLane.DisplayLed(detectedPlate, eventTime, identity, identityGroup, "Hẹn gặp lại", this.lane.id);
            await BaseLane.SaveEventImage(overviewImg, vehicleImg, lprImage, imageKey, false);

            lastEvent = new EventOut()
            {
                Id = eventOut!.Id,
                CreatedUtc = eventTime.AddHours(-7).ToString("yyyy-MM-ddTHH:mm:ss:ffff"),
                PlateNumber = detectedPlate,
                Identity = null,
                LaneId = this.lane.id,
            };
            UnregisterTurnVehicle(identity, registeredVehicle, identityGroup);
        }

        public async void OnKeyPress(Keys keys)
        {
            await semaphoreSlimOnKeyPress.WaitAsync();
            try
            {
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
                                var isUpdateSuccess = await KzParkingApiHelper.UpdateEventOutPlate(lastEvent.Id, newPlate);
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
                    else if ((int)keys == laneOutShortcutConfig.ReserveLane)
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
                            //Chưa cấu hình làn đảo
                            lblResult.UpdateResultMessage("Chưa có cấu hình làn đảo", Color.DarkBlue);
                        }
                    }
                    else if ((int)keys == laneOutShortcutConfig.WriteOut)
                    {
                        lblResult.UpdateResultMessage("Ra lệnh ghi vé ra", Color.DarkBlue);
                        btnWriteOut?.Invoke(new Action(() =>
                        {
                            btnWriteOut.PerformClick();
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
            catch (Exception exx)
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
            if (lastEvent == null || (DateTime.Now - lastEvent.DatetimeOut)?.TotalSeconds >= StaticPool.appOption.AllowBarrieDelayOpenTime)
            {
                string imageKey = BaseLane.GetBaseImageKey(this.lane.name, "", "", DateTime.Now);
                await KzParkingApiHelper.CreateAlarmAsync("", this.lane.id, "", AbnormalCode.OpenBarrierByKeyboard, imageKey, false);
                await SaveAllCameraImage(imageKey);
            }
        }
        #endregion END EVENT

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
                        string _camType = cameras[key][i].GetCameraType() == "HIK" ? "HIKVISION" : cameras[key][i].GetCameraType();
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

        private void DisplayEventOutInfo(DateTime? timeIn, DateTime timeOut, string plateNumber, Identity identity, IdentityGroup? identityGroup, VehicleType vehicle, RegisteredVehicle? registerVehicle, long fee, Customer? customer)
        {
            //dgvEventContent.Invoke(new Action(() =>
            //{
            //    dgvEventContent.Rows.Clear();
            //    dgvEventContent.Rows.Add("Mã", identity?.Code);
            //    dgvEventContent.Rows.Add("Biển Số Xe", plateNumber);
            //    if (!string.IsNullOrEmpty(registerPlate))
            //    {
            //        dgvEventContent.Rows.Add("Biển Số Đăng Ký", registerPlate);
            //    }
            //    if (timeIn != null)
            //    {
            //        dgvEventContent.Rows.Add("Thời Gian Vào", timeIn?.ToString("dd/MM/yyyy HH:mm:ss"));
            //    }
            //    dgvEventContent.Rows.Add("Thời Gian Ra", timeOut.ToString("dd/MM/yyyy HH:mm:ss"));
            //    if (identity != null)
            //    {
            //        switch (identity.Type)
            //        {
            //            case IdentityType.Card:
            //                dgvEventContent.Rows.Add("Hình Thức", "Quẹt thẻ");
            //                break;
            //            case IdentityType.QrCode:
            //                dgvEventContent.Rows.Add("Hình Thức", "QR Code");
            //                break;
            //            case IdentityType.FingerPrint:
            //                dgvEventContent.Rows.Add("Hình Thức", "Vân tay");
            //                break;
            //            case IdentityType.FaceId:
            //                dgvEventContent.Rows.Add("Hình Thức", "Gương mặt");
            //                break;
            //            default:
            //                break;
            //        }
            //    }
            //    dgvEventContent.Rows.Add("Nhóm", identity?.IdentityGroup.Name);
            //    if (vehicle != null)
            //    {
            //        dgvEventContent.Rows.Add("Loại Phương Tiện", VehicleType.GetDisplayStr(vehicle.Type));
            //    }
            //}));
            LaneDirectionConfig laneDirection = NewtonSoftHelper<LaneDirectionConfig>.DeserializeObjectFromPath(
                                                      PathManagement.appLaneDirectionConfigPath(this.lane.id)) ?? LaneDirectionConfig.CreateDefault();
            dgvEventContent?.Invoke(new Action(() =>
            {
                dgvEventContent.Columns[0].Visible = laneDirection.IsDisplayTitle;
            }));
            dgvEventContent.Invoke(new Action(() =>
            {
                dgvEventContent.Rows.Clear();
                dgvEventContent.Rows.Add("Phí gửi xe", TextFormatingTool.GetMoneyFormat(fee.ToString()));
                dgvEventContent.Rows[dgvEventContent.RowCount - 1].DefaultCellStyle.Font = new Font(dgvEventContent.DefaultCellStyle.Font.Name, dgvEventContent.DefaultCellStyle.Font.Size * 2);
                dgvEventContent.Rows[dgvEventContent.RowCount - 1].DefaultCellStyle.ForeColor = Color.Red;
                dgvEventContent.Rows.Add("Mã định danh", identity?.Code);
                dgvEventContent.Rows.Add("Biển số nhận diện", plateNumber);

                if (customer != null)
                {
                    dgvEventContent.Rows.Add("Khách hàng", customer.Name + " / " + customer.Address);
                }
                if (registerVehicle != null)
                {
                    dgvEventContent.Rows.Add("Biển số đăng ký", registerVehicle.Name + " / " + registerVehicle.PlateNumber);
                }
                if (timeIn != null)
                {
                    dgvEventContent.Rows.Add("Thời gian vào", timeIn?.ToString("dd/MM/yyyy HH:mm:ss"));
                }

                dgvEventContent.Rows.Add("Thời gian ra", timeOut.ToString("dd/MM/yyyy HH:mm:ss"));
                if (vehicle != null)
                {
                    dgvEventContent.Rows.Add("Loại phương tiện", VehicleType.GetDisplayStr(vehicle.Type));
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
                dgvEventContent.Rows.Add("Nhóm định danh", identityGroup?.Name);

            }));


        }
        //--PRINT
        private string GetPrintContent(string baseContent)
        {
            return string.Empty;
        }
        private void WbPrint_DocumentCompleted(object? sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                var browser = (WebBrowser)sender!;
                browser.Print();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

            var task1 = MinioHelper.UploadPicture(overviewImg, imageKey + "_OVERVIEWOUT.jpeg");
            if (carVehicleImage != null)
            {
                var task2 = MinioHelper.UploadPicture(carVehicleImage, imageKey + "_VEHICLEOUT.jpeg");
                await Task.WhenAll(task1, task2);
            }
            else
            {
                var task3 = MinioHelper.UploadPicture(motorVehicleImage, imageKey + "_VEHICLEOUT.jpeg");
                await Task.WhenAll(task1, task3);
            }
        }
        #endregion
        private async Task ShowEventInData(AddEventOutResponse eventOut)
        {
            //Lấy thông tin hình ảnh vào
            if (eventOut.eventInFileKeys != null)
            {
                _ = Task.Run(() =>
                {
                    this.Invoke(new Action(async () =>
                    {
                        if (eventOut.eventInFileKeys.Count >= 2)
                        {
                            string displayOverviewInPath = await MinioHelper.GetImage(eventOut.eventInFileKeys[0]);
                            string vehicleInPath = await MinioHelper.GetImage(eventOut.eventInFileKeys[1]);
                            try
                            {
                                picOverviewImageIn.LoadAsync(displayOverviewInPath);
                            }
                            catch (Exception)
                            {
                            }
                            try
                            {
                                picVehicleImageIn.LoadAsync(vehicleInPath);
                            }
                            catch (Exception)
                            {
                            }
                        }
                        else if (eventOut.eventInFileKeys.Count > 0)
                        {
                            try
                            {
                                string displayOverviewInPath = await MinioHelper.GetImage(eventOut.eventInFileKeys[0]);
                                picOverviewImageIn.LoadAsync(displayOverviewInPath);
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }));
                });
            }

        }

        private void ClearView()
        {
            this.Invoke(new Action(() =>
            {
                dgvEventContent.Rows.Clear();
                dgvEventContent.Refresh();

                picOverviewImageIn.Image = null;
                picOverviewImageIn.Refresh();

                picVehicleImageIn.Image = null;
                picVehicleImageIn.Refresh();

                picLprImage.Image = null;
                picLprImage.Refresh();

                picOverviewImageOut.Image = null;
                picOverviewImageOut.Refresh();

                picVehicleImageOut.Image = null;
                picVehicleImageOut.Refresh();

                txtPlate.Text = string.Empty;
                txtPlate.Refresh();

                lblResult.Text = "";
                lblResult.Refresh();
            }));
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

        public async void UnregisterTurnVehicle(Identity? identity, RegisteredVehicle? vehicle, IdentityGroup identityGroup)
        {
            if (identity == null || vehicle == null || identityGroup == null)
            {
                return;
            }
            if (identityGroup != null)
            {
                if (identityGroup.Type == IdentityGroupType.Daily)
                {
                    if (vehicle == null)
                    {
                        return;
                    }
                    if (vehicle.IdentityIds != null)
                    {
                        vehicle.IdentityIds.Remove(identity?.Id ?? "");
                    }
                    await KzParkingApiHelper.UpdateRegisteredVehicleAsyncById(vehicle);
                }
            }
        }

        private void panelAction_SizeChanged(object sender, EventArgs e)
        {
            panelAction.Height = panelAction.HorizontalScroll.Visible ? 20 + 48 : 48;
        }
    }
}