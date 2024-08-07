using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPakrkingv5.Controls.Controls.Labels
{
    public class lblResult : Label
    {
        #region Properties
        private string message = string.Empty;
        // Expose properties to design mode
        [Category("Custom Message")]
        [Description("Sets the text of the Label")]
        public string Message
        {
            set
            {
                this.message = value;
                this.Refresh();
            }
        }

        [Category("Custom Back Color")]
        [Description("Sets the back color of the Label")]
        public Color MessageBackColor
        {
            set
            {
                this.BackColor = value;
                this.Refresh();
            }
        }

        private Color messageForeColor = Color.White;
        public Color MessageForeColor
        {
            set
            {
                this.messageForeColor = value;
                this.Refresh();
            }
        }

        private string fontName = "Segoe UI";
        public string FontName
        {
            set
            {
                this.fontName = value;
                this.Refresh();
            }
        }


        private int maxFontSize = -1;
        public int MaxFontSize
        {
            set
            {
                this.maxFontSize = value;
                this.Refresh();
            }
        }

        public int CurrentFontSize = 0;
        #endregion End Properties

        #region Controls
        public lblResult() : base()
        {
            this.Paint += LblResult_Paint;
        }

        private void LblResult_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            using (Font font = new Font(this.fontName, 10, FontStyle.Bold))
            {
                DrawTextInCenter(g, this.message.ToUpper(), font, this.messageForeColor);
            }

        }
        private void DrawTextInCenter(Graphics g, string text, Font font, Color color)
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            // Calculate the center position of the UserControl
            float centerX = this.Width / 2f;
            float centerY = this.Height / 2f;

            // Calculate the maximum width and height available for the text
            float maxWidth = this.Width;
            float maxHeight = this.Height;

            // Start with a default font size
            float fontSize = 10;

            // Measure the size of the text with the default font size
            SizeF textSize = g.MeasureString(text, font);

            // Calculate the scaling factor for width and height
            float scaleX = maxWidth / textSize.Width;
            float scaleY = maxHeight / textSize.Height;

            // Choose the smaller scaling factor to ensure that the text fits within the UserControl
            float scale = Math.Min(scaleX, scaleY);

            // Adjust the font size based on the scaling factor
            fontSize *= scale;

            fontSize = maxFontSize <= 0 ? fontSize : (fontSize < maxFontSize ? fontSize : maxFontSize);
            this.CurrentFontSize = (int)fontSize;

            // Create a new font with the adjusted font size
            Font adjustedFont = new Font(font.FontFamily, fontSize, font.Style);

            // Recalculate the size of the text with the adjusted font size
            textSize = g.MeasureString(text, adjustedFont);

            float textX = 0;
            float textY = 0;
            textY = centerY - (textSize.Height / 2);
            if (this.TextAlign == ContentAlignment.MiddleCenter)
            {
                textX = centerX - (textSize.Width / 2);
            }
            else if (this.TextAlign == ContentAlignment.MiddleRight)
            {
                textX = this.Width - textSize.Width;
            }
            else
            {
                textX = 0;
            }
            // Calculate the position to draw the text so it is centered


            // Draw the text
            using (SolidBrush brush = new SolidBrush(color))
            {
                g.DrawString(text, adjustedFont, brush, textX, textY);
            }

            // Dispose of the adjusted font
            adjustedFont.Dispose();
        }
        #endregion End Controls

        #region Private Function

        #endregion End Private Functin

        #region Public Function

        #endregion



    }
}
