using Kztek.Tools;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iParkingv5_window.Helpers
{
    public static class ImageHelper
    {
        public static Bitmap ResizeImage(Image imgToResize, int width, int height)
        {
            try
            {
                if (imgToResize == null)
                {
                    return null;
                }

                int sourceWidth = imgToResize.Width;
                int sourceHeight = imgToResize.Height;

                float nPercent = 0;
                float nPercentW = 0;
                float nPercentH = 0;

                nPercentW = ((float)width / (float)sourceWidth);
                nPercentH = ((float)height / (float)sourceHeight);

                if (nPercentH < nPercentW)
                    nPercent = nPercentH;
                else
                    nPercent = nPercentW;

                int destWidth = (int)(sourceWidth * nPercent);
                int destHeight = (int)(sourceHeight * nPercent);

                Bitmap b = new Bitmap(destWidth, destHeight);
                Graphics g = Graphics.FromImage((Image)b);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
                g.Dispose();

                return b;
            }
            catch
            {

            }
            return null;
        }

        public static async Task<List<byte>> ImageToByteArrayAsync(this Image? imageIn)
        {
            if (imageIn == null)
            {
                return new List<byte>();
            }
            return await Task.Run(() =>
            {
                Bitmap? bmp = new Bitmap(imageIn);

                using (var ms = new MemoryStream())
                {
                    try
                    {
                        bmp.Save(ms, ImageFormat.Png);
                        return ms.ToArray().ToList();
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.System, obj: ex);
                        return new List<byte>();
                    }
                }
            });
        }

        public static List<byte> ImageToByteArray(this Image? imageIn)
        {
            if (imageIn == null)
            {
                return new List<byte>();
            }
            Bitmap? bmp = new Bitmap(imageIn);

            using (var ms = new MemoryStream())
            {
                try
                {
                    bmp.Save(ms, ImageFormat.Png);
                    return ms.ToArray().ToList();
                }
                catch (Exception ex)
                {
                    LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.System, obj: ex);
                    return new List<byte>();
                }
            }
        }
    }
}
