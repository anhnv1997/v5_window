using iParkingv5_window.Controls.Buttons;
using iParkingv5_window.Usercontrols.BuildControls;
using iParkingv6.ApiManager.KzParkingv3Apis;
using iParkingv6.Objects.Datas;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iParkingv5_window.Forms.DataForms
{
    public partial class frmSelectCustomer : Form
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
        Point position = new Point(0);
        #endregion END PROPERTIES

        #region FORMS
        public frmSelectCustomer(string title)
        {
            InitializeComponent();
            this.Text = title;
            this.Load += FrmSelectCard_Load;
            dgvData.CellDoubleClick += DgvCard_CellDoubleClick;
        }

        private void FrmSelectCard_Load(object? sender, EventArgs e)
        {
            btnOk1.Init(BtnOk1_Click);
            btnCancel1.Init(BtnCancel1_Click);
            lblSearch.Init(BtnSearch_Click);

            btnCancel1.Location = new Point(this.Width - btnCancel1.Width - 20,
                                            this.Height - btnCancel1.Height - 50 - 10);

            btnOk1.Location = new Point(btnCancel1.Location.X - btnOk1.Width - 10,
                                        btnCancel1.Location.Y);

            lblSearch.Location = new Point(txtCustomerCode.Location.X + txtCustomerCode.Width + 20,
                                           txtCustomerCode.Location.Y + (txtCustomerCode.Height - lblSearch.Height) / 2);

            dgvData.Location = new Point(3, lblSearch.Location.Y + lblSearch.Height + 20);
            dgvData.Size = new Size(dgvData.Width, btnOk1.Location.Y - lblSearch.Location.Y - lblSearch.Height - 30);
            this.Location = this.position;
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
            ucLoading1.Show("Đang tải thông tin khách hàng", frmMain.language);
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
                            dgvData.Rows.Add(i + 1, customers[i].name, customers[i].code, customers[i].customerGroup, customers[i].phoneNumber.ToString(), customers[i].address, customers[i].customerGroupId, customers[i].id);
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
                            dgvData.Rows.Add(i + 1, customers[i].name, customers[i].code, customers[i].customerGroup, customers[i].phoneNumber.ToString(), customers[i].address, customers[i].customerGroupId, customers[i].id);
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
