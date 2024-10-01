﻿using IPaking.Ultility;
using iPakrkingv5.Controls.Controls.Labels;
using iPakrkingv5.Controls.Usercontrols;
using iParkingv5.Controller;
using iParkingv5.Controller.KztekDevices.MT166_CardDispenser;
using iParkingv5.Controller.KztekDevices;
using iParkingv5.LedDisplay.LEDs;
using iParkingv5.Objects;
using iParkingv5.Objects.Configs;
using iParkingv5.Objects.Datas.Device_service;
using iParkingv5.Objects.Datas.parking_service;
using iParkingv5.Objects.Enums;
using iParkingv5.Objects.EventDatas;
using iParkingv5.Objects.Events;
using iParkingv5_window.Forms.DataForms;
using Kztek.Tool;
using Kztek.Tool.LogDatabases;
using Kztek.Tools;
using static iParkingv5.Objects.Enums.ParkingImageType;
using static iParkingv5.Objects.Enums.SoundType;
using iParkingv5.ApiManager.TienPhong;
using iParkingv5.Objects.Datas.ThirtParty.TienPhong;

namespace iParkingv5_window.Usercontrols
{
    public static class BaseLane
    {
        public static bool CheckNewCardEvent(this iLane iLane, Lane lane, CardEventArgs ce,
                                             out ControllerInLane? controllerInLane, out int thoiGianCho)
        {
            thoiGianCho = 0;
            DateTime eventTime = DateTime.Now;
            bool isValidControllerIdAndReader = IsValidControllerAndReader(lane, ce, out controllerInLane);
            if (!isValidControllerIdAndReader) return false;

            foreach (CardEventArgs oldEvent in iLane.lastCardEventDatas)
            {
                if (ce.IsInWaitingTime(oldEvent, StaticPool.appOption.MinDelayCardTime, out thoiGianCho))
                {
                    return false;
                }
            }

            List<CardEventArgs> deleteEvents = new List<CardEventArgs>();
            foreach (var item in iLane.lastCardEventDatas)
            {
                foreach (string card in ce.AllCardFormats)
                {
                    if (item.AllCardFormats.Contains(card))
                    {
                        deleteEvents.Add(item);
                    }
                }
            }
            foreach (var item in deleteEvents)
            {
                iLane.lastCardEventDatas.Remove(item);
            }
            deleteEvents.Clear();

            iLane.lastCardEventDatas.Add(ce);
            return true;
        }

        private static bool IsValidControllerAndReader(Lane lane, CardEventArgs ce, out ControllerInLane? controllerInLane)
        {
            controllerInLane = null;
            bool isValidControllerIdAndReader = false;
            foreach (ControllerInLane _controllerInLane in lane.controlUnits)
            {
                if (_controllerInLane.controlUnitId.ToLower() != ce.DeviceId.ToLower())
                {
                    continue;
                }

                //Danh sách đăng ký có không có reader của sự kiện ==> Bỏ qua
                if (!_controllerInLane.readers.Contains(ce.ReaderIndex))
                {
                    continue;
                }
                isValidControllerIdAndReader = true;
                controllerInLane = _controllerInLane;
            }

            return isValidControllerIdAndReader;
        }
        public static void DisplayLed(string plate, DateTime datetimeIn, Identity? identity, IdentityGroup? identityGroup, string message, string laneId, string fee)
        {
            foreach (Lane item in StaticPool.lanes)
            {
                if (item.Id == laneId)
                {
                    if (!item.displayLed)
                    {
                        return;
                    }
                }
            }
            foreach (Led item in StaticPool.leds)
            {
                IDisplayLED? led = LedFactory.CreateLed(item);
                if (led != null)
                {
                    LedDisplayConfig? ledConfig = NewtonSoftHelper<LedDisplayConfig>.DeserializeObjectFromPath(
                                                    PathManagement.laneLedConfigPath(laneId, item.id));
                    if (ledConfig != null)
                    {
                        ParkingData parkingData = new ParkingData();
                        parkingData.Plate = plate;
                        parkingData.CardNo = identity?.Name ?? "";
                        parkingData.CardNumber = identity?.Code ?? "";
                        parkingData.CardType = identityGroup?.Type.ToString() ?? "";
                        parkingData.DatetimeIn = datetimeIn;
                        parkingData.DatetimeOut = null;
                        parkingData.EventStatus = message;
                        parkingData.Money = fee;
                        led.Connect(item);
                        led.SendToLED(parkingData, ledConfig);
                    }
                }
            }
        }
        static List<Type> allowedTypes = new List<Type>
        {
            typeof(MT166_CardDispenser),
            typeof(MT166_CardDispenserv8),
        };
        public static async void PlaySound(string controllerId, EmSoundType soundType)
        {
            try
            {
                foreach (IController item in frmMain.controllers)
                {
                    if (item.ControllerInfo.Id.ToLower() == controllerId.ToLower())
                    {
                        if (allowedTypes.Contains(item.GetType()) && item is BaseKzDevice baseKzDevice)
                        {
                            int mappedSoundType = MapSoundType(soundType, baseKzDevice);

                            bool isOpenSuccess = false;
                            isOpenSuccess = await baseKzDevice.SetAudio(mappedSoundType);
                            if (!isOpenSuccess)
                            {
                                LogHelper.Log(
                                    logType: LogHelper.EmLogType.ERROR,
                                    doi_tuong_tac_dong: LogHelper.EmObjectLogType.Controller,
                                    hanh_dong: "PLAY SOUND",
                                    mo_ta_them: "THẤT BẠI",
                                    specailName: "");        //controllerInLane.controlUnitId);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }
        public static int MapSoundType(SoundType.EmSoundType globalSoundType, BaseKzDevice device)
        {
            if (device is MT166_CardDispenser)
            {
                /// Map sound bộ V1
                //return globalSoundType switch
                //{
                //    SoundType.EmSoundType.LOOP_PULSE_ON_SOUND => (int)MT166_CardDispenser.EmSoundType.LOOP_PULSE_ON_SOUND,
                //    SoundType.EmSoundType.OPEN_BARRIER_SOUND => (int)MT166_CardDispenser.EmSoundType.OPEN_BARRIER_SOUND,
                //    _ => throw new ArgumentException("Invalid sound type"),
                //};
            }
            if (device is MT166_CardDispenserv8)
            {
                /// Map sound bộ V8
                return globalSoundType switch
                {
                    SoundType.EmSoundType.LOOP_PULSE_ON_SOUND => (int)MT166_CardDispenserv8.EmSoundType.LOOP_PULSE_ON_SOUND,
                    SoundType.EmSoundType.OPEN_BARRIER_SOUND => (int)MT166_CardDispenserv8.EmSoundType.OPEN_BARRIER_SOUND,
                    SoundType.EmSoundType.INVALID_PLATE => (int)MT166_CardDispenserv8.EmSoundType.INVALID_PLATE,
                    SoundType.EmSoundType.CARD_NOT_EXIST => (int)MT166_CardDispenserv8.EmSoundType.CARD_NOT_EXIST,
                    SoundType.EmSoundType.CARD_EXPIRED => (int)MT166_CardDispenserv8.EmSoundType.CARD_EXPIRED,
                    SoundType.EmSoundType.THE_CHUA_RA_KHOI_BAI => (int)MT166_CardDispenserv8.EmSoundType.THE_CHUA_RA_KHOI_BAI,
                    SoundType.EmSoundType.CARD_EMPTY => (int)MT166_CardDispenserv8.EmSoundType.CARD_EMPTY,
                    SoundType.EmSoundType.CARD_DISPENSING_ERROR => (int)MT166_CardDispenserv8.EmSoundType.CARD_DISPENSING_ERROR,
                    _ => throw new ArgumentException("Invalid sound type"),
                };
            }
            return (int)globalSoundType;
        }
        public static void UpdateResultMessage(this lblResult lblResult, string message, Color backColor)
        {
            lblResult.BeginInvoke(() =>
            {
                lblResult.Message = message;
                lblResult.BackColor = backColor;
            });
        }
        public static string GetBaseImageKey(string laneName, string cardNumber, string plate, DateTime eventTime)
        {
            string imageKey = $"{laneName}/{eventTime.ToString("yyyy/MM/dd")}/{cardNumber}_{plate.Replace("-", "").Replace(" ", "").Replace(".", "")}" + eventTime.ToString("_HH_mm_ss_ffff");
            return imageKey;
        }

        public static async Task OpenBarrieByControllerId(string controllerId, ControllerInLane? controllerInLane, iLane iLane, string plate = "", bool isIn = false)
        {
            // Fixme
            
            TienPhongConFirmOpenBarrier(plate, isIn);

            foreach (IController item in frmMain.controllers)
            {
                if (item.ControllerInfo.Id.ToLower() == controllerId.ToLower())
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
        public static async Task OpenAllBarrie(iLane _iLane)
        {
            foreach (IController item in frmMain.controllers)
            {
                foreach (ControllerInLane controllerInLane in _iLane.lane.controlUnits)
                {
                    for (int i = 0; i < controllerInLane.barriers.Length; i++)
                    {
                        bool isOpenSuccess = !await item.OpenDoor(100, controllerInLane.barriers[i]);
                        if (!isOpenSuccess)
                        {
                            tblDeviceLog.SaveLog(item.ControllerInfo.Id, item.ControllerInfo.Name, "", "",
                                                     "Mở barrie Lần 1 Thất Bại");
                            isOpenSuccess = await item.OpenDoor(100, controllerInLane.barriers[i]);
                            if (!isOpenSuccess)
                            {
                                tblDeviceLog.SaveLog(item.ControllerInfo.Id, item.ControllerInfo.Name, "", "",
                                                     "Mở barrie Lần 2 Thất Bại");
                            }
                        }
                        if (isOpenSuccess)
                        {
                            tblDeviceLog.SaveLog(item.ControllerInfo.Id, item.ControllerInfo.Name, "", "",
                                                 "Mở barrie Thành Công");
                        }
                    }
                }
            }
        }
        public static async void TienPhongConFirmOpenBarrier(string plate, bool isIn)
        {
            
            AskOpenData data = new AskOpenData()
            {
                warehouse = "NCT3",
                truck_reg_no = plate,
                status = isIn ? "IN" : "OUT",
                update_user = "abc@1",
            };
            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                       $"Bắt đầu call api ParkingLotBarrier - plate = {plate}"); 

            if (await TienPhongApiHelper.ParkingLotBarrier(data))
            {
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                       $"Response api ParkingLotBarrier success - data = {Newtonsoft.Json.JsonConvert.SerializeObject(data)}");
            }
            else
            {
                tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.CARD_EVENT,
                                       $"Response api ParkingLotBarrier fail - data = {Newtonsoft.Json.JsonConvert.SerializeObject(data)}");
            }
        }
        public static void GetPlate(string laneId, out Image? vehicleImg, out string plate, out Image? lprImage, ucCameraView? ucCameraView, List<Kztek.Cameras.Camera> camDuPhongs, bool isCar)
        {
            Rectangle? config = null;
            if (File.Exists(PathManagement.laneCameraConfigPath(laneId, ucCameraView?._Camera.ID)))
            {
                CameraDetectRegion? cameraDetectRegion = NewtonSoftHelper<CameraDetectRegion>.DeserializeObjectFromPath(PathManagement.laneCameraConfigPath(laneId, ucCameraView._Camera.ID));
                if (cameraDetectRegion != null)
                {
                    config = new Rectangle()
                    {
                        X = cameraDetectRegion.X,
                        Y = cameraDetectRegion.Y,
                        Width = cameraDetectRegion.Width,
                        Height = cameraDetectRegion.Height
                    };
                }
            }
            vehicleImg = ucCameraView?.GetFullCurrentImage();
            plate = AppData.LprDetect.GetPlateNumber(vehicleImg, isCar, config, out lprImage);
            if (string.IsNullOrEmpty(plate))
            {
                for (int i = 0; i < camDuPhongs.Count; i++)
                {
                    if (File.Exists(PathManagement.laneCameraConfigPath(laneId, camDuPhongs[i].ID)))
                    {
                        CameraDetectRegion? cameraDetectRegion = NewtonSoftHelper<CameraDetectRegion>.DeserializeObjectFromPath(PathManagement.laneCameraConfigPath(laneId, ucCameraView._Camera.ID));
                        if (cameraDetectRegion != null)
                        {
                            config = new Rectangle()
                            {
                                X = cameraDetectRegion.X,
                                Y = cameraDetectRegion.Y,
                                Width = cameraDetectRegion.Width,
                                Height = cameraDetectRegion.Height
                            };
                        }
                    }
                    var tempImg = camDuPhongs[i].GetCurrentVideoFrame();
                    plate = AppData.LprDetect.GetPlateNumber(tempImg, isCar, config, out lprImage);
                    if (!string.IsNullOrEmpty(plate))
                    {
                        vehicleImg = tempImg;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Lưu hình ảnh lên server
        /// </summary>
        /// <param name="imagesInfo"></param>
        /// <param name="imageDatas"></param>
        /// <returns></returns>
        public static async Task SaveImage(Dictionary<EmParkingImageType, List<ImageData>>? imagesInfo,
                                     Dictionary<EmParkingImageType, List<List<byte>>> imageDatas)
        {
            if (imagesInfo == null) return;
            List<Task> tasks = new List<Task>();
            foreach (KeyValuePair<EmParkingImageType, List<ImageData>> item in imagesInfo)
            {
                for (int i = 0; i < item.Value.Count; i++)
                {
                    var imgInfo = item.Value[i];
                    tasks.Add(AppData.ApiServer.parkingProcessService.SaveEventImage(imgInfo.bucket, imgInfo.objectKey, imgInfo.type, imageDatas[item.Key][i]));
                }
            }
            if (tasks.Count == 0)
            {
                return;
            }
            await Task.WhenAll(tasks);
        }
        public static List<EmParkingImageType> GetValidImageType(Image? overviewImg, Image? vehicleImg, Image? lprImage)
        {
            List<EmParkingImageType> validImageTypes = new List<EmParkingImageType>();
            if (overviewImg != null)
            {
                validImageTypes.Add(EmParkingImageType.Overview);
            }
            if (vehicleImg != null)
            {
                validImageTypes.Add(EmParkingImageType.Vehicle);
            }
            if (lprImage != null)
            {
                validImageTypes.Add(EmParkingImageType.Plate);
            }

            return validImageTypes;
        }

        public static void ShowImage(MovablePictureBox pictureBox, Image? img)
        {
            pictureBox.Invoke(new Action(() =>
            {
                try
                {
                    Bitmap? bmp = img == null ? null : new Bitmap(img.Clone() as Image);
                    pictureBox.Image = bmp == null ? pictureBox.ErrorImage : bmp.GetThumbnailImage(pictureBox.Width, pictureBox.Height, null, IntPtr.Zero);
                    pictureBox.Tag = bmp;
                    //pictureBox.Refresh();
                }
                catch (Exception ex)
                {
                    pictureBox.Image = pictureBox.ErrorImage;
                }
            }));
        }

        public static void ShowImage(PictureBox pictureBox, Image? img)
        {
            pictureBox.Invoke(new Action(() =>
            {
                try
                {
                    Bitmap? bmp = img == null ? null : new Bitmap(img.Clone() as Image);
                    pictureBox.Image = bmp == null ? pictureBox.ErrorImage : bmp.GetThumbnailImage(pictureBox.Width, pictureBox.Height, null, IntPtr.Zero);
                    pictureBox.Tag = bmp;
                    //pictureBox.Refresh();
                }
                catch (Exception ex)
                {
                    pictureBox.Image = pictureBox.ErrorImage;
                }
            }));
        }

        public static async Task ShowImageAsync(this MovablePictureBox pictureBox, ImageData? imageData)
        {
            if (imageData == null)
            {
                pictureBox.Invoke(new Action(() =>
                {
                    pictureBox.Image = pictureBox.ErrorImage;
                }));
                return;
            }
            string imageUrl = await AppData.ApiServer.parkingProcessService.GetImageUrl(imageData!.bucket, imageData.objectKey);
            pictureBox.BeginInvoke(new Action(() =>
            {
                if (string.IsNullOrEmpty(imageUrl))
                {
                    pictureBox.Image = pictureBox.ErrorImage;
                    return;
                }
                try
                {
                    pictureBox.LoadAsync(imageUrl);
                }
                catch (Exception ex)
                {
                    pictureBox.Image = pictureBox.ErrorImage;
                }
            }));
        }

        public static async Task ShowImageAsync(this PictureBox pictureBox, ImageData? imageData)
        {
            if (imageData == null)
            {
                pictureBox.Invoke(new Action(() =>
                {
                    pictureBox.Image = pictureBox.ErrorImage;
                }));
                return;
            }
            string imageUrl = await AppData.ApiServer.parkingProcessService.GetImageUrl(imageData!.bucket, imageData.objectKey);
            pictureBox.BeginInvoke(new Action(() =>
            {
                if (string.IsNullOrEmpty(imageUrl))
                {
                    pictureBox.Image = pictureBox.ErrorImage;
                    return;
                }
                try
                {
                    pictureBox.LoadAsync(imageUrl);
                }
                catch (Exception ex)
                {
                    pictureBox.Image = pictureBox.ErrorImage;
                }
            }));
        }

    }
}
