namespace iParkingv5_window.Forms.DataForms
{
    partial class frmSelectVehicle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectVehicle));
            lblTitle = new Label();
            btnOk1 = new iPakrkingv5.Controls.Controls.Buttons.BtnOk();
            lblCancel1 = new iPakrkingv5.Controls.Controls.Buttons.LblCancel();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.Location = new Point(18, 17);
            lblTitle.Margin = new Padding(0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(468, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Xác nhận phương tiện vào bãi";
            // 
            // btnOk1
            // 
            btnOk1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnOk1.Location = new Point(457, 251);
            btnOk1.Margin = new Padding(2);
            btnOk1.Name = "btnOk1";
            btnOk1.Size = new Size(74, 29);
            btnOk1.TabIndex = 1;
            btnOk1.Text = "btnOk1";
            btnOk1.UseVisualStyleBackColor = true;
            // 
            // lblCancel1
            // 
            lblCancel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblCancel1.Location = new Point(536, 251);
            lblCancel1.Margin = new Padding(2);
            lblCancel1.Name = "lblCancel1";
            lblCancel1.Size = new Size(83, 29);
            lblCancel1.TabIndex = 2;
            lblCancel1.Text = "lblCancel1";
            lblCancel1.UseVisualStyleBackColor = true;
            // 
            // frmSelectVehicle
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(628, 288);
            Controls.Add(lblCancel1);
            Controls.Add(btnOk1);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 12F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(0);
            Name = "frmSelectVehicle";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Xác nhận phương tiện vào bãi";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private iPakrkingv5.Controls.Controls.Buttons.BtnOk btnOk1;
        private iPakrkingv5.Controls.Controls.Buttons.LblCancel lblCancel1;
    }
}