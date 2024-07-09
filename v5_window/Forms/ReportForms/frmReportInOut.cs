using IPaking.Ultility;
using iPakrkingv5.Controls;
using iPakrkingv5.Controls.Controls.Buttons;
using iParkingv5.ApiManager.KzParkingv5Apis;
using iParkingv5.Objects;
using iParkingv5.Objects.Databases;
using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Enums;
using iParkingv5.Objects.Invoices;
using iParkingv5.Objects.warehouse;
using iParkingv5_window.Forms.DataForms;
using iParkingv5_window.Helpers;
using iParkingv5_window.Usercontrols.BuildControls;
using iParkingv6.Objects.Datas;
using Kztek.Tool.TextFormatingTools;
using Kztek.Tools;
using System.Data;
using System.Globalization;
using System.Runtime.InteropServices;
using static iParkingv5.ApiManager.KzParkingv5Apis.KzParkingv5ApiHelper;
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

            lblMoney.Text = "Tổng Số: " + TextFormatingTool.GetMoneyFormat("0");

            this.ToggleDoubleBuffered(true);
            panelData.ToggleDoubleBuffered(true);
            dgvData.ToggleDoubleBuffered(true);

            this.Load += FrmReportInOut_Load;
            this.KeyDown += FrmReportInOut_KeyDown;
            this.SizeChanged += FrmReportInOut_SizeChanged;
        }
        private async void FrmReportInOut_Load(object? sender, EventArgs e)
        {
            try
            {
                //dgvData.VirtualMode = true;
                //dgvData.CellValueNeeded += DgvData_CellValueNeeded;
                //registerVehicles = await KzParkingApiHelper.GetRegisteredVehicles("");
                registerVehicles = (await AppData.ApiServer.GetRegisterVehiclesAsync("")).Item1;

                //customers = (await KzParkingApiHelper.GetAllCustomers())?.Item1 ?? new List<Customer>();
                customers = (await AppData.ApiServer.GetCustomersAsync())?.Item1 ?? new List<Customer>();

                if (StaticPool.appOption.PrintTemplate != (int)EmPrintTemplate.XuanCuong)
                {
                    dgvData.Columns["vehicle_reagion_type"].Visible = false;
                    dgvData.Columns["WarehouseType"].Visible = false;
                    dgvData.Columns["WarehouseCode"].Visible = false;
                    dgvData.Columns["vehicle_reagion_type"].Visible = false;
                    dgvData.Columns["note_3rd_1"].Visible = false;
                    dgvData.Columns["note_3rd_2"].Visible = false;
                    dgvData.Columns["note_3rd_3"].Visible = false;
                    lblVN.Visible = false;
                    lblTQ.Visible = false;
                }

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
        private void FrmReportInOut_KeyDown(object? sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Return:
                    btnSearch_Click(null, null);
                    break;
                case Keys.F6:
                    btnPrintPhieuThu_Click(null, null);
                    break;
                case Keys.F7:
                    BtnPrintInternet_Click(null, null);
                    break;
                case Keys.F8:
                    BtnPrintOffline_Click(null, null);
                    break;
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
            lblVN.Location = new Point(dgvData.Location.X, lblMoney.Location.Y);
            lblTQ.Location = new Point(dgvData.Location.X, lblVN.Location.Y + lblVN.Height + 3);
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

                var eventOutReportNew = await AppData.ApiServer.GetEventOuts(keyword, startTime, endTime, identityGroupId, vehicleTypeId, laneId, user);

                if (eventOutReportNew == null)
                {
                    DisableFastLoading();
                    ucNotify1.Show(ucNotify.EmNotiType.Error, "Không tải được thông tin xe trong bãi. Vui lòng thử lại!");
                    return;
                }
                //try
                //{
                //    long? money = await KzParkingApiHelper.GetSummary(startTime, endTime);
                //    if (money == null)
                //    {
                //        lblMoney.Text = "Tổng Số: _";
                //    }
                //    else
                //    {
                //        lblMoney.Text = "Tổng Số: " + TextFormatingTool.GetMoneyFormat(money!.ToString());
                //    }
                //    lblMoney.Location = new Point(dgvData.Location.X + (dgvData.Width - lblMoney.Width), dgvData.Location.Y + dgvData.Height + 16);
                //}
                //catch (Exception)
                //{
                //}

                totalPages = 1;
                totalEvents = eventOutReportNew.Rows.Count;
                eventOutData = new List<EventOutReport>();

                List<string> ids = new List<string>();
                foreach (DataRow item in eventOutReportNew.Rows)
                {
                    string transactionCode = eventOutReportNew.Columns.Contains("transactioncode") ? item["transactioncode"].ToString() ?? "" : "";
                    transactionCode = transactionCode.Contains("0-0") ? "" : transactionCode;
                    int transactionType = 0;
                    try
                    {
                        transactionType = eventOutReportNew.Columns.Contains("transactiontype") ? int.Parse(item["transactiontype"].ToString() ?? "0") : 0;
                    }
                    catch (Exception)
                    {
                    }
                    EventOutReport ev = new EventOutReport()
                    {
                        id = eventOutReportNew.Columns.Contains("id") ? item["id"].ToString() : "",
                        eventinid = eventOutReportNew.Columns.Contains("eventinid") ? item["eventinid"].ToString() : "",

                        eventInCreatedUtc = eventOutReportNew.Columns.Contains("eventincreatedutc") ? item["eventincreatedutc"].ToString() : "",
                        createdUtc = eventOutReportNew.Columns.Contains("createdutc") ? item["createdutc"].ToString() : "",

                        IdentityName = eventOutReportNew.Columns.Contains("identityname") ? item["identityname"].ToString() : "",
                        IdentityGroupId = eventOutReportNew.Columns.Contains("identitygroupid") ? item["identitygroupid"].ToString() : "",

                        eventInPlateNumber = eventOutReportNew.Columns.Contains("eventinplatenumber") ? item["eventinplatenumber"].ToString() : "",
                        plateNumber = eventOutReportNew.Columns.Contains("platenumber") ? item["platenumber"].ToString() : "",

                        eventInLaneId = eventOutReportNew.Columns.Contains("eventinlaneid") ? item["eventinlaneid"].ToString() : "",
                        laneId = eventOutReportNew.Columns.Contains("laneid") ? item["laneid"].ToString() : "",

                        TransactionType = transactionType,// eventOutReportNew.Columns.Contains("transactiontype") ? int.Parse(item["transactiontype"].ToString() ?? "0") : 0,
                        TransactionCode = transactionCode,

                        charge = eventOutReportNew.Columns.Contains("charge") ? int.Parse(item["charge"].ToString() ?? "0") : 0,

                        eventInCreatedBy = eventOutReportNew.Columns.Contains("eventincreatedby") ? item["eventincreatedby"].ToString() : "",
                        createdBy = eventOutReportNew.Columns.Contains("createdby") ? item["createdby"].ToString() : "",

                        eventInFileKeys = eventOutReportNew.Columns.Contains("eventinfilekeys") ? item["eventinfilekeys"].ToString()!.Split(",") : new string[] { },
                        fileKeys = eventOutReportNew.Columns.Contains("filekeys") ? item["filekeys"].ToString()!.Split(",") : new string[] { },

                        InvoiceNo = "",
                        InvoiceTemplate = "",
                        note = eventOutReportNew.Columns.Contains("note") ? item["note"].ToString() : "",
                        thirdpartynote = eventOutReportNew.Columns.Contains("thirdpartynote") ? item["thirdpartynote"].ToString() : "",
                    };
                    eventOutData.Add(ev);
                    if (ev.charge > 0)
                    {
                        ids.Add(ev.id.ToLower());
                    }
                }
                if (ids.Count > 0)
                {
                    InvoiceDatas = await AppData.ApiServer.GetMultipleInvoiceData(startTime, endTime) ?? new List<InvoiceResponse>();
                }
                else
                {
                    InvoiceDatas = new List<InvoiceResponse>();
                }

                pendingDatas = await AppData.ApiServer.getPendingEInvoice(startTime, endTime);

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
            ExcelTools.CreatReportFile(dgvData, "Báo cáo Xe Ra Khỏi Bãi", new List<string>() { lblVN.Text, lblTQ.Text });
        }

        private async void BtnPrintInternet_Click(object? sender, EventArgs e)
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
            string selectedId = dgvData.CurrentRow.Cells["invoice_id"].Value.ToString() ?? "";
            var invoiceData = await AppData.ApiServer.GetInvoiceData(selectedId);
            if (invoiceData == null)
            {
                MessageBox.Show("Chưa có thông tin hóa đơn điện tử", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                string pdfContent = invoiceData.fileToBytes;
                if (pdfContent == null)
                {
                    MessageBox.Show("Chưa có thông tin hóa đơn điện tử", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                PrintHelper.PrintPdf(pdfContent);
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.System, obj: ex);
                MessageBox.Show(ex.Message);
            }
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
                    string timeIn = dgvData.CurrentRow.Cells["TimeIn"].Value.ToString() ?? "";
                    string timeOut = dgvData.CurrentRow.Cells["TimeOut"].Value.ToString() ?? "";
                    string plate = dgvData.CurrentRow.Cells["PlateOut"].Value.ToString() ?? "";
                    string chargeStr = dgvData.CurrentRow.Cells["Charge"].Value.ToString() ?? "";
                    string printContent = PrintHelper.GetParkingPrintContent(File.ReadAllText(printTemplatePath),
                                                        DateTime.ParseExact(timeIn, "dd/MM/yyyy HH:mm:ss", CultureInfo.CurrentCulture),
                                                       DateTime.ParseExact(timeOut, "dd/MM/yyyy HH:mm:ss", CultureInfo.CurrentCulture),
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

                string timeIn = dgvData.CurrentRow.Cells["TimeIn"].Value.ToString() ?? "";
                string timeOut = dgvData.CurrentRow.Cells["TimeOut"].Value.ToString() ?? "";
                string plate = dgvData.CurrentRow.Cells["PlateOut"].Value.ToString() ?? "";
                string chargeStr = dgvData.CurrentRow.Cells["Charge"].Value.ToString() ?? "";
                int chargeInt = int.Parse(chargeStr.Replace(".", "").Trim());
                string IdentityCode = dgvData.CurrentRow.Cells["IdentityCode"].Value.ToString() ?? "";
                string IdentityGroup = dgvData.CurrentRow.Cells["IdentityGroup"].Value.ToString() ?? "";

                string printContent = PrintHelper.GetPhieuThuContent(File.ReadAllText(printTemplatePath),
                                                     IdentityCode, IdentityGroup, picVehicleImageOut.Image,
                                                     DateTime.ParseExact(timeIn, "dd/MM/yyyy HH:mm:ss", CultureInfo.CurrentCulture), DateTime.ParseExact(timeOut, "dd/MM/yyyy HH:mm:ss", CultureInfo.CurrentCulture),
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
                string physicalFileOutId = dgvData.CurrentRow?.Cells[dgvData.ColumnCount - 3].Value?.ToString() ?? "";
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

                string physicalFileInId = dgvData.CurrentRow?.Cells[dgvData.ColumnCount - 4].Value?.ToString() ?? "";
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
                btnPrintInternet.InitControl(BtnPrintInternet_Click);
                btnPrintOffline.InitControl(BtnPrintOffline_Click);
                btnPrintInternet.Text = "In hóa đơn (Internet)";
                btnPrintOffline.Text = "In hóa đơn";
                pictureBox1.Location = new Point(this.DisplayRectangle.Width - pictureBox1.Width - TextManagement.ROOT_SIZE,
                                                TextManagement.ROOT_SIZE);
                btnPrintInternet.Width = btnPrintInternet.PreferredSize.Width;
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

                btnPrintInternet.Location = new Point(btnSearch.Location.X + btnSearch.Width + 10, btnSearch.Location.Y);
                btnPrintOffline.Location = new Point(btnPrintInternet.Location.X + btnPrintInternet.Width + 10, btnPrintInternet.Location.Y);

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
        private async Task DisplayEventOutData(List<EventOutReport> eventOutData)
        {
            long total = 0;
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
                row.Cells[i++].Value = item.id;   //0
                row.Cells[i++].Value = item.eventinid;   //0
                row.Cells[i++].Value = (rows.Count + 1).ToString();   //1

                row.Cells[i++].Value = item.eventInPlateNumber;                   //7
                row.Cells[i++].Value = item.plateNumber;                          //8
                string countryCode = item.plateNumber.Length > 0 ?
                                                            (int.TryParse(item.plateNumber[0].ToString(), out int x) ? "VN" : "TQ") :
                                                            "VN";
                row.Cells[i++].Value = countryCode;           //2
                row.Cells[i++].Value = DateTime.Parse(item.eventInCreatedUtc).AddHours(7).ToString("dd/MM/yyyy HH:mm:ss"); //2
                row.Cells[i++].Value = DateTime.Parse(item.createdUtc).AddHours(7).ToString("dd/MM/yyyy HH:mm:ss"); //3
                row.Cells[i++].Value = item.ParkingTime(); //4
                row.Cells[i++].Value = GetIdentityGroupName(item.IdentityGroupId);//6

                row.Cells[i++].Value = TransactionType.GetTransactionTypeStr(item.TransactionType); //9
                row.Cells[i++].Value = item.TransactionCode;              //10

                count_by_countries[countryCode][TransactionType.GetTransactionTypeStr(item.TransactionType)] =
                    count_by_countries[countryCode][TransactionType.GetTransactionTypeStr(item.TransactionType)] + 1;

                string moneyStr = TextFormatingTool.GetMoneyFormat(item.charge.ToString());
                row.Cells[i++].Value = moneyStr.Substring(0, moneyStr.Length - 1);              //11

                row.Cells[i++].Value = item.IdentityName;       //5

                row.Cells[i++].Value = item.eventInCreatedBy;//12
                row.Cells[i++].Value = item.createdBy;       //13

                var invoiceData = InvoiceDatas.Where(e => e.targetId.Equals(item.id, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                row.Cells[i++].Value = invoiceData == null ? "" : StaticPool.templateCode;
                row.Cells[i++].Value = invoiceData == null ? "" : (invoiceData?.code ?? "").Replace(StaticPool.symbolCode, "");  //13

                row.Cells[i++].Value = GetLaneName(item.eventInLaneId);//17
                row.Cells[i++].Value = GetLaneName(item.laneId);       //16


                row.Cells[i++].Value = item.note;              //

                if (string.IsNullOrEmpty(item.thirdpartynote))
                {
                    row.Cells[i++].Value = "";              //
                    row.Cells[i++].Value = "";             //
                    row.Cells[i++].Value = "";             //
                }
                else
                {
                    try
                    {
                        string[] noteArray = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(item.thirdpartynote)!.ToArray();// note.Split(";");
                        row.Cells[i++].Value = noteArray.Length > 0 ? noteArray[0] : "";
                        row.Cells[i++].Value = noteArray.Length > 1 ? noteArray[1] : "";
                        row.Cells[i++].Value = noteArray.Length > 2 ? noteArray[2] : "";
                    }
                    catch (Exception)
                    {
                    }
                }

                row.Cells[i++].Value = physicalFileIdsIn == null ? "" : string.Join(";", physicalFileIdsIn);//14
                row.Cells[i++].Value = item.fileKeys == null ? "" : string.Join(";", item.fileKeys);        //15
                row.Cells[i++].Value = pendingDatas.Where(e => e.targetId.ToLower() == item.id.ToLower()).FirstOrDefault()?.id ?? "";        //16
                row.Cells[i++].Value = invoiceData?.id ?? "";        //16

                rows.Add(row);
                total += item.charge;
            }
            this.Invoke(new Action(() =>
            {
                dgvData.Rows.AddRange(rows.ToArray());
                lblMoney.Text = TextFormatingTool.GetMoneyFormat(total.ToString());
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
            eventOutData.Clear();
            InvoiceDatas.Clear();
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


            //var vehicleTypes = await KzParkingApiHelper.GetAllVehicleTypes() ?? new List<VehicleType>();
            var vehicleTypes = (await AppData.ApiServer.GetVehicleTypesAsync()).Item1 ?? new List<VehicleType>();
            vehicleTypes = vehicleTypes.OrderBy(x => x.Name).ThenBy(x => x.Name.Length).ToList();
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
            cbIdentityGroup.Invoke(new Action(() =>
            {
                cbIdentityGroup.Items.Add(new ListItem()
                {
                    Name = "Tất cả",
                    Value = ""
                });
            }));

            //identityGroups = await KzParkingApiHelper.GetIdentityGroupsAsync() ?? new List<IdentityGroup>();
            identityGroups = (await AppData.ApiServer.GetIdentityGroupsAsync()).Item1 ?? new List<IdentityGroup>();
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

            //lanes = await KzParkingApiHelper.GetLanesAsync() ?? new List<iParkingv6.Objects.Datas.Lane>();
            lanes = (await AppData.ApiServer.GetLanesAsync()).Item1 ?? new List<iParkingv6.Objects.Datas.Lane>();
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
            Lane? selectedLane = lanes.Where(lane => lane.id.ToUpper() == laneId.ToUpper()).FirstOrDefault();
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
                dgvData.CurrentCell = dgvData.Rows[e.RowIndex].Cells[2];
                ContextMenuStrip ctx = new ContextMenuStrip();
                ctx.Items.Add("Sửa ghi chú BSX", Properties.Resources.setting_0_0_0_32px).Name = "UpdateNote";
                if (StaticPool.appOption.IsAllowEditPlateOut)
                {
                    ctx.Items.Add("Sửa biển số vào", Properties.Resources.setting_0_0_0_32px).Name = "UpdatePlateIn";
                    ctx.Items.Add("Sửa biển số ra", Properties.Resources.setting_0_0_0_32px).Name = "UpdatePlateOut";
                }
                string pendingOrderId = dgvData.Rows[e.RowIndex].Cells["pending_invoice_id"].Value.ToString() ?? "";
                if (!string.IsNullOrEmpty(pendingOrderId))
                {
                    ctx.Items.Add("Gửi hóa đơn", Properties.Resources.setting_0_0_0_32px).Name = "SendPendingEInvoice";
                    ctx.Items.Add("Sửa biển số vào", Properties.Resources.setting_0_0_0_32px).Name = "UpdatePlateIn";
                    ctx.Items.Add("Sửa biển số ra", Properties.Resources.setting_0_0_0_32px).Name = "UpdatePlateOut";
                }
                ctx.Font = new Font(dgvData.Font.Name, 16, FontStyle.Bold);
                ctx.BackColor = Color.DarkOrange;
                ctx.ItemClicked += async (sender, ctx_e) =>
                {
                    string eventInId = dgvData.Rows[e.RowIndex].Cells["eventinid"].Value.ToString() ?? "";
                    string eventOutId = dgvData.Rows[e.RowIndex].Cells["id"].Value.ToString() ?? "";
                    string currentPlateIn = dgvData.Rows[e.RowIndex].Cells["PlateIn"].Value.ToString() ?? "";
                    string currentPlateOut = dgvData.Rows[e.RowIndex].Cells["PlateOut"].Value.ToString() ?? "";
                    string currentNote = dgvData.Rows[e.RowIndex].Cells["NoteBSX"].Value.ToString() ?? "";
                    switch (ctx_e.ClickedItem.Name.ToString())
                    {
                        case "UpdateNote":
                            var frmUpdateNote = new frmEditNote(currentNote, eventOutId, false);
                            if (frmUpdateNote.ShowDialog() == DialogResult.OK)
                            {
                                dgvData.Rows[e.RowIndex].Cells["NoteBSX"].Value = frmUpdateNote.newNote;
                                frmUpdateNote.Dispose();
                            }
                            break;
                        case "UpdatePlateIn":
                            {
                                var frmUpdatePlate = new frmEditPlate(currentPlateIn, eventInId, true, currentNote);
                                if (frmUpdatePlate.ShowDialog() == DialogResult.OK)
                                {
                                    dgvData.Rows[e.RowIndex].Cells["PlateIn"].Value = frmUpdatePlate.UpdatePlate;
                                    dgvData.Rows[e.RowIndex].Cells["NoteBSX"].Value = frmUpdatePlate.UpdateNote;
                                    frmUpdatePlate.Dispose();
                                }
                            }

                            break;
                        case "UpdatePlateOut":
                            {
                                var frmUpdatePlate = new frmEditPlate(currentPlateOut, eventOutId, false, currentNote);
                                if (frmUpdatePlate.ShowDialog() == DialogResult.OK)
                                {
                                    dgvData.Rows[e.RowIndex].Cells["PlateOut"].Value = frmUpdatePlate.UpdatePlate;
                                    dgvData.Rows[e.RowIndex].Cells["NoteBSX"].Value = frmUpdatePlate.UpdateNote;
                                    frmUpdatePlate.Dispose();
                                }
                            }
                            break;
                        case "SendPendingEInvoice":
                            {
                                bool isSendSuccess = await AppData.ApiServer.sendPendingEInvoice(eventOutId);
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

        private void btnPrintOffline_Click_1(object sender, EventArgs e)
        {

        }
    }
}
