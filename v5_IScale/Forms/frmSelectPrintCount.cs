using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace v5_IScale.Forms
{
    public partial class frmSelectPrintCount : Form
    {
        public int PrintCount { get; set; } = 1;
        public frmSelectPrintCount()
        {
            InitializeComponent();
        }

        private void btnSelect1_Click(object sender, EventArgs e)
        {
            this.PrintCount = 1;
            this.DialogResult = DialogResult.OK;
        }

        private void btnSelect2_Click(object sender, EventArgs e)
        {
            this.PrintCount = 2;
            this.DialogResult = DialogResult.OK;
        }

        private void btnSelect3_Click(object sender, EventArgs e)
        {
            this.PrintCount = 3;
            this.DialogResult = DialogResult.OK;
        }

        private void btnSelect4_Click(object sender, EventArgs e)
        {
            this.PrintCount = 4;
            this.DialogResult = DialogResult.OK;
        }
    }
}
