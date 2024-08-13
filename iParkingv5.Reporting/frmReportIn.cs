using IPaking.Ultility;
using iPakrkingv5.Controls;
using iPakrkingv5.Controls.Controls.Buttons;
using iParkingv5.ApiManager.interfaces;
using iParkingv5.ApiManager.KzParkingv5Apis;
using iParkingv5.Objects.Databases;
using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Datas.Device_service;
using iParkingv5.Objects.Datas.parking_service;
using iParkingv5.Objects.Datas.user_service;
using iParkingv5.Objects.Enums;
using iParkingv5.Objects.EventDatas;
using iParkingv5_window.Forms;
using Kztek.Helper;
using Kztek.Tools;
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
using static iParkingv5.Objects.Enums.ParkingImageType;

namespace iParkingv5.Reporting
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
        private List<User> users = new List<User>();
        private Image? defaultImg = null;
        public iParkingApi ApiServer = new KzParkingv5ApiHelper();
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
        public frmReportIn(Image defaultImage, iParkingApi ApiServer, bool isAllowSelect = false)
        {
            InitializeComponent();

            this.defaultImg = defaultImage;
            this.ApiServer = ApiServer;

            dtpStartTime.Value = new DateTime(2024, 1, 1, 0, 0, 0);
            dtpEndTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            this.KeyPreview = true;
            this.KeyDown += FrmReportIn_KeyDown;

            dgvData.SelectionChanged += DgvData_SelectionChanged;

            ucPages1.OnpageSelect += UcPages1_OnpageSelect;
            this.isAllowSelect = isAllowSelect;

            this.Load += FrmReportIn_Load;
        }

        private async void FrmReportIn_Load(object? sender, EventArgs e)
        {
            var userTask = ApiServer.userService.GetAllUsers();
            var laneTask = ApiServer.deviceService.GetLanesAsync();
            var identityGroupTask = ApiServer.parkingDataService.GetIdentityGroupsAsync();

            await Task.WhenAll(userTask, laneTask, identityGroupTask);

            users = userTask?.Result?.Item1 ?? new List<User>();
            lanes = laneTask?.Result?.Item1 ?? new List<Lane>();
            identityGroups = identityGroupTask?.Result?.Item1 ?? new List<IdentityGroup>();

            CreateUI();

            if (this.isAllowSelect)
            {
                dgvData.CellDoubleClick += DgvData_CellDoubleClick;
            }

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
            users?.Clear();
            this.Cursor = Cursors.Default;
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
                this.Cursor = Cursors.WaitCursor;
                btnSearch.Enabled = false;
                dgvData.SelectionChanged -= DgvData_SelectionChanged;
                dgvData.CurrentCell = null;
                picOverviewImageIn.Image = defaultImg;
                picVehicleImageIn.Image = defaultImg;

                string keyword = txtKeyword.Text;
                DateTime startTime = dtpStartTime.Value;
                DateTime endTime = dtpEndTime.Value;
                string vehicleTypeId = ((ListItem)cbVehicleType.SelectedItem)?.Value ?? "";
                string identityGroupId = ((ListItem)cbIdentityGroupType.SelectedItem)?.Value ?? "";
                string laneId = ((ListItem)cbLane.SelectedItem)?.Value ?? "";
                string user = string.IsNullOrEmpty(((ListItem)cbUser.SelectedItem)?.Value) ? "" : cbUser.Text;
                var report = await ApiServer.reportingService.GetEventIns(keyword, startTime, endTime, identityGroupId, vehicleTypeId, laneId, user, true, 0, Filter.PAGE_SIZE);
                var eventInReports = report.data;
                if (eventInReports == null)
                {
                    panelData.BackColor = Color.White;
                    MessageBox.Show("Không tải được thông tin xe trong bãi. Vui lòng thử lại");
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

                panelData.ResumeLayout(false);
                panelData.PerformLayout();

                this.ActiveControl = btnSearch;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.System, mo_ta_them: ex);
            }
            finally
            {
                btnSearch.Enabled = true;
                dgvData.SelectionChanged += DgvData_SelectionChanged;
                this.Cursor = Cursors.Default;
            }
        }
        private void ChangeSearchConditionEvent(object? sender, EventArgs e)
        {
            btnSearch.PerformClick();
        }
        private void Pic_LoadCompleted(object? sender, AsyncCompletedEventArgs e)
        {
            PictureBox pictureBox = (sender as PictureBox)!;
            if (e.Error != null)
            {
                pictureBox.Image = pictureBox.ErrorImage;
            }
        }

        private async void DgvData_SelectionChanged(object? sender, EventArgs e)
        {
            try
            {
                if (dgvData.CurrentCell == null)
                {
                    return;
                }
                var imageDatas = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<EmParkingImageType, List<ImageData>>>(dgvData.CurrentRow?.Cells[col_file_keys].Value.ToString()!)!;

                ImageData? displayOverviewInImage = imageDatas.ContainsKey(EmParkingImageType.Overview) ? imageDatas[EmParkingImageType.Overview][0] : null;
                ImageData? vehicleInImage = imageDatas.ContainsKey(EmParkingImageType.Vehicle) ? imageDatas[EmParkingImageType.Vehicle][0] : null;
                ImageData? lprCutImahe = imageDatas.ContainsKey(EmParkingImageType.Plate) ? imageDatas[EmParkingImageType.Plate][0] : null;

                var overviewTask = ApiServer.parkingProcessService.GetImageUrl(displayOverviewInImage?.bucket ?? "", displayOverviewInImage?.objectKey ?? "");
                var vehicleTask = ApiServer.parkingProcessService.GetImageUrl(vehicleInImage?.bucket ?? "", vehicleInImage?.objectKey ?? "");

                await Task.WhenAll(overviewTask, vehicleTask);
                picOverviewImageIn.ShowImageUrlAsync(overviewTask.Result);
                picVehicleImageIn.ShowImageUrlAsync(vehicleTask.Result);
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.System, obj: ex);
            }

        }
        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip ctx = new ContextMenuStrip();
                ctx.Items.Add("Sửa ghi chú BSX").Name = "UpdateNote";
                ctx.Items.Add("Sửa biển số").Name = "UpdatePlateIn";

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
                            var frmUpdateNote = new frmEditNote(currentNote, id, true, this.ApiServer);
                            if (frmUpdateNote.ShowDialog() == DialogResult.OK)
                            {
                                dgvData.Rows[e.RowIndex].Cells[col_note].Value = frmUpdateNote.newNote;
                                frmUpdateNote.Dispose();
                            }
                            break;
                        case "UpdatePlateIn":
                            {
                                var frmUpdatePlate = new frmEditPlate(currentPlateIn, id, true, this.ApiServer);
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
                var report = await ApiServer.reportingService.GetEventIns(keyword, startTime, endTime, identityGroupId, vehicleTypeId, laneId, user, true, pageIndex: pageIndex - 1, pageSize: Filter.PAGE_SIZE);
                var eventInData = report.data;

                totalPages = report.TotalPage;
                totalEvents = report.TotalCount;

                DisplayEventInData(eventInData);
                DisableFastLoading();
                eventInData.Clear();
            }));

        }
        private void btnExportExcel_Click(object? sender, EventArgs e)
        {
            ExcelTools.CreatReportFile(dgvData, "Báo cáo Xe Đang Trong Bãi", new List<string>() { lblTotalEvents.Text });
        }
        private void btnCancel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
        #endregion End Controls In Form

        #region Private Function
        private void CreateUI()
        {
            try
            {
                this.SuspendLayout();
                foreach (var item in panelData.Controls)
                {
                    if (item.GetType() == typeof(Button) || item.GetType() == typeof(PictureBox) || item.GetType() == typeof(DataGridView))
                    {
                        try
                        {
                            ((ISupportInitialize)item).BeginInit();
                        }
                        catch (Exception ex)
                        {
                            LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.System, obj: ex);
                        }
                    }
                }
                panelData.SuspendLayout();
                tablePic.SuspendLayout();
                panelSearch.SuspendLayout();

                btnCancel.InitControl(btnCancel_Click);
                btnExportExcel.InitControl(btnExportExcel_Click);
                btnSearch.InitControl(btnSearch_Click);
                dgvData.ToggleDoubleBuffered(true);

                int rootSize = TextManagement.ROOT_SIZE;

                picGuide.Location = new Point(this.DisplayRectangle.Width - picGuide.Width - rootSize, rootSize);
                picOverviewImageIn.Image = picOverviewImageIn.ErrorImage = defaultImg;
                picVehicleImageIn.Image = picVehicleImageIn.ErrorImage = defaultImg;

                lblTitle.Font = new Font(lblTitle.Font.Name, rootSize * 2, FontStyle.Bold);
                lblTitle.Location = new Point(rootSize * 2, rootSize * 2);
                lblTitle.Text = "Danh Sách Xe Đang Trong Bãi";
                lblTitle.BackColor = Color.Transparent;

                panelSearch.Location = new Point(lblTitle.Location.X, lblTitle.Location.Y + lblTitle.Height + rootSize);

                btnSearch.Location = new Point(panelSearch.Location.X + panelSearch.Width + rootSize,
                                               panelSearch.Location.Y + panelSearch.Height - btnSearch.Height - 6);

                btnCancel.ToBottomRightChild(panelData, rootSize * 2);
                btnExportExcel.ToLeft(btnCancel, rootSize);

                ucPages1.Font = this.Font;
                ucPages1.Location = new Point(rootSize * 2, btnCancel.Location.Y - ucPages1.Height - rootSize);
                ucPages1.Width = panelData.Width - rootSize * 4;
                ucPages1.Height = ucPages1.PreferredSize.Height;

                tablePic.Height = ucPages1.Visible ?
                                        ucPages1.Location.Y - dgvData.Location.Y - rootSize * 2 :
                                        dgvData.Height = ucPages1.Location.Y + ucPages1.Height - dgvData.Location.Y - rootSize * 2;
                tablePic.Width = tablePic.Height * 9 * 2 / 16;

                dgvData.Size = new Size(this.DisplayRectangle.Width - rootSize * 5 - tablePic.Width, tablePic.Height);
                dgvData.Location = new Point(rootSize * 2, panelSearch.Location.Y + panelSearch.Height + rootSize);

                tablePic.Location = new Point(panelData.Width - tablePic.Width - rootSize * 2,
                                              dgvData.Location.Y);

                lblTotalEvents.Location = new Point(btnSearch.Location.X + btnSearch.Width + rootSize,
                                                    btnSearch.Location.Y - lblTotalEvents.Height + btnSearch.Height);

                cbVehicleType.DisplayMember = cbIdentityGroupType.DisplayMember = cbLane.DisplayMember = cbUser.DisplayMember = "Name";
                cbVehicleType.ValueMember = cbIdentityGroupType.ValueMember = cbLane.ValueMember = cbUser.ValueMember = "Value";

                LoadVehicleTypeData();
                LoadIdentityGroup();
                LoadLaneType();
                LoadUsers();

                foreach (var item in panelData.Controls)
                {
                    if (item.GetType() == typeof(Button) || item.GetType() == typeof(PictureBox) || item.GetType() == typeof(DataGridView))
                    {
                        ((ISupportInitialize)item).EndInit();
                    }
                }

                tablePic.ResumeLayout(false);
                tablePic.PerformLayout();

                panelData.ResumeLayout(false);
                panelData.PerformLayout();

                panelSearch.ResumeLayout(false);
                panelSearch.PerformLayout();

                this.ResumeLayout(false);
                this.PerformLayout();
                this.SizeChanged += FrmReportIn_SizeChanged;
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
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.System, obj: ex);
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

        private void DisplayEventInData(List<EventInReport> eventInReports)
        {
            try
            {
                dgvData.CurrentCell = null;
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
                    row.Cells[dgvData.Columns[col_file_keys].Index].Value = item.images == null ?
                                                                                    "[]" :
                                                                                    Newtonsoft.Json.JsonConvert.SerializeObject(item.images);
                    row.Cells[dgvData.Columns[col_customer_id].Index].Value = item.customer?.Id;
                    row.Cells[dgvData.Columns[col_register_vehicle_id].Index].Value = item.vehicle?.Id;
                    row.Cells[dgvData.Columns[col_index].Index].Value = (rows.Count + 1).ToString();
                    row.Cells[dgvData.Columns[col_plate].Index].Value = item.PlateNumber;
                    row.Cells[dgvData.Columns[col_time_in].Index].Value = item.DateTimeIn.ToVNTime();
                    row.Cells[dgvData.Columns[col_note].Index].Value = item.Note;
                    row.Cells[dgvData.Columns[col_identity_group_name].Index].Value = item.IdentityGroup?.Name ?? "";
                    row.Cells[dgvData.Columns[col_user].Index].Value = item.CreatedBy;
                    row.Cells[dgvData.Columns[col_lane_in_name].Index].Value = item.Lane.name;
                    row.Cells[dgvData.Columns[col_identity_name].Index].Value = item.Identity.Name;
                    row.Cells[dgvData.Columns[col_identity_code].Index].Value = item.Identity.Code;
                    row.Cells[dgvData.Columns[col_register_plate].Index].Value = item.vehicle?.PlateNumber ?? "";
                    row.Cells[dgvData.Columns[col_customer].Index].Value = item.customer?.Name ?? "";
                    row.Cells[dgvData.Columns[col_see_more].Index].Value = "Xem Thêm";

                    rows.Add(row);
                }

                this.Invoke(new Action(() =>
                {
                    dgvData.Rows.AddRange(rows.ToArray());
                    if (dgvData.Rows.Count > 0)
                    {
                        dgvData.CurrentCell = dgvData.Rows[0].Cells[col_index];
                    }
                    else
                    {
                        dgvData.CurrentCell = null;
                    }
                    DgvData_SelectionChanged(null, EventArgs.Empty);
                }));
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.System, obj: ex);
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
        private void LoadIdentityGroup()
        {
            cbIdentityGroupType.Invoke(new Action(() =>
            {
                cbIdentityGroupType.Items.Add(new ListItem()
                {
                    Name = "Tất cả",
                    Value = ""
                });
            }));

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
        private void LoadLaneType()
        {
            cbLane.Invoke(new Action(() =>
            {
                cbLane.Items.Add(new ListItem()
                {
                    Name = "Tất cả",
                    Value = ""
                });
            }));

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
        private void LoadUsers()
        {
            cbUser.Invoke(new Action(() =>
            {
                cbUser.Items.Add(new ListItem()
                {
                    Name = "Tất cả",
                    Value = ""
                });
            }));

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

        private string GetIdentityGroupName(string identityGroupId)
        {
            IdentityGroup? selectedIdentityGroup = identityGroups.Where(e => e.Id.ToString().ToLower() == identityGroupId.ToLower()).FirstOrDefault();
            return selectedIdentityGroup == null ? "" : selectedIdentityGroup.Name;
        }
        #endregion End Private Function
    }

}
