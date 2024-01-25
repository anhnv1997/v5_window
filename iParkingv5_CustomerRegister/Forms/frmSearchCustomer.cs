using IPaking.Ultility;
using iPakrkingv5.Controls.Controls.Buttons;
using iPakrkingv5.Controls.Usercontrols.BuildControls;
using iParkingv6.ApiManager.KzParkingv3Apis;
using iParkingv6.Objects.Datas;
using System.Runtime.InteropServices;

namespace iParkingv5_CustomerRegister.Forms
{
    public partial class frmSearchCustomer : Form
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;
        #region PROPERTIES
        public string SelectCustomerName
        {
            get;
            set;
        } = string.Empty;
        public string SelectCustomerCode
        {
            get;
            set;
        } = string.Empty;

        public string SelectCustomerId { get; set; } = string.Empty;
        public string SelectCustomerGroup { get; set; } = string.Empty;
        public string SelectCustomerGroupId { get; set; } = string.Empty;
        #endregion END PROPERTIES

        #region FORMS
        public frmSearchCustomer()
        {
            InitializeComponent();
            this.Load += FrmSelectCustomer_Load;
            dgvData.CellDoubleClick += DgvCard_CellDoubleClick;
        }
        private void FrmSelectCustomer_Load(object? sender, EventArgs e)
        {
            this.Font = panelData.Font = new Font(this.Font.Name, TextManagement.ROOT_SIZE);
            lblTittle.Font = new Font(this.Font.Name,  TextManagement.ROOT_SIZE * 2, FontStyle.Bold);

            lblSearch.Init(BtnSearch_Click);
            btnOk1.Init(BtnOk1_Click);
            btnCancel1.Init(BtnCancel1_Click);

            lblTittle.Location = new Point( TextManagement.ROOT_SIZE * 2,  TextManagement.ROOT_SIZE * 2);
            lblCustomer.Location = new Point(lblTittle.Location.X, lblTittle.Location.Y + lblTittle.Height +  TextManagement.ROOT_SIZE);

            txtCustomerCode.Location = new Point(lblCustomer.Location.X + lblCustomer.Width +  TextManagement.ROOT_SIZE,
                                            lblCustomer.Location.Y + (lblCustomer.Height - txtCustomerCode.Height) / 2);
            lblSearch.Location = new Point(txtCustomerCode.Location.X + txtCustomerCode.Width +  TextManagement.ROOT_SIZE,
                                           txtCustomerCode.Location.Y + (txtCustomerCode.Height - lblSearch.Height) / 2);

            btnCancel1.Location = new Point(panelData.Width - btnCancel1.Width -  TextManagement.ROOT_SIZE * 2,
                                           panelData.Height - btnCancel1.Height -  TextManagement.ROOT_SIZE * 2);
            btnOk1.Location = new Point(btnCancel1.Location.X - btnOk1.Width -  TextManagement.ROOT_SIZE, btnCancel1.Location.Y);
            dgvData.Location = new Point(lblTittle.Location.X, lblSearch.Location.Y + lblSearch.Height +  TextManagement.ROOT_SIZE);
            dgvData.Width = panelData.Width -  TextManagement.ROOT_SIZE * 4;
            dgvData.Height = btnCancel1.Location.Y -  TextManagement.ROOT_SIZE - dgvData.Location.Y;
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
            ucLoading1.Show("Đang tải thông tin khách hàng", TextManagement.ROOT_LANGUAGE);
            panelData.ResumeLayout();
            dgvData.Rows.Clear();
            dgvData.Refresh();

            SendMessage(dgvData.Handle, WM_SETREDRAW, false, 0);
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                var getCustomerRespose = await KzParkingApiHelper.GetCustomerByCode(txtCustomerCode.Text);
                if (getCustomerRespose.Item1 != null)
                {
                    List<Customer> customers = getCustomerRespose.Item1;
                    if (customers != null)
                    {
                        for (int i = 0; i < customers.Count; i++)
                        {
                            dgvData.Rows.Add(i + 1, customers[i].name, customers[i].code, customers[i].customerGroup, customers[i].phoneNumber, customers[i].address, customers[i].customerGroupId, customers[i].id);
                            customers[i] = null;
                        }
                        customers.Clear();
                        GC.Collect();
                    }
                }
                else
                {
                    ucLoading1.HideLoading();
                    ucNotify1.Show(ucNotify.EmNotiType.Error, getCustomerRespose.Item2);
                    ucNotify1.OnSelectResultEvent += UcNotify1_OnSelectResultEvent;
                    return;
                }
            }
            else
            {
                var getCustomerRespose = await KzParkingApiHelper.GetAllCustomers();
                if (getCustomerRespose.Item1 != null)
                {
                    List<Customer> customers = getCustomerRespose.Item1;
                    if (customers != null)
                    {
                        for (int i = 0; i < customers.Count; i++)
                        {
                            dgvData.Rows.Add(i + 1, customers[i].name, customers[i].code, customers[i].customerGroup, customers[i].phoneNumber, customers[i].address, customers[i].customerGroupId, customers[i].id);
                            customers[i] = null;
                        }
                        customers.Clear();
                        GC.Collect();
                    }
                }
                else
                {
                    ucLoading1.HideLoading();
                    ucNotify1.Show(ucNotify.EmNotiType.Error, getCustomerRespose.Item2);
                    ucNotify1.OnSelectResultEvent += UcNotify1_OnSelectResultEvent;
                    return;
                }
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
            this.SelectCustomerName = dgvData.CurrentRow.Cells[1]?.Value?.ToString() ?? string.Empty;
            this.SelectCustomerCode = dgvData.CurrentRow.Cells[2]?.Value?.ToString() ?? string.Empty;
            this.SelectCustomerId = dgvData.CurrentRow.Cells[dgvData.ColumnCount - 1]?.Value?.ToString() ?? string.Empty;
            this.SelectCustomerGroupId = dgvData.CurrentRow.Cells[dgvData.ColumnCount - 2]?.Value?.ToString() ?? string.Empty;
            this.SelectCustomerGroup = dgvData.CurrentRow.Cells[3]?.Value?.ToString() ?? string.Empty;
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
