namespace v5_IScale.Forms.ReportForms
{
    partial class frmReportScaleDetail
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
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportScaleDetail));
            label1 = new Label();
            label2 = new Label();
            dtpStartTime = new DateTimePicker();
            dtpEndTime = new DateTimePicker();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtPlateNumber = new TextBox();
            cbGoodsType = new ComboBox();
            txtUsername = new TextBox();
            dgvData = new DataGridView();
            parking_event_in_id = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            time = new DataGridViewTextBoxColumn();
            laneName = new DataGridViewTextBoxColumn();
            plate_number = new DataGridViewTextBoxColumn();
            weight = new DataGridViewTextBoxColumn();
            index = new DataGridViewTextBoxColumn();
            charge = new DataGridViewTextBoxColumn();
            weighing_type_name = new DataGridViewTextBoxColumn();
            created_by = new DataGridViewTextBoxColumn();
            invoice_code = new DataGridViewTextBoxColumn();
            invoice_no = new DataGridViewTextBoxColumn();
            vehicleImage = new DataGridViewTextBoxColumn();
            firstScaleImage = new DataGridViewTextBoxColumn();
            secondScaleImage = new DataGridViewTextBoxColumn();
            invoice_id = new DataGridViewTextBoxColumn();
            weighing_id = new DataGridViewTextBoxColumn();
            groupBox1 = new GroupBox();
            btnExcel = new Button();
            btnSearch = new Button();
            cbFeeType = new ComboBox();
            cbLanes = new ComboBox();
            label9 = new Label();
            label8 = new Label();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel3 = new Panel();
            label7 = new Label();
            picVehicle = new iParkingv5_window.Usercontrols.MovablePictureBox();
            panel2 = new Panel();
            label6 = new Label();
            picOverview = new iParkingv5_window.Usercontrols.MovablePictureBox();
            groupBox2 = new GroupBox();
            btnSendInvoice = new Button();
            btnPrintInternetEInvoice = new Button();
            btnPrintEInvoice = new Button();
            panel4 = new Panel();
            lblTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picVehicle).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picOverview).BeginInit();
            groupBox2.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 38);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(65, 21);
            label1.TabIndex = 0;
            label1.Text = "Từ ngày";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 70);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(76, 21);
            label2.TabIndex = 0;
            label2.Text = "Đến ngày";
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(103, 32);
            dtpStartTime.Margin = new Padding(4, 3, 4, 3);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.Size = new Size(280, 29);
            dtpStartTime.TabIndex = 2;
            // 
            // dtpEndTime
            // 
            dtpEndTime.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(103, 67);
            dtpEndTime.Margin = new Padding(4, 3, 4, 3);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.Size = new Size(280, 29);
            dtpEndTime.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 105);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(79, 21);
            label3.TabIndex = 2;
            label3.Text = "Biển số xe";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 174);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(78, 21);
            label4.TabIndex = 2;
            label4.Text = "Loại hàng";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 140);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(82, 21);
            label5.TabIndex = 2;
            label5.Text = "Người cân";
            // 
            // txtPlateNumber
            // 
            txtPlateNumber.Location = new Point(103, 102);
            txtPlateNumber.Margin = new Padding(4, 3, 4, 3);
            txtPlateNumber.Name = "txtPlateNumber";
            txtPlateNumber.Size = new Size(280, 29);
            txtPlateNumber.TabIndex = 4;
            // 
            // cbGoodsType
            // 
            cbGoodsType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGoodsType.FormattingEnabled = true;
            cbGoodsType.Location = new Point(103, 171);
            cbGoodsType.Margin = new Padding(4, 3, 4, 3);
            cbGoodsType.Name = "cbGoodsType";
            cbGoodsType.Size = new Size(280, 29);
            cbGoodsType.TabIndex = 6;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(103, 137);
            txtUsername.Margin = new Padding(4, 3, 4, 3);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(280, 29);
            txtUsername.TabIndex = 5;
            // 
            // dgvData
            // 
            dgvData.AllowUserToAddRows = false;
            dgvData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(192, 255, 255);
            dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvData.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Columns.AddRange(new DataGridViewColumn[] { parking_event_in_id, Column1, time, laneName, plate_number, weight, index, charge, weighing_type_name, created_by, invoice_code, invoice_no, vehicleImage, firstScaleImage, secondScaleImage, invoice_id, weighing_id });
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = SystemColors.Window;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle9.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle9.Padding = new Padding(5);
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dgvData.DefaultCellStyle = dataGridViewCellStyle9;
            dgvData.Dock = DockStyle.Fill;
            dgvData.Location = new Point(0, 380);
            dgvData.Margin = new Padding(4, 3, 4, 3);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowHeadersVisible = false;
            dgvData.RowTemplate.Height = 29;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.Size = new Size(1198, 239);
            dgvData.TabIndex = 5;
            dgvData.CellClick += dgvData_CellClick;
            // 
            // parking_event_in_id
            // 
            parking_event_in_id.HeaderText = "parkingEventId";
            parking_event_in_id.Name = "parking_event_in_id";
            parking_event_in_id.ReadOnly = true;
            parking_event_in_id.Visible = false;
            parking_event_in_id.Width = 143;
            // 
            // Column1
            // 
            Column1.HeaderText = "STT";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 72;
            // 
            // time
            // 
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            time.DefaultCellStyle = dataGridViewCellStyle3;
            time.HeaderText = "Giờ cân";
            time.Name = "time";
            time.ReadOnly = true;
            time.Width = 102;
            // 
            // laneName
            // 
            laneName.HeaderText = "Làn";
            laneName.Name = "laneName";
            laneName.ReadOnly = true;
            laneName.Width = 72;
            // 
            // plate_number
            // 
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            plate_number.DefaultCellStyle = dataGridViewCellStyle4;
            plate_number.HeaderText = "Biển số";
            plate_number.Name = "plate_number";
            plate_number.ReadOnly = true;
            // 
            // weight
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Font = new Font("Digital-7", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            weight.DefaultCellStyle = dataGridViewCellStyle5;
            weight.HeaderText = "Khối lượng";
            weight.Name = "weight";
            weight.ReadOnly = true;
            weight.Width = 130;
            // 
            // index
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Font = new Font("Digital-7", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            index.DefaultCellStyle = dataGridViewCellStyle6;
            index.HeaderText = "STT cân";
            index.Name = "index";
            index.ReadOnly = true;
            index.Width = 103;
            // 
            // charge
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleRight;
            charge.DefaultCellStyle = dataGridViewCellStyle7;
            charge.HeaderText = "Phí cân";
            charge.Name = "charge";
            charge.ReadOnly = true;
            charge.Width = 101;
            // 
            // weighing_type_name
            // 
            weighing_type_name.HeaderText = "Loại hàng";
            weighing_type_name.Name = "weighing_type_name";
            weighing_type_name.ReadOnly = true;
            weighing_type_name.Width = 120;
            // 
            // created_by
            // 
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            created_by.DefaultCellStyle = dataGridViewCellStyle8;
            created_by.HeaderText = "Người cân";
            created_by.Name = "created_by";
            created_by.ReadOnly = true;
            created_by.Width = 125;
            // 
            // invoice_code
            // 
            invoice_code.HeaderText = "Mẫu hóa đơn";
            invoice_code.Name = "invoice_code";
            invoice_code.ReadOnly = true;
            invoice_code.Width = 146;
            // 
            // invoice_no
            // 
            invoice_no.HeaderText = "Số hóa đơn";
            invoice_no.Name = "invoice_no";
            invoice_no.ReadOnly = true;
            invoice_no.Width = 131;
            // 
            // vehicleImage
            // 
            vehicleImage.HeaderText = "vehicleInImage";
            vehicleImage.Name = "vehicleImage";
            vehicleImage.ReadOnly = true;
            vehicleImage.Visible = false;
            vehicleImage.Width = 163;
            // 
            // firstScaleImage
            // 
            firstScaleImage.HeaderText = "firstScaleImage";
            firstScaleImage.Name = "firstScaleImage";
            firstScaleImage.ReadOnly = true;
            firstScaleImage.Visible = false;
            firstScaleImage.Width = 163;
            // 
            // secondScaleImage
            // 
            secondScaleImage.HeaderText = "secondScaleImage";
            secondScaleImage.Name = "secondScaleImage";
            secondScaleImage.ReadOnly = true;
            secondScaleImage.Visible = false;
            secondScaleImage.Width = 187;
            // 
            // invoice_id
            // 
            invoice_id.HeaderText = "invoice_id";
            invoice_id.Name = "invoice_id";
            invoice_id.ReadOnly = true;
            invoice_id.Visible = false;
            invoice_id.Width = 123;
            // 
            // weighing_id
            // 
            weighing_id.HeaderText = "weighing_id";
            weighing_id.Name = "weighing_id";
            weighing_id.ReadOnly = true;
            weighing_id.Visible = false;
            weighing_id.Width = 139;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnExcel);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cbFeeType);
            groupBox1.Controls.Add(cbLanes);
            groupBox1.Controls.Add(cbGoodsType);
            groupBox1.Controls.Add(dtpStartTime);
            groupBox1.Controls.Add(txtUsername);
            groupBox1.Controls.Add(dtpEndTime);
            groupBox1.Controls.Add(txtPlateNumber);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label4);
            groupBox1.Dock = DockStyle.Left;
            groupBox1.Font = new Font("Segoe UI", 12F);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(393, 322);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Điều kiện lọc";
            // 
            // btnExcel
            // 
            btnExcel.AutoSize = true;
            btnExcel.Font = new Font("Segoe UI", 14F);
            btnExcel.Image = (Image)resources.GetObject("btnExcel.Image");
            btnExcel.Location = new Point(274, 278);
            btnExcel.Margin = new Padding(4, 3, 4, 3);
            btnExcel.Name = "btnExcel";
            btnExcel.Size = new Size(109, 38);
            btnExcel.TabIndex = 1;
            btnExcel.Text = "Excel";
            btnExcel.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnExcel.UseVisualStyleBackColor = true;
            btnExcel.Click += btnExcel_Click;
            // 
            // btnSearch
            // 
            btnSearch.AutoSize = true;
            btnSearch.Font = new Font("Segoe UI", 14F);
            btnSearch.Image = (Image)resources.GetObject("btnSearch.Image");
            btnSearch.Location = new Point(117, 278);
            btnSearch.Margin = new Padding(4, 3, 4, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(149, 38);
            btnSearch.TabIndex = 0;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // cbFeeType
            // 
            cbFeeType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFeeType.FormattingEnabled = true;
            cbFeeType.Items.AddRange(new object[] { "Tất cả", "Mất phí", "Không mất phí" });
            cbFeeType.Location = new Point(103, 241);
            cbFeeType.Margin = new Padding(4, 3, 4, 3);
            cbFeeType.Name = "cbFeeType";
            cbFeeType.Size = new Size(280, 29);
            cbFeeType.TabIndex = 8;
            // 
            // cbLanes
            // 
            cbLanes.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLanes.FormattingEnabled = true;
            cbLanes.Location = new Point(103, 206);
            cbLanes.Margin = new Padding(4, 3, 4, 3);
            cbLanes.Name = "cbLanes";
            cbLanes.Size = new Size(280, 29);
            cbLanes.TabIndex = 7;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 244);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(77, 21);
            label9.TabIndex = 2;
            label9.Text = "Hình thức";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 209);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(35, 21);
            label8.TabIndex = 2;
            label8.Text = "Làn";
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1198, 322);
            panel1.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel1.Controls.Add(panel3, 1, 0);
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Location = new Point(399, 81);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(762, 238);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // panel3
            // 
            panel3.Controls.Add(label7);
            panel3.Controls.Add(picVehicle);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(382, 2);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new Size(378, 234);
            panel3.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = SystemColors.ControlLightLight;
            label7.Dock = DockStyle.Top;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(0, 0, 192);
            label7.Location = new Point(0, 0);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(77, 20);
            label7.TabIndex = 0;
            label7.Text = "ẢNH SAU";
            // 
            // picVehicle
            // 
            picVehicle.BackColor = SystemColors.ControlLightLight;
            picVehicle.Dock = DockStyle.Fill;
            picVehicle.Location = new Point(0, 0);
            picVehicle.Margin = new Padding(0);
            picVehicle.Name = "picVehicle";
            picVehicle.Size = new Size(378, 234);
            picVehicle.SizeMode = PictureBoxSizeMode.StretchImage;
            picVehicle.TabIndex = 1;
            picVehicle.TabStop = false;
            picVehicle.LoadCompleted += Pic_LoadCompleted;
            // 
            // panel2
            // 
            panel2.Controls.Add(label6);
            panel2.Controls.Add(picOverview);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(2, 2);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(378, 234);
            panel2.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ControlLightLight;
            label6.Dock = DockStyle.Top;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(0, 0, 192);
            label6.Location = new Point(0, 0);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(99, 20);
            label6.TabIndex = 0;
            label6.Text = "ẢNH TRƯỚC";
            // 
            // picOverview
            // 
            picOverview.BackColor = SystemColors.ControlLightLight;
            picOverview.Dock = DockStyle.Fill;
            picOverview.Location = new Point(0, 0);
            picOverview.Margin = new Padding(0);
            picOverview.Name = "picOverview";
            picOverview.Size = new Size(378, 234);
            picOverview.SizeMode = PictureBoxSizeMode.StretchImage;
            picOverview.TabIndex = 1;
            picOverview.TabStop = false;
            picOverview.LoadCompleted += Pic_LoadCompleted;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnSendInvoice);
            groupBox2.Controls.Add(btnPrintInternetEInvoice);
            groupBox2.Controls.Add(btnPrintEInvoice);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(393, 0);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(805, 75);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "In phiếu";
            // 
            // btnSendInvoice
            // 
            btnSendInvoice.AutoSize = true;
            btnSendInvoice.Font = new Font("Segoe UI", 14F);
            btnSendInvoice.Location = new Point(392, 27);
            btnSendInvoice.Name = "btnSendInvoice";
            btnSendInvoice.Size = new Size(126, 41);
            btnSendInvoice.TabIndex = 9;
            btnSendInvoice.Text = "Gửi hóa đơn";
            btnSendInvoice.TextAlign = ContentAlignment.MiddleRight;
            btnSendInvoice.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSendInvoice.UseVisualStyleBackColor = true;
            btnSendInvoice.Visible = false;
            // 
            // btnPrintInternetEInvoice
            // 
            btnPrintInternetEInvoice.AutoSize = true;
            btnPrintInternetEInvoice.Font = new Font("Segoe UI", 14F);
            btnPrintInternetEInvoice.Image = (Image)resources.GetObject("btnPrintInternetEInvoice.Image");
            btnPrintInternetEInvoice.Location = new Point(157, 27);
            btnPrintInternetEInvoice.Name = "btnPrintInternetEInvoice";
            btnPrintInternetEInvoice.Size = new Size(229, 41);
            btnPrintInternetEInvoice.TabIndex = 9;
            btnPrintInternetEInvoice.Text = "Hóa đơn (Internet)";
            btnPrintInternetEInvoice.TextAlign = ContentAlignment.MiddleRight;
            btnPrintInternetEInvoice.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPrintInternetEInvoice.UseVisualStyleBackColor = true;
            btnPrintInternetEInvoice.Click += btnPrintInternetEInvoice_Click;
            // 
            // btnPrintEInvoice
            // 
            btnPrintEInvoice.AutoSize = true;
            btnPrintEInvoice.Font = new Font("Segoe UI", 14F);
            btnPrintEInvoice.Image = (Image)resources.GetObject("btnPrintEInvoice.Image");
            btnPrintEInvoice.Location = new Point(12, 27);
            btnPrintEInvoice.Name = "btnPrintEInvoice";
            btnPrintEInvoice.Size = new Size(139, 41);
            btnPrintEInvoice.TabIndex = 8;
            btnPrintEInvoice.Text = "Hóa đơn";
            btnPrintEInvoice.TextAlign = ContentAlignment.MiddleRight;
            btnPrintEInvoice.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPrintEInvoice.UseVisualStyleBackColor = true;
            btnPrintEInvoice.Click += btnPrintEInvoice_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(lblTotal);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 322);
            panel4.Name = "panel4";
            panel4.Size = new Size(1198, 58);
            panel4.TabIndex = 8;
            // 
            // lblTotal
            // 
            lblTotal.Dock = DockStyle.Left;
            lblTotal.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotal.ForeColor = Color.DarkRed;
            lblTotal.Location = new Point(0, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(896, 58);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "Tổng Tiền : 0";
            lblTotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // frmReportScaleDetail
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1198, 619);
            Controls.Add(dgvData);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmReportScaleDetail";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Báo cáo sự kiện cân";
            WindowState = FormWindowState.Maximized;
            Load += frmReportScaleWithInvoice_Load;
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picVehicle).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picOverview).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private DateTimePicker dtpStartTime;
        private DateTimePicker dtpEndTime;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtPlateNumber;
        private ComboBox cbGoodsType;
        private TextBox txtUsername;
        private DataGridView dgvData;
        private GroupBox groupBox1;
        private Button btnSearch;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel3;
        private Label label7;
        private GroupBox groupBox2;
        private Button btnPrintInternetEInvoice;
        private Button btnPrintEInvoice;
        private Button btnExcel;
        private Panel panel2;
        private Label label6;
        private iParkingv5_window.Usercontrols.MovablePictureBox picVehicle;
        private iParkingv5_window.Usercontrols.MovablePictureBox picOverview;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewTextBoxColumn Column11;
        private DataGridViewTextBoxColumn Column12;
        private Button btnSendInvoice;
        private ComboBox cbLanes;
        private Label label8;
        private ComboBox cbFeeType;
        private Label label9;
        private DataGridViewTextBoxColumn parking_event_in_id;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn time;
        private DataGridViewTextBoxColumn laneName;
        private DataGridViewTextBoxColumn plate_number;
        private DataGridViewTextBoxColumn weight;
        private DataGridViewTextBoxColumn index;
        private DataGridViewTextBoxColumn charge;
        private DataGridViewTextBoxColumn weighing_type_name;
        private DataGridViewTextBoxColumn created_by;
        private DataGridViewTextBoxColumn invoice_code;
        private DataGridViewTextBoxColumn invoice_no;
        private DataGridViewTextBoxColumn vehicleImage;
        private DataGridViewTextBoxColumn firstScaleImage;
        private DataGridViewTextBoxColumn secondScaleImage;
        private DataGridViewTextBoxColumn invoice_id;
        private DataGridViewTextBoxColumn weighing_id;
        private Panel panel4;
        private Label lblTotal;
    }
}