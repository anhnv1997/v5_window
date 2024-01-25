using IPaking.Ultility;

namespace iPakrkingv5.Controls.Controls.Buttons
{
    public class LblCancel : Label, IDesignControl
    {
        public EventHandler? OnClickEvent;
        public LblCancel() : base()
        {
            Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BorderStyle = BorderStyle.Fixed3D;
        }

        private void BtnCancel_MouseLeave(object? sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            ForeColor = Color.Black;
            BorderStyle = BorderStyle.Fixed3D;
            Image = Properties.Resources.NO_0_0_0_32px;
        }
        private void BtnCancel_MouseEnter(object? sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            ForeColor = Color.Red;
            BorderStyle = BorderStyle.FixedSingle;
            Image = Properties.Resources.NO_255_255_255_32px;
        }

        public void Init(EventHandler? OnClickEvent)
        {
            Text = "Đóng";
            Font = new Font(Font.Name, TextManagement.ROOT_SIZE, FontStyle.Bold);

            AutoSize = false;
            ImageAlign = ContentAlignment.MiddleLeft;
            TextAlign = ContentAlignment.MiddleRight;
            Image = Properties.Resources.NO_0_0_0_32px;
            Size = new Size(PreferredWidth + Image.Width / 2 + TextManagement.ROOT_SIZE * 2, PreferredHeight + TextManagement.ROOT_SIZE);

            BackColor = Color.FromArgb(230, 230, 230);
            ForeColor = Color.Black;
            this.OnClickEvent = OnClickEvent;
            MouseEnter += BtnCancel_MouseEnter;
            MouseLeave += BtnCancel_MouseLeave;
            if (this.OnClickEvent != null)
            {
                Click += this.OnClickEvent;
            }
        }
        public void EnableWaitMode()
        {
            BackColor = Color.Transparent;
            Click -= OnClickEvent;
            MouseEnter -= BtnCancel_MouseEnter;
            MouseLeave -= BtnCancel_MouseLeave;
            BorderStyle = BorderStyle.Fixed3D;
            Image = Properties.Resources.NO_0_0_0_32px;
        }
        public void Reset()
        {
            BackColor = Color.FromArgb(230, 230, 230);
            ForeColor = Color.Black;
            Click += OnClickEvent;
            MouseEnter += BtnCancel_MouseEnter;
            MouseLeave += BtnCancel_MouseLeave;
        }
    }
}