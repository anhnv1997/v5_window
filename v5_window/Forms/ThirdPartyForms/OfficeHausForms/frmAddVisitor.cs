using iParkingv5.ApiManager.KzParkingv5Apis.services;
using iParkingv5.Objects.Databases;
using iParkingv5.Objects.Datas.parking_service;
using iParkingv5.Objects.Datas.ThirtParty.OfficeHaus;
using System.Data;

namespace iParkingv5_window.Forms.ThirdPartyForms.OfficeHausForms
{
    public partial class frmAddVisitor : Form
    {
        #region Properties
        List<IdentityGroup> identityGroups = new List<IdentityGroup>();
        public string IdentityGroupCode { get; set; } = "";
        public string PlateNumber { get; set; } = "";
        public HausVisitor? lastHausVistor = null;
        public static string lastIdentityGroupCode = "";
        #endregion

        #region Forms
        public frmAddVisitor()
        {
            InitializeComponent();
            this.KeyDown += FrmAddVisitor_KeyDown;
            this.Load += FrmAddVisitor_Load;
        }

        private void FrmAddVisitor_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                BtnOk_Click(null, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                BtnCancel_Click(null, EventArgs.Empty);
            }
        }
        private async void FrmAddVisitor_Load(object? sender, EventArgs e)
        {
            identityGroups = (await AppData.ApiServer.parkingDataService.GetIdentityGroupsAsync())?.Item1 ?? new List<IdentityGroup>();
            LoadIdentityGroup();
        }
        #endregion End Forms

        #region Controls In Form
        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private async void BtnOk_Click(object? sender, EventArgs e)
        {
            BtnOk.Enabled = false;
            this.IdentityGroupCode = ((ListItem)cbIdentityGroupType.SelectedItem).Value;
            this.PlateNumber = txtPlateNumber.Text;
            lastIdentityGroupCode = this.IdentityGroupCode;

            lastHausVistor = await ThirdPartyService.AddVisitor(this.IdentityGroupCode, this.PlateNumber);
            if (lastHausVistor == null || string.IsNullOrEmpty(lastHausVistor.UserId))
            {
                BtnOk.Enabled = true;
                MessageBox.Show("Lưu thông tin không thành công, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                BtnOk.Enabled = true;
                MessageBox.Show("Lưu thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }

        }
        #endregion End Controls In Form

        #region Private Function
        private void LoadIdentityGroup()
        {
            cbIdentityGroupType.DisplayMember = "Name";
            cbIdentityGroupType.ValueMember = "Value";
            identityGroups = identityGroups.OrderBy(x => x.Name).ThenBy(x => x.Name.Length).ToList();

            cbIdentityGroupType.Invoke(new Action(() =>
            {
                foreach (var item in identityGroups)
                {
                    ListItem identityGroupItem = new ListItem()
                    {
                        Name = item.Name,
                        Value = item.Code.ToString()
                    };
                    cbIdentityGroupType.Items.Add(identityGroupItem);
                }

                foreach (ListItem item in cbIdentityGroupType.Items)
                {
                    if (item.Value == lastIdentityGroupCode)
                    {
                        cbIdentityGroupType.SelectedItem = item;
                        break;
                    }
                }

                if (cbIdentityGroupType.SelectedIndex < 0)
                    cbIdentityGroupType.SelectedIndex = 0;
            }));
        }
        #endregion End Private Function
    }
}
