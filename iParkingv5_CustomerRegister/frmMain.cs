using iParkingv5.Controller;
using iParkingv5_CustomerRegister.Forms;
using iParkingv5_CustomerRegister.Forms.SystemForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iParkingv5_CustomerRegister
{
    public partial class frmMain : Form
    {
        public static List<IController> controllers = new List<IController>();

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnCusomerRegiser_Click(object sender, EventArgs e)
        {
            new frmCustomerRegister()
            {
                StartPosition = FormStartPosition.CenterScreen,
            }
            .ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new frmDevices()
            {
                StartPosition = FormStartPosition.CenterScreen,
            }
            .ShowDialog();
        }

        private void btnRegisterFingerPrint_Click(object sender, EventArgs e)
        {
            new frmCustomerFingerRegister()
            {
                StartPosition = FormStartPosition.CenterScreen,
            }
            .ShowDialog();
        }
    }
}
