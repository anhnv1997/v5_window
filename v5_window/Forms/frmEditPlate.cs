using iParkingv5.ApiManager.KzParkingv5Apis;
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
    public partial class frmEditPlate : Form
    {
        public string UpdatePlate { get => txtNewPlate.Text; }
        private string eventId;
        private bool isEventIn;
        public frmEditPlate(string currentPlate, string eventId, bool isEVentIn)
        {
            InitializeComponent();
            lblCurrentPlate.Text = currentPlate;
            this.eventId = eventId;
            this.isEventIn = isEVentIn;
        }

        private async void frmEditPlate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNewPlate.Text = txtNewPlate.Text.ToUpper();

                bool isUpdateSuccess = isEventIn?
                            await AppData.ApiServer.parkingProcessService.UpdateEventInPlateAsync(this.eventId, txtNewPlate.Text, lblCurrentPlate.Text):
                            await AppData.ApiServer.parkingProcessService.UpdateEventOutPlate(this.eventId, txtNewPlate.Text, lblCurrentPlate.Text) 
                            ;
                if (isUpdateSuccess)
                {
                    MessageBox.Show("Cập nhật biển số thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    return;
                }
                else
                {
                    MessageBox.Show("Cập nhật biển số không thành công, vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtNewPlate.Text = txtNewPlate.Text.ToUpper();
            bool isUpdateSuccess = isEventIn ?
                            await AppData.ApiServer.parkingProcessService.UpdateEventInPlateAsync(this.eventId, txtNewPlate.Text.ToUpper(), lblCurrentPlate.Text) :
                            await AppData.ApiServer.parkingProcessService.UpdateEventOutPlate(this.eventId, txtNewPlate.Text.ToUpper(), lblCurrentPlate.Text)
                            ;
            if (isUpdateSuccess)
            {
                MessageBox.Show("Cập nhật biển số thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                return;
            }
            else
            {
                MessageBox.Show("Cập nhật biển số không thành công, vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
