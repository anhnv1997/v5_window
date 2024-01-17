namespace iParkingv5_window.Forms.DataForms
{
    partial class frmConfirm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfirm));
            lblMessage = new Label();
            panelAction = new Panel();
            btnCancel1 = new Controls.Buttons.LblCancel();
            btnOk = new Controls.Buttons.LblOk();
            panelAction.SuspendLayout();
            SuspendLayout();
            // 
            // lblMessage
            // 
            lblMessage.Dock = DockStyle.Fill;
            lblMessage.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblMessage.Location = new Point(0, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(475, 135);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "label1";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelAction
            // 
            panelAction.Controls.Add(btnCancel1);
            panelAction.Controls.Add(btnOk);
            panelAction.Dock = DockStyle.Bottom;
            panelAction.Location = new Point(0, 135);
            panelAction.Name = "panelAction";
            panelAction.Size = new Size(475, 62);
            panelAction.TabIndex = 1;
            // 
            // btnCancel1
            // 
            btnCancel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel1.AutoSize = true;
            btnCancel1.BorderStyle = BorderStyle.Fixed3D;
            btnCancel1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnCancel1.ForeColor = Color.Black;
            btnCancel1.Location = new Point(403, 22);
            btnCancel1.Name = "btnCancel1";
            btnCancel1.Size = new Size(49, 22);
            btnCancel1.TabIndex = 3;
            btnCancel1.Text = "Đóng";
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk.AutoSize = true;
            btnOk.BorderStyle = BorderStyle.Fixed3D;
            btnOk.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnOk.ForeColor = Color.Black;
            btnOk.Location = new Point(322, 22);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 22);
            btnOk.TabIndex = 2;
            btnOk.Text = "Xác nhận";
            // 
            // frmConfirm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(475, 197);
            Controls.Add(lblMessage);
            Controls.Add(panelAction);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmConfirm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Xác nhận thông tin";
            panelAction.ResumeLayout(false);
            panelAction.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblMessage;
        private Panel panelAction;
        private Controls.Buttons.LblOk btnOk;
        private Controls.Buttons.LblCancel btnCancel1;
    }
}