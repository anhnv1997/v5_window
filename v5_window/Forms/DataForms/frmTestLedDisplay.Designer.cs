namespace iParkingv5_window.Forms.DataForms
{
    partial class frmTestLedDisplay
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
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtCardNumber = new TextBox();
            txtCardNo = new TextBox();
            txtCardType = new TextBox();
            txtEventStatus = new TextBox();
            txtPlateNumber = new TextBox();
            txtMoney = new TextBox();
            label7 = new Label();
            label8 = new Label();
            dtpStartTime = new DateTimePicker();
            dtpEndTime = new DateTimePicker();
            btnOk1 = new Controls.Buttons.LblOk();
            btnCancel1 = new Controls.Buttons.LblCancel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 15);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã Thẻ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 51);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 0;
            label2.Text = "Số Thẻ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 84);
            label3.Name = "label3";
            label3.Size = new Size(65, 20);
            label3.TabIndex = 0;
            label3.Text = "Loại Thẻ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 117);
            label4.Name = "label4";
            label4.Size = new Size(78, 20);
            label4.TabIndex = 0;
            label4.Text = "Trạng Thái";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 150);
            label5.Name = "label5";
            label5.Size = new Size(80, 20);
            label5.TabIndex = 0;
            label5.Text = "Biển Số Xe";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(8, 183);
            label6.Name = "label6";
            label6.Size = new Size(101, 20);
            label6.TabIndex = 0;
            label6.Text = "Thời Gian Vào";
            // 
            // txtCardNumber
            // 
            txtCardNumber.Location = new Point(118, 12);
            txtCardNumber.Name = "txtCardNumber";
            txtCardNumber.Size = new Size(339, 27);
            txtCardNumber.TabIndex = 1;
            txtCardNumber.Text = "CARD NUM";
            // 
            // txtCardNo
            // 
            txtCardNo.Location = new Point(118, 48);
            txtCardNo.Name = "txtCardNo";
            txtCardNo.Size = new Size(339, 27);
            txtCardNo.TabIndex = 2;
            txtCardNo.Text = "CARD NO";
            // 
            // txtCardType
            // 
            txtCardType.Location = new Point(118, 81);
            txtCardType.Name = "txtCardType";
            txtCardType.Size = new Size(339, 27);
            txtCardType.TabIndex = 3;
            txtCardType.Text = "CARD TYPE";
            // 
            // txtEventStatus
            // 
            txtEventStatus.Location = new Point(118, 114);
            txtEventStatus.Name = "txtEventStatus";
            txtEventStatus.Size = new Size(339, 27);
            txtEventStatus.TabIndex = 4;
            txtEventStatus.Text = "EVENT STATUS";
            // 
            // txtPlateNumber
            // 
            txtPlateNumber.Location = new Point(118, 147);
            txtPlateNumber.Name = "txtPlateNumber";
            txtPlateNumber.Size = new Size(339, 27);
            txtPlateNumber.TabIndex = 5;
            txtPlateNumber.Text = "PLATE NUMBER";
            // 
            // txtMoney
            // 
            txtMoney.Location = new Point(118, 246);
            txtMoney.Name = "txtMoney";
            txtMoney.Size = new Size(339, 27);
            txtMoney.TabIndex = 8;
            txtMoney.Text = "5000";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(8, 216);
            label7.Name = "label7";
            label7.Size = new Size(93, 20);
            label7.TabIndex = 0;
            label7.Text = "Thời Gian Ra";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(8, 249);
            label8.Name = "label8";
            label8.Size = new Size(77, 20);
            label8.TabIndex = 0;
            label8.Text = "Phí Gửi Xe";
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(118, 180);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.Size = new Size(339, 27);
            dtpStartTime.TabIndex = 6;
            // 
            // dtpEndTime
            // 
            dtpEndTime.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(118, 213);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.Size = new Size(339, 27);
            dtpEndTime.TabIndex = 7;
            // 
            // btnOk1
            // 
            btnOk1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk1.AutoSize = true;
            btnOk1.BorderStyle = BorderStyle.Fixed3D;
            btnOk1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnOk1.ForeColor = Color.Black;
            btnOk1.Location = new Point(327, 304);
            btnOk1.Name = "btnOk1";
            btnOk1.Size = new Size(75, 22);
            btnOk1.TabIndex = 109;
            btnOk1.Text = "Xác nhận";
            // 
            // btnCancel1
            // 
            btnCancel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel1.AutoSize = true;
            btnCancel1.BorderStyle = BorderStyle.Fixed3D;
            btnCancel1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnCancel1.ForeColor = Color.Black;
            btnCancel1.Location = new Point(408, 304);
            btnCancel1.Name = "btnCancel1";
            btnCancel1.Size = new Size(49, 22);
            btnCancel1.TabIndex = 10;
            btnCancel1.Text = "Đóng";
            // 
            // frmTestLedDisplay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(473, 364);
            Controls.Add(btnCancel1);
            Controls.Add(btnOk1);
            Controls.Add(dtpEndTime);
            Controls.Add(dtpStartTime);
            Controls.Add(txtMoney);
            Controls.Add(txtPlateNumber);
            Controls.Add(txtEventStatus);
            Controls.Add(txtCardType);
            Controls.Add(txtCardNo);
            Controls.Add(txtCardNumber);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "frmTestLedDisplay";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Test Hiển Thị Bảng LED";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtCardNumber;
        private TextBox txtCardNo;
        private TextBox txtCardType;
        private TextBox txtEventStatus;
        private TextBox txtPlateNumber;
        private TextBox txtMoney;
        private Label label7;
        private Label label8;
        private DateTimePicker dtpStartTime;
        private DateTimePicker dtpEndTime;
        private Controls.Buttons.LblOk btnOk1;
        private Controls.Buttons.LblCancel btnCancel1;
    }
}