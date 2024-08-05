using Microsoft.VisualBasic.Logging;
using System.Reflection;

namespace iPakrkingv5.Controls
{
    public static class ControlExtensions
    {
        public static void ShowImageUrlAsync(this PictureBox pic, string imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl))
            {
                pic.Image = pic.ErrorImage;
                return;
            }
            try
            {
                pic.LoadAsync(imageUrl);
            }
            catch (Exception)
            {
            }
        }
        public static void ToggleDoubleBuffered<TControl>(this TControl control, bool isOn) where TControl : Control
        {
            var pi = control.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);

            if (pi != null)
                pi.SetValue(control, isOn, null);
        }
        public static bool IsSupportsTransparency(this Control control)
        {
            // Check if the control type is known to support transparency
            Type[] transparentControlTypes = { typeof(Panel), typeof(GroupBox), typeof(Label) };

            foreach (Type transparentType in transparentControlTypes)
            {
                if (transparentType.IsAssignableFrom(control.GetType()))
                {
                    return true;
                }
            }

            return false;
        }

        public static void ToUnder(this Control setControl, Control rootControl, int distance = 12)
        {
            setControl.Location = new Point(rootControl.Location.X, rootControl.Location.Y + rootControl.Height + distance);
        }

        public static void ToRight(this Control setControl, Control rootControl, int distance = 12)
        {
            setControl.Location = new Point(rootControl.Location.X + rootControl.Width + distance,
                                            rootControl.Location.Y);
        }
        public static void ToCenterRight(this Control setControl, Control rootControl, int distance = 12)
        {
            setControl.Location = new Point((int)(rootControl.Location.X + rootControl.Width + distance),
                                                  rootControl.Location.Y + (rootControl.Height - rootControl.Height) / 2);
        }


        public static void ToBottomRightChild(this Control setControl, Control parent, int padding = 0)
        {
            setControl.Location = new Point(parent.Width - setControl.Width - padding,
                                            parent.Height - setControl.Height - padding);
        }

        public static void ToLeft(this Control setControl, Control baseControl, int margin = 0)
        {
            setControl.Location = new Point(baseControl.Location.X - setControl.Width - margin,
                                                          baseControl.Location.Y);
        }
        public static void FromMultipleControls(this Control setControl, Control rootXControl, Control rootYControl, bool isCenterY = true)
        {
            if (isCenterY)
            {
                setControl.Location = new Point(rootXControl.Location.X, rootYControl.Location.Y + (rootYControl.Height - setControl.Height) / 2);
            }
            else
            {
                setControl.Location = new Point(rootXControl.Location.X, rootYControl.Location.Y);
            }
        }
    }
}
