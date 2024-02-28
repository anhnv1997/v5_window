using iPakrkingv5.Controls;
using iPakrkingv5.Controls.Controls.Buttons;
using iParkingv5.Objects;
using iParkingv5.Objects.Databases;
using iParkingv5_window.Forms.DataForms;
using iParkingv5_window.Usercontrols.BuildControls;
using iParkingv6.ApiManager.KzParkingv3Apis;
using Kztek.Tool.TextFormatingTools;
using System.Runtime.InteropServices;
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
            this.KeyPreview = true;
            dgvData.SelectionChanged += DgvData_SelectionChanged;
            dgvData.CellContentClick += DgvData_CellContentClick;
            ucPages1.OnpageSelect += UcPages1_OnpageSelect;
            ucEventOutInfo1.onBackClickEvent += UcEventInInfo1_onBackClickEvent;

            lblMoney.Text = "Tổng Số: " + TextFormatingTool.GetMoneyFormat("0");

            this.Load += FrmReportInOut_Load;
            this.KeyDown += FrmReportInOut_KeyDown;
            this.SizeChanged += FrmReportInOut_SizeChanged;
        }
        private void FrmReportInOut_Load(object? sender, EventArgs e)
        {
            CreateUI();
            this.ActiveControl = btnSearch;
        }
        private void FrmReportInOut_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnSearch_Click(null, null);
            }
        }
        private void FrmReportInOut_SizeChanged(object? sender, EventArgs e)
        {
            lblMoney.Location = new Point(StaticPool.baseSize * 2, ucPages1.Location.Y - lblMoney.Height - StaticPool.baseSize);

            dgvData.Location = new Point(StaticPool.baseSize * 2, cbVehicleType.Location.Y + cbVehicleType.Height + StaticPool.baseSize);

            dgvData.Height = lblMoney.Location.Y - dgvData.Location.Y - StaticPool.baseSize * 2;
            tablePic.Height = dgvData.Height;
            tablePic.Width = tablePic.Height * 9 * 2 / 16;

            dgvData.Width = this.DisplayRectangle.Width - StaticPool.baseSize * 5 - tablePic.Width;

            tablePic.Location = new Point(panelData.Width - tablePic.Width - StaticPool.baseSize * 2,
                                          dgvData.Location.Y);

            lblPage.Location = new Point(tablePic.Location.X, lblKeyword.Location.Y);
            lblTotalEvents.Location = new Point(tablePic.Location.X, lblStartTime.Location.Y);
            lblMoney.Location = new Point(dgvData.Location.X + (dgvData.Width - lblMoney.Width), lblMoney.Location.Y);
        }
        #endregion End Forms

        #region Controls In Form

        private async void btnSearch_Click(object? sender, EventArgs e)
        {
            this.SuspendLayout();
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
                else if (item is IDesignControl)
                {
                    ((IDesignControl)item).EnableWaitMode();
                }
                else if (!ControlExtensions.IsSupportsTransparency(item))
                {
                    item.Enabled = false;
                    continue;
                }

            }
            ucLoading1.Show("Đang tải thông tin xe ra khỏi bãi", frmMain.language);
            Application.DoEvents();
            panelData.ResumeLayout();
            this.ResumeLayout();

            EnableFastLoading();

            string keyword = txtKeyword.Text;
            DateTime startTime = dtpStartTime.Value;
            DateTime endTime = dtpEndTime.Value;
            string vehicleTypeId = ((ListItem)cbVehicleType.SelectedItem)?.Value??"";
            string identityGroupId = ((ListItem)cbIdentityGroup.SelectedItem)?.Value ?? "";
            string laneId = ((ListItem)cbLane.SelectedItem)?.Value ?? "";

            Tuple<List<EventOutReport>, int, int> eventOutReport = await KzParkingApiHelper.GetEventOuts(keyword, startTime, endTime, identityGroupId, vehicleTypeId, laneId);

            if (eventOutReport.Item1 == null)
            {
                DisableFastLoading();
                panelData.BackColor = Color.White;
                ucLoading1.HideLoading();
                ucNotify1.Show(ucNotify.EmNotiType.Error, "Không tải được thông tin xe trong bãi. Vui lòng thử lại!");
                ucNotify1.OnSelectResultEvent += UcNotify1_OnSelectResultEvent;
                return;
            }
            try
            {
                long? money = await KzParkingApiHelper.GetSummary(startTime, endTime);
                if (money == null)
                {
                    lblMoney.Text = "Tổng Số: _";
                    lblMoney.Location = new Point(dgvData.Location.X + (dgvData.Width - lblMoney.Width), lblMoney.Location.Y);
                }
                else
                {
                    lblMoney.Text = "Tổng Số: " + TextFormatingTool.GetMoneyFormat(money!.ToString());
                    lblMoney.Location = new Point(dgvData.Location.X + (dgvData.Width - lblMoney.Width), lblMoney.Location.Y);
                }
            }
            catch (Exception)
            {
            }


            totalPages = eventOutReport.Item2;
            totalEvents = eventOutReport.Item3;
            List<EventOutReport> eventOutData = eventOutReport.Item1 ?? new List<EventOutReport>();
            DisplayNavigation();
            DisplayEventOutData(eventOutData);
            DisableFastLoading();

            this.SuspendLayout();
            panelData.SuspendLayout();
            ucLoading1.HideLoading();
            panelData.BackColor = Color.White;
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
            Application.DoEvents();
            panelData.ResumeLayout();
            this.ResumeLayout();
            eventOutData.Clear();
        }
        private void btnCancel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
        private void btnExportExcel_Click(object? sender, EventArgs e)
        {
            ExcelTools.CreatReportFile(dgvData, "Báo cáo Xe Ra Khỏi Bãi");
        }
        private async void DgvData_SelectionChanged(object? sender, EventArgs e)
        {
            try
            {
                string physicalFileOutId = dgvData.CurrentRow?.Cells[dgvData.ColumnCount - 2].Value?.ToString() ?? "";
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

                string physicalFileInId = dgvData.CurrentRow?.Cells[dgvData.ColumnCount - 3].Value?.ToString() ?? "";
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
        private void DgvData_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvData.ColumnCount - 1 && e.RowIndex >= 0)
            {
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
                        item.Enabled = true;
                        continue;
                    }
                }

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
                ucEventOutInfo1.ShowInfo(Cursor.Position, eventInLaneId, datetimeIn, plateNumberIn, identityIdIn, createdByInId,
                                                         laneIDOut, datetimeOut, plateNumberOut, identityIdOut, createdById);
            }
        }
        private void UcPages1_OnpageSelect(int pageIndex)
        {
            this.Invoke(new Action(async () =>
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
                    else if (item is IDesignControl)
                    {
                        ((IDesignControl)item).EnableWaitMode();
                    }
                    else if (!ControlExtensions.IsSupportsTransparency(item))
                    {
                        item.Enabled = false;
                        continue;
                    }
                }
                ucLoading1.Show("Đang tải thông tin xe ra khỏi bãi", frmMain.language);
                Application.DoEvents();
                panelData.ResumeLayout();

                EnableFastLoading();

                string keyword = txtKeyword.Text;
                DateTime startTime = dtpStartTime.Value;
                DateTime endTime = dtpEndTime.Value;
                string vehicleTypeId = ((ListItem)cbVehicleType.SelectedItem)?.Value ?? "";
                string identityGroupId = ((ListItem)cbIdentityGroup.SelectedItem)?.Value ?? "";
                string laneId = ((ListItem)cbLane.SelectedItem)?.Value ?? "";

                Tuple<List<EventOutReport>, int, int> eventOutReport = await KzParkingApiHelper.GetEventOuts(keyword, startTime, endTime, identityGroupId, vehicleTypeId, laneId, pageIndex);

                if (eventOutReport.Item1 == null)
                {
                    DisableFastLoading();
                    panelData.BackColor = Color.White;
                    ucLoading1.HideLoading();
                    ucNotify1.Show(ucNotify.EmNotiType.Error, "Không tải được thông tin xe trong bãi. Vui lòng thử lại!");
                    ucNotify1.OnSelectResultEvent += UcNotify1_OnSelectResultEvent;
                    return;
                }

                lblPage.Text = $"Trang: {pageIndex}/ " + totalPages;

                EnableFastLoading();

                totalPages = eventOutReport.Item2;
                totalEvents = eventOutReport.Item3;
                List<EventOutReport> eventOutData = eventOutReport.Item1 ?? new List<EventOutReport>();
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
        #endregion

        #region Private Function
        private async void CreateUI()
        {
            btnCancel.InitControl(btnCancel_Click);
            btnExportExcel.InitControl(btnExportExcel_Click);
            btnSearch.InitControl(btnSearch_Click);
            panelData.ToggleDoubleBuffered(true);

            lblKeyword.Location = new Point(StaticPool.baseSize * 2, StaticPool.baseSize * 2);
            txtKeyword.Location = new Point(lblKeyword.Location.X + lblKeyword.Width + StaticPool.baseSize,
                                            lblKeyword.Location.Y + (lblKeyword.Height - txtKeyword.Height) / 2);

            lblIdentityType.Location = new Point(txtKeyword.Location.X + txtKeyword.Width + StaticPool.baseSize, lblKeyword.Location.Y);
            cbIdentityGroup.Location = new Point(lblIdentityType.Location.X + lblIdentityType.Width + StaticPool.baseSize, txtKeyword.Location.Y);

            dtpStartTime.Location = new Point(txtKeyword.Location.X, txtKeyword.Location.Y + txtKeyword.Height + StaticPool.baseSize);
            lblStartTime.Location = new Point(lblKeyword.Location.X,
                                              dtpStartTime.Location.Y + (dtpStartTime.Height - lblStartTime.Height) / 2);

            lblEndTime.Location = new Point(lblIdentityType.Location.X, lblStartTime.Location.Y);
            dtpEndTime.Location = new Point(cbIdentityGroup.Location.X, dtpStartTime.Location.Y);

            btnSearch.Location = new Point(cbIdentityGroup.Location.X + cbIdentityGroup.Width + StaticPool.baseSize, cbIdentityGroup.Location.Y);

            cbVehicleType.Location = new Point(txtKeyword.Location.X, dtpStartTime.Location.Y + dtpStartTime.Height + StaticPool.baseSize);
            lblVehicleType.Location = new Point(lblKeyword.Location.X,
                                               cbVehicleType.Location.Y + (cbVehicleType.Height - lblVehicleType.Height) / 2);

            cbLane.Location = new Point(dtpEndTime.Location.X, cbVehicleType.Location.Y);
            lblLane.Location = new Point(lblEndTime.Location.X, lblVehicleType.Location.Y);

            btnCancel.Location = new Point(panelData.Width - btnCancel.Width - StaticPool.baseSize * 2,
                                           panelData.Height - btnCancel.Height - StaticPool.baseSize * 2);
            btnExportExcel.Location = new Point(btnCancel.Location.X - btnExportExcel.Width - StaticPool.baseSize,
                                                btnCancel.Location.Y);

            ucPages1.Location = new Point(StaticPool.baseSize * 2, btnCancel.Location.Y - ucPages1.Height - StaticPool.baseSize);
            ucPages1.Width = panelData.Width - StaticPool.baseSize * 4;

            lblMoney.Location = new Point(StaticPool.baseSize * 2, ucPages1.Location.Y - lblMoney.Height - StaticPool.baseSize);

            dgvData.Location = new Point(StaticPool.baseSize * 2, cbVehicleType.Location.Y + cbVehicleType.Height + StaticPool.baseSize);

            dgvData.Height = lblMoney.Location.Y - dgvData.Location.Y - StaticPool.baseSize * 2;
            tablePic.Height = dgvData.Height;
            tablePic.Width = tablePic.Height * 9 * 2 / 16;

            dgvData.Width = this.DisplayRectangle.Width - StaticPool.baseSize * 5 - tablePic.Width;

            tablePic.Location = new Point(panelData.Width - tablePic.Width - StaticPool.baseSize * 2,
                                          dgvData.Location.Y);

            lblPage.Location = new Point(tablePic.Location.X, lblKeyword.Location.Y);
            lblTotalEvents.Location = new Point(tablePic.Location.X, lblStartTime.Location.Y);
            lblMoney.Location = new Point(dgvData.Location.X + (dgvData.Width - lblMoney.Width), lblMoney.Location.Y);

            cbVehicleType.DisplayMember = cbIdentityGroup.DisplayMember = cbLane.DisplayMember = "Name";
            cbVehicleType.ValueMember = cbIdentityGroup.ValueMember = cbLane.ValueMember = "Value";

            await LoadVehicleTypeData();
            await LoadIdentityGroup();
            await LoadLaneType();
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
                row.Cells[i++].Value = TextFormatingTool.GetMoneyFormat( item.charge.ToString());//11
                row.Cells[i++].Value = physicalFileIdsIn == null ? "" : string.Join(";", physicalFileIdsIn);//12
                row.Cells[i++].Value = item.fileKeys == null ? "" : string.Join(";", item.fileKeys);//13
                row.Cells[i++].Value = "Xem thêm";//13
                rows.Add(row);
            }
            dgvData.Rows.AddRange(rows.ToArray());
            if (dgvData.RowCount > 0)
            {
                dgvData.CurrentCell = dgvData.Rows[0].Cells[0];
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


            var vehicleTypes = await KzParkingApiHelper.GetAllVehicleTypes() ?? new List<iParkingv5.Objects.Enums.VehicleType>();
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
            cbIdentityGroup.DisplayMember = "Name";
            cbIdentityGroup.ValueMember = "Value";

            cbIdentityGroup.Invoke(new Action(() =>
            {
                cbIdentityGroup.Items.Add(new ListItem()
                {
                    Name = "Tất cả",
                    Value = ""
                });
            }));

            var identityGroups = await KzParkingApiHelper.GetIdentityGroupsAsync() ?? new List<iParkingv5.Objects.Datas.IdentityGroup>();
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

            var lanes = await KzParkingApiHelper.GetLanesAsync() ?? new List<iParkingv6.Objects.Datas.Lane>();
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
        #endregion End Private Function
    }
}
