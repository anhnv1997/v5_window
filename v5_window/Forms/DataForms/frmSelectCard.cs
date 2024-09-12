using iPakrkingv5.Controls;
using iPakrkingv5.Controls.Controls.Buttons;
using iParkingv5.Objects;
using iParkingv5.Objects.Datas.parking_service;
using iParkingv5_window.Usercontrols.BuildControls;
using System.Linq;
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
        private Dictionary<string, string> identityGroups = new Dictionary<string, string>();
        #endregion END PROPERTIES

        #region FORMS
        public frmSelectCard(string title)
        {
            InitializeComponent();
            this.Text = title;
            dgvData.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this.KeyPreview = true;
            this.KeyDown += FrmSelectCard_KeyDown;
            this.Load += FrmSelectCard_Load;
        }
        private void FrmSelectCard_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSearch_Click(null, EventArgs.Empty);
            }
        }
        private async void FrmSelectCard_Load(object? sender, EventArgs e)
        {
            this.Location = this.position;
            this.Font = panelData.Font = new Font(this.Font.Name, StaticPool.baseSize);
            lblTittle.Font = new Font(this.Font.Name, StaticPool.baseSize * 2, FontStyle.Bold);
            panelData.ToggleDoubleBuffered(true);

            btnSearch.InitControl(BtnSearch_Click);
            btnSelectCard.InitControl(BtnSelectCard_Click);
            btnCancel.InitControl(BtnCancel_Click);

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

            lblGuide.Location = new Point(StaticPool.baseSize * 2, btnSelectCard.Location.Y + (btnSelectCard.Height - lblGuide.Height) / 2);
            lblGuide.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            var identityGroupResponse = (await AppData.ApiServer.parkingDataService.GetIdentityGroupsAsync()).Item1 ?? new List<IdentityGroup>();
            foreach (var item in identityGroupResponse)
            {
                identityGroups.Add(item.Id.ToString().ToLower(), item.Name);
            }

            this.ActiveControl = btnSearch;
        }
        #endregion END FORMS

        #region CONTROLS IN FORM
        private async void BtnSearch_Click(object? sender, EventArgs e)
        {
            dgvData.Rows.Clear();
            dgvData.Refresh();

            SendMessage(dgvData.Handle, WM_SETREDRAW, false, 0);
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            List<Identity> identities = (await AppData.ApiServer.parkingDataService.GetIdentitiesAsync(txtIdentity.Text)).Item1;
            if (identities != null)
            {
                for (int i = 0; i < identities.Count; i++)
                {
                    dgvData.Rows.Add(i + 1, identities[i].Name, identities[i].Code, toString(identities[i].Type),
                                    getIdentityGroupName(identities[i].IdentityGroupId.ToLower(), identityGroups), identities[i].Id);
                }
                identities.Clear();
                GC.Collect();
            }

            if (dgvData.Rows.Count > 0)
            {
                dgvData.CurrentCell = dgvData.Rows[0].Cells[0];
            }

            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            SendMessage(dgvData.Handle, WM_SETREDRAW, true, 0);
            dgvData.Refresh();
        }
        private void BtnSelectCard_Click(object? sender, EventArgs e)
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
        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void DgvCard_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
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
        public string toString(IdentityType type)
        {
            switch (type)
            {
                case IdentityType.Card:
                    return "Thẻ";
                case IdentityType.QrCode:
                    return "QR";
                case IdentityType.FingerPrint:
                    return "Vân tay";
                case IdentityType.FaceId:
                    return "Gương mặt";
                case IdentityType.PlateNumber:
                    return "Biển số xe";
                case IdentityType.QR_1Times:
                    return "QR sử dụng 1 lần";
                default:
                    return "";
            }
        }
        public string getIdentityGroupName(string identityGroupId, Dictionary<string, string> identityGroups)
        {
            return identityGroups.ContainsKey(identityGroupId) ? identityGroups[identityGroupId] : string.Empty;
        }
        #endregion END PRIVATE FUNCTION
    }
}
