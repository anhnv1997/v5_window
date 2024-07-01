namespace iParkingv5_window.Forms
{
    partial class frmSelectWarehouseType
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
            lblCurrentType = new Label();
            button2 = new Button();
            button1 = new Button();
            label2 = new Label();
            label1 = new Label();
            cbWarehouseService = new ComboBox();
            SuspendLayout();
            // 
            // lblCurrentType
            // 
            lblCurrentType.AutoSize = true;
            lblCurrentType.Location = new Point(147, 9);
            lblCurrentType.Name = "lblCurrentType";
            lblCurrentType.Size = new Size(17, 21);
            lblCurrentType.TabIndex = 14;
            lblCurrentType.Text = "_";
            // 
            // button2
            // 
            button2.DialogResult = DialogResult.Cancel;
            button2.Location = new Point(392, 134);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(113, 51);
            button2.TabIndex = 2;
            button2.Text = "Đóng";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.OK;
            button1.Location = new Point(266, 134);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(118, 51);
            button1.TabIndex = 1;
            button1.Text = "Xác nhận";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 42);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(94, 21);
            label2.TabIndex = 12;
            label2.Text = "Dịch vụ mới";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(117, 21);
            label1.TabIndex = 13;
            label1.Text = "Dịch vụ hiện tại";
            // 
            // cbWarehouseService
            // 
            cbWarehouseService.DropDownStyle = ComboBoxStyle.DropDownList;
            cbWarehouseService.FormattingEnabled = true;
            cbWarehouseService.Items.AddRange(new object[] { "Nhập", "Xuất", "Sang Tải", "Khác" });
            cbWarehouseService.Location = new Point(147, 39);
            cbWarehouseService.Name = "cbWarehouseService";
            cbWarehouseService.Size = new Size(356, 29);
            cbWarehouseService.TabIndex = 0;
            // 
            // frmSelectWarehouseType
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(515, 188);
            Controls.Add(cbWarehouseService);
            Controls.Add(lblCurrentType);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F);
            KeyPreview = true;
            Margin = new Padding(4);
            Name = "frmSelectWarehouseType";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Loại dịch vụ";
            KeyDown += frmSelectWarehouseType_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblCurrentType;
        private Button button2;
        private Button button1;
        private Label label2;
        private Label label1;
        private ComboBox cbWarehouseService;
    }
}