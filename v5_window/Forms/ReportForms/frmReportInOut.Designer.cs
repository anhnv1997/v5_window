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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
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
            dgvExport = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn13 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn14 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn15 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn16 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn17 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn18 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn19 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn20 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn21 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn22 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn23 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn24 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn25 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn26 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn27 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn28 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn29 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn30 = new DataGridViewTextBoxColumn();
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
            ucEventOutInfo1 = new ucEventOutInfo();
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
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            file_key_out = new DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)dgvExport).BeginInit();
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
            tableLayoutPanel1.Size = new Size(252, 331);
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
            picOverviewImageIn.Size = new Size(252, 165);
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
            picVehicleImageIn.Location = new Point(0, 165);
            picVehicleImageIn.Margin = new Padding(0);
            picVehicleImageIn.Name = "picVehicleImageIn";
            picVehicleImageIn.Size = new Size(252, 166);
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
            dgvData.Columns.AddRange(new DataGridViewColumn[] { id, eventinid, Column1, PlateIn, PlateOut, vehicle_reagion_type, TimeIn, TimeOut, ParkingTime, IdentityGroup, WarehouseType, WarehouseCode, Charge, IdentityCode, UserIn, UserOut, InvoiceTemplate, InvoiceNo, LaneIn, LaneOut, NoteBSX, note_3rd_1, note_3rd_2, note_3rd_3, Column2, Column3, Column9, file_key_out, pending_invoice_id, invoice_id });
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
            dgvData.Size = new Size(813, 331);
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
            tableLayoutPanel2.Size = new Size(252, 331);
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
            picOverviewImageOut.Size = new Size(252, 165);
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
            picVehicleImageOut.Location = new Point(0, 165);
            picVehicleImageOut.Margin = new Padding(0);
            picVehicleImageOut.Name = "picVehicleImageOut";
            picVehicleImageOut.Size = new Size(252, 166);
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
            ucPages1.Location = new Point(13, 676);
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
            btnCancel.Location = new Point(1278, 763);
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
            btnExportExcel.Location = new Point(1167, 763);
            btnExportExcel.Margin = new Padding(4, 3, 4, 3);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(103, 42);
            btnExportExcel.TabIndex = 59;
            btnExportExcel.Text = "lblExcel1";
            // 
            // panelData
            // 
            panelData.Controls.Add(dgvExport);
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
            panelData.Controls.Add(ucEventOutInfo1);
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
            // dgvExport
            // 
            dgvExport.AllowUserToAddRows = false;
            dgvExport.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(192, 255, 255);
            dgvExport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvExport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvExport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvExport.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvExport.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.Padding = new Padding(3);
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvExport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvExport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExport.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn9, dataGridViewTextBoxColumn10, dataGridViewTextBoxColumn11, dataGridViewTextBoxColumn12, dataGridViewTextBoxColumn13, dataGridViewTextBoxColumn14, dataGridViewTextBoxColumn15, dataGridViewTextBoxColumn16, dataGridViewTextBoxColumn17, dataGridViewTextBoxColumn18, dataGridViewTextBoxColumn19, dataGridViewTextBoxColumn20, dataGridViewTextBoxColumn21, dataGridViewTextBoxColumn22, dataGridViewTextBoxColumn23, dataGridViewTextBoxColumn24, dataGridViewTextBoxColumn25, dataGridViewTextBoxColumn26, dataGridViewTextBoxColumn27, dataGridViewTextBoxColumn28, dataGridViewTextBoxColumn29, dataGridViewTextBoxColumn30 });
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.Padding = new Padding(3);
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgvExport.DefaultCellStyle = dataGridViewCellStyle8;
            dgvExport.Location = new Point(960, 26);
            dgvExport.Margin = new Padding(4, 3, 4, 3);
            dgvExport.Name = "dgvExport";
            dgvExport.ReadOnly = true;
            dgvExport.RowHeadersVisible = false;
            dgvExport.RowTemplate.Height = 29;
            dgvExport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExport.Size = new Size(99, 73);
            dgvExport.TabIndex = 74;
            dgvExport.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "id";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Visible = false;
            dataGridViewTextBoxColumn1.Width = 37;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "eventInId";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Visible = false;
            dataGridViewTextBoxColumn2.Width = 95;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "STT";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.Width = 66;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Biển Số Vào";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            dataGridViewTextBoxColumn4.Width = 123;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Biển Số Ra";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            dataGridViewTextBoxColumn5.Width = 115;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "Xe VN/TQ";
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            dataGridViewTextBoxColumn6.Width = 110;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.HeaderText = "Giờ Vào";
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            dataGridViewTextBoxColumn7.Width = 96;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.HeaderText = "Giờ Ra";
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.ReadOnly = true;
            dataGridViewTextBoxColumn8.Width = 88;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewTextBoxColumn9.HeaderText = "Thời Gian Lưu Bãi";
            dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            dataGridViewTextBoxColumn9.ReadOnly = true;
            dataGridViewTextBoxColumn9.Width = 163;
            // 
            // dataGridViewTextBoxColumn10
            // 
            dataGridViewTextBoxColumn10.HeaderText = "Loại";
            dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            dataGridViewTextBoxColumn10.ReadOnly = true;
            dataGridViewTextBoxColumn10.Width = 70;
            // 
            // dataGridViewTextBoxColumn11
            // 
            dataGridViewTextBoxColumn11.HeaderText = "Phân Loại";
            dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            dataGridViewTextBoxColumn11.ReadOnly = true;
            dataGridViewTextBoxColumn11.Width = 109;
            // 
            // dataGridViewTextBoxColumn12
            // 
            dataGridViewTextBoxColumn12.HeaderText = "Số phiếu xuất";
            dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            dataGridViewTextBoxColumn12.ReadOnly = true;
            dataGridViewTextBoxColumn12.Width = 135;
            // 
            // dataGridViewTextBoxColumn13
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewTextBoxColumn13.HeaderText = "Phí";
            dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            dataGridViewTextBoxColumn13.ReadOnly = true;
            dataGridViewTextBoxColumn13.Width = 63;
            // 
            // dataGridViewTextBoxColumn14
            // 
            dataGridViewTextBoxColumn14.HeaderText = "Vé Xe";
            dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            dataGridViewTextBoxColumn14.ReadOnly = true;
            dataGridViewTextBoxColumn14.Width = 79;
            // 
            // dataGridViewTextBoxColumn15
            // 
            dataGridViewTextBoxColumn15.HeaderText = "Người Dùng Vào";
            dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            dataGridViewTextBoxColumn15.ReadOnly = true;
            dataGridViewTextBoxColumn15.Width = 157;
            // 
            // dataGridViewTextBoxColumn16
            // 
            dataGridViewTextBoxColumn16.HeaderText = "Người Dùng Ra";
            dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            dataGridViewTextBoxColumn16.ReadOnly = true;
            dataGridViewTextBoxColumn16.Width = 149;
            // 
            // dataGridViewTextBoxColumn17
            // 
            dataGridViewTextBoxColumn17.HeaderText = "Mẫu hóa đơn";
            dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            dataGridViewTextBoxColumn17.ReadOnly = true;
            dataGridViewTextBoxColumn17.Width = 134;
            // 
            // dataGridViewTextBoxColumn18
            // 
            dataGridViewTextBoxColumn18.HeaderText = "Số hóa đơn";
            dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            dataGridViewTextBoxColumn18.ReadOnly = true;
            dataGridViewTextBoxColumn18.Width = 121;
            // 
            // dataGridViewTextBoxColumn19
            // 
            dataGridViewTextBoxColumn19.HeaderText = "Làn Vào";
            dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            dataGridViewTextBoxColumn19.ReadOnly = true;
            dataGridViewTextBoxColumn19.Width = 96;
            // 
            // dataGridViewTextBoxColumn20
            // 
            dataGridViewTextBoxColumn20.HeaderText = "Làn Ra";
            dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            dataGridViewTextBoxColumn20.ReadOnly = true;
            dataGridViewTextBoxColumn20.Width = 88;
            // 
            // dataGridViewTextBoxColumn21
            // 
            dataGridViewTextBoxColumn21.HeaderText = "Ghi chú BSX";
            dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            dataGridViewTextBoxColumn21.ReadOnly = true;
            dataGridViewTextBoxColumn21.Width = 125;
            // 
            // dataGridViewTextBoxColumn22
            // 
            dataGridViewTextBoxColumn22.HeaderText = "Ghi chú chặn kích xe";
            dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            dataGridViewTextBoxColumn22.ReadOnly = true;
            dataGridViewTextBoxColumn22.Width = 182;
            // 
            // dataGridViewTextBoxColumn23
            // 
            dataGridViewTextBoxColumn23.HeaderText = "Ghi chú DVHT";
            dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            dataGridViewTextBoxColumn23.ReadOnly = true;
            dataGridViewTextBoxColumn23.Width = 138;
            // 
            // dataGridViewTextBoxColumn24
            // 
            dataGridViewTextBoxColumn24.HeaderText = "Người cho phép ra";
            dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            dataGridViewTextBoxColumn24.ReadOnly = true;
            dataGridViewTextBoxColumn24.Width = 171;
            // 
            // dataGridViewTextBoxColumn25
            // 
            dataGridViewTextBoxColumn25.HeaderText = "Khối lượng cân vào";
            dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            dataGridViewTextBoxColumn25.ReadOnly = true;
            dataGridViewTextBoxColumn25.Width = 174;
            // 
            // dataGridViewTextBoxColumn26
            // 
            dataGridViewTextBoxColumn26.HeaderText = "Khối lượng cân ra";
            dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            dataGridViewTextBoxColumn26.ReadOnly = true;
            dataGridViewTextBoxColumn26.Width = 163;
            // 
            // dataGridViewTextBoxColumn27
            // 
            dataGridViewTextBoxColumn27.HeaderText = "physicalFileIdIns";
            dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            dataGridViewTextBoxColumn27.ReadOnly = true;
            dataGridViewTextBoxColumn27.Visible = false;
            dataGridViewTextBoxColumn27.Width = 168;
            // 
            // dataGridViewTextBoxColumn28
            // 
            dataGridViewTextBoxColumn28.HeaderText = "physicalIdOuts";
            dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            dataGridViewTextBoxColumn28.ReadOnly = true;
            dataGridViewTextBoxColumn28.Visible = false;
            dataGridViewTextBoxColumn28.Width = 154;
            // 
            // dataGridViewTextBoxColumn29
            // 
            dataGridViewTextBoxColumn29.HeaderText = "pendingId";
            dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            dataGridViewTextBoxColumn29.ReadOnly = true;
            dataGridViewTextBoxColumn29.Visible = false;
            dataGridViewTextBoxColumn29.Width = 120;
            // 
            // dataGridViewTextBoxColumn30
            // 
            dataGridViewTextBoxColumn30.HeaderText = "invoiceId";
            dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            dataGridViewTextBoxColumn30.ReadOnly = true;
            dataGridViewTextBoxColumn30.Visible = false;
            dataGridViewTextBoxColumn30.Width = 112;
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
            lblTQ.Location = new Point(14, 641);
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
            lblVN.Location = new Point(14, 596);
            lblVN.Margin = new Padding(4, 0, 4, 0);
            lblVN.Name = "lblVN";
            lblVN.Size = new Size(56, 32);
            lblVN.TabIndex = 64;
            lblVN.Text = "VN:";
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
            tablePic.Size = new Size(504, 331);
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
            // Column2
            // 
            Column2.HeaderText = "Khối lượng cân vào";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 189;
            // 
            // Column3
            // 
            Column3.HeaderText = "Khối lượng cân ra";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 176;
            // 
            // Column9
            // 
            Column9.HeaderText = "physicalFileIdIns";
            Column9.Name = "Column9";
            Column9.ReadOnly = true;
            Column9.Visible = false;
            Column9.Width = 168;
            // 
            // file_key_out
            // 
            file_key_out.HeaderText = "physicalIdOuts";
            file_key_out.Name = "file_key_out";
            file_key_out.ReadOnly = true;
            file_key_out.Visible = false;
            file_key_out.Width = 154;
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
            ((System.ComponentModel.ISupportInitialize)dgvExport).EndInit();
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
        private ucEventOutInfo ucEventOutInfo1;
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
        private DataGridView dgvExport;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
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
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn file_key_out;
        private DataGridViewTextBoxColumn pending_invoice_id;
        private DataGridViewTextBoxColumn invoice_id;
    }
}