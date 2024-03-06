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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLaneOut));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            lblLaneName = new Label();
            panelCameras = new Panel();
            splitContainerMain = new SplitContainer();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel3 = new Panel();
            picOverviewImageIn = new MovablePictureBox();
            panel2 = new Panel();
            picOverviewImageOut = new MovablePictureBox();
            panel6 = new Panel();
            picVehicleImageOut = new MovablePictureBox();
            panel5 = new Panel();
            picVehicleImageIn = new MovablePictureBox();
            label1 = new Label();
            label2 = new Label();
            splitterCamera = new Splitter();
            splitContainerEventContent = new SplitContainer();
            picLprImage = new MovablePictureBox();
            panelAction = new Panel();
            btnPrintTicket = new Button();
            button1 = new Button();
            btnVoucher = new Button();
            btnWriteOut = new Button();
            btnOpenBarrie = new Button();
            btnReTakePhoto = new Button();
            txtPlate = new TextBox();
            dgvEventContent = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            lblResult = new lblResult();
            panel4 = new Panel();
            picSetting = new PictureBox();
            panel7 = new Panel();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picOverviewImageIn).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picOverviewImageOut).BeginInit();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picVehicleImageOut).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picVehicleImageIn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerEventContent).BeginInit();
            splitContainerEventContent.Panel1.SuspendLayout();
            splitContainerEventContent.Panel2.SuspendLayout();
            splitContainerEventContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLprImage).BeginInit();
            panelAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEventContent).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picSetting).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
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
            lblLaneName.Size = new Size(763, 30);
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
            splitContainerMain.Size = new Size(815, 648);
            splitContainerMain.SplitterDistance = 454;
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
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(571, 454);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Control;
            panel3.Controls.Add(picOverviewImageIn);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(5, 247);
            panel3.Name = "panel3";
            panel3.Size = new Size(276, 202);
            panel3.TabIndex = 1;
            // 
            // picOverviewImageIn
            // 
            picOverviewImageIn.BackColor = Color.WhiteSmoke;
            picOverviewImageIn.Dock = DockStyle.Fill;
            picOverviewImageIn.Image = (Image)resources.GetObject("picOverviewImageIn.Image");
            picOverviewImageIn.Location = new Point(0, 0);
            picOverviewImageIn.Name = "picOverviewImageIn";
            picOverviewImageIn.Size = new Size(276, 202);
            picOverviewImageIn.SizeMode = PictureBoxSizeMode.Zoom;
            picOverviewImageIn.TabIndex = 5;
            picOverviewImageIn.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(picOverviewImageOut);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(289, 247);
            panel2.Name = "panel2";
            panel2.Size = new Size(277, 202);
            panel2.TabIndex = 0;
            // 
            // picOverviewImageOut
            // 
            picOverviewImageOut.BackColor = Color.WhiteSmoke;
            picOverviewImageOut.Dock = DockStyle.Fill;
            picOverviewImageOut.Image = (Image)resources.GetObject("picOverviewImageOut.Image");
            picOverviewImageOut.Location = new Point(0, 0);
            picOverviewImageOut.Name = "picOverviewImageOut";
            picOverviewImageOut.Size = new Size(277, 202);
            picOverviewImageOut.SizeMode = PictureBoxSizeMode.Zoom;
            picOverviewImageOut.TabIndex = 5;
            picOverviewImageOut.TabStop = false;
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.Control;
            panel6.Controls.Add(picVehicleImageOut);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(289, 37);
            panel6.Name = "panel6";
            panel6.Size = new Size(277, 202);
            panel6.TabIndex = 3;
            // 
            // picVehicleImageOut
            // 
            picVehicleImageOut.BackColor = Color.WhiteSmoke;
            picVehicleImageOut.Dock = DockStyle.Fill;
            picVehicleImageOut.Image = (Image)resources.GetObject("picVehicleImageOut.Image");
            picVehicleImageOut.Location = new Point(0, 0);
            picVehicleImageOut.Name = "picVehicleImageOut";
            picVehicleImageOut.Size = new Size(277, 202);
            picVehicleImageOut.SizeMode = PictureBoxSizeMode.Zoom;
            picVehicleImageOut.TabIndex = 5;
            picVehicleImageOut.TabStop = false;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.Control;
            panel5.Controls.Add(picVehicleImageIn);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(5, 37);
            panel5.Name = "panel5";
            panel5.Size = new Size(276, 202);
            panel5.TabIndex = 2;
            // 
            // picVehicleImageIn
            // 
            picVehicleImageIn.BackColor = Color.WhiteSmoke;
            picVehicleImageIn.Dock = DockStyle.Fill;
            picVehicleImageIn.Image = (Image)resources.GetObject("picVehicleImageIn.Image");
            picVehicleImageIn.Location = new Point(0, 0);
            picVehicleImageIn.Name = "picVehicleImageIn";
            picVehicleImageIn.Size = new Size(276, 202);
            picVehicleImageIn.SizeMode = PictureBoxSizeMode.Zoom;
            picVehicleImageIn.TabIndex = 5;
            picVehicleImageIn.TabStop = false;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Underline);
            label1.ForeColor = Color.Green;
            label1.Location = new Point(5, 2);
            label1.Name = "label1";
            label1.Size = new Size(276, 30);
            label1.TabIndex = 4;
            label1.Text = "Ảnh Vào";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Underline);
            label2.ForeColor = Color.Maroon;
            label2.Location = new Point(289, 2);
            label2.Name = "label2";
            label2.Size = new Size(277, 30);
            label2.TabIndex = 5;
            label2.Text = "Ảnh Ra";
            label2.TextAlign = ContentAlignment.MiddleCenter;
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
            splitContainerEventContent.Panel1.Controls.Add(picLprImage);
            splitContainerEventContent.Panel1.Controls.Add(panelAction);
            splitContainerEventContent.Panel1.Controls.Add(txtPlate);
            // 
            // splitContainerEventContent.Panel2
            // 
            splitContainerEventContent.Panel2.AutoScroll = true;
            splitContainerEventContent.Panel2.Controls.Add(dgvEventContent);
            splitContainerEventContent.Size = new Size(815, 156);
            splitContainerEventContent.SplitterDistance = 454;
            splitContainerEventContent.TabIndex = 0;
            // 
            // picLprImage
            // 
            picLprImage.BackColor = Color.WhiteSmoke;
            picLprImage.Dock = DockStyle.Fill;
            picLprImage.Image = (Image)resources.GetObject("picLprImage.Image");
            picLprImage.Location = new Point(0, 32);
            picLprImage.Name = "picLprImage";
            picLprImage.Size = new Size(454, 56);
            picLprImage.SizeMode = PictureBoxSizeMode.Zoom;
            picLprImage.TabIndex = 4;
            picLprImage.TabStop = false;
            // 
            // panelAction
            // 
            panelAction.AutoScroll = true;
            panelAction.AutoScrollMinSize = new Size(0, 68);
            panelAction.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelAction.Controls.Add(btnPrintTicket);
            panelAction.Controls.Add(button1);
            panelAction.Controls.Add(btnVoucher);
            panelAction.Controls.Add(btnWriteOut);
            panelAction.Controls.Add(btnOpenBarrie);
            panelAction.Controls.Add(btnReTakePhoto);
            panelAction.Dock = DockStyle.Bottom;
            panelAction.Location = new Point(0, 88);
            panelAction.Name = "panelAction";
            panelAction.Padding = new Padding(0, 3, 0, 3);
            panelAction.Size = new Size(454, 68);
            panelAction.TabIndex = 3;
            panelAction.SizeChanged += panelAction_SizeChanged;
            // 
            // btnPrintTicket
            // 
            btnPrintTicket.AutoSize = true;
            btnPrintTicket.Dock = DockStyle.Left;
            btnPrintTicket.Image = (Image)resources.GetObject("btnPrintTicket.Image");
            btnPrintTicket.ImageAlign = ContentAlignment.TopCenter;
            btnPrintTicket.Location = new Point(400, 3);
            btnPrintTicket.Name = "btnPrintTicket";
            btnPrintTicket.Size = new Size(80, 62);
            btnPrintTicket.TabIndex = 3;
            btnPrintTicket.TextImageRelation = TextImageRelation.ImageAboveText;
            btnPrintTicket.UseVisualStyleBackColor = true;
            btnPrintTicket.Visible = false;
            btnPrintTicket.Click += btnPrintTicket_Click;
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.Dock = DockStyle.Left;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.TopCenter;
            button1.Location = new Point(320, 3);
            button1.Name = "button1";
            button1.Size = new Size(80, 62);
            button1.TabIndex = 0;
            button1.TextImageRelation = TextImageRelation.ImageAboveText;
            button1.UseVisualStyleBackColor = true;
            button1.Visible = false;
            // 
            // btnVoucher
            // 
            btnVoucher.AutoSize = true;
            btnVoucher.Dock = DockStyle.Left;
            btnVoucher.Image = (Image)resources.GetObject("btnVoucher.Image");
            btnVoucher.ImageAlign = ContentAlignment.TopCenter;
            btnVoucher.Location = new Point(240, 3);
            btnVoucher.Name = "btnVoucher";
            btnVoucher.Size = new Size(80, 62);
            btnVoucher.TabIndex = 0;
            btnVoucher.TextImageRelation = TextImageRelation.ImageAboveText;
            btnVoucher.UseVisualStyleBackColor = true;
            btnVoucher.Visible = false;
            // 
            // btnWriteOut
            // 
            btnWriteOut.AutoSize = true;
            btnWriteOut.Dock = DockStyle.Left;
            btnWriteOut.Image = (Image)resources.GetObject("btnWriteOut.Image");
            btnWriteOut.ImageAlign = ContentAlignment.TopCenter;
            btnWriteOut.Location = new Point(160, 3);
            btnWriteOut.Name = "btnWriteOut";
            btnWriteOut.Size = new Size(80, 62);
            btnWriteOut.TabIndex = 2;
            btnWriteOut.TextImageRelation = TextImageRelation.ImageAboveText;
            btnWriteOut.UseVisualStyleBackColor = true;
            btnWriteOut.Click += BtnWriteOut_Click;
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
            btnOpenBarrie.TabIndex = 7;
            btnOpenBarrie.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOpenBarrie.UseVisualStyleBackColor = false;
            btnOpenBarrie.Click += btnOpenBarrie_Click;
            // 
            // btnReTakePhoto
            // 
            btnReTakePhoto.AutoSize = true;
            btnReTakePhoto.Dock = DockStyle.Left;
            btnReTakePhoto.Image = (Image)resources.GetObject("btnReTakePhoto.Image");
            btnReTakePhoto.ImageAlign = ContentAlignment.TopCenter;
            btnReTakePhoto.Location = new Point(0, 3);
            btnReTakePhoto.Name = "btnReTakePhoto";
            btnReTakePhoto.Size = new Size(80, 62);
            btnReTakePhoto.TabIndex = 1;
            btnReTakePhoto.TextImageRelation = TextImageRelation.ImageAboveText;
            btnReTakePhoto.UseVisualStyleBackColor = true;
            btnReTakePhoto.Click += BtnReTakePhoto_Click;
            // 
            // txtPlate
            // 
            txtPlate.BackColor = SystemColors.HighlightText;
            txtPlate.Dock = DockStyle.Top;
            txtPlate.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            txtPlate.Location = new Point(0, 0);
            txtPlate.Name = "txtPlate";
            txtPlate.Size = new Size(454, 32);
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
            dgvEventContent.Name = "dgvEventContent";
            dgvEventContent.ReadOnly = true;
            dgvEventContent.RowHeadersVisible = false;
            dgvEventContent.RowTemplate.Height = 29;
            dgvEventContent.Size = new Size(357, 156);
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
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11.25F);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            Column2.DefaultCellStyle = dataGridViewCellStyle3;
            Column2.HeaderText = "Content";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 5;
            // 
            // lblResult
            // 
            lblResult.BackColor = Color.FromArgb(0, 64, 0);
            lblResult.Dock = DockStyle.Top;
            lblResult.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblResult.ForeColor = SystemColors.ButtonHighlight;
            lblResult.Location = new Point(0, 0);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(815, 34);
            lblResult.TabIndex = 1;
            lblResult.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            panel4.Controls.Add(picSetting);
            panel4.Controls.Add(panel7);
            panel4.Controls.Add(lblLaneName);
            panel4.Controls.Add(pictureBox2);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Margin = new Padding(0);
            panel4.Name = "panel4";
            panel4.Size = new Size(815, 30);
            panel4.TabIndex = 5;
            // 
            // picSetting
            // 
            picSetting.BackColor = Color.DarkRed;
            picSetting.Dock = DockStyle.Right;
            picSetting.Image = (Image)resources.GetObject("picSetting.Image");
            picSetting.Location = new Point(690, 0);
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
            panel7.Location = new Point(742, 0);
            panel7.Margin = new Padding(0);
            panel7.Name = "panel7";
            panel7.Size = new Size(21, 30);
            panel7.TabIndex = 8;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.DarkRed;
            pictureBox2.Dock = DockStyle.Right;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(763, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(52, 30);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            pictureBox2.Visible = false;
            // 
            // ucLaneOut
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainerMain);
            Controls.Add(panel4);
            Margin = new Padding(0);
            Name = "ucLaneOut";
            Size = new Size(815, 678);
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picOverviewImageIn).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picOverviewImageOut).EndInit();
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picVehicleImageOut).EndInit();
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picVehicleImageIn).EndInit();
            splitContainerEventContent.Panel1.ResumeLayout(false);
            splitContainerEventContent.Panel1.PerformLayout();
            splitContainerEventContent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerEventContent).EndInit();
            splitContainerEventContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLprImage).EndInit();
            panelAction.ResumeLayout(false);
            panelAction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEventContent).EndInit();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picSetting).EndInit();
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
        private Button btnVoucher;
        private Button button1;
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
        private Button btnWriteOut;
        private Button btnReTakePhoto;
        private DataGridView dgvEventContent;
        private Button btnPrintTicket;
        private Panel panel4;
        private PictureBox picSetting;
        private PictureBox pictureBox2;
        private Panel panel7;
        private Button btnOpenBarrie;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
    }
}
