using iPakrkingv5.Controls.Controls.Buttons;
using iParkingv5.Objects;

namespace iParkingv5_window.Forms.DataForms
{
    public partial class frmSetShortCutKey : Form
    {
        #region PROPERTIES
        private Keys keySet;
        public Keys KeySet
        {
            get => keySet; set
            {
                keySet = value;
                lblCurrentKeySetValue.Text = keySet.ToString();
            }
        }
        #endregion END PROPERTIES

        #region FORMS
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            this.KeySet = keyData;
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public frmSetShortCutKey(Keys keySet)
        {
            InitializeComponent();
            this.KeySet = keySet;
            this.Load += FrmSetShortCutKey_Load;
        }

        private void FrmSetShortCutKey_Load(object? sender, EventArgs e)
        {
            BtnOk btnOk1 = new BtnOk();
            LblCancel btnCancel = new LblCancel();
            panelActions.Controls.Add(btnOk1);
            panelActions.Controls.Add(btnCancel);

            btnOk1.InitControl(BtnOk1_Click);
            btnCancel.InitControl(BtnCancel_Click);

            btnCancel.Text = "Xóa thiết lập";
            btnCancel.Width = btnCancel.PreferredSize.Width;

            lblTitle.Padding = new Padding(StaticPool.baseSize * 2);
            panelActions.Height = btnOk1.Height + StaticPool.baseSize * 3;
            btnCancel.Location = new Point(panelActions.Width - btnCancel.Width - StaticPool.baseSize * 2,
                                        StaticPool.baseSize);
            btnOk1.Location = new Point(btnCancel.Location.X - btnOk1.Width - 3,
                                        StaticPool.baseSize);
        }

        private void BtnOk1_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            this.keySet = Keys.None;
            this.DialogResult = DialogResult.OK;
        }

        #endregion END FORMS
    }
}
