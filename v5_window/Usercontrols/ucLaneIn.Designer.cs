namespace iParkingv5_window.Usercontrols
{
    partial class ucLaneIn
    {


        #region Component Designer generated code

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLaneIn));
            lblLaneName = new Label();
            panelCameras = new Panel();
            splitContainerMain = new SplitContainer();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel2 = new Panel();
            picVehicleImage = new MovablePictureBox();
            panel3 = new Panel();
            picOverviewImage = new MovablePictureBox();
            splitterCamera = new Splitter();
            panel4 = new Panel();
            panelLastEvent = new Panel();
            panel9 = new Panel();
            label2 = new Label();
            ucEventCount1 = new ucEventCount();
            lblResult = new iPakrkingv5.Controls.Controls.Labels.lblResult();
            splitContainerEventContent = new SplitContainer();
            panelDetectPlate = new Panel();
            picLprImage = new MovablePictureBox();
            txtPlate = new TextBox();
            dgvEventContent = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            panelNote = new Panel();
            tableLayoutPanelNote = new TableLayoutPanel();
            label3 = new Label();
            label6 = new Label();
            groupBox1 = new GroupBox();
            cbNote = new ComboBox();
            picSetting = new PictureBox();
            panel5 = new Panel();
            picRetakePhoto = new PictureBox();
            panel8 = new Panel();
            picWriteIn = new PictureBox();
            panel6 = new Panel();
            picOpenBarrie = new PictureBox();
            panel1 = new Panel();
            panel7 = new Panel();
            pictureBox2 = new PictureBox();
            toolTip1 = new ToolTip(components);
            toolTip2 = new ToolTip(components);
            toolTip3 = new ToolTip(components);
            splitterEventInfoWithCamera = new Splitter();
            panelEventData = new Panel();
            panelScaleAction = new Panel();
            btnopenBarrie = new Button();
            btnPrintScale = new Button();
            panelGoodsType = new Panel();
            cbGoodsType = new ComboBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picVehicleImage).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picOverviewImage).BeginInit();
            panel4.SuspendLayout();
            panelLastEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerEventContent).BeginInit();
            splitContainerEventContent.Panel1.SuspendLayout();
            splitContainerEventContent.Panel2.SuspendLayout();
            splitContainerEventContent.SuspendLayout();
            panelDetectPlate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLprImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEventContent).BeginInit();
            panelNote.SuspendLayout();
            tableLayoutPanelNote.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picSetting).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picRetakePhoto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picWriteIn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picOpenBarrie).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panelEventData.SuspendLayout();
            panelScaleAction.SuspendLayout();
            panelGoodsType.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // lblLaneName
            // 
            lblLaneName.BackColor = Color.DarkGreen;
            lblLaneName.Dock = DockStyle.Fill;
            lblLaneName.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblLaneName.ForeColor = Color.White;
            lblLaneName.Location = new Point(0, 0);
            lblLaneName.Margin = new Padding(0);
            lblLaneName.Name = "lblLaneName";
            lblLaneName.Size = new Size(878, 30);
            lblLaneName.TabIndex = 0;
            lblLaneName.Text = "label1";
            lblLaneName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelCameras
            // 
            panelCameras.BorderStyle = BorderStyle.FixedSingle;
            panelCameras.Dock = DockStyle.Left;
            panelCameras.Location = new Point(0, 0);
            panelCameras.Name = "panelCameras";
            panelCameras.Size = new Size(241, 305);
            panelCameras.TabIndex = 3;
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(0, 30);
            splitContainerMain.Margin = new Padding(0);
            splitContainerMain.Name = "splitContainerMain";
            splitContainerMain.Orientation = Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(tableLayoutPanel1);
            splitContainerMain.Panel1.Controls.Add(splitterCamera);
            splitContainerMain.Panel1.Controls.Add(panelCameras);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(panel4);
            splitContainerMain.Panel2.Controls.Add(lblResult);
            splitContainerMain.Size = new Size(987, 519);
            splitContainerMain.SplitterDistance = 305;
            splitContainerMain.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(244, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(743, 305);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Underline);
            label1.ForeColor = Color.Green;
            label1.Location = new Point(5, 2);
            label1.Name = "label1";
            label1.Size = new Size(733, 40);
            label1.TabIndex = 2;
            label1.Text = "Ảnh Vào";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(panel2, 1, 0);
            tableLayoutPanel2.Controls.Add(panel3, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(5, 47);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(733, 253);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(picVehicleImage);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(369, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(361, 247);
            panel2.TabIndex = 0;
            // 
            // picVehicleImage
            // 
            picVehicleImage.BackColor = Color.WhiteSmoke;
            picVehicleImage.Dock = DockStyle.Fill;
            picVehicleImage.ErrorImage = null;
            picVehicleImage.Location = new Point(0, 0);
            picVehicleImage.Name = "picVehicleImage";
            picVehicleImage.Size = new Size(361, 247);
            picVehicleImage.SizeMode = PictureBoxSizeMode.StretchImage;
            picVehicleImage.TabIndex = 5;
            picVehicleImage.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Control;
            panel3.Controls.Add(picOverviewImage);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(360, 247);
            panel3.TabIndex = 1;
            // 
            // picOverviewImage
            // 
            picOverviewImage.BackColor = Color.WhiteSmoke;
            picOverviewImage.Dock = DockStyle.Fill;
            picOverviewImage.ErrorImage = null;
            picOverviewImage.Location = new Point(0, 0);
            picOverviewImage.Name = "picOverviewImage";
            picOverviewImage.Size = new Size(360, 247);
            picOverviewImage.SizeMode = PictureBoxSizeMode.StretchImage;
            picOverviewImage.TabIndex = 5;
            picOverviewImage.TabStop = false;
            // 
            // splitterCamera
            // 
            splitterCamera.Location = new Point(241, 0);
            splitterCamera.Name = "splitterCamera";
            splitterCamera.Size = new Size(3, 305);
            splitterCamera.TabIndex = 4;
            splitterCamera.TabStop = false;
            // 
            // panel4
            // 
            panel4.Controls.Add(panelLastEvent);
            panel4.Controls.Add(ucEventCount1);
            panel4.Dock = DockStyle.Fill;
            panel4.Font = new Font("Segoe UI", 13F);
            panel4.Location = new Point(0, 34);
            panel4.Name = "panel4";
            panel4.Size = new Size(987, 176);
            panel4.TabIndex = 2;
            // 
            // panelLastEvent
            // 
            panelLastEvent.BackColor = SystemColors.ButtonHighlight;
            panelLastEvent.BorderStyle = BorderStyle.FixedSingle;
            panelLastEvent.Controls.Add(panel9);
            panelLastEvent.Controls.Add(label2);
            panelLastEvent.Dock = DockStyle.Fill;
            panelLastEvent.Location = new Point(253, 0);
            panelLastEvent.Name = "panelLastEvent";
            panelLastEvent.Size = new Size(734, 176);
            panelLastEvent.TabIndex = 7;
            // 
            // panel9
            // 
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(0, 36);
            panel9.Name = "panel9";
            panel9.Size = new Size(732, 138);
            panel9.TabIndex = 8;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label2.ForeColor = Color.Navy;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(732, 36);
            label2.TabIndex = 7;
            label2.Text = "Các lượt xe vào gần đây";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ucEventCount1
            // 
            ucEventCount1.Dock = DockStyle.Left;
            ucEventCount1.Location = new Point(0, 0);
            ucEventCount1.Name = "ucEventCount1";
            ucEventCount1.Size = new Size(253, 176);
            ucEventCount1.TabIndex = 7;
            // 
            // lblResult
            // 
            lblResult.BackColor = Color.FromArgb(0, 64, 0);
            lblResult.Dock = DockStyle.Top;
            lblResult.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblResult.ForeColor = SystemColors.ButtonHighlight;
            lblResult.Location = new Point(0, 0);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(987, 34);
            lblResult.TabIndex = 1;
            lblResult.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // splitContainerEventContent
            // 
            splitContainerEventContent.Dock = DockStyle.Fill;
            splitContainerEventContent.Location = new Point(0, 50);
            splitContainerEventContent.Name = "splitContainerEventContent";
            splitContainerEventContent.Orientation = Orientation.Horizontal;
            // 
            // splitContainerEventContent.Panel1
            // 
            splitContainerEventContent.Panel1.Controls.Add(panelDetectPlate);
            // 
            // splitContainerEventContent.Panel2
            // 
            splitContainerEventContent.Panel2.Controls.Add(dgvEventContent);
            splitContainerEventContent.Panel2.Controls.Add(panelNote);
            splitContainerEventContent.Size = new Size(228, 375);
            splitContainerEventContent.SplitterDistance = 192;
            splitContainerEventContent.TabIndex = 0;
            // 
            // panelDetectPlate
            // 
            panelDetectPlate.Controls.Add(picLprImage);
            panelDetectPlate.Controls.Add(txtPlate);
            panelDetectPlate.Dock = DockStyle.Fill;
            panelDetectPlate.Location = new Point(0, 0);
            panelDetectPlate.Name = "panelDetectPlate";
            panelDetectPlate.Size = new Size(228, 192);
            panelDetectPlate.TabIndex = 4;
            // 
            // picLprImage
            // 
            picLprImage.BackColor = Color.WhiteSmoke;
            picLprImage.Dock = DockStyle.Fill;
            picLprImage.Location = new Point(0, 32);
            picLprImage.Name = "picLprImage";
            picLprImage.Size = new Size(228, 160);
            picLprImage.SizeMode = PictureBoxSizeMode.StretchImage;
            picLprImage.TabIndex = 4;
            picLprImage.TabStop = false;
            // 
            // txtPlate
            // 
            txtPlate.BackColor = SystemColors.HighlightText;
            txtPlate.Dock = DockStyle.Top;
            txtPlate.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            txtPlate.Location = new Point(0, 0);
            txtPlate.Name = "txtPlate";
            txtPlate.Size = new Size(228, 32);
            txtPlate.TabIndex = 0;
            txtPlate.TextAlign = HorizontalAlignment.Center;
            // 
            // dgvEventContent
            // 
            dgvEventContent.AllowUserToAddRows = false;
            dgvEventContent.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(192, 255, 255);
            dgvEventContent.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvEventContent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvEventContent.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvEventContent.BackgroundColor = SystemColors.ButtonHighlight;
            dgvEventContent.BorderStyle = BorderStyle.None;
            dgvEventContent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEventContent.ColumnHeadersVisible = false;
            dgvEventContent.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2 });
            dgvEventContent.Dock = DockStyle.Fill;
            dgvEventContent.Location = new Point(0, 164);
            dgvEventContent.Name = "dgvEventContent";
            dgvEventContent.ReadOnly = true;
            dgvEventContent.RowHeadersVisible = false;
            dgvEventContent.RowTemplate.Height = 29;
            dgvEventContent.Size = new Size(228, 15);
            dgvEventContent.TabIndex = 0;
            // 
            // Column1
            // 
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            Column1.DefaultCellStyle = dataGridViewCellStyle2;
            Column1.HeaderText = "Header";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 5;
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11.25F);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            Column2.DefaultCellStyle = dataGridViewCellStyle3;
            Column2.HeaderText = "Content";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // panelNote
            // 
            panelNote.Controls.Add(tableLayoutPanelNote);
            panelNote.Dock = DockStyle.Top;
            panelNote.Location = new Point(0, 0);
            panelNote.Name = "panelNote";
            panelNote.Size = new Size(228, 164);
            panelNote.TabIndex = 3;
            // 
            // tableLayoutPanelNote
            // 
            tableLayoutPanelNote.BackColor = Color.FromArgb(255, 128, 0);
            tableLayoutPanelNote.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanelNote.ColumnCount = 1;
            tableLayoutPanelNote.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelNote.Controls.Add(label3, 0, 0);
            tableLayoutPanelNote.Controls.Add(label6, 0, 1);
            tableLayoutPanelNote.Controls.Add(groupBox1, 0, 2);
            tableLayoutPanelNote.Dock = DockStyle.Fill;
            tableLayoutPanelNote.Location = new Point(0, 0);
            tableLayoutPanelNote.Name = "tableLayoutPanelNote";
            tableLayoutPanelNote.RowCount = 3;
            tableLayoutPanelNote.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelNote.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelNote.RowStyles.Add(new RowStyle(SizeType.Absolute, 76F));
            tableLayoutPanelNote.Size = new Size(228, 164);
            tableLayoutPanelNote.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label3.Location = new Point(4, 1);
            label3.Name = "label3";
            label3.Size = new Size(71, 20);
            label3.TabIndex = 0;
            label3.Text = "GHI CHÚ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label6.Location = new Point(4, 44);
            label6.Name = "label6";
            label6.Size = new Size(209, 20);
            label6.TabIndex = 0;
            label6.Text = "GHI CHÚ DỊCH VỤ HẠ TẦNG";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbNote);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Segoe UI", 15.75F);
            groupBox1.Location = new Point(1, 87);
            groupBox1.Margin = new Padding(0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(226, 76);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dịch vụ";
            // 
            // cbNote
            // 
            cbNote.BackColor = Color.Silver;
            cbNote.Dock = DockStyle.Fill;
            cbNote.DropDownStyle = ComboBoxStyle.DropDownList;
            cbNote.FlatStyle = FlatStyle.Popup;
            cbNote.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cbNote.ForeColor = Color.FromArgb(192, 0, 0);
            cbNote.FormattingEnabled = true;
            cbNote.Location = new Point(3, 31);
            cbNote.Name = "cbNote";
            cbNote.Size = new Size(220, 38);
            cbNote.TabIndex = 3;
            cbNote.SelectedIndexChanged += cbNote_SelectedIndexChanged;
            // 
            // picSetting
            // 
            picSetting.BackColor = Color.DarkGreen;
            picSetting.Dock = DockStyle.Right;
            picSetting.Image = (Image)resources.GetObject("picSetting.Image");
            picSetting.Location = new Point(878, 0);
            picSetting.Name = "picSetting";
            picSetting.Size = new Size(52, 30);
            picSetting.SizeMode = PictureBoxSizeMode.Zoom;
            picSetting.TabIndex = 5;
            picSetting.TabStop = false;
            picSetting.Click += picSetting_Click;
            picSetting.MouseEnter += picSetting_MouseEnter;
            picSetting.MouseLeave += picSetting_MouseLeave;
            // 
            // panel5
            // 
            panel5.BackColor = Color.DarkGreen;
            panel5.Controls.Add(picRetakePhoto);
            panel5.Controls.Add(panel8);
            panel5.Controls.Add(picWriteIn);
            panel5.Controls.Add(panel6);
            panel5.Controls.Add(picOpenBarrie);
            panel5.Controls.Add(panel1);
            panel5.Controls.Add(lblLaneName);
            panel5.Controls.Add(picSetting);
            panel5.Controls.Add(panel7);
            panel5.Controls.Add(pictureBox2);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 0);
            panel5.Margin = new Padding(0);
            panel5.Name = "panel5";
            panel5.Size = new Size(987, 30);
            panel5.TabIndex = 6;
            // 
            // picRetakePhoto
            // 
            picRetakePhoto.BackColor = Color.DarkGreen;
            picRetakePhoto.Dock = DockStyle.Right;
            picRetakePhoto.Image = (Image)resources.GetObject("picRetakePhoto.Image");
            picRetakePhoto.Location = new Point(707, 0);
            picRetakePhoto.Name = "picRetakePhoto";
            picRetakePhoto.Size = new Size(52, 30);
            picRetakePhoto.SizeMode = PictureBoxSizeMode.Zoom;
            picRetakePhoto.TabIndex = 15;
            picRetakePhoto.TabStop = false;
            picRetakePhoto.Click += BtnReTakePhoto_Click;
            // 
            // panel8
            // 
            panel8.BackColor = Color.DarkGreen;
            panel8.Dock = DockStyle.Right;
            panel8.Location = new Point(759, 0);
            panel8.Margin = new Padding(0);
            panel8.Name = "panel8";
            panel8.Size = new Size(5, 30);
            panel8.TabIndex = 14;
            // 
            // picWriteIn
            // 
            picWriteIn.BackColor = Color.DarkGreen;
            picWriteIn.Dock = DockStyle.Right;
            picWriteIn.Image = (Image)resources.GetObject("picWriteIn.Image");
            picWriteIn.Location = new Point(764, 0);
            picWriteIn.Name = "picWriteIn";
            picWriteIn.Size = new Size(52, 30);
            picWriteIn.SizeMode = PictureBoxSizeMode.Zoom;
            picWriteIn.TabIndex = 13;
            picWriteIn.TabStop = false;
            picWriteIn.Click += BtnWriteIn_Click;
            // 
            // panel6
            // 
            panel6.BackColor = Color.DarkGreen;
            panel6.Dock = DockStyle.Right;
            panel6.Location = new Point(816, 0);
            panel6.Margin = new Padding(0);
            panel6.Name = "panel6";
            panel6.Size = new Size(5, 30);
            panel6.TabIndex = 12;
            // 
            // picOpenBarrie
            // 
            picOpenBarrie.BackColor = Color.DarkGreen;
            picOpenBarrie.Dock = DockStyle.Right;
            picOpenBarrie.Image = (Image)resources.GetObject("picOpenBarrie.Image");
            picOpenBarrie.Location = new Point(821, 0);
            picOpenBarrie.Name = "picOpenBarrie";
            picOpenBarrie.Size = new Size(52, 30);
            picOpenBarrie.SizeMode = PictureBoxSizeMode.Zoom;
            picOpenBarrie.TabIndex = 11;
            picOpenBarrie.TabStop = false;
            picOpenBarrie.Click += btnOpenBarrie_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkGreen;
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(873, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(5, 30);
            panel1.TabIndex = 10;
            // 
            // panel7
            // 
            panel7.BackColor = Color.DarkGreen;
            panel7.Dock = DockStyle.Right;
            panel7.Location = new Point(930, 0);
            panel7.Margin = new Padding(0);
            panel7.Name = "panel7";
            panel7.Size = new Size(5, 30);
            panel7.TabIndex = 9;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.DarkGreen;
            pictureBox2.Dock = DockStyle.Right;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(935, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(52, 30);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            pictureBox2.Visible = false;
            // 
            // splitterEventInfoWithCamera
            // 
            splitterEventInfoWithCamera.Dock = DockStyle.Right;
            splitterEventInfoWithCamera.Location = new Point(754, 30);
            splitterEventInfoWithCamera.Name = "splitterEventInfoWithCamera";
            splitterEventInfoWithCamera.Size = new Size(5, 519);
            splitterEventInfoWithCamera.TabIndex = 7;
            splitterEventInfoWithCamera.TabStop = false;
            // 
            // panelEventData
            // 
            panelEventData.Controls.Add(splitContainerEventContent);
            panelEventData.Controls.Add(panelScaleAction);
            panelEventData.Controls.Add(panelGoodsType);
            panelEventData.Dock = DockStyle.Right;
            panelEventData.Location = new Point(759, 30);
            panelEventData.Name = "panelEventData";
            panelEventData.Size = new Size(228, 519);
            panelEventData.TabIndex = 8;
            // 
            // panelScaleAction
            // 
            panelScaleAction.Controls.Add(btnopenBarrie);
            panelScaleAction.Controls.Add(btnPrintScale);
            panelScaleAction.Dock = DockStyle.Bottom;
            panelScaleAction.Location = new Point(0, 425);
            panelScaleAction.Name = "panelScaleAction";
            panelScaleAction.Size = new Size(228, 94);
            panelScaleAction.TabIndex = 1;
            // 
            // btnopenBarrie
            // 
            btnopenBarrie.Image = (Image)resources.GetObject("btnopenBarrie.Image");
            btnopenBarrie.Location = new Point(120, 6);
            btnopenBarrie.Name = "btnopenBarrie";
            btnopenBarrie.Size = new Size(108, 84);
            btnopenBarrie.TabIndex = 0;
            btnopenBarrie.Text = "Mở barrie";
            btnopenBarrie.TextAlign = ContentAlignment.BottomCenter;
            btnopenBarrie.TextImageRelation = TextImageRelation.ImageAboveText;
            btnopenBarrie.UseVisualStyleBackColor = true;
            btnopenBarrie.Click += btnOpenBarrie_Click;
            // 
            // btnPrintScale
            // 
            btnPrintScale.Image = (Image)resources.GetObject("btnPrintScale.Image");
            btnPrintScale.Location = new Point(6, 7);
            btnPrintScale.Name = "btnPrintScale";
            btnPrintScale.Size = new Size(108, 84);
            btnPrintScale.TabIndex = 0;
            btnPrintScale.Text = "In phiếu cân";
            btnPrintScale.TextAlign = ContentAlignment.BottomCenter;
            btnPrintScale.TextImageRelation = TextImageRelation.ImageAboveText;
            btnPrintScale.UseVisualStyleBackColor = true;
            btnPrintScale.Click += btnPrintScale_Click;
            // 
            // panelGoodsType
            // 
            panelGoodsType.Controls.Add(cbGoodsType);
            panelGoodsType.Dock = DockStyle.Top;
            panelGoodsType.Location = new Point(0, 0);
            panelGoodsType.Name = "panelGoodsType";
            panelGoodsType.Padding = new Padding(0, 5, 0, 5);
            panelGoodsType.Size = new Size(228, 50);
            panelGoodsType.TabIndex = 3;
            // 
            // cbGoodsType
            // 
            cbGoodsType.BackColor = Color.Silver;
            cbGoodsType.Dock = DockStyle.Fill;
            cbGoodsType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGoodsType.FlatStyle = FlatStyle.Popup;
            cbGoodsType.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cbGoodsType.ForeColor = Color.FromArgb(192, 0, 0);
            cbGoodsType.FormattingEnabled = true;
            cbGoodsType.Location = new Point(0, 5);
            cbGoodsType.Name = "cbGoodsType";
            cbGoodsType.Size = new Size(228, 38);
            cbGoodsType.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.FromArgb(255, 128, 0);
            tableLayoutPanel3.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(label4, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(200, 100);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label4.Location = new Point(4, 1);
            label4.Name = "label4";
            label4.Size = new Size(71, 20);
            label4.TabIndex = 0;
            label4.Text = "GHI CHÚ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label5.Location = new Point(4, 22);
            label5.Name = "label5";
            label5.Size = new Size(166, 40);
            label5.TabIndex = 0;
            label5.Text = "GHI CHÚ DỊCH VỤ HẠ TẦNG";
            // 
            // ucLaneIn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitterEventInfoWithCamera);
            Controls.Add(panelEventData);
            Controls.Add(splitContainerMain);
            Controls.Add(panel5);
            Margin = new Padding(0);
            Name = "ucLaneIn";
            Size = new Size(987, 549);
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picVehicleImage).EndInit();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picOverviewImage).EndInit();
            panel4.ResumeLayout(false);
            panelLastEvent.ResumeLayout(false);
            splitContainerEventContent.Panel1.ResumeLayout(false);
            splitContainerEventContent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerEventContent).EndInit();
            splitContainerEventContent.ResumeLayout(false);
            panelDetectPlate.ResumeLayout(false);
            panelDetectPlate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLprImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEventContent).EndInit();
            panelNote.ResumeLayout(false);
            tableLayoutPanelNote.ResumeLayout(false);
            tableLayoutPanelNote.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picSetting).EndInit();
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picRetakePhoto).EndInit();
            ((System.ComponentModel.ISupportInitialize)picWriteIn).EndInit();
            ((System.ComponentModel.ISupportInitialize)picOpenBarrie).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panelEventData.ResumeLayout(false);
            panelScaleAction.ResumeLayout(false);
            panelGoodsType.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblLaneName;
        private Panel panelCameras;
        private SplitContainer splitContainerMain;
        private TableLayoutPanel tableLayoutPanel1;
        private Splitter splitterCamera;
        private SplitContainer splitContainerEventContent;
        private Panel panelAction;
        private TextBox txtPlate;
        private DataGridView dgvEventContent;
        private iPakrkingv5.Controls.Controls.Labels.lblResult lblResult;
        private MovablePictureBox picLprImage;
        private Panel panel2;
        private MovablePictureBox picOverviewImage;
        private Panel panel3;
        private MovablePictureBox picVehicleImage;
        private Panel panelDetectPlate;
        private Label label1;
        private Button btnReTakePhoto;
        private Button btnWriteIn;
        private PictureBox picSetting;
        private Panel panel5;
        private PictureBox pictureBox2;
        private Panel panel7;
        private Button btnOpenBarrie;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private ToolTip toolTip1;
        private ToolTip toolTip2;
        private ToolTip toolTip3;
        private PictureBox picRetakePhoto;
        private Panel panel8;
        private PictureBox picWriteIn;
        private Panel panel6;
        private PictureBox picOpenBarrie;
        private Panel panel1;
        private Panel panelLastEvent;
        private ucLastEventInfo ucTop1Event;
        private ucLastEventInfo ucTop3Event;
        private ucLastEventInfo ucTop2Event;
        private TableLayoutPanel tableLayoutPanel2;
        private Splitter splitterEventInfoWithCamera;
        private ucEventCount ucEventCount1;
        private Panel panel4;
        private Label label2;
        private Panel panel9;
        private Panel panelEventData;
        private Panel panelScaleAction;
        private Button btnopenBarrie;
        private Button btnPrintScale;
        private Panel panelGoodsType;
        private ComboBox cbGoodsType;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label4;
        private Label label5;
        private Panel panelNote;
        private TableLayoutPanel tableLayoutPanelNote;
        private Label label3;
        private Label label6;
        private GroupBox groupBox1;
        private ComboBox cbNote;
    }
}
