using IPaking.Ultility;
using iPakrkingv5.Controls;
using iPakrkingv5.Controls.Usercontrols.BuildControls;
using iParkingv5.FeeTest;
using iParkingv5.Objects.Datas;
using iParkingv5_window;
using iParkingv6.Objects.Datas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace iParkingv5_CustomerRegister.Forms.DataForms
{
    public partial class frmRegisterVehicle : Form
    {
        #region Properties
        private int baseSize = 16;

        string vehicleId = string.Empty;
        string vehicleTypeId = string.Empty;
        string customerID = string.Empty;
        private List<string> identityIds = new List<string>();
        #endregion End Properties

        #region Forms
        public frmRegisterVehicle()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            btnSearchPlateNumber.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.TopMost = true;
            this.Load += Frm_Load;
            this.TopMost = false;
        }
        private void Frm_Load(object? sender, EventArgs e)
        {
            this.Text = "Đăng ký thông tin khách hàng";
            dtpExpireTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            lblTitle.Location = new Point(TextManagement.ROOT_SIZE * 2, TextManagement.ROOT_SIZE * 2);
            lblSubTitle.Location = new Point(lblTitle.Location.X, lblTitle.Location.Y + lblTitle.Height + TextManagement.ROOT_SIZE);

            lblPlateNumber.ToUnder(lblSubTitle, TextManagement.ROOT_SIZE * 2);
            txtPlateNumber.ToCenterRight(lblPlateNumber, TextManagement.ROOT_SIZE * 2);
            btnSearchPlateNumber.ToRight(txtPlateNumber);

            txtCustomerName.ToUnder(txtPlateNumber, TextManagement.ROOT_SIZE);
            txtCustomerName.Width = txtPlateNumber.Width;
            lblCustomerName.FromMultipleControls(lblPlateNumber, txtCustomerName);
            btnSearchCustomer.FromMultipleControls(btnSearchPlateNumber, txtCustomerName, false);

            btnChooseVehicleType.ToUnder(txtCustomerName, TextManagement.ROOT_SIZE);
            btnChooseVehicleType.Width = btnSearchPlateNumber.Location.X + btnSearchPlateNumber.Width - btnChooseVehicleType.Location.X;
            lblVehicleType.FromMultipleControls(lblPlateNumber, btnChooseVehicleType);

            btnChooseIdentity.ToUnder(btnChooseVehicleType, TextManagement.ROOT_SIZE);
            btnChooseIdentity.Width = btnChooseVehicleType.Width;
            lblIdentity.FromMultipleControls(lblPlateNumber, btnChooseIdentity);

            dtpExpireTime.ToUnder(btnChooseIdentity, TextManagement.ROOT_SIZE);
            dtpExpireTime.Width = btnChooseVehicleType.Width;
            lblExpireTime.FromMultipleControls(lblPlateNumber, dtpExpireTime);

            txtCustomerName.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtPlateNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnChooseIdentity.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnSearchPlateNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnChooseVehicleType.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            dtpExpireTime.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            btnAdd.Location = new Point(dtpExpireTime.Location.X + (dtpExpireTime.Width - btnAdd.Width), dtpExpireTime.Location.Y + dtpExpireTime.Height + TextManagement.ROOT_SIZE);
            btnUpdate.Location = new Point(btnAdd.Location.X - btnUpdate.Width - TextManagement.ROOT_SIZE, btnAdd.Location.Y);

            this.Height = btnAdd.Location.Y + btnAdd.Height + TextManagement.ROOT_SIZE * 2 + this.Height - this.DisplayRectangle.Height;
            this.Width = btnChooseVehicleType.Location.X + btnChooseVehicleType.Width + TextManagement.ROOT_SIZE * 2;

            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSearchPlateNumber.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearchCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChooseIdentity.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;
            txtPlateNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCustomerName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnChooseVehicleType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpExpireTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            if (Properties.Settings.Default.preferVehicleWidth > 0 && Properties.Settings.Default.preferVehicleHeight > 0)
            {
                this.Size = new Size(Properties.Settings.Default.preferVehicleWidth, Properties.Settings.Default.preferVehicleHeight);
            }

            toolTip1.SetToolTip(txtCustomerName, "Tên khách hàng, dùng để đăng ký lên hệ thống.");
            toolTip1.SetToolTip(btnSearchCustomer, "Bấm để tìm kiếm khách hàng theo thông tin đã nhập.");
            toolTip1.SetToolTip(txtPlateNumber, "Biển số xe, dùng để đăng ký lên hệ thống.");
            toolTip1.SetToolTip(btnSearchPlateNumber, "Bấm để tìm kiếm biển số xe theo thông tin đã nhập.");
            toolTip1.SetToolTip(btnChooseVehicleType, "Bấm để chọn loại phương tiện.");
            toolTip1.SetToolTip(btnAdd, "Bấm để lưu thông tin lên hệ thống.");

            btnSearchCustomer.Click += BtnSearchCustomer_Click;
            btnSearchCustomer.MouseEnter += BtnSearchCustomer_MouseEnter;
            btnSearchCustomer.MouseLeave += BtnSearchCustomer_MouseLeave;

            btnSearchPlateNumber.Click += BtnSearchPlateNumber_Click;
            btnSearchPlateNumber.MouseEnter += BtnSearchPlateNumber_MouseEnter;
            btnSearchPlateNumber.MouseLeave += BtnSearchPlateNumber_MouseLeave;

            btnChooseVehicleType.Click += BtnChooseVehicleType_Click;
            btnChooseVehicleType.MouseEnter += BtnChooseVehicleType_MouseEnter;
            btnChooseVehicleType.MouseLeave += BtnChooseVehicleType_MouseLeave;

            btnChooseIdentity.Click += BtnChooseIdentity_Click;
            btnChooseIdentity.MouseEnter += BtnChooseIdentity_MouseEnter;
            btnChooseIdentity.MouseLeave += BtnChooseIdentity_MouseLeave;

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
            Properties.Settings.Default.preferVehicleHeight = this.Height;
            Properties.Settings.Default.preferVehicleWidth = this.Width;
            Properties.Settings.Default.Save();
        }
        #endregion End Forms

        #region Controls In Form
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

                txtCustomerName.Text = frm.selecteCustomerName;

                txtPlateNumber.Text = frm.selectedVehiclePlate;
                if (!string.IsNullOrEmpty(this.vehicleTypeId))
                {
                    btnChooseVehicleType.Text = frm.selectedVehicleTypeName;
                }
                else
                {
                    btnChooseVehicleType.Text = "_Chọn_";
                }

                if (frm.ExpireTime != null)
                {
                    dtpExpireTime.Value = frm.ExpireTime.Value;
                }
            }
        }

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
            frmSelectVehicleType frm = new frmSelectVehicleType();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.vehicleTypeId = frm.selectedVehicleTypeId;
                btnChooseVehicleType.Text = frm.selectedVehicleTypeName;
            }
        }

        private void BtnChooseIdentity_MouseLeave(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            btnChooseIdentity.ForeColor = Color.Black;
        }
        private void BtnChooseIdentity_MouseEnter(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            btnChooseIdentity.ForeColor = Color.Red;
        }
        private void BtnChooseIdentity_Click(object? sender, EventArgs e)
        {
            List<string> temp = new List<string>();
            foreach (var item in this.identityIds)
            {
                temp.Add(item.ToString());
            }
            frmSelectIdentity frm = new frmSelectIdentity(temp);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.identityIds = frm.identitids;
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
            string vehiclePlate = txtPlateNumber.Text;
            if (string.IsNullOrEmpty(this.customerID))
            {
                MessageBox.Show("Hãy chọn khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(vehicleTypeId))
            {
                MessageBox.Show("Hãy chọn loại phương tiện.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.identityIds == null)
            {
                MessageBox.Show("Hãy chọn định danh cho phương tiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.identityIds.Count == 0)
            {
                MessageBox.Show("Hãy chọn định danh cho phương tiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<RegisteredVehicle> vehicles = (await AppData.ApiServer.parkingDataService.GetRegisterVehiclesAsync(vehiclePlate)).Item1 ?? new List<RegisteredVehicle>();
            bool isExistPlate = false;
            if (vehicles.Count > 0)
            {
                foreach (RegisteredVehicle item in vehicles)
                {
                    if (item.PlateNumber == vehiclePlate)
                    {
                        isExistPlate = true;

                        bool isConfirmOverride = MessageBox.Show("Phương tiện đã có trong hệ thống. Bạn có muốn ghi đè thông tin?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                        if (!isConfirmOverride)
                        {
                            return;
                        }
                        else
                        {
                            item.CustomerId = this.customerID;
                            item.vehicleType = this.vehicleTypeId;
                            bool isSuccess = await AppData.ApiServer.parkingDataService.UpdateRegisteredVehicleAsyncById(item);
                            if (isSuccess)
                            {
                                MessageBox.Show("Cập nhật thông tin phương tiện thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                MessageBox.Show("Cập nhật thông tin phương tiện thất bại, vui lòng thử lại sau giây lát", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        break;
                    }
                }
            }
            if (!isExistPlate)
            {
                RegisteredVehicle registeredVehicle = new RegisteredVehicle()
                {
                    Name = vehiclePlate,
                    PlateNumber = vehiclePlate,
                    vehicleType = this.vehicleTypeId,
                    CustomerId = this.customerID,
                    ExpireUtc = dtpExpireTime.Value.ToUniversalTime().ToString(),
                    Enabled = true,
                };
                var insertResponse = await AppData.ApiServer.parkingDataService.CreateRegisteredVehicle(registeredVehicle);
                if (insertResponse.Item1 != null)
                {
                    MessageBox.Show("Thêm mới phương tiện thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Thêm mới thông tin phương tiện thất bại, vui lòng thử lại sau giây lát", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
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
            string vehiclePlate = txtPlateNumber.Text;
            if (string.IsNullOrEmpty(this.customerID))
            {
                MessageBox.Show("Hãy chọn khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(vehicleTypeId))
            {
                MessageBox.Show("Hãy chọn loại phương tiện.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.identityIds == null)
            {
                MessageBox.Show("Hãy chọn định danh cho phương tiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.identityIds.Count == 0)
            {
                MessageBox.Show("Hãy chọn định danh cho phương tiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(vehicleId))
            {
                List<RegisteredVehicle> vehicles = (await AppData.ApiServer.parkingDataService.GetRegisterVehiclesAsync(vehiclePlate)).Item1 ?? new List<RegisteredVehicle>();
                RegisteredVehicle? existVehicle = null;
                foreach (RegisteredVehicle item in vehicles)
                {
                    if (item.PlateNumber == vehiclePlate)
                    {
                        existVehicle = item;
                    }
                }
                if (existVehicle != null)
                {
                    existVehicle.CustomerId = this.customerID;
                    existVehicle.vehicleType = this.vehicleTypeId;
                    bool isSuccess = await AppData.ApiServer.parkingDataService.UpdateRegisteredVehicleAsyncById(existVehicle);
                    if (isSuccess)
                    {
                        MessageBox.Show("Cập nhật thông tin phương tiện thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thông tin phương tiện thất bại, vui lòng thử lại sau giây lát", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    bool isConfirmAdd = MessageBox.Show("Phương tiện chưa có trong hệ thống, bạn có muốn thêm mới?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes;
                    if (!isConfirmAdd)
                    {
                        return;
                    }
                    else
                    {
                        RegisteredVehicle registeredVehicle = new RegisteredVehicle()
                        {
                            Name = vehiclePlate,
                            PlateNumber = vehiclePlate,
                            vehicleType = this.vehicleTypeId,
                            CustomerId = this.customerID,
                            ExpireUtc = dtpExpireTime.Value.ToUniversalTime().ToString(),
                            Enabled = true,
                        };
                        var insertResponse = await AppData.ApiServer.parkingDataService.CreateRegisteredVehicle(registeredVehicle);
                        if (insertResponse.Item1 != null)
                        {
                            MessageBox.Show("Thêm mới phương tiện thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("Thêm mới thông tin phương tiện thất bại, vui lòng thử lại sau giây lát", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }
            }
            else
            {
                RegisteredVehicle? registeredVehicle = (await AppData.ApiServer.parkingDataService.GetRegistedVehilceByIdAsync(this.vehicleId)).Item1;
                if (registeredVehicle == null)
                {
                    MessageBox.Show("Gặp lỗi khi thêm mới phương tiện, vui lòng thử lại sau giây lát", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    registeredVehicle.CustomerId = this.customerID;
                    registeredVehicle.vehicleType = this.vehicleTypeId;
                    bool isSuccess = await AppData.ApiServer.parkingDataService.UpdateRegisteredVehicleAsyncById(registeredVehicle);
                    if (isSuccess)
                    {
                        MessageBox.Show("Cập nhật thông tin phương tiện thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thông tin phương tiện thất bại, vui lòng thử lại sau giây lát", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
        }
        #endregion End Controls In Form
    }
}
