using IPaking.Ultility;

namespace iPakrkingv5.Controls.Controls.Buttons
{
    public class LblSetting : Label, IDesignControl
    {
        public EventHandler? OnClickEvent;
        public LblSetting() : base()
        {
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.BorderStyle = BorderStyle.Fixed3D;
        }

        private void BtnOk_MouseLeave(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            this.ForeColor = Color.Black;
            this.BorderStyle = BorderStyle.Fixed3D;
            this.Image = Properties.Resources.setting_0_0_0_32px;
        }
        private void BtnOk_MouseEnter(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            this.ForeColor = Color.Red;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Image = Properties.Resources.setting_255_255_255_32px;
        }

        public void Init(EventHandler? OnClickEvent)
        {
            this.Font = new Font(this.Font.Name, TextManagement.ROOT_SIZE, FontStyle.Bold);

            this.AutoSize = false;
            this.ImageAlign = ContentAlignment.MiddleLeft;
            this.TextAlign = ContentAlignment.MiddleRight;
            this.Image = Properties.Resources.setting_0_0_0_32px;
            this.Size = new Size(this.PreferredWidth + this.Image.Width / 2 + TextManagement.ROOT_SIZE * 2, this.PreferredHeight + TextManagement.ROOT_SIZE);

            this.BackColor = Color.FromArgb(230, 230, 230);
            this.ForeColor = Color.Black;
            this.OnClickEvent = OnClickEvent;
            this.MouseEnter += BtnOk_MouseEnter;
            this.MouseLeave += BtnOk_MouseLeave;
            if (this.OnClickEvent != null)
            {
                this.Click += this.OnClickEvent;
            }
        }
        public void EnableWaitMode()
        {
            this.BackColor = Color.Transparent;
            if (this.OnClickEvent != null)
            {
                this.Click -= this.OnClickEvent;
                this.MouseEnter -= BtnOk_MouseEnter;
                this.MouseLeave -= BtnOk_MouseLeave;
            }
            this.Cursor = Cursors.Default;
            this.ForeColor = Color.Black;
            this.BorderStyle = BorderStyle.Fixed3D;
            this.Image = Properties.Resources.setting_0_0_0_32px;
        }
        public void Reset()
        {
            this.BackColor = Color.FromArgb(230, 230, 230);
            this.ForeColor = Color.Black;
            if (this.OnClickEvent != null)
            {
                this.Click += this.OnClickEvent;
                this.MouseEnter += BtnOk_MouseEnter;
                this.MouseLeave += BtnOk_MouseLeave;
            }
        }
    }
}