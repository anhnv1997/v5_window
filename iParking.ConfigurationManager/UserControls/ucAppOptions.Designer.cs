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
            numRetakePhotoDelayTime = new NumericUpDown();
            numRetakePhotoTurn = new NumericUpDown();
            label12 = new Label();
            chbIsAllowEditPlateOut = new CheckBox();
            chbIsSaveLog = new CheckBox();
            label10 = new Label();
            label3 = new Label();
            label11 = new Label();
            numLoopDelay = new NumericUpDown();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            cbPrintTemplate = new ComboBox();
            txtUpdatePath = new TextBox();
            txtWaitSwipeCardTime = new TextBox();
            txtAllowOpenBarrieTime = new TextBox();
            label5 = new Label();
            label1 = new Label();
            label2 = new Label();
            chbIsIntergratedScaleStation = new CheckBox();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numRetakePhotoDelayTime).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRetakePhotoTurn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numLoopDelay).BeginInit();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.AutoSize = true;
            groupBox2.Controls.Add(chbIsIntergratedScaleStation);
            groupBox2.Controls.Add(numRetakePhotoDelayTime);
            groupBox2.Controls.Add(numRetakePhotoTurn);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(chbIsAllowEditPlateOut);
            groupBox2.Controls.Add(chbIsSaveLog);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(numLoopDelay);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(cbPrintTemplate);
            groupBox2.Controls.Add(txtUpdatePath);
            groupBox2.Controls.Add(txtWaitSwipeCardTime);
            groupBox2.Controls.Add(txtAllowOpenBarrieTime);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(label2);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(571, 291);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tùy chọn";
            // 
            // numRetakePhotoDelayTime
            // 
            numRetakePhotoDelayTime.Location = new Point(191, 150);
            numRetakePhotoDelayTime.Margin = new Padding(3, 2, 3, 2);
            numRetakePhotoDelayTime.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numRetakePhotoDelayTime.Name = "numRetakePhotoDelayTime";
            numRetakePhotoDelayTime.Size = new Size(334, 23);
            numRetakePhotoDelayTime.TabIndex = 6;
            // 
            // numRetakePhotoTurn
            // 
            numRetakePhotoTurn.Location = new Point(191, 123);
            numRetakePhotoTurn.Margin = new Padding(3, 2, 3, 2);
            numRetakePhotoTurn.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numRetakePhotoTurn.Name = "numRetakePhotoTurn";
            numRetakePhotoTurn.Size = new Size(334, 23);
            numRetakePhotoTurn.TabIndex = 6;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(539, 153);
            label12.Name = "label12";
            label12.Size = new Size(23, 15);
            label12.TabIndex = 7;
            label12.Text = "ms";
            // 
            // chbIsAllowEditPlateOut
            // 
            chbIsAllowEditPlateOut.AutoSize = true;
            chbIsAllowEditPlateOut.Location = new Point(191, 227);
            chbIsAllowEditPlateOut.Margin = new Padding(3, 2, 3, 2);
            chbIsAllowEditPlateOut.Name = "chbIsAllowEditPlateOut";
            chbIsAllowEditPlateOut.Size = new Size(153, 19);
            chbIsAllowEditPlateOut.TabIndex = 8;
            chbIsAllowEditPlateOut.Text = "Cho phép sửa biển số ra";
            chbIsAllowEditPlateOut.UseVisualStyleBackColor = true;
            // 
            // chbIsSaveLog
            // 
            chbIsSaveLog.AutoSize = true;
            chbIsSaveLog.Location = new Point(191, 204);
            chbIsSaveLog.Margin = new Padding(3, 2, 3, 2);
            chbIsSaveLog.Name = "chbIsSaveLog";
            chbIsSaveLog.Size = new Size(117, 19);
            chbIsSaveLog.TabIndex = 8;
            chbIsSaveLog.Text = "Lưu log hệ thống";
            chbIsSaveLog.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(539, 126);
            label10.Name = "label10";
            label10.Size = new Size(23, 15);
            label10.TabIndex = 7;
            label10.Text = "lần";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 180);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 7;
            label3.Text = "Update Path";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(5, 151);
            label11.Name = "label11";
            label11.Size = new Size(93, 15);
            label11.TabIndex = 7;
            label11.Text = "Delay chụp hình";
            // 
            // numLoopDelay
            // 
            numLoopDelay.Location = new Point(191, 96);
            numLoopDelay.Margin = new Padding(3, 2, 3, 2);
            numLoopDelay.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numLoopDelay.Name = "numLoopDelay";
            numLoopDelay.Size = new Size(334, 23);
            numLoopDelay.TabIndex = 6;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(5, 124);
            label9.Name = "label9";
            label9.Size = new Size(111, 15);
            label9.TabIndex = 7;
            label9.Text = "Số lần chụp lại hình";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(539, 99);
            label8.Name = "label8";
            label8.Size = new Size(23, 15);
            label8.TabIndex = 7;
            label8.Text = "ms";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(5, 98);
            label7.Name = "label7";
            label7.Size = new Size(66, 15);
            label7.TabIndex = 7;
            label7.Text = "Loop Delay";
            // 
            // cbPrintTemplate
            // 
            cbPrintTemplate.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPrintTemplate.FormattingEnabled = true;
            cbPrintTemplate.Location = new Point(191, 69);
            cbPrintTemplate.Margin = new Padding(3, 2, 3, 2);
            cbPrintTemplate.Name = "cbPrintTemplate";
            cbPrintTemplate.Size = new Size(376, 23);
            cbPrintTemplate.TabIndex = 2;
            // 
            // txtUpdatePath
            // 
            txtUpdatePath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUpdatePath.Location = new Point(191, 177);
            txtUpdatePath.Margin = new Padding(3, 2, 3, 2);
            txtUpdatePath.Name = "txtUpdatePath";
            txtUpdatePath.PlaceholderText = "Đường dẫn chứa file update";
            txtUpdatePath.Size = new Size(378, 23);
            txtUpdatePath.TabIndex = 7;
            // 
            // txtWaitSwipeCardTime
            // 
            txtWaitSwipeCardTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtWaitSwipeCardTime.Location = new Point(191, 42);
            txtWaitSwipeCardTime.Margin = new Padding(3, 2, 3, 2);
            txtWaitSwipeCardTime.Name = "txtWaitSwipeCardTime";
            txtWaitSwipeCardTime.PlaceholderText = "Thời gian giữa 2 lần quẹt thẻ liên tiếp (s)";
            txtWaitSwipeCardTime.Size = new Size(378, 23);
            txtWaitSwipeCardTime.TabIndex = 1;
            // 
            // txtAllowOpenBarrieTime
            // 
            txtAllowOpenBarrieTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAllowOpenBarrieTime.Location = new Point(191, 15);
            txtAllowOpenBarrieTime.Margin = new Padding(3, 2, 3, 2);
            txtAllowOpenBarrieTime.Name = "txtAllowOpenBarrieTime";
            txtAllowOpenBarrieTime.PlaceholderText = "Thời gian cho phép mở barrie (s)";
            txtAllowOpenBarrieTime.Size = new Size(376, 23);
            txtAllowOpenBarrieTime.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(5, 72);
            label5.Name = "label5";
            label5.Size = new Size(75, 15);
            label5.TabIndex = 2;
            label5.Text = "Loại phiếu in";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 44);
            label1.Name = "label1";
            label1.Size = new Size(126, 15);
            label1.TabIndex = 2;
            label1.Text = "Thời gian chờ quẹt thẻ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(5, 17);
            label2.Name = "label2";
            label2.Size = new Size(163, 15);
            label2.TabIndex = 2;
            label2.Text = "Thời gian cho phép mở barrie";
            // 
            // chbIsIntergratedScaleStation
            // 
            chbIsIntergratedScaleStation.AutoSize = true;
            chbIsIntergratedScaleStation.Location = new Point(191, 251);
            chbIsIntergratedScaleStation.Name = "chbIsIntergratedScaleStation";
            chbIsIntergratedScaleStation.Size = new Size(145, 19);
            chbIsIntergratedScaleStation.TabIndex = 9;
            chbIsIntergratedScaleStation.Text = "Tích hợp hệ thống cân";
            chbIsIntergratedScaleStation.UseVisualStyleBackColor = true;
            // 
            // ucAppOptions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox2);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ucAppOptions";
            Size = new Size(571, 296);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numRetakePhotoDelayTime).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRetakePhotoTurn).EndInit();
            ((System.ComponentModel.ISupportInitialize)numLoopDelay).EndInit();
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
        private Label label6;
        private CheckBox chbIsSaveLog;
        private NumericUpDown numLoopDelay;
        private Label label8;
        private Label label7;
        private NumericUpDown numRetakePhotoDelayTime;
        private NumericUpDown numRetakePhotoTurn;
        private Label label12;
        private Label label10;
        private Label label11;
        private Label label9;
        private TextBox txtUpdatePath;
        private CheckBox chbIsAllowEditPlateOut;
        private CheckBox chbIsIntergratedScaleStation;
    }
}
