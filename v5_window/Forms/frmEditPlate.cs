using iParkingv5.ApiManager.KzParkingv5Apis;
using Kztek.Tools;
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
        private string eventInId;
        private bool isEventIn;
        private string eventOutId;
        private bool isWaiting = false;
        private string pendingInvoiceId = "";
        public frmEditPlate(string currentPlate, string eventInId, bool isEVentIn, string note, string pendingInvoiceId, string eventOutId)
        {
            InitializeComponent();
            lblCurrentPlate.Text = currentPlate;
            this.eventInId = eventInId;
            this.eventOutId = eventOutId;
            this.isEventIn = isEVentIn;
            txtNote.Text = note;
            this.pendingInvoiceId = pendingInvoiceId;
        }

        private async void frmEditPlate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (isWaiting) { return; }
                isWaiting = true;
                await Update();
                isWaiting = false;
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
                        await AppData.ApiServer.UpdateEventInPlateAsync(this.eventInId, txtNewPlate.Text, lblCurrentPlate.Text) :
                        await AppData.ApiServer.UpdateEventOutPlate(this.eventOutId, txtNewPlate.Text, lblCurrentPlate.Text)
                        ;
            bool isUpdateNoteSuccess = isEventIn ?
                        await KzParkingv5ApiHelper.UpdateBSXNote(txtNote.Text, this.eventInId, this.isEventIn) :
                        await KzParkingv5ApiHelper.UpdateBSXNote(txtNote.Text, this.eventOutId, this.isEventIn)
                        ;
            if (isUpdateSuccess)
            {
                if (!string.IsNullOrEmpty(pendingInvoiceId))
                {
                    LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, $"Ra lệnh cập nhật lại thông tin biển số xe cho hóa đơn chờ gửi Plate: {txtNewPlate.Text}, EvOutId: {this.eventOutId}, PendingId: {pendingInvoiceId}");
                    await AppData.ApiServer.CreateEinvoice(0, "", DateTime.Now, DateTime.Now, this.eventOutId, false, "");
                }
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
            button1.Enabled = false;
            await Update();
            button1.Enabled = true;
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
