namespace iParkingv5_window.Forms.ReportForms
{
    partial class frmConfirmCardGroup
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
            tableLayoutPanel1 = new TableLayoutPanel();
            lblPlate = new Label();
            lblNew = new Label();
            lblOld = new Label();
            panel1 = new Panel();
            button2 = new Button();
            button1 = new Button();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(6, 1);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(302, 95);
            label1.TabIndex = 0;
            label1.Text = "Biển số xe";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(6, 97);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(302, 95);
            label2.TabIndex = 0;
            label2.Text = "Nhóm thẻ đang sử dụng";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(6, 193);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(302, 97);
            label3.TabIndex = 0;
            label3.Text = "Nhóm thẻ sử dụng gần nhất";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34.81153F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65.18847F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(lblPlate, 1, 0);
            tableLayoutPanel1.Controls.Add(lblNew, 1, 1);
            tableLayoutPanel1.Controls.Add(lblOld, 1, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Size = new Size(902, 291);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // lblPlate
            // 
            lblPlate.Dock = DockStyle.Fill;
            lblPlate.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblPlate.Location = new Point(317, 1);
            lblPlate.Name = "lblPlate";
            lblPlate.Size = new Size(581, 95);
            lblPlate.TabIndex = 1;
            lblPlate.Text = "BSX";
            lblPlate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblNew
            // 
            lblNew.Dock = DockStyle.Fill;
            lblNew.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblNew.Location = new Point(317, 97);
            lblNew.Name = "lblNew";
            lblNew.Size = new Size(581, 95);
            lblNew.TabIndex = 2;
            lblNew.Text = "Nhóm thẻ mới";
            lblNew.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblOld
            // 
            lblOld.Dock = DockStyle.Fill;
            lblOld.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblOld.Location = new Point(317, 193);
            lblOld.Name = "lblOld";
            lblOld.Size = new Size(581, 97);
            lblOld.TabIndex = 3;
            lblOld.Text = "Nhóm thẻ cũ";
            lblOld.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 291);
            panel1.Name = "panel1";
            panel1.Size = new Size(902, 100);
            panel1.TabIndex = 2;
            // 
            // button2
            // 
            button2.BackColor = Color.Maroon;
            button2.DialogResult = DialogResult.Cancel;
            button2.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(733, 38);
            button2.Name = "button2";
            button2.Size = new Size(157, 50);
            button2.TabIndex = 1;
            button2.Text = "Đóng";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Green;
            button1.DialogResult = DialogResult.OK;
            button1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(520, 38);
            button1.Name = "button1";
            button1.Size = new Size(157, 50);
            button1.TabIndex = 0;
            button1.Text = "Xác nhận";
            button1.UseVisualStyleBackColor = false;
            // 
            // frmConfirmCardGroup
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(902, 391);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 16F);
            Margin = new Padding(5, 6, 5, 6);
            Name = "frmConfirmCardGroup";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Xác nhận thông tin";
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblPlate;
        private Label lblNew;
        private Label lblOld;
        private Panel panel1;
        private Button button2;
        private Button button1;
    }
}