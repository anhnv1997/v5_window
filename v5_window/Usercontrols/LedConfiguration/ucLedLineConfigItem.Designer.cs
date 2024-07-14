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
            txtDisplaytext = new TextBox();
            SuspendLayout();
            // 
            // cbDisplayMode
            // 
            cbDisplayMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDisplayMode.FormattingEnabled = true;
            cbDisplayMode.Items.AddRange(new object[] { "Để Trống", "Mã Thẻ", "Số Thẻ", "Loại Thẻ", "Loại Sự Kiện", "Biển Số Xe", "Thời Gian Vào", "Thời Gian Ra", "Phí Gửi Xe", "Tùy Chọn" });
            cbDisplayMode.Location = new Point(87, 11);
            cbDisplayMode.Margin = new Padding(4, 3, 4, 3);
            cbDisplayMode.Name = "cbDisplayMode";
            cbDisplayMode.Size = new Size(225, 29);
            cbDisplayMode.TabIndex = 0;
            cbDisplayMode.SelectedIndexChanged += cbDisplayMode_SelectedIndexChanged;
            // 
            // lblLineName
            // 
            lblLineName.AutoSize = true;
            lblLineName.Location = new Point(4, 14);
            lblLineName.Margin = new Padding(4, 0, 4, 0);
            lblLineName.Name = "lblLineName";
            lblLineName.Size = new Size(59, 21);
            lblLineName.TabIndex = 1;
            lblLineName.Text = "Dòng _";
            // 
            // cbColor
            // 
            cbColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbColor.FormattingEnabled = true;
            cbColor.Items.AddRange(new object[] { "Đỏ", "Xanh Lá", "Vàng", "Xanh Da Trời", "Tím", "Lục Lam", "Trắng" });
            cbColor.Location = new Point(320, 11);
            cbColor.Margin = new Padding(4, 3, 4, 3);
            cbColor.Name = "cbColor";
            cbColor.Size = new Size(135, 29);
            cbColor.TabIndex = 2;
            // 
            // cbFontSize
            // 
            cbFontSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFontSize.FormattingEnabled = true;
            cbFontSize.Items.AddRange(new object[] { "Cỡ Chữ: 7", "Cỡ Chữ: 8", "Cỡ Chữ: 10", "Cỡ Chữ: 12", "Cỡ Chữ: 13", "Cỡ Chữ: 14", "Cỡ Chữ: 16", "Cỡ Chữ: 23", "Cỡ Chữ: 24", "Cỡ Chữ: 25", "Cỡ Chữ: 26" });
            cbFontSize.Location = new Point(463, 11);
            cbFontSize.Margin = new Padding(4, 3, 4, 3);
            cbFontSize.Name = "cbFontSize";
            cbFontSize.Size = new Size(135, 29);
            cbFontSize.TabIndex = 3;
            // 
            // txtDisplaytext
            // 
            txtDisplaytext.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDisplaytext.Location = new Point(607, 11);
            txtDisplaytext.Margin = new Padding(4, 3, 4, 3);
            txtDisplaytext.Name = "txtDisplaytext";
            txtDisplaytext.Size = new Size(220, 29);
            txtDisplaytext.TabIndex = 4;
            txtDisplaytext.Visible = false;
            // 
            // ucLedLineConfigItem
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtDisplaytext);
            Controls.Add(cbFontSize);
            Controls.Add(cbColor);
            Controls.Add(lblLineName);
            Controls.Add(cbDisplayMode);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ucLedLineConfigItem";
            Size = new Size(831, 48);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbDisplayMode;
        private Label lblLineName;
        private ComboBox cbColor;
        private ComboBox cbFontSize;
        private TextBox txtDisplaytext;
    }
}
