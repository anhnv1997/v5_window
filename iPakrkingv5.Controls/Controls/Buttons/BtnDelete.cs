using IPaking.Ultility;

namespace iPakrkingv5.Controls.Controls.Buttons
{
    public class BtnDelete : Button, IDesignControl
    {
        public EventHandler? OnClickEvent;
        public BtnDelete() : base()
        {
            this.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        }

        private void BtnCancel_MouseLeave(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            this.ForeColor = Color.Black;
            this.Image = Properties.Resources.NO_0_0_0_32px;
        }
        private void BtnCancel_MouseEnter(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            this.ForeColor = Color.Red;
            this.Image = Properties.Resources.NO_255_255_255_32px;
        }

        public void InitControl(EventHandler? OnClickEvent)
        {
            this.Text = "Xóa";
            this.Font = new Font(this.Font.Name, TextManagement.ROOT_SIZE, FontStyle.Bold);

            this.AutoSize = false;
            this.ImageAlign = ContentAlignment.MiddleLeft;
            this.TextAlign = ContentAlignment.MiddleRight;
            this.TextImageRelation = TextImageRelation.ImageBeforeText;

            this.Image = Properties.Resources.NO_0_0_0_32px;
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
            this.BackColor = Color.Transparent;
            if (this.OnClickEvent != null)
            {
                this.Click -= this.OnClickEvent;
                this.MouseEnter -= BtnCancel_MouseEnter;
                this.MouseLeave -= BtnCancel_MouseLeave;
            }
            //this.BorderStyle = BorderStyle.Fixed3D;
            this.Enabled = false;
            this.Image = Properties.Resources.NO_0_0_0_32px;
        }
        public void Reset()
        {
            this.BackColor = Color.FromArgb(230, 230, 230);
            this.Enabled = true;
            this.ForeColor = Color.Black;
            if (this.OnClickEvent != null)
            {
                this.Click += this.OnClickEvent;
                this.MouseEnter += BtnCancel_MouseEnter;
                this.MouseLeave += BtnCancel_MouseLeave;
            }
        }
    }
}