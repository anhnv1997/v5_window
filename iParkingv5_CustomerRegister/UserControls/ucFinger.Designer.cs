namespace iParkingv5_CustomerRegister.UserControls
{
    partial class ucFinger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFinger));
            lblFingerIndex = new Label();
            lblFingerData = new Label();
            picAddFinger = new PictureBox();
            picDeleteFinger = new PictureBox();
            picEditFinger = new PictureBox();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)picAddFinger).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picDeleteFinger).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picEditFinger).BeginInit();
            SuspendLayout();
            // 
            // lblFingerIndex
            // 
            lblFingerIndex.AutoSize = true;
            lblFingerIndex.Location = new Point(10, 19);
            lblFingerIndex.Name = "lblFingerIndex";
            lblFingerIndex.Size = new Size(86, 20);
            lblFingerIndex.TabIndex = 0;
            lblFingerIndex.Text = "FingerIndex";
            // 
            // lblFingerData
            // 
            lblFingerData.AutoSize = true;
            lblFingerData.BackColor = Color.White;
            lblFingerData.Location = new Point(187, 19);
            lblFingerData.Name = "lblFingerData";
            lblFingerData.Size = new Size(82, 20);
            lblFingerData.TabIndex = 1;
            lblFingerData.Text = "FingerData";
            // 
            // picAddFinger
            // 
            picAddFinger.Image = (Image)resources.GetObject("picAddFinger.Image");
            picAddFinger.Location = new Point(843, 19);
            picAddFinger.Name = "picAddFinger";
            picAddFinger.Size = new Size(32, 32);
            picAddFinger.SizeMode = PictureBoxSizeMode.CenterImage;
            picAddFinger.TabIndex = 2;
            picAddFinger.TabStop = false;
            // 
            // picDeleteFinger
            // 
            picDeleteFinger.Image = (Image)resources.GetObject("picDeleteFinger.Image");
            picDeleteFinger.Location = new Point(919, 19);
            picDeleteFinger.Name = "picDeleteFinger";
            picDeleteFinger.Size = new Size(32, 32);
            picDeleteFinger.SizeMode = PictureBoxSizeMode.CenterImage;
            picDeleteFinger.TabIndex = 2;
            picDeleteFinger.TabStop = false;
            // 
            // picEditFinger
            // 
            picEditFinger.Image = (Image)resources.GetObject("picEditFinger.Image");
            picEditFinger.Location = new Point(881, 19);
            picEditFinger.Name = "picEditFinger";
            picEditFinger.Size = new Size(32, 32);
            picEditFinger.SizeMode = PictureBoxSizeMode.CenterImage;
            picEditFinger.TabIndex = 2;
            picEditFinger.TabStop = false;
            // 
            // toolTip1
            // 
            toolTip1.IsBalloon = true;
            // 
            // ucFinger
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(picEditFinger);
            Controls.Add(picDeleteFinger);
            Controls.Add(picAddFinger);
            Controls.Add(lblFingerData);
            Controls.Add(lblFingerIndex);
            Name = "ucFinger";
            Size = new Size(954, 62);
            ((System.ComponentModel.ISupportInitialize)picAddFinger).EndInit();
            ((System.ComponentModel.ISupportInitialize)picDeleteFinger).EndInit();
            ((System.ComponentModel.ISupportInitialize)picEditFinger).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFingerIndex;
        private Label lblFingerData;
        private PictureBox picAddFinger;
        private PictureBox picDeleteFinger;
        private PictureBox picEditFinger;
        private ToolTip toolTip1;
    }
}
