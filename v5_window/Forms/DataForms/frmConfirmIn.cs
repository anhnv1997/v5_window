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
        //private iPakrkingv5.Controls.Controls.Buttons.LblCancel btnCancel1;
        //private iPakrkingv5.Controls.Controls.Buttons.BtnOk btnOk;
        public string updatePlate;
        public frmConfirmIn(string message, string identityCode, string identityName, string identityGroupName,
                            string customer, string plateNumber, string address, Image vehicleImage, Image overviewImage, string detectedPlate)
        {
            InitializeComponent();
            this.Text = "Xác nhận xe ra khỏi bãi";
            lblMessage.Text = message;
            lblMessage.Size = lblMessage.PreferredSize;
            updatePlate = plateNumber;

            dgvEventInData.Rows.Clear();
            dgvEventInData.Rows.Add("Mã định danh", identityCode);
            dgvEventInData.Rows.Add("Tên định danh", identityName);
            dgvEventInData.Rows.Add("Nhóm định danh", identityGroupName);
            dgvEventInData.Rows[dgvEventInData.RowCount - 1].DefaultCellStyle.Font = new Font(dgvEventInData.DefaultCellStyle.Font.Name, dgvEventInData.DefaultCellStyle.Font.Size * 2);
            dgvEventInData.Rows[dgvEventInData.RowCount - 1].DefaultCellStyle.ForeColor = Color.Red; dgvEventInData.Rows.Add("Khách hàng", customer);
            dgvEventInData.Rows.Add("Địa chỉ", address);
            dgvEventInData.Rows.Add("Biển số đăng ký", plateNumber);
            dgvEventInData.Rows[dgvEventInData.RowCount - 1].DefaultCellStyle.Font = new Font(dgvEventInData.DefaultCellStyle.Font.Name, dgvEventInData.DefaultCellStyle.Font.Size * 2);
            dgvEventInData.Rows[dgvEventInData.RowCount - 1].DefaultCellStyle.ForeColor = Color.Red;
            dgvEventInData.Rows.Add("Biển số nhận dạng", detectedPlate);
            dgvEventInData.Rows[dgvEventInData.RowCount - 1].DefaultCellStyle.Font = new Font(dgvEventInData.DefaultCellStyle.Font.Name, dgvEventInData.DefaultCellStyle.Font.Size * 2);
            dgvEventInData.Rows[dgvEventInData.RowCount - 1].DefaultCellStyle.ForeColor = Color.Red;
            picOverview.Image = overviewImage;
            picVehicle.Image = vehicleImage;
            this.Load += FrmConfirm_Load;
        }

        private void FrmConfirm_Load(object? sender, EventArgs e)
        {
            //btnOk = new iPakrkingv5.Controls.Controls.Buttons.BtnOk();
            //btnCancel1 = new iPakrkingv5.Controls.Controls.Buttons.LblCancel();

            lblCancel1.InitControl(BtnCancel1_Click);
            btnOk1.InitControl(BtnOk_Click);

            lblMessage.Padding = new Padding(StaticPool.baseSize);
            lblMessage.Height = lblMessage.PreferredSize.Height;

            panelAction.Height = lblCancel1.Height + StaticPool.baseSize * 3;
            lblCancel1.Location = new Point(panelAction.Width - lblCancel1.Width - StaticPool.baseSize * 2,
                                            StaticPool.baseSize);
            btnOk1.Location = new Point(lblCancel1.Location.X - btnOk1.Width - StaticPool.baseSize,
                                       StaticPool.baseSize);
            this.Visible = false;

            this.ActiveControl = btnOk1;
        }

        private void BtnOk_Click(object? sender, EventArgs e)
        {
            updatePlate = dgvEventInData.Rows[6].Cells[1].Value.ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void BtnCancel1_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
