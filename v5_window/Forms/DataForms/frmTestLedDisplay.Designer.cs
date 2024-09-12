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
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(5, 1);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(102, 53);
            label1.TabIndex = 0;
            label1.Text = "Mã Thẻ";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(5, 55);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(102, 53);
            label2.TabIndex = 0;
            label2.Text = "Số Thẻ";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(5, 109);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(102, 53);
            label3.TabIndex = 0;
            label3.Text = "Loại Thẻ";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(5, 163);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(102, 53);
            label4.TabIndex = 0;
            label4.Text = "Trạng Thái";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(5, 217);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(102, 53);
            label5.TabIndex = 0;
            label5.Text = "Biển Số Xe";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.Dock = DockStyle.Fill;
            label6.Location = new Point(5, 271);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(102, 53);
            label6.TabIndex = 0;
            label6.Text = "Thời Gian Vào";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtCardNumber
            // 
            txtCardNumber.Dock = DockStyle.Bottom;
            txtCardNumber.Location = new Point(116, 22);
            txtCardNumber.Margin = new Padding(4, 3, 4, 3);
            txtCardNumber.Name = "txtCardNumber";
            txtCardNumber.Size = new Size(877, 29);
            txtCardNumber.TabIndex = 1;
            txtCardNumber.Text = "CARD NUM";
            // 
            // txtCardNo
            // 
            txtCardNo.Dock = DockStyle.Bottom;
            txtCardNo.Location = new Point(116, 76);
            txtCardNo.Margin = new Padding(4, 3, 4, 3);
            txtCardNo.Name = "txtCardNo";
            txtCardNo.Size = new Size(877, 29);
            txtCardNo.TabIndex = 2;
            txtCardNo.Text = "CARD NO";
            // 
            // txtCardType
            // 
            txtCardType.Dock = DockStyle.Bottom;
            txtCardType.Location = new Point(116, 130);
            txtCardType.Margin = new Padding(4, 3, 4, 3);
            txtCardType.Name = "txtCardType";
            txtCardType.Size = new Size(877, 29);
            txtCardType.TabIndex = 3;
            txtCardType.Text = "CARD TYPE";
            // 
            // txtEventStatus
            // 
            txtEventStatus.Dock = DockStyle.Bottom;
            txtEventStatus.Location = new Point(116, 184);
            txtEventStatus.Margin = new Padding(4, 3, 4, 3);
            txtEventStatus.Name = "txtEventStatus";
            txtEventStatus.Size = new Size(877, 29);
            txtEventStatus.TabIndex = 4;
            txtEventStatus.Text = "EVENT STATUS";
            // 
            // txtPlateNumber
            // 
            txtPlateNumber.Dock = DockStyle.Bottom;
            txtPlateNumber.Location = new Point(116, 238);
            txtPlateNumber.Margin = new Padding(4, 3, 4, 3);
            txtPlateNumber.Name = "txtPlateNumber";
            txtPlateNumber.Size = new Size(877, 29);
            txtPlateNumber.TabIndex = 5;
            txtPlateNumber.Text = "PLATE NUMBER";
            // 
            // txtMoney
            // 
            txtMoney.Dock = DockStyle.Bottom;
            txtMoney.Location = new Point(116, 400);
            txtMoney.Margin = new Padding(4, 3, 4, 3);
            txtMoney.Name = "txtMoney";
            txtMoney.Size = new Size(877, 29);
            txtMoney.TabIndex = 8;
            txtMoney.Text = "5000";
            // 
            // label7
            // 
            label7.Dock = DockStyle.Fill;
            label7.Location = new Point(5, 325);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(102, 53);
            label7.TabIndex = 0;
            label7.Text = "Thời Gian Ra";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.Dock = DockStyle.Fill;
            label8.Location = new Point(5, 379);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(102, 53);
            label8.TabIndex = 0;
            label8.Text = "Phí Gửi Xe";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtpStartTime.Dock = DockStyle.Bottom;
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(116, 292);
            dtpStartTime.Margin = new Padding(4, 3, 4, 3);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.Size = new Size(877, 29);
            dtpStartTime.TabIndex = 6;
            // 
            // dtpEndTime
            // 
            dtpEndTime.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtpEndTime.Dock = DockStyle.Bottom;
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(116, 346);
            dtpEndTime.Margin = new Padding(4, 3, 4, 3);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.Size = new Size(877, 29);
            dtpEndTime.TabIndex = 7;
            // 
            // btnOk1
            // 
            btnOk1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk1.AutoSize = true;
            btnOk1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnOk1.ForeColor = Color.Black;
            btnOk1.Location = new Point(798, 442);
            btnOk1.Margin = new Padding(4, 3, 4, 3);
            btnOk1.Name = "btnOk1";
            btnOk1.Size = new Size(107, 42);
            btnOk1.TabIndex = 9;
            btnOk1.Text = "Xác nhận";
            // 
            // btnCancel1
            // 
            btnCancel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel1.AutoSize = true;
            btnCancel1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnCancel1.ForeColor = Color.Black;
            btnCancel1.Location = new Point(912, 442);
            btnCancel1.Margin = new Padding(4, 3, 4, 3);
            btnCancel1.Name = "btnCancel1";
            btnCancel1.Size = new Size(73, 42);
            btnCancel1.TabIndex = 10;
            btnCancel1.Text = "Đóng";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(txtCardNumber, 1, 0);
            tableLayoutPanel1.Controls.Add(txtCardNo, 1, 1);
            tableLayoutPanel1.Controls.Add(txtCardType, 1, 2);
            tableLayoutPanel1.Controls.Add(txtEventStatus, 1, 3);
            tableLayoutPanel1.Controls.Add(dtpStartTime, 1, 5);
            tableLayoutPanel1.Controls.Add(dtpEndTime, 1, 6);
            tableLayoutPanel1.Controls.Add(txtPlateNumber, 1, 4);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(label5, 0, 4);
            tableLayoutPanel1.Controls.Add(txtMoney, 1, 7);
            tableLayoutPanel1.Controls.Add(label6, 0, 5);
            tableLayoutPanel1.Controls.Add(label7, 0, 6);
            tableLayoutPanel1.Controls.Add(label8, 0, 7);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.Size = new Size(998, 433);
            tableLayoutPanel1.TabIndex = 110;
            // 
            // frmTestLedDisplay
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(998, 496);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(btnCancel1);
            Controls.Add(btnOk1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "frmTestLedDisplay";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Test Hiển Thị Bảng LED";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
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
        private TableLayoutPanel tableLayoutPanel1;
    }
}