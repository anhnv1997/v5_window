using IPaking.Ultility;

namespace iPakrkingv5.Controls.Controls.Buttons
{
    public class BtnSetting : Button, IDesignControl
    {
        public EventHandler? OnClickEvent;
        public BtnSetting() : base()
        {
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        }

        private void BtnOk_MouseLeave(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            this.ForeColor = Color.Black;
            this.Image = Properties.Resources.setting_0_0_0_32px;
        }
        private void BtnOk_MouseEnter(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            this.ForeColor = Color.Red;
            this.Image = Properties.Resources.setting_255_255_255_32px;
        }

        public void InitControl(EventHandler? OnClickEvent)
        {
            this.Font = new Font(this.Font.Name, TextManagement.ROOT_SIZE, FontStyle.Bold);
            this.ImageAlign = ContentAlignment.MiddleLeft;
            this.TextAlign = ContentAlignment.MiddleRight;
            this.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.Image = Properties.Resources.setting_0_0_0_32px;
            this.AutoSize = false;
            this.Size = new Size(this.PreferredSize.Width, this.PreferredSize.Height + TextManagement.ROOT_SIZE);
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
            this.Enabled = false;
            this.BackColor = Color.Transparent;
            if (this.OnClickEvent != null)
            {
                this.Click -= this.OnClickEvent;
                this.MouseEnter -= BtnOk_MouseEnter;
                this.MouseLeave -= BtnOk_MouseLeave;
            }
            this.Cursor = Cursors.Default;
            this.ForeColor = Color.Black;
            this.Image = Properties.Resources.setting_0_0_0_32px;
        }
        public void Reset()
        {
            this.Enabled = true;
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