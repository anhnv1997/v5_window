namespace iParkingv5_CustomerRegister.Forms.DataForms
{
    partial class frmRegisterVehicle
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegisterVehicle));
            dtpExpireTime = new DateTimePicker();
            btnChooseVehicleType = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            btnSearchPlateNumber = new Button();
            lblExpireTime = new Label();
            lblVehicleType = new Label();
            txtPlateNumber = new TextBox();
            lblPlateNumber = new Label();
            lblSubTitle = new Label();
            label5 = new Label();
            lblTitle = new Label();
            toolTip1 = new ToolTip(components);
            btnSearchCustomer = new Button();
            txtCustomerName = new TextBox();
            lblCustomerName = new Label();
            lblIdentity = new Label();
            btnChooseIdentity = new Button();
            SuspendLayout();
            // 
            // dtpExpireTime
            // 
            dtpExpireTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpExpireTime.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtpExpireTime.Format = DateTimePickerFormat.Custom;
            dtpExpireTime.Location = new Point(255, 357);
            dtpExpireTime.Margin = new Padding(4);
            dtpExpireTime.Name = "dtpExpireTime";
            dtpExpireTime.Size = new Size(577, 36);
            dtpExpireTime.TabIndex = 7;
            // 
            // btnChooseVehicleType
            // 
            btnChooseVehicleType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnChooseVehicleType.Location = new Point(255, 253);
            btnChooseVehicleType.Margin = new Padding(6);
            btnChooseVehicleType.Name = "btnChooseVehicleType";
            btnChooseVehicleType.Size = new Size(577, 41);
            btnChooseVehicleType.TabIndex = 5;
            btnChooseVehicleType.Text = "_Chọn_";
            btnChooseVehicleType.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Image = Properties.Resources.edit_0_0_0_24px;
            btnUpdate.Location = new Point(380, 411);
            btnUpdate.Margin = new Padding(6);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(181, 41);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.TextAlign = ContentAlignment.MiddleRight;
            btnUpdate.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Image = Properties.Resources.Checkmark_0_0_0_24px;
            btnAdd.Location = new Point(573, 411);
            btnAdd.Margin = new Padding(6);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(181, 41);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Thêm mới";
            btnAdd.TextAlign = ContentAlignment.MiddleRight;
            btnAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnSearchPlateNumber
            // 
            btnSearchPlateNumber.Image = Properties.Resources.search_0_0_0_24px;
            btnSearchPlateNumber.Location = new Point(771, 151);
            btnSearchPlateNumber.Margin = new Padding(6);
            btnSearchPlateNumber.Name = "btnSearchPlateNumber";
            btnSearchPlateNumber.Size = new Size(61, 36);
            btnSearchPlateNumber.TabIndex = 2;
            btnSearchPlateNumber.UseVisualStyleBackColor = true;
            // 
            // lblExpireTime
            // 
            lblExpireTime.AutoSize = true;
            lblExpireTime.BackColor = Color.Transparent;
            lblExpireTime.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblExpireTime.Location = new Point(33, 362);
            lblExpireTime.Margin = new Padding(6, 0, 6, 0);
            lblExpireTime.Name = "lblExpireTime";
            lblExpireTime.Size = new Size(152, 30);
            lblExpireTime.TabIndex = 9;
            lblExpireTime.Text = "Ngày hết hạn";
            // 
            // lblVehicleType
            // 
            lblVehicleType.AutoSize = true;
            lblVehicleType.BackColor = Color.Transparent;
            lblVehicleType.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblVehicleType.Location = new Point(33, 258);
            lblVehicleType.Margin = new Padding(6, 0, 6, 0);
            lblVehicleType.Name = "lblVehicleType";
            lblVehicleType.Size = new Size(190, 30);
            lblVehicleType.TabIndex = 10;
            lblVehicleType.Text = "Loại phương tiện";
            // 
            // txtPlateNumber
            // 
            txtPlateNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPlateNumber.Font = new Font("Segoe UI", 16F);
            txtPlateNumber.Location = new Point(255, 154);
            txtPlateNumber.Margin = new Padding(6);
            txtPlateNumber.Name = "txtPlateNumber";
            txtPlateNumber.Size = new Size(504, 36);
            txtPlateNumber.TabIndex = 1;
            // 
            // lblPlateNumber
            // 
            lblPlateNumber.AutoSize = true;
            lblPlateNumber.BackColor = Color.Transparent;
            lblPlateNumber.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblPlateNumber.Location = new Point(34, 157);
            lblPlateNumber.Margin = new Padding(6, 0, 6, 0);
            lblPlateNumber.Name = "lblPlateNumber";
            lblPlateNumber.Size = new Size(189, 30);
            lblPlateNumber.TabIndex = 11;
            lblPlateNumber.Text = "Biển số xe            ";
            // 
            // lblSubTitle
            // 
            lblSubTitle.AutoSize = true;
            lblSubTitle.BackColor = Color.Transparent;
            lblSubTitle.Font = new Font("Segoe UI", 24F);
            lblSubTitle.Location = new Point(28, 88);
            lblSubTitle.Margin = new Padding(6, 0, 6, 0);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(707, 45);
            lblSubTitle.TabIndex = 20;
            lblSubTitle.Text = "Tạo một phương tiện mới và thêm vào hệ thống";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label5.Location = new Point(568, 500);
            label5.Margin = new Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new Size(21, 32);
            label5.TabIndex = 19;
            label5.Text = " ";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 14);
            lblTitle.Margin = new Padding(6, 0, 6, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(456, 59);
            lblTitle.TabIndex = 18;
            lblTitle.Text = "Đăng ký phương tiện";
            // 
            // btnSearchCustomer
            // 
            btnSearchCustomer.Image = Properties.Resources.search_0_0_0_24px;
            btnSearchCustomer.Location = new Point(771, 208);
            btnSearchCustomer.Margin = new Padding(6);
            btnSearchCustomer.Name = "btnSearchCustomer";
            btnSearchCustomer.Size = new Size(61, 36);
            btnSearchCustomer.TabIndex = 4;
            btnSearchCustomer.UseVisualStyleBackColor = true;
            // 
            // txtCustomerName
            // 
            txtCustomerName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCustomerName.Font = new Font("Segoe UI", 16F);
            txtCustomerName.Location = new Point(255, 205);
            txtCustomerName.Margin = new Padding(6);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(504, 36);
            txtCustomerName.TabIndex = 3;
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.BackColor = Color.Transparent;
            lblCustomerName.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblCustomerName.Location = new Point(28, 205);
            lblCustomerName.Margin = new Padding(6, 0, 6, 0);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(134, 30);
            lblCustomerName.TabIndex = 23;
            lblCustomerName.Text = "Khách hàng";
            // 
            // lblIdentity
            // 
            lblIdentity.AutoSize = true;
            lblIdentity.BackColor = Color.Transparent;
            lblIdentity.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblIdentity.Location = new Point(33, 311);
            lblIdentity.Margin = new Padding(6, 0, 6, 0);
            lblIdentity.Name = "lblIdentity";
            lblIdentity.Size = new Size(119, 30);
            lblIdentity.TabIndex = 10;
            lblIdentity.Text = "Định danh";
            // 
            // btnChooseIdentity
            // 
            btnChooseIdentity.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnChooseIdentity.Location = new Point(255, 306);
            btnChooseIdentity.Margin = new Padding(6);
            btnChooseIdentity.Name = "btnChooseIdentity";
            btnChooseIdentity.Size = new Size(577, 41);
            btnChooseIdentity.TabIndex = 6;
            btnChooseIdentity.Text = "_Chọn_";
            btnChooseIdentity.UseVisualStyleBackColor = true;
            // 
            // frmRegisterVehicle
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(917, 539);
            Controls.Add(btnSearchCustomer);
            Controls.Add(txtCustomerName);
            Controls.Add(lblCustomerName);
            Controls.Add(lblSubTitle);
            Controls.Add(label5);
            Controls.Add(lblTitle);
            Controls.Add(dtpExpireTime);
            Controls.Add(btnChooseIdentity);
            Controls.Add(btnChooseVehicleType);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(btnSearchPlateNumber);
            Controls.Add(lblIdentity);
            Controls.Add(lblExpireTime);
            Controls.Add(lblVehicleType);
            Controls.Add(txtPlateNumber);
            Controls.Add(lblPlateNumber);
            Font = new Font("Segoe UI", 16F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "frmRegisterVehicle";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng ký phương tiện";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpExpireTime;
        private Button btnChooseVehicleType;
        private Button btnUpdate;
        private Button btnAdd;
        private Button btnSearchPlateNumber;
        private Label lblExpireTime;
        private Label lblVehicleType;
        private TextBox txtPlateNumber;
        private Label lblPlateNumber;
        private Label lblSubTitle;
        private Label label5;
        private Label lblTitle;
        private ToolTip toolTip1;
        private Button btnSearchCustomer;
        private TextBox txtCustomerName;
        private Label lblCustomerName;
        private Label lblIdentity;
        private Button btnChooseIdentity;
    }
}