using iPakrkingv5.Controls.Controls.Buttons;
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportInOut));
            dtpEndTime = new DateTimePicker();
            dtpStartTime = new DateTimePicker();
            lblStartTime = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            picOverviewImageIn = new MovablePictureBox();
            picVehicleImageIn = new MovablePictureBox();
            lblKeyword = new Label();
            txtKeyword = new TextBox();
            dgvData = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column11 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column18 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column10 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column15 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column12 = new DataGridViewTextBoxColumn();
            Column13 = new DataGridViewTextBoxColumn();
            Column19 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            Column14 = new DataGridViewTextBoxColumn();
            Column17 = new DataGridViewTextBoxColumn();
            Column16 = new DataGridViewTextBoxColumn();
            lblEndTime = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            picOverviewImageOut = new MovablePictureBox();
            picVehicleImageOut = new MovablePictureBox();
            ucPages1 = new ucPages();
            lblTotalEvents = new Label();
            btnCancel = new LblCancel();
            btnSearch = new BtnSearch();
            btnExportExcel = new BtnExcel();
            panelData = new Panel();
            lblUser = new Label();
            cbUser = new ComboBox();
            cbLane = new ComboBox();
            lblLane = new Label();
            cbIdentityGroup = new ComboBox();
            cbVehicleType = new ComboBox();
            lblVehicleType = new Label();
            lblIdentityGroup = new Label();
            lblMoney = new Label();
            ucEventOutInfo1 = new ucEventOutInfo();
            ucNotify1 = new Usercontrols.BuildControls.ucNotify();
            ucLoading1 = new Usercontrols.BuildControls.ucLoading();
            tablePic = new TableLayoutPanel();
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
            dtpEndTime.Font = new Font("Segoe UI", 12F);
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(463, 47);
            dtpEndTime.Margin = new Padding(3, 2, 3, 2);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.Size = new Size(250, 29);
            dtpEndTime.TabIndex = 3;
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            dtpStartTime.Font = new Font("Segoe UI", 12F);
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(101, 50);
            dtpStartTime.Margin = new Padding(3, 2, 3, 2);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.Size = new Size(250, 29);
            dtpStartTime.TabIndex = 2;
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.BackColor = Color.Transparent;
            lblStartTime.Font = new Font("Segoe UI", 12F);
            lblStartTime.Location = new Point(13, 47);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(62, 21);
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
            tableLayoutPanel1.Size = new Size(196, 287);
            tableLayoutPanel1.TabIndex = 53;
            // 
            // picOverviewImageIn
            // 
            picOverviewImageIn.BackColor = Color.WhiteSmoke;
            picOverviewImageIn.BorderStyle = BorderStyle.FixedSingle;
            picOverviewImageIn.Dock = DockStyle.Fill;
            picOverviewImageIn.Location = new Point(0, 0);
            picOverviewImageIn.Margin = new Padding(0);
            picOverviewImageIn.Name = "picOverviewImageIn";
            picOverviewImageIn.Size = new Size(196, 143);
            picOverviewImageIn.SizeMode = PictureBoxSizeMode.StretchImage;
            picOverviewImageIn.TabIndex = 30;
            picOverviewImageIn.TabStop = false;
            picOverviewImageIn.LoadCompleted += Pic_LoadCompleted;
            // 
            // picVehicleImageIn
            // 
            picVehicleImageIn.BackColor = Color.WhiteSmoke;
            picVehicleImageIn.BorderStyle = BorderStyle.FixedSingle;
            picVehicleImageIn.Dock = DockStyle.Fill;
            picVehicleImageIn.Location = new Point(0, 143);
            picVehicleImageIn.Margin = new Padding(0);
            picVehicleImageIn.Name = "picVehicleImageIn";
            picVehicleImageIn.Size = new Size(196, 144);
            picVehicleImageIn.SizeMode = PictureBoxSizeMode.StretchImage;
            picVehicleImageIn.TabIndex = 29;
            picVehicleImageIn.TabStop = false;
            picVehicleImageIn.LoadCompleted += Pic_LoadCompleted;
            // 
            // lblKeyword
            // 
            lblKeyword.AutoSize = true;
            lblKeyword.BackColor = Color.Transparent;
            lblKeyword.Font = new Font("Segoe UI", 12F);
            lblKeyword.Location = new Point(11, 13);
            lblKeyword.Name = "lblKeyword";
            lblKeyword.Size = new Size(65, 21);
            lblKeyword.TabIndex = 52;
            lblKeyword.Text = "Từ khóa";
            // 
            // txtKeyword
            // 
            txtKeyword.Font = new Font("Segoe UI", 12F);
            txtKeyword.Location = new Point(101, 14);
            txtKeyword.Margin = new Padding(3, 2, 3, 2);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.Size = new Size(612, 29);
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
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Columns.AddRange(new DataGridViewColumn[] { Column1, Column8, Column11, Column3, Column2, Column18, Column7, Column10, Column4, Column5, Column15, Column6, Column12, Column13, Column19, Column9, Column14, Column17, Column16 });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.Padding = new Padding(3);
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvData.DefaultCellStyle = dataGridViewCellStyle4;
            dgvData.Location = new Point(12, 187);
            dgvData.Margin = new Padding(3, 2, 3, 2);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowHeadersVisible = false;
            dgvData.RowTemplate.Height = 29;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.Size = new Size(632, 287);
            dgvData.TabIndex = 50;
            dgvData.CellMouseClick += dgvData_CellMouseClick;
            dgvData.MouseClick += dgvData_MouseClick;
            // 
            // Column1
            // 
            Column1.Frozen = true;
            Column1.HeaderText = "STT";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 66;
            // 
            // Column8
            // 
            Column8.HeaderText = "Giờ Vào";
            Column8.Name = "Column8";
            Column8.ReadOnly = true;
            Column8.Width = 96;
            // 
            // Column11
            // 
            Column11.HeaderText = "Giờ Ra";
            Column11.Name = "Column11";
            Column11.ReadOnly = true;
            Column11.Width = 88;
            // 
            // Column3
            // 
            Column3.HeaderText = "Thời Gian Lưu Bãi";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 163;
            // 
            // Column2
            // 
            Column2.HeaderText = "Vé Xe";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 79;
            // 
            // Column18
            // 
            Column18.HeaderText = "Loại";
            Column18.Name = "Column18";
            Column18.ReadOnly = true;
            Column18.Width = 70;
            // 
            // Column7
            // 
            Column7.HeaderText = "Biển Số Vào";
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            Column7.Width = 123;
            // 
            // Column10
            // 
            Column10.HeaderText = "Biển Số Ra";
            Column10.Name = "Column10";
            Column10.ReadOnly = true;
            Column10.Width = 115;
            // 
            // Column4
            // 
            Column4.HeaderText = "Phân Loại";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Width = 109;
            // 
            // Column5
            // 
            Column5.HeaderText = "Số phiếu xuất";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.Width = 135;
            // 
            // Column15
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            Column15.DefaultCellStyle = dataGridViewCellStyle3;
            Column15.HeaderText = "Phí";
            Column15.Name = "Column15";
            Column15.ReadOnly = true;
            Column15.Width = 63;
            // 
            // Column6
            // 
            Column6.HeaderText = "Người Dùng Vào";
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            Column6.Width = 157;
            // 
            // Column12
            // 
            Column12.HeaderText = "Người Dùng Ra";
            Column12.Name = "Column12";
            Column12.ReadOnly = true;
            Column12.Width = 149;
            // 
            // Column13
            // 
            Column13.HeaderText = "Mẫu hóa đơn";
            Column13.Name = "Column13";
            Column13.ReadOnly = true;
            Column13.Width = 134;
            // 
            // Column19
            // 
            Column19.HeaderText = "Số hóa đơn";
            Column19.Name = "Column19";
            Column19.ReadOnly = true;
            Column19.Width = 121;
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
            // Column17
            // 
            Column17.HeaderText = "Làn Vào";
            Column17.Name = "Column17";
            Column17.ReadOnly = true;
            Column17.Width = 96;
            // 
            // Column16
            // 
            Column16.HeaderText = "Làn Ra";
            Column16.Name = "Column16";
            Column16.ReadOnly = true;
            Column16.Width = 88;
            // 
            // lblEndTime
            // 
            lblEndTime.AutoSize = true;
            lblEndTime.BackColor = Color.Transparent;
            lblEndTime.Font = new Font("Segoe UI", 12F);
            lblEndTime.Location = new Point(383, 50);
            lblEndTime.Name = "lblEndTime";
            lblEndTime.Size = new Size(74, 21);
            lblEndTime.TabIndex = 43;
            lblEndTime.Text = "Kết thúc  ";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(picOverviewImageOut, 0, 0);
            tableLayoutPanel2.Controls.Add(picVehicleImageOut, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(196, 0);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(196, 287);
            tableLayoutPanel2.TabIndex = 53;
            // 
            // picOverviewImageOut
            // 
            picOverviewImageOut.BackColor = Color.WhiteSmoke;
            picOverviewImageOut.BorderStyle = BorderStyle.FixedSingle;
            picOverviewImageOut.Dock = DockStyle.Fill;
            picOverviewImageOut.Location = new Point(0, 0);
            picOverviewImageOut.Margin = new Padding(0);
            picOverviewImageOut.Name = "picOverviewImageOut";
            picOverviewImageOut.Size = new Size(196, 143);
            picOverviewImageOut.SizeMode = PictureBoxSizeMode.StretchImage;
            picOverviewImageOut.TabIndex = 30;
            picOverviewImageOut.TabStop = false;
            picOverviewImageOut.LoadCompleted += Pic_LoadCompleted;
            // 
            // picVehicleImageOut
            // 
            picVehicleImageOut.BackColor = Color.WhiteSmoke;
            picVehicleImageOut.BorderStyle = BorderStyle.FixedSingle;
            picVehicleImageOut.Dock = DockStyle.Fill;
            picVehicleImageOut.Location = new Point(0, 143);
            picVehicleImageOut.Margin = new Padding(0);
            picVehicleImageOut.Name = "picVehicleImageOut";
            picVehicleImageOut.Size = new Size(196, 144);
            picVehicleImageOut.SizeMode = PictureBoxSizeMode.StretchImage;
            picVehicleImageOut.TabIndex = 29;
            picVehicleImageOut.TabStop = false;
            picVehicleImageOut.LoadCompleted += Pic_LoadCompleted;
            // 
            // ucPages1
            // 
            ucPages1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ucPages1.BackColor = Color.Transparent;
            ucPages1.BorderStyle = BorderStyle.Fixed3D;
            ucPages1.Location = new Point(15, 689);
            ucPages1.Margin = new Padding(4, 3, 4, 3);
            ucPages1.Name = "ucPages1";
            ucPages1.Size = new Size(1336, 50);
            ucPages1.TabIndex = 54;
            ucPages1.Visible = false;
            // 
            // lblTotalEvents
            // 
            lblTotalEvents.AutoSize = true;
            lblTotalEvents.BackColor = Color.Transparent;
            lblTotalEvents.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalEvents.ForeColor = Color.FromArgb(253, 149, 40);
            lblTotalEvents.Location = new Point(823, 147);
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
            btnCancel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(979, 533);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(57, 30);
            btnCancel.TabIndex = 57;
            btnCancel.Text = "Đóng";
            // 
            // btnSearch
            // 
            btnSearch.AutoSize = true;
            btnSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnSearch.ForeColor = Color.Black;
            btnSearch.Location = new Point(733, 142);
            btnSearch.Margin = new Padding(3, 2, 3, 2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(84, 30);
            btnSearch.TabIndex = 58;
            btnSearch.Text = "Tìm kiếm";
            // 
            // btnExportExcel
            // 
            btnExportExcel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExportExcel.AutoSize = true;
            btnExportExcel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnExportExcel.Location = new Point(908, 533);
            btnExportExcel.Margin = new Padding(3, 2, 3, 2);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(80, 30);
            btnExportExcel.TabIndex = 59;
            btnExportExcel.Text = "lblExcel1";
            // 
            // panelData
            // 
            panelData.Controls.Add(lblUser);
            panelData.Controls.Add(cbUser);
            panelData.Controls.Add(cbLane);
            panelData.Controls.Add(lblLane);
            panelData.Controls.Add(cbIdentityGroup);
            panelData.Controls.Add(cbVehicleType);
            panelData.Controls.Add(lblVehicleType);
            panelData.Controls.Add(lblIdentityGroup);
            panelData.Controls.Add(lblMoney);
            panelData.Controls.Add(ucEventOutInfo1);
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
            panelData.Controls.Add(dgvData);
            panelData.Controls.Add(lblStartTime);
            panelData.Controls.Add(dtpStartTime);
            panelData.Controls.Add(dtpEndTime);
            panelData.Dock = DockStyle.Fill;
            panelData.Font = new Font("Segoe UI", 12F);
            panelData.Location = new Point(0, 0);
            panelData.Margin = new Padding(3, 2, 3, 2);
            panelData.Name = "panelData";
            panelData.Size = new Size(1070, 575);
            panelData.TabIndex = 60;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(3, 140);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(94, 21);
            lblUser.TabIndex = 71;
            lblUser.Text = "Người dùng";
            // 
            // cbUser
            // 
            cbUser.DropDownStyle = ComboBoxStyle.DropDownList;
            cbUser.FormattingEnabled = true;
            cbUser.Location = new Point(101, 143);
            cbUser.Margin = new Padding(3, 2, 3, 2);
            cbUser.Name = "cbUser";
            cbUser.Size = new Size(250, 29);
            cbUser.TabIndex = 6;
            // 
            // cbLane
            // 
            cbLane.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLane.Font = new Font("Segoe UI", 12F);
            cbLane.FormattingEnabled = true;
            cbLane.Location = new Point(463, 141);
            cbLane.Margin = new Padding(3, 2, 3, 2);
            cbLane.Name = "cbLane";
            cbLane.Size = new Size(250, 29);
            cbLane.TabIndex = 7;
            // 
            // lblLane
            // 
            lblLane.AutoSize = true;
            lblLane.BackColor = Color.Transparent;
            lblLane.Font = new Font("Segoe UI", 12F);
            lblLane.Location = new Point(385, 145);
            lblLane.Name = "lblLane";
            lblLane.Size = new Size(35, 21);
            lblLane.TabIndex = 69;
            lblLane.Text = "Làn";
            // 
            // cbIdentityGroup
            // 
            cbIdentityGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cbIdentityGroup.Font = new Font("Segoe UI", 12F);
            cbIdentityGroup.FormattingEnabled = true;
            cbIdentityGroup.Location = new Point(463, 106);
            cbIdentityGroup.Margin = new Padding(3, 2, 3, 2);
            cbIdentityGroup.Name = "cbIdentityGroup";
            cbIdentityGroup.Size = new Size(250, 29);
            cbIdentityGroup.TabIndex = 5;
            // 
            // cbVehicleType
            // 
            cbVehicleType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbVehicleType.Font = new Font("Segoe UI", 12F);
            cbVehicleType.FormattingEnabled = true;
            cbVehicleType.Location = new Point(101, 102);
            cbVehicleType.Margin = new Padding(3, 2, 3, 2);
            cbVehicleType.Name = "cbVehicleType";
            cbVehicleType.Size = new Size(250, 29);
            cbVehicleType.TabIndex = 4;
            // 
            // lblVehicleType
            // 
            lblVehicleType.AutoSize = true;
            lblVehicleType.BackColor = Color.Transparent;
            lblVehicleType.Font = new Font("Segoe UI", 12F);
            lblVehicleType.Location = new Point(13, 108);
            lblVehicleType.Name = "lblVehicleType";
            lblVehicleType.Size = new Size(58, 21);
            lblVehicleType.TabIndex = 66;
            lblVehicleType.Text = "Loại xe";
            // 
            // lblIdentityGroup
            // 
            lblIdentityGroup.AutoSize = true;
            lblIdentityGroup.BackColor = Color.Transparent;
            lblIdentityGroup.Font = new Font("Segoe UI", 12F);
            lblIdentityGroup.Location = new Point(383, 110);
            lblIdentityGroup.Name = "lblIdentityGroup";
            lblIdentityGroup.Size = new Size(80, 21);
            lblIdentityGroup.TabIndex = 67;
            lblIdentityGroup.Text = "Nhóm thẻ";
            // 
            // lblMoney
            // 
            lblMoney.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblMoney.AutoSize = true;
            lblMoney.BackColor = Color.Transparent;
            lblMoney.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblMoney.ForeColor = Color.Red;
            lblMoney.Location = new Point(571, 476);
            lblMoney.Name = "lblMoney";
            lblMoney.Size = new Size(83, 32);
            lblMoney.TabIndex = 64;
            lblMoney.Text = "label1";
            // 
            // ucEventOutInfo1
            // 
            ucEventOutInfo1.BackColor = Color.FromArgb(255, 224, 192);
            ucEventOutInfo1.Location = new Point(247, 174);
            ucEventOutInfo1.Margin = new Padding(4, 3, 4, 3);
            ucEventOutInfo1.Name = "ucEventOutInfo1";
            ucEventOutInfo1.Size = new Size(858, 392);
            ucEventOutInfo1.TabIndex = 63;
            // 
            // ucNotify1
            // 
            ucNotify1.BackColor = Color.FromArgb(255, 224, 192);
            ucNotify1.Location = new Point(671, 52);
            ucNotify1.Margin = new Padding(4, 3, 4, 3);
            ucNotify1.MaximumSize = new Size(374, 374);
            ucNotify1.Message = "Nội dung thông báo";
            ucNotify1.MinimumSize = new Size(374, 374);
            ucNotify1.Name = "ucNotify1";
            ucNotify1.NotiType = Usercontrols.BuildControls.ucNotify.EmNotiType.Information;
            ucNotify1.Size = new Size(374, 374);
            ucNotify1.TabIndex = 62;
            ucNotify1.Visible = false;
            // 
            // ucLoading1
            // 
            ucLoading1.BackColor = Color.FromArgb(255, 224, 192);
            ucLoading1.Language = IPaking.Ultility.TextManagement.EmLanguage.Vietnamese;
            ucLoading1.Location = new Point(685, 38);
            ucLoading1.Margin = new Padding(4, 3, 4, 3);
            ucLoading1.Message = "Preparing to download";
            ucLoading1.Name = "ucLoading1";
            ucLoading1.Size = new Size(441, 197);
            ucLoading1.TabIndex = 61;
            // 
            // tablePic
            // 
            tablePic.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            tablePic.ColumnCount = 2;
            tablePic.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tablePic.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tablePic.Controls.Add(tableLayoutPanel1, 0, 0);
            tablePic.Controls.Add(tableLayoutPanel2, 1, 0);
            tablePic.Location = new Point(659, 187);
            tablePic.Margin = new Padding(0);
            tablePic.Name = "tablePic";
            tablePic.RowCount = 1;
            tablePic.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tablePic.Size = new Size(392, 287);
            tablePic.TabIndex = 60;
            // 
            // frmReportInOut
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1070, 575);
            Controls.Add(panelData);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
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
        private Label lblTotalEvents;
        private LblCancel btnCancel;
        private BtnSearch btnSearch;
        private BtnExcel btnExportExcel;
        private Panel panelData;
        private TableLayoutPanel tablePic;
        private Usercontrols.BuildControls.ucNotify ucNotify1;
        private Usercontrols.BuildControls.ucLoading ucLoading1;
        private ucEventOutInfo ucEventOutInfo1;
        private Label lblMoney;
        private ComboBox cbIdentityGroup;
        private ComboBox cbVehicleType;
        private Label lblVehicleType;
        private Label lblIdentityGroup;
        private ComboBox cbLane;
        private Label lblLane;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column11;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column18;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column15;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column12;
        private DataGridViewTextBoxColumn Column13;
        private DataGridViewTextBoxColumn Column19;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column14;
        private DataGridViewTextBoxColumn Column17;
        private DataGridViewTextBoxColumn Column16;
        private Label lblUser;
        private ComboBox cbUser;
    }
}