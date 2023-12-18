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
            lblLaneName = new Label();
            panelCameras = new Panel();
            splitContainer1 = new SplitContainer();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel3 = new Panel();
            movablePictureBox2 = new MovablePictureBox();
            panel2 = new Panel();
            movablePictureBox3 = new MovablePictureBox();
            panel6 = new Panel();
            movablePictureBox5 = new MovablePictureBox();
            panel5 = new Panel();
            movablePictureBox4 = new MovablePictureBox();
            label1 = new Label();
            label2 = new Label();
            splitter1 = new Splitter();
            splitContainer2 = new SplitContainer();
            movablePictureBox1 = new MovablePictureBox();
            panel1 = new Panel();
            btnPrintTicket = new Button();
            button1 = new Button();
            btnVoucher = new Button();
            btnReTakePhoto = new Button();
            btnWriteOut = new Button();
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            lblResult = new Label();
            panel4 = new Panel();
            pictureBox1 = new PictureBox();
            panel7 = new Panel();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)movablePictureBox2).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)movablePictureBox3).BeginInit();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)movablePictureBox5).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)movablePictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)movablePictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            panelCameras.Size = new Size(241, 444);
            panelCameras.TabIndex = 3;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 43);
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
            splitContainer1.Size = new Size(815, 635);
            splitContainer1.SplitterDistance = 444;
            splitContainer1.TabIndex = 4;
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
            tableLayoutPanel1.Size = new Size(571, 444);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Control;
            panel3.Controls.Add(movablePictureBox2);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(5, 242);
            panel3.Name = "panel3";
            panel3.Size = new Size(276, 197);
            panel3.TabIndex = 1;
            // 
            // movablePictureBox2
            // 
            movablePictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            movablePictureBox2.Image = (Image)resources.GetObject("movablePictureBox2.Image");
            movablePictureBox2.Location = new Point(0, 0);
            movablePictureBox2.Name = "movablePictureBox2";
            movablePictureBox2.Size = new Size(275, 197);
            movablePictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            movablePictureBox2.TabIndex = 5;
            movablePictureBox2.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(movablePictureBox3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(289, 242);
            panel2.Name = "panel2";
            panel2.Size = new Size(277, 197);
            panel2.TabIndex = 0;
            // 
            // movablePictureBox3
            // 
            movablePictureBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            movablePictureBox3.Image = (Image)resources.GetObject("movablePictureBox3.Image");
            movablePictureBox3.Location = new Point(3, 3);
            movablePictureBox3.Name = "movablePictureBox3";
            movablePictureBox3.Size = new Size(276, 197);
            movablePictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            movablePictureBox3.TabIndex = 5;
            movablePictureBox3.TabStop = false;
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.Control;
            panel6.Controls.Add(movablePictureBox5);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(289, 37);
            panel6.Name = "panel6";
            panel6.Size = new Size(277, 197);
            panel6.TabIndex = 3;
            // 
            // movablePictureBox5
            // 
            movablePictureBox5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            movablePictureBox5.Image = (Image)resources.GetObject("movablePictureBox5.Image");
            movablePictureBox5.Location = new Point(0, 0);
            movablePictureBox5.Name = "movablePictureBox5";
            movablePictureBox5.Size = new Size(279, 197);
            movablePictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            movablePictureBox5.TabIndex = 5;
            movablePictureBox5.TabStop = false;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.Control;
            panel5.Controls.Add(movablePictureBox4);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(5, 37);
            panel5.Name = "panel5";
            panel5.Size = new Size(276, 197);
            panel5.TabIndex = 2;
            // 
            // movablePictureBox4
            // 
            movablePictureBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            movablePictureBox4.Image = (Image)resources.GetObject("movablePictureBox4.Image");
            movablePictureBox4.Location = new Point(0, 0);
            movablePictureBox4.Name = "movablePictureBox4";
            movablePictureBox4.Size = new Size(275, 197);
            movablePictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            movablePictureBox4.TabIndex = 5;
            movablePictureBox4.TabStop = false;
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
            // splitter1
            // 
            splitter1.Location = new Point(241, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(3, 444);
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
            splitContainer2.Panel1.Controls.Add(movablePictureBox1);
            splitContainer2.Panel1.Controls.Add(panel1);
            splitContainer2.Panel1.Controls.Add(textBox1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(dataGridView1);
            splitContainer2.Size = new Size(815, 153);
            splitContainer2.SplitterDistance = 454;
            splitContainer2.TabIndex = 0;
            // 
            // movablePictureBox1
            // 
            movablePictureBox1.Dock = DockStyle.Fill;
            movablePictureBox1.Image = (Image)resources.GetObject("movablePictureBox1.Image");
            movablePictureBox1.Location = new Point(0, 32);
            movablePictureBox1.Name = "movablePictureBox1";
            movablePictureBox1.Size = new Size(454, 53);
            movablePictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            movablePictureBox1.TabIndex = 4;
            movablePictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnPrintTicket);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btnVoucher);
            panel1.Controls.Add(btnReTakePhoto);
            panel1.Controls.Add(btnWriteOut);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 85);
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
            // textBox1
            // 
            textBox1.BackColor = SystemColors.HighlightText;
            textBox1.Dock = DockStyle.Top;
            textBox1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.Location = new Point(0, 0);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(454, 32);
            textBox1.TabIndex = 0;
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(357, 153);
            dataGridView1.TabIndex = 1;
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
            panel4.Controls.Add(pictureBox1);
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
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Red;
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(690, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(52, 43);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
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
            // 
            // ucLaneOut
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Controls.Add(panel4);
            Margin = new Padding(0);
            Name = "ucLaneOut";
            Size = new Size(815, 678);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)movablePictureBox2).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)movablePictureBox3).EndInit();
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)movablePictureBox5).EndInit();
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)movablePictureBox4).EndInit();
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)movablePictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private Button btnVoucher;
        private Button button1;
        private TextBox textBox1;
        private Label lblResult;
        private MovablePictureBox movablePictureBox1;
        private Panel panel2;
        private MovablePictureBox movablePictureBox3;
        private Panel panel3;
        private MovablePictureBox movablePictureBox2;
        private Panel panel6;
        private MovablePictureBox movablePictureBox5;
        private Panel panel5;
        private MovablePictureBox movablePictureBox4;
        private Label label1;
        private Label label2;
        private Button btnWriteOut;
        private Button btnReTakePhoto;
        private DataGridView dataGridView1;
        private Button btnPrintTicket;
        private Panel panel4;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Panel panel7;
    }
}
