namespace iPakrkingv5.Controls.Usercontrols.BuildControls
{
    partial class ucNotify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucNotify));
            picNotiType = new PictureBox();
            lblMessageType = new Label();
            lblMessage = new Label();
            btnCancel = new Controls.Buttons.LblCancel();
            btnConfirm = new Controls.Buttons.LblOk();
            ((System.ComponentModel.ISupportInitialize)picNotiType).BeginInit();
            SuspendLayout();
            // 
            // picNotiType
            // 
            picNotiType.Image = (Image)resources.GetObject("picNotiType.Image");
            picNotiType.Location = new Point(125, 41);
            picNotiType.Name = "picNotiType";
            picNotiType.Size = new Size(66, 66);
            picNotiType.SizeMode = PictureBoxSizeMode.Zoom;
            picNotiType.TabIndex = 0;
            picNotiType.TabStop = false;
            // 
            // lblMessageType
            // 
            lblMessageType.AutoSize = true;
            lblMessageType.Font = new Font("Segoe UI", 32F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblMessageType.ForeColor = Color.Black;
            lblMessageType.Location = new Point(80, 134);
            lblMessageType.Name = "lblMessageType";
            lblMessageType.Size = new Size(193, 45);
            lblMessageType.TabIndex = 2;
            lblMessageType.Text = "Thông báo!";
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblMessage.Location = new Point(97, 218);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(176, 25);
            lblMessage.TabIndex = 3;
            lblMessage.Text = "Nội dung thông báo";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.AutoSize = true;
            //btnCancel.BorderStyle = BorderStyle.Fixed3D;
            btnCancel.Location = new Point(250, 309);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(80, 22);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "lblCancel1";
            // 
            // btnConfirm
            // 
            btnConfirm.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnConfirm.AutoSize = true;
            //btnConfirm.BorderStyle = BorderStyle.Fixed3D;
            btnConfirm.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnConfirm.Location = new Point(188, 309);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(56, 22);
            btnConfirm.TabIndex = 6;
            btnConfirm.Text = "lblOk1";
            // 
            // ucNotify
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 224, 192);
            Controls.Add(btnConfirm);
            Controls.Add(btnCancel);
            Controls.Add(lblMessage);
            Controls.Add(lblMessageType);
            Controls.Add(picNotiType);
            MaximumSize = new Size(333, 356);
            MinimumSize = new Size(333, 356);
            Name = "ucNotify";
            Size = new Size(333, 356);
            ((System.ComponentModel.ISupportInitialize)picNotiType).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picNotiType;
        private Label lblMessageType;
        private Label lblMessage;
        private Controls.Buttons.LblCancel btnCancel;
        private Controls.Buttons.LblOk btnConfirm;
    }
}
