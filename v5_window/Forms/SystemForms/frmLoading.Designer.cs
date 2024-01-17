namespace iParkingv5_window.Forms.SystemForms
{
    partial class frmLoading
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoading));
            panelTittle = new Panel();
            panelBackground = new Panel();
            pictureBox1 = new PictureBox();
            panelMessage = new Panel();
            timer1 = new System.Windows.Forms.Timer(components);
            panelBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panelTittle
            // 
            panelTittle.Dock = DockStyle.Top;
            panelTittle.Location = new Point(0, 0);
            panelTittle.Name = "panelTittle";
            panelTittle.Size = new Size(800, 82);
            panelTittle.TabIndex = 1;
            // 
            // panelBackground
            // 
            panelBackground.BackgroundImageLayout = ImageLayout.Center;
            panelBackground.Controls.Add(pictureBox1);
            panelBackground.Dock = DockStyle.Fill;
            panelBackground.Location = new Point(0, 82);
            panelBackground.Name = "panelBackground";
            panelBackground.Size = new Size(800, 193);
            panelBackground.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(800, 193);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panelMessage
            // 
            panelMessage.Dock = DockStyle.Bottom;
            panelMessage.Location = new Point(0, 275);
            panelMessage.Name = "panelMessage";
            panelMessage.Size = new Size(800, 175);
            panelMessage.TabIndex = 3;
            // 
            // timer1
            // 
            timer1.Interval = 300;
            timer1.Tick += timerUpdateWaitingMessage_Tick;
            // 
            // frmLoading
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelBackground);
            Controls.Add(panelMessage);
            Controls.Add(panelTittle);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmLoading";
            StartPosition = FormStartPosition.Manual;
            Text = "frmLoading";
            WindowState = FormWindowState.Maximized;
            FormClosing += frmLoading_FormClosing;
            panelBackground.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelTittle;
        private Panel panelBackground;
        private Panel panelMessage;
        private System.Windows.Forms.Timer timer1;
        private PictureBox pictureBox1;
    }
}