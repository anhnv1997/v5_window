namespace iParkingv5_window.Usercontrols
{
    partial class ucLaneIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLaneIn));
            lblLaneName = new Label();
            panelCameras = new Panel();
            splitContainer1 = new SplitContainer();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel3 = new Panel();
            picVehicleImage = new MovablePictureBox();
            panel2 = new Panel();
            picOverviewImage = new MovablePictureBox();
            label1 = new Label();
            splitter1 = new Splitter();
            splitContainer2 = new SplitContainer();
            dataGridView1 = new DataGridView();
            panel4 = new Panel();
            picLprImage = new MovablePictureBox();
            panel1 = new Panel();
            btnReTakePhoto = new Button();
            btnWriteIn = new Button();
            txtPlate = new TextBox();
            lblResult = new Label();
            pictureBox1 = new PictureBox();
            panel5 = new Panel();
            panel7 = new Panel();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picVehicleImage).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picOverviewImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLprImage).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // lblLaneName
            // 
            lblLaneName.BackColor = Color.Green;
            lblLaneName.Dock = DockStyle.Fill;
            lblLaneName.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblLaneName.ForeColor = SystemColors.ButtonHighlight;
            lblLaneName.Location = new Point(0, 0);
            lblLaneName.Margin = new Padding(0);
            lblLaneName.Name = "lblLaneName";
            lblLaneName.Size = new Size(727, 44);
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
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 44);
            splitContainer1.Margin = new Padding(0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel1);
            splitContainer1.Panel1.Controls.Add(splitter1);
            splitContainer1.Panel1.Controls.Add(panelCameras);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Panel2.Controls.Add(lblResult);
            splitContainer1.Size = new Size(727, 634);
            splitContainer1.SplitterDistance = 445;
            splitContainer1.TabIndex = 4;
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
            tableLayoutPanel1.Size = new Size(483, 445);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Control;
            panel3.Controls.Add(picVehicleImage);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(5, 37);
            panel3.Name = "panel3";
            panel3.Size = new Size(473, 197);
            panel3.TabIndex = 1;
            // 
            // picVehicleImage
            // 
            picVehicleImage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            picVehicleImage.Image = (Image)resources.GetObject("picVehicleImage.Image");
            picVehicleImage.Location = new Point(0, 0);
            picVehicleImage.Name = "picVehicleImage";
            picVehicleImage.Size = new Size(473, 197);
            picVehicleImage.SizeMode = PictureBoxSizeMode.Zoom;
            picVehicleImage.TabIndex = 5;
            picVehicleImage.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(picOverviewImage);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(5, 242);
            panel2.Name = "panel2";
            panel2.Size = new Size(473, 198);
            panel2.TabIndex = 0;
            // 
            // picOverviewImage
            // 
            picOverviewImage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            picOverviewImage.Image = (Image)resources.GetObject("picOverviewImage.Image");
            picOverviewImage.Location = new Point(0, 0);
            picOverviewImage.Name = "picOverviewImage";
            picOverviewImage.Size = new Size(473, 198);
            picOverviewImage.SizeMode = PictureBoxSizeMode.Zoom;
            picOverviewImage.TabIndex = 5;
            picOverviewImage.TabStop = false;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label1.ForeColor = Color.Green;
            label1.Location = new Point(5, 2);
            label1.Name = "label1";
            label1.Size = new Size(473, 30);
            label1.TabIndex = 2;
            label1.Text = "Ảnh Vào";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(241, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(3, 445);
            splitter1.TabIndex = 4;
            splitter1.TabStop = false;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 34);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(dataGridView1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(panel4);
            splitContainer2.Panel2.Controls.Add(panel1);
            splitContainer2.Panel2.Controls.Add(txtPlate);
            splitContainer2.Size = new Size(727, 151);
            splitContainer2.SplitterDistance = 402;
            splitContainer2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(402, 151);
            dataGridView1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(picLprImage);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 32);
            panel4.Name = "panel4";
            panel4.Size = new Size(321, 51);
            panel4.TabIndex = 4;
            // 
            // picLprImage
            // 
            picLprImage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            picLprImage.Image = (Image)resources.GetObject("picLprImage.Image");
            picLprImage.Location = new Point(0, 0);
            picLprImage.Name = "picLprImage";
            picLprImage.Size = new Size(321, 51);
            picLprImage.SizeMode = PictureBoxSizeMode.Zoom;
            picLprImage.TabIndex = 4;
            picLprImage.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnReTakePhoto);
            panel1.Controls.Add(btnWriteIn);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 83);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(0, 3, 0, 3);
            panel1.Size = new Size(321, 68);
            panel1.TabIndex = 3;
            // 
            // btnReTakePhoto
            // 
            btnReTakePhoto.AutoSize = true;
            btnReTakePhoto.Dock = DockStyle.Left;
            btnReTakePhoto.Image = (Image)resources.GetObject("btnReTakePhoto.Image");
            btnReTakePhoto.ImageAlign = ContentAlignment.TopCenter;
            btnReTakePhoto.Location = new Point(98, 3);
            btnReTakePhoto.Name = "btnReTakePhoto";
            btnReTakePhoto.Size = new Size(106, 62);
            btnReTakePhoto.TabIndex = 3;
            btnReTakePhoto.Text = "Chụp lại";
            btnReTakePhoto.TextImageRelation = TextImageRelation.ImageAboveText;
            btnReTakePhoto.UseVisualStyleBackColor = true;
            btnReTakePhoto.Click += BtnReTakePhoto_Click;
            // 
            // btnWriteIn
            // 
            btnWriteIn.AutoSize = true;
            btnWriteIn.Dock = DockStyle.Left;
            btnWriteIn.Image = (Image)resources.GetObject("btnWriteIn.Image");
            btnWriteIn.ImageAlign = ContentAlignment.TopCenter;
            btnWriteIn.Location = new Point(0, 3);
            btnWriteIn.Name = "btnWriteIn";
            btnWriteIn.Size = new Size(98, 62);
            btnWriteIn.TabIndex = 4;
            btnWriteIn.Text = "Ghi Vé Vào";
            btnWriteIn.TextImageRelation = TextImageRelation.ImageAboveText;
            btnWriteIn.UseVisualStyleBackColor = true;
            btnWriteIn.Click += BtnWriteIn_Click;
            // 
            // txtPlate
            // 
            txtPlate.BackColor = SystemColors.HighlightText;
            txtPlate.Dock = DockStyle.Top;
            txtPlate.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            txtPlate.Location = new Point(0, 0);
            txtPlate.Name = "txtPlate";
            txtPlate.Size = new Size(321, 32);
            txtPlate.TabIndex = 0;
            txtPlate.TextAlign = HorizontalAlignment.Center;
            // 
            // lblResult
            // 
            lblResult.BackColor = Color.FromArgb(0, 64, 0);
            lblResult.Dock = DockStyle.Top;
            lblResult.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblResult.ForeColor = SystemColors.ButtonHighlight;
            lblResult.Location = new Point(0, 0);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(727, 34);
            lblResult.TabIndex = 1;
            lblResult.Text = "XIN MỜI VÀO";
            lblResult.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Green;
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(602, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(52, 44);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Green;
            panel5.Controls.Add(pictureBox1);
            panel5.Controls.Add(panel7);
            panel5.Controls.Add(pictureBox2);
            panel5.Controls.Add(lblLaneName);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 0);
            panel5.Margin = new Padding(0);
            panel5.Name = "panel5";
            panel5.Size = new Size(727, 44);
            panel5.TabIndex = 6;
            // 
            // panel7
            // 
            panel7.BackColor = Color.DarkGreen;
            panel7.Dock = DockStyle.Right;
            panel7.Location = new Point(654, 0);
            panel7.Margin = new Padding(0);
            panel7.Name = "panel7";
            panel7.Size = new Size(21, 44);
            panel7.TabIndex = 9;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Red;
            pictureBox2.Dock = DockStyle.Right;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(675, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(52, 44);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // ucLaneIn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Controls.Add(panel5);
            Margin = new Padding(0);
            Name = "ucLaneIn";
            Size = new Size(727, 678);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picVehicleImage).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picOverviewImage).EndInit();
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLprImage).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblLaneName;
        private Panel panelCameras;
        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel1;
        private Splitter splitter1;
        private SplitContainer splitContainer2;
        private Panel panel1;
        private TextBox txtPlate;
        private DataGridView dataGridView1;
        private Label lblResult;
        private MovablePictureBox picLprImage;
        private Panel panel2;
        private MovablePictureBox picOverviewImage;
        private Panel panel3;
        private MovablePictureBox picVehicleImage;
        private Panel panel4;
        private Label label1;
        private Button btnReTakePhoto;
        private Button btnWriteIn;
        private PictureBox pictureBox1;
        private Panel panel5;
        private PictureBox pictureBox2;
        private Panel panel7;
    }
}
