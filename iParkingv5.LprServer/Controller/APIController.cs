﻿using iParkingv5.LprServer;
using iParkingv5.Objects;
using Kztek.Tools;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Imaging;

namespace IPGS.Controls.Controller
{
    public class APIController
    {
        /// <summary>
        /// Hello World
        /// </summary>
        /// <returns></returns>
        [HttpGet("hello")]
        public ActionResult<string> Hello()
        {
            return new OkObjectResult("hello");
        }

        /// <summary>
        /// Mỗi 60s ZCU sẽ gửi trạng thái của toàn bộ ZONE lên Server <br/>
        /// Đề phòng trường hợp CCU tắt 1 khoảng thời gian
        /// </summary>
        /// <returns></returns>
        [HttpPost("DetectPlate")]
        public ActionResult<LprResult> DetectPlate([FromBody] LprRequest lprRequest)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, obj: lprRequest);
            var image = Kztek.Helper.ImageHelper.Base64ToImage(lprRequest.base64);
            byte[] baseImageBytes = Convert.FromBase64String(lprRequest.base64);

            DateTime requestTime = DateTime.Now;
            string directory = Path.Combine(LogHelper.SaveLogFolder, "images");
            string baseFileName = requestTime.ToString("yyyy_MM_dd_HH_mm_ss_fffffff") + ".png";
            string requestPath = Path.Combine(directory, "request_" + baseFileName);
            string resultPath = Path.Combine(directory, "result_" + baseFileName);
            try
            {
                File.WriteAllBytes(requestPath, baseImageBytes);
            }
            catch (Exception)
            {
            }
            Image? lprImage = null;
            if (image != null)
            {
                try
                {
                    var plate = StaticPool.LprDetect.GetPlateNumber(image, lprRequest.isCar, null, out lprImage);
                    string base64Str = "";
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        try
                        {
                            lprImage.Save(memoryStream, ImageFormat.Jpeg);

                            byte[] imageBytes = memoryStream.ToArray();
                            base64Str = Convert.ToBase64String(imageBytes);
                            File.WriteAllBytes(resultPath, imageBytes);

                        }
                        catch (Exception)
                        {
                        }
                    }
                    Form1.showEvent(requestPath, resultPath, plate);
                    return new LprResult()
                    {
                        PlateNumber = plate,
                        LprImage = base64Str,
                    };
                }
                catch (Exception ex)
                {
                    Form1.showEvent(requestPath, "", ex.Message);
                    return new LprResult()
                    {
                        PlateNumber = "",
                        LprImage = null,
                    };
                }
            }
            Form1.showEvent(requestPath, "", "null");
            return new LprResult()
            {
                PlateNumber = "",
                LprImage = null,
            };
        }



        /// <summary>
        /// Mỗi 60s ZCU sẽ gửi trạng thái của toàn bộ ZONE lên Server <br/>
        /// Đề phòng trường hợp CCU tắt 1 khoảng thời gian
        /// </summary>
        /// <returns></returns>
        [HttpPost("lprinfo")]
        public ActionResult<LprResponseModel> DetectPlatev3([FromBody] LprRequest lprRequest)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, obj: lprRequest);
            var image = Kztek.Helper.ImageHelper.Base64ToImage(lprRequest.base64);
            byte[] baseImageBytes = Convert.FromBase64String(lprRequest.base64);

            DateTime requestTime = DateTime.Now;
            string directory = Path.Combine(LogHelper.SaveLogFolder, "images");
            string baseFileName = requestTime.ToString("yyyy_MM_dd_HH_mm_ss_fffffff") + ".png";
            string requestPath = Path.Combine(directory, "request_" + baseFileName);
            string resultPath = Path.Combine(directory, "result_" + baseFileName);
            try
            {
                File.WriteAllBytes(requestPath, baseImageBytes);
            }
            catch (Exception)
            {
            }
            Image? lprImage = null;
            if (image != null)
            {
                try
                {
                    var plate = StaticPool.LprDetect.GetPlateNumber(image, lprRequest.isCar, null, out lprImage);
                    string base64Str = "";
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        try
                        {
                            lprImage.Save(memoryStream, ImageFormat.Jpeg);

                            byte[] imageBytes = memoryStream.ToArray();
                            base64Str = Convert.ToBase64String(imageBytes);
                            File.WriteAllBytes(resultPath, imageBytes);

                        }
                        catch (Exception)
                        {
                        }
                    }
                    Form1.showEvent(requestPath, resultPath, plate);
                    return new LprResponseModel()
                    {
                        PlateNumber = plate,
                        PlateImageBase64 = base64Str,
                    };
                }
                catch (Exception ex)
                {
                    Form1.showEvent(requestPath, "", ex.Message);
                    return new LprResponseModel()
                    {
                        PlateNumber = "",
                        PlateImageBase64 = null,
                    };
                }
            }
            Form1.showEvent(requestPath, "", "null");   
            return new LprResponseModel()
            {
                PlateNumber = "",
                PlateImageBase64 = null,
            };
        }
        public class LprResponseModel
        {

            private bool isSuccess = false;
            private int height = 0;
            private int width = 0;
            private string plateNumber = String.Empty;
            private double confidence = 0;
            private string plateImageBase64 = String.Empty;

            public int Height { get => height; set => height = value; }
            public int Width { get => width; set => width = value; }
            public string PlateNumber { get => plateNumber; set => plateNumber = value; }
            public double Confidence { get => confidence; set => confidence = value; }
            public string PlateImageBase64 { get => plateImageBase64; set => plateImageBase64 = value; }
            public bool IsSuccess { get => isSuccess; set => isSuccess = value; }
        }
        public class LprRequest
        {
            public string base64 { get; set; }
            public bool isCar { get; set; }
        }
        public class LprResult
        {
            public string? LprImage { get; set; }
            public string PlateNumber { get; set; } = "";
        }
    }
}