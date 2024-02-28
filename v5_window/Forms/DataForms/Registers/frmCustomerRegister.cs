using IPaking.Ultility;
using iPakrkingv5.Controls.Controls.Buttons;
using iParkingv5.Controller;
using iParkingv5.Objects;
using iParkingv5.Objects.Databases;
using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Enums;
using iParkingv5_CustomerRegister.Forms;
using iParkingv6.ApiManager.KzParkingv3Apis;
using iParkingv6.Objects.Datas;

namespace iParkingv5_window.Forms.DataForms
{
    public partial class frmCustomerRegister : Form
    {
        #region Properties
        private Lane lane;
        private VehicleType.VehicleBaseType vehicleType;
        private Identity? selectedIdentity = null;
        private readonly SemaphoreSlim semaphoreSlimOnNewEvent = new SemaphoreSlim(1, 1);
        List<VehicleType>? vehicleTypes = null;
        #endregion End Properties

        #region Forms
        public frmCustomerRegister(List<Lane> lanes, VehicleType.VehicleBaseType baseType)
        {
            InitializeComponent();
            txtIdentity.Enabled = false;
            dtpExpireTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            this.DoubleBuffered = true;
            foreach (var lane in lanes)
            {
                if (lane.type == 0)
                {
                    if (baseType == VehicleType.VehicleBaseType.Car && lane.loop)
                    {
                        this.lane = lane;
                    }
                    else if (baseType != VehicleType.VehicleBaseType.Car && !lane.loop)
                    {
                        this.lane = lane;
                    }
                }
            }
            this.vehicleType = baseType;
            this.Load += FrmCustomerRegister_Load;
            this.FormClosing += FrmCustomerRegister_FormClosing;
        }
        LblSearch btnSearchCustomer;
        private async void FrmCustomerRegister_Load(object? sender, EventArgs e)
        {
            btnSearchCustomer = new LblSearch();
            btnSearchCustomer.InitControl(BtnSearchCustomer_Click);
            this.Controls.Add(btnSearchCustomer);

            btnSearch.InitControl(btnSearchPlate_Click);
            btnOk1.InitControl(btnConfirm_Click);

            CreateUI();

            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            await LoadVehicleType();
            LoadCustomerGroup();

            if (this.lane != null)
            {
                foreach (IController controller in frmMain.controllers)
                {
                    if (this.lane.controlUnits != null)
                    {
                        foreach (ControllerInLane controllerInLane in this.lane.controlUnits)
                        {
                            if (controllerInLane.controlUnitId.ToLower() == controller.ControllerInfo.Id.ToLower())
                            {
                                controller.CardEvent += Controller_CardEvent;
                            }
                        }
                    }
                }
            }
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

        private void FrmCustomerRegister_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (this.lane != null)
            {
                foreach (IController controller in frmMain.controllers)
                {
                    if (this.lane.controlUnits != null)
                    {
                        foreach (ControllerInLane controllerInLane in this.lane.controlUnits)
                        {
                            if (controllerInLane.controlUnitId.ToLower() == controller.ControllerInfo.Id.ToLower())
                            {
                                controller.CardEvent -= Controller_CardEvent;
                            }
                        }
                    }
                }
            }
        }
        #endregion End Forms

        #region Event
        private async void Controller_CardEvent(object sender, iParkingv5.Objects.Events.CardEventArgs ce)
        {
            await semaphoreSlimOnNewEvent.WaitAsync();
            try
            {
                foreach (ControllerInLane controllerInLane in this.lane.controlUnits)
                {
                    if (controllerInLane.controlUnitId.ToLower() == ce.DeviceId)
                    {
                        if (!controllerInLane.readers.Contains(ce.ReaderIndex))
                        {
                            return;
                        }
                    }
                }
                var identityResponse = await KzParkingApiHelper.GetIdentityByCode(ce.PreferCard);
                this.selectedIdentity = identityResponse.Item1;
                if (!identityResponse.Item2)
                {
                    MessageBox.Show("Không đọc được thông tin định danh, vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (this.selectedIdentity == null)
                {
                    MessageBox.Show("Mã định danh không có trong hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                txtIdentity.Invoke(new Action(() =>
                {
                    txtIdentity.Text = this.selectedIdentity.Name;
                }));
            }
            catch (Exception)
            {
                MessageBox.Show("Không đọc được thông tin định danh, vui lòng quẹt thẻ lại hoặc sử dụng thẻ khác",
                                   "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            finally
            {
                semaphoreSlimOnNewEvent.Release();
            }
        }
        #endregion

        #region Controls In Form
        private string vehicleId = string.Empty;
        private string vehicleTypeId = string.Empty;
        private string customerID = string.Empty;
        private void btnSearchPlate_Click(object sender, EventArgs e)
        {
            frmSearchPlateNumber frm = new frmSearchPlateNumber();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.vehicleId = frm.selectedVehicleId;
                this.vehicleTypeId = frm.selectedVehicleTypeId;
                this.customerID = frm.selecteCustomerId;

                txtCustomerName.Text = frm.selecteCustomerName;
                txtCustomerCode.Text = frm.selecteCustomerCode;

                txtPlate.Text = frm.selectedVehiclePlate;
                if (!string.IsNullOrEmpty(this.vehicleTypeId))
                {
                    cbVehicleTypes.SelectedIndex = cbVehicleTypes.FindStringExact(frm.selectedVehicleTypeName);
                }
                if (frm.ExpireTime != null)
                {
                    dtpExpireTime.Value = frm.ExpireTime.Value;
                }
            }
        }
        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            btnOk1.Enabled = false;
            if (cbCustomerGroup.SelectedIndex == -1)
            {
                btnOk1.Enabled = true;
                MessageBox.Show("Thông tin nhóm khách hàng không được phép bỏ trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtCustomerName.Text))
            {
                btnOk1.Enabled = true;
                MessageBox.Show("Thông tin tên khách hàng không được phép bỏ trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtPlate.Text))
            {
                btnOk1.Enabled = true;
                MessageBox.Show("Thông tin biển số xe không được phép bỏ trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cbVehicleTypes.SelectedIndex == -1)
            {
                btnOk1.Enabled = true;
                MessageBox.Show("Thông tin loại xe không được phép bỏ trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.selectedIdentity == null)
            {
                btnOk1.Enabled = true;
                MessageBox.Show("Hãy quẹt thẻ lấy thông tin định danh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            IdentityGroup identityGroup = await KzParkingApiHelper.GetIdentityGroupByIdAsync(this.selectedIdentity!.IdentityGroupId);
            if (identityGroup == null)
            {
                btnOk1.Enabled = true;
                MessageBox.Show("Không đọc được thông tin nhóm định danh, vui lòng thử lại sau giây lát", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (identityGroup.Type == IdentityGroupType.Monthly)
            {
                btnOk1.Enabled = true;
                MessageBox.Show("Định danh được dụng thuộc nhóm thẻ tháng, vui lòng sử dụng thẻ lượt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Save();
            btnOk1.Enabled = true;
        }
        #endregion End Controls In Form

        #region Private Function
        private void CreateUI()
        {
            lblPlateNumber.Location = new Point(TextManagement.ROOT_SIZE * 2, TextManagement.ROOT_SIZE * 2);
            txtPlate.Location = new Point(lblPlateNumber.Location.X + lblCustomerGroup.Width + TextManagement.ROOT_SIZE,
                                          lblPlateNumber.Location.Y + (lblPlateNumber.Height - lblPlateNumber.Height) / 2);
            btnSearch.Location = new Point(txtPlate.Location.X + txtPlate.Width + TextManagement.ROOT_SIZE,
                                           txtPlate.Location.Y);

            cbVehicleTypes.Location = new Point(txtPlate.Location.X,
                                                txtPlate.Location.Y + txtPlate.Height + TextManagement.ROOT_SIZE);
            cbVehicleTypes.Width = txtPlate.Width + btnSearch.Width + TextManagement.ROOT_SIZE;
            lblVehicleGroup.Location = new Point(lblPlateNumber.Location.X,
                                                  cbVehicleTypes.Location.Y + (cbVehicleTypes.Height - lblVehicleGroup.Height) / 2);

            txtCustomerName.Location = new Point(txtPlate.Location.X, cbVehicleTypes.Location.Y + cbVehicleTypes.Height + TextManagement.ROOT_SIZE);
            txtCustomerName.Width = txtPlate.Width;
            lblCustomerName.Location = new Point(lblPlateNumber.Location.X,
                                                 txtCustomerName.Location.Y + (txtCustomerName.Height - lblCustomerName.Height) / 2);

            btnSearchCustomer.Location = new Point(btnSearch.Location.X, txtCustomerName.Location.Y);

            txtCustomerCode.Location = new Point(txtCustomerName.Location.X, txtCustomerName.Location.Y + txtCustomerName.Height + TextManagement.ROOT_SIZE);
            txtCustomerCode.Width = cbVehicleTypes.Width;
            lblCustomerCode.Location = new Point(lblCustomerName.Location.X,
                                                 txtCustomerCode.Location.Y + (txtCustomerCode.Height - lblCustomerCode.Height) / 2);

            cbCustomerGroup.Location = new Point(txtCustomerCode.Location.X, txtCustomerCode.Location.Y + txtCustomerCode.Height + TextManagement.ROOT_SIZE);
            cbCustomerGroup.Width = cbVehicleTypes.Width;
            lblCustomerGroup.Location = new Point(lblCustomerName.Location.X,
                                                  cbCustomerGroup.Location.Y + (cbCustomerGroup.Height - lblCustomerGroup.Height) / 2);

            dtpExpireTime.Location = new Point(cbCustomerGroup.Location.X, cbCustomerGroup.Location.Y + cbCustomerGroup.Height + TextManagement.ROOT_SIZE);
            dtpExpireTime.Width = cbVehicleTypes.Width;
            lblExpireTime.Location = new Point(lblCustomerName.Location.X,
                                                dtpExpireTime.Location.Y + (dtpExpireTime.Height - lblExpireTime.Height) / 2);

            txtIdentity.Location = new Point(dtpExpireTime.Location.X,
                                              dtpExpireTime.Location.Y + dtpExpireTime.Height + TextManagement.ROOT_SIZE);
            txtIdentity.Width = cbVehicleTypes.Width;
            lblIdentity.Location = new Point(lblCustomerName.Location.X,
                                              txtIdentity.Location.Y + (txtIdentity.Height - lblIdentity.Height) / 2);

            btnOk1.Location = new Point(txtIdentity.Location.X + (txtIdentity.Width - btnOk1.Width),
                                         txtIdentity.Location.Y + txtIdentity.Height + TextManagement.ROOT_SIZE);

            foreach (Control item in this.Controls)
            {
                item.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            }
            this.Width = this.PreferredSize.Width + TextManagement.ROOT_SIZE;
            this.Height = this.PreferredSize.Height + TextManagement.ROOT_SIZE;
            //this.Width = btnSearch.Location.X + btnSearch.Width + TextManagement.ROOT_SIZE*2;
            //this.Height = btnOk1.Location.Y + btnOk1.Height + TextManagement.ROOT_SIZE*2;

            txtCustomerName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCustomerCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbCustomerGroup.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPlate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbVehicleTypes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpExpireTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtIdentity.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearchCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOk1.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            btnOk1.DialogResult = DialogResult.None;
        }
        private async Task LoadVehicleType()
        {
            vehicleTypes = await KzParkingApiHelper.GetAllVehicleTypes();
            if (vehicleTypes == null)
            {
                MessageBox.Show("Không nhận được thông tin nhóm phương tiện, vui lòng thử lại sau giây lát!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            foreach (VehicleType vehicleType in vehicleTypes)
            {
                if (vehicleType.Type != this.vehicleType)
                {
                    continue;
                }
                ListItem listItem = new()
                {
                    Value = vehicleType.Name,
                    Name = vehicleType.Id.ToString()
                };
                cbVehicleTypes.Items.Add(listItem);
            }
            cbVehicleTypes.SelectedIndex = cbVehicleTypes.Items.Count > 0 ? 0 : -1;
            cbVehicleTypes.DisplayMember = "Value";
        }
        private void LoadCustomerGroup()
        {
            foreach (CustomerGroup customerGroup in StaticPool.customerGroupCollection)
            {
                ListItem listItem = new()
                {
                    Value = customerGroup.Name,
                    Name = customerGroup.Id.ToString()
                };
                cbCustomerGroup.Items.Add(listItem);
            }
            cbCustomerGroup.SelectedIndex = cbCustomerGroup.Items.Count > 0 ? 0 : -1;
            cbCustomerGroup.DisplayMember = "Value";
        }
        private async void Save()
        {
            bool allowDeleteCustomer = true;

            if (!string.IsNullOrEmpty(this.customerID))
            {
                allowDeleteCustomer = false;
                //Cập nhật thông tin khách hàng
                Customer _customer = new Customer()
                {
                    Id = customerID,
                    Name = txtCustomerName.Text,
                    Code = txtCustomerCode.Text,
                };
                bool isUpdateCustomerSuccess = await KzParkingApiHelper.UpdateCustomer(_customer);
                if (!isUpdateCustomerSuccess)
                {
                    MessageBox.Show("Gặp lỗi khi cập nhật thông tin khách hàng, vui lòng thử lại sau giây lát!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                //Thêm mới thông tin khách hàng
                string customerId = await SaveNewCustomer();
                if (string.IsNullOrEmpty(customerId))
                {
                    return;
                }
                else
                {
                    this.customerID = customerId;
                }
            }
            string vehicleTypeID = ((ListItem)cbVehicleTypes.SelectedItem).Name;
            if (!string.IsNullOrEmpty(this.vehicleId))
            {
                //Cập nhật thông tin phương tiện
                RegisteredVehicle vehicle = new RegisteredVehicle()
                {
                    Id = this.vehicleId,
                    Name = txtPlate.Text,
                    PlateNumber = txtPlate.Text,
                    VehicleTypeId = int.Parse(vehicleTypeID),
                    CustomerId = this.customerID,
                    Enabled = true,
                    Deleted = false,
                    IdentityIds = new List<string>() { this.selectedIdentity!.Id },
                    //CreatedUtc = DateTime.Now.ToString(UltilityManagement.UTCFormat),
                    ExpireUtc = dtpExpireTime.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.ffff"),
                    LastActivatedUtc = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd"),
                };
                bool isSuccess = await KzParkingApiHelper.UpdateRegisteredVehicleAsyncById(vehicle);
                if (isSuccess)
                {
                    MessageBox.Show("Đăng ký thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    return;
                }
            }
            else
            {
                //Thêm mới thông tin phương tiện
                if (await SaveNewRegisterVehicle(this.customerID, allowDeleteCustomer))
                {
                    MessageBox.Show("Đăng ký thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    return;
                }
            }

        }
        private async Task<string> SaveNewCustomer()
        {
            string customerGroupId = ((ListItem)cbCustomerGroup.SelectedItem).Name;
            Customer customer = new Customer()
            {
                Name = txtCustomerName.Text,
                Code = txtCustomerCode.Text,
                CustomerGroupId = customerGroupId,
                DateOfBirth = DateTime.MinValue,
            };
            var createCustomerResponse = await KzParkingApiHelper.CreateCustomer(customer);
            if (!createCustomerResponse.Item1)
            {
                MessageBox.Show(createCustomerResponse.Item2, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
            else
                return createCustomerResponse.Item2;
        }
        private async Task<bool> SaveNewRegisterVehicle(string customerId, bool allowDeleteCustomerIfError)
        {
            string vehicleTypeID = ((ListItem)cbVehicleTypes.SelectedItem).Name;
            RegisteredVehicle registeredVehicle = new RegisteredVehicle()
            {
                Name = txtPlate.Text,
                PlateNumber = txtPlate.Text,
                VehicleTypeId = int.Parse(vehicleTypeID),
                CustomerId = customerId,
                Enabled = true,
                Deleted = false,
                IdentityIds = new List<string>() { this.selectedIdentity!.Id },
                //CreatedUtc = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.ffff") ,
                ExpireUtc = dtpExpireTime.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.ffff"),
                LastActivatedUtc = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd"),
            };

            var createRegisterVehicleResponse = await KzParkingApiHelper.CreateRegisteredVehicle(registeredVehicle);
            if (!createRegisterVehicleResponse.Item1)
            {
                MessageBox.Show(createRegisterVehicleResponse.Item2, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (allowDeleteCustomerIfError)
                {
                    await KzParkingApiHelper.DeleteCustomerById(customerId);
                    this.customerID = string.Empty;
                }
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion End Private Function
    }
}
