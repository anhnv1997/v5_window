namespace iParkingv5_CustomerRegister
{
    partial class frmCustomerRegister
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblTitle = new Label();
            btnAdd = new Button();
            label5 = new Label();
            btnSearchCustomer = new Button();
            txtCustomerName = new TextBox();
            lblCustomerName = new Label();
            lblPlateNumber = new Label();
            txtPlateNumber = new TextBox();
            lblSubTitle = new Label();
            lblCustomerCode = new Label();
            txtCustomerCode = new TextBox();
            lblCustomerGroup = new Label();
            lblVehicleType = new Label();
            btnChooseCustomerGroup = new Button();
            btnChooseVehicleType = new Button();
            lblExpireTime = new Label();
            btnSearchPlateNumber = new Button();
            dtpExpireTime = new DateTimePicker();
            toolTip1 = new ToolTip(components);
            btnUpdate = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblTitle.Location = new Point(32, 32);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(438, 59);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Đăng ký khách hàng";
            // 
            // btnAdd
            // 
            btnAdd.Image = Properties.Resources.Checkmark_0_0_0_24px;
            btnAdd.Location = new Point(703, 493);
            btnAdd.Margin = new Padding(4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(181, 41);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Thêm mới";
            btnAdd.TextAlign = ContentAlignment.MiddleRight;
            btnAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label5.Location = new Point(473, 49);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(21, 32);
            label5.TabIndex = 4;
            label5.Text = " ";
            // 
            // btnSearchCustomer
            // 
            btnSearchCustomer.Image = Properties.Resources.search_0_0_0_24px;
            btnSearchCustomer.Location = new Point(824, 195);
            btnSearchCustomer.Margin = new Padding(4);
            btnSearchCustomer.Name = "btnSearchCustomer";
            btnSearchCustomer.Size = new Size(61, 36);
            btnSearchCustomer.TabIndex = 2;
            btnSearchCustomer.UseVisualStyleBackColor = true;
            // 
            // txtCustomerName
            // 
            txtCustomerName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCustomerName.Location = new Point(359, 195);
            txtCustomerName.Margin = new Padding(4);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(457, 36);
            txtCustomerName.TabIndex = 1;
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.BackColor = Color.Transparent;
            lblCustomerName.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblCustomerName.Location = new Point(53, 195);
            lblCustomerName.Margin = new Padding(4, 0, 4, 0);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(174, 30);
            lblCustomerName.TabIndex = 1;
            lblCustomerName.Text = "Tên khách hàng";
            // 
            // lblPlateNumber
            // 
            lblPlateNumber.AutoSize = true;
            lblPlateNumber.BackColor = Color.Transparent;
            lblPlateNumber.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblPlateNumber.Location = new Point(53, 345);
            lblPlateNumber.Margin = new Padding(4, 0, 4, 0);
            lblPlateNumber.Name = "lblPlateNumber";
            lblPlateNumber.Size = new Size(117, 30);
            lblPlateNumber.TabIndex = 1;
            lblPlateNumber.Text = "Biển số xe";
            // 
            // txtPlateNumber
            // 
            txtPlateNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPlateNumber.Location = new Point(359, 345);
            txtPlateNumber.Margin = new Padding(4);
            txtPlateNumber.Name = "txtPlateNumber";
            txtPlateNumber.Size = new Size(457, 36);
            txtPlateNumber.TabIndex = 5;
            // 
            // lblSubTitle
            // 
            lblSubTitle.AutoSize = true;
            lblSubTitle.BackColor = Color.Transparent;
            lblSubTitle.Font = new Font("Segoe UI", 24F);
            lblSubTitle.Location = new Point(32, 102);
            lblSubTitle.Margin = new Padding(4, 0, 4, 0);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(695, 45);
            lblSubTitle.TabIndex = 5;
            lblSubTitle.Text = "Tạo một khách hàng mới và thêm vào hệ thống";
            // 
            // lblCustomerCode
            // 
            lblCustomerCode.AutoSize = true;
            lblCustomerCode.BackColor = Color.Transparent;
            lblCustomerCode.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblCustomerCode.Location = new Point(53, 245);
            lblCustomerCode.Margin = new Padding(4, 0, 4, 0);
            lblCustomerCode.Name = "lblCustomerCode";
            lblCustomerCode.Size = new Size(171, 30);
            lblCustomerCode.TabIndex = 1;
            lblCustomerCode.Text = "Mã khách hàng";
            // 
            // txtCustomerCode
            // 
            txtCustomerCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCustomerCode.Location = new Point(359, 245);
            txtCustomerCode.Margin = new Padding(4);
            txtCustomerCode.Name = "txtCustomerCode";
            txtCustomerCode.Size = new Size(525, 36);
            txtCustomerCode.TabIndex = 3;
            // 
            // lblCustomerGroup
            // 
            lblCustomerGroup.AutoSize = true;
            lblCustomerGroup.BackColor = Color.Transparent;
            lblCustomerGroup.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblCustomerGroup.Location = new Point(53, 296);
            lblCustomerGroup.Margin = new Padding(4, 0, 4, 0);
            lblCustomerGroup.Name = "lblCustomerGroup";
            lblCustomerGroup.Size = new Size(201, 30);
            lblCustomerGroup.TabIndex = 1;
            lblCustomerGroup.Text = "Nhóm khách hàng";
            // 
            // lblVehicleType
            // 
            lblVehicleType.AutoSize = true;
            lblVehicleType.BackColor = Color.Transparent;
            lblVehicleType.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblVehicleType.Location = new Point(53, 400);
            lblVehicleType.Margin = new Padding(4, 0, 4, 0);
            lblVehicleType.Name = "lblVehicleType";
            lblVehicleType.Size = new Size(190, 30);
            lblVehicleType.TabIndex = 1;
            lblVehicleType.Text = "Loại phương tiện";
            // 
            // btnChooseCustomerGroup
            // 
            btnChooseCustomerGroup.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnChooseCustomerGroup.Location = new Point(359, 295);
            btnChooseCustomerGroup.Margin = new Padding(4);
            btnChooseCustomerGroup.Name = "btnChooseCustomerGroup";
            btnChooseCustomerGroup.Size = new Size(526, 41);
            btnChooseCustomerGroup.TabIndex = 4;
            btnChooseCustomerGroup.Text = "_Chọn_";
            btnChooseCustomerGroup.UseVisualStyleBackColor = true;
            // 
            // btnChooseVehicleType
            // 
            btnChooseVehicleType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnChooseVehicleType.Location = new Point(359, 400);
            btnChooseVehicleType.Margin = new Padding(4);
            btnChooseVehicleType.Name = "btnChooseVehicleType";
            btnChooseVehicleType.Size = new Size(526, 41);
            btnChooseVehicleType.TabIndex = 7;
            btnChooseVehicleType.Text = "_Chọn_";
            btnChooseVehicleType.UseVisualStyleBackColor = true;
            // 
            // lblExpireTime
            // 
            lblExpireTime.AutoSize = true;
            lblExpireTime.BackColor = Color.Transparent;
            lblExpireTime.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblExpireTime.Location = new Point(53, 450);
            lblExpireTime.Margin = new Padding(4, 0, 4, 0);
            lblExpireTime.Name = "lblExpireTime";
            lblExpireTime.Size = new Size(152, 30);
            lblExpireTime.TabIndex = 1;
            lblExpireTime.Text = "Ngày hết hạn";
            // 
            // btnSearchPlateNumber
            // 
            btnSearchPlateNumber.Image = Properties.Resources.search_0_0_0_24px;
            btnSearchPlateNumber.Location = new Point(824, 345);
            btnSearchPlateNumber.Margin = new Padding(4);
            btnSearchPlateNumber.Name = "btnSearchPlateNumber";
            btnSearchPlateNumber.Size = new Size(61, 36);
            btnSearchPlateNumber.TabIndex = 6;
            btnSearchPlateNumber.UseVisualStyleBackColor = true;
            // 
            // dtpExpireTime
            // 
            dtpExpireTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpExpireTime.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtpExpireTime.Format = DateTimePickerFormat.Custom;
            dtpExpireTime.Location = new Point(359, 450);
            dtpExpireTime.Name = "dtpExpireTime";
            dtpExpireTime.Size = new Size(526, 36);
            dtpExpireTime.TabIndex = 8;
            // 
            // toolTip1
            // 
            toolTip1.IsBalloon = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Image = Properties.Resources.edit_0_0_0_24px;
            btnUpdate.Location = new Point(514, 493);
            btnUpdate.Margin = new Padding(4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(181, 41);
            btnUpdate.TabIndex = 0;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.TextAlign = ContentAlignment.MiddleRight;
            btnUpdate.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // frmCustomerRegister
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1021, 729);
            Controls.Add(dtpExpireTime);
            Controls.Add(btnChooseVehicleType);
            Controls.Add(btnChooseCustomerGroup);
            Controls.Add(lblSubTitle);
            Controls.Add(label5);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(btnSearchPlateNumber);
            Controls.Add(btnSearchCustomer);
            Controls.Add(lblExpireTime);
            Controls.Add(lblTitle);
            Controls.Add(lblVehicleType);
            Controls.Add(txtCustomerCode);
            Controls.Add(lblCustomerGroup);
            Controls.Add(txtCustomerName);
            Controls.Add(lblCustomerCode);
            Controls.Add(txtPlateNumber);
            Controls.Add(lblCustomerName);
            Controls.Add(lblPlateNumber);
            Font = new Font("Segoe UI", 16F);
            Margin = new Padding(4);
            Name = "frmCustomerRegister";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnAdd;
        private Label label5;
        private Button btnSearchCustomer;
        private TextBox txtCustomerName;
        private Label lblCustomerName;
        private Label lblPlateNumber;
        private TextBox txtPlateNumber;
        private Label lblSubTitle;
        private Label lblCustomerCode;
        private TextBox txtCustomerCode;
        private Label lblCustomerGroup;
        private Label lblVehicleType;
        private Button btnChooseCustomerGroup;
        private Button btnChooseVehicleType;
        private Label lblExpireTime;
        private Button btnSearchPlateNumber;
        private DateTimePicker dtpExpireTime;
        private ToolTip toolTip1;
        private Button btnUpdate;
    }
}
