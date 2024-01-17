using IPaking.Ultility;
using iParkingv5.Controller;
using iParkingv5.LprDetecter.Objects;
using iParkingv5.Objects;
using iParkingv5.Objects.Configs;
using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Enums;
using iParkingv5.Objects.EventDatas;
using iParkingv5.Objects.Events;
using iParkingv5_window.Forms.DataForms;
using iParkingv6.ApiManager.KzParkingv3Apis;
using iParkingv6.Objects.Datas;
using Kztek.Tool;
using Kztek.Tools;
using static iParkingv5.Objects.Enums.VehicleType;

namespace iParkingv5_window.Usercontrols
{
    public partial class ucLaneOut : UserControl, iLane
    {
        #region PROPERTIES
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
        EventOut? lastEvent = null;

        private Image? LoopVehicleImage = null;
        private Image? LoopLprImage = null;

        private readonly SemaphoreSlim semaphoreSlimOnNewEvent = new SemaphoreSlim(1, 1);
        private readonly SemaphoreSlim semaphoreSlimOnKeyPress = new SemaphoreSlim(1, 1);
        public List<CardEventArgs> lastCardEventDatas { get; set; } = new List<CardEventArgs>();
        public List<InputEventArgs> lastInputEventDatas { get; set; } = new List<InputEventArgs>();
        #endregion 
        #endregion END PROPERTIES

        #region FORMS
        public ucLaneOut(Lane lane, LaneDisplayConfig? laneDisplayConfig)
        {
            InitializeComponent();

            lblLaneName.Text = lane.name;
            lblLaneName.BackColor = Color.DarkRed;
            this.lane = lane;

            panelCameras.Dock = DockStyle.Right;
            SplitterCamera.Dock = DockStyle.Right;

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

            this.SizeChanged += UcLaneOut_SizeChanged;
            panelCameras.SizeChanged += PanelCameras_SizeChanged;
        }

        private void UcLaneOut_SizeChanged(object? sender, EventArgs e)
        {
            lblResult.MaximumSize = new Size(this.DisplayRectangle.Width, 0);
            lblResult.MinimumSize = new Size(this.DisplayRectangle.Width, 0);
            lblResult.Height = lblResult.PreferredHeight;
        }
        #endregion END FORMS

        #region CONTROLS IN FORM
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
                item.Width = panelCameras.Width;
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

        /// <summary>
        /// Ghi vé ra=> Chọn vé cần ghi ==> Kích hoạt sự kiện như sự kiện quẹt thẻ
        /// Lưu sự kiện cảnh báo MANUAL EVENT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnWriteOut_Click(object sender, EventArgs e)
        {
            frmSelectCard frmSelectCard = new("Chọn thẻ ghi vé ra");
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
                    PreferCard = frmSelectCard.SelectIdentity,
                };

                await OnNewEvent(ce);
                //Lưu sự kiện cảnh báo
                string imageKey = BaseLane.GetBaseImageKey(this.lane.name, ce.PreferCard, ce.PlateNumber, ce.EventTime);
                await KzParkingApiHelper.CreateAlarmAsync(frmSelectCard.SelectIdentityId, this.lane.id, ce.PlateNumber, AbnormalCode.ManualEvent, imageKey, false); ;
                return;
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
        }
        private void picSetting_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            picSetting.BackColor = Color.Green;
        }
        private void picSetting_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            picSetting.BackColor = Color.Red;
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
            if (this.laneDisplayConfig == null)
            {
                return;
            }
            this.splitContainerMain.SplitterDistance = this.laneDisplayConfig.splitContainerMain;
            this.splitContainerMain.Refresh();

            this.splitContainerEventContent.SplitterDistance = this.laneDisplayConfig.splitContainerEventContent;
            this.splitContainerEventContent.Refresh();

            this.SplitterCamera.SplitPosition = this.laneDisplayConfig.SplitterCameraPosition;
            this.SplitterCamera.Refresh();
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
                SplitterCameraPosition = this.SplitterCamera.SplitPosition,
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
            plate = "30G - 39582";
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

            List<string> imageKeys = new List<string>()
             {
                     imageKey + "_OVERVIEWOUT.jpeg",
                     imageKey + "_VEHICLEOUT.jpeg",
                     imageKey + "_LPROUT.jpeg",
             };
            AddEventOutResponse eventOut = await KzParkingApiHelper.PostCheckOutAsync(lane.id,
            plate,
             null,
             imageKeys, false);
            if (eventOut == null)
            {
                goto LOI_HE_THONG;
            }
            //Kiểm tra mở barrie
            if (eventOut.OpenBarrier)
            {
                goto SU_KIEN_HOP_LE;
            }
            else
            {
                switch ((AbnormalCode?)eventOut.AbnormalCode)
                {
                    case null:
                        goto SU_KIEN_CANH_BAO;
                    case AbnormalCode.InvalidPlateNumber:
                        {
                            //Xác nhận cho xe ra bãi
                            frmConfirm frm = new(eventOut.ErrorMessage, false)
                            {
                                AutoSize = true,
                                StartPosition = FormStartPosition.Manual
                            };
                            int x = this.Location.X + (Width - frm.Width) / 2;
                            int y = 60 + (this.Height - frm.Height) / 2;
                            frm.Location = new Point(x, y);
                            bool isConfirm = frm.ShowDialog() == DialogResult.Yes;
                            if (isConfirm)
                            {
                                eventOut = await KzParkingApiHelper.PostCheckOutAsync(this.lane.id,
                                              plate, null,
                                              imageKeys, true);
                                if (eventOut == null)
                                {
                                    goto LOI_HE_THONG;
                                }
                                if (!eventOut.OpenBarrier)
                                {
                                    goto SU_KIEN_LOI;
                                }
                                else
                                {
                                    goto SU_KIEN_HOP_LE;
                                }
                            }
                            else
                            {
                                goto SU_KIEN_LOI;
                            }
                        }
                    default:
                        goto SU_KIEN_LOI;
                }
            }

        LOI_HE_THONG:
            {
                lblResult.UpdateResultMessage("Không gửi được thông tin xe ra lên hệ thống, vui lòng thử lại sau giây lát", Color.DarkRed);
                return;
            }
        SU_KIEN_LOI:
            {
                lblResult.UpdateResultMessage(eventOut.ErrorMessage, Color.DarkRed);
                DisplayEventOutInfo(eventOut?.DatetimeIn, ie.EventTime, plate, eventOut.Identity, registeredVehicle.VehicleType, eventOut?.RegisteredVehicle?.PlateNumber);
                return;
            }
        SU_KIEN_CANH_BAO:
            {
                lblResult.UpdateResultMessage(eventOut.ErrorMessage, Color.DarkOrange);
                DisplayEventOutInfo(eventOut?.DatetimeIn, ie.EventTime, plate, eventOut.Identity, registeredVehicle.VehicleType, eventOut?.RegisteredVehicle?.PlateNumber);
                BaseLane.DisplayLed(plate, ie.EventTime, eventOut.Identity, eventOut.Identity?.IdentityGroup, "Hẹn gặp lại", this.lane.id);
                await BaseLane.SaveEventImage(overviewImage, vehicleImg, lprImage, imageKey, false);
                lastEvent = new EventOut()
                {
                    Id = eventOut.Id,
                    CreatedUtc = ie.EventTime.AddHours(-7).ToString("dd/MM/yyyy HH:mm:ss"),
                    PlateNumber = plate,
                    Identity = null,
                    LaneId = this.lane.id,
                };
                return;
            }
        SU_KIEN_HOP_LE:
            {
                lblResult.UpdateResultMessage("Hẹn Gặp Lại", Color.DarkGreen);
                ControllerInLane? controllerInLane = (from _controllerInLane in this.lane.controlUnits
                                                      where _controllerInLane.controlUnitId == ie.DeviceId
                                                      select _controllerInLane).FirstOrDefault();
                if (controllerInLane != null)
                {
                    await BaseLane.OpenBarrieByControllerId(ie.DeviceId, controllerInLane);
                }
                DisplayEventOutInfo(eventOut?.DatetimeIn, ie.EventTime, plate, eventOut.Identity, registeredVehicle.VehicleType, eventOut?.RegisteredVehicle?.PlateNumber);
                ShowEventInData(eventOut);
                BaseLane.DisplayLed(plate, ie.EventTime, eventOut.Identity, eventOut.Identity?.IdentityGroup, "Hẹn gặp lại", this.lane.id);
                await BaseLane.SaveEventImage(overviewImage, vehicleImg, lprImage, imageKey, false);
                lastEvent = new EventOut()
                {
                    Id = eventOut.Id,
                    CreatedUtc = ie.EventTime.AddHours(-7).ToString("dd/MM/yyyy HH:mm:ss"),
                    PlateNumber = plate,
                    Identity = null,
                    LaneId = this.lane.id,
                };
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
            if (lastEvent == null || (DateTime.Now - lastEvent.DatetimeOut)?.TotalSeconds >= 5)
            {
                string imageKey = BaseLane.GetBaseImageKey(this.lane.name, "", "", ie.EventTime);
                await KzParkingApiHelper.CreateAlarmAsync("", this.lane.id, "", AbnormalCode.OpenBarrierByButton, imageKey, false); ;
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
            List<string> images = new List<string>()
                 {
                     imageKey + "_OVERVIEWOUT.jpeg",
                     imageKey + "_VEHICLEOUT.jpeg",
                     imageKey + "_LPROUT.jpeg",
                 };
            AddEventOutResponse eventOut = await KzParkingApiHelper.PostCheckOutAsync(lane.id,
                 ce.PlateNumber,
                 identity,
                 images, false);
            if (eventOut == null)
            {
                goto LOI_HE_THONG;
            }

            //Kiểm tra mở barrie
            if (eventOut.OpenBarrier)
            {
                goto SU_KIEN_HOP_LE;
            }
            else
            {
                switch ((AbnormalCode)eventOut.AbnormalCode)
                {
                    case AbnormalCode.InvalidPlateNumber:
                        {
                            //Xác nhận cho xe ra bãi
                            frmConfirm frm = new(eventOut.ErrorMessage, false)
                            {
                                AutoSize = true,
                                StartPosition = FormStartPosition.Manual
                            };
                            int x = this.Location.X + (Width - frm.Width) / 2;
                            int y = 60 + (this.Height - frm.Height) / 2;
                            frm.Location = new Point(x, y);
                            bool isConfirm = frm.ShowDialog() == DialogResult.Yes;
                            if (!isConfirm)
                            {
                                goto SU_KIEN_LOI;
                            }
                            else
                            {
                                eventOut = await KzParkingApiHelper.PostCheckOutAsync(this.lane.id,
                                             ce.PlateNumber,
                                             identity,
                                             images, true);
                                if (eventOut == null)
                                {
                                    goto LOI_HE_THONG;
                                }
                                if (!eventOut.OpenBarrier)
                                {
                                    goto SU_KIEN_LOI;
                                }
                                else
                                {
                                    goto SU_KIEN_HOP_LE;
                                }
                            }
                        }

                    default:
                        goto SU_KIEN_LOI;
                }
            }

        LOI_HE_THONG:
            {
                lblResult.UpdateResultMessage("Không gửi được thông tin xe ra lên hệ thống, vui lòng thử lại sau giây lát", Color.DarkRed);
                return;
            }
        SU_KIEN_LOI:
            {
                lblResult.UpdateResultMessage(eventOut.ErrorMessage, Color.DarkRed);
                DisplayEventOutInfo(eventOut?.DatetimeIn, ce.EventTime, ce.PlateNumber, identity, vehicleType, eventOut?.RegisteredVehicle?.PlateNumber);
                return;
            }
        SU_KIEN_HOP_LE:
            {
                lblResult.UpdateResultMessage("Hẹn Gặp Lại", Color.DarkGreen);

                await BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane);
                DisplayEventOutInfo(eventOut?.DatetimeIn, ce.EventTime, ce.PlateNumber, identity, vehicleType, eventOut?.RegisteredVehicle?.PlateNumber);
                ShowEventInData(eventOut);
                BaseLane.DisplayLed(ce.PlateNumber, ce.EventTime, identity, identityGroup, "Hẹn gặp lại", this.lane.id);
                await BaseLane.SaveEventImage(overviewImg, vehicleImg, lprImage, imageKey, false);

                lastEvent = new EventOut()
                {
                    Id = eventOut!.Id,
                    CreatedUtc = ce.EventTime.AddHours(-7).ToString("dd/MM/yyyy HH:mm:ss"),
                    PlateNumber = ce.PlateNumber,
                    Identity = null,
                    LaneId = this.lane.id,
                };
            }
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
                                var updatePlateInResponse = await KzParkingApiHelper.UpdateEventOutPlate(lastEvent.Id, newPlate);
                                if (updatePlateInResponse.Item1)
                                {
                                    lblResult.UpdateResultMessage("Ra Lệnh Cập Nhật Biển Số Thành Công", Color.DarkBlue);
                                }
                                else
                                {
                                    lblResult.UpdateResultMessage(updatePlateInResponse.Item2, Color.DarkBlue);
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
                                    if (controller.ControllerInfo.id.ToLower() == controllerId.ToLower())
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
            if (lastEvent == null || (DateTime.Now - lastEvent.DatetimeOut)?.TotalSeconds >= 5)
            {
                string imageKey = BaseLane.GetBaseImageKey(this.lane.name, "", "", DateTime.Now);
                await KzParkingApiHelper.CreateAlarmAsync("", this.lane.id, "", AbnormalCode.OpenBarrierByKeyboard, imageKey, false); ;
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
                    if (cam.id.ToLower() == cameraInLane.cameraId)
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
                        cam_du_phong.ID = cameras[key][i].id;
                        cam_du_phong.Name = cameras[key][i].name;
                        cam_du_phong.VideoSource = cameras[key][i].ipAddress;
                        cam_du_phong.HttpPort = int.Parse(cameras[key][i].httpPort);
                        cam_du_phong.Login = cameras[key][i].username;
                        cam_du_phong.Password = cameras[key][i].password;
                        cam_du_phong.Chanel = cameras[key][i].channel;
                        string _camType = cameras[key][i].GetCameraType() == "HIK" ? "HIKVISION" : cameras[key][i].GetCameraType();
                        cam_du_phong.CameraType = Kztek.Cameras.CameraTypes.GetType(_camType);
                        cam_du_phong.StreamType = Kztek.Cameras.StreamTypes.GetType("H264");
                        cam_du_phong.Resolution = string.IsNullOrEmpty(cameras[key][0].resolution) ? "1280x720" : cameras[key][i].resolution;
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
                cam.ID = cameras[key][0].id;
                cam.Name = cameras[key][0].name;
                cam.VideoSource = cameras[key][0].ipAddress;
                cam.HttpPort = int.Parse(cameras[key][0].httpPort);
                cam.Login = cameras[key][0].username;
                cam.Password = cameras[key][0].password;
                cam.Chanel = cameras[key][0].channel;
                string camType = cameras[key][0].GetCameraType() == "HIK" ? "HIKVISION2" : cameras[key][0].GetCameraType();
                cam.CameraType = Kztek.Cameras.CameraTypes.GetType(camType);
                cam.StreamType = Kztek.Cameras.StreamTypes.GetType("H264");
                cam.Resolution = string.IsNullOrEmpty(cameras[key][0].resolution) ? "1280x720" : cameras[key][0].resolution;
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
            string plate = StaticPool.LprDetect.GetPlateNumber(vehicleImg, true, null, out lprImage);
            if (string.IsNullOrEmpty(plate))
            {
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

        private void DisplayEventOutInfo(DateTime? timeIn, DateTime timeOut, string plateNumber, Identity identity, VehicleType vehicle, string? registerPlate)
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
            dgvEventContent.Invoke(new Action(() =>
            {
                dgvEventContent.Rows.Clear();
                dgvEventContent.Rows.Add("", identity?.Code);
                dgvEventContent.Rows.Add("", plateNumber);
                if (!string.IsNullOrEmpty(registerPlate))
                {
                    dgvEventContent.Rows.Add("", registerPlate);
                }
                if (timeIn != null)
                {
                    dgvEventContent.Rows.Add("", timeIn?.ToString("dd/MM/yyyy HH:mm:ss"));
                }
                dgvEventContent.Rows.Add("", timeOut.ToString("dd/MM/yyyy HH:mm:ss"));
                if (identity != null)
                {
                    switch (identity.Type)
                    {
                        case IdentityType.Card:
                            dgvEventContent.Rows.Add("", "Quẹt thẻ");
                            break;
                        case IdentityType.QrCode:
                            dgvEventContent.Rows.Add("", "QR Code");
                            break;
                        case IdentityType.FingerPrint:
                            dgvEventContent.Rows.Add("", "Vân tay");
                            break;
                        case IdentityType.FaceId:
                            dgvEventContent.Rows.Add("", "Gương mặt");
                            break;
                        default:
                            break;
                    }
                }
                dgvEventContent.Rows.Add("", identity?.IdentityGroup.Name);
                if (vehicle != null)
                {
                    dgvEventContent.Rows.Add("", VehicleType.GetDisplayStr(vehicle.Type));
                }
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
            var task2 = MinioHelper.UploadPicture(carVehicleImage, imageKey + "_CAROUT.jpeg");
            var task3 = MinioHelper.UploadPicture(motorVehicleImage, imageKey + "_MOTOROUT.jpeg");
            await Task.WhenAll(task1, task2, task3);
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
            }));
        }
    }
}