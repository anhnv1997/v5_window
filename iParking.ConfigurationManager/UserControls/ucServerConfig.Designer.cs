namespace iParking.ConfigurationManager.UserControls
{
    partial class ucServerConfig
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
            groupBox2 = new GroupBox();
            txtParkingServerUrl = new TextBox();
            label2 = new Label();
            groupBox1 = new GroupBox();
            label1 = new Label();
            txtMinioServerUrl = new TextBox();
            txtMinioServerPassword = new TextBox();
            label3 = new Label();
            txtMinioServerUsername = new TextBox();
            label4 = new Label();
            groupBox3 = new GroupBox();
            label5 = new Label();
            txtRabbitMqServer = new TextBox();
            txtRabbitMQPassword = new TextBox();
            label6 = new Label();
            txtRabbitMQUsername = new TextBox();
            label7 = new Label();
            groupBox4 = new GroupBox();
            label8 = new Label();
            txtMQTTServer = new TextBox();
            txtMQTTPassword = new TextBox();
            label9 = new Label();
            txtMQTTUsername = new TextBox();
            label10 = new Label();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.AutoSize = true;
            groupBox2.Controls.Add(txtParkingServerUrl);
            groupBox2.Controls.Add(label2);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(703, 78);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin Parking Server";
            // 
            // txtParkingServerUrl
            // 
            txtParkingServerUrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtParkingServerUrl.Location = new Point(166, 21);
            txtParkingServerUrl.Margin = new Padding(4, 3, 4, 3);
            txtParkingServerUrl.Name = "txtParkingServerUrl";
            txtParkingServerUrl.PlaceholderText = "Url của server";
            txtParkingServerUrl.Size = new Size(513, 29);
            txtParkingServerUrl.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 24);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(31, 21);
            label2.TabIndex = 2;
            label2.Text = "Url";
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtMinioServerUrl);
            groupBox1.Controls.Add(txtMinioServerPassword);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtMinioServerUsername);
            groupBox1.Controls.Add(label4);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 78);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(703, 147);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin Minio Server";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 94);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(93, 21);
            label1.TabIndex = 6;
            label1.Text = "Mã bảo mật";
            // 
            // txtMinioServerUrl
            // 
            txtMinioServerUrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMinioServerUrl.Location = new Point(166, 21);
            txtMinioServerUrl.Margin = new Padding(4, 3, 4, 3);
            txtMinioServerUrl.Name = "txtMinioServerUrl";
            txtMinioServerUrl.PlaceholderText = "Url của server";
            txtMinioServerUrl.Size = new Size(513, 29);
            txtMinioServerUrl.TabIndex = 1;
            // 
            // txtMinioServerPassword
            // 
            txtMinioServerPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMinioServerPassword.Location = new Point(166, 90);
            txtMinioServerPassword.Margin = new Padding(4, 3, 4, 3);
            txtMinioServerPassword.Name = "txtMinioServerPassword";
            txtMinioServerPassword.PasswordChar = '*';
            txtMinioServerPassword.PlaceholderText = "Mật khẩu tài khoản hoặc mã bảo mật";
            txtMinioServerPassword.Size = new Size(513, 29);
            txtMinioServerPassword.TabIndex = 3;
            txtMinioServerPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 55);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(111, 21);
            label3.TabIndex = 7;
            label3.Text = "Tên đăng nhập";
            // 
            // txtMinioServerUsername
            // 
            txtMinioServerUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMinioServerUsername.Location = new Point(166, 56);
            txtMinioServerUsername.Margin = new Padding(4, 3, 4, 3);
            txtMinioServerUsername.Name = "txtMinioServerUsername";
            txtMinioServerUsername.PlaceholderText = "Tên đăng nhập vào hệ thống";
            txtMinioServerUsername.Size = new Size(513, 29);
            txtMinioServerUsername.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 24);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(31, 21);
            label4.TabIndex = 2;
            label4.Text = "Url";
            // 
            // groupBox3
            // 
            groupBox3.AutoSize = true;
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(txtRabbitMqServer);
            groupBox3.Controls.Add(txtRabbitMQPassword);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(txtRabbitMQUsername);
            groupBox3.Controls.Add(label7);
            groupBox3.Dock = DockStyle.Top;
            groupBox3.Location = new Point(0, 225);
            groupBox3.Margin = new Padding(4, 3, 4, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4, 3, 4, 3);
            groupBox3.Size = new Size(703, 147);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Thông tin Rabbit MQ Server";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 94);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(93, 21);
            label5.TabIndex = 6;
            label5.Text = "Mã bảo mật";
            // 
            // txtRabbitMqServer
            // 
            txtRabbitMqServer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtRabbitMqServer.Location = new Point(166, 21);
            txtRabbitMqServer.Margin = new Padding(4, 3, 4, 3);
            txtRabbitMqServer.Name = "txtRabbitMqServer";
            txtRabbitMqServer.PlaceholderText = "Địa chỉ IP của Server";
            txtRabbitMqServer.Size = new Size(513, 29);
            txtRabbitMqServer.TabIndex = 1;
            // 
            // txtRabbitMQPassword
            // 
            txtRabbitMQPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtRabbitMQPassword.Location = new Point(166, 90);
            txtRabbitMQPassword.Margin = new Padding(4, 3, 4, 3);
            txtRabbitMQPassword.Name = "txtRabbitMQPassword";
            txtRabbitMQPassword.PasswordChar = '*';
            txtRabbitMQPassword.PlaceholderText = "Mật khẩu tài khoản hoặc mã bảo mật";
            txtRabbitMQPassword.Size = new Size(513, 29);
            txtRabbitMQPassword.TabIndex = 3;
            txtRabbitMQPassword.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 55);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(111, 21);
            label6.TabIndex = 7;
            label6.Text = "Tên đăng nhập";
            // 
            // txtRabbitMQUsername
            // 
            txtRabbitMQUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtRabbitMQUsername.Location = new Point(166, 56);
            txtRabbitMQUsername.Margin = new Padding(4, 3, 4, 3);
            txtRabbitMQUsername.Name = "txtRabbitMQUsername";
            txtRabbitMQUsername.PlaceholderText = "Tên đăng nhập vào hệ thống";
            txtRabbitMQUsername.Size = new Size(513, 29);
            txtRabbitMQUsername.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 24);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(31, 21);
            label7.TabIndex = 2;
            label7.Text = "Url";
            // 
            // groupBox4
            // 
            groupBox4.AutoSize = true;
            groupBox4.Controls.Add(label8);
            groupBox4.Controls.Add(txtMQTTServer);
            groupBox4.Controls.Add(txtMQTTPassword);
            groupBox4.Controls.Add(label9);
            groupBox4.Controls.Add(txtMQTTUsername);
            groupBox4.Controls.Add(label10);
            groupBox4.Dock = DockStyle.Top;
            groupBox4.Location = new Point(0, 372);
            groupBox4.Margin = new Padding(4, 3, 4, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(4, 3, 4, 3);
            groupBox4.Size = new Size(703, 147);
            groupBox4.TabIndex = 8;
            groupBox4.TabStop = false;
            groupBox4.Text = "Thông tin MQTT";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(7, 94);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(93, 21);
            label8.TabIndex = 6;
            label8.Text = "Mã bảo mật";
            // 
            // txtMQTTServer
            // 
            txtMQTTServer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMQTTServer.Location = new Point(167, 21);
            txtMQTTServer.Margin = new Padding(4, 3, 4, 3);
            txtMQTTServer.Name = "txtMQTTServer";
            txtMQTTServer.PlaceholderText = "Địa chỉ IP của Server";
            txtMQTTServer.Size = new Size(512, 29);
            txtMQTTServer.TabIndex = 1;
            // 
            // txtMQTTPassword
            // 
            txtMQTTPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMQTTPassword.Location = new Point(167, 90);
            txtMQTTPassword.Margin = new Padding(4, 3, 4, 3);
            txtMQTTPassword.Name = "txtMQTTPassword";
            txtMQTTPassword.PasswordChar = '*';
            txtMQTTPassword.PlaceholderText = "Mật khẩu tài khoản hoặc mã bảo mật";
            txtMQTTPassword.Size = new Size(512, 29);
            txtMQTTPassword.TabIndex = 3;
            txtMQTTPassword.UseSystemPasswordChar = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(7, 55);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(111, 21);
            label9.TabIndex = 7;
            label9.Text = "Tên đăng nhập";
            // 
            // txtMQTTUsername
            // 
            txtMQTTUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMQTTUsername.Location = new Point(167, 56);
            txtMQTTUsername.Margin = new Padding(4, 3, 4, 3);
            txtMQTTUsername.Name = "txtMQTTUsername";
            txtMQTTUsername.PlaceholderText = "Tên đăng nhập vào hệ thống";
            txtMQTTUsername.Size = new Size(512, 29);
            txtMQTTUsername.TabIndex = 2;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(7, 24);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(31, 21);
            label10.TabIndex = 2;
            label10.Text = "Url";
            // 
            // ucServerConfig
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ucServerConfig";
            Size = new Size(703, 529);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox2;
        private TextBox txtParkingServerUrl;
        private Label label2;
        private GroupBox groupBox1;
        private Label label1;
        private TextBox txtMinioServerUrl;
        private TextBox txtMinioServerPassword;
        private Label label3;
        private TextBox txtMinioServerUsername;
        private Label label4;
        private GroupBox groupBox3;
        private Label label5;
        private TextBox txtRabbitMqServer;
        private TextBox txtRabbitMQPassword;
        private Label label6;
        private TextBox txtRabbitMQUsername;
        private Label label7;
        private GroupBox groupBox4;
        private Label label8;
        private TextBox txtMQTTServer;
        private TextBox txtMQTTPassword;
        private Label label9;
        private TextBox txtMQTTUsername;
        private Label label10;
    }
}
