using DocumentFormat.OpenXml.EMMA;
using IPaking.Ultility;
using iPakrkingv5.Controls;
using iPakrkingv5.Controls.Controls.Buttons;
using iParkingv5.ApiManager.KzParkingv5Apis;
using iParkingv5.ApiManager.XuanCuong;
using iParkingv5.Objects;
using iParkingv5.Objects.Databases;
using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Datas.Device_service;
using iParkingv5.Objects.Datas.parking_service;
using iParkingv5.Objects.Datas.user_service;
using iParkingv5.Objects.Enums;
using iParkingv5_window.Forms.DataForms;
using iParkingv5_window.Usercontrols.BuildControls;
using Kztek.Tools;
using System.Data;
using System.Data.SqlTypes;
using System.Globalization;
using System.Runtime.InteropServices;
using static iParkingv5.ApiManager.KzParkingv5Apis.KzParkingv5ApiHelper;
using static iParkingv5.Objects.Enums.PrintHelpers;
using static iParkingv6.ApiManager.KzParkingv3Apis.KzParkingApiHelper;

namespace iParkingv5_window.Forms.ReportForms
{
    public partial class frmReportIn : Form
    {
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
            dgvData.CellContentClick += DgvData_CellContentClick;

            ucPages1.OnpageSelect += UcPages1_OnpageSelect;
            ucEventInInfo1.onBackClickEvent += UcEventInfo1_onBackClickEvent;

            this.isAllowSelect = isAllowSelect;

            this.Load += FrmReportIn_Load;
            this.SizeChanged += FrmReportIn_SizeChanged;
        }

        private async void FrmReportIn_Load(object? sender, EventArgs e)
        {
            registerVehicles = (await AppData.ApiServer.GetRegisterVehiclesAsync("")).Item1;
            customers = (await AppData.ApiServer.GetCustomersAsync())?.Item1 ?? new List<Customer>();
            users = (await AppData.ApiServer.GetAllUsers())?.Item1 ?? new List<User>();

            if (StaticPool.appOption.PrintTemplate != (int)EmPrintTemplate.XuanCuong)
            {
                dgvData.Columns["vehicle_reagion_type"].Visible = false;
                dgvData.Columns["warehouse"].Visible = false;
                dgvData.Columns["warehouse_code"].Visible = false;
                dgvData.Columns["vehicle_reagion_type"].Visible = false;
                dgvData.Columns["note_3rd_1"].Visible = false;
                dgvData.Columns["note_3rd_2"].Visible = false;
                dgvData.Columns["note_3rd_3"].Visible = false;
                lblVN.Visible = false;
                lblTQ.Visible = false;
            }
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
                btnSearch_Click(null, null);
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
            lblVN.Location = new Point(dgvData.Location.X, dgvData.Location.Y + dgvData.Height + 3);
            lblTQ.Location = new Point(dgvData.Location.X, lblVN.Location.Y + lblVN.Height + 3);
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
                var report = await AppData.ApiServer.GetEventIns(keyword, startTime, endTime, identityGroupId, vehicleTypeId, laneId, user, 1, Filter.PAGE_SIZE);
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
                await DisplayEventInData(eventInReports);
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

        private async void DgvData_SelectionChanged(object? sender, EventArgs e)
        {
            try
            {
                string physicalFileId = dgvData.CurrentRow?.Cells[dgvData.ColumnCount - 4].Value.ToString() ?? "";
                string[] physicalFileIds = physicalFileId.Split(';');
                if (physicalFileIds.Length >= 2)
                {
                    string displayOverviewInPath = physicalFileIds[0];// await MinioHelper.GetImage(physicalFileIds[0]);
                    string vehicleInPath = physicalFileIds[1];// await MinioHelper.GetImage(physicalFileIds[1]);
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
            return;
            if (e.ColumnIndex == dgvData.ColumnCount - 1 && e.RowIndex >= 0)
            {
                panelData.SuspendLayout();
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

                string identityId = dgvData.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "";
                string plateNumber = dgvData.Rows[e.RowIndex].Cells[2].Value?.ToString() ?? "";
                string datetimeIn = dgvData.Rows[e.RowIndex].Cells[5].Value?.ToString() ?? "";
                string laneID = dgvData.Rows[e.RowIndex].Cells[6].Value?.ToString() ?? "";
                string createdById = dgvData.Rows[e.RowIndex].Cells[7].Value?.ToString() ?? "";
                string customerId = dgvData.Rows[e.RowIndex].Cells[9].Value?.ToString() ?? "";
                string registerVehicleId = dgvData.Rows[e.RowIndex].Cells[10].Value?.ToString() ?? "";
                ucEventInInfo1.ShowInfo(new Point((this.Width - ucEventInInfo1.Width) / 2, (this.Height - ucEventInInfo1.Height) / 2), laneID, datetimeIn, plateNumber, identityId, createdById, customerId, registerVehicleId);
                this.ActiveControl = ucEventInInfo1;
                panelData.ResumeLayout();
            }
        }
        private async void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                dgvData.CurrentCell = dgvData.Rows[e.RowIndex].Cells[1];
                ContextMenuStrip ctx = new ContextMenuStrip();
                ctx.Items.Add("Sửa ghi chú BSX", Properties.Resources.setting_0_0_0_32px).Name = "UpdateNote";
                ctx.Items.Add("Sửa biển số", Properties.Resources.setting_0_0_0_32px).Name = "UpdatePlateIn";

                if (StaticPool.appOption.PrintTemplate == (int)EmPrintTemplate.XuanCuong)
                {
                    ctx.Items.Add("Sửa loại dịch vụ", Properties.Resources.setting_0_0_0_32px).Name = "UpdateWarehose";
                    ctx.Items.Add("In Phiếu Xuất", Properties.Resources.print_0_0_0_32px).Name = "PrintWarehouse";
                }

                ctx.Font = new Font(dgvData.Font.Name, 16, FontStyle.Bold);
                ctx.BackColor = Color.DarkOrange;
                ctx.ItemClicked += async (sender, ctx_e) =>
                {
                    string id = dgvData.Rows[e.RowIndex].Cells[0].Value.ToString() ?? "";
                    string currentPlateIn = dgvData.Rows[e.RowIndex].Cells["plate"].Value?.ToString() ?? "";
                    string currentNote = dgvData.Rows[e.RowIndex].Cells["NoteBSX"].Value?.ToString() ?? "";
                    string current_warehouse = dgvData.Rows[e.RowIndex].Cells["warehouse"].Value?.ToString() ?? "";
                    string timeIn = dgvData.Rows[e.RowIndex].Cells["timeIn"].Value?.ToString() ?? "";
                    string identityName = dgvData.Rows[e.RowIndex].Cells["identityName"].Value?.ToString() ?? "";
                    string FileIds = dgvData.Rows[e.RowIndex].Cells["FileIds"].Value?.ToString() ?? "";
                    switch (ctx_e.ClickedItem.Name.ToString())
                    {
                        case "UpdateNote":
                            var frmUpdateNote = new frmEditNote(currentNote, id, true);
                            if (frmUpdateNote.ShowDialog() == DialogResult.OK)
                            {
                                dgvData.Rows[e.RowIndex].Cells["NoteBSX"].Value = frmUpdateNote.newNote;
                                frmUpdateNote.Dispose();
                            }
                            break;
                        case "UpdatePlateIn":
                            {
                                var frmUpdatePlate = new frmEditPlate(currentPlateIn, id, true);
                                if (frmUpdatePlate.ShowDialog() == DialogResult.OK)
                                {
                                    if (((EmPrintTemplate)StaticPool.appOption.PrintTemplate) == EmPrintTemplate.XuanCuong)
                                    {
                                        await XuanCuongApiHelper.SendParkingInfo(id, "in", frmUpdatePlate.UpdatePlate, DateTime.ParseExact(timeIn, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture), FileIds.Split(";").ToList(), "");
                                    }
                                    dgvData.Rows[e.RowIndex].Cells["plate"].Value = frmUpdatePlate.UpdatePlate;
                                    frmUpdatePlate.Dispose();
                                }
                            }
                            break;
                        case "UpdateWarehose":
                            {
                                var frmUpdatePlate = new frmSelectWarehouseType(id, current_warehouse, currentPlateIn);
                                if (frmUpdatePlate.ShowDialog() == DialogResult.OK)
                                {
                                    dgvData.Rows[e.RowIndex].Cells["warehouse"].Value = frmUpdatePlate.newType;
                                    frmUpdatePlate.Dispose();
                                    await Task.Delay(1000);
                                    btnSearch_Click(null, null);
                                }
                            }
                            break;
                        case "PrintWarehouse":
                            {
                                bool isConfirmPrint = MessageBox.Show("Bạn có muốn in phiếu xuất?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
                                //bool isConfirmPrint = true;
                                if (isConfirmPrint)
                                {
                                    var warehouse = await AppData.ApiServer.CreateWarehouseService(id, "", currentPlateIn,
                                        TransactionType.EmTransactionType.OutBound, true);
                                    var wbPrint = new WebBrowser();
                                    wbPrint.DocumentCompleted += WbPrint_DocumentCompleted;
                                    wbPrint.DocumentText = GetPrintWarehoseContent(warehouse, identityName, currentPlateIn, DateTime.Parse(timeIn));
                                }
                                break;
                            }
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
            this.selectedIdentityId = dgvData.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "";
            this.selectedPlateNumber = dgvData.Rows[e.RowIndex].Cells[2].Value?.ToString() ?? "";

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
                var report = await AppData.ApiServer.GetEventIns(keyword, startTime, endTime, identityGroupId, vehicleTypeId, laneId, user, pageIndex: pageIndex, pageSize: Filter.PAGE_SIZE);
                var eventInData = report.data;

                totalPages = report.TotalPage;
                totalEvents = report.TotalCount;

                await DisplayEventInData(eventInData);
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
            ExcelTools.CreatReportFile(dgvData, "Báo cáo Xe Đang Trong Bãi", new List<string>() { lblVN.Text, lblTQ.Text });
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

                lblVN.Location = new Point(dgvData.Location.X, dgvData.Location.Y + dgvData.Height + 3);
                lblTQ.Location = new Point(dgvData.Location.X, lblVN.Location.Y + lblVN.Height + 3);

                cbVehicleType.DisplayMember = cbIdentityGroupType.DisplayMember = cbLane.DisplayMember = cbUser.DisplayMember = "Name";
                cbVehicleType.ValueMember = cbIdentityGroupType.ValueMember = cbLane.ValueMember = cbUser.ValueMember = "Value";

                await LoadVehicleTypeData();
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

        private async Task DisplayEventInData(List<EventInData> eventInReports)
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            Dictionary<string, Dictionary<string, int>> count_by_countries = new Dictionary<string, Dictionary<string, int>>();
            count_by_countries.Add("VN", new Dictionary<string, int>());
            count_by_countries.Add("TQ", new Dictionary<string, int>());
            foreach (KeyValuePair<string, Dictionary<string, int>> item in count_by_countries)
            {
                foreach (TransactionType.EmTransactionType type in Enum.GetValues(typeof(TransactionType.EmTransactionType)))
                {
                    item.Value.Add(TransactionType.GetTransactionTypeStr((int)type), 0);
                }
            }

            foreach (var item in eventInReports)
            {
                DataGridViewRow row = new DataGridViewRow();
                this.Invoke(new Action(() =>
                {
                    row.CreateCells(dgvData);
                }));
                int i = 0;
                row.Cells[i++].Value = item.Id;//0
                row.Cells[i++].Value = (rows.Count + 1).ToString();//0
                row.Cells[i++].Value = item.Identity.Id;            //1
                row.Cells[i++].Value = item.PlateNumber;           //2
                string countryCode = (item.PlateNumber?.Length ?? 0) > 0 ?
                                                        (int.TryParse(item.PlateNumber[0].ToString(), out int x) ? "VN" : "TQ") :
                                                        "VN";
                row.Cells[i++].Value = countryCode;           //2
                //count_by_countries[countryCode][TransactionType.GetTransactionTypeStr(item.TransactionType)] =
                //    count_by_countries[countryCode][TransactionType.GetTransactionTypeStr(item.TransactionType)] + 1;

                row.Cells[i++].Value = item.DatetimeIn?.ToString("dd/MM/yyyy HH:mm:ss"); //5
                row.Cells[i++].Value = "";//  TransactionType.GetTransactionTypeStr(item.TransactionType); //8
                row.Cells[i++].Value = "";              //9
                row.Cells[i++].Value = item.note ?? "";              //
                row.Cells[i++].Value = "";              //
                row.Cells[i++].Value = "";

                //NHÓM
                row.Cells[i++].Value = GetIdentityGroupName(item.IdentityGroup.Id);//12
                //N G Ư Ờ I D Ù N G
                row.Cells[i++].Value = item.createdBy;             //7

                //L À N V À O
                row.Cells[i++].Value = GetLaneName(item.Lane.id);//11

                row.Cells[i++].Value = item.Identity.Name;          //3
                row.Cells[i++].Value = item.Identity.Code;          //4
                row.Cells[i++].Value = GetRegisterVehiclePlate("");//13
                row.Cells[i++].Value = GetCustomer("");//14
                row.Cells[i++].Value = "";              //

                row.Cells[i++].Value = item.Lane.id;                //6
                List<string> url = new List<string>();
                if (item.images != null)
                {
                    foreach (ImageData imageData in item.images)
                    {
                        url.Add(imageData.Url);
                    }
                }

                row.Cells[i++].Value = string.Join(";", url);// item.fileKeys?.Length > 0 ? string.Join(";", item.fileKeys) : "";//8
                row.Cells[i++].Value = "";//9
                row.Cells[i++].Value = "";//10
                row.Cells[i++].Value = "Xem Thêm";//15

                rows.Add(row);
            }
            this.Invoke(new Action(() =>
            {
                dgvData.Rows.AddRange(rows.ToArray());
                if (dgvData.RowCount > 0)
                {
                    dgvData.CurrentCell = dgvData.Rows[0].Cells[1];
                }
                lblVN.Text = "";
                lblTQ.Text = "";
                string TH_VN = "";
                string TH_TQ = "";
                foreach (var item in count_by_countries["VN"])
                {
                    TH_VN += item.Key + " - " + item.Value + "    ";
                }
                foreach (var item in count_by_countries["TQ"])
                {
                    TH_TQ += item.Key + " - " + item.Value + "    ";
                }
                lblVN.Text = "VN: " + TH_VN;
                lblTQ.Text = "TQ: " + TH_TQ;
            }));
        }

        private async Task ShowImage(string fileKey, PictureBox pic)
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


            //if (!string.IsNullOrEmpty(fileKey))
            //{
            //    string displayPath = await MinioHelper.GetImage(fileKey);
            //    if (!string.IsNullOrEmpty(displayPath))
            //    {
            //        pic.LoadAsync(displayPath);
            //        return;
            //    }
            //}
            //pic.Image = defaultImg;
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


            //var vehicleTypes = await KzParkingApiHelper.GetAllVehicleTypes() ?? new List<VehicleType>();
            //var vehicleTypes = (await AppData.ApiServer.GetVehicleTypesAsync()).Item1 ?? new List<VehicleType>();
            //vehicleTypes = vehicleTypes.OrderBy(x => x.Name).ThenBy(x => x.Name.Length).ToList();
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

            identityGroups = (await AppData.ApiServer.GetIdentityGroupsAsync()).Item1 ?? new List<IdentityGroup>();
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

            //lanes = await KzParkingApiHelper.GetLanesAsync() ?? new List<iParkingv6.Objects.Datas.Lane>();
            lanes = (await AppData.ApiServer.GetLanesAsync()).Item1 ?? new List<Lane>();
            lanes = lanes.OrderBy(x => x.name).ThenBy(x => x.name.Length).ToList();
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

            //lanes = await KzParkingApiHelper.GetLanesAsync() ?? new List<iParkingv6.Objects.Datas.Lane>();
            users = (await AppData.ApiServer.GetAllUsers()).Item1 ?? new List<User>();
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
            Lane? selectedLane = lanes.Where(lane => lane.id.ToLower() == laneId.ToLower()).FirstOrDefault();
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

        private string GetPrintWarehoseContent(KzParkingv5ApiHelper.WarehouseService warehouseService, string cardName, string plateNumber, DateTime timeIn)
        {
            string printTemplatePath = PathManagement.appPrintTemplateWarehousePath(((EmPrintTemplate)StaticPool.appOption.PrintTemplate).ToString());
            if (File.Exists(printTemplatePath))
            {
                string baseContent = File.ReadAllText(printTemplatePath);
                baseContent = baseContent.Replace("$card_name", cardName);
                baseContent = baseContent.Replace("$plate_number", plateNumber);
                baseContent = baseContent.Replace("$timeIn", timeIn.ToString("HH:mm:ss - dd/MM/yyyy"));
                baseContent = baseContent.Replace("$warehouseNumber", (int.Parse(warehouseService.paperworkSequence)).ToString("00"));
                baseContent = baseContent.Replace("$code", warehouseService.codeCharacterSequence + "-" + warehouseService.codeNumberSequence);
                return baseContent;
            }
            else
            {
                MessageBox.Show("Không tìm thấy mẫu in", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return string.Empty;
            }
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
        #endregion End Private Function
    }
}
