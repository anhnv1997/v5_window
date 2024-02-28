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
            SuspendLayout();
            // 
            // lblDisplayDirection
            // 
            lblDisplayDirection.AutoSize = true;
            lblDisplayDirection.Location = new Point(8, 18);
            lblDisplayDirection.Name = "lblDisplayDirection";
            lblDisplayDirection.Size = new Size(99, 20);
            lblDisplayDirection.TabIndex = 5;
            lblDisplayDirection.Text = "Chiều hiển thị";
            // 
            // cbDisplayDirection
            // 
            cbDisplayDirection.FormattingEnabled = true;
            cbDisplayDirection.Items.AddRange(new object[] { "Dọc", "Ngang từ trái sang phải", "Ngang từ phải sang trái" });
            cbDisplayDirection.Location = new Point(113, 15);
            cbDisplayDirection.Name = "cbDisplayDirection";
            cbDisplayDirection.Size = new Size(244, 28);
            cbDisplayDirection.TabIndex = 4;
            // 
            // chbIsDisplayTitle
            // 
            chbIsDisplayTitle.AutoSize = true;
            chbIsDisplayTitle.Location = new Point(113, 49);
            chbIsDisplayTitle.Name = "chbIsDisplayTitle";
            chbIsDisplayTitle.Size = new Size(130, 24);
            chbIsDisplayTitle.TabIndex = 3;
            chbIsDisplayTitle.Text = "Hiển thị tiêu đề";
            chbIsDisplayTitle.UseVisualStyleBackColor = true;
            // 
            // ucLaneDirectionConfig
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblDisplayDirection);
            Controls.Add(cbDisplayDirection);
            Controls.Add(chbIsDisplayTitle);
            Name = "ucLaneDirectionConfig";
            Size = new Size(617, 451);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDisplayDirection;
        private ComboBox cbDisplayDirection;
        private CheckBox chbIsDisplayTitle;
    }
}
