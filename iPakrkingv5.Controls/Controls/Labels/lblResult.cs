using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPakrkingv5.Controls.Controls.Labels
{
    public class lblResult : Label
    {
        private string message = string.Empty;
        public string Message
        {
            set
            {
                this.message = value;
                this.Refresh();
            }
        }
        public Color MessageColor
        {
            set
            {
                this.BackColor = value;
                this.Refresh();
            }
        }
        public lblResult() : base()
        {
            this.Paint += LblResult_Paint;
        }

        private void LblResult_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            using (Font font = new Font("Segoe UI", 10, FontStyle.Bold))
            {
                DrawTextInCenter(g, this.message, font, Color.White);
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

            // Create a new font with the adjusted font size
            Font adjustedFont = new Font(font.FontFamily, fontSize, font.Style);

            // Recalculate the size of the text with the adjusted font size
            textSize = g.MeasureString(text, adjustedFont);

            // Calculate the position to draw the text so it is centered
            float textX = centerX - (textSize.Width / 2);
            float textY = centerY - (textSize.Height / 2);

            // Draw the text
            using (SolidBrush brush = new SolidBrush(color))
            {
                g.DrawString(text, adjustedFont, brush, textX, textY);
            }

            // Dispose of the adjusted font
            adjustedFont.Dispose();
        }

    }
}
