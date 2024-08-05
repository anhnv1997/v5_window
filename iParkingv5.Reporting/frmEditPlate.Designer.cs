namespace iParkingv5_window.Forms
{
    partial class frmEditPlate
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
            lblCurrentPlate = new Label();
            button2 = new Button();
            button1 = new Button();
            label2 = new Label();
            label1 = new Label();
            txtNewPlate = new TextBox();
            SuspendLayout();
            // 
            // lblCurrentPlate
            // 
            lblCurrentPlate.AutoSize = true;
            lblCurrentPlate.Location = new Point(147, 11);
            lblCurrentPlate.Name = "lblCurrentPlate";
            lblCurrentPlate.Size = new Size(17, 21);
            lblCurrentPlate.TabIndex = 8;
            lblCurrentPlate.Text = "_";
            // 
            // button2
            // 
            button2.DialogResult = DialogResult.Cancel;
            button2.Location = new Point(392, 136);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(113, 51);
            button2.TabIndex = 2;
            button2.Text = "Đóng";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.OK;
            button1.Location = new Point(266, 136);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(118, 51);
            button1.TabIndex = 1;
            button1.Text = "Xác nhận";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 44);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(92, 21);
            label2.TabIndex = 4;
            label2.Text = "Biển số mới";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 11);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(115, 21);
            label1.TabIndex = 5;
            label1.Text = "Biển số hiện tại";
            // 
            // txtNewPlate
            // 
            txtNewPlate.Location = new Point(147, 41);
            txtNewPlate.Name = "txtNewPlate";
            txtNewPlate.Size = new Size(358, 29);
            txtNewPlate.TabIndex = 0;
            // 
            // frmEditPlate
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(514, 199);
            Controls.Add(txtNewPlate);
            Controls.Add(lblCurrentPlate);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F);
            KeyPreview = true;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmEditPlate";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CẬP NHẬT THÔNG TIN";
            KeyDown += frmEditPlate_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCurrentPlate;
        private Button button2;
        private Button button1;
        private Label label2;
        private Label label1;
        private TextBox txtNewPlate;
    }
}