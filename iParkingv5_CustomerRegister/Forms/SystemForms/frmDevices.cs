using iParkingv5.Controller;
using iParkingv5.Objects;
using iParkingv5.Objects.Databases;
using iParkingv5_CustomerRegister.Databases;
using iParkingv6.ApiManager.KzParkingv3Apis;
using iParkingv6.Objects.Datas;
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

namespace iParkingv5_CustomerRegister.Forms.SystemForms
{
    public partial class frmDevices : Form
    {
        #region Properties
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;
        List<string> selectedControllerIds = new List<string>();
        List<string> selectedCustomerIds = new List<string>();
        #endregion End Properties

        #region Forms
        public frmDevices()
        {
            InitializeComponent();
            this.Load += FrmDevices_Load;
        }
        private async void FrmDevices_Load(object? sender, EventArgs e)
        {
            btnSearchCustomer.PerformClick();
            foreach (var bdk in StaticPool.bdks)
            {
                ListItem item = new ListItem()
                {
                    Name = bdk.name,
                    Value = bdk.id
                };
                chlbDevices.Items.Add(item);
            }
            chlbDevices.DisplayMember = "Name";
            chlbDevices.ValueMember = "Value";
            chlbDevices.CheckOnClick = true;

            dgvCustomerData.MultiSelect = true;
        }
        #endregion End Forms

        #region Controls In Form
        private async void BtnSearch_Click(object? sender, EventArgs e)
        {
            dgvCustomerData.Rows.Clear();
            dgvCustomerData.Refresh();

            SendMessage(dgvCustomerData.Handle, WM_SETREDRAW, false, 0);
            dgvCustomerData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvCustomerData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

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
                            dgvCustomerData.Rows.Add(i + 1, customers[i].name, customers[i].code, customers[i].customerGroup, customers[i].phoneNumber, customers[i].address, customers[i].customerGroupId, customers[i].id);
                            customers[i] = null;
                        }
                        customers.Clear();
                        GC.Collect();
                    }
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
                            dgvCustomerData.Rows.Add(i + 1, customers[i].name, customers[i].code, customers[i].customerGroup, customers[i].phoneNumber, customers[i].address, customers[i].customerGroupId, customers[i].id);
                            customers[i] = null;
                        }
                        customers.Clear();
                        GC.Collect();
                    }
                }
            }

            if (dgvCustomerData.Rows.Count > 0)
            {
                dgvCustomerData.CurrentCell = dgvCustomerData.Rows[0].Cells[0];
            }

            dgvCustomerData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvCustomerData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            SendMessage(dgvCustomerData.Handle, WM_SETREDRAW, true, 0);
            dgvCustomerData.Refresh();
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            this.selectedControllerIds = new List<string>();
            this.selectedCustomerIds = new List<string>();
            foreach (var item in chlbDevices.CheckedItems)
            {
                var temp = item as ListItem;
                if (temp != null)
                {
                    this.selectedControllerIds.Add(temp.Value);
                }
            }
            if (this.selectedControllerIds.Count == 0)
            {
                MessageBox.Show("Hãy chọn thiết bị cần đăng ký vân tay", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dgvCustomerData.SelectedRows.Count == 0)
            {
                MessageBox.Show("Hãy chọn khách hàng cần đăng ký vân tay", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            foreach (DataGridViewRow row in dgvCustomerData.SelectedRows)
            {
                string customerId = row.Cells[dgvCustomerData.ColumnCount - 1].Value.ToString() ?? "";
                selectedCustomerIds.Add(customerId);
            }
            await DownloadFinger(this.selectedControllerIds, this.selectedCustomerIds);
        }
        #endregion End Controls In Form

        #region Private Function
        private async Task DownloadFinger(List<string> controllerIds, List<string> customerIds)
        {
            //Lấy danh sách bộ điều khiển
            List<IController> controllers = new List<IController>();
            foreach (var item in frmMain.controllers)
            {
                if (controllerIds.Contains(item.ControllerInfo.id))
                {
                    controllers.Add(item);
                }
            }

            List<string> results = new List<string>();
            //Lấy danh sách vân tay
            foreach (string customerID in customerIds)
            {
                List<string> downloadFingers = new List<string>();
                List<string> registedFingers = await tblFingerCustomer.GetFingerIdsByCustomerId(customerID);
                List<Tuple<string, string>> fingerDatas = await tblFingerprint.GetFingerDatas(registedFingers);
                foreach (var item in fingerDatas)
                {
                    downloadFingers.Add(item.Item2);
                }
                registedFingers.Clear();
                fingerDatas.Clear();
                if (downloadFingers.Count == 0)
                {
                    results.Add(customerID + "- Chưa đăng ký vân tay");
                    continue;
                }

                //Đọc thông tin UserId
                //Đăng ký người dùng dựa trên thông tin userId
            }
        }
        #endregion End Private Function

        #region Public Function

        #endregion End Public Function
    }
}
