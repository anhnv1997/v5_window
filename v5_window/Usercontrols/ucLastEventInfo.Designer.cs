namespace iParkingv5_window.Usercontrols
{
    partial class ucLastEventInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLastEventInfo));
            picVehicle = new PictureBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picVehicle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // picVehicle
            // 
            picVehicle.BackColor = SystemColors.Control;
            picVehicle.Dock = DockStyle.Fill;
            picVehicle.Image = Properties.Resources.defaultImage;
            picVehicle.Location = new Point(0, 10);
            picVehicle.Name = "picVehicle";
            picVehicle.Size = new Size(149, 134);
            picVehicle.SizeMode = PictureBoxSizeMode.StretchImage;
            picVehicle.TabIndex = 0;
            picVehicle.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(149, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(61, 134);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // ucLastEventInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(picVehicle);
            Controls.Add(pictureBox1);
            Name = "ucLastEventInfo";
            Padding = new Padding(0, 10, 10, 10);
            Size = new Size(220, 154);
            ((System.ComponentModel.ISupportInitialize)picVehicle).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picVehicle;
        private PictureBox pictureBox1;
    }
}
