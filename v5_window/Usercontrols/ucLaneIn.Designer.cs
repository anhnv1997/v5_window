using iPakrkingv5.Controls.Usercontrols;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLaneIn));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            lblLaneName = new Label();
            panelCameras = new Panel();
            label15 = new Label();
            splitContainerMain = new SplitContainer();
            tableCamera = new TableLayoutPanel();
            tablePic = new TableLayoutPanel();
            picVehicleImage = new MovablePictureBox();
            panel3 = new Panel();
            picOverviewImage = new MovablePictureBox();
            label1 = new Label();
            splitterCamera = new Splitter();
            panelAllCameras = new Panel();
            splitContainerCamera = new SplitContainer();
            panelLastEvent = new Panel();
            panelNearestEvent = new Panel();
            panelThirdParty = new TableLayoutPanel();
            btnRegister = new Button();
            btnPrintQR = new Button();
            label2 = new Label();
            lblResult = new iPakrkingv5.Controls.Controls.Labels.lblResult();
            panelDisplayLastEvent = new Panel();
            splitContainerLastEvent = new SplitContainer();
            ucEventCount1 = new ucEventCount();
            splitContainerEventContent = new SplitContainer();
            panelLpr = new Panel();
            panel10 = new Panel();
            picLprImage = new MovablePictureBox();
            label27 = new Label();
            panelDetectPlate = new Panel();
            txtPlate = new TextBox();
            label25 = new Label();
            panelEventInfo = new Panel();
            dgvEventContent = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
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
            toolTipOpenBarrie = new ToolTip(components);
            toolTipReTakePhoto = new ToolTip(components);
            toolTipWriteIn = new ToolTip(components);
            splitterEventInfoWithCamera = new Splitter();
            panelEventData = new Panel();
            tableLayoutPanel3 = new TableLayoutPanel();
            label4 = new Label();
            label5 = new Label();
            timerRefreshUI = new System.Windows.Forms.Timer(components);
            toolTipSetting = new ToolTip(components);
            panelCameras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            tableCamera.SuspendLayout();
            tablePic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picVehicleImage).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picOverviewImage).BeginInit();
            panelAllCameras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerCamera).BeginInit();
            splitContainerCamera.Panel1.SuspendLayout();
            splitContainerCamera.SuspendLayout();
            panelLastEvent.SuspendLayout();
            panelNearestEvent.SuspendLayout();
            panelThirdParty.SuspendLayout();
            panelDisplayLastEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerLastEvent).BeginInit();
            splitContainerLastEvent.Panel1.SuspendLayout();
            splitContainerLastEvent.Panel2.SuspendLayout();
            splitContainerLastEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerEventContent).BeginInit();
            splitContainerEventContent.Panel1.SuspendLayout();
            splitContainerEventContent.Panel2.SuspendLayout();
            splitContainerEventContent.SuspendLayout();
            panelLpr.SuspendLayout();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLprImage).BeginInit();
            panelDetectPlate.SuspendLayout();
            panelEventInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEventContent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSetting).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picRetakePhoto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picWriteIn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picOpenBarrie).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panelEventData.SuspendLayout();
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
            lblLaneName.Size = new Size(1242, 22);
            lblLaneName.TabIndex = 0;
            lblLaneName.Text = "label1";
            lblLaneName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelCameras
            // 
            panelCameras.BackColor = Color.White;
            panelCameras.Controls.Add(label15);
            panelCameras.Dock = DockStyle.Fill;
            panelCameras.Location = new Point(0, 0);
            panelCameras.Margin = new Padding(0);
            panelCameras.Name = "panelCameras";
            panelCameras.Size = new Size(316, 303);
            panelCameras.TabIndex = 3;
            // 
            // label15
            // 
            label15.Dock = DockStyle.Top;
            label15.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Underline);
            label15.ForeColor = Color.Green;
            label15.Location = new Point(0, 0);
            label15.Name = "label15";
            label15.Size = new Size(316, 37);
            label15.TabIndex = 3;
            label15.Text = "CAM LỐI VÀO";
            label15.TextAlign = ContentAlignment.MiddleCenter;
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
            splitContainerMain.Panel1.Controls.Add(tableCamera);
            splitContainerMain.Panel1.Controls.Add(label1);
            splitContainerMain.Panel1.Controls.Add(splitterCamera);
            splitContainerMain.Panel1.Controls.Add(panelAllCameras);
            splitContainerMain.Panel1.Controls.Add(lblResult);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(panelDisplayLastEvent);
            splitContainerMain.Size = new Size(869, 721);
            splitContainerMain.SplitterDistance = 440;
            splitContainerMain.SplitterWidth = 2;
            splitContainerMain.TabIndex = 4;
            // 
            // tableCamera
            // 
            tableCamera.ColumnCount = 1;
            tableCamera.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableCamera.Controls.Add(tablePic, 0, 0);
            tableCamera.Dock = DockStyle.Fill;
            tableCamera.Location = new Point(318, 37);
            tableCamera.Margin = new Padding(0);
            tableCamera.Name = "tableCamera";
            tableCamera.RowCount = 1;
            tableCamera.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableCamera.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableCamera.Size = new Size(551, 359);
            tableCamera.TabIndex = 5;
            // 
            // tablePic
            // 
            tablePic.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tablePic.ColumnCount = 1;
            tablePic.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tablePic.Controls.Add(picVehicleImage, 0, 1);
            tablePic.Controls.Add(panel3, 0, 0);
            tablePic.Dock = DockStyle.Fill;
            tablePic.Location = new Point(0, 0);
            tablePic.Margin = new Padding(0);
            tablePic.Name = "tablePic";
            tablePic.RowCount = 2;
            tablePic.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tablePic.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tablePic.Size = new Size(551, 359);
            tablePic.TabIndex = 3;
            // 
            // picVehicleImage
            // 
            picVehicleImage.BackColor = Color.WhiteSmoke;
            picVehicleImage.Dock = DockStyle.Fill;
            picVehicleImage.ErrorImage = null;
            picVehicleImage.Image = (Image)resources.GetObject("picVehicleImage.Image");
            picVehicleImage.Location = new Point(1, 180);
            picVehicleImage.Margin = new Padding(0);
            picVehicleImage.Name = "picVehicleImage";
            picVehicleImage.Size = new Size(549, 178);
            picVehicleImage.SizeMode = PictureBoxSizeMode.StretchImage;
            picVehicleImage.TabIndex = 5;
            picVehicleImage.TabStop = false;
            picVehicleImage.LoadCompleted += Pic_LoadCompleted;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Control;
            panel3.Controls.Add(picOverviewImage);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(1, 1);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new Size(549, 178);
            panel3.TabIndex = 1;
            // 
            // picOverviewImage
            // 
            picOverviewImage.BackColor = Color.WhiteSmoke;
            picOverviewImage.Dock = DockStyle.Fill;
            picOverviewImage.ErrorImage = null;
            picOverviewImage.Image = (Image)resources.GetObject("picOverviewImage.Image");
            picOverviewImage.Location = new Point(0, 0);
            picOverviewImage.Margin = new Padding(0);
            picOverviewImage.Name = "picOverviewImage";
            picOverviewImage.Size = new Size(549, 178);
            picOverviewImage.SizeMode = PictureBoxSizeMode.StretchImage;
            picOverviewImage.TabIndex = 5;
            picOverviewImage.TabStop = false;
            picOverviewImage.LoadCompleted += Pic_LoadCompleted;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Underline);
            label1.ForeColor = Color.Green;
            label1.Location = new Point(318, 0);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(551, 37);
            label1.TabIndex = 2;
            label1.Text = "ẢNH VÀO";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // splitterCamera
            // 
            splitterCamera.BackColor = SystemColors.ButtonHighlight;
            splitterCamera.Location = new Point(316, 0);
            splitterCamera.Margin = new Padding(3, 2, 3, 2);
            splitterCamera.Name = "splitterCamera";
            splitterCamera.Size = new Size(2, 396);
            splitterCamera.TabIndex = 4;
            splitterCamera.TabStop = false;
            // 
            // panelAllCameras
            // 
            panelAllCameras.BackColor = Color.White;
            panelAllCameras.Controls.Add(splitContainerCamera);
            panelAllCameras.Dock = DockStyle.Left;
            panelAllCameras.Location = new Point(0, 0);
            panelAllCameras.Name = "panelAllCameras";
            panelAllCameras.Size = new Size(316, 396);
            panelAllCameras.TabIndex = 7;
            // 
            // splitContainerCamera
            // 
            splitContainerCamera.Dock = DockStyle.Fill;
            splitContainerCamera.Location = new Point(0, 0);
            splitContainerCamera.Name = "splitContainerCamera";
            splitContainerCamera.Orientation = Orientation.Horizontal;
            // 
            // splitContainerCamera.Panel1
            // 
            splitContainerCamera.Panel1.Controls.Add(panelCameras);
            splitContainerCamera.Panel2MinSize = 0;
            splitContainerCamera.Size = new Size(316, 396);
            splitContainerCamera.SplitterDistance = 303;
            splitContainerCamera.SplitterWidth = 2;
            splitContainerCamera.TabIndex = 0;
            // 
            // panelLastEvent
            // 
            panelLastEvent.BackColor = SystemColors.ButtonHighlight;
            panelLastEvent.BorderStyle = BorderStyle.FixedSingle;
            panelLastEvent.Controls.Add(panelNearestEvent);
            panelLastEvent.Controls.Add(label2);
            panelLastEvent.Dock = DockStyle.Fill;
            panelLastEvent.Location = new Point(0, 0);
            panelLastEvent.Margin = new Padding(3, 2, 3, 2);
            panelLastEvent.Name = "panelLastEvent";
            panelLastEvent.Size = new Size(418, 279);
            panelLastEvent.TabIndex = 7;
            // 
            // panelNearestEvent
            // 
            panelNearestEvent.Controls.Add(panelThirdParty);
            panelNearestEvent.Dock = DockStyle.Fill;
            panelNearestEvent.Location = new Point(0, 27);
            panelNearestEvent.Margin = new Padding(0);
            panelNearestEvent.Name = "panelNearestEvent";
            panelNearestEvent.Size = new Size(416, 250);
            panelNearestEvent.TabIndex = 8;
            // 
            // panelThirdParty
            // 
            panelThirdParty.ColumnCount = 1;
            panelThirdParty.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            panelThirdParty.Controls.Add(btnRegister, 0, 0);
            panelThirdParty.Controls.Add(btnPrintQR, 0, 1);
            panelThirdParty.Dock = DockStyle.Right;
            panelThirdParty.Location = new Point(216, 0);
            panelThirdParty.Name = "panelThirdParty";
            panelThirdParty.RowCount = 2;
            panelThirdParty.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            panelThirdParty.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            panelThirdParty.Size = new Size(200, 250);
            panelThirdParty.TabIndex = 0;
            // 
            // btnRegister
            // 
            btnRegister.Dock = DockStyle.Fill;
            btnRegister.Location = new Point(3, 3);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(194, 119);
            btnRegister.TabIndex = 0;
            btnRegister.Text = "Đăng ký";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnPrintQR
            // 
            btnPrintQR.Dock = DockStyle.Fill;
            btnPrintQR.Location = new Point(3, 128);
            btnPrintQR.Name = "btnPrintQR";
            btnPrintQR.Size = new Size(194, 119);
            btnPrintQR.TabIndex = 0;
            btnPrintQR.Text = "In QR";
            btnPrintQR.UseVisualStyleBackColor = true;
            btnPrintQR.Click += btnPrintQR_Click;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label2.ForeColor = Color.Navy;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(416, 27);
            label2.TabIndex = 7;
            label2.Text = "Các lượt xe vào gần đây";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblResult
            // 
            lblResult.BackColor = Color.FromArgb(0, 64, 0);
            lblResult.Dock = DockStyle.Bottom;
            lblResult.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblResult.ForeColor = SystemColors.ButtonHighlight;
            lblResult.Location = new Point(0, 396);
            lblResult.Margin = new Padding(0);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(869, 44);
            lblResult.TabIndex = 1;
            lblResult.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelDisplayLastEvent
            // 
            panelDisplayLastEvent.Controls.Add(splitContainerLastEvent);
            panelDisplayLastEvent.Dock = DockStyle.Fill;
            panelDisplayLastEvent.Font = new Font("Segoe UI", 13F);
            panelDisplayLastEvent.Location = new Point(0, 0);
            panelDisplayLastEvent.Margin = new Padding(0);
            panelDisplayLastEvent.Name = "panelDisplayLastEvent";
            panelDisplayLastEvent.Size = new Size(869, 279);
            panelDisplayLastEvent.TabIndex = 2;
            // 
            // splitContainerLastEvent
            // 
            splitContainerLastEvent.BackColor = SystemColors.ButtonHighlight;
            splitContainerLastEvent.Dock = DockStyle.Fill;
            splitContainerLastEvent.Location = new Point(0, 0);
            splitContainerLastEvent.Margin = new Padding(0);
            splitContainerLastEvent.Name = "splitContainerLastEvent";
            // 
            // splitContainerLastEvent.Panel1
            // 
            splitContainerLastEvent.Panel1.Controls.Add(ucEventCount1);
            // 
            // splitContainerLastEvent.Panel2
            // 
            splitContainerLastEvent.Panel2.Controls.Add(panelLastEvent);
            splitContainerLastEvent.Size = new Size(869, 279);
            splitContainerLastEvent.SplitterDistance = 447;
            splitContainerLastEvent.TabIndex = 8;
            // 
            // ucEventCount1
            // 
            ucEventCount1.BorderStyle = BorderStyle.FixedSingle;
            ucEventCount1.Dock = DockStyle.Fill;
            ucEventCount1.Font = new Font("Segoe UI", 12F);
            ucEventCount1.Location = new Point(0, 0);
            ucEventCount1.Margin = new Padding(3, 2, 3, 2);
            ucEventCount1.Name = "ucEventCount1";
            ucEventCount1.Size = new Size(447, 279);
            ucEventCount1.TabIndex = 7;
            // 
            // splitContainerEventContent
            // 
            splitContainerEventContent.BorderStyle = BorderStyle.FixedSingle;
            splitContainerEventContent.Dock = DockStyle.Fill;
            splitContainerEventContent.Location = new Point(0, 0);
            splitContainerEventContent.Margin = new Padding(0);
            splitContainerEventContent.Name = "splitContainerEventContent";
            splitContainerEventContent.Orientation = Orientation.Horizontal;
            // 
            // splitContainerEventContent.Panel1
            // 
            splitContainerEventContent.Panel1.Controls.Add(panelLpr);
            // 
            // splitContainerEventContent.Panel2
            // 
            splitContainerEventContent.Panel2.Controls.Add(panelEventInfo);
            splitContainerEventContent.Size = new Size(469, 721);
            splitContainerEventContent.SplitterDistance = 350;
            splitContainerEventContent.SplitterWidth = 2;
            splitContainerEventContent.TabIndex = 0;
            // 
            // panelLpr
            // 
            panelLpr.Controls.Add(panel10);
            panelLpr.Controls.Add(panelDetectPlate);
            panelLpr.Dock = DockStyle.Fill;
            panelLpr.Location = new Point(0, 0);
            panelLpr.Name = "panelLpr";
            panelLpr.Size = new Size(467, 348);
            panelLpr.TabIndex = 5;
            // 
            // panel10
            // 
            panel10.Controls.Add(picLprImage);
            panel10.Controls.Add(label27);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(0, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(467, 252);
            panel10.TabIndex = 0;
            // 
            // picLprImage
            // 
            picLprImage.BackColor = Color.WhiteSmoke;
            picLprImage.Dock = DockStyle.Fill;
            picLprImage.Image = (Image)resources.GetObject("picLprImage.Image");
            picLprImage.Location = new Point(0, 21);
            picLprImage.Margin = new Padding(3, 2, 3, 2);
            picLprImage.Name = "picLprImage";
            picLprImage.Size = new Size(467, 231);
            picLprImage.SizeMode = PictureBoxSizeMode.StretchImage;
            picLprImage.TabIndex = 4;
            picLprImage.TabStop = false;
            picLprImage.LoadCompleted += Pic_LoadCompleted;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Dock = DockStyle.Top;
            label27.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label27.ForeColor = Color.Navy;
            label27.Location = new Point(0, 0);
            label27.Name = "label27";
            label27.Size = new Size(149, 21);
            label27.TabIndex = 5;
            label27.Text = "ẢNH BIỂN SỐ VÀO";
            // 
            // panelDetectPlate
            // 
            panelDetectPlate.Controls.Add(txtPlate);
            panelDetectPlate.Controls.Add(label25);
            panelDetectPlate.Dock = DockStyle.Bottom;
            panelDetectPlate.Location = new Point(0, 252);
            panelDetectPlate.Margin = new Padding(0);
            panelDetectPlate.Name = "panelDetectPlate";
            panelDetectPlate.Size = new Size(467, 96);
            panelDetectPlate.TabIndex = 4;
            // 
            // txtPlate
            // 
            txtPlate.BackColor = SystemColors.ButtonHighlight;
            txtPlate.BorderStyle = BorderStyle.None;
            txtPlate.Dock = DockStyle.Bottom;
            txtPlate.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            txtPlate.ForeColor = Color.Black;
            txtPlate.Location = new Point(0, 32);
            txtPlate.Margin = new Padding(0);
            txtPlate.Name = "txtPlate";
            txtPlate.Size = new Size(467, 64);
            txtPlate.TabIndex = 0;
            txtPlate.TextAlign = HorizontalAlignment.Center;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Dock = DockStyle.Top;
            label25.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label25.ForeColor = Color.Navy;
            label25.Location = new Point(0, 0);
            label25.Name = "label25";
            label25.Size = new Size(132, 21);
            label25.TabIndex = 4;
            label25.Text = "BIỂN SỐ XE VÀO";
            // 
            // panelEventInfo
            // 
            panelEventInfo.Controls.Add(dgvEventContent);
            panelEventInfo.Dock = DockStyle.Fill;
            panelEventInfo.Location = new Point(0, 0);
            panelEventInfo.Name = "panelEventInfo";
            panelEventInfo.Size = new Size(467, 367);
            panelEventInfo.TabIndex = 4;
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
            dgvEventContent.Size = new Size(467, 367);
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
            // picSetting
            // 
            picSetting.BackColor = Color.DarkGreen;
            picSetting.Dock = DockStyle.Right;
            picSetting.Image = (Image)resources.GetObject("picSetting.Image");
            picSetting.Location = new Point(1242, 0);
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
            panel5.Size = new Size(1338, 22);
            panel5.TabIndex = 6;
            // 
            // picRetakePhoto
            // 
            picRetakePhoto.BackColor = Color.DarkGreen;
            picRetakePhoto.Dock = DockStyle.Right;
            picRetakePhoto.Image = (Image)resources.GetObject("picRetakePhoto.Image");
            picRetakePhoto.Location = new Point(1092, 0);
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
            panel8.Location = new Point(1138, 0);
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
            picWriteIn.Location = new Point(1142, 0);
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
            panel6.Location = new Point(1188, 0);
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
            picOpenBarrie.Location = new Point(1192, 0);
            picOpenBarrie.Margin = new Padding(3, 2, 3, 2);
            picOpenBarrie.Name = "picOpenBarrie";
            picOpenBarrie.Size = new Size(46, 22);
            picOpenBarrie.SizeMode = PictureBoxSizeMode.Zoom;
            picOpenBarrie.TabIndex = 11;
            picOpenBarrie.TabStop = false;
            picOpenBarrie.Click += BtnOpenBarrie_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkGreen;
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(1238, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(4, 22);
            panel1.TabIndex = 10;
            // 
            // panel7
            // 
            panel7.BackColor = Color.DarkGreen;
            panel7.Dock = DockStyle.Right;
            panel7.Location = new Point(1288, 0);
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
            pictureBox2.Location = new Point(1292, 0);
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
            splitterEventInfoWithCamera.BackColor = SystemColors.ButtonHighlight;
            splitterEventInfoWithCamera.Dock = DockStyle.Right;
            splitterEventInfoWithCamera.Location = new Point(866, 22);
            splitterEventInfoWithCamera.Margin = new Padding(3, 2, 3, 2);
            splitterEventInfoWithCamera.Name = "splitterEventInfoWithCamera";
            splitterEventInfoWithCamera.Size = new Size(3, 721);
            splitterEventInfoWithCamera.TabIndex = 7;
            splitterEventInfoWithCamera.TabStop = false;
            // 
            // panelEventData
            // 
            panelEventData.Controls.Add(splitContainerEventContent);
            panelEventData.Dock = DockStyle.Right;
            panelEventData.Location = new Point(869, 22);
            panelEventData.Margin = new Padding(0);
            panelEventData.Name = "panelEventData";
            panelEventData.Size = new Size(469, 721);
            panelEventData.TabIndex = 8;
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
            // timerRefreshUI
            // 
            timerRefreshUI.Interval = 1000;
            timerRefreshUI.Tick += timerRefreshUI_Tick;
            // 
            // ucLaneIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            Controls.Add(splitterEventInfoWithCamera);
            Controls.Add(splitContainerMain);
            Controls.Add(panelEventData);
            Controls.Add(panel5);
            Margin = new Padding(0);
            Name = "ucLaneIn";
            Size = new Size(1338, 743);
            panelCameras.ResumeLayout(false);
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            tableCamera.ResumeLayout(false);
            tablePic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picVehicleImage).EndInit();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picOverviewImage).EndInit();
            panelAllCameras.ResumeLayout(false);
            splitContainerCamera.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerCamera).EndInit();
            splitContainerCamera.ResumeLayout(false);
            panelLastEvent.ResumeLayout(false);
            panelNearestEvent.ResumeLayout(false);
            panelThirdParty.ResumeLayout(false);
            panelDisplayLastEvent.ResumeLayout(false);
            splitContainerLastEvent.Panel1.ResumeLayout(false);
            splitContainerLastEvent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerLastEvent).EndInit();
            splitContainerLastEvent.ResumeLayout(false);
            splitContainerEventContent.Panel1.ResumeLayout(false);
            splitContainerEventContent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerEventContent).EndInit();
            splitContainerEventContent.ResumeLayout(false);
            panelLpr.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLprImage).EndInit();
            panelDetectPlate.ResumeLayout(false);
            panelDetectPlate.PerformLayout();
            panelEventInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEventContent).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSetting).EndInit();
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picRetakePhoto).EndInit();
            ((System.ComponentModel.ISupportInitialize)picWriteIn).EndInit();
            ((System.ComponentModel.ISupportInitialize)picOpenBarrie).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panelEventData.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblLaneName;
        private Panel panelCameras;
        private SplitContainer splitContainerMain;
        private TableLayoutPanel tableCamera;
        private Splitter splitterCamera;
        private SplitContainer splitContainerEventContent;
        private Panel panelAction;
        private TextBox txtPlate;
        private DataGridView dgvEventContent;
        private iPakrkingv5.Controls.Controls.Labels.lblResult lblResult;
        private MovablePictureBox picLprImage;
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
        private ToolTip toolTipOpenBarrie;
        private ToolTip toolTipReTakePhoto;
        private ToolTip toolTipWriteIn;
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
        private TableLayoutPanel tablePic;
        private Splitter splitterEventInfoWithCamera;
        private ucEventCount ucEventCount1;
        private Panel panelDisplayLastEvent;
        private Label label2;
        private Panel panelNearestEvent;
        private Panel panelEventData;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label4;
        private Label label5;
        private Label label15;
        private Label label25;
        private Panel panel10;
        private Label label27;
        private Panel panelAllCameras;
        private Panel panelLpr;
        private Panel panelEventInfo;
        private SplitContainer splitContainerCamera;
        private System.Windows.Forms.Timer timerRefreshUI;
        private SplitContainer splitContainerLastEvent;
        private ToolTip toolTipSetting;
        private TableLayoutPanel panelThirdParty;
        private Button btnRegister;
        private Button btnPrintQR;
    }
}
