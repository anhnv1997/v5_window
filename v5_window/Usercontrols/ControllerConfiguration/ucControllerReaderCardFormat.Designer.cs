namespace iParkingv5_window.Usercontrols.ControllerConfiguration
{
    partial class ucControllerReaderCardFormat
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
            cbInputFormat = new ComboBox();
            label1 = new Label();
            cbOutputFormat = new ComboBox();
            label2 = new Label();
            cbConfigOption = new ComboBox();
            label3 = new Label();
            lblReaderName = new Label();
            SuspendLayout();
            // 
            // cbInputFormat
            // 
            cbInputFormat.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbInputFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            cbInputFormat.FormattingEnabled = true;
            cbInputFormat.Location = new Point(134, 43);
            cbInputFormat.Name = "cbInputFormat";
            cbInputFormat.Size = new Size(351, 29);
            cbInputFormat.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 43);
            label1.Name = "label1";
            label1.Size = new Size(111, 21);
            label1.TabIndex = 1;
            label1.Text = "Định dạng vào";
            // 
            // cbOutputFormat
            // 
            cbOutputFormat.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbOutputFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            cbOutputFormat.FormattingEnabled = true;
            cbOutputFormat.Location = new Point(134, 78);
            cbOutputFormat.Name = "cbOutputFormat";
            cbOutputFormat.Size = new Size(351, 29);
            cbOutputFormat.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 78);
            label2.Name = "label2";
            label2.Size = new Size(100, 21);
            label2.TabIndex = 1;
            label2.Text = "Định dạng ra";
            // 
            // cbConfigOption
            // 
            cbConfigOption.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbConfigOption.DropDownStyle = ComboBoxStyle.DropDownList;
            cbConfigOption.FormattingEnabled = true;
            cbConfigOption.Location = new Point(134, 113);
            cbConfigOption.Name = "cbConfigOption";
            cbConfigOption.Size = new Size(351, 29);
            cbConfigOption.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 113);
            label3.Name = "label3";
            label3.Size = new Size(66, 21);
            label3.TabIndex = 1;
            label3.Text = "Bổ sung";
            // 
            // lblReaderName
            // 
            lblReaderName.AutoSize = true;
            lblReaderName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblReaderName.Location = new Point(17, 10);
            lblReaderName.Name = "lblReaderName";
            lblReaderName.Size = new Size(57, 21);
            lblReaderName.TabIndex = 2;
            lblReaderName.Text = "label4";
            // 
            // ucControllerReaderCardFormat
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblReaderName);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(cbOutputFormat);
            Controls.Add(cbConfigOption);
            Controls.Add(cbInputFormat);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            MaximumSize = new Size(500, 150);
            Name = "ucControllerReaderCardFormat";
            Size = new Size(500, 150);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbInputFormat;
        private Label label1;
        private ComboBox cbOutputFormat;
        private Label label2;
        private ComboBox cbConfigOption;
        private Label label3;
        private Label lblReaderName;
    }
}
