namespace iParking.ConfigurationManager.UserControls
{
    partial class ucLprConnection
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
            label1 = new Label();
            cbLprType = new ComboBox();
            label2 = new Label();
            txtLprUrl = new TextBox();
            label3 = new Label();
            txtUsername = new TextBox();
            label4 = new Label();
            txtPassword = new TextBox();
            panelLprInfo = new Panel();
            panelLprInfo.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 20);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(39, 21);
            label1.TabIndex = 0;
            label1.Text = "Loại";
            // 
            // cbLprType
            // 
            cbLprType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbLprType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLprType.FormattingEnabled = true;
            cbLprType.Location = new Point(136, 15);
            cbLprType.Margin = new Padding(4, 3, 4, 3);
            cbLprType.Name = "cbLprType";
            cbLprType.Size = new Size(514, 29);
            cbLprType.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 6);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(31, 21);
            label2.TabIndex = 2;
            label2.Text = "Url";
            // 
            // txtLprUrl
            // 
            txtLprUrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtLprUrl.Location = new Point(134, 3);
            txtLprUrl.Margin = new Padding(4, 3, 4, 3);
            txtLprUrl.Name = "txtLprUrl";
            txtLprUrl.PlaceholderText = "Link dùng để nhận thông tin biển số";
            txtLprUrl.Size = new Size(514, 29);
            txtLprUrl.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 41);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(111, 21);
            label3.TabIndex = 2;
            label3.Text = "Tên đăng nhập";
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUsername.Location = new Point(134, 38);
            txtUsername.Margin = new Padding(4, 3, 4, 3);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Tên đăng nhập";
            txtUsername.Size = new Size(514, 29);
            txtUsername.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 76);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(75, 21);
            label4.TabIndex = 2;
            label4.Text = "Mật khẩu";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.Location = new Point(134, 73);
            txtPassword.Margin = new Padding(4, 3, 4, 3);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Mật khẩu";
            txtPassword.Size = new Size(514, 29);
            txtPassword.TabIndex = 3;
            // 
            // panelLprInfo
            // 
            panelLprInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelLprInfo.Controls.Add(txtLprUrl);
            panelLprInfo.Controls.Add(txtPassword);
            panelLprInfo.Controls.Add(label2);
            panelLprInfo.Controls.Add(label4);
            panelLprInfo.Controls.Add(label3);
            panelLprInfo.Controls.Add(txtUsername);
            panelLprInfo.Location = new Point(3, 52);
            panelLprInfo.Margin = new Padding(4, 3, 4, 3);
            panelLprInfo.Name = "panelLprInfo";
            panelLprInfo.Size = new Size(660, 115);
            panelLprInfo.TabIndex = 4;
            // 
            // ucLprConnection
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            Controls.Add(panelLprInfo);
            Controls.Add(cbLprType);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ucLprConnection";
            Size = new Size(665, 423);
            panelLprInfo.ResumeLayout(false);
            panelLprInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cbLprType;
        private Label label2;
        private TextBox txtLprUrl;
        private Label label3;
        private TextBox txtUsername;
        private Label label4;
        private TextBox txtPassword;
        private Panel panelLprInfo;
    }
}
