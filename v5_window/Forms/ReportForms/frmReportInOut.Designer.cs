using iParkingv5_window.Usercontrols;

namespace iParkingv5_window.Forms.ReportForms
{
    partial class frmReportInOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportInOut));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dtpEndTime = new DateTimePicker();
            dtpStartTime = new DateTimePicker();
            lblStartTime = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            picOverviewImageIn = new MovablePictureBox();
            picVehicleImageIn = new MovablePictureBox();
            lblKeyword = new Label();
            txtKeyword = new TextBox();
            dgvData = new DataGridView();
            lblEndTime = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            picOverviewImageOut = new MovablePictureBox();
            picVehicleImageOut = new MovablePictureBox();
            ucPages1 = new ucPages();
            lblPage = new Label();
            lblTotalEvents = new Label();
            btnCancel = new Controls.Buttons.LblCancel();
            btnSearch = new Controls.Buttons.LblSearch();
            btnExportExcel = new Controls.Buttons.LblExcel();
            panelData = new Panel();
            ucNotify1 = new Usercontrols.BuildControls.ucNotify();
            ucLoading1 = new Usercontrols.BuildControls.ucLoading();
            tablePic = new TableLayoutPanel();
            Column1 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column10 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column11 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column13 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column12 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            Column14 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewButtonColumn();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picOverviewImageIn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picVehicleImageIn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picOverviewImageOut).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picVehicleImageOut).BeginInit();
            panelData.SuspendLayout();
            tablePic.SuspendLayout();
            SuspendLayout();
            // 
            // dtpEndTime
            // 
            dtpEndTime.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(369, 36);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.Size = new Size(210, 27);
            dtpEndTime.TabIndex = 45;
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(76, 36);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.Size = new Size(210, 27);
            dtpStartTime.TabIndex = 46;
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.BackColor = Color.Transparent;
            lblStartTime.Location = new Point(10, 41);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(60, 20);
            lblStartTime.TabIndex = 44;
            lblStartTime.Text = "Bắt đầu";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(picOverviewImageIn, 0, 0);
            tableLayoutPanel1.Controls.Add(picVehicleImageIn, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(224, 434);
            tableLayoutPanel1.TabIndex = 53;
            // 
            // picOverviewImageIn
            // 
            picOverviewImageIn.BorderStyle = BorderStyle.FixedSingle;
            picOverviewImageIn.Dock = DockStyle.Fill;
            picOverviewImageIn.Image = (Image)resources.GetObject("picOverviewImageIn.Image");
            picOverviewImageIn.Location = new Point(0, 0);
            picOverviewImageIn.Margin = new Padding(0);
            picOverviewImageIn.Name = "picOverviewImageIn";
            picOverviewImageIn.Size = new Size(224, 217);
            picOverviewImageIn.SizeMode = PictureBoxSizeMode.StretchImage;
            picOverviewImageIn.TabIndex = 30;
            picOverviewImageIn.TabStop = false;
            // 
            // picVehicleImageIn
            // 
            picVehicleImageIn.BorderStyle = BorderStyle.FixedSingle;
            picVehicleImageIn.Dock = DockStyle.Fill;
            picVehicleImageIn.Image = (Image)resources.GetObject("picVehicleImageIn.Image");
            picVehicleImageIn.Location = new Point(0, 217);
            picVehicleImageIn.Margin = new Padding(0);
            picVehicleImageIn.Name = "picVehicleImageIn";
            picVehicleImageIn.Size = new Size(224, 217);
            picVehicleImageIn.SizeMode = PictureBoxSizeMode.StretchImage;
            picVehicleImageIn.TabIndex = 29;
            picVehicleImageIn.TabStop = false;
            // 
            // lblKeyword
            // 
            lblKeyword.AutoSize = true;
            lblKeyword.BackColor = Color.Transparent;
            lblKeyword.Location = new Point(8, 7);
            lblKeyword.Name = "lblKeyword";
            lblKeyword.Size = new Size(62, 20);
            lblKeyword.TabIndex = 52;
            lblKeyword.Text = "Từ khóa";
            // 
            // txtKeyword
            // 
            txtKeyword.Location = new Point(76, 3);
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
            dgvData.Columns.AddRange(new DataGridViewColumn[] { Column1, Column4, Column2, Column7, Column10, Column8, Column11, Column5, Column13, Column6, Column12, Column9, Column14, Column3 });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11.25F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new Padding(3);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvData.DefaultCellStyle = dataGridViewCellStyle3;
            dgvData.Location = new Point(8, 92);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowHeadersVisible = false;
            dgvData.RowTemplate.Height = 29;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.Size = new Size(515, 434);
            dgvData.TabIndex = 50;
            // 
            // lblEndTime
            // 
            lblEndTime.AutoSize = true;
            lblEndTime.BackColor = Color.Transparent;
            lblEndTime.Location = new Point(300, 41);
            lblEndTime.Name = "lblEndTime";
            lblEndTime.Size = new Size(63, 20);
            lblEndTime.TabIndex = 43;
            lblEndTime.Text = "Kết thúc";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(picOverviewImageOut, 0, 0);
            tableLayoutPanel2.Controls.Add(picVehicleImageOut, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(224, 0);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(224, 434);
            tableLayoutPanel2.TabIndex = 53;
            // 
            // picOverviewImageOut
            // 
            picOverviewImageOut.BorderStyle = BorderStyle.FixedSingle;
            picOverviewImageOut.Dock = DockStyle.Fill;
            picOverviewImageOut.Image = (Image)resources.GetObject("picOverviewImageOut.Image");
            picOverviewImageOut.Location = new Point(0, 0);
            picOverviewImageOut.Margin = new Padding(0);
            picOverviewImageOut.Name = "picOverviewImageOut";
            picOverviewImageOut.Size = new Size(224, 217);
            picOverviewImageOut.SizeMode = PictureBoxSizeMode.StretchImage;
            picOverviewImageOut.TabIndex = 30;
            picOverviewImageOut.TabStop = false;
            // 
            // picVehicleImageOut
            // 
            picVehicleImageOut.BorderStyle = BorderStyle.FixedSingle;
            picVehicleImageOut.Dock = DockStyle.Fill;
            picVehicleImageOut.Image = (Image)resources.GetObject("picVehicleImageOut.Image");
            picVehicleImageOut.Location = new Point(0, 217);
            picVehicleImageOut.Margin = new Padding(0);
            picVehicleImageOut.Name = "picVehicleImageOut";
            picVehicleImageOut.Size = new Size(224, 217);
            picVehicleImageOut.SizeMode = PictureBoxSizeMode.StretchImage;
            picVehicleImageOut.TabIndex = 29;
            picVehicleImageOut.TabStop = false;
            // 
            // ucPages1
            // 
            ucPages1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ucPages1.BorderStyle = BorderStyle.Fixed3D;
            ucPages1.Location = new Point(8, 551);
            ucPages1.Name = "ucPages1";
            ucPages1.Size = new Size(981, 48);
            ucPages1.TabIndex = 54;
            ucPages1.Visible = false;
            // 
            // lblPage
            // 
            lblPage.AutoSize = true;
            lblPage.BackColor = Color.Transparent;
            lblPage.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblPage.ForeColor = Color.Navy;
            lblPage.Location = new Point(710, 7);
            lblPage.Name = "lblPage";
            lblPage.Size = new Size(64, 25);
            lblPage.TabIndex = 55;
            lblPage.Text = "Trang";
            lblPage.Visible = false;
            // 
            // lblTotalEvents
            // 
            lblTotalEvents.AutoSize = true;
            lblTotalEvents.BackColor = Color.Transparent;
            lblTotalEvents.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalEvents.ForeColor = Color.Navy;
            lblTotalEvents.Location = new Point(710, 38);
            lblTotalEvents.Name = "lblTotalEvents";
            lblTotalEvents.Size = new Size(153, 25);
            lblTotalEvents.TabIndex = 56;
            lblTotalEvents.Text = "Tổng số sự kiện";
            lblTotalEvents.Visible = false;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.AutoSize = true;
            btnCancel.BorderStyle = BorderStyle.Fixed3D;
            btnCancel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(928, 623);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(49, 22);
            btnCancel.TabIndex = 57;
            btnCancel.Text = "Đóng";
            // 
            // btnSearch
            // 
            btnSearch.AutoSize = true;
            btnSearch.BorderStyle = BorderStyle.Fixed3D;
            btnSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnSearch.ForeColor = Color.Black;
            btnSearch.Location = new Point(585, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(76, 22);
            btnSearch.TabIndex = 58;
            btnSearch.Text = "Tìm kiếm";
            // 
            // btnExportExcel
            // 
            btnExportExcel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExportExcel.AutoSize = true;
            btnExportExcel.BorderStyle = BorderStyle.Fixed3D;
            btnExportExcel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnExportExcel.Location = new Point(850, 623);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(72, 22);
            btnExportExcel.TabIndex = 59;
            btnExportExcel.Text = "lblExcel1";
            // 
            // panelData
            // 
            panelData.Controls.Add(ucNotify1);
            panelData.Controls.Add(ucLoading1);
            panelData.Controls.Add(tablePic);
            panelData.Controls.Add(txtKeyword);
            panelData.Controls.Add(btnExportExcel);
            panelData.Controls.Add(lblEndTime);
            panelData.Controls.Add(btnCancel);
            panelData.Controls.Add(btnSearch);
            panelData.Controls.Add(ucPages1);
            panelData.Controls.Add(lblTotalEvents);
            panelData.Controls.Add(lblKeyword);
            panelData.Controls.Add(lblPage);
            panelData.Controls.Add(dgvData);
            panelData.Controls.Add(lblStartTime);
            panelData.Controls.Add(dtpStartTime);
            panelData.Controls.Add(dtpEndTime);
            panelData.Dock = DockStyle.Fill;
            panelData.Location = new Point(0, 0);
            panelData.Name = "panelData";
            panelData.Size = new Size(1016, 660);
            panelData.TabIndex = 60;
            // 
            // ucNotify1
            // 
            ucNotify1.BackColor = Color.FromArgb(255, 224, 192);
            ucNotify1.Location = new Point(597, 49);
            ucNotify1.MaximumSize = new Size(333, 356);
            ucNotify1.Message = "Nội dung thông báo";
            ucNotify1.MinimumSize = new Size(333, 356);
            ucNotify1.Name = "ucNotify1";
            ucNotify1.NotiType = Usercontrols.BuildControls.ucNotify.EmNotiType.Information;
            ucNotify1.Size = new Size(333, 356);
            ucNotify1.TabIndex = 62;
            // 
            // ucLoading1
            // 
            ucLoading1.BackColor = Color.FromArgb(255, 224, 192);
            ucLoading1.Language = IPaking.Ultility.TextManagement.EmLanguage.Vietnamese;
            ucLoading1.Location = new Point(609, 36);
            ucLoading1.Message = "Preparing to download";
            ucLoading1.Name = "ucLoading1";
            ucLoading1.Size = new Size(392, 188);
            ucLoading1.TabIndex = 61;
            // 
            // tablePic
            // 
            tablePic.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tablePic.ColumnCount = 2;
            tablePic.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tablePic.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tablePic.Controls.Add(tableLayoutPanel1, 0, 0);
            tablePic.Controls.Add(tableLayoutPanel2, 1, 0);
            tablePic.Location = new Point(541, 92);
            tablePic.Margin = new Padding(0);
            tablePic.Name = "tablePic";
            tablePic.RowCount = 1;
            tablePic.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tablePic.Size = new Size(448, 434);
            tablePic.TabIndex = 60;
            // 
            // Column1
            // 
            Column1.HeaderText = "STT";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 68;
            // 
            // Column4
            // 
            Column4.HeaderText = "Định Danh";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Visible = false;
            Column4.Width = 123;
            // 
            // Column2
            // 
            Column2.HeaderText = "Định danh ra";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Visible = false;
            Column2.Width = 140;
            // 
            // Column7
            // 
            Column7.HeaderText = "Biển Số Xe Vào";
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            Column7.Width = 154;
            // 
            // Column10
            // 
            Column10.HeaderText = "Biển Số Xe ra";
            Column10.Name = "Column10";
            Column10.ReadOnly = true;
            Column10.Width = 140;
            // 
            // Column8
            // 
            Column8.HeaderText = "Giờ Vào";
            Column8.Name = "Column8";
            Column8.ReadOnly = true;
            // 
            // Column11
            // 
            Column11.HeaderText = "Giờ Ra";
            Column11.Name = "Column11";
            Column11.ReadOnly = true;
            Column11.Width = 90;
            // 
            // Column5
            // 
            Column5.HeaderText = "Làn Vào";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.Visible = false;
            Column5.Width = 101;
            // 
            // Column13
            // 
            Column13.HeaderText = "Làn Ra";
            Column13.Name = "Column13";
            Column13.ReadOnly = true;
            Column13.Visible = false;
            Column13.Width = 91;
            // 
            // Column6
            // 
            Column6.HeaderText = "Người Dùng Vào";
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            Column6.Visible = false;
            Column6.Width = 169;
            // 
            // Column12
            // 
            Column12.HeaderText = "Người Dùng Ra";
            Column12.Name = "Column12";
            Column12.ReadOnly = true;
            Column12.Visible = false;
            Column12.Width = 159;
            // 
            // Column9
            // 
            Column9.HeaderText = "physicalFileIdIns";
            Column9.Name = "Column9";
            Column9.ReadOnly = true;
            Column9.Visible = false;
            Column9.Width = 168;
            // 
            // Column14
            // 
            Column14.HeaderText = "physicalIdOuts";
            Column14.Name = "Column14";
            Column14.ReadOnly = true;
            Column14.Visible = false;
            Column14.Width = 154;
            // 
            // Column3
            // 
            Column3.HeaderText = "Xem thêm";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // frmReportInOut
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1016, 660);
            Controls.Add(panelData);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmReportInOut";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Xe ra khỏi bãi";
            WindowState = FormWindowState.Maximized;
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picOverviewImageIn).EndInit();
            ((System.ComponentModel.ISupportInitialize)picVehicleImageIn).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picOverviewImageOut).EndInit();
            ((System.ComponentModel.ISupportInitialize)picVehicleImageOut).EndInit();
            panelData.ResumeLayout(false);
            panelData.PerformLayout();
            tablePic.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private DateTimePicker dtpEndTime;
        private DateTimePicker dtpStartTime;
        private Label lblStartTime;
        private TableLayoutPanel tableLayoutPanel1;
        private MovablePictureBox picOverviewImageIn;
        private MovablePictureBox picVehicleImageIn;
        private Label lblKeyword;
        private TextBox txtKeyword;
        private DataGridView dgvData;
        private Label lblEndTime;
        private TableLayoutPanel tableLayoutPanel2;
        private MovablePictureBox picOverviewImageOut;
        private MovablePictureBox picVehicleImageOut;
        private Usercontrols.ucPages ucPages1;
        private Label lblPage;
        private Label lblTotalEvents;
        private Controls.Buttons.LblCancel btnCancel;
        private Controls.Buttons.LblSearch btnSearch;
        private Controls.Buttons.LblExcel btnExportExcel;
        private Panel panelData;
        private TableLayoutPanel tablePic;
        private Usercontrols.BuildControls.ucNotify ucNotify1;
        private Usercontrols.BuildControls.ucLoading ucLoading1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column11;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column13;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column12;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column14;
        private DataGridViewButtonColumn Column3;
    }
}