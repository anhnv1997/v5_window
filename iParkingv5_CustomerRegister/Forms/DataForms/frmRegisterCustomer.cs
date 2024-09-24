
using IPaking.Ultility;
using iParkingv5_CustomerRegister.Databases;
using iParkingv5_CustomerRegister.Forms;
using iParkingv5_CustomerRegister.UserControls;
using iParkingv6.ApiManager.KzParkingv3Apis;
using iParkingv6.Objects.Datas;

namespace iParkingv5_CustomerRegister
{
    public partial class frmRegisterCustomer : Form
    {
        #region Properties
        private int baseSize = 16;

        string customerID = string.Empty;
        #endregion End Properties

        #region Forms
        public frmRegisterCustomer()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            btnSearchCustomer.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.TopMost = true;
            this.Load += Form1_Load;
            this.TopMost = false;
        }
        private void Form1_Load(object? sender, EventArgs e)
        {
            this.Text = "Đăng ký thông tin khách hàng";
            lblTitle.Location = new Point(this.baseSize * 2, this.baseSize * 2);
            lblSubTitle.Location = new Point(lblTitle.Location.X, lblTitle.Location.Y + lblTitle.Height + this.baseSize);

            lblCustomerName.Location = new Point(lblTitle.Location.X, lblSubTitle.Location.Y + lblSubTitle.Height + this.baseSize * 2);
            txtCustomerName.Location = new Point((int)(lblCustomerName.Location.X + lblCustomerName.Width + this.baseSize * 2), lblCustomerName.Location.Y + (lblCustomerName.Height - txtCustomerName.Height) / 2);
            btnSearchCustomer.Location = new Point(txtCustomerName.Location.X + txtCustomerName.Width + this.baseSize, txtCustomerName.Location.Y);

            txtCustomerCode.Location = new Point(txtCustomerName.Location.X, txtCustomerName.Location.Y + txtCustomerName.Height + this.baseSize);
            txtCustomerCode.Width = btnSearchCustomer.Location.X + btnSearchCustomer.Width - txtCustomerCode.Location.X;
            lblCustomerCode.Location = new Point(lblCustomerName.Location.X, txtCustomerCode.Location.Y + (txtCustomerCode.Height - lblCustomerCode.Height) / 2);

            
            txtCustomerName.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnSearchCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtCustomerCode.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            btnAdd.Location = new Point(txtCustomerCode.Location.X + (txtCustomerCode.Width - btnAdd.Width), txtCustomerCode.Location.Y + txtCustomerCode.Height + this.baseSize);
            btnUpdate.Location = new Point(btnAdd.Location.X - btnUpdate.Width - TextManagement.ROOT_SIZE, btnAdd.Location.Y);

            this.Height = btnAdd.Location.Y + btnAdd.Height + this.baseSize * 2 + this.Height - this.DisplayRectangle.Height;
            this.Width = btnSearchCustomer.Location.X + btnSearchCustomer.Width + this.baseSize * 2;

            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSearchCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtCustomerName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCustomerCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            if (Properties.Settings.Default.preferWidth > 0 && Properties.Settings.Default.preferHeight > 0)
            {
                this.Size = new Size(Properties.Settings.Default.preferWidth, Properties.Settings.Default.preferHeight);
            }

            toolTip1.SetToolTip(txtCustomerName, "Tên khách hàng, dùng để đăng ký lên hệ thống.");
            toolTip1.SetToolTip(btnSearchCustomer, "Bấm để tìm kiếm khách hàng theo thông tin đã nhập.");
            toolTip1.SetToolTip(txtCustomerCode, "Mã khách hàng, dùng để phân biệt giữa các khách hàng.");
            toolTip1.SetToolTip(btnAdd, "Bấm để lưu thông tin lên hệ thống.");

            btnSearchCustomer.Click += BtnSearchCustomer_Click;
            btnSearchCustomer.MouseEnter += BtnSearchCustomer_MouseEnter;
            btnSearchCustomer.MouseLeave += BtnSearchCustomer_MouseLeave;

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

                txtCustomerName.Text = frm.SelectCustomerName;
                txtCustomerCode.Text = frm.SelectCustomerCode;
            }
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
                Id = customerId,
                Name = customerName,
                Code = customerCode
            };
            var createCustomerResponse = await KzParkingApiHelper.CreateCustomer(customer);
            if (!createCustomerResponse.Item1)
            {
                MessageBox.Show(createCustomerResponse.Item2, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnAdd.Enabled = true;
                return;
            }

            MessageBox.Show("Đăng ký thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            if (customer.Code.Equals(txtCustomerCode.Text, StringComparison.CurrentCultureIgnoreCase))
                            {
                                this.customerID = customer.Id;
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
                        this.customerID = searchCustomerResponse.Item1[0].Id;
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
                Id = customerID,
                Name = customerName,
                Code = customerCode,
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
