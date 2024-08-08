using iParkingv5.Objects.Databases;
using iParkingv5.Objects.Datas.parking_service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iParkingv5_window.Forms.ThirdPartyForms.OfficeHausForms
{
    public partial class frmAddVisitor : Form
    {
        #region Properties
        List<IdentityGroup> identityGroups = new List<IdentityGroup>();
        public string IdentityGroupCode { get; set; } = "";
        public string PlateNumber { get; set; } = "";
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

        private void BtnOk_Click(object? sender, EventArgs e)
        {
            this.IdentityGroupCode = ((ListItem)cbIdentityGroupType.SelectedItem).Value;
            this.PlateNumber = txtPlateNumber.Text;
            this.DialogResult = DialogResult.OK;
        }
        #endregion End Controls In Form

        #region Private Function
        private void LoadIdentityGroup()
        {
            cbIdentityGroupType.DisplayMember = "Name";
            cbIdentityGroupType.ValueMember = "Value";
            cbIdentityGroupType.Invoke(new Action(() =>
            {
                cbIdentityGroupType.Items.Add(new ListItem()
                {
                    Name = "Tất cả",
                    Value = ""
                });
            }));
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
                cbIdentityGroupType.SelectedIndex = 0;
            }));
        }
        #endregion End Private Function
    }
}
