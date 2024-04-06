using IPaking.Ultility;
using iPakrkingv5.Controls;
using iPakrkingv5.Controls.Controls.Buttons;
using iParkingv5.Objects;
using iParkingv5.Objects.Databases;
using iParkingv5.Objects.Datas;
using iParkingv5_window.Forms.DataForms;
using iParkingv5_window.Usercontrols;
using iParkingv5_window.Usercontrols.BuildControls;
using iParkingv6.ApiManager.KzParkingv3Apis;
using iParkingv6.Objects.Datas;
using Kztek.Tool.TextFormatingTools;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static iParkingv5.Objects.Enums.PrintHelpers;
using static iParkingv6.ApiManager.KzParkingv3Apis.KzParkingApiHelper;

namespace iParkingv5_window.Forms.ReportForms
{
    public partial class frmReportInOut : Form
    {
        #region Properties
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;
        private int totalPages = 0;
        private int totalEvents = 0;

        private List<Lane> lanes = new List<Lane>();
        private List<IdentityGroup> identityGroups = new List<IdentityGroup>();
        private List<RegisteredVehicle> registerVehicles = new List<RegisteredVehicle>();
        private List<Customer> customers = new List<Customer>();
        #endregion End Properties

        #region Forms
        public frmReportInOut()
        {
            InitializeComponent();
            dtpStartTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dtpEndTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            this.KeyPreview = true;
            dgvData.SelectionChanged += DgvData_SelectionChanged;
            dgvData.CellContentClick += DgvData_CellContentClick;
            ucPages1.OnpageSelect += UcPages1_OnpageSelect;
            ucEventOutInfo1.onBackClickEvent += UcEventInInfo1_onBackClickEvent;

            lblMoney.Text = "Tổng Số: " + TextFormatingTool.GetMoneyFormat("0");

            this.ToggleDoubleBuffered(true);
            panelData.ToggleDoubleBuffered(true);

            this.Load += FrmReportInOut_Load;
            this.KeyDown += FrmReportInOut_KeyDown;
            this.SizeChanged += FrmReportInOut_SizeChanged;
        }
        private async void FrmReportInOut_Load(object? sender, EventArgs e)
        {
            registerVehicles = await KzParkingApiHelper.GetRegisteredVehicles("");
            customers = (await KzParkingApiHelper.GetAllCustomers())?.Item1 ?? new List<Customer>();
            CreateUI();
            this.ActiveControl = btnSearch;
            btnSearch.PerformClick();
        }
        private void FrmReportInOut_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnSearch_Click(null, null);
            }
        }
        private void FrmReportInOut_SizeChanged(object? sender, EventArgs e)
        {
            dgvData.Location = new Point(TextManagement.ROOT_SIZE * 2, cbVehicleType.Location.Y + cbVehicleType.Height + TextManagement.ROOT_SIZE);

            if (ucPages1.Visible)
            {
                dgvData.Height = ucPages1.Location.Y - dgvData.Location.Y - TextManagement.ROOT_SIZE * 2 - lblMoney.Height - 16;
            }
            else
            {
                dgvData.Height = ucPages1.Location.Y + ucPages1.Height - dgvData.Location.Y - TextManagement.ROOT_SIZE * 2 - lblMoney.Height;
            }
            tablePic.Height = dgvData.Height;
            tablePic.Width = tablePic.Height * 9 * 2 / 16;

            dgvData.Width = this.DisplayRectangle.Width - StaticPool.baseSize * 5 - tablePic.Width;

            tablePic.Location = new Point(panelData.Width - tablePic.Width - StaticPool.baseSize * 2,
                                          dgvData.Location.Y);

            lblTotalEvents.Location = new Point(btnSearch.Location.X + btnSearch.Width + TextManagement.ROOT_SIZE,
                                             btnSearch.Location.Y - lblTotalEvents.Height + btnSearch.Height);
            lblMoney.Location = new Point(dgvData.Location.X + (dgvData.Width - lblMoney.Width), dgvData.Location.Y + dgvData.Height + 16);

            this.Refresh();
        }
        #endregion End Forms

        #region Controls In Form
        public static Image defaultImg = Image.FromFile(frmMain.defaultImagePath);
        private async void btnSearch_Click(object? sender, EventArgs e)
        {
            EnableFastLoading();

            string keyword = txtKeyword.Text;
            DateTime startTime = dtpStartTime.Value;
            DateTime endTime = dtpEndTime.Value;
            string vehicleTypeId = ((ListItem)cbVehicleType.SelectedItem)?.Value ?? "";
            string identityGroupId = ((ListItem)cbIdentityGroup.SelectedItem)?.Value ?? "";
            string laneId = ((ListItem)cbLane.SelectedItem)?.Value ?? "";

            Tuple<List<EventOutReport>, int, int> eventOutReport = await KzParkingApiHelper.GetEventOuts(keyword, startTime, endTime, identityGroupId, vehicleTypeId, laneId);

            if (eventOutReport.Item1 == null)
            {
                DisableFastLoading();
                ucNotify1.Show(ucNotify.EmNotiType.Error, "Không tải được thông tin xe trong bãi. Vui lòng thử lại!");
                return;
            }
            try
            {
                long? money = await KzParkingApiHelper.GetSummary(startTime, endTime);
                if (money == null)
                {
                    lblMoney.Text = "Tổng Số: _";
                }
                else
                {
                    lblMoney.Text = "Tổng Số: " + TextFormatingTool.GetMoneyFormat(money!.ToString());
                }
                lblMoney.Location = new Point(dgvData.Location.X + (dgvData.Width - lblMoney.Width), dgvData.Location.Y + dgvData.Height + 16);
            }
            catch (Exception)
            {
            }

            totalPages = eventOutReport.Item2;
            totalEvents = eventOutReport.Item3;
            List<EventOutReport> eventOutData = eventOutReport.Item1 ?? new List<EventOutReport>();
            DisplayNavigation();
            await DisplayEventOutData(eventOutData);
            DisableFastLoading();
            eventOutData.Clear();
        }
        private void btnCancel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
        private void btnExportExcel_Click(object? sender, EventArgs e)
        {
            ExcelTools.CreatReportFile(dgvData, "Báo cáo Xe Ra Khỏi Bãi");
        }
        private async void DgvData_SelectionChanged(object? sender, EventArgs e)
        {
            try
            {
                string physicalFileOutId = dgvData.CurrentRow?.Cells[dgvData.ColumnCount - 7].Value?.ToString() ?? "";
                string[] physicalFileIdOuts = physicalFileOutId.Split(';');
                if (physicalFileIdOuts.Length >= 2)
                {
                    await ShowImage(physicalFileIdOuts[0], picOverviewImageOut);
                    await ShowImage(physicalFileIdOuts[1], picVehicleImageOut);
                }
                else if (physicalFileIdOuts.Length > 0)
                {
                    await ShowImage(physicalFileIdOuts[0], picOverviewImageOut);
                    this.Invoke(new Action(() =>
                    {
                        picVehicleImageOut.Image = defaultImg;
                    }));
                }
                else
                {
                    this.Invoke(new Action(() =>
                    {
                        picOverviewImageOut.Image = defaultImg;
                        picVehicleImageOut.Image = defaultImg;
                    }));
                }

                string physicalFileInId = dgvData.CurrentRow?.Cells[dgvData.ColumnCount - 8].Value?.ToString() ?? "";
                string[] physicalFileIdIns = physicalFileInId.Split(';');
                if (physicalFileIdIns.Length >= 2)
                {
                    await ShowImage(physicalFileIdIns[0], picOverviewImageIn);
                    await ShowImage(physicalFileIdIns[1], picVehicleImageIn);
                }
                else if (physicalFileIdIns.Length > 0)
                {
                    await ShowImage(physicalFileIdIns[0], picOverviewImageIn);
                    this.Invoke(new Action(() =>
                    {
                        picVehicleImageIn.Image = defaultImg;
                    }));
                }
                else
                {
                    this.Invoke(new Action(() =>
                    {
                        picOverviewImageIn.Image = defaultImg;
                        picVehicleImageIn.Image = defaultImg;
                    }));
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
                this.SuspendLayout();
                panelData.BackColor = Color.FromArgb((int)(0.37 * 255), 42, 47, 48);
                foreach (Control item in panelData.Controls)
                {
                    if (item is UserControl)
                    {
                        continue;
                    }
                    if (item is IDesignControl)
                    {
                        ((IDesignControl)item).EnableWaitMode();
                    }
                    else if (!ControlExtensions.IsSupportsTransparency(item))
                    {
                        item.Enabled = false;
                        continue;
                    }
                }
                this.ResumeLayout();

                string identityIdOut = dgvData.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "";
                string identityIdIn = dgvData.Rows[e.RowIndex].Cells[2].Value?.ToString() ?? "";

                string plateNumberIn = dgvData.Rows[e.RowIndex].Cells[3].Value?.ToString() ?? "";
                string plateNumberOut = dgvData.Rows[e.RowIndex].Cells[4].Value?.ToString() ?? "";

                string datetimeIn = dgvData.Rows[e.RowIndex].Cells[5].Value?.ToString() ?? "";
                string datetimeOut = dgvData.Rows[e.RowIndex].Cells[6].Value?.ToString() ?? "";

                string eventInLaneId = dgvData.Rows[e.RowIndex].Cells[7].Value?.ToString() ?? "";
                string laneIDOut = dgvData.Rows[e.RowIndex].Cells[8].Value?.ToString() ?? "";

                string createdById = dgvData.Rows[e.RowIndex].Cells[9].Value?.ToString() ?? "";
                string createdByInId = dgvData.Rows[e.RowIndex].Cells[10].Value?.ToString() ?? "";
                ucEventOutInfo1.ShowInfo(new Point((this.Width - ucEventOutInfo1.Width) / 2, (this.Height - ucEventOutInfo1.Height) / 2), eventInLaneId, datetimeIn, plateNumberIn, identityIdIn, createdByInId,
                                                         laneIDOut, datetimeOut, plateNumberOut, identityIdOut, createdById);
            }
        }
        private void UcPages1_OnpageSelect(int pageIndex)
        {
            this.Invoke(new Action(async () =>
            {
                EnableFastLoading();

                string keyword = txtKeyword.Text;
                DateTime startTime = dtpStartTime.Value;
                DateTime endTime = dtpEndTime.Value;
                string vehicleTypeId = ((ListItem)cbVehicleType.SelectedItem)?.Value ?? "";
                string identityGroupId = ((ListItem)cbIdentityGroup.SelectedItem)?.Value ?? "";
                string laneId = ((ListItem)cbLane.SelectedItem)?.Value ?? "";

                Tuple<List<EventOutReport>, int, int> eventOutReport = await KzParkingApiHelper.GetEventOuts(keyword, startTime, endTime, identityGroupId, vehicleTypeId, laneId, pageIndex);

                if (eventOutReport.Item1 == null)
                {
                    DisableFastLoading();
                    panelData.BackColor = Color.White;
                    ucLoading1.HideLoading();
                    ucNotify1.Show(ucNotify.EmNotiType.Error, "Không tải được thông tin xe trong bãi. Vui lòng thử lại!");
                    ucNotify1.OnSelectResultEvent += UcNotify1_OnSelectResultEvent;
                    return;
                }

                EnableFastLoading();

                totalPages = eventOutReport.Item2;
                totalEvents = eventOutReport.Item3;
                List<EventOutReport> eventOutData = eventOutReport.Item1 ?? new List<EventOutReport>();
                await DisplayEventOutData(eventOutData);
                DisableFastLoading();
                eventOutData.Clear();
            }));
        }
        private void UcNotify1_OnSelectResultEvent(DialogResult result)
        {
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
                else if (!ControlExtensions.IsSupportsTransparency(item))
                {
                    item.Enabled = true;
                    continue;
                }
            }
        }
        private void UcEventInInfo1_onBackClickEvent(object sender)
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
        #endregion

        #region Private Function
        private async void CreateUI()
        {
            panelData.SuspendLayout();
            btnCancel.InitControl(btnCancel_Click);
            btnExportExcel.InitControl(btnExportExcel_Click);
            btnSearch.InitControl(btnSearch_Click);
            panelData.ToggleDoubleBuffered(true);

            lblKeyword.Location = new Point(StaticPool.baseSize * 2, StaticPool.baseSize * 2);
            txtKeyword.Location = new Point(lblKeyword.Location.X + lblKeyword.Width + StaticPool.baseSize,
                                            lblKeyword.Location.Y + (lblKeyword.Height - txtKeyword.Height) / 2);

            lblIdentityType.Location = new Point(txtKeyword.Location.X + txtKeyword.Width + StaticPool.baseSize, lblKeyword.Location.Y);
            cbIdentityGroup.Location = new Point(lblIdentityType.Location.X + lblIdentityType.Width + StaticPool.baseSize, txtKeyword.Location.Y);

            dtpStartTime.Location = new Point(txtKeyword.Location.X, txtKeyword.Location.Y + txtKeyword.Height + StaticPool.baseSize);
            lblStartTime.Location = new Point(lblKeyword.Location.X,
                                              dtpStartTime.Location.Y + (dtpStartTime.Height - lblStartTime.Height) / 2);

            lblEndTime.Location = new Point(lblIdentityType.Location.X, lblStartTime.Location.Y);
            dtpEndTime.Location = new Point(cbIdentityGroup.Location.X, dtpStartTime.Location.Y);

            cbVehicleType.Location = new Point(txtKeyword.Location.X, dtpStartTime.Location.Y + dtpStartTime.Height + StaticPool.baseSize);
            lblVehicleType.Location = new Point(lblKeyword.Location.X,
                                               cbVehicleType.Location.Y + (cbVehicleType.Height - lblVehicleType.Height) / 2);

            cbLane.Location = new Point(dtpEndTime.Location.X, cbVehicleType.Location.Y);
            lblLane.Location = new Point(lblEndTime.Location.X, lblVehicleType.Location.Y);

            btnSearch.Location = new Point(cbLane.Location.X + cbLane.Width + TextManagement.ROOT_SIZE,
                                          cbLane.Location.Y + cbLane.Height - btnSearch.Height);

            btnCancel.Location = new Point(panelData.Width - btnCancel.Width - StaticPool.baseSize * 2,
                                           panelData.Height - btnCancel.Height - StaticPool.baseSize * 2);
            btnExportExcel.Location = new Point(btnCancel.Location.X - btnExportExcel.Width - StaticPool.baseSize,
                                                btnCancel.Location.Y);

            ucPages1.Location = new Point(StaticPool.baseSize * 2, btnCancel.Location.Y - ucPages1.Height - StaticPool.baseSize);
            ucPages1.Width = panelData.Width - StaticPool.baseSize * 4;

            dgvData.Location = new Point(TextManagement.ROOT_SIZE * 2, cbVehicleType.Location.Y + cbVehicleType.Height + TextManagement.ROOT_SIZE);

            if (ucPages1.Visible)
            {
                dgvData.Height = ucPages1.Location.Y - dgvData.Location.Y - TextManagement.ROOT_SIZE * 2 - lblMoney.Height;
            }
            else
            {
                dgvData.Height = ucPages1.Location.Y + ucPages1.Height - dgvData.Location.Y - TextManagement.ROOT_SIZE * 2 - lblMoney.Height;
            }
            tablePic.Height = dgvData.Height;
            tablePic.Width = tablePic.Height * 9 * 2 / 16;

            dgvData.Width = this.DisplayRectangle.Width - StaticPool.baseSize * 5 - tablePic.Width;

            tablePic.Location = new Point(panelData.Width - tablePic.Width - StaticPool.baseSize * 2,
                                          dgvData.Location.Y);


            lblTotalEvents.Location = new Point(btnSearch.Location.X + btnSearch.Width + TextManagement.ROOT_SIZE,
                                                btnSearch.Location.Y - lblTotalEvents.Height + btnSearch.Height);
            lblMoney.Location = new Point(dgvData.Location.X + (dgvData.Width - lblMoney.Width), dgvData.Location.Y + dgvData.Height + 16);

            cbVehicleType.DisplayMember = cbIdentityGroup.DisplayMember = cbLane.DisplayMember = "Name";
            cbVehicleType.ValueMember = cbIdentityGroup.ValueMember = cbLane.ValueMember = "Value";

            await LoadVehicleTypeData();
            await LoadIdentityGroup();
            await LoadLaneType();
            panelData.ResumeLayout();
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
            if (totalPages > 1)
            {
                ucPages1.Visible = true;
                ucPages1.UpdateMaxPage(totalPages);
            }
            else
            {
                ucPages1.Visible = false;
            }
            FrmReportInOut_SizeChanged(null, null);
        }
        private async Task DisplayEventOutData(List<EventOutReport> eventOutData)
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (var item in eventOutData)
            {
                List<string?> physicalFileIdsIn = new List<string?>();
                if (item.eventInFileKeys != null)
                {
                    foreach (var eventInImageKey in item.eventInFileKeys)
                    {
                        physicalFileIdsIn.Add(eventInImageKey);
                    }
                }
                DataGridViewRow row = new DataGridViewRow();
                this.Invoke(new Action(() =>
                {
                    row.CreateCells(dgvData);
                }));
                int i = 0;
                row.Cells[i++].Value = (rows.Count + 1).ToString();   //0
                row.Cells[i++].Value = item.identityId;               //1
                row.Cells[i++].Value = item.eventInIdentityId;        //2

                row.Cells[i++].Value = item.eventInPlateNumber;       //4
                row.Cells[i++].Value = item.plateNumber;              //5

                row.Cells[i++].Value = item.DatetimeIn?.ToString("dd/MM/yyyy HH:mm:ss");  //6
                row.Cells[i++].Value = item.DatetimeOut?.ToString("dd/MM/yyyy HH:mm:ss"); //7

                row.Cells[i++].Value = item.eventInLaneId; //8
                row.Cells[i++].Value = item.laneId;        //9

                row.Cells[i++].Value = item.createdBy;     //10
                row.Cells[i++].Value = item.eventInCreatedBy;//11
                row.Cells[i++].Value = TextFormatingTool.GetMoneyFormat(item.charge.ToString());//11
                row.Cells[i++].Value = physicalFileIdsIn == null ? "" : string.Join(";", physicalFileIdsIn);//12
                row.Cells[i++].Value = item.fileKeys == null ? "" : string.Join(";", item.fileKeys);//13

                row.Cells[i++].Value = GetLaneName(item.laneId);//7
                row.Cells[i++].Value = GetLaneName(item.eventInLaneId);//7
                row.Cells[i++].Value = GetIdentityGroupName(item.IdentityGroupId);//8
                row.Cells[i++].Value = GetRegisterVehiclePlate(item.RegisteredVehicleId);//9
                row.Cells[i++].Value = GetCustomer(item.CustomerId);//10

                row.Cells[i++].Value = "Xem thêm";//13
                rows.Add(row);
            }
            this.Invoke(new Action(() =>
            {
                dgvData.Rows.AddRange(rows.ToArray());
            }));
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
            cbVehicleType.Invoke(new Action(() =>
            {
                cbVehicleType.Items.Add(new ListItem()
                {
                    Name = "Tất cả",
                    Value = ""
                });
            }));


            var vehicleTypes = await KzParkingApiHelper.GetAllVehicleTypes() ?? new List<iParkingv5.Objects.Enums.VehicleType>();
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
        private async Task LoadIdentityGroup()
        {
            cbIdentityGroup.DisplayMember = "Name";
            cbIdentityGroup.ValueMember = "Value";

            cbIdentityGroup.Invoke(new Action(() =>
            {
                cbIdentityGroup.Items.Add(new ListItem()
                {
                    Name = "Tất cả",
                    Value = ""
                });
            }));

            identityGroups = await KzParkingApiHelper.GetIdentityGroupsAsync() ?? new List<iParkingv5.Objects.Datas.IdentityGroup>();
            cbIdentityGroup.Invoke(new Action(() =>
            {
                foreach (var item in identityGroups)
                {
                    ListItem identityGroupItem = new ListItem()
                    {
                        Name = item.Name,
                        Value = item.Id.ToString()
                    };
                    cbIdentityGroup.Items.Add(identityGroupItem);
                }
                cbIdentityGroup.SelectedIndex = 0;
            }));

        }
        private async Task LoadLaneType()
        {
            cbLane.Invoke(new Action(() =>
            {
                cbLane.Items.Add(new ListItem()
                {
                    Name = "Tất cả",
                    Value = ""
                });
            }));

            lanes = await KzParkingApiHelper.GetLanesAsync() ?? new List<iParkingv6.Objects.Datas.Lane>();
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
            Lane? selectedLane = lanes.Where(lane => lane.id == laneId).FirstOrDefault();
            return selectedLane == null ? "" : selectedLane.name;
        }
        private string GetIdentityGroupName(string identityGroupId)
        {
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

        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip ctx = new ContextMenuStrip();
                ctx.Items.Add("In Vé Xe");
                ctx.ItemClicked += (sender, e) =>
                {
                    string printTemplatePath = PathManagement.appPrintTemplateConfigPath(((EmPrintTemplate)StaticPool.appOption.PrintTemplate).ToString());
                    if (File.Exists(printTemplatePath))
                    {
                        string printContent = GetPrintContent(File.ReadAllText(printTemplatePath),
                                                              DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));
                        var wbPrint = new WebBrowser();
                        wbPrint.DocumentCompleted += WbPrint_DocumentCompleted;
                        wbPrint.DocumentText = printContent;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy mẫu in", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                };
                var location = dgvData.PointToScreen(dgvData.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location);
                ctx.Show(dgvData, new Point(location.X - dgvData.Location.X, location.Y - dgvData.Location.Y));
            }
        }
        private string GetPrintContent(string baseContent,
                               DateTime dateTimeIn, DateTime dateTimeOut,
                               string companyTaxCode = "", string address = "",
                               string companyName = "", string kyHieuHoaDon = "",
                               string plate = "", string moneyStr = "", long moneyInt = 0, string receiveBillCode = "")
        {
            baseContent = baseContent.Replace("$companyTaxCode", companyTaxCode);
            baseContent = baseContent.Replace("$companyAddress", address);
            baseContent = baseContent.Replace("$companyName", companyName);
            baseContent = baseContent.Replace("$templateCode", kyHieuHoaDon);

            baseContent = baseContent.Replace("$day", DateTime.Now.Day.ToString("00"));
            baseContent = baseContent.Replace("$month", DateTime.Now.Month.ToString("00"));
            baseContent = baseContent.Replace("$year", DateTime.Now.Year.ToString("0000"));

            baseContent = baseContent.Replace("$datetimeIn", dateTimeIn.ToString("dd/MM/yyyy HH:mm:ss"));
            baseContent = baseContent.Replace("$datetimeOut", dateTimeOut.ToString("dd/MM/yyyy HH:mm:ss"));
            var ParkingTime = dateTimeOut - dateTimeIn;
            string formattedTime = "";
            if (ParkingTime.TotalDays > 1)
            {
                formattedTime = string.Format("{0} ngày {1} giờ {2} phút {3} giây", ParkingTime.Days, ParkingTime.Hours, ParkingTime.Minutes, ParkingTime.Seconds);
            }
            else
            {
                formattedTime = string.Format("{0} giờ {1} phút {2} giây", ParkingTime.Hours, ParkingTime.Minutes, ParkingTime.Seconds);
                //formattedTime = string.Format("{0:hh\\:mm\\:ss}", ParkingTime);
            }

            baseContent = baseContent.Replace("$parking_time", formattedTime);
            baseContent = baseContent.Replace("$plateNumber", plate);

            baseContent = baseContent.Replace("$money_int", moneyStr);

            baseContent = baseContent.Replace("$money_str", SayMoney.MISASaysMoney.MISASayMoney(moneyInt));

            baseContent = baseContent.Replace("$ReceiveBillCode", receiveBillCode);
            return baseContent;
        }
        private void WbPrint_DocumentCompleted(object? sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                var browser = (WebBrowser)sender!;
                browser.Print();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvData_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
