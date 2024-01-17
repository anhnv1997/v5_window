namespace iParking.ConfigurationManager.UserControls
{
    partial class ucAppOptions
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
            groupBox2 = new GroupBox();
            txtAllowOpenBarrieTime = new TextBox();
            label2 = new Label();
            txtWaitSwipeCardTime = new TextBox();
            label1 = new Label();
            cbPrintTemplate = new ComboBox();
            label5 = new Label();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.AutoSize = true;
            groupBox2.Controls.Add(cbPrintTemplate);
            groupBox2.Controls.Add(txtWaitSwipeCardTime);
            groupBox2.Controls.Add(txtAllowOpenBarrieTime);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(label2);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(653, 140);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tùy chọn";
            // 
            // txtAllowOpenBarrieTime
            // 
            txtAllowOpenBarrieTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAllowOpenBarrieTime.Location = new Point(218, 20);
            txtAllowOpenBarrieTime.Name = "txtAllowOpenBarrieTime";
            txtAllowOpenBarrieTime.PlaceholderText = "Thời gian cho phép mở barrie (s)";
            txtAllowOpenBarrieTime.Size = new Size(432, 27);
            txtAllowOpenBarrieTime.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 23);
            label2.Name = "label2";
            label2.Size = new Size(206, 20);
            label2.TabIndex = 2;
            label2.Text = "Thời gian cho phép mở barrie";
            // 
            // txtWaitSwipeCardTime
            // 
            txtWaitSwipeCardTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtWaitSwipeCardTime.Location = new Point(215, 53);
            txtWaitSwipeCardTime.Name = "txtWaitSwipeCardTime";
            txtWaitSwipeCardTime.PlaceholderText = "Thời gian giữa 2 lần quẹt thẻ liên tiếp (s)";
            txtWaitSwipeCardTime.Size = new Size(432, 27);
            txtWaitSwipeCardTime.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 56);
            label1.Name = "label1";
            label1.Size = new Size(158, 20);
            label1.TabIndex = 2;
            label1.Text = "Thời gian chờ quẹt thẻ";
            // 
            // cbPrintTemplate
            // 
            cbPrintTemplate.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPrintTemplate.FormattingEnabled = true;
            cbPrintTemplate.Location = new Point(218, 86);
            cbPrintTemplate.Name = "cbPrintTemplate";
            cbPrintTemplate.Size = new Size(429, 28);
            cbPrintTemplate.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 89);
            label5.Name = "label5";
            label5.Size = new Size(94, 20);
            label5.TabIndex = 2;
            label5.Text = "Loại phiếu in";
            // 
            // ucAppOptions
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox2);
            Name = "ucAppOptions";
            Size = new Size(653, 395);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox2;
        private Label label4;
        private Label label3;
        private TextBox txtAction;
        private TextBox txtTemplateFile;
        private TextBox txtAllowOpenBarrieTime;
        private Label label2;
        private ComboBox cbPrintTemplate;
        private TextBox txtWaitSwipeCardTime;
        private Label label5;
        private Label label1;
    }
}
