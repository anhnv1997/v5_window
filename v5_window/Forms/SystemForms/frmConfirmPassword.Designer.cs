namespace iParkingv5_window.Forms.SystemForms
{
    partial class frmConfirmPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfirmPassword));
            label1 = new Label();
            txtPassword = new TextBox();
            panel1 = new Panel();
            panel2 = new Panel();
            btnConfirm = new Button();
            btnCancel = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.ForeColor = Color.DarkOrange;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(660, 77);
            label1.TabIndex = 0;
            label1.Text = "Vui lòng nhập mật khẩu để thực hiện chức năng này";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtPassword
            // 
            txtPassword.Dock = DockStyle.Fill;
            txtPassword.Font = new Font("Segoe UI", 32F);
            txtPassword.Location = new Point(120, 60);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(420, 64);
            txtPassword.TabIndex = 0;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtPassword);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 77);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(120, 60, 120, 100);
            panel1.Size = new Size(660, 215);
            panel1.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnConfirm);
            panel2.Controls.Add(btnCancel);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 292);
            panel2.Name = "panel2";
            panel2.Size = new Size(660, 85);
            panel2.TabIndex = 3;
            // 
            // btnConfirm
            // 
            btnConfirm.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnConfirm.AutoSize = true;
            btnConfirm.Font = new Font("Segoe UI", 16F);
            btnConfirm.Image = (Image)resources.GetObject("btnConfirm.Image");
            btnConfirm.Location = new Point(364, 7);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(142, 66);
            btnConfirm.TabIndex = 1;
            btnConfirm.Text = "Xác nhận";
            btnConfirm.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.AutoSize = true;
            btnCancel.Font = new Font("Segoe UI", 16F);
            btnCancel.Image = (Image)resources.GetObject("btnCancel.Image");
            btnCancel.Location = new Point(512, 7);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(136, 66);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Đóng";
            btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmConfirmPassword
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(660, 377);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new Padding(4);
            Name = "frmConfirmPassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Xác thực thông tin";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox txtPassword;
        private Panel panel1;
        private Panel panel2;
        private Button btnConfirm;
        private Button btnCancel;
    }
}