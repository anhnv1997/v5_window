using IPaking.Ultility;
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
using iParkingv5.Objects.warehouse;
using iParkingv5_CustomerRegister.Forms;
using iParkingv5_window.Forms.DataForms;
using iParkingv5_window.Forms.ReportForms;
using iParkingv5_window.Helpers;
using Kztek.Tool;
using Kztek.Tool.TextFormatingTools;
using Kztek.Tools;
using System.Data;
using System.Windows.Forms;
using v5_IScale.Forms;
using static iParkingv5.Objects.Configs.LaneDirectionConfig;
using static iParkingv5.Objects.Enums.LaneDisplayMode;
using static iParkingv5.Objects.Enums.PrintHelpers;
using static iParkingv5.Objects.Enums.VehicleType;

namespace iParkingv5_window.Usercontrols
{
    public partial class ucLaneIn : UserControl, iLane, IDisposable
    {
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
                        lblScaleInfo.Text = scaleValue.ToString();
                    }));
                }
                catch (Exception)
                {

                }
            }
        }

        #region PROPERTIES
        public event OnControlSizeChanged onControlSizeChangeEvent;

        #region -- Data
        public Lane lane { get; set; }
        private Dictionary<CameraPurposeType.EmCameraPurposeType, List<Camera>> cameras = new Dictionary<CameraPurposeType.EmCameraPurposeType, List<Camera>>();
        private List<Kztek.Cameras.Camera> camBienSoXeMayDuPhongs = new List<Kztek.Cameras.Camera>();
        private List<Kztek.Cameras.Camera> camBienSoOTODuPhongs = new List<Kztek.Cameras.Camera>();
        private List<Kztek.Cameras.Camera> OtherCams = new List<Kztek.Cameras.Camera>();
        public EmLaneDisplayMode displayMode { get; set; } = EmLaneDisplayMode.Horizontal;
        #endregion

        #region -- Controls In Lane
        ucCameraView? ucOverView = null;
        ucCameraView? ucMotoLpr = null;
        ucCameraView? ucCarLpr = null;
        private bool isShowOtherCam = false;
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

        private bool isInRegisterMode = false;

        //private bool isLeftToRight = false;
        //private bool isTopToBottom = true;
        public static Image defaultImg = Image.FromFile(frmMain.defaultImagePath);
        List<ucLastEventInfo> ucLastEventInfos = new List<ucLastEventInfo>();
        private WeighingAction? WeighingActionDetail = null;
        #endregion

        private int printCount = 0;
        LaneDirectionConfig laneDirection = new LaneDirectionConfig();
        #endregion END PROPERTIES

        #region FORMS
        public ucLaneIn(Lane lane, LaneDisplayConfig? laneDisplayConfig, bool isDisplayLastEvent, bool isScale)
        {
            InitializeComponent();

            this.isScale = isScale;
            lblLaneName.Text = lane.name;
            lblLaneName.BackColor = Color.DarkGreen;

            this.lane = lane;
            this.laneDisplayConfig = laneDisplayConfig;

            this.DoubleBuffered = true;

            laneDirection = NewtonSoftHelper<LaneDirectionConfig>.DeserializeObjectFromPath(
                                                        PathManagement.appLaneDirectionConfigPath(this.lane.id)) ?? LaneDirectionConfig.CreateDefault();
            panelDisplayLastEVent.Visible = laneDirection.IsDisplayLastEvent;
            splitContainerMain.Panel2Collapsed = laneDirection.IsDisplayLastEvent ? false : true;
            panelLastEvent.Visible = isDisplayLastEvent;

            //switch (laneDirection.displayDirection)
            //{
            //    case LaneDirectionConfig.EmDisplayDirection.Vertical:
            //        this.isTopToBottom = true;
            //        splitterEventInfoWithCamera.Dock = DockStyle.Bottom;
            //        panelEventData.Dock = DockStyle.Bottom;

            //        //panelCameras.Dock = DockStyle.Top;
            //        //splitterCamera.Dock = DockStyle.Top;
            //        //panelCameras.Height = 200;

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
            //    //panelCameras.Dock = DockStyle.Top;
            //    //splitterCamera.Dock = DockStyle.Top;
            //}
            //else
            //{
            //    if (this.isLeftToRight)
            //    {
            //        //panelCameras.Dock = DockStyle.Left;
            //        //splitterCamera.Dock = DockStyle.Left;

            //        splitContainerEventContent.Panel1.Controls.Add(panelDetectPlate);
            //        splitContainerEventContent.Panel2.Controls.Add(dgvEventContent);
            //    }
            //    else
            //    {
            //        //panelCameras.Dock = DockStyle.Right;
            //        //splitterCamera.Dock = DockStyle.Right;

            //        splitContainerEventContent.Panel1.Controls.Add(dgvEventContent);
            //        splitContainerEventContent.Panel2.Controls.Add(panelDetectPlate);
            //    }
            //}
            panelScaleAction.Visible = isScale;
            lblScaleFee.Text = TextFormatingTool.GetMoneyFormat("0");
            this.Load += UcLaneIn_Load;
        }
        private async void UcLaneIn_Load(object? sender, EventArgs e)
        {
            GetShortcutConfig();
            LoadCamera();
            await CreateUI();
            RegisterUIEvent();
            this.ActiveControl = lblLaneName;
            panelOversizeCam.Size = panelCameras.Size;
            SetDisplayDirection();
            DisplayUIConfig();
            PanelCameras_SizeChanged(null, EventArgs.Empty);
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
        public async Task ExcecuteInputEvent(InputEventArgs ie)
        {
            foreach (ControllerInLane controllerInLane in lane.controlUnits)
            {
                if (controllerInLane.controlUnitId.ToLower() != ie.DeviceId.ToLower())
                {
                    //Danh sách đăng ký có không có cấu hình của thiết bị ==> Bỏ qua
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
                var imageKeys = new List<string>()
                                                {
                                                    imageKey + "_OVERVIEWIN.jpeg",
                                                    imageKey + "_VEHICLEIN.jpeg",
                                                    imageKey + "_LPRIN.jpeg",
                };

            CheckInNormal:
                {
                    //var responseNormal = await KzParkingApiHelper.PostCheckInAsync(lane.id, plate, null, imageKeys);
                    eventIn = await AppData.ApiServer.PostCheckInAsync(lane.id, plate, null, imageKeys, false, null, txtNote.Text);
                    if (eventIn == null)
                    {
                        goto LOI_HE_THONG;
                    }
                    //if (responseNormal.metadata.success == false)
                    //{
                    //    isAlarm = true;
                    //    var errorCode = ApiInternalErrorMessages.GetFromName(responseNormal.metadata.message.code);
                    //    if (errorCode == EmApiErrorMessage.PINT_1013 || errorCode == EmApiErrorMessage.PINT_1018)
                    //    {
                    //        bool isConfirm = MessageBox.Show(ApiInternalErrorMessages.ToString(errorCode), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes;
                    //        if (isConfirm)
                    //        {
                    //            goto CheckInWithForce;
                    //        }
                    //        else
                    //        {
                    //            return;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        errorMessage = ApiInternalErrorMessages.ToString(errorCode);
                    //        goto SU_KIEN_LOI;
                    //    }
                    //}
                    //else
                    {
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

            CheckInWithForce:
                {
                    //var responseWithForce = await KzParkingApiHelper.PostCheckInAsync(lane.id, plate, null, imageKeys, true);
                    eventIn = await AppData.ApiServer.PostCheckInAsync(lane.id, plate, null, imageKeys, true, null, txtNote.Text);
                    if (eventIn == null)
                    {
                        goto LOI_HE_THONG;
                    }
                    //if (responseWithForce.metadata.success == false)
                    //{
                    //    errorMessage = ApiInternalErrorMessages.ToString(ApiInternalErrorMessages.GetFromName(responseWithForce.metadata.message.code));
                    //    goto SU_KIEN_LOI;
                    //}
                    else
                    {
                        //eventIn = responseWithForce.data;
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
                    ExcecuteUnvalidEvent(null, null, vehicleType.Type, plate, ie.EventTime, errorMessage, null, "");
                    return;
                }
            SU_KIEN_HOP_LE:
                {
                    //if (eventIn.registeredVehicle != null)
                    //{
                    //    plate = eventIn.registeredVehicle.PlateNumber;
                    //}
                    await ExcecuteValidEvent(null, null, vehicleType.Type, plate, ie.EventTime, overviewImage, vehicleImg, lprImage, imageKey, eventIn, isAlarm, imageKeys, optionalImages);
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
            if (lastEvent == null)
            {
                string imageKey = BaseLane.GetBaseImageKey(this.lane.name, "", "", DateTime.Now);
                //await KzParkingApiHelper.CreateAlarmAsync("", this.lane.id, "", AbnormalCode.OpenBarrierByButton, imageKey, true, "", "", "", "");
                await AppData.ApiServer.CreateAlarmAsync("", this.lane.id, "", EmAbnormalCode.OpenBarrierByButton, imageKey, true, "", "", "", "");
                SaveAllCameraImage(imageKey);
                return;
            }

            //Đã có sự kiện trước đó kiểm tra xem có trong thời gian cho phép mở ko
            if ((DateTime.Now - lastEvent.DatetimeIn)?.TotalSeconds >= StaticPool.appOption.AllowBarrieDelayOpenTime)
            {
                string imageKey = BaseLane.GetBaseImageKey(this.lane.name, "", "", DateTime.Now);
                //await KzParkingApiHelper.CreateAlarmAsync(lastEvent.Identity?.Id, this.lane.id, lastEvent.PlateNumber, AbnormalCode.OpenBarrierByButton,
                //imageKey, true,
                //                                          lastEvent?.IdentityGroupId, lastEvent?.customer?.Id,
                //                                          lastEvent?.RegisteredVehicle?.Id, "");
                await AppData.ApiServer.CreateAlarmAsync(lastEvent.Identity?.Id, this.lane.id, lastEvent.PlateNumber, EmAbnormalCode.OpenBarrierByButton,
                                                          imageKey, true,
                                                          lastEvent?.IdentityGroupId, lastEvent?.customer?.Id,
                                                          lastEvent?.RegisteredVehicle?.Id, "");
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

            ClearView();
            //Danh sách biến sử dụng
            Image? overviewImg = null;
            Image? vehicleImg = null;

            lblResult.UpdateResultMessage("Đang kiểm tra thông tin sự kiện quẹt thẻ..." + ce.PreferCard, Color.DarkBlue);

            #region Kiểm tra thông tin định danh
            var identityResponse = await IsValidIdentity(ce.PreferCard);
            if (!identityResponse.Item1)
            {
                return;
            }
            Identity? identity = identityResponse.Item2!;
            identity = (await AppData.ApiServer.GetIdentityByIdAsync(identity.Id)).Item1;
            if (identity == null)
            {
                lblResult.UpdateResultMessage("Mã định danh không có trong hệ thống, vui lòng thử lại", Color.DarkRed);
                return;
            }
            #endregion End kiểm tra thông tin định danh

            #region Kiểm tra thông tin nhóm định danh
            lblResult.UpdateResultMessage("Đọc thông tin nhóm định danh...", Color.DarkBlue);
            IdentityGroup? identityGroup = (await AppData.ApiServer.GetIdentityGroupByIdAsync(identity.IdentityGroupId.ToString()))?.Item1;
            if (identityGroup == null || identityGroup.Id == Guid.Empty)
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

            List<Image> optionalImages;
            #endregion End kiểm tra thông tin loại phương tiện

            Image? lprImage = GetPlate(ce, ref overviewImg, ref vehicleImg, vehicleBaseType, out optionalImages);

            //Đọc thông tin loại phương tiện
            lblResult.UpdateResultMessage("Đang check in..." + ce.PreferCard, Color.DarkBlue);
            string imageKey = BaseLane.GetBaseImageKey(this.lane.name, ce.PreferCard, ce.PlateNumber, ce.EventTime);
            List<string> imageKeys = new List<string>()
            {
                imageKey + "_OVERVIEWIN.jpeg",
                imageKey + "_VEHICLEIN.jpeg",
                imageKey + "_LPRIN.jpeg",
            };

            // Kiểm tra quẹt sai loại thẻ so với lần cuối cùng
            if (!string.IsNullOrEmpty(ce.PlateNumber))
            {
                // Lấy thông tin sự kiện cuối cùng đã ra có biển số  = biển số nhận diện
                string lastIdentityId = await AppData.ApiServer.GetLastEventOutIdentityGroupIdByPlateNumber(ce.PlateNumber) ?? "";

                // Kiểm tra thông tin nhóm thẻ của sự kiện cuối cùng == nhóm thẻ hiện tại
                bool isDifferenceIdentityGroup = lastIdentityId.ToLower() != identityGroup.Id.ToString().ToLower();
                if (isDifferenceIdentityGroup)
                {
                    var lastCardGroup = await AppData.ApiServer.GetIdentityGroupByIdAsync(lastIdentityId);
                    if (lastCardGroup != null)
                    {
                        if (lastCardGroup.Item1 != null)
                        {
                            var frm = new frmConfirmCardGroup(ce.PlateNumber, lastCardGroup.Item1.Name, identityGroup.Name);
                            bool isConfirm = frm.ShowDialog() == DialogResult.OK;
                            if (!isConfirm)
                            {
                                lblResult.UpdateResultMessage("Không xác nhận đổi nhóm thẻ", Color.DarkRed);
                                return;
                            }
                        }
                    }
                }
            }

            bool isMonthCard = identityGroup.Type == IdentityGroupType.Monthly;
            if (isMonthCard)
            {
                await ExcecuteMonthCardEventIn(identity, identityGroup, vehicleBaseType, ce.PlateNumber, imageKeys,
                                               ce, controllerInLane,
                                               overviewImg, vehicleImg, lprImage, imageKey, optionalImages);
            }
            else
            {
                await ExcecuteNonMonthCardEventIn(identity, identityGroup, vehicleBaseType, ce.PlateNumber, imageKeys,
                                                  ce, controllerInLane,
                                                  overviewImg, vehicleImg, lprImage, imageKey, optionalImages);
            }

        }

        private bool IsAllowDesignRealtime = false;
        private void FocusOnTitle()
        {
            this.Invoke(new Action(() =>
            {
                this.ActiveControl = lblLaneName;
                lblLaneName.Focus();
            }));
        }
        public async void OnKeyPress(Keys keys)
        {
            await semaphoreSlimOnKeyPress.WaitAsync();
            try
            {
                if (StaticPool.appOption.PrintTemplate == (int)EmPrintTemplate.XuanCuong)
                {
                    if (keys == Keys.F1)
                    {
                        //for (int i = 0; i < 17; i++)
                        //{
                        //    await OnNewEvent(new CardEventArgs()
                        //    {
                        //        PreferCard = "the" +i.ToString(),
                        //        DeviceId = "e9bc8a38-9440-4d5a-8033-90cfd7e61ae2",
                        //        ReaderIndex = 1
                        //    });
                        //}

                        if (this.lastEvent != null)
                        {
                            bool isConfirm = MessageBox.Show("Bạn có xác nhận đổi sang loại xe nhập?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
                            if (!isConfirm)
                            {
                                return;
                            }
                            await AppData.ApiServer.CreateWarehouseService(lastEvent.Id, "", txtPlate.Text, TransactionType.EmTransactionType.InBound, false);
                        }
                    }
                    if (keys == Keys.F2)
                    {
                        if (this.lastEvent != null)
                        {
                            bool isConfirm = MessageBox.Show("Bạn có xác nhận đổi sang loại xe xuất?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
                            if (!isConfirm)
                            {
                                return;
                            }
                            await AppData.ApiServer.CreateWarehouseService(lastEvent.Id, "", txtPlate.Text, TransactionType.EmTransactionType.OutBound, false);
                        }
                    }
                    if (keys == Keys.F3)
                    {
                        if (this.lastEvent != null)
                        {
                            bool isConfirm = MessageBox.Show("Bạn có xác nhận đổi sang loại xe sang tải?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
                            if (!isConfirm)
                            {
                                return;
                            }
                            await AppData.ApiServer.CreateWarehouseService(lastEvent.Id, "", txtPlate.Text, TransactionType.EmTransactionType.Overweight, false);
                        }
                    }
                    if (keys == Keys.F4)
                    {
                        if (this.lastEvent != null)
                        {
                            bool isConfirm = MessageBox.Show("Bạn có xác nhận đổi sang loại xe khác?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
                            if (!isConfirm)
                            {
                                return;
                            }
                            await AppData.ApiServer.CreateWarehouseService(lastEvent.Id, "", txtPlate.Text, TransactionType.EmTransactionType.Other, false);
                        }
                    }
                    if (keys == Keys.F8)
                    {
                        if (this.lastEvent != null)
                        {
                            bool isConfirmPrint = MessageBox.Show("Bạn có muốn in phiếu xuất?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
                            //bool isConfirmPrint = true;
                            if (isConfirmPrint)
                            {
                                var warehouse = await AppData.ApiServer.CreateWarehouseService(lastEvent.Id, "", txtPlate.Text,
                                    TransactionType.EmTransactionType.OutBound, true);
                                this.printCount = 1;
                                var wbPrint = new WebBrowser();
                                wbPrint.DocumentCompleted += WbPrint_DocumentCompleted;
                                wbPrint.DocumentText = GetPrintWarehoseContent(warehouse, lastEvent.Identity.Name, lastEvent.PlateNumber, lastEvent.DatetimeIn.Value);
                            }
                        }
                    }
                    if (keys == Keys.F12)
                    {
                        this.Invoke(new Action(() =>
                        {
                            this.SuspendLayout();
                            panelOversizeCam.Visible = !isShowOtherCam;
                            this.isShowOtherCam = !isShowOtherCam;
                            panelCameras.Visible = !panelOversizeCam.Visible;
                            this.ResumeLayout();
                        }));
                    }
                }



                if (keys == Keys.F9)
                {
                    this.IsAllowDesignRealtime = !this.IsAllowDesignRealtime;
                    this.Invoke(new Action(() =>
                    {
                        this.AllowDesignRealtime(this.IsAllowDesignRealtime);
                    }));
                }
                if (keys == Keys.Enter)
                {
                    if (this.lastEvent != null)
                    {
                        if (txtNote.Focused)
                        {
                            bool isUpdateNote = MessageBox.Show("Bạn có muốn cập nhật ghi chú BSX?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
                            if (isUpdateNote)
                            {
                                bool isUpdateSuccess = await KzParkingv5ApiHelper.UpdateBSXNote(txtNote.Text, lastEvent.Id, true);
                                if (isUpdateSuccess)
                                {
                                    lblResult.UpdateResultMessage("Ra Lệnh Cập Nhật Ghi Chú Biển Số Thành Công", Color.DarkBlue);
                                }
                                else
                                {
                                    lblResult.UpdateResultMessage("Cập Nhật Lỗi, Vui Lòng Thử Lại", Color.DarkRed);
                                }
                            }
                            FocusOnTitle();
                        }
                    }
                }
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
                                //bool isUpdateSuccess = await KzParkingApiHelper.UpdateEventInPlate(lastEvent.Id, newPlate);
                                bool isUpdateSuccess = await AppData.ApiServer.UpdateEventInPlateAsync(lastEvent.Id, newPlate.ToUpper(), lastEvent.PlateNumber);
                                if (isUpdateSuccess)
                                {
                                    lblResult.UpdateResultMessage("Ra Lệnh Cập Nhật Biển Số Thành Công", Color.DarkBlue);
                                    if (ucTop1Event != null)
                                    {
                                        ucTop1Event.plateNumber = newPlate.ToUpper();
                                    }
                                    lastEvent.PlateNumber = newPlate.ToUpper();
                                    if (((EmPrintTemplate)StaticPool.appOption.PrintTemplate) == EmPrintTemplate.XuanCuong)
                                    {
                                        await XuanCuongApiHelper.SendParkingInfo(lastEvent.Id, "in", newPlate, lastTime, lastImageKeys, "");
                                    }
                                    if (isScale)
                                    {
                                        await KzScaleApiHelper.UpdatePlate(lastEvent.Id, newPlate.ToUpper());
                                    }
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
                                NewtonSoftHelper<LaneDisplayConfig>.SaveConfig(config, PathManagement.appDisplayConfigPath(this.lane.id));
                            }));
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
        /// Sự kiện xảy ra khi người dùng sử dụng phím tắt để ra lệnh mở barrie
        /// </summary>
        private async Task ProcessButtonEvent()
        {
            //--Chưa có sự kiện vào hoặc thời gian từ lúc có sự kiện đến khi bấm mở barrie quá 5s thì lưu sự kiện cảnh báo
            if (lastEvent == null)
            {
                string imageKey = BaseLane.GetBaseImageKey(this.lane.name, "", "", DateTime.Now);
                //await KzParkingApiHelper.CreateAlarmAsync("", this.lane.id, "", AbnormalCode.OpenBarrierByKeyboard, imageKey, true, "", "", "", "");
                await AppData.ApiServer.CreateAlarmAsync("", this.lane.id, "", EmAbnormalCode.OpenBarrierByKeyboard, imageKey, true, "", "", "", "");
                SaveAllCameraImage(imageKey);
            }
            else if ((DateTime.Now - lastEvent.DatetimeIn)?.TotalSeconds >= StaticPool.appOption.AllowBarrieDelayOpenTime)
            {
                string imageKey = BaseLane.GetBaseImageKey(this.lane.name, "", "", DateTime.Now);
                //await KzParkingApiHelper.CreateAlarmAsync(lastEvent.Identity?.Id, this.lane.id, lastEvent.PlateNumber, AbnormalCode.OpenBarrierByKeyboard,
                //                                          imageKey, true,
                //                                          lastEvent?.IdentityGroupId, lastEvent?.customer?.Id,
                //                                          lastEvent?.RegisteredVehicle?.Id, "");
                await AppData.ApiServer.CreateAlarmAsync(lastEvent.Identity?.Id, this.lane.id, lastEvent.PlateNumber, EmAbnormalCode.OpenBarrierByKeyboard,
                                                     imageKey, true,
                                                     lastEvent?.IdentityGroupId, lastEvent?.customer?.Id,
                                                     lastEvent?.RegisteredVehicle?.Id, "");
                SaveAllCameraImage(imageKey);
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
                if (panelCameras.Controls.Count > 0)
                {
                    Control lastControl = panelCameras.Controls[panelCameras.Controls.Count - 1];
                    Point location = new Point(lastControl.Location.X, lastControl.Location.Y + lastControl.Height + 10);
                    panelCameras.Controls.Add(ucOverView);
                    ucOverView.Location = location;
                }
                else
                {
                    panelCameras.Controls.Add(ucOverView);
                    ucOverView.Location = new Point(0);
                }
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

            foreach (var item in this.cameras)
            {
                var key = CameraPurposeType.EmCameraPurposeType.SubOverView;
                if (item.Key == CameraPurposeType.EmCameraPurposeType.SubOverView)
                {
                    for (int i = 0; i < item.Value.Count; i++)
                    {
                        Kztek.Cameras.Camera otherCam = new Kztek.Cameras.Camera();
                        otherCam.ID = cameras[key][i].Id;
                        otherCam.Name = cameras[key][i].Name;
                        otherCam.VideoSource = cameras[key][i].IpAddress;
                        otherCam.HttpPort = int.Parse(cameras[key][i].HttpPort);
                        otherCam.Login = cameras[key][i].Username;
                        otherCam.Password = cameras[key][i].Password;
                        otherCam.Chanel = cameras[key][i].Channel;
                        string _camType = cameras[key][i].GetCameraType() == "HIK" ? "HIKVISION" : cameras[key][i].GetCameraType();
                        otherCam.CameraType = Kztek.Cameras.CameraTypes.GetType(_camType);
                        otherCam.StreamType = Kztek.Cameras.StreamTypes.GetType("H264");
                        otherCam.Resolution = string.IsNullOrEmpty(cameras[key][0].Resolution) ? "1280x720" : cameras[key][i].Resolution;
                        otherCam.Start();
                        this.OtherCams.Add(otherCam);
                        var ucCam = new ucCameraView();
                        ucCam.StartViewer(otherCam, CameraErrorFunc);
                        Control lastControl = panelOversizeCam.Controls[panelOversizeCam.Controls.Count - 1];
                        Point location = new Point(lastControl.Location.X, lastControl.Location.Y + lastControl.Height + 10);
                        panelOversizeCam.Controls.Add(ucCam);
                        ucCam.Location = location;
                    }
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

        private async Task CreateUI()
        {
            this.Dock = DockStyle.Fill;

            lblResult.Padding = new Padding(StaticPool.baseSize);
            lblResult.UpdateResultMessage("XIN MỜI VÀO", Color.DarkGreen);

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
            //Tuple<List<EventInReport>, int, int> top3Event = await KzParkingApiHelper.GetEventIns("", startTime, endTime, "", "", this.lane.id, 1, 3);
            var top3Event = await AppData.ApiServer.GetEventIns("", startTime, endTime, "", "", this.lane.id, "", 1, 3);
            if (top3Event != null)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (top3Event.Count <= i)
                    {
                        continue;
                    }
                    string id = top3Event[i].id.ToString() ?? "";
                    string plateNumber = top3Event[i].plateNumber.ToString() ?? "";
                    string vehicleGroupId = "";
                    string cardGroupId = top3Event[i].IdentityGroupId.ToString() ?? "";
                    DateTime dateTimeIn = DateTime.Parse(top3Event[i].createdUtc.ToString()).AddHours(7);

                    List<string> picDirs = top3Event[i].fileKeys ?? new List<string>();
                    string customerId = "";// top3Event.Rows[i]["customerid"].ToString() ?? "";
                    string registerVehicleId = "";// top3Event.Rows[i]["vehicleid"].ToString() ?? "";
                    string laneId = top3Event[i].laneId.ToString() ?? "";
                    string identityId = top3Event[i].identityId.ToString() ?? "";
                    ucLastEventInfos[i].UpdateEventInfo(id, plateNumber, vehicleGroupId, cardGroupId, dateTimeIn, picDirs,
                                                        customerId, registerVehicleId, laneId, identityId, true);
                }
            }
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
                for (int i = 0; i < tablePic.RowCount; i++)
                {
                    Control Control = tablePic.GetControlFromPosition(tablePic.ColumnCount - 1, i);
                    tablePic.Controls.Remove(Control);
                }
                tablePic.ColumnStyles.RemoveAt(tablePic.ColumnCount - 1);
                panelNote.Visible = false;
            }
        }
        private void RegisterUIEvent()
        {
            panelCameras.SizeChanged += PanelCameras_SizeChanged;
            panelOversizeCam.SizeChanged += PanelOversizeCam_SizeChanged;
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

        private void PanelOversizeCam_SizeChanged(object? sender, EventArgs e)
        {
            panelCameras.Size = panelOversizeCam.Size;
            foreach (Control item in panelOversizeCam.Controls)
            {
                //if (this.isTopToBottom)
                //{
                //    item.Width = (panelCameras.Height - 50) * 16 / 9;
                //}
                //else
                {
                    item.Width = panelOversizeCam.Width - panelOversizeCam.Margin.Left - panelOversizeCam.Margin.Right - panelOversizeCam.Padding.Left - panelOversizeCam.Padding.Right
                                                    - item.Margin.Left - item.Margin.Right - item.Padding.Left - item.Padding.Right;
                }
            }
            for (int i = 0; i < panelOversizeCam.Controls.Count; i++)
            {
                if (i == 0)
                {
                    panelOversizeCam.Controls[i].Location = new Point(0);
                }
                else
                {
                    Control lastControl = panelOversizeCam.Controls[i - 1];
                    //if (this.isTopToBottom)
                    //{
                    //    Point location = new Point(lastControl.Location.X + lastControl.Width + 10, lastControl.Location.Y);
                    //    panelCameras.Controls[i].Location = location;
                    //}
                    //else
                    {
                        Point location = new Point(lastControl.Location.X, lastControl.Location.Y + lastControl.Height + 10);
                        panelOversizeCam.Controls[i].Location = location;
                    }
                }
            }
        }

        private Image? GetPlate(CardEventArgs ce, ref Image? overviewImg, ref Image? vehicleImg, VehicleBaseType vehicleBaseType, out List<Image> optionalImages)
        {
            optionalImages = new List<Image>();
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
            BaseLane.ShowImage(picOverviewImage, overviewImg);
            BaseLane.ShowImage(picVehicleImage, vehicleImg);
            BaseLane.ShowImage(picLprImage, lprImage);

            txtPlate.Invoke(new Action(() =>
            {
                txtPlate.Text = ce.PlateNumber;
                txtPlate.Refresh();
            }));
            foreach (var item in this.OtherCams)
            {
                optionalImages.Add(item.GetCurrentVideoFrame());
            }
            if (optionalImages.Count == 1)
            {
                BaseLane.ShowImage(picOther1, optionalImages[0]);
            }
            else if (optionalImages.Count > 1)
            {
                BaseLane.ShowImage(picOther1, optionalImages[0]);
                BaseLane.ShowImage(picOther2, optionalImages[1]);
            }
            return lprImage;
        }
        private void DisplayEventInfo(DateTime eventTime, string plateNumber, Identity? identity, IdentityGroup? identityGroup, VehicleBaseType? vehicle, Customer? customer, RegisteredVehicle? registeredVehicle, WeighingAction? weighingAction = null)
        {
            laneDirection = NewtonSoftHelper<LaneDirectionConfig>.DeserializeObjectFromPath(
                                                      PathManagement.appLaneDirectionConfigPath(this.lane.id)) ?? LaneDirectionConfig.CreateDefault();
            dgvEventContent?.Invoke(new Action(() =>
            {
                dgvEventContent.Columns[0].Visible = laneDirection.IsDisplayTitle;
            }));
            dgvEventContent?.Invoke(new Action(() =>
            {
                dgvEventContent.Rows.Clear();
                dgvEventContent.Rows.Add("Giờ Vào", eventTime.ToString(UltilityManagement.fullDayFormat));
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

                if (weighingAction != null && !string.IsNullOrEmpty(weighingAction.Id))
                {
                    lblScaleFee.Text = TextFormatingTool.GetMoneyFormat(weighingAction.weighingType.Price.ToString());
                }
                else
                {
                    //LOG
                }
                dgvEventContent.BringToFront();
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

            _ = MinioHelper.UploadPicture(overviewImg, imageKey + "_OVERVIEWIN.jpeg");
            if (carVehicleImage != null)
            {
                _ = MinioHelper.UploadPicture(carVehicleImage, imageKey + "_VEHICLEIN.jpeg");
            }
            else
            {
                _ = MinioHelper.UploadPicture(motorVehicleImage, imageKey + "_VEHICLEIN.jpeg");
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

                lblResult.UpdateResultMessage("", Color.DarkBlue);
                lblResult.Refresh();

                this.WeighingActionDetail = null;

                lblScaleFee.Text = TextFormatingTool.GetMoneyFormat("0");
                if (cbGoodsType.Items.Count > 0)
                {
                    cbGoodsType.SelectedIndex = 0;
                }
            }));
        }

        private string GetPrintWarehoseContent(WarehouseService warehouseService, string cardName, string plateNumber, DateTime timeIn)
        {
            string printTemplatePath = PathManagement.appPrintTemplateWarehousePath(((EmPrintTemplate)StaticPool.appOption.PrintTemplate).ToString());
            if (File.Exists(printTemplatePath))
            {
                string baseContent = File.ReadAllText(printTemplatePath);
                baseContent = baseContent.Replace("$card_name", cardName);
                baseContent = baseContent.Replace("$plate_number", plateNumber);
                baseContent = baseContent.Replace("$timeIn", timeIn.ToString(UltilityManagement.fullDayFormat));
                baseContent = baseContent.Replace("$warehouseNumber", (int.Parse(warehouseService.paperworkSequence)).ToString("00"));
                baseContent = baseContent.Replace("$code", warehouseService.codeCharacterSequence + "-" + warehouseService.codeNumberSequence);
                return baseContent;
            }
            else
            {
                MessageBox.Show("Không tìm thấy mẫu in", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return string.Empty;
            }

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
                baseContent = baseContent.Replace("{$plateNumber}", lastEvent.PlateNumber);
                baseContent = baseContent.Replace("{$weightType}", cbGoodsType.Text);
                baseContent = baseContent.Replace("{$number}", weighingActionDetails[0].weighingSlip.printNumber);
                return baseContent;
            }
            else
            {
                MessageBox.Show("Không tìm thấy mẫu in", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return string.Empty;
            }
        }
        private string GetPrintScaleInvoiceOfflineContent(WeighingAction weighingActionDetail)
        {
            string printTemplatePath = PathManagement.appPrintScaleInvoiceOfflineTemplateConfigPath(((EmPrintTemplate)StaticPool.appOption.PrintTemplate).ToString());
            if (File.Exists(printTemplatePath))
            {
                string baseContent = File.ReadAllText(printTemplatePath);
                baseContent = baseContent.Replace("$companyTaxCode", StaticPool.TaxCode);
                baseContent = baseContent.Replace("$companyAddress", StaticPool.CompanyAddress);
                baseContent = baseContent.Replace("$companyName", StaticPool.CompanyName);
                baseContent = baseContent.Replace("$templateCode", StaticPool.scaleSymbolCode);

                baseContent = baseContent.Replace("$day", DateTime.Now.Day.ToString("00"));
                baseContent = baseContent.Replace("$month", DateTime.Now.Month.ToString("00"));
                baseContent = baseContent.Replace("$year", DateTime.Now.Year.ToString("0000"));

                baseContent = baseContent.Replace("$excecute_time", DateTime.Now.ToString(UltilityManagement.fullDayFormat));
                baseContent = baseContent.Replace("$plateNumber", lastEvent.PlateNumber);

                baseContent = baseContent.Replace("$money_int", TextFormatingTool.GetMoneyFormat(weighingActionDetail.weighingType.Price.ToString()));

                baseContent = baseContent.Replace("$money_str", SayMoney.MISASaysMoney.MISASayMoney(weighingActionDetail.weighingType.Price));

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
                        <center><span>{weighingActionDetail.createdUtcTime!.Value.ToString(UltilityManagement.fullDayFormat)}</span></center>
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
        #endregion End Private Function

        #region Xử lý sự kiện thẻ
        private async Task ExcecuteMonthCardEventIn(Identity identity, IdentityGroup identityGroup, VehicleBaseType vehicleType, string plateNumber, List<string> imageKeys,
                                                    CardEventArgs ce, ControllerInLane? controllerInLane,
                                                    Image? overviewImg, Image? vehicleImg, Image? lprImage, string imageKey, List<Image> optionalImages)
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

            string errorMessage = string.Empty;
            AddEventInResponse? eventIn = null;
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
                eventIn = await AppData.ApiServer.PostCheckInAsync(lane.id, plateNumber, identity, imageKeys, false, null, txtNote.Text);
                if (eventIn == null)
                {
                    goto LOI_HE_THONG;
                }
                if (!eventIn.IsSuccess)
                {
                    errorMessage = eventIn.fields.Count > 0 ? (eventIn.fields[0].ToString() ?? "") : eventIn.detailCode;
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
                                                                         identity.Vehicles[0].Customer.Name, identity.Vehicles[0].PlateNumber,
                                                                         identity.Vehicles[0].Customer.Address, vehicleImg, overviewImg, plateNumber);
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
                eventIn = await AppData.ApiServer.PostCheckInAsync(lane.id, plateNumber, identity, imageKeys, true, null, txtNote.Text);
                if (eventIn == null)
                {
                    goto LOI_HE_THONG;
                }
                if (!eventIn.IsSuccess)
                {
                    if (eventIn.fields.Count > 0)
                    {
                        errorMessage = eventIn.fields[0].ToString() ?? "";
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
                await ExcecuteValidEvent(identity, identityGroup, vehicleType, plateNumber, ce.EventTime, overviewImg, vehicleImg, lprImage, imageKey, eventIn, isAlarm, imageKeys, optionalImages);
                return;
            }
        }

        private async Task ExcecuteNonMonthCardEventIn(Identity identity, IdentityGroup identityGroup,
                                                       VehicleBaseType vehicleType, string plateNumber, List<string> imageKeys,
                                                       CardEventArgs ce, ControllerInLane? controllerInLane,
                                                       Image? overviewImg, Image? vehicleImg, Image? lprImage, string imageKey, List<Image> optionalImages)
        {

            string errorMessage = string.Empty;
            AddEventInResponse? eventIn = null;
            bool isAlarm = false;
            //UPDATE TEST
            //if (identityGroup.PlateNumberValidation != (int)EmPlateCompareRule.UnCheck)
            //{
            //    if (string.IsNullOrEmpty(plateNumber))
            //    {
            //        isAlarm = true;
            //        bool isConfirm = MessageBox.Show("Không nhận diện được biển số, bạn có muốn cho xe vào bãi?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes;
            //        if (!isConfirm)
            //        {
            //            ClearView();
            //            return;
            //        }
            //    }
            //}
            string note = "";
            this.Invoke(new Action(() =>
            {
                note = txtNote.Text;
            }));
            eventIn = await AppData.ApiServer.PostCheckInAsync(lane.id, plateNumber, identity, imageKeys, false, null, note);
            if (eventIn == null)
            {
                goto LOI_HE_THONG;
            }

            if (!eventIn.IsSuccess)
            {
                if (eventIn.fields == null)
                {
                    goto LOI_HE_THONG;
                }
                if (eventIn.fields.Count > 0)
                {
                    errorMessage = eventIn.fields[0].ToString() ?? "";
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
                await ExcecuteValidEvent(identity, identityGroup, vehicleType, ce.PlateNumber, ce.EventTime,
                                        overviewImg, vehicleImg, lprImage,
                                        imageKey, eventIn, isAlarm, imageKeys, optionalImages);
                return;
            }
        }

        private void ExcecuteSystemErrorCheckIn()
        {
            lblResult.UpdateResultMessage("Không gửi được thông tin xe vào lên hệ thống, vui lòng thử lại sau giây lát", Color.DarkRed);
        }
        private void ExcecuteUnvalidEvent(Identity identity, IdentityGroup identityGroup, VehicleBaseType vehicleType, string detectPlate, DateTime eventTime, string errorMessage, Customer? customer, string registerPlate)
        {
            lblResult.UpdateResultMessage(errorMessage, Color.DarkRed);
            DisplayEventInfo(eventTime, detectPlate, identity, identityGroup, vehicleType, customer, null);
        }
        List<string> lastImageKeys = new List<string>();
        DateTime lastTime = DateTime.Now;
        private async Task ExcecuteValidEvent(Identity? identity, IdentityGroup? identityGroup,
                                              VehicleBaseType vehicleType, string detectPlate,
                                              DateTime eventTime, Image? overviewImg,
                                              Image? vehicleImg, Image? lprImage, string imageKey,
                                              AddEventInResponse? eventIn, bool isAlarm, List<string> imageKeys, List<Image> optionalImages)
        {
            txtPlate.Invoke(new Action(() =>
            {
                txtPlate.Text = detectPlate;
            }));
            lblResult.UpdateResultMessage("Xin Mời Qua", Color.DarkGreen);

            WeighingAction? weigingAction = null;
            if (isScale)
            {
                string weightFormId = ((ListItem)cbGoodsType.SelectedItem)?.Name ?? "";
                this.WeighingActionDetail = await KzScaleApiHelper.CreateScaleEvent(detectPlate, eventIn?.Id, this.ScaleValue, weightFormId,
                                                        StaticPool.userId, StaticPool.user_name, imageKeys);
            }
            DisplayEventInfo(eventTime, detectPlate, identity, identityGroup, vehicleType, null, null, weigingAction);
            BaseLane.DisplayLed(detectPlate, eventTime, identity, identityGroup, "Hẹn Gặp lại", this.lane.id, "0");
            await BaseLane.SaveEventImage(overviewImg, vehicleImg, lprImage, imageKey, true, optionalImages);

            lastEvent = new EventIn()
            {
                Id = eventIn?.Id,
                CreatedUtc = eventTime.AddHours(-7).ToString("yyyy-MM-ddTHH:mm:ss:ffff"),
                PlateNumber = detectPlate,
                Identity = identity,
                IdentityId = identity?.Id,
                LaneId = this.lane.id,
                IdentityGroupId = identityGroup?.Id.ToString(),
            };

            if (isAlarm)
            {
                await AppData.ApiServer.CreateAlarmAsync(identity?.Id, this.lane.id, detectPlate, EmAbnormalCode.InvalidPlateNumber,
                                                         imageKey, true, identityGroup?.Id.ToString(), "", "", "Cảnh báo biển số");
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
                                                        customerId, registerVehicleId, laneId, identityId, true);
                }
                var overviewKey = imageKey + "_OVERVIEWIN.jpeg";
                var vehicleKey = imageKey + "_VEHICLEIN.jpeg";
                var vehicleCutKey = imageKey + "_LPRIN.jpeg";
                var imageKeys = new List<string>() { overviewKey, vehicleKey, vehicleCutKey };
                ucLastEventInfos[0].UpdateEventInfo(eventIn.Id, detectPlate, "",
                                                    identityGroup?.Id.ToString() ?? "", eventTime, imageKeys,
                                                     "", "", this.lane.id, identity?.Id, true);
            }));
            if (((EmPrintTemplate)StaticPool.appOption.PrintTemplate) == EmPrintTemplate.XuanCuong)
            {
                lastImageKeys = imageKeys;
                lastTime = eventTime;
                XuanCuongApiHelper.SendParkingInfo(lastEvent.Id, "in", detectPlate, eventTime, imageKeys, "");
            }
            await AppData.ApiServer.CreateWarehouseService(lastEvent.Id, "", detectPlate, TransactionType.EmTransactionType.InBound, false);
        }
        #endregion End xử lý sự kiện thẻ

        #region CONTROLS IN FORM

        #region ACTION
        private void CbNote_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ActiveControl = lblLaneName;
        }
        private void CbGoodsType_SelectedIndexChanged(object? sender, EventArgs e)
        {
            this.ActiveControl = lblLaneName;
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

            laneDirection = NewtonSoftHelper<LaneDirectionConfig>.DeserializeObjectFromPath(
                                                       PathManagement.appLaneDirectionConfigPath(this.lane.id)) ?? LaneDirectionConfig.CreateDefault();
            panelDisplayLastEVent.Visible = laneDirection.IsDisplayLastEvent;
            SetDisplayDirection();
        }

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
            panelDisplayLastEVent.Visible = laneDirection.IsDisplayLastEvent;
            splitContainerMain.Panel2Collapsed = laneDirection.IsDisplayLastEvent ? false : true;
            panelLastEvent.Visible = laneDirection.IsDisplayLastEvent;
            PanelCameras_SizeChanged(null, null);
        }

        private async void BtnPrintScale_Click(object sender, EventArgs e)
        {

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
                MessageBox.Show("Chưa có thông tin sự kiện cân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool isContinue = await CheckWeighingType();
            if (!isContinue)
            {
                return;
            }

            var frm = new frmSelectPrintCount();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.printCount = frm.PrintCount;

                var wbPrint = new WebBrowser();
                wbPrint.DocumentCompleted += WbPrint_DocumentCompleted;
                wbPrint.DocumentText = GetPrintContent(await KzScaleApiHelper.GetWeighingActionDetailsByTrafficId(this.lastEvent.Id));
            }
        }
        private async void btnPrintScaleOffline_Click(object sender, EventArgs e)
        {
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

            this.printCount = 1;
            var wbPrint = new WebBrowser();
            wbPrint.DocumentCompleted += WbPrint_DocumentCompleted;
            wbPrint.DocumentText = GetPrintScaleInvoiceOfflineContent(this.WeighingActionDetail);
        }
        private async void btnPrintScaleOnline_Click(object sender, EventArgs e)
        {
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

            if (this.WeighingActionDetail.weighingType.Price == 0)
            {
                MessageBox.Show("Phương tiện không phát sinh phí cân xe.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //In hóa đơn internet
            //UPDATE TEST
            //if (string.IsNullOrEmpty(this.WeighingActionDetail.InvoiceId))
            //{
            //    var invoiceData = await KzScaleApiHelper.CreateInvoice(this.WeighingActionDetail.Id, true);
            //    if (invoiceData==null|| string.IsNullOrEmpty(invoiceData.id) || invoiceData.id == Guid.Empty.ToString())
            //    {
            //        MessageBox.Show("Chưa gửi được thông tin hóa đơn điện tử", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //    this.WeighingActionDetail.InvoiceId = invoiceData.id;
            //}

            //var invoiceFile = await AppData.ApiServer.GetInvoiceData(this.WeighingActionDetail.InvoiceId);
            //if (invoiceFile == null)
            //{
            //    MessageBox.Show("Chưa có thông tin hóa đơn điện tử", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            //try
            //{
            //    string pdfContent = invoiceFile.fileToBytes;
            //    if (!string.IsNullOrEmpty(pdfContent))
            //    {
            //        PrintHelper.PrintPdf(pdfContent);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Chưa có thông tin hóa đơn điện tử", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //}
            //catch (Exception ex)
            //{
            //}
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
                                lblScaleFee.Text = TextFormatingTool.GetMoneyFormat(this.WeighingActionDetail.weighingType.Price.ToString());
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
            //RegisteredVehicle? registeredVehicle = await KzParkingApiHelper.GetRegisteredVehicle(selectedPlate);
            RegisteredVehicle? registeredVehicle = (await AppData.ApiServer.GetRegistedVehilceByPlateAsync(selectedPlate)).Item1;
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

            string vehicleTypeId = registeredVehicle.VehicleTypeId;
            string customerId = registeredVehicle.CustomerId;

            //vehicleType = await KzParkingApiHelper.GetVehicleTypeById(vehicleTypeId.ToString());
            vehicleType = (await AppData.ApiServer.GetVehicleTypeByIdAsync(vehicleTypeId.ToString())).Item1;
            switch (vehicleType.Type)
            {
                case VehicleBaseType.Car:
                    vehicleImage = ucCarLpr?.GetFullCurrentImage();
                    break;
                default:
                    vehicleImage = ucMotoLpr?.GetFullCurrentImage();
                    break;
            }
            if (!string.IsNullOrEmpty(customerId))
            {
                //customer = await KzParkingApiHelper.GetCustomerById(customerId);
                customer = (await AppData.ApiServer.GetCustomerByIdAsync(customerId)).Item1;
            }

            ClearView();
            var imageKey = BaseLane.GetBaseImageKey(this.lane.name, "", selectedPlate, DateTime.Now);
            var imageKeys = new List<string>() {
                                        imageKey + "_OVERVIEWIN.jpeg",
                                        imageKey + "_VEHICLEIN.jpeg",
                                        imageKey + "_LPRIN.jpeg", };
            //var responseWithForce = await KzParkingApiHelper.PostCheckInAsync(lane.id, selectedPlate, null, imageKeys, true);
            eventIn = await AppData.ApiServer.PostCheckInAsync(lane.id, selectedPlate, null, imageKeys, true, null, txtNote.Text);
            if (eventIn == null)
            {
                goto LOI_HE_THONG;
            }
            //if (responseWithForce.metadata.success == false)
            //{
            //    errorMessage = ApiInternalErrorMessages.ToString(ApiInternalErrorMessages.GetFromName(responseWithForce.metadata.message.code));
            //    goto SU_KIEN_LOI;
            //}
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
                ExcecuteUnvalidEvent(null, null, vehicleType.Type, selectedPlate, DateTime.Now, errorMessage, null, "");
                return;
            }
        SU_KIEN_HOP_LE:
            {

                await ExcecuteValidEvent(null, null, vehicleType.Type, selectedPlate, DateTime.Now, overviewImage, vehicleImage, null, imageKey, eventIn, false, imageKeys, new List<Image>());
                if (lastEvent != null)
                {
                    //var identity = await KzParkingApiHelper.GetIdentityById(eventIn.IdentityId);
                    var identity = (await AppData.ApiServer.GetIdentityByIdAsync(eventIn.identity.Id)).Item1;
                    //await KzParkingApiHelper.CreateAlarmAsync(identity.Id, this.lane.id, lastEvent.PlateNumber, AbnormalCode.ManualEvent,
                    //                                     imageKey, true,
                    //                                     identity?.IdentityGroupId, lastEvent?.customer?.Id,
                    //                                     lastEvent?.RegisteredVehicle?.Id, "");
                    await AppData.ApiServer.CreateAlarmAsync(identity.Id, this.lane.id, lastEvent.PlateNumber, EmAbnormalCode.ManualEvent,
                                                       imageKey, true,
                                                       identity?.IdentityGroupId, lastEvent?.customer?.Id,
                                                       lastEvent?.RegisteredVehicle?.Id, "");
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
                (DateTime.Now - lastEvent.DatetimeIn)?.TotalSeconds >= StaticPool.appOption.AllowBarrieDelayOpenTime)
            {
                string imageKey = BaseLane.GetBaseImageKey(this.lane.name, "", "", DateTime.Now);
                //await KzParkingApiHelper.CreateAlarmAsync("", this.lane.id, "", AbnormalCode.OpenBarrierByKeyboard, imageKey, true,
                //                                          "", "", "", "");
                await AppData.ApiServer.CreateAlarmAsync("", this.lane.id, "", EmAbnormalCode.OpenBarrierByKeyboard, imageKey, true,
                                                        "", "", "", "");
                SaveAllCameraImage(imageKey);
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
            panelOversizeCam.Size = panelCameras.Size;
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
            onControlSizeChangeEvent?.Invoke(this, new ControlSizeChangedEventArgs()
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
        private async Task LoadGoodsType()
        {
            try
            {
                var weighingForms = await KzScaleApiHelper.GetWeighingForms();
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
                    cbGoodsType.SelectedIndex = cbGoodsType.Items.Count > 0 ? 0 : -1;
                    cbGoodsType.SelectedIndexChanged += CbGoodsType_SelectedIndexChanged;
                }
            }
            catch (Exception)
            {
            }
        }
        private async Task<Tuple<bool, Identity?>> IsValidIdentity(string cardNumber)
        {
            var identityResponse = await AppData.ApiServer.GetIdentityByCodeAsync(cardNumber);
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
                                            PathManagement.laneShortcutConfigPath(this.lane.id)) ?? new LaneInShortcutConfig();
            controllerShortcutConfigs = NewtonSoftHelper<List<ControllerShortcutConfig>>.DeserializeObjectFromPath(
                                            PathManagement.laneControllerShortcutConfigPath(this.lane.id)) ?? new List<ControllerShortcutConfig>();
        }

        /// <summary>
        /// Hiển thị giao diện như lần cuối cùng sử dụng
        /// </summary>
        public void DisplayUIConfig()
        {
            this.SuspendLayout();
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
                if (this.splitContainerMain.Panel2Collapsed)
                {
                    this.splitContainerMain.Height = this.laneDisplayConfig.splitContainerMain;
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
                    await ExcecuteCardEvent(cardEvent);
                }
                else if (e is InputEventArgs inputEvent)
                {
                    await ExcecuteInputEvent(inputEvent);
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
        }
        #endregion END PUBLIC FUNCTION
    }
}