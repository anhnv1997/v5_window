using iParkingv5.Controller;
using iParkingv5.Objects;
using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Enums;
using iParkingv5.Objects.EventDatas;
using iParkingv5.Objects.Events;
using iParkingv5_window.Forms.DataForms;
using iParkingv6.ApiManager.KzParkingv3Apis;
using iParkingv6.Objects.Datas;
using Kztek.LPR;
using Kztek.Tools;
using ParkingHelper.ModelSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iParkingv5_window.Usercontrols
{
    public partial class ucLaneIn : UserControl, iLane
    {
        #region Properties
        private Lane lane;
        private Dictionary<CameraPurposeType.EmCameraPurposeType, List<Camera>> cameras = new Dictionary<CameraPurposeType.EmCameraPurposeType, List<Camera>>();
        ucCameraView? ucOverView = null;
        ucCameraView? ucMotoLpr = null;
        ucCameraView? ucCarLpr = null;

        CardEvent? lastEvent = null;
        public List<CardEventArgs> lastCardEventDatas { get; set; } = new List<CardEventArgs>();
        public List<InputEventArgs> lastInputEventDatas { get; set; } = new List<InputEventArgs>();
        #endregion

        #region Forms
        public ucLaneIn(Lane lane)
        {
            InitializeComponent();
            lblLaneName.Text = lane.name;
            lblLaneName.BackColor = Color.DarkGreen;

            this.lane = lane;
            this.Load += UcLaneIn_Load;
        }
        private void UcLaneIn_Load(object? sender, EventArgs e)
        {
            foreach (CameraInLane cameraInLane in lane.cameras)
            {
                foreach (Camera cam in StaticPool.cameras)
                {
                    if (cam.id?.ToLower() == cameraInLane.cameraId)
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
                ucOverView = new ucCameraView();
                ucOverView.StartViewer(mainOverviewCamera, CameraErrorFunc);
                panelCameras.Controls.Add(ucOverView);
                ucOverView.Location = new Point(0);
            }

            Kztek.Cameras.Camera? motorLprCamera = GetCameraConfig(CameraPurposeType.EmCameraPurposeType.MotorLPR, cameras);
            if (motorLprCamera != null)
            {
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
            this.Dock = DockStyle.Top;
            panelCameras.SizeChanged += PanelCameras_SizeChanged;
        }
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
        #endregion

        #region Controls In Form
        private void BtnWriteIn_Click(object sender, EventArgs e)
        {
            frmSelectCard frmSelectCard = new();
            if (frmSelectCard.ShowDialog() != DialogResult.OK) return;

            foreach (ControllerInLane controllerInLane in lane.controlUnits)
            {
                if (controllerInLane.readers.Length == 0)
                {
                    continue;
                }

                CardEventArgs ce = new()
                {
                    DeviceId = controllerInLane.controlUnitId,
                    ReaderIndex = controllerInLane.readers[0],
                    AllCardFormats = new List<string>() { frmSelectCard.SelectedCard }
                };

                _ = OnNewEvent(ce);
                //Lưu sự kiện cảnh báo
                return;
            }
        }
        private void BtnReTakePhoto_Click(object sender, EventArgs e)
        {
            foreach (ControllerInLane controllerInLane in lane.controlUnits)
            {
                if (controllerInLane.inputs.Length == 0)
                {
                    continue;
                }
                InputEventArgs ie = new InputEventArgs();
                ie.DeviceId = controllerInLane.controlUnitId;
                ie.InputIndex = controllerInLane.inputs[0];
                ie.InputType = InputTupe.EmInputType.Loop;
                _ = OnNewEvent(ie);
                return;
            }
        }
        #endregion End Controls In Form

        #region Public Function
        public bool SaveUIConfig()
        {
            return true;
        }
        public async Task OnNewEvent(EventArgs e)
        {
            await semaphoreSlim.WaitAsync();
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
                semaphoreSlim.Release();
            }
        }
        #endregion End Public Function

        #region Private Function
        private static Kztek.Cameras.Camera? GetCameraConfig(CameraPurposeType.EmCameraPurposeType key, Dictionary<CameraPurposeType.EmCameraPurposeType, List<Camera>> cameras)
        {
            if (cameras.ContainsKey(key))
            {
                Kztek.Cameras.Camera mainOverviewCamera = new Kztek.Cameras.Camera();
                mainOverviewCamera.ID = cameras[key][0].id;
                mainOverviewCamera.Name = cameras[key][0].name;
                mainOverviewCamera.VideoSource = cameras[key][0].ipAddress;
                mainOverviewCamera.HttpPort = int.Parse(cameras[key][0].httpPort);
                mainOverviewCamera.Login = cameras[key][0].username;
                mainOverviewCamera.Password = cameras[key][0].password;
                mainOverviewCamera.Chanel = cameras[key][0].channel;
                mainOverviewCamera.CameraType = Kztek.Cameras.CameraTypes.GetType(cameras[key][0].GetCameraType());
                mainOverviewCamera.StreamType = Kztek.Cameras.StreamTypes.GetType("H264");
                mainOverviewCamera.Resolution = string.IsNullOrEmpty(cameras[key][0].resolution) ? "1280x720" : cameras[key][0].resolution;
                return mainOverviewCamera;
            }
            return null;
        }
        private void CameraErrorFunc(object sender, string errorString)
        {
            LogHelper.Log(logType: LogHelper.EmLogType.ERROR,
                           doi_tuong_tac_dong: LogHelper.EmObjectLogType.Camera,
                           mo_ta_them: errorString);
        }
        private void UpdateResultMessage(string message, Color backColor)
        {
            lblResult.Invoke(() =>
            {
                lblResult.Text = message;
                lblResult.BackColor = backColor;
                lblResult.Refresh();
            });
        }
        private static void ShowImage(MovablePictureBox pictureBox, Image? img)
        {
            pictureBox.BeginInvoke(new Action(() =>
            {
                pictureBox.Image = img;
                pictureBox.Refresh();
            }));
        }
        #endregion End Private Function

        #region EVENT
        private readonly SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);

        public async Task ExcecuteInputEvent(InputEventArgs ie)
        {
            foreach (ControllerInLane controllerInLane in lane.controlUnits)
            {
                if (controllerInLane.controlUnitId.ToLower() != ie.DeviceId.ToLower())
                {
                    continue;
                }
                if (!controllerInLane.inputs.Contains(ie.InputIndex.ToString()))
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
        public async Task ExcecuteLoopEvent(InputEventArgs ie)
        {
            //Danh sách biến sử dụng
            Image? overviewImg = null;
            Image? vehicleImg = null;
            List<Image?> optionalImages = new();
            Card? card = null;
            CardGroup? cardGroup = null;
            VehicleGroup? vehicleGroup = null;

            UpdateResultMessage("Đang kiểm trang thông tin sự kiện loop..." + ie.InputIndex, Color.DarkBlue);
        }
        public async Task ExcecuteExitEvent(InputEventArgs ie)
        {
            //Danh sách biến sử dụng
            Image? overviewImg = null;
            Image? vehicleImg = null;
            List<Image?> optionalImages = new();
            Card? card = null;
            CardGroup? cardGroup = null;
            VehicleGroup? vehicleGroup = null;
            Alarm? alarm = null;

            UpdateResultMessage("Đang kiểm trang thông tin sự kiện exit..." + ie.InputIndex, Color.DarkBlue);
            //--Chưa có sự kiện vào hoặc thời gian từ lúc có sự kiện đến khi bấm mở barrie quá 5s thì lưu sự kiện cảnh báo
            if (lastEvent == null || (lastEvent.DateTimeIn - DateTime.Now)?.TotalSeconds >= 5)
            {
                alarm.AlarmCode = "";
                //--Lấy hình ảnh sự kiện
                //--Lưu hình ảnh sự kiện
            }
            //--Bấm nút mở barrie hợp lệ
            else
            {
                alarm.AlarmCode = "";
                //--Mở barrie
                foreach (IController item in frmMain.controllers)
                {
                    foreach (ControllerInLane controllerInLane in lane.controlUnits)
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
                                            specailName: controllerInLane.controlUnitName);
                                }
                            }
                            else
                            {
                                LogHelper.Log(logType: LogHelper.EmLogType.ERROR,
                                             doi_tuong_tac_dong: LogHelper.EmObjectLogType.Controller,
                                             hanh_dong: "OPEN BARRIE",
                                             mo_ta_them: "LẦN 1 THẤT BẠI",
                                             specailName: controllerInLane.controlUnitName);
                            }

                            if (isOpenSuccess)
                            {
                                LogHelper.Log(logType: LogHelper.EmLogType.INFOR,
                                              doi_tuong_tac_dong: LogHelper.EmObjectLogType.Controller,
                                              hanh_dong: "OPEN BARRIE",
                                              mo_ta_them: "SUCCESS",
                                              specailName: controllerInLane.controlUnitName);
                            }
                        }
                    }
                }
            }

            //--Lưu lại thông tin sự kiện mở barrie bằng nút nhấn
            await KzParkingApiHelper.CreateAlarmAsync(alarm);
        }

        public async Task ExcecuteCardEvent(CardEventArgs ce)
        {
            if (!this.CheckNewCardEvent(this.lane, ce, out ControllerInLane? controllerInLane, out int thoiGianCho))
            {
                if (thoiGianCho > 0)
                {
                    UpdateResultMessage($"Đang trong thời gian chờ, vui lòng quẹt lại sau {thoiGianCho}s", Color.DarkBlue);
                }
                return;
            }

            //Danh sách biến sử dụng
            Image? overviewImg = null;
            Image? vehicleImg = null;
            List<Image?> optionalImages = new();
            Card? card = null;
            CardGroup? cardGroup = null;
            VehicleGroup? vehicleGroup = null;

            DateTime eventTime = DateTime.Now;
            UpdateResultMessage("Đang kiểm trang thông tin sự kiện quẹt thẻ..." + ce.AllCardFormats[0], Color.DarkBlue);

            //Đọc thông tin thẻ
            var cardInfo = await KzParkingApiHelper.GetCardByCardNumberAsync(ce.AllCardFormats[0]);
            if (cardInfo.Item1 == null)
            {
                UpdateResultMessage("Đọc thông tin thẻ lỗi: " + cardInfo.Item2, Color.DarkRed);
                return;
            }
            card = cardInfo.Item1;

            //Đọc thông tin nhóm thẻ
            //--Để lại
            //var cardGroupInfo = await KzParkingApiHelper.GetCardGroupByIdAsync(card.CardGroupId);
            UpdateResultMessage("Đọc thông tin nhóm thẻ...", Color.DarkBlue);
            var cardGroups = await KzParkingApiHelper.GetCardGroupsAsync();
            if (cardGroups == null)
            {
                UpdateResultMessage("Đọc thông tin nhóm thẻ lỗi", Color.DarkRed);
                return;
            }
            foreach (CardGroup item in cardGroups)
            {
                if (item.Id.ToLower() == card.CardGroupId.ToLower())
                {
                    cardGroup = item;
                    break;
                }
            }
            if (cardGroup == null)
            {
                UpdateResultMessage("Không lấy được thông tin nhóm thẻ", Color.DarkRed);
                return;
            }

            //Đọc thông tin loại phương tiện
            UpdateResultMessage("Đang kiểm trang thông tin sự kiện quẹt thẻ..." + ce.AllCardFormats[0], Color.DarkBlue);
            //Đọc thông tin thẻ
            var vehicleGroupInfo = await KzParkingApiHelper.GetVehicleGroupByIdAsync(cardGroup.VehicleGroupId);
            if (vehicleGroupInfo.Item1 == null)
            {
                UpdateResultMessage("Đọc thông tin loại phương tiện lỗi: " + vehicleGroupInfo.Item2, Color.DarkRed);
                return;
            }
            vehicleGroup = vehicleGroupInfo.Item1;

            //Lấy hình ảnh sự kiện
            UpdateResultMessage("Lấy hình ảnh sự kiện...", Color.DarkBlue);
            foreach (KeyValuePair<CameraPurposeType.EmCameraPurposeType, List<Camera>> kvp in cameras)
            {
                switch (kvp.Key)
                {
                    case CameraPurposeType.EmCameraPurposeType.MainOverView:
                        overviewImg = ucOverView?.GetFullCurrentImage();
                        break;
                    case CameraPurposeType.EmCameraPurposeType.CarLPR:
                        if (vehicleGroup.VehicleType == (int)VehicleType.EmVehicleType.Car)
                        {
                            vehicleImg = ucCarLpr?.GetFullCurrentImage();
                        }
                        break;
                    case CameraPurposeType.EmCameraPurposeType.MotorLPR:
                        if (vehicleGroup.VehicleType != (int)VehicleType.EmVehicleType.Car)
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
            UpdateResultMessage("Hiển thị hình ảnh sự kiện...", Color.DarkBlue);
            ShowImage(picOverviewImage, overviewImg);
            ShowImage(picVehicleImage, vehicleImg);

            //Đọc biển số
            UpdateResultMessage("Đọc biển số...", Color.DarkBlue);
            string plate = LprDetect.GetPlateNumber(LPRDetecter.EmLprDetecter.KztekLpr, vehicleImg, out Image? lprImage);
            ShowImage(picLprImage, lprImage);
            txtPlate.Invoke(new Action(() =>
            {
                txtPlate.Text = plate;
                txtPlate.Refresh();
            }));

            //Gửi API Check In
            //--Cập nhật lại đường dẫn có thêm thông tin biển số xe
            string overviewPath = ImageHelper.CreateSaveFileName(eventTime, false, plate, lane.id, "OVERVIEW");
            string vehiclePath = ImageHelper.CreateSaveFileName(eventTime, false, plate, lane.id, "VEHICLE");
            string lprPath = ImageHelper.CreateSaveFileName(eventTime, false, plate, lane.id, "LPR");
            CardEvent? cardEvent = new CardEvent()
            {
            };
            UpdateResultMessage("Check In...", Color.DarkBlue);
            await KzParkingApiHelper.PostCheckInAsync(cardEvent);

            //Kiểm tra mở barrie
            bool isOpenBarrie = true;
            if (isOpenBarrie)
            {
                foreach (IController item in frmMain.controllers)
                {
                    if (item.ControllerInfo.id.ToLower() == ce.DeviceId.ToLower())
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

            //Lưu hình ảnh sự kiện
            UpdateResultMessage("Lưu hình ảnh sự kiện...", Color.DarkBlue);
            var task1 = MinioHelper.UploadPicture(overviewImg, overviewPath);
            var task2 = MinioHelper.UploadPicture(vehicleImg, vehiclePath);
            var task3 = MinioHelper.UploadPicture(lprImage, lprPath);
            await Task.WhenAll(task1, task2, task3);

            //Hiển thị kết quả check in
            UpdateResultMessage("Hiển thị kết quả Check In...", Color.DarkBlue);
            UpdateResultMessage("Xin Mời Qua", Color.DarkGreen);

            //Cập nhật biến lastEvent
            lastEvent = cardEvent;
        }
        #endregion End EVENT
    }
}
