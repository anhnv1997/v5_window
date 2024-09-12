namespace iParkingv5_window.Forms.SystemForms
{
    partial class frmOptionViewMode
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
            numRow = new NumericUpDown();
            numColumn = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            btnOk = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numRow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numColumn).BeginInit();
            SuspendLayout();
            // 
            // numRow
            // 
            numRow.Location = new Point(101, 13);
            numRow.Margin = new Padding(4);
            numRow.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numRow.Name = "numRow";
            numRow.Size = new Size(328, 29);
            numRow.TabIndex = 0;
            numRow.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numColumn
            // 
            numColumn.Location = new Point(101, 50);
            numColumn.Margin = new Padding(5, 6, 5, 6);
            numColumn.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numColumn.Name = "numColumn";
            numColumn.Size = new Size(328, 29);
            numColumn.TabIndex = 1;
            numColumn.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(68, 21);
            label1.TabIndex = 1;
            label1.Text = "Số dòng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 52);
            label2.Name = "label2";
            label2.Size = new Size(53, 21);
            label2.TabIndex = 1;
            label2.Text = "Số cột";
            // 
            // btnOk
            // 
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(231, 105);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(96, 37);
            btnOk.TabIndex = 3;
            btnOk.Text = "Xác nhận";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(333, 105);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(96, 37);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Đóng";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmOptionViewMode
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(438, 154);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numColumn);
            Controls.Add(numRow);
            Font = new Font("Segoe UI", 12F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            KeyPreview = true;
            Margin = new Padding(4);
            Name = "frmOptionViewMode";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tùy chọn giao diện";
            KeyDown += frmOptionViewMode_KeyDown;
            ((System.ComponentModel.ISupportInitialize)numRow).EndInit();
            ((System.ComponentModel.ISupportInitialize)numColumn).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown numRow;
        private NumericUpDown numColumn;
        private Label label1;
        private Label label2;
        private Button btnOk;
        private Button btnCancel;
    }
}