using iPakrkingv5.Controls.Controls.Labels;

namespace iParkingv5_window.Usercontrols
{
    partial class ucLaneOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLaneOut));
            lblLaneName = new Label();
            panelCameras = new Panel();
            splitContainerMain = new SplitContainer();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel3 = new Panel();
            picVehicleImageIn = new MovablePictureBox();
            panel2 = new Panel();
            picVehicleImageOut = new MovablePictureBox();
            panel6 = new Panel();
            picOverviewImageOut = new MovablePictureBox();
            panel5 = new Panel();
            picOverviewImageIn = new MovablePictureBox();
            label1 = new Label();
            label2 = new Label();
            splitterCamera = new Splitter();
            panelLastEvent = new Panel();
            panel11 = new Panel();
            label3 = new Label();
            ucEventCount1 = new ucEventCount();
            lblResult = new lblResult();
            splitContainerEventContent = new SplitContainer();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel14 = new Panel();
            picLprImage = new MovablePictureBox();
            txtPlate = new TextBox();
            panel15 = new Panel();
            picLprImageIn = new MovablePictureBox();
            lblPlateIn = new Label();
            dgvEventContent = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            panel4 = new Panel();
            picRetakePhoto = new PictureBox();
            panel10 = new Panel();
            picWriteOut = new PictureBox();
            panel8 = new Panel();
            picOpenBarrie = new PictureBox();
            panel1 = new Panel();
            picPrint = new PictureBox();
            panel9 = new Panel();
            picSetting = new PictureBox();
            panel7 = new Panel();
            pictureBox2 = new PictureBox();
            toolTip1 = new ToolTip(components);
            toolTip2 = new ToolTip(components);
            toolTip3 = new ToolTip(components);
            splitterEventInfoWithCamera = new Splitter();
            panelEventData = new Panel();
            panelScaleAction = new Panel();
            btnOpenBarrie = new Button();
            button2 = new Button();
            toolTipPrint = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picVehicleImageIn).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picVehicleImageOut).BeginInit();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picOverviewImageOut).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picOverviewImageIn).BeginInit();
            panelLastEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerEventContent).BeginInit();
            splitContainerEventContent.Panel1.SuspendLayout();
            splitContainerEventContent.Panel2.SuspendLayout();
            splitContainerEventContent.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLprImage).BeginInit();
            panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLprImageIn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEventContent).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picRetakePhoto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picWriteOut).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picOpenBarrie).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picPrint).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSetting).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panelEventData.SuspendLayout();
            panelScaleAction.SuspendLayout();
            SuspendLayout();
            // 
            // lblLaneName
            // 
            lblLaneName.BackColor = Color.DarkRed;
            lblLaneName.Dock = DockStyle.Fill;
            lblLaneName.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblLaneName.ForeColor = SystemColors.ButtonHighlight;
            lblLaneName.Location = new Point(0, 0);
            lblLaneName.Margin = new Padding(0);
            lblLaneName.Name = "lblLaneName";
            lblLaneName.Size = new Size(1041, 22);
            lblLaneName.TabIndex = 0;
            lblLaneName.Text = "label1";
            lblLaneName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelCameras
            // 
            panelCameras.BorderStyle = BorderStyle.FixedSingle;
            panelCameras.Dock = DockStyle.Left;
            panelCameras.Location = new Point(0, 0);
            panelCameras.Margin = new Padding(3, 2, 3, 2);
            panelCameras.Name = "panelCameras";
            panelCameras.Size = new Size(211, 285);
            panelCameras.TabIndex = 3;
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(0, 22);
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
            splitContainerMain.Panel2.Controls.Add(panelLastEvent);
            splitContainerMain.Panel2.Controls.Add(ucEventCount1);
            splitContainerMain.Panel2.Controls.Add(lblResult);
            splitContainerMain.Size = new Size(1187, 408);
            splitContainerMain.SplitterDistance = 285;
            splitContainerMain.SplitterWidth = 3;
            splitContainerMain.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel3, 0, 2);
            tableLayoutPanel1.Controls.Add(panel2, 1, 2);
            tableLayoutPanel1.Controls.Add(panel6, 1, 1);
            tableLayoutPanel1.Controls.Add(panel5, 0, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(214, 0);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(973, 285);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Control;
            panel3.Controls.Add(picVehicleImageIn);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(5, 162);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(477, 119);
            panel3.TabIndex = 1;
            // 
            // picVehicleImageIn
            // 
            picVehicleImageIn.BackColor = Color.WhiteSmoke;
            picVehicleImageIn.Dock = DockStyle.Fill;
            picVehicleImageIn.Location = new Point(0, 0);
            picVehicleImageIn.Margin = new Padding(3, 2, 3, 2);
            picVehicleImageIn.Name = "picVehicleImageIn";
            picVehicleImageIn.Size = new Size(477, 119);
            picVehicleImageIn.SizeMode = PictureBoxSizeMode.StretchImage;
            picVehicleImageIn.TabIndex = 5;
            picVehicleImageIn.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(picVehicleImageOut);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(490, 162);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(478, 119);
            panel2.TabIndex = 0;
            // 
            // picVehicleImageOut
            // 
            picVehicleImageOut.BackColor = Color.WhiteSmoke;
            picVehicleImageOut.Dock = DockStyle.Fill;
            picVehicleImageOut.Location = new Point(0, 0);
            picVehicleImageOut.Margin = new Padding(3, 2, 3, 2);
            picVehicleImageOut.Name = "picVehicleImageOut";
            picVehicleImageOut.Size = new Size(478, 119);
            picVehicleImageOut.SizeMode = PictureBoxSizeMode.StretchImage;
            picVehicleImageOut.TabIndex = 5;
            picVehicleImageOut.TabStop = false;
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.Control;
            panel6.Controls.Add(picOverviewImageOut);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(490, 37);
            panel6.Margin = new Padding(3, 2, 3, 2);
            panel6.Name = "panel6";
            panel6.Size = new Size(478, 119);
            panel6.TabIndex = 3;
            // 
            // picOverviewImageOut
            // 
            picOverviewImageOut.BackColor = Color.WhiteSmoke;
            picOverviewImageOut.Dock = DockStyle.Fill;
            picOverviewImageOut.Location = new Point(0, 0);
            picOverviewImageOut.Margin = new Padding(3, 2, 3, 2);
            picOverviewImageOut.Name = "picOverviewImageOut";
            picOverviewImageOut.Size = new Size(478, 119);
            picOverviewImageOut.SizeMode = PictureBoxSizeMode.StretchImage;
            picOverviewImageOut.TabIndex = 5;
            picOverviewImageOut.TabStop = false;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.Control;
            panel5.Controls.Add(picOverviewImageIn);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(5, 37);
            panel5.Margin = new Padding(3, 2, 3, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(477, 119);
            panel5.TabIndex = 2;
            // 
            // picOverviewImageIn
            // 
            picOverviewImageIn.BackColor = Color.WhiteSmoke;
            picOverviewImageIn.Dock = DockStyle.Fill;
            picOverviewImageIn.Location = new Point(0, 0);
            picOverviewImageIn.Margin = new Padding(3, 2, 3, 2);
            picOverviewImageIn.Name = "picOverviewImageIn";
            picOverviewImageIn.Size = new Size(477, 119);
            picOverviewImageIn.SizeMode = PictureBoxSizeMode.StretchImage;
            picOverviewImageIn.TabIndex = 5;
            picOverviewImageIn.TabStop = false;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Underline);
            label1.ForeColor = Color.Green;
            label1.Location = new Point(5, 2);
            label1.Name = "label1";
            label1.Size = new Size(477, 31);
            label1.TabIndex = 4;
            label1.Text = "Ảnh Vào";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Underline);
            label2.ForeColor = Color.Maroon;
            label2.Location = new Point(490, 2);
            label2.Name = "label2";
            label2.Size = new Size(478, 31);
            label2.TabIndex = 5;
            label2.Text = "Ảnh Ra";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // splitterCamera
            // 
            splitterCamera.Location = new Point(211, 0);
            splitterCamera.Margin = new Padding(3, 2, 3, 2);
            splitterCamera.Name = "splitterCamera";
            splitterCamera.Size = new Size(3, 285);
            splitterCamera.TabIndex = 4;
            splitterCamera.TabStop = false;
            // 
            // panelLastEvent
            // 
            panelLastEvent.BackColor = SystemColors.ButtonHighlight;
            panelLastEvent.BorderStyle = BorderStyle.FixedSingle;
            panelLastEvent.Controls.Add(panel11);
            panelLastEvent.Controls.Add(label3);
            panelLastEvent.Dock = DockStyle.Fill;
            panelLastEvent.Location = new Point(214, 26);
            panelLastEvent.Margin = new Padding(3, 2, 3, 2);
            panelLastEvent.Name = "panelLastEvent";
            panelLastEvent.Size = new Size(973, 94);
            panelLastEvent.TabIndex = 8;
            // 
            // panel11
            // 
            panel11.Dock = DockStyle.Fill;
            panel11.Location = new Point(0, 27);
            panel11.Margin = new Padding(3, 2, 3, 2);
            panel11.Name = "panel11";
            panel11.Size = new Size(971, 65);
            panel11.TabIndex = 8;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label3.ForeColor = Color.Navy;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(971, 27);
            label3.TabIndex = 7;
            label3.Text = "Các lượt xe vào gần đây";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ucEventCount1
            // 
            ucEventCount1.Dock = DockStyle.Left;
            ucEventCount1.Location = new Point(0, 26);
            ucEventCount1.Margin = new Padding(3, 2, 3, 2);
            ucEventCount1.Name = "ucEventCount1";
            ucEventCount1.Size = new Size(214, 94);
            ucEventCount1.TabIndex = 2;
            // 
            // lblResult
            // 
            lblResult.BackColor = Color.FromArgb(0, 64, 0);
            lblResult.Dock = DockStyle.Top;
            lblResult.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblResult.ForeColor = SystemColors.ButtonHighlight;
            lblResult.Location = new Point(0, 0);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(1187, 26);
            lblResult.TabIndex = 1;
            lblResult.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // splitContainerEventContent
            // 
            splitContainerEventContent.Dock = DockStyle.Fill;
            splitContainerEventContent.Location = new Point(0, 0);
            splitContainerEventContent.Margin = new Padding(3, 2, 3, 2);
            splitContainerEventContent.Name = "splitContainerEventContent";
            // 
            // splitContainerEventContent.Panel1
            // 
            splitContainerEventContent.Panel1.Controls.Add(tableLayoutPanel2);
            // 
            // splitContainerEventContent.Panel2
            // 
            splitContainerEventContent.Panel2.AutoScroll = true;
            splitContainerEventContent.Panel2.Controls.Add(dgvEventContent);
            splitContainerEventContent.Size = new Size(308, 332);
            splitContainerEventContent.SplitterDistance = 109;
            splitContainerEventContent.SplitterWidth = 3;
            splitContainerEventContent.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(panel14, 1, 0);
            tableLayoutPanel2.Controls.Add(panel15, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(109, 332);
            tableLayoutPanel2.TabIndex = 5;
            // 
            // panel14
            // 
            panel14.Controls.Add(picLprImage);
            panel14.Controls.Add(txtPlate);
            panel14.Dock = DockStyle.Fill;
            panel14.Location = new Point(57, 2);
            panel14.Margin = new Padding(3, 2, 3, 2);
            panel14.Name = "panel14";
            panel14.Size = new Size(49, 328);
            panel14.TabIndex = 0;
            // 
            // picLprImage
            // 
            picLprImage.BackColor = Color.WhiteSmoke;
            picLprImage.Dock = DockStyle.Fill;
            picLprImage.Location = new Point(0, 32);
            picLprImage.Margin = new Padding(3, 2, 3, 2);
            picLprImage.Name = "picLprImage";
            picLprImage.Size = new Size(49, 296);
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
            txtPlate.Margin = new Padding(3, 2, 3, 2);
            txtPlate.Name = "txtPlate";
            txtPlate.Size = new Size(49, 32);
            txtPlate.TabIndex = 0;
            txtPlate.TextAlign = HorizontalAlignment.Center;
            // 
            // panel15
            // 
            panel15.Controls.Add(picLprImageIn);
            panel15.Controls.Add(lblPlateIn);
            panel15.Dock = DockStyle.Fill;
            panel15.Location = new Point(3, 2);
            panel15.Margin = new Padding(3, 2, 3, 2);
            panel15.Name = "panel15";
            panel15.Size = new Size(48, 328);
            panel15.TabIndex = 1;
            // 
            // picLprImageIn
            // 
            picLprImageIn.BackColor = Color.WhiteSmoke;
            picLprImageIn.Dock = DockStyle.Fill;
            picLprImageIn.Location = new Point(0, 24);
            picLprImageIn.Margin = new Padding(3, 2, 3, 2);
            picLprImageIn.Name = "picLprImageIn";
            picLprImageIn.Size = new Size(48, 304);
            picLprImageIn.SizeMode = PictureBoxSizeMode.StretchImage;
            picLprImageIn.TabIndex = 1;
            picLprImageIn.TabStop = false;
            // 
            // lblPlateIn
            // 
            lblPlateIn.BackColor = SystemColors.HighlightText;
            lblPlateIn.Dock = DockStyle.Top;
            lblPlateIn.Location = new Point(0, 0);
            lblPlateIn.Name = "lblPlateIn";
            lblPlateIn.Size = new Size(48, 24);
            lblPlateIn.TabIndex = 0;
            lblPlateIn.TextAlign = ContentAlignment.MiddleCenter;
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
            dgvEventContent.Location = new Point(0, 0);
            dgvEventContent.Margin = new Padding(3, 2, 3, 2);
            dgvEventContent.Name = "dgvEventContent";
            dgvEventContent.ReadOnly = true;
            dgvEventContent.RowHeadersVisible = false;
            dgvEventContent.RowTemplate.Height = 29;
            dgvEventContent.Size = new Size(196, 332);
            dgvEventContent.TabIndex = 1;
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
            // panel4
            // 
            panel4.Controls.Add(picRetakePhoto);
            panel4.Controls.Add(panel10);
            panel4.Controls.Add(picWriteOut);
            panel4.Controls.Add(panel8);
            panel4.Controls.Add(picOpenBarrie);
            panel4.Controls.Add(panel1);
            panel4.Controls.Add(lblLaneName);
            panel4.Controls.Add(picPrint);
            panel4.Controls.Add(panel9);
            panel4.Controls.Add(picSetting);
            panel4.Controls.Add(panel7);
            panel4.Controls.Add(pictureBox2);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Margin = new Padding(0);
            panel4.Name = "panel4";
            panel4.Size = new Size(1187, 22);
            panel4.TabIndex = 5;
            // 
            // picRetakePhoto
            // 
            picRetakePhoto.BackColor = Color.DarkRed;
            picRetakePhoto.Dock = DockStyle.Right;
            picRetakePhoto.Image = (Image)resources.GetObject("picRetakePhoto.Image");
            picRetakePhoto.Location = new Point(891, 0);
            picRetakePhoto.Margin = new Padding(3, 2, 3, 2);
            picRetakePhoto.Name = "picRetakePhoto";
            picRetakePhoto.Size = new Size(46, 22);
            picRetakePhoto.SizeMode = PictureBoxSizeMode.Zoom;
            picRetakePhoto.TabIndex = 16;
            picRetakePhoto.TabStop = false;
            picRetakePhoto.Click += BtnReTakePhoto_Click;
            // 
            // panel10
            // 
            panel10.BackColor = Color.DarkRed;
            panel10.Dock = DockStyle.Right;
            panel10.Location = new Point(937, 0);
            panel10.Margin = new Padding(0);
            panel10.Name = "panel10";
            panel10.Size = new Size(4, 22);
            panel10.TabIndex = 15;
            // 
            // picWriteOut
            // 
            picWriteOut.BackColor = Color.DarkRed;
            picWriteOut.Dock = DockStyle.Right;
            picWriteOut.Image = (Image)resources.GetObject("picWriteOut.Image");
            picWriteOut.Location = new Point(941, 0);
            picWriteOut.Margin = new Padding(3, 2, 3, 2);
            picWriteOut.Name = "picWriteOut";
            picWriteOut.Size = new Size(46, 22);
            picWriteOut.SizeMode = PictureBoxSizeMode.Zoom;
            picWriteOut.TabIndex = 14;
            picWriteOut.TabStop = false;
            picWriteOut.Click += BtnWriteOut_Click;
            // 
            // panel8
            // 
            panel8.BackColor = Color.DarkRed;
            panel8.Dock = DockStyle.Right;
            panel8.Location = new Point(987, 0);
            panel8.Margin = new Padding(0);
            panel8.Name = "panel8";
            panel8.Size = new Size(4, 22);
            panel8.TabIndex = 11;
            // 
            // picOpenBarrie
            // 
            picOpenBarrie.BackColor = Color.DarkRed;
            picOpenBarrie.Dock = DockStyle.Right;
            picOpenBarrie.Image = (Image)resources.GetObject("picOpenBarrie.Image");
            picOpenBarrie.Location = new Point(991, 0);
            picOpenBarrie.Margin = new Padding(3, 2, 3, 2);
            picOpenBarrie.Name = "picOpenBarrie";
            picOpenBarrie.Size = new Size(46, 22);
            picOpenBarrie.SizeMode = PictureBoxSizeMode.Zoom;
            picOpenBarrie.TabIndex = 10;
            picOpenBarrie.TabStop = false;
            picOpenBarrie.Click += btnOpenBarrie_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkRed;
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(1037, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(4, 22);
            panel1.TabIndex = 9;
            // 
            // picPrint
            // 
            picPrint.BackColor = Color.DarkRed;
            picPrint.Dock = DockStyle.Right;
            picPrint.Image = (Image)resources.GetObject("picPrint.Image");
            picPrint.Location = new Point(1041, 0);
            picPrint.Margin = new Padding(3, 2, 3, 2);
            picPrint.Name = "picPrint";
            picPrint.Size = new Size(46, 22);
            picPrint.SizeMode = PictureBoxSizeMode.Zoom;
            picPrint.TabIndex = 18;
            picPrint.TabStop = false;
            picPrint.Click += btnPrintTicket_Click;
            // 
            // panel9
            // 
            panel9.BackColor = Color.DarkRed;
            panel9.Dock = DockStyle.Right;
            panel9.Location = new Point(1087, 0);
            panel9.Margin = new Padding(0);
            panel9.Name = "panel9";
            panel9.Size = new Size(4, 22);
            panel9.TabIndex = 17;
            // 
            // picSetting
            // 
            picSetting.BackColor = Color.DarkRed;
            picSetting.Dock = DockStyle.Right;
            picSetting.Image = (Image)resources.GetObject("picSetting.Image");
            picSetting.Location = new Point(1091, 0);
            picSetting.Margin = new Padding(3, 2, 3, 2);
            picSetting.Name = "picSetting";
            picSetting.Size = new Size(46, 22);
            picSetting.SizeMode = PictureBoxSizeMode.Zoom;
            picSetting.TabIndex = 6;
            picSetting.TabStop = false;
            picSetting.Click += picSetting_Click;
            // 
            // panel7
            // 
            panel7.BackColor = Color.DarkRed;
            panel7.Dock = DockStyle.Right;
            panel7.Location = new Point(1137, 0);
            panel7.Margin = new Padding(0);
            panel7.Name = "panel7";
            panel7.Size = new Size(4, 22);
            panel7.TabIndex = 8;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.DarkRed;
            pictureBox2.Dock = DockStyle.Right;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(1141, 0);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(46, 22);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            pictureBox2.Visible = false;
            // 
            // splitterEventInfoWithCamera
            // 
            splitterEventInfoWithCamera.Dock = DockStyle.Right;
            splitterEventInfoWithCamera.Location = new Point(875, 22);
            splitterEventInfoWithCamera.Margin = new Padding(3, 2, 3, 2);
            splitterEventInfoWithCamera.Name = "splitterEventInfoWithCamera";
            splitterEventInfoWithCamera.Size = new Size(4, 408);
            splitterEventInfoWithCamera.TabIndex = 6;
            splitterEventInfoWithCamera.TabStop = false;
            // 
            // panelEventData
            // 
            panelEventData.Controls.Add(splitContainerEventContent);
            panelEventData.Controls.Add(panelScaleAction);
            panelEventData.Dock = DockStyle.Right;
            panelEventData.Location = new Point(879, 22);
            panelEventData.Margin = new Padding(3, 2, 3, 2);
            panelEventData.Name = "panelEventData";
            panelEventData.Size = new Size(308, 408);
            panelEventData.TabIndex = 7;
            // 
            // panelScaleAction
            // 
            panelScaleAction.Controls.Add(btnOpenBarrie);
            panelScaleAction.Controls.Add(button2);
            panelScaleAction.Dock = DockStyle.Bottom;
            panelScaleAction.Location = new Point(0, 332);
            panelScaleAction.Margin = new Padding(3, 2, 3, 2);
            panelScaleAction.Name = "panelScaleAction";
            panelScaleAction.Size = new Size(308, 76);
            panelScaleAction.TabIndex = 1;
            // 
            // btnOpenBarrie
            // 
            btnOpenBarrie.Image = (Image)resources.GetObject("btnOpenBarrie.Image");
            btnOpenBarrie.ImageAlign = ContentAlignment.BottomCenter;
            btnOpenBarrie.Location = new Point(205, 11);
            btnOpenBarrie.Margin = new Padding(3, 2, 3, 2);
            btnOpenBarrie.Name = "btnOpenBarrie";
            btnOpenBarrie.Size = new Size(94, 63);
            btnOpenBarrie.TabIndex = 1;
            btnOpenBarrie.Text = "Mở barrie";
            btnOpenBarrie.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOpenBarrie.UseVisualStyleBackColor = true;
            btnOpenBarrie.Click += btnOpenBarrie_Click;
            // 
            // button2
            // 
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.BottomCenter;
            button2.Location = new Point(105, 11);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(94, 62);
            button2.TabIndex = 1;
            button2.Text = "In vé xe";
            button2.TextImageRelation = TextImageRelation.ImageAboveText;
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnPrintTicket_Click;
            // 
            // ucLaneOut
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitterEventInfoWithCamera);
            Controls.Add(panelEventData);
            Controls.Add(splitContainerMain);
            Controls.Add(panel4);
            Margin = new Padding(0);
            Name = "ucLaneOut";
            Size = new Size(1187, 430);
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picVehicleImageIn).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picVehicleImageOut).EndInit();
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picOverviewImageOut).EndInit();
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picOverviewImageIn).EndInit();
            panelLastEvent.ResumeLayout(false);
            splitContainerEventContent.Panel1.ResumeLayout(false);
            splitContainerEventContent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerEventContent).EndInit();
            splitContainerEventContent.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel14.ResumeLayout(false);
            panel14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLprImage).EndInit();
            panel15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLprImageIn).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEventContent).EndInit();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picRetakePhoto).EndInit();
            ((System.ComponentModel.ISupportInitialize)picWriteOut).EndInit();
            ((System.ComponentModel.ISupportInitialize)picOpenBarrie).EndInit();
            ((System.ComponentModel.ISupportInitialize)picPrint).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSetting).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panelEventData.ResumeLayout(false);
            panelScaleAction.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblLaneName;
        private Panel panelCameras;
        private SplitContainer splitContainerMain;
        private TableLayoutPanel tableLayoutPanel1;
        private Splitter splitterCamera;
        private SplitContainer splitContainerEventContent;
        private TextBox txtPlate;
        private lblResult lblResult;
        private MovablePictureBox picLprImage;
        private Panel panel2;
        private MovablePictureBox picOverviewImageOut;
        private Panel panel3;
        private MovablePictureBox picOverviewImageIn;
        private Panel panel6;
        private MovablePictureBox picVehicleImageOut;
        private Panel panel5;
        private MovablePictureBox picVehicleImageIn;
        private Label label1;
        private Label label2;
        private DataGridView dgvEventContent;
        private Panel panel4;
        private PictureBox picSetting;
        private PictureBox pictureBox2;
        private Panel panel7;
        private ToolTip toolTip1;
        private ToolTip toolTip2;
        private ToolTip toolTip3;
        private PictureBox picWriteOut;
        private Panel panel8;
        private PictureBox picOpenBarrie;
        private Panel panel1;
        private PictureBox picRetakePhoto;
        private Panel panel10;
        private PictureBox picPrint;
        private Panel panel9;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private Splitter splitterEventInfoWithCamera;
        private ucEventCount ucEventCount1;
        private Panel panelLastEvent;
        private Panel panel11;
        private Label label3;
        private Panel panelEventData;
        private Panel panelScaleAction;
        private Button btnOpenBarrie;
        private Button button2;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel14;
        private Panel panel15;
        private MovablePictureBox picLprImageIn;
        private Label lblPlateIn;
        private ToolTip toolTipPrint;
    }
}
