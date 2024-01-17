namespace iParkingv5_window.Forms.DataForms
{
    partial class frmCustomerRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerRegister));
            label1 = new Label();
            txtCustomerName = new TextBox();
            txtPlate = new TextBox();
            label2 = new Label();
            label3 = new Label();
            cbCustomerGroup = new ComboBox();
            label4 = new Label();
            dtpExpireTime = new DateTimePicker();
            label5 = new Label();
            label6 = new Label();
            txtIdentity = new TextBox();
            cbVehicleTypes = new ComboBox();
            label7 = new Label();
            txtCustomerCode = new TextBox();
            btnOk1 = new Controls.Buttons.LblOk();
            btnSearch = new Controls.Buttons.LblSearch();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22F);
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(64, 41);
            label1.TabIndex = 0;
            label1.Text = "Tên";
            // 
            // txtCustomerName
            // 
            txtCustomerName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCustomerName.Font = new Font("Segoe UI", 22F);
            txtCustomerName.Location = new Point(318, 9);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(677, 47);
            txtCustomerName.TabIndex = 1;
            // 
            // txtPlate
            // 
            txtPlate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPlate.Font = new Font("Segoe UI", 22F);
            txtPlate.Location = new Point(318, 222);
            txtPlate.Name = "txtPlate";
            txtPlate.Size = new Size(915, 47);
            txtPlate.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 22F);
            label2.Location = new Point(12, 149);
            label2.Name = "label2";
            label2.Size = new Size(262, 41);
            label2.TabIndex = 0;
            label2.Text = "Nhóm khách hàng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 22F);
            label3.Location = new Point(12, 225);
            label3.Name = "label3";
            label3.Size = new Size(152, 41);
            label3.TabIndex = 0;
            label3.Text = "Biển số xe";
            // 
            // cbCustomerGroup
            // 
            cbCustomerGroup.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbCustomerGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCustomerGroup.Font = new Font("Segoe UI", 22F);
            cbCustomerGroup.FormattingEnabled = true;
            cbCustomerGroup.Location = new Point(318, 146);
            cbCustomerGroup.Name = "cbCustomerGroup";
            cbCustomerGroup.Size = new Size(915, 48);
            cbCustomerGroup.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 22F);
            label4.Location = new Point(12, 303);
            label4.Name = "label4";
            label4.Size = new Size(244, 41);
            label4.TabIndex = 0;
            label4.Text = "Loại phương tiện";
            // 
            // dtpExpireTime
            // 
            dtpExpireTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpExpireTime.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtpExpireTime.Font = new Font("Segoe UI", 22F);
            dtpExpireTime.Format = DateTimePickerFormat.Custom;
            dtpExpireTime.Location = new Point(318, 379);
            dtpExpireTime.Name = "dtpExpireTime";
            dtpExpireTime.Size = new Size(915, 47);
            dtpExpireTime.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 22F);
            label5.Location = new Point(12, 384);
            label5.Name = "label5";
            label5.Size = new Size(196, 41);
            label5.TabIndex = 0;
            label5.Text = "Ngày hết hạn";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 22F);
            label6.Location = new Point(12, 464);
            label6.Name = "label6";
            label6.Size = new Size(155, 41);
            label6.TabIndex = 5;
            label6.Text = "Định danh";
            // 
            // txtIdentity
            // 
            txtIdentity.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtIdentity.Font = new Font("Segoe UI", 22F);
            txtIdentity.Location = new Point(318, 461);
            txtIdentity.Name = "txtIdentity";
            txtIdentity.PlaceholderText = "Quẹt thẻ vào đầu đọc của làn để lấy thông tin định danh";
            txtIdentity.Size = new Size(915, 47);
            txtIdentity.TabIndex = 7;
            // 
            // cbVehicleTypes
            // 
            cbVehicleTypes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbVehicleTypes.DropDownStyle = ComboBoxStyle.DropDownList;
            cbVehicleTypes.Font = new Font("Segoe UI", 22F);
            cbVehicleTypes.FormattingEnabled = true;
            cbVehicleTypes.Location = new Point(318, 300);
            cbVehicleTypes.Name = "cbVehicleTypes";
            cbVehicleTypes.Size = new Size(915, 48);
            cbVehicleTypes.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 22F);
            label7.Location = new Point(12, 77);
            label7.Name = "label7";
            label7.Size = new Size(221, 41);
            label7.TabIndex = 0;
            label7.Text = "Mã khách hàng";
            // 
            // txtCustomerCode
            // 
            txtCustomerCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCustomerCode.Font = new Font("Segoe UI", 22F);
            txtCustomerCode.Location = new Point(318, 74);
            txtCustomerCode.Name = "txtCustomerCode";
            txtCustomerCode.PlaceholderText = "Thông tin để phân biệt giữa các khách hàng (nên dùng số điện thoại, CMT)";
            txtCustomerCode.Size = new Size(915, 47);
            txtCustomerCode.TabIndex = 2;
            // 
            // btnOk1
            // 
            btnOk1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk1.AutoSize = true;
            btnOk1.BorderStyle = BorderStyle.Fixed3D;
            btnOk1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btnOk1.ForeColor = Color.Black;
            btnOk1.Location = new Point(1053, 613);
            btnOk1.Name = "btnOk1";
            btnOk1.Size = new Size(121, 34);
            btnOk1.TabIndex = 8;
            btnOk1.Text = "Xác nhận";
            btnOk1.Click += btnConfirm_Click;
            // 
            // btnSearch
            // 
            btnSearch.AutoSize = true;
            btnSearch.BorderStyle = BorderStyle.Fixed3D;
            btnSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnSearch.Location = new Point(1001, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(83, 22);
            btnSearch.TabIndex = 9;
            btnSearch.Text = "lblSearch1";
            // 
            // frmCustomerRegister
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1245, 676);
            Controls.Add(btnSearch);
            Controls.Add(btnOk1);
            Controls.Add(cbVehicleTypes);
            Controls.Add(txtIdentity);
            Controls.Add(label6);
            Controls.Add(dtpExpireTime);
            Controls.Add(cbCustomerGroup);
            Controls.Add(txtPlate);
            Controls.Add(txtCustomerCode);
            Controls.Add(txtCustomerName);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label7);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmCustomerRegister";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng ký khách hàng";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtCustomerName;
        private TextBox txtPlate;
        private Label label2;
        private Label label3;
        private ComboBox cbCustomerGroup;
        private Label label4;
        private DateTimePicker dtpExpireTime;
        private Label label5;
        private Label label6;
        private TextBox txtIdentity;
        private ComboBox cbVehicleTypes;
        private Label label7;
        private TextBox txtCustomerCode;
        private Controls.Buttons.LblOk btnOk1;
        private Controls.Buttons.LblSearch btnSearch;
    }
}