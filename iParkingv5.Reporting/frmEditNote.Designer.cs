namespace iParkingv5_window.Forms
{
    partial class frmEditNote
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
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            lblCurrentNote = new Label();
            txtNewNote = new RichTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 22);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(118, 21);
            label1.TabIndex = 0;
            label1.Text = "Ghi chú hiện tại";
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.OK;
            button1.Location = new Point(353, 271);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(118, 51);
            button1.TabIndex = 1;
            button1.Text = "Xác nhận";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.DialogResult = DialogResult.Cancel;
            button2.Location = new Point(479, 271);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(113, 51);
            button2.TabIndex = 2;
            button2.Text = "Đóng";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 52);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(95, 21);
            label2.TabIndex = 0;
            label2.Text = "Ghi chú mới";
            // 
            // lblCurrentNote
            // 
            lblCurrentNote.AutoSize = true;
            lblCurrentNote.Location = new Point(149, 22);
            lblCurrentNote.Name = "lblCurrentNote";
            lblCurrentNote.Size = new Size(17, 21);
            lblCurrentNote.TabIndex = 2;
            lblCurrentNote.Text = "_";
            // 
            // txtNewNote
            // 
            txtNewNote.Location = new Point(149, 52);
            txtNewNote.Name = "txtNewNote";
            txtNewNote.Size = new Size(443, 192);
            txtNewNote.TabIndex = 0;
            txtNewNote.Text = "";
            // 
            // frmEditNote
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(607, 335);
            Controls.Add(txtNewNote);
            Controls.Add(lblCurrentNote);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F);
            KeyPreview = true;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmEditNote";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CẬP NHẬT THÔNG TIN";
            KeyDown += frmEditNote_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Label label2;
        private Label lblCurrentNote;
        private RichTextBox txtNewNote;
    }
}