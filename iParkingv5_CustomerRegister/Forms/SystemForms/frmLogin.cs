using IPaking.Ultility;
using iPakrkingv5.Controls;
using iPakrkingv5.Controls.Usercontrols.BuildControls;
using iParkingv5.Objects;
using iParkingv6.ApiManager.KzParkingv3Apis;
using Kztek.Tools;

namespace iParkingv5_CustomerRegister.Forms.SystemForms
{
    public partial class frmLogin : Form
    {
        #region Properties
        private int waitTimeForLogin = 0;
        List<Control> activeControls = new List<Control>();
        #endregion End Properties

        #region Forms
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Return)
            {
                if (btnLogin.Enabled)
                    btnLogin_Click(null, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public frmLogin()
        {
            InitializeComponent();
            this.Load += FrmLogin_Load;
        }
        private void FrmLogin_Load(object? sender, EventArgs e)
        {
            panelMain.ToggleDoubleBuffered(true);
            chbIsRemember.Checked = Properties.Settings.Default.isRemember;
            if (chbIsRemember.Checked)
            {
                txtUsername.Text = Properties.Settings.Default.username;
                txtPassword.Text = Properties.Settings.Default.password;
            }

            activeControls = new()
            {
                txtUsername,
                txtPassword,
                btnCancel1,
                btnLogin
            };
            ucNotify1.OnSelectResultEvent += UcNotify1_OnSelectResultEvent;

            panelMain.Padding = new Padding(TextManagement.ROOT_SIZE);
            panelMain.Font = new Font(panelMain.Font.Name, TextManagement.ROOT_SIZE);

            btnCancel1.InitControl(btnExit_Click);
            btnLogin.InitControl(btnLogin_Click);

            lblLoginTitle.Location = new Point(TextManagement.ROOT_SIZE * 2,
                                               picLogo.Location.Y + picLogo.Height + TextManagement.ROOT_SIZE * 2);

            lblUsername.Location = new Point(lblLoginTitle.Location.X,
                                             lblLoginTitle.Location.Y + lblLoginTitle.Height + TextManagement.ROOT_SIZE);
            txtUsername.Location = new Point(lblUsername.Location.X + lblUsername.Width + TextManagement.ROOT_SIZE,
                                             lblUsername.Location.Y + (lblUsername.Height - txtUsername.Height) / 2);
            txtUsername.Width = panelMain.Width - txtUsername.Location.X - TextManagement.ROOT_SIZE * 2;

            txtPassword.Location = new Point(txtUsername.Location.X,
                                             txtUsername.Location.Y + txtUsername.Height + TextManagement.ROOT_SIZE / 2);
            txtPassword.Width = txtUsername.Width;
            lblPassword.Location = new Point(lblUsername.Location.X,
                                             txtPassword.Location.Y + (txtPassword.Height - lblPassword.Height) / 2);

            chbIsRemember.Location = new Point(txtPassword.Location.X,
                                               txtPassword.Location.Y + txtPassword.Height + TextManagement.ROOT_SIZE / 2);

            this.Height = chbIsRemember.Location.Y + chbIsRemember.Height + btnCancel1.Height+  TextManagement.ROOT_SIZE * 3 + this.Height - this.DisplayRectangle.Height;

            btnCancel1.Location = new Point(panelMain.Width - btnCancel1.Width - TextManagement.ROOT_SIZE * 2,
                                            chbIsRemember.Location.Y + chbIsRemember.Height + TextManagement.ROOT_SIZE);

            btnLogin.Location = new Point(btnCancel1.Location.X - btnLogin.Width - TextManagement.ROOT_SIZE / 2,
                                          btnCancel1.Location.Y);

            lblStatus.Location = new Point(lblLoginTitle.Location.X,
                                           btnLogin.Location.Y + (btnLogin.Height - lblStatus.Height) / 2);

            timerAutoConnect.Enabled = true;
        }

        private void UcNotify1_OnSelectResultEvent(DialogResult result)
        {
            panelMain.BackColor = Color.White;
            foreach (var item in activeControls)
            {
                item.Visible = true;
            }
        }
        #endregion End Forms

        #region Controls In Form
        private void btnExit_Click(object? sender, EventArgs e)
        {
            lblStatus.Visible = false;
            timerAutoConnect.Enabled = false;
            Application.Exit();
            Environment.Exit(0);
        }

        private async void btnLogin_Click(object? sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            lblStatus.Visible = false;
            timerAutoConnect.Enabled = false;

            panelMain.SuspendLayout();
            panelMain.BackColor = Color.FromArgb((int)(0.37 * 255), 42, 47, 48);

            foreach (var item in activeControls)
            {
                //item.Visible = false;
                try
                {
                    item.BackColor = Color.FromArgb((int)(0.37 * 255), 42, 47, 48);
                }
                catch (Exception)
                {
                    item.Visible = false;
                }
            }
            ucLoading1.Show("Đang đăng nhập hệ thống", TextManagement.ROOT_LANGUAGE);
            panelMain.ResumeLayout();
            Application.DoEvents();

            try
            {
                await Task.Delay(500);
                var tokenResponse = await KzParkingApiHelper.GetToken(txtUsername.Text, txtPassword.Text);
                string token = tokenResponse.Item1;
                panelMain.SuspendLayout();
                ucLoading1.HideLoading();
                if (string.IsNullOrEmpty(token))
                {
                    ucNotify1.Show(ucNotify.EmNotiType.Error, tokenResponse.Item2);
                    return;
                }
                else
                {
                    panelMain.BackColor = Color.White;
                    foreach (var item in activeControls)
                    {
                        item.Visible = true;
                    }
                }
                panelMain.ResumeLayout();
                Application.DoEvents();
                await Task.Delay(500);

                KzParkingApiHelper.StartPollingAuthorize();

                Properties.Settings.Default.isRemember = chbIsRemember.Checked;
                Properties.Settings.Default.username = txtUsername.Text;
                Properties.Settings.Default.password = txtPassword.Text;
                Properties.Settings.Default.Save();
                this.Hide();
                frmLoading frm = new()
                {
                    Owner = this
                };
                frm.Show();
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogHelper.EmLogType.ERROR, LogHelper.EmObjectLogType.System, obj: ex);
                MessageBox.Show("Gặp lỗi trong quá trình xử lý, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                btnLogin.Enabled = true;
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
