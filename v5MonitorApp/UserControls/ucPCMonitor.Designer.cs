namespace v5MonitorApp.UserControls
{
    partial class ucPCMonitor
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
            lblResult1 = new iPakrkingv5.Controls.Controls.Labels.lblResult();
            toolTip1 = new ToolTip(components);
            SuspendLayout();
            // 
            // lblResult1
            // 
            lblResult1.Dock = DockStyle.Bottom;
            lblResult1.Font = new Font("Segoe UI", 12F);
            lblResult1.Location = new Point(0, 141);
            lblResult1.Name = "lblResult1";
            lblResult1.Size = new Size(218, 43);
            lblResult1.TabIndex = 0;
            lblResult1.Text = "PC_NAME";
            lblResult1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ucPCMonitor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.pc_info_64;
            BackgroundImageLayout = ImageLayout.Center;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lblResult1);
            DoubleBuffered = true;
            Name = "ucPCMonitor";
            Size = new Size(218, 184);
            ResumeLayout(false);
        }

        #endregion

        private iPakrkingv5.Controls.Controls.Labels.lblResult lblResult1;
        private ToolTip toolTip1;
    }
}
