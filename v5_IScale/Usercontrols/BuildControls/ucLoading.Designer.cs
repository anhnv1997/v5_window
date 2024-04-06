namespace v5_IScale.Usercontrols.BuildControls
{
    partial class ucLoading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLoading));
            lblMessage = new Label();
            lblWaiting = new Label();
            picWaiting = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picWaiting).BeginInit();
            SuspendLayout();
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblMessage.Location = new Point(120, 105);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(195, 25);
            lblMessage.TabIndex = 8;
            lblMessage.Text = "Preparing to download";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWaiting
            // 
            lblWaiting.AutoSize = true;
            lblWaiting.Font = new Font("Segoe UI", 32F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblWaiting.ForeColor = Color.Black;
            lblWaiting.Location = new Point(24, 24);
            lblWaiting.Name = "lblWaiting";
            lblWaiting.Size = new Size(223, 45);
            lblWaiting.TabIndex = 7;
            lblWaiting.Text = "Please wait ...";
            // 
            // picWaiting
            // 
            picWaiting.Image = (Image)resources.GetObject("picWaiting.Image");
            picWaiting.Location = new Point(24, 83);
            picWaiting.Name = "picWaiting";
            picWaiting.Size = new Size(90, 72);
            picWaiting.SizeMode = PictureBoxSizeMode.Zoom;
            picWaiting.TabIndex = 4;
            picWaiting.TabStop = false;
            // 
            // ucLoading
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 224, 192);
            Controls.Add(lblMessage);
            Controls.Add(lblWaiting);
            Controls.Add(picWaiting);
            Name = "ucLoading";
            Size = new Size(392, 188);
            ((System.ComponentModel.ISupportInitialize)picWaiting).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMessage;
        private Label lblWaiting;
        private PictureBox picWaiting;
    }
}
