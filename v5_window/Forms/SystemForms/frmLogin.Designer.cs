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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.chbIsRemember = new System.Windows.Forms.CheckBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.timerAutoConnect = new System.Windows.Forms.Timer(this.components);
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnCancel1 = new iPakrkingv5.Controls.Controls.Buttons.LblCancel();
            this.btnLogin = new iPakrkingv5.Controls.Controls.Buttons.BtnLogin();
            this.panelMain = new System.Windows.Forms.Panel();
            this.ucLoading1 = new iParkingv5_window.Usercontrols.BuildControls.ucLoading();
            this.lblLoginTitle = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.ucNotify1 = new iParkingv5_window.Usercontrols.BuildControls.ucNotify();
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.timerRefreshToken = new System.Windows.Forms.Timer(this.components);
            this.timerRestartSocket = new System.Windows.Forms.Timer(this.components);
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Location = new System.Drawing.Point(28, 261);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(111, 21);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Tên đăng nhập";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Location = new System.Drawing.Point(28, 290);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(75, 21);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Mật khẩu";
            // 
            // chbIsRemember
            // 
            this.chbIsRemember.AutoSize = true;
            this.chbIsRemember.BackColor = System.Drawing.Color.Transparent;
            this.chbIsRemember.Location = new System.Drawing.Point(128, 313);
            this.chbIsRemember.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chbIsRemember.Name = "chbIsRemember";
            this.chbIsRemember.Size = new System.Drawing.Size(128, 25);
            this.chbIsRemember.TabIndex = 5;
            this.chbIsRemember.Text = "Nhớ tài khoản";
            this.chbIsRemember.UseVisualStyleBackColor = false;
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.Location = new System.Drawing.Point(128, 259);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(0, 29);
            this.txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(128, 288);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(0, 29);
            this.txtPassword.TabIndex = 4;
            // 
            // timerAutoConnect
            // 
            this.timerAutoConnect.Interval = 1000;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic);
            this.lblStatus.ForeColor = System.Drawing.Color.Green;
            this.lblStatus.Location = new System.Drawing.Point(12, 444);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(48, 20);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "label1";
            // 
            // btnCancel1
            // 
            this.btnCancel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel1.AutoSize = true;
            this.btnCancel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnCancel1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel1.ForeColor = System.Drawing.Color.Black;
            this.btnCancel1.Location = new System.Drawing.Point(-82, 342);
            this.btnCancel1.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel1.Name = "btnCancel1";
            this.btnCancel1.Size = new System.Drawing.Size(60, 30);
            this.btnCancel1.TabIndex = 7;
            this.btnCancel1.Text = "Thoát";
            this.btnCancel1.UseVisualStyleBackColor = false;
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogin.AutoSize = true;
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.Black;
            this.btnLogin.Location = new System.Drawing.Point(-176, 342);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(0);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(95, 30);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = false;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.ucLoading1);
            this.panelMain.Controls.Add(this.lblLoginTitle);
            this.panelMain.Controls.Add(this.picLogo);
            this.panelMain.Controls.Add(this.ucNotify1);
            this.panelMain.Controls.Add(this.lblUsername);
            this.panelMain.Controls.Add(this.btnLogin);
            this.panelMain.Controls.Add(this.lblPassword);
            this.panelMain.Controls.Add(this.btnCancel1);
            this.panelMain.Controls.Add(this.chbIsRemember);
            this.panelMain.Controls.Add(this.txtUsername);
            this.panelMain.Controls.Add(this.txtPassword);
            this.panelMain.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(21, 18, 21, 18);
            this.panelMain.Size = new System.Drawing.Size(0, 379);
            this.panelMain.TabIndex = 9;
            // 
            // ucLoading1
            // 
            this.ucLoading1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ucLoading1.Language = IPaking.Ultility.TextManagement.EmLanguage.Vietnamese;
            this.ucLoading1.Location = new System.Drawing.Point(382, 213);
            this.ucLoading1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucLoading1.Message = "Preparing to download";
            this.ucLoading1.Name = "ucLoading1";
            this.ucLoading1.Size = new System.Drawing.Size(343, 141);
            this.ucLoading1.TabIndex = 13;
            // 
            // lblLoginTitle
            // 
            this.lblLoginTitle.AutoSize = true;
            this.lblLoginTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblLoginTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblLoginTitle.Location = new System.Drawing.Point(21, 206);
            this.lblLoginTitle.Name = "lblLoginTitle";
            this.lblLoginTitle.Size = new System.Drawing.Size(328, 45);
            this.lblLoginTitle.TabIndex = 12;
            this.lblLoginTitle.Text = "Đăng nhập hệ thống";
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.picLogo.Location = new System.Drawing.Point(21, 18);
            this.picLogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(0, 177);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 11;
            this.picLogo.TabStop = false;
            // 
            // ucNotify1
            // 
            this.ucNotify1.BackColor = System.Drawing.Color.White;
            this.ucNotify1.Location = new System.Drawing.Point(76, 92);
            this.ucNotify1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucNotify1.MaximumSize = new System.Drawing.Size(328, 280);
            this.ucNotify1.Message = "Nội dung thông báo";
            this.ucNotify1.MinimumSize = new System.Drawing.Size(328, 280);
            this.ucNotify1.Name = "ucNotify1";
            this.ucNotify1.NotiType = iParkingv5_window.Usercontrols.BuildControls.ucNotify.EmNotiType.Information;
            this.ucNotify1.Size = new System.Drawing.Size(328, 280);
            this.ucNotify1.TabIndex = 10;
            // 
            // webView21
            // 
            this.webView21.AllowExternalDrop = true;
            this.webView21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.Location = new System.Drawing.Point(0, 0);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(631, 473);
            this.webView21.TabIndex = 10;
            this.webView21.ZoomFactor = 1D;
            // 
            // timerRefreshToken
            // 
            this.timerRefreshToken.Interval = 1000;
            // 
            // timerRestartSocket
            // 
            this.timerRestartSocket.Interval = 3600000;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(631, 473);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.webView21);
            this.Controls.Add(this.panelMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập hệ thống";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Timer timerRestartSocket;
    }
}