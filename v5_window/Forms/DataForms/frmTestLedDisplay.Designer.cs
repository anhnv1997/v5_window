using iPakrkingv5.Controls.Controls.Buttons;

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
            btnOk1 = new BtnOk();
            btnCancel1 = new LblCancel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 11);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 0;
            label1.Text = "Mã Thẻ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 38);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 0;
            label2.Text = "Số Thẻ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 63);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 0;
            label3.Text = "Loại Thẻ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 88);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 0;
            label4.Text = "Trạng Thái";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 112);
            label5.Name = "label5";
            label5.Size = new Size(62, 15);
            label5.TabIndex = 0;
            label5.Text = "Biển Số Xe";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 137);
            label6.Name = "label6";
            label6.Size = new Size(79, 15);
            label6.TabIndex = 0;
            label6.Text = "Thời Gian Vào";
            // 
            // txtCardNumber
            // 
            txtCardNumber.Location = new Point(103, 9);
            txtCardNumber.Margin = new Padding(3, 2, 3, 2);
            txtCardNumber.Name = "txtCardNumber";
            txtCardNumber.Size = new Size(297, 23);
            txtCardNumber.TabIndex = 1;
            txtCardNumber.Text = "CARD NUM";
            // 
            // txtCardNo
            // 
            txtCardNo.Location = new Point(103, 36);
            txtCardNo.Margin = new Padding(3, 2, 3, 2);
            txtCardNo.Name = "txtCardNo";
            txtCardNo.Size = new Size(297, 23);
            txtCardNo.TabIndex = 2;
            txtCardNo.Text = "CARD NO";
            // 
            // txtCardType
            // 
            txtCardType.Location = new Point(103, 61);
            txtCardType.Margin = new Padding(3, 2, 3, 2);
            txtCardType.Name = "txtCardType";
            txtCardType.Size = new Size(297, 23);
            txtCardType.TabIndex = 3;
            txtCardType.Text = "CARD TYPE";
            // 
            // txtEventStatus
            // 
            txtEventStatus.Location = new Point(103, 86);
            txtEventStatus.Margin = new Padding(3, 2, 3, 2);
            txtEventStatus.Name = "txtEventStatus";
            txtEventStatus.Size = new Size(297, 23);
            txtEventStatus.TabIndex = 4;
            txtEventStatus.Text = "EVENT STATUS";
            // 
            // txtPlateNumber
            // 
            txtPlateNumber.Location = new Point(103, 110);
            txtPlateNumber.Margin = new Padding(3, 2, 3, 2);
            txtPlateNumber.Name = "txtPlateNumber";
            txtPlateNumber.Size = new Size(297, 23);
            txtPlateNumber.TabIndex = 5;
            txtPlateNumber.Text = "PLATE NUMBER";
            // 
            // txtMoney
            // 
            txtMoney.Location = new Point(103, 184);
            txtMoney.Margin = new Padding(3, 2, 3, 2);
            txtMoney.Name = "txtMoney";
            txtMoney.Size = new Size(297, 23);
            txtMoney.TabIndex = 8;
            txtMoney.Text = "5000";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(7, 162);
            label7.Name = "label7";
            label7.Size = new Size(73, 15);
            label7.TabIndex = 0;
            label7.Text = "Thời Gian Ra";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(7, 187);
            label8.Name = "label8";
            label8.Size = new Size(61, 15);
            label8.TabIndex = 0;
            label8.Text = "Phí Gửi Xe";
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(103, 135);
            dtpStartTime.Margin = new Padding(3, 2, 3, 2);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.Size = new Size(297, 23);
            dtpStartTime.TabIndex = 6;
            // 
            // dtpEndTime
            // 
            dtpEndTime.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(103, 160);
            dtpEndTime.Margin = new Padding(3, 2, 3, 2);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.Size = new Size(297, 23);
            dtpEndTime.TabIndex = 7;
            // 
            // btnOk1
            // 
            btnOk1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk1.AutoSize = true;
            btnOk1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnOk1.ForeColor = Color.Black;
            btnOk1.Location = new Point(254, 214);
            btnOk1.Margin = new Padding(3, 2, 3, 2);
            btnOk1.Name = "btnOk1";
            btnOk1.Size = new Size(83, 30);
            btnOk1.TabIndex = 109;
            btnOk1.Text = "Xác nhận";
            btnOk1.Click += btnOk1_Click_1;
            // 
            // btnCancel1
            // 
            btnCancel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel1.AutoSize = true;
            btnCancel1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnCancel1.ForeColor = Color.Black;
            btnCancel1.Location = new Point(343, 214);
            btnCancel1.Margin = new Padding(3, 2, 3, 2);
            btnCancel1.Name = "btnCancel1";
            btnCancel1.Size = new Size(57, 30);
            btnCancel1.TabIndex = 10;
            btnCancel1.Text = "Đóng";
            // 
            // frmTestLedDisplay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 273);
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
            Margin = new Padding(3, 2, 3, 2);
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
        private BtnOk btnOk1;
        private LblCancel btnCancel1;
    }
}