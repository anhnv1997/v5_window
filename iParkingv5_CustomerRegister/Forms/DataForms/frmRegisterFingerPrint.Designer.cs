namespace iParkingv5_CustomerRegister.Forms
{
    partial class frmRegisterFingerPrint
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegisterFingerPrint));
            btnConnect = new Button();
            pb = new PictureBox();
            btnEnroll = new Button();
            btnSaveFinger = new Button();
            dgvStatus = new DataGridView();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)pb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvStatus).BeginInit();
            SuspendLayout();
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(12, 12);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(190, 31);
            btnConnect.TabIndex = 0;
            btnConnect.Text = "Kết nối thiết bị";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btn_ConnectDevice_Click;
            // 
            // pb
            // 
            pb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pb.Location = new Point(643, 71);
            pb.Name = "pb";
            pb.Size = new Size(332, 367);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.TabIndex = 9;
            pb.TabStop = false;
            // 
            // btnEnroll
            // 
            btnEnroll.Location = new Point(208, 12);
            btnEnroll.Name = "btnEnroll";
            btnEnroll.Size = new Size(190, 31);
            btnEnroll.TabIndex = 1;
            btnEnroll.Text = "Đăng ký vân tay";
            btnEnroll.UseVisualStyleBackColor = true;
            btnEnroll.Click += btnEnroll_Click;
            // 
            // btnSaveFinger
            // 
            btnSaveFinger.Location = new Point(404, 12);
            btnSaveFinger.Name = "btnSaveFinger";
            btnSaveFinger.Size = new Size(147, 31);
            btnSaveFinger.TabIndex = 2;
            btnSaveFinger.Text = "Lưu vân tay";
            btnSaveFinger.UseVisualStyleBackColor = true;
            btnSaveFinger.Click += btnSaveFinger_Click;
            // 
            // dgvStatus
            // 
            dgvStatus.AllowUserToAddRows = false;
            dgvStatus.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(192, 255, 255);
            dgvStatus.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvStatus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvStatus.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvStatus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvStatus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStatus.Columns.AddRange(new DataGridViewColumn[] { Column2, Column3 });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11.25F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new Padding(3);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvStatus.DefaultCellStyle = dataGridViewCellStyle3;
            dgvStatus.Location = new Point(12, 69);
            dgvStatus.Name = "dgvStatus";
            dgvStatus.ReadOnly = true;
            dgvStatus.RowHeadersVisible = false;
            dgvStatus.RowTemplate.Height = 29;
            dgvStatus.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStatus.Size = new Size(625, 369);
            dgvStatus.TabIndex = 10;
            // 
            // Column2
            // 
            Column2.HeaderText = "Thời Gian";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column3.HeaderText = "Trạng Thái";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // frmRegisterFingerPrint
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(987, 450);
            Controls.Add(dgvStatus);
            Controls.Add(btnSaveFinger);
            Controls.Add(pb);
            Controls.Add(btnEnroll);
            Controls.Add(btnConnect);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmRegisterFingerPrint";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Đăng ký vân tay";
            ((System.ComponentModel.ISupportInitialize)pb).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvStatus).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private Label label2;
        private Button btnConnect;
        private PictureBox pb;
        private Button btnEnroll;
        private Button btnSaveFinger;
        private DataGridView dgvStatus;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
    }
}