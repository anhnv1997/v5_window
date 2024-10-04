namespace MotionDetection
{
    partial class ucCameraView
    {


        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblCameraName = new Label();
            panelCameraView = new Panel();
            toolTip1 = new ToolTip(components);
            label1 = new Label();
            SuspendLayout();
            // 
            // lblCameraName
            // 
            lblCameraName.BackColor = Color.MidnightBlue;
            lblCameraName.Dock = DockStyle.Top;
            lblCameraName.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblCameraName.ForeColor = SystemColors.ButtonHighlight;
            lblCameraName.Location = new Point(0, 0);
            lblCameraName.Name = "lblCameraName";
            lblCameraName.Size = new Size(524, 25);
            lblCameraName.TabIndex = 0;
            lblCameraName.Text = "label1";
            lblCameraName.TextAlign = ContentAlignment.MiddleLeft;
            lblCameraName.Visible = false;
            // 
            // panelCameraView
            // 
            panelCameraView.BorderStyle = BorderStyle.FixedSingle;
            panelCameraView.Dock = DockStyle.Fill;
            panelCameraView.Location = new Point(0, 25);
            panelCameraView.Margin = new Padding(3, 2, 3, 2);
            panelCameraView.Name = "panelCameraView";
            panelCameraView.Size = new Size(524, 249);
            panelCameraView.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Bottom;
            label1.Location = new Point(0, 259);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 2;
            label1.Text = "MOTION-ALARM";
            label1.Visible = false;
            // 
            // ucCameraView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(panelCameraView);
            Controls.Add(lblCameraName);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ucCameraView";
            Size = new Size(524, 274);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCameraName;
        private Panel panelCameraView;
        private ToolTip toolTip1;
        private Label label1;
    }
}
