namespace iParkingv5_window.Forms.ThirdPartyForms.OfficeHausForms
{
    partial class frmAddVisitor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddVisitor));
            label1 = new Label();
            label2 = new Label();
            cbIdentityGroupType = new ComboBox();
            txtPlateNumber = new TextBox();
            BtnOk = new Button();
            BtnCancel = new Button();
            lblGuide = new Label();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 56);
            label1.Name = "label1";
            label1.Size = new Size(79, 21);
            label1.TabIndex = 0;
            label1.Text = "Biển số xe";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 21);
            label2.Name = "label2";
            label2.Size = new Size(39, 21);
            label2.TabIndex = 0;
            label2.Text = "Loại";
            // 
            // cbIdentityGroupType
            // 
            cbIdentityGroupType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbIdentityGroupType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbIdentityGroupType.FormattingEnabled = true;
            cbIdentityGroupType.Location = new Point(115, 18);
            cbIdentityGroupType.Name = "cbIdentityGroupType";
            cbIdentityGroupType.Size = new Size(628, 29);
            cbIdentityGroupType.TabIndex = 0;
            // 
            // txtPlateNumber
            // 
            txtPlateNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPlateNumber.Location = new Point(115, 53);
            txtPlateNumber.Name = "txtPlateNumber";
            txtPlateNumber.Size = new Size(628, 29);
            txtPlateNumber.TabIndex = 1;
            // 
            // BtnOk
            // 
            BtnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnOk.AutoSize = true;
            BtnOk.Image = (Image)resources.GetObject("BtnOk.Image");
            BtnOk.Location = new Point(511, 10);
            BtnOk.Name = "BtnOk";
            BtnOk.Size = new Size(115, 44);
            BtnOk.TabIndex = 2;
            BtnOk.Text = "Xác nhận";
            BtnOk.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnOk.UseVisualStyleBackColor = true;
            BtnOk.Click += BtnOk_Click;
            // 
            // BtnCancel
            // 
            BtnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnCancel.AutoSize = true;
            BtnCancel.Image = (Image)resources.GetObject("BtnCancel.Image");
            BtnCancel.Location = new Point(632, 10);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(111, 44);
            BtnCancel.TabIndex = 3;
            BtnCancel.Text = "Đóng";
            BtnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // lblGuide
            // 
            lblGuide.Dock = DockStyle.Left;
            lblGuide.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblGuide.ForeColor = Color.FromArgb(255, 128, 0);
            lblGuide.Location = new Point(0, 0);
            lblGuide.Name = "lblGuide";
            lblGuide.Size = new Size(509, 64);
            lblGuide.TabIndex = 7;
            lblGuide.Text = "Vui lòng kiểm tra và nhập biển số phương tiện vào ô biển số ra.\r\nNhấn Enter để xác nhận, Esc để hủy.";
            lblGuide.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblGuide);
            panel1.Controls.Add(BtnCancel);
            panel1.Controls.Add(BtnOk);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 118);
            panel1.Name = "panel1";
            panel1.Size = new Size(755, 64);
            panel1.TabIndex = 8;
            // 
            // frmAddVisitor
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(755, 182);
            Controls.Add(panel1);
            Controls.Add(txtPlateNumber);
            Controls.Add(cbIdentityGroupType);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new Padding(4);
            Name = "frmAddVisitor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng ký thông tin";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cbIdentityGroupType;
        private TextBox txtPlateNumber;
        private Button BtnOk;
        private Button BtnCancel;
        private Label lblGuide;
        private Panel panel1;
    }
}