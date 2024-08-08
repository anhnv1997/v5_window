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
            chbIsCheckKey = new CheckBox();
            chbIsUseInvoice = new CheckBox();
            chbIsIntergratedScaleStation = new CheckBox();
            numRetakePhotoDelayTime = new NumericUpDown();
            numRetakePhotoTurn = new NumericUpDown();
            label12 = new Label();
            chbIsAllowEditPlateOut = new CheckBox();
            chbIsSaveLog = new CheckBox();
            label10 = new Label();
            label3 = new Label();
            label11 = new Label();
            numAutoReturnDialogTime = new NumericUpDown();
            numLoopDelay = new NumericUpDown();
            label14 = new Label();
            label9 = new Label();
            label13 = new Label();
            label8 = new Label();
            label7 = new Label();
            cbAutoReturnDialogResult = new ComboBox();
            cbPrintTemplate = new ComboBox();
            txtUpdatePath = new TextBox();
            txtWaitSwipeCardTime = new TextBox();
            label15 = new Label();
            txtAllowOpenBarrieTime = new TextBox();
            label5 = new Label();
            label1 = new Label();
            label2 = new Label();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numRetakePhotoDelayTime).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRetakePhotoTurn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numAutoReturnDialogTime).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numLoopDelay).BeginInit();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.AutoSize = true;
            groupBox2.Controls.Add(chbIsCheckKey);
            groupBox2.Controls.Add(chbIsUseInvoice);
            groupBox2.Controls.Add(chbIsIntergratedScaleStation);
            groupBox2.Controls.Add(numRetakePhotoDelayTime);
            groupBox2.Controls.Add(numRetakePhotoTurn);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(chbIsAllowEditPlateOut);
            groupBox2.Controls.Add(chbIsSaveLog);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(numAutoReturnDialogTime);
            groupBox2.Controls.Add(numLoopDelay);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(cbAutoReturnDialogResult);
            groupBox2.Controls.Add(cbPrintTemplate);
            groupBox2.Controls.Add(txtUpdatePath);
            groupBox2.Controls.Add(txtWaitSwipeCardTime);
            groupBox2.Controls.Add(label15);
            groupBox2.Controls.Add(txtAllowOpenBarrieTime);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(label2);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(734, 530);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tùy chọn";
            // 
            // chbIsCheckKey
            // 
            chbIsCheckKey.AutoSize = true;
            chbIsCheckKey.Location = new Point(246, 476);
            chbIsCheckKey.Margin = new Padding(4);
            chbIsCheckKey.Name = "chbIsCheckKey";
            chbIsCheckKey.Size = new Size(115, 25);
            chbIsCheckKey.TabIndex = 13;
            chbIsCheckKey.Text = "Kiểm tra key";
            chbIsCheckKey.UseVisualStyleBackColor = true;
            chbIsCheckKey.Visible = false;
            // 
            // chbIsUseInvoice
            // 
            chbIsUseInvoice.AutoSize = true;
            chbIsUseInvoice.Location = new Point(246, 443);
            chbIsUseInvoice.Margin = new Padding(4);
            chbIsUseInvoice.Name = "chbIsUseInvoice";
            chbIsUseInvoice.Size = new Size(203, 25);
            chbIsUseInvoice.TabIndex = 12;
            chbIsUseInvoice.Text = "Tích hợp hóa đơn điện tử";
            chbIsUseInvoice.UseVisualStyleBackColor = true;
            // 
            // chbIsIntergratedScaleStation
            // 
            chbIsIntergratedScaleStation.AutoSize = true;
            chbIsIntergratedScaleStation.Location = new Point(246, 414);
            chbIsIntergratedScaleStation.Margin = new Padding(4);
            chbIsIntergratedScaleStation.Name = "chbIsIntergratedScaleStation";
            chbIsIntergratedScaleStation.Size = new Size(183, 25);
            chbIsIntergratedScaleStation.TabIndex = 11;
            chbIsIntergratedScaleStation.Text = "Tích hợp hệ thống cân";
            chbIsIntergratedScaleStation.UseVisualStyleBackColor = true;
            // 
            // numRetakePhotoDelayTime
            // 
            numRetakePhotoDelayTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numRetakePhotoDelayTime.Location = new Point(246, 210);
            numRetakePhotoDelayTime.Margin = new Padding(4, 3, 4, 3);
            numRetakePhotoDelayTime.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numRetakePhotoDelayTime.Name = "numRetakePhotoDelayTime";
            numRetakePhotoDelayTime.Size = new Size(429, 29);
            numRetakePhotoDelayTime.TabIndex = 5;
            // 
            // numRetakePhotoTurn
            // 
            numRetakePhotoTurn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numRetakePhotoTurn.Location = new Point(246, 172);
            numRetakePhotoTurn.Margin = new Padding(4, 3, 4, 3);
            numRetakePhotoTurn.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numRetakePhotoTurn.Name = "numRetakePhotoTurn";
            numRetakePhotoTurn.Size = new Size(429, 29);
            numRetakePhotoTurn.TabIndex = 4;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(693, 214);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(31, 21);
            label12.TabIndex = 7;
            label12.Text = "ms";
            // 
            // chbIsAllowEditPlateOut
            // 
            chbIsAllowEditPlateOut.AutoSize = true;
            chbIsAllowEditPlateOut.Location = new Point(246, 385);
            chbIsAllowEditPlateOut.Margin = new Padding(4, 3, 4, 3);
            chbIsAllowEditPlateOut.Name = "chbIsAllowEditPlateOut";
            chbIsAllowEditPlateOut.Size = new Size(196, 25);
            chbIsAllowEditPlateOut.TabIndex = 10;
            chbIsAllowEditPlateOut.Text = "Cho phép sửa biển số ra";
            chbIsAllowEditPlateOut.UseVisualStyleBackColor = true;
            // 
            // chbIsSaveLog
            // 
            chbIsSaveLog.AutoSize = true;
            chbIsSaveLog.Location = new Point(246, 353);
            chbIsSaveLog.Margin = new Padding(4, 3, 4, 3);
            chbIsSaveLog.Name = "chbIsSaveLog";
            chbIsSaveLog.Size = new Size(147, 25);
            chbIsSaveLog.TabIndex = 9;
            chbIsSaveLog.Text = "Lưu log hệ thống";
            chbIsSaveLog.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(693, 176);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(31, 21);
            label10.TabIndex = 7;
            label10.Text = "lần";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 251);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(94, 21);
            label3.TabIndex = 7;
            label3.Text = "Update Path";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(6, 211);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(122, 21);
            label11.TabIndex = 7;
            label11.Text = "Delay chụp hình";
            // 
            // numAutoReturnDialogTime
            // 
            numAutoReturnDialogTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numAutoReturnDialogTime.Location = new Point(246, 283);
            numAutoReturnDialogTime.Margin = new Padding(4, 3, 4, 3);
            numAutoReturnDialogTime.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numAutoReturnDialogTime.Name = "numAutoReturnDialogTime";
            numAutoReturnDialogTime.Size = new Size(429, 29);
            numAutoReturnDialogTime.TabIndex = 7;
            // 
            // numLoopDelay
            // 
            numLoopDelay.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numLoopDelay.Location = new Point(246, 134);
            numLoopDelay.Margin = new Padding(4, 3, 4, 3);
            numLoopDelay.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numLoopDelay.Name = "numLoopDelay";
            numLoopDelay.Size = new Size(429, 29);
            numLoopDelay.TabIndex = 3;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(693, 285);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(17, 21);
            label14.TabIndex = 7;
            label14.Text = "s";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 174);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(146, 21);
            label9.TabIndex = 7;
            label9.Text = "Số lần chụp lại hình";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(6, 285);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(202, 21);
            label13.TabIndex = 7;
            label13.Text = "Tự động đóng cảnh báo sau";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(693, 139);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(31, 21);
            label8.TabIndex = 7;
            label8.Text = "ms";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 137);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(88, 21);
            label7.TabIndex = 7;
            label7.Text = "Loop Delay";
            // 
            // cbAutoReturnDialogResult
            // 
            cbAutoReturnDialogResult.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbAutoReturnDialogResult.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAutoReturnDialogResult.FormattingEnabled = true;
            cbAutoReturnDialogResult.Items.AddRange(new object[] { "Xác nhận", "Không xác nhận" });
            cbAutoReturnDialogResult.Location = new Point(246, 318);
            cbAutoReturnDialogResult.Margin = new Padding(4, 3, 4, 3);
            cbAutoReturnDialogResult.Name = "cbAutoReturnDialogResult";
            cbAutoReturnDialogResult.Size = new Size(478, 29);
            cbAutoReturnDialogResult.TabIndex = 8;
            // 
            // cbPrintTemplate
            // 
            cbPrintTemplate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbPrintTemplate.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPrintTemplate.FormattingEnabled = true;
            cbPrintTemplate.Location = new Point(246, 97);
            cbPrintTemplate.Margin = new Padding(4, 3, 4, 3);
            cbPrintTemplate.Name = "cbPrintTemplate";
            cbPrintTemplate.Size = new Size(478, 29);
            cbPrintTemplate.TabIndex = 2;
            // 
            // txtUpdatePath
            // 
            txtUpdatePath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUpdatePath.Location = new Point(246, 248);
            txtUpdatePath.Margin = new Padding(4, 3, 4, 3);
            txtUpdatePath.Name = "txtUpdatePath";
            txtUpdatePath.PlaceholderText = "Đường dẫn chứa file update";
            txtUpdatePath.Size = new Size(478, 29);
            txtUpdatePath.TabIndex = 6;
            // 
            // txtWaitSwipeCardTime
            // 
            txtWaitSwipeCardTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtWaitSwipeCardTime.Location = new Point(246, 59);
            txtWaitSwipeCardTime.Margin = new Padding(4, 3, 4, 3);
            txtWaitSwipeCardTime.Name = "txtWaitSwipeCardTime";
            txtWaitSwipeCardTime.PlaceholderText = "Thời gian giữa 2 lần quẹt thẻ liên tiếp (s)";
            txtWaitSwipeCardTime.Size = new Size(481, 29);
            txtWaitSwipeCardTime.TabIndex = 1;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(6, 322);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(160, 21);
            label15.TabIndex = 2;
            label15.Text = "Kết quả tự động đóng";
            // 
            // txtAllowOpenBarrieTime
            // 
            txtAllowOpenBarrieTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAllowOpenBarrieTime.Location = new Point(246, 21);
            txtAllowOpenBarrieTime.Margin = new Padding(4, 3, 4, 3);
            txtAllowOpenBarrieTime.Name = "txtAllowOpenBarrieTime";
            txtAllowOpenBarrieTime.PlaceholderText = "Thời gian cho phép mở barrie (s)";
            txtAllowOpenBarrieTime.Size = new Size(478, 29);
            txtAllowOpenBarrieTime.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 101);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(99, 21);
            label5.TabIndex = 2;
            label5.Text = "Loại phiếu in";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 62);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(166, 21);
            label1.TabIndex = 2;
            label1.Text = "Thời gian chờ quẹt thẻ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 24);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(216, 21);
            label2.TabIndex = 2;
            label2.Text = "Thời gian cho phép mở barrie";
            // 
            // ucAppOptions
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            Controls.Add(groupBox2);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ucAppOptions";
            Size = new Size(734, 556);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numRetakePhotoDelayTime).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRetakePhotoTurn).EndInit();
            ((System.ComponentModel.ISupportInitialize)numAutoReturnDialogTime).EndInit();
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
        private CheckBox chbIsCheckKey;
        private CheckBox chbIsUseInvoice;
        private NumericUpDown numAutoReturnDialogTime;
        private Label label14;
        private Label label13;
        private ComboBox cbAutoReturnDialogResult;
        private Label label15;
    }
}
