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
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            picInput = new PictureBox();
            picOutput = new PictureBox();
            chbIsCar = new CheckBox();
            btnSaveErrorPic = new Button();
            btnStop = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picOutput).BeginInit();
            SuspendLayout();
            // 
            // txtInputPath
            // 
            txtInputPath.Location = new Point(75, 12);
            txtInputPath.Name = "txtInputPath";
            txtInputPath.Size = new Size(454, 27);
            txtInputPath.TabIndex = 1;
            // 
            // txtOutputPath
            // 
            txtOutputPath.Location = new Point(75, 45);
            txtOutputPath.Name = "txtOutputPath";
            txtOutputPath.Size = new Size(454, 27);
            txtOutputPath.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 15);
            label1.Name = "label1";
            label1.Size = new Size(43, 20);
            label1.TabIndex = 2;
            label1.Text = "Input";
            label1.DoubleClick += label1_DoubleClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 48);
            label2.Name = "label2";
            label2.Size = new Size(55, 20);
            label2.TabIndex = 2;
            label2.Text = "Output";
            // 
            // btnDetect
            // 
            btnDetect.Location = new Point(535, 12);
            btnDetect.Name = "btnDetect";
            btnDetect.Size = new Size(137, 28);
            btnDetect.TabIndex = 0;
            btnDetect.Text = "Nhận dạng";
            btnDetect.UseVisualStyleBackColor = true;
            btnDetect.Click += btnDetect_Click;
            // 
            // dgvData
            // 
            dgvData.AllowUserToAddRows = false;
            dgvData.AllowUserToDeleteRows = false;
            dgvData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvData.BackgroundColor = SystemColors.Control;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Columns.AddRange(new DataGridViewColumn[] { Column1, Column4, Column5, Column2, Column3, Column6 });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11.25F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.Padding = new Padding(3);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvData.DefaultCellStyle = dataGridViewCellStyle1;
            dgvData.Location = new Point(12, 91);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowHeadersVisible = false;
            dgvData.RowTemplate.Height = 29;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.Size = new Size(554, 454);
            dgvData.TabIndex = 3;
            // 
            // Column1
            // 
            Column1.HeaderText = "STT";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 64;
            // 
            // Column4
            // 
            Column4.HeaderText = "rootPath";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Visible = false;
            Column4.Width = 96;
            // 
            // Column5
            // 
            Column5.HeaderText = "resultPath";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.Visible = false;
            Column5.Width = 104;
            // 
            // Column2
            // 
            Column2.HeaderText = "Ảnh gốc";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 95;
            // 
            // Column3
            // 
            Column3.HeaderText = "Biển nhận diện";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 138;
            // 
            // Column6
            // 
            Column6.HeaderText = "Thời gian xử lý";
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            Column6.Width = 137;
            // 
            // picInput
            // 
            picInput.Location = new Point(572, 91);
            picInput.Name = "picInput";
            picInput.Size = new Size(354, 224);
            picInput.SizeMode = PictureBoxSizeMode.Zoom;
            picInput.TabIndex = 4;
            picInput.TabStop = false;
            // 
            // picOutput
            // 
            picOutput.Location = new Point(572, 330);
            picOutput.Name = "picOutput";
            picOutput.Size = new Size(354, 215);
            picOutput.SizeMode = PictureBoxSizeMode.Zoom;
            picOutput.TabIndex = 4;
            picOutput.TabStop = false;
            // 
            // chbIsCar
            // 
            chbIsCar.AutoSize = true;
            chbIsCar.Location = new Point(535, 46);
            chbIsCar.Name = "chbIsCar";
            chbIsCar.Size = new Size(59, 24);
            chbIsCar.TabIndex = 5;
            chbIsCar.Text = "Ô Tô";
            chbIsCar.UseVisualStyleBackColor = true;
            // 
            // btnSaveErrorPic
            // 
            btnSaveErrorPic.Location = new Point(793, 12);
            btnSaveErrorPic.Name = "btnSaveErrorPic";
            btnSaveErrorPic.Size = new Size(133, 28);
            btnSaveErrorPic.TabIndex = 0;
            btnSaveErrorPic.Text = "Lưu ảnh sai";
            btnSaveErrorPic.UseVisualStyleBackColor = true;
            btnSaveErrorPic.Click += btnSaveErrorPic_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(678, 12);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(109, 28);
            btnStop.TabIndex = 0;
            btnStop.Text = "Dừng";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(938, 557);
            Controls.Add(chbIsCar);
            Controls.Add(picOutput);
            Controls.Add(picInput);
            Controls.Add(dgvData);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtOutputPath);
            Controls.Add(txtInputPath);
            Controls.Add(btnSaveErrorPic);
            Controls.Add(btnStop);
            Controls.Add(btnDetect);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ((System.ComponentModel.ISupportInitialize)picInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)picOutput).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column6;
        private Button btnSaveErrorPic;
        private Button button1;
        private Button btnStop;
    }
}
