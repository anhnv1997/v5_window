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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportIn));
            this.picOverviewImageIn = new iParkingv5_window.Usercontrols.MovablePictureBox();
            this.picVehicleImageIn = new iParkingv5_window.Usercontrols.MovablePictureBox();
            this.tablePic = new System.Windows.Forms.TableLayoutPanel();
            this.lblKeyword = new System.Windows.Forms.Label();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.ucPages1 = new iParkingv5_window.Usercontrols.ucPages();
            this.lblTotalEvents = new System.Windows.Forms.Label();
            this.btnCancel = new iPakrkingv5.Controls.Controls.Buttons.LblCancel();
            this.btnSearch = new iPakrkingv5.Controls.Controls.Buttons.BtnSearch();
            this.btnExportExcel = new iPakrkingv5.Controls.Controls.Buttons.BtnExcel();
            this.panelData = new System.Windows.Forms.Panel();
            this.btnWriteInOut = new iPakrkingv5.Controls.Controls.Buttons.BtnWriteInOut();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cbLane = new System.Windows.Forms.ComboBox();
            this.cbIdentityGroupType = new System.Windows.Forms.ComboBox();
            this.cbVehicleType = new System.Windows.Forms.ComboBox();
            this.ucEventInInfo1 = new iParkingv5_window.Usercontrols.ucEventInInfo();
            this.ucNotify1 = new iParkingv5_window.Usercontrols.BuildControls.ucNotify();
            this.ucLoading1 = new iParkingv5_window.Usercontrols.BuildControls.ucLoading();
            this.lblLane = new System.Windows.Forms.Label();
            this.lblVehicleType = new System.Windows.Forms.Label();
            this.lblIdentityType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picOverviewImageIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVehicleImageIn)).BeginInit();
            this.tablePic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.panelData.SuspendLayout();
            this.SuspendLayout();
            // 
            // picOverviewImageIn
            // 
            this.picOverviewImageIn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picOverviewImageIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picOverviewImageIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picOverviewImageIn.Location = new System.Drawing.Point(0, 0);
            this.picOverviewImageIn.Margin = new System.Windows.Forms.Padding(0);
            this.picOverviewImageIn.Name = "picOverviewImageIn";
            this.picOverviewImageIn.Size = new System.Drawing.Size(215, 154);
            this.picOverviewImageIn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picOverviewImageIn.TabIndex = 30;
            this.picOverviewImageIn.TabStop = false;
            // 
            // picVehicleImageIn
            // 
            this.picVehicleImageIn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picVehicleImageIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picVehicleImageIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picVehicleImageIn.Location = new System.Drawing.Point(0, 154);
            this.picVehicleImageIn.Margin = new System.Windows.Forms.Padding(0);
            this.picVehicleImageIn.Name = "picVehicleImageIn";
            this.picVehicleImageIn.Size = new System.Drawing.Size(215, 154);
            this.picVehicleImageIn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picVehicleImageIn.TabIndex = 29;
            this.picVehicleImageIn.TabStop = false;
            // 
            // tablePic
            // 
            this.tablePic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablePic.ColumnCount = 1;
            this.tablePic.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePic.Controls.Add(this.picOverviewImageIn, 0, 0);
            this.tablePic.Controls.Add(this.picVehicleImageIn, 0, 1);
            this.tablePic.Location = new System.Drawing.Point(681, 68);
            this.tablePic.Margin = new System.Windows.Forms.Padding(0);
            this.tablePic.Name = "tablePic";
            this.tablePic.RowCount = 2;
            this.tablePic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePic.Size = new System.Drawing.Size(215, 308);
            this.tablePic.TabIndex = 42;
            // 
            // lblKeyword
            // 
            this.lblKeyword.AutoSize = true;
            this.lblKeyword.BackColor = System.Drawing.Color.Transparent;
            this.lblKeyword.Location = new System.Drawing.Point(10, 25);
            this.lblKeyword.Name = "lblKeyword";
            this.lblKeyword.Size = new System.Drawing.Size(49, 15);
            this.lblKeyword.TabIndex = 41;
            this.lblKeyword.Text = "Từ khóa";
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(69, 22);
            this.txtKeyword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(184, 23);
            this.txtKeyword.TabIndex = 1;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column7,
            this.Column8,
            this.Column5,
            this.Column6,
            this.Column9,
            this.Column13,
            this.Column14,
            this.Column4,
            this.Column10,
            this.Column12,
            this.Column11,
            this.Column3});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvData.Location = new System.Drawing.Point(7, 119);
            this.dgvData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowTemplate.Height = 29;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(666, 256);
            this.dgvData.TabIndex = 39;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "STT";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 68;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tên Định Danh";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            this.Column2.Width = 154;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Biển Số Xe";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 121;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Giờ Vào";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Làn Vào";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            this.Column5.Width = 101;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Người Dùng";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            this.Column6.Width = 136;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "physicalFileIds";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Visible = false;
            this.Column9.Width = 153;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "customerID";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Visible = false;
            this.Column13.Width = 129;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "registerVehicleId";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Visible = false;
            this.Column14.Width = 170;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Làn vào";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Nhóm";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 89;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Biển số đăng ký";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 161;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Khách hàng";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 131;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Xem Thêm";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 103;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(334, 45);
            this.dtpEndTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(184, 23);
            this.dtpEndTime.TabIndex = 3;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(69, 46);
            this.dtpStartTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(184, 23);
            this.dtpStartTime.TabIndex = 2;
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.BackColor = System.Drawing.Color.Transparent;
            this.lblEndTime.Location = new System.Drawing.Point(265, 50);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(57, 15);
            this.lblEndTime.TabIndex = 32;
            this.lblEndTime.Text = "Kết thúc  ";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.BackColor = System.Drawing.Color.Transparent;
            this.lblStartTime.Location = new System.Drawing.Point(11, 50);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(47, 15);
            this.lblStartTime.TabIndex = 33;
            this.lblStartTime.Text = "Bắt đầu";
            // 
            // ucPages1
            // 
            this.ucPages1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPages1.BackColor = System.Drawing.Color.Transparent;
            this.ucPages1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ucPages1.Location = new System.Drawing.Point(3, 391);
            this.ucPages1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucPages1.Name = "ucPages1";
            this.ucPages1.Size = new System.Drawing.Size(887, 37);
            this.ucPages1.TabIndex = 43;
            this.ucPages1.Visible = false;
            // 
            // lblTotalEvents
            // 
            this.lblTotalEvents.AutoSize = true;
            this.lblTotalEvents.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalEvents.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalEvents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(149)))), ((int)(((byte)(40)))));
            this.lblTotalEvents.Location = new System.Drawing.Point(523, 26);
            this.lblTotalEvents.Name = "lblTotalEvents";
            this.lblTotalEvents.Size = new System.Drawing.Size(153, 25);
            this.lblTotalEvents.TabIndex = 58;
            this.lblTotalEvents.Text = "Tổng số sự kiện";
            this.lblTotalEvents.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoSize = true;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(829, 423);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(57, 30);
            this.btnCancel.TabIndex = 59;
            this.btnCancel.Text = "Đóng";
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSize = true;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(523, 68);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(84, 30);
            this.btnSearch.TabIndex = 60;
            this.btnSearch.Text = "Tìm kiếm";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.AutoSize = true;
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnExportExcel.Location = new System.Drawing.Point(746, 423);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(80, 30);
            this.btnExportExcel.TabIndex = 61;
            this.btnExportExcel.Text = "lblExcel1";
            // 
            // panelData
            // 
            this.panelData.Controls.Add(this.btnWriteInOut);
            this.panelData.Controls.Add(this.lblTitle);
            this.panelData.Controls.Add(this.cbLane);
            this.panelData.Controls.Add(this.cbIdentityGroupType);
            this.panelData.Controls.Add(this.cbVehicleType);
            this.panelData.Controls.Add(this.ucEventInInfo1);
            this.panelData.Controls.Add(this.ucNotify1);
            this.panelData.Controls.Add(this.ucLoading1);
            this.panelData.Controls.Add(this.lblKeyword);
            this.panelData.Controls.Add(this.btnExportExcel);
            this.panelData.Controls.Add(this.lblLane);
            this.panelData.Controls.Add(this.lblVehicleType);
            this.panelData.Controls.Add(this.lblIdentityType);
            this.panelData.Controls.Add(this.lblStartTime);
            this.panelData.Controls.Add(this.btnCancel);
            this.panelData.Controls.Add(this.btnSearch);
            this.panelData.Controls.Add(this.ucPages1);
            this.panelData.Controls.Add(this.lblTotalEvents);
            this.panelData.Controls.Add(this.tablePic);
            this.panelData.Controls.Add(this.lblEndTime);
            this.panelData.Controls.Add(this.dgvData);
            this.panelData.Controls.Add(this.dtpStartTime);
            this.panelData.Controls.Add(this.dtpEndTime);
            this.panelData.Controls.Add(this.txtKeyword);
            this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelData.Location = new System.Drawing.Point(0, 0);
            this.panelData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(896, 460);
            this.panelData.TabIndex = 62;
            // 
            // btnWriteInOut
            // 
            this.btnWriteInOut.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnWriteInOut.Location = new System.Drawing.Point(613, 69);
            this.btnWriteInOut.Name = "btnWriteInOut";
            this.btnWriteInOut.Size = new System.Drawing.Size(75, 23);
            this.btnWriteInOut.TabIndex = 66;
            this.btnWriteInOut.Text = "btnWriteInOut1";
            this.btnWriteInOut.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(10, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(29, 15);
            this.lblTitle.TabIndex = 65;
            this.lblTitle.Text = "Title";
            // 
            // cbLane
            // 
            this.cbLane.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLane.FormattingEnabled = true;
            this.cbLane.Location = new System.Drawing.Point(334, 70);
            this.cbLane.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbLane.Name = "cbLane";
            this.cbLane.Size = new System.Drawing.Size(184, 23);
            this.cbLane.TabIndex = 5;
            // 
            // cbIdentityGroupType
            // 
            this.cbIdentityGroupType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIdentityGroupType.FormattingEnabled = true;
            this.cbIdentityGroupType.Location = new System.Drawing.Point(334, 20);
            this.cbIdentityGroupType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbIdentityGroupType.Name = "cbIdentityGroupType";
            this.cbIdentityGroupType.Size = new System.Drawing.Size(184, 23);
            this.cbIdentityGroupType.TabIndex = 5;
            // 
            // cbVehicleType
            // 
            this.cbVehicleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVehicleType.FormattingEnabled = true;
            this.cbVehicleType.Location = new System.Drawing.Point(69, 71);
            this.cbVehicleType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbVehicleType.Name = "cbVehicleType";
            this.cbVehicleType.Size = new System.Drawing.Size(184, 23);
            this.cbVehicleType.TabIndex = 4;
            // 
            // ucEventInInfo1
            // 
            this.ucEventInInfo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ucEventInInfo1.Location = new System.Drawing.Point(534, 42);
            this.ucEventInInfo1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucEventInInfo1.Name = "ucEventInInfo1";
            this.ucEventInInfo1.Size = new System.Drawing.Size(432, 470);
            this.ucEventInInfo1.TabIndex = 64;
            // 
            // ucNotify1
            // 
            this.ucNotify1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ucNotify1.Location = new System.Drawing.Point(511, 49);
            this.ucNotify1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucNotify1.MaximumSize = new System.Drawing.Size(291, 267);
            this.ucNotify1.Message = "Nội dung thông báo";
            this.ucNotify1.MinimumSize = new System.Drawing.Size(291, 267);
            this.ucNotify1.Name = "ucNotify1";
            this.ucNotify1.NotiType = iParkingv5_window.Usercontrols.BuildControls.ucNotify.EmNotiType.Information;
            this.ucNotify1.Size = new System.Drawing.Size(291, 267);
            this.ucNotify1.TabIndex = 63;
            // 
            // ucLoading1
            // 
            this.ucLoading1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ucLoading1.Language = IPaking.Ultility.TextManagement.EmLanguage.Vietnamese;
            this.ucLoading1.Location = new System.Drawing.Point(552, 38);
            this.ucLoading1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucLoading1.Message = "Preparing to download";
            this.ucLoading1.Name = "ucLoading1";
            this.ucLoading1.Size = new System.Drawing.Size(343, 141);
            this.ucLoading1.TabIndex = 62;
            // 
            // lblLane
            // 
            this.lblLane.AutoSize = true;
            this.lblLane.BackColor = System.Drawing.Color.Transparent;
            this.lblLane.Location = new System.Drawing.Point(267, 75);
            this.lblLane.Name = "lblLane";
            this.lblLane.Size = new System.Drawing.Size(26, 15);
            this.lblLane.TabIndex = 33;
            this.lblLane.Text = "Làn";
            // 
            // lblVehicleType
            // 
            this.lblVehicleType.AutoSize = true;
            this.lblVehicleType.BackColor = System.Drawing.Color.Transparent;
            this.lblVehicleType.Location = new System.Drawing.Point(11, 76);
            this.lblVehicleType.Name = "lblVehicleType";
            this.lblVehicleType.Size = new System.Drawing.Size(44, 15);
            this.lblVehicleType.TabIndex = 33;
            this.lblVehicleType.Text = "Loại xe";
            // 
            // lblIdentityType
            // 
            this.lblIdentityType.AutoSize = true;
            this.lblIdentityType.BackColor = System.Drawing.Color.Transparent;
            this.lblIdentityType.Location = new System.Drawing.Point(265, 26);
            this.lblIdentityType.Name = "lblIdentityType";
            this.lblIdentityType.Size = new System.Drawing.Size(61, 15);
            this.lblIdentityType.TabIndex = 33;
            this.lblIdentityType.Text = "Nhóm thẻ";
            // 
            // frmReportIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 460);
            this.Controls.Add(this.panelData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmReportIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xe đang trong bãi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.picOverviewImageIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVehicleImageIn)).EndInit();
            this.tablePic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.panelData.ResumeLayout(false);
            this.panelData.PerformLayout();
            this.ResumeLayout(false);

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
        private BtnWriteInOut btnWriteInOut;
    }
}