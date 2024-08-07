using IPaking.Ultility;
using iParkingv5.Objects;
using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Datas.parking_service;
using iParkingv5.Objects.Enums;

namespace iParkingv5_window.Forms.DataForms
{
    public partial class frmConfirmIn : Form
    {
        //private iPakrkingv5.Controls.Controls.Buttons.LblCancel btnCancel1;
        //private iPakrkingv5.Controls.Controls.Buttons.BtnOk btnOk;
        public string updatePlate;
        public frmConfirmIn(string message, Identity identity, IdentityGroup identityGroup, Customer? customer, RegisteredVehicle? vehicle,
                            string plateNumber, Image vehicleImage, Image overviewImage)
        {
            InitializeComponent();
            this.Text = "Xác nhận thông tin";
            lblMessage.Text = message;
            lblMessage.Height = lblMessage.PreferredHeight;
            updatePlate = plateNumber;

            txtDetectPlate.Text = plateNumber;
            lblRegisterPlate.Text = vehicle?.PlateNumber ?? "";
            lblTimeIn.Text = DateTime.Now.ToVNTime();
            lblIdentityCode.Text = identity?.Name ?? "";
            lblIdentityGroup.Text = identityGroup?.Name ?? "";
            lblVehicleType.Text = VehicleType.GetDisplayStr(identityGroup?.VehicleType ?? 0);

            picOverview.Image = overviewImage;
            picVehicle.Image = vehicleImage;
            this.Load += FrmConfirm_Load;
        }

        private void FrmConfirm_Load(object? sender, EventArgs e)
        {
            lblCancel1.InitControl(BtnCancel1_Click);
            btnOk1.InitControl(BtnOk_Click);

            lblMessage.Padding = new Padding(StaticPool.baseSize);
            lblMessage.Height = lblMessage.PreferredSize.Height;

            panelAction.Height = lblCancel1.Height + StaticPool.baseSize * 3;
            lblCancel1.Location = new Point(panelAction.Width - lblCancel1.Width - StaticPool.baseSize * 2,
                                            StaticPool.baseSize);
            btnOk1.Location = new Point(lblCancel1.Location.X - btnOk1.Width - StaticPool.baseSize,
                                       StaticPool.baseSize);
            this.Visible = false;

            this.ActiveControl = btnOk1;
        }

        #region Controls In Form
        private void BtnOk_Click(object? sender, EventArgs e)
        {
            updatePlate = txtDetectPlate.Text;
            this.DialogResult = DialogResult.OK;
        }
        private void BtnCancel1_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion

        private void btnCopy_Click(object sender, EventArgs e)
        {
            txtDetectPlate.Text = lblRegisterPlate.Text;
            this.ActiveControl = txtDetectPlate;
            txtDetectPlate.SelectionStart = txtDetectPlate.Text.Length;
            txtDetectPlate.SelectionLength = 0;
        }

        private void frmConfirmIn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                BtnOk_Click(null, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                BtnCancel1_Click(null, EventArgs.Empty);
            }
        }
    }
}
