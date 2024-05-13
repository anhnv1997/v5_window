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
            tableLayoutPanel2 = new TableLayoutPanel();
            panel2 = new Panel();
            picVehicleImage = new MovablePictureBox();
            panel3 = new Panel();
            picOverviewImage = new MovablePictureBox();
            label1 = new Label();
            splitterCamera = new Splitter();
            lblResult = new iPakrkingv5.Controls.Controls.Labels.lblResult();
            panel4 = new Panel();
            panelEventData = new Panel();
            splitContainerEventContent = new SplitContainer();
            panelDetectPlate = new Panel();
            picLprImage = new MovablePictureBox();
            txtPlate = new TextBox();
            dgvEventContent = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            panelLastEvent = new Panel();
            panel9 = new Panel();
            label2 = new Label();
            ucEventCount1 = new ucEventCount();
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
            ((System.ComponentModel.ISupportInitialize)splitContainerEventContent).BeginInit();
            splitContainerEventContent.Panel1.SuspendLayout();
            splitContainerEventContent.Panel2.SuspendLayout();
            splitContainerEventContent.SuspendLayout();
            panelDetectPlate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLprImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEventContent).BeginInit();
            panelLastEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picSetting).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picRetakePhoto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picWriteIn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picOpenBarrie).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
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
            lblLaneName.Size = new Size(865, 22);
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
            panelCameras.Size = new Size(211, 312);
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
            splitContainerMain.Panel2.Controls.Add(splitContainerEventContent);
            splitContainerMain.Panel2.Controls.Add(lblResult);
            splitContainerMain.Size = new Size(961, 534);
            splitContainerMain.SplitterDistance = 312;
            splitContainerMain.SplitterWidth = 3;
            splitContainerMain.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(214, 0);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            tableLayoutPanel1.Size = new Size(747, 312);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(panel2, 0, 1);
            tableLayoutPanel2.Controls.Add(panel3, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(5, 36);
            tableLayoutPanel2.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(737, 272);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(picVehicleImage);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 138);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(731, 132);
            panel2.TabIndex = 0;
            // 
            // picVehicleImage
            // 
            picVehicleImage.BackColor = Color.WhiteSmoke;
            picVehicleImage.Dock = DockStyle.Fill;
            picVehicleImage.ErrorImage = null;
            picVehicleImage.Location = new Point(0, 0);
            picVehicleImage.Margin = new Padding(3, 2, 3, 2);
            picVehicleImage.Name = "picVehicleImage";
            picVehicleImage.Size = new Size(731, 132);
            picVehicleImage.SizeMode = PictureBoxSizeMode.StretchImage;
            picVehicleImage.TabIndex = 5;
            picVehicleImage.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Control;
            panel3.Controls.Add(picOverviewImage);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 2);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(731, 132);
            panel3.TabIndex = 1;
            // 
            // picOverviewImage
            // 
            picOverviewImage.BackColor = Color.WhiteSmoke;
            picOverviewImage.Dock = DockStyle.Fill;
            picOverviewImage.ErrorImage = null;
            picOverviewImage.Location = new Point(0, 0);
            picOverviewImage.Margin = new Padding(3, 2, 3, 2);
            picOverviewImage.Name = "picOverviewImage";
            picOverviewImage.Size = new Size(731, 132);
            picOverviewImage.SizeMode = PictureBoxSizeMode.StretchImage;
            picOverviewImage.TabIndex = 5;
            picOverviewImage.TabStop = false;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Underline);
            label1.ForeColor = Color.Green;
            label1.Location = new Point(5, 2);
            label1.Name = "label1";
            label1.Size = new Size(737, 30);
            label1.TabIndex = 2;
            label1.Text = "Ảnh Vào";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // splitterCamera
            // 
            splitterCamera.Location = new Point(211, 0);
            splitterCamera.Margin = new Padding(3, 2, 3, 2);
            splitterCamera.Name = "splitterCamera";
            splitterCamera.Size = new Size(3, 312);
            splitterCamera.TabIndex = 4;
            splitterCamera.TabStop = false;
            // 
            // lblResult
            // 
            lblResult.BackColor = Color.FromArgb(0, 64, 0);
            lblResult.Dock = DockStyle.Top;
            lblResult.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblResult.ForeColor = SystemColors.ButtonHighlight;
            lblResult.Location = new Point(0, 0);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(961, 26);
            lblResult.TabIndex = 1;
            lblResult.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            panel4.Controls.Add(panelEventData);
            panel4.Controls.Add(panelLastEvent);
            panel4.Controls.Add(ucEventCount1);
            panel4.Font = new Font("Segoe UI", 13F);
            panel4.Location = new Point(60, 395);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(864, 150);
            panel4.TabIndex = 2;
            // 
            // panelEventData
            // 
            panelEventData.Dock = DockStyle.Fill;
            panelEventData.Location = new Point(482, 0);
            panelEventData.Margin = new Padding(3, 2, 3, 2);
            panelEventData.Name = "panelEventData";
            panelEventData.Size = new Size(382, 150);
            panelEventData.TabIndex = 8;
            // 
            // splitContainerEventContent
            // 
            splitContainerEventContent.Dock = DockStyle.Fill;
            splitContainerEventContent.Location = new Point(0, 26);
            splitContainerEventContent.Margin = new Padding(3, 2, 3, 2);
            splitContainerEventContent.Name = "splitContainerEventContent";
            // 
            // splitContainerEventContent.Panel1
            // 
            splitContainerEventContent.Panel1.Controls.Add(panelDetectPlate);
            // 
            // splitContainerEventContent.Panel2
            // 
            splitContainerEventContent.Panel2.Controls.Add(dgvEventContent);
            splitContainerEventContent.Size = new Size(961, 193);
            splitContainerEventContent.SplitterDistance = 656;
            splitContainerEventContent.SplitterWidth = 3;
            splitContainerEventContent.TabIndex = 0;
            // 
            // panelDetectPlate
            // 
            panelDetectPlate.Controls.Add(picLprImage);
            panelDetectPlate.Controls.Add(txtPlate);
            panelDetectPlate.Dock = DockStyle.Fill;
            panelDetectPlate.Location = new Point(0, 0);
            panelDetectPlate.Margin = new Padding(3, 2, 3, 2);
            panelDetectPlate.Name = "panelDetectPlate";
            panelDetectPlate.Size = new Size(656, 193);
            panelDetectPlate.TabIndex = 4;
            // 
            // picLprImage
            // 
            picLprImage.BackColor = Color.WhiteSmoke;
            picLprImage.Dock = DockStyle.Fill;
            picLprImage.Location = new Point(0, 32);
            picLprImage.Margin = new Padding(3, 2, 3, 2);
            picLprImage.Name = "picLprImage";
            picLprImage.Size = new Size(656, 161);
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
            txtPlate.Size = new Size(656, 32);
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
            dgvEventContent.Location = new Point(0, 0);
            dgvEventContent.Margin = new Padding(3, 2, 3, 2);
            dgvEventContent.Name = "dgvEventContent";
            dgvEventContent.ReadOnly = true;
            dgvEventContent.RowHeadersVisible = false;
            dgvEventContent.RowTemplate.Height = 29;
            dgvEventContent.Size = new Size(302, 193);
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
            // panelLastEvent
            // 
            panelLastEvent.BackColor = SystemColors.ButtonHighlight;
            panelLastEvent.BorderStyle = BorderStyle.FixedSingle;
            panelLastEvent.Controls.Add(panel9);
            panelLastEvent.Controls.Add(label2);
            panelLastEvent.Dock = DockStyle.Left;
            panelLastEvent.Location = new Point(221, 0);
            panelLastEvent.Margin = new Padding(3, 2, 3, 2);
            panelLastEvent.Name = "panelLastEvent";
            panelLastEvent.Size = new Size(261, 150);
            panelLastEvent.TabIndex = 7;
            panelLastEvent.Visible = false;
            // 
            // panel9
            // 
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(0, 27);
            panel9.Margin = new Padding(3, 2, 3, 2);
            panel9.Name = "panel9";
            panel9.Size = new Size(259, 121);
            panel9.TabIndex = 8;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label2.ForeColor = Color.Navy;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(259, 27);
            label2.TabIndex = 7;
            label2.Text = "Các lượt xe vào gần đây";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ucEventCount1
            // 
            ucEventCount1.Dock = DockStyle.Left;
            ucEventCount1.Location = new Point(0, 0);
            ucEventCount1.Margin = new Padding(3, 2, 3, 2);
            ucEventCount1.Name = "ucEventCount1";
            ucEventCount1.Size = new Size(221, 150);
            ucEventCount1.TabIndex = 7;
            ucEventCount1.Visible = false;
            // 
            // picSetting
            // 
            picSetting.BackColor = Color.DarkGreen;
            picSetting.Dock = DockStyle.Right;
            picSetting.Image = (Image)resources.GetObject("picSetting.Image");
            picSetting.Location = new Point(865, 0);
            picSetting.Margin = new Padding(3, 2, 3, 2);
            picSetting.Name = "picSetting";
            picSetting.Size = new Size(46, 22);
            picSetting.SizeMode = PictureBoxSizeMode.Zoom;
            picSetting.TabIndex = 5;
            picSetting.TabStop = false;
            picSetting.Click += picSetting_Click;
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
            panel5.Size = new Size(961, 22);
            panel5.TabIndex = 6;
            // 
            // picRetakePhoto
            // 
            picRetakePhoto.BackColor = Color.DarkGreen;
            picRetakePhoto.Dock = DockStyle.Right;
            picRetakePhoto.Image = (Image)resources.GetObject("picRetakePhoto.Image");
            picRetakePhoto.Location = new Point(715, 0);
            picRetakePhoto.Margin = new Padding(3, 2, 3, 2);
            picRetakePhoto.Name = "picRetakePhoto";
            picRetakePhoto.Size = new Size(46, 22);
            picRetakePhoto.SizeMode = PictureBoxSizeMode.Zoom;
            picRetakePhoto.TabIndex = 15;
            picRetakePhoto.TabStop = false;
            picRetakePhoto.Click += BtnReTakePhoto_Click;
            // 
            // panel8
            // 
            panel8.BackColor = Color.DarkGreen;
            panel8.Dock = DockStyle.Right;
            panel8.Location = new Point(761, 0);
            panel8.Margin = new Padding(0);
            panel8.Name = "panel8";
            panel8.Size = new Size(4, 22);
            panel8.TabIndex = 14;
            // 
            // picWriteIn
            // 
            picWriteIn.BackColor = Color.DarkGreen;
            picWriteIn.Dock = DockStyle.Right;
            picWriteIn.Image = (Image)resources.GetObject("picWriteIn.Image");
            picWriteIn.Location = new Point(765, 0);
            picWriteIn.Margin = new Padding(3, 2, 3, 2);
            picWriteIn.Name = "picWriteIn";
            picWriteIn.Size = new Size(46, 22);
            picWriteIn.SizeMode = PictureBoxSizeMode.Zoom;
            picWriteIn.TabIndex = 13;
            picWriteIn.TabStop = false;
            picWriteIn.Click += BtnWriteIn_Click;
            // 
            // panel6
            // 
            panel6.BackColor = Color.DarkGreen;
            panel6.Dock = DockStyle.Right;
            panel6.Location = new Point(811, 0);
            panel6.Margin = new Padding(0);
            panel6.Name = "panel6";
            panel6.Size = new Size(4, 22);
            panel6.TabIndex = 12;
            // 
            // picOpenBarrie
            // 
            picOpenBarrie.BackColor = Color.DarkGreen;
            picOpenBarrie.Dock = DockStyle.Right;
            picOpenBarrie.Image = (Image)resources.GetObject("picOpenBarrie.Image");
            picOpenBarrie.Location = new Point(815, 0);
            picOpenBarrie.Margin = new Padding(3, 2, 3, 2);
            picOpenBarrie.Name = "picOpenBarrie";
            picOpenBarrie.Size = new Size(46, 22);
            picOpenBarrie.SizeMode = PictureBoxSizeMode.Zoom;
            picOpenBarrie.TabIndex = 11;
            picOpenBarrie.TabStop = false;
            picOpenBarrie.Click += btnOpenBarrie_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkGreen;
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(861, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(4, 22);
            panel1.TabIndex = 10;
            // 
            // panel7
            // 
            panel7.BackColor = Color.DarkGreen;
            panel7.Dock = DockStyle.Right;
            panel7.Location = new Point(911, 0);
            panel7.Margin = new Padding(0);
            panel7.Name = "panel7";
            panel7.Size = new Size(4, 22);
            panel7.TabIndex = 9;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.DarkGreen;
            pictureBox2.Dock = DockStyle.Right;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(915, 0);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(46, 22);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            pictureBox2.Visible = false;
            // 
            // splitterEventInfoWithCamera
            // 
            splitterEventInfoWithCamera.Dock = DockStyle.Right;
            splitterEventInfoWithCamera.Location = new Point(957, 22);
            splitterEventInfoWithCamera.Margin = new Padding(3, 2, 3, 2);
            splitterEventInfoWithCamera.Name = "splitterEventInfoWithCamera";
            splitterEventInfoWithCamera.Size = new Size(4, 534);
            splitterEventInfoWithCamera.TabIndex = 7;
            splitterEventInfoWithCamera.TabStop = false;
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
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitterEventInfoWithCamera);
            Controls.Add(splitContainerMain);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Margin = new Padding(0);
            Name = "ucLaneIn";
            Size = new Size(961, 556);
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
            splitContainerEventContent.Panel1.ResumeLayout(false);
            splitContainerEventContent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerEventContent).EndInit();
            splitContainerEventContent.ResumeLayout(false);
            panelDetectPlate.ResumeLayout(false);
            panelDetectPlate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLprImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEventContent).EndInit();
            panelLastEvent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picSetting).EndInit();
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picRetakePhoto).EndInit();
            ((System.ComponentModel.ISupportInitialize)picWriteIn).EndInit();
            ((System.ComponentModel.ISupportInitialize)picOpenBarrie).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
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
        private TableLayoutPanel tableLayoutPanel3;
        private Label label4;
        private Label label5;
    }
}
