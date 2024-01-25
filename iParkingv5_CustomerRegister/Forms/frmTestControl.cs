using iParkingv5_CustomerRegister.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iParkingv5_CustomerRegister.Forms
{
    public partial class frmTestControl : Form
    {
        public frmTestControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ucFinger uc = new ucFinger(1, "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA",0);
            panel1.Controls.Add(uc);
            uc.Location = new Point(0, 0);
            uc.Dock = DockStyle.Fill;
        }
    }
}
