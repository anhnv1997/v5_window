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
            this.cbbIdentityGroup = new System.Windows.Forms.ComboBox();
            this.DayIn = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.TimeIn = new System.Windows.Forms.DateTimePicker();
            this.DayOut = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.TimeOut = new System.Windows.Forms.DateTimePicker();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.txbMoney = new System.Windows.Forms.TextBox();
            this.dgvShow = new System.Windows.Forms.DataGridView();
            this.btnClear = new System.Windows.Forms.Button();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdentityGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateTimeIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateTimeOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Money = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).BeginInit();
            this.SuspendLayout();
            // 
            // cbbIdentityGroup
            // 
            this.cbbIdentityGroup.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbIdentityGroup.FormattingEnabled = true;
            this.cbbIdentityGroup.Location = new System.Drawing.Point(127, 96);
            this.cbbIdentityGroup.Name = "cbbIdentityGroup";
            this.cbbIdentityGroup.Size = new System.Drawing.Size(325, 38);
            this.cbbIdentityGroup.TabIndex = 4;
            // 
            // DayIn
            // 
            this.DayIn.CalendarFont = new System.Drawing.Font("Segoe UI", 12F);
            this.DayIn.CustomFormat = "dd/MM/yyyy";
            this.DayIn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DayIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DayIn.Location = new System.Drawing.Point(127, 153);
            this.DayIn.Name = "DayIn";
            this.DayIn.Size = new System.Drawing.Size(108, 29);
            this.DayIn.TabIndex = 3;
            this.DayIn.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(22, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tên biểu phí :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(35, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nhóm thẻ :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(51, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Giờ vào :";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(128, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(324, 29);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "XuanCuong";
            // 
            // TimeIn
            // 
            this.TimeIn.CalendarFont = new System.Drawing.Font("Segoe UI", 12F);
            this.TimeIn.CustomFormat = "HH:mm:ss";
            this.TimeIn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TimeIn.Location = new System.Drawing.Point(274, 153);
            this.TimeIn.Name = "TimeIn";
            this.TimeIn.ShowUpDown = true;
            this.TimeIn.Size = new System.Drawing.Size(96, 29);
            this.TimeIn.TabIndex = 8;
            // 
            // DayOut
            // 
            this.DayOut.CalendarFont = new System.Drawing.Font("Segoe UI", 12F);
            this.DayOut.CustomFormat = "dd/MM/yyyy";
            this.DayOut.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DayOut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DayOut.Location = new System.Drawing.Point(127, 194);
            this.DayOut.Name = "DayOut";
            this.DayOut.Size = new System.Drawing.Size(108, 29);
            this.DayOut.TabIndex = 3;
            this.DayOut.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.Location = new System.Drawing.Point(62, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "Giờ ra :";
            // 
            // TimeOut
            // 
            this.TimeOut.CalendarFont = new System.Drawing.Font("Segoe UI", 12F);
            this.TimeOut.CustomFormat = "HH:mm:ss";
            this.TimeOut.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeOut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TimeOut.Location = new System.Drawing.Point(274, 194);
            this.TimeOut.Name = "TimeOut";
            this.TimeOut.ShowUpDown = true;
            this.TimeOut.Size = new System.Drawing.Size(96, 29);
            this.TimeOut.TabIndex = 8;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(550, 46);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(138, 74);
            this.btnCalculate.TabIndex = 9;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // txbMoney
            // 
            this.txbMoney.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMoney.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txbMoney.Location = new System.Drawing.Point(550, 149);
            this.txbMoney.Name = "txbMoney";
            this.txbMoney.Size = new System.Drawing.Size(138, 35);
            this.txbMoney.TabIndex = 10;
            // 
            // dgvShow
            // 
            this.dgvShow.AllowUserToAddRows = false;
            this.dgvShow.AllowUserToDeleteRows = false;
            this.dgvShow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvShow.BackgroundColor = System.Drawing.Color.White;
            this.dgvShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.FeeName,
            this.IdentityGroup,
            this.DateTimeIn,
            this.DateTimeOut,
            this.Money});
            this.dgvShow.Location = new System.Drawing.Point(12, 247);
            this.dgvShow.Name = "dgvShow";
            this.dgvShow.ReadOnly = true;
            this.dgvShow.RowTemplate.Height = 25;
            this.dgvShow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShow.Size = new System.Drawing.Size(1309, 334);
            this.dgvShow.TabIndex = 11;
            this.dgvShow.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShow_CellClick);
            this.dgvShow.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvShow_CellMouseDown);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(1225, 208);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(96, 33);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 60;
            // 
            // FeeName
            // 
            this.FeeName.HeaderText = "Biểu phí";
            this.FeeName.Name = "FeeName";
            this.FeeName.ReadOnly = true;
            this.FeeName.Width = 200;
            // 
            // IdentityGroup
            // 
            this.IdentityGroup.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IdentityGroup.HeaderText = "Nhóm thẻ";
            this.IdentityGroup.Name = "IdentityGroup";
            this.IdentityGroup.ReadOnly = true;
            // 
            // DateTimeIn
            // 
            this.DateTimeIn.HeaderText = "Giờ vào";
            this.DateTimeIn.Name = "DateTimeIn";
            this.DateTimeIn.ReadOnly = true;
            this.DateTimeIn.Width = 200;
            // 
            // DateTimeOut
            // 
            this.DateTimeOut.HeaderText = "Giờ ra";
            this.DateTimeOut.Name = "DateTimeOut";
            this.DateTimeOut.ReadOnly = true;
            this.DateTimeOut.Width = 200;
            // 
            // Money
            // 
            this.Money.HeaderText = "Tiền";
            this.Money.Name = "Money";
            this.Money.ReadOnly = true;
            this.Money.Width = 150;
            // 
            // frmFeeCalculate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 593);
            this.Controls.Add(this.dgvShow);
            this.Controls.Add(this.txbMoney);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.TimeOut);
            this.Controls.Add(this.TimeIn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DayOut);
            this.Controls.Add(this.cbbIdentityGroup);
            this.Controls.Add(this.DayIn);
            this.Name = "frmFeeCalculate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmFeeCalculate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFeeCalculate_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cbbIdentityGroup;
        private DateTimePicker DayIn;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private DateTimePicker TimeIn;
        private DateTimePicker DayOut;
        private Label label4;
        private DateTimePicker TimeOut;
        private Button btnCalculate;
        private TextBox txbMoney;
        private DataGridView dgvShow;
        private Button btnClear;
        private DataGridViewTextBoxColumn STT;
        private DataGridViewTextBoxColumn FeeName;
        private DataGridViewTextBoxColumn IdentityGroup;
        private DataGridViewTextBoxColumn DateTimeIn;
        private DataGridViewTextBoxColumn DateTimeOut;
        private DataGridViewTextBoxColumn Money;
    }
}