using IPaking.Ultility;
using iPakrkingv5.Controls.Controls.Labels;
using iParkingv5.Controller;
using iParkingv5.LedDisplay.LEDs;
using iParkingv5.Objects;
using iParkingv5.Objects.Configs;
using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Events;
using iParkingv5_window.Forms.DataForms;
using iParkingv6.Objects.Datas;
using Kztek.Tool;
using Kztek.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
        public static void DisplayLed(string plate, DateTime datetimeIn, Identity? identity, IdentityGroup? identityGroup, string message, string laneId)
        {
            foreach (Lane item in StaticPool.lanes)
            {
                if (item.id == laneId)
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
                        parkingData.Money = "0";
                        led.Connect(item);
                        led.SendToLED(parkingData, ledConfig);
                    }
                }
            }
        }
        public static async Task SaveEventImage(Image? overviewImg, Image? vehicleImg, Image? lprImage, string imageKey, bool isInEvent)
        {
            MinioHelper.UploadPicture(overviewImg, imageKey + (isInEvent ? "_OVERVIEWIN.jpeg" : "_OVERVIEWOUT.jpeg"));
            MinioHelper.UploadPicture(vehicleImg, imageKey + (isInEvent ? "_VEHICLEIN.jpeg" : "_VEHICLEOUT.jpeg"));
            MinioHelper.UploadPicture(lprImage, imageKey + (isInEvent ? "_LPRIN.jpeg" : "_LPROUT.jpeg"));
        }

        public static void ShowImage(MovablePictureBox pictureBox, Image? img)
        {
            pictureBox.BeginInvoke(new Action(() =>
            {
                pictureBox.Image = img;
                pictureBox.Refresh();
            }));
        }
        public static void UpdateResultMessage(this lblResult lblResult, string message, Color backColor)
        {
            lblResult.Invoke(() =>
            {
                lblResult.Message = message;
                //lblResult.Text = message;
                lblResult.BackColor = backColor;
                //lblResult.Height = lblResult.PreferredHeight;
                //lblResult.Refresh();
            });
        }
        public static string GetBaseImageKey(string laneName, string cardNumber, string plate, DateTime eventTime)
        {
            string imageKey = $"{laneName}/{eventTime.ToString("yyyy/MM/dd")}/{cardNumber}_{plate.Replace("-", "").Replace(" ", "").Replace(".", "")}" + eventTime.ToString("_HH_mm_ss_ffff");
            return imageKey;
        }

        public static async Task OpenBarrieByControllerId(string controllerId, ControllerInLane? controllerInLane)
        {
            // Hiện tại bộ InGressus đang bị StopEvent khi chạy vào Log -> Tạm thời comment log

            //LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, 
            //    $"Ra lệnh mở barrier: controllerID = {controllerId}," +
            //    $" controllerInLane = {Newtonsoft.Json.JsonConvert.SerializeObject(controllerInLane)}, " +
            //    $"frmMain.controllers = {Newtonsoft.Json.JsonConvert.SerializeObject(frmMain.controllers)}");

            foreach (IController item in frmMain.controllers)
            {
                //LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, 
                    //$"controllerID = {item.ControllerInfo.Id}",
                    //obj: item);

                if (item.ControllerInfo.Id.ToLower() == controllerId.ToLower())
                {
                    //LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, $"ID = ID {Newtonsoft.Json.JsonConvert.SerializeObject(controllerInLane?.barriers)}");

                    for (int i = 0; i < controllerInLane?.barriers.Length; i++)
                    {
                        bool isOpenSuccess = false;
                        //LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "Ra lệnh mở barrier lần 1");

                        if (!await item.OpenDoor(100, controllerInLane.barriers[i]))
                        {
                            //LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "Ra lệnh mở barrier lần 2");

                            isOpenSuccess = await item.OpenDoor(100, controllerInLane.barriers[i]);
                            if (!isOpenSuccess)
                            {
                                //LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "Mở barrier thất bại");

                            }
                        }
                        else
                        {
                        }
                        if (isOpenSuccess)
                        {
                            //LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "Mở barrier thành công");
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
                        bool isOpenSuccess = false;
                        if (!await item.OpenDoor(100, controllerInLane.barriers[i]))
                        {
                            isOpenSuccess = await item.OpenDoor(100, controllerInLane.barriers[i]);
                            if (!isOpenSuccess)
                            {
                                LogHelper.Log(logType: LogHelper.EmLogType.ERROR,
                                        doi_tuong_tac_dong: LogHelper.EmObjectLogType.Controller,
                                        hanh_dong: "OPEN BARRIE",
                                        mo_ta_them: "LẦN 2 THẤT BẠI",
                                        specailName: controllerInLane.controlUnitId);
                            }
                        }
                        else
                        {
                            LogHelper.Log(logType: LogHelper.EmLogType.ERROR,
                                         doi_tuong_tac_dong: LogHelper.EmObjectLogType.Controller,
                                         hanh_dong: "OPEN BARRIE",
                                         mo_ta_them: "LẦN 1 THẤT BẠI",
                                         specailName: controllerInLane.controlUnitId);
                        }

                        if (isOpenSuccess)
                        {
                            LogHelper.Log(logType: LogHelper.EmLogType.INFOR,
                                          doi_tuong_tac_dong: LogHelper.EmObjectLogType.Controller,
                                          hanh_dong: "OPEN BARRIE",
                                          mo_ta_them: "SUCCESS",
                                          specailName: controllerInLane.controlUnitId);
                        }
                    }
                }
            }
        }

        public static void GetPlate(string laneId, out Image? vehicleImd, out string plate, out Image? lprImage, ucCameraView? ucCameraView, List<Kztek.Cameras.Camera> camDuPhongs, bool isCar)
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
            vehicleImd = ucCameraView?.GetFullCurrentImage();
            plate = StaticPool.LprDetect.GetPlateNumber(vehicleImd, isCar, config, out lprImage);
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
                    plate = StaticPool.LprDetect.GetPlateNumber(tempImg, isCar, config, out lprImage);
                    if (!string.IsNullOrEmpty(plate))
                    {
                        vehicleImd = tempImg;
                        break;
                    }
                }
            }

            if(plate != "")
            {
                plate = StandardlizePlateNumber(plate);
            }
        }
        public static string StandardlizePlateNumber(this string plateNumber)
        {
            string output = string.Empty;
            Regex regex = new Regex("[a-zA-Z0-9;]");

            for (int i = 0; i < plateNumber.Length; i++)
            {
                string plateNumberItem = plateNumber[i].ToString();
                if (regex.IsMatch(plateNumberItem))
                {
                    output += plateNumberItem;
                }
            }

            // Chỉ lấy 9 ký tự đầu tiên
            if (output.Length > 9)
            {
                output = output.Substring(0, 9);
            }

            // Nếu ký tự cuối cùng là chữ cái, thì loại bỏ nó
            if (output.Length > 0 && char.IsLetter(output[^1]))
            {
                output = output.Substring(0, output.Length - 1);
            }

            return output;
        }
    }
}
