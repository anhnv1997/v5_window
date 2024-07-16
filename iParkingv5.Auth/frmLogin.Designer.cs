using iPakrkingv5.Controls.Controls.Buttons;
using System.Windows.Forms;

namespace iParkingv5.Auth
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
            panelMain = new Panel();
            lblLoginTitle = new Label();
            picLogo = new PictureBox();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            timerRefreshToken = new System.Windows.Forms.Timer(components);
            timerRestartSocket = new System.Windows.Forms.Timer(components);
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
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUsername.Location = new Point(128, 259);
            txtUsername.Margin = new Padding(3, 2, 3, 2);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(0, 29);
            txtUsername.TabIndex = 3;
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
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(lblLoginTitle);
            panelMain.Controls.Add(picLogo);
            panelMain.Controls.Add(lblUsername);
            panelMain.Controls.Add(lblPassword);
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
            picLogo.Location = new Point(21, 18);
            picLogo.Margin = new Padding(3, 2, 3, 2);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(0, 177);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 11;
            picLogo.TabStop = false;
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
            timerRefreshToken.Interval = 1000;
            timerRefreshToken.Tick += timerRefreshToken_Tick;
            // 
            // timerRestartSocket
            // 
            timerRestartSocket.Interval = 3600000;
            timerRestartSocket.Tick += timerRestartSocket_Tick;
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
        private PictureBox picLogo;
        private Label lblLoginTitle;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private System.Windows.Forms.Timer timerRefreshToken;
        private System.Windows.Forms.Timer timerRestartSocket;
    }
}