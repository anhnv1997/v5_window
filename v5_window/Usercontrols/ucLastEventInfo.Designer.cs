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
            picVehicle = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picVehicle).BeginInit();
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
            picVehicle.Size = new Size(308, 167);
            picVehicle.SizeMode = PictureBoxSizeMode.StretchImage;
            picVehicle.TabIndex = 0;
            picVehicle.TabStop = false;
            picVehicle.LoadCompleted += picVehicle_LoadCompleted;
            // 
            // ucLastEventInfo
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            Controls.Add(picVehicle);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(0);
            Name = "ucLastEventInfo";
            Padding = new Padding(0, 0, 10, 1);
            Size = new Size(318, 168);
            ((System.ComponentModel.ISupportInitialize)picVehicle).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picVehicle;
    }
}
