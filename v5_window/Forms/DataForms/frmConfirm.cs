using iParkingv5.Objects;

namespace iParkingv5_window.Forms.DataForms
{
    public partial class frmConfirm : Form
    {
        #region Forms
        public frmConfirm(string errorMessage, bool isEventIn)
        {
            InitializeComponent();
            this.Text = isEventIn ? "Xác nhận xe vào bãi" : "Xác nhận xe ra khỏi bãi";
            lblMessage.Text = errorMessage + (isEventIn ? "\r\nBạn có xác nhận cho xe vào bãi?" :
                                                          "\r\nBạn có xác nhận cho xe ra khỏi bãi?");
            lblMessage.Size = lblMessage.PreferredSize;
            btnOk.Focus();
            this.Size = new Size(lblMessage.Width, lblMessage.Height + panelAction.Height + 100);
            this.Load += FrmConfirm_Load;
        }

        private void FrmConfirm_Load(object? sender, EventArgs e)
        {
            btnCancel1.Init(BtnCancel1_Click);
            btnOk.Init(BtnOk_Click);

            lblMessage.Padding = new Padding(StaticPool.baseSize * 2);

            panelAction.Height = btnCancel1.Height + StaticPool.baseSize * 3;
            btnCancel1.Location = new Point(panelAction.Width - btnCancel1.Width - StaticPool.baseSize * 2,
                                            StaticPool.baseSize);
            btnOk.Location = new Point(btnCancel1.Location.X - btnOk.Width - StaticPool.baseSize,
                                       StaticPool.baseSize);
        }

        private void BtnOk_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void BtnCancel1_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion End Forms

    }
}
