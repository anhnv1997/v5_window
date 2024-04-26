using iPakrkingv5.Controls.Controls.Buttons;
using iParkingv5_window.Usercontrols;

namespace iParkingv5_window.Forms.ReportForms
{
    partial class frmReportIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportIn));
            picOverviewImageIn = new MovablePictureBox();
            picVehicleImageIn = new MovablePictureBox();
            tablePic = new TableLayoutPanel();
            lblKeyword = new Label();
            txtKeyword = new TextBox();
            dgvData = new DataGridView();
            dtpEndTime = new DateTimePicker();
            dtpStartTime = new DateTimePicker();
            lblEndTime = new Label();
            lblStartTime = new Label();
            ucPages1 = new ucPages();
            lblTotalEvents = new Label();
            btnCancel = new LblCancel();
            btnSearch = new BtnSearch();
            btnExportExcel = new BtnExcel();
            panelData = new Panel();
            lblTitle = new Label();
            cbLane = new ComboBox();
            cbIdentityGroupType = new ComboBox();
            cbVehicleType = new ComboBox();
            ucEventInInfo1 = new ucEventInInfo();
            ucNotify1 = new Usercontrols.BuildControls.ucNotify();
            ucLoading1 = new Usercontrols.BuildControls.ucLoading();
            lblLane = new Label();
            lblVehicleType = new Label();
            lblIdentityType = new Label();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column15 = new DataGridViewTextBoxColumn();
            Column16 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            Column13 = new DataGridViewTextBoxColumn();
            Column14 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column10 = new DataGridViewTextBoxColumn();
            Column12 = new DataGridViewTextBoxColumn();
            Column11 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewButtonColumn();
            Column17 = new DataGridViewTextBoxColumn();
            Column18 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)picOverviewImageIn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picVehicleImageIn).BeginInit();
            tablePic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            panelData.SuspendLayout();
            SuspendLayout();
            // 
            // picOverviewImageIn
            // 
            picOverviewImageIn.BackColor = Color.WhiteSmoke;
            picOverviewImageIn.BorderStyle = BorderStyle.FixedSingle;
            picOverviewImageIn.Dock = DockStyle.Fill;
            picOverviewImageIn.Location = new Point(0, 0);
            picOverviewImageIn.Margin = new Padding(0);
            picOverviewImageIn.Name = "picOverviewImageIn";
            picOverviewImageIn.Size = new Size(215, 154);
            picOverviewImageIn.SizeMode = PictureBoxSizeMode.StretchImage;
            picOverviewImageIn.TabIndex = 30;
            picOverviewImageIn.TabStop = false;
            // 
            // picVehicleImageIn
            // 
            picVehicleImageIn.BackColor = Color.WhiteSmoke;
            picVehicleImageIn.BorderStyle = BorderStyle.FixedSingle;
            picVehicleImageIn.Dock = DockStyle.Fill;
            picVehicleImageIn.Location = new Point(0, 154);
            picVehicleImageIn.Margin = new Padding(0);
            picVehicleImageIn.Name = "picVehicleImageIn";
            picVehicleImageIn.Size = new Size(215, 154);
            picVehicleImageIn.SizeMode = PictureBoxSizeMode.StretchImage;
            picVehicleImageIn.TabIndex = 29;
            picVehicleImageIn.TabStop = false;
            // 
            // tablePic
            // 
            tablePic.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            tablePic.ColumnCount = 1;
            tablePic.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tablePic.Controls.Add(picOverviewImageIn, 0, 0);
            tablePic.Controls.Add(picVehicleImageIn, 0, 1);
            tablePic.Location = new Point(681, 68);
            tablePic.Margin = new Padding(0);
            tablePic.Name = "tablePic";
            tablePic.RowCount = 2;
            tablePic.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tablePic.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tablePic.Size = new Size(215, 308);
            tablePic.TabIndex = 42;
            // 
            // lblKeyword
            // 
            lblKeyword.AutoSize = true;
            lblKeyword.BackColor = Color.Transparent;
            lblKeyword.Location = new Point(10, 25);
            lblKeyword.Name = "lblKeyword";
            lblKeyword.Size = new Size(49, 15);
            lblKeyword.TabIndex = 41;
            lblKeyword.Text = "Từ khóa";
            // 
            // txtKeyword
            // 
            txtKeyword.Location = new Point(69, 22);
            txtKeyword.Margin = new Padding(3, 2, 3, 2);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.Size = new Size(184, 23);
            txtKeyword.TabIndex = 1;
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
            dgvData.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column7, Column15, Column16, Column8, Column5, Column6, Column9, Column13, Column14, Column4, Column10, Column12, Column11, Column3, Column17, Column18 });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11.25F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new Padding(3);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvData.DefaultCellStyle = dataGridViewCellStyle3;
            dgvData.Location = new Point(7, 119);
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
            dgvData.Size = new Size(666, 256);
            dgvData.TabIndex = 39;
            // 
            // dtpEndTime
            // 
            dtpEndTime.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(334, 45);
            dtpEndTime.Margin = new Padding(3, 2, 3, 2);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.Size = new Size(184, 23);
            dtpEndTime.TabIndex = 3;
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(69, 46);
            dtpStartTime.Margin = new Padding(3, 2, 3, 2);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.Size = new Size(184, 23);
            dtpStartTime.TabIndex = 2;
            // 
            // lblEndTime
            // 
            lblEndTime.AutoSize = true;
            lblEndTime.BackColor = Color.Transparent;
            lblEndTime.Location = new Point(265, 50);
            lblEndTime.Name = "lblEndTime";
            lblEndTime.Size = new Size(57, 15);
            lblEndTime.TabIndex = 32;
            lblEndTime.Text = "Kết thúc  ";
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.BackColor = Color.Transparent;
            lblStartTime.Location = new Point(11, 50);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(47, 15);
            lblStartTime.TabIndex = 33;
            lblStartTime.Text = "Bắt đầu";
            // 
            // ucPages1
            // 
            ucPages1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ucPages1.BackColor = Color.Transparent;
            ucPages1.BorderStyle = BorderStyle.Fixed3D;
            ucPages1.Location = new Point(3, 391);
            ucPages1.Margin = new Padding(3, 2, 3, 2);
            ucPages1.Name = "ucPages1";
            ucPages1.Size = new Size(887, 37);
            ucPages1.TabIndex = 43;
            ucPages1.Visible = false;
            // 
            // lblTotalEvents
            // 
            lblTotalEvents.AutoSize = true;
            lblTotalEvents.BackColor = Color.Transparent;
            lblTotalEvents.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalEvents.ForeColor = Color.FromArgb(253, 149, 40);
            lblTotalEvents.Location = new Point(602, 69);
            lblTotalEvents.Name = "lblTotalEvents";
            lblTotalEvents.Size = new Size(153, 25);
            lblTotalEvents.TabIndex = 58;
            lblTotalEvents.Text = "Tổng số sự kiện";
            lblTotalEvents.Visible = false;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.AutoSize = true;
            btnCancel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(829, 423);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(57, 30);
            btnCancel.TabIndex = 59;
            btnCancel.Text = "Đóng";
            // 
            // btnSearch
            // 
            btnSearch.AutoSize = true;
            btnSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnSearch.ForeColor = Color.Black;
            btnSearch.Location = new Point(523, 68);
            btnSearch.Margin = new Padding(3, 2, 3, 2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(84, 30);
            btnSearch.TabIndex = 60;
            btnSearch.Text = "Tìm kiếm";
            // 
            // btnExportExcel
            // 
            btnExportExcel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExportExcel.AutoSize = true;
            btnExportExcel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnExportExcel.Location = new Point(746, 423);
            btnExportExcel.Margin = new Padding(3, 2, 3, 2);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(80, 30);
            btnExportExcel.TabIndex = 61;
            btnExportExcel.Text = "lblExcel1";
            // 
            // panelData
            // 
            panelData.Controls.Add(lblTitle);
            panelData.Controls.Add(cbLane);
            panelData.Controls.Add(cbIdentityGroupType);
            panelData.Controls.Add(cbVehicleType);
            panelData.Controls.Add(ucEventInInfo1);
            panelData.Controls.Add(ucNotify1);
            panelData.Controls.Add(ucLoading1);
            panelData.Controls.Add(lblKeyword);
            panelData.Controls.Add(btnExportExcel);
            panelData.Controls.Add(lblLane);
            panelData.Controls.Add(lblVehicleType);
            panelData.Controls.Add(lblIdentityType);
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
            panelData.Size = new Size(896, 460);
            panelData.TabIndex = 62;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(10, 7);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(29, 15);
            lblTitle.TabIndex = 65;
            lblTitle.Text = "Title";
            // 
            // cbLane
            // 
            cbLane.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLane.FormattingEnabled = true;
            cbLane.Location = new Point(334, 70);
            cbLane.Margin = new Padding(3, 2, 3, 2);
            cbLane.Name = "cbLane";
            cbLane.Size = new Size(184, 23);
            cbLane.TabIndex = 5;
            // 
            // cbIdentityGroupType
            // 
            cbIdentityGroupType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbIdentityGroupType.FormattingEnabled = true;
            cbIdentityGroupType.Location = new Point(334, 20);
            cbIdentityGroupType.Margin = new Padding(3, 2, 3, 2);
            cbIdentityGroupType.Name = "cbIdentityGroupType";
            cbIdentityGroupType.Size = new Size(184, 23);
            cbIdentityGroupType.TabIndex = 5;
            // 
            // cbVehicleType
            // 
            cbVehicleType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbVehicleType.FormattingEnabled = true;
            cbVehicleType.Location = new Point(69, 71);
            cbVehicleType.Margin = new Padding(3, 2, 3, 2);
            cbVehicleType.Name = "cbVehicleType";
            cbVehicleType.Size = new Size(184, 23);
            cbVehicleType.TabIndex = 4;
            // 
            // ucEventInInfo1
            // 
            ucEventInInfo1.BackColor = Color.FromArgb(255, 224, 192);
            ucEventInInfo1.Location = new Point(534, 42);
            ucEventInInfo1.Margin = new Padding(3, 2, 3, 2);
            ucEventInInfo1.Name = "ucEventInInfo1";
            ucEventInInfo1.Size = new Size(432, 470);
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
            // lblLane
            // 
            lblLane.AutoSize = true;
            lblLane.BackColor = Color.Transparent;
            lblLane.Location = new Point(267, 75);
            lblLane.Name = "lblLane";
            lblLane.Size = new Size(26, 15);
            lblLane.TabIndex = 33;
            lblLane.Text = "Làn";
            // 
            // lblVehicleType
            // 
            lblVehicleType.AutoSize = true;
            lblVehicleType.BackColor = Color.Transparent;
            lblVehicleType.Location = new Point(11, 76);
            lblVehicleType.Name = "lblVehicleType";
            lblVehicleType.Size = new Size(44, 15);
            lblVehicleType.TabIndex = 33;
            lblVehicleType.Text = "Loại xe";
            // 
            // lblIdentityType
            // 
            lblIdentityType.AutoSize = true;
            lblIdentityType.BackColor = Color.Transparent;
            lblIdentityType.Location = new Point(265, 26);
            lblIdentityType.Name = "lblIdentityType";
            lblIdentityType.Size = new Size(61, 15);
            lblIdentityType.TabIndex = 33;
            lblIdentityType.Text = "Nhóm thẻ";
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
            // Column15
            // 
            Column15.HeaderText = "Tên Thẻ";
            Column15.Name = "Column15";
            Column15.ReadOnly = true;
            // 
            // Column16
            // 
            Column16.HeaderText = "Mã Thẻ";
            Column16.Name = "Column16";
            Column16.ReadOnly = true;
            Column16.Width = 97;
            // 
            // Column8
            // 
            Column8.HeaderText = "Giờ Vào";
            Column8.Name = "Column8";
            Column8.ReadOnly = true;
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
            // Column13
            // 
            Column13.HeaderText = "customerID";
            Column13.Name = "Column13";
            Column13.ReadOnly = true;
            Column13.Visible = false;
            Column13.Width = 129;
            // 
            // Column14
            // 
            Column14.HeaderText = "registerVehicleId";
            Column14.Name = "Column14";
            Column14.ReadOnly = true;
            Column14.Visible = false;
            Column14.Width = 170;
            // 
            // Column4
            // 
            Column4.HeaderText = "Làn vào";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // Column10
            // 
            Column10.HeaderText = "Nhóm";
            Column10.Name = "Column10";
            Column10.ReadOnly = true;
            Column10.Width = 89;
            // 
            // Column12
            // 
            Column12.HeaderText = "Biển số đăng ký";
            Column12.Name = "Column12";
            Column12.ReadOnly = true;
            Column12.Width = 161;
            // 
            // Column11
            // 
            Column11.HeaderText = "Khách hàng";
            Column11.Name = "Column11";
            Column11.ReadOnly = true;
            Column11.Width = 131;
            // 
            // Column3
            // 
            Column3.HeaderText = "Xem Thêm";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Visible = false;
            Column3.Width = 103;
            // 
            // Column17
            // 
            Column17.HeaderText = "Phân loại";
            Column17.Name = "Column17";
            Column17.ReadOnly = true;
            Column17.Width = 113;
            // 
            // Column18
            // 
            Column18.HeaderText = "Số phiếu xuất";
            Column18.Name = "Column18";
            Column18.ReadOnly = true;
            Column18.Width = 146;
            // 
            // frmReportIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 460);
            Controls.Add(panelData);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmReportIn";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Xe đang trong bãi";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)picOverviewImageIn).EndInit();
            ((System.ComponentModel.ISupportInitialize)picVehicleImageIn).EndInit();
            tablePic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            panelData.ResumeLayout(false);
            panelData.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private MovablePictureBox picOverviewImageIn;
        private MovablePictureBox picVehicleImageIn;
        private TableLayoutPanel tablePic;
        private Label lblKeyword;
        private TextBox txtKeyword;
        private DataGridView dgvData;
        private DateTimePicker dtpEndTime;
        private DateTimePicker dtpStartTime;
        private Label lblEndTime;
        private Label lblStartTime;
        private Usercontrols.ucPages ucPages1;
        private Label lblTotalEvents;
        private LblCancel btnCancel;
        private BtnSearch btnSearch;
        private BtnExcel btnExportExcel;
        private Panel panelData;
        private Usercontrols.BuildControls.ucNotify ucNotify1;
        private Usercontrols.BuildControls.ucLoading ucLoading1;
        private ucEventInInfo ucEventInInfo1;
        private Label lblIdentityType;
        private Label lblVehicleType;
        private ComboBox cbIdentityGroupType;
        private ComboBox cbVehicleType;
        private ComboBox cbLane;
        private Label lblLane;
        private Label lblTitle;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column15;
        private DataGridViewTextBoxColumn Column16;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column13;
        private DataGridViewTextBoxColumn Column14;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewTextBoxColumn Column12;
        private DataGridViewTextBoxColumn Column11;
        private DataGridViewButtonColumn Column3;
        private DataGridViewTextBoxColumn Column17;
        private DataGridViewTextBoxColumn Column18;
    }
}