using iParkingv5.Lpr.Objects;
using iParkingv5.LprDetecter.Events;
using iParkingv5.LprDetecter.LprDetecters;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace iParkingv5.Lpr.LprDetecters.AmericalLprs
{
    public class AmericalLpr : ILpr
    {
        public event Events.OnLprDetectComplete? onLprDetectCompleteEvent;
        private LprConfig lprConfig;
        public AmericalLpr(LprConfig lprConfig)
        {
            this.lprConfig = lprConfig;
        }
        public bool CreateLpr(LprConfig lprConfig)
        {
            return true;
        }

        public async Task<bool> CreateLprAsync()
        {
            return true;
        }
        public static Bitmap Zoom(Bitmap originalBitmap, float zoomFactor)
        {
            int newWidth = (int)(originalBitmap.Width * zoomFactor);
            int newHeight = (int)(originalBitmap.Height * zoomFactor);

            Bitmap zoomedBitmap = new Bitmap(newWidth, newHeight);

            using (Graphics g = Graphics.FromImage(zoomedBitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalBitmap, new Rectangle(0, 0, newWidth, newHeight));
            }

            return zoomedBitmap;
        }

        public string GetPlateNumber(Image? originalImage, bool isCar, Rectangle? detectRegion, out Image? lprImage)
        {
            LicensePlateCollection licensePlateList = new LicensePlateCollection();
            lprImage = null;
            if (originalImage == null)
            {
                return string.Empty;
            }
            Bitmap bitmapCut = detectRegion != null ? CropBitmap((Bitmap)originalImage, (Rectangle)detectRegion!) : (Bitmap)originalImage;

            Bitmap detectBitmap = bitmapCut.Clone(new Rectangle(0, 0, originalImage.Width, originalImage.Height), PixelFormat.Format24bppRgb);

            MemoryStream ms = new MemoryStream();
            detectBitmap.Save(ms, ImageFormat.Jpeg);
            byte[] bytearray = ms.ToArray();

            PlateReaderResult plateReaderResult = Read(lprConfig.Url, bytearray, "");

            licensePlateList = GetBestResult(plateReaderResult, detectBitmap);
            if (licensePlateList.Count > 0)
            {
                onLprDetectCompleteEvent?.Invoke(this, new Events.LprDetectEventArgs()
                {
                    LprImage = licensePlateList[0].Bitmap,
                    OriginalImage = originalImage,
                    Result = licensePlateList[0].Text,
                });
                return licensePlateList[0].Text;
            }
            else
            {
                onLprDetectCompleteEvent?.Invoke(this, new Events.LprDetectEventArgs()
                {
                    LprImage = null,
                    OriginalImage = originalImage,
                    Result = "",
                });
                return string.Empty;
            }
        }

        public async Task<Tuple<string, Image?>> GetPlateNumberAsync(Image? originalImage, bool isCar, Rectangle? detectRegion)
        {
            throw new NotImplementedException();
        }

        #region Private Function
        public static PlateReaderResult Read(string postUrl, byte[] data, string token)
        {
            try
            {
                PlateReaderResult result = null;
                string formDataBoundary = string.Format("----------{0:N}", Guid.NewGuid());
                string contentType = "multipart/form-data; boundary=" + formDataBoundary;
                byte[] formData = GetMultipartFormData2("--", "", formDataBoundary, data);

                HttpWebRequest request = WebRequest.Create(postUrl) as HttpWebRequest;
                request.ReadWriteTimeout = 2000;
                // Set up the request properties.
                request.Method = "POST";
                request.ContentType = contentType;
                request.UserAgent = ".NET Framework CSharp Client";
                request.CookieContainer = new CookieContainer();
                request.ContentLength = formData.Length;
                request.Headers.Add("Authorization", "Token " + token);

                // Send the form data to the request.
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(formData, 0, formData.Length);
                    requestStream.Close();
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    WebHeaderCollection header = response.Headers;
                    var encoding = Encoding.ASCII;
                    using (var reader = new StreamReader(response.GetResponseStream(), encoding))
                    {
                        string responseText = reader.ReadToEnd();
                        try
                        {
                            result = Newtonsoft.Json.JsonConvert.DeserializeObject<PlateReaderResult>(responseText);
                        }
                        catch
                        {

                        }
                    }
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Build Multipart Formdata from files and regions.
        /// </summary>
        /// <param name="filePath">File path.</param>
        /// <param name="regions">Regions</param>
        /// <param name="boundary">Boundary.</param>
        /// <returns></returns>
        private static byte[] GetMultipartFormData(string filePath, string regions, string boundary)
        {
            Stream formDataStream = new MemoryStream();
            if (!string.IsNullOrWhiteSpace(filePath))
            {
                // Add just the first part of this param, since we will write the file data directly to the Stream
                string header = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\"\r\nContent-Type: {3}\r\n\r\n",
                    boundary,
                    "upload",
                    filePath,
                    "application/octet-stream");

                formDataStream.Write(Encoding.UTF8.GetBytes(header), 0, Encoding.UTF8.GetByteCount(header));
                byte[] file = File.ReadAllBytes(filePath);
                // Write the file data directly to the Stream, rather than serializing it to a string.
                formDataStream.Write(file, 0, file.Length);
            }

            if (!string.IsNullOrWhiteSpace(regions))
            {
                formDataStream.Write(Encoding.UTF8.GetBytes("\r\n"), 0, Encoding.UTF8.GetByteCount("\r\n"));
                string postData = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}",
                    boundary,
                    "regions",
                    regions);
                formDataStream.Write(Encoding.UTF8.GetBytes(postData), 0, Encoding.UTF8.GetByteCount(postData));
            }

            // Add the end of the request.  Start with a newline
            string footer = "\r\n--" + boundary + "--\r\n";
            formDataStream.Write(Encoding.UTF8.GetBytes(footer), 0, Encoding.UTF8.GetByteCount(footer));

            // Dump the Stream into a byte[]
            formDataStream.Position = 0;
            byte[] formData = new byte[formDataStream.Length];
            formDataStream.Read(formData, 0, formData.Length);
            formDataStream.Close();

            return formData;
        }

        private static byte[] GetMultipartFormData2(string filePath, string regions, string boundary, byte[] data)
        {
            Stream formDataStream = new MemoryStream();
            if (!string.IsNullOrWhiteSpace(filePath))
            {
                // Add just the first part of this param, since we will write the file data directly to the Stream
                string header = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\"\r\nContent-Type: {3}\r\n\r\n",
                    boundary,
                    "upload",
                    filePath,
                    "application/octet-stream");

                formDataStream.Write(Encoding.UTF8.GetBytes(header), 0, Encoding.UTF8.GetByteCount(header));
                byte[] file = data;//File.ReadAllBytes(filePath);
                // Write the file data directly to the Stream, rather than serializing it to a string.
                formDataStream.Write(file, 0, file.Length);
            }

            if (!string.IsNullOrWhiteSpace(regions))
            {
                formDataStream.Write(Encoding.UTF8.GetBytes("\r\n"), 0, Encoding.UTF8.GetByteCount("\r\n"));
                string postData = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}",
                    boundary,
                    "regions",
                    regions);
                formDataStream.Write(Encoding.UTF8.GetBytes(postData), 0, Encoding.UTF8.GetByteCount(postData));
            }

            // Add the end of the request.  Start with a newline
            string footer = "\r\n--" + boundary + "--\r\n";
            formDataStream.Write(Encoding.UTF8.GetBytes(footer), 0, Encoding.UTF8.GetByteCount(footer));

            // Dump the Stream into a byte[]
            formDataStream.Position = 0;
            byte[] formData = new byte[formDataStream.Length];
            formDataStream.Read(formData, 0, formData.Length);
            formDataStream.Close();

            return formData;
        }
        private LicensePlateCollection GetBestResult(PlateReaderResult plateReaderResult, Bitmap bmp)
        {
            try
            {
                LicensePlateCollection licensePlateList = new LicensePlateCollection();
                var bestplate = new LicensePlate();

                if (plateReaderResult.Results != null)
                {
                    foreach (var result in plateReaderResult.Results)
                    {
                        LicensePlate plate = new LicensePlate
                        {
                            Text = result.Plate.ToUpper(),
                            Bitmap = bmp.Clone(new Rectangle(result.Box.Xmin, result.Box.Ymin, result.Box.Xmax - result.Box.Xmin, result.Box.Ymax - result.Box.Ymin), PixelFormat.Format24bppRgb),
                            ConfidenceLevel = (float)result.Dscore
                        };

                        if (result.Dscore > bestplate.ConfidenceLevel)
                            bestplate = plate;

                        licensePlateList.Add(plate);
                    }
                    licensePlateList.Maxcalls = plateReaderResult.usage.Max_calls;
                    licensePlateList.QueryTimes = plateReaderResult.usage.Calls;
                }
                // (plateReaderResult.usage.Calls + 5 == plateReaderResult.usage.Max_calls) bestplate.IsMaxcalls = true;

                licensePlateList.Add(bestplate);
                return licensePlateList;
            }
            catch
            {
                throw;
            }
        }
        static Bitmap CropBitmap(Bitmap source, Rectangle? cutRect)
        {
            try
            {
                if (cutRect == null)
                {
                    return source;
                }
                Rectangle _cutRect = (Rectangle)cutRect;
                Bitmap cutBmp = new Bitmap(_cutRect.Width, _cutRect.Height);
                using (Graphics g = Graphics.FromImage(cutBmp))
                {
                    g.DrawImage(source, 0, 0, _cutRect, GraphicsUnit.Pixel);
                }
                return cutBmp;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        #endregion
    }
}
