namespace iParkingv5_window.Usercontrols
{
    partial class ucLedLineConfigItem
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
            cbDisplayMode = new ComboBox();
            lblLineName = new Label();
            cbColor = new ComboBox();
            cbFontSize = new ComboBox();
            SuspendLayout();
            // 
            // cbDisplayMode
            // 
            cbDisplayMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDisplayMode.FormattingEnabled = true;
            cbDisplayMode.Items.AddRange(new object[] { "Để Trống", "Mã Thẻ", "Số Thẻ", "Loại Thẻ", "Loại Sự Kiện", "Biển Số Xe", "Thời Gian Vào", "Thời Gian Ra", "Phí Gửi Xe" });
            cbDisplayMode.Location = new Point(78, 10);
            cbDisplayMode.Name = "cbDisplayMode";
            cbDisplayMode.Size = new Size(201, 28);
            cbDisplayMode.TabIndex = 0;
            // 
            // lblLineName
            // 
            lblLineName.AutoSize = true;
            lblLineName.Location = new Point(3, 13);
            lblLineName.Name = "lblLineName";
            lblLineName.Size = new Size(56, 20);
            lblLineName.TabIndex = 1;
            lblLineName.Text = "Dòng _";
            // 
            // cbColor
            // 
            cbColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbColor.FormattingEnabled = true;
            cbColor.Items.AddRange(new object[] { "Đỏ", "Xanh Lá", "Vàng", "Xanh Da Trời", "Tím", "Lục Lam", "Trắng" });
            cbColor.Location = new Point(285, 10);
            cbColor.Name = "cbColor";
            cbColor.Size = new Size(121, 28);
            cbColor.TabIndex = 2;
            // 
            // cbFontSize
            // 
            cbFontSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFontSize.FormattingEnabled = true;
            cbFontSize.Items.AddRange(new object[] { "Cỡ Chữ: 7", "Cỡ Chữ: 8", "Cỡ Chữ: 10", "Cỡ Chữ: 12", "Cỡ Chữ: 13", "Cỡ Chữ: 14", "Cỡ Chữ: 16", "Cỡ Chữ: 23", "Cỡ Chữ: 24", "Cỡ Chữ: 25", "Cỡ Chữ: 26" });
            cbFontSize.Location = new Point(412, 10);
            cbFontSize.Name = "cbFontSize";
            cbFontSize.Size = new Size(121, 28);
            cbFontSize.TabIndex = 3;
            // 
            // ucLedLineConfigItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cbFontSize);
            Controls.Add(cbColor);
            Controls.Add(lblLineName);
            Controls.Add(cbDisplayMode);
            Name = "ucLedLineConfigItem";
            Size = new Size(540, 46);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbDisplayMode;
        private Label lblLineName;
        private ComboBox cbColor;
        private ComboBox cbFontSize;
    }
}
