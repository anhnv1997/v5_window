namespace ALSE
{
    partial class ucControllerConnection
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
            picConnectStatus = new PictureBox();
            lblControllerName = new Label();
            timerUpdateStatus = new System.Windows.Forms.Timer(components);
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)picConnectStatus).BeginInit();
            SuspendLayout();
            // 
            // picConnectStatus
            // 
            picConnectStatus.Dock = DockStyle.Left;
            picConnectStatus.Location = new Point(0, 0);
            picConnectStatus.Name = "picConnectStatus";
            picConnectStatus.Size = new Size(29, 28);
            picConnectStatus.SizeMode = PictureBoxSizeMode.Zoom;
            picConnectStatus.TabIndex = 0;
            picConnectStatus.TabStop = false;
            // 
            // lblControllerName
            // 
            lblControllerName.Dock = DockStyle.Fill;
            lblControllerName.Location = new Point(29, 0);
            lblControllerName.Name = "lblControllerName";
            lblControllerName.Size = new Size(117, 28);
            lblControllerName.TabIndex = 1;
            lblControllerName.Text = "255.255.255.255";
            lblControllerName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timerUpdateStatus
            // 
            timerUpdateStatus.Enabled = true;
            timerUpdateStatus.Interval = 1000;
            timerUpdateStatus.Tick += timerUpdateStatus_Tick;
            // 
            // ucControllerConnection
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(lblControllerName);
            Controls.Add(picConnectStatus);
            Name = "ucControllerConnection";
            Size = new Size(146, 28);
            ((System.ComponentModel.ISupportInitialize)picConnectStatus).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picConnectStatus;
        private Label lblControllerName;
        private System.Windows.Forms.Timer timerUpdateStatus;
        private ToolTip toolTip1;
    }
}
