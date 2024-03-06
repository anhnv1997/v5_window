using IPaking.Ultility;

namespace iPakrkingv5.Controls.Controls.Buttons
{
    public class LblCancel : Button, IDesignControl
    {
        public EventHandler? OnClickEvent;
        public LblCancel() : base()
        {
            Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.Text = "Đóng";
        }

        private void BtnCancel_MouseLeave(object? sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            ForeColor = Color.Black;
            Image = Properties.Resources.NO_0_0_0_32px;
            Image = Properties.Resources.NO_255_255_255_32px;
        }
        private void BtnCancel_MouseEnter(object? sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            ForeColor = Color.Red;
            Image = Properties.Resources.NO_255_255_255_32px;
        }

        public void InitControl(EventHandler? OnClickEvent)
        {
            this.Text = "Đóng";
            this.Font = new Font(this.Font.Name, TextManagement.ROOT_SIZE, FontStyle.Bold);
            this.ImageAlign = ContentAlignment.MiddleLeft;
            this.TextAlign = ContentAlignment.MiddleRight;
            this.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.Image = Properties.Resources.NO_0_0_0_32px;
            Image = Properties.Resources.NO_255_255_255_32px;
            this.AutoSize = false;
            this.Size = new Size(this.PreferredSize.Width, this.PreferredSize.Height + TextManagement.ROOT_SIZE);
            this.BackColor = Color.FromArgb(230, 230, 230);
            this.ForeColor = Color.Black;
            this.OnClickEvent = OnClickEvent;
            this.MouseEnter += BtnCancel_MouseEnter;
            this.MouseLeave += BtnCancel_MouseLeave;
            if (this.OnClickEvent != null)
            {
                this.Click += this.OnClickEvent;
            }
        }
        public void EnableWaitMode()
        {
            BackColor = Color.Transparent;
            this.Enabled = false;
            Click -= OnClickEvent;
            MouseEnter -= BtnCancel_MouseEnter;
            MouseLeave -= BtnCancel_MouseLeave;
            Image = Properties.Resources.NO_0_0_0_32px;
            Image = Properties.Resources.NO_255_255_255_32px;
        }
        public void Reset()
        {
            this.Enabled = true;
            BackColor = Color.FromArgb(230, 230, 230);
            ForeColor = Color.Black;
            Click += OnClickEvent;
            MouseEnter += BtnCancel_MouseEnter;
            MouseLeave += BtnCancel_MouseLeave;
        }
    }
}