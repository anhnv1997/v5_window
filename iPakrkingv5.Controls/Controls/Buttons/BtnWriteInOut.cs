using IPaking.Ultility;

namespace iPakrkingv5.Controls.Controls.Buttons
{
    public class BtnWriteInOut : Button, IDesignControl
    {
        public EventHandler? OnClickEvent;
        public BtnWriteInOut() : base()
        {
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            //this.BorderStyle = BorderStyle.Fixed3D;
        }

        private void BtnWriteInOut_MouseLeave(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            this.ForeColor = Color.Black;
            //this.BorderStyle = BorderStyle.Fixed3D;
            this.Image = Properties.Resources.Write;
        }
        private void BtnWriteInOut_MouseEnter(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            this.ForeColor = Color.Red;
            //this.BorderStyle = BorderStyle.FixedSingle;
            this.Image = Properties.Resources.Write;
        }

        public void InitControl(EventHandler? OnClickEvent)
        {
            this.Text = "Ghi vào";
            this.Font = new Font(this.Font.Name, TextManagement.ROOT_SIZE, FontStyle.Bold);
            this.ImageAlign = ContentAlignment.MiddleLeft;
            this.TextAlign = ContentAlignment.MiddleRight;
            this.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.Image = Properties.Resources.Write;
            this.AutoSize = false;
            this.Size = new Size(this.PreferredSize.Width, this.PreferredSize.Height + TextManagement.ROOT_SIZE);
            this.BackColor = Color.FromArgb(230, 230, 230);
            this.ForeColor = Color.Black;
            this.OnClickEvent = OnClickEvent;
            this.MouseEnter += BtnWriteInOut_MouseEnter;
            this.MouseLeave += BtnWriteInOut_MouseLeave;
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
                this.MouseEnter -= BtnWriteInOut_MouseEnter;
                this.MouseLeave -= BtnWriteInOut_MouseLeave;
            }
            this.Cursor = Cursors.Default;
            this.ForeColor = Color.Black;
            //this.BorderStyle = BorderStyle.Fixed3D;
            this.Image = Properties.Resources.Write;
        }
        public void Reset()
        {
            this.Enabled = true;
            this.BackColor = Color.FromArgb(230, 230, 230);
            this.ForeColor = Color.Black;
            if (this.OnClickEvent != null)
            {
                this.Click += this.OnClickEvent;
                this.MouseEnter += BtnWriteInOut_MouseEnter;
                this.MouseLeave += BtnWriteInOut_MouseLeave;
            }
        }
    }
}