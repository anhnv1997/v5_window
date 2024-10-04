namespace iParkingv5_window.Forms.DevelopeModes
{
    partial class frmSystemLogs
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvData = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            panel2 = new Panel();
            label2 = new Label();
            label1 = new Label();
            dtpEndTime = new DateTimePicker();
            dtpStartTime = new DateTimePicker();
            btnSearch = new Button();
            panel1 = new Panel();
            btnCancel = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            picVehicle = new PictureBox();
            picLpr = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picVehicle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLpr).BeginInit();
            SuspendLayout();
            // 
            // dgvData
            // 
            dgvData.AllowUserToAddRows = false;
            dgvData.AllowUserToDeleteRows = false;
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvData.BackgroundColor = SystemColors.ButtonHighlight;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Columns.AddRange(new DataGridViewColumn[] { Column1, Column3, Column2, Column4, Column5 });
            dgvData.Dock = DockStyle.Fill;
            dgvData.Location = new Point(0, 57);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowHeadersVisible = false;
            dgvData.RowTemplate.Height = 25;
            dgvData.Size = new Size(710, 482);
            dgvData.TabIndex = 2;
            // 
            // Column1
            // 
            Column1.HeaderText = "STT";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 60;
            // 
            // Column3
            // 
            Column3.HeaderText = "Thời gian";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.HeaderText = "Biển số xe";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 104;
            // 
            // Column4
            // 
            Column4.HeaderText = "vehiclePath";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Visible = false;
            Column4.Width = 113;
            // 
            // Column5
            // 
            Column5.HeaderText = "lprPath";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.Visible = false;
            Column5.Width = 84;
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(dtpEndTime);
            panel2.Controls.Add(dtpStartTime);
            panel2.Controls.Add(btnSearch);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1024, 57);
            panel2.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(333, 16);
            label2.Name = "label2";
            label2.Size = new Size(66, 21);
            label2.TabIndex = 6;
            label2.Text = "Kết thúc";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 18);
            label1.Name = "label1";
            label1.Size = new Size(62, 21);
            label1.TabIndex = 6;
            label1.Text = "Bắt đầu";
            // 
            // dtpEndTime
            // 
            dtpEndTime.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(421, 10);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.Size = new Size(200, 29);
            dtpEndTime.TabIndex = 5;
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(96, 12);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.Size = new Size(200, 29);
            dtpStartTime.TabIndex = 5;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(646, 10);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 29);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCancel);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 539);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(4);
            panel1.Size = new Size(1024, 61);
            panel1.TabIndex = 3;
            // 
            // btnCancel
            // 
            btnCancel.Dock = DockStyle.Right;
            btnCancel.Location = new Point(870, 4);
            btnCancel.Margin = new Padding(4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 53);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Đóng";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(picVehicle, 0, 0);
            tableLayoutPanel1.Controls.Add(picLpr, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Right;
            tableLayoutPanel1.Location = new Point(710, 57);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(314, 482);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // picVehicle
            // 
            picVehicle.Dock = DockStyle.Fill;
            picVehicle.Location = new Point(3, 3);
            picVehicle.Name = "picVehicle";
            picVehicle.Size = new Size(308, 235);
            picVehicle.SizeMode = PictureBoxSizeMode.StretchImage;
            picVehicle.TabIndex = 0;
            picVehicle.TabStop = false;
            // 
            // picLpr
            // 
            picLpr.Dock = DockStyle.Fill;
            picLpr.Location = new Point(3, 244);
            picLpr.Name = "picLpr";
            picLpr.Size = new Size(308, 235);
            picLpr.SizeMode = PictureBoxSizeMode.StretchImage;
            picLpr.TabIndex = 0;
            picLpr.TabStop = false;
            // 
            // frmSystemLogs
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1024, 600);
            Controls.Add(dgvData);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            Name = "frmSystemLogs";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kiểm tra log hệ thống";
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picVehicle).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLpr).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Button btnCancel;
        private DataGridView dgvData;
        private Button btnSearch;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox picVehicle;
        private PictureBox picLpr;
        private Label label2;
        private Label label1;
        private DateTimePicker dtpEndTime;
        private DateTimePicker dtpStartTime;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
    }
}