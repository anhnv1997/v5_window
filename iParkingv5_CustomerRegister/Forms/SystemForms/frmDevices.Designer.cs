namespace iParkingv5_CustomerRegister.Forms.SystemForms
{
    partial class frmDevices
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
            chlbDevices = new CheckedListBox();
            label1 = new Label();
            label2 = new Label();
            dgvCustomerData = new DataGridView();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            btnRegister = new Button();
            txtCustomerCode = new TextBox();
            btnSearchCustomer = new Button();
            chbSelectAllDevice = new CheckBox();
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(457, 19);
            label1.Name = "label1";
            label1.Size = new Size(156, 20);
            label1.TabIndex = 2;
            label1.Text = "Danh sách khách hàng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 19);
            label2.Name = "label2";
            label2.Size = new Size(128, 20);
            label2.TabIndex = 2;
            label2.Text = "Danh sách thiết bị";
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
            // btnRegister
            // 
            btnRegister.Location = new Point(857, 451);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(199, 50);
            btnRegister.TabIndex = 13;
            btnRegister.Text = "Đăng ký";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // txtCustomerCode
            // 
            txtCustomerCode.Location = new Point(457, 56);
            txtCustomerCode.Name = "txtCustomerCode";
            txtCustomerCode.PlaceholderText = "Tên khách hàng";
            txtCustomerCode.Size = new Size(290, 27);
            txtCustomerCode.TabIndex = 1;
            // 
            // btnSearchCustomer
            // 
            btnSearchCustomer.Location = new Point(753, 56);
            btnSearchCustomer.Name = "btnSearchCustomer";
            btnSearchCustomer.Size = new Size(145, 27);
            btnSearchCustomer.TabIndex = 14;
            btnSearchCustomer.Text = "Tìm kiếm";
            btnSearchCustomer.UseVisualStyleBackColor = true;
            btnSearchCustomer.Click += BtnSearch_Click;
            // 
            // chbSelectAllDevice
            // 
            chbSelectAllDevice.AutoSize = true;
            chbSelectAllDevice.Location = new Point(12, 59);
            chbSelectAllDevice.Name = "chbSelectAllDevice";
            chbSelectAllDevice.Size = new Size(103, 24);
            chbSelectAllDevice.TabIndex = 15;
            chbSelectAllDevice.Text = "Chọn tất cả";
            chbSelectAllDevice.UseVisualStyleBackColor = true;
            // 
            // frmDevices
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1068, 513);
            Controls.Add(chbSelectAllDevice);
            Controls.Add(btnSearchCustomer);
            Controls.Add(btnRegister);
            Controls.Add(dgvCustomerData);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtCustomerCode);
            Controls.Add(chlbDevices);
            Name = "frmDevices";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nạp vân tay xuống thiết bị";
            ((System.ComponentModel.ISupportInitialize)dgvCustomerData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox chlbDevices;
        private Label label1;
        private Label label2;
        private DataGridView dgvCustomerData;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column1;
        private Button btnRegister;
        private TextBox txtCustomerCode;
        private Button btnSearchCustomer;
        private CheckBox chbSelectAllDevice;
    }
}