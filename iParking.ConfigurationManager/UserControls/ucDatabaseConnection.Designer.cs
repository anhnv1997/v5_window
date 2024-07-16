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
            chbIsUseDatabase = new CheckBox();
            btnCheckConnection = new Button();
            cbAuthenMode = new ComboBox();
            txtUsername = new TextBox();
            label3 = new Label();
            cbDatabaseEX = new ComboBox();
            cbDatabase = new ComboBox();
            label6 = new Label();
            txtPassword = new TextBox();
            label5 = new Label();
            label1 = new Label();
            label2 = new Label();
            txtServerName = new TextBox();
            label4 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.Controls.Add(chbIsUseDatabase);
            groupBox1.Controls.Add(btnCheckConnection);
            groupBox1.Controls.Add(cbAuthenMode);
            groupBox1.Controls.Add(txtUsername);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cbDatabaseEX);
            groupBox1.Controls.Add(cbDatabase);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtServerName);
            groupBox1.Controls.Add(label4);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(867, 356);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin Database";
            // 
            // chbIsUseDatabase
            // 
            chbIsUseDatabase.AutoSize = true;
            chbIsUseDatabase.Location = new Point(166, 251);
            chbIsUseDatabase.Margin = new Padding(4, 3, 4, 3);
            chbIsUseDatabase.Name = "chbIsUseDatabase";
            chbIsUseDatabase.Size = new Size(155, 25);
            chbIsUseDatabase.TabIndex = 7;
            chbIsUseDatabase.Text = "Sử dụng Database";
            chbIsUseDatabase.UseVisualStyleBackColor = true;
            // 
            // btnCheckConnection
            // 
            btnCheckConnection.Location = new Point(643, 280);
            btnCheckConnection.Margin = new Padding(4, 3, 4, 3);
            btnCheckConnection.Name = "btnCheckConnection";
            btnCheckConnection.Size = new Size(204, 48);
            btnCheckConnection.TabIndex = 8;
            btnCheckConnection.Text = "Kiểm tra kết nối";
            btnCheckConnection.UseVisualStyleBackColor = true;
            // 
            // cbAuthenMode
            // 
            cbAuthenMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAuthenMode.FormattingEnabled = true;
            cbAuthenMode.Location = new Point(166, 56);
            cbAuthenMode.Margin = new Padding(4, 3, 4, 3);
            cbAuthenMode.Name = "cbAuthenMode";
            cbAuthenMode.Size = new Size(680, 29);
            cbAuthenMode.TabIndex = 2;
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUsername.Location = new Point(166, 91);
            txtUsername.Margin = new Padding(4, 3, 4, 3);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Tên đăng nhập vào hệ thống";
            txtUsername.Size = new Size(680, 29);
            txtUsername.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 90);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(111, 21);
            label3.TabIndex = 7;
            label3.Text = "Tên đăng nhập";
            // 
            // cbDatabaseEX
            // 
            cbDatabaseEX.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDatabaseEX.FormattingEnabled = true;
            cbDatabaseEX.Location = new Point(166, 199);
            cbDatabaseEX.Margin = new Padding(4, 3, 4, 3);
            cbDatabaseEX.Name = "cbDatabaseEX";
            cbDatabaseEX.Size = new Size(680, 29);
            cbDatabaseEX.TabIndex = 6;
            // 
            // cbDatabase
            // 
            cbDatabase.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDatabase.FormattingEnabled = true;
            cbDatabase.Location = new Point(166, 161);
            cbDatabase.Margin = new Padding(4, 3, 4, 3);
            cbDatabase.Name = "cbDatabase";
            cbDatabase.Size = new Size(680, 29);
            cbDatabase.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 202);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(144, 21);
            label6.TabIndex = 6;
            label6.Text = "Cơ sở dữ liệu event";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.Location = new Point(166, 126);
            txtPassword.Margin = new Padding(4, 3, 4, 3);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Mật khẩu tài khoản hoặc mã bảo mật";
            txtPassword.Size = new Size(680, 29);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 164);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(102, 21);
            label5.TabIndex = 6;
            label5.Text = "Cơ sở dữ liệu";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 129);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(75, 21);
            label1.TabIndex = 6;
            label1.Text = "Mật khẩu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 59);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(119, 21);
            label2.TabIndex = 6;
            label2.Text = "Chế độ xác thực";
            // 
            // txtServerName
            // 
            txtServerName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtServerName.Location = new Point(166, 21);
            txtServerName.Margin = new Padding(4, 3, 4, 3);
            txtServerName.Name = "txtServerName";
            txtServerName.PlaceholderText = "Url của server";
            txtServerName.Size = new Size(680, 29);
            txtServerName.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 24);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(96, 21);
            label4.TabIndex = 2;
            label4.Text = "Tên máy chủ";
            // 
            // ucDatabaseConnection
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ucDatabaseConnection";
            Size = new Size(867, 468);
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
        private CheckBox chbIsUseDatabase;
        private ComboBox cbDatabaseEX;
        private Label label6;
    }
}
