using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPakrkingv5.Controls.Controls.TextBoxs
{
    public class AutoFontSizeTextBox : TextBox
    {
        private bool isBold = true;
        // Expose properties to design mode
        [Browsable(true)]
        [Category("Custom Message")]
        [Description("Sets the text of the Label")]
        public bool IsBold
        {
            get { return isBold; }
            set
            {
                this.isBold = value;
                this.Refresh();
            }
        }

        private string message = string.Empty;
        // Expose properties to design mode
        [Browsable(true)]
        [Category("Custom Message")]
        [Description("Sets the text of the Label")]
        public string Message
        {
            get { return message; }
            set
            {
                this.message = value;
                this.Refresh();
            }
        }

        [Browsable(true)]
        [Category("Custom Back Color")]
        [Description("Sets the back color of the Label")]
        public Color MessageBackColor
        {
            get { return this.BackColor; }
            set
            {
                this.BackColor = value;
                this.Refresh();
            }
        }

        private Color messageForeColor = Color.White;
        public Color MessageForeColor
        {
            get { return this.messageForeColor; }
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


        private int maxFontSize = 24;
        [Browsable(true)]
        [Category("Custom max font size")]
        [Description("Sets  max font size of the Label")]
        public int MaxFontSize
        {
            get { return maxFontSize; }
            set
            {
                this.maxFontSize = value;
                this.Refresh();
            }
        }

        public int CurrentFontSize = 0;
        public AutoFontSizeTextBox()
        {
            // Set some default properties
            this.Multiline = false;
            this.Width = 100;
            this.Height = 100;
            this.TextChanged += AutoFontSizeTextBox_TextChanged;
        }

        private void AutoFontSizeTextBox_TextChanged(object sender, EventArgs e)
        {
            AdjustFontSize();
        }

        private void AdjustFontSize()
        {
            // Initial font size
            float fontSize = maxFontSize;
            this.Font = new Font(this.Font.FontFamily, fontSize, (IsBold ? FontStyle.Bold : FontStyle.Regular));

            // Get the size of the TextBox
            Size textBoxSize = this.ClientSize;

            // Measure the size of the text
            using (Graphics g = this.CreateGraphics())
            {
                while (fontSize > 1)
                {
                    SizeF textSize = g.MeasureString(this.Text, new Font(this.Font.FontFamily, fontSize));

                    // Adjust the font size if the text is too large or too small
                    if ((textSize.Width + 10) > textBoxSize.Width || textSize.Height > textBoxSize.Height)
                    {
                        fontSize -= 0.5f; // Decrease font size
                    }
                    else
                    {
                        break; // Text fits within the TextBox
                    }
                }
            }

            // Set the new font size
            this.Font = new Font(this.Font.FontFamily, fontSize, (IsBold ? FontStyle.Bold : FontStyle.Regular));
            using (Graphics g = this.CreateGraphics())
            {
                // Measure the height of the text
                SizeF textSize = g.MeasureString(this.Text, this.Font);

                // Calculate the vertical padding needed to center the text
                int verticalPadding = (int)((this.ClientSize.Height - textSize.Height) / 2);

                // Ensure the padding isn't negative
                verticalPadding = Math.Max(verticalPadding, 0);

                // Apply padding to vertically center the text
                this.Padding = new Padding(this.Padding.Left, verticalPadding, this.Padding.Right, verticalPadding);
            }

        }
    }
}
