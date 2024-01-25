using IPaking.Ultility;
using iPakrkingv5.Controls.Controls.Buttons;
using iPakrkingv5.Controls.Usercontrols.BuildControls;

namespace iParkingv5_CustomerRegister.Forms.SystemForms
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            lblUsername = new Label();
            lblPassword = new Label();
            chbIsRemember = new CheckBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            timerAutoConnect = new System.Windows.Forms.Timer(components);
            lblStatus = new Label();
            btnCancel1 = new LblCancel();
            btnLogin = new LblLogin();
            panelMain = new Panel();
            lblLoginTitle = new Label();
            picLogo = new PictureBox();
            ucNotify1 = new ucNotify();
            ucLoading1 = new ucLoading();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.Transparent;
            lblUsername.Location = new Point(32, 348);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(111, 21);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Tên đăng nhập";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Location = new Point(32, 387);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(75, 21);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Mật khẩu";
            // 
            // chbIsRemember
            // 
            chbIsRemember.AutoSize = true;
            chbIsRemember.BackColor = Color.Transparent;
            chbIsRemember.Location = new Point(146, 417);
            chbIsRemember.Name = "chbIsRemember";
            chbIsRemember.Size = new Size(128, 25);
            chbIsRemember.TabIndex = 5;
            chbIsRemember.Text = "Nhớ tài khoản";
            chbIsRemember.UseVisualStyleBackColor = false;
            chbIsRemember.CheckedChanged += chbIsRemember_CheckedChanged;
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUsername.Location = new Point(146, 345);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(383, 29);
            txtUsername.TabIndex = 3;
            txtUsername.Click += Control_Click;
            txtUsername.TextChanged += textBox_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.Location = new Point(146, 384);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(383, 29);
            txtPassword.TabIndex = 4;
            txtPassword.TextChanged += textBox_TextChanged;
            // 
            // timerAutoConnect
            // 
            timerAutoConnect.Interval = 1000;
            timerAutoConnect.Tick += timerAutoConnect_Tick;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic);
            lblStatus.ForeColor = Color.Green;
            lblStatus.Location = new Point(27, 452);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(48, 20);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "label1";
            // 
            // btnCancel1
            // 
            btnCancel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel1.AutoSize = true;
            btnCancel1.BackColor = Color.FromArgb(230, 230, 230);
            btnCancel1.BorderStyle = BorderStyle.Fixed3D;
            btnCancel1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnCancel1.ForeColor = Color.Black;
            btnCancel1.Location = new Point(477, 474);
            btnCancel1.Margin = new Padding(0);
            btnCancel1.Name = "btnCancel1";
            btnCancel1.Size = new Size(52, 22);
            btnCancel1.TabIndex = 7;
            btnCancel1.Text = "Thoát";
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLogin.AutoSize = true;
            btnLogin.BackColor = Color.FromArgb(230, 230, 230);
            btnLogin.BorderStyle = BorderStyle.Fixed3D;
            btnLogin.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnLogin.ForeColor = Color.Black;
            btnLogin.Location = new Point(374, 474);
            btnLogin.Margin = new Padding(0);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(87, 22);
            btnLogin.TabIndex = 8;
            btnLogin.Text = "Đăng nhập";
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(ucLoading1);
            panelMain.Controls.Add(lblLoginTitle);
            panelMain.Controls.Add(picLogo);
            panelMain.Controls.Add(ucNotify1);
            panelMain.Controls.Add(lblUsername);
            panelMain.Controls.Add(btnLogin);
            panelMain.Controls.Add(lblPassword);
            panelMain.Controls.Add(btnCancel1);
            panelMain.Controls.Add(chbIsRemember);
            panelMain.Controls.Add(lblStatus);
            panelMain.Controls.Add(txtUsername);
            panelMain.Controls.Add(txtPassword);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Font = new Font("Segoe UI", 12F);
            panelMain.Location = new Point(0, 0);
            panelMain.Margin = new Padding(0);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(24);
            panelMain.Size = new Size(553, 505);
            panelMain.TabIndex = 9;
            // 
            // lblLoginTitle
            // 
            lblLoginTitle.AutoSize = true;
            lblLoginTitle.BackColor = Color.Transparent;
            lblLoginTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblLoginTitle.Location = new Point(24, 263);
            lblLoginTitle.Name = "lblLoginTitle";
            lblLoginTitle.Size = new Size(328, 45);
            lblLoginTitle.TabIndex = 12;
            lblLoginTitle.Text = "Đăng nhập hệ thống";
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Dock = DockStyle.Top;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(24, 24);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(505, 236);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 11;
            picLogo.TabStop = false;
            // 
            // ucNotify1
            // 
            ucNotify1.BackColor = Color.White;
            ucNotify1.Location = new Point(87, 123);
            ucNotify1.MaximumSize = new Size(375, 374);
            ucNotify1.Message = "Nội dung thông báo";
            ucNotify1.MinimumSize = new Size(375, 374);
            ucNotify1.Name = "ucNotify1";
            ucNotify1.NotiType = ucNotify.EmNotiType.Information;
            ucNotify1.Size = new Size(375, 374);
            ucNotify1.TabIndex = 10;
            // 
            // ucLoading1
            // 
            ucLoading1.BackColor = Color.FromArgb(255, 224, 192);
            ucLoading1.Language = TextManagement.EmLanguage.Vietnamese;
            ucLoading1.Location = new Point(437, 284);
            ucLoading1.Message = "Preparing to download";
            ucLoading1.Name = "ucLoading1";
            ucLoading1.Size = new Size(392, 188);
            ucLoading1.TabIndex = 13;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(553, 505);
            Controls.Add(panelMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập hệ thống";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblUsername;
        private Label lblPassword;
        private CheckBox chbIsRemember;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private System.Windows.Forms.Timer timerAutoConnect;
        private Label lblStatus;
        private LblCancel btnCancel1;
        private LblLogin btnLogin;
        private Panel panelMain;
        private ucNotify ucNotify1;
        private PictureBox picLogo;
        private Label lblLoginTitle;
        private ucLoading ucLoading1;
    }
}