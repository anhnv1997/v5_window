using iPakrkingv5.Controls.Controls.Buttons;
using iPakrkingv5.Controls.Usercontrols;
using System.Windows.Forms;

namespace iParkingv5.Reporting
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
            dtpEndTime = new DateTimePicker();
            dtpStartTime = new DateTimePicker();
            lblStartTime = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            picOverviewImageIn = new MovablePictureBox();
            picVehicleImageIn = new MovablePictureBox();
            lblKeyword = new Label();
            txtKeyword = new TextBox();
            dgvData = new DataGridView();
            event_out_id = new DataGridViewTextBoxColumn();
            event_in_id = new DataGridViewTextBoxColumn();
            invoice_pending_id = new DataGridViewTextBoxColumn();
            invoice_id = new DataGridViewTextBoxColumn();
            index = new DataGridViewTextBoxColumn();
            plate_in = new DataGridViewTextBoxColumn();
            plate_out = new DataGridViewTextBoxColumn();
            time_in = new DataGridViewTextBoxColumn();
            time_out = new DataGridViewTextBoxColumn();
            parking_time = new DataGridViewTextBoxColumn();
            identity_group_name = new DataGridViewTextBoxColumn();
            parking_fee = new DataGridViewTextBoxColumn();
            identity_code = new DataGridViewTextBoxColumn();
            user_in = new DataGridViewTextBoxColumn();
            user_out = new DataGridViewTextBoxColumn();
            invoice_template = new DataGridViewTextBoxColumn();
            invoice_no = new DataGridViewTextBoxColumn();
            lane_in_name = new DataGridViewTextBoxColumn();
            lane_out_name = new DataGridViewTextBoxColumn();
            note = new DataGridViewTextBoxColumn();
            file_keys_in = new DataGridViewTextBoxColumn();
            file_keys_out = new DataGridViewTextBoxColumn();
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
            panelSearch = new TableLayoutPanel();
            cbLane = new ComboBox();
            cbUser = new ComboBox();
            cbIdentityGroup = new ComboBox();
            lblUser = new Label();
            lblVehicleType = new Label();
            cbVehicleType = new ComboBox();
            lblIdentityGroup = new Label();
            lblLane = new Label();
            btnPrintPhieuThu = new BtnPrint();
            tablePic = new TableLayoutPanel();
            toolTip1 = new ToolTip(components);
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picOverviewImageIn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picVehicleImageIn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picOverviewImageOut).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picVehicleImageOut).BeginInit();
            panelData.SuspendLayout();
            panelSearch.SuspendLayout();
            tablePic.SuspendLayout();
            SuspendLayout();
            // 
            // dtpEndTime
            // 
            dtpEndTime.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            dtpEndTime.Dock = DockStyle.Fill;
            dtpEndTime.Font = new Font("Segoe UI", 12F);
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(442, 38);
            dtpEndTime.Margin = new Padding(4, 3, 4, 3);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.Size = new Size(200, 29);
            dtpEndTime.TabIndex = 3;
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            dtpStartTime.Dock = DockStyle.Fill;
            dtpStartTime.Font = new Font("Segoe UI", 12F);
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(106, 38);
            dtpStartTime.Margin = new Padding(4, 3, 4, 3);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.Size = new Size(200, 29);
            dtpStartTime.TabIndex = 2;
            // 
            // lblStartTime
            // 
            lblStartTime.BackColor = Color.Transparent;
            lblStartTime.Dock = DockStyle.Fill;
            lblStartTime.Font = new Font("Segoe UI", 12F);
            lblStartTime.Location = new Point(4, 35);
            lblStartTime.Margin = new Padding(4, 0, 4, 0);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(94, 35);
            lblStartTime.TabIndex = 44;
            lblStartTime.Text = "Bắt đầu";
            lblStartTime.TextAlign = ContentAlignment.MiddleLeft;
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
            tableLayoutPanel1.Size = new Size(252, 493);
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
            picOverviewImageIn.Size = new Size(252, 246);
            picOverviewImageIn.SizeMode = PictureBoxSizeMode.StretchImage;
            picOverviewImageIn.TabIndex = 30;
            picOverviewImageIn.TabStop = false;
            toolTip1.SetToolTip(picOverviewImageIn, "Kích đúp chuột để xem hình ảnh phóng to");
            picOverviewImageIn.LoadCompleted += Pic_LoadCompleted;
            // 
            // picVehicleImageIn
            // 
            picVehicleImageIn.BackColor = Color.WhiteSmoke;
            picVehicleImageIn.BorderStyle = BorderStyle.FixedSingle;
            picVehicleImageIn.Dock = DockStyle.Fill;
            picVehicleImageIn.Location = new Point(0, 246);
            picVehicleImageIn.Margin = new Padding(0);
            picVehicleImageIn.Name = "picVehicleImageIn";
            picVehicleImageIn.Size = new Size(252, 247);
            picVehicleImageIn.SizeMode = PictureBoxSizeMode.StretchImage;
            picVehicleImageIn.TabIndex = 29;
            picVehicleImageIn.TabStop = false;
            toolTip1.SetToolTip(picVehicleImageIn, "Kích đúp chuột để xem hình ảnh phóng to");
            picVehicleImageIn.LoadCompleted += Pic_LoadCompleted;
            // 
            // lblKeyword
            // 
            lblKeyword.BackColor = Color.Transparent;
            lblKeyword.Dock = DockStyle.Fill;
            lblKeyword.Font = new Font("Segoe UI", 12F);
            lblKeyword.Location = new Point(4, 0);
            lblKeyword.Margin = new Padding(4, 0, 4, 0);
            lblKeyword.Name = "lblKeyword";
            lblKeyword.Size = new Size(94, 35);
            lblKeyword.TabIndex = 52;
            lblKeyword.Text = "Từ khóa";
            lblKeyword.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtKeyword
            // 
            panelSearch.SetColumnSpan(txtKeyword, 4);
            txtKeyword.Dock = DockStyle.Fill;
            txtKeyword.Font = new Font("Segoe UI", 12F);
            txtKeyword.Location = new Point(106, 3);
            txtKeyword.Margin = new Padding(4, 3, 4, 3);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.PlaceholderText = "Biển số, tên định danh, mã định danh";
            txtKeyword.Size = new Size(536, 29);
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
            dgvData.Columns.AddRange(new DataGridViewColumn[] { event_out_id, event_in_id, invoice_pending_id, invoice_id, index, plate_in, plate_out, time_in, time_out, parking_time, identity_group_name, parking_fee, identity_code, user_in, user_out, invoice_template, invoice_no, lane_in_name, lane_out_name, note, file_keys_in, file_keys_out });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.Padding = new Padding(3);
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvData.DefaultCellStyle = dataGridViewCellStyle4;
            dgvData.Location = new Point(15, 171);
            dgvData.Margin = new Padding(4, 3, 4, 3);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowHeadersVisible = false;
            dgvData.RowTemplate.Height = 29;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.Size = new Size(813, 493);
            dgvData.TabIndex = 50;
            dgvData.CellMouseClick += dgvData_CellMouseClick;
            dgvData.MouseClick += dgvData_MouseClick;
            // 
            // event_out_id
            // 
            event_out_id.HeaderText = "id";
            event_out_id.Name = "event_out_id";
            event_out_id.ReadOnly = true;
            event_out_id.Visible = false;
            event_out_id.Width = 35;
            // 
            // event_in_id
            // 
            event_in_id.HeaderText = "eventInId";
            event_in_id.Name = "event_in_id";
            event_in_id.ReadOnly = true;
            event_in_id.Visible = false;
            event_in_id.Width = 86;
            // 
            // invoice_pending_id
            // 
            invoice_pending_id.HeaderText = "invoice_pending_id";
            invoice_pending_id.Name = "invoice_pending_id";
            invoice_pending_id.ReadOnly = true;
            invoice_pending_id.Visible = false;
            invoice_pending_id.Width = 155;
            // 
            // invoice_id
            // 
            invoice_id.HeaderText = "invoiceId";
            invoice_id.Name = "invoice_id";
            invoice_id.ReadOnly = true;
            invoice_id.Visible = false;
            invoice_id.Width = 84;
            // 
            // index
            // 
            index.HeaderText = "STT";
            index.Name = "index";
            index.ReadOnly = true;
            index.Width = 66;
            // 
            // plate_in
            // 
            plate_in.HeaderText = "Biển Số Vào";
            plate_in.Name = "plate_in";
            plate_in.ReadOnly = true;
            plate_in.Width = 123;
            // 
            // plate_out
            // 
            plate_out.HeaderText = "Biển Số Ra";
            plate_out.Name = "plate_out";
            plate_out.ReadOnly = true;
            plate_out.Width = 115;
            // 
            // time_in
            // 
            time_in.HeaderText = "Giờ Vào";
            time_in.Name = "time_in";
            time_in.ReadOnly = true;
            time_in.Width = 96;
            // 
            // time_out
            // 
            time_out.HeaderText = "Giờ Ra";
            time_out.Name = "time_out";
            time_out.ReadOnly = true;
            time_out.Width = 88;
            // 
            // parking_time
            // 
            parking_time.HeaderText = "Thời Gian Lưu Bãi";
            parking_time.Name = "parking_time";
            parking_time.ReadOnly = true;
            parking_time.Width = 163;
            // 
            // identity_group_name
            // 
            identity_group_name.HeaderText = "Loại";
            identity_group_name.Name = "identity_group_name";
            identity_group_name.ReadOnly = true;
            identity_group_name.Width = 70;
            // 
            // parking_fee
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            parking_fee.DefaultCellStyle = dataGridViewCellStyle3;
            parking_fee.HeaderText = "Phí";
            parking_fee.Name = "parking_fee";
            parking_fee.ReadOnly = true;
            parking_fee.Width = 63;
            // 
            // identity_code
            // 
            identity_code.HeaderText = "Vé Xe";
            identity_code.Name = "identity_code";
            identity_code.ReadOnly = true;
            identity_code.Width = 79;
            // 
            // user_in
            // 
            user_in.HeaderText = "Người Dùng Vào";
            user_in.Name = "user_in";
            user_in.ReadOnly = true;
            user_in.Width = 157;
            // 
            // user_out
            // 
            user_out.HeaderText = "Người Dùng Ra";
            user_out.Name = "user_out";
            user_out.ReadOnly = true;
            user_out.Width = 149;
            // 
            // invoice_template
            // 
            invoice_template.HeaderText = "Mẫu hóa đơn";
            invoice_template.Name = "invoice_template";
            invoice_template.ReadOnly = true;
            invoice_template.Width = 134;
            // 
            // invoice_no
            // 
            invoice_no.HeaderText = "Số hóa đơn";
            invoice_no.Name = "invoice_no";
            invoice_no.ReadOnly = true;
            invoice_no.Width = 121;
            // 
            // lane_in_name
            // 
            lane_in_name.HeaderText = "Làn Vào";
            lane_in_name.Name = "lane_in_name";
            lane_in_name.ReadOnly = true;
            lane_in_name.Width = 96;
            // 
            // lane_out_name
            // 
            lane_out_name.HeaderText = "Làn Ra";
            lane_out_name.Name = "lane_out_name";
            lane_out_name.ReadOnly = true;
            lane_out_name.Width = 88;
            // 
            // note
            // 
            note.HeaderText = "Ghi Chú";
            note.Name = "note";
            note.ReadOnly = true;
            note.Width = 97;
            // 
            // file_keys_in
            // 
            file_keys_in.HeaderText = "physicalFileIdIns";
            file_keys_in.Name = "file_keys_in";
            file_keys_in.ReadOnly = true;
            file_keys_in.Visible = false;
            file_keys_in.Width = 154;
            // 
            // file_keys_out
            // 
            file_keys_out.HeaderText = "physicalIdOuts";
            file_keys_out.Name = "file_keys_out";
            file_keys_out.ReadOnly = true;
            file_keys_out.Visible = false;
            file_keys_out.Width = 143;
            // 
            // lblEndTime
            // 
            lblEndTime.BackColor = Color.Transparent;
            lblEndTime.Dock = DockStyle.Fill;
            lblEndTime.Font = new Font("Segoe UI", 12F);
            lblEndTime.Location = new Point(354, 35);
            lblEndTime.Margin = new Padding(4, 0, 4, 0);
            lblEndTime.Name = "lblEndTime";
            lblEndTime.Size = new Size(80, 35);
            lblEndTime.TabIndex = 43;
            lblEndTime.Text = "Kết thúc  ";
            lblEndTime.TextAlign = ContentAlignment.MiddleLeft;
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
            tableLayoutPanel2.Size = new Size(252, 493);
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
            picOverviewImageOut.Size = new Size(252, 246);
            picOverviewImageOut.SizeMode = PictureBoxSizeMode.StretchImage;
            picOverviewImageOut.TabIndex = 30;
            picOverviewImageOut.TabStop = false;
            toolTip1.SetToolTip(picOverviewImageOut, "Kích đúp chuột để xem hình ảnh phóng to");
            picOverviewImageOut.LoadCompleted += Pic_LoadCompleted;
            // 
            // picVehicleImageOut
            // 
            picVehicleImageOut.BackColor = Color.WhiteSmoke;
            picVehicleImageOut.BorderStyle = BorderStyle.FixedSingle;
            picVehicleImageOut.Dock = DockStyle.Fill;
            picVehicleImageOut.Location = new Point(0, 246);
            picVehicleImageOut.Margin = new Padding(0);
            picVehicleImageOut.Name = "picVehicleImageOut";
            picVehicleImageOut.Size = new Size(252, 247);
            picVehicleImageOut.SizeMode = PictureBoxSizeMode.StretchImage;
            picVehicleImageOut.TabIndex = 29;
            picVehicleImageOut.TabStop = false;
            toolTip1.SetToolTip(picVehicleImageOut, "Kích đúp chuột để xem hình ảnh phóng to");
            picVehicleImageOut.LoadCompleted += Pic_LoadCompleted;
            // 
            // ucPages1
            // 
            ucPages1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ucPages1.BackColor = Color.Transparent;
            ucPages1.BorderStyle = BorderStyle.Fixed3D;
            ucPages1.CurrentPage = 0;
            ucPages1.Font = new Font("Segoe UI", 12F);
            ucPages1.Location = new Point(15, 689);
            ucPages1.Margin = new Padding(4, 3, 4, 3);
            ucPages1.MaxPage = 0;
            ucPages1.MinimumSize = new Size(0, 44);
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
            lblTotalEvents.Location = new Point(959, 112);
            lblTotalEvents.Margin = new Padding(4, 0, 4, 0);
            lblTotalEvents.Name = "lblTotalEvents";
            lblTotalEvents.Size = new Size(163, 50);
            lblTotalEvents.TabIndex = 56;
            lblTotalEvents.Text = "Tổng số sự kiện: \r\nTổng phí gửi xe: ";
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
            btnSearch.Location = new Point(677, 120);
            btnSearch.Margin = new Padding(4, 3, 4, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(108, 42);
            btnSearch.TabIndex = 58;
            btnSearch.Text = "Tìm kiếm";
            toolTip1.SetToolTip(btnSearch, "Click chuột hoặc bấm Enter để tìm kiếm");
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
            panelData.Controls.Add(panelSearch);
            panelData.Controls.Add(btnPrintPhieuThu);
            panelData.Controls.Add(tablePic);
            panelData.Controls.Add(btnExportExcel);
            panelData.Controls.Add(btnCancel);
            panelData.Controls.Add(btnSearch);
            panelData.Controls.Add(ucPages1);
            panelData.Controls.Add(lblTotalEvents);
            panelData.Controls.Add(dgvData);
            panelData.Dock = DockStyle.Fill;
            panelData.Font = new Font("Segoe UI", 12F);
            panelData.Location = new Point(0, 0);
            panelData.Margin = new Padding(4, 3, 4, 3);
            panelData.Name = "panelData";
            panelData.Size = new Size(1376, 805);
            panelData.TabIndex = 60;
            // 
            // panelSearch
            // 
            panelSearch.AutoSize = true;
            panelSearch.ColumnCount = 5;
            panelSearch.ColumnStyles.Add(new ColumnStyle());
            panelSearch.ColumnStyles.Add(new ColumnStyle());
            panelSearch.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            panelSearch.ColumnStyles.Add(new ColumnStyle());
            panelSearch.ColumnStyles.Add(new ColumnStyle());
            panelSearch.Controls.Add(lblKeyword, 0, 0);
            panelSearch.Controls.Add(lblStartTime, 0, 1);
            panelSearch.Controls.Add(cbLane, 4, 3);
            panelSearch.Controls.Add(cbUser, 1, 3);
            panelSearch.Controls.Add(cbIdentityGroup, 4, 2);
            panelSearch.Controls.Add(lblUser, 0, 3);
            panelSearch.Controls.Add(lblVehicleType, 0, 2);
            panelSearch.Controls.Add(lblEndTime, 3, 1);
            panelSearch.Controls.Add(cbVehicleType, 1, 2);
            panelSearch.Controls.Add(lblIdentityGroup, 3, 2);
            panelSearch.Controls.Add(lblLane, 3, 3);
            panelSearch.Controls.Add(txtKeyword, 1, 0);
            panelSearch.Controls.Add(dtpStartTime, 1, 1);
            panelSearch.Controls.Add(dtpEndTime, 4, 1);
            panelSearch.Location = new Point(15, 25);
            panelSearch.Name = "panelSearch";
            panelSearch.RowCount = 4;
            panelSearch.RowStyles.Add(new RowStyle());
            panelSearch.RowStyles.Add(new RowStyle());
            panelSearch.RowStyles.Add(new RowStyle());
            panelSearch.RowStyles.Add(new RowStyle());
            panelSearch.Size = new Size(646, 140);
            panelSearch.TabIndex = 73;
            // 
            // cbLane
            // 
            cbLane.Dock = DockStyle.Fill;
            cbLane.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLane.Font = new Font("Segoe UI", 12F);
            cbLane.FormattingEnabled = true;
            cbLane.Location = new Point(442, 108);
            cbLane.Margin = new Padding(4, 3, 4, 3);
            cbLane.Name = "cbLane";
            cbLane.Size = new Size(200, 29);
            cbLane.TabIndex = 7;
            // 
            // cbUser
            // 
            cbUser.Dock = DockStyle.Fill;
            cbUser.DropDownStyle = ComboBoxStyle.DropDownList;
            cbUser.FormattingEnabled = true;
            cbUser.Location = new Point(106, 108);
            cbUser.Margin = new Padding(4, 3, 4, 3);
            cbUser.Name = "cbUser";
            cbUser.Size = new Size(200, 29);
            cbUser.TabIndex = 6;
            // 
            // cbIdentityGroup
            // 
            cbIdentityGroup.Dock = DockStyle.Fill;
            cbIdentityGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cbIdentityGroup.Font = new Font("Segoe UI", 12F);
            cbIdentityGroup.FormattingEnabled = true;
            cbIdentityGroup.Location = new Point(442, 73);
            cbIdentityGroup.Margin = new Padding(4, 3, 4, 3);
            cbIdentityGroup.Name = "cbIdentityGroup";
            cbIdentityGroup.Size = new Size(200, 29);
            cbIdentityGroup.TabIndex = 5;
            // 
            // lblUser
            // 
            lblUser.Dock = DockStyle.Fill;
            lblUser.Location = new Point(4, 105);
            lblUser.Margin = new Padding(4, 0, 4, 0);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(94, 35);
            lblUser.TabIndex = 71;
            lblUser.Text = "Người dùng";
            lblUser.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblVehicleType
            // 
            lblVehicleType.BackColor = Color.Transparent;
            lblVehicleType.Dock = DockStyle.Fill;
            lblVehicleType.Font = new Font("Segoe UI", 12F);
            lblVehicleType.Location = new Point(4, 70);
            lblVehicleType.Margin = new Padding(4, 0, 4, 0);
            lblVehicleType.Name = "lblVehicleType";
            lblVehicleType.Size = new Size(94, 35);
            lblVehicleType.TabIndex = 66;
            lblVehicleType.Text = "Loại xe";
            lblVehicleType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbVehicleType
            // 
            cbVehicleType.Dock = DockStyle.Fill;
            cbVehicleType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbVehicleType.Font = new Font("Segoe UI", 12F);
            cbVehicleType.FormattingEnabled = true;
            cbVehicleType.Location = new Point(106, 73);
            cbVehicleType.Margin = new Padding(4, 3, 4, 3);
            cbVehicleType.Name = "cbVehicleType";
            cbVehicleType.Size = new Size(200, 29);
            cbVehicleType.TabIndex = 4;
            // 
            // lblIdentityGroup
            // 
            lblIdentityGroup.BackColor = Color.Transparent;
            lblIdentityGroup.Dock = DockStyle.Fill;
            lblIdentityGroup.Font = new Font("Segoe UI", 12F);
            lblIdentityGroup.Location = new Point(354, 70);
            lblIdentityGroup.Margin = new Padding(4, 0, 4, 0);
            lblIdentityGroup.Name = "lblIdentityGroup";
            lblIdentityGroup.Size = new Size(80, 35);
            lblIdentityGroup.TabIndex = 67;
            lblIdentityGroup.Text = "Nhóm thẻ";
            lblIdentityGroup.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblLane
            // 
            lblLane.BackColor = Color.Transparent;
            lblLane.Dock = DockStyle.Fill;
            lblLane.Font = new Font("Segoe UI", 12F);
            lblLane.Location = new Point(354, 105);
            lblLane.Margin = new Padding(4, 0, 4, 0);
            lblLane.Name = "lblLane";
            lblLane.Size = new Size(80, 35);
            lblLane.TabIndex = 69;
            lblLane.Text = "Làn";
            lblLane.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnPrintPhieuThu
            // 
            btnPrintPhieuThu.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnPrintPhieuThu.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnPrintPhieuThu.Location = new Point(793, 120);
            btnPrintPhieuThu.Margin = new Padding(4);
            btnPrintPhieuThu.Name = "btnPrintPhieuThu";
            btnPrintPhieuThu.Size = new Size(158, 42);
            btnPrintPhieuThu.TabIndex = 72;
            btnPrintPhieuThu.Text = "In phiếu thu";
            btnPrintPhieuThu.UseVisualStyleBackColor = true;
            // 
            // tablePic
            // 
            tablePic.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            tablePic.ColumnCount = 2;
            tablePic.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tablePic.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tablePic.Controls.Add(tableLayoutPanel1, 0, 0);
            tablePic.Controls.Add(tableLayoutPanel2, 1, 0);
            tablePic.Location = new Point(847, 171);
            tablePic.Margin = new Padding(0);
            tablePic.Name = "tablePic";
            tablePic.RowCount = 1;
            tablePic.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tablePic.Size = new Size(504, 493);
            tablePic.TabIndex = 60;
            // 
            // toolTip1
            // 
            toolTip1.IsBalloon = true;
            // 
            // frmReportInOut
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1376, 805);
            Controls.Add(panelData);
            Font = new Font("Segoe UI", 12F);
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
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
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
        private ucPages ucPages1;
        private Label lblTotalEvents;
        private LblCancel btnCancel;
        private BtnSearch btnSearch;
        private BtnExcel btnExportExcel;
        private Panel panelData;
        private TableLayoutPanel tablePic;
        private ComboBox cbIdentityGroup;
        private ComboBox cbVehicleType;
        private Label lblVehicleType;
        private Label lblIdentityGroup;
        private ComboBox cbLane;
        private Label lblLane;
        private Label lblUser;
        private ComboBox cbUser;
        private BtnPrint btnPrintPhieuThu;
        private ToolTip toolTip1;
        private DataGridViewTextBoxColumn event_out_id;
        private DataGridViewTextBoxColumn event_in_id;
        private DataGridViewTextBoxColumn invoice_pending_id;
        private DataGridViewTextBoxColumn invoice_id;
        private DataGridViewTextBoxColumn index;
        private DataGridViewTextBoxColumn plate_in;
        private DataGridViewTextBoxColumn plate_out;
        private DataGridViewTextBoxColumn time_in;
        private DataGridViewTextBoxColumn time_out;
        private DataGridViewTextBoxColumn parking_time;
        private DataGridViewTextBoxColumn identity_group_name;
        private DataGridViewTextBoxColumn parking_fee;
        private DataGridViewTextBoxColumn identity_code;
        private DataGridViewTextBoxColumn user_in;
        private DataGridViewTextBoxColumn user_out;
        private DataGridViewTextBoxColumn invoice_template;
        private DataGridViewTextBoxColumn invoice_no;
        private DataGridViewTextBoxColumn lane_in_name;
        private DataGridViewTextBoxColumn lane_out_name;
        private DataGridViewTextBoxColumn note;
        private DataGridViewTextBoxColumn file_keys_in;
        private DataGridViewTextBoxColumn file_keys_out;
        private TableLayoutPanel panelSearch;
    }

}