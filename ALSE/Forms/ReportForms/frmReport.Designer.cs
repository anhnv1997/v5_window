namespace ALSE
{
    partial class frmReport
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
            label1 = new Label();
            txtCardNumber = new TextBox();
            dtpStartTime = new DateTimePicker();
            dtpEndTime = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            cbEventType = new ComboBox();
            label4 = new Label();
            cbEventStatus = new ComboBox();
            label5 = new Label();
            panel1 = new Panel();
            btnExportExcel = new Button();
            btnSearch = new Button();
            dgvData = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            btnClose = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 6);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã Thẻ";
            // 
            // txtCardNumber
            // 
            txtCardNumber.Location = new Point(88, 3);
            txtCardNumber.Name = "txtCardNumber";
            txtCardNumber.Size = new Size(193, 27);
            txtCardNumber.TabIndex = 1;
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(437, 3);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.Size = new Size(193, 27);
            dtpStartTime.TabIndex = 2;
            // 
            // dtpEndTime
            // 
            dtpEndTime.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(437, 36);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.Size = new Size(193, 27);
            dtpEndTime.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(353, 41);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 3;
            label2.Text = "Đến ngày";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(353, 8);
            label3.Name = "label3";
            label3.Size = new Size(62, 20);
            label3.TabIndex = 3;
            label3.Text = "Từ ngày";
            // 
            // cbEventType
            // 
            cbEventType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEventType.FormattingEnabled = true;
            cbEventType.Items.AddRange(new object[] { "TẤT CẢ", "VÀO", "RA" });
            cbEventType.Location = new Point(88, 35);
            cbEventType.Name = "cbEventType";
            cbEventType.Size = new Size(193, 28);
            cbEventType.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(4, 38);
            label4.Name = "label4";
            label4.Size = new Size(37, 20);
            label4.TabIndex = 5;
            label4.Text = "Loại";
            // 
            // cbEventStatus
            // 
            cbEventStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEventStatus.FormattingEnabled = true;
            cbEventStatus.Items.AddRange(new object[] { "TẤT CẢ", "HỢP LỆ", "KHÔNG HỢP LỆ" });
            cbEventStatus.Location = new Point(88, 69);
            cbEventStatus.Name = "cbEventStatus";
            cbEventStatus.Size = new Size(193, 28);
            cbEventStatus.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(4, 72);
            label5.Name = "label5";
            label5.Size = new Size(78, 20);
            label5.TabIndex = 5;
            label5.Text = "Trạng Thái";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnExportExcel);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(txtCardNumber);
            panel1.Controls.Add(cbEventStatus);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(dtpStartTime);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(dtpEndTime);
            panel1.Controls.Add(cbEventType);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(891, 108);
            panel1.TabIndex = 7;
            // 
            // btnExportExcel
            // 
            btnExportExcel.Location = new Point(765, 5);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(93, 58);
            btnExportExcel.TabIndex = 8;
            btnExportExcel.Text = "Xuất Excel";
            btnExportExcel.UseVisualStyleBackColor = true;
            btnExportExcel.Click += btnExportExcel_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(662, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(97, 60);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "Tìm Kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
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
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Columns.AddRange(new DataGridViewColumn[] { Column1, Column4, Column2, Column3, Column6, Column5 });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11.25F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new Padding(3);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvData.DefaultCellStyle = dataGridViewCellStyle3;
            dgvData.Location = new Point(4, 114);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowHeadersVisible = false;
            dgvData.RowTemplate.Height = 29;
            dgvData.Size = new Size(875, 363);
            dgvData.TabIndex = 8;
            // 
            // Column1
            // 
            Column1.HeaderText = "STT";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 70;
            // 
            // Column4
            // 
            Column4.HeaderText = "Thời Gian";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Width = 111;
            // 
            // Column2
            // 
            Column2.HeaderText = "Mã Thẻ";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 96;
            // 
            // Column3
            // 
            Column3.HeaderText = "Tên";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 69;
            // 
            // Column6
            // 
            Column6.HeaderText = "Loại Sự Kiện";
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            Column6.Width = 130;
            // 
            // Column5
            // 
            Column5.HeaderText = "Trạng Thái";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.Width = 118;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Image = Properties.Resources.cancel;
            btnClose.Location = new Point(752, 492);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(127, 44);
            btnClose.TabIndex = 9;
            btnClose.Text = "Đóng";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            // 
            // frmReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(891, 539);
            Controls.Add(btnClose);
            Controls.Add(dgvData);
            Controls.Add(panel1);
            Name = "frmReport";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lịch sử quẹt thẻ";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox txtCardNumber;
        private DateTimePicker dtpStartTime;
        private DateTimePicker dtpEndTime;
        private Label label2;
        private Label label3;
        private ComboBox cbEventType;
        private Label label4;
        private ComboBox cbEventStatus;
        private Label label5;
        private Panel panel1;
        private Button btnSearch;
        private DataGridView dgvData;
        private Button btnClose;
        private Button btnExportExcel;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column5;
    }
}