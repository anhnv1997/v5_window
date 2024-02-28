using IPaking.Ultility;
using iParkingv5.Objects;
using iParkingv5.Objects.Databases;
using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Enums;
using iParkingv6.ApiManager.KzParkingv3Apis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iParkingv5_CustomerRegister.Forms
{
    public partial class frmSelectIdentityGroup : Form
    {
        #region Properties
        public string IdentityGroupId { get; set; }
        public string IdentityGroupName { get; set; }
        private string title = "Danh sách nhóm định danh";
        List<VehicleType> vehicleTypes = new List<VehicleType>();
        #endregion End Properties

        #region Forms
        public frmSelectIdentityGroup()
        {
            InitializeComponent();
            this.Load += FrmSelectIdentityGroup_Load;
            dgvData.CellDoubleClick += DgvData_CellDoubleClick;
        }


        private async void FrmSelectIdentityGroup_Load(object? sender, EventArgs e)
        {
            lblTitle.Text = title;
            lblTitle.BackColor = Color.Transparent;
            lblIdentityGroupName.BackColor = Color.Transparent;
            lblVehicleType.BackColor = Color.Transparent;

            lblSearch1.InitControl(LblSearch1_Click);
            lblCancel1.InitControl(LblCancel1_Click);
            lblOk1.InitControl(LblOk1_Click);

            lblTitle.Font = new Font(this.Font.Name, TextManagement.ROOT_SIZE * 2, FontStyle.Bold);
            lblTitle.Location = new Point(TextManagement.ROOT_SIZE * 2, TextManagement.ROOT_SIZE * 2);


            lblIdentityGroupName.Location = new Point(lblTitle.Location.X, lblTitle.Location.Y + lblTitle.Height + (int)(TextManagement.ROOT_SIZE * 1.5));
            txtIdentityGroupName.Location = new Point(lblIdentityGroupName.Location.X + lblIdentityGroupName.Width + TextManagement.ROOT_SIZE,
                                                      lblIdentityGroupName.Location.Y + (lblIdentityGroupName.Height - txtIdentityGroupName.Height) / 2);

            cbVehicleType.Location = new Point(txtIdentityGroupName.Location.X, txtIdentityGroupName.Location.Y + txtIdentityGroupName.Height + TextManagement.ROOT_SIZE);
            lblVehicleType.Location = new Point(lblIdentityGroupName.Location.X, cbVehicleType.Location.Y + (cbVehicleType.Height - lblVehicleType.Height) / 2);

            lblSearch1.Location = new Point(txtIdentityGroupName.Location.X + txtIdentityGroupName.Width + TextManagement.ROOT_SIZE,
                                            cbVehicleType.Location.Y + cbVehicleType.Height - lblSearch1.Height);

            lblCancel1.Location = new Point(this.DisplayRectangle.Width - lblCancel1.Width - TextManagement.ROOT_SIZE * 2,
                                            this.DisplayRectangle.Height - lblCancel1.Height - TextManagement.ROOT_SIZE * 2);
            lblOk1.Location = new Point(lblCancel1.Location.X - lblOk1.Width - TextManagement.ROOT_SIZE, lblCancel1.Location.Y);

            dgvData.Location = new Point(lblTitle.Location.X, cbVehicleType.Location.Y + cbVehicleType.Height + TextManagement.ROOT_SIZE);
            dgvData.Width = this.DisplayRectangle.Width - TextManagement.ROOT_SIZE * 4;
            dgvData.Height = lblCancel1.Location.Y - TextManagement.ROOT_SIZE - dgvData.Location.Y;

            dgvData.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;

            await LoadVehicleType();
        }
        #endregion End Forms

        #region Controls In Form
        private async void LblSearch1_Click(object? sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                dgvData.Rows.Clear();
                this.Cursor = Cursors.WaitCursor;
            }));
            string keyword = txtIdentityGroupName.Text;
            string vehicleTypeId = cbVehicleType.SelectedItem == null ? "" : ((ListItem)cbVehicleType.SelectedItem).Value;
            List<IdentityGroup> identityGroups = await KzParkingApiHelper.GetIdentityGroupsAsync(keyword, vehicleTypeId);
            if (identityGroups != null)
            {
                foreach (var identityGroup in identityGroups)
                {
                    string id = identityGroup.Id.ToString();
                    string name = identityGroup.Name;
                    string code = identityGroup.Code;
                    string vehicleType = VehicleType.GetVehicleTypeName(this.vehicleTypes, identityGroup.VehicleTypeId);
                    this.Invoke(new Action(() =>
                    {
                        dgvData.Rows.Add(id, dgvData.RowCount + 1, name, code, vehicleType);
                    }));
                }
            }
            this.Invoke(new Action(() =>
            {
                this.Cursor = Cursors.Default;
            }));
        }
        private void LblCancel1_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void LblOk1_Click(object? sender, EventArgs e)
        {
            if (dgvData.Rows.Count > 0)
            {
                ChooseIdentityGroup();
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
        private void DgvData_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                ChooseIdentityGroup();
            }
        }

        private void ChooseIdentityGroup()
        {
            this.IdentityGroupId = dgvData.CurrentRow.Cells[0]?.Value?.ToString() ?? string.Empty;
            this.IdentityGroupName = dgvData.CurrentRow.Cells[2]?.Value?.ToString() ?? string.Empty;
            this.DialogResult = DialogResult.OK;
        }
        #endregion End Controls In Form

        #region Private Function
        private async Task LoadVehicleType()
        {
            vehicleTypes = await KzParkingApiHelper.GetAllVehicleTypes();
            if (vehicleTypes != null)
            {
                foreach (var vehicleType in vehicleTypes)
                {
                    ListItem item = new ListItem()
                    {
                        Name = vehicleType.Name,
                        Value = vehicleType.Id.ToString()
                    };
                    cbVehicleType.Items.Add(item);
                }
            }
            cbVehicleType.DisplayMember = "Name";
            cbVehicleType.ValueMember = "Value";
            cbVehicleType.SelectedIndex = cbVehicleType.Items.Count > 0 ? 0 : -1;
            cbVehicleType.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        #endregion End Private Function

        #region Public Function

        #endregion End Public Function

    }
}
