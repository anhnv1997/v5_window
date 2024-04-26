using IPaking.Ultility;
using iParkingv5.Objects.Enums;
using iParkingv5.Objects;
using iParkingv6.ApiManager.KzParkingv3Apis;
using iParkingv6.Objects.Datas;
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
using iPakrkingv5.Controls;
using iPakrkingv5.Controls.Usercontrols.BuildControls;
using iPakrkingv5.Controls.Controls.Buttons;
using iParkingv5.ApiManager.KzParkingv5Apis;

namespace iParkingv5_CustomerRegister.Forms
{
    public partial class frmSelectVehicleType : Form
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;
        #region PROPERTIES
        public string selectedVehicleTypeId { get; set; } = string.Empty;
        public string selectedVehicleTypeName
        {
            get;
            set;
        } = string.Empty;
        #endregion END PROPERTIES

        #region FORMS
        public frmSelectVehicleType()
        {
            InitializeComponent();
            this.Load += FrmSelectPlateNumber_Load;
            dgvData.CellDoubleClick += DgvCard_CellDoubleClick;
        }
        private void FrmSelectPlateNumber_Load(object? sender, EventArgs e)
        {
            this.Font = new Font(this.Font.Name, StaticPool.baseSize);
            lblTitle.Font = new Font(this.Font.Name, StaticPool.baseSize * 2, FontStyle.Bold);
            panelData.ToggleDoubleBuffered(true);

            lblSearch.InitControl(BtnSearch_Click);
            btnOk1.InitControl(BtnOk1_Click);
            btnCancel1.InitControl(BtnCancel1_Click);

            lblTitle.Location = new Point(StaticPool.baseSize * 2, StaticPool.baseSize * 2);
            lblKeyword.Location = new Point(lblTitle.Location.X, lblTitle.Location.Y + lblTitle.Height + StaticPool.baseSize);

            txtKeyword.Location = new Point(lblKeyword.Location.X + lblKeyword.Width + StaticPool.baseSize,
                                            lblKeyword.Location.Y + (lblKeyword.Height - txtKeyword.Height) / 2);
            lblSearch.Location = new Point(txtKeyword.Location.X + txtKeyword.Width + StaticPool.baseSize,
                                           txtKeyword.Location.Y + (txtKeyword.Height - lblSearch.Height) / 2);

            btnCancel1.Location = new Point(panelData.Width - btnCancel1.Width - StaticPool.baseSize * 2,
                                           panelData.Height - btnCancel1.Height - StaticPool.baseSize * 2);
            btnOk1.Location = new Point(btnCancel1.Location.X - btnOk1.Width - StaticPool.baseSize, btnCancel1.Location.Y);
            dgvData.Location = new Point(lblTitle.Location.X, lblSearch.Location.Y + lblSearch.Height + StaticPool.baseSize);
            dgvData.Width = panelData.Width - StaticPool.baseSize * 4;
            dgvData.Height = btnCancel1.Location.Y - StaticPool.baseSize - dgvData.Location.Y;
            ucNotify1.OnSelectResultEvent += UcNotify1_OnSelectResultEvent;
        }
        #endregion END FORMS

        #region CONTROLS IN FORM
        private async void BtnSearch_Click(object? sender, EventArgs e)
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
                else if (!item.IsSupportsTransparency())
                {
                    item.Enabled = false;
                    continue;
                }
            }
            ucLoading1.Show("Đang tải thông tin phương tiện", TextManagement.ROOT_LANGUAGE);
            panelData.ResumeLayout();
            dgvData.Rows.Clear();
            dgvData.Refresh();

            SendMessage(dgvData.Handle, WM_SETREDRAW, false, 0);
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            //await Task.Delay(5000);
            var registerVehicleTypes = (await KzParkingv5ApiHelper.GetVehicleTypesAsync(txtKeyword.Text)).Item1;
            if (registerVehicleTypes != null)
            {
                if (registerVehicleTypes != null)
                {
                    for (int i = 0; i < registerVehicleTypes.Count; i++)
                    {
                        dgvData.Rows.Add(i + 1, registerVehicleTypes[i].Name,
                                                registerVehicleTypes[i].Id);
                        registerVehicleTypes[i] = null;
                    }
                    registerVehicleTypes.Clear();
                    GC.Collect();
                }
            }
            else
            {
                ucLoading1.HideLoading();
                ucNotify1.Show(ucNotify.EmNotiType.Error, "");
                ucNotify1.OnSelectResultEvent += UcNotify1_OnSelectResultEvent;
                return;
            }

            if (dgvData.Rows.Count > 0)
            {
                dgvData.CurrentCell = dgvData.Rows[0].Cells[0];
            }

            ucLoading1.HideLoading();
            panelData.BackColor = Color.White;
            foreach (Control item in panelData.Controls)
            {
                if (item is ucLoading)
                {
                    continue;
                }
                else if (item is IDesignControl)
                {
                    ((IDesignControl)item).Reset();
                }
                item.Enabled = true;
            }

            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            SendMessage(dgvData.Handle, WM_SETREDRAW, true, 0);
            dgvData.Refresh();
        }

        private void UcNotify1_OnSelectResultEvent(DialogResult result)
        {
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
                item.Enabled = true;
            }
        }

        private void BtnCancel1_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void BtnOk1_Click(object? sender, EventArgs e)
        {
            if (dgvData.Rows.Count > 0)
            {
                ChooseCustomer();
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
        private void DgvCard_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                ChooseCustomer();
            }
        }
        #endregion END CONTROLS IN FORM

        #region PRIVATE FUNCTION
        private void ChooseCustomer()
        {
            //VehicleType
            this.selectedVehicleTypeName = dgvData.CurrentRow.Cells[1]?.Value?.ToString() ?? string.Empty;
            this.selectedVehicleTypeId = dgvData.CurrentRow.Cells[dgvData.ColumnCount - 1]?.Value?.ToString() ?? string.Empty;
            this.DialogResult = DialogResult.OK;
        }
        #endregion END PRIVATE FUNCTION
    }
}