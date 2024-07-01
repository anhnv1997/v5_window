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
    public partial class frmEditNote : Form
    {
        public string newNote { get => txtNewNote.Text; }
        private string eventId;
        private bool isEventIn;
        public frmEditNote(string currentNote, string eventId, bool isEventIn)
        {
            InitializeComponent();
            lblCurrentNote.Text = currentNote;
            this.eventId = eventId;
            this.isEventIn = isEventIn;
        }

        private async void frmEditNote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bool isUpdateSuccess = await KzParkingv5ApiHelper.UpdateBSXNote(txtNewNote.Text, this.eventId, this.isEventIn);
                if (isUpdateSuccess)
                {
                    MessageBox.Show("Cập nhật ghi chú thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    return;
                }
                else
                {
                    MessageBox.Show("Cập nhật ghi chú không thành công, vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            bool isUpdateSuccess = await KzParkingv5ApiHelper.UpdateBSXNote(txtNewNote.Text, this.eventId, this.isEventIn);
            if (isUpdateSuccess)
            {
                MessageBox.Show("Cập nhật ghi chú thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                return;
            }
            else
            {
                MessageBox.Show("Cập nhật ghi chú không thành công, vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.Cancel;
        }
    }
}
