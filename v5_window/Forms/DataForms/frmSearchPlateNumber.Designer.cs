using iPakrkingv5.Controls.Controls.Buttons;
using iPakrkingv5.Controls.Usercontrols.BuildControls;

namespace iParkingv5_CustomerRegister.Forms
{
    partial class frmSearchPlateNumber
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchPlateNumber));
            panelData = new Panel();
            ucLoading1 = new ucLoading();
            lblTitle = new Label();
            btnCancel1 = new LblCancel();
            btnOk1 = new BtnOk();
            btnSearch = new BtnSearch();
            ucNotify1 = new ucNotify();
            lblKeyword = new Label();
            txtKeyword = new TextBox();
            dgvData = new DataGridView();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column11 = new DataGridViewTextBoxColumn();
            Column10 = new DataGridViewTextBoxColumn();
            Column12 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            panelData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // panelData
            // 
            panelData.Controls.Add(ucLoading1);
            panelData.Controls.Add(lblTitle);
            panelData.Controls.Add(btnCancel1);
            panelData.Controls.Add(btnOk1);
            panelData.Controls.Add(btnSearch);
            panelData.Controls.Add(ucNotify1);
            panelData.Controls.Add(lblKeyword);
            panelData.Controls.Add(txtKeyword);
            panelData.Controls.Add(dgvData);
            panelData.Dock = DockStyle.Fill;
            panelData.Location = new Point(0, 0);
            panelData.Name = "panelData";
            panelData.Size = new Size(894, 496);
            panelData.TabIndex = 0;
            // 
            // ucLoading1
            // 
            ucLoading1.BackColor = Color.FromArgb(255, 224, 192);
            ucLoading1.Language = IPaking.Ultility.TextManagement.EmLanguage.Vietnamese;
            ucLoading1.Location = new Point(27, 316);
            ucLoading1.Message = "Preparing to download";
            ucLoading1.Name = "ucLoading1";
            ucLoading1.Size = new Size(392, 188);
            ucLoading1.TabIndex = 28;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.Location = new Point(83, 35);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(367, 45);
            lblTitle.TabIndex = 26;
            lblTitle.Text = "Danh sách phương tiện";
            // 
            // btnCancel1
            // 
            btnCancel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel1.AutoSize = true;
            btnCancel1.Location = new Point(552, 355);
            btnCancel1.Name = "btnCancel1";
            btnCancel1.Size = new Size(88, 30);
            btnCancel1.TabIndex = 4;
            btnCancel1.Text = "Đóng";
            // 
            // btnOk1
            // 
            btnOk1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk1.AutoSize = true;
            btnOk1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnOk1.Location = new Point(490, 355);
            btnOk1.Name = "btnOk1";
            btnOk1.Size = new Size(64, 30);
            btnOk1.TabIndex = 3;
            // 
            // lblSearch
            // 
            btnSearch.AutoSize = true;
            btnSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnSearch.Location = new Point(560, 98);
            btnSearch.Name = "lblSearch";
            btnSearch.Size = new Size(91, 30);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "lblSearch1";
            // 
            // ucNotify1
            // 
            ucNotify1.BackColor = Color.FromArgb(255, 224, 192);
            ucNotify1.Location = new Point(579, 96);
            ucNotify1.MaximumSize = new Size(333, 356);
            ucNotify1.Message = "Nội dung thông báo";
            ucNotify1.MinimumSize = new Size(333, 356);
            ucNotify1.Name = "ucNotify1";
            ucNotify1.NotiType = ucNotify.EmNotiType.Information;
            ucNotify1.Size = new Size(333, 356);
            ucNotify1.TabIndex = 27;
            // 
            // lblKeyword
            // 
            lblKeyword.AutoSize = true;
            lblKeyword.BackColor = Color.Transparent;
            lblKeyword.Location = new Point(83, 105);
            lblKeyword.Name = "lblKeyword";
            lblKeyword.Size = new Size(62, 20);
            lblKeyword.TabIndex = 20;
            lblKeyword.Text = "Từ khóa";
            // 
            // txtKeyword
            // 
            txtKeyword.Location = new Point(170, 98);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.PlaceholderText = "Tên/Biển số xe";
            txtKeyword.Size = new Size(365, 27);
            txtKeyword.TabIndex = 0;
            // 
            // dgvData
            // 
            dgvData.AllowUserToAddRows = false;
            dgvData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(192, 255, 255);
            dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            dgvData.Columns.AddRange(new DataGridViewColumn[] { Column2, Column3, Column8, Column5, Column6, Column11, Column10, Column12, Column1, Column4, Column7, Column9 });
            dgvData.Location = new Point(170, 143);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowHeadersVisible = false;
            dataGridViewCellStyle3.Padding = new Padding(3);
            dgvData.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvData.RowTemplate.Height = 29;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.Size = new Size(457, 193);
            dgvData.TabIndex = 2;
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
            // Column8
            // 
            Column8.HeaderText = "Biển số xe";
            Column8.Name = "Column8";
            Column8.ReadOnly = true;
            Column8.Width = 133;
            // 
            // Column5
            // 
            Column5.HeaderText = "Loại phương tiện";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.Width = 196;
            // 
            // Column6
            // 
            Column6.HeaderText = "Khách hàng";
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            Column6.Width = 146;
            // 
            // Column11
            // 
            Column11.HeaderText = "Mã khách hàng";
            Column11.Name = "Column11";
            Column11.ReadOnly = true;
            Column11.Width = 178;
            // 
            // Column10
            // 
            Column10.HeaderText = "Nhóm khách hàng";
            Column10.Name = "Column10";
            Column10.ReadOnly = true;
            Column10.Width = 205;
            // 
            // Column12
            // 
            Column12.HeaderText = "Hạn sử dụng";
            Column12.Name = "Column12";
            Column12.ReadOnly = true;
            Column12.Width = 159;
            // 
            // Column1
            // 
            Column1.HeaderText = "vehicleId";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Visible = false;
            Column1.Width = 121;
            // 
            // Column4
            // 
            Column4.HeaderText = "vehicleTypeId";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Visible = false;
            Column4.Width = 163;
            // 
            // Column7
            // 
            Column7.HeaderText = "customerId";
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            Column7.Visible = false;
            Column7.Width = 144;
            // 
            // Column9
            // 
            Column9.HeaderText = "customerGroupId";
            Column9.Name = "Column9";
            Column9.ReadOnly = true;
            Column9.Visible = false;
            Column9.Width = 202;
            // 
            // frmSearchPlateNumber
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(894, 496);
            Controls.Add(panelData);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmSearchPlateNumber";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tìm kiếm biển số xe";
            panelData.ResumeLayout(false);
            panelData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelData;
        private ucLoading ucLoading1;
        private Label lblTitle;
        private LblCancel btnCancel1;
        private BtnOk btnOk1;
        private BtnSearch btnSearch;
        private ucNotify ucNotify1;
        private Label lblKeyword;
        private TextBox txtKeyword;
        private DataGridView dgvData;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column11;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewTextBoxColumn Column12;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column9;
    }
}