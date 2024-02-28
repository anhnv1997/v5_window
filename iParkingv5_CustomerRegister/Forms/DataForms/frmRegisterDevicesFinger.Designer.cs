namespace iParkingv5_CustomerRegister.Forms.SystemForms
{
    partial class frmRegisterDevicesFinger
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegisterDevicesFinger));
            chlbDevices = new CheckedListBox();
            lblCustomerListTitle = new Label();
            lblDeviceListTitle = new Label();
            dgvCustomerData = new DataGridView();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            txtCustomerCode = new TextBox();
            chbSelectAllDevice = new CheckBox();
            lblSearch1 = new iPakrkingv5.Controls.Controls.Buttons.LblSearch();
            lblOk1 = new iPakrkingv5.Controls.Controls.Buttons.LblOk();
            ((System.ComponentModel.ISupportInitialize)dgvCustomerData).BeginInit();
            SuspendLayout();
            // 
            // chlbDevices
            // 
            chlbDevices.FormattingEnabled = true;
            chlbDevices.Location = new Point(12, 89);
            chlbDevices.Name = "chlbDevices";
            chlbDevices.Size = new Size(439, 356);
            chlbDevices.TabIndex = 0;
            // 
            // lblCustomerListTitle
            // 
            lblCustomerListTitle.AutoSize = true;
            lblCustomerListTitle.BackColor = Color.Transparent;
            lblCustomerListTitle.Location = new Point(457, 19);
            lblCustomerListTitle.Name = "lblCustomerListTitle";
            lblCustomerListTitle.Size = new Size(156, 20);
            lblCustomerListTitle.TabIndex = 2;
            lblCustomerListTitle.Text = "Danh sách khách hàng";
            // 
            // lblDeviceListTitle
            // 
            lblDeviceListTitle.AutoSize = true;
            lblDeviceListTitle.BackColor = Color.Transparent;
            lblDeviceListTitle.Location = new Point(12, 19);
            lblDeviceListTitle.Name = "lblDeviceListTitle";
            lblDeviceListTitle.Size = new Size(128, 20);
            lblDeviceListTitle.TabIndex = 2;
            lblDeviceListTitle.Text = "Danh sách thiết bị";
            // 
            // dgvCustomerData
            // 
            dgvCustomerData.AllowUserToAddRows = false;
            dgvCustomerData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(192, 255, 255);
            dgvCustomerData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvCustomerData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCustomerData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCustomerData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCustomerData.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvCustomerData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCustomerData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomerData.Columns.AddRange(new DataGridViewColumn[] { Column2, Column3, Column8, Column5, Column6, Column4, Column7, Column1 });
            dgvCustomerData.Location = new Point(457, 89);
            dgvCustomerData.Name = "dgvCustomerData";
            dgvCustomerData.ReadOnly = true;
            dgvCustomerData.RowHeadersVisible = false;
            dataGridViewCellStyle3.Padding = new Padding(3);
            dgvCustomerData.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvCustomerData.RowTemplate.Height = 29;
            dgvCustomerData.ScrollBars = ScrollBars.Vertical;
            dgvCustomerData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomerData.Size = new Size(599, 356);
            dgvCustomerData.TabIndex = 12;
            // 
            // Column2
            // 
            Column2.HeaderText = "STT";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 76;
            // 
            // Column3
            // 
            Column3.HeaderText = "Tên";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 74;
            // 
            // Column8
            // 
            Column8.HeaderText = "Mã";
            Column8.Name = "Column8";
            Column8.ReadOnly = true;
            Column8.Width = 71;
            // 
            // Column5
            // 
            Column5.HeaderText = "Nhóm khách hàng";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.Width = 205;
            // 
            // Column6
            // 
            Column6.HeaderText = "Số điện thoại";
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            Column6.Width = 160;
            // 
            // Column4
            // 
            Column4.HeaderText = "Địa chỉ";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Width = 102;
            // 
            // Column7
            // 
            Column7.HeaderText = "CustomerGroupId";
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            Column7.Visible = false;
            Column7.Width = 205;
            // 
            // Column1
            // 
            Column1.HeaderText = "ID";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Visible = false;
            Column1.Width = 63;
            // 
            // txtCustomerCode
            // 
            txtCustomerCode.Location = new Point(457, 56);
            txtCustomerCode.Name = "txtCustomerCode";
            txtCustomerCode.PlaceholderText = "Tên khách hàng";
            txtCustomerCode.Size = new Size(290, 27);
            txtCustomerCode.TabIndex = 1;
            // 
            // chbSelectAllDevice
            // 
            chbSelectAllDevice.AutoSize = true;
            chbSelectAllDevice.BackColor = Color.Transparent;
            chbSelectAllDevice.Location = new Point(12, 59);
            chbSelectAllDevice.Name = "chbSelectAllDevice";
            chbSelectAllDevice.Size = new Size(103, 24);
            chbSelectAllDevice.TabIndex = 15;
            chbSelectAllDevice.Text = "Chọn tất cả";
            chbSelectAllDevice.UseVisualStyleBackColor = false;
            // 
            // lblSearch1
            // 
            lblSearch1.AutoSize = true;
            //lblSearch1.BorderStyle = BorderStyle.Fixed3D;
            lblSearch1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblSearch1.Location = new Point(904, 37);
            lblSearch1.Name = "lblSearch1";
            lblSearch1.Size = new Size(83, 22);
            lblSearch1.TabIndex = 16;
            lblSearch1.Text = "lblSearch1";
            // 
            // lblOk1
            // 
            lblOk1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblOk1.AutoSize = true;
            //lblOk1.BorderStyle = BorderStyle.Fixed3D;
            lblOk1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblOk1.Location = new Point(1000, 482);
            lblOk1.Name = "lblOk1";
            lblOk1.Size = new Size(56, 22);
            lblOk1.TabIndex = 17;
            lblOk1.Text = "lblOk1";
            // 
            // frmDevices
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1068, 513);
            Controls.Add(lblOk1);
            Controls.Add(lblSearch1);
            Controls.Add(chbSelectAllDevice);
            Controls.Add(dgvCustomerData);
            Controls.Add(lblDeviceListTitle);
            Controls.Add(lblCustomerListTitle);
            Controls.Add(txtCustomerCode);
            Controls.Add(chlbDevices);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmDevices";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nạp vân tay xuống thiết bị";
            ((System.ComponentModel.ISupportInitialize)dgvCustomerData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox chlbDevices;
        private Label lblCustomerListTitle;
        private Label lblDeviceListTitle;
        private DataGridView dgvCustomerData;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column1;
        private TextBox txtCustomerCode;
        private CheckBox chbSelectAllDevice;
        private iPakrkingv5.Controls.Controls.Buttons.LblSearch lblSearch1;
        private iPakrkingv5.Controls.Controls.Buttons.LblOk lblOk1;
    }
}