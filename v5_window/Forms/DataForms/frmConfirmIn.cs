using iParkingv5.Objects;
using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Enums;
using iParkingv6.ApiManager.KzParkingv3Apis;
using iParkingv6.Objects.Datas;
using Minio.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iParkingv5_window.Forms.DataForms
{
    public partial class frmConfirmIn : Form
    {
        private iPakrkingv5.Controls.Controls.Buttons.LblCancel btnCancel1;
        private iPakrkingv5.Controls.Controls.Buttons.LblOk btnOk;
        public frmConfirmIn(string message, string identityCode, string identityName, string identityGroupName,
                            string customer, string plateNumber, string address, Image vehicleImage, Image overviewImage)
        {
            InitializeComponent();
            this.Text = "Xác nhận xe ra khỏi bãi";
            lblMessage.Text = message + "\r\nBạn có xác nhận cho xe ra khỏi bãi?";
            lblMessage.Size = lblMessage.PreferredSize;


            dgvEventInData.Rows.Clear();
            dgvEventInData.Rows.Add("Mã định danh", identityCode);
            dgvEventInData.Rows.Add("Tên định danh", identityName);
            dgvEventInData.Rows.Add("Nhóm định danh", identityGroupName);
            dgvEventInData.Rows.Add("Khách hàng", customer);
            dgvEventInData.Rows.Add("Địa chỉ", address);
            dgvEventInData.Rows.Add("Biển số đăng ký", plateNumber);
            picOverview.Image = overviewImage;
            picVehicle.Image = vehicleImage;
            this.Load += FrmConfirm_Load;
        }

        private void FrmConfirm_Load(object? sender, EventArgs e)
        {
            btnOk = new iPakrkingv5.Controls.Controls.Buttons.LblOk();
            btnCancel1 = new iPakrkingv5.Controls.Controls.Buttons.LblCancel();

            this.Controls.Add(btnOk);
            this.Controls.Add(btnCancel1);

            btnCancel1.InitControl(BtnCancel1_Click);
            btnOk.InitControl(BtnOk_Click);

            lblMessage.Padding = new Padding(StaticPool.baseSize);
            lblMessage.Height = lblMessage.PreferredSize.Height;

            panelAction.Height = btnCancel1.Height + StaticPool.baseSize * 3;
            btnCancel1.Location = new Point(panelAction.Width - btnCancel1.Width - StaticPool.baseSize * 2,
                                            StaticPool.baseSize);
            btnOk.Location = new Point(btnCancel1.Location.X - btnOk.Width - StaticPool.baseSize,
                                       StaticPool.baseSize);

            this.Visible = false;

            this.ActiveControl = btnOk;
        }

        private void BtnOk_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void BtnCancel1_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
