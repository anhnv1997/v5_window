namespace iParking.ConfigurationManager.UserControls
{
    partial class ucDatabaseConnection
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            label1 = new Label();
            txtServerName = new TextBox();
            txtPassword = new TextBox();
            label3 = new Label();
            txtUsername = new TextBox();
            label4 = new Label();
            cbDatabase = new ComboBox();
            cbAuthenMode = new ComboBox();
            label2 = new Label();
            label5 = new Label();
            btnCheckConnection = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.Controls.Add(btnCheckConnection);
            groupBox1.Controls.Add(cbAuthenMode);
            groupBox1.Controls.Add(txtUsername);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cbDatabase);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtServerName);
            groupBox1.Controls.Add(label4);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(770, 268);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin Database";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 123);
            label1.Name = "label1";
            label1.Size = new Size(70, 20);
            label1.TabIndex = 6;
            label1.Text = "Mật khẩu";
            // 
            // txtServerName
            // 
            txtServerName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtServerName.Location = new Point(147, 20);
            txtServerName.Name = "txtServerName";
            txtServerName.PlaceholderText = "Url của server";
            txtServerName.Size = new Size(605, 27);
            txtServerName.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.Location = new Point(147, 120);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Mật khẩu tài khoản hoặc mã bảo mật";
            txtPassword.Size = new Size(605, 27);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 86);
            label3.Name = "label3";
            label3.Size = new Size(107, 20);
            label3.TabIndex = 7;
            label3.Text = "Tên đăng nhập";
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUsername.Location = new Point(147, 87);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Tên đăng nhập vào hệ thống";
            txtUsername.Size = new Size(605, 27);
            txtUsername.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 23);
            label4.Name = "label4";
            label4.Size = new Size(91, 20);
            label4.TabIndex = 2;
            label4.Text = "Tên máy chủ";
            // 
            // cbDatabase
            // 
            cbDatabase.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDatabase.FormattingEnabled = true;
            cbDatabase.Location = new Point(147, 153);
            cbDatabase.Name = "cbDatabase";
            cbDatabase.Size = new Size(605, 28);
            cbDatabase.TabIndex = 5;
            // 
            // cbAuthenMode
            // 
            cbAuthenMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAuthenMode.FormattingEnabled = true;
            cbAuthenMode.Location = new Point(147, 53);
            cbAuthenMode.Name = "cbAuthenMode";
            cbAuthenMode.Size = new Size(605, 28);
            cbAuthenMode.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 56);
            label2.Name = "label2";
            label2.Size = new Size(115, 20);
            label2.TabIndex = 6;
            label2.Text = "Chế độ xác thực";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 156);
            label5.Name = "label5";
            label5.Size = new Size(96, 20);
            label5.TabIndex = 6;
            label5.Text = "Cơ sở dữ liệu";
            // 
            // btnCheckConnection
            // 
            btnCheckConnection.Location = new Point(570, 196);
            btnCheckConnection.Name = "btnCheckConnection";
            btnCheckConnection.Size = new Size(182, 46);
            btnCheckConnection.TabIndex = 6;
            btnCheckConnection.Text = "Kiểm tra kết nối";
            btnCheckConnection.UseVisualStyleBackColor = true;
            // 
            // ucDatabaseConnection
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Name = "ucDatabaseConnection";
            Size = new Size(770, 445);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private TextBox txtServerName;
        private TextBox txtPassword;
        private Label label3;
        private TextBox txtUsername;
        private Label label4;
        private ComboBox cbAuthenMode;
        private ComboBox cbDatabase;
        private Label label5;
        private Label label2;
        private Button btnCheckConnection;
    }
}
