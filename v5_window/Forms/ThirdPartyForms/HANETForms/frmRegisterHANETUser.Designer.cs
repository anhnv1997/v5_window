namespace iParkingv5_window.Forms.ThirdPartyForms.HANETForms
{
    partial class frmRegisterHANETUser
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
            lblName = new Label();
            label2 = new Label();
            txtName = new TextBox();
            txtCode = new TextBox();
            picFace = new PictureBox();
            label1 = new Label();
            btnRegister = new Button();
            label3 = new Label();
            cbIdentityGroupType = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)picFace).BeginInit();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(5, 238);
            lblName.Name = "lblName";
            lblName.Size = new Size(33, 21);
            lblName.TabIndex = 0;
            lblName.Text = "Tên";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(5, 278);
            label2.Name = "label2";
            label2.Size = new Size(32, 21);
            label2.TabIndex = 0;
            label2.Text = "Mã";
            // 
            // txtName
            // 
            txtName.Location = new Point(84, 235);
            txtName.Name = "txtName";
            txtName.Size = new Size(456, 29);
            txtName.TabIndex = 1;
            // 
            // txtCode
            // 
            txtCode.Location = new Point(84, 275);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(456, 29);
            txtCode.TabIndex = 1;
            // 
            // picFace
            // 
            picFace.BackColor = SystemColors.AppWorkspace;
            picFace.Location = new Point(84, 12);
            picFace.Name = "picFace";
            picFace.Size = new Size(456, 217);
            picFace.SizeMode = PictureBoxSizeMode.Zoom;
            picFace.TabIndex = 2;
            picFace.TabStop = false;
            picFace.DoubleClick += picFace_DoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 208);
            label1.Name = "label1";
            label1.Size = new Size(73, 21);
            label1.TabIndex = 3;
            label1.Text = "Hình ảnh";
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(412, 371);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(128, 46);
            btnRegister.TabIndex = 4;
            btnRegister.Text = "Đăng ký";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(5, 313);
            label3.Name = "label3";
            label3.Size = new Size(32, 21);
            label3.TabIndex = 0;
            label3.Text = "Mã";
            // 
            // cbIdentityGroupType
            // 
            cbIdentityGroupType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbIdentityGroupType.FormattingEnabled = true;
            cbIdentityGroupType.Location = new Point(84, 310);
            cbIdentityGroupType.Name = "cbIdentityGroupType";
            cbIdentityGroupType.Size = new Size(456, 29);
            cbIdentityGroupType.TabIndex = 5;
            // 
            // frmRegisterHANETUser
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(552, 422);
            Controls.Add(cbIdentityGroupType);
            Controls.Add(btnRegister);
            Controls.Add(label1);
            Controls.Add(picFace);
            Controls.Add(txtCode);
            Controls.Add(label3);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(lblName);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "frmRegisterHANETUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng ký thông tin";
            ((System.ComponentModel.ISupportInitialize)picFace).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private Label label2;
        private TextBox txtName;
        private TextBox txtCode;
        private PictureBox picFace;
        private Label label1;
        private Button btnRegister;
        private Label label3;
        private ComboBox cbIdentityGroupType;
    }
}