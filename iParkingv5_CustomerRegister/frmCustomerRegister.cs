
using DahuaLib.DahuaFuntion;
using IPaking.Ultility;
using iParkingv5_CustomerRegister.Databases;
using iParkingv5_CustomerRegister.Forms;
using iParkingv5_CustomerRegister.UserControls;
using iParkingv6.ApiManager.KzParkingv3Apis;
using iParkingv6.Objects.Datas;

namespace iParkingv5_CustomerRegister
{
    public partial class frmCustomerRegister : Form
    {
        #region Properties
        private int baseSize = 16;

        string vehicleId = string.Empty;
        string vehicleTypeId = string.Empty;
        string customerID = string.Empty;
        string customerGroupID = string.Empty;
        #endregion End Properties

        #region Forms
        public frmCustomerRegister()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            btnSearchCustomer.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            btnSearchPlateNumber.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.TopMost = true;
            this.Load += Form1_Load;
            this.TopMost = false;
        }
        private void Form1_Load(object? sender, EventArgs e)
        {
            this.Text = "Đăng ký thông tin khách hàng";
            dtpExpireTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            lblTitle.Location = new Point(this.baseSize * 2, this.baseSize * 2);
            lblSubTitle.Location = new Point(lblTitle.Location.X, lblTitle.Location.Y + lblTitle.Height + this.baseSize);

            lblCustomerName.Location = new Point(lblTitle.Location.X, lblSubTitle.Location.Y + lblSubTitle.Height + this.baseSize * 2);
            txtCustomerName.Location = new Point((int)(lblCustomerName.Location.X + lblCustomerName.Width + this.baseSize * 2), lblCustomerName.Location.Y + (lblCustomerName.Height - txtCustomerName.Height) / 2);
            btnSearchCustomer.Location = new Point(txtCustomerName.Location.X + txtCustomerName.Width + this.baseSize, txtCustomerName.Location.Y);

            txtCustomerCode.Location = new Point(txtCustomerName.Location.X, txtCustomerName.Location.Y + txtCustomerName.Height + this.baseSize);
            txtCustomerCode.Width = btnSearchCustomer.Location.X + btnSearchCustomer.Width - txtCustomerCode.Location.X;
            lblCustomerCode.Location = new Point(lblCustomerName.Location.X, txtCustomerCode.Location.Y + (txtCustomerCode.Height - lblCustomerCode.Height) / 2);

            btnChooseCustomerGroup.Location = new Point(txtCustomerCode.Location.X, txtCustomerCode.Location.Y + txtCustomerCode.Height + this.baseSize);
            btnChooseCustomerGroup.Width = txtCustomerCode.Width;
            lblCustomerGroup.Location = new Point(lblCustomerName.Location.X, btnChooseCustomerGroup.Location.Y + (btnChooseCustomerGroup.Height - lblCustomerGroup.Height) / 2);

            txtPlateNumber.Location = new Point(txtCustomerCode.Location.X, btnChooseCustomerGroup.Location.Y + btnChooseCustomerGroup.Height + this.baseSize);
            txtPlateNumber.Width = txtCustomerName.Width;
            btnSearchPlateNumber.Location = new Point(btnSearchCustomer.Location.X, txtPlateNumber.Location.Y);
            lblPlateNumber.Location = new Point(lblCustomerName.Location.X, txtPlateNumber.Location.Y + (txtPlateNumber.Height - lblPlateNumber.Height) / 2);

            btnChooseVehicleType.Location = new Point(txtCustomerCode.Location.X, txtPlateNumber.Location.Y + txtPlateNumber.Height + this.baseSize);
            btnChooseVehicleType.Width = btnChooseCustomerGroup.Width;
            lblVehicleType.Location = new Point(lblCustomerName.Location.X, btnChooseVehicleType.Location.Y + (btnChooseVehicleType.Height - lblVehicleType.Height) / 2);

            dtpExpireTime.Location = new Point(btnChooseVehicleType.Location.X, btnChooseVehicleType.Location.Y + btnChooseVehicleType.Height + this.baseSize);
            dtpExpireTime.Width = btnChooseVehicleType.Width;
            lblExpireTime.Location = new Point(lblCustomerName.Location.X, dtpExpireTime.Location.Y + (dtpExpireTime.Height - lblExpireTime.Height) / 2);

            txtCustomerName.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnSearchCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtCustomerCode.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnChooseCustomerGroup.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtPlateNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnSearchPlateNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnChooseVehicleType.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            dtpExpireTime.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            btnAdd.Location = new Point(dtpExpireTime.Location.X + (dtpExpireTime.Width - btnAdd.Width), dtpExpireTime.Location.Y + dtpExpireTime.Height + this.baseSize);
            btnUpdate.Location = new Point(btnAdd.Location.X - btnUpdate.Width - TextManagement.ROOT_SIZE, btnAdd.Location.Y);

            this.Height = btnAdd.Location.Y + btnAdd.Height + this.baseSize * 2 + this.Height - this.DisplayRectangle.Height;
            this.Width = btnSearchCustomer.Location.X + btnSearchCustomer.Width + this.baseSize * 2;

            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSearchCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearchPlateNumber.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtCustomerName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCustomerCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnChooseCustomerGroup.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPlateNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnChooseVehicleType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpExpireTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            if (Properties.Settings.Default.preferWidth > 0 && Properties.Settings.Default.preferHeight > 0)
            {
                this.Size = new Size(Properties.Settings.Default.preferWidth, Properties.Settings.Default.preferHeight);
            }

            toolTip1.SetToolTip(txtCustomerName, "Tên khách hàng, dùng để đăng ký lên hệ thống.");
            toolTip1.SetToolTip(btnSearchCustomer, "Bấm để tìm kiếm khách hàng theo thông tin đã nhập.");
            toolTip1.SetToolTip(txtCustomerCode, "Mã khách hàng, dùng để phân biệt giữa các khách hàng.");
            toolTip1.SetToolTip(btnChooseCustomerGroup, "Bấm để chọn nhóm khách hàng.");
            toolTip1.SetToolTip(txtPlateNumber, "Biển số xe, dùng để đăng ký lên hệ thống.");
            toolTip1.SetToolTip(btnSearchPlateNumber, "Bấm để tìm kiếm biển số xe theo thông tin đã nhập.");
            toolTip1.SetToolTip(btnChooseVehicleType, "Bấm để chọn loại phương tiện.");
            toolTip1.SetToolTip(btnAdd, "Bấm để lưu thông tin lên hệ thống.");

            btnSearchCustomer.Click += BtnSearchCustomer_Click;
            btnSearchCustomer.MouseEnter += BtnSearchCustomer_MouseEnter;
            btnSearchCustomer.MouseLeave += BtnSearchCustomer_MouseLeave;

            btnChooseCustomerGroup.Click += BtnChooseCustomerGroup_Click;
            btnChooseCustomerGroup.MouseEnter += BtnChooseCustomerGroup_MouseEnter;
            btnChooseCustomerGroup.MouseLeave += BtnChooseCustomerGroup_MouseLeave;

            btnSearchPlateNumber.Click += BtnSearchPlateNumber_Click;
            btnSearchPlateNumber.MouseEnter += BtnSearchPlateNumber_MouseEnter;
            btnSearchPlateNumber.MouseLeave += BtnSearchPlateNumber_MouseLeave;

            btnChooseVehicleType.Click += BtnChooseVehicleType_Click;
            btnChooseVehicleType.MouseEnter += BtnChooseVehicleType_MouseEnter;
            btnChooseVehicleType.MouseLeave += BtnChooseVehicleType_MouseLeave;

            btnAdd.Click += BtnConfirm_Click;
            btnAdd.MouseEnter += BtnConfirm_MouseEnter;
            btnAdd.MouseLeave += BtnConfirm_MouseLeave;

            btnUpdate.Click += BtnUpdate_Click;
            btnUpdate.MouseEnter += BtnUpdate_MouseEnter;
            btnUpdate.MouseLeave += BtnUpdate_MouseLeave;

            this.ResizeEnd += Form1_ResizeEnd;
        }
        private void Form1_ResizeEnd(object? sender, EventArgs e)
        {
            Properties.Settings.Default.preferHeight = this.Height;
            Properties.Settings.Default.preferWidth = this.Width;
            Properties.Settings.Default.Save();
        }
        #endregion End Forms

        #region Controls In Form
        private void BtnSearchCustomer_MouseLeave(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            btnSearchCustomer.ForeColor = Color.Black;
            btnSearchCustomer.Image = Properties.Resources.search_0_0_0_24px;
        }
        private void BtnSearchCustomer_MouseEnter(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            btnSearchCustomer.ForeColor = Color.Red;
            btnSearchCustomer.Image = Properties.Resources.search_255_255_255_24px;
        }
        private void BtnSearchCustomer_Click(object? sender, EventArgs e)
        {
            frmSearchCustomer frm = new frmSearchCustomer();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                customerID = frm.SelectCustomerId;
                customerGroupID = frm.SelectCustomerGroupId;

                txtCustomerName.Text = frm.SelectCustomerName;
                txtCustomerCode.Text = frm.SelectCustomerCode;
                btnChooseCustomerGroup.Text = frm.SelectCustomerGroup;
                if (string.IsNullOrEmpty(frm.SelectCustomerGroupId))
                {
                    btnChooseCustomerGroup.Text = "_Chọn_";
                }
            }
        }

        private void BtnChooseCustomerGroup_MouseLeave(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            btnChooseCustomerGroup.ForeColor = Color.Black;
        }
        private void BtnChooseCustomerGroup_MouseEnter(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            btnChooseCustomerGroup.ForeColor = Color.Red;
        }
        private void BtnChooseCustomerGroup_Click(object? sender, EventArgs e)
        {
            new frmSelectCustomerGroup().ShowDialog();
        }

        private void BtnSearchPlateNumber_MouseLeave(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            btnSearchPlateNumber.ForeColor = Color.Black;
            btnSearchPlateNumber.Image = Properties.Resources.search_0_0_0_24px;
        }
        private void BtnSearchPlateNumber_MouseEnter(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            btnSearchPlateNumber.ForeColor = Color.Red;
            btnSearchPlateNumber.Image = Properties.Resources.search_255_255_255_24px;
        }
        private async void BtnSearchPlateNumber_Click(object? sender, EventArgs e)
        {
            frmSearchPlateNumber frm = new frmSearchPlateNumber();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.vehicleId = frm.selectedVehicleId;
                this.vehicleTypeId = frm.selectedVehicleTypeId;
                this.customerID = frm.selecteCustomerId;
                this.customerGroupID = frm.selectedCustomerGroupId;

                txtCustomerName.Text = frm.selecteCustomerName;
                txtCustomerCode.Text = frm.selecteCustomerCode;

                if (!string.IsNullOrEmpty(this.customerGroupID))
                {
                    btnChooseCustomerGroup.Text = frm.selectedCustomerGroupName;
                }
                else
                {
                    btnChooseCustomerGroup.Text = "_Chọn_";
                }

                txtPlateNumber.Text = frm.selectedVehiclePlate;
                if (!string.IsNullOrEmpty(this.vehicleTypeId))
                {
                    btnChooseVehicleType.Text = frm.selectedVehicleTypeName;
                }
                else
                {
                    btnChooseVehicleType.Text = "_Chọn_";
                }
            }
        }

        private void BtnChooseVehicleType_MouseLeave(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            btnChooseVehicleType.ForeColor = Color.Black;
        }
        private void BtnChooseVehicleType_MouseEnter(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            btnChooseVehicleType.ForeColor = Color.Red;
        }
        private void BtnChooseVehicleType_Click(object? sender, EventArgs e)
        {
            new frmSelectVehicleType().ShowDialog();
        }

        private void BtnConfirm_MouseLeave(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            btnAdd.ForeColor = Color.Black;
            btnAdd.Image = Properties.Resources.Checkmark_0_0_0_24px;
        }
        private void BtnConfirm_MouseEnter(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            btnAdd.ForeColor = Color.Red;
            btnAdd.Image = Properties.Resources.Checkmark_255_255_255_24px;
        }
        private async void BtnConfirm_Click(object? sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            string customerName = txtCustomerName.Text;
            string customerCode = txtCustomerCode.Text;

            if (string.IsNullOrEmpty(customerName))
            {
                MessageBox.Show("Thông tin tên khách hàng không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnAdd.Enabled = true;
                return;
            }
            if (string.IsNullOrEmpty(customerCode))
            {
                MessageBox.Show("Thông tin mã khách hàng không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnAdd.Enabled = true;
                return;
            }

            //Đăng ký khách hàng
            string customerId = Guid.NewGuid().ToString();
            Customer customer = new Customer()
            {
                id = customerId,
                name = customerName,
                code = customerCode
            };
            var createCustomerResponse = await KzParkingApiHelper.CreateCustomer(customer);
            if (!createCustomerResponse.Item1)
            {
                MessageBox.Show(createCustomerResponse.Item2, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnAdd.Enabled = true;
                return;
            }
            //Nếu có thông tin vân tay thì đăng ký định danh
            //Nếu có thông tin biển số thì đăng ký registerVehicle

            btnAdd.Enabled = true;
            this.DialogResult = DialogResult.OK;
        }

        private void BtnUpdate_MouseLeave(object? sender, EventArgs e)
        {
            btnUpdate.Cursor = Cursors.Default;
            btnUpdate.ForeColor = Color.Black;
            btnUpdate.Image = Properties.Resources.edit_0_0_0_24px;
        }
        private void BtnUpdate_MouseEnter(object? sender, EventArgs e)
        {
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.ForeColor = Color.Red;
            btnUpdate.Image = Properties.Resources.edit_255_255_255_24px;
        }
        private async void BtnUpdate_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(customerID))
            {
                //Tìm khách hàng theo code
                var searchCustomerResponse = await KzParkingApiHelper.GetCustomerByCode(txtCustomerCode.Text);
                if (searchCustomerResponse.Item1 != null)
                {
                    if (searchCustomerResponse.Item1.Count > 1)
                    {
                        bool isFound = false;
                        foreach (var customer in searchCustomerResponse.Item1)
                        {
                            if (customer.code.Equals(txtCustomerCode.Text, StringComparison.CurrentCultureIgnoreCase))
                            {
                                this.customerID = customer.id;
                                isFound = true;
                            }
                        }

                        if (!isFound)
                        {
                            MessageBox.Show("Hãy nhập chính xác thông tin mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else if (searchCustomerResponse.Item1.Count == 1)
                    {
                        this.customerID = searchCustomerResponse.Item1[0].id;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin khách hàng trong hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin khách hàng trong hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            string customerName = txtCustomerName.Text;
            string customerCode = txtCustomerCode.Text;

            Customer _customer = new Customer()
            {
                id = customerID,
                name = customerName,
                code = customerCode,
                customerGroupId = this.customerGroupID,
            };
            bool isUpdateCustomerSuccess = await KzParkingApiHelper.UpdateCustomer(_customer);
            if (isUpdateCustomerSuccess)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Gặp lỗi khi cập nhật thông tin khách hàng, vui lòng thử lại sau giây lát!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        #endregion End Controls In Form
    }
}
