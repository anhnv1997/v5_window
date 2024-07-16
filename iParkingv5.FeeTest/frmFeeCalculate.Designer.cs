namespace iParkingv5.FeeTest
{
    partial class frmFeeCalculate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFeeCalculate));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            cbbIdentityGroup = new ComboBox();
            DayIn = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtFeeName = new TextBox();
            TimeIn = new DateTimePicker();
            DayOut = new DateTimePicker();
            label4 = new Label();
            TimeOut = new DateTimePicker();
            btnCalculate = new Button();
            dgvShow = new DataGridView();
            btnClear = new Button();
            txbMoney = new Label();
            label5 = new Label();
            STT = new DataGridViewTextBoxColumn();
            FeeName = new DataGridViewTextBoxColumn();
            IdentityGroup = new DataGridViewTextBoxColumn();
            DateTimeIn = new DataGridViewTextBoxColumn();
            DateTimeOut = new DataGridViewTextBoxColumn();
            Money = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvShow).BeginInit();
            SuspendLayout();
            // 
            // cbbIdentityGroup
            // 
            cbbIdentityGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbIdentityGroup.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbbIdentityGroup.FormattingEnabled = true;
            cbbIdentityGroup.Location = new Point(169, 44);
            cbbIdentityGroup.Margin = new Padding(4);
            cbbIdentityGroup.Name = "cbbIdentityGroup";
            cbbIdentityGroup.Size = new Size(463, 38);
            cbbIdentityGroup.TabIndex = 2;
            // 
            // DayIn
            // 
            DayIn.CalendarFont = new Font("Segoe UI", 12F);
            DayIn.CustomFormat = "dd/MM/yyyy";
            DayIn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DayIn.Format = DateTimePickerFormat.Custom;
            DayIn.Location = new Point(169, 90);
            DayIn.Margin = new Padding(4);
            DayIn.Name = "DayIn";
            DayIn.Size = new Size(153, 29);
            DayIn.TabIndex = 3;
            DayIn.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(17, 15);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 21);
            label1.TabIndex = 5;
            label1.Text = "Tên biểu phí :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(17, 61);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(87, 21);
            label2.TabIndex = 5;
            label2.Text = "Nhóm thẻ :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(17, 98);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(71, 21);
            label3.TabIndex = 5;
            label3.Text = "Giờ vào :";
            // 
            // txtFeeName
            // 
            txtFeeName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFeeName.Location = new Point(169, 7);
            txtFeeName.Margin = new Padding(4);
            txtFeeName.Name = "txtFeeName";
            txtFeeName.Size = new Size(461, 29);
            txtFeeName.TabIndex = 1;
            txtFeeName.Text = "XuanCuong";
            // 
            // TimeIn
            // 
            TimeIn.CalendarFont = new Font("Segoe UI", 12F);
            TimeIn.CustomFormat = "HH:mm:ss";
            TimeIn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TimeIn.Format = DateTimePickerFormat.Custom;
            TimeIn.Location = new Point(348, 90);
            TimeIn.Margin = new Padding(4);
            TimeIn.Name = "TimeIn";
            TimeIn.ShowUpDown = true;
            TimeIn.Size = new Size(135, 29);
            TimeIn.TabIndex = 4;
            // 
            // DayOut
            // 
            DayOut.CalendarFont = new Font("Segoe UI", 12F);
            DayOut.CustomFormat = "dd/MM/yyyy";
            DayOut.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DayOut.Format = DateTimePickerFormat.Custom;
            DayOut.Location = new Point(169, 127);
            DayOut.Margin = new Padding(4);
            DayOut.Name = "DayOut";
            DayOut.Size = new Size(153, 29);
            DayOut.TabIndex = 5;
            DayOut.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(17, 135);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(60, 21);
            label4.TabIndex = 5;
            label4.Text = "Giờ ra :";
            // 
            // TimeOut
            // 
            TimeOut.CalendarFont = new Font("Segoe UI", 12F);
            TimeOut.CustomFormat = "HH:mm:ss";
            TimeOut.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TimeOut.Format = DateTimePickerFormat.Custom;
            TimeOut.Location = new Point(348, 127);
            TimeOut.Margin = new Padding(4);
            TimeOut.Name = "TimeOut";
            TimeOut.ShowUpDown = true;
            TimeOut.Size = new Size(135, 29);
            TimeOut.TabIndex = 6;
            // 
            // btnCalculate
            // 
            btnCalculate.Image = (Image)resources.GetObject("btnCalculate.Image");
            btnCalculate.Location = new Point(638, 7);
            btnCalculate.Margin = new Padding(4);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(150, 75);
            btnCalculate.TabIndex = 0;
            btnCalculate.Text = "Tính phí";
            btnCalculate.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // dgvShow
            // 
            dgvShow.AllowUserToAddRows = false;
            dgvShow.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(192, 255, 255);
            dgvShow.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvShow.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvShow.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvShow.BackgroundColor = Color.White;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvShow.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvShow.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvShow.Columns.AddRange(new DataGridViewColumn[] { STT, FeeName, IdentityGroup, DateTimeIn, DateTimeOut, Money });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.Padding = new Padding(3);
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvShow.DefaultCellStyle = dataGridViewCellStyle4;
            dgvShow.Location = new Point(17, 219);
            dgvShow.Margin = new Padding(4);
            dgvShow.Name = "dgvShow";
            dgvShow.ReadOnly = true;
            dgvShow.RowHeadersVisible = false;
            dgvShow.RowTemplate.Height = 25;
            dgvShow.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvShow.Size = new Size(805, 343);
            dgvShow.TabIndex = 11;
            dgvShow.CellClick += dgvShow_CellClick;
            dgvShow.CellMouseDown += dgvShow_CellMouseDown;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClear.Location = new Point(685, 291);
            btnClear.Margin = new Padding(4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(137, 46);
            btnClear.TabIndex = 9;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // txbMoney
            // 
            txbMoney.BackColor = SystemColors.ActiveCaption;
            txbMoney.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            txbMoney.ForeColor = Color.DarkRed;
            txbMoney.Location = new Point(169, 160);
            txbMoney.Name = "txbMoney";
            txbMoney.Size = new Size(314, 42);
            txbMoney.TabIndex = 12;
            txbMoney.Text = "0";
            txbMoney.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(17, 173);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(84, 21);
            label5.TabIndex = 5;
            label5.Text = "Phí gửi xe :";
            // 
            // STT
            // 
            STT.HeaderText = "STT";
            STT.Name = "STT";
            STT.ReadOnly = true;
            STT.Width = 72;
            // 
            // FeeName
            // 
            FeeName.HeaderText = "Biểu phí";
            FeeName.Name = "FeeName";
            FeeName.ReadOnly = true;
            FeeName.Width = 108;
            // 
            // IdentityGroup
            // 
            IdentityGroup.HeaderText = "Nhóm thẻ";
            IdentityGroup.Name = "IdentityGroup";
            IdentityGroup.ReadOnly = true;
            IdentityGroup.Width = 122;
            // 
            // DateTimeIn
            // 
            DateTimeIn.HeaderText = "Giờ vào";
            DateTimeIn.Name = "DateTimeIn";
            DateTimeIn.ReadOnly = true;
            DateTimeIn.Width = 103;
            // 
            // DateTimeOut
            // 
            DateTimeOut.HeaderText = "Giờ ra";
            DateTimeOut.Name = "DateTimeOut";
            DateTimeOut.ReadOnly = true;
            DateTimeOut.Width = 90;
            // 
            // Money
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            Money.DefaultCellStyle = dataGridViewCellStyle3;
            Money.HeaderText = "Phí gửi xe";
            Money.Name = "Money";
            Money.ReadOnly = true;
            Money.Width = 122;
            // 
            // frmFeeCalculate
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 575);
            Controls.Add(txbMoney);
            Controls.Add(dgvShow);
            Controls.Add(btnClear);
            Controls.Add(btnCalculate);
            Controls.Add(TimeOut);
            Controls.Add(TimeIn);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtFeeName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(DayOut);
            Controls.Add(cbbIdentityGroup);
            Controls.Add(DayIn);
            Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "frmFeeCalculate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tính phí gửi xe";
            FormClosing += frmFeeCalculate_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dgvShow).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbbIdentityGroup;
        private DateTimePicker DayIn;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtFeeName;
        private DateTimePicker TimeIn;
        private DateTimePicker DayOut;
        private Label label4;
        private DateTimePicker TimeOut;
        private Button btnCalculate;
        private DataGridView dgvShow;
        private Button btnClear;
        private Label txbMoney;
        private Label label5;
        private DataGridViewTextBoxColumn STT;
        private DataGridViewTextBoxColumn FeeName;
        private DataGridViewTextBoxColumn IdentityGroup;
        private DataGridViewTextBoxColumn DateTimeIn;
        private DataGridViewTextBoxColumn DateTimeOut;
        private DataGridViewTextBoxColumn Money;
    }
}