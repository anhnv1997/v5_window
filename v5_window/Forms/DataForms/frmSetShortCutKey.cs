using iParkingv5.Objects;
using iParkingv5_window.Controls.Buttons;

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
            btnOk1.Init(BtnOk1_Click);
            lblTitle.Padding = new Padding(StaticPool.baseSize * 2);
            panelActions.Height = btnOk1.Height + StaticPool.baseSize * 3;
            btnOk1.Location = new Point(panelActions.Width - btnOk1.Width - StaticPool.baseSize * 2,
                                        StaticPool.baseSize);
        }

        private void BtnOk1_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        #endregion END FORMS
    }
}
