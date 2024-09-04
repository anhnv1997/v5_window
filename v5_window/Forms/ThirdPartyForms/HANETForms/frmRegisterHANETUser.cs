using iParkingv5.ApiManager;
using iParkingv5.Objects.Databases;
using iParkingv5.Objects.Datas.parking_service;
using Kztek.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iParkingv5_window.Forms.ThirdPartyForms.HANETForms
{
    public partial class frmRegisterHANETUser : Form
    {
        private Image? selectedImage = null;
        List<IdentityGroup> identityGroups = new List<IdentityGroup>();
        public static string lastIdentityGroupId = "";

        public frmRegisterHANETUser()
        {
            InitializeComponent();
            this.Load += FrmRegisterHANETUser_Load;
        }

        private async void FrmRegisterHANETUser_Load(object? sender, EventArgs e)
        {
            identityGroups = (await AppData.ApiServer.parkingDataService.GetIdentityGroupsAsync())?.Item1 ?? new List<IdentityGroup>();
            LoadIdentityGroup();
        }

        private void picFace_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedImage = Image.FromFile(ofd.FileName);
                picFace.Image = selectedImage;
            }
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            string identityGroupId = ((ListItem)cbIdentityGroupType.SelectedItem).Value;
            lastIdentityGroupId = identityGroupId;
            string code = txtCode.Text;
            //Đăng ký Identity

            Identity? identity = (await AppData.ApiServer.parkingDataService.GetIdentityByCodeAsync(code)).Item1;
            if (identity == null)
            {
                string format = "";
                IdentityType type = IdentityType.FaceId;
                //Thêm mới
                identity = new Identity()
                {
                    Name = txtName.Text,
                    Code = code,
                    IdentityGroupId = identityGroupId,
                    Type = type,
                };

                identity = (await AppData.ApiServer.parkingDataService.CreateIdentityAsync(identity))?.Item1 ?? null;
                if (identity == null)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show("Thêm mới thất bại");
                        return;
                    }));
                }
            }
            else
            {
                this.Invoke((Action)(() =>
                {
                    MessageBox.Show(code + " - đã tồn tại trong hệ thống");
                    return;
                }));
            }

            //Đăng ký Face
          bool isSuccess =   HANETApi.RegisterUser(txtName.Text, txtCode.Text , "20134",selectedImage.ImageToByteArray());
            if (isSuccess)
            {
                MessageBox.Show("Đăng ký thành công");
                this.DialogResult = DialogResult.OK;
            }
        }

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
                        Value = item.Id.ToString()
                    };
                    cbIdentityGroupType.Items.Add(identityGroupItem);
                }

                foreach (ListItem item in cbIdentityGroupType.Items)
                {
                    if (item.Value == lastIdentityGroupId)
                    {
                        cbIdentityGroupType.SelectedItem = item;
                        break;
                    }
                }

                if (cbIdentityGroupType.SelectedIndex < 0)
                    cbIdentityGroupType.SelectedIndex = 0;
            }));
        }

    }
}
