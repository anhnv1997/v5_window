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
            dtpEndTime = new DateTimePicker();
            dtpStartTime = new DateTimePicker();
            lblEndTime = new Label();
            lblStartTime = new Label();
            lblTotalEvents = new Label();
            btnCancel = new LblCancel();
            btnSearch = new BtnSearch();
            btnExportExcel = new BtnExcel();
            panelData = new Panel();
            lblTQ = new Label();
            lblVN = new Label();
            pictureBox1 = new PictureBox();
            lblUser = new Label();
            lblTitle = new Label();
            cbLane = new ComboBox();
            cbIdentityGroupType = new ComboBox();
            cbUser = new ComboBox();
            cbVehicleType = new ComboBox();
            ucEventInInfo1 = new ucEventInInfo();
            ucNotify1 = new Usercontrols.BuildControls.ucNotify();
            ucLoading1 = new Usercontrols.BuildControls.ucLoading();
            lblLane = new Label();
            lblVehicleType = new Label();
            lblIdentityType = new Label();
            ucPages1 = new ucPages();
            toolTip1 = new ToolTip(components);
            id = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            plate = new DataGridViewTextBoxColumn();
            vehicle_reagion_type = new DataGridViewTextBoxColumn();
            timeIn = new DataGridViewTextBoxColumn();
            warehouse = new DataGridViewTextBoxColumn();
            warehouse_code = new DataGridViewTextBoxColumn();
            NoteBSX = new DataGridViewTextBoxColumn();
            note_3rd_1 = new DataGridViewTextBoxColumn();
            note_3rd_2 = new DataGridViewTextBoxColumn();
            Column10 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            identityName = new DataGridViewTextBoxColumn();
            Column16 = new DataGridViewTextBoxColumn();
            Column12 = new DataGridViewTextBoxColumn();
            Column11 = new DataGridViewTextBoxColumn();
            note_3rd_3 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            FileIds = new DataGridViewTextBoxColumn();
            Column13 = new DataGridViewTextBoxColumn();
            Column14 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)picOverviewImageIn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picVehicleImageIn).BeginInit();
            tablePic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            panelData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            lblKeyword.AutoSize = true;
            lblKeyword.BackColor = Color.Transparent;
            lblKeyword.Location = new Point(15, 57);
            lblKeyword.Margin = new Padding(4, 0, 4, 0);
            lblKeyword.Name = "lblKeyword";
            lblKeyword.Size = new Size(65, 21);
            lblKeyword.TabIndex = 41;
            lblKeyword.Text = "Từ khóa";
            // 
            // txtKeyword
            // 
            txtKeyword.Location = new Point(143, 46);
            txtKeyword.Margin = new Padding(4, 3, 4, 3);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.PlaceholderText = "Biển số, tên định danh, mã định danh";
            txtKeyword.Size = new Size(766, 29);
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
            dgvData.Columns.AddRange(new DataGridViewColumn[] { id, Column1, Column2, plate, vehicle_reagion_type, timeIn, warehouse, warehouse_code, NoteBSX, note_3rd_1, note_3rd_2, Column10, Column6, Column4, identityName, Column16, Column12, Column11, note_3rd_3, Column5, FileIds, Column13, Column14, Column3 });
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
            // dtpEndTime
            // 
            dtpEndTime.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(589, 98);
            dtpEndTime.Margin = new Padding(4, 3, 4, 3);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.Size = new Size(320, 29);
            dtpEndTime.TabIndex = 3;
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(141, 108);
            dtpStartTime.Margin = new Padding(4, 3, 4, 3);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.Size = new Size(320, 29);
            dtpStartTime.TabIndex = 2;
            // 
            // lblEndTime
            // 
            lblEndTime.AutoSize = true;
            lblEndTime.BackColor = Color.Transparent;
            lblEndTime.Location = new Point(471, 106);
            lblEndTime.Margin = new Padding(4, 0, 4, 0);
            lblEndTime.Name = "lblEndTime";
            lblEndTime.Size = new Size(74, 21);
            lblEndTime.TabIndex = 32;
            lblEndTime.Text = "Kết thúc  ";
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.BackColor = Color.Transparent;
            lblStartTime.Location = new Point(17, 116);
            lblStartTime.Margin = new Padding(4, 0, 4, 0);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(62, 21);
            lblStartTime.TabIndex = 33;
            lblStartTime.Text = "Bắt đầu";
            // 
            // lblTotalEvents
            // 
            lblTotalEvents.AutoSize = true;
            lblTotalEvents.BackColor = Color.Transparent;
            lblTotalEvents.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalEvents.ForeColor = Color.FromArgb(253, 149, 40);
            lblTotalEvents.Location = new Point(1034, 200);
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
            btnSearch.Location = new Point(918, 199);
            btnSearch.Margin = new Padding(4, 3, 4, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(108, 42);
            btnSearch.TabIndex = 60;
            btnSearch.Text = "Tìm kiếm";
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
            panelData.Controls.Add(lblTQ);
            panelData.Controls.Add(lblVN);
            panelData.Controls.Add(pictureBox1);
            panelData.Controls.Add(lblUser);
            panelData.Controls.Add(lblTitle);
            panelData.Controls.Add(cbLane);
            panelData.Controls.Add(cbIdentityGroupType);
            panelData.Controls.Add(cbUser);
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
            panelData.Font = new Font("Segoe UI", 12F);
            panelData.Location = new Point(0, 0);
            panelData.Margin = new Padding(4, 3, 4, 3);
            panelData.Name = "panelData";
            panelData.Size = new Size(1682, 760);
            panelData.TabIndex = 62;
            // 
            // lblTQ
            // 
            lblTQ.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTQ.AutoSize = true;
            lblTQ.BackColor = Color.Transparent;
            lblTQ.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTQ.ForeColor = Color.Red;
            lblTQ.Location = new Point(12, 724);
            lblTQ.Margin = new Padding(4, 0, 4, 0);
            lblTQ.Name = "lblTQ";
            lblTQ.Size = new Size(52, 32);
            lblTQ.TabIndex = 68;
            lblTQ.Text = "TQ:";
            // 
            // lblVN
            // 
            lblVN.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblVN.AutoSize = true;
            lblVN.BackColor = Color.Transparent;
            lblVN.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblVN.ForeColor = Color.Red;
            lblVN.Location = new Point(9, 683);
            lblVN.Margin = new Padding(4, 0, 4, 0);
            lblVN.Name = "lblVN";
            lblVN.Size = new Size(56, 32);
            lblVN.TabIndex = 69;
            lblVN.Text = "VN:";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.Image = Properties.Resources.noti_question_64;
            pictureBox1.Location = new Point(1640, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(29, 29);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 67;
            pictureBox1.TabStop = false;
            toolTip1.SetToolTip(pictureBox1, "\r\nBấm chuột phải vào bản ghi để mở tính năng bổ sung\r\n");
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(15, 196);
            lblUser.Margin = new Padding(4, 0, 4, 0);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(94, 21);
            lblUser.TabIndex = 66;
            lblUser.Text = "Người dùng";
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
            // cbLane
            // 
            cbLane.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLane.FormattingEnabled = true;
            cbLane.Location = new Point(589, 196);
            cbLane.Margin = new Padding(4, 3, 4, 3);
            cbLane.Name = "cbLane";
            cbLane.Size = new Size(320, 29);
            cbLane.TabIndex = 7;
            // 
            // cbIdentityGroupType
            // 
            cbIdentityGroupType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbIdentityGroupType.FormattingEnabled = true;
            cbIdentityGroupType.Location = new Point(589, 148);
            cbIdentityGroupType.Margin = new Padding(4, 3, 4, 3);
            cbIdentityGroupType.Name = "cbIdentityGroupType";
            cbIdentityGroupType.Size = new Size(320, 29);
            cbIdentityGroupType.TabIndex = 5;
            // 
            // cbUser
            // 
            cbUser.DropDownStyle = ComboBoxStyle.DropDownList;
            cbUser.FormattingEnabled = true;
            cbUser.Location = new Point(141, 200);
            cbUser.Margin = new Padding(4, 3, 4, 3);
            cbUser.Name = "cbUser";
            cbUser.Size = new Size(320, 29);
            cbUser.TabIndex = 6;
            // 
            // cbVehicleType
            // 
            cbVehicleType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbVehicleType.FormattingEnabled = true;
            cbVehicleType.Location = new Point(141, 154);
            cbVehicleType.Margin = new Padding(4, 3, 4, 3);
            cbVehicleType.Name = "cbVehicleType";
            cbVehicleType.Size = new Size(320, 29);
            cbVehicleType.TabIndex = 4;
            // 
            // ucEventInInfo1
            // 
            ucEventInInfo1.BackColor = Color.FromArgb(255, 224, 192);
            ucEventInInfo1.Location = new Point(687, 59);
            ucEventInInfo1.Margin = new Padding(4, 3, 4, 3);
            ucEventInInfo1.Name = "ucEventInInfo1";
            ucEventInInfo1.Size = new Size(555, 476);
            ucEventInInfo1.TabIndex = 64;
            // 
            // ucNotify1
            // 
            ucNotify1.BackColor = Color.FromArgb(255, 224, 192);
            ucNotify1.Location = new Point(657, 69);
            ucNotify1.Margin = new Padding(4, 3, 4, 3);
            ucNotify1.MaximumSize = new Size(374, 374);
            ucNotify1.Message = "Nội dung thông báo";
            ucNotify1.MinimumSize = new Size(374, 374);
            ucNotify1.Name = "ucNotify1";
            ucNotify1.NotiType = Usercontrols.BuildControls.ucNotify.EmNotiType.Information;
            ucNotify1.Size = new Size(374, 374);
            ucNotify1.TabIndex = 63;
            // 
            // ucLoading1
            // 
            ucLoading1.BackColor = Color.FromArgb(255, 224, 192);
            ucLoading1.Language = IPaking.Ultility.TextManagement.EmLanguage.Vietnamese;
            ucLoading1.Location = new Point(710, 53);
            ucLoading1.Margin = new Padding(4, 3, 4, 3);
            ucLoading1.Message = "Preparing to download";
            ucLoading1.Name = "ucLoading1";
            ucLoading1.Size = new Size(441, 197);
            ucLoading1.TabIndex = 62;
            // 
            // lblLane
            // 
            lblLane.AutoSize = true;
            lblLane.BackColor = Color.Transparent;
            lblLane.Location = new Point(473, 204);
            lblLane.Margin = new Padding(4, 0, 4, 0);
            lblLane.Name = "lblLane";
            lblLane.Size = new Size(35, 21);
            lblLane.TabIndex = 33;
            lblLane.Text = "Làn";
            // 
            // lblVehicleType
            // 
            lblVehicleType.AutoSize = true;
            lblVehicleType.BackColor = Color.Transparent;
            lblVehicleType.Location = new Point(17, 153);
            lblVehicleType.Margin = new Padding(4, 0, 4, 0);
            lblVehicleType.Name = "lblVehicleType";
            lblVehicleType.Size = new Size(58, 21);
            lblVehicleType.TabIndex = 33;
            lblVehicleType.Text = "Loại xe";
            // 
            // lblIdentityType
            // 
            lblIdentityType.AutoSize = true;
            lblIdentityType.BackColor = Color.Transparent;
            lblIdentityType.Location = new Point(471, 158);
            lblIdentityType.Margin = new Padding(4, 0, 4, 0);
            lblIdentityType.Name = "lblIdentityType";
            lblIdentityType.Size = new Size(80, 21);
            lblIdentityType.TabIndex = 33;
            lblIdentityType.Text = "Nhóm thẻ";
            // 
            // ucPages1
            // 
            ucPages1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ucPages1.BackColor = Color.Transparent;
            ucPages1.BorderStyle = BorderStyle.Fixed3D;
            ucPages1.Location = new Point(4, 630);
            ucPages1.Margin = new Padding(4, 3, 4, 3);
            ucPages1.Name = "ucPages1";
            ucPages1.Size = new Size(1551, 50);
            ucPages1.TabIndex = 43;
            ucPages1.Visible = false;
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
            id.Width = 35;
            // 
            // Column1
            // 
            Column1.HeaderText = "STT";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 66;
            // 
            // Column2
            // 
            Column2.HeaderText = "Tên Định Danh";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Visible = false;
            Column2.Width = 142;
            // 
            // plate
            // 
            plate.HeaderText = "Biển Số Xe";
            plate.Name = "plate";
            plate.ReadOnly = true;
            plate.Width = 114;
            // 
            // vehicle_reagion_type
            // 
            vehicle_reagion_type.HeaderText = "Xe VN/TQ";
            vehicle_reagion_type.Name = "vehicle_reagion_type";
            vehicle_reagion_type.ReadOnly = true;
            vehicle_reagion_type.Width = 110;
            // 
            // timeIn
            // 
            timeIn.HeaderText = "Giờ Vào";
            timeIn.Name = "timeIn";
            timeIn.ReadOnly = true;
            timeIn.Width = 96;
            // 
            // warehouse
            // 
            warehouse.HeaderText = "Phân loại";
            warehouse.Name = "warehouse";
            warehouse.ReadOnly = true;
            warehouse.Width = 105;
            // 
            // warehouse_code
            // 
            warehouse_code.HeaderText = "Số phiếu xuất";
            warehouse_code.Name = "warehouse_code";
            warehouse_code.ReadOnly = true;
            warehouse_code.Width = 135;
            // 
            // NoteBSX
            // 
            NoteBSX.HeaderText = "Ghi chú BSX";
            NoteBSX.Name = "NoteBSX";
            NoteBSX.ReadOnly = true;
            NoteBSX.Width = 125;
            // 
            // note_3rd_1
            // 
            note_3rd_1.HeaderText = "Lý do chặn kích xe";
            note_3rd_1.Name = "note_3rd_1";
            note_3rd_1.ReadOnly = true;
            note_3rd_1.Width = 166;
            // 
            // note_3rd_2
            // 
            note_3rd_2.HeaderText = "Ghi chú DVHT";
            note_3rd_2.Name = "note_3rd_2";
            note_3rd_2.ReadOnly = true;
            note_3rd_2.Width = 138;
            // 
            // Column10
            // 
            Column10.HeaderText = "Nhóm";
            Column10.Name = "Column10";
            Column10.ReadOnly = true;
            Column10.Width = 85;
            // 
            // Column6
            // 
            Column6.HeaderText = "Người Dùng";
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            Column6.Width = 127;
            // 
            // Column4
            // 
            Column4.HeaderText = "Làn vào";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Width = 95;
            // 
            // identityName
            // 
            identityName.HeaderText = "Tên Thẻ";
            identityName.Name = "identityName";
            identityName.ReadOnly = true;
            identityName.Width = 93;
            // 
            // Column16
            // 
            Column16.HeaderText = "Mã Thẻ";
            Column16.Name = "Column16";
            Column16.ReadOnly = true;
            Column16.Width = 92;
            // 
            // Column12
            // 
            Column12.HeaderText = "Biển số đăng ký";
            Column12.Name = "Column12";
            Column12.ReadOnly = true;
            Column12.Width = 150;
            // 
            // Column11
            // 
            Column11.HeaderText = "Khách hàng";
            Column11.Name = "Column11";
            Column11.ReadOnly = true;
            Column11.Width = 122;
            // 
            // note_3rd_3
            // 
            note_3rd_3.HeaderText = "Người cho phép ra";
            note_3rd_3.Name = "note_3rd_3";
            note_3rd_3.ReadOnly = true;
            note_3rd_3.Width = 171;
            // 
            // Column5
            // 
            Column5.HeaderText = "Làn Vào Id";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.Visible = false;
            Column5.Width = 113;
            // 
            // FileIds
            // 
            FileIds.HeaderText = "physicalFileIds";
            FileIds.Name = "FileIds";
            FileIds.ReadOnly = true;
            FileIds.Visible = false;
            FileIds.Width = 141;
            // 
            // Column13
            // 
            Column13.HeaderText = "customerID";
            Column13.Name = "Column13";
            Column13.ReadOnly = true;
            Column13.Visible = false;
            Column13.Width = 121;
            // 
            // Column14
            // 
            Column14.HeaderText = "registerVehicleId";
            Column14.Name = "Column14";
            Column14.ReadOnly = true;
            Column14.Visible = false;
            Column14.Width = 156;
            // 
            // Column3
            // 
            Column3.HeaderText = "Xem Thêm";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Visible = false;
            Column3.Width = 96;
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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private Label lblUser;
        private ComboBox cbUser;
        private ucPages ucPages1;
        private PictureBox pictureBox1;
        private ToolTip toolTip1;
        private DataGridViewTextBoxColumn Column9;
        private Label lblTQ;
        private Label lblVN;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn plate;
        private DataGridViewTextBoxColumn vehicle_reagion_type;
        private DataGridViewTextBoxColumn timeIn;
        private DataGridViewTextBoxColumn warehouse;
        private DataGridViewTextBoxColumn warehouse_code;
        private DataGridViewTextBoxColumn NoteBSX;
        private DataGridViewTextBoxColumn note_3rd_1;
        private DataGridViewTextBoxColumn note_3rd_2;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn identityName;
        private DataGridViewTextBoxColumn Column16;
        private DataGridViewTextBoxColumn Column12;
        private DataGridViewTextBoxColumn Column11;
        private DataGridViewTextBoxColumn note_3rd_3;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn FileIds;
        private DataGridViewTextBoxColumn Column13;
        private DataGridViewTextBoxColumn Column14;
        private DataGridViewButtonColumn Column3;
    }
}