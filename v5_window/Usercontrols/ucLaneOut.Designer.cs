namespace iParkingv5_window.Usercontrols
{
    partial class ucLaneOut
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
            SplitterCamera = new Splitter();
            splitContainerEventContent = new SplitContainer();
            picLprImage = new MovablePictureBox();
            panel1 = new Panel();
            btnPrintTicket = new Button();
            button1 = new Button();
            btnVoucher = new Button();
            btnReTakePhoto = new Button();
            btnWriteOut = new Button();
            txtPlate = new TextBox();
            dgvEventContent = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            lblResult = new Label();
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
            panel1.SuspendLayout();
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
            lblLaneName.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblLaneName.ForeColor = SystemColors.ButtonHighlight;
            lblLaneName.Location = new Point(0, 0);
            lblLaneName.Margin = new Padding(0);
            lblLaneName.Name = "lblLaneName";
            lblLaneName.Size = new Size(763, 43);
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
            panelCameras.Size = new Size(241, 445);
            panelCameras.TabIndex = 3;
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(0, 43);
            splitContainerMain.Margin = new Padding(0);
            splitContainerMain.Name = "splitContainerMain";
            splitContainerMain.Orientation = Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(tableLayoutPanel1);
            splitContainerMain.Panel1.Controls.Add(SplitterCamera);
            splitContainerMain.Panel1.Controls.Add(panelCameras);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(splitContainerEventContent);
            splitContainerMain.Panel2.Controls.Add(lblResult);
            splitContainerMain.Size = new Size(815, 635);
            splitContainerMain.SplitterDistance = 445;
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
            tableLayoutPanel1.Size = new Size(571, 445);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Control;
            panel3.Controls.Add(picOverviewImageIn);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(5, 242);
            panel3.Name = "panel3";
            panel3.Size = new Size(276, 198);
            panel3.TabIndex = 1;
            // 
            // picOverviewImageIn
            // 
            picOverviewImageIn.Dock = DockStyle.Fill;
            picOverviewImageIn.Image = (Image)resources.GetObject("picOverviewImageIn.Image");
            picOverviewImageIn.Location = new Point(0, 0);
            picOverviewImageIn.Name = "picOverviewImageIn";
            picOverviewImageIn.Size = new Size(276, 198);
            picOverviewImageIn.SizeMode = PictureBoxSizeMode.StretchImage;
            picOverviewImageIn.TabIndex = 5;
            picOverviewImageIn.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(picOverviewImageOut);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(289, 242);
            panel2.Name = "panel2";
            panel2.Size = new Size(277, 198);
            panel2.TabIndex = 0;
            // 
            // picOverviewImageOut
            // 
            picOverviewImageOut.Dock = DockStyle.Fill;
            picOverviewImageOut.Image = (Image)resources.GetObject("picOverviewImageOut.Image");
            picOverviewImageOut.Location = new Point(0, 0);
            picOverviewImageOut.Name = "picOverviewImageOut";
            picOverviewImageOut.Size = new Size(277, 198);
            picOverviewImageOut.SizeMode = PictureBoxSizeMode.StretchImage;
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
            panel6.Size = new Size(277, 197);
            panel6.TabIndex = 3;
            // 
            // picVehicleImageOut
            // 
            picVehicleImageOut.Dock = DockStyle.Fill;
            picVehicleImageOut.Image = (Image)resources.GetObject("picVehicleImageOut.Image");
            picVehicleImageOut.Location = new Point(0, 0);
            picVehicleImageOut.Name = "picVehicleImageOut";
            picVehicleImageOut.Size = new Size(277, 197);
            picVehicleImageOut.SizeMode = PictureBoxSizeMode.StretchImage;
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
            panel5.Size = new Size(276, 197);
            panel5.TabIndex = 2;
            // 
            // picVehicleImageIn
            // 
            picVehicleImageIn.Dock = DockStyle.Fill;
            picVehicleImageIn.Image = (Image)resources.GetObject("picVehicleImageIn.Image");
            picVehicleImageIn.Location = new Point(0, 0);
            picVehicleImageIn.Name = "picVehicleImageIn";
            picVehicleImageIn.Size = new Size(276, 197);
            picVehicleImageIn.SizeMode = PictureBoxSizeMode.StretchImage;
            picVehicleImageIn.TabIndex = 5;
            picVehicleImageIn.TabStop = false;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
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
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label2.ForeColor = Color.Maroon;
            label2.Location = new Point(289, 2);
            label2.Name = "label2";
            label2.Size = new Size(277, 30);
            label2.TabIndex = 5;
            label2.Text = "Ảnh Ra";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SplitterCamera
            // 
            SplitterCamera.Location = new Point(241, 0);
            SplitterCamera.Name = "SplitterCamera";
            SplitterCamera.Size = new Size(3, 445);
            SplitterCamera.TabIndex = 4;
            SplitterCamera.TabStop = false;
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
            splitContainerEventContent.Panel1.Controls.Add(panel1);
            splitContainerEventContent.Panel1.Controls.Add(txtPlate);
            // 
            // splitContainerEventContent.Panel2
            // 
            splitContainerEventContent.Panel2.AutoScroll = true;
            splitContainerEventContent.Panel2.Controls.Add(dgvEventContent);
            splitContainerEventContent.Size = new Size(815, 152);
            splitContainerEventContent.SplitterDistance = 454;
            splitContainerEventContent.TabIndex = 0;
            // 
            // picLprImage
            // 
            picLprImage.Dock = DockStyle.Fill;
            picLprImage.Image = (Image)resources.GetObject("picLprImage.Image");
            picLprImage.Location = new Point(0, 32);
            picLprImage.Name = "picLprImage";
            picLprImage.Size = new Size(454, 52);
            picLprImage.SizeMode = PictureBoxSizeMode.StretchImage;
            picLprImage.TabIndex = 4;
            picLprImage.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnPrintTicket);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btnVoucher);
            panel1.Controls.Add(btnReTakePhoto);
            panel1.Controls.Add(btnWriteOut);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 84);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(0, 3, 0, 3);
            panel1.Size = new Size(454, 68);
            panel1.TabIndex = 3;
            // 
            // btnPrintTicket
            // 
            btnPrintTicket.AutoSize = true;
            btnPrintTicket.Dock = DockStyle.Left;
            btnPrintTicket.Image = (Image)resources.GetObject("btnPrintTicket.Image");
            btnPrintTicket.ImageAlign = ContentAlignment.TopCenter;
            btnPrintTicket.Location = new Point(358, 3);
            btnPrintTicket.Name = "btnPrintTicket";
            btnPrintTicket.Size = new Size(74, 62);
            btnPrintTicket.TabIndex = 3;
            btnPrintTicket.Text = "In Vé";
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
            button1.Location = new Point(257, 3);
            button1.Name = "button1";
            button1.Size = new Size(101, 62);
            button1.TabIndex = 0;
            button1.Text = "TT - ONLINE";
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
            btnVoucher.Location = new Point(185, 3);
            btnVoucher.Name = "btnVoucher";
            btnVoucher.Size = new Size(72, 62);
            btnVoucher.TabIndex = 0;
            btnVoucher.Text = "Voucher";
            btnVoucher.TextImageRelation = TextImageRelation.ImageAboveText;
            btnVoucher.UseVisualStyleBackColor = true;
            btnVoucher.Visible = false;
            // 
            // btnReTakePhoto
            // 
            btnReTakePhoto.AutoSize = true;
            btnReTakePhoto.Dock = DockStyle.Left;
            btnReTakePhoto.Image = (Image)resources.GetObject("btnReTakePhoto.Image");
            btnReTakePhoto.ImageAlign = ContentAlignment.TopCenter;
            btnReTakePhoto.Location = new Point(98, 3);
            btnReTakePhoto.Name = "btnReTakePhoto";
            btnReTakePhoto.Size = new Size(87, 62);
            btnReTakePhoto.TabIndex = 1;
            btnReTakePhoto.Text = "Chụp lại";
            btnReTakePhoto.TextImageRelation = TextImageRelation.ImageAboveText;
            btnReTakePhoto.UseVisualStyleBackColor = true;
            btnReTakePhoto.Click += BtnReTakePhoto_Click;
            // 
            // btnWriteOut
            // 
            btnWriteOut.AutoSize = true;
            btnWriteOut.Dock = DockStyle.Left;
            btnWriteOut.Image = (Image)resources.GetObject("btnWriteOut.Image");
            btnWriteOut.ImageAlign = ContentAlignment.TopCenter;
            btnWriteOut.Location = new Point(0, 3);
            btnWriteOut.Name = "btnWriteOut";
            btnWriteOut.Size = new Size(98, 62);
            btnWriteOut.TabIndex = 2;
            btnWriteOut.Text = "Ghi Vé Ra";
            btnWriteOut.TextImageRelation = TextImageRelation.ImageAboveText;
            btnWriteOut.UseVisualStyleBackColor = true;
            btnWriteOut.Click += BtnWriteOut_Click;
            // 
            // txtPlate
            // 
            txtPlate.BackColor = SystemColors.HighlightText;
            txtPlate.Dock = DockStyle.Top;
            txtPlate.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
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
            dgvEventContent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEventContent.ColumnHeadersVisible = false;
            dgvEventContent.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2 });
            dgvEventContent.Dock = DockStyle.Fill;
            dgvEventContent.Location = new Point(0, 0);
            dgvEventContent.Name = "dgvEventContent";
            dgvEventContent.ReadOnly = true;
            dgvEventContent.RowHeadersVisible = false;
            dgvEventContent.RowTemplate.Height = 29;
            dgvEventContent.Size = new Size(357, 152);
            dgvEventContent.TabIndex = 1;
            // 
            // Column1
            // 
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Column1.DefaultCellStyle = dataGridViewCellStyle2;
            Column1.HeaderText = "Header";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 5;
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            Column2.DefaultCellStyle = dataGridViewCellStyle3;
            Column2.HeaderText = "Content";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // lblResult
            // 
            lblResult.BackColor = Color.FromArgb(0, 64, 0);
            lblResult.Dock = DockStyle.Top;
            lblResult.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblResult.ForeColor = SystemColors.ButtonHighlight;
            lblResult.Location = new Point(0, 0);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(815, 34);
            lblResult.TabIndex = 1;
            lblResult.Text = "HẸN GẶP LẠI";
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
            panel4.Size = new Size(815, 43);
            panel4.TabIndex = 5;
            // 
            // picSetting
            // 
            picSetting.BackColor = Color.Red;
            picSetting.Dock = DockStyle.Right;
            picSetting.Image = (Image)resources.GetObject("picSetting.Image");
            picSetting.Location = new Point(690, 0);
            picSetting.Name = "picSetting";
            picSetting.Size = new Size(52, 43);
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
            panel7.Size = new Size(21, 43);
            panel7.TabIndex = 8;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Green;
            pictureBox2.Dock = DockStyle.Right;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(763, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(52, 43);
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
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private Splitter SplitterCamera;
        private SplitContainer splitContainerEventContent;
        private Panel panel1;
        private Button btnVoucher;
        private Button button1;
        private TextBox txtPlate;
        private Label lblResult;
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
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
    }
}
