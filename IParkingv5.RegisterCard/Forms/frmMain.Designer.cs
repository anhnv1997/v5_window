namespace IParkingv5.RegisterCard
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            label1 = new Label();
            label2 = new Label();
            cbFormat = new ComboBox();
            cbIdentityGroup = new ComboBox();
            label3 = new Label();
            cbController = new ComboBox();
            label4 = new Label();
            cbIdentityType = new ComboBox();
            groupBox1 = new GroupBox();
            numericUpDown1 = new NumericUpDown();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            txtLetter = new TextBox();
            label8 = new Label();
            groupBox2 = new GroupBox();
            btnStop = new Button();
            btnStart = new Button();
            lsbShow = new ListBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 47);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 0;
            label1.Text = "Nhóm định danh";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 100);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 0;
            label2.Text = "Định dạng";
            // 
            // cbFormat
            // 
            cbFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFormat.FormattingEnabled = true;
            cbFormat.Items.AddRange(new object[] { "000", "0000", "00000", "000000", "0000000", "00000000", "000000000", "0000000000" });
            cbFormat.Location = new Point(282, 98);
            cbFormat.Margin = new Padding(3, 2, 3, 2);
            cbFormat.Name = "cbFormat";
            cbFormat.Size = new Size(196, 23);
            cbFormat.TabIndex = 4;
            // 
            // cbIdentityGroup
            // 
            cbIdentityGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cbIdentityGroup.FormattingEnabled = true;
            cbIdentityGroup.Location = new Point(136, 47);
            cbIdentityGroup.Margin = new Padding(3, 2, 3, 2);
            cbIdentityGroup.Name = "cbIdentityGroup";
            cbIdentityGroup.Size = new Size(341, 23);
            cbIdentityGroup.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 22);
            label3.Name = "label3";
            label3.Size = new Size(79, 15);
            label3.TabIndex = 0;
            label3.Text = "Bộ điều khiển";
            // 
            // cbController
            // 
            cbController.DropDownStyle = ComboBoxStyle.DropDownList;
            cbController.FormattingEnabled = true;
            cbController.Location = new Point(136, 20);
            cbController.Margin = new Padding(3, 2, 3, 2);
            cbController.Name = "cbController";
            cbController.Size = new Size(341, 23);
            cbController.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 22);
            label4.Name = "label4";
            label4.Size = new Size(29, 15);
            label4.TabIndex = 0;
            label4.Text = "Loại";
            // 
            // cbIdentityType
            // 
            cbIdentityType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbIdentityType.FormattingEnabled = true;
            cbIdentityType.Location = new Point(136, 20);
            cbIdentityType.Margin = new Padding(3, 2, 3, 2);
            cbIdentityType.Name = "cbIdentityType";
            cbIdentityType.Size = new Size(341, 23);
            cbIdentityType.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(numericUpDown1);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtLetter);
            groupBox1.Controls.Add(cbIdentityType);
            groupBox1.Controls.Add(cbIdentityGroup);
            groupBox1.Controls.Add(cbFormat);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(10, 9);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(486, 225);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin thẻ";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(136, 73);
            numericUpDown1.Margin = new Padding(3, 2, 3, 2);
            numericUpDown1.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(340, 23);
            numericUpDown1.TabIndex = 2;
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic);
            label7.Location = new Point(136, 145);
            label7.Name = "label7";
            label7.Size = new Size(340, 64);
            label7.TabIndex = 5;
            label7.Text = "Ví dụ: Muốn lưu trữ số thứ tự thẻ dạng A001122 \r\nthì phần chữ nhập chữ A, \r\nsố ký tự số chọn \"000000\", \r\nphần STT nhập 001122";
            // 
            // label6
            // 
            label6.Location = new Point(282, 121);
            label6.Name = "label6";
            label6.Size = new Size(195, 17);
            label6.TabIndex = 4;
            label6.Text = "Số ký tự số (*)";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Location = new Point(136, 120);
            label5.Name = "label5";
            label5.Size = new Size(140, 17);
            label5.TabIndex = 4;
            label5.Text = "Phần chữ";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtLetter
            // 
            txtLetter.Location = new Point(136, 98);
            txtLetter.Margin = new Padding(3, 2, 3, 2);
            txtLetter.Name = "txtLetter";
            txtLetter.Size = new Size(140, 23);
            txtLetter.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(10, 74);
            label8.Name = "label8";
            label8.Size = new Size(25, 15);
            label8.TabIndex = 0;
            label8.Text = "STT";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnStop);
            groupBox2.Controls.Add(btnStart);
            groupBox2.Controls.Add(cbController);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(501, 14);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(486, 220);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin thẻ";
            // 
            // btnStop
            // 
            btnStop.Location = new Point(214, 45);
            btnStop.Margin = new Padding(3, 2, 3, 2);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(73, 28);
            btnStop.TabIndex = 7;
            btnStop.Text = "Dừng";
            btnStop.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(136, 45);
            btnStart.Margin = new Padding(3, 2, 3, 2);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(73, 28);
            btnStart.TabIndex = 6;
            btnStart.Text = "Bắt đầu";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click_1;
            // 
            // lsbShow
            // 
            lsbShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lsbShow.FormattingEnabled = true;
            lsbShow.ItemHeight = 15;
            lsbShow.Location = new Point(10, 238);
            lsbShow.Margin = new Padding(3, 2, 3, 2);
            lsbShow.Name = "lsbShow";
            lsbShow.Size = new Size(977, 304);
            lsbShow.TabIndex = 2;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(997, 547);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(lsbShow);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng ký thẻ";
            Load += frmMain_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private ComboBox cbIdentityGroup;
        private ComboBox cbFormat;
        private Label label2;
        private Label label3;
        private ComboBox cbController;
        private Label label4;
        private ComboBox cbIdentityType;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnStart;
        private Button btnStop;
        private TextBox txtLetter;
        private Label label7;
        private Label label6;
        private Label label5;
        private System.Windows.Forms.ListBox lsbShow;
        private NumericUpDown numericUpDown1;
        private Label label8;
    }
}