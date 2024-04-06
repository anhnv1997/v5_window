namespace iParkingv5_window.Usercontrols.Payments
{
    partial class ucPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPayment));
            picCash = new PictureBox();
            picQR = new PictureBox();
            picVisa = new PictureBox();
            picVoucher = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picCash).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picQR).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picVisa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picVoucher).BeginInit();
            SuspendLayout();
            // 
            // picCash
            // 
            picCash.Image = (Image)resources.GetObject("picCash.Image");
            picCash.Location = new Point(26, 14);
            picCash.Name = "picCash";
            picCash.Size = new Size(95, 95);
            picCash.SizeMode = PictureBoxSizeMode.Zoom;
            picCash.TabIndex = 0;
            picCash.TabStop = false;
            // 
            // picQR
            // 
            picQR.Image = (Image)resources.GetObject("picQR.Image");
            picQR.Location = new Point(156, 14);
            picQR.Name = "picQR";
            picQR.Size = new Size(95, 95);
            picQR.SizeMode = PictureBoxSizeMode.Zoom;
            picQR.TabIndex = 0;
            picQR.TabStop = false;
            // 
            // picVisa
            // 
            picVisa.Image = (Image)resources.GetObject("picVisa.Image");
            picVisa.Location = new Point(26, 122);
            picVisa.Name = "picVisa";
            picVisa.Size = new Size(95, 95);
            picVisa.SizeMode = PictureBoxSizeMode.Zoom;
            picVisa.TabIndex = 0;
            picVisa.TabStop = false;
            // 
            // picVoucher
            // 
            picVoucher.Image = (Image)resources.GetObject("picVoucher.Image");
            picVoucher.Location = new Point(156, 122);
            picVoucher.Name = "picVoucher";
            picVoucher.Size = new Size(95, 95);
            picVoucher.SizeMode = PictureBoxSizeMode.Zoom;
            picVoucher.TabIndex = 0;
            picVoucher.TabStop = false;
            // 
            // ucPayment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(picVoucher);
            Controls.Add(picVisa);
            Controls.Add(picQR);
            Controls.Add(picCash);
            Name = "ucPayment";
            Size = new Size(276, 225);
            ((System.ComponentModel.ISupportInitialize)picCash).EndInit();
            ((System.ComponentModel.ISupportInitialize)picQR).EndInit();
            ((System.ComponentModel.ISupportInitialize)picVisa).EndInit();
            ((System.ComponentModel.ISupportInitialize)picVoucher).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picCash;
        private PictureBox picQR;
        private PictureBox picVisa;
        private PictureBox picVoucher;
    }
}
