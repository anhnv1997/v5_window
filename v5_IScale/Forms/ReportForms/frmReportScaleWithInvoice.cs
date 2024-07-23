using DocumentFormat.OpenXml.Spreadsheet;
using IPaking.Ultility;
using iParkingv5.ApiManager.KzParkingv5Apis;
using iParkingv5.ApiManager.KzScaleApis;
using iParkingv5.Objects;
using iParkingv5.Objects.Databases;
using iParkingv5.Objects.EventDatas;
using iParkingv5.Objects.ScaleObjects;
using iParkingv5_window;
using iParkingv5_window.Forms.DataForms;
using iParkingv5_window.Helpers;
using Kztek.Tools;
using static iParkingv5.Objects.Enums.PrintHelpers;

namespace v5_IScale.Forms.ReportForms
{
    public partial class frmReportScaleWithInvoice : Form
    {
        #region Properties
        private int printCount = 0;
        public static Image defaultImg = Image.FromFile(frmMain.defaultImagePath);
        #endregion End Properties

        #region Forms
        public frmReportScaleWithInvoice()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += frmReportScaleWithInvoice_KeyDown;
        }
        private async void frmReportScaleWithInvoice_Load(object sender, EventArgs e)
        {
            try
            {
                dtpStartTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                dtpEndTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

                await LoadGoodsType();
                btnSearch.PerformClick();
                cbPrintMode.SelectedIndexChanged += cbPrintMode_SelectedIndexChanged;
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

        private async void btnPrintScaleTicket_Click(object sender, EventArgs e)
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

            var frm = new frmSelectPrintCount(-1);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.printCount = frm.PrintCount;

                var wbPrint = new WebBrowser();
                wbPrint.DocumentCompleted += WbPrint_DocumentCompleted;
                wbPrint.DocumentText = GetPrintContent(await KzScaleApiHelper.GetWeighingActionDetailsByTrafficId(parkingEventId));
            }
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
            var weighingActionDetails = await KzScaleApiHelper.GetWeighingActionDetailsByTrafficId(parkingEventId);
            if (weighingActionDetails.Count < (cbPrintMode.SelectedIndex + 1))
            {
                MessageBox.Show("Không có thông tin hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.printCount = 1;
            var wbPrint = new WebBrowser();
            wbPrint.DocumentCompleted += WbPrint_DocumentCompleted;
            wbPrint.DocumentText = PrintHelper.GetPrintScaleInvoiceOfflineContent(weighingActionDetails[cbPrintMode.SelectedIndex], plateNumber);
        }
        private async void btnPrintInternetEInvoice_Click(object sender, EventArgs e)
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


            var weighingActionDetails = await KzScaleApiHelper.GetWeighingActionDetailsByTrafficId(parkingEventId);
            if (weighingActionDetails.Count < (cbPrintMode.SelectedIndex + 1))
            {
                MessageBox.Show("Không có thông tin hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var invoiceData = await KzScaleApiHelper.CreateInvoice(weighingActionDetails[cbPrintMode.SelectedIndex].Id, true);
            if (string.IsNullOrEmpty(invoiceData.id))
            {
                MessageBox.Show("Chưa gửi được thông tin hóa đơn điện tử", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            await Task.Delay(300);
            var invoiceFile = await AppData.ApiServer.GetInvoiceData(invoiceData.id);
            if (string.IsNullOrEmpty(invoiceFile.fileToBytes))
            {
                MessageBox.Show("Chưa gửi được thông tin hóa đơn điện tử", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string pdfContent = invoiceFile.fileToBytes;
            PrintHelper.PrintPdf(pdfContent);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExcelTools.CreatReportFile(dgvData, "Báo cáo sự kiện cân", new List<string>());
        }
        //private async void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (dgvData.CurrentRow == null)
        //        {
        //            return;
        //        }
        //        string trafficId = "";
        //        string vehicleImage = "";
        //        string firstScaleImage = dgvData.CurrentRow.Cells[dgvData.ColumnCount - 2].Value.ToString() ?? "";
        //        string secondScaleImage = dgvData.CurrentRow.Cells[dgvData.ColumnCount - 1].Value.ToString() ?? "";
        //        if (!string.IsNullOrEmpty(firstScaleImage))
        //        {
        //            string[] firstScaleImages = firstScaleImage.Split(";");
        //            if (firstScaleImages.Length > 1)
        //            {
        //                string firstWeightImagePath = await MinioHelper.GetImage(firstScaleImages[1]);
        //                string vehicleImagePath = await MinioHelper.GetImage(firstScaleImages[0]);
        //                this.Invoke(new Action(() =>
        //                {
        //                    picVehicleImage.LoadAsync(vehicleImagePath);
        //                    picFirstWeight.LoadAsync(firstWeightImagePath);
        //                }));
        //            }
        //        }
        //        if (!string.IsNullOrEmpty(secondScaleImage))
        //        {
        //            string[] secondScaleImages = secondScaleImage.Split(";");
        //            if (secondScaleImages.Length > 1)
        //            {
        //                string tempPath = await MinioHelper.GetImage(secondScaleImages[1]);
        //                this.Invoke(new Action(() =>
        //                {
        //                    picSecondWeight.LoadAsync(tempPath);
        //                }));
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }

        //}
        private async void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvData.CurrentRow == null)
                {
                    return;
                }
                cbPrintMode.SelectedIndexChanged -= cbPrintMode_SelectedIndexChanged;
                cbPrintMode.SelectedIndex = 0;
                cbPrintMode_SelectedIndexChanged(null, EventArgs.Empty);
                cbPrintMode.SelectedIndexChanged += cbPrintMode_SelectedIndexChanged;
                //string trafficId = "";
                //string vehicleImage = "";
                //string firstScaleImage = dgvData.CurrentRow.Cells[dgvData.ColumnCount - 2].Value.ToString() ?? "";
                //string secondScaleImage = dgvData.CurrentRow.Cells[dgvData.ColumnCount - 1].Value.ToString() ?? "";
                //if (!string.IsNullOrEmpty(firstScaleImage))
                //{
                //    string[] firstScaleImages = firstScaleImage.Split(";");
                //    if (firstScaleImages.Length > 1)
                //    {
                //        string frontImagePath = firstScaleImages.Length > 1 ? await MinioHelper.GetImage(firstScaleImages[1]) : "";
                //        string rearImagePath = firstScaleImages.Length > 2 ? await MinioHelper.GetImage(firstScaleImages[2]) : "";
                //        string vehicleImagePath = firstScaleImages.Length > 0 ? await MinioHelper.GetImage(firstScaleImages[0]) : "";
                //        this.Invoke(new Action(() =>
                //        {
                //            if (!string.IsNullOrEmpty(vehicleImagePath))
                //            {
                //                picVehicleImage.LoadAsync(vehicleImagePath);
                //            }

                //            if (!string.IsNullOrEmpty(frontImagePath))
                //            {
                //                picFirstWeight.LoadAsync(frontImagePath);
                //            }

                //            if (!string.IsNullOrEmpty(rearImagePath))
                //            {
                //                picSecondWeight.LoadAsync(rearImagePath);
                //            }
                //        }));
                //    }
                //}
            }
            catch (Exception)
            {
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
            return await KzScaleApiHelper.GetWeighingActionDetails(startTime, endTime, plateNumber, userCode, goodsTypeId);
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

                foreach (KeyValuePair<string, List<WeighingAction>> item in reports)
                {
                    var orderData = item.Value.OrderBy(e => e.createdUtcTime).ToList();
                    string firstScaleTime = "";
                    string secondScaleTime = "";
                    string largerThan2TimesScale = "";
                    string plateNumber = item.Value[0].plateNumber;
                    string firstWeightScale = "";
                    string secondWeightScale = "";
                    string goodType = "";
                    if (orderData.Count > 0)
                    {
                        firstScaleTime = orderData[0].createdUtcTime?.ToString(UltilityManagement.fullDayFormat) ?? "";
                        firstWeightScale = orderData[0].Weight.ToString("#,0");
                        goodType = orderData[0].weighingType.Name;
                    }
                    if (orderData.Count > 1)
                    {
                        secondScaleTime = orderData[1].createdUtcTime?.ToString(UltilityManagement.fullDayFormat) ?? "";
                        secondWeightScale = orderData[1].Weight.ToString("#,0");
                    }
                    if (orderData.Count > 2)
                    {
                        for (int i = 2; i < orderData.Count; i++)
                        {
                            string tempTime = orderData[i].createdUtcTime?.ToString(UltilityManagement.fullDayFormat) ?? "";
                            string tempWeight = orderData[i].Weight.ToString("#,0");
                            largerThan2TimesScale += "Lần " + (i + 1) + " : " + tempTime + " - " + tempWeight + "\r\n";
                        }
                    }
                    largerThan2TimesScale = largerThan2TimesScale.TrimEnd();
                    string userAction = orderData.Count > 0 ? orderData[0].createdBy : "";
                    string vehicleImage = "";
                    string firstScaleImage = orderData.Count > 0 ? string.Join(";", orderData[0].FileKeys) : "";
                    string secondScaleImage = orderData.Count > 1 ? string.Join(";", orderData[1].FileKeys) : "";
                    dgvData.Rows.Add(item.Key, dgvData.Rows.Count + 1, firstScaleTime, secondScaleTime,
                                     plateNumber, firstWeightScale, secondWeightScale, largerThan2TimesScale, goodType, orderData[0].weighingSlip.printNumber,
                                     userAction, vehicleImage, firstScaleImage, secondScaleImage);
                }
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
            cbPrintMode.SelectedIndex = 0;
        }
        private string GetPrintContent(List<WeighingAction> weighingActionDetails)
        {
            string printContent = string.Empty;
            int turnPrint = cbPrintMode.SelectedIndex + 1;

            switch (turnPrint)
            {
                case 1:
                    printContent += GetPrintContentItem(weighingActionDetails[0], 1);
                    printContent += GetPrintContentItem(null, 2);
                    printContent += GetGoodsScaleItem("_");
                    break;
                case 2:
                    printContent += GetPrintContentItem(weighingActionDetails[0], 1);
                    printContent += weighingActionDetails.Count >= 2 ? GetPrintContentItem(weighingActionDetails[1], 2) :
                                                                       GetPrintContentItem(null, 2);
                    printContent += weighingActionDetails.Count >= 2 ? GetGoodsScaleItem(Math.Abs(weighingActionDetails[0].Weight - weighingActionDetails[1].Weight).ToString("#,0")) :
                                                                       GetGoodsScaleItem("_");
                    break;
                default:
                    for (int i = 1; i <= turnPrint; i++)
                    {
                        if (weighingActionDetails.Count >= i)
                        {
                            string scaleItem = GetPrintContentItem(weighingActionDetails[i - 1], i);
                            printContent += scaleItem;
                        }
                    }
                    break;
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
                baseContent = baseContent.Replace("{$number}", weighingActionDetails[0].weighingSlip.printNumber);
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
        private async void cbPrintMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count == 0)
            {
                return;
            }

            if (dgvData.CurrentRow == null)
            {
                return;
            }

            string parkingEventId = dgvData.CurrentRow.Cells[0].Value.ToString() ?? "";

            var scaleData = await KzScaleApiHelper.GetWeighingActionDetailsByTrafficId(parkingEventId);
            if (scaleData.Count < (cbPrintMode.SelectedIndex + 1))
            {
                MessageBox.Show("Không có thông tin cân lần " + (cbPrintMode.SelectedIndex + 1), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var firstScaleImages = scaleData[cbPrintMode.SelectedIndex].FileKeys;
            if (firstScaleImages.Count > 1)
            {

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
                    else if (item.Contains("EventInImage") )
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

                this.Invoke(new Action(() =>
                {
                    if (!string.IsNullOrEmpty(vehicleImagePath))
                    {
                        picVehicleImage.LoadAsync(vehicleImagePath);
                    }

                    if (!string.IsNullOrEmpty(frontImagePath))
                    {
                        picFirstWeight.LoadAsync(frontImagePath);
                    }

                    if (!string.IsNullOrEmpty(rearImagePath))
                    {
                        picSecondWeight.LoadAsync(rearImagePath);
                    }
                }));
            }
        }
    }
}
