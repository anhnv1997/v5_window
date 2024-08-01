using DocumentFormat.OpenXml.Vml;
using IPaking.Ultility;
using iPakrkingv5.Controls;
using iPakrkingv5.Controls.Controls.Buttons;
using iParkingv5.ApiManager.KzParkingv5Apis;
using iParkingv5.Objects;
using iParkingv5.Objects.Databases;
using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Datas.Device_service;
using iParkingv5.Objects.Datas.invoice_service;
using iParkingv5.Objects.Datas.parking_service;
using iParkingv5.Objects.Datas.user_service;
using iParkingv5.Objects.Datas.warehouse_service;
using iParkingv5.Objects.Enums;
using iParkingv5.Objects.EventDatas;
using iParkingv5_window.Forms.DataForms;
using iParkingv5_window.Helpers;
using iParkingv5_window.Usercontrols.BuildControls;
using Kztek.Helper;
using Kztek.Tool.TextFormatingTools;
using Kztek.Tools;
using System.Data;
using System.Runtime.InteropServices;
using static iParkingv5.Objects.Enums.ParkingImageType;
using static iParkingv5.Objects.Enums.PrintHelpers;
using ImageData = iParkingv5.Objects.EventDatas.ImageData;

namespace iParkingv5_window.Forms.ReportForms
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
        private List<RegisteredVehicle> registerVehicles = new List<RegisteredVehicle>();
        private List<Customer> customers = new List<Customer>();
        private List<User> users = new List<User>();
        List<InvoiceResponse> InvoiceDatas = new List<InvoiceResponse>();
        List<InvoiceResponse> pendingDatas = new List<InvoiceResponse>();
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

            if (!StaticPool.eInvoiceConfig.IsUseEInvoice)
            {
                dgvData.Columns[col_invoice_no].Visible = false;
                dgvData.Columns[col_invoice_template].Visible = false;
            }
            lblMoney.Text = "Tổng Số: " + TextFormatingTool.GetMoneyFormat("0");

            this.ToggleDoubleBuffered(true);
            panelData.ToggleDoubleBuffered(true);
            dgvData.ToggleDoubleBuffered(true);

            this.Load += FrmReportInOut_Load;
            this.SizeChanged += FrmReportInOut_SizeChanged;
        }
        private async void FrmReportInOut_Load(object? sender, EventArgs e)
        {
            try
            {
                registerVehicles = (await AppData.ApiServer.parkingDataService.GetRegisterVehiclesAsync("")).Item1;

                customers = (await AppData.ApiServer.parkingDataService.GetCustomersAsync())?.Item1 ?? new List<Customer>();

                await CreateUI();
                this.ActiveControl = btnSearch;
                btnSearch.PerformClick();
                picOverviewImageIn.Image = picOverviewImageIn.ErrorImage = defaultImg;
                picVehicleImageIn.Image = picVehicleImageIn.ErrorImage = defaultImg;
                picOverviewImageOut.Image = picOverviewImageOut.ErrorImage = defaultImg;
                picVehicleImageOut.Image = picVehicleImageOut.ErrorImage = defaultImg;

                cbVehicleType.SelectedIndexChanged += ChangeSearchConditionEvent;
                cbIdentityGroup.SelectedIndexChanged += ChangeSearchConditionEvent;
                cbLane.SelectedIndexChanged += ChangeSearchConditionEvent;
                cbUser.SelectedIndexChanged += ChangeSearchConditionEvent;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.System, mo_ta_them: ex);
            }
            finally
            {
                GC.Collect();
            }
        }
        private void FrmReportInOut_SizeChanged(object? sender, EventArgs e)
        {
            dgvData.Location = new Point(TextManagement.ROOT_SIZE * 2, cbLane.Location.Y + cbLane.Height + TextManagement.ROOT_SIZE);

            if (ucPages1.Visible)
            {
                dgvData.Height = ucPages1.Location.Y - dgvData.Location.Y - TextManagement.ROOT_SIZE * 2 - lblMoney.Height - 16;
            }
            else
            {
                dgvData.Height = ucPages1.Location.Y + ucPages1.Height - dgvData.Location.Y - TextManagement.ROOT_SIZE * 2 - lblMoney.Height;
            }
            tablePic.Height = dgvData.Height;
            tablePic.Width = tablePic.Height * 9 * 2 / 30;

            dgvData.Width = this.DisplayRectangle.Width - StaticPool.baseSize * 5 - tablePic.Width;

            tablePic.Location = new Point(panelData.Width - tablePic.Width - StaticPool.baseSize * 2,
                                          dgvData.Location.Y);

            lblTotalEvents.Location = new Point(btnPrintOffline.Location.X + btnPrintOffline.Width + TextManagement.ROOT_SIZE,
                                             btnPrintOffline.Location.Y - lblTotalEvents.Height + btnPrintOffline.Height);
            lblMoney.Location = new Point(dgvData.Location.X + (dgvData.Width - lblMoney.Width), dgvData.Location.Y + dgvData.Height + 16);
            this.Refresh();
        }
        #endregion End Forms

        #region Controls In Form
        public static Image defaultImg = Image.FromFile(frmMain.defaultImagePath);
        List<EventOutReport> eventOutData = new List<EventOutReport>();

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
                btnSearch.Enabled = false;
                EnableFastLoading();

                string keyword = txtKeyword.Text;
                DateTime startTime = dtpStartTime.Value;
                DateTime endTime = dtpEndTime.Value;
                string vehicleTypeId = ((ListItem)cbVehicleType.SelectedItem)?.Value ?? "";
                string identityGroupId = ((ListItem)cbIdentityGroup.SelectedItem)?.Value ?? "";
                string laneId = ((ListItem)cbLane.SelectedItem)?.Value ?? "";
                string user = string.IsNullOrEmpty(((ListItem)cbUser.SelectedItem)?.Value) ? "" : cbUser.Text;

                var report = await AppData.ApiServer.reportingService.GetEventOuts(keyword, startTime, endTime, identityGroupId, vehicleTypeId, laneId, user, 1, Filter.PAGE_SIZE);
                var eventOutData = report.data;
                totalPages = report.TotalPage;
                totalEvents = report.TotalCount;

                DisplayNavigation();
                await DisplayEventOutData(eventOutData);
                DisableFastLoading();
                eventOutData.Clear();
            }
            catch (Exception)
            {
            }
            finally
            {
                btnSearch.Enabled = true;
            }

        }
        private void btnCancel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
        private void btnExportExcel_Click(object? sender, EventArgs e)
        {
            ExcelTools.CreatReportFile(dgvData, "Báo cáo Xe Ra Khỏi Bãi", new List<string>() { });
        }

        private void BtnPrintOffline_Click(object? sender, EventArgs e)
        {
            try
            {
                if (dgvData.Rows.Count == 0)
                {
                    return;
                }
                if (dgvData.CurrentRow == null)
                {
                    MessageBox.Show("Hãy chọn bản ghi cần in hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string printTemplatePath = PathManagement.appPrintTemplateConfigPath(((EmPrintTemplate)StaticPool.appOption.PrintTemplate).ToString());
                if (File.Exists(printTemplatePath))
                {
                    bool isConfirm = MessageBox.Show("Bạn có muốn in hóa đơn?", "In hóa đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
                    if (!isConfirm)
                    {
                        return;
                    }
                    string timeIn = dgvData.CurrentRow.Cells[col_time_in].Value.ToString() ?? "";
                    string timeOut = dgvData.CurrentRow.Cells[col_time_out].Value.ToString() ?? "";
                    string plate = dgvData.CurrentRow.Cells[col_plate_out].Value.ToString() ?? "";
                    string chargeStr = dgvData.CurrentRow.Cells[col_parking_fee].Value.ToString() ?? "";
                    string printContent = PrintHelper.GetParkingPrintContent(File.ReadAllText(printTemplatePath),
                                                          DateTime.Parse(timeIn), DateTime.Parse(timeOut),
                                                          plate, TextFormatingTool.GetMoneyFormat(chargeStr.Replace(".", "").Trim()),
                                                          int.Parse(chargeStr.Replace(".", "").Trim()));
                    var wbPrint = new WebBrowser();
                    wbPrint.DocumentCompleted += WbPrint_DocumentCompleted;
                    wbPrint.DocumentText = printContent;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mẫu in", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.System, obj: ex);
            }

        }
        private void btnPrintPhieuThu_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count == 0)
            {
                return;
            }
            if (dgvData.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn bản ghi cần in hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string printTemplatePath = PathManagement.appPrintPhieuThu(((EmPrintTemplate)StaticPool.appOption.PrintTemplate).ToString());
            if (File.Exists(printTemplatePath))
            {
                bool isConfirm = MessageBox.Show("Bạn có muốn in phiếu thu?", "In hóa đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
                if (!isConfirm)
                {
                    return;
                }

                string timeIn = dgvData.CurrentRow.Cells[col_time_in].Value.ToString() ?? "";
                string timeOut = dgvData.CurrentRow.Cells[col_time_out].Value.ToString() ?? "";
                string plate = dgvData.CurrentRow.Cells[col_plate_out].Value.ToString() ?? "";
                string chargeStr = dgvData.CurrentRow.Cells[col_parking_fee].Value.ToString() ?? "";
                int chargeInt = int.Parse(chargeStr.Replace(".", "").Trim());
                string IdentityCode = dgvData.CurrentRow.Cells[col_identity_code].Value.ToString() ?? "";
                string IdentityGroup = dgvData.CurrentRow.Cells[col_identity_group_name].Value.ToString() ?? "";

                string printContent = PrintHelper.GetPhieuThuContent(File.ReadAllText(printTemplatePath),
                                                     IdentityCode, IdentityGroup, picVehicleImageOut.Image,
                                                     DateTime.Parse(timeIn), DateTime.Parse(timeOut),
                                                     plate, TextFormatingTool.ConvertToMoneyFormat<int>(chargeInt), chargeInt);
                var wbPrint = new WebBrowser();
                wbPrint.DocumentCompleted += WbPrint_DocumentCompleted;
                wbPrint.DocumentText = printContent;
            }
            else
            {
                MessageBox.Show("Không tìm thấy mẫu in", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private async void DgvData_SelectionChanged(object? sender, EventArgs e)
        {
            try
            {
                var imageOutDatas = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<EmParkingImageType, List<ImageData>>>(dgvData.CurrentRow?.Cells[col_file_keys_out].Value.ToString()!)!;
                ImageData? displayOverviewOutImage = imageOutDatas.ContainsKey(EmParkingImageType.Overview) ? imageOutDatas[EmParkingImageType.Overview][0] : null;
                ImageData? vehicleOutImage = imageOutDatas.ContainsKey(EmParkingImageType.Vehicle) ? imageOutDatas[EmParkingImageType.Vehicle][0] : null;

                var task1 = ShowImage(displayOverviewOutImage, picOverviewImageOut);
                var task2 = ShowImage(vehicleOutImage, picVehicleImageOut);

                var imageInDatas = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<EmParkingImageType, List<ImageData>>>(dgvData.CurrentRow?.Cells[col_file_keys_in].Value.ToString()!)!;
                ImageData? displayOverviewInImage = imageInDatas.ContainsKey(EmParkingImageType.Overview) ? imageInDatas[EmParkingImageType.Overview][0] : null;
                ImageData? vehicleInImage = imageInDatas.ContainsKey(EmParkingImageType.Vehicle) ? imageInDatas[EmParkingImageType.Vehicle][0] : null;


                var task3 = ShowImage(displayOverviewInImage, picOverviewImageIn);
                var task4 = ShowImage(vehicleInImage, picVehicleImageIn);
                await Task.WhenAll(task1, task2, task3, task4);
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

                var report = await AppData.ApiServer.reportingService.GetEventOuts(keyword, startTime, endTime, identityGroupId, vehicleTypeId, laneId, user, 1, Filter.PAGE_SIZE);
                var eventOutData = report.data;

                totalPages = report.TotalPage;
                totalEvents = report.TotalCount;

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
        private void ChangeSearchConditionEvent(object? sender, EventArgs e)
        {
            btnSearch.PerformClick();
        }
        #endregion

        #region Private Function
        private async Task CreateUI()
        {
            try
            {
                panelData.SuspendLayout();
                btnCancel.InitControl(btnCancel_Click);
                btnExportExcel.InitControl(btnExportExcel_Click);
                btnSearch.InitControl(btnSearch_Click);
                btnPrintOffline.InitControl(BtnPrintOffline_Click);
                btnPrintOffline.Text = "In hóa đơn";
                btnPrintOffline.Width = btnPrintOffline.PreferredSize.Width;

                panelData.ToggleDoubleBuffered(true);

                //Từ khóa
                lblKeyword.Location = new Point(StaticPool.baseSize * 2, StaticPool.baseSize * 2);
                txtKeyword.Location = new Point(lblKeyword.Location.X + lblUser.Width + StaticPool.baseSize,
                                                lblKeyword.Location.Y + (lblKeyword.Height - txtKeyword.Height) / 2);

                // Giờ bắt đầu
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
                lblIdentityGroup.Location = new Point(lblEndTime.Location.X, lblVehicleType.Location.Y);
                cbIdentityGroup.Location = new Point(dtpEndTime.Location.X, cbVehicleType.Location.Y);


                //Làn
                cbLane.Location = new Point(dtpEndTime.Location.X, cbUser.Location.Y);
                lblLane.Location = new Point(lblEndTime.Location.X, lblUser.Location.Y);

                txtKeyword.Width = dtpEndTime.Width + dtpEndTime.Location.X - txtKeyword.Location.X;

                btnSearch.Location = new Point(cbLane.Location.X + cbLane.Width + TextManagement.ROOT_SIZE,
                                              cbLane.Location.Y + cbLane.Height - btnSearch.Height);

                btnPrintOffline.Location = new Point(btnSearch.Location.X + btnSearch.Width + 10, btnSearch.Location.Y);

                btnCancel.Location = new Point(panelData.Width - btnCancel.Width - StaticPool.baseSize * 2,
                                               panelData.Height - btnCancel.Height - StaticPool.baseSize * 2);
                btnExportExcel.Location = new Point(btnCancel.Location.X - btnExportExcel.Width - StaticPool.baseSize,
                                                    btnCancel.Location.Y);

                ucPages1.Location = new Point(StaticPool.baseSize * 2, btnCancel.Location.Y - ucPages1.Height - StaticPool.baseSize);
                ucPages1.Width = panelData.Width - StaticPool.baseSize * 4;

                dgvData.Location = new Point(TextManagement.ROOT_SIZE * 2, cbLane.Location.Y + cbLane.Height + TextManagement.ROOT_SIZE);

                if (ucPages1.Visible)
                {
                    dgvData.Height = ucPages1.Location.Y - dgvData.Location.Y - TextManagement.ROOT_SIZE * 2 - lblMoney.Height;
                }
                else
                {
                    dgvData.Height = ucPages1.Location.Y + ucPages1.Height - dgvData.Location.Y - TextManagement.ROOT_SIZE * 2 - lblMoney.Height;
                }
                tablePic.Height = dgvData.Height;
                tablePic.Width = tablePic.Height * 9 * 2 / 30;

                dgvData.Width = this.DisplayRectangle.Width - StaticPool.baseSize * 5 - tablePic.Width;

                tablePic.Location = new Point(panelData.Width - tablePic.Width - StaticPool.baseSize * 2,
                                              dgvData.Location.Y);


                lblTotalEvents.Location = new Point(btnPrintOffline.Location.X + btnPrintOffline.Width + TextManagement.ROOT_SIZE,
                                                    btnPrintOffline.Location.Y - lblTotalEvents.Height + btnPrintOffline.Height);

                lblMoney.Location = new Point(dgvData.Location.X + (dgvData.Width - lblMoney.Width), dgvData.Location.Y + dgvData.Height + 16);

                cbVehicleType.DisplayMember = cbIdentityGroup.DisplayMember = cbLane.DisplayMember = cbUser.DisplayMember = "Name";
                cbVehicleType.ValueMember = cbIdentityGroup.ValueMember = cbLane.ValueMember = cbUser.ValueMember = "Value";

                await LoadVehicleTypeData();
                await LoadIdentityGroup();
                await LoadLaneType();
                await LoadUsers();
                panelData.ResumeLayout();
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.System, mo_ta_them: ex);
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
        private async Task DisplayEventOutData(List<EventOutData> eventOutData)
        {
            long total = 0;
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (var item in eventOutData)
            {
                DataGridViewRow row = new DataGridViewRow();
                this.Invoke(new Action(() =>
                {
                    row.CreateCells(dgvData);
                }));
                int i = 0;
                DateTime? timeIn = item.eventIn.DatetimeIn == null ? null : item.eventIn.DatetimeIn.Value;
                string moneyStr = TextFormatingTool.GetMoneyFormat(item.charge.ToString());

                row.Cells[dgvData.Columns[col_event_out_id].Index].Value = item.Id;
                row.Cells[dgvData.Columns[col_event_in_id].Index].Value = item.eventIn.Id;
                row.Cells[dgvData.Columns[col_invoice_pending_id].Index].Value = "";
                row.Cells[dgvData.Columns[col_invoice_id].Index].Value = "";
                row.Cells[dgvData.Columns[col_file_keys_in].Index].Value = item.eventIn.images == null ? "[]" : Newtonsoft.Json.JsonConvert.SerializeObject(item.eventIn.images);
                row.Cells[dgvData.Columns[col_file_keys_out].Index].Value = item.images == null ? "[]" : Newtonsoft.Json.JsonConvert.SerializeObject(item.images);
                row.Cells[dgvData.Columns[col_index].Index].Value = rows.Count + 1;
                row.Cells[dgvData.Columns[col_plate_in].Index].Value = item.eventIn.PlateNumber;
                row.Cells[dgvData.Columns[col_plate_out].Index].Value = item.PlateNumber;
                row.Cells[dgvData.Columns[col_time_in].Index].Value = timeIn.ToVNTime();
                row.Cells[dgvData.Columns[col_time_out].Index].Value = item.DatetimeOut.ToVNTime();
                row.Cells[dgvData.Columns[col_parking_time].Index].Value = item.DatetimeOut!.Value - item.eventIn.DatetimeIn!.Value;
                row.Cells[dgvData.Columns[col_identity_group_name].Index].Value = item.IdentityGroup.Name;
                row.Cells[dgvData.Columns[col_parking_fee].Index].Value = moneyStr.Substring(0, moneyStr.Length - 1);
                row.Cells[dgvData.Columns[col_identity_code].Index].Value = item.Identity.Code;
                row.Cells[dgvData.Columns[col_user_in].Index].Value = item.eventIn.createdBy;
                row.Cells[dgvData.Columns[col_user_out].Index].Value = item.createdBy;
                row.Cells[dgvData.Columns[col_invoice_template].Index].Value = "";
                row.Cells[dgvData.Columns[col_invoice_no].Index].Value = "";
                row.Cells[dgvData.Columns[col_lane_in_name].Index].Value = item.eventIn.Lane.name;
                row.Cells[dgvData.Columns[col_lane_out_name].Index].Value = item.Lane.name;
                row.Cells[dgvData.Columns[col_note].Index].Value = item.eventIn.note;
                rows.Add(row);
                total += item.charge;
            }
            this.Invoke(new Action(() =>
            {
                dgvData.Rows.AddRange(rows.ToArray());
                lblMoney.Text = TextFormatingTool.GetMoneyFormat(total.ToString());
            }));
            eventOutData.Clear();
            InvoiceDatas.Clear();
        }
        private async Task ShowImage(ImageData? imageData, PictureBox pic)
        {
            try
            {
                if (imageData == null)
                {
                    pic.Image = defaultImg;
                }
                else
                {
                    string imageUrl = await AppData.ApiServer.parkingProcessService.GetImageUrl(imageData.bucket, imageData.objectKey);
                    pic.LoadAsync(imageUrl);
                }
            }
            catch (Exception)
            {
                pic.Image = defaultImg;
            }
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
            cbIdentityGroup.Invoke(new Action(() =>
            {
                cbIdentityGroup.Items.Add(new ListItem()
                {
                    Name = "Tất cả",
                    Value = ""
                });
            }));

            identityGroups = (await AppData.ApiServer.parkingDataService.GetIdentityGroupsAsync()).Item1 ?? new List<IdentityGroup>();
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
            Lane? selectedLane = lanes.Where(lane => lane.Id.ToUpper() == laneId.ToUpper()).FirstOrDefault();
            return selectedLane == null ? "" : selectedLane.name;
        }
        private string GetIdentityGroupName(string identityGroupId)
        {
            IdentityGroup? selectedIdentityGroup = identityGroups.Where(e => e.Id.ToString().ToUpper() == identityGroupId.ToUpper()).FirstOrDefault();
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
            var registerVehicle = registerVehicles.Where(e => e.Id.ToUpper().ToUpper() == registerVehicleId.ToUpper()).FirstOrDefault();
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
            Customer? customer = customers.Where(e => e.Id.ToUpper() == customerID.ToUpper()).FirstOrDefault();
            return customer == null ? "" : customer.Name + " / " + customer.PhoneNumber;
        }
        #endregion End Private Function

        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip ctx = new ContextMenuStrip();
                ctx.Items.Add("Sửa ghi chú BSX", Properties.Resources.setting_0_0_0_32px).Name = "UpdateNote";
                if (StaticPool.appOption.IsAllowEditPlateOut)
                {
                    ctx.Items.Add("Sửa biển số vào", Properties.Resources.setting_0_0_0_32px).Name = "UpdatePlateIn";
                    ctx.Items.Add("Sửa biển số ra", Properties.Resources.setting_0_0_0_32px).Name = "UpdatePlateOut";
                }
                string pendingOrderId = dgvData.Rows[e.RowIndex].Cells[col_invoice_pending_id].Value.ToString() ?? "";
                if (!string.IsNullOrEmpty(pendingOrderId))
                {
                    ctx.Items.Add("Gửi hóa đơn", Properties.Resources.setting_0_0_0_32px).Name = "SendPendingEInvoice";
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
                            var frmUpdateNote = new frmEditNote(currentNote, eventOutId, false);
                            if (frmUpdateNote.ShowDialog() == DialogResult.OK)
                            {
                                dgvData.Rows[e.RowIndex].Cells[col_note].Value = frmUpdateNote.newNote;
                                frmUpdateNote.Dispose();
                            }
                            break;
                        case "UpdatePlateIn":
                            {
                                var frmUpdatePlate = new frmEditPlate(currentPlateIn, eventInId, true);
                                if (frmUpdatePlate.ShowDialog() == DialogResult.OK)
                                {
                                    dgvData.Rows[e.RowIndex].Cells[col_plate_in].Value = frmUpdatePlate.UpdatePlate;
                                    frmUpdatePlate.Dispose();
                                }
                            }

                            break;
                        case "UpdatePlateOut":
                            {
                                var frmUpdatePlate = new frmEditPlate(currentPlateOut, eventOutId, false);
                                if (frmUpdatePlate.ShowDialog() == DialogResult.OK)
                                {
                                    dgvData.Rows[e.RowIndex].Cells[col_plate_out].Value = frmUpdatePlate.UpdatePlate;
                                    frmUpdatePlate.Dispose();
                                }
                            }
                            break;
                        case "SendPendingEInvoice":
                            {
                                bool isSendSuccess = await AppData.ApiServer.invoiceService.sendPendingEInvoice(pendingOrderId);
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
