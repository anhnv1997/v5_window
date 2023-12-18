namespace iParkingv5_window.Forms.DataForms
{
    partial class frmSelectCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectCard));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            blTittle = new Label();
            btnReTakePhoto = new Button();
            btnWriteIn = new Button();
            dgvCard = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            panelSearch = new Panel();
            btnSearch = new Button();
            txtPlateNumber = new TextBox();
            lblPlateNumber = new Label();
            txtCardNumber = new TextBox();
            lblCardNumber = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvCard).BeginInit();
            panelSearch.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // blTittle
            // 
            blTittle.AutoSize = true;
            blTittle.Dock = DockStyle.Top;
            blTittle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            blTittle.ForeColor = Color.FromArgb(0, 64, 0);
            blTittle.Location = new Point(0, 0);
            blTittle.Name = "blTittle";
            blTittle.Size = new Size(159, 30);
            blTittle.TabIndex = 0;
            blTittle.Text = "Danh sách thẻ";
            // 
            // btnReTakePhoto
            // 
            btnReTakePhoto.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnReTakePhoto.AutoSize = true;
            btnReTakePhoto.Image = (Image)resources.GetObject("btnReTakePhoto.Image");
            btnReTakePhoto.ImageAlign = ContentAlignment.TopCenter;
            btnReTakePhoto.Location = new Point(694, 4);
            btnReTakePhoto.Name = "btnReTakePhoto";
            btnReTakePhoto.Size = new Size(106, 62);
            btnReTakePhoto.TabIndex = 5;
            btnReTakePhoto.Text = "Đóng";
            btnReTakePhoto.TextImageRelation = TextImageRelation.ImageAboveText;
            btnReTakePhoto.UseVisualStyleBackColor = true;
            // 
            // btnWriteIn
            // 
            btnWriteIn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnWriteIn.AutoSize = true;
            btnWriteIn.Image = Properties.Resources.confirm;
            btnWriteIn.ImageAlign = ContentAlignment.TopCenter;
            btnWriteIn.Location = new Point(582, 4);
            btnWriteIn.Name = "btnWriteIn";
            btnWriteIn.Size = new Size(106, 62);
            btnWriteIn.TabIndex = 6;
            btnWriteIn.Text = "Xác nhận";
            btnWriteIn.TextImageRelation = TextImageRelation.ImageAboveText;
            btnWriteIn.UseVisualStyleBackColor = true;
            // 
            // dgvCard
            // 
            dgvCard.AllowUserToAddRows = false;
            dgvCard.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(192, 255, 255);
            dgvCard.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvCard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCard.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCard.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvCard.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCard.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column6, Column4, Column5, Column7 });
            dgvCard.Dock = DockStyle.Fill;
            dgvCard.Location = new Point(0, 85);
            dgvCard.Name = "dgvCard";
            dgvCard.ReadOnly = true;
            dgvCard.RowHeadersVisible = false;
            dataGridViewCellStyle3.Padding = new Padding(3);
            dgvCard.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvCard.RowTemplate.Height = 29;
            dgvCard.Size = new Size(800, 296);
            dgvCard.TabIndex = 7;
            // 
            // Column1
            // 
            Column1.HeaderText = "ID";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Visible = false;
            Column1.Width = 63;
            // 
            // Column2
            // 
            Column2.HeaderText = "STT";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 76;
            // 
            // Column3
            // 
            Column3.HeaderText = "Mã thẻ";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 104;
            // 
            // Column6
            // 
            Column6.HeaderText = "Số thẻ";
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            Column6.Width = 99;
            // 
            // Column4
            // 
            Column4.HeaderText = "Nhóm thẻ";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Width = 131;
            // 
            // Column5
            // 
            Column5.HeaderText = "Biển số xe";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.Width = 133;
            // 
            // Column7
            // 
            Column7.HeaderText = "Khách hàng";
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            Column7.Width = 146;
            // 
            // panelSearch
            // 
            panelSearch.Controls.Add(btnSearch);
            panelSearch.Controls.Add(txtPlateNumber);
            panelSearch.Controls.Add(lblPlateNumber);
            panelSearch.Controls.Add(txtCardNumber);
            panelSearch.Controls.Add(lblCardNumber);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Location = new Point(0, 30);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(800, 55);
            panelSearch.TabIndex = 8;
            // 
            // btnSearch
            // 
            btnSearch.AutoSize = true;
            btnSearch.Image = (Image)resources.GetObject("btnSearch.Image");
            btnSearch.Location = new Point(613, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(112, 46);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtPlateNumber
            // 
            txtPlateNumber.Location = new Point(383, 12);
            txtPlateNumber.Name = "txtPlateNumber";
            txtPlateNumber.Size = new Size(217, 27);
            txtPlateNumber.TabIndex = 1;
            // 
            // lblPlateNumber
            // 
            lblPlateNumber.AutoSize = true;
            lblPlateNumber.Location = new Point(301, 15);
            lblPlateNumber.Name = "lblPlateNumber";
            lblPlateNumber.Size = new Size(76, 20);
            lblPlateNumber.TabIndex = 0;
            lblPlateNumber.Text = "Biển số xe";
            // 
            // txtCardNumber
            // 
            txtCardNumber.Location = new Point(59, 12);
            txtCardNumber.Name = "txtCardNumber";
            txtCardNumber.Size = new Size(217, 27);
            txtCardNumber.TabIndex = 1;
            // 
            // lblCardNumber
            // 
            lblCardNumber.AutoSize = true;
            lblCardNumber.Location = new Point(3, 15);
            lblCardNumber.Name = "lblCardNumber";
            lblCardNumber.Size = new Size(55, 20);
            lblCardNumber.TabIndex = 0;
            lblCardNumber.Text = "Mã thẻ";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnReTakePhoto);
            panel1.Controls.Add(btnWriteIn);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 381);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 69);
            panel1.TabIndex = 9;
            // 
            // frmSelectCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvCard);
            Controls.Add(panel1);
            Controls.Add(panelSearch);
            Controls.Add(blTittle);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmSelectCard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lựa chọn thẻ";
            ((System.ComponentModel.ISupportInitialize)dgvCard).EndInit();
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label blTittle;
        private Button btnReTakePhoto;
        private Button btnWriteIn;
        private DataGridView dgvCard;
        private Panel panelSearch;
        private Button btnSearch;
        private TextBox txtPlateNumber;
        private Label lblPlateNumber;
        private TextBox txtCardNumber;
        private Label lblCardNumber;
        private Panel panel1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column7;
    }
}