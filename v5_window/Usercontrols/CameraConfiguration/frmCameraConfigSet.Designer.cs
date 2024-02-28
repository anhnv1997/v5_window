using iPakrkingv5.Controls.Controls.Buttons;

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
            btnOk1 = new LblOk();
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
            panelCameraView.Name = "panelCameraView";
            panelCameraView.Size = new Size(934, 462);
            panelCameraView.TabIndex = 0;
            // 
            // pic
            // 
            pic.BackColor = SystemColors.GradientInactiveCaption;
            pic.BorderStyle = BorderStyle.FixedSingle;
            pic.Dock = DockStyle.Fill;
            pic.Location = new Point(0, 0);
            pic.Name = "pic";
            pic.Size = new Size(934, 462);
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
            btnOk1.Location = new Point(699, 8);
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
            btnCancel1.Location = new Point(820, 8);
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
            panelActions.Location = new Point(0, 462);
            panelActions.Name = "panelActions";
            panelActions.Size = new Size(934, 69);
            panelActions.TabIndex = 1;
            // 
            // frmCameraConfigSet
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(934, 531);
            Controls.Add(panelCameraView);
            Controls.Add(panelActions);
            MaximizeBox = false;
            Name = "frmCameraConfigSet";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cấu hình vùng nhận diện cho Camera";
            panelCameraView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pic).EndInit();
            panelActions.ResumeLayout(false);
            panelActions.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelCameraView;
        private PictureBox pic;
        private LblOk btnOk1;
        private LblCancel btnCancel1;
        private Panel panelActions;
    }
}