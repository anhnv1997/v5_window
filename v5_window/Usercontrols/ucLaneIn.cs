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
using iParkingv5.Printer.OfficeHaus;
using iParkingv5_window.Forms.DataForms;
using iParkingv5_window.Forms.SystemForms;
using iParkingv5_window.Forms.ThirdPartyForms.OfficeHausForms;
using iParkingv6.Objects.Datas;
using Kztek.Helper;
using Kztek.Tool;
using Kztek.Tool.LogDatabases;
using Kztek.Tools;
using System.Data;
using System.Windows.Forms;
using static iParkingv5.Objects.Configs.LaneDirectionConfig;
using static iParkingv5.Objects.Enums.ParkingImageType;
using static iParkingv5.Objects.Enums.PrintHelpers;
using static iParkingv5.Objects.Enums.VehicleType;
using static Kztek.Tool.LogDatabases.tblSystemLog;

namespace iParkingv5_window.Usercontrols
{
    public partial class ucLaneIn : ucBaseLane, iLane, IDisposable
    {
        #region PROPERTIES

        #region THIRD - PARTY
        HausVisitor? lastHausVistor = null;
        #endregion End THIRD - PARTY

        #region Config
        private LaneInShortcutConfig? laneInShortcutConfig = null;
        #endregion

        #region EVENT
        EventInData? lastEvent = null;
        #endregion End EVENT

        #region OTHER
        public static Image defaultImg = Image.FromFile(frmMain.defaultImagePath);
        #endregion End OTHER

        #endregion End PROPERTIES

        #region FORMS - OK
        public ucLaneIn(Lane lane, LaneDisplayConfig? laneDisplayConfig, LaneDirectionConfig laneDirectionConfig)
        {
            InitializeComponent();

            this.lane = lane;
            this.laneDisplayConfig = laneDisplayConfig;
            this.laneDirectionConfig = laneDirectionConfig;

            this.DoubleBuffered = true;

            tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS, "Init Lane");
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
            tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS, "Dispose Lane");

            foreach (var cam in this.camBienSoOTODuPhongs)
            {
                cam?.Stop();
            }
            foreach (var cam in this.camBienSoXeMayDuPhongs)
            {
                cam?.Stop();
            }
            ucEventCount1.Stop();
            timerRefreshUI.Enabled = false;
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion End FORMS

        #region EVENT - OK
        public async void OnKeyPress(Keys keys)
        {
            await semaphoreSlimOnKeyPress.WaitAsync();
            tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS, $"KeyPress {keys.ToString()}");

            try
            {
                if (keys == Keys.F9)
                {
                    this.AllowDesignRealtime(!this.IsAllowDesignRealtime);
                }

                await CheckLaneInShortcutConfig(keys);
                await CheckControllerShortcutConfig(keys);
            }
            catch (Exception ex)
            {
                tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS, $"KeyPress {keys.ToString()}", ex);
            }
            finally
            {
                semaphoreSlimOnKeyPress.Release();
            }
        }

        /// <summary>
        /// Có sự kiện từ bộ điều khiển hoặc người dùng
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public async Task OnNewEvent(EventArgs e)
        {
            StopTimeRefreshUI();
            await semaphoreSlimOnNewEvent.WaitAsync();
            lastEvent = null;
            try
            {
                if (e is CardEventArgs cardEvent)
                {
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.PROCESS,
                                         $"Get New Card Event", cardEvent);
                    string controlUnitId = cardEvent.DeviceId;
                    int readerIndex = cardEvent.ReaderIndex;
                    await ExcecuteCardEvent(cardEvent);
                }
                else if (e is InputEventArgs inputEvent)
                {
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.PROCESS,
                                         $"Get New Input Event", inputEvent);
                    await ExcecuteInputEvent(inputEvent, lblResult);
                }
            }
            catch (Exception ex)
            {
                tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS, "OnNewEvent", ex);
            }
            finally
            {
                semaphoreSlimOnNewEvent.Release();
                StartTimerRefreshUI();
            }
        }

        /// <summary>
        /// Sự kiện xảy ra khi xe đi qua vòng từ
        /// </summary>
        /// <param name="ie"></param>
        /// <returns></returns>
        public override async Task ExcecuteLoopEvent(InputEventArgs ie)
        {
            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                 $"{this.lane.name}.Loop.{ie.InputIndex} - START");
            ClearView();

            EventInData? eventIn = null;

            //Danh sách biến sử dụng
            Image? overviewImg = null;
            List<Image?> optionalImages = new();
            bool isAlarm = false;
            var lprResult = new LoopLprResult();

            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                 $"{this.lane.name}.Loop.{ie.InputIndex} - START DETECT PLATE");
            lblResult.UpdateResultMessage("Nhận dạng biển số", ProcessColor);
            overviewImg = ucOverView?.GetFullCurrentImage();
            lprResult = await LoopLprDetection();
            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                 $"{this.lane.name}.Loop.{ie.InputIndex} - END DETECT PLATE");

            //Hiển thị hình ảnh
            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                 $"{this.lane.name}.Loop.{ie.InputIndex} - DISPLAY EVENT IMAGE");
            BaseLane.ShowImage(picVehicleImage, lprResult.VehicleImage);
            BaseLane.ShowImage(picOverviewImage, overviewImg);
            DisplayDetectedPlate(lprResult.PlateNumber, lprResult.LprImage);

            if (lprResult.Vehicle == null)
            {
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                $"{this.lane.name}.Loop.{ie.InputIndex} - VEHICLE NULL - END");
                lblResult.UpdateResultMessage("Phương tiện chưa được đăng ký trong hệ thống", ErrorColor);
                return;
            }

            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                $"{this.lane.name}.Loop.{ie.InputIndex} - START CHECK IN");
            lblResult.UpdateResultMessage("Đang check in..." + lprResult.PlateNumber, ProcessColor);
            string customerId = lprResult.Vehicle.CustomerId;
            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                $"{this.lane.name}.Loop.{ie.InputIndex} - GET CUSTOMER INFO");
            Customer? customer = string.IsNullOrEmpty(customerId) ?
                                           null : customer = (await AppData.ApiServer.parkingDataService.GetCustomerByIdAsync(customerId))?.Item1;

            List<EmParkingImageType> validImageTypes = BaseLane.GetValidImageType(overviewImg, lprResult.VehicleImage, lprResult.LprImage);

            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                $"{this.lane.name}.Loop.{ie.InputIndex} - SEND CHECK IN NORMAL REQUEST");
            var eventInResponse = await AppData.ApiServer.parkingProcessService.PostCheckInAsync(lane.Id, lprResult.PlateNumber, null, validImageTypes,
                                                                                                  false, lprResult.Vehicle);

            var checkInOutResponse = CheckEventInReponse(eventInResponse, customer, lprResult.Vehicle.vehicleType, lprResult.PlateNumber, false);
            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                 $"{this.lane.name}.Loop.{ie.InputIndex} - CHECK EVENT IN NORMAL RESPONSE", checkInOutResponse);

            if (!checkInOutResponse.IsValidEvent)
            {
                if (!checkInOutResponse.IsContinueExcecute)
                {
                    return;
                }
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                 $"{this.lane.name}.Loop.{ie.InputIndex} - SHOW CONFIRM REQUEST", checkInOutResponse.ErrorMessage);
                bool isConfirm = new frmConfirm(checkInOutResponse.ErrorMessage).ShowDialog() == DialogResult.OK;
                if (!isConfirm)
                {
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                 $"{this.lane.name}.Loop.{ie.InputIndex} - NOT CONFIRM, END PROCES");
                    return;
                }
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                $"{this.lane.name}.Loop.{ie.InputIndex} - SEND CHECK IN FORCE REQUEST");
                eventInResponse = await AppData.ApiServer.parkingProcessService.PostCheckInAsync(lane.Id, lprResult.PlateNumber, null, validImageTypes,
                                                                                                  true, lprResult.Vehicle);
                checkInOutResponse = CheckEventInReponse(eventInResponse, customer, lprResult.Vehicle.vehicleType, lprResult.PlateNumber, true);
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                  $"{this.lane.name}.Loop.{ie.InputIndex} - CHECK EVENT OUT FORCE RESPONSE", checkInOutResponse);
                //Sau khi force vẫn không thành công, kết thúc quy trình
                if (!checkInOutResponse.IsValidEvent)
                {
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                 $"{this.lane.name}.Loop.{ie.InputIndex} - INVALID EVENT, END PROCESS");
                    return;
                }
            }

            eventIn = checkInOutResponse.eventIn!;
            if (eventIn.OpenBarrier)
            {
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                       $"{this.lane.name}.Loop.{ie.InputIndex} - OPEN BARRIE");
                ControllerInLane? controllerInLane = (from _controllerInLane in this.lane.controlUnits
                                                      where _controllerInLane.controlUnitId == ie.DeviceId
                                                      select _controllerInLane).FirstOrDefault();
                _ = BaseLane.OpenBarrieByControllerId(ie.DeviceId, controllerInLane, this);
            }
            else
            {
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                       $"{this.lane.name}.Loop.{ie.InputIndex} - SHOW CONFIRM OPEN BARRIE REQUEST");
                bool isOpenBarrie = new frmConfirm("Bạn có muốn mở Barrie không?").ShowDialog() == DialogResult.OK;
                if (isOpenBarrie)
                {
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                         $"{this.lane.name}.Loop.{ie.InputIndex} - CONFIRM OPEN BARRIE");
                    ControllerInLane? controllerInLane = (from _controllerInLane in this.lane.controlUnits
                                                          where _controllerInLane.controlUnitId == ie.DeviceId
                                                          select _controllerInLane).FirstOrDefault();
                    _ = BaseLane.OpenBarrieByControllerId(ie.DeviceId, controllerInLane, this);
                }
                else
                {
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                       $"{this.lane.name}.Loop.{ie.InputIndex} - NOT CONFIRM OPEN BARRIE");
                }
            }
            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                 $"{this.lane.name}.Loop.{ie.InputIndex} - Display Valid Event");
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
            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.EXIT_EVENT,
                                $"{this.lane.name}.Exit.{ie.InputIndex}");
            string plateNumber = lastEvent?.PlateNumber ?? "";
            bool isOverAllowTime = ((DateTime.Now - lastEvent?.DateTimeIn)?.TotalSeconds ?? -1) >= StaticPool.appOption.AllowBarrieDelayOpenTime;
            if (lastEvent == null || isOverAllowTime)
            {
                var imageData = GetAllCameraImage();
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.EXIT_EVENT,
                                $"{this.lane.name}.Exit.{ie.InputIndex} - SAVE EXIT ABNOMAL EVENT");
                await SaveManualAbnormalEvent(plateNumber, lastEvent?.Identity, lastEvent?.IdentityGroup, imageData, true, abnormalCode: AbnormalCode.OpenBarrierByButton);
            }
        }

        /// <summary>
        /// Sự kiện xảy ra khi người dùng quẹt thẻ trên đầu đọc, hoặc đầu đọc xa phát hiện thẻ
        /// </summary>
        /// <param name="ce"></param>
        /// <returns></returns>
        public async Task ExcecuteCardEvent(CardEventArgs ce)
        {
            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                            $"{this.lane.name}.Card.{ce.PreferCard} - START");
            if (!this.CheckNewCardEvent(this.lane, ce, out ControllerInLane? controllerInLane, out int thoiGianCho))
            {
                if (thoiGianCho > 0)
                {
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                              $"{this.lane.name}.Card.{ce.PreferCard} - In Waiting Time: {thoiGianCho}s");
                    lblResult.UpdateResultMessage($"Đang trong thời gian chờ, vui lòng quẹt lại sau {thoiGianCho}s", ProcessColor);
                    return;
                }
            }

            ClearView();
            lblResult.UpdateResultMessage("Đang kiểm tra thông tin sự kiện quẹt thẻ..." + ce.PreferCard, ProcessColor);

            #region Kiểm tra thông tin định danh
            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                              $"{this.lane.name}.Card.{ce.PreferCard} - Check Identity");
            var identityResponse = await IsValidIdentity(ce.PreferCard);

            if (!identityResponse.Item1)
            {
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                              $"{this.lane.name}.Card.{ce.PreferCard} - Invalid Identity");
                return;
            }
            Identity? identity = identityResponse.Item2!;
            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                        $"{this.lane.name}.Card.{ce.PreferCard} - Check Identity Detail & Identity Group");
            var identityTask = AppData.ApiServer.parkingDataService.GetIdentityByIdAsync(identity.Id);
            var identityGroupTask = AppData.ApiServer.parkingDataService.GetIdentityGroupByIdAsync(identity.IdentityGroupId.ToString());
            await Task.WhenAll(identityTask, identityGroupTask);

            //Cần gọi GET BY ID để lấy thông tin phương tiện đăng ký
            identity = identityTask.Result.Item1;
            if (identity == null || string.IsNullOrEmpty(identity.Id) || identity.Id == Guid.Empty.ToString())
            {
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                     $"{this.lane.name}.Card.{ce.PreferCard} - Invalid Identity");
                lblResult.UpdateResultMessage("Không đọc được thông tin định danh, vui lòng thử lại", ErrorColor);
                return;
            }
            #endregion End kiểm tra thông tin định danh

            #region Kiểm tra thông tin nhóm định danh
            IdentityGroup? identityGroup = identityGroupTask.Result.Item1;
            if (identityGroup == null || identityGroup.Id == Guid.Empty)
            {
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                     $"{this.lane.name}.Card.{ce.PreferCard} - Invalid IdentityGroup");
                lblResult.UpdateResultMessage("Không đọc được thông tin nhóm định danh, vui lòng thử lại", ErrorColor);
                return;
            }
            #endregion End kiểm tra thông tin nhóm định danh

            #region Kiểm tra thông tin loại phương tiện
            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                     $"{this.lane.name}.Card.{ce.PreferCard} - Check Vehicle Type");
            VehicleBaseType vehicleBaseType = identityGroup.VehicleType;
            if (vehicleBaseType == VehicleBaseType.Unknown)
            {
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                     $"{this.lane.name}.Card.{ce.PreferCard} - Invalid Vehicle Type");
                lblResult.UpdateResultMessage("Thông tin loại phương tiện không hợp lệ, vui lòng kiểm tra thông tin định danh", ErrorColor);
                return;
            }
            #endregion End kiểm tra thông tin loại phương tiện
            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                 $"{this.lane.name}.Card.{ce.PreferCard} - Get Event Image");
            Image? overviewImg = ucOverView?.GetFullCurrentImage();
            Image? vehicleImg = null;

            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                 $"{this.lane.name}.Card.{ce.PreferCard} - Get Plate");
            Image? lprImage = GetPlate(ce, ref overviewImg, ref vehicleImg, vehicleBaseType, lblResult, txtPlate, picOverviewImage, picVehicleImage, picLprImage);

            //Đọc thông tin loại phương tiện
            lblResult.UpdateResultMessage("Đang kiểm tra thông tin..." + ce.PreferCard, ProcessColor);
            try
            {
                bool isDailyCard = identityGroup.Type == IdentityGroupType.Daily;
                if (isDailyCard)
                {
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                 $"{this.lane.name}.Card.{ce.PreferCard} - Start Non Month Card Process");
                    await ExcecuteNonMonthCardEventIn(identity, identityGroup, vehicleBaseType, ce.PlateNumber,
                                                      ce, controllerInLane,
                                                      overviewImg, vehicleImg, lprImage);
                }
                else
                {
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                 $"{this.lane.name}.Card.{ce.PreferCard} - Start Month Card Process");
                    await ExcecuteMonthCardEventIn(identity, identityGroup, vehicleBaseType, ce.PlateNumber,
                                                  ce, controllerInLane,
                                                  overviewImg, vehicleImg, lprImage);
                }
            }
            catch (Exception ex)
            {
                lblResult.UpdateResultMessage("Gặp lỗi trong quá trình xử lý, vui lòng thử lại", ErrorColor);
                tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS, "ExcecuteCardEvent", ex);
            }
        }
        #endregion End EVENT

        #region Xử lý sự kiện thẻ
        private async Task ExcecuteMonthCardEventIn(Identity identity, IdentityGroup identityGroup,
                                                    VehicleBaseType vehicleType, string plateNumber,
                                                    CardEventArgs ce, ControllerInLane? controllerInLane,
                                                    Image? overviewImg, Image? vehicleImg, Image? lprImage)
        {
            bool isAlarm = false;
            string errorMessage = string.Empty;
            List<EmParkingImageType> validImageTypes = BaseLane.GetValidImageType(overviewImg, vehicleImg, lprImage);
            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                               $"{this.lane.name}.Card.{ce.PreferCard} - Check Valid Register Vehicle");
            if (identity.Vehicles == null)
            {
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                              $"{this.lane.name}.Card.{ce.PreferCard} - Invalid Register Vehicle, End Process");

                lblResult.UpdateResultMessage("Thẻ tháng chưa đăng ký phương tiện", ErrorColor);
                return;
            }

            if (identity.Vehicles.Count == 0)
            {
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                               $"{this.lane.name}.Card.{ce.PreferCard} - Invalid Register Vehicle, End Process");

                lblResult.UpdateResultMessage("Thẻ tháng chưa đăng ký phương tiện", ErrorColor);
                return;
            }

            EventInData? eventIn = null;
            if (string.IsNullOrEmpty(plateNumber) && identityGroup.PlateNumberValidation != (int)EmPlateCompareRule.UnCheck)
            {
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                    $"{this.lane.name}.Card.{ce.PreferCard} - Empty Plate && Register Vehicle Count = {identity.Vehicles.Count}",
                                    identity.Vehicles);

                isAlarm = true;
                bool isConfirm = false;
                if (identity.Vehicles.Count == 1)
                {
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                         $"{this.lane.name}.Card.{ce.PreferCard} - Show Confirm Plate Request");

                    string message = "Không nhận diện được biển số, bạn có muốn cho xe vào bãi?";
                    frmConfirmIn frmConfirmIn = new frmConfirmIn(message, identity, identityGroup, identity.Vehicles[0].customer,
                                                                 identity.Vehicles[0], plateNumber, vehicleImg, overviewImg);
                    isConfirm = frmConfirmIn.ShowDialog() == DialogResult.OK;
                    if (isConfirm)
                    {
                        plateNumber = identity.Vehicles[0].PlateNumber;
                        isAlarm = true;
                    }
                }
                else
                {
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                         $"{this.lane.name}.Card.{ce.PreferCard} - Show Select Plate Request");

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
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                         $"{this.lane.name}.Card.{ce.PreferCard} - Not Confirm, End Process");

                    ClearView();
                    return;
                }
            }

            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                         $"{this.lane.name}.Card.{ce.PreferCard} - Send Check In Normal Request");

            var eventInResponse = await AppData.ApiServer.parkingProcessService.PostCheckInAsync(lane.Id, plateNumber, identity, validImageTypes, false, null, "");

            var checkInOutResponse = CheckEventInReponse(eventInResponse, null, vehicleType, plateNumber, false);
            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                         $"{this.lane.name}.Card.{ce.PreferCard} - Check Event In Response", checkInOutResponse);

            if (!checkInOutResponse.IsValidEvent)
            {
                if (!checkInOutResponse.IsContinueExcecute)
                {
                    return;
                }
                bool isConfirm = false;

                if (identity.Vehicles.Count == 1)
                {
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                         $"{this.lane.name}.Card.{ce.PreferCard} - Show Confirm Plate Request");

                    string message = "Biển số không khớp với biển số đăng ký" + "\r\nBạn có muốn cho xe vào bãi?";
                    frmConfirmIn frmConfirmIn = new frmConfirmIn(message, identity, identityGroup, identity.Vehicles[0].customer, identity.Vehicles[0],
                                                                 plateNumber, vehicleImg, overviewImg);
                    isConfirm = frmConfirmIn.ShowDialog() == DialogResult.OK;
                    plateNumber = frmConfirmIn.updatePlate;
                }
                else
                {
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                        $"{this.lane.name}.Card.{ce.PreferCard} - Show Select Plate Request");

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
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                         $"{this.lane.name}.Card.{ce.PreferCard} - Not Confirm, End Process");
                    return;
                }
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                       $"{this.lane.name}.Card.{ce.PreferCard} - Send Check In Force Request");

                eventInResponse = await AppData.ApiServer.parkingProcessService.PostCheckInAsync(lane.Id, plateNumber, identity, validImageTypes, true, null, "");
                checkInOutResponse = CheckEventInReponse(eventInResponse, null, vehicleType, plateNumber, true);
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                         $"{this.lane.name}.Card.{ce.PreferCard} - Check Event Out Force Response", checkInOutResponse);

                if (!checkInOutResponse.IsValidEvent)
                {
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                       $"{this.lane.name}.Card.{ce.PreferCard} - Invalid Event, End Process");

                    return;
                }
            }

            eventIn = checkInOutResponse.eventIn!;
            if (eventIn.OpenBarrier)
            {
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                       $"{this.lane.name}.Card.{ce.PreferCard} - Open Barrie");

                _ = BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane, this);
            }
            else
            {
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                        $"{this.lane.name}.Card.{ce.PreferCard} - Show Confirm Open Barrie Request");

                string message = "Bạn có muốn mở Barrie?";
                frmConfirm frmConfirm = new frmConfirm(message);
                bool isOpenBarrie = frmConfirm.ShowDialog() == DialogResult.OK;
                if (isOpenBarrie)
                {
                    _ = BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane, this);
                }
                else
                {
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                            $"{this.lane.name}.Card.{ce.PreferCard} - Not Confirm Open Barrie");
                }
            }
            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                            $"{this.lane.name}.Card.{ce.PreferCard} - Display Valid Event");

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
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                 $"{this.lane.name}.Card.{ce.PreferCard} - Empty Plate - Show Confirm Request");
                    frmConfirm frmConfirm = new frmConfirm(message);
                    bool isConfirm = frmConfirm.ShowDialog() == DialogResult.OK;
                    frmConfirm.Dispose();
                    if (!isConfirm)
                    {
                        tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                 $"{this.lane.name}.Card.{ce.PreferCard} - Not Confirm");

                        ClearView();
                        return;
                    }
                }
            }
            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                 $"{this.lane.name}.Card.{ce.PreferCard} - Send Check In Normal Request");
            var eventInResponse = await AppData.ApiServer.parkingProcessService.PostCheckInAsync(lane.Id, plateNumber, identity, validImageTypes, false, null, "");
            var checkInOutResponse = CheckEventInReponse(eventInResponse, null, vehicleType, plateNumber, false);

            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                $"{this.lane.name}.Card.{ce.PreferCard} - Check Check In Normal Response", checkInOutResponse);

            if (!checkInOutResponse.IsValidEvent)
            {
                isAlarm = true;
                if (checkInOutResponse.IsContinueExcecute)
                {
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                               $"{this.lane.name}.Card.{ce.PreferCard} - Show Confirm Request", checkInOutResponse.ErrorMessage);

                    frmConfirm frmConfirm = new frmConfirm(checkInOutResponse.ErrorMessage);
                    bool isConfirm = frmConfirm.ShowDialog() == DialogResult.OK;
                    frmConfirm.Dispose();
                    if (!isConfirm)
                    {
                        tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                               $"{this.lane.name}.Card.{ce.PreferCard} - Not Confirm, End Process");

                        return;
                    }
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                               $"{this.lane.name}.Card.{ce.PreferCard} - Confirm, Send Check In Force Request");

                    eventInResponse = await AppData.ApiServer.parkingProcessService.PostCheckInAsync(lane.Id, plateNumber, identity, validImageTypes, true, null, "");

                    checkInOutResponse = CheckEventInReponse(eventInResponse, null, vehicleType, plateNumber, true);
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                $"{this.lane.name}.Card.{ce.PreferCard} - Check Event In Force Response", checkInOutResponse);

                    if (!checkInOutResponse.IsValidEvent)
                    {
                        tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                             $"{this.lane.name}.Card.{ce.PreferCard} - Invalid Event, End Process", checkInOutResponse);

                        return;
                    }
                }
                else
                {
                    return;
                }
            }

            eventIn = checkInOutResponse.eventIn!;
            if (eventIn.OpenBarrier)
            {
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                              $"{this.lane.name}.Card.{ce.PreferCard} - Open Barrie");

                _ = BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane, this);
            }
            else
            {
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                               $"{this.lane.name}.Card.{ce.PreferCard} - Show Confirm Open Barrie Request");

                frmConfirm frmConfirm = new frmConfirm("Bạn có muốn mở Barrie?");
                bool isOpenBarrie = frmConfirm.ShowDialog() == DialogResult.OK;
                if (isOpenBarrie)
                {
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                               $"{this.lane.name}.Card.{ce.PreferCard} - Confirm Open Barrie");

                    _ = BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane, this);
                }
                else
                {
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                              $"{this.lane.name}.Card.{ce.PreferCard} - Not Confirm Open Barrie");
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
            tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS,
                                 $"{this.lane.name}.EventIn.{eventIn.Id} - Display Event In Info");
            DisplayEventInfo(eventTime, detectPlate, identity, identityGroup, vehicleType, customer, registeredVehicle, null);

            tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS,
                                 $"{this.lane.name}.EventIn.{eventIn.Id} - Display Led");
            BaseLane.DisplayLed(detectPlate, eventTime, identity, identityGroup, "Xin mời qua", this.lane.Id, "0");

            lastEvent = eventIn;

            tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS,
                                 $"{this.lane.name}.EventIn.{eventIn.Id} - Save Image");
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

            _ = BaseLane.SaveImage(eventIn.images, imageDatas);

            if (isAlarm)
            {
                tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS,
                              $"{this.lane.name}.EventIn.{eventIn.Id} - Save Alarm");
                string alarmStr = "Cảnh báo biển số";
                var response = await AppData.ApiServer.parkingProcessService.CreateAlarmAsync(identity?.Code, this.lane.Id, detectPlate, AbnormalCode.InvalidPlateNumber,
                                                            imageDatas, true, identityGroup?.Id.ToString(), "", "", alarmStr);
                if (response != null)
                {
                    _ = BaseLane.SaveImage(response.images, imageDatas);
                }
            }

            if (this.laneDirectionConfig.IsDisplayLastEvent)
            {
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
                    ucLastEventInfos[0].UpdateEventInfo(eventIn.Id, eventIn.images, lprImage ?? vehicleImg);
                }));
            }
        }
        #endregion End xử lý sự kiện thẻ

        #region CONTROLS IN FORM
        #region THIRD - PARTY - OK
        private async void btnRegister_Click(object? sender, EventArgs e)
        {
            tblUserLog.SaveLog(this.lane.name, $"User Click To Open Register Screen");

            var frmAddVisitor = new frmAddVisitor();
            if (frmAddVisitor.ShowDialog() == DialogResult.OK)
            {
                string identityGroupCode = frmAddVisitor.IdentityGroupCode;
                string plateNumber = frmAddVisitor.PlateNumber;
                lblResult.UpdateResultMessage("Đang lưu thông tin khách hàng...", ProcessColor);
                lastHausVistor = await ThirdPartyService.AddVisitor(identityGroupCode, plateNumber);
                if (lastHausVistor == null)
                {
                    lblResult.UpdateResultMessage("Lưu thông tin không thành công, vui lòng thử lại!", ErrorColor);
                }
                else
                {
                    lblResult.UpdateResultMessage("Lưu thông tin thành công.", SuccessColor);
                }
            }
        }
        public async void printQR(CardEventArgs ce, HausQR qrData)
        {
            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.ThirtParty, tblSystemLog.EmSystemActionDetail.PROCESS,
                                $"{this.lane.name}.Card.{ce.PreferCard} - Print QR Request");

            await this.OnNewEvent(ce);
            if (lastEvent == null)
            {
                lblResult.UpdateResultMessage("Lưu thông tin không thành công, vui lòng thử lại!", ErrorColor);
            }
            else
            {
                var printer = new OfficeHausPrinter();
                string baseContent = File.ReadAllText(PathManagement.hausQRPath());
                lblResult.UpdateResultMessage("Lấy thông tin thành công.", SuccessColor);
                printer.printQR(baseContent, qrData.QrCode ?? "");
            }
        }
        private async void btnPrintQR_Click(object? sender, EventArgs e)
        {
            tblUserLog.SaveLog(this.lane.name, $"User Click To Print QR");

            lastEvent = null;
            lblResult.UpdateResultMessage("Đang lấy thông tin QR...", ProcessColor);
            if (lastHausVistor == null)
            {
                lblResult.UpdateResultMessage("Không có thông tin khách đăng ký, vui lòng thử lại!", ErrorColor);
                return;
            }
            var qrData = await ThirdPartyService.GetQRData(lastHausVistor);
            if (qrData == null || string.IsNullOrEmpty(qrData.QrCode))
            {
                lblResult.UpdateResultMessage("Lấy thông tin không thành công, vui lòng thử lại!", ErrorColor);
            }
            else
            {
                foreach (var item in this.lane.controlUnits)
                {
                    if (item.readers.Length > 0)
                    {
                        CardEventArgs ce = new CardEventArgs();
                        ce.DeviceId = item.controlUnitId;
                        ce.ReaderIndex = item.readers[0];
                        ce.PreferCard = lastHausVistor.IdentityCode;
                        await this.OnNewEvent(ce);
                        break;
                    }
                }
                if (lastEvent == null)
                {
                    lblResult.UpdateResultMessage("Lưu thông tin không thành công, vui lòng thử lại!", ErrorColor);
                    return;
                }
                var printer = new OfficeHausPrinter();
                string baseContent = File.ReadAllText(PathManagement.hausQRPath());
                lblResult.UpdateResultMessage("Lấy thông tin thành công.", SuccessColor);
                printer.printQR(baseContent, qrData.QrCode ?? "");
            }
        }
        #endregion End THIRD - PARTY

        #region ACTION - OK
        /// <summary>
        /// Hiển thị thông tin sự kiện lên giao diện
        /// </summary>
        /// <param name="eventId"></param>
        private async void UcTopEvent_onChoosen(object? sender, string eventId)
        {
            try
            {
                tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS,
                                     $"{this.lane.name}.EventIn.{eventId}  - User Click To UcTopEvent");
                tblUserLog.SaveLog(this.lane.name, $"User Click To UC {eventId}");

                StopTimeRefreshUI();
                if (string.IsNullOrEmpty(eventId))
                {
                    ClearView();
                    return;
                }
                DateTime now = DateTime.Now;
                DateTime startTime = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
                DateTime endTime = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);

                tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS,
                                     $"{this.lane.name}.EventIn.{eventId}  - Get Report By EventInId");
                var report = await AppData.ApiServer.reportingService.GetEventIns("", startTime, endTime, "", "", "", "", true, 0, 1, eventId);
                if (report == null || report.data.Count == 0)
                {
                    tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS,
                                  $"{this.lane.name}.EventIn.{eventId}  - Report InValid, End Process");
                    ClearView();
                    return;
                }
                var eventInfo = report.data[0];
                lastEvent = new EventInData(eventInfo);
                tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS,
                                   $"{this.lane.name}.EventIn.{eventId}  - Event Info", eventInfo);
                tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS,
                                     $"{this.lane.name}.EventIn.{eventId}  - Get EventIn Image");

                if (eventInfo.images != null)
                {
                    ImageData? overviewImgData = eventInfo.images.ContainsKey(EmParkingImageType.Overview) ?
                                                            eventInfo.images[EmParkingImageType.Overview][0] : null;
                    ImageData? vehicleImgData = eventInfo.images.ContainsKey(EmParkingImageType.Vehicle) ?
                                                            eventInfo.images[EmParkingImageType.Vehicle][0] : null;
                    ImageData? lprImgData = eventInfo.images.ContainsKey(EmParkingImageType.Plate) ?
                                                           eventInfo.images[EmParkingImageType.Plate][0] : null;

                    var overviewInTask = AppData.ApiServer.parkingProcessService.GetImageUrl(overviewImgData?.bucket ?? "", overviewImgData?.objectKey ?? "");
                    var vehicleInTask = AppData.ApiServer.parkingProcessService.GetImageUrl(vehicleImgData?.bucket ?? "", vehicleImgData?.objectKey ?? "");
                    var lprInTask = AppData.ApiServer.parkingProcessService.GetImageUrl(lprImgData?.bucket ?? "", lprImgData?.objectKey ?? "");

                    await Task.WhenAll(overviewInTask, vehicleInTask, lprInTask);

                    picLprImage.ShowImageUrlAsync(lprInTask.Result);
                    picVehicleImage.ShowImageUrlAsync(vehicleInTask.Result);
                    picOverviewImage.ShowImageUrlAsync(overviewInTask.Result);
                }
                tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS,
                                  $"{this.lane.name}.EventIn.{eventId}  - Display Event Info");
                DisplayEventInfo(eventInfo.DateTimeIn ?? DateTime.Now, eventInfo.PlateNumber, eventInfo.Identity, eventInfo.IdentityGroup,
                               eventInfo.IdentityGroup.VehicleType, eventInfo.customer, eventInfo.vehicle, null);
                this.Invoke(new Action(() =>
                {
                    txtPlate.Text = eventInfo.PlateNumber;
                }));
            }
            catch (Exception ex)
            {
                tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS, "UcTopEvent_onChoosen", ex);
            }
            finally
            {
                StartTimerRefreshUI();
            }
        }

        /// <summary>
        /// Mở giao diện cấu hỉnh làn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picSetting_Click(object? sender, EventArgs e)
        {
            tblUserLog.SaveLog(this.lane.name, $"User Click To Open Setting Screen");

            var frmConfirmPassword = new frmConfirmPassword();
            if (frmConfirmPassword.ShowDialog() != DialogResult.OK)
            {
                return;
            }

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

            string configPath = PathManagement.appLaneDirectionConfigPath(this.lane.Id);
            var newConfig = NewtonSoftHelper<LaneDirectionConfig>.DeserializeObjectFromPath(configPath) ?? LaneDirectionConfig.CreateDefault();

            if (laneDirectionConfig.IsSameConfig(newConfig))
            {
                return;
            }

            laneDirectionConfig = newConfig;
            panelDisplayLastEvent.Visible = laneDirectionConfig.IsDisplayLastEvent;
            SetUserDisplayConfig();
        }

        /// <summary>
        /// Ghi vé vào=> Chọn vé cần ghi ==> Kích hoạt sự kiện như sự kiện quẹt thẻ
        /// Lưu sự kiện cảnh báo MANUAL EVENT
        /// </summary>
        private async void BtnWriteIn_Click(object? sender, EventArgs e)
        {
            tblUserLog.SaveLog(this.lane.name, $"User Click To Open WriteIn Screen");

            lblResult.UpdateResultMessage("Ra Lệnh Ghi Vé Vào", ProcessColor);
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
                    await BaseLane.SaveImage(response?.images ?? null, imageDatas);
                    break;
                }
            }
        }

        /// <summary>
        /// Bấm nút chụp lại hình ảnh ==> Kích hoạt sự kiện như sự kiện LOOP
        /// </summary>
        private void BtnReTakePhoto_Click(object? sender, EventArgs e)
        {
            tblUserLog.SaveLog(this.lane.name, $"User Click To Btn Take Photo");

            lblResult.UpdateResultMessage("Ra lệnh chụp lại", ProcessColor);
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
        /// Ra lệnh mở barrie
        /// </summary>
        private async void BtnOpenBarrie_Click(object? sender, EventArgs e)
        {
            tblUserLog.SaveLog(this.lane.name, $"User Click To Btn Open Barrie");

            await OpenAllBarrie();
            bool isOverAllowTime = ((DateTime.Now - lastEvent?.DateTimeIn)?.TotalSeconds ?? -1) >= StaticPool.appOption.AllowBarrieDelayOpenTime;
            if (lastEvent == null || isOverAllowTime)
            {
                var imageDatas = GetAllCameraImage();
                string plateNumber = lastEvent?.PlateNumber ?? "";
                await SaveManualAbnormalEvent(plateNumber, lastEvent?.Identity, lastEvent?.IdentityGroup, imageDatas, true);
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
                if (laneDirectionConfig.cameraDirection == LaneDirectionConfig.EmCameraDirection.Vertical)
                {
                    int newWidth = panelCameras.Width - panelCameras.Margin.Left - panelCameras.Margin.Right -
                                                        panelCameras.Padding.Left - panelCameras.Padding.Right
                                                      - item.Padding.Left - item.Padding.Right;
                    item.ChangeByWidth(new Size(newWidth, (displayRegionHeight) / count), this.laneDirectionConfig.cameraResolutionDisplay);
                }
                else
                {
                    item.ChangeByHeight(new Size((panelCameras.Width - panelCameras.Margin.Left - panelCameras.Margin.Right - panelCameras.Padding.Left - panelCameras.Padding.Right
                                                    - /*item.Margin.Left - item.Margin.Right -*/ item.Padding.Left - item.Padding.Right) / count, panelCameras.Height - 50), this.laneDirectionConfig.cameraResolutionDisplay);
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
                    if (laneDirectionConfig.cameraDirection == LaneDirectionConfig.EmCameraDirection.Vertical)
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

        #region EFFECT - OK
        private void Pic_MouseHover(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            var pictureBox = (sender as PictureBox)!;
            pictureBox.BackColor = Color.Green;
            pictureBox.Refresh();
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
        #endregion End EFFECT
        #endregion End CONTROLS IN FORM

        #region TIMER - OK
        private void timerRefreshUI_Tick(object sender, EventArgs e)
        {
            time_refresh++;
            if (time_refresh >= StaticPool.oemConfig.TimeToDefautUI)
            {
                StopTimeRefreshUI();
                ClearView();
            }
        }
        private void StopTimeRefreshUI()
        {
            timerRefreshUI.Enabled = false;
            time_refresh = 0;
        }
        private void StartTimerRefreshUI()
        {
            if (StaticPool.oemConfig.IsAutoReturnToDefault)
            {
                timerRefreshUI.Enabled = true;
            }
        }
        #endregion End TIMER

        #region PRIVATE FUNCTION

        #region LOADING
        private async void CreateBaseUI()
        {
            lblResult.Padding = new Padding(StaticPool.baseSize);
            lblResult.UpdateResultMessage(StaticPool.oemConfig.AppName, SuccessColor);
            CreateToolTip();
            SetDefaultImage();
            if (StaticPool.appOption.PrintTemplate != (int)EmPrintTemplate.OfficeHaus)
            {
                panelThirdParty.Visible = false;
            }
            if (this.laneDirectionConfig.IsDisplayLastEvent)
            {
                CreatePanelTop3Event();
                await DisplayTop3EventInfo();
            }
            else
            {
                ucEventCount1.Stop();
            }
        }
        private void CreateToolTip()
        {
            List<string> controllerShortcut = new List<string>();

            if (controllerShortcutConfigs != null)
            {
                controllerShortcut = controllerShortcutConfigs
                    .SelectMany(config => config.KeySetByRelays.Values)
                    .Select(key => ((Keys)key).ToString())
                    .ToList();
            }

            toolTipOpenBarrie.SetupToolTip(picOpenBarrie, "Mở Barrie", string.Join(",", controllerShortcut));
            toolTipReTakePhoto.SetupToolTip(picRetakePhoto, "Chụp Lại", () => ((Keys)laneInShortcutConfig?.ReSnapshotKey).ToString());
            toolTipWriteIn.SetupToolTip(picWriteIn, "Ghi Vé Vào", () => ((Keys)laneInShortcutConfig?.WriteIn).ToString());
            toolTipSetting.SetupToolTip(picSetting, "Cấu hình ứng dụng", "");
        }
        private void SetDefaultImage()
        {
            List<PictureBox> displayEventPics = new List<PictureBox>() { picLprImage, picOverviewImage, picVehicleImage, };
            foreach (var item in displayEventPics)
            {
                try
                {
                    item.Image = item.InitialImage = item.ErrorImage = defaultImg;
                }
                catch (Exception)
                {
                }
            }
            displayEventPics.Clear();
        }
        private void CreatePanelTop3Event()
        {
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
        }
        private async Task DisplayTop3EventInfo()
        {
            DateTime startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            DateTime endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            var top3Event = (await AppData.ApiServer.reportingService.GetEventIns("", startTime, endTime, "", "", this.lane.Id, "", true, 0, 3)).data;
            if (top3Event == null)
            {
                return;
            }
            for (int i = 0; i < top3Event.Count; i++)
            {
                if (ucLastEventInfos.Count <= i)
                {
                    continue;
                }
                ucLastEventInfos[i].UpdateEventInfo(top3Event[i].Id, top3Event[i].images);
            }
        }

        private void RegisterUIEvent()
        {
            panelCameras.SizeChanged += PanelCameras_SizeChanged;
            List<PictureBox> picSettings = new List<PictureBox>()
            {
                picSetting, picRetakePhoto, picOpenBarrie, picWriteIn
            };
            foreach (var pic in picSettings)
            {
                pic.MouseHover += Pic_MouseHover;
                pic.MouseLeave += Pic_MouseLeave;
            }
            picSettings.Clear();
        }
        private void SetUserDisplayConfig()
        {
            panelCameras.SizeChanged -= PanelCameras_SizeChanged;
            switch (laneDirectionConfig.displayDirection)
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

            switch (laneDirectionConfig.cameraPicDirection)
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
                switch (laneDirectionConfig.picDirection)
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

            switch (laneDirectionConfig.eventDirection)
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
            panelDisplayLastEvent.Visible = laneDirectionConfig.IsDisplayLastEvent;
            splitContainerMain.Panel2Collapsed = laneDirectionConfig.IsDisplayLastEvent ? false : true;
            panelLastEvent.Visible = laneDirectionConfig.IsDisplayLastEvent;
            PanelCameras_SizeChanged(null, EventArgs.Empty);
            panelCameras.SizeChanged += PanelCameras_SizeChanged;
        }
        #endregion End LOADING

        #region KEY PREVIEW - OK
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

        /// <summary>
        /// Kiểm tra phím tắt điều khiển controller
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private async Task CheckControllerShortcutConfig(Keys key)
        {
            if (this.controllerShortcutConfigs == null)
                return;

            foreach (ControllerShortcutConfig controllerShortcutConfig in controllerShortcutConfigs)
            {
                foreach (var item in controllerShortcutConfig.KeySetByRelays)
                {
                    if (item.Value != (int)key)
                    {
                        continue;
                    }
                    string controllerId = controllerShortcutConfig.ControllerId;
                    int barrieIndex = item.Key;

                    IController? controller = frmMain.controllers.FirstOrDefault(e => e.ControllerInfo.Id.ToLower() == controllerId.ToLower());
                    if (controller == null)
                    {
                        continue;
                    }
                    lblResult.UpdateResultMessage("Ra Lệnh Mở Barrie" + barrieIndex, ProcessColor);
                    await controller.OpenDoor(100, barrieIndex);

                    bool isOverAllowTime = ((DateTime.Now - lastEvent?.DateTimeIn)?.TotalSeconds ?? -1) >= StaticPool.appOption.AllowBarrieDelayOpenTime;
                    if (lastEvent == null || isOverAllowTime)
                    {
                        var imageDatas = GetAllCameraImage();
                        string plateNumber = lastEvent?.PlateNumber ?? "";
                        await SaveManualAbnormalEvent(plateNumber, lastEvent?.Identity, lastEvent?.IdentityGroup, imageDatas, true);
                    }
                }
            }
        }

        /// <summary>
        /// Kiểm tra phím tắt điều khiển làn
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private async Task CheckLaneInShortcutConfig(Keys key)
        {
            if (laneInShortcutConfig == null)
                return;
            if ((int)key == laneInShortcutConfig.ConfirmPlateKey && txtPlate.Focused && this.lastEvent != null)
            {
                await ExitPlateOnUI();
            }
            else if ((int)key == laneInShortcutConfig.ReserveLane)
            {
                ReverseLane();
            }
            else if ((int)key == laneInShortcutConfig.WriteIn)
            {
                BtnWriteIn_Click(null, EventArgs.Empty);
            }
            else if ((int)key == laneInShortcutConfig.ReSnapshotKey)
            {
                BtnReTakePhoto_Click(null, EventArgs.Empty);
            }
        }
        private async Task ExitPlateOnUI()
        {
            FocusOnTitle();
            string newPlate = string.Empty;
            this.Invoke(new Action(() =>
            {
                txtPlate.Text = txtPlate.Text.ToUpper().Replace("-", "").Replace(".", "").Trim();
                newPlate = txtPlate.Text;
            }));
            bool isUpdateSuccess = await AppData.ApiServer.parkingProcessService.UpdateEventInPlateAsync(lastEvent!.Id, newPlate, lastEvent.PlateNumber);
            if (isUpdateSuccess)
            {
                this.Invoke(new Action(() =>
                {

                    lblResult.UpdateResultMessage("Ra Lệnh Cập Nhật Biển Số Thành Công", ProcessColor);
                    lastEvent.PlateNumber = newPlate;
                }));
            }
            else
            {
                this.Invoke(new Action(() =>
                {
                    lblResult.UpdateResultMessage("Cập nhật lỗi, vui lòng thử lại", ProcessColor);
                }));
            }
        }
        private void ReverseLane()
        {
            if (string.IsNullOrEmpty(this.lane.reverseLaneId?.ToString()))
            {
                lblResult.UpdateResultMessage("Không có cấu hình làn đảo", ProcessColor);
                return;
            }
            var config = GetCurrentUIConfig();
            NewtonSoftHelper<LaneDisplayConfig>.SaveConfig(config, PathManagement.appDisplayConfigPath(this.lane.Id));
            lblResult.UpdateResultMessage("Ra Lệnh Đảo Làn", ProcessColor);
            OnChangeLaneEventInvoke(this);
            this.Dispose();
            return;
        }

        #endregion End KEY PREVIEW

        #region PROCESS - OK
        private void FocusOnTitle()
        {
            this.BeginInvoke(new Action(() =>
            {
                this.ActiveControl = lblLaneName;
                lblLaneName.Focus();
            }));
        }

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

        /// <summary>
        /// Kiểm tra kết quả check in nhận từ server <br/>
        /// <param> <paramref name="eventInReponse"/> Kết quả nhận từ server</param> <br/>
        /// <param name="customer"> <paramref name="customer"/> Thông tin khách hàng, khi lỗi sẽ hiển thị thông tin</param> <br/>
        /// <param name="vehicleBaseType"> <paramref name="vehicleBaseType"/> Thông tin loại xe, khi lỗi sẽ hiển thị thông tin</param> <br/>
        /// <param name="plateNumber"> <paramref name="plateNumber"/> Biển số xe</param> <br/>
        /// <param name="isForce"> <paramref name="isForce"/> Biến xác định là check in normal hay force, nếu force thì tự động dừng lại nếu lỗi</param> <br/>
        /// </summary>
        /// <returns></returns>
        private CheckEventInResponse CheckEventInReponse(Tuple<EventInData, BaseErrorData> eventInReponse, Customer? customer,
                                                      VehicleBaseType vehicleBaseType, string plateNumber,
                                                      bool isForce)
        {
            CheckEventInResponse checkInOutResponse = new CheckEventInResponse()
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

            //Sự kiện hợp lệ
            if (checkInOutResponse.ErrorData is null)
            {
                checkInOutResponse.IsValidEvent = true;
                checkInOutResponse.IsContinueExcecute = false;
                return checkInOutResponse;
            }

            //Sự kiện lỗi, kiểm tra thông tin lỗi
            else
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
        }

        private Dictionary<EmParkingImageType, List<List<byte>>> GetAllCameraImage()
        {
            var imageData = new Dictionary<EmParkingImageType, List<List<byte>>>();
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

        private void DisplayDetectedPlate(string plate, Image? lprImage)
        {
            BaseLane.ShowImage(picLprImage, lprImage);
            txtPlate.Invoke(new Action(() =>
            {
                txtPlate.Text = plate;
                txtPlate.Refresh();
            }));
        }

        private void DisplayEventInfo(DateTime eventTime, string plateNumber, Identity? identity, IdentityGroup? identityGroup, VehicleBaseType? vehicle,
                                      Customer? customer, RegisteredVehicle? registeredVehicle, WeighingDetail? weighingDetail = null)
        {
            dgvEventContent?.Invoke(new Action(() =>
            {
                dgvEventContent.Columns[0].Visible = laneDirectionConfig.IsDisplayTitle;
                dgvEventContent.Rows.Clear();
                dgvEventContent.Rows.Add("Giờ Vào", eventTime.ToString("dd/MM/yyyy HH:mm:ss"));
                dgvEventContent.Rows.Add("Vé Xe", identity?.Name + " - " + identity?.Code);
                if (StaticPool.appOption.IsDisplayCustomerInfo)
                {
                    if (customer != null)
                    {
                        dgvEventContent.Rows.Add("Nhóm khách hàng", customer.CustomerGroupName);
                        dgvEventContent.Rows.Add("Khách hàng", customer.Name + " / " + customer.Address);
                        dgvEventContent.Rows.Add("SĐT", customer.PhoneNumber);
                    }
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
            }));
        }

        private void ClearView()
        {
            this.Invoke(new Action(() =>
            {
                FocusOnTitle();

                lastEvent = null;

                dgvEventContent.Rows.Clear();

                picOverviewImage.Image = defaultImg;
                picLprImage.Image = defaultImg;
                picVehicleImage.Image = defaultImg;

                txtPlate.Text = string.Empty;

                lblResult.UpdateResultMessage(StaticPool.oemConfig.AppName, SuccessColor);
            }));
        }
        #endregion End PROCESS

        #endregion END PRIVATE FUNCTION

        #region PUBLIC FUNCTION
        public void DispayUI()
        {
            if (StaticPool.appOption.PrintTemplate != (int)EmPrintTemplate.OfficeHaus)
            {
                panelThirdParty.Visible = false;
            }

            lblLaneName.Text = lane.name;
            lblLaneName.BackColor = SuccessColor;

            splitContainerMain.Panel2Collapsed = !laneDirectionConfig.IsDisplayLastEvent;
            panelDisplayLastEvent.Visible = laneDirectionConfig.IsDisplayLastEvent;
            panelLastEvent.Visible = laneDirectionConfig.IsDisplayLastEvent;

            GetShortcutConfig();
            LoadCamera(panelCameras);

            CreateBaseUI();
            RegisterUIEvent();

            SetUserDisplayConfig();
            LoadSavedUIConfig();

            try
            {
                this.ActiveControl = lblLaneName;
            }
            catch (Exception)
            {
            }
        }

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
        public void LoadSavedUIConfig()
        {
            if (this.laneDisplayConfig == null) return;

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
                tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS, "LoadSavedUIConfig", ex);
            }

            try
            {
                this.splitterEventInfoWithCamera.SplitPosition = this.laneDisplayConfig.splitEventInfoWithCameraPosition;
            }
            catch (Exception ex)
            {
                tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS, "LoadSavedUIConfig", ex);
            }

            try
            {
                this.splitContainerLastEvent.SplitterDistance = this.laneDisplayConfig.splitLastEventPosition;
            }
            catch (Exception ex)
            {
                tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS, "LoadSavedUIConfig", ex);
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
                tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS, "LoadSavedUIConfig", ex);
            }

            try
            {
                this.splitContainerEventContent.SplitterDistance = this.laneDisplayConfig.splitContainerEventContent;
            }
            catch (Exception ex)
            {
                tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS, "LoadSavedUIConfig", ex);
            }

            try
            {
                this.splitterCamera.SplitPosition = this.laneDisplayConfig.SplitterCameraPosition;
            }
            catch (Exception ex)
            {
                tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS, "LoadSavedUIConfig", ex);
            }

            AllowDesignRealtime(false);
        }

        /// <summary>
        /// Lấy thông tin hiển thị hiện tại để lưu lại
        /// </summary>
        /// <returns></returns>
        public LaneDisplayConfig GetCurrentUIConfig()
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
        #endregion ENd PUBLIC FUNCTION
    }
}