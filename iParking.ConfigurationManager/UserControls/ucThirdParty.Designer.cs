namespace iParking.ConfigurationManager.UserControls
{
    partial class ucThirdParty
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
            txtServerUrl = new TextBox();
            label7 = new Label();
            label3 = new Label();
            groupBox2 = new GroupBox();
            label1 = new Label();
            txtUsername = new TextBox();
            label2 = new Label();
            txtPassword = new TextBox();
            chbIsUse = new CheckBox();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // txtServerUrl
            // 
            txtServerUrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtServerUrl.Location = new Point(127, 28);
            txtServerUrl.Name = "txtServerUrl";
            txtServerUrl.Size = new Size(425, 27);
            txtServerUrl.TabIndex = 13;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(899, 230);
            label7.Name = "label7";
            label7.Size = new Size(28, 20);
            label7.TabIndex = 12;
            label7.Text = "ms";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 31);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 8;
            label3.Text = "Server";
            // 
            // groupBox2
            // 
            groupBox2.AutoSize = true;
            groupBox2.Controls.Add(chbIsUse);
            groupBox2.Controls.Add(txtPassword);
            groupBox2.Controls.Add(txtUsername);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(txtServerUrl);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label3);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(555, 273);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin thiết bị cân";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 64);
            label1.Name = "label1";
            label1.Size = new Size(107, 20);
            label1.TabIndex = 8;
            label1.Text = "Tên đăng nhập";
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUsername.Location = new Point(127, 61);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(425, 27);
            txtUsername.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 97);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 8;
            label2.Text = "Mật khẩu";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.Location = new Point(127, 94);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(425, 27);
            txtPassword.TabIndex = 13;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // chbIsUse
            // 
            chbIsUse.AutoSize = true;
            chbIsUse.Location = new Point(127, 127);
            chbIsUse.Name = "chbIsUse";
            chbIsUse.Size = new Size(83, 24);
            chbIsUse.TabIndex = 14;
            chbIsUse.Text = "Sử dụng";
            chbIsUse.UseVisualStyleBackColor = true;
            // 
            // ucThirdParty
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox2);
            Name = "ucThirdParty";
            Size = new Size(555, 331);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtServerUrl;
        private Label label7;
        private Label label3;
        private GroupBox groupBox2;
        private CheckBox chbIsUse;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label label2;
        private Label label1;
    }
}
