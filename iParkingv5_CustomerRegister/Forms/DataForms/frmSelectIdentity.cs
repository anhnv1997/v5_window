using IPaking.Ultility;
using iPakrkingv5.Controls;
using iPakrkingv5.Controls.Controls.Buttons;
using iPakrkingv5.Controls.Usercontrols.BuildControls;
using iParkingv5.Objects;
using iParkingv5.Objects.Datas.parking;
using iParkingv5.Objects.Enums;
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
using System.Xml.Linq;

namespace iParkingv5_CustomerRegister.Forms.DataForms
{
    public partial class frmSelectIdentity : Form
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;
        #region Properties
        public List<string> identitids { get; set; } = new List<string>();
        public List<string> identitiNames { get; set; } = new List<string>();
        #endregion End Properties

        #region Forms
        public frmSelectIdentity(List<string> identities)
        {
            InitializeComponent();
            this.identitids = identities;
            this.Load += FrmSelectIdentity_Load;
            dgvData.CellContentClick += DgvData_CellContentClick;
        }

        private async void FrmSelectIdentity_Load(object? sender, EventArgs e)
        {
            lblKeyword.Text = "Từ khóa";
            var identities = await KzParkingApiHelper.GetIdentities("");
            foreach (var id in this.identitids)
            {
                Identity? identity = (from Identity _identity in identities
                                      where _identity.Id.ToLower() == id.ToLower()
                                      select _identity).FirstOrDefault();
                if (identity != null)
                {
                    this.identitiNames.Add(identity.Name);
                }
            }
            lblGuide.Text = "Danh sách đã chọn: " + string.Join(", ", identitiNames);
            CreateUI();
        }
        #endregion End Forms

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

            var identities = await KzParkingApiHelper.GetIdentities(txtKeyword.Text);

            if (identities != null)
            {
                var identityGroups = await KzParkingApiHelper.GetIdentityGroupsAsync();

                for (int i = 0; i < identities.Count; i++)
                {
                    string identityId = identities[i].Id;
                    string name = identities[i].Name;
                    string code = identities[i].Code;
                    string identityGroupId = identities[i].IdentityGroupId;
                    string type = identities[i].Type.ToString();
                    string note = identities[i].Note;

                    if (this.identitids.Contains(identityId))
                    {
                        dgvData.Rows.Add(identityId, true, i + 1, name, code, IdentityGroup.GetIdentityGroupName(identityGroups, identityGroupId), type, note);
                    }
                    else
                    {
                        dgvData.Rows.Add(identityId, false, i + 1, name, code, IdentityGroup.GetIdentityGroupName(identityGroups, identityGroupId), type, note);
                    }
                    identities[i] = null;
                }
                identities.Clear();
                GC.Collect();
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
                dgvData.CurrentCell = dgvData.Rows[0].Cells[1];
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
        private void DgvData_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            dgvData.CommitEdit(DataGridViewDataErrorContexts.Commit);
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                string name = dgvData.Rows[e.RowIndex].Cells[3].Value.ToString() ?? "";
                string id = dgvData.Rows[e.RowIndex].Cells[0].Value.ToString() ?? "";

                if (Convert.ToBoolean(dgvData.Rows[e.RowIndex].Cells["dgv_col_select"].Value))
                {
                    if (!this.identitids.Contains(id))
                    {
                        identitiNames.Add(name);
                        identitids.Add(id);
                    }
                }
                else
                {
                    identitiNames.Remove(name);
                    identitids.Remove(id);
                }
                lblGuide.Text = "Danh sách đã chọn: " + string.Join(", ", identitiNames);
            }
        }

        private void BtnCancel1_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void BtnOk1_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
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
        #endregion END CONTROLS IN FORM

        #region Private Function
        private void CreateUI()
        {
            this.Font = new Font(this.Font.Name, TextManagement.ROOT_SIZE);
            lblTitle.BackColor = lblKeyword.BackColor = lblGuide.BackColor = Color.Transparent;

            lblTitle.Font = new Font(this.Font.Name, TextManagement.ROOT_SIZE * 2, FontStyle.Bold);
            panelData.ToggleDoubleBuffered(true);

            lblSearch.InitControl(BtnSearch_Click);

            btnOk1.InitControl(BtnOk1_Click);
            btnCancel1.InitControl(BtnCancel1_Click);

            lblTitle.Location = new Point(TextManagement.ROOT_SIZE * 2, TextManagement.ROOT_SIZE * 2);

            lblKeyword.Location = new Point(lblTitle.Location.X, lblTitle.Location.Y + lblTitle.Height + TextManagement.ROOT_SIZE * 2);
            txtKeyword.Location = new Point(lblKeyword.Location.X + lblKeyword.Width + TextManagement.ROOT_SIZE,
                                           lblKeyword.Location.Y + (lblKeyword.Height - txtKeyword.Height) / 2);
            lblSearch.Location = new Point(txtKeyword.Location.X + txtKeyword.Width + TextManagement.ROOT_SIZE,
                                          txtKeyword.Location.Y + (txtKeyword.Height - lblSearch.Height) / 2);


            lblGuide.Location = new Point(lblKeyword.Location.X, lblSearch.Location.Y + lblSearch.Height + TextManagement.ROOT_SIZE);

            dgvData.Location = new Point(lblKeyword.Location.X, lblGuide.Location.Y + lblGuide.Height + TextManagement.ROOT_SIZE);
            dgvData.ToUnder(lblGuide, TextManagement.ROOT_SIZE);

            btnCancel1.Location = new Point(panelData.Width - btnCancel1.Width - StaticPool.baseSize * 2,
                                            panelData.Height - btnCancel1.Height - StaticPool.baseSize * 2);
            btnOk1.Location = new Point(btnCancel1.Location.X - btnOk1.Width - StaticPool.baseSize, btnCancel1.Location.Y);

            dgvData.Width = panelData.Width - StaticPool.baseSize * 4;
            dgvData.Height = btnCancel1.Location.Y - StaticPool.baseSize - dgvData.Location.Y;
            ucNotify1.OnSelectResultEvent += UcNotify1_OnSelectResultEvent;
            dgvData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BtnSearch_Click(null, null);
        }


        #endregion End Private Function

        #region Public Function

        #endregion End Public Function

    }
}
