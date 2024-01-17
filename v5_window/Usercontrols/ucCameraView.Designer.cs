namespace iParkingv5_window.Usercontrols
{
    partial class ucCameraView
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
            components = new System.ComponentModel.Container();
            lblCameraName = new Label();
            panelCameraView = new Panel();
            toolTip1 = new ToolTip(components);
            SuspendLayout();
            // 
            // lblCameraName
            // 
            lblCameraName.BackColor = Color.MidnightBlue;
            lblCameraName.Dock = DockStyle.Top;
            lblCameraName.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblCameraName.ForeColor = SystemColors.ButtonHighlight;
            lblCameraName.Location = new Point(0, 0);
            lblCameraName.Name = "lblCameraName";
            lblCameraName.Size = new Size(597, 33);
            lblCameraName.TabIndex = 0;
            lblCameraName.Text = "label1";
            lblCameraName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelCameraView
            // 
            panelCameraView.BorderStyle = BorderStyle.FixedSingle;
            panelCameraView.Dock = DockStyle.Fill;
            panelCameraView.Location = new Point(0, 33);
            panelCameraView.Name = "panelCameraView";
            panelCameraView.Size = new Size(597, 330);
            panelCameraView.TabIndex = 1;
            // 
            // ucCameraView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(panelCameraView);
            Controls.Add(lblCameraName);
            Name = "ucCameraView";
            Size = new Size(597, 363);
            ResumeLayout(false);
        }

        #endregion

        private Label lblCameraName;
        private Panel panelCameraView;
        private ToolTip toolTip1;
    }
}
