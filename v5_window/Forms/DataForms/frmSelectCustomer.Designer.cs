namespace iParkingv5_window.Forms.DataForms
{
    partial class frmSelectCustomer
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
            dgvData = new DataGridView();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            txtCustomerCode = new TextBox();
            lblCardNumber = new Label();
            blTittle = new Label();
            btnCancel1 = new Controls.Buttons.LblCancel();
            panelData = new Panel();
            ucLoading1 = new Usercontrols.BuildControls.ucLoading();
            btnOk1 = new Controls.Buttons.LblOk();
            lblSearch = new Controls.Buttons.LblSearch();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            panelData.SuspendLayout();
            SuspendLayout();
            // 
            // dgvData
            // 
            dgvData.AllowUserToAddRows = false;
            dgvData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(192, 255, 255);
            dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvData.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Columns.AddRange(new DataGridViewColumn[] { Column2, Column3, Column8, Column5, Column6, Column4, Column7, Column1 });
            dgvData.Location = new Point(27, 95);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowHeadersVisible = false;
            dataGridViewCellStyle3.Padding = new Padding(3);
            dgvData.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvData.RowTemplate.Height = 29;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.Size = new Size(737, 280);
            dgvData.TabIndex = 11;
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
            txtCustomerCode.Location = new Point(144, 62);
            txtCustomerCode.Name = "txtCustomerCode";
            txtCustomerCode.Size = new Size(365, 27);
            txtCustomerCode.TabIndex = 1;
            // 
            // lblCardNumber
            // 
            lblCardNumber.AutoSize = true;
            lblCardNumber.BackColor = Color.Transparent;
            lblCardNumber.Location = new Point(27, 65);
            lblCardNumber.Name = "lblCardNumber";
            lblCardNumber.Size = new Size(111, 20);
            lblCardNumber.TabIndex = 0;
            lblCardNumber.Text = "Tên khách hàng";
            // 
            // blTittle
            // 
            blTittle.AutoSize = true;
            blTittle.BackColor = Color.Transparent;
            blTittle.Dock = DockStyle.Top;
            blTittle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            blTittle.ForeColor = Color.FromArgb(0, 64, 0);
            blTittle.Location = new Point(24, 24);
            blTittle.Name = "blTittle";
            blTittle.Size = new Size(244, 30);
            blTittle.TabIndex = 10;
            blTittle.Text = "Danh sách khách hàng";
            // 
            // btnCancel1
            // 
            btnCancel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel1.AutoSize = true;
            btnCancel1.BorderStyle = BorderStyle.Fixed3D;
            btnCancel1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnCancel1.ForeColor = Color.Black;
            btnCancel1.Location = new Point(715, 395);
            btnCancel1.Name = "btnCancel1";
            btnCancel1.Size = new Size(49, 22);
            btnCancel1.TabIndex = 7;
            btnCancel1.Text = "Đóng";
            // 
            // panelData
            // 
            panelData.BackColor = Color.Transparent;
            panelData.Controls.Add(ucLoading1);
            panelData.Controls.Add(btnOk1);
            panelData.Controls.Add(btnCancel1);
            panelData.Controls.Add(lblSearch);
            panelData.Controls.Add(lblCardNumber);
            panelData.Controls.Add(txtCustomerCode);
            panelData.Controls.Add(dgvData);
            panelData.Controls.Add(blTittle);
            panelData.Dock = DockStyle.Fill;
            panelData.Location = new Point(0, 0);
            panelData.Name = "panelData";
            panelData.Padding = new Padding(24);
            panelData.Size = new Size(800, 450);
            panelData.TabIndex = 14;
            // 
            // ucLoading1
            // 
            ucLoading1.BackColor = Color.FromArgb(255, 224, 192);
            ucLoading1.Language = IPaking.Ultility.TextManagement.EmLanguage.Vietnamese;
            ucLoading1.Location = new Point(131, 278);
            ucLoading1.Message = "Preparing to download";
            ucLoading1.Name = "ucLoading1";
            ucLoading1.Size = new Size(392, 188);
            ucLoading1.TabIndex = 17;
            // 
            // btnOk1
            // 
            btnOk1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk1.AutoSize = true;
            btnOk1.BackColor = Color.Gray;
            btnOk1.BorderStyle = BorderStyle.Fixed3D;
            btnOk1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnOk1.ForeColor = Color.Black;
            btnOk1.ImageAlign = ContentAlignment.MiddleLeft;
            btnOk1.Location = new Point(637, 395);
            btnOk1.Name = "btnOk1";
            btnOk1.Size = new Size(63, 22);
            btnOk1.TabIndex = 15;
            btnOk1.Text = "btnOk1";
            btnOk1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.BorderStyle = BorderStyle.Fixed3D;
            lblSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblSearch.Location = new Point(515, 62);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(83, 22);
            lblSearch.TabIndex = 16;
            lblSearch.Text = "lblSearch1";
            // 
            // frmSelectCustomer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelData);
            Name = "frmSelectCustomer";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chọn khách hàng";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            panelData.ResumeLayout(false);
            panelData.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvData;
        private TextBox txtCustomerCode;
        private Label lblCardNumber;
        private Label blTittle;
        private Controls.Buttons.LblCancel btnCancel1;
        private Panel panelData;
        private Controls.Buttons.LblOk btnOk1;
        private Controls.Buttons.LblSearch lblSearch;
        private Usercontrols.BuildControls.ucNotify ucNotify1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column1;
        private Usercontrols.BuildControls.ucLoading ucLoading1;
    }
}