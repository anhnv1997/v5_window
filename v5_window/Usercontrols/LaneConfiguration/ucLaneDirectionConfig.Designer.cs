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
            SuspendLayout();
            // 
            // lblDisplayDirection
            // 
            lblDisplayDirection.AutoSize = true;
            lblDisplayDirection.Location = new Point(7, 14);
            lblDisplayDirection.Name = "lblDisplayDirection";
            lblDisplayDirection.Size = new Size(81, 15);
            lblDisplayDirection.TabIndex = 5;
            lblDisplayDirection.Text = "Chiều hiển thị";
            // 
            // cbDisplayDirection
            // 
            cbDisplayDirection.FormattingEnabled = true;
            cbDisplayDirection.Items.AddRange(new object[] { "Dọc", "Ngang từ trái sang phải", "Ngang từ phải sang trái", "Dọc Trái Qua Phải", "Dọc Phải Qua Trái" });
            cbDisplayDirection.Location = new Point(155, 6);
            cbDisplayDirection.Margin = new Padding(3, 2, 3, 2);
            cbDisplayDirection.Name = "cbDisplayDirection";
            cbDisplayDirection.Size = new Size(214, 23);
            cbDisplayDirection.TabIndex = 1;
            // 
            // chbIsDisplayTitle
            // 
            chbIsDisplayTitle.AutoSize = true;
            chbIsDisplayTitle.Location = new Point(155, 159);
            chbIsDisplayTitle.Margin = new Padding(3, 2, 3, 2);
            chbIsDisplayTitle.Name = "chbIsDisplayTitle";
            chbIsDisplayTitle.Size = new Size(107, 19);
            chbIsDisplayTitle.TabIndex = 6;
            chbIsDisplayTitle.Text = "Hiển thị tiêu đề";
            chbIsDisplayTitle.UseVisualStyleBackColor = true;
            // 
            // chbIsDisplayLastEvent
            // 
            chbIsDisplayLastEvent.AutoSize = true;
            chbIsDisplayLastEvent.Location = new Point(155, 182);
            chbIsDisplayLastEvent.Margin = new Padding(3, 2, 3, 2);
            chbIsDisplayLastEvent.Name = "chbIsDisplayLastEvent";
            chbIsDisplayLastEvent.Size = new Size(158, 19);
            chbIsDisplayLastEvent.TabIndex = 7;
            chbIsDisplayLastEvent.Text = "Hiển thị sự kiện gần nhất";
            chbIsDisplayLastEvent.UseVisualStyleBackColor = true;
            // 
            // cbCameraDirection
            // 
            cbCameraDirection.FormattingEnabled = true;
            cbCameraDirection.Items.AddRange(new object[] { "Dọc", "Ngang" });
            cbCameraDirection.Location = new Point(155, 33);
            cbCameraDirection.Margin = new Padding(3, 2, 3, 2);
            cbCameraDirection.Name = "cbCameraDirection";
            cbCameraDirection.Size = new Size(214, 23);
            cbCameraDirection.TabIndex = 2;
            // 
            // cbPicDiection
            // 
            cbPicDiection.FormattingEnabled = true;
            cbPicDiection.Items.AddRange(new object[] { "Dọc", "Ngang" });
            cbPicDiection.Location = new Point(155, 60);
            cbPicDiection.Margin = new Padding(3, 2, 3, 2);
            cbPicDiection.Name = "cbPicDiection";
            cbPicDiection.Size = new Size(214, 23);
            cbPicDiection.TabIndex = 3;
            // 
            // lblCameraDirection
            // 
            lblCameraDirection.AutoSize = true;
            lblCameraDirection.Location = new Point(12, 44);
            lblCameraDirection.Name = "lblCameraDirection";
            lblCameraDirection.Size = new Size(86, 15);
            lblCameraDirection.TabIndex = 6;
            lblCameraDirection.Text = "Khung Camera";
            // 
            // lblPicDirection
            // 
            lblPicDirection.AutoSize = true;
            lblPicDirection.Location = new Point(12, 63);
            lblPicDirection.Name = "lblPicDirection";
            lblPicDirection.Size = new Size(96, 15);
            lblPicDirection.TabIndex = 6;
            lblPicDirection.Text = "Khung Hình Ảnh";
            // 
            // cbCameraPicDirection
            // 
            cbCameraPicDirection.FormattingEnabled = true;
            cbCameraPicDirection.Items.AddRange(new object[] { "Dọc", "Ngang từ trái sang phải", "Ngang từ phải sang trái" });
            cbCameraPicDirection.Location = new Point(155, 87);
            cbCameraPicDirection.Margin = new Padding(3, 2, 3, 2);
            cbCameraPicDirection.Name = "cbCameraPicDirection";
            cbCameraPicDirection.Size = new Size(214, 23);
            cbCameraPicDirection.TabIndex = 4;
            // 
            // lblCameraPicDirection
            // 
            lblCameraPicDirection.AutoSize = true;
            lblCameraPicDirection.Location = new Point(12, 90);
            lblCameraPicDirection.Name = "lblCameraPicDirection";
            lblCameraPicDirection.Size = new Size(132, 15);
            lblCameraPicDirection.TabIndex = 6;
            lblCameraPicDirection.Text = "Khung Cam - Hình Ảnh";
            // 
            // cbEventDirection
            // 
            cbEventDirection.FormattingEnabled = true;
            cbEventDirection.Items.AddRange(new object[] { "Dọc", "Ngang từ trái sang phải", "Ngang từ phải sang trái" });
            cbEventDirection.Location = new Point(155, 114);
            cbEventDirection.Margin = new Padding(3, 2, 3, 2);
            cbEventDirection.Name = "cbEventDirection";
            cbEventDirection.Size = new Size(214, 23);
            cbEventDirection.TabIndex = 5;
            // 
            // lblEventDirection
            // 
            lblEventDirection.AutoSize = true;
            lblEventDirection.Location = new Point(12, 117);
            lblEventDirection.Name = "lblEventDirection";
            lblEventDirection.Size = new Size(84, 15);
            lblEventDirection.TabIndex = 6;
            lblEventDirection.Text = "Khung Sự Kiện";
            // 
            // ucLaneDirectionConfig
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblEventDirection);
            Controls.Add(lblCameraPicDirection);
            Controls.Add(lblPicDirection);
            Controls.Add(lblCameraDirection);
            Controls.Add(lblDisplayDirection);
            Controls.Add(cbEventDirection);
            Controls.Add(cbCameraPicDirection);
            Controls.Add(cbPicDiection);
            Controls.Add(cbCameraDirection);
            Controls.Add(cbDisplayDirection);
            Controls.Add(chbIsDisplayLastEvent);
            Controls.Add(chbIsDisplayTitle);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ucLaneDirectionConfig";
            Size = new Size(540, 338);
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
    }
}
