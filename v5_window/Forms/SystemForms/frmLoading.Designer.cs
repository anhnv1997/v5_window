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
            panelTittle.Margin = new Padding(3, 2, 3, 2);
            panelTittle.Name = "panelTittle";
            panelTittle.Size = new Size(700, 62);
            panelTittle.TabIndex = 1;
            // 
            // panelBackground
            // 
            panelBackground.BackgroundImageLayout = ImageLayout.Center;
            panelBackground.Controls.Add(pictureBox1);
            panelBackground.Dock = DockStyle.Fill;
            panelBackground.Location = new Point(0, 62);
            panelBackground.Margin = new Padding(3, 2, 3, 2);
            panelBackground.Name = "panelBackground";
            panelBackground.Size = new Size(700, 145);
            panelBackground.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(700, 145);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panelMessage
            // 
            panelMessage.Dock = DockStyle.Bottom;
            panelMessage.Location = new Point(0, 207);
            panelMessage.Margin = new Padding(3, 2, 3, 2);
            panelMessage.Name = "panelMessage";
            panelMessage.Size = new Size(700, 131);
            panelMessage.TabIndex = 3;
            // 
            // timer1
            // 
            timer1.Interval = 300;
            timer1.Tick += timerUpdateWaitingMessage_Tick;
            // 
            // frmLoading
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(panelBackground);
            Controls.Add(panelMessage);
            Controls.Add(panelTittle);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
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