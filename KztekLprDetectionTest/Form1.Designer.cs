namespace KztekLprDetectionTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            txtInputPath = new TextBox();
            txtOutputPath = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnDetect = new Button();
            dgvData = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            picInput = new PictureBox();
            picOutput = new PictureBox();
            chbIsCar = new CheckBox();
            btnSaveErrorPic = new Button();
            btnStop = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            btnDetect1Image = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picOutput).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtInputPath
            // 
            txtInputPath.Location = new Point(76, 17);
            txtInputPath.Margin = new Padding(4, 3, 4, 3);
            txtInputPath.Name = "txtInputPath";
            txtInputPath.Size = new Size(511, 29);
            txtInputPath.TabIndex = 1;
            // 
            // txtOutputPath
            // 
            txtOutputPath.Location = new Point(76, 52);
            txtOutputPath.Margin = new Padding(4, 3, 4, 3);
            txtOutputPath.Name = "txtOutputPath";
            txtOutputPath.Size = new Size(511, 29);
            txtOutputPath.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 20);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(46, 21);
            label1.TabIndex = 2;
            label1.Text = "Input";
            label1.DoubleClick += label1_DoubleClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(5, 55);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(59, 21);
            label2.TabIndex = 2;
            label2.Text = "Output";
            // 
            // btnDetect
            // 
            btnDetect.Location = new Point(659, 15);
            btnDetect.Margin = new Padding(4, 3, 4, 3);
            btnDetect.Name = "btnDetect";
            btnDetect.Size = new Size(154, 29);
            btnDetect.TabIndex = 0;
            btnDetect.Text = "Nhận dạng";
            btnDetect.UseVisualStyleBackColor = true;
            btnDetect.Click += btnDetect_Click;
            // 
            // dgvData
            // 
            dgvData.AllowUserToAddRows = false;
            dgvData.AllowUserToDeleteRows = false;
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvData.BackgroundColor = SystemColors.Control;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Columns.AddRange(new DataGridViewColumn[] { Column1, Column4, Column5, Column3, Column6, Column2 });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.Padding = new Padding(3);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvData.DefaultCellStyle = dataGridViewCellStyle1;
            dgvData.Dock = DockStyle.Fill;
            dgvData.Location = new Point(0, 90);
            dgvData.Margin = new Padding(4, 3, 4, 3);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowHeadersVisible = false;
            dgvData.RowTemplate.Height = 29;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.Size = new Size(945, 621);
            dgvData.TabIndex = 3;
            // 
            // Column1
            // 
            Column1.HeaderText = "STT";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 66;
            // 
            // Column4
            // 
            Column4.HeaderText = "rootPath";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Visible = false;
            // 
            // Column5
            // 
            Column5.HeaderText = "resultPath";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.Visible = false;
            Column5.Width = 110;
            // 
            // Column3
            // 
            Column3.HeaderText = "Biển nhận diện";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 144;
            // 
            // Column6
            // 
            Column6.HeaderText = "Thời gian xử lý";
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            Column6.Width = 142;
            // 
            // Column2
            // 
            Column2.HeaderText = "Ảnh gốc";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 98;
            // 
            // picInput
            // 
            picInput.Dock = DockStyle.Fill;
            picInput.Location = new Point(4, 3);
            picInput.Margin = new Padding(4, 3, 4, 3);
            picInput.Name = "picInput";
            picInput.Size = new Size(249, 304);
            picInput.SizeMode = PictureBoxSizeMode.Zoom;
            picInput.TabIndex = 4;
            picInput.TabStop = false;
            // 
            // picOutput
            // 
            picOutput.Dock = DockStyle.Fill;
            picOutput.Location = new Point(4, 313);
            picOutput.Margin = new Padding(4, 3, 4, 3);
            picOutput.Name = "picOutput";
            picOutput.Size = new Size(249, 305);
            picOutput.SizeMode = PictureBoxSizeMode.Zoom;
            picOutput.TabIndex = 4;
            picOutput.TabStop = false;
            // 
            // chbIsCar
            // 
            chbIsCar.AutoSize = true;
            chbIsCar.Location = new Point(595, 56);
            chbIsCar.Margin = new Padding(4, 3, 4, 3);
            chbIsCar.Name = "chbIsCar";
            chbIsCar.Size = new Size(60, 25);
            chbIsCar.TabIndex = 5;
            chbIsCar.Text = "Ô Tô";
            chbIsCar.UseVisualStyleBackColor = true;
            // 
            // btnSaveErrorPic
            // 
            btnSaveErrorPic.Location = new Point(829, 16);
            btnSaveErrorPic.Margin = new Padding(4, 3, 4, 3);
            btnSaveErrorPic.Name = "btnSaveErrorPic";
            btnSaveErrorPic.Size = new Size(149, 29);
            btnSaveErrorPic.TabIndex = 0;
            btnSaveErrorPic.Text = "Lưu ảnh sai";
            btnSaveErrorPic.UseVisualStyleBackColor = true;
            btnSaveErrorPic.Click += btnSaveErrorPic_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(659, 46);
            btnStop.Margin = new Padding(4, 3, 4, 3);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(154, 29);
            btnStop.TabIndex = 0;
            btnStop.Text = "Dừng";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(picInput, 0, 0);
            tableLayoutPanel1.Controls.Add(picOutput, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Right;
            tableLayoutPanel1.Location = new Point(945, 90);
            tableLayoutPanel1.Margin = new Padding(4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(257, 621);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnDetect1Image);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnDetect);
            panel1.Controls.Add(chbIsCar);
            panel1.Controls.Add(btnStop);
            panel1.Controls.Add(btnSaveErrorPic);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtInputPath);
            panel1.Controls.Add(txtOutputPath);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1202, 90);
            panel1.TabIndex = 7;
            // 
            // btnDetect1Image
            // 
            btnDetect1Image.Location = new Point(829, 46);
            btnDetect1Image.Name = "btnDetect1Image";
            btnDetect1Image.Size = new Size(149, 29);
            btnDetect1Image.TabIndex = 6;
            btnDetect1Image.Text = "Check";
            btnDetect1Image.UseVisualStyleBackColor = true;
            btnDetect1Image.Click += btnDetect1Image_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1202, 711);
            Controls.Add(dgvData);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ((System.ComponentModel.ISupportInitialize)picInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)picOutput).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TextBox txtInputPath;
        private TextBox txtOutputPath;
        private Label label1;
        private Label label2;
        private Button btnDetect;
        private DataGridView dgvData;
        private PictureBox picInput;
        private PictureBox picOutput;
        private CheckBox chbIsCar;
        private Button btnSaveErrorPic;
        private Button button1;
        private Button btnStop;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column2;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Button btnDetect1Image;
    }
}
