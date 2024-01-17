namespace iParkingv5_window.Usercontrols.CameraConfiguration
{
    partial class frmCameraConfigSet
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
            panelCameraView = new Panel();
            pic = new PictureBox();
            btnOk1 = new Controls.Buttons.LblOk();
            btnCancel1 = new Controls.Buttons.LblCancel();
            panelActions = new Panel();
            panelCameraView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic).BeginInit();
            panelActions.SuspendLayout();
            SuspendLayout();
            // 
            // panelCameraView
            // 
            panelCameraView.Controls.Add(pic);
            panelCameraView.Dock = DockStyle.Fill;
            panelCameraView.Location = new Point(0, 0);
            panelCameraView.Name = "panelCameraView";
            panelCameraView.Size = new Size(800, 381);
            panelCameraView.TabIndex = 0;
            // 
            // pic
            // 
            pic.Location = new Point(0, 0);
            pic.Name = "pic";
            pic.Size = new Size(100, 50);
            pic.TabIndex = 0;
            pic.TabStop = false;
            pic.MouseDown += pic_MouseDown;
            pic.MouseMove += pic_MouseMove;
            // 
            // btnOk1
            // 
            btnOk1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk1.AutoSize = true;
            btnOk1.BorderStyle = BorderStyle.Fixed3D;
            btnOk1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnOk1.ForeColor = Color.Black;
            btnOk1.Location = new Point(573, 16);
            btnOk1.Name = "btnOk1";
            btnOk1.Size = new Size(75, 22);
            btnOk1.TabIndex = 3;
            btnOk1.Text = "Xác nhận";
            // 
            // btnCancel1
            // 
            btnCancel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel1.AutoSize = true;
            btnCancel1.BorderStyle = BorderStyle.Fixed3D;
            btnCancel1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnCancel1.ForeColor = Color.Black;
            btnCancel1.Location = new Point(694, 16);
            btnCancel1.Name = "btnCancel1";
            btnCancel1.Size = new Size(49, 22);
            btnCancel1.TabIndex = 4;
            btnCancel1.Text = "Đóng";
            // 
            // panelActions
            // 
            panelActions.Controls.Add(btnCancel1);
            panelActions.Controls.Add(btnOk1);
            panelActions.Dock = DockStyle.Bottom;
            panelActions.Location = new Point(0, 381);
            panelActions.Name = "panelActions";
            panelActions.Size = new Size(800, 69);
            panelActions.TabIndex = 1;
            // 
            // frmCameraConfigSet
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelCameraView);
            Controls.Add(panelActions);
            Name = "frmCameraConfigSet";
            Text = "Cấu hình vùng nhận diện cho Camera";
            WindowState = FormWindowState.Maximized;
            panelCameraView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pic).EndInit();
            panelActions.ResumeLayout(false);
            panelActions.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelCameraView;
        private PictureBox pic;
        private Controls.Buttons.LblOk btnOk1;
        private Controls.Buttons.LblCancel btnCancel1;
        private Panel panelActions;
    }
}