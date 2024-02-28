using iParkingv5.Objects;
using iParkingv5_CustomerRegister.Databases;
using iParkingv5_CustomerRegister.Forms;
using static iParkingv5_CustomerRegister.BRNETLH;

namespace iParkingv5_CustomerRegister.UserControls
{
    public partial class ucFinger : UserControl
    {
        #region Properties
        public ushort FingerId { get; set; } = 0;
        private string fingerDataStr = string.Empty;
        public string FingerDataStr
        {
            get => fingerDataStr;
            set
            {
                fingerDataStr = value;
                picEditFinger.Enabled = !string.IsNullOrEmpty(value);
                picDeleteFinger.Enabled = !string.IsNullOrEmpty(value);
                picAddFinger.Enabled = string.IsNullOrEmpty(value);
                lblFingerData.Text = value;
            }
        }
        #endregion End Properties

        #region Forms
        public ucFinger(int fingerIndex, string fingerData, ushort fingerId)
        {
            InitializeComponent();
            this.FingerId = fingerId;
            this.FingerDataStr = fingerData;

            lblFingerIndex.Text = fingerIndex.ToString("00");

            lblFingerData.AutoSize = false;

            this.Load += UcFinger_Load;
        }
        private void UcFinger_Load(object? sender, EventArgs e)
        {
            picDeleteFinger.Location = new Point(this.Width - picDeleteFinger.Width - StaticPool.baseSize, StaticPool.baseSize);
            picEditFinger.Location = new Point(picDeleteFinger.Location.X - picEditFinger.Width - StaticPool.baseSize, picDeleteFinger.Location.Y);
            picAddFinger.Location = new Point(picEditFinger.Location.X - picEditFinger.Width - StaticPool.baseSize, picEditFinger.Location.Y);

            lblFingerIndex.Location = new Point(StaticPool.baseSize, picDeleteFinger.Location.Y + (picDeleteFinger.Height - lblFingerIndex.Height) / 2);
            lblFingerData.Location = new Point(lblFingerIndex.Location.X + lblFingerIndex.Width + StaticPool.baseSize, lblFingerIndex.Location.Y);

            lblFingerData.Width = picAddFinger.Location.X - lblFingerData.Location.X - StaticPool.baseSize;
            lblFingerData.Height = lblFingerIndex.Height;
            this.Height = picAddFinger.Height + StaticPool.baseSize * 2;

            picAddFinger.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picDeleteFinger.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picEditFinger.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            picAddFinger.Click += PicAddFinger_Click;
            picAddFinger.MouseEnter += PicAddFinger_MouseEnter;
            picAddFinger.MouseLeave += PicAddFinger_MouseLeave;

            picDeleteFinger.Click += PicDeleteFinger_Click;
            picDeleteFinger.MouseEnter += PicDeleteFinger_MouseEnter;
            picDeleteFinger.MouseLeave += PicDeleteFinger_MouseLeave;

            picEditFinger.Click += PicEditFinger_Click;
            picEditFinger.MouseEnter += PicEditFinger_MouseEnter;
            picEditFinger.MouseLeave += PicEditFinger_MouseLeave;

            toolTip1.SetToolTip(picAddFinger, "Thêm thông tin vân tay");
            toolTip1.SetToolTip(picEditFinger, "Sửa thông tin vân tay");
            toolTip1.SetToolTip(picDeleteFinger, "Xóa thông tin vân tay");
            this.SizeChanged += UcFinger_SizeChanged;
        }
        private void UcFinger_SizeChanged(object? sender, EventArgs e)
        {
            lblFingerData.Width = picAddFinger.Location.X - lblFingerData.Location.X - StaticPool.baseSize;
        }
        #endregion End Forms

        #region Controls In Form
        private void PicEditFinger_MouseLeave(object? sender, EventArgs e)
        {
            picEditFinger.Cursor = Cursors.Default;
            picEditFinger.Image = Properties.Resources.finger_edit_0_0_0_24px_png;
        }
        private void PicEditFinger_MouseEnter(object? sender, EventArgs e)
        {
            picEditFinger.Cursor = Cursors.Hand;
            picEditFinger.Image = Properties.Resources.finger_edit_255_255_255_24px_png;
        }
        private void PicEditFinger_Click(object? sender, EventArgs e)
        {
            frmRegisterFingerPrint frm = new(this.FingerId, frmRegisterFingerPrint.EmOperatorType.Modify);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.FingerDataStr = frm.FingerCharStr;
            }
        }

        private void PicDeleteFinger_MouseLeave(object? sender, EventArgs e)
        {
            picDeleteFinger.Cursor = Cursors.Default;
            picDeleteFinger.Image = Properties.Resources.finger_delete_0_0_0_24px_png;
        }
        private void PicDeleteFinger_MouseEnter(object? sender, EventArgs e)
        {
            picDeleteFinger.Cursor = Cursors.Hand;
            picDeleteFinger.Image = Properties.Resources.finger_delete_255_255_255_24px_png;
        }
        private void PicDeleteFinger_Click(object? sender, EventArgs e)
        {
            if (!(BRNETLH.Open()))
            {
                MessageBox.Show("Không kết nối được đến thiết bị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (BRNETLH.CmdDelChar(this.FingerId))
            {
                MessageBox.Show("Xóa thông tin vân tay thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (BRNETLH._ErrFlag != (int)EmError.CMD_RT_MB_NOT_EXIST_IN_ADDRESS)
                {
                    string errorMessgae = BRNETLH.GetLastErrorMessage();
                    MessageBox.Show($"Xóa thông tin vân tay thất bại: {errorMessgae} \r\n vui lòng thử lại sau giây lát!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            tblFingerprint.DeleteFinger(this.FingerId);
            tblFingerCustomer.DeleteByFingerId(this.FingerId);
            this.FingerDataStr = "";
            BRNETLH.Close();
        }

        private void PicAddFinger_MouseLeave(object? sender, EventArgs e)
        {
            picAddFinger.Cursor = Cursors.Default;
            picAddFinger.Image = Properties.Resources.finger_add_0_0_0_24px;
        }
        private void PicAddFinger_MouseEnter(object? sender, EventArgs e)
        {
            picAddFinger.Cursor = Cursors.Hand;
            picAddFinger.Image = Properties.Resources.finger_add_255_255_255_24px;
        }
        private void PicAddFinger_Click(object? sender, EventArgs e)
        {
            frmRegisterFingerPrint frm = new(this.FingerId, frmRegisterFingerPrint.EmOperatorType.Add);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.FingerDataStr = frm.FingerCharStr;
                this.FingerId = frm.registerIndex;
            }
        }
        public Tuple<ushort, string> GetFingerData()
        {
            return Tuple.Create<ushort, string>(this.FingerId, this.FingerDataStr);
        }
        #endregion End Controls In Form
    }
}
