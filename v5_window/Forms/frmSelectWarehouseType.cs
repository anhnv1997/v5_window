using iParkingv5.Objects.EventDatas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iParkingv5_window.Forms
{
    public partial class frmSelectWarehouseType : Form
    {
        public string newType => cbWarehouseService.Text;
        private string eventId = "";
        private string plate = "";
        public frmSelectWarehouseType(string eventId, string currentType, string plate)
        {
            InitializeComponent();
            lblCurrentType.Text = currentType;
            this.eventId = eventId;
            this.plate = plate;
            cbWarehouseService.SelectedIndex = 0;
        }

        private async void frmSelectWarehouseType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bool isUpdateSuccess = await AppData.ApiServer.CreateWarehouseService(this.eventId, "", this.plate,
                    (iParkingv6.ApiManager.KzParkingv3Apis.KzParkingApiHelper.TransactionType.EmTransactionType)(cbWarehouseService.SelectedIndex), false) != null;
                if (isUpdateSuccess)
                {
                    MessageBox.Show("Cập nhật loại dịch vụ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    return;
                }
                else
                {
                    MessageBox.Show("Cập nhật loại dịch vụ không thành công, vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            bool isUpdateSuccess = await AppData.ApiServer.CreateWarehouseService(this.eventId, "", this.plate,
                    (iParkingv6.ApiManager.KzParkingv3Apis.KzParkingApiHelper.TransactionType.EmTransactionType)(cbWarehouseService.SelectedIndex), false) != null;
            if (isUpdateSuccess)
            {
                MessageBox.Show("Cập nhật loại dịch vụ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                return;
            }
            else
            {
                MessageBox.Show("Cập nhật loại dịch vụ không thành công, vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
