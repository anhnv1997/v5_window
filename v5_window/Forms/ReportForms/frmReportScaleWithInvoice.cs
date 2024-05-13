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
            var data = await GetReportData();
            DisplayInGridview(data);
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

            var frm = new frmSelectPrintCount();

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
            string orderId = await KzScaleApiHelper.CreateInvoice(weighingActionDetails[cbPrintMode.SelectedIndex].Id, StaticPool.userId, StaticPool.user_name);
            if (string.IsNullOrEmpty(orderId))
            {
                MessageBox.Show("Chưa gửi được thông tin hóa đơn điện tử", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var invoiceData = await KzParkingv5ApiHelper.GetInvoiceData(orderId);
            if (string.IsNullOrEmpty(invoiceData.id))
            {
                MessageBox.Show("Chưa gửi được thông tin hóa đơn điện tử", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string pdfContent = invoiceData.signedFileData;
            PrintHelper.PrintPdf(pdfContent);
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExcelTools.CreatReportFile(dgvData, "Báo cáo sự kiện cân");
        }
        private async void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string trafficId = "";
                string vehicleImage = "";
                string firstScaleImage = dgvData.CurrentRow.Cells[dgvData.ColumnCount - 2].Value.ToString() ?? "";
                string secondScaleImage = dgvData.CurrentRow.Cells[dgvData.ColumnCount - 1].Value.ToString() ?? "";
                if (!string.IsNullOrEmpty(firstScaleImage))
                {
                    string[] firstScaleImages = firstScaleImage.Split(";");
                    if (firstScaleImages.Length > 1)
                    {
                        string firstWeightImagePath = await MinioHelper.GetImage(firstScaleImages[1]);
                        string vehicleImagePath = await MinioHelper.GetImage(firstScaleImages[0]);
                        this.Invoke(new Action(() =>
                        {
                            picVehicleImage.LoadAsync(vehicleImagePath);
                            picFirstWeight.LoadAsync(firstWeightImagePath);
                        }));
                    }
                }
                if (!string.IsNullOrEmpty(secondScaleImage))
                {
                    string[] secondScaleImages = secondScaleImage.Split(";");
                    if (secondScaleImages.Length > 1)
                    {
                        string tempPath = await MinioHelper.GetImage(secondScaleImages[1]);
                        this.Invoke(new Action(() =>
                        {
                            picSecondWeight.LoadAsync(tempPath);
                        }));
                    }
                }
            }
            catch (Exception)
            {
            }

        }
        #endregion End Controls In Form

        #region Private Function
        private async Task<List<WeighingDetail>> GetReportData()
        {
            DateTime startTime = dtpStartTime.Value;
            DateTime endTime = dtpEndTime.Value;
            string plateNumber = txtPlateNumber.Text;
            string userCode = txtUsername.Text;
            string goodsTypeId = ((ListItem)cbGoodsType.SelectedItem)?.Name ?? "";
            return await KzScaleApiHelper.GetWeighingActionDetails(startTime, endTime, plateNumber, userCode, goodsTypeId);
        }
        private void DisplayInGridview(List<WeighingDetail> data)
        {
            this.Invoke(new Action(() =>
            {
                dgvData.Rows.Clear();
                foreach (WeighingDetail item in data)
                {
                    string firstScaleTime = "";
                    string secondScaleTime = "";
                    string largerThan2TimesScale = "";
                    string plateNumber = "";
                    string firstWeightScale = "";
                    string secondWeightScale = "";
                    string goodType = "";
                    if (item.weighing_action_detail == null)
                    {
                        continue;
                    }
                    plateNumber = item.plate_number;
                    if (item.weighing_action_detail.Count > 0)
                    {
                        firstScaleTime = item.weighing_action_detail[0].CreatedAtTime?.ToString("dd/MM/yyyy HH:mm:ss") ?? "";
                        firstWeightScale = item.weighing_action_detail[0].Weight.ToString("#,0");
                        goodType = StaticPool.WeighingFormCollection.GetObjectById(item.weighing_action_detail[0].Weighting_form_id ?? "")?.Name ?? "";
                    }
                    if (item.weighing_action_detail.Count > 1)
                    {
                        secondScaleTime = item.weighing_action_detail[1].CreatedAtTime?.ToString("dd/MM/yyyy HH:mm:ss") ?? "";
                        secondWeightScale = item.weighing_action_detail[1].Weight.ToString("#,0");
                    }
                    if (item.weighing_action_detail.Count > 2)
                    {
                        for (int i = 1; i < item.weighing_action_detail.Count; i++)
                        {
                            string tempTime = item.weighing_action_detail[i].CreatedAtTime?.ToString("dd/MM/yyyy HH:mm:ss") ?? "";
                            string tempWeight = item.weighing_action_detail[i].Weight.ToString("#,0");
                            largerThan2TimesScale += "Lần " + item.weighing_action_detail[i].Order_by + " : " + tempTime + " - " + tempWeight + "\r\n";
                        }
                    }
                    largerThan2TimesScale = largerThan2TimesScale.TrimEnd();
                    string userAction = item.weighing_action_detail.Count > 0 ? item.weighing_action_detail[0].User_code : "";
                    string vehicleImage = "";
                    string firstScaleImage = item.weighing_action_detail.Count > 0 ? item.weighing_action_detail[0].list_image : "";
                    string secondScaleImage = item.weighing_action_detail.Count > 1 ? item.weighing_action_detail[1].list_image : "";
                    dgvData.Rows.Add(item.Traffic_id, dgvData.Rows.Count + 1, firstScaleTime, secondScaleTime,
                                     plateNumber, firstWeightScale, secondWeightScale, largerThan2TimesScale, goodType,
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
        private string GetPrintContent(List<WeighingActionDetail> weighingActionDetails)
        {
            string printContent = string.Empty;
            if (weighingActionDetails.Count <= 2)
            {
                foreach (var item in weighingActionDetails)
                {
                    string scaleItem = GetPrintContentItem(item, item.Order_by);
                    printContent += scaleItem;
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
                foreach (var item in weighingActionDetails)
                {
                    string scaleItem = GetPrintContentItem(item, item.Order_by);
                    printContent += scaleItem;
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
        private string GetPrintContentItem(WeighingActionDetail? weighingActionDetail, int index)
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
                            <center>Lần cân {weighingActionDetail.Order_by}</center>
                        </span>
                    </td>
                    <td>
                        <center><span>{weighingActionDetail.CreatedAtTime:dd/MM/yyyy HH:mm:ss}</span></center>
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
