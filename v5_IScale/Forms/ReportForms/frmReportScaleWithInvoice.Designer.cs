namespace v5_IScale.Forms.ReportForms
{
    partial class frmReportScaleWithInvoice
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
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportScaleWithInvoice));
            label1 = new Label();
            label2 = new Label();
            dtpStartTime = new DateTimePicker();
            dtpEndTime = new DateTimePicker();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtPlateNumber = new TextBox();
            cbGoodsType = new ComboBox();
            txtUsername = new TextBox();
            dgvData = new DataGridView();
            Column13 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            Column10 = new DataGridViewTextBoxColumn();
            Column11 = new DataGridViewTextBoxColumn();
            Column12 = new DataGridViewTextBoxColumn();
            groupBox1 = new GroupBox();
            btnExcel = new Button();
            btnSearch = new Button();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel3 = new Panel();
            picFirstWeight = new MovablePictureBox();
            label7 = new Label();
            panel4 = new Panel();
            picSecondWeight = new MovablePictureBox();
            label8 = new Label();
            groupBox2 = new GroupBox();
            cbPrintMode = new ComboBox();
            btnPrintInternetEInvoice = new Button();
            btnPrintScaleTicket = new Button();
            btnPrintEInvoice = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picFirstWeight).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picSecondWeight).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 36);
            label1.Name = "label1";
            label1.Size = new Size(62, 20);
            label1.TabIndex = 0;
            label1.Text = "Từ ngày";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 67);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 0;
            label2.Text = "Đến ngày";
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(91, 31);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.Size = new Size(289, 27);
            dtpStartTime.TabIndex = 2;
            // 
            // dtpEndTime
            // 
            dtpEndTime.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(91, 64);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.Size = new Size(289, 27);
            dtpEndTime.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 100);
            label3.Name = "label3";
            label3.Size = new Size(76, 20);
            label3.TabIndex = 2;
            label3.Text = "Biển số xe";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 166);
            label4.Name = "label4";
            label4.Size = new Size(74, 20);
            label4.TabIndex = 2;
            label4.Text = "Loại hàng";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 133);
            label5.Name = "label5";
            label5.Size = new Size(78, 20);
            label5.TabIndex = 2;
            label5.Text = "Người cân";
            // 
            // txtPlateNumber
            // 
            txtPlateNumber.Location = new Point(91, 97);
            txtPlateNumber.Name = "txtPlateNumber";
            txtPlateNumber.Size = new Size(289, 27);
            txtPlateNumber.TabIndex = 4;
            // 
            // cbGoodsType
            // 
            cbGoodsType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGoodsType.FormattingEnabled = true;
            cbGoodsType.Location = new Point(91, 163);
            cbGoodsType.Name = "cbGoodsType";
            cbGoodsType.Size = new Size(289, 28);
            cbGoodsType.TabIndex = 6;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(91, 130);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(289, 27);
            txtUsername.TabIndex = 5;
            // 
            // dgvData
            // 
            dgvData.AllowUserToAddRows = false;
            dgvData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(192, 255, 255);
            dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvData.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Columns.AddRange(new DataGridViewColumn[] { Column13, Column1, Column2, Column3, Column4, Column5, Column6, Column7, Column8, Column9, Column10, Column11, Column12 });
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = SystemColors.Window;
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 11.25F);
            dataGridViewCellStyle10.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle10.Padding = new Padding(5);
            dataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            dgvData.DefaultCellStyle = dataGridViewCellStyle10;
            dgvData.Dock = DockStyle.Fill;
            dgvData.Location = new Point(0, 266);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowHeadersVisible = false;
            dgvData.RowTemplate.Height = 29;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.Size = new Size(1232, 243);
            dgvData.TabIndex = 5;
            dgvData.CellClick += dgvData_CellClick;
            // 
            // Column13
            // 
            Column13.HeaderText = "parkingEventId";
            Column13.Name = "Column13";
            Column13.ReadOnly = true;
            Column13.Visible = false;
            Column13.Width = 131;
            // 
            // Column1
            // 
            Column1.HeaderText = "STT";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 70;
            // 
            // Column2
            // 
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            Column2.DefaultCellStyle = dataGridViewCellStyle3;
            Column2.HeaderText = "Giờ cân 1";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 109;
            // 
            // Column3
            // 
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            Column3.DefaultCellStyle = dataGridViewCellStyle4;
            Column3.HeaderText = "Giờ cân 2";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 109;
            // 
            // Column4
            // 
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            Column4.DefaultCellStyle = dataGridViewCellStyle5;
            Column4.HeaderText = "Biển số";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Width = 95;
            // 
            // Column5
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Font = new Font("Digital-7", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Column5.DefaultCellStyle = dataGridViewCellStyle6;
            Column5.HeaderText = "Khối lượng cân 1";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.Width = 162;
            // 
            // Column6
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Font = new Font("Digital-7", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Column6.DefaultCellStyle = dataGridViewCellStyle7;
            Column6.HeaderText = "Khối lượng cân 2";
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            Column6.Width = 162;
            // 
            // Column7
            // 
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Column7.DefaultCellStyle = dataGridViewCellStyle8;
            Column7.HeaderText = "Thông tin cân lần >= 3";
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            Column7.Width = 204;
            // 
            // Column8
            // 
            Column8.HeaderText = "Loại hàng";
            Column8.Name = "Column8";
            Column8.ReadOnly = true;
            Column8.Width = 112;
            // 
            // Column9
            // 
            Column9.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            Column9.DefaultCellStyle = dataGridViewCellStyle9;
            Column9.HeaderText = "Người cân";
            Column9.Name = "Column9";
            Column9.ReadOnly = true;
            // 
            // Column10
            // 
            Column10.HeaderText = "vehicleInImage";
            Column10.Name = "Column10";
            Column10.ReadOnly = true;
            Column10.Visible = false;
            Column10.Width = 150;
            // 
            // Column11
            // 
            Column11.HeaderText = "firstScaleImage";
            Column11.Name = "Column11";
            Column11.ReadOnly = true;
            Column11.Visible = false;
            Column11.Width = 152;
            // 
            // Column12
            // 
            Column12.HeaderText = "secondScaleImage";
            Column12.Name = "Column12";
            Column12.ReadOnly = true;
            Column12.Visible = false;
            Column12.Width = 172;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnExcel);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cbGoodsType);
            groupBox1.Controls.Add(dtpStartTime);
            groupBox1.Controls.Add(txtUsername);
            groupBox1.Controls.Add(dtpEndTime);
            groupBox1.Controls.Add(txtPlateNumber);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Dock = DockStyle.Left;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(390, 266);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Điều kiện lọc";
            // 
            // btnExcel
            // 
            btnExcel.AutoSize = true;
            btnExcel.Font = new Font("Segoe UI", 14F);
            btnExcel.Image = Properties.Resources.icons8_export_csv_32px;
            btnExcel.Location = new Point(279, 210);
            btnExcel.Name = "btnExcel";
            btnExcel.Size = new Size(101, 46);
            btnExcel.TabIndex = 1;
            btnExcel.Text = "Excel";
            btnExcel.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnExcel.UseVisualStyleBackColor = true;
            btnExcel.Click += btnExcel_Click;
            // 
            // btnSearch
            // 
            btnSearch.AutoSize = true;
            btnSearch.Font = new Font("Segoe UI", 14F);
            btnSearch.Image = Properties.Resources.icons8_search_32px;
            btnSearch.Location = new Point(143, 210);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(130, 46);
            btnSearch.TabIndex = 0;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1232, 266);
            panel1.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0000076F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(panel3, 0, 0);
            tableLayoutPanel1.Controls.Add(panel4, 1, 0);
            tableLayoutPanel1.Location = new Point(390, 70);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(842, 196);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // panel3
            // 
            panel3.Controls.Add(picFirstWeight);
            panel3.Controls.Add(label7);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(5, 5);
            panel3.Name = "panel3";
            panel3.Size = new Size(412, 186);
            panel3.TabIndex = 0;
            // 
            // picFirstWeight
            // 
            picFirstWeight.Dock = DockStyle.Fill;
            picFirstWeight.Location = new Point(0, 20);
            picFirstWeight.Name = "picFirstWeight";
            picFirstWeight.Size = new Size(412, 166);
            picFirstWeight.SizeMode = PictureBoxSizeMode.Zoom;
            picFirstWeight.TabIndex = 1;
            picFirstWeight.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Top;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(0, 0, 192);
            label7.Location = new Point(0, 0);
            label7.Name = "label7";
            label7.Size = new Size(114, 20);
            label7.TabIndex = 0;
            label7.Text = "ẢNH XE CÂN 1";
            // 
            // panel4
            // 
            panel4.Controls.Add(picSecondWeight);
            panel4.Controls.Add(label8);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(425, 5);
            panel4.Name = "panel4";
            panel4.Size = new Size(412, 186);
            panel4.TabIndex = 0;
            // 
            // picSecondWeight
            // 
            picSecondWeight.Dock = DockStyle.Fill;
            picSecondWeight.Location = new Point(0, 20);
            picSecondWeight.Name = "picSecondWeight";
            picSecondWeight.Size = new Size(412, 166);
            picSecondWeight.SizeMode = PictureBoxSizeMode.Zoom;
            picSecondWeight.TabIndex = 1;
            picSecondWeight.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Top;
            label8.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(0, 0, 192);
            label8.Location = new Point(0, 0);
            label8.Name = "label8";
            label8.Size = new Size(114, 20);
            label8.TabIndex = 0;
            label8.Text = "ẢNH XE CÂN 2";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cbPrintMode);
            groupBox2.Controls.Add(btnPrintInternetEInvoice);
            groupBox2.Controls.Add(btnPrintScaleTicket);
            groupBox2.Controls.Add(btnPrintEInvoice);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(390, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(842, 70);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "In";
            // 
            // cbPrintMode
            // 
            cbPrintMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPrintMode.FormattingEnabled = true;
            cbPrintMode.Items.AddRange(new object[] { "Thông tin cân lần 1", "Thông tin cân lần 2", "Thông tin cân lần 3", "Thông tin cân lần 4", "Thông tin cân lần 5", "Thông tin cân lần 6", "Thông tin cân lần 7", "Thông tin cân lần 8", "Thông tin cân lần 9", "Thông tin cân lần 10" });
            cbPrintMode.Location = new Point(6, 31);
            cbPrintMode.Name = "cbPrintMode";
            cbPrintMode.Size = new Size(261, 28);
            cbPrintMode.TabIndex = 6;
            // 
            // btnPrintInternetEInvoice
            // 
            btnPrintInternetEInvoice.AutoSize = true;
            btnPrintInternetEInvoice.Font = new Font("Segoe UI", 14F);
            btnPrintInternetEInvoice.Image = Properties.Resources.icons8_print_32px;
            btnPrintInternetEInvoice.Location = new Point(577, 24);
            btnPrintInternetEInvoice.Name = "btnPrintInternetEInvoice";
            btnPrintInternetEInvoice.Size = new Size(226, 38);
            btnPrintInternetEInvoice.TabIndex = 9;
            btnPrintInternetEInvoice.Text = "Hóa đơn (Internet)";
            btnPrintInternetEInvoice.TextAlign = ContentAlignment.MiddleRight;
            btnPrintInternetEInvoice.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPrintInternetEInvoice.UseVisualStyleBackColor = true;
            btnPrintInternetEInvoice.Click += btnPrintInternetEInvoice_Click;
            // 
            // btnPrintScaleTicket
            // 
            btnPrintScaleTicket.AutoSize = true;
            btnPrintScaleTicket.Font = new Font("Segoe UI", 14F);
            btnPrintScaleTicket.Image = Properties.Resources.icons8_print_32px;
            btnPrintScaleTicket.Location = new Point(273, 24);
            btnPrintScaleTicket.Name = "btnPrintScaleTicket";
            btnPrintScaleTicket.Size = new Size(166, 38);
            btnPrintScaleTicket.TabIndex = 7;
            btnPrintScaleTicket.Text = "Phiếu cân";
            btnPrintScaleTicket.TextAlign = ContentAlignment.MiddleRight;
            btnPrintScaleTicket.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPrintScaleTicket.UseVisualStyleBackColor = true;
            btnPrintScaleTicket.Click += btnPrintScaleTicket_Click;
            // 
            // btnPrintEInvoice
            // 
            btnPrintEInvoice.AutoSize = true;
            btnPrintEInvoice.Font = new Font("Segoe UI", 14F);
            btnPrintEInvoice.Image = Properties.Resources.icons8_print_32px;
            btnPrintEInvoice.Location = new Point(445, 24);
            btnPrintEInvoice.Name = "btnPrintEInvoice";
            btnPrintEInvoice.Size = new Size(126, 38);
            btnPrintEInvoice.TabIndex = 8;
            btnPrintEInvoice.Text = "Hóa đơn";
            btnPrintEInvoice.TextAlign = ContentAlignment.MiddleRight;
            btnPrintEInvoice.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPrintEInvoice.UseVisualStyleBackColor = true;
            btnPrintEInvoice.Click += btnPrintEInvoice_Click;
            // 
            // frmReportScaleWithInvoice
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1232, 509);
            Controls.Add(dgvData);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmReportScaleWithInvoice";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Báo cáo sự kiện cân";
            WindowState = FormWindowState.Maximized;
            Load += frmReportScaleWithInvoice_Load;
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picFirstWeight).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picSecondWeight).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private DateTimePicker dtpStartTime;
        private DateTimePicker dtpEndTime;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtPlateNumber;
        private ComboBox cbGoodsType;
        private TextBox txtUsername;
        private DataGridView dgvData;
        private GroupBox groupBox1;
        private Button btnSearch;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private ComboBox cbPrintMode;
        private Panel panel3;
        private Label label7;
        private Panel panel4;
        private Label label8;
        private MovablePictureBox picFirstWeight;
        private MovablePictureBox picSecondWeight;
        private GroupBox groupBox2;
        private Button btnPrintInternetEInvoice;
        private Button btnPrintEInvoice;
        private Button btnPrintScaleTicket;
        private Button btnExcel;
        private DataGridViewTextBoxColumn Column13;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewTextBoxColumn Column11;
        private DataGridViewTextBoxColumn Column12;
    }
}