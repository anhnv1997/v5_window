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
        public string UpdateNote { get => txtNote.Text; }
        private string eventId;
        private bool isEventIn;
        public frmEditPlate(string currentPlate, string eventId, bool isEVentIn, string note)
        {
            InitializeComponent();
            lblCurrentPlate.Text = currentPlate;
            this.eventId = eventId;
            this.isEventIn = isEVentIn;
            txtNote.Text = note;
        }

        private async void frmEditPlate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await Update();
                return;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private async Task Update()
        {
            if (string.IsNullOrEmpty(txtNote.Text))
            {
                MessageBox.Show("Hãy nhập ghi chú lý do sửa biển số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtNewPlate.Text = txtNewPlate.Text.ToUpper();

            bool isUpdateSuccess = isEventIn ?
                        await AppData.ApiServer.UpdateEventInPlateAsync(this.eventId, txtNewPlate.Text, lblCurrentPlate.Text) :
                        await AppData.ApiServer.UpdateEventOutPlate(this.eventId, txtNewPlate.Text, lblCurrentPlate.Text)
                        ;
            bool isUpdateNoteSuccess = await KzParkingv5ApiHelper.UpdateBSXNote(txtNote.Text, this.eventId, this.isEventIn);
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

        private async void button1_Click(object sender, EventArgs e)
        {
            Update();
            //txtNewPlate.Text = txtNewPlate.Text.ToUpper();
            //bool isUpdateSuccess = isEventIn ?
            //                await AppData.ApiServer.UpdateEventInPlateAsync(this.eventId, txtNewPlate.Text.ToUpper(), lblCurrentPlate.Text) :
            //                await AppData.ApiServer.UpdateEventOutPlate(this.eventId, txtNewPlate.Text.ToUpper(), lblCurrentPlate.Text)
            //                ;
            //if (isUpdateSuccess)
            //{
            //    MessageBox.Show("Cập nhật biển số thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.DialogResult = DialogResult.OK;
            //    return;
            //}
            //else
            //{
            //    MessageBox.Show("Cập nhật biển số không thành công, vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
