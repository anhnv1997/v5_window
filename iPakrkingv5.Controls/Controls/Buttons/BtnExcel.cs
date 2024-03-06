using IPaking.Ultility;

namespace iPakrkingv5.Controls.Controls.Buttons
{
    public class BtnExcel : Button, IDesignControl
    {
        public EventHandler? OnClickEvent;
        public BtnExcel() : base()
        {
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        }

        private void BtnOk_MouseLeave(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            this.ForeColor = Color.Black;
            this.Image = Properties.Resources.Excel_0_0_0_32px;
            this.Image = Properties.Resources.excel;
        }
        private void BtnOk_MouseEnter(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            this.ForeColor = Color.Red;
            this.Image = Properties.Resources.Excel_255_255_255_32px;
            this.Image = Properties.Resources.excel;
        }

        public void InitControl(EventHandler? OnClickEvent)
        {

            this.Text = "Xuất Excel";
            this.Font = new Font(this.Font.Name, TextManagement.ROOT_SIZE, FontStyle.Bold);

            this.AutoSize = false;
            this.ImageAlign = ContentAlignment.MiddleLeft;
            this.TextAlign = ContentAlignment.MiddleRight;
            this.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.Image = Properties.Resources.Excel_0_0_0_32px;
            this.Image = Properties.Resources.excel;
            this.Size = new Size(this.PreferredSize.Width, this.PreferredSize.Height + TextManagement.ROOT_SIZE);
            this.AutoSize = true;
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
                this.Image = Properties.Resources.Excel_0_0_0_32px;
                this.Image = Properties.Resources.excel;
            }
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
