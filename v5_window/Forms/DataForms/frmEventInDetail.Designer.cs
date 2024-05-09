namespace iParkingv5_window.Forms.DataForms
{
    partial class frmEventInDetail
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
<<<<<<< HEAD
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblVehilceType = new System.Windows.Forms.Label();
            this.lblIdentityGroup = new System.Windows.Forms.Label();
            this.lblTimeIn = new System.Windows.Forms.Label();
            this.lblIdentityCode = new System.Windows.Forms.Label();
            this.lblLaneName = new System.Windows.Forms.Label();
            this.lblIdentityName = new System.Windows.Forms.Label();
            this.lblVehilceTypeTitle = new System.Windows.Forms.Label();
            this.lblPlateNumberTitle = new System.Windows.Forms.Label();
            this.lblIdentityGroupTitle = new System.Windows.Forms.Label();
            this.lblTimeInTitle = new System.Windows.Forms.Label();
            this.lblIdentityCodeTitle = new System.Windows.Forms.Label();
            this.lblLaneNameTitle = new System.Windows.Forms.Label();
            this.lblIdentityNameTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.picOverviewImageIn = new iPakrkingv5.Controls.Usercontrols.MovablePictureBox();
            this.picVehicleImageIn = new iPakrkingv5.Controls.Usercontrols.MovablePictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPlate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.lblExpireTime = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdatePlate = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOverviewImageIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVehicleImageIn)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(10, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(345, 45);
            this.lblTitle.TabIndex = 20;
            this.lblTitle.Text = "Thông tin sự kiện vào";
            // 
            // lblVehilceType
            // 
            this.lblVehilceType.BackColor = System.Drawing.Color.Transparent;
            this.lblVehilceType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVehilceType.Location = new System.Drawing.Point(160, 72);
            this.lblVehilceType.Name = "lblVehilceType";
            this.lblVehilceType.Size = new System.Drawing.Size(278, 24);
            this.lblVehilceType.TabIndex = 17;
            this.lblVehilceType.Text = "_";
            this.lblVehilceType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIdentityGroup
            // 
            this.lblIdentityGroup.BackColor = System.Drawing.Color.Transparent;
            this.lblIdentityGroup.Location = new System.Drawing.Point(160, 144);
            this.lblIdentityGroup.Name = "lblIdentityGroup";
            this.lblIdentityGroup.Size = new System.Drawing.Size(228, 24);
            this.lblIdentityGroup.TabIndex = 19;
            this.lblIdentityGroup.Text = "_";
            this.lblIdentityGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTimeIn
            // 
            this.lblTimeIn.BackColor = System.Drawing.Color.Transparent;
            this.lblTimeIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTimeIn.Location = new System.Drawing.Point(160, 24);
            this.lblTimeIn.Name = "lblTimeIn";
            this.lblTimeIn.Size = new System.Drawing.Size(278, 24);
            this.lblTimeIn.TabIndex = 15;
            this.lblTimeIn.Text = "_";
            this.lblTimeIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIdentityCode
            // 
            this.lblIdentityCode.BackColor = System.Drawing.Color.Transparent;
            this.lblIdentityCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIdentityCode.Location = new System.Drawing.Point(160, 120);
            this.lblIdentityCode.Name = "lblIdentityCode";
            this.lblIdentityCode.Size = new System.Drawing.Size(278, 24);
            this.lblIdentityCode.TabIndex = 16;
            this.lblIdentityCode.Text = "_";
            this.lblIdentityCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLaneName
            // 
            this.lblLaneName.BackColor = System.Drawing.Color.Transparent;
            this.lblLaneName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLaneName.Location = new System.Drawing.Point(160, 0);
            this.lblLaneName.Name = "lblLaneName";
            this.lblLaneName.Size = new System.Drawing.Size(278, 24);
            this.lblLaneName.TabIndex = 13;
            this.lblLaneName.Text = "_";
            this.lblLaneName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIdentityName
            // 
            this.lblIdentityName.BackColor = System.Drawing.Color.Transparent;
            this.lblIdentityName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIdentityName.Location = new System.Drawing.Point(160, 96);
            this.lblIdentityName.Name = "lblIdentityName";
            this.lblIdentityName.Size = new System.Drawing.Size(278, 24);
            this.lblIdentityName.TabIndex = 14;
            this.lblIdentityName.Text = "_";
            this.lblIdentityName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVehilceTypeTitle
            // 
            this.lblVehilceTypeTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblVehilceTypeTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVehilceTypeTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblVehilceTypeTitle.Location = new System.Drawing.Point(3, 72);
            this.lblVehilceTypeTitle.Name = "lblVehilceTypeTitle";
            this.lblVehilceTypeTitle.Size = new System.Drawing.Size(151, 24);
            this.lblVehilceTypeTitle.TabIndex = 6;
            this.lblVehilceTypeTitle.Text = "Loại xe";
            this.lblVehilceTypeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPlateNumberTitle
            // 
            this.lblPlateNumberTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblPlateNumberTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPlateNumberTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblPlateNumberTitle.Location = new System.Drawing.Point(3, 48);
            this.lblPlateNumberTitle.Name = "lblPlateNumberTitle";
            this.lblPlateNumberTitle.Size = new System.Drawing.Size(151, 24);
            this.lblPlateNumberTitle.TabIndex = 7;
            this.lblPlateNumberTitle.Text = "Biến số xe";
            this.lblPlateNumberTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIdentityGroupTitle
            // 
            this.lblIdentityGroupTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblIdentityGroupTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIdentityGroupTitle.Location = new System.Drawing.Point(3, 144);
            this.lblIdentityGroupTitle.Name = "lblIdentityGroupTitle";
            this.lblIdentityGroupTitle.Size = new System.Drawing.Size(123, 24);
            this.lblIdentityGroupTitle.TabIndex = 8;
            this.lblIdentityGroupTitle.Text = "Nhóm định danh";
            this.lblIdentityGroupTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTimeInTitle
            // 
            this.lblTimeInTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTimeInTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTimeInTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTimeInTitle.Location = new System.Drawing.Point(3, 24);
            this.lblTimeInTitle.Name = "lblTimeInTitle";
            this.lblTimeInTitle.Size = new System.Drawing.Size(151, 24);
            this.lblTimeInTitle.TabIndex = 9;
            this.lblTimeInTitle.Text = "Giờ vào";
            this.lblTimeInTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIdentityCodeTitle
            // 
            this.lblIdentityCodeTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblIdentityCodeTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIdentityCodeTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIdentityCodeTitle.Location = new System.Drawing.Point(3, 120);
            this.lblIdentityCodeTitle.Name = "lblIdentityCodeTitle";
            this.lblIdentityCodeTitle.Size = new System.Drawing.Size(151, 24);
            this.lblIdentityCodeTitle.TabIndex = 10;
            this.lblIdentityCodeTitle.Text = "Mã định danh";
            this.lblIdentityCodeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLaneNameTitle
            // 
            this.lblLaneNameTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblLaneNameTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLaneNameTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblLaneNameTitle.Location = new System.Drawing.Point(3, 0);
            this.lblLaneNameTitle.Name = "lblLaneNameTitle";
            this.lblLaneNameTitle.Size = new System.Drawing.Size(151, 24);
            this.lblLaneNameTitle.TabIndex = 11;
            this.lblLaneNameTitle.Text = "Tên làn";
            this.lblLaneNameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIdentityNameTitle
            // 
            this.lblIdentityNameTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblIdentityNameTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIdentityNameTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIdentityNameTitle.Location = new System.Drawing.Point(3, 96);
            this.lblIdentityNameTitle.Name = "lblIdentityNameTitle";
            this.lblIdentityNameTitle.Size = new System.Drawing.Size(151, 24);
            this.lblIdentityNameTitle.TabIndex = 12;
            this.lblIdentityNameTitle.Text = "Tên định danh";
            this.lblIdentityNameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.picOverviewImageIn, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.picVehicleImageIn, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(469, 56);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(268, 248);
            this.tableLayoutPanel1.TabIndex = 23;
            // 
            // picOverviewImageIn
            // 
            this.picOverviewImageIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picOverviewImageIn.Location = new System.Drawing.Point(3, 2);
            this.picOverviewImageIn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picOverviewImageIn.Name = "picOverviewImageIn";
            this.picOverviewImageIn.Size = new System.Drawing.Size(262, 120);
            this.picOverviewImageIn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picOverviewImageIn.TabIndex = 0;
            this.picOverviewImageIn.TabStop = false;
            // 
            // picVehicleImageIn
            // 
            this.picVehicleImageIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picVehicleImageIn.Location = new System.Drawing.Point(3, 126);
            this.picVehicleImageIn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picVehicleImageIn.Name = "picVehicleImageIn";
            this.picVehicleImageIn.Size = new System.Drawing.Size(262, 120);
            this.picVehicleImageIn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picVehicleImageIn.TabIndex = 1;
            this.picVehicleImageIn.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.80902F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.19098F));
            this.tableLayoutPanel2.Controls.Add(this.lblLaneNameTitle, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblTimeInTitle, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblPlateNumberTitle, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblVehilceTypeTitle, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblIdentityGroup, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.lblVehilceType, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblIdentityNameTitle, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblIdentityName, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblIdentityCodeTitle, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.lblIdentityGroupTitle, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.lblTimeIn, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblLaneName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblIdentityCode, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.lblCustomer, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.lblPhoneNumber, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.lblExpireTime, 1, 9);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(10, 56);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 10;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(441, 248);
            this.tableLayoutPanel2.TabIndex = 24;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtPlate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(157, 48);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.panel1.Size = new System.Drawing.Size(284, 24);
            this.panel1.TabIndex = 20;
            // 
            // txtPlate
            // 
            this.txtPlate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPlate.Location = new System.Drawing.Point(0, 8);
            this.txtPlate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPlate.Name = "txtPlate";
            this.txtPlate.Size = new System.Drawing.Size(284, 23);
            this.txtPlate.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "Khách hàng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "Số điện thoại";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(3, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 32);
            this.label3.TabIndex = 8;
            this.label3.Text = "Hạn sử dụng";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCustomer
            // 
            this.lblCustomer.BackColor = System.Drawing.Color.Transparent;
            this.lblCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCustomer.Location = new System.Drawing.Point(160, 168);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(278, 24);
            this.lblCustomer.TabIndex = 19;
            this.lblCustomer.Text = "_";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblPhoneNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPhoneNumber.Location = new System.Drawing.Point(160, 192);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(278, 24);
            this.lblPhoneNumber.TabIndex = 19;
            this.lblPhoneNumber.Text = "_";
            this.lblPhoneNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblExpireTime
            // 
            this.lblExpireTime.BackColor = System.Drawing.Color.Transparent;
            this.lblExpireTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblExpireTime.Location = new System.Drawing.Point(160, 216);
            this.lblExpireTime.Name = "lblExpireTime";
            this.lblExpireTime.Size = new System.Drawing.Size(278, 32);
            this.lblExpireTime.TabIndex = 19;
            this.lblExpireTime.Text = "_";
            this.lblExpireTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(638, 324);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 30);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Đóng";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnUpdatePlate
            // 
            this.btnUpdatePlate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdatePlate.Location = new System.Drawing.Point(536, 324);
            this.btnUpdatePlate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdatePlate.Name = "btnUpdatePlate";
            this.btnUpdatePlate.Size = new System.Drawing.Size(96, 30);
            this.btnUpdatePlate.TabIndex = 25;
            this.btnUpdatePlate.Text = "Cập nhật";
            this.btnUpdatePlate.UseVisualStyleBackColor = true;
            // 
            // frmEventInDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 363);
            this.Controls.Add(this.btnUpdatePlate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmEventInDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin sự kiện vào";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picOverviewImageIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVehicleImageIn)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

=======
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEventInDetail));
            lblTitle = new Label();
            lblVehilceType = new Label();
            lblIdentityGroup = new Label();
            lblTimeIn = new Label();
            lblIdentityCode = new Label();
            lblLaneName = new Label();
            lblIdentityName = new Label();
            lblVehilceTypeTitle = new Label();
            lblPlateNumberTitle = new Label();
            lblIdentityGroupTitle = new Label();
            lblTimeInTitle = new Label();
            lblIdentityCodeTitle = new Label();
            lblLaneNameTitle = new Label();
            lblIdentityNameTitle = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            picOverviewImageIn = new iPakrkingv5.Controls.Usercontrols.MovablePictureBox();
            picVehicleImageIn = new iPakrkingv5.Controls.Usercontrols.MovablePictureBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel1 = new Panel();
            txtPlate = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lblCustomer = new Label();
            lblPhoneNumber = new Label();
            lblExpireTime = new Label();
            btnCancel = new Button();
            btnUpdatePlate = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picOverviewImageIn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picVehicleImageIn).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.Location = new Point(10, 7);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(345, 45);
            lblTitle.TabIndex = 20;
            lblTitle.Text = "Thông tin sự kiện vào";
            // 
            // lblVehilceType
            // 
            lblVehilceType.BackColor = Color.Transparent;
            lblVehilceType.Dock = DockStyle.Fill;
            lblVehilceType.Location = new Point(169, 123);
            lblVehilceType.Name = "lblVehilceType";
            lblVehilceType.Size = new Size(293, 41);
            lblVehilceType.TabIndex = 17;
            lblVehilceType.Text = "_";
            lblVehilceType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblIdentityGroup
            // 
            lblIdentityGroup.BackColor = Color.Transparent;
            lblIdentityGroup.Dock = DockStyle.Fill;
            lblIdentityGroup.Location = new Point(169, 246);
            lblIdentityGroup.Name = "lblIdentityGroup";
            lblIdentityGroup.Size = new Size(293, 41);
            lblIdentityGroup.TabIndex = 19;
            lblIdentityGroup.Text = "_";
            lblIdentityGroup.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTimeIn
            // 
            lblTimeIn.BackColor = Color.Transparent;
            lblTimeIn.Dock = DockStyle.Fill;
            lblTimeIn.Location = new Point(169, 41);
            lblTimeIn.Name = "lblTimeIn";
            lblTimeIn.Size = new Size(293, 41);
            lblTimeIn.TabIndex = 15;
            lblTimeIn.Text = "_";
            lblTimeIn.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblIdentityCode
            // 
            lblIdentityCode.BackColor = Color.Transparent;
            lblIdentityCode.Dock = DockStyle.Fill;
            lblIdentityCode.Location = new Point(169, 205);
            lblIdentityCode.Name = "lblIdentityCode";
            lblIdentityCode.Size = new Size(293, 41);
            lblIdentityCode.TabIndex = 16;
            lblIdentityCode.Text = "_";
            lblIdentityCode.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblLaneName
            // 
            lblLaneName.BackColor = Color.Transparent;
            lblLaneName.Dock = DockStyle.Fill;
            lblLaneName.Location = new Point(169, 0);
            lblLaneName.Name = "lblLaneName";
            lblLaneName.Size = new Size(293, 41);
            lblLaneName.TabIndex = 13;
            lblLaneName.Text = "_";
            lblLaneName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblIdentityName
            // 
            lblIdentityName.BackColor = Color.Transparent;
            lblIdentityName.Dock = DockStyle.Fill;
            lblIdentityName.Location = new Point(169, 164);
            lblIdentityName.Name = "lblIdentityName";
            lblIdentityName.Size = new Size(293, 41);
            lblIdentityName.TabIndex = 14;
            lblIdentityName.Text = "_";
            lblIdentityName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblVehilceTypeTitle
            // 
            lblVehilceTypeTitle.BackColor = Color.Transparent;
            lblVehilceTypeTitle.Dock = DockStyle.Fill;
            lblVehilceTypeTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblVehilceTypeTitle.Location = new Point(3, 123);
            lblVehilceTypeTitle.Name = "lblVehilceTypeTitle";
            lblVehilceTypeTitle.Size = new Size(160, 41);
            lblVehilceTypeTitle.TabIndex = 6;
            lblVehilceTypeTitle.Text = "Loại xe";
            lblVehilceTypeTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPlateNumberTitle
            // 
            lblPlateNumberTitle.BackColor = Color.Transparent;
            lblPlateNumberTitle.Dock = DockStyle.Fill;
            lblPlateNumberTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPlateNumberTitle.Location = new Point(3, 82);
            lblPlateNumberTitle.Name = "lblPlateNumberTitle";
            lblPlateNumberTitle.Size = new Size(160, 41);
            lblPlateNumberTitle.TabIndex = 7;
            lblPlateNumberTitle.Text = "Biến số xe";
            lblPlateNumberTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblIdentityGroupTitle
            // 
            lblIdentityGroupTitle.BackColor = Color.Transparent;
            lblIdentityGroupTitle.Dock = DockStyle.Fill;
            lblIdentityGroupTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblIdentityGroupTitle.Location = new Point(3, 246);
            lblIdentityGroupTitle.Name = "lblIdentityGroupTitle";
            lblIdentityGroupTitle.Size = new Size(160, 41);
            lblIdentityGroupTitle.TabIndex = 8;
            lblIdentityGroupTitle.Text = "Nhóm định danh";
            lblIdentityGroupTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTimeInTitle
            // 
            lblTimeInTitle.BackColor = Color.Transparent;
            lblTimeInTitle.Dock = DockStyle.Fill;
            lblTimeInTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTimeInTitle.Location = new Point(3, 41);
            lblTimeInTitle.Name = "lblTimeInTitle";
            lblTimeInTitle.Size = new Size(160, 41);
            lblTimeInTitle.TabIndex = 9;
            lblTimeInTitle.Text = "Giờ vào";
            lblTimeInTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblIdentityCodeTitle
            // 
            lblIdentityCodeTitle.BackColor = Color.Transparent;
            lblIdentityCodeTitle.Dock = DockStyle.Fill;
            lblIdentityCodeTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblIdentityCodeTitle.Location = new Point(3, 205);
            lblIdentityCodeTitle.Name = "lblIdentityCodeTitle";
            lblIdentityCodeTitle.Size = new Size(160, 41);
            lblIdentityCodeTitle.TabIndex = 10;
            lblIdentityCodeTitle.Text = "Mã định danh";
            lblIdentityCodeTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblLaneNameTitle
            // 
            lblLaneNameTitle.BackColor = Color.Transparent;
            lblLaneNameTitle.Dock = DockStyle.Fill;
            lblLaneNameTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblLaneNameTitle.Location = new Point(3, 0);
            lblLaneNameTitle.Name = "lblLaneNameTitle";
            lblLaneNameTitle.Size = new Size(160, 41);
            lblLaneNameTitle.TabIndex = 11;
            lblLaneNameTitle.Text = "Tên làn";
            lblLaneNameTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblIdentityNameTitle
            // 
            lblIdentityNameTitle.BackColor = Color.Transparent;
            lblIdentityNameTitle.Dock = DockStyle.Fill;
            lblIdentityNameTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblIdentityNameTitle.Location = new Point(3, 164);
            lblIdentityNameTitle.Name = "lblIdentityNameTitle";
            lblIdentityNameTitle.Size = new Size(160, 41);
            lblIdentityNameTitle.TabIndex = 12;
            lblIdentityNameTitle.Text = "Tên định danh";
            lblIdentityNameTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(picOverviewImageIn, 0, 0);
            tableLayoutPanel1.Controls.Add(picVehicleImageIn, 0, 1);
            tableLayoutPanel1.Location = new Point(490, 56);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(291, 412);
            tableLayoutPanel1.TabIndex = 23;
            // 
            // picOverviewImageIn
            // 
            picOverviewImageIn.Dock = DockStyle.Fill;
            picOverviewImageIn.Location = new Point(3, 2);
            picOverviewImageIn.Margin = new Padding(3, 2, 3, 2);
            picOverviewImageIn.Name = "picOverviewImageIn";
            picOverviewImageIn.Size = new Size(285, 202);
            picOverviewImageIn.SizeMode = PictureBoxSizeMode.Zoom;
            picOverviewImageIn.TabIndex = 0;
            picOverviewImageIn.TabStop = false;
            // 
            // picVehicleImageIn
            // 
            picVehicleImageIn.Dock = DockStyle.Fill;
            picVehicleImageIn.Location = new Point(3, 208);
            picVehicleImageIn.Margin = new Padding(3, 2, 3, 2);
            picVehicleImageIn.Name = "picVehicleImageIn";
            picVehicleImageIn.Size = new Size(285, 202);
            picVehicleImageIn.SizeMode = PictureBoxSizeMode.Zoom;
            picVehicleImageIn.TabIndex = 1;
            picVehicleImageIn.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.80902F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64.19098F));
            tableLayoutPanel2.Controls.Add(lblLaneNameTitle, 0, 0);
            tableLayoutPanel2.Controls.Add(lblTimeInTitle, 0, 1);
            tableLayoutPanel2.Controls.Add(lblPlateNumberTitle, 0, 2);
            tableLayoutPanel2.Controls.Add(lblVehilceTypeTitle, 0, 3);
            tableLayoutPanel2.Controls.Add(lblIdentityGroup, 1, 6);
            tableLayoutPanel2.Controls.Add(lblVehilceType, 1, 3);
            tableLayoutPanel2.Controls.Add(lblIdentityNameTitle, 0, 4);
            tableLayoutPanel2.Controls.Add(lblIdentityName, 1, 4);
            tableLayoutPanel2.Controls.Add(lblIdentityCodeTitle, 0, 5);
            tableLayoutPanel2.Controls.Add(lblIdentityGroupTitle, 0, 6);
            tableLayoutPanel2.Controls.Add(lblTimeIn, 1, 1);
            tableLayoutPanel2.Controls.Add(lblLaneName, 1, 0);
            tableLayoutPanel2.Controls.Add(lblIdentityCode, 1, 5);
            tableLayoutPanel2.Controls.Add(panel1, 1, 2);
            tableLayoutPanel2.Controls.Add(label1, 0, 7);
            tableLayoutPanel2.Controls.Add(label2, 0, 8);
            tableLayoutPanel2.Controls.Add(label3, 0, 9);
            tableLayoutPanel2.Controls.Add(lblCustomer, 1, 7);
            tableLayoutPanel2.Controls.Add(lblPhoneNumber, 1, 8);
            tableLayoutPanel2.Controls.Add(lblExpireTime, 1, 9);
            tableLayoutPanel2.Font = new Font("Segoe UI", 12F);
            tableLayoutPanel2.Location = new Point(10, 56);
            tableLayoutPanel2.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 10;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.Size = new Size(465, 412);
            tableLayoutPanel2.TabIndex = 24;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtPlate);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(166, 82);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(0, 8, 0, 0);
            panel1.Size = new Size(299, 41);
            panel1.TabIndex = 20;
            // 
            // txtPlate
            // 
            txtPlate.Dock = DockStyle.Fill;
            txtPlate.Location = new Point(0, 8);
            txtPlate.Margin = new Padding(3, 2, 3, 2);
            txtPlate.Name = "txtPlate";
            txtPlate.Size = new Size(299, 29);
            txtPlate.TabIndex = 0;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(3, 287);
            label1.Name = "label1";
            label1.Size = new Size(160, 41);
            label1.TabIndex = 8;
            label1.Text = "Khách hàng";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(3, 328);
            label2.Name = "label2";
            label2.Size = new Size(160, 41);
            label2.TabIndex = 8;
            label2.Text = "Số điện thoại";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(3, 369);
            label3.Name = "label3";
            label3.Size = new Size(160, 43);
            label3.TabIndex = 8;
            label3.Text = "Hạn sử dụng";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCustomer
            // 
            lblCustomer.BackColor = Color.Transparent;
            lblCustomer.Dock = DockStyle.Fill;
            lblCustomer.Location = new Point(169, 287);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(293, 41);
            lblCustomer.TabIndex = 19;
            lblCustomer.Text = "_";
            lblCustomer.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.BackColor = Color.Transparent;
            lblPhoneNumber.Dock = DockStyle.Fill;
            lblPhoneNumber.Location = new Point(169, 328);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(293, 41);
            lblPhoneNumber.TabIndex = 19;
            lblPhoneNumber.Text = "_";
            lblPhoneNumber.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblExpireTime
            // 
            lblExpireTime.BackColor = Color.Transparent;
            lblExpireTime.Dock = DockStyle.Fill;
            lblExpireTime.Location = new Point(169, 369);
            lblExpireTime.Name = "lblExpireTime";
            lblExpireTime.Size = new Size(293, 43);
            lblExpireTime.TabIndex = 19;
            lblExpireTime.Text = "_";
            lblExpireTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Font = new Font("Segoe UI", 12F);
            btnCancel.Location = new Point(682, 483);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(96, 30);
            btnCancel.TabIndex = 25;
            btnCancel.Text = "Đóng";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnUpdatePlate
            // 
            btnUpdatePlate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnUpdatePlate.Font = new Font("Segoe UI", 12F);
            btnUpdatePlate.Location = new Point(580, 483);
            btnUpdatePlate.Margin = new Padding(3, 2, 3, 2);
            btnUpdatePlate.Name = "btnUpdatePlate";
            btnUpdatePlate.Size = new Size(96, 30);
            btnUpdatePlate.TabIndex = 25;
            btnUpdatePlate.Text = "Cập nhật";
            btnUpdatePlate.UseVisualStyleBackColor = true;
            btnUpdatePlate.Click += btnUpdatePlate_Click;
            // 
            // frmEventInDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(789, 522);
            Controls.Add(btnUpdatePlate);
            Controls.Add(btnCancel);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(lblTitle);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmEventInDetail";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông tin sự kiện vào";
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picOverviewImageIn).EndInit();
            ((System.ComponentModel.ISupportInitialize)picVehicleImageIn).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
>>>>>>> XuanCuong
        }

        #endregion
        private Label lblTitle;
        private Label lblVehilceType;
        private Label lblIdentityGroup;
        private Label lblTimeIn;
        private Label lblIdentityCode;
        private Label lblLaneName;
        private Label lblIdentityName;
        private Label lblVehilceTypeTitle;
        private Label lblPlateNumberTitle;
        private Label lblIdentityGroupTitle;
        private Label lblTimeInTitle;
        private Label lblIdentityCodeTitle;
        private Label lblLaneNameTitle;
        private Label lblIdentityNameTitle;
        private TableLayoutPanel tableLayoutPanel1;
        private iPakrkingv5.Controls.Usercontrols.MovablePictureBox movablePictureBox1;
        private iPakrkingv5.Controls.Usercontrols.MovablePictureBox movablePictureBox2;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel1;
        private TextBox txtPlate;
        private Button btnCancel;
        private Button btnUpdatePlate;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblCustomer;
        private Label lblPhoneNumber;
        private Label lblExpireTime;
        private iPakrkingv5.Controls.Usercontrols.MovablePictureBox picOverviewImageIn;
        private iPakrkingv5.Controls.Usercontrols.MovablePictureBox picVehicleImageIn;
    }
}