using Kztek.Tools;
using System.Drawing.Imaging;

namespace Kztek.Helper
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
            Image? cloneImg = imageIn == null ? null : (Image)imageIn.Clone();

            if (cloneImg == null)
            {
                return new List<byte>();
            }
            return await Task.Run(() =>
            {

                Bitmap? bmp = new Bitmap(cloneImg);
                cloneImg.Dispose();
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
        public static Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }
        public static string ImageToBase64(string imagePath)
        {
            string base64String = string.Empty;
            if (File.Exists(imagePath))
            {
                using (var imageStream = new FileStream(imagePath, FileMode.Open))
                {
                    var buffer = new byte[imageStream.Length];
                    imageStream.Read(buffer, 0, (int)imageStream.Length);
                    base64String = Convert.ToBase64String(buffer);
                }
            }
            return base64String;
        }


    }
}
