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
            cbDatabase = new ComboBox();
            txtPassword = new TextBox();
            label5 = new Label();
            label1 = new Label();
            label2 = new Label();
            txtServerName = new TextBox();
            label4 = new Label();
            label6 = new Label();
            cbDatabaseEX = new ComboBox();
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
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(674, 254);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin Database";
            // 
            // chbIsUseDatabase
            // 
            chbIsUseDatabase.AutoSize = true;
            chbIsUseDatabase.Location = new Point(129, 179);
            chbIsUseDatabase.Margin = new Padding(3, 2, 3, 2);
            chbIsUseDatabase.Name = "chbIsUseDatabase";
            chbIsUseDatabase.Size = new Size(121, 19);
            chbIsUseDatabase.TabIndex = 7;
            chbIsUseDatabase.Text = "Sử dụng Database";
            chbIsUseDatabase.UseVisualStyleBackColor = true;
            // 
            // btnCheckConnection
            // 
            btnCheckConnection.Location = new Point(500, 200);
            btnCheckConnection.Margin = new Padding(3, 2, 3, 2);
            btnCheckConnection.Name = "btnCheckConnection";
            btnCheckConnection.Size = new Size(159, 34);
            btnCheckConnection.TabIndex = 8;
            btnCheckConnection.Text = "Kiểm tra kết nối";
            btnCheckConnection.UseVisualStyleBackColor = true;
            // 
            // cbAuthenMode
            // 
            cbAuthenMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAuthenMode.FormattingEnabled = true;
            cbAuthenMode.Location = new Point(129, 40);
            cbAuthenMode.Margin = new Padding(3, 2, 3, 2);
            cbAuthenMode.Name = "cbAuthenMode";
            cbAuthenMode.Size = new Size(530, 23);
            cbAuthenMode.TabIndex = 2;
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUsername.Location = new Point(129, 65);
            txtUsername.Margin = new Padding(3, 2, 3, 2);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Tên đăng nhập vào hệ thống";
            txtUsername.Size = new Size(530, 23);
            txtUsername.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(5, 64);
            label3.Name = "label3";
            label3.Size = new Size(85, 15);
            label3.TabIndex = 7;
            label3.Text = "Tên đăng nhập";
            // 
            // cbDatabase
            // 
            cbDatabase.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDatabase.FormattingEnabled = true;
            cbDatabase.Location = new Point(129, 115);
            cbDatabase.Margin = new Padding(3, 2, 3, 2);
            cbDatabase.Name = "cbDatabase";
            cbDatabase.Size = new Size(530, 23);
            cbDatabase.TabIndex = 5;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.Location = new Point(129, 90);
            txtPassword.Margin = new Padding(3, 2, 3, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Mật khẩu tài khoản hoặc mã bảo mật";
            txtPassword.Size = new Size(530, 23);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(5, 117);
            label5.Name = "label5";
            label5.Size = new Size(76, 15);
            label5.TabIndex = 6;
            label5.Text = "Cơ sở dữ liệu";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 92);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 6;
            label1.Text = "Mật khẩu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(5, 42);
            label2.Name = "label2";
            label2.Size = new Size(93, 15);
            label2.TabIndex = 6;
            label2.Text = "Chế độ xác thực";
            // 
            // txtServerName
            // 
            txtServerName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtServerName.Location = new Point(129, 15);
            txtServerName.Margin = new Padding(3, 2, 3, 2);
            txtServerName.Name = "txtServerName";
            txtServerName.PlaceholderText = "Url của server";
            txtServerName.Size = new Size(530, 23);
            txtServerName.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(5, 17);
            label4.Name = "label4";
            label4.Size = new Size(74, 15);
            label4.TabIndex = 2;
            label4.Text = "Tên máy chủ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(5, 144);
            label6.Name = "label6";
            label6.Size = new Size(108, 15);
            label6.TabIndex = 6;
            label6.Text = "Cơ sở dữ liệu event";
            // 
            // cbDatabaseEX
            // 
            cbDatabaseEX.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDatabaseEX.FormattingEnabled = true;
            cbDatabaseEX.Location = new Point(129, 142);
            cbDatabaseEX.Margin = new Padding(3, 2, 3, 2);
            cbDatabaseEX.Name = "cbDatabaseEX";
            cbDatabaseEX.Size = new Size(530, 23);
            cbDatabaseEX.TabIndex = 6;
            // 
            // ucDatabaseConnection
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ucDatabaseConnection";
            Size = new Size(674, 334);
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
