namespace iParkingv5_window.Forms.DataForms
{
    partial class frmScaleManual
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
            dtpScaleTime = new DateTimePicker();
            numScale = new NumericUpDown();
            cbLane = new ComboBox();
            label3 = new Label();
            cbGoodsType = new ComboBox();
            label4 = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            label5 = new Label();
            lblScaleFee = new Label();
            ((System.ComponentModel.ISupportInitialize)numScale).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 24);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(75, 21);
            label1.TabIndex = 0;
            label1.Text = "Thời gian";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 56);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(95, 21);
            label2.TabIndex = 0;
            label2.Text = "Trọng lượng";
            // 
            // dtpScaleTime
            // 
            dtpScaleTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpScaleTime.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            dtpScaleTime.Format = DateTimePickerFormat.Custom;
            dtpScaleTime.Location = new Point(164, 18);
            dtpScaleTime.Name = "dtpScaleTime";
            dtpScaleTime.Size = new Size(403, 29);
            dtpScaleTime.TabIndex = 0;
            // 
            // numScale
            // 
            numScale.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numScale.Location = new Point(164, 54);
            numScale.Margin = new Padding(4);
            numScale.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numScale.Name = "numScale";
            numScale.Size = new Size(403, 29);
            numScale.TabIndex = 1;
            // 
            // cbLane
            // 
            cbLane.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbLane.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLane.FormattingEnabled = true;
            cbLane.Location = new Point(164, 90);
            cbLane.Name = "cbLane";
            cbLane.Size = new Size(403, 29);
            cbLane.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 93);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(54, 21);
            label3.TabIndex = 0;
            label3.Text = "Làn xe";
            // 
            // cbGoodsType
            // 
            cbGoodsType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbGoodsType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGoodsType.FormattingEnabled = true;
            cbGoodsType.Location = new Point(164, 125);
            cbGoodsType.Name = "cbGoodsType";
            cbGoodsType.Size = new Size(403, 29);
            cbGoodsType.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 128);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(78, 21);
            label4.TabIndex = 0;
            label4.Text = "Loại hàng";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(311, 226);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(125, 55);
            btnSave.TabIndex = 4;
            btnSave.Text = "Xác nhận";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(442, 226);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(125, 55);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Đóng";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 176);
            label5.Name = "label5";
            label5.Size = new Size(60, 21);
            label5.TabIndex = 6;
            label5.Text = "Phí cân";
            // 
            // lblScaleFee
            // 
            lblScaleFee.AutoSize = true;
            lblScaleFee.Font = new Font("Segoe UI", 18F);
            lblScaleFee.Location = new Point(164, 167);
            lblScaleFee.Name = "lblScaleFee";
            lblScaleFee.Size = new Size(41, 32);
            lblScaleFee.TabIndex = 7;
            lblScaleFee.Text = "0đ";
            // 
            // frmScaleManual
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(579, 293);
            Controls.Add(lblScaleFee);
            Controls.Add(label5);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cbGoodsType);
            Controls.Add(cbLane);
            Controls.Add(numScale);
            Controls.Add(dtpScaleTime);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "frmScaleManual";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cân thủ công";
            ((System.ComponentModel.ISupportInitialize)numScale).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private DateTimePicker dtpScaleTime;
        private NumericUpDown numScale;
        private ComboBox cbLane;
        private Label label3;
        private ComboBox cbGoodsType;
        private Label label4;
        private Button btnSave;
        private Button btnCancel;
        private Label label5;
        private Label lblScaleFee;
    }
}