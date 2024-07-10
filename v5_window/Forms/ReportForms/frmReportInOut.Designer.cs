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
            components = new System.ComponentModel.Container();
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
            pictureBox1 = new PictureBox();
            btnPrintOffline = new BtnPrint();
            btnPrintInternet = new BtnPrint();
            lblUser = new Label();
            cbUser = new ComboBox();
            cbLane = new ComboBox();
            lblLane = new Label();
            cbIdentityGroup = new ComboBox();
            cbVehicleType = new ComboBox();
            lblVehicleType = new Label();
            lblIdentityGroup = new Label();
            lblTQ = new Label();
            lblVN = new Label();
            lblMoney = new Label();
            ucEventOutInfo1 = new ucEventOutInfo();
            ucNotify1 = new Usercontrols.BuildControls.ucNotify();
            ucLoading1 = new Usercontrols.BuildControls.ucLoading();
            tablePic = new TableLayoutPanel();
            toolTip1 = new ToolTip(components);
            id = new DataGridViewTextBoxColumn();
            eventinid = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            PlateIn = new DataGridViewTextBoxColumn();
            PlateOut = new DataGridViewTextBoxColumn();
            vehicle_reagion_type = new DataGridViewTextBoxColumn();
            TimeIn = new DataGridViewTextBoxColumn();
            TimeOut = new DataGridViewTextBoxColumn();
            ParkingTime = new DataGridViewTextBoxColumn();
            IdentityGroup = new DataGridViewTextBoxColumn();
            WarehouseType = new DataGridViewTextBoxColumn();
            WarehouseCode = new DataGridViewTextBoxColumn();
            Charge = new DataGridViewTextBoxColumn();
            IdentityCode = new DataGridViewTextBoxColumn();
            UserIn = new DataGridViewTextBoxColumn();
            UserOut = new DataGridViewTextBoxColumn();
            InvoiceTemplate = new DataGridViewTextBoxColumn();
            InvoiceNo = new DataGridViewTextBoxColumn();
            LaneIn = new DataGridViewTextBoxColumn();
            LaneOut = new DataGridViewTextBoxColumn();
            NoteBSX = new DataGridViewTextBoxColumn();
            note_3rd_1 = new DataGridViewTextBoxColumn();
            note_3rd_2 = new DataGridViewTextBoxColumn();
            note_3rd_3 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            Column14 = new DataGridViewTextBoxColumn();
            pending_invoice_id = new DataGridViewTextBoxColumn();
            invoice_id = new DataGridViewTextBoxColumn();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picOverviewImageIn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picVehicleImageIn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picOverviewImageOut).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picVehicleImageOut).BeginInit();
            panelData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tablePic.SuspendLayout();
            SuspendLayout();
            // 
            // dtpEndTime
            // 
            dtpEndTime.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            dtpEndTime.Font = new Font("Segoe UI", 12F);
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(595, 66);
            dtpEndTime.Margin = new Padding(4, 3, 4, 3);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.Size = new Size(320, 29);
            dtpEndTime.TabIndex = 3;
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            dtpStartTime.Font = new Font("Segoe UI", 12F);
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(130, 70);
            dtpStartTime.Margin = new Padding(4, 3, 4, 3);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.Size = new Size(320, 29);
            dtpStartTime.TabIndex = 2;
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.BackColor = Color.Transparent;
            lblStartTime.Font = new Font("Segoe UI", 12F);
            lblStartTime.Location = new Point(17, 66);
            lblStartTime.Margin = new Padding(4, 0, 4, 0);
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
            tableLayoutPanel1.Size = new Size(252, 402);
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
            picOverviewImageIn.Size = new Size(252, 201);
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
            picVehicleImageIn.Location = new Point(0, 201);
            picVehicleImageIn.Margin = new Padding(0);
            picVehicleImageIn.Name = "picVehicleImageIn";
            picVehicleImageIn.Size = new Size(252, 201);
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
            lblKeyword.Location = new Point(14, 18);
            lblKeyword.Margin = new Padding(4, 0, 4, 0);
            lblKeyword.Name = "lblKeyword";
            lblKeyword.Size = new Size(65, 21);
            lblKeyword.TabIndex = 52;
            lblKeyword.Text = "Từ khóa";
            // 
            // txtKeyword
            // 
            txtKeyword.Font = new Font("Segoe UI", 12F);
            txtKeyword.Location = new Point(130, 20);
            txtKeyword.Margin = new Padding(4, 3, 4, 3);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.PlaceholderText = "Biển số, tên định danh, mã định danh";
            txtKeyword.Size = new Size(786, 29);
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
            dgvData.Columns.AddRange(new DataGridViewColumn[] { id, eventinid, Column1, PlateIn, PlateOut, vehicle_reagion_type, TimeIn, TimeOut, ParkingTime, IdentityGroup, WarehouseType, WarehouseCode, Charge, IdentityCode, UserIn, UserOut, InvoiceTemplate, InvoiceNo, LaneIn, LaneOut, NoteBSX, note_3rd_1, note_3rd_2, note_3rd_3, Column9, Column14, pending_invoice_id, invoice_id });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.Padding = new Padding(3);
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvData.DefaultCellStyle = dataGridViewCellStyle4;
            dgvData.Location = new Point(15, 262);
            dgvData.Margin = new Padding(4, 3, 4, 3);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowHeadersVisible = false;
            dgvData.RowTemplate.Height = 29;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.Size = new Size(813, 402);
            dgvData.TabIndex = 50;
            dgvData.CellMouseClick += dgvData_CellMouseClick;
            dgvData.MouseClick += dgvData_MouseClick;
            // 
            // lblEndTime
            // 
            lblEndTime.AutoSize = true;
            lblEndTime.BackColor = Color.Transparent;
            lblEndTime.Font = new Font("Segoe UI", 12F);
            lblEndTime.Location = new Point(492, 70);
            lblEndTime.Margin = new Padding(4, 0, 4, 0);
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
            tableLayoutPanel2.Location = new Point(252, 0);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(252, 402);
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
            picOverviewImageOut.Size = new Size(252, 201);
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
            picVehicleImageOut.Location = new Point(0, 201);
            picVehicleImageOut.Margin = new Padding(0);
            picVehicleImageOut.Name = "picVehicleImageOut";
            picVehicleImageOut.Size = new Size(252, 201);
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
            lblTotalEvents.Location = new Point(1202, 97);
            lblTotalEvents.Margin = new Padding(4, 0, 4, 0);
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
            btnCancel.Location = new Point(1259, 746);
            btnCancel.Margin = new Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(73, 42);
            btnCancel.TabIndex = 57;
            btnCancel.Text = "Đóng";
            // 
            // btnSearch
            // 
            btnSearch.AutoSize = true;
            btnSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnSearch.ForeColor = Color.Black;
            btnSearch.Location = new Point(924, 132);
            btnSearch.Margin = new Padding(4, 3, 4, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(108, 42);
            btnSearch.TabIndex = 58;
            btnSearch.Text = "Tìm kiếm";
            // 
            // btnExportExcel
            // 
            btnExportExcel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExportExcel.AutoSize = true;
            btnExportExcel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnExportExcel.Location = new Point(1167, 746);
            btnExportExcel.Margin = new Padding(4, 3, 4, 3);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(103, 42);
            btnExportExcel.TabIndex = 59;
            btnExportExcel.Text = "lblExcel1";
            // 
            // panelData
            // 
            panelData.Controls.Add(pictureBox1);
            panelData.Controls.Add(btnPrintOffline);
            panelData.Controls.Add(btnPrintInternet);
            panelData.Controls.Add(lblUser);
            panelData.Controls.Add(cbUser);
            panelData.Controls.Add(cbLane);
            panelData.Controls.Add(lblLane);
            panelData.Controls.Add(cbIdentityGroup);
            panelData.Controls.Add(cbVehicleType);
            panelData.Controls.Add(lblVehicleType);
            panelData.Controls.Add(lblIdentityGroup);
            panelData.Controls.Add(lblTQ);
            panelData.Controls.Add(lblVN);
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
            panelData.Margin = new Padding(4, 3, 4, 3);
            panelData.Name = "panelData";
            panelData.Size = new Size(1376, 805);
            panelData.TabIndex = 60;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.Image = Properties.Resources.noti_question_64;
            pictureBox1.Location = new Point(1321, 18);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 30);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 73;
            pictureBox1.TabStop = false;
            toolTip1.SetToolTip(pictureBox1, "Bấm chuột phải vào bản ghi để mở tính năng bổ sung\r\n\r\nPhím Tắt:\r\nF6 - In phiếu thu\r\nF7 - In hóa đơn internet\r\nF8 - In hóa đơn offline");
            // 
            // btnPrintOffline
            // 
            btnPrintOffline.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnPrintOffline.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnPrintOffline.Location = new Point(1225, 127);
            btnPrintOffline.Margin = new Padding(4);
            btnPrintOffline.Name = "btnPrintOffline";
            btnPrintOffline.Size = new Size(158, 45);
            btnPrintOffline.TabIndex = 72;
            btnPrintOffline.Text = "In hóa đơn";
            btnPrintOffline.UseVisualStyleBackColor = true;
            btnPrintOffline.Click += btnPrintOffline_Click_1;
            // 
            // btnPrintInternet
            // 
            btnPrintInternet.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnPrintInternet.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnPrintInternet.Location = new Point(1040, 127);
            btnPrintInternet.Margin = new Padding(4);
            btnPrintInternet.Name = "btnPrintInternet";
            btnPrintInternet.Size = new Size(177, 45);
            btnPrintInternet.TabIndex = 72;
            btnPrintInternet.Text = "In hóa đơn(Internet)";
            btnPrintInternet.UseVisualStyleBackColor = true;
            btnPrintInternet.Click += btnPrintInternet_Click_1;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(5, 144);
            lblUser.Margin = new Padding(4, 0, 4, 0);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(94, 21);
            lblUser.TabIndex = 71;
            lblUser.Text = "Người dùng";
            // 
            // cbUser
            // 
            cbUser.DropDownStyle = ComboBoxStyle.DropDownList;
            cbUser.FormattingEnabled = true;
            cbUser.Location = new Point(131, 148);
            cbUser.Margin = new Padding(4, 3, 4, 3);
            cbUser.Name = "cbUser";
            cbUser.Size = new Size(320, 29);
            cbUser.TabIndex = 6;
            // 
            // cbLane
            // 
            cbLane.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLane.Font = new Font("Segoe UI", 12F);
            cbLane.FormattingEnabled = true;
            cbLane.Location = new Point(596, 145);
            cbLane.Margin = new Padding(4, 3, 4, 3);
            cbLane.Name = "cbLane";
            cbLane.Size = new Size(320, 29);
            cbLane.TabIndex = 7;
            // 
            // lblLane
            // 
            lblLane.AutoSize = true;
            lblLane.BackColor = Color.Transparent;
            lblLane.Font = new Font("Segoe UI", 12F);
            lblLane.Location = new Point(496, 151);
            lblLane.Margin = new Padding(4, 0, 4, 0);
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
            cbIdentityGroup.Location = new Point(595, 110);
            cbIdentityGroup.Margin = new Padding(4, 3, 4, 3);
            cbIdentityGroup.Name = "cbIdentityGroup";
            cbIdentityGroup.Size = new Size(320, 29);
            cbIdentityGroup.TabIndex = 5;
            // 
            // cbVehicleType
            // 
            cbVehicleType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbVehicleType.Font = new Font("Segoe UI", 12F);
            cbVehicleType.FormattingEnabled = true;
            cbVehicleType.Location = new Point(130, 105);
            cbVehicleType.Margin = new Padding(4, 3, 4, 3);
            cbVehicleType.Name = "cbVehicleType";
            cbVehicleType.Size = new Size(320, 29);
            cbVehicleType.TabIndex = 4;
            // 
            // lblVehicleType
            // 
            lblVehicleType.AutoSize = true;
            lblVehicleType.BackColor = Color.Transparent;
            lblVehicleType.Font = new Font("Segoe UI", 12F);
            lblVehicleType.Location = new Point(17, 113);
            lblVehicleType.Margin = new Padding(4, 0, 4, 0);
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
            lblIdentityGroup.Location = new Point(492, 116);
            lblIdentityGroup.Margin = new Padding(4, 0, 4, 0);
            lblIdentityGroup.Name = "lblIdentityGroup";
            lblIdentityGroup.Size = new Size(80, 21);
            lblIdentityGroup.TabIndex = 67;
            lblIdentityGroup.Text = "Nhóm thẻ";
            // 
            // lblTQ
            // 
            lblTQ.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTQ.AutoSize = true;
            lblTQ.BackColor = Color.Transparent;
            lblTQ.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTQ.ForeColor = Color.Red;
            lblTQ.Location = new Point(17, 707);
            lblTQ.Margin = new Padding(4, 0, 4, 0);
            lblTQ.Name = "lblTQ";
            lblTQ.Size = new Size(52, 32);
            lblTQ.TabIndex = 64;
            lblTQ.Text = "TQ:";
            // 
            // lblVN
            // 
            lblVN.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblVN.AutoSize = true;
            lblVN.BackColor = Color.Transparent;
            lblVN.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblVN.ForeColor = Color.Red;
            lblVN.Location = new Point(14, 666);
            lblVN.Margin = new Padding(4, 0, 4, 0);
            lblVN.Name = "lblVN";
            lblVN.Size = new Size(56, 32);
            lblVN.TabIndex = 64;
            lblVN.Text = "VN:";
            // 
            // lblMoney
            // 
            lblMoney.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblMoney.AutoSize = true;
            lblMoney.BackColor = Color.Transparent;
            lblMoney.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblMoney.ForeColor = Color.Red;
            lblMoney.Location = new Point(734, 666);
            lblMoney.Margin = new Padding(4, 0, 4, 0);
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
            tablePic.Location = new Point(847, 262);
            tablePic.Margin = new Padding(0);
            tablePic.Name = "tablePic";
            tablePic.RowCount = 1;
            tablePic.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tablePic.Size = new Size(504, 402);
            tablePic.TabIndex = 60;
            // 
            // toolTip1
            // 
            toolTip1.IsBalloon = true;
            // 
            // id
            // 
            id.HeaderText = "id";
            id.Name = "id";
            id.ReadOnly = true;
            id.Visible = false;
            id.Width = 37;
            // 
            // eventinid
            // 
            eventinid.HeaderText = "eventInId";
            eventinid.Name = "eventinid";
            eventinid.ReadOnly = true;
            eventinid.Visible = false;
            eventinid.Width = 95;
            // 
            // Column1
            // 
            Column1.HeaderText = "STT";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 68;
            // 
            // PlateIn
            // 
            PlateIn.HeaderText = "Biển Số Vào";
            PlateIn.Name = "PlateIn";
            PlateIn.ReadOnly = true;
            PlateIn.Width = 131;
            // 
            // PlateOut
            // 
            PlateOut.HeaderText = "Biển Số Ra";
            PlateOut.Name = "PlateOut";
            PlateOut.ReadOnly = true;
            PlateOut.Width = 121;
            // 
            // vehicle_reagion_type
            // 
            vehicle_reagion_type.HeaderText = "Xe VN/TQ";
            vehicle_reagion_type.Name = "vehicle_reagion_type";
            vehicle_reagion_type.ReadOnly = true;
            vehicle_reagion_type.Width = 115;
            // 
            // TimeIn
            // 
            TimeIn.HeaderText = "Giờ Vào";
            TimeIn.Name = "TimeIn";
            TimeIn.ReadOnly = true;
            // 
            // TimeOut
            // 
            TimeOut.HeaderText = "Giờ Ra";
            TimeOut.Name = "TimeOut";
            TimeOut.ReadOnly = true;
            TimeOut.Width = 90;
            // 
            // ParkingTime
            // 
            ParkingTime.HeaderText = "Thời Gian Lưu Bãi";
            ParkingTime.Name = "ParkingTime";
            ParkingTime.ReadOnly = true;
            ParkingTime.Width = 175;
            // 
            // IdentityGroup
            // 
            IdentityGroup.HeaderText = "Loại";
            IdentityGroup.Name = "IdentityGroup";
            IdentityGroup.ReadOnly = true;
            IdentityGroup.Width = 73;
            // 
            // WarehouseType
            // 
            WarehouseType.HeaderText = "Phân Loại";
            WarehouseType.Name = "WarehouseType";
            WarehouseType.ReadOnly = true;
            WarehouseType.Width = 116;
            // 
            // WarehouseCode
            // 
            WarehouseCode.HeaderText = "Số phiếu xuất";
            WarehouseCode.Name = "WarehouseCode";
            WarehouseCode.ReadOnly = true;
            WarehouseCode.Width = 146;
            // 
            // Charge
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            Charge.DefaultCellStyle = dataGridViewCellStyle3;
            Charge.HeaderText = "Phí";
            Charge.Name = "Charge";
            Charge.ReadOnly = true;
            Charge.Width = 66;
            // 
            // IdentityCode
            // 
            IdentityCode.HeaderText = "Vé Xe";
            IdentityCode.Name = "IdentityCode";
            IdentityCode.ReadOnly = true;
            IdentityCode.Width = 83;
            // 
            // UserIn
            // 
            UserIn.HeaderText = "Người Dùng Vào";
            UserIn.Name = "UserIn";
            UserIn.ReadOnly = true;
            UserIn.Width = 169;
            // 
            // UserOut
            // 
            UserOut.HeaderText = "Người Dùng Ra";
            UserOut.Name = "UserOut";
            UserOut.ReadOnly = true;
            UserOut.Width = 159;
            // 
            // InvoiceTemplate
            // 
            InvoiceTemplate.HeaderText = "Mẫu hóa đơn";
            InvoiceTemplate.Name = "InvoiceTemplate";
            InvoiceTemplate.ReadOnly = true;
            InvoiceTemplate.Width = 142;
            // 
            // InvoiceNo
            // 
            InvoiceNo.HeaderText = "Số hóa đơn";
            InvoiceNo.Name = "InvoiceNo";
            InvoiceNo.ReadOnly = true;
            InvoiceNo.Width = 127;
            // 
            // LaneIn
            // 
            LaneIn.HeaderText = "Làn Vào";
            LaneIn.Name = "LaneIn";
            LaneIn.ReadOnly = true;
            LaneIn.Width = 101;
            // 
            // LaneOut
            // 
            LaneOut.HeaderText = "Làn Ra";
            LaneOut.Name = "LaneOut";
            LaneOut.ReadOnly = true;
            LaneOut.Width = 91;
            // 
            // NoteBSX
            // 
            NoteBSX.HeaderText = "Ghi chú BSX";
            NoteBSX.Name = "NoteBSX";
            NoteBSX.ReadOnly = true;
            NoteBSX.Width = 132;
            // 
            // note_3rd_1
            // 
            note_3rd_1.HeaderText = "Ghi chú chặn kích xe";
            note_3rd_1.Name = "note_3rd_1";
            note_3rd_1.ReadOnly = true;
            note_3rd_1.Width = 198;
            // 
            // note_3rd_2
            // 
            note_3rd_2.HeaderText = "Ghi chú DVHT";
            note_3rd_2.Name = "note_3rd_2";
            note_3rd_2.ReadOnly = true;
            note_3rd_2.Width = 147;
            // 
            // note_3rd_3
            // 
            note_3rd_3.HeaderText = "Người cho phép ra";
            note_3rd_3.Name = "note_3rd_3";
            note_3rd_3.ReadOnly = true;
            note_3rd_3.Width = 184;
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
            // pending_invoice_id
            // 
            pending_invoice_id.HeaderText = "pendingId";
            pending_invoice_id.Name = "pending_invoice_id";
            pending_invoice_id.ReadOnly = true;
            pending_invoice_id.Visible = false;
            pending_invoice_id.Width = 120;
            // 
            // invoice_id
            // 
            invoice_id.HeaderText = "invoiceId";
            invoice_id.Name = "invoice_id";
            invoice_id.ReadOnly = true;
            invoice_id.Visible = false;
            invoice_id.Width = 112;
            // 
            // frmReportInOut
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1376, 805);
            Controls.Add(panelData);
            Font = new Font("Segoe UI", 12F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private Label lblUser;
        private ComboBox cbUser;
        private BtnPrint btnPrintInternet;
        private BtnPrint btnPrintOffline;
        private PictureBox pictureBox1;
        private ToolTip toolTip1;
        private Label lblTQ;
        private Label lblVN;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn eventinid;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn PlateIn;
        private DataGridViewTextBoxColumn PlateOut;
        private DataGridViewTextBoxColumn vehicle_reagion_type;
        private DataGridViewTextBoxColumn TimeIn;
        private DataGridViewTextBoxColumn TimeOut;
        private DataGridViewTextBoxColumn ParkingTime;
        private DataGridViewTextBoxColumn IdentityGroup;
        private DataGridViewTextBoxColumn WarehouseType;
        private DataGridViewTextBoxColumn WarehouseCode;
        private DataGridViewTextBoxColumn Charge;
        private DataGridViewTextBoxColumn IdentityCode;
        private DataGridViewTextBoxColumn UserIn;
        private DataGridViewTextBoxColumn UserOut;
        private DataGridViewTextBoxColumn InvoiceTemplate;
        private DataGridViewTextBoxColumn InvoiceNo;
        private DataGridViewTextBoxColumn LaneIn;
        private DataGridViewTextBoxColumn LaneOut;
        private DataGridViewTextBoxColumn NoteBSX;
        private DataGridViewTextBoxColumn note_3rd_1;
        private DataGridViewTextBoxColumn note_3rd_2;
        private DataGridViewTextBoxColumn note_3rd_3;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column14;
        private DataGridViewTextBoxColumn pending_invoice_id;
        private DataGridViewTextBoxColumn invoice_id;
    }
}