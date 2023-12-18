using IPGS.Object.Ultilities.Enums;
using IPGS.Ultility.Options;
using IPGS.Ultility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace iParkingv5.Controls
{
    public static class Extensions
    {
        public static void ToggleDoubleBuffered<TControl>(this TControl control, bool isOn) where TControl : Control
        {
            var pi = control.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);

            if (pi != null)
                pi.SetValue(control, isOn, null);
        }
        public static void EnableFastLoadGridView(this DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        public static void DisableFastLoadGridView(this DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
        }

        public static string Id(this DataGridView dgv)
        {
            var drv = dgv.CurrentRow;
            var selectedId = drv != null && drv.Cells["_ID"].Value == null ? "" : drv?.Cells["_ID"].Value.ToString() ?? "";
            return selectedId;
        }

        public static void AddMenuImageToImageList(this ImageList imgList, EmValidImage image, string key)
        {
            string imagePath = UltilityManagement.GetDisplayImagePath(Option.iconFontSize, image);
            var img = Image.FromFile(imagePath);
            var bmp = new Bitmap(img);
            imgList.Images.Add(key, bmp);
            img.Dispose();
        }

    }
}
