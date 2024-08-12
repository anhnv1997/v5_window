using iPakrkingv5.Controls.Controls.Buttons;

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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectCard));
            lblTittle = new Label();
            dgvData = new DataGridView();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            btnSearch = new BtnSearch();
            txtIdentity = new TextBox();
            lblCardNumber = new Label();
            btnCancel = new LblCancel();
            btnSelectCard = new BtnOk();
            panelData = new Panel();
            lblGuide = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            panelData.SuspendLayout();
            SuspendLayout();
            // 
            // lblTittle
            // 
            lblTittle.AutoSize = true;
            lblTittle.BackColor = Color.Transparent;
            lblTittle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTittle.ForeColor = Color.Black;
            lblTittle.Location = new Point(10, 7);
            lblTittle.Name = "lblTittle";
            lblTittle.Size = new Size(229, 30);
            lblTittle.TabIndex = 0;
            lblTittle.Text = "Danh sách định danh";
            // 
            // dgvData
            // 
            dgvData.AllowUserToAddRows = false;
            dgvData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(192, 255, 255);
            dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvData.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Columns.AddRange(new DataGridViewColumn[] { Column2, Column3, Column6, Column4, Column1 });
            dgvData.Location = new Point(13, 65);
            dgvData.Margin = new Padding(3, 2, 3, 2);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowHeadersVisible = false;
            dataGridViewCellStyle3.Padding = new Padding(3);
            dgvData.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvData.RowTemplate.Height = 29;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.Size = new Size(675, 221);
            dgvData.TabIndex = 7;
            dgvData.CellDoubleClick += DgvCard_CellDoubleClick;
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
            Column3.HeaderText = "Tên";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 74;
            // 
            // Column6
            // 
            Column6.HeaderText = "Mã";
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            Column6.Width = 71;
            // 
            // Column4
            // 
            Column4.HeaderText = "Loại";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Width = 80;
            // 
            // Column1
            // 
            Column1.HeaderText = "ID";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Visible = false;
            Column1.Width = 63;
            // 
            // btnSearch
            // 
            btnSearch.AutoSize = true;
            btnSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnSearch.ForeColor = Color.Black;
            btnSearch.Location = new Point(331, 34);
            btnSearch.Margin = new Padding(3, 2, 3, 2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(84, 30);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm kiếm";
            // 
            // txtIdentity
            // 
            txtIdentity.Location = new Point(112, 40);
            txtIdentity.Margin = new Padding(3, 2, 3, 2);
            txtIdentity.Name = "txtIdentity";
            txtIdentity.Size = new Size(190, 23);
            txtIdentity.TabIndex = 1;
            // 
            // lblCardNumber
            // 
            lblCardNumber.AutoSize = true;
            lblCardNumber.BackColor = Color.Transparent;
            lblCardNumber.Location = new Point(19, 42);
            lblCardNumber.Name = "lblCardNumber";
            lblCardNumber.Size = new Size(81, 15);
            lblCardNumber.TabIndex = 0;
            lblCardNumber.Text = "Mã định danh";
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.AutoSize = true;
            btnCancel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(669, 393);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(57, 30);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Đóng";
            // 
            // btnSelectCard
            // 
            btnSelectCard.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSelectCard.AutoSize = true;
            btnSelectCard.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnSelectCard.ForeColor = Color.Black;
            btnSelectCard.Location = new Point(580, 393);
            btnSelectCard.Margin = new Padding(3, 2, 3, 2);
            btnSelectCard.Name = "btnSelectCard";
            btnSelectCard.Size = new Size(83, 30);
            btnSelectCard.TabIndex = 4;
            btnSelectCard.Text = "Xác nhận";
            // 
            // panelData
            // 
            panelData.Controls.Add(lblGuide);
            panelData.Controls.Add(lblTittle);
            panelData.Controls.Add(btnCancel);
            panelData.Controls.Add(txtIdentity);
            panelData.Controls.Add(btnSelectCard);
            panelData.Controls.Add(btnSearch);
            panelData.Controls.Add(dgvData);
            panelData.Controls.Add(lblCardNumber);
            panelData.Dock = DockStyle.Fill;
            panelData.Location = new Point(0, 0);
            panelData.Margin = new Padding(3, 2, 3, 2);
            panelData.Name = "panelData";
            panelData.Size = new Size(767, 434);
            panelData.TabIndex = 8;
            // 
            // lblGuide
            // 
            lblGuide.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblGuide.ForeColor = Color.FromArgb(255, 128, 0);
            lblGuide.Location = new Point(13, 378);
            lblGuide.Name = "lblGuide";
            lblGuide.Size = new Size(430, 45);
            lblGuide.TabIndex = 8;
            lblGuide.Text = "Enter để tìm kiếm.\r\nKích đúp chuột hoặc bấm xác nhận để chọn định danh.";
            lblGuide.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // frmSelectCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(767, 434);
            Controls.Add(panelData);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmSelectCard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lựa chọn thẻ";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            panelData.ResumeLayout(false);
            panelData.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTittle;
        private DataGridView dgvData;
        private TextBox txtIdentity;
        private Label lblCardNumber;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column1;
        private LblCancel btnCancel;
        private BtnOk btnSelectCard;
        private BtnSearch btnSearch;
        private Panel panelData;
        private Label lblGuide;
    }
}