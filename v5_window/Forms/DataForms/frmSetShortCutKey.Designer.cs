namespace iParkingv5_window.Forms.DataForms
{
    partial class frmSetShortCutKey
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
            lblTitle = new Label();
            lblCurrentKeySetValue = new Label();
            panelActions = new Panel();
            btnOk1 = new Controls.Buttons.LblOk();
            panelActions.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(291, 20);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Nhập phím tắt muốn gán vào chức năng";
            // 
            // lblCurrentKeySetValue
            // 
            lblCurrentKeySetValue.Dock = DockStyle.Fill;
            lblCurrentKeySetValue.Font = new Font("Segoe UI", 25F);
            lblCurrentKeySetValue.Location = new Point(0, 20);
            lblCurrentKeySetValue.Name = "lblCurrentKeySetValue";
            lblCurrentKeySetValue.Size = new Size(564, 161);
            lblCurrentKeySetValue.TabIndex = 1;
            lblCurrentKeySetValue.Text = "label1";
            lblCurrentKeySetValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelActions
            // 
            panelActions.Controls.Add(btnOk1);
            panelActions.Dock = DockStyle.Bottom;
            panelActions.Location = new Point(0, 181);
            panelActions.Name = "panelActions";
            panelActions.Size = new Size(564, 51);
            panelActions.TabIndex = 3;
            // 
            // btnOk1
            // 
            btnOk1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk1.AutoSize = true;
            btnOk1.BorderStyle = BorderStyle.Fixed3D;
            btnOk1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnOk1.Location = new Point(496, 11);
            btnOk1.Name = "btnOk1";
            btnOk1.Size = new Size(56, 22);
            btnOk1.TabIndex = 0;
            btnOk1.Text = "lblOk1";
            // 
            // frmSetShortCutKey
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(564, 232);
            Controls.Add(lblCurrentKeySetValue);
            Controls.Add(panelActions);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 11.25F);
            KeyPreview = true;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmSetShortCutKey";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chọn phím tắt";
            panelActions.ResumeLayout(false);
            panelActions.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblCurrentKeySetValue;
        private Panel panelActions;
        private Controls.Buttons.LblOk btnOk1;
    }
}