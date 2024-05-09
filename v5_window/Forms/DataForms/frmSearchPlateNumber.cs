using IPaking.Ultility;
using iPakrkingv5.Controls.Controls.Buttons;
using iPakrkingv5.Controls.Usercontrols.BuildControls;
using iParkingv5.Objects;
using iParkingv5.Objects.Enums;
using iParkingv6.ApiManager.KzParkingv3Apis;
using iParkingv6.Objects.Datas;
using System.Runtime.InteropServices;
using iPakrkingv5.Controls;
using iParkingv5.ApiManager.KzParkingv5Apis;

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

        public DateTime? ExpireTime { get; set; } = null;
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
            this.Font = new Font(this.Font.Name, StaticPool.baseSize);
            lblTitle.Font = new Font(this.Font.Name, StaticPool.baseSize * 2, FontStyle.Bold);
            panelData.ToggleDoubleBuffered(true);

            btnSearch.InitControl(BtnSearch_Click);
            btnOk1.InitControl(BtnOk1_Click);
            btnCancel1.InitControl(BtnCancel1_Click);

            lblTitle.Location = new Point(StaticPool.baseSize * 2, StaticPool.baseSize * 2);
            lblKeyword.Location = new Point(lblTitle.Location.X, lblTitle.Location.Y + lblTitle.Height + StaticPool.baseSize);

            txtKeyword.Location = new Point(lblKeyword.Location.X + lblKeyword.Width + StaticPool.baseSize,
                                            lblKeyword.Location.Y + (lblKeyword.Height - txtKeyword.Height) / 2);
            btnSearch.Location = new Point(txtKeyword.Location.X + txtKeyword.Width + StaticPool.baseSize,
                                           txtKeyword.Location.Y + (txtKeyword.Height - btnSearch.Height) / 2);

            btnCancel1.Location = new Point(panelData.Width - btnCancel1.Width - StaticPool.baseSize * 2,
                                           panelData.Height - btnCancel1.Height - StaticPool.baseSize * 2);
            btnOk1.Location = new Point(btnCancel1.Location.X - btnOk1.Width - StaticPool.baseSize, btnCancel1.Location.Y);
            dgvData.Location = new Point(lblTitle.Location.X, btnSearch.Location.Y + btnSearch.Height + StaticPool.baseSize);
            dgvData.Width = panelData.Width - StaticPool.baseSize * 4;
            dgvData.Height = btnCancel1.Location.Y - StaticPool.baseSize - dgvData.Location.Y;
            ucNotify1.OnSelectResultEvent += UcNotify1_OnSelectResultEvent;

            btnSearch.PerformClick();
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
                else if (item is IDesignControl)
                {
                    ((IDesignControl)item).EnableWaitMode();
                }
                else if (!item.IsSupportsTransparency())
                {
                    item.Enabled = false;
                    continue;
                }
            }
            ucLoading1.Show("Đang tải thông tin phương tiện", TextManagement.ROOT_LANGUAGE);
            panelData.ResumeLayout();
            dgvData.Rows.Clear();
            dgvData.Refresh();

            SendMessage(dgvData.Handle, WM_SETREDRAW, false, 0);
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            //var registerVehicles = await KzParkingApiHelper.GetRegisteredVehicles(txtKeyword.Text);
            var registerVehicles = (await KzParkingv5ApiHelper.GetRegisterVehiclesAsync(txtKeyword.Text)).Item1;
            //var customers = await KzParkingApiHelper.GetAllCustomers();
            var customers = (await KzParkingv5ApiHelper.GetCustomersAsync()).Item1;
            //var vehicleTypes = await KzParkingApiHelper.GetAllVehicleTypes();
            var vehicleTypes = (await KzParkingv5ApiHelper.GetVehicleTypesAsync()).Item1;
            if (registerVehicles != null)
            {
                if (registerVehicles != null)
                {
                    for (int i = 0; i < registerVehicles.Count; i++)
                    {
                        string vehicleId = registerVehicles[i].Id;
                        string vehicleTypeId = registerVehicles[i].VehicleTypeId.ToString();
                        string customerID = registerVehicles[i].CustomerId;

                        Customer.GetCustomerName(customers, customerID, out string customerName, out string customerCode,
                                                                              out string customerGroupId, out string customerGroupName);
                        dgvData.Rows.Add(i + 1, registerVehicles[i].Name,
                                                registerVehicles[i].PlateNumber,
                                                VehicleType.GetVehicleTypeName(vehicleTypes, registerVehicles[i].VehicleTypeId),
                                                customerName,
                                                customerCode,
                                                customerGroupName,
                                                registerVehicles[i].ExpireTime?.ToString("dd/MM/yyyy HH:mm:ss"),
                                                vehicleId,
                                                vehicleTypeId,
                                                customerID,
                                                customerGroupId);
                        registerVehicles[i] = null;
                    }
                    registerVehicles.Clear();
                    customers?.Clear();
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
                ChooseVehicle();
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
                ChooseVehicle();
            }
        }
        #endregion END CONTROLS IN FORM

        #region PRIVATE FUNCTION
        private void ChooseVehicle()
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


            //ExpireTime
            string expireTimeStr = dgvData.CurrentRow.Cells[7]?.Value?.ToString() ?? string.Empty;
            try
            {
                this.ExpireTime = DateTime.ParseExact(expireTimeStr, "dd/MM/yyyy HH:mm:ss", null).AddHours(7);

            }
            catch (Exception)
            {
                this.ExpireTime = null;
            }

            this.DialogResult = DialogResult.OK;
        }
        #endregion END PRIVATE FUNCTION
    }
}