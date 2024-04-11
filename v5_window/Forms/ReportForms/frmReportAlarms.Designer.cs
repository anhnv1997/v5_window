using iPakrkingv5.Controls.Controls.Buttons;

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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportAlarms));
            cbLane = new ComboBox();
            cbVehicleType = new ComboBox();
            ucEventInInfo1 = new Usercontrols.ucEventInInfo();
            ucNotify1 = new Usercontrols.BuildControls.ucNotify();
            ucLoading1 = new Usercontrols.BuildControls.ucLoading();
            lblKeyword = new Label();
            btnExportExcel = new BtnExcel();
            lblLane = new Label();
            lblVehicleType = new Label();
            btnCancel = new LblCancel();
            btnSearch = new BtnSearch();
            ucPages1 = new Usercontrols.ucPages();
            lblTotalEvents = new Label();
            tablePic = new TableLayoutPanel();
            picOverviewImageIn = new Usercontrols.MovablePictureBox();
            picVehicleImageIn = new Usercontrols.MovablePictureBox();
            panelData = new Panel();
            cbAbNormalType = new ComboBox();
            lblAbNormalType = new Label();
            lblStartTime = new Label();
            lblEndTime = new Label();
            dgvData = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            Column14 = new DataGridViewTextBoxColumn();
            Column15 = new DataGridViewTextBoxColumn();
            Column10 = new DataGridViewTextBoxColumn();
            Column11 = new DataGridViewTextBoxColumn();
            Column12 = new DataGridViewTextBoxColumn();
            Column13 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewButtonColumn();
            dtpStartTime = new DateTimePicker();
            dtpEndTime = new DateTimePicker();
            txtKeyword = new TextBox();
            tablePic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picOverviewImageIn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picVehicleImageIn).BeginInit();
            panelData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // cbLane
            // 
            cbLane.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLane.FormattingEnabled = true;
            cbLane.Location = new Point(327, 54);
            cbLane.Margin = new Padding(3, 2, 3, 2);
            cbLane.Name = "cbLane";
            cbLane.Size = new Size(184, 23);
            cbLane.TabIndex = 6;
            // 
            // cbVehicleType
            // 
            cbVehicleType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbVehicleType.FormattingEnabled = true;
            cbVehicleType.Location = new Point(62, 56);
            cbVehicleType.Margin = new Padding(3, 2, 3, 2);
            cbVehicleType.Name = "cbVehicleType";
            cbVehicleType.Size = new Size(184, 23);
            cbVehicleType.TabIndex = 5;
            // 
            // ucEventInInfo1
            // 
            ucEventInInfo1.BackColor = Color.FromArgb(255, 224, 192);
            ucEventInInfo1.Location = new Point(534, 42);
            ucEventInInfo1.Margin = new Padding(3, 2, 3, 2);
            ucEventInInfo1.Name = "ucEventInInfo1";
            ucEventInInfo1.Size = new Size(432, 352);
            ucEventInInfo1.TabIndex = 64;
            // 
            // ucNotify1
            // 
            ucNotify1.BackColor = Color.FromArgb(255, 224, 192);
            ucNotify1.Location = new Point(511, 49);
            ucNotify1.Margin = new Padding(3, 2, 3, 2);
            ucNotify1.MaximumSize = new Size(291, 267);
            ucNotify1.Message = "Nội dung thông báo";
            ucNotify1.MinimumSize = new Size(291, 267);
            ucNotify1.Name = "ucNotify1";
            ucNotify1.NotiType = Usercontrols.BuildControls.ucNotify.EmNotiType.Information;
            ucNotify1.Size = new Size(291, 267);
            ucNotify1.TabIndex = 63;
            // 
            // ucLoading1
            // 
            ucLoading1.BackColor = Color.FromArgb(255, 224, 192);
            ucLoading1.Language = IPaking.Ultility.TextManagement.EmLanguage.Vietnamese;
            ucLoading1.Location = new Point(552, 38);
            ucLoading1.Margin = new Padding(3, 2, 3, 2);
            ucLoading1.Message = "Preparing to download";
            ucLoading1.Name = "ucLoading1";
            ucLoading1.Size = new Size(343, 141);
            ucLoading1.TabIndex = 62;
            // 
            // lblKeyword
            // 
            lblKeyword.AutoSize = true;
            lblKeyword.BackColor = Color.Transparent;
            lblKeyword.Location = new Point(3, 9);
            lblKeyword.Name = "lblKeyword";
            lblKeyword.Size = new Size(49, 15);
            lblKeyword.TabIndex = 41;
            lblKeyword.Text = "Từ khóa";
            // 
            // btnExportExcel
            // 
            btnExportExcel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExportExcel.AutoSize = true;
            btnExportExcel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnExportExcel.Location = new Point(595, 326);
            btnExportExcel.Margin = new Padding(3, 2, 3, 2);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(80, 32);
            btnExportExcel.TabIndex = 7;
            btnExportExcel.Text = "lblExcel1";
            // 
            // lblLane
            // 
            lblLane.AutoSize = true;
            lblLane.BackColor = Color.Transparent;
            lblLane.Location = new Point(260, 59);
            lblLane.Name = "lblLane";
            lblLane.Size = new Size(53, 15);
            lblLane.TabIndex = 33;
            lblLane.Text = "Làn         ";
            // 
            // lblVehicleType
            // 
            lblVehicleType.AutoSize = true;
            lblVehicleType.BackColor = Color.Transparent;
            lblVehicleType.Location = new Point(4, 60);
            lblVehicleType.Name = "lblVehicleType";
            lblVehicleType.Size = new Size(44, 15);
            lblVehicleType.TabIndex = 33;
            lblVehicleType.Text = "Loại xe";
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.AutoSize = true;
            btnCancel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(680, 326);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(72, 32);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Đóng";
            // 
            // btnSearch
            // 
            btnSearch.AutoSize = true;
            btnSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnSearch.ForeColor = Color.Black;
            btnSearch.Location = new Point(516, 52);
            btnSearch.Margin = new Padding(3, 2, 3, 2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(84, 30);
            btnSearch.TabIndex = 0;
            btnSearch.Text = "Tìm kiếm";
            // 
            // ucPages1
            // 
            ucPages1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ucPages1.BackColor = Color.Transparent;
            ucPages1.BorderStyle = BorderStyle.Fixed3D;
            ucPages1.Location = new Point(10, 707);
            ucPages1.Margin = new Padding(3, 2, 3, 2);
            ucPages1.Name = "ucPages1";
            ucPages1.Size = new Size(1543, 37);
            ucPages1.TabIndex = 43;
            ucPages1.Visible = false;
            // 
            // lblTotalEvents
            // 
            lblTotalEvents.AutoSize = true;
            lblTotalEvents.BackColor = Color.Transparent;
            lblTotalEvents.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalEvents.ForeColor = Color.FromArgb(253, 149, 40);
            lblTotalEvents.Location = new Point(595, 56);
            lblTotalEvents.Name = "lblTotalEvents";
            lblTotalEvents.Size = new Size(153, 25);
            lblTotalEvents.TabIndex = 58;
            lblTotalEvents.Text = "Tổng số sự kiện";
            lblTotalEvents.Visible = false;
            // 
            // tablePic
            // 
            tablePic.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            tablePic.ColumnCount = 1;
            tablePic.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tablePic.Controls.Add(picOverviewImageIn, 0, 0);
            tablePic.Controls.Add(picVehicleImageIn, 0, 1);
            tablePic.Location = new Point(432, 86);
            tablePic.Margin = new Padding(0);
            tablePic.Name = "tablePic";
            tablePic.RowCount = 2;
            tablePic.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tablePic.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tablePic.Size = new Size(319, 238);
            tablePic.TabIndex = 42;
            // 
            // picOverviewImageIn
            // 
            picOverviewImageIn.BackColor = Color.WhiteSmoke;
            picOverviewImageIn.BorderStyle = BorderStyle.FixedSingle;
            picOverviewImageIn.Dock = DockStyle.Fill;
            picOverviewImageIn.Location = new Point(0, 0);
            picOverviewImageIn.Margin = new Padding(0);
            picOverviewImageIn.Name = "picOverviewImageIn";
            picOverviewImageIn.Size = new Size(319, 119);
            picOverviewImageIn.SizeMode = PictureBoxSizeMode.StretchImage;
            picOverviewImageIn.TabIndex = 30;
            picOverviewImageIn.TabStop = false;
            // 
            // picVehicleImageIn
            // 
            picVehicleImageIn.BackColor = Color.WhiteSmoke;
            picVehicleImageIn.BorderStyle = BorderStyle.FixedSingle;
            picVehicleImageIn.Dock = DockStyle.Fill;
            picVehicleImageIn.Location = new Point(0, 119);
            picVehicleImageIn.Margin = new Padding(0);
            picVehicleImageIn.Name = "picVehicleImageIn";
            picVehicleImageIn.Size = new Size(319, 119);
            picVehicleImageIn.SizeMode = PictureBoxSizeMode.StretchImage;
            picVehicleImageIn.TabIndex = 29;
            picVehicleImageIn.TabStop = false;
            // 
            // panelData
            // 
            panelData.Controls.Add(cbAbNormalType);
            panelData.Controls.Add(cbLane);
            panelData.Controls.Add(cbVehicleType);
            panelData.Controls.Add(ucEventInInfo1);
            panelData.Controls.Add(ucNotify1);
            panelData.Controls.Add(ucLoading1);
            panelData.Controls.Add(lblKeyword);
            panelData.Controls.Add(lblAbNormalType);
            panelData.Controls.Add(btnExportExcel);
            panelData.Controls.Add(lblLane);
            panelData.Controls.Add(lblVehicleType);
            panelData.Controls.Add(lblStartTime);
            panelData.Controls.Add(btnCancel);
            panelData.Controls.Add(btnSearch);
            panelData.Controls.Add(ucPages1);
            panelData.Controls.Add(lblTotalEvents);
            panelData.Controls.Add(tablePic);
            panelData.Controls.Add(lblEndTime);
            panelData.Controls.Add(dgvData);
            panelData.Controls.Add(dtpStartTime);
            panelData.Controls.Add(dtpEndTime);
            panelData.Controls.Add(txtKeyword);
            panelData.Dock = DockStyle.Fill;
            panelData.Location = new Point(0, 0);
            panelData.Margin = new Padding(3, 2, 3, 2);
            panelData.Name = "panelData";
            panelData.Size = new Size(831, 367);
            panelData.TabIndex = 63;
            // 
            // cbAbNormalType
            // 
            cbAbNormalType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAbNormalType.FormattingEnabled = true;
            cbAbNormalType.Location = new Point(327, 4);
            cbAbNormalType.Margin = new Padding(3, 2, 3, 2);
            cbAbNormalType.Name = "cbAbNormalType";
            cbAbNormalType.Size = new Size(184, 23);
            cbAbNormalType.TabIndex = 2;
            // 
            // lblAbNormalType
            // 
            lblAbNormalType.AutoSize = true;
            lblAbNormalType.BackColor = Color.Transparent;
            lblAbNormalType.Location = new Point(260, 9);
            lblAbNormalType.Name = "lblAbNormalType";
            lblAbNormalType.Size = new Size(29, 15);
            lblAbNormalType.TabIndex = 33;
            lblAbNormalType.Text = "Loại";
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.BackColor = Color.Transparent;
            lblStartTime.Location = new Point(4, 34);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(47, 15);
            lblStartTime.TabIndex = 33;
            lblStartTime.Text = "Bắt đầu";
            // 
            // lblEndTime
            // 
            lblEndTime.AutoSize = true;
            lblEndTime.BackColor = Color.Transparent;
            lblEndTime.Location = new Point(258, 34);
            lblEndTime.Name = "lblEndTime";
            lblEndTime.Size = new Size(57, 15);
            lblEndTime.TabIndex = 32;
            lblEndTime.Text = "Kết thúc  ";
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
            dgvData.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column7, Column8, Column4, Column5, Column6, Column9, Column14, Column15, Column10, Column11, Column12, Column13, Column3 });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11.25F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new Padding(3);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvData.DefaultCellStyle = dataGridViewCellStyle3;
            dgvData.Location = new Point(4, 86);
            dgvData.Margin = new Padding(3, 2, 3, 2);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 11.25F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvData.RowHeadersVisible = false;
            dgvData.RowTemplate.Height = 29;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.Size = new Size(425, 238);
            dgvData.TabIndex = 39;
            // 
            // Column1
            // 
            Column1.HeaderText = "STT";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 68;
            // 
            // Column2
            // 
            Column2.HeaderText = "Tên Định Danh";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Visible = false;
            Column2.Width = 154;
            // 
            // Column7
            // 
            Column7.HeaderText = "Biển Số Xe";
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            Column7.Width = 121;
            // 
            // Column8
            // 
            Column8.HeaderText = "Thời gian";
            Column8.Name = "Column8";
            Column8.ReadOnly = true;
            Column8.Width = 113;
            // 
            // Column4
            // 
            Column4.HeaderText = "Loại";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Width = 73;
            // 
            // Column5
            // 
            Column5.HeaderText = "Làn Vào";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.Visible = false;
            Column5.Width = 101;
            // 
            // Column6
            // 
            Column6.HeaderText = "Người Dùng";
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            Column6.Visible = false;
            Column6.Width = 136;
            // 
            // Column9
            // 
            Column9.HeaderText = "physicalFileIds";
            Column9.Name = "Column9";
            Column9.ReadOnly = true;
            Column9.Visible = false;
            Column9.Width = 153;
            // 
            // Column14
            // 
            Column14.HeaderText = "customerID";
            Column14.Name = "Column14";
            Column14.ReadOnly = true;
            Column14.Visible = false;
            Column14.Width = 129;
            // 
            // Column15
            // 
            Column15.HeaderText = "registerVehicleId";
            Column15.Name = "Column15";
            Column15.ReadOnly = true;
            Column15.Visible = false;
            Column15.Width = 170;
            // 
            // Column10
            // 
            Column10.HeaderText = "Làn";
            Column10.Name = "Column10";
            Column10.ReadOnly = true;
            Column10.Width = 68;
            // 
            // Column11
            // 
            Column11.HeaderText = "Nhóm";
            Column11.Name = "Column11";
            Column11.ReadOnly = true;
            Column11.Width = 89;
            // 
            // Column12
            // 
            Column12.HeaderText = "BSĐK";
            Column12.Name = "Column12";
            Column12.ReadOnly = true;
            Column12.Width = 82;
            // 
            // Column13
            // 
            Column13.HeaderText = "Khách hàng";
            Column13.Name = "Column13";
            Column13.ReadOnly = true;
            Column13.Width = 131;
            // 
            // Column3
            // 
            Column3.HeaderText = "Xem Thêm";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 103;
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(62, 31);
            dtpStartTime.Margin = new Padding(3, 2, 3, 2);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.Size = new Size(184, 23);
            dtpStartTime.TabIndex = 3;
            // 
            // dtpEndTime
            // 
            dtpEndTime.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(327, 29);
            dtpEndTime.Margin = new Padding(3, 2, 3, 2);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.Size = new Size(184, 23);
            dtpEndTime.TabIndex = 4;
            // 
            // txtKeyword
            // 
            txtKeyword.Location = new Point(62, 6);
            txtKeyword.Margin = new Padding(3, 2, 3, 2);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.Size = new Size(184, 23);
            txtKeyword.TabIndex = 1;
            // 
            // frmReportAlarms
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(831, 367);
            Controls.Add(panelData);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmReportAlarms";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sự kiện cảnh báo";
            WindowState = FormWindowState.Maximized;
            tablePic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picOverviewImageIn).EndInit();
            ((System.ComponentModel.ISupportInitialize)picVehicleImageIn).EndInit();
            panelData.ResumeLayout(false);
            panelData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cbLane;
        private ComboBox cbVehicleType;
        private Usercontrols.ucEventInInfo ucEventInInfo1;
        private Usercontrols.BuildControls.ucNotify ucNotify1;
        private Usercontrols.BuildControls.ucLoading ucLoading1;
        private Label lblKeyword;
        private BtnExcel btnExportExcel;
        private Label lblLane;
        private Label lblVehicleType;
        private LblCancel btnCancel;
        private BtnSearch btnSearch;
        private Usercontrols.ucPages ucPages1;
        private Label lblTotalEvents;
        private TableLayoutPanel tablePic;
        private Usercontrols.MovablePictureBox picOverviewImageIn;
        private Usercontrols.MovablePictureBox picVehicleImageIn;
        private Panel panelData;
        private Label lblStartTime;
        private Label lblEndTime;
        private DataGridView dgvData;
        private DateTimePicker dtpStartTime;
        private DateTimePicker dtpEndTime;
        private TextBox txtKeyword;
        private ComboBox cbAbNormalType;
        private Label lblAbNormalType;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column14;
        private DataGridViewTextBoxColumn Column15;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewTextBoxColumn Column11;
        private DataGridViewTextBoxColumn Column12;
        private DataGridViewTextBoxColumn Column13;
        private DataGridViewButtonColumn Column3;
    }
}