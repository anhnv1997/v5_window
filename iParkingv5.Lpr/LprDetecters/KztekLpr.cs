using iParkingv5.Lpr.Objects;
using NXT.Net6.LPR_AI;
using System;
using System.Drawing;
using System.Threading.Tasks;

namespace iParkingv5.LprDetecter.LprDetecters
{
    public class KztekLpr : ILpr
    {
        #region PROPERTIES
        public CarANPR? carANPR;
        public MotoANPR? motorANPR;
        #endregion END PROPERTIES
        public event Events.Events.OnLprDetectComplete? onLprDetectCompleteEvent;

        public bool CreateLpr(LprConfig lprConfig)
        {
            return CreateKztekLPR();
        }
        public async Task<bool> CreateLprAsync()
        {
            return CreateKztekLPR();
        }

        public string GetPlateNumber(Image? originalImage, bool isCar, Rectangle? detectRegion, out Image? lprImage)
        {
            lprImage = null;
            string plateNumber = string.Empty;
            if (originalImage == null) { goto ReturnResult; }
            if (isCar && carANPR == null) { goto ReturnResult; }
            if (!isCar && motorANPR == null) { goto ReturnResult; }
            Bitmap bitmapCut = detectRegion != null ? CropBitmap((Bitmap)originalImage, (Rectangle)detectRegion!) : (Bitmap)originalImage;

            var lPRObject_Result = new LPR_Result_Object
            {
                enableMultiplePlateNumber = true,
                vehicleImage = bitmapCut
            };
            if (isCar)
            {
                carANPR!.Analyze(ref lPRObject_Result);

                plateNumber = lPRObject_Result.plateNumber;
                lprImage = lPRObject_Result.plateImage;
            }
            else
            {
                motorANPR!.Analyze(ref lPRObject_Result);

                plateNumber = lPRObject_Result.plateNumber;
                lprImage = lPRObject_Result.plateImage;
                //if (detectRegion != null)
                //{
                //    originalImage = DrawRectangle((Bitmap)originalImage, detectRegion.Value.X, detectRegion.Value.Y, detectRegion.Value.Width, detectRegion.Value.Height, Color.Red);
                //    originalImage = DrawRectangle((Bitmap)originalImage, lPRObject_Result.plateLocation.X + detectRegion.Value.X,
                //                                                         lPRObject_Result.plateLocation.Y + detectRegion.Value.Y,
                //                                                         lPRObject_Result.plateLocation.Width,
                //                                                         lPRObject_Result.plateLocation.Height, Color.Blue);
                //}
            }
           
        ReturnResult:
            {
                onLprDetectCompleteEvent?.Invoke(this, new Events.Events.LprDetectEventArgs()
                {
                    LprImage = lprImage,
                    OriginalImage = originalImage,
                    Result = plateNumber,
                });
                return plateNumber;
            }
        }
        public async Task<Tuple<string, Image?>> GetPlateNumberAsync(Image? originalImage, bool isCar, Rectangle? detectRegion)
        {
            Tuple<string, Image?> response;
            if (originalImage == null)
            {
                response = Tuple.Create<string, Image?>(string.Empty, null);
                goto ReturnResult;
            }
            if (isCar && carANPR == null)
            {
                response = Tuple.Create<string, Image?>(string.Empty, null);
                goto ReturnResult;
            }
            if (!isCar && motorANPR == null)
            {
                response = Tuple.Create<string, Image?>(string.Empty, null);
                goto ReturnResult;
            }
            Bitmap bitmapCut = CropBitmap((Bitmap)originalImage, (Rectangle)detectRegion!);
            var lPRObject_Result = new LPR_Result_Object
            {
                enableMultiplePlateNumber = true,
                vehicleImage = (Bitmap)bitmapCut
            };
            await Task.Run(() =>
            {
                carANPR!.Analyze(ref lPRObject_Result);
            });
            string plateNumber = lPRObject_Result?.plateNumber ?? string.Empty;
            response = Tuple.Create<string, Image?>(plateNumber, lPRObject_Result?.plateImage);
        ReturnResult:
            {
                onLprDetectCompleteEvent?.Invoke(this, new Events.Events.LprDetectEventArgs()
                {
                    LprImage = response.Item2,
                    OriginalImage = originalImage,
                    Result = response.Item1
                });
                return response;
            }
        }

        private bool CreateKztekLPR()
        {
            try
            {
                carANPR = new CarANPR();
                carANPR.CreateLPREngine();

                motorANPR = new MotoANPR();
                motorANPR.CreateLPREngine();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
        static Bitmap DrawRectangle(Bitmap bitmap, int x, int y, int width, int height, Color color)
        {
            // Create a graphics object from the bitmap
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                // Create a pen with the specified color
                using (Pen pen = new Pen(color, 5))
                {
                    // Draw the rectangle
                    g.DrawRectangle(pen, x, y, width, height);
                }
            }

            // Return the modified bitmap
            return bitmap;
        }
    }
}
