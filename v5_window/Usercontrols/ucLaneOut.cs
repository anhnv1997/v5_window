using IPaking.Ultility;
using iPakrkingv5.Controls;
using iParkingv5.Controller;
using iParkingv5.Objects;
using iParkingv5.Objects.Configs;
using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Datas.Device_service;
using iParkingv5.Objects.Datas.invoice_service;
using iParkingv5.Objects.Datas.parking_service;
using iParkingv5.Objects.Datas.ThirtParty.OfficeHaus;
using iParkingv5.Objects.Datas.weighing_service;
using iParkingv5.Objects.Enums;
using iParkingv5.Objects.EventDatas;
using iParkingv5.Objects.Events;
using iParkingv5.Reporting;
using iParkingv5_window.Forms.DataForms;
using iParkingv5_window.Forms.SystemForms;
using iParkingv6.Objects.Datas;
using Kztek.Helper;
using Kztek.Tool;
using Kztek.Tool.LogDatabases;
using Kztek.Tool.TextFormatingTools;
using Kztek.Tools;
using Microsoft.Extensions.Logging;
using System.Threading;
using static iParkingv5.Objects.Configs.LaneDirectionConfig;
using static iParkingv5.Objects.Enums.ParkingImageType;
using static iParkingv5.Objects.Enums.PrintHelpers;
using static iParkingv5.Objects.Enums.VehicleType;
using static Kztek.Tool.LogDatabases.tblSystemLog;

namespace iParkingv5_window.Usercontrols
{
    public partial class ucLaneOut : ucBaseLane, iLane, IDisposable
    {
        public async void printQR(CardEventArgs ce, HausQR qrData)
        {

        }
        #region PROPERTIES
        #region Config
        private LaneOutShortcutConfig? laneOutShortcutConfig;
        #endregion

        #region EVENT
        EventOutData? lastEvent = null;
        private ucLastEventInfo? ucTop1Event;
        private ucLastEventInfo? ucTop3Event;
        private ucLastEventInfo? ucTop2Event;
        List<string> lastImageKeys = new List<string>();
        #endregion End EVENT

        #region OTHER
        public static Image defaultImg = Image.FromFile(StaticPool.oemConfig.LogoPath);
        #endregion End OTHER

        #endregion End PROPERTIES

        #region FORMS
        public ucLaneOut(Lane lane, LaneDisplayConfig? laneDisplayConfig, LaneDirectionConfig laneDirectionConfig)
        {
            InitializeComponent();
            tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS, "Init Lane");

            this.DoubleBuffered = true;

            this.lane = lane;

            this.laneDisplayConfig = laneDisplayConfig;
            this.laneDirectionConfig = laneDirectionConfig;

            tblEventContent.ToggleDoubleBuffered(true);

            var activeSpliters = new List<SplitContainer>()
            {
                spliterCamera ,
                spliterPicEv_PicPlate ,
                spliterCamera_PicEv_PicPlate ,
                spliterCamera_top3Event,
                spliterEvInPlate ,
                spliterEvOutPlate,
                splitContainerMain,
                spliterTopEvent_Actions
            };

            foreach (var spliter in activeSpliters)
            {
                spliter.ToggleDoubleBuffered(true);
                spliter.Paint += SpliterCamera_Paint;
                spliter.DoubleClick += Spliter_DoubleClick;
                spliter.SplitterMoved += Spliter_SplitterMoved;
            }
            activeSpliters.Clear();

            if (!StaticPool.appOption.IsDisplayCustomerInfo)
            {
                tblEventContent.ColumnStyles[2].SizeType = SizeType.Absolute;
                tblEventContent.ColumnStyles[2].Width = 0;
                tblEventContent.ColumnStyles[3].SizeType = SizeType.Absolute;
                tblEventContent.ColumnStyles[3].Width = 0;
            }
        }

        private void SpliterCamera_Paint(object? sender, PaintEventArgs e)
        {
            var spliter = sender as SplitContainer;
            // Set the color you want for the splitter
            Color splitterColor = this.IsAllowDesignRealtime ? Color.Red : SystemColors.ButtonHighlight;

            // Create a brush with the desired color
            using (SolidBrush brush = new SolidBrush(splitterColor))
            {
                // Draw the splitter manually
                if (spliter.Orientation == Orientation.Horizontal)
                {
                    // Horizontal splitter
                    e.Graphics.FillRectangle(brush, 0, spliter.SplitterDistance, spliter.Width, spliter.SplitterWidth);
                }
                else
                {
                    // Vertical splitter
                    e.Graphics.FillRectangle(brush, spliter.SplitterDistance, 0, spliter.SplitterWidth, spliter.Height);
                }
            }
        }

        private void Spliter_SplitterMoved(object? sender, SplitterEventArgs e)
        {
            var spliter = sender as SplitContainer;
            if (spliter!.Name == splitContainerMain.Name)
            {
                frmMain.preferMainDistance = spliter.SplitterDistance;
            }
            if (spliter!.Name == spliterCamera.Name)
            {
                frmMain.preferCameraDistance = spliter.SplitterDistance;
            }
            else if (spliter!.Name == spliterCamera_PicEv_PicPlate.Name)
            {
                frmMain.preferCamera_PicEv_PicPlateDistance = spliter.SplitterDistance;
            }
            else if (spliter!.Name == spliterPicEv_PicPlate.Name)
            {
                frmMain.preferPicEv_PicPlateDistance = spliter.SplitterDistance;
            }
            else if (spliter!.Name == spliterCamera_top3Event.Name)
            {
                frmMain.preferCamera_TopEvent_Distance = spliter.SplitterDistance;
            }
            else if (spliter!.Name == spliterTopEvent_Actions.Name)
            {
                frmMain.preferTopEvent_Action_Distance = spliter.SplitterDistance;
            }
            else if (spliter!.Name == spliterEvInPlate.Name)
            {
                frmMain.preferEvOutPlateDistance = spliter.SplitterDistance;
            }
            else if (spliter!.Name == spliterEvOutPlate.Name)
            {
                frmMain.preferEvOutPlateDistance = spliter.SplitterDistance;
            }
            spliter.Refresh();
        }

        private void Spliter_DoubleClick(object? sender, EventArgs e)
        {
            var spliter = sender as SplitContainer;
            spliter!.SplitterMoved -= Spliter_SplitterMoved;

            if (spliter.Name == splitContainerMain.Name)
            {
                if (frmMain.preferMainDistance > 0)
                {
                    spliter.SplitterDistance = frmMain.preferMainDistance;
                }
                else
                {
                    spliter.SplitterDistance = spliter.Width / 2;
                }
            }
            if (spliter.Name == spliterCamera.Name)
            {
                if (frmMain.preferCameraDistance > 0)
                {
                    spliter.SplitterDistance = frmMain.preferCameraDistance;
                }
                else
                {
                    spliter.SplitterDistance = spliter.Width / 2;
                }
            }
            else if (spliter.Name == spliterCamera_PicEv_PicPlate.Name)
            {
                if (frmMain.preferCamera_PicEv_PicPlateDistance > 0)
                {
                    spliter.SplitterDistance = frmMain.preferCamera_PicEv_PicPlateDistance;
                }
                else
                {
                    spliter.SplitterDistance = spliter.Width / 2;
                }
            }
            else if (spliter!.Name == spliterPicEv_PicPlate.Name)
            {
                if (frmMain.preferPicEv_PicPlateDistance > 0)
                {
                    spliter.SplitterDistance = frmMain.preferPicEv_PicPlateDistance;
                }
                else
                {
                    spliter.SplitterDistance = spliter.Width / 2;
                }
            }
            else if (spliter!.Name == spliterCamera_top3Event.Name)
            {
                if (frmMain.preferCamera_TopEvent_Distance > 0)
                {
                    spliter.SplitterDistance = frmMain.preferCamera_TopEvent_Distance;
                }
                else
                {
                    spliter.SplitterDistance = spliter.Width / 2;
                }
            }
            else if (spliter!.Name == spliterTopEvent_Actions.Name)
            {
                if (frmMain.preferTopEvent_Action_Distance > 0)
                {
                    spliter.SplitterDistance = frmMain.preferTopEvent_Action_Distance;
                }
                else
                {
                    spliter.SplitterDistance = spliter.Width / 2;
                }
            }
            else if (spliter!.Name == spliterEvInPlate.Name)
            {
                if (frmMain.preferEvOutPlateDistance > 0)
                {
                    spliter.SplitterDistance = frmMain.preferEvOutPlateDistance;
                }
                else
                {
                    spliter.SplitterDistance = spliter.Width / 2;
                }
            }
            else if (spliter!.Name == spliterEvOutPlate.Name)
            {
                if (frmMain.preferEvOutPlateDistance > 0)
                {
                    spliter.SplitterDistance = frmMain.preferEvOutPlateDistance;
                }
                else
                {
                    spliter.SplitterDistance = spliter.Width / 2;
                }
            }
            spliter.SplitterMoved += Spliter_SplitterMoved;
            spliter.Refresh();
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
            tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS, $"KeyPress {keys.ToString()}");

            try
            {
                if (keys == Keys.F9)
                {
                    AllowDesignRealtime(!this.IsAllowDesignRealtime);
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
            try
            {
                if (e is CardEventArgs cardEvent)
                {
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.PROCESS,
                                         $"Get New Card Event", cardEvent);
                    await ExcecuteCardEvent(cardEvent);
                }
                else if (e is InputEventArgs inputEvent)
                {
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.PROCESS,
                                         $"Get New Input Event", inputEvent);
                    await ExcecuteInputEvent(inputEvent, lblEventMessage);
                }
            }
            finally
            {
                semaphoreSlimOnNewEvent.Release();
                StartTimerRefreshUI();
            }
        }
        private bool isExcecute = false;
        public override async void UcMotoLpr_MotionDetectEvent(object sender, ucCameraView.MotionDetectEventArgs e)
        {
            if (isExcecute)
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
                    EventTime = DateTime.Now,
                    DeviceId = controllerInLane.controlUnitId,
                    InputIndex = controllerInLane.inputs[0],
                };
                isExcecute = true;

                var lprResult = new LoopLprResult();
                lprResult = await LoopLprDetection();
                Image? overviewImg = null;

                if (lprResult.Vehicle == null)
                {
                    isExcecute = false;

                    if (!string.IsNullOrEmpty(lprResult.PlateNumber))
                    {
                        overviewImg = ucOverView?.GetFullCurrentImage();
                        BaseLane.ShowImage(picVehicleImageOut, lprResult.VehicleImage);
                        BaseLane.ShowImage(picOverviewImageOut, overviewImg);
                        BaseLane.ShowImage(picLprImage, lprResult.VehicleImage);
                    }
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                    $"{this.lane.name}.Loop.{ie.InputIndex} - VEHICLE NULL - END");
                    lblEventMessage.UpdateResultMessage((lprResult.PlateNumber ?? "") + " - Phương tiện chưa được đăng ký trong hệ thống", ErrorColor);
                    return;
                }

                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                $"{this.lane.name}.Loop.{ie.InputIndex} - START");
                ClearView();

                EventOutData? eventOut = null;
                List<Image?> optionalImages = new();
                bool isAlarm = false;

                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                     $"{this.lane.name}.Loop.{ie.InputIndex} - START DETECT PLATE");
                lblEventMessage.UpdateResultMessage("Nhận dạng biển số", ProcessColor);

                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                     $"{this.lane.name}.Loop.{ie.InputIndex} - END DETECT PLATE");

                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                    $"{this.lane.name}.Loop.{ie.InputIndex} - DISPLAY EVENT IMAGE");

                BaseLane.ShowImage(picVehicleImageOut, lprResult.VehicleImage);
                BaseLane.ShowImage(picOverviewImageOut, overviewImg);
                DisplayDetectedPlate(lprResult.PlateNumber, lprResult.LprImage);


                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                    $"{this.lane.name}.Loop.{ie.InputIndex} - START CHECK OUT");
                lblEventMessage.UpdateResultMessage("Đang check out..." + lprResult.PlateNumber, ProcessColor);

                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                    $"{this.lane.name}.Loop.{ie.InputIndex} - GET CUSTOMER INFO");
                string customerId = lprResult.Vehicle.CustomerId;
                Customer? customer = string.IsNullOrEmpty(customerId) ?
                                               null : customer = (await AppData.ApiServer.parkingDataService.GetCustomerByIdAsync(customerId))?.Item1;
                List<EmParkingImageType> validImageTypes = BaseLane.GetValidImageType(overviewImg, lprResult.VehicleImage, lprResult.LprImage);

                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                    $"{this.lane.name}.Loop.{ie.InputIndex} - SEND CHECK OUT NORMAL REQUEST");
                var eventOutResponse = await AppData.ApiServer.parkingProcessService.PostCheckOutAsync(lane.Id, lprResult.PlateNumber, null,
                                                                                                        validImageTypes, false);

                var checkInOutResponse = CheckEventOutReponse(eventOutResponse, customer, lprResult.Vehicle.vehicleType, lprResult.PlateNumber, false);

                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                     $"{this.lane.name}.Loop.{ie.InputIndex} - CHECK EVENT OUT NORMAL RESPONSE", checkInOutResponse);

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
                        lblEventMessage.UpdateResultMessage(StaticPool.oemConfig.AppName, SuccessColor);

                        return;
                    }
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                    $"{this.lane.name}.Loop.{ie.InputIndex} - SEND CHECK OUT FORCE REQUEST");

                    eventOutResponse = await AppData.ApiServer.parkingProcessService.PostCheckOutAsync(lane.Id, lprResult.PlateNumber, null,
                                                                                                       validImageTypes, true);
                    checkInOutResponse = CheckEventOutReponse(eventOutResponse, customer, lprResult.Vehicle.vehicleType, lprResult.PlateNumber, true);
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                      $"{this.lane.name}.Loop.{ie.InputIndex} - CHECK EVENT OUT FORCE RESPONSE", checkInOutResponse);

                    if (!checkInOutResponse.IsValidEvent)
                    {
                        tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                     $"{this.lane.name}.Loop.{ie.InputIndex} - INVALID EVENT, END PROCESS");
                        return;
                    }
                }
                eventOut = checkInOutResponse.eventOut!;
                if (eventOut.OpenBarrier)
                {
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                           $"{this.lane.name}.Loop.{ie.InputIndex} - OPEN BARRIE");
                    _ = BaseLane.OpenBarrieByControllerId(ie.DeviceId, controllerInLane, this);
                    _ = AppData.ApiServer.parkingProcessService.CommitOutAsync(eventOut);
                }
                else
                {
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                           $"{this.lane.name}.Loop.{ie.InputIndex} - SHOW CONFIRM OPEN BARRIE REQUEST");

                    frmConfirmOut frmConfirmOut = new frmConfirmOut(eventOut.PlateNumber, "Bạn có xác nhận mở barrie?",
                                                                    eventOut.EventIn.PlateNumber ?? "",
                                                                    eventOut.EventIn?.Identity?.Name ?? "",
                                                                    eventOut.EventIn?.IdentityGroup?.Name ?? "",
                                                                    eventOut.EventIn?.IdentityGroup?.VehicleType ?? VehicleBaseType.Unknown,
                                                                    eventOut.EventIn?.images ?? new Dictionary<EmParkingImageType, List<ImageData>>(),
                                                                    eventOut.EventIn?.DateTimeIn ?? DateTime.Now, false, eventOut.Charge);
                    bool isConfirm = frmConfirmOut.ShowDialog() == DialogResult.OK;
                    if (!isConfirm)
                    {
                        tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                           $"{this.lane.name}.Loop.{ie.InputIndex} - NOT CONFIRM OPEN BARRIE");

                        lblEventMessage.UpdateResultMessage("Không xác nhận mở barrie", ProcessColor);
                        return;
                    }
                    else
                    {
                        tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                           $"{this.lane.name}.Loop.{ie.InputIndex} - CONFIRM OPEN BARRIE");

                        eventOut.PlateNumber = frmConfirmOut.updatePlate.ToUpper();
                        _ = BaseLane.OpenBarrieByControllerId(ie.DeviceId, controllerInLane, this);
                        _ = AppData.ApiServer.parkingProcessService.CommitOutAsync(eventOut);
                    }
                }

                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                           $"{this.lane.name}.Loop.{ie.InputIndex} - Display Valid Event");
                await ExcecuteValidEvent(null, null, lprResult.Vehicle.vehicleType, lprResult.PlateNumber, ie.EventTime, overviewImg, lprResult.VehicleImage,
                                        lprResult.LprImage, eventOut, eventOut.vehicle, isAlarm);
                if (lastEvent != null)
                {
                    await Task.Delay(StaticPool.appOption.MotionAlarmDelayMilisecond);
                }
                isExcecute = false;
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

            EventOutData? eventOut = null;
            Image? overviewImg = null;
            List<Image?> optionalImages = new();
            bool isAlarm = false;
            var lprResult = new LoopLprResult();

            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                 $"{this.lane.name}.Loop.{ie.InputIndex} - START DETECT PLATE");
            lblEventMessage.UpdateResultMessage("Nhận dạng biển số", ProcessColor);
            overviewImg = ucOverView?.GetFullCurrentImage();
            lprResult = await LoopLprDetection();

            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                 $"{this.lane.name}.Loop.{ie.InputIndex} - END DETECT PLATE");

            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                $"{this.lane.name}.Loop.{ie.InputIndex} - DISPLAY EVENT IMAGE");

            BaseLane.ShowImage(picVehicleImageOut, lprResult.VehicleImage);
            BaseLane.ShowImage(picOverviewImageOut, overviewImg);
            DisplayDetectedPlate(lprResult.PlateNumber, lprResult.LprImage);


            if (lprResult.Vehicle == null)
            {
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                $"{this.lane.name}.Loop.{ie.InputIndex} - VEHICLE NULL - END");
                lblEventMessage.UpdateResultMessage("Phương tiện chưa được đăng ký trong hệ thống", ErrorColor);
                return;
            }

            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                $"{this.lane.name}.Loop.{ie.InputIndex} - START CHECK OUT");
            lblEventMessage.UpdateResultMessage("Đang check out..." + lprResult.PlateNumber, ProcessColor);

            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                $"{this.lane.name}.Loop.{ie.InputIndex} - GET CUSTOMER INFO");
            string customerId = lprResult.Vehicle.CustomerId;
            Customer? customer = string.IsNullOrEmpty(customerId) ?
                                           null : customer = (await AppData.ApiServer.parkingDataService.GetCustomerByIdAsync(customerId))?.Item1;
            List<EmParkingImageType> validImageTypes = BaseLane.GetValidImageType(overviewImg, lprResult.VehicleImage, lprResult.LprImage);

            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                $"{this.lane.name}.Loop.{ie.InputIndex} - SEND CHECK OUT NORMAL REQUEST");
            var eventOutResponse = await AppData.ApiServer.parkingProcessService.PostCheckOutAsync(lane.Id, lprResult.PlateNumber, null,
                                                                                                    validImageTypes, false);

            var checkInOutResponse = CheckEventOutReponse(eventOutResponse, customer, lprResult.Vehicle.vehicleType, lprResult.PlateNumber, false);

            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                 $"{this.lane.name}.Loop.{ie.InputIndex} - CHECK EVENT OUT NORMAL RESPONSE", checkInOutResponse);

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
                    lblEventMessage.UpdateResultMessage(StaticPool.oemConfig.AppName, SuccessColor);

                    return;
                }
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                $"{this.lane.name}.Loop.{ie.InputIndex} - SEND CHECK OUT FORCE REQUEST");

                eventOutResponse = await AppData.ApiServer.parkingProcessService.PostCheckOutAsync(lane.Id, lprResult.PlateNumber, null,
                                                                                                   validImageTypes, true);
                checkInOutResponse = CheckEventOutReponse(eventOutResponse, customer, lprResult.Vehicle.vehicleType, lprResult.PlateNumber, true);
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                  $"{this.lane.name}.Loop.{ie.InputIndex} - CHECK EVENT OUT FORCE RESPONSE", checkInOutResponse);

                if (!checkInOutResponse.IsValidEvent)
                {
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                                 $"{this.lane.name}.Loop.{ie.InputIndex} - INVALID EVENT, END PROCESS");
                    return;
                }
            }
            eventOut = checkInOutResponse.eventOut!;
            if (eventOut.OpenBarrier)
            {
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                       $"{this.lane.name}.Loop.{ie.InputIndex} - OPEN BARRIE");
                ControllerInLane? controllerInLane = (from _controllerInLane in this.lane.controlUnits
                                                      where _controllerInLane.controlUnitId == ie.DeviceId
                                                      select _controllerInLane).FirstOrDefault();
                _ = BaseLane.OpenBarrieByControllerId(ie.DeviceId, controllerInLane, this);
                _ = AppData.ApiServer.parkingProcessService.CommitOutAsync(eventOut);
            }
            else
            {
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                       $"{this.lane.name}.Loop.{ie.InputIndex} - SHOW CONFIRM OPEN BARRIE REQUEST");

                frmConfirmOut frmConfirmOut = new frmConfirmOut(eventOut.PlateNumber, "Bạn có xác nhận mở barrie?",
                                                                eventOut.EventIn.PlateNumber ?? "",
                                                                eventOut.EventIn?.Identity?.Name ?? "",
                                                                eventOut.EventIn?.IdentityGroup?.Name ?? "",
                                                                eventOut.EventIn?.IdentityGroup?.VehicleType ?? VehicleBaseType.Unknown,
                                                                eventOut.EventIn?.images ?? new Dictionary<EmParkingImageType, List<ImageData>>(),
                                                                eventOut.EventIn?.DateTimeIn ?? DateTime.Now, false, eventOut.Charge);
                bool isConfirm = frmConfirmOut.ShowDialog() == DialogResult.OK;
                if (!isConfirm)
                {
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                       $"{this.lane.name}.Loop.{ie.InputIndex} - NOT CONFIRM OPEN BARRIE");

                    lblEventMessage.UpdateResultMessage("Không xác nhận mở barrie", ProcessColor);
                    return;
                }
                else
                {
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                       $"{this.lane.name}.Loop.{ie.InputIndex} - CONFIRM OPEN BARRIE");

                    eventOut.PlateNumber = frmConfirmOut.updatePlate.ToUpper();
                    ControllerInLane? controllerInLane = (from _controllerInLane in this.lane.controlUnits
                                                          where _controllerInLane.controlUnitId == ie.DeviceId
                                                          select _controllerInLane).FirstOrDefault();
                    _ = BaseLane.OpenBarrieByControllerId(ie.DeviceId, controllerInLane, this);
                    _ = AppData.ApiServer.parkingProcessService.CommitOutAsync(eventOut);
                }
            }

            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.LOOP_EVENT,
                       $"{this.lane.name}.Loop.{ie.InputIndex} - Display Valid Event");
            await ExcecuteValidEvent(null, null, lprResult.Vehicle.vehicleType, lprResult.PlateNumber, ie.EventTime, overviewImg, lprResult.VehicleImage,
                                    lprResult.LprImage, eventOut, eventOut.vehicle, isAlarm);
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
            bool isOverAllowTime = ((DateTime.Now - lastEvent?.DatetimeOut)?.TotalSeconds ?? -1) >= StaticPool.appOption.AllowBarrieDelayOpenTime;
            if (lastEvent == null || isOverAllowTime)
            {
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.EXIT_EVENT,
                                $"{this.lane.name}.Exit.{ie.InputIndex} - SAVE EXIT ABNOMAL EVENT");

                var imageData = GetAllCameraImage(true);
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
                    //lblEventMessage.UpdateResultMessage($"Đang trong thời gian chờ, vui lòng quẹt lại sau {thoiGianCho}s", ProcessColor);
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
            lblEventMessage.UpdateResultMessage("Đang kiểm trang thông tin sự kiện quẹt thẻ..." + ce.PreferCard, ProcessColor);

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

            //tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
            //            $"{this.lane.name}.Card.{ce.PreferCard} - Check Identity Detail & Identity Group");
            //var identityTask = AppData.ApiServer.parkingDataService.GetIdentityByIdAsync(identity.Id);
            //var identityGroupTask = AppData.ApiServer.parkingDataService.GetIdentityGroupByIdAsync(identity.IdentityGroupId.ToString());
            //await Task.WhenAll(identityTask, identityGroupTask);

            //Cần gọi GET by ID để lấy thông tin phương tiện đăng ký
            //identity = identityTask.Result.Item1;
            if (identity == null || string.IsNullOrEmpty(identity.Id) || identity.Id == Guid.Empty.ToString())
            {
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                     $"{this.lane.name}.Card.{ce.PreferCard} - Invalid Identity");

                lblEventMessage.UpdateResultMessage("Không đọc được thông tin định danh, vui lòng thử lại", ErrorColor);
                return;
            }
            #endregion End kiểm tra thông tin định danh

            #region Kiểm tra thông tin nhóm định danh
            IdentityGroup? identityGroup = identity.IdentityGroup;// identityGroupTask.Result.Item1;
            if (identityGroup == null || identityGroup.Id == Guid.Empty)
            {
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                     $"{this.lane.name}.Card.{ce.PreferCard} - Invalid IdentityGroup");
                lblEventMessage.UpdateResultMessage("Không đọc được thông tin nhóm định danh, vui lòng thử lại", ErrorColor);
                return;
            }
            #endregion End kiểm tra thông tin nhóm định danh

            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                     $"{this.lane.name}.Card.{ce.PreferCard} - Check Vehicle Type");

            lblEventMessage.UpdateResultMessage("Đọc thông tin loại phương tiện...", ProcessColor);
            VehicleBaseType vehicleBaseType = identityGroup.VehicleType;
            switch (vehicleBaseType)
            {
                case VehicleBaseType.Unknown:
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                     $"{this.lane.name}.Card.{ce.PreferCard} - Invalid Vehicle Type");
                    lblEventMessage.UpdateResultMessage("Thông tin loại phương tiện không hợp lệ vui lòng sử dụng thẻ khác", ErrorColor);
                    return;
                default:
                    break;
            }

            //Lấy hình ảnh sự kiện
            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                 $"{this.lane.name}.Card.{ce.PreferCard} - Get Event Image");
            lblEventMessage.UpdateResultMessage("Lấy hình ảnh sự kiện ra...", ProcessColor);
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

            //Nếu là sự kiện thẻ thì đọc biển số,
            //còn nếu là sự kiện loop chuyển qua quẹt thẻ thì hiển thị thông tin biển số đã đọc trước đó chứ không đọc lại tránh tốn lượt nhận dạng
            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                 $"{this.lane.name}.Card.{ce.PreferCard} - Get Plate");
            Image? lprImage = GetPlate(ce, overviewImg, ref vehicleImg, vehicleBaseType, lblEventMessage, txtPlate,
                                       picOverviewImageOut, picVehicleImageOut, picLprImage);

            //Đọc thông tin loại phương tiện
            lblEventMessage.UpdateResultMessage("Đang check out..." + ce.PreferCard, ProcessColor);
            bool isMonthCard = identityGroup.Type == IdentityGroupType.Monthly;
            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                 $"{this.lane.name}.Card.{ce.PreferCard} - Start {identityGroup.Type} Card Process");
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
        #endregion End EVENT

        #region Xử lý sự kiện thẻ
        private async Task ExcecuteNonMonthCardEventOut(Identity identity, IdentityGroup identityGroup, VehicleBaseType vehicleType,
                                                string plateNumber, CardEventArgs ce, ControllerInLane? controllerInLane,
                                                Image? overviewImg, Image? vehicleImg, Image? lprImage)
        {
            EventOutData? eventOut = null;
            List<EmParkingImageType> validImageTypes = BaseLane.GetValidImageType(overviewImg, vehicleImg, lprImage);
            EventInData? eventIn = null;

            bool isAlarm = false;

            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                 $"{this.lane.name}.Card.{ce.PreferCard} - Send Check Out Normal Request");
            var eventOutResponse = await AppData.ApiServer.parkingProcessService.PostCheckOutAsync(lane.Id, plateNumber, identity, validImageTypes, false);

            var checkInOutResponse = CheckEventOutReponse(eventOutResponse, null, vehicleType, plateNumber, false);
            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                 $"{this.lane.name}.Card.{ce.PreferCard} - Check Check Out Normal Response", checkInOutResponse);

            if (!checkInOutResponse.IsValidEvent)
            {
                isAlarm = true;
                if (!checkInOutResponse.IsContinueExcecute)
                {
                    return;
                }
                else
                {
                    if (checkInOutResponse.ErrorData?.Payload is not null)
                    {
                        string data = checkInOutResponse.ErrorData.Payload.ContainsKey("EventIn") ? checkInOutResponse.ErrorData.Payload["EventIn"].ToString() : "";
                        if (!string.IsNullOrEmpty(data))
                        {
                            eventIn = Newtonsoft.Json.JsonConvert.DeserializeObject<EventInData>(data);
                        }
                    }
                    if (eventIn == null)
                    {
                        tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                $"{this.lane.name}.Card.{ce.PreferCard} - EventIn = NULL, End Process", checkInOutResponse);
                        ExcecuteSystemErrorCheckOut();
                        return;
                    }

                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                $"{this.lane.name}.Card.{ce.PreferCard} - Show Confirm Request", checkInOutResponse.ErrorMessage);

                    bool isConfirm = false;
                    frmConfirmOut frmConfirmOut = new frmConfirmOut(plateNumber, checkInOutResponse.ErrorMessage, eventIn.PlateNumber ?? "",
                                                                eventIn.Identity?.Name ?? "",
                                                                eventIn.IdentityGroup?.Name ?? "",
                                                                eventIn.IdentityGroup?.VehicleType ?? VehicleBaseType.Unknown,
                                                                eventIn.images, eventIn.DateTimeIn ?? DateTime.Now,
                                                                true, eventIn.Charge);
                    if (frmConfirmOut.ShowDialog() == DialogResult.OK)
                    {
                        if (plateNumber.ToUpper() != frmConfirmOut.updatePlate.ToUpper())
                        {
                            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                $"{this.lane.name}.Card.{ce.PreferCard} - Sửa biển số khi quẹt thẻ EventInId: " + eventIn.Id +
                                                      "\r\nOld Plate: " + plateNumber +
                                                      " => New Plate: " + frmConfirmOut.updatePlate);
                        }
                        plateNumber = frmConfirmOut.updatePlate.ToUpper();
                        isConfirm = true;
                    }
                    if (!isConfirm)
                    {
                        tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                $"{this.lane.name}.Card.{ce.PreferCard} - Not Confirm, End Process");
                        lblEventMessage.UpdateResultMessage("Không xác nhận sự kiện ra", ProcessColor);
                        ClearView();
                        return;
                    }
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                               $"{this.lane.name}.Card.{ce.PreferCard} - Confirm, Send Check Out Force Request");

                    eventOutResponse = await AppData.ApiServer.parkingProcessService.PostCheckOutAsync(lane.Id, plateNumber, identity,
                                                                                                       validImageTypes, true);
                    checkInOutResponse = CheckEventOutReponse(eventOutResponse, null, vehicleType, plateNumber, true);

                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                $"{this.lane.name}.Card.{ce.PreferCard} - Check Event Out Force Response", checkInOutResponse);

                    if (!checkInOutResponse.IsValidEvent)
                    {
                        tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                               $"{this.lane.name}.Card.{ce.PreferCard} - Invalid Event, End Process", checkInOutResponse);
                        return;
                    }
                }
            }

            eventOut = eventOutResponse.Item1!;
            eventIn = eventOut.EventIn!;

            if (eventOut.OpenBarrier)
            {
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                               $"{this.lane.name}.Card.{ce.PreferCard} - Open Barrie");
                _ = BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane, this);
                _ = AppData.ApiServer.parkingProcessService.CommitOutAsync(eventOut);
            }
            else
            {
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                               $"{this.lane.name}.Card.{ce.PreferCard} - Show Confirm Open Barrie Request");

                frmConfirmOut frmConfirmOut = new frmConfirmOut(plateNumber, "Bạn có xác nhận mở barrie?",
                                                                eventIn.PlateNumber ?? "",
                                                                eventIn.Identity?.Name ?? "",
                                                                eventIn.IdentityGroup?.Name ?? "",
                                                                eventIn.IdentityGroup?.VehicleType ?? VehicleBaseType.Unknown,
                                                                eventIn.images ?? new Dictionary<EmParkingImageType, List<ImageData>>(),
                                                                eventIn.DateTimeIn ?? DateTime.Now, false, eventOut.Charge);
                bool isConfirm = frmConfirmOut.ShowDialog() == DialogResult.OK;
                if (!isConfirm)
                {
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                               $"{this.lane.name}.Card.{ce.PreferCard} - Not Confirm Open Barrie");
                    lblEventMessage.UpdateResultMessage("Không xác nhận mở barrie", ProcessColor);
                    return;
                }
                else
                {
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                               $"{this.lane.name}.Card.{ce.PreferCard} - Confirm Open Barrie");
                    plateNumber = frmConfirmOut.updatePlate.ToUpper();
                    _ = BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane, this);
                    eventOut.PlateNumber = plateNumber;
                    _ = AppData.ApiServer.parkingProcessService.CommitOutAsync(eventOut);
                }
            }

            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                              $"{this.lane.name}.Card.{ce.PreferCard} - Display Valid Event");
            await ExcecuteValidEvent(identity, identityGroup, vehicleType, plateNumber,
                                     ce.EventTime, overviewImg, vehicleImg, lprImage,
                                     eventOut, eventOut.vehicle, isAlarm);
        }

        private async Task ExcecuteMonthCardEventOut(Identity identity, IdentityGroup identityGroup, VehicleBaseType vehicleType,
                                                     string plateNumber, CardEventArgs ce, ControllerInLane? controllerInLane,
                                                     Image? overviewImg, Image? vehicleImg, Image? lprImage)
        {
            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                               $"{this.lane.name}.Card.{ce.PreferCard} - Check Valid Register Vehicle");

            List<EmParkingImageType> validImageTypes = BaseLane.GetValidImageType(overviewImg, vehicleImg, lprImage);
            bool isAlarm = false;
            if (identity.Vehicles == null || identity.Vehicles.Count == 0)
            {
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                               $"{this.lane.name}.Card.{ce.PreferCard} - Invalid Register Vehicle, End Process");

                lblEventMessage.UpdateResultMessage("Thẻ tháng chưa đăng ký phương tiện", ErrorColor);
                return;
            }

            EventOutData? eventOut = null;
            string errorMessage = string.Empty;

            if (string.IsNullOrEmpty(plateNumber) && identityGroup.PlateNumberValidation != (int)EmPlateCompareRule.UnCheck)
            {
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                     $"{this.lane.name}.Card.{ce.PreferCard} - Empty Plate && Register Vehicle Count = {identity.Vehicles.Count}",
                                     identity.Vehicles);

                bool isConfirm = true;
                if (identity.Vehicles.Count > 1)
                //{
                //    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                //                         $"{this.lane.name}.Card.{ce.PreferCard} - Show Confirm Plate Request");

                //    string message = "Không nhận diện được biển số, bạn có muốn cho xe ra khỏi bãi?";
                //    frmConfirm frmConfirm = new frmConfirm(message);
                //    isConfirm = frmConfirm.ShowDialog() == DialogResult.OK;
                //    frmConfirm.Dispose();

                //    if (isConfirm)
                //    {
                //        isAlarm = true;
                //        plateNumber = identity.Vehicles[0].PlateNumber;
                //        ce.PlateNumber = plateNumber;
                //    }
                //}
                //else
                {
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                         $"{this.lane.name}.Card.{ce.PreferCard} - Show Select Plate Request");

                    var frmSelectVehicle = new frmSelectVehicle(identity.Vehicles);
                    isConfirm = frmSelectVehicle.ShowDialog() == DialogResult.OK;
                    if (isConfirm)
                    {
                        isAlarm = true;
                        plateNumber = frmSelectVehicle.selectedPlate;
                        ce.PlateNumber = plateNumber;
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
                                         $"{this.lane.name}.Card.{ce.PreferCard} - Send Check Out Normal Request");

            var eventOutResponse = await AppData.ApiServer.parkingProcessService.PostCheckOutAsync(lane.Id, ce.PlateNumber, identity,
                                                                                                    validImageTypes, false);

            var checkInOutResponse = CheckEventOutReponse(eventOutResponse, null, vehicleType, plateNumber, false);
            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                         $"{this.lane.name}.Card.{ce.PreferCard} - Check Event Out Response", checkInOutResponse);

            if (!checkInOutResponse.IsValidEvent)
            {
                isAlarm = true;
                if (!checkInOutResponse.IsContinueExcecute)
                {
                    return;
                }
                bool isConfirm = false;

                if (identity.Vehicles.Count == 1)
                {
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                         $"{this.lane.name}.Card.{ce.PreferCard} - Show Confirm Plate Request");
                    string message = $"{errorMessage}\r\nBạn có muốn cho xe ra khỏi bãi";
                    frmConfirmIn frmConfirmIn = new frmConfirmIn(message, identity, identityGroup,
                                                                 identity.Vehicles[0].customer, identity.Vehicles[0],
                                                                 plateNumber, vehicleImg, overviewImg);
                    isConfirm = frmConfirmIn.ShowDialog() == DialogResult.OK;
                    plateNumber = identity.Vehicles[0].PlateNumber;
                    ce.PlateNumber = plateNumber;
                }
                else
                {
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                         $"{this.lane.name}.Card.{ce.PreferCard} - Show Select Plate Request");
                    var frmSelectVehicle = new frmSelectVehicle(identity.Vehicles);
                    if (frmSelectVehicle.ShowDialog() == DialogResult.OK)
                    {
                        isConfirm = true;
                        plateNumber = frmSelectVehicle.selectedPlate;
                        ce.PlateNumber = plateNumber;
                    }
                }

                if (!isConfirm)
                {
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                         $"{this.lane.name}.Card.{ce.PreferCard} - Not Confirm, End Process");
                    lblEventMessage.UpdateResultMessage(StaticPool.oemConfig.AppName, SuccessColor);

                    return;
                }

                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                         $"{this.lane.name}.Card.{ce.PreferCard} - Send Check Out Force Request");

                eventOutResponse = await AppData.ApiServer.parkingProcessService.PostCheckOutAsync(lane.Id, ce.PlateNumber, identity,
                                                                                                   validImageTypes, true);

                checkInOutResponse = CheckEventOutReponse(eventOutResponse, null, vehicleType, plateNumber, true);
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                         $"{this.lane.name}.Card.{ce.PreferCard} - Check Event Out Force Response", checkInOutResponse);

                if (!checkInOutResponse.IsValidEvent)
                {
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                        $"{this.lane.name}.Card.{ce.PreferCard} - Invalid Event, End Process");

                    return;
                }
            }
            eventOut = eventOutResponse.Item1!;
            if (eventOut.OpenBarrier)
            {
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                        $"{this.lane.name}.Card.{ce.PreferCard} - Open Barrie");

                _ = BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane, this);
                _ = AppData.ApiServer.parkingProcessService.CommitOutAsync(eventOut);
            }
            else
            {
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                        $"{this.lane.name}.Card.{ce.PreferCard} - Show Confirm Open Barrie Request");

                frmConfirmOut frmConfirmOut = new frmConfirmOut(plateNumber, "Bạn có xác nhận mở barrie?",
                                                                eventOut.EventIn?.PlateNumber ?? "",
                                                                eventOut.EventIn?.Identity?.Name ?? "",
                                                                eventOut.EventIn?.IdentityGroup?.Name ?? "",
                                                                eventOut.EventIn?.IdentityGroup?.VehicleType ?? VehicleBaseType.Unknown,
                                                                eventOut.EventIn?.images ?? new Dictionary<EmParkingImageType, List<ImageData>>(),
                                                                eventOut.EventIn?.DateTimeIn ?? DateTime.Now, false, eventOut.Charge);
                bool isConfirm = frmConfirmOut.ShowDialog() == DialogResult.OK;
                if (!isConfirm)
                {
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                            $"{this.lane.name}.Card.{ce.PreferCard} - Not Confirm Open Barrie");
                    lblEventMessage.UpdateResultMessage("Không xác nhận mở barrie", ProcessColor);
                    return;
                }
                else
                {
                    tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                            $"{this.lane.name}.Card.{ce.PreferCard} - Confirm Open Barrie");
                    plateNumber = frmConfirmOut.updatePlate.ToUpper();
                    _ = BaseLane.OpenBarrieByControllerId(ce.DeviceId, controllerInLane, this);
                    eventOut.PlateNumber = plateNumber;
                    _ = AppData.ApiServer.parkingProcessService.CommitOutAsync(eventOut);
                }
            }
            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                            $"{this.lane.name}.Card.{ce.PreferCard} - Display Valid Event");

            await ExcecuteValidEvent(identity, identityGroup, vehicleType, plateNumber,
                                         ce.EventTime, overviewImg, vehicleImg, lprImage,
                                         eventOut, eventOut.vehicle, isAlarm);
        }

        private void ExcecuteSystemErrorCheckOut()
        {
            lblEventMessage.UpdateResultMessage("Không gửi được thông tin xe ra lên hệ thống, vui lòng thử lại sau giây lát", ErrorColor);
        }

        private void ExcecuteUnvalidEvent(Identity identity, VehicleBaseType vehicleType, string plate, DateTime eventTime, EventOutData? eventOut, string errorMessage)
        {
            lblEventMessage.UpdateResultMessage(errorMessage, ErrorColor);
            DisplayEventOutInfo(eventOut?.EventIn?.DateTimeIn, eventTime, plate, identity, null, vehicleType, eventOut?.vehicle, (long)(eventOut?.Charge ?? 0), eventOut?.customer, null, "", "");
        }

        private async Task ExcecuteValidEvent(Identity? identity, IdentityGroup? identityGroup, VehicleBaseType vehicleType,
                                              string detectedPlate, DateTime eventTime, Image? overviewImg, Image? vehicleImg,
                                              Image? lprImage, EventOutData eventOut,
                                              RegisteredVehicle? registeredVehicle, bool isAlarm)
        {
            DisplayEventInData(eventOut);

            string resultText = eventOut.Charge > 0 ? "Thu tiền" : "Hẹn gặp lại";
            lblEventMessage.UpdateResultMessage(resultText, SuccessColor);

            tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS,
                                 $"{this.lane.name}.EventOut.{eventOut.Id} - Display Event Out Info");

            Customer? customer = null;
            if (registeredVehicle != null)
            {
                var customerResponse = await AppData.ApiServer.parkingDataService.GetCustomerByIdAsync(registeredVehicle.CustomerId);
                if (customerResponse != null)
                {
                    customer = customerResponse.Item1;
                }
            }

            DisplayEventOutInfo(eventOut.EventIn?.DateTimeIn, eventTime, detectedPlate, identity, identityGroup, vehicleType,
                                eventOut.vehicle, (long)eventOut.Charge, customer, null, "", "");

            tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS,
                                 $"{this.lane.name}.EventOut.{eventOut.Id} - Display Led");
            BaseLane.DisplayLed(detectedPlate, eventTime, identity, identityGroup, "Hẹn gặp lại", this.lane.Id, eventOut.Charge.ToString());
            lastEvent = eventOut;

            try
            {
                tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS,
                                 $"{this.lane.name}.EventOut.{eventOut.Id} - Save Image");

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
                    tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS,
                               $"{this.lane.name}.EventOut.{eventOut.Id} - Save Alarm");

                    var response = await AppData.ApiServer.parkingProcessService.CreateAlarmAsync(identity.Code, this.lane.Id, detectedPlate, AbnormalCode.InvalidPlateNumber,
                                                                                                  imageDatas, false, identityGroup.Id.ToString(),
                                                                                                  eventOut.customer?.Id, eventOut.vehicle?.Id, "Cảnh báo biển số");
                    if (response != null)
                    {
                        BaseLane.SaveImage(response.images, imageDatas);
                    }
                }
            }
            catch (Exception ex)
            {
                tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS,
                              $"{this.lane.name}.EventOut.{eventOut.Id} - Error", ex);
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
                    ucLastEventInfos[0].UpdateEventInfo(lastEvent.Id, eventOut.images, lprImage ?? vehicleImg);
                }));
            }

            tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS,
                                 $"{this.lane.name}.EventOut.{eventOut.Id} - Create Payment Transaction");
            _ = AppData.ApiServer.paymentService.CreatePaymentTransaction(eventOut);
            if (eventOut.Charge > 0)
            {
                tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS,
                                 $"{this.lane.name}.EventOut.{eventOut.Id} - Start Send Invoice");
                string invoiceId = await SendInvoice(eventOut!, identityGroup?.Name ?? "");
                if (!string.IsNullOrEmpty(invoiceId))
                {
                    tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS,
                                 $"{this.lane.name}.EventOut.{eventOut.Id} - Start Send Success - {invoiceId}");
                    lastEvent.InvoiceId = invoiceId;
                }
            }
        }
        #endregion End xử lý sự kiện thẻ

        #region CONTROLS IN FORM

        #region ACTION - OK
        /// <summary>
        /// Hiển thị thông tin sự kiện lên giao diện
        /// </summary>
        private async void UcTop1Event_onChoosen(object sender, string eventId)
        {
            try
            {
                ClearView();

                tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS,
                                     $"{this.lane.name}.EventOut.{eventId}  - User Click To UcTopEvent");
                tblUserLog.SaveLog(this.lane.name, $"User Click To UC {eventId}");
                StopTimeRefreshUI();
                if (string.IsNullOrEmpty(eventId))
                {
                    return;
                }
                DateTime now = DateTime.Now;
                DateTime startTime = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
                DateTime endTime = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);

                tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS,
                                     $"{this.lane.name}.EventOut.{eventId}  - Get Report By EventOutId");
                var eventOutInfo = await AppData.ApiServer.reportingService.GetEventOutById(eventId);

                tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS,
                                     $"{this.lane.name}.EventOut.{eventId}  - Event Info", eventOutInfo);
                tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS,
                                     $"{this.lane.name}.EventOut.{eventId}  - Get EventIn Image");
                if (eventOutInfo.EventIn.images != null)
                {
                    ImageData? overviewImgData = eventOutInfo.EventIn.images.ContainsKey(EmParkingImageType.Overview) ?
                                                            eventOutInfo.EventIn.images[EmParkingImageType.Overview][0] : null;
                    ImageData? vehicleImgData = eventOutInfo.EventIn.images.ContainsKey(EmParkingImageType.Vehicle) ?
                                                            eventOutInfo.EventIn.images[EmParkingImageType.Vehicle][0] : null;
                    ImageData? lprImgData = eventOutInfo.EventIn.images.ContainsKey(EmParkingImageType.Plate) ?
                                                           eventOutInfo.EventIn.images[EmParkingImageType.Plate][0] : null;
                    picOverviewImageIn.ShowImageAsync(overviewImgData);
                    picVehicleImageIn.ShowImageAsync(vehicleImgData);
                    picLprImageIn.ShowImageAsync(lprImgData);
                }
                tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS,
                                     $"{this.lane.name}.EventOut.{eventId}  - Get EventOut Image");
                if (eventOutInfo.images != null)
                {
                    ImageData? overviewOutImgData = eventOutInfo.images.ContainsKey(EmParkingImageType.Overview) ?
                                                            eventOutInfo.images[EmParkingImageType.Overview][0] : null;
                    ImageData? vehicleImgOutData = eventOutInfo.images.ContainsKey(EmParkingImageType.Vehicle) ?
                                                            eventOutInfo.images[EmParkingImageType.Vehicle][0] : null;
                    ImageData? lprImgOutData = eventOutInfo.images.ContainsKey(EmParkingImageType.Plate) ?
                                                           eventOutInfo.images[EmParkingImageType.Plate][0] : null;
                    picOverviewImageOut.ShowImageAsync(overviewOutImgData);
                    picVehicleImageOut.ShowImageAsync(vehicleImgOutData);
                    picLprImage.ShowImageAsync(lprImgOutData);
                }

                lastEvent = eventOutInfo;// new EventOutData(eventInfo);
                tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS,
                                  $"{this.lane.name}.EventOut.{eventId}  - Display Event Info");
                DisplayEventOutInfo(eventOutInfo.EventIn.DateTimeIn ?? DateTime.Now, eventOutInfo.DatetimeOut ?? DateTime.Now, eventOutInfo.PlateNumber,
                                    eventOutInfo.Identity, eventOutInfo.IdentityGroup, eventOutInfo.IdentityGroup.VehicleType, eventOutInfo.vehicle,
                                    eventOutInfo.Charge, eventOutInfo.customer);

                this.Invoke(new Action(() =>
                {
                    lblPlateIn.Text = eventOutInfo.EventIn.PlateNumber;
                    txtPlate.Text = eventOutInfo.PlateNumber;
                }));
            }
            catch (Exception ex)
            {
                tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS,
                                 $"{this.lane.name}.EventOut.{eventId}  - Error", ex);
            }
            finally
            {
                StartTimerRefreshUI();
            }

        }

        /// <summary>
        /// Mở giao diện cấu hỉnh làn
        /// </summary>
        private void picSetting_Click(object sender, EventArgs e)
        {
            tblUserLog.SaveLog(this.lane.name, $"User Click To Open Setting Screen");
            if (frmMain.IsNeedToConfirmPassword)
            {
                var frmConfirmPassword = new frmConfirmPassword();
                if (frmConfirmPassword.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                frmMain.IsNeedToConfirmPassword = false;
            }
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

            string configPath = PathManagement.appLaneDirectionConfigPath(this.lane.Id);
            var newConfig = NewtonSoftHelper<LaneDirectionConfig>.DeserializeObjectFromPath(configPath) ?? LaneDirectionConfig.CreateDefault();

            if (laneDirectionConfig.IsSameConfig(newConfig))
            {
                return;
            }
            laneDirectionConfig = newConfig;
            SetUserDisplayConfig();
        }

        /// <summary>
        /// Ghi vé ra=> Chọn vé cần ghi ==> Kích hoạt sự kiện như sự kiện quẹt thẻ
        /// Lưu sự kiện cảnh báo MANUAL EVENT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnWriteOut_Click(object? sender, EventArgs e)
        {
            tblUserLog.SaveLog(this.lane.name, $"User Click To Open WriteOut Screen");
            lblEventMessage.UpdateResultMessage("Ra lệnh ghi vé ra", ProcessColor);
            frmReportIn frm = new frmReportIn(defaultImg, AppData.ApiServer, true);

            if (frm.ShowDialog() != DialogResult.OK)
            {
                lblEventMessage.UpdateResultMessage(StaticPool.oemConfig.AppName, SuccessColor);
                return;
            }

            Identity identity = (await AppData.ApiServer.parkingDataService.GetIdentityByIdAsync(frm.selectedIdentityId)).Item1;
            if (identity == null)
            {
                return;
            }
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
                if (lastEvent == null)
                {
                    continue;
                }
                //Lưu sự kiện cảnh báo
                var imageDatas = GetAllCameraImage(false);

                var response = await AppData.ApiServer.parkingProcessService.CreateAlarmAsync(lastEvent.Identity?.Code, this.lane.Id, lastEvent.PlateNumber, AbnormalCode.ManualEvent,
                                                             imageDatas, false,
                                                             lastEvent?.IdentityGroup?.Id.ToString() ?? "", "", "", "");
                if (response != null)
                {
                    await BaseLane.SaveImage(response.images, imageDatas);
                }
                break;
            }
        }

        /// <summary>
        /// Bấm nút chụp lại hình ảnh ==> Kích hoạt sự kiện như sự kiện LOOP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnReTakePhoto_Click(object? sender, EventArgs e)
        {
            tblUserLog.SaveLog(this.lane.name, $"User Click To Btn Take Photo");
            lblEventMessage.UpdateResultMessage("Ra lệnh chụp lại", ProcessColor);
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
        /// Ra lệnh mở barrie
        /// </summary>
        private async void btnOpenBarrie_Click(object sender, EventArgs e)
        {
            tblUserLog.SaveLog(this.lane.name, $"User Click To Btn Open Barrie");
            FocusOnTitle();
            await OpenAllBarrie();
            bool isOverAllowTime = ((DateTime.Now - lastEvent?.DatetimeOut)?.TotalSeconds ?? -1) >= StaticPool.appOption.AllowBarrieDelayOpenTime;

            if (lastEvent == null || isOverAllowTime)
            {
                var imageDatas = GetAllCameraImage(true);
                string plateNumber = lastEvent?.PlateNumber ?? "";
                await SaveManualAbnormalEvent(plateNumber, lastEvent?.Identity, lastEvent?.IdentityGroup, imageDatas, false);
            }
        }

        /// <summary>
        /// In Phiếu Thu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintTicket_Click(object? sender, EventArgs e)
        {
            tblUserLog.SaveLog(this.lane.name, $"User Click To Btn Print Ticket");
            lblEventMessage.UpdateResultMessage("Ra lệnh in vé xe", ProcessColor);
            FocusOnTitle();
            if (lastEvent == null)
            {
                MessageBox.Show("Không có thông tin sự kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string printTemplatePath = PathManagement.appPrintTemplateConfigPath(((EmPrintTemplate)StaticPool.appOption.PrintTemplate).ToString());
            if (!File.Exists(printTemplatePath))
            {
                MessageBox.Show("Không tìm thấy mẫu in", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string message = "Bạn có muốn in phiếu thu?";
            frmConfirm frmConfirm = new frmConfirm(message);
            bool isConfirm = frmConfirm.ShowDialog() == DialogResult.OK;
            frmConfirm.Dispose();

            if (!isConfirm)
            {
                lblEventMessage.UpdateResultMessage(StaticPool.oemConfig.AppName, SuccessColor);
                return;
            }
            AppData.printer.PrintPhieuThu(File.ReadAllText(printTemplatePath), lastEvent.Identity.Name, lastEvent.IdentityGroup.Name, null,
                                                  lastEvent.EventIn.DateTimeIn ?? DateTime.Now, lastEvent.DatetimeOut ?? DateTime.Now,
                                                  lastEvent.PlateNumber, TextFormatingTool.GetMoneyFormat(lastEvent.Charge.ToString()), lastEvent.Charge);
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
            int marginHeight = 2;
            int displayRegionHeight = panelCameras.Height - marginHeight;
            foreach (ucCameraView item in panelCameras.Controls.OfType<ucCameraView>())
            {
                if (laneDirectionConfig.cameraDirection == LaneDirectionConfig.EmCameraDirection.Vertical)
                {
                    int newWidth = panelCameras.Width - panelCameras.Margin.Left - panelCameras.Margin.Right -
                                                        panelCameras.Padding.Left - panelCameras.Padding.Right
                                                    - /*item.Margin.Left - item.Margin.Right -*/ item.Padding.Left - item.Padding.Right;
                    item.ChangeByWidth(new Size(newWidth, (displayRegionHeight) / count), this.laneDirectionConfig.cameraResolutionDisplay);
                }
                else
                {
                    item.ChangeByHeight(new Size((panelCameras.Width - panelCameras.Margin.Left - panelCameras.Margin.Right - panelCameras.Padding.Left - panelCameras.Padding.Right
                                                /*- item.Margin.Left - item.Margin.Right*/ - item.Padding.Left - item.Padding.Right) / count, panelCameras.Height - 50), this.laneDirectionConfig.cameraResolutionDisplay);
                }
            }
            for (int i = 0; i < panelCameras.Controls.OfType<ucCameraView>().ToList().Count; i++)
            {
                var item = panelCameras.Controls.OfType<ucCameraView>().ToList()[i];
                if (i == 0)
                {
                    item.Location = new Point(0, marginHeight);
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

        #region EFFECT
        private void PicRetakePhoto_MouseHover(object? sender, EventArgs e)
        {
            //this.Cursor = Cursors.Hand;
            var pictureBox = (sender as PictureBox)!;
            pictureBox.BackColor = Color.Red;
            pictureBox.Refresh();
        }
        private void picSetting_MouseLeave(object? sender, EventArgs e)
        {
            //this.Cursor = Cursors.Default;
            var pictureBox = (sender as PictureBox)!;
            pictureBox.BackColor = ErrorColor;
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
            tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS,
                                  $"{this.lane.name}.timerRefreshUI  - Stop");
            timerRefreshUI.Enabled = false;
            time_refresh = 0;
        }
        private void StartTimerRefreshUI()
        {
            if (StaticPool.oemConfig.IsAutoReturnToDefault)
            {
                tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS,
                                  $"{this.lane.name}.timerRefreshUI  - Start");
                timerRefreshUI.Enabled = true;
            }
        }
        #endregion End TIMER

        #region PRIVATE FUNCTION
        #region LOADING
        private async void CreateBaseUI()
        {
            lblEventMessage.Padding = new Padding(StaticPool.baseSize);
            lblEventMessage.UpdateResultMessage(StaticPool.oemConfig.AppName, SuccessColor);

            CreateToolTip();
            SetDefaultImage();
            if (this.laneDirectionConfig.IsDisplayLastEvent)
            {
                CreatePanelTop3Event();
                await DisplayTop3EventInfo();
            }
        }
        private void CreateToolTip()
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
            toolTipOpenBarrie.SetupToolTip(picOpenBarrie, "Mở Barrie", string.Join(",", controllserShortcut));

            if (laneOutShortcutConfig != null)
            {
                if ((Keys)laneOutShortcutConfig.ReSnapshotKey == Keys.None)
                    toolTipReTakePhoto.SetupToolTip(picRetakePhoto, "Chụp Lại", () => "");
                else
                    toolTipReTakePhoto.SetupToolTip(picRetakePhoto, "Chụp Lại", () => ((Keys)laneOutShortcutConfig.ReSnapshotKey).ToString());

                if ((Keys)laneOutShortcutConfig.WriteOut == Keys.None)
                    toolTipWriteOut.SetupToolTip(picWriteOut, "Ghi Vé Ra", () => "");
                else
                    toolTipWriteOut.SetupToolTip(picWriteOut, "Ghi Vé Ra", () => ((Keys)laneOutShortcutConfig.WriteOut).ToString());

                if ((Keys)laneOutShortcutConfig.PrintKey == Keys.None)
                    toolTipPrint.SetupToolTip(picPrint, "In Vé Xe", () => "");
                else
                    toolTipPrint.SetupToolTip(picPrint, "In Vé Xe", () => ((Keys)laneOutShortcutConfig.PrintKey).ToString());
            }
            else
            {
                toolTipReTakePhoto.SetupToolTip(picRetakePhoto, "Chụp Lại", () => "");
                toolTipWriteOut.SetupToolTip(picWriteOut, "Ghi Vé Ra", () => "");
                toolTipPrint.SetupToolTip(picPrint, "In Vé Xe", () => "");
            }
        }
        private void SetDefaultImage()
        {
            List<PictureBox> displayEventPics = new List<PictureBox>() {
                                                    picLprImageIn, picOverviewImageIn, picVehicleImageIn,
                                                    picLprImage, picOverviewImageOut, picVehicleImageOut, };
            foreach (var pic in displayEventPics)
            {
                pic.Image = pic.InitialImage = pic.ErrorImage = defaultImg;
            }
            displayEventPics.Clear();
        }
        private void CreatePanelTop3Event()
        {
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
            // 
            // ucTop2Event
            // 
            ucTop2Event.BackColor = SystemColors.ButtonHighlight;
            ucTop2Event.Dock = DockStyle.Left;
            ucTop2Event.Location = new Point(200, 0);
            ucTop2Event.Name = "ucTop2Event";
            // 
            // ucTop1Event
            // 
            ucTop1Event.BackColor = SystemColors.ButtonHighlight;
            ucTop1Event.Dock = DockStyle.Left;
            ucTop1Event.Location = new Point(0, 0);
            ucTop1Event.Name = "ucTop1Event";

            ucLastEventInfos.Add(ucTop1Event);
            ucLastEventInfos.Add(ucTop2Event);
            ucLastEventInfos.Add(ucTop3Event);

            ucTop1Event.onChoosen += UcTop1Event_onChoosen;
            ucTop2Event.onChoosen += UcTop1Event_onChoosen;
            ucTop3Event.onChoosen += UcTop1Event_onChoosen;
        }
        private async Task DisplayTop3EventInfo()
        {
            DateTime startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            DateTime endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            var top3EventReport = await AppData.ApiServer.reportingService.GetEventOuts("", startTime, endTime, "", "", this.lane.Id, "", true, 0, 3);
            var top3Event = top3EventReport?.data ?? null;
            if (top3Event != null)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (top3Event.Count <= i)
                    {
                        break;
                    }
                    string id = top3Event[i].Id.ToString() ?? "";
                    ucLastEventInfos[i].UpdateEventInfo(id, top3Event[i].images);
                }
            }
        }

        private void RegisterUIEvent()
        {
            panelCameras.SizeChanged += PanelCameras_SizeChanged;
            List<PictureBox> settingPics = new List<PictureBox>()
            {
                picRetakePhoto, picOpenBarrie, picWriteOut, picPrint,
            };
            foreach (var pic in settingPics)
            {
                pic.MouseEnter += PicRetakePhoto_MouseHover;
                pic.MouseLeave += picSetting_MouseLeave;
            }
            settingPics.Clear();

            picPrint.Click += btnPrintTicket_Click;
        }
        private void SetUserDisplayConfig()
        {
            switch (laneDirectionConfig.displayDirection)
            {
                case LaneDirectionConfig.EmDisplayDirection.Vertical:
                    splitContainerMain.Orientation = Orientation.Horizontal;
                    splitContainerMain.Panel1.Controls.Add(spliterCamera_top3Event);
                    splitContainerMain.Panel2.Controls.Add(panelEventStatus);
                    break;
                case LaneDirectionConfig.EmDisplayDirection.HorizontalLeftToRight:
                    splitContainerMain.Orientation = Orientation.Vertical;
                    splitContainerMain.Panel1.Controls.Add(spliterCamera_top3Event);
                    splitContainerMain.Panel2.Controls.Add(panelEventStatus);
                    break;
                case LaneDirectionConfig.EmDisplayDirection.HorizontalRightToLeft:
                    splitContainerMain.Orientation = Orientation.Vertical;
                    splitContainerMain.Panel1.Controls.Add(panelEventStatus);
                    splitContainerMain.Panel2.Controls.Add(spliterCamera_top3Event);
                    break;
                default:
                    break;
            }

            switch (laneDirectionConfig.cameraPicDirection)
            {
                case LaneDirectionConfig.EmCameraPicFunction.Vertical:
                    //splitterCamera.Dock = DockStyle.Top;
                    //splitContainerCamera.Dock = DockStyle.Top;
                    //splitContainerCamera.Height = 100;
                    break;
                case LaneDirectionConfig.EmCameraPicFunction.HorizontalLeftToRight:
                    //splitContainerCamera.Width = 100;
                    //splitContainerCamera.Dock = DockStyle.Left;
                    //splitterCamera.Dock = DockStyle.Left;

                    break;
                case LaneDirectionConfig.EmCameraPicFunction.HorizontalRightToLeft:
                    //splitContainerCamera.Width = 100;
                    //splitContainerCamera.Dock = DockStyle.Right;
                    //splitterCamera.Dock = DockStyle.Right;
                    break;
                default:
                    break;
            }
            switch (laneDirectionConfig.eventDirection)
            {
                case EmEventDirection.Vertical:
                    //splitContainerEventContent.Orientation = Orientation.Horizontal;
                    //splitContainerEventContent.Panel1.Controls.Add(panelLpr);
                    //splitContainerEventContent.Panel2.Controls.Add(panelEventInfo);
                    break;
                case EmEventDirection.HorizontalLeftToRight:
                    //panelEventData.Width = 300;
                    //splitContainerEventContent.Orientation = Orientation.Vertical;
                    //splitContainerEventContent.Panel1.Controls.Add(panelLpr);
                    //splitContainerEventContent.Panel2.Controls.Add(panelEventInfo);
                    break;
                case EmEventDirection.HorizontalRightToLeft:
                    //panelEventData.Width = 300;
                    //splitContainerEventContent.Orientation = Orientation.Vertical;
                    //splitContainerEventContent.Panel1.Controls.Add(panelEventInfo);
                    //splitContainerEventContent.Panel2.Controls.Add(panelLpr);
                    break;
                default:
                    break;
            }

            spliterCamera_top3Event.Panel2Collapsed = !laneDirectionConfig.IsDisplayLastEvent;
            spliterTopEvent_Actions.Visible = laneDirectionConfig.IsDisplayLastEvent;

            PanelCameras_SizeChanged(null, null);
        }
        #endregion End LOADING

        #region KEY PREVIEW - OK
        private void AllowDesignRealtime(bool isAllow)
        {
            tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS,
                                  $"{this.lane.name}  - Change Design Mode To {isAllow}");
            this.IsAllowDesignRealtime = isAllow;
            if (!this.IsAllowDesignRealtime)
            {
                if (spliterCamera.Panel2.Height <= 5)
                {
                    spliterCamera.Panel2Collapsed = true;
                }
            }
            var activeSpliters = new List<SplitContainer>()
            {
                spliterCamera ,
                spliterPicEv_PicPlate ,
                spliterCamera_PicEv_PicPlate ,
                spliterCamera_top3Event,
                spliterEvInPlate ,
                spliterEvOutPlate,
                splitContainerMain,
                spliterTopEvent_Actions
            };

            foreach (var spliter in activeSpliters)
            {
                spliter.IsSplitterFixed = !isAllow;
                spliter.SplitterWidth = isAllow ? 5 : 1;
                spliter.Refresh();
            }
            activeSpliters.Clear();
        }

        private async Task CheckControllerShortcutConfig(Keys key)
        {
            if (controllerShortcutConfigs == null)
            {
                return;
            }
            foreach (var controllerShortcutConfig in controllerShortcutConfigs)
            {
                foreach (var item in controllerShortcutConfig.KeySetByRelays)
                {
                    if (item.Value != (int)key)
                    {
                        continue;
                    }
                    string controllerId = controllerShortcutConfig.ControllerId;
                    int barrieIndex = item.Key;
                    foreach (IController controller in frmMain.controllers)
                    {
                        if (controller.ControllerInfo.Id.ToLower() == controllerId.ToLower())
                        {
                            lblEventMessage.UpdateResultMessage("Ra lệnh mở cửa: " + barrieIndex, ProcessColor);

                            //Ra lệnh mở cửa
                            await controller.OpenDoor(100, barrieIndex);

                            //Lưu lại cảnh báo mở barrie bằng nút nhấn
                            bool isOverAllowTime = ((DateTime.Now - lastEvent?.DatetimeOut)?.TotalSeconds ?? -1) >= StaticPool.appOption.AllowBarrieDelayOpenTime;
                            if (lastEvent == null || isOverAllowTime)
                            {
                                var imageDatas = GetAllCameraImage(true);
                                string plateNumber = lastEvent?.PlateNumber ?? "";
                                await SaveManualAbnormalEvent(plateNumber, lastEvent?.Identity, lastEvent?.IdentityGroup, imageDatas, false);
                            }
                            break;
                        }
                    }
                }
            }
        }

        private async Task CheckLaneInShortcutConfig(Keys keys)
        {
            if (laneOutShortcutConfig is null)
            {
                return;
            }
            if ((int)keys == laneOutShortcutConfig.ConfirmPlateKey && txtPlate.Focused && this.lastEvent != null)
            {
                await ExitPlateOnUI();
            }
            else if ((int)keys == laneOutShortcutConfig.ReverseLane)
            {
                ReverseLane();
            }
            else if ((int)keys == laneOutShortcutConfig.WriteOut)
            {
                BtnWriteOut_Click(null, EventArgs.Empty);
            }
            else if ((int)keys == laneOutShortcutConfig.ReSnapshotKey)
            {
                BtnReTakePhoto_Click(null, EventArgs.Empty);
            }
            else if ((int)keys == laneOutShortcutConfig.PrintKey)
            {
                btnPrintTicket_Click(null, EventArgs.Empty);
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
            var isUpdateSuccess = await AppData.ApiServer.parkingProcessService.UpdateEventOutPlate(lastEvent!.Id, newPlate, lastEvent.PlateNumber);
            if (isUpdateSuccess)
            {
                lblEventMessage.UpdateResultMessage("Ra Lệnh Cập Nhật Biển Số Thành Công", ProcessColor);
                lastEvent.PlateNumber = newPlate;
            }
            else
            {
                lblEventMessage.UpdateResultMessage("Cập nhật lỗi, vui lòng thử lại", ProcessColor);
            }
        }
        private void ReverseLane()
        {
            if (string.IsNullOrEmpty(this.lane.reverseLaneId?.ToString()))
            {
                //Chưa cấu hình làn đảo
                lblEventMessage.UpdateResultMessage("Chưa có cấu hình làn đảo", ProcessColor);
                return;
            }
            var config = GetCurrentUIConfig();
            NewtonSoftHelper<LaneDisplayConfig>.SaveConfig(config, PathManagement.appDisplayConfigPath(this.lane.Id));
            lblEventMessage.UpdateResultMessage("Ra Lệnh Đảo Làn", ProcessColor);
            OnChangeLaneEventInvoke(this);
            this.Dispose();
            return;
        }
        #endregion End KEY PREVIEW

        #region PROCESS
        private void FocusOnTitle()
        {
            this.Invoke(new Action(() =>
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
                lblEventMessage.UpdateResultMessage("Không đọc được thông tin định danh, vui lòng thử lại", ErrorColor);
                return Tuple.Create<bool, Identity?>(false, null);
            }

            Identity? identity = identityResponse.Item1;
            if (identity == null)
            {
                lblEventMessage.UpdateResultMessage("Mã định danh không có trong hệ thống", ErrorColor);
                return Tuple.Create<bool, Identity?>(false, null);
            }

            if (identity.Status == IdentityStatus.Locked)
            {
                lblEventMessage.UpdateResultMessage("Định danh - ngừng sử dụng", ErrorColor);
                return Tuple.Create<bool, Identity?>(false, identity);
            }
            return Tuple.Create<bool, Identity?>(true, identity);
        }
        /// <summary>
        /// Kiểm tra kết quả check in nhận từ server <br/>
        /// <param> <paramref name="eventOutReponse"/> Kết quả nhận từ server</param> <br/>
        /// <param name="customer"> <paramref name="customer"/> Thông tin khách hàng, khi lỗi sẽ hiển thị thông tin</param> <br/>
        /// <param name="vehicleBaseType"> <paramref name="vehicleBaseType"/> Thông tin loại xe, khi lỗi sẽ hiển thị thông tin</param> <br/>
        /// <param name="plateNumber"> <paramref name="plateNumber"/> Biển số xe</param> <br/>
        /// <param name="isForce"> <paramref name="isForce"/> Biến xác định là check in normal hay force, nếu force thì tự động dừng lại nếu lỗi</param> <br/>
        /// </summary>
        /// <returns></returns>
        private CheckEventOutResponse CheckEventOutReponse(Tuple<EventOutData, BaseErrorData> eventOutReponse, Customer? customer,
                                                          VehicleBaseType vehicleBaseType, string plateNumber,
                                                          bool isForce)
        {
            CheckEventOutResponse checkInOutResponse = new CheckEventOutResponse()
            {
                IsContinueExcecute = false,
                IsValidEvent = false,
                eventOut = eventOutReponse.Item1,
                ErrorMessage = string.Empty,
                ErrorData = eventOutReponse.Item2,
            };
            if (eventOutReponse == null)
            {
                ExcecuteSystemErrorCheckOut();
                return checkInOutResponse;
            }

            if (checkInOutResponse.eventOut is null && checkInOutResponse.ErrorData is null)
            {
                ExcecuteSystemErrorCheckOut();
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
                    ExcecuteSystemErrorCheckOut();
                    return checkInOutResponse;
                }
                checkInOutResponse.ErrorMessage = checkInOutResponse.ErrorData.fields[0].ToString();
                if (isForce)
                {
                    ExcecuteUnvalidEvent(null, vehicleBaseType, plateNumber, DateTime.Now, null, checkInOutResponse.ErrorMessage);
                    return checkInOutResponse;
                }
                else
                {
                    // Sử dụng cho các trường hợp phương tiện hết hạn sử dụng, ngoài giờ được phép sử dụng
                    if (!allowAlarmMessage.Contains(checkInOutResponse.ErrorMessage))
                    {
                        ExcecuteUnvalidEvent(null, vehicleBaseType, plateNumber, DateTime.Now, null, checkInOutResponse.ErrorMessage);
                        return checkInOutResponse;
                    }
                    checkInOutResponse.IsContinueExcecute = true;
                    return checkInOutResponse;
                }
            }
        }
        private Dictionary<EmParkingImageType, List<List<byte>>> GetAllCameraImage(bool isDisplay)
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
                        if (isDisplay)
                        {
                            try
                            {
                                picOverviewImageOut.Image = overviewImg;
                            }
                            catch (Exception)
                            {
                            }
                        }
                        break;
                    case CameraPurposeType.EmCameraPurposeType.CarLPR:
                        carVehicleImage = ucCarLpr?.GetFullCurrentImage();
                        if (!imageData.ContainsKey(EmParkingImageType.Vehicle))
                            imageData.Add(EmParkingImageType.Vehicle, new List<List<byte>>() { carVehicleImage.ImageToByteArray() });
                        if (isDisplay)
                        {
                            try
                            {
                                picVehicleImageOut.Image = carVehicleImage;
                            }
                            catch (Exception)
                            {
                            }
                        }
                        break;
                    case CameraPurposeType.EmCameraPurposeType.MotorLPR:
                        motorVehicleImage = ucMotoLpr?.GetFullCurrentImage();
                        if (!imageData.ContainsKey(EmParkingImageType.Vehicle))
                            imageData.Add(EmParkingImageType.Vehicle, new List<List<byte>>() { motorVehicleImage.ImageToByteArray() });
                        if (isDisplay)
                        {
                            try
                            {
                                picVehicleImageOut.Image = motorVehicleImage;
                            }
                            catch (Exception)
                            {
                            }
                        }
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

        private void DisplayEventInData(EventOutData eventOut)
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
        private void DisplayEventOutInfo(DateTime? timeIn, DateTime timeOut, string plateNumber, Identity identity, IdentityGroup identityGroup, VehicleBaseType vehicle,
                                        RegisteredVehicle? registerVehicle, long fee, Customer? customer, WeighingDetail? weighingDetail = null, string thirdPartyNote = "", string note = "")
        {
            laneDirectionConfig = NewtonSoftHelper<LaneDirectionConfig>.DeserializeObjectFromPath(
                                                     PathManagement.appLaneDirectionConfigPath(this.lane.Id)) ?? LaneDirectionConfig.CreateDefault();

            if (identityGroup != null)
            {
                tblEventContent.SuspendLayout();
                if (identityGroup.Type == IdentityGroupType.Daily)
                {
                    for (int i = 2; i < tblEventContent.ColumnCount; i++)
                    {
                        tblEventContent.ColumnStyles[i].SizeType = SizeType.Absolute;
                        tblEventContent.ColumnStyles[i].Width = 0;
                    }
                }
                else
                {
                    for (int i = 0; i < tblEventContent.ColumnCount; i++)
                    {
                        if (i % 2 == 0)
                        {
                            tblEventContent.ColumnStyles[i].SizeType = SizeType.Absolute;
                            tblEventContent.ColumnStyles[i].Width = 80;
                        }
                        else
                        {
                            tblEventContent.ColumnStyles[i] = new ColumnStyle(SizeType.Percent, 50F);
                        }
                    }
                    if (!StaticPool.appOption.IsDisplayCustomerInfo)
                    {
                        tblEventContent.ColumnStyles[2].SizeType = SizeType.Absolute;
                        tblEventContent.ColumnStyles[2].Width = 0;
                        tblEventContent.ColumnStyles[3].SizeType = SizeType.Absolute;
                        tblEventContent.ColumnStyles[3].Width = 0;
                    }
                }
                tblEventContent.PerformLayout();
                tblEventContent.ResumeLayout(true);
            }

            lblFee.Message = TextFormatingTool.GetMoneyFormat(fee.ToString());
            lblIdentityGroupName.Message = identityGroup?.Name ?? "";
            lblIdentityName.Message = identity?.Name ?? "";
            lblIdentityCode.Message = identity?.Code ?? "";

            if (timeIn != null)
            {
                lblTimeOut.Message = timeOut.ToString("dd/MM/yyyy HH:mm:ss");
                lblTimeIn.Message = timeIn.Value.ToString("dd/MM/yyyy HH:mm:ss");
                TimeSpan ParkingTime = (TimeSpan)(timeOut - timeIn)!;
                string formattedTime = "";
                if (ParkingTime.TotalDays > 1)
                {
                    lblParkingTime.Message = string.Format("{0} ngày\r\n{1} giờ {2} phút", ParkingTime.Days, ParkingTime.Hours,
                                                                               ParkingTime.Minutes, ParkingTime.Seconds);
                }
                else
                {
                    lblParkingTime.Message = string.Format("{0} giờ {1} phút {2} giây", ParkingTime.Hours, ParkingTime.Minutes, ParkingTime.Seconds);
                }
            }

            if (StaticPool.appOption.IsDisplayCustomerInfo)
            {
                if (customer != null)
                {
                    lblCustomerGroupName.Message = customer.customerGroup?.Name ?? "";
                    lblCustomerName.Message = customer.Name;
                    lblCustomerPhone.Message = customer.PhoneNumber;
                    lblCustomerAddress.Message = customer.Address;
                }
            }

            if (registerVehicle != null)
            {
                lblRegisterVehilceName.Message = registerVehicle.Name;
                lblRegisterPlate.Message = registerVehicle.PlateNumber;
                lblRegisterVehileExpireDate.Message = registerVehicle.ExpireTime!.Value.ToVNTime() ?? DateTime.Now.ToVNTime();
                double remainingTime = (registerVehicle.ExpireTime.Value - DateTime.Now).TotalDays;
                lblRegisterVehicleValidTime.Message = (int)remainingTime + " ngày";

                if (remainingTime <= 7)
                {
                    lblRegisterVehileExpireDate.MessageForeColor = Color.DarkRed;
                }
                else
                {
                    lblRegisterVehileExpireDate.MessageForeColor = Color.DarkGreen;
                }
            }

            //dgvEventContent!.Invoke(new Action(() =>
            //{
            //    dgvEventContent.Columns[0].Visible = laneDirectionConfig.IsDisplayTitle;

            //    dgvEventContent.Rows.Clear();

            //    dgvEventContent.Rows.Add("Phí gửi xe", TextFormatingTool.GetMoneyFormat(fee.ToString()));
            //    if (this.Width < 1500)
            //    {
            //        dgvEventContent.Rows[dgvEventContent.RowCount - 1].DefaultCellStyle.Font = new Font(dgvEventContent.DefaultCellStyle.Font.Name,
            //                                                                                            20, FontStyle.Bold);
            //    }
            //    else
            //    {
            //        dgvEventContent.Rows[dgvEventContent.RowCount - 1].DefaultCellStyle.Font = new Font(dgvEventContent.DefaultCellStyle.Font.Name,
            //                                                                                            dgvEventContent.DefaultCellStyle.Font.Size * 3, FontStyle.Bold);
            //    }
            //    dgvEventContent.Rows[dgvEventContent.RowCount - 1].DefaultCellStyle.ForeColor = Color.Red;

            //    if (timeIn != null)
            //    {
            //        TimeSpan ParkingTime = (TimeSpan)(timeOut - timeIn)!;
            //        string formattedTime = "";
            //        if (ParkingTime.TotalDays > 1)
            //        {
            //            formattedTime = string.Format("{0} ngày {1} giờ {2} phút", ParkingTime.Days, ParkingTime.Hours,
            //                                                                       ParkingTime.Minutes, ParkingTime.Seconds);
            //        }
            //        else
            //        {
            //            formattedTime = string.Format("{0} giờ {1} phút", ParkingTime.Hours, ParkingTime.Minutes, ParkingTime.Seconds);
            //        }
            //        dgvEventContent.Rows.Add("Thời gian lưu bãi", formattedTime);

            //        dgvEventContent.Rows.Add("Giờ Vào", timeIn?.ToString("dd/MM/yyyy HH:mm:ss"));
            //        dgvEventContent.Rows.Add("Giờ ra", timeOut.ToString("dd/MM/yyyy HH:mm:ss"));
            //    }
            //    else
            //    {
            //        dgvEventContent.Rows.Add("Thời gian ra", timeOut.ToString("dd/MM/yyyy HH:mm:ss"));
            //    }
            //    dgvEventContent.Rows.Add("Loại Xe", VehicleType.GetDisplayStr(vehicle));

            //    dgvEventContent.Rows.Add("Vé Xe", identity?.Code ?? "" + " - " + identity?.Code ?? "");

            //    if (StaticPool.appOption.IsDisplayCustomerInfo)
            //    {
            //        if (customer != null)
            //        {
            //            dgvEventContent.Rows.Add("Nhóm khách hàng", customer.CustomerGroupName);
            //            dgvEventContent.Rows.Add("Khách hàng", customer.Name + " / " + customer.Address);
            //            dgvEventContent.Rows.Add("SĐT", customer.PhoneNumber);
            //        }
            //    }

            //    if (registerVehicle != null)
            //    {
            //        dgvEventContent.Rows.Add("BSĐK", registerVehicle.Name + " / " + registerVehicle.PlateNumber);
            //        dgvEventContent.Rows.Add("Hết hạn", registerVehicle.ExpireTime?.ToString("dd/MM/yyyy HH:mm:ss"));
            //    }

            //    dgvEventContent.Rows.Add("Nhóm định danh", identityGroup?.Name);
            //    dgvEventContent.BringToFront();
            //    dgvEventContent.CurrentCell = null;
            //    this.ActiveControl = lblLaneName;
            //}));
        }
        private async Task<string> SendInvoice(EventOutData eventOut, string identityGroupName)
        {
            if (AppData.ApiServer.invoiceService == null)
            {
                return "";
            }
            string message = $"Bạn có muốn gửi hóa đơn ({TextFormatingTool.GetMoneyFormat(eventOut.Charge.ToString())}) không?";
            frmConfirm frmConfirm = new frmConfirm(message);
            bool isConfirmSendEinvoie = frmConfirm.ShowDialog() == DialogResult.OK;
            frmConfirm.Dispose();

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

        private void ClearView()
        {
            this.Invoke(new Action(() =>
            {
                FocusOnTitle();

                lastEvent = null;

                lblFee.Message = lblIdentityGroupName.Message =
                lblIdentityName.Message =
                lblIdentityCode.Message =
                lblTimeIn.Message =
                lblTimeOut.Message =
                lblCustomerGroupName.Message =
                lblCustomerName.Message =
                lblCustomerPhone.Message =
                lblCustomerAddress.Message =
                lblRegisterVehilceName.Message =
                lblRegisterPlate.Message =
                lblRegisterVehileExpireDate.Message =
                lblRegisterVehicleValidTime.Message = "_ _ _ _ _";

                //dgvEventContent.Rows.Clear();
                picOverviewImageIn.Image = picVehicleImageIn.Image =
                picLprImage.Image = picOverviewImageOut.Image =
                picVehicleImageOut.Image = picLprImageIn.Image = defaultImg;

                lblPlateIn.Text = txtPlate.Text = string.Empty;

                lblEventMessage.UpdateResultMessage(StaticPool.oemConfig.AppName, SuccessColor);
            }));
        }
        #endregion End PROCESS
        #endregion End PRIVATE FUNCTION

        #region PUBLIC FUNCTION
        public void DispayUI()
        {
            lblLaneName.Text = lane.name;
            lblLaneName.BackColor = ErrorColor;

            spliterCamera_top3Event.Panel2Collapsed = !laneDirectionConfig.IsDisplayLastEvent;
            spliterTopEvent_Actions.Visible = laneDirectionConfig.IsDisplayLastEvent;

            txtPlate.Enabled = StaticPool.appOption.IsAllowEditPlateOut;

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
            laneOutShortcutConfig = NewtonSoftHelper<LaneOutShortcutConfig>.DeserializeObjectFromPath(PathManagement.laneShortcutConfigPath(this.lane.Id)) ?? new LaneOutShortcutConfig();
            controllerShortcutConfigs = NewtonSoftHelper<List<ControllerShortcutConfig>>.DeserializeObjectFromPath(PathManagement.laneControllerShortcutConfigPath(this.lane.Id)) ?? new List<ControllerShortcutConfig>();
        }

        /// <summary>
        /// Hiển thị giao diện như lần cuối cùng sử dụng
        /// </summary>
        public void LoadSavedUIConfig()
        {
            if (this.laneDisplayConfig == null)
            {
                return;
            }

            try
            {
                this.splitContainerMain.SplitterDistance = this.laneDisplayConfig.splitContainerMain;

                this.spliterCamera_top3Event.SplitterDistance = this.laneDisplayConfig.spliterCamera_top3Event;

                this.spliterCamera_PicEv_PicPlate.SplitterDistance = this.laneDisplayConfig.spliterCamera_PicEv_PicPlate;
                this.spliterPicEv_PicPlate.SplitterDistance = this.laneDisplayConfig.spliterPicEv_PicPlate;
                this.spliterEvInPlate.SplitterDistance = this.laneDisplayConfig.spliterEvInPlate;
                this.spliterEvOutPlate.SplitterDistance = this.laneDisplayConfig.spliterEvOutPlate;
                this.spliterCamera.SplitterDistance = this.laneDisplayConfig.SplitterCameraPosition;

                this.spliterTopEvent_Actions.SplitterDistance = this.laneDisplayConfig.spliterTopEvent_Actions;
            }
            catch (Exception ex)
            {
                tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS, "LoadSavedUIConfig", ex);
            }

            AllowDesignRealtime(false);
            this.ResumeLayout();
        }

        /// <summary>
        /// Lấy thông tin hiển thị hiện tại để lưu lại
        /// </summary>
        /// <returns></returns>
        public LaneDisplayConfig GetCurrentUIConfig()
        {
            //AllowDesignRealtime(true);
            return new LaneDisplayConfig()
            {
                LaneId = this.lane.Id,
                DisplayIndex = 1,
                splitContainerMain = this.splitContainerMain.SplitterDistance,
                SplitterCameraPosition = this.spliterCamera.SplitterDistance,
                spliterCamera_PicEv_PicPlate = this.spliterCamera_PicEv_PicPlate.SplitterDistance,
                spliterCamera_top3Event = this.spliterCamera_top3Event.SplitterDistance,
                spliterPicEv_PicPlate = this.spliterPicEv_PicPlate.SplitterDistance,
                spliterEvInPlate = this.spliterEvInPlate.SplitterDistance,
                spliterEvOutPlate = this.spliterEvOutPlate.SplitterDistance,
                spliterTopEvent_Actions = this.spliterTopEvent_Actions.SplitterDistance,
            };
        }
        #endregion End PUBLIC FUNCTION

        private void panelTop3Event_SizeChanged(object sender, EventArgs e)
        {
            foreach (ucLastEventInfo item in panelTop3Event.Controls.OfType<ucLastEventInfo>())
            {
                item.UpdateSize();
            }
        }
    }
}