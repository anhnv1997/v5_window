using iPakrkingv5.Controls.Controls.Labels;
using iPakrkingv5.Controls.Usercontrols;
using iParkingv5.Controller;
using iParkingv5.Objects;
using iParkingv5.Objects.Configs;
using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Datas.Device_service;
using iParkingv5.Objects.Datas.parking_service;
using iParkingv5.Objects.Enums;
using iParkingv5.Objects.Events;
using iParkingv5_CustomerRegister.Forms;
using iParkingv5_window.Forms.DataForms;
using iParkingv6.Objects.Datas;
using Kztek.Tool.LogDatabases;
using Kztek.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static iParkingv5.Objects.Enums.ParkingImageType;
using static iParkingv5.Objects.Enums.VehicleType;

namespace iParkingv5_window.Usercontrols
{
    public partial class ucBaseLane : UserControl
    {
        public string hanetPlateNumber { get; set; }
        public Image? hanetImg { get; set; }

        public List<string> allowAlarmMessage = new List<string>()
        {
            "Biển số không hợp lệ".ToUpper(),
            "BIỂN SỐ VÀO RA KHÔNG KHỚP"
        };
        public Color ProcessColor = Color.DarkBlue;
        public Color ErrorColor = Color.DarkRed;
        public Color WarningColor = Color.DarkOrange;
        public Color SuccessColor = Color.DarkGreen;

        public event OnChangeLaneEvent? OnChangeLaneEvent;
        public event OnControlSizeChanged? onControlSizeChangeEvent;


        #region -- Data
        public Lane lane { get; set; }
        public Dictionary<CameraPurposeType.EmCameraPurposeType, List<Camera>> cameras = new Dictionary<CameraPurposeType.EmCameraPurposeType, List<Camera>>();
        public List<Kztek.Cameras.Camera> camBienSoXeMayDuPhongs = new List<Kztek.Cameras.Camera>();
        public List<Kztek.Cameras.Camera> camBienSoOTODuPhongs = new List<Kztek.Cameras.Camera>();
        public List<Kztek.Cameras.Camera> OtherCams = new List<Kztek.Cameras.Camera>();
        #endregion

        #region -- Controls In Lane
        public ucCameraView? ucOverView = null;
        public ucCameraView? ucMotoLpr = null;
        public ucCameraView? ucCarLpr = null;
        #endregion

        #region Config
        public List<ControllerShortcutConfig>? controllerShortcutConfigs = null;
        public LaneDisplayConfig? laneDisplayConfig = null;
        #endregion

        public readonly SemaphoreSlim semaphoreSlimOnNewEvent = new SemaphoreSlim(1, 1);
        public readonly SemaphoreSlim semaphoreSlimOnKeyPress = new SemaphoreSlim(1, 1);

        public bool IsAllowDesignRealtime = false;

        public List<CardEventArgs> lastCardEventDatas { get; set; } = new List<CardEventArgs>();
        public List<InputEventArgs> lastInputEventDatas { get; set; } = new List<InputEventArgs>();

        public LaneDirectionConfig laneDirectionConfig = new LaneDirectionConfig();

        public int printCount = 0;
        public int time_refresh = 0;

        public List<ucLastEventInfo> ucLastEventInfos = new List<ucLastEventInfo>();

        public ucBaseLane()
        {
            InitializeComponent();
        }
        public void LoadCamera(Panel panelCameras)
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
            Kztek.Cameras.Camera? motorLprCamera = GetCameraConfig(CameraPurposeType.EmCameraPurposeType.MotorLPR, cameras);
            Kztek.Cameras.Camera? carLprCamera = GetCameraConfig(CameraPurposeType.EmCameraPurposeType.CarLPR, cameras);

            if (mainOverviewCamera != null)
            {
                ucOverView = new ucCameraView(this.lane.Id);
                AddCamera(panelCameras, mainOverviewCamera, ucOverView);
                if (AppData.isUseVirtualLoop == EmVirtualLoopMode.Overview || AppData.isUseVirtualLoop == EmVirtualLoopMode.Both)
                {
                    ucOverView.MotionDetectEvent += UcMotoLpr_MotionDetectEvent;
                    ucOverView.StartMotionDetection();
                }
            }
            if (motorLprCamera != null)
            {
                ucMotoLpr = new ucCameraView(this.lane.Id);
                AddCamera(panelCameras, motorLprCamera, ucMotoLpr);
            }
            if (carLprCamera != null)
            {
                ucCarLpr = new ucCameraView(this.lane.Id);
                AddCamera(panelCameras, carLprCamera, ucCarLpr);
                if (AppData.isUseVirtualLoop == EmVirtualLoopMode.Lpr || AppData.isUseVirtualLoop == EmVirtualLoopMode.Both)
                {
                    ucCarLpr.MotionDetectEvent += UcMotoLpr_MotionDetectEvent;
                    ucCarLpr.StartMotionDetection();
                }
            }
        }

        public virtual void UcMotoLpr_MotionDetectEvent(object sender, ucCameraView.MotionDetectEventArgs e)
        {
        }

        private void VideoSourcePlayer_Alarm(object? sender, EventArgs e)
        {
        }

        private void AddCamera(Panel panel, Kztek.Cameras.Camera cam, ucCameraView uc)
        {
            cam.Name += "-OVERVIEW";
            uc.StartViewer(cam, CameraErrorFunc);
            uc.BorderStyle = BorderStyle.None;
            if (panel.Controls.Count > 0)
            {
                Control lastControl = panel.Controls[panel.Controls.Count - 1];
                Point location = new Point(lastControl.Location.X, lastControl.Location.Y + lastControl.Height + 10);
                panel.Controls.Add(uc);
                uc.Location = location;
            }
            else
            {
                panel.Controls.Add(uc);
                uc.Location = new Point(0);
            }

        }

        public Kztek.Cameras.Camera? GetCameraConfig(CameraPurposeType.EmCameraPurposeType key, Dictionary<CameraPurposeType.EmCameraPurposeType, List<Camera>> cameras)
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
                        string _camType = cameras[key][i].GetCameraType() == "HIK" ? "HIKVISION2" : cameras[key][i].GetCameraType();
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
        public void CameraErrorFunc(object sender, string errorString)
        {
            tblDeviceLog.SaveLog("", "", "", "", errorString);
        }

        protected void OnChangeLaneEventInvoke(object e)
        {
            OnChangeLaneEvent?.Invoke(e);
        }
        protected void onControlSizeChangeEventInvoke(object sender, ControlSizeChangedEventArgs e)
        {
            onControlSizeChangeEvent?.Invoke(sender, e);
        }

        public async Task ExcecuteInputEvent(InputEventArgs ie, lblResult lbl)
        {
            foreach (ControllerInLane controllerInLane in lane.controlUnits)
            {
                if (controllerInLane.controlUnitId.ToLower() != ie.DeviceId.ToLower())
                {
                    continue;
                }
                if (!controllerInLane.inputs.Contains(ie.InputIndex))
                {
                    continue;
                }

                switch (ie.InputType)
                {
                    case InputTupe.EmInputType.Loop:
                        if (lane.loop)
                        {
                            if (StaticPool.appOption.LoopDelay > 0)
                            {
                                await Task.Delay(StaticPool.appOption.LoopDelay);
                                lbl.UpdateResultMessage($"Nhận sự kiên Loop {ie.InputIndex}, chờ {StaticPool.appOption.LoopDelay} ms ", Color.DarkBlue);
                            }
                            await ExcecuteLoopEvent(ie);
                        }
                        else
                        {
                            lbl.UpdateResultMessage($"Làn không cấu hình sử dụng loop ", Color.DarkBlue);
                        }
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

        public virtual async Task ExcecuteLoopEvent(InputEventArgs ie)
        {

        }

        public virtual async Task ExcecuteExitEvent(InputEventArgs ie)
        {

        }
        public virtual async Task ExcecuteEventCancel(CardCancelEventArgs ec)
        {
            // Xử lý hủy thẻ vào bãi
        }

        public async Task ExcecuteEventError(ControllerErrorEventArgs error)
        {
            string nameError = error.ErrorFunc.ToString();
            // Cảnh báo với máy nhả thẻ
            if (error.DispenserError != null)
            {
                if (error.DispenserError.IsCardErrorDispenser)
                {
                    // Play Sound nhả thẻ bị lỗi
                    BaseLane.PlaySound(error.DeviceId, SoundType.EmSoundType.CARD_DISPENSING_ERROR);
                }
                else if (error.DispenserError.IsCardEmptyDispenser)
                {
                    // Play sound hết thẻ
                    BaseLane.PlaySound(error.DeviceId, SoundType.EmSoundType.CARD_EMPTY);
                }
                else if (error.DispenserError.IsLessCardDispenser)
                {
                    // Play sound gần hết thẻ
                }
                await Task.Delay(100);
            }
        }

        public Image? GetPlate(CardEventArgs ce, ref Image? overviewImg, ref Image? vehicleImg, VehicleBaseType vehicleBaseType,
                                lblResult lblResult, TextBox txtPlate,
                                MovablePictureBox picOverview, MovablePictureBox picVehicle, MovablePictureBox picLpr)
        {
            Image? lprImage = null;
            lblResult.UpdateResultMessage("Đọc biển số...", Color.DarkBlue);
            string plate = string.Empty;
            switch (vehicleBaseType)
            {
                case VehicleBaseType.Car:
                    BaseLane.GetPlate(this.lane.Id, out vehicleImg, out plate, out lprImage, ucCarLpr, camBienSoOTODuPhongs, true);
                    break;
                default:
                    BaseLane.GetPlate(this.lane.Id, out vehicleImg, out plate, out lprImage, ucMotoLpr, camBienSoXeMayDuPhongs, false);
                    break;
            }
            ce.PlateNumber = plate;

            lblResult.UpdateResultMessage("Hiển thị hình ảnh sự kiện...", Color.DarkBlue);
            BaseLane.ShowImage(picOverview, overviewImg);
            BaseLane.ShowImage(picVehicle, vehicleImg);
            BaseLane.ShowImage(picLpr, lprImage);

            txtPlate.BeginInvoke(new Action(() =>
            {
                txtPlate.Text = ce.PlateNumber;
                txtPlate.Refresh();
            }));
            return lprImage;
        }

        public async Task<LoopLprResult> LoopLprDetection()
        {
            LoopLprResult lprResult = new LoopLprResult();
            int retry = 0;

            while (retry < StaticPool.appOption.RetakePhotoTimes)
            {
                (Image? vehicleImg, string plate, Image? lprImage) = TryGetPlateAsync();
                lprResult.LprImage = lprImage;
                lprResult.VehicleImage = vehicleImg;
                lprResult.PlateNumber = plate ?? "";
                lprResult.PlateNumber = lprResult.PlateNumber.Trim();
                if (!string.IsNullOrEmpty(plate))
                {
                    var registeredVehicle = await AppData.ApiServer.parkingDataService.GetRegistedVehilceByPlateAsync(plate);
                    if (registeredVehicle.Item1 != null)
                    {
                        lprResult.Vehicle = registeredVehicle.Item1;
                        return lprResult;
                    }
                }

                retry++;
                await Task.Delay(StaticPool.appOption.RetakePhotoDelay);
            }

            return lprResult;
        }
        private (Image?, string, Image?) TryGetPlateAsync()
        {
            Image? vehicleImg = null;
            string plate = "";
            Image? lprImage = null;

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

            return (vehicleImg, plate, lprImage);
        }

        public async Task OpenAllBarrie()
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
                                    tblDeviceLog.SaveLog(controller.ControllerInfo.Id, controller.ControllerInfo.Name, "", "", "Mở barrie thủ công thất bại");
                                }
                            }
                            else
                            {
                                tblDeviceLog.SaveLog(controller.ControllerInfo.Id, controller.ControllerInfo.Name, "", "", "Mở barrie thủ công thành công");
                            }
                        }
                        break;
                    }
                }
            }
        }
        public async Task SaveManualAbnormalEvent(string plateNumber, Identity? identity, IdentityGroup? identityGroup,
                                                  Dictionary<EmParkingImageType, List<List<byte>>> imageDatas, bool isLaneIn,
                                                  string customerId = "", string vehicleId = "", string description = "",
                                                  AbnormalCode abnormalCode = AbnormalCode.OpenBarrierByKeyboard)
        {
            string identityCode = identity?.Code ?? "";
            string identityGroupId = identityGroup == null ? "" : identityGroup.Id.ToString();
            var response = await AppData.ApiServer.parkingProcessService.CreateAlarmAsync(
                                                    identityCode, this.lane.Id, plateNumber, abnormalCode,
                                                    imageDatas, isLaneIn, identityGroupId, customerId, vehicleId, description);
            if (response != null)
            {
                await BaseLane.SaveImage(response.images, imageDatas);
            }
        }
    }
}
