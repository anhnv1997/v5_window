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
            btnLogin = new Button();
            btnExit = new Button();
            timerAutoConnect = new System.Windows.Forms.Timer(components);
            lblStatus = new Label();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(8, 25);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(107, 20);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Tên đăng nhập";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(8, 64);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(70, 20);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Mật khẩu";
            // 
            // chbIsRemember
            // 
            chbIsRemember.AutoSize = true;
            chbIsRemember.Location = new Point(123, 94);
            chbIsRemember.Name = "chbIsRemember";
            chbIsRemember.Size = new Size(121, 24);
            chbIsRemember.TabIndex = 5;
            chbIsRemember.Text = "Nhớ tài khoản";
            chbIsRemember.UseVisualStyleBackColor = true;
            chbIsRemember.CheckedChanged += chbIsRemember_CheckedChanged;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(123, 22);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(289, 27);
            txtUsername.TabIndex = 3;
            txtUsername.Click += Control_Click;
            txtUsername.TextChanged += textBox_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(123, 61);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(289, 27);
            txtPassword.TabIndex = 4;
            txtPassword.TextChanged += textBox_TextChanged;
            // 
            // btnLogin
            // 
            btnLogin.AutoSize = true;
            btnLogin.Location = new Point(231, 131);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(92, 30);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.AutoSize = true;
            btnExit.Location = new Point(337, 131);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 30);
            btnExit.TabIndex = 1;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
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
            lblStatus.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic, GraphicsUnit.Point);
            lblStatus.ForeColor = Color.Green;
            lblStatus.Location = new Point(8, 171);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(48, 20);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "label1";
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(423, 199);
            Controls.Add(lblStatus);
            Controls.Add(btnExit);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(chbIsRemember);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập hệ thống";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsername;
        private Label lblPassword;
        private CheckBox chbIsRemember;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnExit;
        private System.Windows.Forms.Timer timerAutoConnect;
        private Label lblStatus;
    }
}