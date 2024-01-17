﻿using iParkingv5.Objects;
using iParkingv5.Objects.Datas;
using iParkingv5_window.Controls.Buttons;
using iParkingv5_window.Usercontrols.BuildControls;
using iParkingv6.ApiManager.KzParkingv3Apis;
using System.Runtime.InteropServices;

namespace iParkingv5_window.Forms.DataForms
{
    public partial class frmSelectCard : Form
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;
        #region PROPERTIES
        public string SelectIdentity
        {
            get;
            set;
        } = string.Empty;
        public string SelectIdentityId { get; set; } = string.Empty;
        Point position = new Point(0);
        #endregion END PROPERTIES

        #region FORMS
        public frmSelectCard(string title)
        {
            InitializeComponent();
            this.Text = title;
            dgvData.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Load += FrmSelectCard_Load;
        }

        private void FrmSelectCard_Load(object? sender, EventArgs e)
        {
            this.Location = this.position;
            this.Font = panelData.Font = new Font(this.Font.Name, StaticPool.baseSize);
            lblTittle.Font = new Font(this.Font.Name, StaticPool.baseSize * 2, FontStyle.Bold);

            btnSearch.Init(BtnSearch_Click);
            btnSelectCard.Init(BtnSelectCard_Click);
            btnCancel.Init(BtnCancel_Click);

            lblTittle.Location = new Point(StaticPool.baseSize * 2, StaticPool.baseSize * 2);
            lblCardNumber.Location = new Point(lblTittle.Location.X, lblTittle.Location.Y + lblTittle.Height + StaticPool.baseSize);

            txtIdentity.Location = new Point(lblCardNumber.Location.X + lblCardNumber.Width + StaticPool.baseSize,
                                            lblCardNumber.Location.Y + (lblCardNumber.Height - txtIdentity.Height) / 2);
            btnSearch.Location = new Point(txtIdentity.Location.X + txtIdentity.Width + StaticPool.baseSize,
                                           txtIdentity.Location.Y + (txtIdentity.Height - btnSearch.Height) / 2);

            btnCancel.Location = new Point(panelData.Width - btnCancel.Width - StaticPool.baseSize * 2,
                                           panelData.Height - btnCancel.Height - StaticPool.baseSize * 2);
            btnSelectCard.Location = new Point(btnCancel.Location.X - btnSelectCard.Width - StaticPool.baseSize,
                                               btnCancel.Location.Y);
            dgvData.Location = new Point(lblTittle.Location.X, btnSearch.Location.Y + btnSearch.Height + StaticPool.baseSize);
            dgvData.Width = panelData.Width - StaticPool.baseSize * 4;
            dgvData.Height = btnCancel.Location.Y - StaticPool.baseSize - dgvData.Location.Y;
        }
        #endregion END FORMS

        #region CONTROLS IN FORM
        private async void BtnSearch_Click(object sender, EventArgs e)
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
            ucLoading1.Show("Đang tải thông tin định danh", frmMain.language);
            panelData.ResumeLayout();
            dgvData.Rows.Clear();
            dgvData.Refresh();

            SendMessage(dgvData.Handle, WM_SETREDRAW, false, 0);
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            if (!string.IsNullOrEmpty(txtIdentity.Text))
            {
                var identityResponse = await KzParkingApiHelper.GetIdentityByCode(txtIdentity.Text);
                Identity? identity = identityResponse.Item1;
                if (!identityResponse.Item2)
                {
                    MessageBox.Show("Không đọc được thông tin định danh, vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (identity == null)
                {
                    MessageBox.Show("Mã định danh không có trong hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (identity != null)
                {
                    dgvData.Rows.Add("1", identity.Name, identity.Code, identity.Type.ToString(), identity.Id);
                }
            }
            else
            {
                List<Identity> identities = await KzParkingApiHelper.GetAllIdentity();
                if (identities != null)
                {
                    for (int i = 0; i < identities.Count; i++)
                    {
                        dgvData.Rows.Add(i + 1, identities[i].Name, identities[i].Code, identities[i].Type.ToString(), identities[i].Id);
                        identities[i] = null;
                    }
                    identities.Clear();
                    GC.Collect();
                }
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
        private void BtnSelectCard_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count > 0)
            {
                ChooseIdentity();
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void DgvCard_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                ChooseIdentity();
            }
        }
        #endregion END CONTROLS IN FORM

        #region PRIVATE FUNCTION
        private void ChooseIdentity()
        {
            this.SelectIdentity = dgvData.CurrentRow.Cells[2]?.Value?.ToString() ?? string.Empty;
            this.SelectIdentityId = dgvData.CurrentRow.Cells[dgvData.ColumnCount - 1]?.Value?.ToString() ?? string.Empty;
            this.DialogResult = DialogResult.OK;
        }
        #endregion END PRIVATE FUNCTION
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

    }
}
