using iParkingv5.Objects;
using iParkingv5.Objects.Enums;
using iParkingv5_window.Controls.Buttons;
using iParkingv5_window.Forms.DataForms;
using iParkingv5_window.Usercontrols.BuildControls;
using iParkingv6.ApiManager.KzParkingv3Apis;
using IPGS.Object.Databases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static iParkingv6.ApiManager.KzParkingv3Apis.KzParkingApiHelper;

namespace iParkingv5_window.Forms.ReportForms
{
    public partial class frmReportIn : Form
    {
        #region Properties

        #endregion End Properties
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;
        private int totalPages = 0;
        private int totalEvents = 0;

        #region Forms
        public frmReportIn()
        {
            InitializeComponent();
            dtpStartTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dtpEndTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            this.KeyPreview = true;
            this.KeyDown += FrmReportIn_KeyDown;
            dgvData.SelectionChanged += DgvData_SelectionChanged;
            dgvData.CellContentClick += DgvData_CellContentClick;
            ucPages1.OnpageSelect += UcPages1_OnpageSelect;
            ucEventInInfo1.onBackClickEvent += UcEventInfo1_onBackClickEvent;

            this.Load += FrmReportIn_Load;
            this.SizeChanged += FrmReportIn_SizeChanged;
        }
        private void FrmReportIn_Load(object? sender, EventArgs e)
        {
            CreateUI();
        }

        private void FrmReportIn_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnSearch_Click(null, null);
            }
        }
        private void FrmReportIn_SizeChanged(object? sender, EventArgs e)
        {
            dgvData.Location = new Point(StaticPool.baseSize * 2, cbVehicleType.Location.Y + cbVehicleType.Height + StaticPool.baseSize);

            dgvData.Height = btnCancel.Location.Y - dgvData.Location.Y - StaticPool.baseSize * 2 - ucPages1.Height;
            tablePic.Height = dgvData.Height;
            tablePic.Width = tablePic.Height * 9 / 16;
            dgvData.Width = this.DisplayRectangle.Width - StaticPool.baseSize * 5 - tablePic.Width;

            tablePic.Location = new Point(panelData.Width - tablePic.Width - StaticPool.baseSize * 2,
                                          dgvData.Location.Y);

            lblPage.Location = new Point(tablePic.Location.X, lblKeyword.Location.Y);
            lblTotalEvents.Location = new Point(tablePic.Location.X, lblStartTime.Location.Y);
            ucPages1.Width = panelData.Width - StaticPool.baseSize * 4;
            ucPages1.Location = new Point(dgvData.Location.X, dgvData.Location.Y + dgvData.Height + StaticPool.baseSize);
        }

        #endregion End Forms

        #region Controls In Form
        private async void btnSearch_Click(object? sender, EventArgs e)
        {
            panelData.SuspendLayout();
            picOverviewImageIn.Image = Properties.Resources.defaultImage;
            picVehicleImageIn.Image = Properties.Resources.defaultImage;
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
                if (item is IDesignControl)
                {
                    ((IDesignControl)item).EnableWaitMode();
                }
                else if (!IsSupportsTransparency(item))
                {
                    item.Enabled = true;
                    continue;
                }
            }
            ucLoading1.Show("Đang tải thông tin xe trong bãi", frmMain.language);
            panelData.ResumeLayout();

            EnableFastLoading();

            string keyword = txtKeyword.Text;
            DateTime startTime = dtpStartTime.Value;
            DateTime endTime = dtpEndTime.Value;
            string vehicleTypeId = ((ListItem)cbVehicleType.SelectedItem).Value;
            string identityGroupId = ((ListItem)cbIdentityGroupType.SelectedItem).Value;
            string laneId = ((ListItem)cbLane.SelectedItem).Value;
            Application.DoEvents();
            Tuple<List<EventInReport>, int, int> eventInData = await KzParkingApiHelper.GetEventIns(keyword, startTime, endTime, identityGroupId, vehicleTypeId, laneId);

            if (eventInData.Item1 == null)
            {
                DisableFastLoading();
                panelData.BackColor = Color.White;
                ucLoading1.HideLoading();
                ucNotify1.Show(ucNotify.EmNotiType.Error, "Không tải được thông tin xe trong bãi. Vui lòng thử lại!");
                ucNotify1.OnSelectResultEvent += UcNotify1_OnSelectResultEvent;
                return;
            }

            totalPages = eventInData.Item2;
            totalEvents = eventInData.Item3;
            List<EventInReport> eventInReports = eventInData.Item1 ?? new List<EventInReport>();

            DisplayNavigation();
            DisplayEventInData(eventInReports);
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

            eventInReports.Clear();
        }

        private void btnExportExcel_Click(object? sender, EventArgs e)
        {
            ExcelTools.CreatReportFile(dgvData, "Báo cáo Xe Đang Trong Bãi");
        }
        private void btnCancel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private async void DgvData_SelectionChanged(object? sender, EventArgs e)
        {
            try
            {
                string physicalFileId = dgvData.CurrentRow?.Cells[dgvData.ColumnCount - 2].Value.ToString() ?? "";
                string[] physicalFileIds = physicalFileId.Split(';');
                if (physicalFileIds.Length >= 2)
                {
                    string displayOverviewInPath = await MinioHelper.GetImage(physicalFileIds[0]);
                    string vehicleInPath = await MinioHelper.GetImage(physicalFileIds[1]);
                    Task task1 = ShowImage(physicalFileIds[0], picOverviewImageIn);
                    Task task2 = ShowImage(physicalFileIds[1], picVehicleImageIn);
                    await Task.WhenAll(task1, task2);
                }
                else if (physicalFileIds.Length > 0)
                {
                    await ShowImage(physicalFileIds[0], picOverviewImageIn);
                    this.Invoke(() =>
                    {
                        picVehicleImageIn.Image = Properties.Resources.defaultImage;
                    });
                }
                else
                {
                    this.Invoke(() =>
                    {
                        picOverviewImageIn.Image = Properties.Resources.defaultImage;
                        picVehicleImageIn.Image = Properties.Resources.defaultImage;
                    });
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
                    else if (!IsSupportsTransparency(item))
                    {
                        item.Enabled = true;
                        continue;
                    }
                }

                string identityId = dgvData.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "";
                string plateNumber = dgvData.Rows[e.RowIndex].Cells[2].Value?.ToString() ?? "";
                string datetimeIn = dgvData.Rows[e.RowIndex].Cells[3].Value?.ToString() ?? "";
                string laneID = dgvData.Rows[e.RowIndex].Cells[4].Value?.ToString() ?? "";
                string createdById = dgvData.Rows[e.RowIndex].Cells[5].Value?.ToString() ?? "";
                ucEventInInfo1.ShowInfo(Cursor.Position, laneID, datetimeIn, plateNumber, identityId, createdById);
                this.ActiveControl = ucEventInInfo1;
            }
        }

        private void UcPages1_OnpageSelect(int pageIndex)
        {
            this.Invoke(new Action(async () =>
            {
                picOverviewImageIn.Image = Properties.Resources.defaultImage;
                picVehicleImageIn.Image = Properties.Resources.defaultImage;

                panelData.SuspendLayout();
                picOverviewImageIn.Image = Properties.Resources.defaultImage;
                picVehicleImageIn.Image = Properties.Resources.defaultImage;
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
                    if (item is IDesignControl)
                    {
                        ((IDesignControl)item).EnableWaitMode();
                    }
                    else if (!IsSupportsTransparency(item))
                    {
                        item.Enabled = true;
                        continue;
                    }
                }
                ucLoading1.Show("Đang tải thông tin xe trong bãi", frmMain.language);
                panelData.ResumeLayout();

                EnableFastLoading();

                string keyword = txtKeyword.Text;
                DateTime startTime = dtpStartTime.Value;
                DateTime endTime = dtpEndTime.Value;
                string vehicleTypeId = ((ListItem)cbVehicleType.SelectedItem).Value;
                string identityGroupId = ((ListItem)cbIdentityGroupType.SelectedItem).Value;
                string laneId = ((ListItem)cbLane.SelectedItem).Value;

                Application.DoEvents();
                Tuple<List<EventInReport>, int, int> eventInData = await KzParkingApiHelper.GetEventIns(keyword, startTime, endTime, identityGroupId, vehicleTypeId, laneId, pageIndex);

                if (eventInData.Item1 == null)
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

                totalPages = eventInData.Item2;
                totalEvents = eventInData.Item3;

                List<EventInReport> eventInReports = eventInData.Item1 ?? new List<EventInReport>();
                DisplayEventInData(eventInReports);
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

                eventInReports.Clear();
            }));

        }
        private void UcNotify1_OnSelectResultEvent(DialogResult result)
        {
            ucEventInInfo1.onBackClickEvent -= UcEventInfo1_onBackClickEvent;
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
                    else if (!IsSupportsTransparency(item))
                    {
                        item.Enabled = true;
                        continue;
                    }
                }
            }));
        }
        #endregion End Controls In Form

        #region Private Function
        private async void CreateUI()
        {
            btnCancel.Init(btnCancel_Click);
            btnExportExcel.Init(btnExportExcel_Click);
            btnSearch.Init(btnSearch_Click);

            lblKeyword.Location = new Point(StaticPool.baseSize * 2, StaticPool.baseSize * 2);
            txtKeyword.Location = new Point(lblKeyword.Location.X + lblKeyword.Width + StaticPool.baseSize,
                                            lblKeyword.Location.Y + (lblKeyword.Height - txtKeyword.Height) / 2);

            lblIdentityType.Location = new Point(txtKeyword.Location.X + txtKeyword.Width + StaticPool.baseSize, lblKeyword.Location.Y);
            cbIdentityGroupType.Location = new Point(lblIdentityType.Location.X + lblIdentityType.Width + StaticPool.baseSize, txtKeyword.Location.Y);

            dtpStartTime.Location = new Point(txtKeyword.Location.X, txtKeyword.Location.Y + txtKeyword.Height + StaticPool.baseSize);
            lblStartTime.Location = new Point(lblKeyword.Location.X,
                                              dtpStartTime.Location.Y + (dtpStartTime.Height - lblStartTime.Height) / 2);

            lblEndTime.Location = new Point(lblIdentityType.Location.X, lblStartTime.Location.Y);
            dtpEndTime.Location = new Point(cbIdentityGroupType.Location.X, dtpStartTime.Location.Y);

            btnSearch.Location = new Point(cbIdentityGroupType.Location.X + cbIdentityGroupType.Width + StaticPool.baseSize, cbIdentityGroupType.Location.Y);

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

            dgvData.Location = new Point(StaticPool.baseSize * 2, cbVehicleType.Location.Y + cbVehicleType.Height + StaticPool.baseSize);

            dgvData.Height = ucPages1.Location.Y - dgvData.Location.Y - StaticPool.baseSize * 2;
            tablePic.Height = dgvData.Height;
            tablePic.Width = tablePic.Height * 9 * 2 / 16;

            dgvData.Width = this.DisplayRectangle.Width - StaticPool.baseSize * 5 - tablePic.Width;

            tablePic.Location = new Point(panelData.Width - tablePic.Width - StaticPool.baseSize * 2,
                                          dgvData.Location.Y);

            lblPage.Location = new Point(tablePic.Location.X, lblKeyword.Location.Y);
            lblTotalEvents.Location = new Point(tablePic.Location.X, lblStartTime.Location.Y);

            await LoadVehicleTypeData();
            await LoadIdentityGroup();
            await LoadLaneType();

            cbVehicleType.DisplayMember = cbIdentityGroupType.DisplayMember = cbLane.DisplayMember = "Name";
            cbVehicleType.ValueMember = cbIdentityGroupType.ValueMember = cbLane.ValueMember = "Value";
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
        private void DisplayEventInData(List<EventInReport> eventInReports)
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (var item in eventInReports)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvData);
                int i = 0;
                row.Cells[i++].Value = (rows.Count + 1).ToString();//0
                row.Cells[i++].Value = item.identityId;            //1
                row.Cells[i++].Value = item.plateNumber;           //2
                row.Cells[i++].Value = item.DatetimeIn?.ToString("dd/MM/yyyy HH:mm:ss"); //3
                row.Cells[i++].Value = item.laneId;                //4
                row.Cells[i++].Value = item.createdBy;             //5
                row.Cells[i++].Value = item.fileKeys?.Length > 0 ? string.Join(";", item.fileKeys) : "";
                row.Cells[i++].Value = "Xem Thêm";
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
            cbIdentityGroupType.Invoke(new Action(() =>
            {
                cbIdentityGroupType.Items.Add(new ListItem()
                {
                    Name = "Tất cả",
                    Value = ""
                });
            }));

            var identities = await KzParkingApiHelper.GetIdentityGroupsAsync() ?? new List<iParkingv5.Objects.Datas.IdentityGroup>();
            cbIdentityGroupType.Invoke(new Action(() =>
            {
                foreach (var item in identities)
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
