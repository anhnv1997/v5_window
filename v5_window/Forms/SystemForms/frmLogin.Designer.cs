using IPaking.Ultility;
using iPakrkingv5.Controls.Controls.Buttons;

namespace iParkingv5_window.Forms.SystemForms
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
            btnLogin = new BtnLogin();
            panelMain = new Panel();
            ucLoading1 = new Usercontrols.BuildControls.ucLoading();
            lblLoginTitle = new Label();
            picLogo = new PictureBox();
            ucNotify1 = new Usercontrols.BuildControls.ucNotify();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            timerRefreshToken = new System.Windows.Forms.Timer(components);
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.Transparent;
            lblUsername.Location = new Point(28, 261);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(111, 21);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Tên đăng nhập";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Location = new Point(28, 290);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(75, 21);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Mật khẩu";
            // 
            // chbIsRemember
            // 
            chbIsRemember.AutoSize = true;
            chbIsRemember.BackColor = Color.Transparent;
            chbIsRemember.Location = new Point(128, 313);
            chbIsRemember.Margin = new Padding(3, 2, 3, 2);
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
            txtUsername.Location = new Point(128, 259);
            txtUsername.Margin = new Padding(3, 2, 3, 2);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(0, 29);
            txtUsername.TabIndex = 3;
            txtUsername.Click += Control_Click;
            txtUsername.TextChanged += textBox_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.Location = new Point(128, 288);
            txtPassword.Margin = new Padding(3, 2, 3, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(0, 29);
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
            lblStatus.Location = new Point(12, 444);
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
            btnCancel1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnCancel1.ForeColor = Color.Black;
            btnCancel1.Location = new Point(-82, 342);
            btnCancel1.Margin = new Padding(0);
            btnCancel1.Name = "btnCancel1";
            btnCancel1.Size = new Size(60, 30);
            btnCancel1.TabIndex = 7;
            btnCancel1.Text = "Thoát";
            btnCancel1.UseVisualStyleBackColor = false;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLogin.AutoSize = true;
            btnLogin.BackColor = Color.FromArgb(230, 230, 230);
            btnLogin.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnLogin.ForeColor = Color.Black;
            btnLogin.Location = new Point(-176, 342);
            btnLogin.Margin = new Padding(0);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(95, 30);
            btnLogin.TabIndex = 8;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = false;
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
            panelMain.Controls.Add(txtUsername);
            panelMain.Controls.Add(txtPassword);
            panelMain.Font = new Font("Segoe UI", 12F);
            panelMain.Location = new Point(0, 0);
            panelMain.Margin = new Padding(0);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(21, 18, 21, 18);
            panelMain.Size = new Size(0, 379);
            panelMain.TabIndex = 9;
            // 
            // ucLoading1
            // 
            ucLoading1.BackColor = Color.FromArgb(255, 224, 192);
            ucLoading1.Language = TextManagement.EmLanguage.Vietnamese;
            ucLoading1.Location = new Point(382, 213);
            ucLoading1.Margin = new Padding(3, 2, 3, 2);
            ucLoading1.Message = "Preparing to download";
            ucLoading1.Name = "ucLoading1";
            ucLoading1.Size = new Size(343, 141);
            ucLoading1.TabIndex = 13;
            // 
            // lblLoginTitle
            // 
            lblLoginTitle.AutoSize = true;
            lblLoginTitle.BackColor = Color.Transparent;
            lblLoginTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblLoginTitle.Location = new Point(21, 206);
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
            picLogo.Location = new Point(21, 18);
            picLogo.Margin = new Padding(3, 2, 3, 2);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(0, 177);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 11;
            picLogo.TabStop = false;
            // 
            // ucNotify1
            // 
            ucNotify1.BackColor = Color.White;
            ucNotify1.Location = new Point(76, 92);
            ucNotify1.Margin = new Padding(3, 2, 3, 2);
            ucNotify1.MaximumSize = new Size(328, 280);
            ucNotify1.Message = "Nội dung thông báo";
            ucNotify1.MinimumSize = new Size(328, 280);
            ucNotify1.Name = "ucNotify1";
            ucNotify1.NotiType = Usercontrols.BuildControls.ucNotify.EmNotiType.Information;
            ucNotify1.Size = new Size(328, 280);
            ucNotify1.TabIndex = 10;
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(0, 0);
            webView21.Name = "webView21";
            webView21.Size = new Size(631, 473);
            webView21.TabIndex = 10;
            webView21.ZoomFactor = 1D;
            // 
            // timerRefreshToken
            // 
            timerRefreshToken.Interval = 60000;
            timerRefreshToken.Tick += timerRefreshToken_Tick;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(631, 473);
            Controls.Add(lblStatus);
            Controls.Add(webView21);
            Controls.Add(panelMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập hệ thống";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private BtnLogin btnLogin;
        private Panel panelMain;
        private Usercontrols.BuildControls.ucNotify ucNotify1;
        private PictureBox picLogo;
        private Label lblLoginTitle;
        private Usercontrols.BuildControls.ucLoading ucLoading1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private System.Windows.Forms.Timer timerRefreshToken;
    }
}