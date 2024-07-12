using IPaking.Ultility;
using iPakrkingv5.Controls;
using iPakrkingv5.Controls.Controls.Buttons;
using iParkingv5.ApiManager.KzParkingv5Apis;
using iParkingv5.Objects.Databases;
using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Datas.Device_service;
using iParkingv5.Objects.Datas.parking_service;
using iParkingv5.Objects.Datas.user_service;
using iParkingv5.Objects.Enums;
using iParkingv5.Objects.EventDatas;
using iParkingv5_window.Forms.DataForms;
using iParkingv5_window.Usercontrols.BuildControls;
using Kztek.Tool.TextFormatingTools;
using Kztek.Tools;
using System.Data;
using System.Data.SqlTypes;
using System.Runtime.InteropServices;

namespace iParkingv5_window.Forms.ReportForms
{
    public partial class frmReportIn : Form
    {

        const string col_event_id = "event_id";
        const string col_identity_id = "identity_id";
        const string col_lane_in_id = "lane_in_id";
        const string col_file_keys = "file_keys";
        const string col_customer_id = "customer_id";
        const string col_register_vehicle_id = "register_vehicle_id";
        const string col_index = "index";
        const string col_plate = "plate";
        const string col_time_in = "time_in";
        const string col_note = "note";
        const string col_identity_group_name = "identity_group_name";
        const string col_user = "user";
        const string col_lane_in_name = "lane_in_name";
        const string col_identity_name = "identity_name";
        const string col_identity_code = "identity_code";
        const string col_register_plate = "register_plate";
        const string col_customer = "customer";
        const string col_see_more = "see_more";

        #region Properties
        private List<Lane> lanes = new List<Lane>();
        private List<IdentityGroup> identityGroups = new List<IdentityGroup>();
        private List<RegisteredVehicle> registerVehicles = new List<RegisteredVehicle>();
        private List<Customer> customers = new List<Customer>();
        private List<User> users = new List<User>();
        public static Image defaultImg = Image.FromFile(frmMain.defaultImagePath);
        #endregion End Properties


        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;
        private int totalPages = 0;
        private int totalEvents = 0;
        private bool isAllowSelect = false;

        public string selectedEventId = string.Empty;
        public string selectedIdentityId = String.Empty;
        public string selectedPlateNumber = String.Empty;
        #region Forms
        public frmReportIn(bool isAllowSelect = false)
        {
            InitializeComponent();
            dtpStartTime.Value = new DateTime(2024, 1, 1, 0, 0, 0);
            dtpEndTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            this.KeyPreview = true;
            this.KeyDown += FrmReportIn_KeyDown;

            dgvData.SelectionChanged += DgvData_SelectionChanged;

            ucPages1.OnpageSelect += UcPages1_OnpageSelect;
            ucEventInInfo1.onBackClickEvent += UcEventInfo1_onBackClickEvent;

            this.isAllowSelect = isAllowSelect;

            this.Load += FrmReportIn_Load;
            this.SizeChanged += FrmReportIn_SizeChanged;
        }

        private async void FrmReportIn_Load(object? sender, EventArgs e)
        {
            registerVehicles = (await AppData.ApiServer.parkingDataService.GetRegisterVehiclesAsync("")).Item1;
            customers = (await AppData.ApiServer.parkingDataService.GetCustomersAsync())?.Item1 ?? new List<Customer>();
            users = (await AppData.ApiServer.userService.GetAllUsers())?.Item1 ?? new List<User>();

            await CreateUI();

            panelData.ToggleDoubleBuffered(true);
            if (this.isAllowSelect)
            {
                dgvData.CellDoubleClick += DgvData_CellDoubleClick;
            }
            picOverviewImageIn.Image = picOverviewImageIn.ErrorImage = defaultImg;
            picVehicleImageIn.Image = picVehicleImageIn.ErrorImage = defaultImg;

            picOverviewImageIn.LoadCompleted += Pic_LoadCompleted;
            picVehicleImageIn.LoadCompleted += Pic_LoadCompleted;

            cbVehicleType.SelectedIndexChanged += ChangeSearchConditionEvent;
            cbIdentityGroupType.SelectedIndexChanged += ChangeSearchConditionEvent;
            cbLane.SelectedIndexChanged += ChangeSearchConditionEvent;
            cbUser.SelectedIndexChanged += ChangeSearchConditionEvent;

            btnSearch.PerformClick();

            this.FormClosing += FrmReportIn_FormClosing;
        }

        private void FrmReportIn_FormClosing(object? sender, FormClosingEventArgs e)
        {
            lanes?.Clear();
            identityGroups?.Clear();
            registerVehicles?.Clear();
            customers?.Clear();
        }

        private void FrmReportIn_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnSearch_Click(null, EventArgs.Empty);
                return;
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
            try
            {
                btnSearch.Enabled = false;
                picOverviewImageIn.Image = defaultImg;
                picVehicleImageIn.Image = defaultImg;

                string keyword = txtKeyword.Text;
                DateTime startTime = dtpStartTime.Value;
                DateTime endTime = dtpEndTime.Value;
                string vehicleTypeId = ((ListItem)cbVehicleType.SelectedItem)?.Value ?? "";
                string identityGroupId = ((ListItem)cbIdentityGroupType.SelectedItem)?.Value ?? "";
                string laneId = ((ListItem)cbLane.SelectedItem)?.Value ?? "";
                string user = string.IsNullOrEmpty(((ListItem)cbUser.SelectedItem)?.Value) ? "" : cbUser.Text;
                var report = await AppData.ApiServer.reportingService.GetEventIns(keyword, startTime, endTime, identityGroupId, vehicleTypeId, laneId, user, 1, Filter.PAGE_SIZE);
                var eventInReports = report.data;
                if (eventInReports == null)
                {
                    panelData.BackColor = Color.White;
                    ucLoading1.HideLoading();
                    ucNotify1.Show(ucNotify.EmNotiType.Error, "Không tải được thông tin xe trong bãi. Vui lòng thử lại!");
                    return;
                }

                totalPages = report.TotalPage;
                totalEvents = report.TotalCount;


                panelData.SuspendLayout();
                EnableFastLoading();
                DisplayNavigation();
                DisplayEventInData(eventInReports);
                DisableFastLoading();
                eventInReports.Clear();
                panelData.ResumeLayout();
                this.ActiveControl = btnSearch;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.System, mo_ta_them: ex);
            }
            finally
            {
                btnSearch.Enabled = true;
            }

        }
        private void ChangeSearchConditionEvent(object? sender, EventArgs e)
        {
            btnSearch.PerformClick();
        }
        private void Pic_LoadCompleted(object? sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            PictureBox pictureBox = (sender as PictureBox)!;
            if (e.Error != null)
            {
                pictureBox.Image = defaultImg;
            }
        }

        private void DgvData_SelectionChanged(object? sender, EventArgs e)
        {
            try
            {
                var imageDatas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ImageData>>(dgvData.CurrentRow?.Cells[col_file_keys].Value.ToString()!)!;
                ShowImage(imageDatas.FirstOrDefault(e => e.type == ParkingImageType.EmParkingImageType.Overview)?.Url ?? "", picOverviewImageIn);
                ShowImage(imageDatas.FirstOrDefault(e => e.type == ParkingImageType.EmParkingImageType.Vehicle)?.Url ?? "", picVehicleImageIn);
            }
            catch (Exception ex)
            {
            }

        }
        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip ctx = new ContextMenuStrip();
                ctx.Items.Add("Sửa ghi chú BSX", Properties.Resources.setting_0_0_0_32px).Name = "UpdateNote";
                ctx.Items.Add("Sửa biển số", Properties.Resources.setting_0_0_0_32px).Name = "UpdatePlateIn";

                ctx.Font = new Font(dgvData.Font.Name, 16, FontStyle.Bold);
                ctx.BackColor = Color.DarkOrange;
                ctx.ItemClicked += (sender, ctx_e) =>
                {
                    string id = dgvData.Rows[e.RowIndex].Cells[col_event_id].Value.ToString() ?? "";
                    string currentPlateIn = dgvData.Rows[e.RowIndex].Cells[col_plate].Value?.ToString() ?? "";
                    string currentNote = dgvData.Rows[e.RowIndex].Cells[col_note].Value?.ToString() ?? "";
                    string timeIn = dgvData.Rows[e.RowIndex].Cells[col_time_in].Value?.ToString() ?? "";
                    string identityName = dgvData.Rows[e.RowIndex].Cells[col_identity_name].Value?.ToString() ?? "";
                    switch (ctx_e.ClickedItem.Name.ToString())
                    {
                        case "UpdateNote":
                            var frmUpdateNote = new frmEditNote(currentNote, id, true);
                            if (frmUpdateNote.ShowDialog() == DialogResult.OK)
                            {
                                dgvData.Rows[e.RowIndex].Cells[col_note].Value = frmUpdateNote.newNote;
                                frmUpdateNote.Dispose();
                            }
                            break;
                        case "UpdatePlateIn":
                            {
                                var frmUpdatePlate = new frmEditPlate(currentPlateIn, id, true);
                                if (frmUpdatePlate.ShowDialog() == DialogResult.OK)
                                {
                                    dgvData.Rows[e.RowIndex].Cells[col_plate].Value = frmUpdatePlate.UpdatePlate;
                                    frmUpdatePlate.Dispose();
                                }
                            }
                            break;
                        default:
                            break;
                    }
                };
                var location = dgvData.PointToScreen(dgvData.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location);
                ctx.Show(dgvData, new Point(location.X - dgvData.Location.X, location.Y - dgvData.Location.Y));
            }

        }
        private void DgvData_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            this.selectedIdentityId = dgvData.Rows[e.RowIndex].Cells[col_identity_id].Value?.ToString() ?? "";
            this.selectedPlateNumber = dgvData.Rows[e.RowIndex].Cells[col_plate].Value?.ToString() ?? "";

            this.DialogResult = DialogResult.OK;
        }

        private void UcPages1_OnpageSelect(int pageIndex)
        {
            this.Invoke(new Action(async () =>
            {
                picOverviewImageIn.Image = defaultImg;
                picVehicleImageIn.Image = defaultImg;

                EnableFastLoading();

                string keyword = txtKeyword.Text;
                DateTime startTime = dtpStartTime.Value;
                DateTime endTime = dtpEndTime.Value;
                string vehicleTypeId = ((ListItem)cbVehicleType.SelectedItem)?.Value ?? "";
                string identityGroupId = ((ListItem)cbIdentityGroupType.SelectedItem)?.Value ?? "";
                string laneId = ((ListItem)cbLane.SelectedItem)?.Value ?? "";
                string user = string.IsNullOrEmpty(((ListItem)cbUser.SelectedItem)?.Value) ? "" : cbUser.Text;

                Application.DoEvents();
                var report = await AppData.ApiServer.reportingService.GetEventIns(keyword, startTime, endTime, identityGroupId, vehicleTypeId, laneId, user, pageIndex: pageIndex, pageSize: Filter.PAGE_SIZE);
                var eventInData = report.data;

                totalPages = report.TotalPage;
                totalEvents = report.TotalCount;

                DisplayEventInData(eventInData);
                DisableFastLoading();
                eventInData.Clear();
            }));

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

        private void btnExportExcel_Click(object? sender, EventArgs e)
        {
            ExcelTools.CreatReportFile(dgvData, "Báo cáo Xe Đang Trong Bãi", new List<string>() { });
        }
        private void btnCancel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
        #endregion End Controls In Form

        #region Private Function
        private async Task CreateUI()
        {
            try
            {
                this.SuspendLayout();
                btnCancel.InitControl(btnCancel_Click);
                btnExportExcel.InitControl(btnExportExcel_Click);
                btnSearch.InitControl(btnSearch_Click);
                panelData.ToggleDoubleBuffered(true);
                dgvData.ToggleDoubleBuffered(true);

                pictureBox1.Location = new Point(this.DisplayRectangle.Width - pictureBox1.Width - TextManagement.ROOT_SIZE,
                                                TextManagement.ROOT_SIZE);
                lblTitle.Text = "Danh Sách Xe Đang Trong Bãi";
                lblTitle.Location = new Point(TextManagement.ROOT_SIZE * 2, TextManagement.ROOT_SIZE * 2);
                lblTitle.Font = new Font(lblTitle.Font.Name, TextManagement.ROOT_SIZE * 2, FontStyle.Bold);
                lblTitle.BackColor = Color.Transparent;
                //Từ khóa
                lblKeyword.Location = new Point(lblTitle.Location.X, lblTitle.Location.Y + lblTitle.Height + TextManagement.ROOT_SIZE);
                txtKeyword.Location = new Point(lblKeyword.Location.X + lblUser.Width + TextManagement.ROOT_SIZE,
                                                lblKeyword.Location.Y + (lblKeyword.Height - txtKeyword.Height) / 2);
                //Giờ bắt đầu
                dtpStartTime.Location = new Point(txtKeyword.Location.X, txtKeyword.Location.Y + txtKeyword.Height + TextManagement.ROOT_SIZE);
                lblStartTime.Location = new Point(lblKeyword.Location.X,
                                                  dtpStartTime.Location.Y + (dtpStartTime.Height - lblStartTime.Height) / 2);

                //Loại phương tiện
                cbVehicleType.Location = new Point(txtKeyword.Location.X, dtpStartTime.Location.Y + dtpStartTime.Height + TextManagement.ROOT_SIZE);
                lblVehicleType.Location = new Point(lblKeyword.Location.X,
                                                   cbVehicleType.Location.Y + (cbVehicleType.Height - lblVehicleType.Height) / 2);

                //Người dùng
                cbUser.Location = new Point(txtKeyword.Location.X, cbVehicleType.Location.Y + cbVehicleType.Height + TextManagement.ROOT_SIZE);
                lblUser.Location = new Point(lblKeyword.Location.X, cbUser.Location.Y + (cbUser.Height - lblUser.Height) / 2);

                //Giờ kết thúc
                lblEndTime.Location = new Point(dtpStartTime.Location.X + dtpStartTime.Width + TextManagement.ROOT_SIZE * 2,
                                                lblStartTime.Location.Y);
                dtpEndTime.Location = new Point(lblEndTime.Location.X + lblEndTime.Width + TextManagement.ROOT_SIZE,
                                                dtpStartTime.Location.Y);

                //Nhóm thẻ
                lblIdentityType.Location = new Point(lblEndTime.Location.X, lblVehicleType.Location.Y);
                cbIdentityGroupType.Location = new Point(dtpEndTime.Location.X, cbVehicleType.Location.Y);


                //Làn
                cbLane.Location = new Point(dtpEndTime.Location.X, cbUser.Location.Y);
                lblLane.Location = new Point(lblEndTime.Location.X, lblUser.Location.Y);

                txtKeyword.Width = dtpEndTime.Width + dtpEndTime.Location.X - txtKeyword.Location.X;

                btnSearch.Location = new Point(cbLane.Location.X + cbLane.Width + TextManagement.ROOT_SIZE,
                                              cbLane.Location.Y + cbLane.Height - btnSearch.Height);
                btnCancel.Location = new Point(panelData.Width - btnCancel.Width - TextManagement.ROOT_SIZE * 2,
                                               panelData.Height - btnCancel.Height - TextManagement.ROOT_SIZE * 2);
                btnExportExcel.Location = new Point(btnCancel.Location.X - btnExportExcel.Width - TextManagement.ROOT_SIZE,
                                                    btnCancel.Location.Y);

                ucPages1.Location = new Point(TextManagement.ROOT_SIZE * 2, btnCancel.Location.Y - ucPages1.Height - TextManagement.ROOT_SIZE);
                ucPages1.Width = panelData.Width - TextManagement.ROOT_SIZE * 4;

                dgvData.Location = new Point(TextManagement.ROOT_SIZE * 2, cbLane.Location.Y + cbLane.Height + TextManagement.ROOT_SIZE);

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

                cbVehicleType.DisplayMember = cbIdentityGroupType.DisplayMember = cbLane.DisplayMember = cbUser.DisplayMember = "Name";
                cbVehicleType.ValueMember = cbIdentityGroupType.ValueMember = cbLane.ValueMember = cbUser.ValueMember = "Value";

                LoadVehicleTypeData();
                await LoadIdentityGroup();
                await LoadLaneType();
                await LoadUsers();
                this.ResumeLayout();
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.System, mo_ta_them: ex);
            }
        }
        private void DisableFastLoading()
        {
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            SendMessage(dgvData.Handle, WM_SETREDRAW, true, 0);
            dgvData.Refresh();
        }
        private void EnableFastLoading()
        {
            try
            {
                dgvData.Rows.Clear();
                dgvData.Refresh();

                SendMessage(dgvData.Handle, WM_SETREDRAW, false, 0);
                dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            }
            catch (Exception)
            {
            }
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

        private void DisplayEventInData(List<EventInData> eventInReports)
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (var item in eventInReports)
            {
                DataGridViewRow row = new DataGridViewRow();
                this.Invoke(new Action(() =>
                {
                    row.CreateCells(dgvData);

                }));
                row.Cells[dgvData.Columns[col_event_id].Index].Value = item.Id;
                row.Cells[dgvData.Columns[col_identity_id].Index].Value = item.Identity.Id;
                row.Cells[dgvData.Columns[col_lane_in_id].Index].Value = item.Lane.Id;
                row.Cells[dgvData.Columns[col_file_keys].Index].Value = item.images == null ? "[]" : Newtonsoft.Json.JsonConvert.SerializeObject(item.images);
                row.Cells[dgvData.Columns[col_customer_id].Index].Value = item.customer?.Id;
                row.Cells[dgvData.Columns[col_register_vehicle_id].Index].Value = item.vehicle?.Id;
                row.Cells[dgvData.Columns[col_index].Index].Value = (rows.Count + 1).ToString();
                row.Cells[dgvData.Columns[col_plate].Index].Value = item.PlateNumber;
                row.Cells[dgvData.Columns[col_time_in].Index].Value = item.DatetimeIn.ToVNTime();
                row.Cells[dgvData.Columns[col_note].Index].Value = item.note;
                row.Cells[dgvData.Columns[col_identity_group_name].Index].Value = GetIdentityGroupName(item.IdentityGroup.Id);
                row.Cells[dgvData.Columns[col_user].Index].Value = item.createdBy;
                row.Cells[dgvData.Columns[col_lane_in_name].Index].Value = item.Lane.name;
                row.Cells[dgvData.Columns[col_identity_name].Index].Value = item.Identity.Name;
                row.Cells[dgvData.Columns[col_identity_code].Index].Value = item.Identity.Code;
                row.Cells[dgvData.Columns[col_register_plate].Index].Value = item.vehicle?.PlateNumber ?? "";
                row.Cells[dgvData.Columns[col_customer].Index].Value = item.customer?.Name ?? "";
                row.Cells[dgvData.Columns[col_see_more].Index].Value = "Xem Thêm";//15

                rows.Add(row);
            }

            this.Invoke(new Action(() =>
            {
                dgvData.Rows.AddRange(rows.ToArray());
            }));
        }

        private void ShowImage(string fileKey, PictureBox pic)
        {
            try
            {
                if (string.IsNullOrEmpty(fileKey))
                {
                    pic.Image = defaultImg;
                }
                else
                {
                    pic.LoadAsync(fileKey);
                }
            }
            catch (Exception)
            {
                pic.Image = defaultImg;
            }
        }
        private void LoadVehicleTypeData()
        {
            cbVehicleType.Invoke(new Action(() =>
            {
                cbVehicleType.Items.Add(new ListItem()
                {
                    Name = "Tất cả",
                    Value = ""
                });
            }));


            cbVehicleType.Invoke(new Action(() =>
            {
                foreach (VehicleType.VehicleBaseType item in Enum.GetValues(typeof(VehicleType.VehicleBaseType)))
                {
                    ListItem vehicleTypeItem = new ListItem()
                    {
                        Name = VehicleType.GetDisplayStr(item),
                        Value = ((int)item).ToString()
                    };
                    cbVehicleType.Items.Add(vehicleTypeItem);
                }
                cbVehicleType.SelectedIndex = 0;
            }));
        }
        private async Task LoadIdentityGroup()
        {
            cbIdentityGroupType.Invoke(new Action(() =>
            {
                cbIdentityGroupType.Items.Add(new ListItem()
                {
                    Name = "Tất cả",
                    Value = ""
                });
            }));

            identityGroups = (await AppData.ApiServer.parkingDataService.GetIdentityGroupsAsync()).Item1 ?? new List<IdentityGroup>();
            identityGroups = identityGroups.OrderBy(x => x.Name).ThenBy(x => x.Name.Length).ToList();

            cbIdentityGroupType.Invoke(new Action(() =>
            {
                foreach (var item in identityGroups)
                {
                    ListItem identityGroupItem = new ListItem()
                    {
                        Name = item.Name,
                        Value = item.Id.ToString()
                    };
                    cbIdentityGroupType.Items.Add(identityGroupItem);
                }
                cbIdentityGroupType.SelectedIndex = 0;
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

            lanes = (await AppData.ApiServer.deviceService.GetLanesAsync()).Item1 ?? new List<Lane>();
            lanes = lanes.OrderBy(x => x.name).ThenBy(x => x.name.Length).ToList();
            cbLane.Invoke(new Action(() =>
            {
                foreach (var item in lanes)
                {
                    ListItem laneItem = new ListItem()
                    {
                        Name = item.name,
                        Value = item.Id
                    };
                    cbLane.Items.Add(laneItem);
                }
                cbLane.SelectedIndex = 0;
            }));
        }
        private async Task LoadUsers()
        {
            cbUser.Invoke(new Action(() =>
            {
                cbUser.Items.Add(new ListItem()
                {
                    Name = "Tất cả",
                    Value = ""
                });
            }));

            users = (await AppData.ApiServer.userService.GetAllUsers()).Item1 ?? new List<User>();
            users = users.OrderBy(x => x.upn).ThenBy(x => x.upn.Length).ToList();
            cbUser.Invoke(new Action(() =>
            {
                foreach (var item in users)
                {
                    ListItem laneItem = new ListItem()
                    {
                        Name = item.upn,
                        Value = item.id
                    };
                    cbUser.Items.Add(laneItem);
                }
                cbUser.SelectedIndex = 0;
            }));
        }

        private string GetLaneName(string laneId)
        {
            Lane? selectedLane = lanes.Where(lane => lane.Id.ToLower() == laneId.ToLower()).FirstOrDefault();
            return selectedLane == null ? "" : selectedLane.name;
        }
        private string GetIdentityGroupName(string identityGroupId)
        {
            IdentityGroup? selectedIdentityGroup = identityGroups.Where(e => e.Id.ToString().ToLower() == identityGroupId.ToLower()).FirstOrDefault();
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
            var registerVehicle = registerVehicles.Where(e => e.Id.ToLower() == registerVehicleId.ToLower()).FirstOrDefault();
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
            Customer? customer = customers.Where(e => e.Id.ToLower() == customerID.ToLower()).FirstOrDefault();
            return customer == null ? "" : customer.Name + " / " + customer.PhoneNumber;
        }
        #endregion End Private Function
    }
}
