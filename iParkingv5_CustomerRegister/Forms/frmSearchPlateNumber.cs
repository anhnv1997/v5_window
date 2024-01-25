using IPaking.Ultility;
using iPakrkingv5.Controls.Controls.Buttons;
using iPakrkingv5.Controls.Usercontrols.BuildControls;
using iParkingv5.Objects;
using iParkingv5.Objects.Enums;
using iParkingv6.ApiManager.KzParkingv3Apis;
using iParkingv6.Objects.Datas;
using System.Runtime.InteropServices;

namespace iParkingv5_CustomerRegister.Forms
{
    public partial class frmSearchPlateNumber : Form
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;
        #region PROPERTIES
        public string selectedVehicleName
        {
            get;
            set;
        } = string.Empty;
        public string selectedVehiclePlate
        {
            get;
            set;
        } = string.Empty;
        public string selectedVehicleId { get; set; } = string.Empty;

        public string selectedVehicleTypeId { get; set; } = string.Empty;
        public string selectedVehicleTypeName
        {
            get;
            set;
        } = string.Empty;


        public string selecteCustomerId { get; set; } = string.Empty;
        public string selecteCustomerName { get; set; } = string.Empty;
        public string selecteCustomerCode { get; set; } = string.Empty;

        public string selectedCustomerGroupId { get; set; } = string.Empty;
        public string selectedCustomerGroupName { get; set; } = string.Empty;
        #endregion END PROPERTIES

        #region FORMS
        public frmSearchPlateNumber()
        {
            InitializeComponent();
            this.Load += FrmSelectPlateNumber_Load;
            dgvData.CellDoubleClick += DgvCard_CellDoubleClick;
        }
        private void FrmSelectPlateNumber_Load(object? sender, EventArgs e)
        {
            this.Font = panelData.Font = new Font(this.Font.Name, StaticPool.baseSize);
            lblTittle.Font = new Font(this.Font.Name, StaticPool.baseSize * 2, FontStyle.Bold);

            lblSearch.Init(BtnSearch_Click);
            btnOk1.Init(BtnOk1_Click);
            btnCancel1.Init(BtnCancel1_Click);

            lblTittle.Location = new Point(StaticPool.baseSize * 2, StaticPool.baseSize * 2);
            lblCustomer.Location = new Point(lblTittle.Location.X, lblTittle.Location.Y + lblTittle.Height + StaticPool.baseSize);

            txtKeyword.Location = new Point(lblCustomer.Location.X + lblCustomer.Width + StaticPool.baseSize,
                                            lblCustomer.Location.Y + (lblCustomer.Height - txtKeyword.Height) / 2);
            lblSearch.Location = new Point(txtKeyword.Location.X + txtKeyword.Width + StaticPool.baseSize,
                                           txtKeyword.Location.Y + (txtKeyword.Height - lblSearch.Height) / 2);

            btnCancel1.Location = new Point(panelData.Width - btnCancel1.Width - StaticPool.baseSize * 2,
                                           panelData.Height - btnCancel1.Height - StaticPool.baseSize * 2);
            btnOk1.Location = new Point(btnCancel1.Location.X - btnOk1.Width - StaticPool.baseSize, btnCancel1.Location.Y);
            dgvData.Location = new Point(lblTittle.Location.X, lblSearch.Location.Y + lblSearch.Height + StaticPool.baseSize);
            dgvData.Width = panelData.Width - StaticPool.baseSize * 4;
            dgvData.Height = btnCancel1.Location.Y - StaticPool.baseSize - dgvData.Location.Y;
            ucNotify1.OnSelectResultEvent += UcNotify1_OnSelectResultEvent;
        }
        #endregion END FORMS

        #region CONTROLS IN FORM
        private async void BtnSearch_Click(object? sender, EventArgs e)
        {
            panelData.SuspendLayout();
            panelData.BackColor = Color.FromArgb((int)(0.37 * 255), 42, 47, 48);
            foreach (Control item in panelData.Controls)
            {
                if (item is ucLoading)
                {
                    continue;
                }
                else if (item is ucNotify)
                {
                    continue;
                }
                if (!IsSupportsTransparency(item))
                {
                    item.Enabled = false;
                    continue;
                }
                else if (item is IDesignControl)
                {
                    ((IDesignControl)item).EnableWaitMode();
                }
            }
            ucLoading1.Show("Đang tải thông tin phương tiện", TextManagement.ROOT_LANGUAGE);
            panelData.ResumeLayout();
            dgvData.Rows.Clear();
            dgvData.Refresh();

            SendMessage(dgvData.Handle, WM_SETREDRAW, false, 0);
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            var registerVehicles = await KzParkingApiHelper.GetRegisteredVehicles(txtKeyword.Text);
            var customers = await KzParkingApiHelper.GetAllCustomers();
            var vehicleTypes = await KzParkingApiHelper.GetAllVehicleTypes();
            if (registerVehicles != null)
            {
                if (registerVehicles != null)
                {
                    for (int i = 0; i < registerVehicles.Count; i++)
                    {
                        string vehicleId = registerVehicles[i].Id;
                        string vehicleTypeId = registerVehicles[i].VehicleTypeId.ToString();
                        string customerID = registerVehicles[i].CustomerId;

                        Customer.GetCustomerName(customers.Item1, customerID, out string customerName, out string customerCode,
                                                                              out string customerGroupId, out string customerGroupName);
                        dgvData.Rows.Add(i + 1, registerVehicles[i].Name,
                                                registerVehicles[i].PlateNumber,
                                                VehicleType.GetVehicleTypeName(vehicleTypes, registerVehicles[i].VehicleTypeId),
                                                customerName,
                                                customerCode,
                                                customerGroupName,
                                                customerID,
                                                vehicleTypeId,
                                                customerID,
                                                customerGroupId);
                        registerVehicles[i] = null;
                    }
                    registerVehicles.Clear();
                    customers.Item1?.Clear();
                    vehicleTypes?.Clear();
                    GC.Collect();
                }
            }
            else
            {
                ucLoading1.HideLoading();
                ucNotify1.Show(ucNotify.EmNotiType.Error, "");
                ucNotify1.OnSelectResultEvent += UcNotify1_OnSelectResultEvent;
                return;
            }

            if (dgvData.Rows.Count > 0)
            {
                dgvData.CurrentCell = dgvData.Rows[0].Cells[0];
            }

            ucLoading1.HideLoading();
            panelData.BackColor = Color.White;
            foreach (Control item in panelData.Controls)
            {
                if (item is ucLoading)
                {
                    continue;
                }
                else if (item is IDesignControl)
                {
                    ((IDesignControl)item).Reset();
                }
                item.Enabled = true;
            }

            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            SendMessage(dgvData.Handle, WM_SETREDRAW, true, 0);
            dgvData.Refresh();
        }

        private void UcNotify1_OnSelectResultEvent(DialogResult result)
        {
            panelData.BackColor = Color.White;
            foreach (Control item in panelData.Controls)
            {
                if (item is ucLoading)
                {
                    continue;
                }
                else if (item is ucNotify)
                {
                    continue;
                }
                else if (item is IDesignControl)
                {
                    ((IDesignControl)item).Reset();
                }
                item.Enabled = true;
            }
        }

        private void BtnCancel1_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void BtnOk1_Click(object? sender, EventArgs e)
        {
            if (dgvData.Rows.Count > 0)
            {
                ChooseCustomer();
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
        private void DgvCard_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                ChooseCustomer();
            }
        }
        #endregion END CONTROLS IN FORM

        #region PRIVATE FUNCTION
        private void ChooseCustomer()
        {
            //Vehicle
            this.selectedVehicleName = dgvData.CurrentRow.Cells[1]?.Value?.ToString() ?? string.Empty;
            this.selectedVehiclePlate = dgvData.CurrentRow.Cells[2]?.Value?.ToString() ?? string.Empty;
            this.selectedVehicleId = dgvData.CurrentRow.Cells[dgvData.ColumnCount - 4]?.Value?.ToString() ?? string.Empty;

            //VehicleType
            this.selectedVehicleTypeName = dgvData.CurrentRow.Cells[3]?.Value?.ToString() ?? string.Empty;
            this.selectedVehicleTypeId = dgvData.CurrentRow.Cells[dgvData.ColumnCount - 3]?.Value?.ToString() ?? string.Empty;

            //Customer
            this.selecteCustomerName = dgvData.CurrentRow.Cells[4]?.Value?.ToString() ?? string.Empty;
            this.selecteCustomerCode = dgvData.CurrentRow.Cells[5]?.Value?.ToString() ?? string.Empty;
            this.selecteCustomerId = dgvData.CurrentRow.Cells[dgvData.ColumnCount - 2]?.Value?.ToString() ?? string.Empty;

            //CustomerGroup
            this.selectedCustomerGroupName = dgvData.CurrentRow.Cells[6]?.Value?.ToString() ?? string.Empty;
            this.selectedCustomerGroupId = dgvData.CurrentRow.Cells[dgvData.ColumnCount - 2]?.Value?.ToString() ?? string.Empty;

            this.DialogResult = DialogResult.OK;
        }
        #endregion END PRIVATE FUNCTION
        static bool IsSupportsTransparency(Control control)
        {
            // Check if the control type is known to support transparency
            Type[] transparentControlTypes = { typeof(Panel), typeof(GroupBox), typeof(Label) };

            foreach (Type transparentType in transparentControlTypes)
            {
                if (transparentType.IsAssignableFrom(control.GetType()))
                {
                    return true;
                }
            }

            return false;
        }
    }

}