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
        public static List<byte> ImageToByteArray(this Image? imageIn)
        {
            if (imageIn == null)
            {
                return new List<byte>();
            }
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, ImageFormat.Png);
                return ms.ToArray().ToList();
            }
        }
    }
}
