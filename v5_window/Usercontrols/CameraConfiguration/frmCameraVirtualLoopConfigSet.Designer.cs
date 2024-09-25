using iPakrkingv5.Controls.Controls.Buttons;

namespace iParkingv5_window.Usercontrols.CameraConfiguration
{
    partial class frmCameraVirtualLoopConfigSet
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
            btnOk1 = new BtnOk();
            btnCancel1 = new LblCancel();
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
            panelCameraView.Margin = new Padding(3, 2, 3, 2);
            panelCameraView.Name = "panelCameraView";
            panelCameraView.Size = new Size(987, 468);
            panelCameraView.TabIndex = 0;
            // 
            // pic
            // 
            pic.BackColor = SystemColors.GradientInactiveCaption;
            pic.BorderStyle = BorderStyle.FixedSingle;
            pic.Location = new Point(0, 0);
            pic.Margin = new Padding(3, 2, 3, 2);
            pic.Name = "pic";
            pic.Size = new Size(987, 468);
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.TabIndex = 0;
            pic.TabStop = false;
            pic.MouseDown += pic_MouseDown;
            pic.MouseMove += pic_MouseMove;
            // 
            // btnOk1
            // 
            btnOk1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk1.AutoSize = true;
            btnOk1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnOk1.ForeColor = Color.Black;
            btnOk1.Location = new Point(816, 11);
            btnOk1.Margin = new Padding(3, 2, 3, 2);
            btnOk1.Name = "btnOk1";
            btnOk1.Size = new Size(83, 30);
            btnOk1.TabIndex = 3;
            btnOk1.Text = "Xác nhận";
            // 
            // btnCancel1
            // 
            btnCancel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel1.AutoSize = true;
            btnCancel1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnCancel1.ForeColor = Color.Black;
            btnCancel1.Location = new Point(905, 11);
            btnCancel1.Margin = new Padding(3, 2, 3, 2);
            btnCancel1.Name = "btnCancel1";
            btnCancel1.Size = new Size(57, 30);
            btnCancel1.TabIndex = 4;
            btnCancel1.Text = "Đóng";
            // 
            // panelActions
            // 
            panelActions.Controls.Add(btnCancel1);
            panelActions.Controls.Add(btnOk1);
            panelActions.Dock = DockStyle.Bottom;
            panelActions.Location = new Point(0, 468);
            panelActions.Margin = new Padding(3, 2, 3, 2);
            panelActions.Name = "panelActions";
            panelActions.Size = new Size(987, 52);
            panelActions.TabIndex = 1;
            // 
            // frmCameraConfigSet
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(987, 520);
            Controls.Add(panelCameraView);
            Controls.Add(panelActions);
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "frmCameraConfigSet";
            StartPosition = FormStartPosition.CenterScreen;
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
        private BtnOk btnOk1;
        private LblCancel btnCancel1;
        private Panel panelActions;
    }
}