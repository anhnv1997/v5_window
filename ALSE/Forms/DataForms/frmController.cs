using ALSE.Objects;
using iParkingv5.Objects.Enums;
using static iParkingv5.Controller.ControllerFactory;

namespace ALSE
{
    public partial class frmController : Form
    {
        #region Properties
        private string controllerId = string.Empty;
        #endregion

        #region Forms
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                btnConfirm.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public frmController(string controllerId)
        {
            InitializeComponent();
            this.controllerId = controllerId;

            btnConfirm.Click += BtnConfirm_Click;
            btnCancel.Click += BtnCancel_Click;
            this.Load += FrmController_Load;
            cbCommunication.SelectedIndexChanged += CbCommunication_SelectedIndexChanged;
        }
        private void CbCommunication_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbCommunication.SelectedIndex == (int)CommunicationTypes.EM_CommunicationType.SERIAL)
            {
                lblIp.Text = "COM";
                lblPort.Text = "Baudrate";
            }
            else
            {
                lblIp.Text = "IP";
                lblPort.Text = "Port";
            }
        }
        private void FrmController_Load(object? sender, EventArgs e)
        {
            LoadCommunication();
            LoadControllerType();
            cbControllerType.DropDownStyle = cbCommunication.DropDownStyle = ComboBoxStyle.DropDownList;
            cbControllerType.SelectedIndex = 0;
            cbCommunication.SelectedIndex = 0;

            if (!string.IsNullOrEmpty(this.controllerId))
            {
                Controller? controller = AppDatas.controllers.GetObjectById(this.controllerId);
                if (controller != null)
                {
                    txtName.Text = controller.name;
                    txtCode.Text = controller.code;
                    txtDescription.Text = controller.description;
                    cbCommunication.SelectedIndex = controller.communication;
                    cbControllerType.SelectedIndex = controller.type;
                    txtIp.Text = controller.comport;
                    txtPort.Text = controller.baudrate.ToString();
                }
            }
        }
        #endregion

        #region Controls In Form
        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private async void BtnConfirm_Click(object? sender, EventArgs e)
        {
            bool isSuccess = false;
            string name = txtName.Text;
            string code = txtCode.Text;
            string description = txtDescription.Text;

            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Hãy nhập thông tin tên bộ điều khiển", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(txtIp.Text))
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin kết nối của thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int.Parse(txtPort.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Thông tin cổng không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Controller controller = new Controller(this.controllerId, name, code, description, txtIp.Text, int.Parse(txtPort.Text), cbControllerType.SelectedIndex, cbCommunication.SelectedIndex);
            if (string.IsNullOrEmpty(this.controllerId))
            {
                string newId = await tblController.InsertController(controller);
                if (!string.IsNullOrEmpty(newId))
                {
                    isSuccess = true;
                    controller.id = newId;
                    AppDatas.controllers.Add(controller);
                }
            }
            else
            {
                if (tblController.ModifyController(controller))
                {
                    AppDatas.controllers.Update(controller);
                    isSuccess = true;
                }
            }

            if (isSuccess)
            {
                MessageBox.Show("Cập nhật thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin thất bại, vui lòng thử lại sau giây lát", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        #endregion End Controls In Form

        #region Private Function
        private void LoadCommunication()
        {
            foreach (string communicationType in Enum.GetNames(typeof(CommunicationTypes.EM_CommunicationType)))
            {
                cbCommunication.Items.Add(communicationType);
            }
        }
        private void LoadControllerType()
        {
            foreach (string controllerType in Enum.GetNames(typeof(EmControllerType)))
            {
                cbControllerType.Items.Add(controllerType);
            }
        }
        #endregion End Private Function

        private void txtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
