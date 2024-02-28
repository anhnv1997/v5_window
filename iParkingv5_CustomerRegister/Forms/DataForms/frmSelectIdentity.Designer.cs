namespace iParkingv5_CustomerRegister.Forms.DataForms
{
    partial class frmSelectIdentity
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
            lblTitle = new Label();
            lblKeyword = new Label();
            txtKeyword = new TextBox();
            lblSearch = new iPakrkingv5.Controls.Controls.Buttons.LblSearch();
            dgvData = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            dgv_col_select = new DataGridViewCheckBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            lblGuide = new Label();
            panelData = new Panel();
            btnCancel1 = new iPakrkingv5.Controls.Controls.Buttons.LblCancel();
            btnOk1 = new iPakrkingv5.Controls.Controls.Buttons.LblOk();
            ucNotify1 = new iPakrkingv5.Controls.Usercontrols.BuildControls.ucNotify();
            ucLoading1 = new iPakrkingv5.Controls.Usercontrols.BuildControls.ucLoading();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            panelData.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.Location = new Point(3, 21);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(753, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Chọn định danh phương tiện được phép sử dụng";
            // 
            // lblKeyword
            // 
            lblKeyword.AutoSize = true;
            lblKeyword.Location = new Point(15, 72);
            lblKeyword.Name = "lblKeyword";
            lblKeyword.Size = new Size(50, 20);
            lblKeyword.TabIndex = 1;
            lblKeyword.Text = "label2";
            // 
            // txtKeyword
            // 
            txtKeyword.Location = new Point(86, 69);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.Size = new Size(334, 27);
            txtKeyword.TabIndex = 2;
            // 
            // lblSearch
            // 
            lblSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblSearch.Location = new Point(426, 69);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(50, 27);
            lblSearch.TabIndex = 3;
            lblSearch.UseVisualStyleBackColor = true;
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
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Columns.AddRange(new DataGridViewColumn[] { Column1, dgv_col_select, Column8, Column3, Column4, Column5, Column6, Column7 });
            dgvData.Location = new Point(78, 134);
            dgvData.Name = "dgvData";
            dgvData.RowHeadersVisible = false;
            dgvData.RowTemplate.Height = 29;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.Size = new Size(726, 286);
            dgvData.TabIndex = 4;
            // 
            // Column1
            // 
            Column1.HeaderText = "ID";
            Column1.Name = "Column1";
            Column1.Visible = false;
            Column1.Width = 41;
            // 
            // dgv_col_select
            // 
            dgv_col_select.HeaderText = "   ";
            dgv_col_select.Name = "dgv_col_select";
            dgv_col_select.Width = 37;
            // 
            // Column8
            // 
            Column8.HeaderText = "STT";
            Column8.Name = "Column8";
            Column8.Width = 70;
            // 
            // Column3
            // 
            Column3.HeaderText = "Tên";
            Column3.Name = "Column3";
            Column3.Resizable = DataGridViewTriState.True;
            Column3.SortMode = DataGridViewColumnSortMode.NotSortable;
            Column3.Width = 50;
            // 
            // Column4
            // 
            Column4.HeaderText = "Mã";
            Column4.Name = "Column4";
            Column4.Resizable = DataGridViewTriState.True;
            Column4.SortMode = DataGridViewColumnSortMode.NotSortable;
            Column4.Width = 47;
            // 
            // Column5
            // 
            Column5.HeaderText = "Nhóm định danh";
            Column5.Name = "Column5";
            Column5.Resizable = DataGridViewTriState.True;
            Column5.SortMode = DataGridViewColumnSortMode.NotSortable;
            Column5.Width = 143;
            // 
            // Column6
            // 
            Column6.HeaderText = "Loại";
            Column6.Name = "Column6";
            Column6.Resizable = DataGridViewTriState.True;
            Column6.SortMode = DataGridViewColumnSortMode.NotSortable;
            Column6.Width = 54;
            // 
            // Column7
            // 
            Column7.HeaderText = "Ghi chú";
            Column7.Name = "Column7";
            Column7.Resizable = DataGridViewTriState.True;
            Column7.SortMode = DataGridViewColumnSortMode.NotSortable;
            Column7.Width = 78;
            // 
            // lblGuide
            // 
            lblGuide.AutoSize = true;
            lblGuide.Location = new Point(15, 111);
            lblGuide.Name = "lblGuide";
            lblGuide.Size = new Size(134, 20);
            lblGuide.TabIndex = 5;
            lblGuide.Text = "Danh sách đã chọn";
            // 
            // panelData
            // 
            panelData.Controls.Add(btnCancel1);
            panelData.Controls.Add(btnOk1);
            panelData.Controls.Add(ucNotify1);
            panelData.Controls.Add(ucLoading1);
            panelData.Controls.Add(lblTitle);
            panelData.Controls.Add(dgvData);
            panelData.Controls.Add(lblGuide);
            panelData.Controls.Add(lblSearch);
            panelData.Controls.Add(lblKeyword);
            panelData.Controls.Add(txtKeyword);
            panelData.Dock = DockStyle.Fill;
            panelData.Location = new Point(0, 0);
            panelData.Name = "panelData";
            panelData.Size = new Size(1042, 450);
            panelData.TabIndex = 6;
            // 
            // btnCancel1
            // 
            btnCancel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel1.Location = new Point(723, 406);
            btnCancel1.Name = "btnCancel1";
            btnCancel1.Size = new Size(81, 23);
            btnCancel1.TabIndex = 9;
            btnCancel1.Text = "lblCancel1";
            btnCancel1.UseVisualStyleBackColor = true;
            // 
            // btnOk1
            // 
            btnOk1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnOk1.Location = new Point(642, 406);
            btnOk1.Name = "btnOk1";
            btnOk1.Size = new Size(75, 23);
            btnOk1.TabIndex = 8;
            btnOk1.Text = "lblOk1";
            btnOk1.UseVisualStyleBackColor = true;
            // 
            // ucNotify1
            // 
            ucNotify1.BackColor = Color.FromArgb(255, 224, 192);
            ucNotify1.Location = new Point(395, 129);
            ucNotify1.MaximumSize = new Size(333, 356);
            ucNotify1.Message = "Nội dung thông báo";
            ucNotify1.MinimumSize = new Size(333, 356);
            ucNotify1.Name = "ucNotify1";
            ucNotify1.NotiType = iPakrkingv5.Controls.Usercontrols.BuildControls.ucNotify.EmNotiType.Information;
            ucNotify1.Size = new Size(333, 356);
            ucNotify1.TabIndex = 7;
            // 
            // ucLoading1
            // 
            ucLoading1.BackColor = Color.FromArgb(255, 224, 192);
            ucLoading1.Language = IPaking.Ultility.TextManagement.EmLanguage.Vietnamese;
            ucLoading1.Location = new Point(414, 174);
            ucLoading1.Message = "Preparing to download";
            ucLoading1.Name = "ucLoading1";
            ucLoading1.Size = new Size(392, 188);
            ucLoading1.TabIndex = 6;
            // 
            // frmSelectIdentity
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1042, 450);
            Controls.Add(panelData);
            Name = "frmSelectIdentity";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chọn định danh";
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            panelData.ResumeLayout(false);
            panelData.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private Label lblKeyword;
        private TextBox txtKeyword;
        private iPakrkingv5.Controls.Controls.Buttons.LblSearch lblSearch;
        private DataGridView dgvData;
        private Label lblGuide;
        private Panel panelData;
        private iPakrkingv5.Controls.Usercontrols.BuildControls.ucNotify ucNotify1;
        private iPakrkingv5.Controls.Usercontrols.BuildControls.ucLoading ucLoading1;
        private iPakrkingv5.Controls.Controls.Buttons.LblCancel btnCancel1;
        private iPakrkingv5.Controls.Controls.Buttons.LblOk btnOk1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewCheckBoxColumn dgv_col_select;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
    }
}