using IPaking.Ultility;
using iPakrkingv5.Controls.Controls.Buttons;
using iPakrkingv5.Controls.Usercontrols;

namespace iParkingv5.Reporting
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportIn));
            picOverviewImageIn = new MovablePictureBox();
            picVehicleImageIn = new MovablePictureBox();
            tablePic = new TableLayoutPanel();
            lblKeyword = new Label();
            txtKeyword = new TextBox();
            dgvData = new DataGridView();
            event_id = new DataGridViewTextBoxColumn();
            identity_id = new DataGridViewTextBoxColumn();
            lane_in_id = new DataGridViewTextBoxColumn();
            file_keys = new DataGridViewTextBoxColumn();
            customer_id = new DataGridViewTextBoxColumn();
            register_vehicle_id = new DataGridViewTextBoxColumn();
            index = new DataGridViewTextBoxColumn();
            plate = new DataGridViewTextBoxColumn();
            time_in = new DataGridViewTextBoxColumn();
            note = new DataGridViewTextBoxColumn();
            identity_group_name = new DataGridViewTextBoxColumn();
            user = new DataGridViewTextBoxColumn();
            lane_in_name = new DataGridViewTextBoxColumn();
            identity_name = new DataGridViewTextBoxColumn();
            identity_code = new DataGridViewTextBoxColumn();
            register_plate = new DataGridViewTextBoxColumn();
            customer = new DataGridViewTextBoxColumn();
            see_more = new DataGridViewButtonColumn();
            dtpEndTime = new DateTimePicker();
            dtpStartTime = new DateTimePicker();
            lblEndTime = new Label();
            lblStartTime = new Label();
            lblTotalEvents = new Label();
            btnCancel = new LblCancel();
            btnSearch = new BtnSearch();
            btnExportExcel = new BtnExcel();
            panelData = new Panel();
            panelSearch = new TableLayoutPanel();
            lblUser = new Label();
            cbLane = new ComboBox();
            cbIdentityGroupType = new ComboBox();
            lblVehicleType = new Label();
            cbUser = new ComboBox();
            lblLane = new Label();
            lblIdentityType = new Label();
            cbVehicleType = new ComboBox();
            picGuide = new PictureBox();
            lblTitle = new Label();
            ucPages1 = new ucPages();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)picOverviewImageIn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picVehicleImageIn).BeginInit();
            tablePic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            panelData.SuspendLayout();
            panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picGuide).BeginInit();
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
            picOverviewImageIn.Size = new Size(276, 273);
            picOverviewImageIn.SizeMode = PictureBoxSizeMode.StretchImage;
            picOverviewImageIn.TabIndex = 30;
            picOverviewImageIn.TabStop = false;
            toolTip1.SetToolTip(picOverviewImageIn, "Kích đúp chuột để xem hình ảnh phóng to");
            // 
            // picVehicleImageIn
            // 
            picVehicleImageIn.BackColor = Color.WhiteSmoke;
            picVehicleImageIn.BorderStyle = BorderStyle.FixedSingle;
            picVehicleImageIn.Dock = DockStyle.Fill;
            picVehicleImageIn.Location = new Point(0, 273);
            picVehicleImageIn.Margin = new Padding(0);
            picVehicleImageIn.Name = "picVehicleImageIn";
            picVehicleImageIn.Size = new Size(276, 274);
            picVehicleImageIn.SizeMode = PictureBoxSizeMode.StretchImage;
            picVehicleImageIn.TabIndex = 29;
            picVehicleImageIn.TabStop = false;
            toolTip1.SetToolTip(picVehicleImageIn, "Kích đúp chuột để xem hình ảnh phóng to");
            // 
            // tablePic
            // 
            tablePic.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            tablePic.ColumnCount = 1;
            tablePic.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tablePic.Controls.Add(picOverviewImageIn, 0, 0);
            tablePic.Controls.Add(picVehicleImageIn, 0, 1);
            tablePic.Location = new Point(1405, 95);
            tablePic.Margin = new Padding(0);
            tablePic.Name = "tablePic";
            tablePic.RowCount = 2;
            tablePic.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tablePic.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tablePic.Size = new Size(276, 547);
            tablePic.TabIndex = 42;
            // 
            // lblKeyword
            // 
            lblKeyword.BackColor = Color.Transparent;
            lblKeyword.Dock = DockStyle.Fill;
            lblKeyword.Location = new Point(4, 0);
            lblKeyword.Margin = new Padding(4, 0, 4, 0);
            lblKeyword.Name = "lblKeyword";
            lblKeyword.Size = new Size(100, 39);
            lblKeyword.TabIndex = 41;
            lblKeyword.Text = "Từ khóa";
            lblKeyword.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtKeyword
            // 
            panelSearch.SetColumnSpan(txtKeyword, 4);
            txtKeyword.Dock = DockStyle.Fill;
            txtKeyword.Location = new Point(112, 3);
            txtKeyword.Margin = new Padding(4, 3, 4, 3);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.PlaceholderText = "Biển số, tên định danh, mã định danh";
            txtKeyword.Size = new Size(569, 29);
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
            dgvData.Columns.AddRange(new DataGridViewColumn[] { event_id, identity_id, lane_in_id, file_keys, customer_id, register_vehicle_id, index, plate, time_in, note, identity_group_name, user, lane_in_name, identity_name, identity_code, register_plate, customer, see_more });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new Padding(3);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvData.DefaultCellStyle = dataGridViewCellStyle3;
            dgvData.Location = new Point(9, 239);
            dgvData.Margin = new Padding(4, 3, 4, 3);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowHeadersVisible = false;
            dgvData.RowTemplate.Height = 29;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.Size = new Size(1386, 402);
            dgvData.TabIndex = 39;
            dgvData.CellMouseClick += dgvData_CellMouseClick;
            // 
            // event_id
            // 
            event_id.HeaderText = "event_id";
            event_id.Name = "event_id";
            event_id.ReadOnly = true;
            event_id.Visible = false;
            event_id.Width = 80;
            // 
            // identity_id
            // 
            identity_id.HeaderText = "identity_id";
            identity_id.Name = "identity_id";
            identity_id.ReadOnly = true;
            identity_id.Visible = false;
            identity_id.Width = 94;
            // 
            // lane_in_id
            // 
            lane_in_id.HeaderText = "lane_in_id";
            lane_in_id.Name = "lane_in_id";
            lane_in_id.ReadOnly = true;
            lane_in_id.Visible = false;
            lane_in_id.Width = 91;
            // 
            // file_keys
            // 
            file_keys.HeaderText = "file_keys";
            file_keys.Name = "file_keys";
            file_keys.ReadOnly = true;
            file_keys.Visible = false;
            file_keys.Width = 81;
            // 
            // customer_id
            // 
            customer_id.HeaderText = "customer_id";
            customer_id.Name = "customer_id";
            customer_id.ReadOnly = true;
            customer_id.Visible = false;
            customer_id.Width = 107;
            // 
            // register_vehicle_id
            // 
            register_vehicle_id.HeaderText = "register_vehicle_id";
            register_vehicle_id.Name = "register_vehicle_id";
            register_vehicle_id.ReadOnly = true;
            register_vehicle_id.Visible = false;
            register_vehicle_id.Width = 150;
            // 
            // index
            // 
            index.HeaderText = "STT";
            index.Name = "index";
            index.ReadOnly = true;
            index.Width = 68;
            // 
            // plate
            // 
            plate.HeaderText = "Biển Số Xe";
            plate.Name = "plate";
            plate.ReadOnly = true;
            plate.Width = 121;
            // 
            // time_in
            // 
            time_in.HeaderText = "Giờ Vào";
            time_in.Name = "time_in";
            time_in.ReadOnly = true;
            // 
            // note
            // 
            note.HeaderText = "Ghi chú";
            note.Name = "note";
            note.ReadOnly = true;
            note.Width = 99;
            // 
            // identity_group_name
            // 
            identity_group_name.HeaderText = "Nhóm";
            identity_group_name.Name = "identity_group_name";
            identity_group_name.ReadOnly = true;
            identity_group_name.Width = 89;
            // 
            // user
            // 
            user.HeaderText = "Người Dùng";
            user.Name = "user";
            user.ReadOnly = true;
            user.Width = 136;
            // 
            // lane_in_name
            // 
            lane_in_name.HeaderText = "Làn vào";
            lane_in_name.Name = "lane_in_name";
            lane_in_name.ReadOnly = true;
            // 
            // identity_name
            // 
            identity_name.HeaderText = "Tên Thẻ";
            identity_name.Name = "identity_name";
            identity_name.ReadOnly = true;
            // 
            // identity_code
            // 
            identity_code.HeaderText = "Mã Thẻ";
            identity_code.Name = "identity_code";
            identity_code.ReadOnly = true;
            identity_code.Width = 97;
            // 
            // register_plate
            // 
            register_plate.HeaderText = "Biển số đăng ký";
            register_plate.Name = "register_plate";
            register_plate.ReadOnly = true;
            register_plate.Width = 161;
            // 
            // customer
            // 
            customer.HeaderText = "Khách hàng";
            customer.Name = "customer";
            customer.ReadOnly = true;
            customer.Width = 131;
            // 
            // see_more
            // 
            see_more.HeaderText = "Xem Thêm";
            see_more.Name = "see_more";
            see_more.ReadOnly = true;
            see_more.Visible = false;
            see_more.Width = 96;
            // 
            // dtpEndTime
            // 
            dtpEndTime.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            dtpEndTime.Dock = DockStyle.Fill;
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(468, 42);
            dtpEndTime.Margin = new Padding(4, 3, 4, 3);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.Size = new Size(213, 29);
            dtpEndTime.TabIndex = 3;
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            dtpStartTime.Dock = DockStyle.Fill;
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(112, 42);
            dtpStartTime.Margin = new Padding(4, 3, 4, 3);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.Size = new Size(230, 29);
            dtpStartTime.TabIndex = 2;
            // 
            // lblEndTime
            // 
            lblEndTime.BackColor = Color.Transparent;
            lblEndTime.Dock = DockStyle.Fill;
            lblEndTime.Location = new Point(380, 39);
            lblEndTime.Margin = new Padding(4, 0, 4, 0);
            lblEndTime.Name = "lblEndTime";
            lblEndTime.Size = new Size(80, 39);
            lblEndTime.TabIndex = 32;
            lblEndTime.Text = "Kết thúc  ";
            lblEndTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblStartTime
            // 
            lblStartTime.BackColor = Color.Transparent;
            lblStartTime.Dock = DockStyle.Fill;
            lblStartTime.Location = new Point(4, 39);
            lblStartTime.Margin = new Padding(4, 0, 4, 0);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(100, 39);
            lblStartTime.TabIndex = 33;
            lblStartTime.Text = "Bắt đầu";
            lblStartTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalEvents
            // 
            lblTotalEvents.AutoSize = true;
            lblTotalEvents.BackColor = Color.Transparent;
            lblTotalEvents.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalEvents.ForeColor = Color.FromArgb(253, 149, 40);
            lblTotalEvents.Location = new Point(818, 158);
            lblTotalEvents.Margin = new Padding(4, 0, 4, 0);
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
            btnCancel.Location = new Point(1596, 708);
            btnCancel.Margin = new Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(73, 42);
            btnCancel.TabIndex = 59;
            btnCancel.Text = "Đóng";
            // 
            // btnSearch
            // 
            btnSearch.AutoSize = true;
            btnSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnSearch.ForeColor = Color.Black;
            btnSearch.Location = new Point(702, 141);
            btnSearch.Margin = new Padding(4, 3, 4, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(108, 42);
            btnSearch.TabIndex = 60;
            btnSearch.Text = "Tìm kiếm";
            toolTip1.SetToolTip(btnSearch, "Click chuột hoặc bấm Enter để tìm kiếm");
            // 
            // btnExportExcel
            // 
            btnExportExcel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExportExcel.AutoSize = true;
            btnExportExcel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnExportExcel.Location = new Point(1489, 708);
            btnExportExcel.Margin = new Padding(4, 3, 4, 3);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(103, 42);
            btnExportExcel.TabIndex = 61;
            btnExportExcel.Text = "lblExcel1";
            // 
            // panelData
            // 
            panelData.Controls.Add(panelSearch);
            panelData.Controls.Add(picGuide);
            panelData.Controls.Add(lblTitle);
            panelData.Controls.Add(btnExportExcel);
            panelData.Controls.Add(btnCancel);
            panelData.Controls.Add(btnSearch);
            panelData.Controls.Add(ucPages1);
            panelData.Controls.Add(lblTotalEvents);
            panelData.Controls.Add(tablePic);
            panelData.Controls.Add(dgvData);
            panelData.Dock = DockStyle.Fill;
            panelData.Font = new Font("Segoe UI", 12F);
            panelData.Location = new Point(0, 0);
            panelData.Margin = new Padding(4, 3, 4, 3);
            panelData.Name = "panelData";
            panelData.Size = new Size(1682, 760);
            panelData.TabIndex = 62;
            // 
            // panelSearch
            // 
            panelSearch.AutoSize = true;
            panelSearch.ColumnCount = 5;
            panelSearch.ColumnStyles.Add(new ColumnStyle());
            panelSearch.ColumnStyles.Add(new ColumnStyle());
            panelSearch.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            panelSearch.ColumnStyles.Add(new ColumnStyle());
            panelSearch.ColumnStyles.Add(new ColumnStyle());
            panelSearch.Controls.Add(lblKeyword, 0, 0);
            panelSearch.Controls.Add(txtKeyword, 1, 0);
            panelSearch.Controls.Add(lblUser, 0, 3);
            panelSearch.Controls.Add(cbLane, 4, 3);
            panelSearch.Controls.Add(lblStartTime, 0, 1);
            panelSearch.Controls.Add(cbIdentityGroupType, 4, 2);
            panelSearch.Controls.Add(lblVehicleType, 0, 2);
            panelSearch.Controls.Add(cbUser, 1, 3);
            panelSearch.Controls.Add(lblLane, 3, 3);
            panelSearch.Controls.Add(dtpStartTime, 1, 1);
            panelSearch.Controls.Add(lblIdentityType, 3, 2);
            panelSearch.Controls.Add(cbVehicleType, 1, 2);
            panelSearch.Controls.Add(lblEndTime, 3, 1);
            panelSearch.Controls.Add(dtpEndTime, 4, 1);
            panelSearch.Location = new Point(13, 34);
            panelSearch.Name = "panelSearch";
            panelSearch.RowCount = 4;
            panelSearch.RowStyles.Add(new RowStyle());
            panelSearch.RowStyles.Add(new RowStyle());
            panelSearch.RowStyles.Add(new RowStyle());
            panelSearch.RowStyles.Add(new RowStyle());
            panelSearch.Size = new Size(685, 156);
            panelSearch.TabIndex = 68;
            // 
            // lblUser
            // 
            lblUser.Dock = DockStyle.Fill;
            lblUser.Location = new Point(4, 117);
            lblUser.Margin = new Padding(4, 0, 4, 0);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(100, 39);
            lblUser.TabIndex = 66;
            lblUser.Text = "Người dùng";
            lblUser.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbLane
            // 
            cbLane.Dock = DockStyle.Fill;
            cbLane.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLane.FormattingEnabled = true;
            cbLane.Location = new Point(468, 120);
            cbLane.Margin = new Padding(4, 3, 4, 3);
            cbLane.Name = "cbLane";
            cbLane.Size = new Size(213, 29);
            cbLane.TabIndex = 7;
            // 
            // cbIdentityGroupType
            // 
            cbIdentityGroupType.Dock = DockStyle.Fill;
            cbIdentityGroupType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbIdentityGroupType.FormattingEnabled = true;
            cbIdentityGroupType.Location = new Point(468, 81);
            cbIdentityGroupType.Margin = new Padding(4, 3, 4, 3);
            cbIdentityGroupType.Name = "cbIdentityGroupType";
            cbIdentityGroupType.Size = new Size(213, 29);
            cbIdentityGroupType.TabIndex = 5;
            // 
            // lblVehicleType
            // 
            lblVehicleType.BackColor = Color.Transparent;
            lblVehicleType.Dock = DockStyle.Fill;
            lblVehicleType.Location = new Point(4, 78);
            lblVehicleType.Margin = new Padding(4, 0, 4, 0);
            lblVehicleType.Name = "lblVehicleType";
            lblVehicleType.Size = new Size(100, 39);
            lblVehicleType.TabIndex = 33;
            lblVehicleType.Text = "Loại xe";
            lblVehicleType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbUser
            // 
            cbUser.Dock = DockStyle.Fill;
            cbUser.DropDownStyle = ComboBoxStyle.DropDownList;
            cbUser.FormattingEnabled = true;
            cbUser.Location = new Point(112, 120);
            cbUser.Margin = new Padding(4, 3, 4, 3);
            cbUser.Name = "cbUser";
            cbUser.Size = new Size(230, 29);
            cbUser.TabIndex = 6;
            // 
            // lblLane
            // 
            lblLane.BackColor = Color.Transparent;
            lblLane.Dock = DockStyle.Fill;
            lblLane.Location = new Point(380, 117);
            lblLane.Margin = new Padding(4, 0, 4, 0);
            lblLane.Name = "lblLane";
            lblLane.Size = new Size(80, 39);
            lblLane.TabIndex = 33;
            lblLane.Text = "Làn";
            lblLane.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblIdentityType
            // 
            lblIdentityType.BackColor = Color.Transparent;
            lblIdentityType.Dock = DockStyle.Fill;
            lblIdentityType.Location = new Point(380, 78);
            lblIdentityType.Margin = new Padding(4, 0, 4, 0);
            lblIdentityType.Name = "lblIdentityType";
            lblIdentityType.Size = new Size(80, 39);
            lblIdentityType.TabIndex = 33;
            lblIdentityType.Text = "Nhóm thẻ";
            lblIdentityType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbVehicleType
            // 
            cbVehicleType.Dock = DockStyle.Fill;
            cbVehicleType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbVehicleType.FormattingEnabled = true;
            cbVehicleType.Location = new Point(112, 81);
            cbVehicleType.Margin = new Padding(4, 3, 4, 3);
            cbVehicleType.Name = "cbVehicleType";
            cbVehicleType.Size = new Size(230, 29);
            cbVehicleType.TabIndex = 4;
            // 
            // picGuide
            // 
            picGuide.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picGuide.Location = new Point(1640, 12);
            picGuide.Name = "picGuide";
            picGuide.Size = new Size(29, 29);
            picGuide.SizeMode = PictureBoxSizeMode.Zoom;
            picGuide.TabIndex = 67;
            picGuide.TabStop = false;
            toolTip1.SetToolTip(picGuide, "\r\nBấm chuột phải vào bản ghi để mở tính năng bổ sung\r\n");
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(13, 10);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(39, 21);
            lblTitle.TabIndex = 65;
            lblTitle.Text = "Title";
            // 
            // ucPages1
            // 
            ucPages1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ucPages1.BackColor = Color.Transparent;
            ucPages1.BorderStyle = BorderStyle.Fixed3D;
            ucPages1.CurrentPage = 1;
            ucPages1.Font = new Font("Segoe UI", 12F);
            ucPages1.Location = new Point(9, 652);
            ucPages1.Margin = new Padding(4, 3, 4, 3);
            ucPages1.MaxPage = 0;
            ucPages1.MinimumSize = new Size(0, 44);
            ucPages1.Name = "ucPages1";
            ucPages1.Size = new Size(1551, 50);
            ucPages1.TabIndex = 43;
            ucPages1.Visible = false;
            // 
            // toolTip1
            // 
            toolTip1.IsBalloon = true;
            // 
            // frmReportIn
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1682, 760);
            Controls.Add(panelData);
            Font = new Font("Segoe UI", 12F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
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
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picGuide).EndInit();
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
        private Label lblTotalEvents;
        private LblCancel btnCancel;
        private BtnSearch btnSearch;
        private BtnExcel btnExportExcel;
        private Panel panelData;
        private Label lblIdentityType;
        private Label lblVehicleType;
        private ComboBox cbIdentityGroupType;
        private ComboBox cbVehicleType;
        private ComboBox cbLane;
        private Label lblLane;
        private Label lblTitle;
        private ComboBox cbUser;
        private ucPages ucPages1;
        private PictureBox picGuide;
        private ToolTip toolTip1;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn event_id;
        private DataGridViewTextBoxColumn identity_id;
        private DataGridViewTextBoxColumn lane_in_id;
        private DataGridViewTextBoxColumn file_keys;
        private DataGridViewTextBoxColumn customer_id;
        private DataGridViewTextBoxColumn register_vehicle_id;
        private DataGridViewTextBoxColumn index;
        private DataGridViewTextBoxColumn plate;
        private DataGridViewTextBoxColumn time_in;
        private DataGridViewTextBoxColumn note;
        private DataGridViewTextBoxColumn identity_group_name;
        private DataGridViewTextBoxColumn user;
        private DataGridViewTextBoxColumn lane_in_name;
        private DataGridViewTextBoxColumn identity_name;
        private DataGridViewTextBoxColumn identity_code;
        private DataGridViewTextBoxColumn register_plate;
        private DataGridViewTextBoxColumn customer;
        private DataGridViewButtonColumn see_more;
        private TableLayoutPanel panelSearch;
        private Label lblUser;
    }
}