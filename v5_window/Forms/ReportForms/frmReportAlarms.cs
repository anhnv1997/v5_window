using IPaking.Ultility;
using iPakrkingv5.Controls;
using iPakrkingv5.Controls.Controls.Buttons;
using iParkingv5.ApiManager.KzParkingv5Apis;
using iParkingv5.Objects;
using iParkingv5.Objects.Databases;
using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Datas.Device_service;
using iParkingv5.Objects.Datas.parking_service;
using iParkingv5.Objects.EventDatas;
using iParkingv5_window.Forms.DataForms;
using iParkingv5_window.Usercontrols.BuildControls;
using iParkingv6.ApiManager.KzParkingv3Apis;
using System.Data;
using System.Runtime.InteropServices;
using static iParkingv6.ApiManager.KzParkingv3Apis.KzParkingApiHelper;

namespace iParkingv5_window.Forms.ReportForms
{
    public partial class frmReportAlarms : Form
    {
        #region Properties
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;
        private int totalPages = 0;
        private int totalEvents = 0;
        public static Image defaultImg = Image.FromFile(frmMain.defaultImagePath);

        #region Properties
        private List<Lane> lanes = new List<Lane>();
        private List<IdentityGroup> identityGroups = new List<IdentityGroup>();
        private List<RegisteredVehicle> registerVehicles = new List<RegisteredVehicle>();
        private List<Customer> customers = new List<Customer>();
        #endregion End Properties

        #endregion End Properties

        #region Forms
        public frmReportAlarms()
        {
            InitializeComponent();
            dtpStartTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dtpEndTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            this.KeyPreview = true;
            this.KeyDown += FrmReportIn_KeyDown;
            dgvData.SelectionChanged += DgvData_SelectionChanged;
            dgvData.CellContentClick += DgvData_CellContentClick;
            ucPages1.OnpageSelect += UcPages1_OnpageSelect;
            ucEventInInfo1.onBackClickEvent += UcEventInfo1_onBackClickEvent;

            this.Load += FrmReportIn_Load;
            this.SizeChanged += FrmReportIn_SizeChanged;
            this.FormClosing += FrmReportAlarms_FormClosing;
        }

        private void FrmReportAlarms_FormClosing(object? sender, FormClosingEventArgs e)
        {
            lanes?.Clear();
            identityGroups?.Clear();
            registerVehicles?.Clear();
            customers?.Clear();
        }

        private async void FrmReportIn_Load(object? sender, EventArgs e)
        {
            //registerVehicles = await KzParkingApiHelper.GetRegisteredVehicles("");

            registerVehicles = (await  AppData.ApiServer.GetRegisterVehiclesAsync("")).Item1;

            //customers = (await KzParkingApiHelper.GetAllCustomers())?.Item1 ?? new List<Customer>();
            customers = (await  AppData.ApiServer.GetCustomersAsync())?.Item1 ?? new List<Customer>();

            //identityGroups = await KzParkingApiHelper.GetIdentityGroupsAsync() ?? new List<IdentityGroup>();
            identityGroups = (await  AppData.ApiServer.GetIdentityGroupsAsync()).Item1 ?? new List<IdentityGroup>();

            picOverviewImageIn.Image = picVehicleImageIn.Image = defaultImg;
            await CreateUI();
            this.ActiveControl = btnSearch;
            btnSearch.PerformClick();
        }
        private void FrmReportIn_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnSearch.PerformClick();
            }
        }
        private void FrmReportIn_SizeChanged(object? sender, EventArgs e)
        {
            if (ucPages1.Visible)
            {
                dgvData.Height = btnCancel.Location.Y - dgvData.Location.Y - TextManagement.ROOT_SIZE * 2 - ucPages1.Height;
            }
            else
            {
                dgvData.Height = btnCancel.Location.Y - dgvData.Location.Y - TextManagement.ROOT_SIZE * 2;
            }
            tablePic.Height = dgvData.Height;
            tablePic.Width = tablePic.Height * 9 / 16;
            dgvData.Width = this.DisplayRectangle.Width - TextManagement.ROOT_SIZE * 5 - tablePic.Width;

            tablePic.Location = new Point(panelData.Width - tablePic.Width - TextManagement.ROOT_SIZE * 2,
                                          dgvData.Location.Y);

            lblTotalEvents.Location = new Point(btnSearch.Location.X + btnSearch.Width + TextManagement.ROOT_SIZE,
                                               btnSearch.Location.Y - lblTotalEvents.Height + btnSearch.Height);
            ucPages1.Width = panelData.Width - TextManagement.ROOT_SIZE * 4;
            ucPages1.Location = new Point(dgvData.Location.X, dgvData.Location.Y + dgvData.Height + TextManagement.ROOT_SIZE);
        }
        #endregion End Forms

        #region Controls In Form
        private async void btnSearch_Click(object? sender, EventArgs e)
        {
            EnableFastLoading();

            string keyword = txtKeyword.Text;
            DateTime startTime = dtpStartTime.Value;
            DateTime endTime = dtpEndTime.Value;
            string vehicleTypeId = ((ListItem)cbVehicleType.SelectedItem)?.Value ?? "";
            string laneId = ((ListItem)cbLane.SelectedItem)?.Value ?? "";
            //var alarmData = await KzParkingApiHelper.GetAlarms(keyword, startTime, endTime, "", vehicleTypeId, laneId);
            var dtAlarm = await  AppData.ApiServer.GetAlarmReport(keyword, startTime, endTime, "", vehicleTypeId, laneId);
            if (dtAlarm == null)
            {
                DisableFastLoading();
                ucNotify1.Show(ucNotify.EmNotiType.Error, "Không tải được thông tin xe trong bãi. Vui lòng thử lại!");
                ucNotify1.OnSelectResultEvent += UcNotify1_OnSelectResultEvent;
                return;
            }

            totalPages = 1;// alarmData.Item2;
            totalEvents = dtAlarm.Rows.Count;
            List<AbnormalEvent> abnormalEvent = new List<AbnormalEvent>();
            //foreach (DataRow row in dtAlarm.Rows)
            //{
            //    AbnormalEvent ev = new AbnormalEvent()
            //    {
            //        identityId = row["identityid"].ToString(),
            //        plateNumber = row["platenumber"].ToString(),
            //        createdUtc = row["createdutc"].ToString(),
            //        laneId = row["laneId"].ToString(),
            //        createdBy = "",
            //        fileKeys = row["filekeys"].ToString()?.Split(","),
            //        CustomerId = dtAlarm.Columns.Contains("customerid") ? row["customerid"].ToString() : "",
            //        RegisteredVehicleId = eventInData.Columns.Contains("vehicleid") ? row["vehicleid"].ToString() : "",
            //        IdentityGroupId = row["identitygroupid"].ToString(),
            //        identityCode = dtAlarm.Columns.Contains("identityCode") ? row["identityCode"].ToString() : "",
            //        identityName = dtAlarm.Columns.Contains("identityName") ? row["identityName"].ToString() : "",
            //        TransactionType = dtAlarm.Columns.Contains("transactiontype") ? int.Parse(row["transactiontype"].ToString() ?? "0") : 0,
            //        TransactionCode = dtAlarm.Columns.Contains("transactioncode") ? row["transactioncode"].ToString() : "",
            //    };
            //    abnormalEvent.Add(ev);
            //}

            DisplayNavigation();
            DisplayEventInData(abnormalEvent);
            DisableFastLoading();

            abnormalEvent.Clear();
        }

        private void btnExportExcel_Click(object? sender, EventArgs e)
        {
            ExcelTools.CreatReportFile(dgvData, "Báo cáo Xe Đang Trong Bãi", new List<string>() { });
        }
        private void btnCancel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private async void DgvData_SelectionChanged(object? sender, EventArgs e)
        {
            try
            {
                string physicalFileId = dgvData.CurrentRow?.Cells[dgvData.ColumnCount - 8].Value.ToString() ?? "";
                string[] physicalFileIds = physicalFileId.Split(';');
                if (physicalFileIds.Length >= 2)
                {
                    string displayOverviewInPath = await MinioHelper.GetImage(physicalFileIds[0]);
                    string vehicleInPath = await MinioHelper.GetImage(physicalFileIds[1]);
                    Task task1 = ShowImage(physicalFileIds[0], picOverviewImageIn);
                    Task task2 = ShowImage(physicalFileIds[1], picVehicleImageIn);
                    await Task.WhenAll(task1, task2);
                }
                else if (physicalFileIds.Length > 0)
                {
                    await ShowImage(physicalFileIds[0], picOverviewImageIn);
                    this.Invoke(() =>
                    {
                        picVehicleImageIn.Image = defaultImg;
                    });
                }
                else
                {
                    this.Invoke(() =>
                    {
                        picOverviewImageIn.Image = defaultImg;
                        picVehicleImageIn.Image = defaultImg;
                    });
                }
            }
            catch (Exception)
            {
            }

        }
        private void DgvData_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvData.ColumnCount - 1 && e.RowIndex >= 0)
            {
                panelData.BackColor = Color.FromArgb((int)(0.37 * 255), 42, 47, 48);
                foreach (Control item in panelData.Controls)
                {
                    if (item is UserControl)
                    {
                        continue;
                    }
                    else if (item is IDesignControl)
                    {
                        ((IDesignControl)item).EnableWaitMode();
                    }
                    else if (!ControlExtensions.IsSupportsTransparency(item))
                    {
                        item.Enabled = true;
                        continue;
                    }
                }

                string identityId = dgvData.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "";
                string plateNumber = dgvData.Rows[e.RowIndex].Cells[2].Value?.ToString() ?? "";
                string datetimeIn = dgvData.Rows[e.RowIndex].Cells[3].Value?.ToString() ?? "";
                string laneID = dgvData.Rows[e.RowIndex].Cells[5].Value?.ToString() ?? "";
                string createdById = dgvData.Rows[e.RowIndex].Cells[6].Value?.ToString() ?? "";
                string customerID = dgvData.Rows[e.RowIndex].Cells[8].Value?.ToString() ?? "";
                string regiterVehicleId = dgvData.Rows[e.RowIndex].Cells[9].Value?.ToString() ?? "";
                ucEventInInfo1.ShowInfo(new Point((this.Width - ucEventInInfo1.Width) / 2, (this.Height - ucEventInInfo1.Height) / 2), laneID, datetimeIn, plateNumber, identityId, createdById, customerID, regiterVehicleId);
                this.ActiveControl = ucEventInInfo1;
            }
        }

        private void UcPages1_OnpageSelect(int pageIndex)
        {
            this.Invoke(new Action(async () =>
            {
                picOverviewImageIn.Image = defaultImg;
                picVehicleImageIn.Image = defaultImg;

                //panelData.SuspendLayout();
                //picOverviewImageIn.Image = frmMain.defaultImage;
                //picVehicleImageIn.Image = frmMain.defaultImage;
                //panelData.BackColor = Color.FromArgb((int)(0.37 * 255), 42, 47, 48);
                //foreach (Control item in panelData.Controls)
                //{
                //    if (item is ucLoading)
                //    {
                //        continue;
                //    }
                //    else if (item is ucNotify)
                //    {
                //        continue;
                //    }
                //    if (item is IDesignControl)
                //    {
                //        ((IDesignControl)item).EnableWaitMode();
                //    }
                //    else if (!ControlExtensions.IsSupportsTransparency(item))
                //    {
                //        item.Enabled = true;
                //        continue;
                //    }
                //}
                //ucLoading1.Show("Đang tải thông tin xe trong bãi", frmMain.language);
                //panelData.ResumeLayout();

                EnableFastLoading();

                string keyword = txtKeyword.Text;
                DateTime startTime = dtpStartTime.Value;
                DateTime endTime = dtpEndTime.Value;
                string vehicleTypeId = ((ListItem)cbVehicleType.SelectedItem)?.Value ?? "";
                string laneId = ((ListItem)cbLane.SelectedItem)?.Value ?? "";

                Application.DoEvents();
                Tuple<List<AbnormalEvent>, int, int> abnormalEvent = null;// await AppData.ApiServer.GetAlarmReport(keyword, startTime, endTime, "", vehicleTypeId, laneId, pageIndex);

                if (abnormalEvent.Item1 == null)
                {
                    DisableFastLoading();
                    //panelData.BackColor = Color.White;
                    ucLoading1.HideLoading();
                    ucNotify1.Show(ucNotify.EmNotiType.Error, "Không tải được thông tin xe trong bãi. Vui lòng thử lại!");
                    ucNotify1.OnSelectResultEvent += UcNotify1_OnSelectResultEvent;
                    return;
                }

                EnableFastLoading();

                totalPages = abnormalEvent.Item2;
                totalEvents = abnormalEvent.Item3;

                List<AbnormalEvent> eventInReports = abnormalEvent.Item1 ?? new List<AbnormalEvent>();
                DisplayEventInData(eventInReports);
                DisableFastLoading();

                //panelData.BackColor = Color.White;
                //ucLoading1.HideLoading();
                //foreach (Control item in panelData.Controls)
                //{
                //    if (item is ucLoading)
                //    {
                //        continue;
                //    }
                //    else if (item is ucNotify)
                //    {
                //        continue;
                //    }
                //    else if (item is IDesignControl)
                //    {
                //        ((IDesignControl)item).Reset();
                //    }
                //    else if (!ControlExtensions.IsSupportsTransparency(item))
                //    {
                //        item.Enabled = true;
                //        continue;
                //    }
                //}

                eventInReports.Clear();
            }));

        }
        private void UcNotify1_OnSelectResultEvent(DialogResult result)
        {
            //ucEventInInfo1.onBackClickEvent -= UcEventInfo1_onBackClickEvent;
            //foreach (Control item in panelData.Controls)
            //{
            //    if (item is ucLoading)
            //    {
            //        continue;
            //    }
            //    else if (item is ucNotify)
            //    {
            //        continue;
            //    }
            //    else if (item is IDesignControl)
            //    {
            //        ((IDesignControl)item).Reset();
            //    }
            //    else if (!ControlExtensions.IsSupportsTransparency(item))
            //    {
            //        item.Enabled = true;
            //        continue;
            //    }
            //}
        }
        private void UcEventInfo1_onBackClickEvent(object sender)
        {
            panelData.BackColor = Color.White;
            this.Invoke(new Action(() =>
            {
                foreach (Control item in panelData.Controls)
                {
                    if (item is UserControl)
                    {
                        continue;
                    }
                    if (item is IDesignControl)
                    {
                        ((IDesignControl)item).Reset();
                    }
                    else if (!ControlExtensions.IsSupportsTransparency(item))
                    {
                        item.Enabled = true;
                        continue;
                    }
                }
            }));
        }
        #endregion End Controls In Form

        #region Private Function
        private async Task CreateUI()
        {
            btnCancel.InitControl(btnCancel_Click);
            btnExportExcel.InitControl(btnExportExcel_Click);
            btnSearch.InitControl(btnSearch_Click);
            panelData.ToggleDoubleBuffered(true);

            lblKeyword.Location = new Point(TextManagement.ROOT_SIZE * 2, TextManagement.ROOT_SIZE * 2);
            txtKeyword.Location = new Point(lblKeyword.Location.X + lblKeyword.Width + TextManagement.ROOT_SIZE,
                                            lblKeyword.Location.Y + (lblKeyword.Height - txtKeyword.Height) / 2);

            lblAbNormalType.Location = new Point(txtKeyword.Location.X + txtKeyword.Width + TextManagement.ROOT_SIZE,
                                                 lblKeyword.Location.Y);
            cbAbNormalType.Location = new Point(lblAbNormalType.Location.X + lblEndTime.Width + TextManagement.ROOT_SIZE,
                                                txtKeyword.Location.Y);

            dtpStartTime.Location = new Point(txtKeyword.Location.X, txtKeyword.Location.Y + txtKeyword.Height + TextManagement.ROOT_SIZE);
            lblStartTime.Location = new Point(lblKeyword.Location.X,
                                              dtpStartTime.Location.Y + (dtpStartTime.Height - lblStartTime.Height) / 2);

            lblEndTime.Location = new Point(lblAbNormalType.Location.X, lblStartTime.Location.Y);
            dtpEndTime.Location = new Point(cbAbNormalType.Location.X, dtpStartTime.Location.Y);

            cbVehicleType.Location = new Point(txtKeyword.Location.X, dtpStartTime.Location.Y + dtpStartTime.Height + TextManagement.ROOT_SIZE);
            lblVehicleType.Location = new Point(lblKeyword.Location.X,
                                               cbVehicleType.Location.Y + (cbVehicleType.Height - lblVehicleType.Height) / 2);

            lblLane.Location = new Point(lblAbNormalType.Location.X, lblVehicleType.Location.Y);
            cbLane.Location = new Point(cbAbNormalType.Location.X, cbVehicleType.Location.Y);

            btnSearch.Location = new Point(cbLane.Location.X + cbLane.Width + TextManagement.ROOT_SIZE,
                                           cbLane.Location.Y + (cbLane.Height - btnSearch.Height));

            btnCancel.Location = new Point(panelData.Width - btnCancel.Width - TextManagement.ROOT_SIZE * 2,
                                           panelData.Height - btnCancel.Height - TextManagement.ROOT_SIZE * 2);
            btnExportExcel.Location = new Point(btnCancel.Location.X - btnExportExcel.Width - TextManagement.ROOT_SIZE,
                                                btnCancel.Location.Y);

            ucPages1.Location = new Point(TextManagement.ROOT_SIZE * 2, btnCancel.Location.Y - ucPages1.Height - TextManagement.ROOT_SIZE);
            ucPages1.Width = panelData.Width - StaticPool.baseSize * 4;

            dgvData.Location = new Point(TextManagement.ROOT_SIZE * 2, cbVehicleType.Location.Y + cbVehicleType.Height + TextManagement.ROOT_SIZE);

            if (ucPages1.Visible)
            {
                dgvData.Height = ucPages1.Location.Y - dgvData.Location.Y - TextManagement.ROOT_SIZE * 2;
            }
            else
            {
                dgvData.Height = ucPages1.Location.Y + ucPages1.Height - dgvData.Location.Y - TextManagement.ROOT_SIZE * 2;
            }
            tablePic.Height = dgvData.Height;
            tablePic.Width = tablePic.Height * 9 * 2 / 16;

            dgvData.Width = this.DisplayRectangle.Width - TextManagement.ROOT_SIZE * 5 - tablePic.Width;

            tablePic.Location = new Point(panelData.Width - tablePic.Width - TextManagement.ROOT_SIZE * 2,
                                          dgvData.Location.Y);

            lblTotalEvents.Location = new Point(btnSearch.Location.X + btnSearch.Width + TextManagement.ROOT_SIZE,
                                                btnSearch.Location.Y - lblTotalEvents.Height + btnSearch.Height);

            cbVehicleType.DisplayMember = cbAbNormalType.DisplayMember = cbLane.DisplayMember = "Name";
            cbVehicleType.ValueMember = cbAbNormalType.ValueMember = cbLane.ValueMember = "Value";

            await LoadVehicleTypeData();
            await LoadLaneType();
        }
        private void DisableFastLoading()
        {
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            SendMessage(dgvData.Handle, WM_SETREDRAW, true, 0);
            dgvData.Refresh();
        }
        private void EnableFastLoading()
        {
            dgvData.Rows.Clear();
            dgvData.Refresh();

            SendMessage(dgvData.Handle, WM_SETREDRAW, false, 0);
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }
        private void DisplayNavigation()
        {
            lblTotalEvents.Visible = true;
            lblTotalEvents.Text = "Tổng số sự kiện: " + totalEvents;
            lblTotalEvents.Refresh();
            ucPages1.Visible = totalPages > 1;
            ucPages1.UpdateMaxPage(totalPages);

            if (ucPages1.Visible)
            {
                dgvData.Height = btnCancel.Location.Y - dgvData.Location.Y - TextManagement.ROOT_SIZE * 2 - ucPages1.Height;
            }
            else
            {
                dgvData.Height = btnCancel.Location.Y - dgvData.Location.Y - TextManagement.ROOT_SIZE * 2;
            }
            tablePic.Height = dgvData.Height;
            tablePic.Width = tablePic.Height * 9 / 16;
            dgvData.Width = this.DisplayRectangle.Width - TextManagement.ROOT_SIZE * 5 - tablePic.Width;

            tablePic.Location = new Point(panelData.Width - tablePic.Width - TextManagement.ROOT_SIZE * 2,
                                          dgvData.Location.Y);

            lblTotalEvents.Location = new Point(btnSearch.Location.X + btnSearch.Width + TextManagement.ROOT_SIZE,
                                               btnSearch.Location.Y - lblTotalEvents.Height + btnSearch.Height);
            ucPages1.Width = panelData.Width - TextManagement.ROOT_SIZE * 4;
            ucPages1.Location = new Point(dgvData.Location.X, dgvData.Location.Y + dgvData.Height + TextManagement.ROOT_SIZE);
            panelData.Refresh();
        }
        private void DisplayEventInData(List<AbnormalEvent> abnomalEvent)
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (var item in abnomalEvent)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvData);
                int i = 0;
                row.Cells[i++].Value = (rows.Count + 1).ToString();//0
                row.Cells[i++].Value = item.IdentityId;            //1
                row.Cells[i++].Value = item.PlateNumber;           //2
                row.Cells[i++].Value = item.AlarmTime?.ToString("dd/MM/yyyy HH:mm:ss"); //3
                row.Cells[i++].Value = item.GetAbnormalStr();//("dd/MM/yyyy HH:mm:ss"); //4
                row.Cells[i++].Value = item.LaneId;                //5
                row.Cells[i++].Value = item.CreatedBy;             //6
                row.Cells[i++].Value = item.FileKeys?.Count > 0 ? string.Join(";", item.FileKeys) : "";//7
                row.Cells[i++].Value = item.CustomerId;//8
                row.Cells[i++].Value = item.RegisteredVehicleId;//8
                row.Cells[i++].Value = GetLaneName(item.LaneId);//7
                row.Cells[i++].Value = GetIdentityGroupName(item.IdentityGroupId);//9
                row.Cells[i++].Value = GetRegisterVehiclePlate(item.RegisteredVehicleId);//10
                row.Cells[i++].Value = GetCustomer(item.CustomerId);//11
                row.Cells[i++].Value = "Xem Thêm";
                rows.Add(row);
            }
            dgvData.Rows.AddRange(rows.ToArray());
            if (dgvData.RowCount > 0)
            {
                dgvData.CurrentCell = dgvData.Rows[0].Cells[0];
            }
        }

        private async Task ShowImage(string fileKey, PictureBox pic)
        {
            if (!string.IsNullOrEmpty(fileKey))
            {
                string displayPath = await MinioHelper.GetImage(fileKey);
                if (!string.IsNullOrEmpty(displayPath))
                {
                    pic.LoadAsync(displayPath);
                    return;
                }
            }
            pic.Image = defaultImg;
        }
        private async Task LoadVehicleTypeData()
        {
            cbVehicleType.DisplayMember = "Name";
            cbVehicleType.ValueMember = "Value";

            cbVehicleType.Invoke(new Action(() =>
            {
                cbVehicleType.Items.Add(new ListItem()
                {
                    Name = "Tất cả",
                    Value = ""
                });
            }));


            //var vehicleTypes = await KzParkingApiHelper.GetAllVehicleTypes() ?? new List<iParkingv5.Objects.Enums.VehicleType>();
            var vehicleTypes = (await  AppData.ApiServer.GetVehicleTypesAsync()).Item1 ?? new List<iParkingv5.Objects.Enums.VehicleType>();
            cbVehicleType.Invoke(new Action(() =>
            {
                foreach (var item in vehicleTypes)
                {
                    ListItem vehicleTypeItem = new ListItem()
                    {
                        Name = item.Name,
                        Value = item.Id.ToString()
                    };
                    cbVehicleType.Items.Add(vehicleTypeItem);
                }
                cbVehicleType.SelectedIndex = 0;
            }));
        }
        private async Task LoadLaneType()
        {
            cbLane.DisplayMember = "Name";
            cbLane.ValueMember = "Value";

            cbLane.Invoke(new Action(() =>
            {
                cbLane.Items.Add(new ListItem()
                {
                    Name = "Tất cả",
                    Value = ""
                });
            }));

            //lanes = await KzParkingApiHelper.GetLanesAsync() ?? new List<iParkingv6.Objects.Datas.Lane>();
            lanes = (await  AppData.ApiServer.GetLanesAsync()).Item1 ?? new List<Lane>();
            cbLane.Invoke(new Action(() =>
            {
                foreach (var item in lanes)
                {
                    ListItem laneItem = new ListItem()
                    {
                        Name = item.name,
                        Value = item.id
                    };
                    cbLane.Items.Add(laneItem);
                }
                cbLane.SelectedIndex = 0;
            }));
        }

        private string GetLaneName(string laneId)
        {
            if (string.IsNullOrEmpty(laneId))
            {
                return string.Empty;
            }
            if (lanes == null)
            {
                return string.Empty;
            }
            Lane? selectedLane = lanes.Where(lane => lane.id == laneId).FirstOrDefault();
            return selectedLane == null ? "" : selectedLane.name;
        }
        private string GetIdentityGroupName(string identityGroupId)
        {
            if (string.IsNullOrEmpty(identityGroupId))
            {
                return string.Empty;
            }
            if (identityGroups == null)
            {
                return string.Empty;
            }
            IdentityGroup? selectedIdentityGroup = identityGroups.Where(e => e.Id.ToString() == identityGroupId).FirstOrDefault();
            return selectedIdentityGroup == null ? "" : selectedIdentityGroup.Name;
        }
        private string GetRegisterVehiclePlate(string registerVehicleId)
        {
            if (string.IsNullOrEmpty(registerVehicleId))
            {
                return string.Empty;
            }
            if (registerVehicles == null)
            {
                return string.Empty;
            }
            var registerVehicle = registerVehicles.Where(e => e.Id == registerVehicleId).FirstOrDefault();
            return registerVehicle?.PlateNumber ?? "";
        }
        private string GetCustomer(string customerID)
        {
            if (string.IsNullOrEmpty(customerID))
            {
                return string.Empty;
            }
            if (customers == null)
            {
                return string.Empty;
            }
            Customer? customer = customers.Where(e => e.Id == customerID).FirstOrDefault();
            return customer == null ? "" : customer.Name + " / " + customer.PhoneNumber;
        }
        #endregion End Private Function
    }
}