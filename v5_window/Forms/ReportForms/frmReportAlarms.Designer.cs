namespace iParkingv5_window.Forms.ReportForms
{
    partial class frmReportAlarms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportAlarms));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Column9 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label3 = new Label();
            txtKeyword = new TextBox();
            dgvData = new DataGridView();
            label2 = new Label();
            label1 = new Label();
            dtpEndTime = new DateTimePicker();
            dtpStartTime = new DateTimePicker();
            lblPrint1 = new Controls.Buttons.LblPrint();
            lblCancel1 = new Controls.Buttons.LblCancel();
            lblSearch1 = new Controls.Buttons.LblSearch();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // Column9
            // 
            Column9.HeaderText = "physicalFileIds";
            Column9.Name = "Column9";
            Column9.ReadOnly = true;
            Column9.Visible = false;
            // 
            // Column5
            // 
            Column5.HeaderText = "Làn Vào";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.Width = 101;
            // 
            // Column8
            // 
            Column8.HeaderText = "Giờ Vào";
            Column8.Name = "Column8";
            Column8.ReadOnly = true;
            // 
            // Column7
            // 
            Column7.HeaderText = "Biển Số Xe";
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            Column7.Width = 121;
            // 
            // Column4
            // 
            Column4.HeaderText = "Nhóm Định Danh";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Width = 175;
            // 
            // Column3
            // 
            Column3.HeaderText = "Mã Định Danh";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 151;
            // 
            // Column2
            // 
            Column2.HeaderText = "Tên Định Danh";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 154;
            // 
            // Column1
            // 
            Column1.HeaderText = "STT";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 68;
            // 
            // Column6
            // 
            Column6.HeaderText = "Người Dùng";
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            Column6.Width = 136;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(pictureBox2, 0, 1);
            tableLayoutPanel1.Location = new Point(779, 88);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(246, 461);
            tableLayoutPanel1.TabIndex = 53;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(240, 224);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 30;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Dock = DockStyle.Fill;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(3, 233);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(240, 225);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 29;
            pictureBox2.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 13);
            label3.Name = "label3";
            label3.Size = new Size(62, 20);
            label3.TabIndex = 52;
            label3.Text = "Từ khóa";
            // 
            // txtKeyword
            // 
            txtKeyword.Location = new Point(80, 9);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.Size = new Size(503, 27);
            txtKeyword.TabIndex = 51;
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
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column7, Column8, Column5, Column6, Column9 });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11.25F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new Padding(3);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvData.DefaultCellStyle = dataGridViewCellStyle3;
            dgvData.Location = new Point(12, 88);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowHeadersVisible = false;
            dgvData.RowTemplate.Height = 29;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.Size = new Size(761, 461);
            dgvData.TabIndex = 50;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(304, 47);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 43;
            label2.Text = "Kết thúc";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 47);
            label1.Name = "label1";
            label1.Size = new Size(60, 20);
            label1.TabIndex = 44;
            label1.Text = "Bắt đầu";
            // 
            // dtpEndTime
            // 
            dtpEndTime.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(373, 42);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.Size = new Size(210, 27);
            dtpEndTime.TabIndex = 45;
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(80, 42);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.Size = new Size(210, 27);
            dtpStartTime.TabIndex = 46;
            // 
            // lblPrint1
            // 
            lblPrint1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblPrint1.AutoSize = true;
            lblPrint1.BorderStyle = BorderStyle.Fixed3D;
            lblPrint1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblPrint1.Location = new Point(865, 576);
            lblPrint1.Name = "lblPrint1";
            lblPrint1.Size = new Size(71, 22);
            lblPrint1.TabIndex = 54;
            lblPrint1.Text = "lblPrint1";
            // 
            // lblCancel1
            // 
            lblCancel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblCancel1.AutoSize = true;
            lblCancel1.BorderStyle = BorderStyle.Fixed3D;
            lblCancel1.Location = new Point(942, 576);
            lblCancel1.Name = "lblCancel1";
            lblCancel1.Size = new Size(80, 22);
            lblCancel1.TabIndex = 55;
            lblCancel1.Text = "lblCancel1";
            // 
            // lblSearch1
            // 
            lblSearch1.AutoSize = true;
            lblSearch1.BorderStyle = BorderStyle.Fixed3D;
            lblSearch1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblSearch1.Location = new Point(605, 14);
            lblSearch1.Name = "lblSearch1";
            lblSearch1.Size = new Size(83, 22);
            lblSearch1.TabIndex = 56;
            lblSearch1.Text = "lblSearch1";
            // 
            // frmReportAlarms
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1037, 619);
            Controls.Add(lblSearch1);
            Controls.Add(lblCancel1);
            Controls.Add(lblPrint1);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(label3);
            Controls.Add(txtKeyword);
            Controls.Add(dgvData);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpEndTime);
            Controls.Add(dtpStartTime);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmReportAlarms";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sự kiện cảnh báo";
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column6;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label3;
        private TextBox txtKeyword;
        private DataGridView dgvData;
        private Label label2;
        private Label label1;
        private DateTimePicker dtpEndTime;
        private DateTimePicker dtpStartTime;
        private Controls.Buttons.LblPrint lblPrint1;
        private Controls.Buttons.LblCancel lblCancel1;
        private Controls.Buttons.LblSearch lblSearch1;
    }
}