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
            panelNote = new Panel();
            tableLayoutPanelNote = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            cbNote = new ComboBox();
            label4 = new Label();
            label5 = new Label();
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
            button1 = new Button();
            panelGoodsType = new Panel();
            cbGoodsType = new ComboBox();
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
            panelNote.SuspendLayout();
            tableLayoutPanelNote.SuspendLayout();
            groupBox1.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picRetakePhoto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picWriteOut).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picOpenBarrie).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picPrint).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSetting).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panelEventData.SuspendLayout();
            panelScaleAction.SuspendLayout();
            panelGoodsType.SuspendLayout();
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
            lblLaneName.Size = new Size(959, 30);
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
            panelCameras.Size = new Size(241, 380);
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
            splitContainerMain.Panel2.Controls.Add(panelLastEvent);
            splitContainerMain.Panel2.Controls.Add(ucEventCount1);
            splitContainerMain.Panel2.Controls.Add(lblResult);
            splitContainerMain.Size = new Size(1125, 543);
            splitContainerMain.SplitterDistance = 380;
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
            tableLayoutPanel1.Location = new Point(244, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(881, 380);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Control;
            panel3.Controls.Add(picVehicleImageIn);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(5, 215);
            panel3.Name = "panel3";
            panel3.Size = new Size(431, 160);
            panel3.TabIndex = 1;
            // 
            // picVehicleImageIn
            // 
            picVehicleImageIn.BackColor = Color.WhiteSmoke;
            picVehicleImageIn.Dock = DockStyle.Fill;
            picVehicleImageIn.Location = new Point(0, 0);
            picVehicleImageIn.Name = "picVehicleImageIn";
            picVehicleImageIn.Size = new Size(431, 160);
            picVehicleImageIn.SizeMode = PictureBoxSizeMode.StretchImage;
            picVehicleImageIn.TabIndex = 5;
            picVehicleImageIn.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(picVehicleImageOut);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(444, 215);
            panel2.Name = "panel2";
            panel2.Size = new Size(432, 160);
            panel2.TabIndex = 0;
            // 
            // picVehicleImageOut
            // 
            picVehicleImageOut.BackColor = Color.WhiteSmoke;
            picVehicleImageOut.Dock = DockStyle.Fill;
            picVehicleImageOut.Location = new Point(0, 0);
            picVehicleImageOut.Name = "picVehicleImageOut";
            picVehicleImageOut.Size = new Size(432, 160);
            picVehicleImageOut.SizeMode = PictureBoxSizeMode.StretchImage;
            picVehicleImageOut.TabIndex = 5;
            picVehicleImageOut.TabStop = false;
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.Control;
            panel6.Controls.Add(picOverviewImageOut);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(444, 48);
            panel6.Name = "panel6";
            panel6.Size = new Size(432, 159);
            panel6.TabIndex = 3;
            // 
            // picOverviewImageOut
            // 
            picOverviewImageOut.BackColor = Color.WhiteSmoke;
            picOverviewImageOut.Dock = DockStyle.Fill;
            picOverviewImageOut.Location = new Point(0, 0);
            picOverviewImageOut.Name = "picOverviewImageOut";
            picOverviewImageOut.Size = new Size(432, 159);
            picOverviewImageOut.SizeMode = PictureBoxSizeMode.StretchImage;
            picOverviewImageOut.TabIndex = 5;
            picOverviewImageOut.TabStop = false;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.Control;
            panel5.Controls.Add(picOverviewImageIn);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(5, 48);
            panel5.Name = "panel5";
            panel5.Size = new Size(431, 159);
            panel5.TabIndex = 2;
            // 
            // picOverviewImageIn
            // 
            picOverviewImageIn.BackColor = Color.WhiteSmoke;
            picOverviewImageIn.Dock = DockStyle.Fill;
            picOverviewImageIn.Location = new Point(0, 0);
            picOverviewImageIn.Name = "picOverviewImageIn";
            picOverviewImageIn.Size = new Size(431, 159);
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
            label1.Size = new Size(431, 41);
            label1.TabIndex = 4;
            label1.Text = "Ảnh Vào";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Underline);
            label2.ForeColor = Color.Maroon;
            label2.Location = new Point(444, 2);
            label2.Name = "label2";
            label2.Size = new Size(432, 41);
            label2.TabIndex = 5;
            label2.Text = "Ảnh Ra";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // splitterCamera
            // 
            splitterCamera.Location = new Point(241, 0);
            splitterCamera.Name = "splitterCamera";
            splitterCamera.Size = new Size(3, 380);
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
            panelLastEvent.Location = new Point(244, 34);
            panelLastEvent.Name = "panelLastEvent";
            panelLastEvent.Size = new Size(881, 125);
            panelLastEvent.TabIndex = 8;
            // 
            // panel11
            // 
            panel11.Dock = DockStyle.Fill;
            panel11.Location = new Point(0, 36);
            panel11.Name = "panel11";
            panel11.Size = new Size(879, 87);
            panel11.TabIndex = 8;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label3.ForeColor = Color.Navy;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(879, 36);
            label3.TabIndex = 7;
            label3.Text = "Các lượt xe vào gần đây";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ucEventCount1
            // 
            ucEventCount1.Dock = DockStyle.Left;
            ucEventCount1.Location = new Point(0, 34);
            ucEventCount1.Name = "ucEventCount1";
            ucEventCount1.Size = new Size(244, 125);
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
            lblResult.Size = new Size(1125, 34);
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
            splitContainerEventContent.Panel1.Controls.Add(tableLayoutPanel2);
            // 
            // splitContainerEventContent.Panel2
            // 
            splitContainerEventContent.Panel2.AutoScroll = true;
            splitContainerEventContent.Panel2.Controls.Add(dgvEventContent);
            splitContainerEventContent.Panel2.Controls.Add(panelNote);
            splitContainerEventContent.Size = new Size(352, 391);
            splitContainerEventContent.SplitterDistance = 130;
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
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(352, 130);
            tableLayoutPanel2.TabIndex = 5;
            // 
            // panel14
            // 
            panel14.Controls.Add(picLprImage);
            panel14.Controls.Add(txtPlate);
            panel14.Dock = DockStyle.Fill;
            panel14.Location = new Point(179, 3);
            panel14.Name = "panel14";
            panel14.Size = new Size(170, 124);
            panel14.TabIndex = 0;
            // 
            // picLprImage
            // 
            picLprImage.BackColor = Color.WhiteSmoke;
            picLprImage.Dock = DockStyle.Fill;
            picLprImage.Location = new Point(0, 32);
            picLprImage.Name = "picLprImage";
            picLprImage.Size = new Size(170, 92);
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
            txtPlate.Size = new Size(170, 32);
            txtPlate.TabIndex = 0;
            txtPlate.TextAlign = HorizontalAlignment.Center;
            // 
            // panel15
            // 
            panel15.Controls.Add(picLprImageIn);
            panel15.Controls.Add(lblPlateIn);
            panel15.Dock = DockStyle.Fill;
            panel15.Location = new Point(3, 3);
            panel15.Name = "panel15";
            panel15.Size = new Size(170, 124);
            panel15.TabIndex = 1;
            // 
            // picLprImageIn
            // 
            picLprImageIn.BackColor = Color.WhiteSmoke;
            picLprImageIn.Dock = DockStyle.Fill;
            picLprImageIn.Location = new Point(0, 32);
            picLprImageIn.Name = "picLprImageIn";
            picLprImageIn.Size = new Size(170, 92);
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
            lblPlateIn.Size = new Size(170, 32);
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
            dgvEventContent.Location = new Point(0, 155);
            dgvEventContent.Name = "dgvEventContent";
            dgvEventContent.ReadOnly = true;
            dgvEventContent.RowHeadersVisible = false;
            dgvEventContent.RowTemplate.Height = 29;
            dgvEventContent.Size = new Size(352, 102);
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
            // panelNote
            // 
            panelNote.Controls.Add(tableLayoutPanelNote);
            panelNote.Dock = DockStyle.Top;
            panelNote.Location = new Point(0, 0);
            panelNote.Name = "panelNote";
            panelNote.Size = new Size(352, 155);
            panelNote.TabIndex = 2;
            // 
            // tableLayoutPanelNote
            // 
            tableLayoutPanelNote.BackColor = Color.FromArgb(255, 128, 0);
            tableLayoutPanelNote.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanelNote.ColumnCount = 1;
            tableLayoutPanelNote.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelNote.Controls.Add(groupBox1, 0, 2);
            tableLayoutPanelNote.Controls.Add(label4, 0, 0);
            tableLayoutPanelNote.Controls.Add(label5, 0, 1);
            tableLayoutPanelNote.Dock = DockStyle.Fill;
            tableLayoutPanelNote.Location = new Point(0, 0);
            tableLayoutPanelNote.Name = "tableLayoutPanelNote";
            tableLayoutPanelNote.RowCount = 3;
            tableLayoutPanelNote.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelNote.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelNote.RowStyles.Add(new RowStyle(SizeType.Absolute, 74F));
            tableLayoutPanelNote.Size = new Size(352, 155);
            tableLayoutPanelNote.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbNote);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Segoe UI", 15.75F);
            groupBox1.Location = new Point(1, 79);
            groupBox1.Margin = new Padding(0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(350, 75);
            groupBox1.TabIndex = 2;
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
            cbNote.Size = new Size(344, 38);
            cbNote.TabIndex = 3;
            cbNote.SelectedIndexChanged += cbNote_SelectedIndexChanged;
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
            label5.Location = new Point(4, 40);
            label5.Name = "label5";
            label5.Size = new Size(209, 20);
            label5.TabIndex = 0;
            label5.Text = "GHI CHÚ DỊCH VỤ HẠ TẦNG";
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
            panel4.Size = new Size(1125, 30);
            panel4.TabIndex = 5;
            // 
            // picRetakePhoto
            // 
            picRetakePhoto.BackColor = Color.DarkRed;
            picRetakePhoto.Dock = DockStyle.Right;
            picRetakePhoto.Image = (Image)resources.GetObject("picRetakePhoto.Image");
            picRetakePhoto.Location = new Point(788, 0);
            picRetakePhoto.Name = "picRetakePhoto";
            picRetakePhoto.Size = new Size(52, 30);
            picRetakePhoto.SizeMode = PictureBoxSizeMode.Zoom;
            picRetakePhoto.TabIndex = 16;
            picRetakePhoto.TabStop = false;
            picRetakePhoto.Click += BtnReTakePhoto_Click;
            // 
            // panel10
            // 
            panel10.BackColor = Color.DarkRed;
            panel10.Dock = DockStyle.Right;
            panel10.Location = new Point(840, 0);
            panel10.Margin = new Padding(0);
            panel10.Name = "panel10";
            panel10.Size = new Size(5, 30);
            panel10.TabIndex = 15;
            // 
            // picWriteOut
            // 
            picWriteOut.BackColor = Color.DarkRed;
            picWriteOut.Dock = DockStyle.Right;
            picWriteOut.Image = (Image)resources.GetObject("picWriteOut.Image");
            picWriteOut.Location = new Point(845, 0);
            picWriteOut.Name = "picWriteOut";
            picWriteOut.Size = new Size(52, 30);
            picWriteOut.SizeMode = PictureBoxSizeMode.Zoom;
            picWriteOut.TabIndex = 14;
            picWriteOut.TabStop = false;
            picWriteOut.Click += BtnWriteOut_Click;
            // 
            // panel8
            // 
            panel8.BackColor = Color.DarkRed;
            panel8.Dock = DockStyle.Right;
            panel8.Location = new Point(897, 0);
            panel8.Margin = new Padding(0);
            panel8.Name = "panel8";
            panel8.Size = new Size(5, 30);
            panel8.TabIndex = 11;
            // 
            // picOpenBarrie
            // 
            picOpenBarrie.BackColor = Color.DarkRed;
            picOpenBarrie.Dock = DockStyle.Right;
            picOpenBarrie.Image = (Image)resources.GetObject("picOpenBarrie.Image");
            picOpenBarrie.Location = new Point(902, 0);
            picOpenBarrie.Name = "picOpenBarrie";
            picOpenBarrie.Size = new Size(52, 30);
            picOpenBarrie.SizeMode = PictureBoxSizeMode.Zoom;
            picOpenBarrie.TabIndex = 10;
            picOpenBarrie.TabStop = false;
            picOpenBarrie.Click += btnOpenBarrie_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkRed;
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(954, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(5, 30);
            panel1.TabIndex = 9;
            // 
            // picPrint
            // 
            picPrint.BackColor = Color.DarkRed;
            picPrint.Dock = DockStyle.Right;
            picPrint.Image = (Image)resources.GetObject("picPrint.Image");
            picPrint.Location = new Point(959, 0);
            picPrint.Name = "picPrint";
            picPrint.Size = new Size(52, 30);
            picPrint.SizeMode = PictureBoxSizeMode.Zoom;
            picPrint.TabIndex = 18;
            picPrint.TabStop = false;
            // 
            // panel9
            // 
            panel9.BackColor = Color.DarkRed;
            panel9.Dock = DockStyle.Right;
            panel9.Location = new Point(1011, 0);
            panel9.Margin = new Padding(0);
            panel9.Name = "panel9";
            panel9.Size = new Size(5, 30);
            panel9.TabIndex = 17;
            // 
            // picSetting
            // 
            picSetting.BackColor = Color.DarkRed;
            picSetting.Dock = DockStyle.Right;
            picSetting.Image = (Image)resources.GetObject("picSetting.Image");
            picSetting.Location = new Point(1016, 0);
            picSetting.Name = "picSetting";
            picSetting.Size = new Size(52, 30);
            picSetting.SizeMode = PictureBoxSizeMode.Zoom;
            picSetting.TabIndex = 6;
            picSetting.TabStop = false;
            picSetting.Click += picSetting_Click;
            picSetting.MouseEnter += picSetting_MouseEnter;
            picSetting.MouseLeave += picSetting_MouseLeave;
            // 
            // panel7
            // 
            panel7.BackColor = Color.DarkRed;
            panel7.Dock = DockStyle.Right;
            panel7.Location = new Point(1068, 0);
            panel7.Margin = new Padding(0);
            panel7.Name = "panel7";
            panel7.Size = new Size(5, 30);
            panel7.TabIndex = 8;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.DarkRed;
            pictureBox2.Dock = DockStyle.Right;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(1073, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(52, 30);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            pictureBox2.Visible = false;
            // 
            // splitterEventInfoWithCamera
            // 
            splitterEventInfoWithCamera.Dock = DockStyle.Right;
            splitterEventInfoWithCamera.Location = new Point(768, 30);
            splitterEventInfoWithCamera.Name = "splitterEventInfoWithCamera";
            splitterEventInfoWithCamera.Size = new Size(5, 543);
            splitterEventInfoWithCamera.TabIndex = 6;
            splitterEventInfoWithCamera.TabStop = false;
            // 
            // panelEventData
            // 
            panelEventData.Controls.Add(splitContainerEventContent);
            panelEventData.Controls.Add(panelScaleAction);
            panelEventData.Controls.Add(panelGoodsType);
            panelEventData.Dock = DockStyle.Right;
            panelEventData.Location = new Point(773, 30);
            panelEventData.Name = "panelEventData";
            panelEventData.Size = new Size(352, 543);
            panelEventData.TabIndex = 7;
            // 
            // panelScaleAction
            // 
            panelScaleAction.Controls.Add(btnOpenBarrie);
            panelScaleAction.Controls.Add(button2);
            panelScaleAction.Controls.Add(button1);
            panelScaleAction.Dock = DockStyle.Bottom;
            panelScaleAction.Location = new Point(0, 441);
            panelScaleAction.Name = "panelScaleAction";
            panelScaleAction.Size = new Size(352, 102);
            panelScaleAction.TabIndex = 1;
            // 
            // btnOpenBarrie
            // 
            btnOpenBarrie.Image = (Image)resources.GetObject("btnOpenBarrie.Image");
            btnOpenBarrie.ImageAlign = ContentAlignment.BottomCenter;
            btnOpenBarrie.Location = new Point(234, 15);
            btnOpenBarrie.Name = "btnOpenBarrie";
            btnOpenBarrie.Size = new Size(108, 84);
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
            button2.Location = new Point(120, 15);
            button2.Name = "button2";
            button2.Size = new Size(108, 83);
            button2.TabIndex = 1;
            button2.Text = "In vé xe";
            button2.TextImageRelation = TextImageRelation.ImageAboveText;
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnPrintTicket_Click;
            // 
            // button1
            // 
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.BottomCenter;
            button1.Location = new Point(6, 16);
            button1.Name = "button1";
            button1.Size = new Size(108, 84);
            button1.TabIndex = 2;
            button1.Text = "In phiếu cân";
            button1.TextImageRelation = TextImageRelation.ImageAboveText;
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnPrintScale_Click;
            // 
            // panelGoodsType
            // 
            panelGoodsType.Controls.Add(cbGoodsType);
            panelGoodsType.Dock = DockStyle.Top;
            panelGoodsType.Location = new Point(0, 0);
            panelGoodsType.Name = "panelGoodsType";
            panelGoodsType.Padding = new Padding(0, 5, 0, 5);
            panelGoodsType.Size = new Size(352, 50);
            panelGoodsType.TabIndex = 4;
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
            cbGoodsType.Size = new Size(352, 38);
            cbGoodsType.TabIndex = 2;
            // 
            // ucLaneOut
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitterEventInfoWithCamera);
            Controls.Add(panelEventData);
            Controls.Add(splitContainerMain);
            Controls.Add(panel4);
            Margin = new Padding(0);
            Name = "ucLaneOut";
            Size = new Size(1125, 573);
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
            panelNote.ResumeLayout(false);
            tableLayoutPanelNote.ResumeLayout(false);
            tableLayoutPanelNote.PerformLayout();
            groupBox1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picRetakePhoto).EndInit();
            ((System.ComponentModel.ISupportInitialize)picWriteOut).EndInit();
            ((System.ComponentModel.ISupportInitialize)picOpenBarrie).EndInit();
            ((System.ComponentModel.ISupportInitialize)picPrint).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSetting).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panelEventData.ResumeLayout(false);
            panelScaleAction.ResumeLayout(false);
            panelGoodsType.ResumeLayout(false);
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
        private Button button1;
        private Panel panelGoodsType;
        private ComboBox cbGoodsType;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel14;
        private Panel panel15;
        private MovablePictureBox picLprImageIn;
        private Label lblPlateIn;
        private Panel panelNote;
        private TableLayoutPanel tableLayoutPanelNote;
        private Label label4;
        private Label label5;
        private GroupBox groupBox1;
        private ComboBox cbNote;
        private ToolTip toolTipPrint;
    }
}
