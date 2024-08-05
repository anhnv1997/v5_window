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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchPlateNumber));
            this.panelData = new System.Windows.Forms.Panel();
            this.ucLoading1 = new iPakrkingv5.Controls.Usercontrols.BuildControls.ucLoading();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCancel1 = new iPakrkingv5.Controls.Controls.Buttons.LblCancel();
            this.btnOk1 = new iPakrkingv5.Controls.Controls.Buttons.BtnOk();
            this.btnSearch = new iPakrkingv5.Controls.Controls.Buttons.BtnSearch();
            this.ucNotify1 = new iPakrkingv5.Controls.Usercontrols.BuildControls.ucNotify();
            this.lblKeyword = new System.Windows.Forms.Label();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnWriteInOut = new iPakrkingv5.Controls.Controls.Buttons.BtnWriteInOut();
            this.panelData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // panelData
            // 
            this.panelData.Controls.Add(this.btnWriteInOut);
            this.panelData.Controls.Add(this.ucLoading1);
            this.panelData.Controls.Add(this.lblTitle);
            this.panelData.Controls.Add(this.btnCancel1);
            this.panelData.Controls.Add(this.btnOk1);
            this.panelData.Controls.Add(this.btnSearch);
            this.panelData.Controls.Add(this.ucNotify1);
            this.panelData.Controls.Add(this.lblKeyword);
            this.panelData.Controls.Add(this.txtKeyword);
            this.panelData.Controls.Add(this.dgvData);
            this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelData.Location = new System.Drawing.Point(0, 0);
            this.panelData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(782, 372);
            this.panelData.TabIndex = 0;
            // 
            // ucLoading1
            // 
            this.ucLoading1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ucLoading1.Language = IPaking.Ultility.TextManagement.EmLanguage.Vietnamese;
            this.ucLoading1.Location = new System.Drawing.Point(24, 237);
            this.ucLoading1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucLoading1.Message = "Preparing to download";
            this.ucLoading1.Name = "ucLoading1";
            this.ucLoading1.Size = new System.Drawing.Size(343, 141);
            this.ucLoading1.TabIndex = 28;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(73, 26);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(367, 45);
            this.lblTitle.TabIndex = 26;
            this.lblTitle.Text = "Danh sách phương tiện";
            // 
            // btnCancel1
            // 
            this.btnCancel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel1.AutoSize = true;
            this.btnCancel1.Location = new System.Drawing.Point(483, 263);
            this.btnCancel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel1.Name = "btnCancel1";
            this.btnCancel1.Size = new System.Drawing.Size(77, 25);
            this.btnCancel1.TabIndex = 4;
            this.btnCancel1.Text = "Đóng";
            // 
            // btnOk1
            // 
            this.btnOk1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk1.AutoSize = true;
            this.btnOk1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnOk1.Location = new System.Drawing.Point(429, 266);
            this.btnOk1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOk1.Name = "btnOk1";
            this.btnOk1.Size = new System.Drawing.Size(56, 22);
            this.btnOk1.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSize = true;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Location = new System.Drawing.Point(490, 74);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(91, 30);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "lblSearch1";
            // 
            // ucNotify1
            // 
            this.ucNotify1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ucNotify1.Location = new System.Drawing.Point(507, 72);
            this.ucNotify1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucNotify1.MaximumSize = new System.Drawing.Size(291, 267);
            this.ucNotify1.Message = "Nội dung thông báo";
            this.ucNotify1.MinimumSize = new System.Drawing.Size(291, 267);
            this.ucNotify1.Name = "ucNotify1";
            this.ucNotify1.NotiType = iPakrkingv5.Controls.Usercontrols.BuildControls.ucNotify.EmNotiType.Information;
            this.ucNotify1.Size = new System.Drawing.Size(291, 267);
            this.ucNotify1.TabIndex = 27;
            // 
            // lblKeyword
            // 
            this.lblKeyword.AutoSize = true;
            this.lblKeyword.BackColor = System.Drawing.Color.Transparent;
            this.lblKeyword.Location = new System.Drawing.Point(73, 79);
            this.lblKeyword.Name = "lblKeyword";
            this.lblKeyword.Size = new System.Drawing.Size(49, 15);
            this.lblKeyword.TabIndex = 20;
            this.lblKeyword.Text = "Từ khóa";
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(149, 74);
            this.txtKeyword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.PlaceholderText = "Tên/Biển số xe";
            this.txtKeyword.Size = new System.Drawing.Size(320, 23);
            this.txtKeyword.TabIndex = 0;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column8,
            this.Column5,
            this.Column6,
            this.Column11,
            this.Column10,
            this.Column12,
            this.Column1,
            this.Column4,
            this.Column7,
            this.Column9});
            this.dgvData.Location = new System.Drawing.Point(149, 107);
            this.dgvData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(3);
            this.dgvData.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvData.RowTemplate.Height = 29;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(400, 145);
            this.dgvData.TabIndex = 2;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "STT";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 76;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Tên";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 74;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Biển số xe";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 133;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Loại phương tiện";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 196;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Khách hàng";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 146;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Mã khách hàng";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 178;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Nhóm khách hàng";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 205;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Hạn sử dụng";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 159;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "vehicleId";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            this.Column1.Width = 121;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "vehicleTypeId";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            this.Column4.Width = 163;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "customerId";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            this.Column7.Width = 144;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "customerGroupId";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Visible = false;
            this.Column9.Width = 202;
            // 
            // btnWriteInOut
            // 
            this.btnWriteInOut.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnWriteInOut.Location = new System.Drawing.Point(623, 79);
            this.btnWriteInOut.Name = "btnWriteInOut";
            this.btnWriteInOut.Size = new System.Drawing.Size(93, 32);
            this.btnWriteInOut.TabIndex = 29;
            this.btnWriteInOut.Text = "btnWriteInOut1";
            this.btnWriteInOut.UseVisualStyleBackColor = true;
            // 
            // frmSearchPlateNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 372);
            this.Controls.Add(this.panelData);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmSearchPlateNumber";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm biển số xe";
            this.panelData.ResumeLayout(false);
            this.panelData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

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
        private BtnWriteInOut btnWriteInOut;
    }
}