using IPaking.Ultility;
using iParkingv5.Controller;
using iParkingv5.Objects;
using iParkingv5.Objects.Databases;
using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Enums;
using iParkingv6.ApiManager.KzParkingv3Apis;
using iParkingv6.Objects.Datas;

namespace iParkingv5_window.Forms.DataForms
{
    public partial class frmCustomerRegister : Form
    {
        #region Properties
        private Lane lane;
        private Identity? selectedIdentity = null;
        private readonly SemaphoreSlim semaphoreSlimOnNewEvent = new SemaphoreSlim(1, 1);
        List<CustomerGroup>? customerGroups = null;
        List<VehicleType>? vehicleTypes = null;
        #endregion End Properties

        #region Forms
        public frmCustomerRegister(Lane lane)
        {
            InitializeComponent();
            txtIdentity.Enabled = false;
            dtpExpireTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            this.StartPosition = FormStartPosition.CenterParent;
            this.lane = lane;
            this.Load += FrmCustomerRegister_Load;
            this.FormClosing += FrmCustomerRegister_FormClosing;
        }
        private async void FrmCustomerRegister_Load(object? sender, EventArgs e)
        {
            btnSearch.Init(btnSearch_Click);
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            await LoadVehicleType();
            LoadCustomerGroup();

            foreach (IController controller in frmMain.controllers)
            {
                if (this.lane.controlUnits != null)
                {
                    foreach (ControllerInLane controllerInLane in this.lane.controlUnits)
                    {
                        if (controllerInLane.controlUnitId.ToLower() == controller.ControllerInfo.id.ToLower())
                        {
                            controller.CardEvent += Controller_CardEvent;
                        }
                    }
                }
            }
        }
        private void FrmCustomerRegister_FormClosing(object? sender, FormClosingEventArgs e)
        {
            foreach (IController controller in frmMain.controllers)
            {
                if (this.lane.controlUnits != null)
                {
                    foreach (ControllerInLane controllerInLane in this.lane.controlUnits)
                    {
                        if (controllerInLane.controlUnitId.ToLower() == controller.ControllerInfo.id.ToLower())
                        {
                            controller.CardEvent -= Controller_CardEvent;
                        }
                    }
                }
            }
        }
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
        #endregion End Forms

        #region Controls In Form
        private void btnConfirm_Click(object sender, EventArgs e)
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
            Save();
            btnOk1.Enabled = true;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmSelectCustomer frm = new("Tìm kiếm khách hàng");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtCustomerName.Text = frm.SelectCustomerName;
                txtCustomerCode.Text = frm.SelectCustomerCode;
                cbCustomerGroup.SelectedIndex = cbCustomerGroup.FindStringExact(frm.SelectCustomerGroup);
            }
        }
        #endregion End Controls In Form

        #region Private Function
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
        private async Task LoadCustomerGroup()
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
            string customerId = await SaveNewCustomer();
            if (string.IsNullOrEmpty(customerId))
            {
                return;
            }
            if (await SaveNewRegisterVehicle(customerId))
            {
                MessageBox.Show("Đăng ký thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        private async Task<string> SaveNewCustomer()
        {
            string customerGroupId = ((ListItem)cbCustomerGroup.SelectedItem).Name;
            string id = Guid.NewGuid().ToString();
            Customer customer = new Customer()
            {
                id = id,
                name = txtCustomerName.Text,
                code = txtCustomerCode.Text,
                customerGroupId = customerGroupId,
                dateOfBirth = DateTime.MinValue.ToString(UltilityManagement.UTCFormat),
            };
            var createCustomerResponse = await KzParkingApiHelper.CreateCustomer(customer);
            if (!createCustomerResponse.Item1)
            {
                MessageBox.Show(createCustomerResponse.Item2, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
            return id;
        }
        private async Task<bool> SaveNewRegisterVehicle(string customerId)
        {
            string vehicleTypeID = ((ListItem)cbVehicleTypes.SelectedItem).Name;
            string vehicleId = Guid.NewGuid().ToString();
            RegisteredVehicle registeredVehicle = new RegisteredVehicle()
            {
                Id = vehicleId,
                Name = txtPlate.Text,
                PlateNumber = txtPlate.Text,
                VehicleTypeId = int.Parse(vehicleTypeID),
                CustomerId = customerId,
                Enabled = true,
                Deleted = false,
                //RegisteredVehicleIdentityMaps = new List<RegisteredVehicleIdentityMap>()
                //{
                //    new RegisteredVehicleIdentityMap()
                //    {
                //        RegisteredVehicleId = vehicleId,
                //        IdentityId = this.selectedIdentity!.Id,
                //    }
                //},
                CreatedUtc = DateTime.Now.ToString(UltilityManagement.UTCFormat),
            };

            var createRegisterVehicleResponse = await KzParkingApiHelper.CreateRegisteredVehicle(registeredVehicle);
            if (!createRegisterVehicleResponse.Item1)
            {
                MessageBox.Show(createRegisterVehicleResponse.Item2, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                await KzParkingApiHelper.DeleteCustomerById(customerId);
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
