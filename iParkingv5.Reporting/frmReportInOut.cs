using IPaking.Ultility;
using iPakrkingv5.Controls;
using iParkingv5.ApiManager.interfaces;
using iParkingv5.ApiManager.KzParkingv5Apis;
using iParkingv5.Objects;
using iParkingv5.Objects.Databases;
using iParkingv5.Objects.Datas.Device_service;
using iParkingv5.Objects.Datas.invoice_service;
using iParkingv5.Objects.Datas.parking_service;
using iParkingv5.Objects.Datas.user_service;
using iParkingv5.Objects.Enums;
using iParkingv5.Objects.EventDatas;
using iParkingv5.Printer;
using iParkingv5_window.Forms;
using Kztek.Helper;
using Kztek.Tool.LogDatabases;
using Kztek.Tool.TextFormatingTools;
using Kztek.Tools;
using System.ComponentModel;
using System.Data;
using System.Runtime.InteropServices;
using static iParkingv5.Objects.Enums.ParkingImageType;
using static iParkingv5.Objects.Enums.PrintHelpers;
using static Kztek.Tool.LogDatabases.tblSystemLog;
using ImageData = iParkingv5.Objects.EventDatas.ImageData;

namespace iParkingv5.Reporting
{
    public partial class frmReportInOut : Form
    {

        const string col_event_out_id = "event_out_id";
        const string col_event_in_id = "event_in_id";
        const string col_invoice_pending_id = "invoice_pending_id";
        const string col_invoice_id = "invoice_id";
        const string col_file_keys_in = "file_keys_in";
        const string col_file_keys_out = "file_keys_out";
        const string col_index = "index";
        const string col_plate_in = "plate_in";
        const string col_plate_out = "plate_out";
        const string col_time_in = "time_in";
        const string col_time_out = "time_out";
        const string col_parking_time = "parking_time";
        const string col_identity_group_name = "identity_group_name";
        const string col_parking_fee = "parking_fee";
        const string col_identity_code = "identity_code";
        const string col_user_in = "user_in";
        const string col_user_out = "user_out";
        const string col_invoice_template = "invoice_template";
        const string col_invoice_no = "invoice_no";
        const string col_lane_in_name = "lane_in_name";
        const string col_lane_out_name = "lane_out_name";
        const string col_note = "note";

        #region Properties
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;
        private int totalPages = 0;
        private int totalEvents = 0;

        private List<Lane> lanes = new List<Lane>();
        private List<IdentityGroup> identityGroups = new List<IdentityGroup>();
        private List<User> users = new List<User>();
        List<InvoiceResponse> InvoiceDatas = new List<InvoiceResponse>();
        List<InvoiceResponse> pendingDatas = new List<InvoiceResponse>();
        iParkingApi ApiServer = new KzParkingv5ApiHelper();
        public Image? defaultImg = null;
        List<EventOutReport> eventOutData = new List<EventOutReport>();
        private iPrinter printer;
        #endregion End Properties
        #region Forms
        public frmReportInOut(iParkingApi ApiServer, Image defaultImg, iPrinter printer)
        {
            InitializeComponent();
            this.ApiServer = ApiServer;
            this.defaultImg = defaultImg;
            this.printer = printer;

            dtpStartTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dtpEndTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            this.KeyPreview = true;
            this.KeyDown += FrmReportInOut_KeyDown;

            dgvData.SelectionChanged += DgvData_SelectionChanged;
            ucPages1.OnpageSelect += UcPages1_OnpageSelect;
            lblTotalEvents.TextChanged += LblTotalEvents_TextChanged;

            if (!StaticPool.eInvoiceConfig.IsUseEInvoice)
            {
                dgvData.Columns[col_invoice_no].Visible = false;
                dgvData.Columns[col_invoice_template].Visible = false;
            }

            this.ToggleDoubleBuffered(true);
            panelData.ToggleDoubleBuffered(true);
            dgvData.ToggleDoubleBuffered(true);

            this.Load += FrmReportInOut_Load;
            this.FormClosing += FrmReportInOut_FormClosing;
        }
        private async void FrmReportInOut_Load(object? sender, EventArgs e)
        {
            try
            {
                var userTask = ApiServer.userService.GetAllUsers();
                var laneTask = ApiServer.deviceService.GetLanesAsync();
                var identityGroupTask = ApiServer.parkingDataService.GetIdentityGroupsAsync();

                await Task.WhenAll(userTask, laneTask, identityGroupTask);

                users = userTask?.Result?.Item1 ?? new List<User>();
                lanes = laneTask?.Result?.Item1 ?? new List<Lane>();
                identityGroups = identityGroupTask?.Result?.Item1 ?? new List<IdentityGroup>();

                CreateUI();
                this.ActiveControl = btnSearch;
                btnSearch.PerformClick();

                cbVehicleType.SelectedIndexChanged += ChangeSearchConditionEvent;
                cbIdentityGroup.SelectedIndexChanged += ChangeSearchConditionEvent;
                cbLane.SelectedIndexChanged += ChangeSearchConditionEvent;
                cbUser.SelectedIndexChanged += ChangeSearchConditionEvent;
            }
            catch (Exception ex)
            {
                tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS, "ReportInOut", ex);
            }
            finally
            {
                GC.Collect();
            }
        }
        private void FrmReportInOut_SizeChanged(object? sender, EventArgs e)
        {
            if (ucPages1.MaxPage > 1)
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

            lblTotalEvents.Location = new Point(btnPrintPhieuThu.Location.X + btnPrintPhieuThu.Width + TextManagement.ROOT_SIZE,
                                               btnPrintPhieuThu.Location.Y - lblTotalEvents.Height + btnPrintPhieuThu.Height);
            ucPages1.Width = panelData.Width - TextManagement.ROOT_SIZE * 4;
            ucPages1.Location = new Point(dgvData.Location.X, dgvData.Location.Y + dgvData.Height + TextManagement.ROOT_SIZE);
            if (ucPages1.MaxPage > 1)
                ucPages1.Visible = true;
        }
        private void FrmReportInOut_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnSearch_Click(null, EventArgs.Empty);
                return;
            }
        }
        private void FrmReportInOut_FormClosing(object? sender, FormClosingEventArgs e)
        {
            lanes?.Clear();
            identityGroups?.Clear();
            users?.Clear();
            this.Cursor = Cursors.Hand;
        }
        #endregion End Forms

        #region Controls In Form
        private void LblTotalEvents_TextChanged(object? sender, EventArgs e)
        {
            lblTotalEvents.Height = lblTotalEvents.PreferredHeight;
            lblTotalEvents.Location = new Point(btnPrintPhieuThu.Location.X + btnPrintPhieuThu.Width + TextManagement.ROOT_SIZE,
                                                btnPrintPhieuThu.Location.Y - lblTotalEvents.Height + btnPrintPhieuThu.Height);

        }
        private async void btnSearch_Click(object? sender, EventArgs e)
        {
            try
            {
                this.Invoke(new Action(() =>
                {
                    picOverviewImageOut.Image = defaultImg;
                    picVehicleImageOut.Image = defaultImg;
                    picOverviewImageIn.Image = defaultImg;
                    picVehicleImageIn.Image = defaultImg;
                }));
                this.Cursor = Cursors.WaitCursor;
                btnSearch.Enabled = false;
                dgvData.SelectionChanged -= DgvData_SelectionChanged;
                dgvData.CurrentCell = null;
                EnableFastLoading();

                string keyword = txtKeyword.Text;
                DateTime startTime = dtpStartTime.Value;
                DateTime endTime = dtpEndTime.Value;
                string vehicleTypeId = ((ListItem)cbVehicleType.SelectedItem)?.Value ?? "";
                string identityGroupId = ((ListItem)cbIdentityGroup.SelectedItem)?.Value ?? "";
                string laneId = ((ListItem)cbLane.SelectedItem)?.Value ?? "";
                string user = string.IsNullOrEmpty(((ListItem)cbUser.SelectedItem)?.Value) ? "" : cbUser.Text;

                var report = await ApiServer.reportingService.GetEventOuts(keyword, startTime, endTime, identityGroupId, vehicleTypeId, laneId, user, true, 0, Filter.PAGE_SIZE);
                var eventOutData = report.data;
                totalPages = report.TotalPage;
                totalEvents = report.TotalCount;

                lblTotalEvents.Visible = true;
                lblTotalEvents.Text = "Tổng số sự kiện: " + totalEvents + "\r\nTổng phí gửi xe: " + TextFormatingTool.GetMoneyFormat(report.Revenue.ToString());
                lblTotalEvents.Refresh();

                DisplayNavigation();
                DisplayEventOutData(eventOutData);
                DisableFastLoading();
                eventOutData.Clear();
            }
            catch (Exception)
            {
            }
            finally
            {
                btnSearch.Enabled = true;
                dgvData.SelectionChanged += DgvData_SelectionChanged;
                this.Cursor = Cursors.Default;
            }

        }
        private void btnCancel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
        private void btnExportExcel_Click(object? sender, EventArgs e)
        {
            ExcelTools.CreatReportFile(dgvData, "Báo cáo Xe Ra Khỏi Bãi", new List<string>() { lblTotalEvents.Text });
        }

        private void BtnPrintPhieuThu_Click(object? sender, EventArgs e)
        {
            try
            {
                if (dgvData.Rows.Count == 0)
                {
                    return;
                }
                if (dgvData.CurrentRow == null)
                {
                    MessageBox.Show("Hãy chọn bản ghi cần in phiếu thu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string printTemplatePath = PathManagement.appPrintTemplateConfigPath(((EmPrintTemplate)StaticPool.appOption.PrintTemplate).ToString());
                if (File.Exists(printTemplatePath))
                {
                    bool isConfirm = MessageBox.Show("Bạn có muốn in phiếu thu?", "In phiếu thu", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
                    if (!isConfirm)
                    {
                        return;
                    }
                    string timeIn = dgvData.CurrentRow.Cells[col_time_in].Value.ToString() ?? "";
                    string timeOut = dgvData.CurrentRow.Cells[col_time_out].Value.ToString() ?? "";
                    string plate = dgvData.CurrentRow.Cells[col_plate_out].Value.ToString() ?? "";
                    string chargeStr = dgvData.CurrentRow.Cells[col_parking_fee].Value.ToString() ?? "";
                    string cardName = dgvData.CurrentRow.Cells[col_identity_code].Value.ToString() ?? "";
                    string cardGroupName = dgvData.CurrentRow.Cells[col_identity_group_name].Value.ToString() ?? "";

                    printer.PrintPhieuThu(File.ReadAllText(printTemplatePath), cardName, cardGroupName, null,
                                                         DateTime.Parse(timeIn), DateTime.Parse(timeOut),
                                                         plate, TextFormatingTool.GetMoneyFormat(chargeStr.Replace(".", "").Trim()),
                                                         int.Parse(chargeStr.Replace(".", "").Trim()));
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mẫu in", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS, "ReportInOut", ex);
                MessageBox.Show(ex.Message);
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
                this.Cursor = Cursors.WaitCursor;
                var imageOutDatas = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<EmParkingImageType, List<ImageData>>>(dgvData.CurrentRow?.Cells[col_file_keys_out].Value.ToString()!)!;
                ImageData? displayOverviewOutImage = imageOutDatas.ContainsKey(EmParkingImageType.Overview) ? imageOutDatas[EmParkingImageType.Overview][0] : null;
                ImageData? vehicleOutImage = imageOutDatas.ContainsKey(EmParkingImageType.Vehicle) ? imageOutDatas[EmParkingImageType.Vehicle][0] : null;

                var imageInDatas = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<EmParkingImageType, List<ImageData>>>(dgvData.CurrentRow?.Cells[col_file_keys_in].Value.ToString()!)!;
                ImageData? displayOverviewInImage = imageInDatas.ContainsKey(EmParkingImageType.Overview) ? imageInDatas[EmParkingImageType.Overview][0] : null;
                ImageData? vehicleInImage = imageInDatas.ContainsKey(EmParkingImageType.Vehicle) ? imageInDatas[EmParkingImageType.Vehicle][0] : null;


                var overviewOutTask = ApiServer.parkingProcessService.GetImageUrl(displayOverviewOutImage?.bucket ?? "", displayOverviewOutImage?.objectKey ?? "");
                var vehicleOutTask = ApiServer.parkingProcessService.GetImageUrl(vehicleOutImage?.bucket ?? "", vehicleOutImage?.objectKey ?? "");
                var overviewInTask = ApiServer.parkingProcessService.GetImageUrl(displayOverviewInImage?.bucket ?? "", displayOverviewInImage?.objectKey ?? "");
                var vehicleInTask = ApiServer.parkingProcessService.GetImageUrl(vehicleInImage?.bucket ?? "", vehicleInImage?.objectKey ?? "");

                await Task.WhenAll(overviewOutTask, vehicleOutTask, overviewInTask, vehicleInTask);

                picOverviewImageOut.ShowImageUrlAsync(overviewOutTask.Result);
                picVehicleImageOut.ShowImageUrlAsync(vehicleOutTask.Result);
                picOverviewImageIn.ShowImageUrlAsync(overviewInTask.Result);
                picVehicleImageIn.ShowImageUrlAsync(vehicleInTask.Result);
            }
            catch (Exception ex)
            {
                tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS, "ReportInOut", ex);
            }
            finally
            {
                this.Cursor = Cursors.Hand;
            }
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
                string identityGroupId = ((ListItem)cbIdentityGroup.SelectedItem)?.Value ?? "";
                string laneId = ((ListItem)cbLane.SelectedItem)?.Value ?? "";
                string user = string.IsNullOrEmpty(((ListItem)cbUser.SelectedItem)?.Value) ? "" : cbUser.Text;

                var report = await ApiServer.reportingService.GetEventOuts(keyword, startTime, endTime, identityGroupId, vehicleTypeId, laneId, user, true, pageIndex - 1, Filter.PAGE_SIZE);
                var eventOutData = report.data;

                totalPages = report.TotalPage;
                totalEvents = report.TotalCount;

                DisplayEventOutData(eventOutData);
                DisableFastLoading();
                eventOutData.Clear();
            }));

        }
        private void ChangeSearchConditionEvent(object? sender, EventArgs e)
        {
            btnSearch.PerformClick();
        }
        #endregion

        #region Private Function
        private void CreateUI()
        {
            try
            {
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
                            tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS, "ReportInOut", ex);
                        }
                    }
                }
                panelData.SuspendLayout();
                tablePic.SuspendLayout();
                panelSearch.SuspendLayout();

                btnCancel.InitControl(btnCancel_Click);
                btnExportExcel.InitControl(btnExportExcel_Click);
                btnSearch.InitControl(btnSearch_Click);
                btnPrintPhieuThu.InitControl(BtnPrintPhieuThu_Click);

                picOverviewImageIn.Image = picOverviewImageIn.ErrorImage = defaultImg;
                picVehicleImageIn.Image = picVehicleImageIn.ErrorImage = defaultImg;
                picOverviewImageOut.Image = picOverviewImageOut.ErrorImage = defaultImg;
                picVehicleImageOut.Image = picVehicleImageOut.ErrorImage = defaultImg;

                btnPrintPhieuThu.Text = "In phiếu thu";
                btnPrintPhieuThu.Width = btnPrintPhieuThu.PreferredSize.Width;
                btnPrintPhieuThu.Anchor = btnSearch.Anchor;
                int rootSize = TextManagement.ROOT_SIZE;
                btnSearch.Location = new Point(panelSearch.Location.X + panelSearch.Width + rootSize,
                                               panelSearch.Location.Y + panelSearch.Height - btnSearch.Height);

                btnPrintPhieuThu.Location = new Point(btnSearch.Location.X + btnSearch.Width + 10, btnSearch.Location.Y);

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

                lblTotalEvents.Location = new Point(btnPrintPhieuThu.Location.X + btnPrintPhieuThu.Width + rootSize,
                                                    btnPrintPhieuThu.Location.Y - lblTotalEvents.Height + btnPrintPhieuThu.Height);

                cbVehicleType.DisplayMember = cbIdentityGroup.DisplayMember = cbLane.DisplayMember = cbUser.DisplayMember = "Name";
                cbVehicleType.ValueMember = cbIdentityGroup.ValueMember = cbLane.ValueMember = cbUser.ValueMember = "Value";

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
                this.SizeChanged += FrmReportInOut_SizeChanged;
            }
            catch (Exception ex)
            {
                tblSystemLog.SaveLog(EmSystemAction.Application, EmSystemActionDetail.PROCESS, "ReportInOut", ex);
            }

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
            ucPages1.UpdateMaxPage(totalPages);
            if (totalPages <= 1)
            {
                ucPages1.Visible = false;
            }
            FrmReportInOut_SizeChanged(null, null);
        }
        private void DisplayEventOutData(List<EventOutReport> eventOutData)
        {
            try
            {
                List<DataGridViewRow> rows = new List<DataGridViewRow>();
                foreach (var item in eventOutData)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    this.Invoke(new Action(() =>
                    {
                        row.CreateCells(dgvData);
                    }));
                    DateTime? timeIn = item.EventIn.DateTimeIn == null ? null : item.EventIn.DateTimeIn.Value;
                    string moneyStr = TextFormatingTool.GetMoneyFormat(item.Charge.ToString());

                    row.Cells[dgvData.Columns[col_event_out_id].Index].Value = item.Id;
                    row.Cells[dgvData.Columns[col_event_in_id].Index].Value = item.EventIn.Id;
                    row.Cells[dgvData.Columns[col_invoice_pending_id].Index].Value = "";
                    row.Cells[dgvData.Columns[col_invoice_id].Index].Value = "";
                    row.Cells[dgvData.Columns[col_file_keys_in].Index].Value = item.EventIn.images == null ? "[]" : Newtonsoft.Json.JsonConvert.SerializeObject(item.EventIn.images);
                    row.Cells[dgvData.Columns[col_file_keys_out].Index].Value = item.images == null ? "[]" : Newtonsoft.Json.JsonConvert.SerializeObject(item.images);
                    row.Cells[dgvData.Columns[col_index].Index].Value = rows.Count + 1;
                    row.Cells[dgvData.Columns[col_plate_in].Index].Value = item.EventIn.PlateNumber;
                    row.Cells[dgvData.Columns[col_plate_out].Index].Value = item.PlateNumber;
                    row.Cells[dgvData.Columns[col_time_in].Index].Value = timeIn.ToVNTime();
                    row.Cells[dgvData.Columns[col_time_out].Index].Value = item.DatetimeOut.ToVNTime();
                    row.Cells[dgvData.Columns[col_parking_time].Index].Value = item.DatetimeOut!.Value - item.EventIn.DateTimeIn!.Value;
                    row.Cells[dgvData.Columns[col_identity_group_name].Index].Value = item.IdentityGroup.Name;
                    row.Cells[dgvData.Columns[col_parking_fee].Index].Value = moneyStr.Substring(0, moneyStr.Length - 1);
                    row.Cells[dgvData.Columns[col_identity_code].Index].Value = item.Identity.Code;
                    row.Cells[dgvData.Columns[col_user_in].Index].Value = item.EventIn.CreatedBy;
                    row.Cells[dgvData.Columns[col_user_out].Index].Value = item.CreatedBy;
                    row.Cells[dgvData.Columns[col_invoice_template].Index].Value = "";
                    row.Cells[dgvData.Columns[col_invoice_no].Index].Value = "";
                    row.Cells[dgvData.Columns[col_lane_in_name].Index].Value = item.EventIn.Lane.name;
                    row.Cells[dgvData.Columns[col_lane_out_name].Index].Value = item.Lane.name;
                    row.Cells[dgvData.Columns[col_note].Index].Value = item.EventIn.Note;
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
                eventOutData.Clear();
                InvoiceDatas.Clear();
            }
            catch (Exception)
            {
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
            cbIdentityGroup.Invoke(new Action(() =>
            {
                cbIdentityGroup.Items.Add(new ListItem()
                {
                    Name = "Tất cả",
                    Value = ""
                });
            }));

            identityGroups = identityGroups.OrderBy(x => x.Name).ThenBy(x => x.Name.Length).ToList();

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
        #endregion End Private Function

        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip ctx = new ContextMenuStrip();
                ctx.Items.Add("Sửa ghi chú BSX").Name = "UpdateNote";
                if (StaticPool.appOption.IsAllowEditPlateOut)
                {
                    ctx.Items.Add("Sửa biển số vào").Name = "UpdatePlateIn";
                    ctx.Items.Add("Sửa biển số ra").Name = "UpdatePlateOut";
                }
                string pendingOrderId = dgvData.Rows[e.RowIndex].Cells[col_invoice_pending_id].Value.ToString() ?? "";
                if (!string.IsNullOrEmpty(pendingOrderId))
                {
                    ctx.Items.Add("Gửi hóa đơn").Name = "SendPendingEInvoice";
                }
                ctx.Font = new Font(dgvData.Font.Name, 16, FontStyle.Bold);
                ctx.BackColor = Color.DarkOrange;
                ctx.ItemClicked += async (sender, ctx_e) =>
                {
                    string eventInId = dgvData.Rows[e.RowIndex].Cells[col_event_in_id].Value.ToString() ?? "";
                    string eventOutId = dgvData.Rows[e.RowIndex].Cells[col_event_out_id].Value.ToString() ?? "";
                    string currentPlateIn = dgvData.Rows[e.RowIndex].Cells[col_plate_in].Value.ToString() ?? "";
                    string currentPlateOut = dgvData.Rows[e.RowIndex].Cells[col_plate_out].Value.ToString() ?? "";
                    string currentNote = dgvData.Rows[e.RowIndex].Cells[col_note].Value.ToString() ?? "";
                    switch (ctx_e.ClickedItem.Name.ToString())
                    {
                        case "UpdateNote":
                            var frmUpdateNote = new frmEditNote(currentNote, eventOutId, false, this.ApiServer);
                            if (frmUpdateNote.ShowDialog() == DialogResult.OK)
                            {
                                dgvData.Rows[e.RowIndex].Cells[col_note].Value = frmUpdateNote.newNote;
                                frmUpdateNote.Dispose();
                            }
                            break;
                        case "UpdatePlateIn":
                            {
                                var frmUpdatePlate = new frmEditPlate(currentPlateIn, eventInId, true, this.ApiServer);
                                if (frmUpdatePlate.ShowDialog() == DialogResult.OK)
                                {
                                    dgvData.Rows[e.RowIndex].Cells[col_plate_in].Value = frmUpdatePlate.UpdatePlate;
                                    frmUpdatePlate.Dispose();
                                }
                            }
                            break;
                        case "UpdatePlateOut":
                            {
                                var frmUpdatePlate = new frmEditPlate(currentPlateOut, eventOutId, false, this.ApiServer);
                                if (frmUpdatePlate.ShowDialog() == DialogResult.OK)
                                {
                                    dgvData.Rows[e.RowIndex].Cells[col_plate_out].Value = frmUpdatePlate.UpdatePlate;
                                    frmUpdatePlate.Dispose();
                                }
                            }
                            break;
                        case "SendPendingEInvoice":
                            {
                                bool isSendSuccess = await ApiServer.invoiceService.sendPendingEInvoice(pendingOrderId);
                                if (isSendSuccess)
                                {
                                    MessageBox.Show("Gửi hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    btnSearch_Click(null, null);
                                }
                                else
                                {
                                    MessageBox.Show("Gửi hóa đơn không thành công, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        private void dgvData_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private void Pic_LoadCompleted(object? sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            PictureBox pictureBox = (sender as PictureBox)!;
            if (e.Error != null)
            {
                pictureBox.Image = defaultImg;
            }
        }

        private void btnPrintInternet_Click_1(object sender, EventArgs e)
        {

        }
    }

}
