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
            picVehicle.BorderStyle = BorderStyle.FixedSingle;
            picVehicle.Dock = DockStyle.Fill;
            picVehicle.Image = Properties.Resources.defaultImage;
            picVehicle.Location = new Point(0, 0);
            picVehicle.Margin = new Padding(4, 3, 4, 3);
            picVehicle.Name = "picVehicle";
            picVehicle.Size = new Size(162, 168);
            picVehicle.SizeMode = PictureBoxSizeMode.StretchImage;
            picVehicle.TabIndex = 0;
            picVehicle.TabStop = false;
            picVehicle.LoadCompleted += picVehicle_LoadCompleted;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(162, 0);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(64, 168);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // ucLastEventInfo
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            Controls.Add(picVehicle);
            Controls.Add(pictureBox1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(0);
            Name = "ucLastEventInfo";
            Size = new Size(226, 168);
            ((System.ComponentModel.ISupportInitialize)picVehicle).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picVehicle;
        private PictureBox pictureBox1;
    }
}
