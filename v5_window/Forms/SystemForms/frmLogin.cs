using iParkingv6.ApiManager.KzParkingv3Apis;

namespace iParkingv5_window.Forms.SystemForms
{
    public partial class frmLogin : Form
    {
        #region Properties
        private int waitTimeForLogin = 0;
        #endregion End Properties

        #region Forms
        public frmLogin()
        {
            InitializeComponent();
            this.Load += FrmLogin_Load;
        }
        private void FrmLogin_Load(object? sender, EventArgs e)
        {
            chbIsRemember.Checked = Properties.Settings.Default.isRemember;
            if (chbIsRemember.Checked)
            {
                txtUsername.Text = Properties.Settings.Default.username;
                txtPassword.Text = Properties.Settings.Default.password;
            }
            timerAutoConnect.Enabled = true;
        }
        #endregion End Forms

        #region Controls In Form
        private void btnExit_Click(object sender, EventArgs e)
        {
            lblStatus.Visible = false;
            timerAutoConnect.Enabled = false;
            Application.Exit();
            Environment.Exit(0);
        }
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            lblStatus.Visible = false;
            timerAutoConnect.Enabled = false;
            try
            {
                string token = await KzParkingApiHelper.GetToken(txtUsername.Text, txtPassword.Text);
                if (string.IsNullOrEmpty(token))
                {
                    MessageBox.Show("Thông tin tài khoản không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //LogHelper.Logger_SystemInfor("User: " + txtUsername.Text + " Login Success!", LogHelper.SaveLogFolder);
                KzParkingApiHelper.StartPollingAuthorize();
                Properties.Settings.Default.isRemember = chbIsRemember.Checked;
                Properties.Settings.Default.username = txtUsername.Text;
                Properties.Settings.Default.password = txtPassword.Text;
                Properties.Settings.Default.Save();
                this.Hide();
                frmLoading frm = new frmLoading
                {
                    Owner = this
                };
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gặp lỗi trong quá trình xử lý, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            lblStatus.Visible = false;
            timerAutoConnect.Enabled = false;
        }
        private void Control_Click(object sender, EventArgs e)
        {
            lblStatus.Visible = false;
            timerAutoConnect.Enabled = false;
        }
        private void chbIsRemember_CheckedChanged(object sender, EventArgs e)
        {
            lblStatus.Visible = false;
            timerAutoConnect.Enabled = false;
        }
        #endregion End Controls In Form

        #region TIMER
        private void timerAutoConnect_Tick(object sender, EventArgs e)
        {
            waitTimeForLogin++;
            if (waitTimeForLogin > 30)
            {
                lblStatus.Visible = false;
                timerAutoConnect.Enabled = false;
                btnLogin_Click(null, null);
            }
            else
            {
                lblStatus.Visible = true;
                lblStatus.Text = "Tự động đăng nhập sau: " + (30 - waitTimeForLogin) + "s";
                lblStatus.Refresh();
            }
        }
        #endregion END TIMER
    }
}
