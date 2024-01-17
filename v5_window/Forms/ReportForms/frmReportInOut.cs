using iParkingv5.Objects;
using iParkingv5_window.Controls.Buttons;
using iParkingv5_window.Forms.DataForms;
using iParkingv5_window.Usercontrols.BuildControls;
using iParkingv6.ApiManager.KzParkingv3Apis;
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
using static iParkingv6.ApiManager.KzParkingv3Apis.KzParkingApiHelper;

namespace iParkingv5_window.Forms.ReportForms
{
    public partial class frmReportInOut : Form
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;
        private int totalPages = 0;
        private int totalEvents = 0;
        #region Forms
        public frmReportInOut()
        {
            InitializeComponent();
            dtpStartTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dtpEndTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            dgvData.SelectionChanged += DgvData_SelectionChanged;
            ucPages1.OnpageSelect += UcPages1_OnpageSelect;

            this.Load += FrmReportInOut_Load;
        }
        private void FrmReportInOut_Load(object? sender, EventArgs e)
        {
            btnCancel.Init(btnCancel_Click);
            btnExportExcel.Init(btnExportExcel_Click);
            btnSearch.Init(btnSearch_Click);

            lblKeyword.Location = new Point(StaticPool.baseSize * 2, StaticPool.baseSize * 2);
            txtKeyword.Location = new Point(lblKeyword.Location.X + lblKeyword.Width + StaticPool.baseSize,
                                            lblKeyword.Location.Y + (lblKeyword.Height - txtKeyword.Height) / 2);

            dtpStartTime.Location = new Point(txtKeyword.Location.X, txtKeyword.Location.Y + txtKeyword.Height + StaticPool.baseSize);
            lblStartTime.Location = new Point(lblKeyword.Location.X,
                                              dtpStartTime.Location.Y + (dtpStartTime.Height - lblStartTime.Height) / 2);

            lblEndTime.Location = new Point(dtpStartTime.Location.X + dtpStartTime.Width + StaticPool.baseSize * 2,
                                            lblStartTime.Location.Y);

            dtpEndTime.Location = new Point(lblEndTime.Location.X + lblEndTime.Width + StaticPool.baseSize,
                                            dtpStartTime.Location.Y);

            txtKeyword.Width = dtpEndTime.Location.X + dtpEndTime.Width - txtKeyword.Location.X;

            btnSearch.Location = new Point(txtKeyword.Location.X + txtKeyword.Width + StaticPool.baseSize, txtKeyword.Location.Y);

            btnCancel.Location = new Point(panelData.Width - btnCancel.Width - StaticPool.baseSize * 2,
                                           panelData.Height - btnCancel.Height - StaticPool.baseSize * 2);
            btnExportExcel.Location = new Point(btnCancel.Location.X - btnExportExcel.Width - StaticPool.baseSize,
                                                btnCancel.Location.Y);

            dgvData.Location = new Point(StaticPool.baseSize * 2, dtpStartTime.Location.Y + dtpStartTime.Height + StaticPool.baseSize);

            dgvData.Height = btnCancel.Location.Y - dgvData.Location.Y - StaticPool.baseSize;
            tablePic.Height = dgvData.Height;
            tablePic.Width = tablePic.Height * 9 * 2 / 16;

            dgvData.Width = this.DisplayRectangle.Width - StaticPool.baseSize * 5 - tablePic.Width;

            tablePic.Location = new Point(panelData.Width - tablePic.Width - StaticPool.baseSize * 2,
                                          dgvData.Location.Y);

            lblPage.Location = new Point(tablePic.Location.X, lblKeyword.Location.Y);
            lblTotalEvents.Location = new Point(tablePic.Location.X, lblStartTime.Location.Y);
        }
        #endregion End Forms

        #region Controls In Form
        private void DisplayEventOutData(List<EventOutReport> eventOutData)
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
                row.CreateCells(dgvData);
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
                row.Cells[i++].Value = string.Join(";", physicalFileIdsIn ?? new List<string?>());//12
                row.Cells[i++].Value = string.Join(";", item.fileKeys);//13
                rows.Add(row);
            }
            dgvData.Rows.AddRange(rows.ToArray());
            if (dgvData.RowCount > 0)
            {
                dgvData.CurrentCell = dgvData.Rows[0].Cells[0];
            }
        }

        private async void btnSearch_Click(object? sender, EventArgs e)
        {
            panelData.SuspendLayout();
            panelData.BackColor = Color.FromArgb((int)(0.37 * 255), 42, 47, 48);
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
                if (!IsSupportsTransparency(item))
                {
                    item.Enabled = false;
                    continue;
                }
                else if (item is IDesignControl)
                {
                    ((IDesignControl)item).EnableWaitMode();
                }
            }
            ucLoading1.Show("Đang tải thông tin xe ra khỏi bãi", frmMain.language);
            Application.DoEvents();
            panelData.ResumeLayout();

            EnableFastLoading();

            string keyword = txtKeyword.Text;
            DateTime startTime = dtpStartTime.Value;
            DateTime endTime = dtpEndTime.Value;
            Tuple<List<EventOutReport>, int, int> eventOutReport = await KzParkingApiHelper.GetEventOuts(keyword, startTime, endTime);

            if (eventOutReport.Item1 == null)
            {
                DisableFastLoading();
                panelData.BackColor = Color.White;
                ucLoading1.HideLoading();
                ucNotify1.Show(ucNotify.EmNotiType.Error, "Không tải được thông tin xe trong bãi. Vui lòng thử lại!");
                ucNotify1.OnSelectResultEvent += UcNotify1_OnSelectResultEvent;
                return;
            }

            totalPages = eventOutReport.Item2;
            totalEvents = eventOutReport.Item3;
            List<EventOutReport> eventOutData = eventOutReport.Item1 ?? new List<EventOutReport>();
            DisplayNavigation();
            DisplayEventOutData(eventOutData);
            DisableFastLoading();

            panelData.BackColor = Color.White;
            ucLoading1.HideLoading();
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
                if (!IsSupportsTransparency(item))
                {
                    item.Enabled = true;
                    continue;
                }
                else if (item is IDesignControl)
                {
                    ((IDesignControl)item).Reset();
                }
            }

            eventOutData.Clear();
        }
        private void UcPages1_OnpageSelect(int pageIndex)
        {
            this.Invoke(new Action(async () =>
            {
                this.Cursor = Cursors.WaitCursor;
                string keyword = txtKeyword.Text;
                DateTime startTime = dtpStartTime.Value;
                DateTime endTime = dtpEndTime.Value;

                Tuple<List<EventOutReport>, int, int> eventOutReport = await KzParkingApiHelper.GetEventOuts(keyword, startTime, endTime, pageIndex);
                if (eventOutReport == null)
                {
                    MessageBox.Show("Không tải được thông tin sự kiện, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                lblPage.Text = $"Trang: {pageIndex}/ " + totalPages;

                EnableFastLoading();

                totalPages = eventOutReport.Item2;
                totalEvents = eventOutReport.Item3;
                List<EventOutReport> eventOutData = eventOutReport.Item1 ?? new List<EventOutReport>();
                DisplayEventOutData(eventOutData);
                DisableFastLoading();

                eventOutData.Clear();
                btnSearch.Enabled = true;
                this.Cursor = Cursors.Default;
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
                if (!IsSupportsTransparency(item))
                {
                    item.Enabled = true;
                    continue;
                }
                else if (item is IDesignControl)
                {
                    ((IDesignControl)item).Reset();
                }
            }
        }

        private async void DgvData_SelectionChanged(object? sender, EventArgs e)
        {
            try
            {
                string physicalFileOutId = dgvData.CurrentRow?.Cells[dgvData.ColumnCount - 1].Value?.ToString() ?? "";
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
                        picVehicleImageOut.Image = Properties.Resources.defaultImage;
                    }));
                }
                else
                {
                    this.Invoke(new Action(() =>
                    {
                        picOverviewImageOut.Image = Properties.Resources.defaultImage;
                        picVehicleImageOut.Image = Properties.Resources.defaultImage;
                    }));
                }

                string physicalFileInId = dgvData.CurrentRow?.Cells[dgvData.ColumnCount - 2].Value?.ToString() ?? "";
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
                        picVehicleImageIn.Image = Properties.Resources.defaultImage;
                    }));
                }
                else
                {
                    this.Invoke(new Action(() =>
                    {
                        picOverviewImageIn.Image = Properties.Resources.defaultImage;
                        picVehicleImageIn.Image = Properties.Resources.defaultImage;
                    }));
                }
            }
            catch (Exception)
            {
            }

        }
        private void btnCancel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
        private void btnExportExcel_Click(object? sender, EventArgs e)
        {
            ExcelTools.CreatReportFile(dgvData, "Báo cáo Xe Ra Khỏi Bãi");
        }
        #endregion


        #region Private Function
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
            lblPage.Visible = true;
            lblTotalEvents.Visible = true;
            lblPage.Text = "Trang: 1/ " + totalPages;
            lblTotalEvents.Text = "Tổng số sự kiện: " + totalEvents;
            lblPage.Refresh();
            lblTotalEvents.Refresh();
            if (totalPages > 1)
            {
                ucPages1.Visible = true;
                ucPages1.UpdateMaxPage(totalPages);
            }
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
            pic.Image = Properties.Resources.defaultImage;
        }
        static bool IsSupportsTransparency(Control control)
        {
            Type[] transparentControlTypes = { typeof(Panel), typeof(GroupBox), typeof(Label) };

            foreach (Type transparentType in transparentControlTypes)
            {
                if (transparentType.IsAssignableFrom(control.GetType()))
                {
                    return true;
                }
            }

            return false;
        }
        #endregion End Private Function
    }
}
