namespace v5_IScale.Forms
{
    partial class frmUpdateWeighingType
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
            label2 = new Label();
            cbWeighingType = new ComboBox();
            lblCurrentWeighingType = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 28);
            label1.Name = "label1";
            label1.Size = new Size(133, 21);
            label1.TabIndex = 0;
            label1.Text = "Loại hàng hiện tại";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 67);
            label2.Name = "label2";
            label2.Size = new Size(110, 21);
            label2.TabIndex = 0;
            label2.Text = "Loại hàng mới";
            // 
            // cbWeighingType
            // 
            cbWeighingType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbWeighingType.FormattingEnabled = true;
            cbWeighingType.Location = new Point(151, 64);
            cbWeighingType.Name = "cbWeighingType";
            cbWeighingType.Size = new Size(399, 29);
            cbWeighingType.TabIndex = 0;
            // 
            // lblCurrentWeighingType
            // 
            lblCurrentWeighingType.AutoSize = true;
            lblCurrentWeighingType.Location = new Point(151, 28);
            lblCurrentWeighingType.Name = "lblCurrentWeighingType";
            lblCurrentWeighingType.Size = new Size(17, 21);
            lblCurrentWeighingType.TabIndex = 2;
            lblCurrentWeighingType.Text = "_";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(294, 124);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(125, 53);
            btnSave.TabIndex = 1;
            btnSave.Text = "Xác nhận ";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(425, 124);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(125, 53);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Đóng";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmUpdateWeighingType
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(563, 190);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(lblCurrentWeighingType);
            Controls.Add(cbWeighingType);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4, 4, 4, 4);
            Name = "frmUpdateWeighingType";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cập nhật loại hàng";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cbWeighingType;
        private Label lblCurrentWeighingType;
        private Button btnSave;
        private Button btnCancel;
    }

}
