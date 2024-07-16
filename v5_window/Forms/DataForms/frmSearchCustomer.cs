using IPaking.Ultility;
using iPakrkingv5.Controls.Controls.Buttons;
using System.Runtime.InteropServices;
using iPakrkingv5.Controls;
using iParkingv5.Objects.Datas.parking_service;
using iParkingv5_window.Usercontrols.BuildControls;

namespace iParkingv5_window.Forms.DataForms
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

        BtnSearch lblSearch;
        LblCancel btnCancel1;
        ucLoading ucLoading1;
        ucNotify ucNotify1;
        BtnOk btnOk1;
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

            lblSearch = new BtnSearch();
            btnCancel1 = new LblCancel();
            ucLoading1 = new ucLoading();
            ucNotify1 = new ucNotify();
            btnOk1 = new BtnOk();

            panelData.Controls.Add(lblSearch);
            panelData.Controls.Add(btnCancel1);
            panelData.Controls.Add(ucLoading1);
            panelData.Controls.Add(ucNotify1);
            panelData.Controls.Add(btnOk1);

            lblTittle.Font = new Font(this.Font.Name, TextManagement.ROOT_SIZE * 2, FontStyle.Bold);
            panelData.ToggleDoubleBuffered(true);

            lblSearch.InitControl(BtnSearch_Click);
            btnOk1.InitControl(BtnOk1_Click);
            btnCancel1.InitControl(BtnCancel1_Click);

            lblTittle.Location = new Point(TextManagement.ROOT_SIZE * 2, TextManagement.ROOT_SIZE * 2);
            lblCustomer.Location = new Point(lblTittle.Location.X, lblTittle.Location.Y + lblTittle.Height + TextManagement.ROOT_SIZE);

            txtCustomerCode.Location = new Point(lblCustomer.Location.X + lblCustomer.Width + TextManagement.ROOT_SIZE,
                                            lblCustomer.Location.Y + (lblCustomer.Height - txtCustomerCode.Height) / 2);
            lblSearch.Location = new Point(txtCustomerCode.Location.X + txtCustomerCode.Width + TextManagement.ROOT_SIZE,
                                           txtCustomerCode.Location.Y + (txtCustomerCode.Height - lblSearch.Height) / 2);

            btnCancel1.Location = new Point(panelData.Width - btnCancel1.Width - TextManagement.ROOT_SIZE * 2,
                                           panelData.Height - btnCancel1.Height - TextManagement.ROOT_SIZE * 2);
            btnOk1.Location = new Point(btnCancel1.Location.X - btnOk1.Width - TextManagement.ROOT_SIZE, btnCancel1.Location.Y);
            dgvData.Location = new Point(lblTittle.Location.X, lblSearch.Location.Y + lblSearch.Height + TextManagement.ROOT_SIZE);
            dgvData.Width = panelData.Width - TextManagement.ROOT_SIZE * 4;
            dgvData.Height = btnCancel1.Location.Y - TextManagement.ROOT_SIZE - dgvData.Location.Y;
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
            ucLoading1.Show("Đang tải thông tin khách hàng", TextManagement.ROOT_LANGUAGE);
            panelData.ResumeLayout();
            dgvData.Rows.Clear();
            dgvData.Refresh();

            SendMessage(dgvData.Handle, WM_SETREDRAW, false, 0);
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                var getCustomerRespose = await  AppData.ApiServer.parkingDataService.GetCustomersAsync(txtCustomerCode.Text);
                if (getCustomerRespose.Item1 != null)
                {
                    List<Customer> customers = getCustomerRespose.Item1;
                    if (customers != null)
                    {
                        for (int i = 0; i < customers.Count; i++)
                        {
                            dgvData.Rows.Add(i + 1, customers[i].Name, customers[i].Code, customers[i].CustomerGroupName, customers[i].PhoneNumber, customers[i].Address, customers[i].CustomerGroupId, customers[i].Id);
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
                var getCustomerRespose = await  AppData.ApiServer.parkingDataService.GetCustomersAsync();
                if (getCustomerRespose.Item1 != null)
                {
                    List<Customer> customers = getCustomerRespose.Item1;
                    if (customers != null)
                    {
                        for (int i = 0; i < customers.Count; i++)
                        {
                            dgvData.Rows.Add(i + 1, customers[i].Name, customers[i].Code, customers[i].CustomerGroupName, customers[i].PhoneNumber, customers[i].Address, customers[i].CustomerGroupId, customers[i].Id);
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
            panelData.SuspendLayout();
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
            panelData.ResumeLayout();
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
    }
}
