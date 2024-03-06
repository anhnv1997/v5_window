using iPakrkingv5.Controls.Controls.Buttons;

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
            lblCustomerName = new Label();
            txtCustomerName = new TextBox();
            txtPlate = new TextBox();
            lblCustomerGroup = new Label();
            lblPlateNumber = new Label();
            cbCustomerGroup = new ComboBox();
            lblVehicleGroup = new Label();
            dtpExpireTime = new DateTimePicker();
            lblExpireTime = new Label();
            lblIdentity = new Label();
            txtIdentity = new TextBox();
            cbVehicleTypes = new ComboBox();
            lblCustomerCode = new Label();
            txtCustomerCode = new TextBox();
            btnOk1 = new BtnOk();
            btnSearch = new BtnSearch();
            SuspendLayout();
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Font = new Font("Segoe UI", 22F);
            lblCustomerName.Location = new Point(21, 179);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(225, 41);
            lblCustomerName.TabIndex = 0;
            lblCustomerName.Text = "Tên khách hàng";
            // 
            // txtCustomerName
            // 
            txtCustomerName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCustomerName.Font = new Font("Segoe UI", 22F);
            txtCustomerName.Location = new Point(327, 176);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(815, 47);
            txtCustomerName.TabIndex = 3;
            // 
            // txtPlate
            // 
            txtPlate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPlate.Font = new Font("Segoe UI", 22F);
            txtPlate.Location = new Point(327, 34);
            txtPlate.Name = "txtPlate";
            txtPlate.Size = new Size(815, 47);
            txtPlate.TabIndex = 0;
            // 
            // lblCustomerGroup
            // 
            lblCustomerGroup.AutoSize = true;
            lblCustomerGroup.Font = new Font("Segoe UI", 22F);
            lblCustomerGroup.Location = new Point(21, 316);
            lblCustomerGroup.Name = "lblCustomerGroup";
            lblCustomerGroup.Size = new Size(262, 41);
            lblCustomerGroup.TabIndex = 0;
            lblCustomerGroup.Text = "Nhóm khách hàng";
            // 
            // lblPlateNumber
            // 
            lblPlateNumber.AutoSize = true;
            lblPlateNumber.Font = new Font("Segoe UI", 22F);
            lblPlateNumber.Location = new Point(21, 37);
            lblPlateNumber.Name = "lblPlateNumber";
            lblPlateNumber.Size = new Size(152, 41);
            lblPlateNumber.TabIndex = 0;
            lblPlateNumber.Text = "Biển số xe";
            // 
            // cbCustomerGroup
            // 
            cbCustomerGroup.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbCustomerGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCustomerGroup.Font = new Font("Segoe UI", 22F);
            cbCustomerGroup.FormattingEnabled = true;
            cbCustomerGroup.Location = new Point(327, 313);
            cbCustomerGroup.Name = "cbCustomerGroup";
            cbCustomerGroup.Size = new Size(1049, 48);
            cbCustomerGroup.TabIndex = 5;
            // 
            // lblVehicleGroup
            // 
            lblVehicleGroup.AutoSize = true;
            lblVehicleGroup.Font = new Font("Segoe UI", 22F);
            lblVehicleGroup.Location = new Point(21, 115);
            lblVehicleGroup.Name = "lblVehicleGroup";
            lblVehicleGroup.Size = new Size(244, 41);
            lblVehicleGroup.TabIndex = 0;
            lblVehicleGroup.Text = "Loại phương tiện";
            // 
            // dtpExpireTime
            // 
            dtpExpireTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpExpireTime.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtpExpireTime.Font = new Font("Segoe UI", 22F);
            dtpExpireTime.Format = DateTimePickerFormat.Custom;
            dtpExpireTime.Location = new Point(315, 379);
            dtpExpireTime.Name = "dtpExpireTime";
            dtpExpireTime.Size = new Size(1061, 47);
            dtpExpireTime.TabIndex = 6;
            // 
            // lblExpireTime
            // 
            lblExpireTime.AutoSize = true;
            lblExpireTime.Font = new Font("Segoe UI", 22F);
            lblExpireTime.Location = new Point(9, 384);
            lblExpireTime.Name = "lblExpireTime";
            lblExpireTime.Size = new Size(196, 41);
            lblExpireTime.TabIndex = 0;
            lblExpireTime.Text = "Ngày hết hạn";
            // 
            // lblIdentity
            // 
            lblIdentity.AutoSize = true;
            lblIdentity.Font = new Font("Segoe UI", 22F);
            lblIdentity.Location = new Point(9, 464);
            lblIdentity.Name = "lblIdentity";
            lblIdentity.Size = new Size(155, 41);
            lblIdentity.TabIndex = 5;
            lblIdentity.Text = "Định danh";
            // 
            // txtIdentity
            // 
            txtIdentity.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtIdentity.Font = new Font("Segoe UI", 22F);
            txtIdentity.Location = new Point(315, 461);
            txtIdentity.Name = "txtIdentity";
            txtIdentity.PlaceholderText = "Quẹt thẻ vào đầu đọc của làn để lấy thông tin định danh";
            txtIdentity.Size = new Size(1061, 47);
            txtIdentity.TabIndex = 7;
            // 
            // cbVehicleTypes
            // 
            cbVehicleTypes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbVehicleTypes.DropDownStyle = ComboBoxStyle.DropDownList;
            cbVehicleTypes.Font = new Font("Segoe UI", 22F);
            cbVehicleTypes.FormattingEnabled = true;
            cbVehicleTypes.Location = new Point(327, 112);
            cbVehicleTypes.Name = "cbVehicleTypes";
            cbVehicleTypes.Size = new Size(1049, 48);
            cbVehicleTypes.TabIndex = 2;
            // 
            // lblCustomerCode
            // 
            lblCustomerCode.AutoSize = true;
            lblCustomerCode.Font = new Font("Segoe UI", 22F);
            lblCustomerCode.Location = new Point(21, 244);
            lblCustomerCode.Name = "lblCustomerCode";
            lblCustomerCode.Size = new Size(221, 41);
            lblCustomerCode.TabIndex = 0;
            lblCustomerCode.Text = "Mã khách hàng";
            // 
            // txtCustomerCode
            // 
            txtCustomerCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCustomerCode.Font = new Font("Segoe UI", 22F);
            txtCustomerCode.Location = new Point(327, 241);
            txtCustomerCode.Name = "txtCustomerCode";
            txtCustomerCode.PlaceholderText = "Thông tin để phân biệt giữa các khách hàng (nên dùng số điện thoại, CMT)";
            txtCustomerCode.Size = new Size(1049, 47);
            txtCustomerCode.TabIndex = 4;
            // 
            // btnOk1
            // 
            btnOk1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk1.AutoSize = true;
            btnOk1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btnOk1.ForeColor = Color.Black;
            btnOk1.Location = new Point(1191, 790);
            btnOk1.Name = "btnOk1";
            btnOk1.Size = new Size(129, 42);
            btnOk1.TabIndex = 8;
            btnOk1.Text = "Xác nhận";
            // 
            // btnSearch
            // 
            btnSearch.AutoSize = true;
            btnSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnSearch.Location = new Point(1285, 48);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(91, 30);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "lblSearch1";
            // 
            // frmCustomerRegister
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1391, 861);
            Controls.Add(btnSearch);
            Controls.Add(btnOk1);
            Controls.Add(cbVehicleTypes);
            Controls.Add(txtIdentity);
            Controls.Add(lblIdentity);
            Controls.Add(dtpExpireTime);
            Controls.Add(cbCustomerGroup);
            Controls.Add(txtPlate);
            Controls.Add(txtCustomerCode);
            Controls.Add(txtCustomerName);
            Controls.Add(lblExpireTime);
            Controls.Add(lblVehicleGroup);
            Controls.Add(lblPlateNumber);
            Controls.Add(lblCustomerCode);
            Controls.Add(lblCustomerGroup);
            Controls.Add(lblCustomerName);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmCustomerRegister";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng ký khách hàng";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCustomerName;
        private TextBox txtCustomerName;
        private TextBox txtPlate;
        private Label lblCustomerGroup;
        private Label lblPlateNumber;
        private ComboBox cbCustomerGroup;
        private Label lblVehicleGroup;
        private DateTimePicker dtpExpireTime;
        private Label lblExpireTime;
        private Label lblIdentity;
        private TextBox txtIdentity;
        private ComboBox cbVehicleTypes;
        private Label lblCustomerCode;
        private TextBox txtCustomerCode;
        private BtnOk btnOk1;
        private BtnSearch btnSearch;
    }
}