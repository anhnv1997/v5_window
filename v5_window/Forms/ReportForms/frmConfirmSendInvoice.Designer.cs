namespace iParkingv5_window.Forms.ReportForms
{
    partial class frmConfirmSendInvoice
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
            label1 = new Label();
            btnConfirm = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label1.Location = new Point(40, 46);
            label1.Name = "label1";
            label1.Size = new Size(423, 45);
            label1.TabIndex = 0;
            label1.Text = "Bạn có muốn gửi hóa đơn?";
            // 
            // btnConfirm
            // 
            btnConfirm.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnConfirm.BackColor = Color.Green;
            btnConfirm.DialogResult = DialogResult.OK;
            btnConfirm.Font = new Font("Segoe UI", 18F);
            btnConfirm.ForeColor = SystemColors.ButtonHighlight;
            btnConfirm.Location = new Point(299, 168);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(193, 55);
            btnConfirm.TabIndex = 1;
            btnConfirm.Text = "XÁC NHẬN";
            btnConfirm.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancel.BackColor = Color.FromArgb(192, 0, 0);
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Font = new Font("Segoe UI", 18F);
            btnCancel.ForeColor = SystemColors.ButtonHighlight;
            btnCancel.Location = new Point(12, 168);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(160, 55);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "KHÔNG";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // frmConfirmSendInvoice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(504, 235);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmConfirmSendInvoice";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmConfirmSendInvoice";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnConfirm;
        private Button btnCancel;
    }
}