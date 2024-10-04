namespace iParkingv5_window.Usercontrols.LaneConfiguration
{
    partial class ucLaneDirectionConfig
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
            lblDisplayDirection = new Label();
            cbDisplayDirection = new ComboBox();
            chbIsDisplayTitle = new CheckBox();
            chbIsDisplayLastEvent = new CheckBox();
            cbCameraDirection = new ComboBox();
            cbPicDiection = new ComboBox();
            lblCameraDirection = new Label();
            lblPicDirection = new Label();
            cbCameraPicDirection = new ComboBox();
            lblCameraPicDirection = new Label();
            cbEventDirection = new ComboBox();
            lblEventDirection = new Label();
            cbCamScale = new ComboBox();
            lblCamScale = new Label();
            SuspendLayout();
            // 
            // lblDisplayDirection
            // 
            lblDisplayDirection.AutoSize = true;
            lblDisplayDirection.Location = new Point(15, 11);
            lblDisplayDirection.Margin = new Padding(4, 0, 4, 0);
            lblDisplayDirection.Name = "lblDisplayDirection";
            lblDisplayDirection.Size = new Size(106, 21);
            lblDisplayDirection.TabIndex = 5;
            lblDisplayDirection.Text = "Chiều hiển thị";
            // 
            // cbDisplayDirection
            // 
            cbDisplayDirection.FormattingEnabled = true;
            cbDisplayDirection.Items.AddRange(new object[] { "Dọc", "Ngang từ trái sang phải", "Ngang từ phải sang trái", "Dọc Trái Qua Phải", "Dọc Phải Qua Trái" });
            cbDisplayDirection.Location = new Point(199, 8);
            cbDisplayDirection.Margin = new Padding(4, 3, 4, 3);
            cbDisplayDirection.Name = "cbDisplayDirection";
            cbDisplayDirection.Size = new Size(274, 29);
            cbDisplayDirection.TabIndex = 1;
            // 
            // chbIsDisplayTitle
            // 
            chbIsDisplayTitle.AutoSize = true;
            chbIsDisplayTitle.Location = new Point(199, 233);
            chbIsDisplayTitle.Margin = new Padding(4, 3, 4, 3);
            chbIsDisplayTitle.Name = "chbIsDisplayTitle";
            chbIsDisplayTitle.Size = new Size(134, 25);
            chbIsDisplayTitle.TabIndex = 6;
            chbIsDisplayTitle.Text = "Hiển thị tiêu đề";
            chbIsDisplayTitle.UseVisualStyleBackColor = true;
            // 
            // chbIsDisplayLastEvent
            // 
            chbIsDisplayLastEvent.AutoSize = true;
            chbIsDisplayLastEvent.Location = new Point(199, 265);
            chbIsDisplayLastEvent.Margin = new Padding(4, 3, 4, 3);
            chbIsDisplayLastEvent.Name = "chbIsDisplayLastEvent";
            chbIsDisplayLastEvent.Size = new Size(201, 25);
            chbIsDisplayLastEvent.TabIndex = 7;
            chbIsDisplayLastEvent.Text = "Hiển thị sự kiện gần nhất";
            chbIsDisplayLastEvent.UseVisualStyleBackColor = true;
            // 
            // cbCameraDirection
            // 
            cbCameraDirection.FormattingEnabled = true;
            cbCameraDirection.Items.AddRange(new object[] { "Dọc", "Ngang", "Bảng" });
            cbCameraDirection.Location = new Point(199, 46);
            cbCameraDirection.Margin = new Padding(4, 3, 4, 3);
            cbCameraDirection.Name = "cbCameraDirection";
            cbCameraDirection.Size = new Size(274, 29);
            cbCameraDirection.TabIndex = 2;
            // 
            // cbPicDiection
            // 
            cbPicDiection.FormattingEnabled = true;
            cbPicDiection.Items.AddRange(new object[] { "Dọc", "Ngang" });
            cbPicDiection.Location = new Point(199, 84);
            cbPicDiection.Margin = new Padding(4, 3, 4, 3);
            cbPicDiection.Name = "cbPicDiection";
            cbPicDiection.Size = new Size(274, 29);
            cbPicDiection.TabIndex = 3;
            // 
            // lblCameraDirection
            // 
            lblCameraDirection.AutoSize = true;
            lblCameraDirection.Location = new Point(15, 49);
            lblCameraDirection.Margin = new Padding(4, 0, 4, 0);
            lblCameraDirection.Name = "lblCameraDirection";
            lblCameraDirection.Size = new Size(113, 21);
            lblCameraDirection.TabIndex = 6;
            lblCameraDirection.Text = "Khung Camera";
            // 
            // lblPicDirection
            // 
            lblPicDirection.AutoSize = true;
            lblPicDirection.Location = new Point(15, 87);
            lblPicDirection.Margin = new Padding(4, 0, 4, 0);
            lblPicDirection.Name = "lblPicDirection";
            lblPicDirection.Size = new Size(124, 21);
            lblPicDirection.TabIndex = 6;
            lblPicDirection.Text = "Khung Hình Ảnh";
            // 
            // cbCameraPicDirection
            // 
            cbCameraPicDirection.FormattingEnabled = true;
            cbCameraPicDirection.Items.AddRange(new object[] { "Dọc", "Ngang từ trái sang phải", "Ngang từ phải sang trái" });
            cbCameraPicDirection.Location = new Point(199, 122);
            cbCameraPicDirection.Margin = new Padding(4, 3, 4, 3);
            cbCameraPicDirection.Name = "cbCameraPicDirection";
            cbCameraPicDirection.Size = new Size(274, 29);
            cbCameraPicDirection.TabIndex = 4;
            // 
            // lblCameraPicDirection
            // 
            lblCameraPicDirection.AutoSize = true;
            lblCameraPicDirection.Location = new Point(15, 125);
            lblCameraPicDirection.Margin = new Padding(4, 0, 4, 0);
            lblCameraPicDirection.Name = "lblCameraPicDirection";
            lblCameraPicDirection.Size = new Size(170, 21);
            lblCameraPicDirection.TabIndex = 6;
            lblCameraPicDirection.Text = "Khung Cam - Hình Ảnh";
            // 
            // cbEventDirection
            // 
            cbEventDirection.FormattingEnabled = true;
            cbEventDirection.Items.AddRange(new object[] { "Dọc", "Ngang từ trái sang phải", "Ngang từ phải sang trái" });
            cbEventDirection.Location = new Point(199, 160);
            cbEventDirection.Margin = new Padding(4, 3, 4, 3);
            cbEventDirection.Name = "cbEventDirection";
            cbEventDirection.Size = new Size(274, 29);
            cbEventDirection.TabIndex = 5;
            // 
            // lblEventDirection
            // 
            lblEventDirection.AutoSize = true;
            lblEventDirection.Location = new Point(15, 163);
            lblEventDirection.Margin = new Padding(4, 0, 4, 0);
            lblEventDirection.Name = "lblEventDirection";
            lblEventDirection.Size = new Size(111, 21);
            lblEventDirection.TabIndex = 6;
            lblEventDirection.Text = "Khung Sự Kiện";
            // 
            // cbCamScale
            // 
            cbCamScale.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCamScale.FormattingEnabled = true;
            cbCamScale.Location = new Point(199, 198);
            cbCamScale.Margin = new Padding(4, 3, 4, 3);
            cbCamScale.Name = "cbCamScale";
            cbCamScale.Size = new Size(274, 29);
            cbCamScale.TabIndex = 5;
            // 
            // lblCamScale
            // 
            lblCamScale.AutoSize = true;
            lblCamScale.Location = new Point(15, 201);
            lblCamScale.Margin = new Padding(4, 0, 4, 0);
            lblCamScale.Name = "lblCamScale";
            lblCamScale.Size = new Size(97, 21);
            lblCamScale.TabIndex = 6;
            lblCamScale.Text = "Tỷ lệ camera";
            // 
            // ucLaneDirectionConfig
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblCamScale);
            Controls.Add(lblEventDirection);
            Controls.Add(lblCameraPicDirection);
            Controls.Add(lblPicDirection);
            Controls.Add(lblCameraDirection);
            Controls.Add(lblDisplayDirection);
            Controls.Add(cbCamScale);
            Controls.Add(cbEventDirection);
            Controls.Add(cbCameraPicDirection);
            Controls.Add(cbPicDiection);
            Controls.Add(cbCameraDirection);
            Controls.Add(cbDisplayDirection);
            Controls.Add(chbIsDisplayLastEvent);
            Controls.Add(chbIsDisplayTitle);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ucLaneDirectionConfig";
            Size = new Size(604, 381);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDisplayDirection;
        private ComboBox cbDisplayDirection;
        private CheckBox chbIsDisplayTitle;
        private CheckBox chbIsDisplayLastEvent;
        private ComboBox cbCameraDirection;
        private ComboBox cbPicDiection;
        private Label lblCameraDirection;
        private Label lblPicDirection;
        private ComboBox cbCameraPicDirection;
        private Label lblCameraPicDirection;
        private ComboBox cbEventDirection;
        private Label lblEventDirection;
        private ComboBox cbCamScale;
        private Label lblCamScale;
    }
}
