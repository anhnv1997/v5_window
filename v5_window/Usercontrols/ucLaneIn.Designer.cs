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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLaneIn));
            lblLaneName = new Label();
            panelCameras = new Panel();
            splitContainerMain = new SplitContainer();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel3 = new Panel();
            picVehicleImage = new MovablePictureBox();
            panel2 = new Panel();
            picOverviewImage = new MovablePictureBox();
            label1 = new Label();
            splitterCamera = new Splitter();
            splitContainerEventContent = new SplitContainer();
            dgvEventContent = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            panel4 = new Panel();
            picLprImage = new MovablePictureBox();
            panelAction = new Panel();
            btnWriteIn = new Button();
            btnOpenBarrie = new Button();
            btnReTakePhoto = new Button();
            txtPlate = new TextBox();
            lblResult = new iPakrkingv5.Controls.Controls.Labels.lblResult();
            picSetting = new PictureBox();
            panel5 = new Panel();
            panel7 = new Panel();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picVehicleImage).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picOverviewImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerEventContent).BeginInit();
            splitContainerEventContent.Panel1.SuspendLayout();
            splitContainerEventContent.Panel2.SuspendLayout();
            splitContainerEventContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEventContent).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLprImage).BeginInit();
            panelAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picSetting).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
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
            lblLaneName.Size = new Size(602, 30);
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
            panelCameras.Size = new Size(241, 454);
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
            splitContainerMain.Panel2.Controls.Add(splitContainerEventContent);
            splitContainerMain.Panel2.Controls.Add(lblResult);
            splitContainerMain.Size = new Size(727, 648);
            splitContainerMain.SplitterDistance = 454;
            splitContainerMain.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel3, 0, 1);
            tableLayoutPanel1.Controls.Add(panel2, 0, 2);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(244, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(483, 454);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Control;
            panel3.Controls.Add(picVehicleImage);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(5, 37);
            panel3.Name = "panel3";
            panel3.Size = new Size(473, 202);
            panel3.TabIndex = 1;
            // 
            // picVehicleImage
            // 
            picVehicleImage.BackColor = Color.WhiteSmoke;
            picVehicleImage.Dock = DockStyle.Fill;
            picVehicleImage.Image = (Image)resources.GetObject("picVehicleImage.Image");
            picVehicleImage.Location = new Point(0, 0);
            picVehicleImage.Name = "picVehicleImage";
            picVehicleImage.Size = new Size(473, 202);
            picVehicleImage.SizeMode = PictureBoxSizeMode.Zoom;
            picVehicleImage.TabIndex = 5;
            picVehicleImage.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(picOverviewImage);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(5, 247);
            panel2.Name = "panel2";
            panel2.Size = new Size(473, 202);
            panel2.TabIndex = 0;
            // 
            // picOverviewImage
            // 
            picOverviewImage.BackColor = Color.WhiteSmoke;
            picOverviewImage.Dock = DockStyle.Fill;
            picOverviewImage.Image = (Image)resources.GetObject("picOverviewImage.Image");
            picOverviewImage.Location = new Point(0, 0);
            picOverviewImage.Name = "picOverviewImage";
            picOverviewImage.Size = new Size(473, 202);
            picOverviewImage.SizeMode = PictureBoxSizeMode.Zoom;
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
            label1.Size = new Size(473, 30);
            label1.TabIndex = 2;
            label1.Text = "Ảnh Vào";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // splitterCamera
            // 
            splitterCamera.Location = new Point(241, 0);
            splitterCamera.Name = "splitterCamera";
            splitterCamera.Size = new Size(3, 454);
            splitterCamera.TabIndex = 4;
            splitterCamera.TabStop = false;
            // 
            // splitContainerEventContent
            // 
            splitContainerEventContent.Dock = DockStyle.Fill;
            splitContainerEventContent.Location = new Point(0, 34);
            splitContainerEventContent.Name = "splitContainerEventContent";
            // 
            // splitContainerEventContent.Panel1
            // 
            splitContainerEventContent.Panel1.Controls.Add(dgvEventContent);
            // 
            // splitContainerEventContent.Panel2
            // 
            splitContainerEventContent.Panel2.Controls.Add(panel4);
            splitContainerEventContent.Panel2.Controls.Add(panelAction);
            splitContainerEventContent.Panel2.Controls.Add(txtPlate);
            splitContainerEventContent.Size = new Size(727, 156);
            splitContainerEventContent.SplitterDistance = 304;
            splitContainerEventContent.TabIndex = 0;
            // 
            // dgvEventContent
            // 
            dgvEventContent.AllowUserToAddRows = false;
            dgvEventContent.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(192, 255, 255);
            dgvEventContent.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvEventContent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvEventContent.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvEventContent.BackgroundColor = SystemColors.ButtonHighlight;
            dgvEventContent.BorderStyle = BorderStyle.None;
            dgvEventContent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEventContent.ColumnHeadersVisible = false;
            dgvEventContent.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2 });
            dgvEventContent.Dock = DockStyle.Fill;
            dgvEventContent.Location = new Point(0, 0);
            dgvEventContent.Name = "dgvEventContent";
            dgvEventContent.ReadOnly = true;
            dgvEventContent.RowHeadersVisible = false;
            dgvEventContent.RowTemplate.Height = 29;
            dgvEventContent.Size = new Size(304, 156);
            dgvEventContent.TabIndex = 0;
            // 
            // Column1
            // 
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            Column1.DefaultCellStyle = dataGridViewCellStyle5;
            Column1.HeaderText = "Header";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 5;
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 11.25F);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            Column2.DefaultCellStyle = dataGridViewCellStyle6;
            Column2.HeaderText = "Content";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // panel4
            // 
            panel4.Controls.Add(picLprImage);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 32);
            panel4.Name = "panel4";
            panel4.Size = new Size(419, 79);
            panel4.TabIndex = 4;
            // 
            // picLprImage
            // 
            picLprImage.BackColor = Color.WhiteSmoke;
            picLprImage.Dock = DockStyle.Fill;
            picLprImage.Image = (Image)resources.GetObject("picLprImage.Image");
            picLprImage.Location = new Point(0, 0);
            picLprImage.Name = "picLprImage";
            picLprImage.Size = new Size(419, 79);
            picLprImage.SizeMode = PictureBoxSizeMode.Zoom;
            picLprImage.TabIndex = 4;
            picLprImage.TabStop = false;
            // 
            // panelAction
            // 
            panelAction.AutoScroll = true;
            panelAction.AutoScrollMinSize = new Size(0, 68);
            panelAction.Controls.Add(btnWriteIn);
            panelAction.Controls.Add(btnOpenBarrie);
            panelAction.Controls.Add(btnReTakePhoto);
            panelAction.Dock = DockStyle.Bottom;
            panelAction.Location = new Point(0, 111);
            panelAction.Name = "panelAction";
            panelAction.Padding = new Padding(0, 3, 0, 3);
            panelAction.Size = new Size(419, 45);
            panelAction.TabIndex = 3;
            panelAction.SizeChanged += panelAction_SizeChanged;
            // 
            // btnWriteIn
            // 
            btnWriteIn.AutoSize = true;
            btnWriteIn.BackColor = Color.Transparent;
            btnWriteIn.Dock = DockStyle.Left;
            btnWriteIn.Image = (Image)resources.GetObject("btnWriteIn.Image");
            btnWriteIn.ImageAlign = ContentAlignment.TopCenter;
            btnWriteIn.Location = new Point(160, 3);
            btnWriteIn.Name = "btnWriteIn";
            btnWriteIn.Size = new Size(80, 62);
            btnWriteIn.TabIndex = 4;
            btnWriteIn.TextImageRelation = TextImageRelation.ImageAboveText;
            btnWriteIn.UseVisualStyleBackColor = false;
            btnWriteIn.Click += BtnWriteIn_Click;
            // 
            // btnOpenBarrie
            // 
            btnOpenBarrie.AutoSize = true;
            btnOpenBarrie.BackColor = Color.Transparent;
            btnOpenBarrie.Dock = DockStyle.Left;
            btnOpenBarrie.Image = (Image)resources.GetObject("btnOpenBarrie.Image");
            btnOpenBarrie.ImageAlign = ContentAlignment.TopCenter;
            btnOpenBarrie.Location = new Point(80, 3);
            btnOpenBarrie.Name = "btnOpenBarrie";
            btnOpenBarrie.Size = new Size(80, 62);
            btnOpenBarrie.TabIndex = 6;
            btnOpenBarrie.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOpenBarrie.UseVisualStyleBackColor = false;
            btnOpenBarrie.Click += btnOpenBarrie_Click;
            // 
            // btnReTakePhoto
            // 
            btnReTakePhoto.AutoSize = true;
            btnReTakePhoto.BackColor = Color.Transparent;
            btnReTakePhoto.Dock = DockStyle.Left;
            btnReTakePhoto.Image = (Image)resources.GetObject("btnReTakePhoto.Image");
            btnReTakePhoto.ImageAlign = ContentAlignment.TopCenter;
            btnReTakePhoto.Location = new Point(0, 3);
            btnReTakePhoto.Name = "btnReTakePhoto";
            btnReTakePhoto.Size = new Size(80, 62);
            btnReTakePhoto.TabIndex = 3;
            btnReTakePhoto.TextImageRelation = TextImageRelation.ImageAboveText;
            btnReTakePhoto.UseVisualStyleBackColor = false;
            btnReTakePhoto.Click += BtnReTakePhoto_Click;
            // 
            // txtPlate
            // 
            txtPlate.BackColor = SystemColors.HighlightText;
            txtPlate.Dock = DockStyle.Top;
            txtPlate.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            txtPlate.Location = new Point(0, 0);
            txtPlate.Name = "txtPlate";
            txtPlate.Size = new Size(419, 32);
            txtPlate.TabIndex = 0;
            txtPlate.TextAlign = HorizontalAlignment.Center;
            // 
            // lblResult
            // 
            lblResult.BackColor = Color.FromArgb(0, 64, 0);
            lblResult.Dock = DockStyle.Top;
            lblResult.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblResult.ForeColor = SystemColors.ButtonHighlight;
            lblResult.Location = new Point(0, 0);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(727, 34);
            lblResult.TabIndex = 1;
            lblResult.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picSetting
            // 
            picSetting.BackColor = Color.DarkGreen;
            picSetting.Dock = DockStyle.Right;
            picSetting.Image = (Image)resources.GetObject("picSetting.Image");
            picSetting.Location = new Point(602, 0);
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
            panel5.Controls.Add(lblLaneName);
            panel5.Controls.Add(picSetting);
            panel5.Controls.Add(panel7);
            panel5.Controls.Add(pictureBox2);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 0);
            panel5.Margin = new Padding(0);
            panel5.Name = "panel5";
            panel5.Size = new Size(727, 30);
            panel5.TabIndex = 6;
            // 
            // panel7
            // 
            panel7.BackColor = Color.DarkGreen;
            panel7.Dock = DockStyle.Right;
            panel7.Location = new Point(654, 0);
            panel7.Margin = new Padding(0);
            panel7.Name = "panel7";
            panel7.Size = new Size(21, 30);
            panel7.TabIndex = 9;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.DarkGreen;
            pictureBox2.Dock = DockStyle.Right;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(675, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(52, 30);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            pictureBox2.Visible = false;
            // 
            // ucLaneIn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainerMain);
            Controls.Add(panel5);
            Margin = new Padding(0);
            Name = "ucLaneIn";
            Size = new Size(727, 678);
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picVehicleImage).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picOverviewImage).EndInit();
            splitContainerEventContent.Panel1.ResumeLayout(false);
            splitContainerEventContent.Panel2.ResumeLayout(false);
            splitContainerEventContent.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerEventContent).EndInit();
            splitContainerEventContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEventContent).EndInit();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLprImage).EndInit();
            panelAction.ResumeLayout(false);
            panelAction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picSetting).EndInit();
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
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
        private Panel panel4;
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
    }
}
