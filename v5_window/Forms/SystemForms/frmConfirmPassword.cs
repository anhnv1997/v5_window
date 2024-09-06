using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iParkingv5_window.Forms.SystemForms
{
    public partial class frmConfirmPassword : Form
    {
        string checkPassword = "Kztek123456";
        #region Forms
        public frmConfirmPassword()
        {
            InitializeComponent();
            this.KeyDown += FrmConfirmPassword_KeyDown;
        }

        private void FrmConfirmPassword_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnConfirm_Click(null, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnCancel_Click(null, EventArgs.Empty);
            }
        }
        #endregion

        #region Controls In Form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Kztek123456")
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        #endregion

        #region Private Function

        #endregion

        #region Public Function

        #endregion




    }
}
