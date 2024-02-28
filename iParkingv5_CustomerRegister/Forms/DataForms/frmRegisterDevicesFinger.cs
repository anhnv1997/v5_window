using IPaking.Ultility;
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
    public partial class frmRegisterDevicesFinger : Form
    {
        #region Properties
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;
        List<string> selectedControllerIds = new List<string>();
        List<Tuple<string, string>> selectedCustomers = new List<Tuple<string, string>>();

        private bool isSelectAll = false;
        private bool IsSelectAll
        {
            get => isSelectAll;
            set
            {
                isSelectAll = value;
                for (int i = 0; i < chlbDevices.Items.Count; i++)
                {
                    chlbDevices.SetItemChecked(i, value);
                }
            }
        }
        #endregion End Properties

        #region Forms
        public frmRegisterDevicesFinger()
        {
            InitializeComponent();
            this.Load += FrmDevices_Load;
        }
        private async void FrmDevices_Load(object? sender, EventArgs e)
        {
            CreateUI();
        }


        private void ChbSelectAllDevice_CheckedChanged(object? sender, EventArgs e)
        {
            IsSelectAll = !IsSelectAll;
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
                            dgvCustomerData.Rows.Add(i + 1, customers[i].Name, customers[i].Code, customers[i].CustomerGroupName, customers[i].PhoneNumber, customers[i].Address, customers[i].CustomerGroupId, customers[i].Id);
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
                            dgvCustomerData.Rows.Add(i + 1, customers[i].Name, customers[i].Code, customers[i].CustomerGroupName, customers[i].PhoneNumber, customers[i].Address, customers[i].CustomerGroupId, customers[i].Id);
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
            this.selectedCustomers = new List<Tuple<string, string>>();
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
                string customerName = row.Cells[1].Value.ToString() ?? "";
                selectedCustomers.Add(Tuple.Create<string, string>(customerId, customerName));
            }
            await DownloadFinger(this.selectedControllerIds, this.selectedCustomers);
        }
        #endregion End Controls In Form

        #region Private Function
        private void CreateUI()
        {
            this.WindowState = FormWindowState.Maximized;
            lblSearch1.InitControl(BtnSearch_Click);
            lblOk1.InitControl(btnRegister_Click);

            lblDeviceListTitle.Font = lblCustomerListTitle.Font = new Font(this.Font.Name, TextManagement.ROOT_SIZE, FontStyle.Bold);
            lblDeviceListTitle.Location = new Point(TextManagement.ROOT_SIZE * 2, TextManagement.ROOT_SIZE * 2);

            chbSelectAllDevice.Location = new Point(lblDeviceListTitle.Location.X, lblDeviceListTitle.Location.Y + lblDeviceListTitle.Height + (int)(StaticPool.baseSize * 1.5));
            chlbDevices.Location = new Point(lblDeviceListTitle.Location.X, chbSelectAllDevice.Location.Y + chbSelectAllDevice.Height + TextManagement.ROOT_SIZE);

            lblCustomerListTitle.Location = new Point(chlbDevices.Location.X + chlbDevices.Width + TextManagement.ROOT_SIZE, lblDeviceListTitle.Location.Y);
            txtCustomerCode.Location = new Point(lblCustomerListTitle.Location.X, chbSelectAllDevice.Location.Y);
            lblSearch1.Location = new Point(txtCustomerCode.Location.X + txtCustomerCode.Width + TextManagement.ROOT_SIZE,
                                            txtCustomerCode.Location.Y + (txtCustomerCode.Height - lblSearch1.Height) / 2);
            dgvCustomerData.Location = new Point(lblCustomerListTitle.Location.X, chlbDevices.Location.Y);


            lblOk1.Location = new Point(this.DisplayRectangle.Width - TextManagement.ROOT_SIZE - lblOk1.Width,
                                        this.DisplayRectangle.Height - lblOk1.Height - TextManagement.ROOT_SIZE);

            chlbDevices.Height = lblOk1.Location.Y - chlbDevices.Location.Y - TextManagement.ROOT_SIZE;
            dgvCustomerData.Width = this.DisplayRectangle.Width - dgvCustomerData.Location.X - TextManagement.ROOT_SIZE;

            chlbDevices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgvCustomerData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;


            //BtnSearch_Click(null, null);
            foreach (var bdk in StaticPool.bdks)
            {
                ListItem item = new ListItem()
                {
                    Name = bdk.Name,
                    Value = bdk.Id
                };
                chlbDevices.Items.Add(item);
            }
            chlbDevices.DisplayMember = "Name";
            chlbDevices.ValueMember = "Value";
            chlbDevices.CheckOnClick = true;

            dgvCustomerData.MultiSelect = true;

            chbSelectAllDevice.CheckedChanged += ChbSelectAllDevice_CheckedChanged;
            this.SizeChanged += FrmDevices_SizeChanged;
        }

        private void FrmDevices_SizeChanged(object? sender, EventArgs e)
        {
        }

        private async Task DownloadFinger(List<string> controllerIds, List<Tuple<string, string>> customers)
        {
            //Lấy danh sách bộ điều khiển
            List<IController> controllers = new List<IController>();
            foreach (var item in frmMain.controllers)
            {
                if (controllerIds.Contains(item.ControllerInfo.Id))
                {
                    controllers.Add(item);
                }
            }
            //Ten khách hàng , Tên BĐK, Kết Quả
            List<Tuple<string, string, string>> results = new List<Tuple<string, string, string>>();
            //Lấy danh sách vân tay
            foreach (Tuple<string, string> customer in customers)
            {
                List<string> downloadFingers = new List<string>();
                List<string> registedFingers = (await tblFingerCustomer.GetRegisterFingersByCustomerId(customer.Item1)).Item1;
                List<Tuple<string, string>> fingerDatas = await tblFingerprint.GetFingerDatas(registedFingers);
                foreach (var item in fingerDatas)
                {
                    downloadFingers.Add(item.Item2);
                }
                registedFingers.Clear();
                fingerDatas.Clear();

                //Hủy đăng ký vân tay nếu có thông tin đăng ký cũ
                //Bỏ qua nếu chưa đăng ký
                if (downloadFingers.Count == 0)
                {
                    for (int i = 0; i < controllers.Count; i++)
                    {
                        string controllerId = controllers[i].ControllerInfo.Id;
                        int userId = tblFingerControlUnit.GetControlUnitUserId(customer.Item1, controllerId, out bool valid);
                        if (!valid)
                        {
                            results.Add(Tuple.Create<string, string, string>(customer.Item2, controllers[i].ControllerInfo.Name, "Chưa đăng ký vân tay"));
                        }
                        else
                        {
                            bool isSuccess = await controllers[i].DeleteFinger(userId.ToString(), 0);
                            if (isSuccess)
                            {
                                results.Add(Tuple.Create<string, string, string>(customer.Item2, controllers[i].ControllerInfo.Name, "Hủy thông tin vân tay thành công"));
                                tblFingerControlUnit.Delete(customer.Item1, controllerId);
                            }
                            else
                            {
                                results.Add(Tuple.Create<string, string, string>(customer.Item2, controllers[i].ControllerInfo.Name, "Hủy thông tin vân tay lỗi"));
                            }
                        }
                    }
                }
                //Đăng ký thông tin vân tay mới hoặc cập nhật
                else
                {
                    for (int i = 0; i < controllers.Count; i++)
                    {
                        string controllerId = controllers[i].ControllerInfo.Id;
                        int userId = tblFingerControlUnit.GetControlUnitUserId(customer.Item1, controllerId, out bool valid);
                        bool isSuccess = await controllers[i].AddFinger(downloadFingers, customer.Item2, userId);
                        if (isSuccess)
                        {
                            tblFingerControlUnit.Insert(controllers[i].ControllerInfo.Id, userId, customer.Item1);
                            results.Add(Tuple.Create<string, string, string>(customer.Item2, controllers[i].ControllerInfo.Name, "Đăng ký thông tin vân tay thành công"));
                        }
                        else
                        {
                            results.Add(Tuple.Create<string, string, string>(customer.Item2, controllers[i].ControllerInfo.Name, "Đăng ký thông tin vân tay lỗi"));
                        }
                    }
                }

            }
            new frmShowResult(results).Show(this);
        }
        #endregion End Private Function

        #region Public Function
        #endregion End Public Function
    }
}
