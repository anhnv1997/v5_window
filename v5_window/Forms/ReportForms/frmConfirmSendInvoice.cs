using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iParkingv5_window.Forms.ReportForms
{
    public partial class frmConfirmSendInvoice : Form
    {
        public frmConfirmSendInvoice()
        {
            InitializeComponent();
            btnConfirm.Click += BtnConfirm_Click;
            btnCancel.Click += BtnCancel_Click;
            this.ActiveControl = label1;
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BtnConfirm_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
