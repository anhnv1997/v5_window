namespace iParkingv5_CustomerRegister.Forms
{
    partial class frmSelectVehicleType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectVehicleType));
            ucLoading1 = new iPakrkingv5.Controls.Usercontrols.BuildControls.ucLoading();
            lblTitle = new Label();
            btnCancel1 = new iPakrkingv5.Controls.Controls.Buttons.LblCancel();
            btnOk1 = new iPakrkingv5.Controls.Controls.Buttons.LblOk();
            lblSearch = new iPakrkingv5.Controls.Controls.Buttons.LblSearch();
            ucNotify1 = new iPakrkingv5.Controls.Usercontrols.BuildControls.ucNotify();
            lblKeyword = new Label();
            txtKeyword = new TextBox();
            dgvData = new DataGridView();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Id = new DataGridViewTextBoxColumn();
            panelData = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            panelData.SuspendLayout();
            SuspendLayout();
            // 
            // ucLoading1
            // 
            ucLoading1.BackColor = Color.FromArgb(255, 224, 192);
            ucLoading1.Language = IPaking.Ultility.TextManagement.EmLanguage.Vietnamese;
            ucLoading1.Location = new Point(27, 193);
            ucLoading1.Message = "Preparing to download";
            ucLoading1.Name = "ucLoading1";
            ucLoading1.Size = new Size(392, 203);
            ucLoading1.TabIndex = 28;
            ucLoading1.Visible = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.Location = new Point(83, 35);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(431, 45);
            lblTitle.TabIndex = 26;
            lblTitle.Text = "Danh sách loại phương tiện";
            // 
            // btnCancel1
            // 
            btnCancel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel1.AutoSize = true;
            btnCancel1.Location = new Point(591, 388);
            btnCancel1.Name = "btnCancel1";
            btnCancel1.Size = new Size(88, 30);
            btnCancel1.TabIndex = 4;
            // 
            // btnOk1
            // 
            btnOk1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk1.AutoSize = true;
            btnOk1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnOk1.Location = new Point(497, 380);
            btnOk1.Name = "btnOk1";
            btnOk1.Size = new Size(64, 30);
            btnOk1.TabIndex = 3;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblSearch.Location = new Point(560, 98);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(91, 30);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "lblSearch1";
            // 
            // ucNotify1
            // 
            ucNotify1.BackColor = Color.FromArgb(255, 224, 192);
            ucNotify1.Location = new Point(579, 96);
            ucNotify1.MaximumSize = new Size(333, 356);
            ucNotify1.Message = "Nội dung thông báo";
            ucNotify1.MinimumSize = new Size(333, 356);
            ucNotify1.Name = "ucNotify1";
            ucNotify1.NotiType = iPakrkingv5.Controls.Usercontrols.BuildControls.ucNotify.EmNotiType.Information;
            ucNotify1.Size = new Size(333, 356);
            ucNotify1.TabIndex = 27;
            // 
            // lblKeyword
            // 
            lblKeyword.AutoSize = true;
            lblKeyword.BackColor = Color.Transparent;
            lblKeyword.Location = new Point(83, 105);
            lblKeyword.Name = "lblKeyword";
            lblKeyword.Size = new Size(62, 20);
            lblKeyword.TabIndex = 20;
            lblKeyword.Text = "Từ khóa";
            // 
            // txtKeyword
            // 
            txtKeyword.Location = new Point(170, 98);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.Size = new Size(365, 27);
            txtKeyword.TabIndex = 0;
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
            dgvData.Columns.AddRange(new DataGridViewColumn[] { Column2, Column3, Id });
            dgvData.Location = new Point(170, 143);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowHeadersVisible = false;
            dataGridViewCellStyle3.Padding = new Padding(3);
            dgvData.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvData.RowTemplate.Height = 29;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.Size = new Size(473, 228);
            dgvData.TabIndex = 2;
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
            // Id
            // 
            Id.HeaderText = "vehicleTypeId";
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Visible = false;
            Id.Width = 163;
            // 
            // panelData
            // 
            panelData.Controls.Add(ucLoading1);
            panelData.Controls.Add(lblTitle);
            panelData.Controls.Add(btnCancel1);
            panelData.Controls.Add(btnOk1);
            panelData.Controls.Add(lblSearch);
            panelData.Controls.Add(ucNotify1);
            panelData.Controls.Add(lblKeyword);
            panelData.Controls.Add(txtKeyword);
            panelData.Controls.Add(dgvData);
            panelData.Dock = DockStyle.Fill;
            panelData.Location = new Point(0, 0);
            panelData.Name = "panelData";
            panelData.Size = new Size(800, 450);
            panelData.TabIndex = 1;
            // 
            // frmSelectVehicleType
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelData);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmSelectVehicleType";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chọn phương tiện";
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            panelData.ResumeLayout(false);
            panelData.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private iPakrkingv5.Controls.Usercontrols.BuildControls.ucLoading ucLoading1;
        private Label lblTitle;
        private iPakrkingv5.Controls.Controls.Buttons.LblCancel btnCancel1;
        private iPakrkingv5.Controls.Controls.Buttons.LblOk btnOk1;
        private iPakrkingv5.Controls.Controls.Buttons.LblSearch lblSearch;
        private iPakrkingv5.Controls.Usercontrols.BuildControls.ucNotify ucNotify1;
        private Label lblKeyword;
        private TextBox txtKeyword;
        private DataGridView dgvData;
        private Panel panelData;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Id;
    }
}