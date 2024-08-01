using IPaking.Ultility;
using iParkingv5.ApiManager.KzScaleApis;
using iParkingv5.Objects;
using iParkingv5.Objects.Databases;
using iParkingv5.Objects.Invoices;
using iParkingv5.Objects.ScaleObjects;
using iParkingv5_window;
using iParkingv5_window.Forms.DataForms;
using iParkingv5_window.Helpers;
using iParkingv6.ApiManager.KzParkingv3Apis;
using Kztek.Tool.TextFormatingTools;
using Kztek.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static iParkingv5.Objects.Enums.PrintHelpers;

namespace v5_IScale.Forms.ReportForms
{
    public partial class frmReportScaleDetail : Form
    {
        #region Properties
        private int printCount = 0;
        public static Image defaultImg = Image.FromFile(frmMain.defaultImagePath);
        #endregion End Properties

        #region Forms
        public frmReportScaleDetail()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += frmReportScaleWithInvoice_KeyDown;
            dgvData.CellMouseClick += DgvData_CellMouseClick;
        }
        private async void frmReportScaleWithInvoice_Load(object sender, EventArgs e)
        {
            try
            {
                btnSendInvoice.Click += BtnSendInvoice_Click;
                dtpStartTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                dtpEndTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

                await LoadGoodsType();
                await LoadLanes();
                cbFeeType.SelectedIndex = 0;
                btnSearch.PerformClick();
                this.ActiveControl = btnSearch;
            }
            catch (Exception)
            {
            }
        }

        private void frmReportScaleWithInvoice_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnSearch.PerformClick();
            }
        }
        #endregion End Forms

        #region Controls In Form
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var data = await GetReportData();
                DisplayInGridview(data);
                dgvData_CellClick(null, null);
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.System, obj: ex);
            }
        }
        private async void BtnSendInvoice_Click(object? sender, EventArgs e)
        {
            btnSendInvoice.Enabled = false;
            string weighing_id = dgvData.CurrentRow.Cells["weighing_id"].Value?.ToString() ?? "";
            string invoiceId = dgvData.CurrentRow.Cells["invoice_id"].Value?.ToString() ?? "";
            string invoiceNo = dgvData.CurrentRow.Cells["invoice_no"].Value?.ToString() ?? "";
            string chargeStr = dgvData.CurrentRow.Cells["charge"].Value?.ToString() ?? "";
            int charge = TextFormatingTool.MoneyToSpecific<int>(chargeStr);
            if (charge == 0)
            {
                MessageBox.Show("Phương tiện không phát sinh phí cân xe.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSendInvoice.Enabled = true;
                return;
            }
            //Hóa đơn lỗi || chờ thì gửi lại theo invoice_id
            //Hóa đơn chưa gửi thì tạo mới theo event_in_id
            bool isErrorInvoice = !string.IsNullOrWhiteSpace(invoiceId) && string.IsNullOrEmpty(invoiceNo);
            InvoiceResponse? response = null;
            if (isErrorInvoice)
            {
                response = await KzScaleApiHelper.sendPendingEInvoice(invoiceId);
            }
            else
            {
                response = await KzScaleApiHelper.CreateInvoice(weighing_id, true);
            }
            btnSendInvoice.Enabled = true;

            if (response == null || string.IsNullOrEmpty(response.id) || response.id == Guid.Empty.ToString())
            {
                MessageBox.Show("Chưa gửi được thông tin hóa đơn điện tử", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            btnSearch.PerformClick();
        }
        private async void btnPrintEInvoice_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count == 0)
            {
                MessageBox.Show("Không có thông tin sự kiện cân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dgvData.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn sự kiện cần in phiếu cân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string parkingEventId = dgvData.CurrentRow.Cells[0].Value.ToString() ?? "";
            string plateNumber = dgvData.CurrentRow.Cells[4].Value.ToString() ?? "";
            string index = dgvData.CurrentRow.Cells["index"].Value.ToString() ?? "";
            var weighingActionDetails = await KzScaleApiHelper.GetWeighingActionDetailsByTrafficId(parkingEventId);
            this.printCount = 1;
            var wbPrint = new WebBrowser();
            wbPrint.DocumentCompleted += WbPrint_DocumentCompleted;
            wbPrint.DocumentText = PrintHelper.GetPrintScaleInvoiceOfflineContent(weighingActionDetails[int.Parse(index) - 1], plateNumber);
        }
        private async void btnPrintInternetEInvoice_Click(object sender, EventArgs e)
        {
            btnPrintInternetEInvoice.Enabled = false;

            if (dgvData.Rows.Count == 0)
            {
                MessageBox.Show("Không có thông tin sự kiện cân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnPrintInternetEInvoice.Enabled = true;
                return;
            }

            if (dgvData.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn sự kiện cần in phiếu cân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnPrintInternetEInvoice.Enabled = true;
                return;
            }
            string parkingEventId = dgvData.CurrentRow.Cells[0].Value.ToString() ?? "";
            string plateNumber = dgvData.CurrentRow.Cells[4].Value.ToString() ?? "";
            string index = dgvData.CurrentRow.Cells["index"].Value.ToString() ?? "";

            var weighingActionDetails = await KzScaleApiHelper.GetWeighingActionDetailsByTrafficId(parkingEventId);

            if (weighingActionDetails[int.Parse(index) - 1].Charge == 0)
            {
                MessageBox.Show("Phương tiện không phát sinh phí cân xe.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnPrintInternetEInvoice.Enabled = true;
                return;
            }
            var invoiceData = await KzScaleApiHelper.CreateInvoice(weighingActionDetails[int.Parse(index) - 1].Id, true);
            btnPrintInternetEInvoice.Enabled = true;

            if (invoiceData == null || string.IsNullOrEmpty(invoiceData.id) || invoiceData.id == Guid.Empty.ToString())
            {
                MessageBox.Show("Chưa gửi được thông tin hóa đơn điện tử", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var invoicePdf = await AppData.ApiServer.GetInvoiceData(invoiceData.id);
            if (string.IsNullOrEmpty(invoicePdf.fileToBytes))
            {
                MessageBox.Show("Chưa gửi được thông tin hóa đơn điện tử", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string pdfContent = invoicePdf.fileToBytes;
            PrintHelper.PrintPdf(pdfContent);
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExcelTools.CreatReportFile(dgvData, "Báo cáo sự kiện cân", new List<string>());
        }
        private async void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvData.CurrentRow == null)
                {
                    return;
                }
                string trafficId = "";
                string vehicleImage = "";
                string firstScaleImage = dgvData.CurrentRow.Cells["firstScaleImage"].Value.ToString() ?? "";
                string invoiceId = dgvData.CurrentRow.Cells["invoice_id"].Value?.ToString() ?? "";
                string invoice_no = dgvData.CurrentRow.Cells["invoice_no"].Value?.ToString() ?? "";

                btnSendInvoice.Visible = (string.IsNullOrEmpty(invoiceId) || invoiceId == Guid.Empty.ToString()) ||
                                         (!string.IsNullOrEmpty(invoiceId) && string.IsNullOrEmpty(invoice_no));

                if (!string.IsNullOrEmpty(firstScaleImage))
                {
                    string[] firstScaleImages = firstScaleImage.Split(";");

                    string frontImagePath = "";
                    string rearImagePath = "";
                    string vehicleImagePath = "";

                    foreach (var item in firstScaleImages)
                    {
                        if (item.Contains("VEHICLEOUT") || item.Contains("VEHICLEIN"))
                        {
                            vehicleImagePath = item;
                            frontImagePath = item;
                        }
                        else if (item.Contains("OVERVIEWOUT") || item.Contains("OVERVIEWIN"))
                        {
                            rearImagePath = item;
                        }
                        else if (item.Contains("EventInImage"))
                        {
                            vehicleImagePath = item;
                        }
                        else if (item.Contains("EventInImage"))
                        {
                            vehicleImagePath = item;
                        }
                        else if (item.Contains("VEHICLESCALE"))
                        {
                            rearImagePath = item;
                        }
                        else if (item.Contains("OVERVIEWSCALE"))
                        {
                            frontImagePath = item;
                        }
                    }
                    frontImagePath = string.IsNullOrEmpty(frontImagePath) ? "" : await MinioHelper.GetImage(frontImagePath);
                    vehicleImagePath = string.IsNullOrEmpty(vehicleImagePath) ? "" : await MinioHelper.GetImage(vehicleImagePath);
                    rearImagePath = string.IsNullOrEmpty(rearImagePath) ? "" : await MinioHelper.GetImage(rearImagePath);
                    picOverview.LoadAsync(frontImagePath);
                    picVehicle.LoadAsync(rearImagePath);
                    //if (firstScaleImages.Length > 1)
                    //{
                    //    string overviewPath = await MinioHelper.GetImage(firstScaleImages.First(e => e.Contains("VEHICLE")));
                    //    string vehiclePath = await MinioHelper.GetImage(firstScaleImages.First(e => e.Contains("OVERVIEW")));
                    //    this.Invoke(new Action(() =>
                    //    {

                    //    }));
                    //}
                }
            }
            catch (Exception)
            {
            }

        }
        private void DgvData_CellMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                dgvData.CurrentCell = dgvData.Rows[e.RowIndex].Cells[1];
                ContextMenuStrip ctx = new ContextMenuStrip();
                ctx.Items.Add("Đổi loại hàng").Name = "UpdateWeighingType";
                ctx.Font = new Font(dgvData.Font.Name, 16, FontStyle.Bold);
                ctx.BackColor = Color.DarkOrange;
                ctx.ItemClicked += async (sender, ctx_e) =>
                {
                    string id = dgvData.Rows[e.RowIndex].Cells["weighing_id"].Value.ToString() ?? "";
                    string invoice_id = dgvData.Rows[e.RowIndex].Cells["invoice_id"].Value.ToString() ?? "";
                    string weighingTypeName = dgvData.Rows[e.RowIndex].Cells["weighing_type_name"].Value.ToString() ?? "";
                    switch (ctx_e.ClickedItem.Name.ToString())
                    {
                        case "UpdateWeighingType":
                            {
                                //if (string.IsNullOrEmpty(invoice_id))
                                {
                                    var frm = new frmUpdateWeighingType(id, weighingTypeName);
                                    if (frm.ShowDialog() == DialogResult.OK)
                                    {
                                        btnSearch.PerformClick();
                                    }
                                }
                                //else
                                //{
                                //    MessageBox.Show("Lượt cân đã được gửi hóa đơn, không được phép đổi thông tin loại hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //    return;
                                //}
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

        #endregion End Controls In Form

        #region Private Function
        private async Task<List<WeighingAction>> GetReportData()
        {
            DateTime startTime = dtpStartTime.Value;
            DateTime endTime = dtpEndTime.Value;
            string plateNumber = txtPlateNumber.Text;
            string userCode = txtUsername.Text;
            string goodsTypeId = ((ListItem)cbGoodsType.SelectedItem)?.Name ?? "";
            int? isFee = null;
            if (cbFeeType.SelectedIndex == 0)
            {
                isFee = null;
            }
            else if (cbFeeType.SelectedIndex == 1)
            {
                isFee = 1;
            }
            else if (cbFeeType.SelectedIndex == 2)
            {
                isFee = 0;
            }

            string laneId = ((ListItem)cbLanes.SelectedItem)?.Name ?? "";

            return await KzScaleApiHelper.GetWeighingActionInvoiceDetails(startTime, endTime, isFee, laneId, plateNumber, userCode, goodsTypeId);
        }
        private void DisplayInGridview(List<WeighingAction> data)
        {
            this.Invoke(new Action(() =>
            {
                dgvData.Rows.Clear();

                Dictionary<string, List<WeighingAction>> reports = new Dictionary<string, List<WeighingAction>>();

                foreach (WeighingAction item in data)
                {
                    string eventId = item.eventInId;
                    if (reports.ContainsKey(eventId))
                    {
                        reports[eventId].Add(item);
                    }
                    else
                    {
                        reports.Add(eventId, new List<WeighingAction> { item });
                    }
                }
                float money = 0;
                foreach (KeyValuePair<string, List<WeighingAction>> item in reports)
                {
                    var orderData = item.Value.OrderBy(e => e.createdUtcTime).ToList();
                    for (int i = 0; i < orderData.Count; i++)
                    {
                        string scaleTime = orderData[i].createdUtcTime?.ToString(UltilityManagement.fullDayFormat) ?? "";
                        string plateNumber = orderData[i].plateNumber;
                        var weight = orderData[i].Weight.ToString("#,0");
                        string goodType = orderData[i].weighingTypeName;
                        string userAction = orderData[i].createdBy;
                        string vehicleImage = "";

                        string invoiceNo = orderData[i].invoiceCode ?? "";
                        string templateCode = StaticPool.scaleSymbolCode;
                        string charge = TextFormatingTool.GetMoneyFormat(orderData[i].Charge.ToString());
                        string firstScaleImage = orderData.Count > 0 ? string.Join(";", orderData[i].FileKeys ?? new List<string>()) : "";
                        string invoiceId = orderData[i].InvoiceId ?? "";
                        dgvData.Rows.Add(item.Key, dgvData.Rows.Count + 1, scaleTime, orderData[i].laneName, plateNumber, weight, i + 1, charge, goodType,
                                         userAction, templateCode, invoiceNo, vehicleImage, firstScaleImage, secondScaleImage, invoiceId, orderData[i].Id);
                        money += orderData[i].Charge;
                    }
                }
                lblTotal.Text = "Tổng số: " + TextFormatingTool.GetMoneyFormat(money.ToString());
            }));
        }
        #endregion End Private Function

        #region Public Function
        private async Task LoadGoodsType()
        {
            StaticPool.WeighingFormCollection.Clear();
            var weighingForms = await KzScaleApiHelper.GetWeighingForms();
            cbGoodsType.Items.Add(new ListItem()
            {
                Name = "",
                Value = "Tất cả",
            });

            if (weighingForms != null)
            {
                foreach (var item in weighingForms)
                {
                    StaticPool.WeighingFormCollection.Add(item);
                    ListItem li = new()
                    {
                        Name = item.Id,
                        Value = item.Name,
                    };
                    cbGoodsType.Items.Add(li);
                }
            }

            cbGoodsType.DisplayMember = "Value";
            cbGoodsType.SelectedIndex = cbGoodsType.Items.Count > 0 ? 0 : -1;
        }
        private async Task LoadLanes()
        {
            var lanes = await AppData.ApiServer.GetLanesAsync();
            if (lanes == null)
            {
                return;
            }
            if (lanes.Item1 == null)
            {
                return;
            }
            cbLanes.Items.Add(new ListItem()
            {
                Name = "",
                Value = "Tất cả",
            });

            foreach (var item in lanes.Item1)
            {
                ListItem li = new()
                {
                    Name = item.id,
                    Value = item.name,
                };
                cbLanes.Items.Add(li);
            }

            cbLanes.DisplayMember = "Value";
            cbLanes.SelectedIndex = cbLanes.Items.Count > 0 ? 0 : -1;
        }

        private string GetPrintContent(List<WeighingAction> weighingActionDetails)
        {
            string printContent = string.Empty;
            if (weighingActionDetails.Count <= 2)
            {
                int i = 1;
                foreach (var item in weighingActionDetails)
                {
                    string scaleItem = GetPrintContentItem(item, i);
                    printContent += scaleItem;
                    i++;
                }
                if (weighingActionDetails.Count <= 1)
                {
                    printContent += GetPrintContentItem(null, 2);
                    printContent += GetGoodsScaleItem("_");
                }
                else
                {
                    printContent += GetGoodsScaleItem(Math.Abs(weighingActionDetails[0].Weight - weighingActionDetails[1].Weight).ToString("#,0"));
                }
            }
            else
            {
                int i = 1;
                foreach (var item in weighingActionDetails)
                {
                    string scaleItem = GetPrintContentItem(item, i);
                    printContent += scaleItem;
                    i++;
                }
            }

            string plateNumber = dgvData.CurrentRow.Cells[4].Value.ToString() ?? "";
            string weighingType = dgvData.CurrentRow.Cells[8].Value.ToString() ?? "";
            string printTemplatePath = PathManagement.appPrintScaleTemplateConfigPath(((EmPrintTemplate)StaticPool.appOption.PrintTemplate).ToString());
            if (File.Exists(printTemplatePath))
            {
                string baseContent = File.ReadAllText(printTemplatePath);
                baseContent = baseContent.Replace("{$content}", printContent);
                baseContent = baseContent.Replace("{$plateNumber}", plateNumber);
                baseContent = baseContent.Replace("{$weightType}", weighingType);
                return baseContent;
            }
            else
            {
                MessageBox.Show("Không tìm thấy mẫu in", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return string.Empty;
            }
        }
        private string GetPrintContentItem(WeighingAction? weighingActionDetail, int index)
        {
            if (weighingActionDetail == null)
            {
                return $@"<tr>
                    <td>
                        <span>
                            <center>Lần cân {index}</center>
                        </span>
                    </td>
                    <td>
                        <center><span>__/__/____ __:__</span></center>
                    </td>
                    <td>
                        <center><span><b>_</b></span></center>
                    </td>
                    </tr>";
            }
            else
                return $@"<tr>
                    <td>
                        <span>
                            <center>Lần cân {index}</center>
                        </span>
                    </td>
                    <td>
                        <center><span>{weighingActionDetail.createdUtcTime.Value.ToString(UltilityManagement.fullDayFormat)}</span></center>
                    </td>
                    <td>
                        <center><span><b>{weighingActionDetail.Weight.ToString("#,0")}</b></span></center>
                    </td>
                    </tr>";
        }
        private string GetGoodsScaleItem(string goodScale)
        {
            return $@" <tr>
                    <td colspan=""2"">
                        <span>
                            <center>Khối lượng hàng</center>
                        </span>
                    </td>
                    <td>
                        <center><b><span>{goodScale}</span></b></center>
                    </td>
                    </tr>";
        }
        private void WbPrint_DocumentCompleted(object? sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                var browser = (WebBrowser)sender!;
                for (int i = 0; i < this.printCount; i++)
                {
                    browser.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Pic_LoadCompleted(object? sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            PictureBox pictureBox = (sender as PictureBox)!;
            if (e.Error != null)
            {
                pictureBox.Image = defaultImg;
            }
        }
        #endregion End Public Function
    }
}
