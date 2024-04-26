namespace v5_IScale.Forms
{
    partial class frmSelectPrintCount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectPrintCount));
            btnSelect1 = new Button();
            btnSelect2 = new Button();
            btnSelect3 = new Button();
            btnSelect4 = new Button();
            SuspendLayout();
            // 
            // btnSelect1
            // 
            btnSelect1.Location = new Point(139, 48);
            btnSelect1.Margin = new Padding(4, 3, 4, 3);
            btnSelect1.Name = "btnSelect1";
            btnSelect1.Size = new Size(170, 134);
            btnSelect1.TabIndex = 0;
            btnSelect1.Tag = "1";
            btnSelect1.Text = "In 1 phiếu";
            btnSelect1.UseVisualStyleBackColor = true;
            btnSelect1.Click += btnSelect1_Click;
            // 
            // btnSelect2
            // 
            btnSelect2.Location = new Point(328, 48);
            btnSelect2.Margin = new Padding(4, 3, 4, 3);
            btnSelect2.Name = "btnSelect2";
            btnSelect2.Size = new Size(170, 134);
            btnSelect2.TabIndex = 1;
            btnSelect2.Tag = "2";
            btnSelect2.Text = "In 2 phiếu";
            btnSelect2.UseVisualStyleBackColor = true;
            btnSelect2.Click += btnSelect2_Click;
            // 
            // btnSelect3
            // 
            btnSelect3.Location = new Point(139, 188);
            btnSelect3.Margin = new Padding(4, 3, 4, 3);
            btnSelect3.Name = "btnSelect3";
            btnSelect3.Size = new Size(170, 134);
            btnSelect3.TabIndex = 2;
            btnSelect3.Tag = "3";
            btnSelect3.Text = "In 3 phiếu";
            btnSelect3.UseVisualStyleBackColor = true;
            btnSelect3.Click += btnSelect3_Click;
            // 
            // btnSelect4
            // 
            btnSelect4.Location = new Point(328, 188);
            btnSelect4.Margin = new Padding(4, 3, 4, 3);
            btnSelect4.Name = "btnSelect4";
            btnSelect4.Size = new Size(170, 134);
            btnSelect4.TabIndex = 3;
            btnSelect4.Tag = "4";
            btnSelect4.Text = "In 4 phiếu";
            btnSelect4.UseVisualStyleBackColor = true;
            btnSelect4.Click += btnSelect4_Click;
            // 
            // frmSelectPrintCount
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(633, 370);
            Controls.Add(btnSelect4);
            Controls.Add(btnSelect2);
            Controls.Add(btnSelect3);
            Controls.Add(btnSelect1);
            Font = new Font("Segoe UI", 12F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "frmSelectPrintCount";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chọn số lượng phiếu in";
            ResumeLayout(false);
        }

        #endregion

        private Button btnSelect1;
        private Button btnSelect2;
        private Button btnSelect3;
        private Button btnSelect4;
    }
}